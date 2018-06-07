using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Model = VF.Macros.Common.Models;
using VF.Macros.Data;
using VF.Macros.External;


namespace VF.Macros.Service.Standard
{

    /// <summary>
    /// The Standard External Integration Service Implementation
    /// </summary>
    /// <remarks>
    /// TODO: This will largely have to be re-written due to the heavily changing model
    /// </remarks>
    public class StdExternalIntegrationServiceImpl : IExternalIntegrationService
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(StdExternalIntegrationServiceImpl));

        /// <summary>
        /// The Data Repository
        /// </summary>
        private IDataRepository _dataRepository;

        /// <summary>
        /// The Installed External Providers
        /// </summary>
        private Dictionary<string, IProvider> _installedProviders = new Dictionary<string, IProvider>();

        /// <summary>
        /// The Label Management Service
        /// </summary>
        private ILabelManagementService _labelManagementService;

        /// <summary>
        /// The Macro Manager Service
        /// </summary>
        private IMacroManagementService _macroManagementService;

        /// <summary>
        /// Initialize Standard External Integration Service Implementation
        /// </summary>
        /// <param name="dataRepository">The Data Repository</param>
        /// <param name="installedProviders">The Installed Providers</param>
        /// <param name="labelManagementService">The Label Management Service</param>
        /// <param name="macroManagementService">The Macro Management Service</param>
        public StdExternalIntegrationServiceImpl(
            IDataRepository dataRepository, 
            IProvider[] installedProviders,
            ILabelManagementService labelManagementService, 
            IMacroManagementService macroManagementService)
        {
            try
            {
                _dataRepository = dataRepository;
                _labelManagementService = labelManagementService;
                _macroManagementService = macroManagementService;
                installedProviders.ToList().ForEach(p => _installedProviders.Add(p.ProviderCode, p));

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Standard External Integration Service Implementation", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Installed External Providers
        /// </summary>
        /// <returns>The Installed External Providers</returns>
        public IEnumerable<Model.Metadata.ExternalProvider> GetInstalledProviders()
        {
            try
            {
                if (_installedProviders == null)
                {
                    throw new ApplicationException("No External Providers Installed");
                }

                var externalProviders = new List<Model.Metadata.ExternalProvider>();
                foreach (var provider in _installedProviders)
                {
                    externalProviders.Add(BuildExternalProviderModel(provider.Value));
                }
                return externalProviders;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Installed Providers", caught);
                throw;
            }
        }

        /// <summary>
        /// Build Macro Action Assembly
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <param name="label">The Label to Associate new Macro With</param>
        /// <param name="source">The External Macro Source</param>
        /// <returns>The Macro</returns>
        public Model.Macro.Macro BuildMacroFromSource(Model.Metadata.ExternalProvider provider, Model.Metadata.Label label, string source)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                if (string.IsNullOrWhiteSpace(source))
                {
                    throw new ArgumentNullException("source");
                }
                // The label should be able to be null, no problem.  This would cause new macro to not be categorized with anything, it would show up under all macros

                var externalProvider = _installedProviders[provider.Code];

                //Create Macro Header
                var macro = new Model.Macro.Macro();
                macro.Label = label;
                macro.ListOrder = 0;
                macro.Name = "New Macro";

                //Create External source, and associate source and macro
                var externalSource = new Model.Macro.MacroExternalSource();
                macro.ExternalSources.Add(externalSource);
                externalSource.Macro = macro;

                externalSource.CreateDate = DateTime.UtcNow;
                externalSource.Provider = provider;
                externalSource.QualifiedName = externalProvider.GenerateQualifiedName();
                externalSource.MacroSource = source;

                var assembler = externalProvider.Assembler;
                try
                {
                    var assembly = assembler.Build(source);
                    var orderedAssembly = assembly.OrderBy(ma => ma.ActionDelay);
                    orderedAssembly.ToList().ForEach(ma => macro.Assembly.Add(ma));
                    externalSource.DesignerSupported = true;
                }
                catch (Exception assemblerCaught)
                {
                    logger.Warn("Macro Source Is Not Understood", assemblerCaught);
                    externalSource.DesignerSupported = false;
                }
                return macro;
            }
            catch (Exception caught)
            {
                logger.Error("unexpected Error Building Macro From Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Rebuild Macro from Source
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <param name="macro">The Macro to Rebuild</param>
        /// <param name="source">The New Macro Source</param>
        /// <returns>The Rebuilt Macro</returns>
        public Model.Macro.Macro ReBuildMacroFromSource(Model.Metadata.ExternalProvider provider, Model.Macro.Macro macro, string source)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }
                if (string.IsNullOrWhiteSpace(source))
                {
                    throw new ArgumentNullException("source");
                }

                var externalProvider = _installedProviders[provider.Code];

                /*
                 * We look to see if the macro already has an external source for this provider
                 * if it does we can update that, and if it doesn't we can simply create a new one for
                 * the provider.
                 */
                var externalSource = (from es in macro.ExternalSources
                                     where es.Provider.Code == provider.Code
                                     select es).FirstOrDefault();
                if (externalSource == null)
                {
                    externalSource = new Model.Macro.MacroExternalSource();
                    macro.ExternalSources.Add(externalSource);
                    externalSource.Macro = macro;

                    externalSource.CreateDate = DateTime.UtcNow;
                    externalSource.Provider = provider;
                    externalSource.QualifiedName = externalProvider.GenerateQualifiedName();
                }
                externalSource.MacroSource = source;

                macro.Assembly.Clear();

                //TODO: There may be a need to re-generate the source from the assembly for each other provider registered with this macro
                //This is low priority because at the moment only Nox is offially supported
                var assembler = externalProvider.Assembler;
                try
                {
                    var assembly = assembler.Build(source);
                    var orderedAssembly = assembly.OrderBy(ma => ma.ActionDelay);
                    orderedAssembly.ToList().ForEach(ma => macro.Assembly.Add(ma));
                    externalSource.DesignerSupported = true;
                }
                catch (Exception assemblerCaught)
                {
                    logger.Warn("Macro Source Is Not Understood", assemblerCaught);
                    externalSource.DesignerSupported = false;
                }
                
                return macro;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Rebuilding Macro from Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Import Macros
        /// </summary>
        /// <param name="provider">The Provider</param>
        public void ImportMacros(Model.Metadata.ExternalProvider provider)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }

                var externalProvider = _installedProviders[provider.Code];
                var importer = externalProvider.Importer;
                var externalMacroModels = importer.ImportMacros();

                foreach (var externalMacroModel in externalMacroModels)
                {
                     var importedMacroModel = BuildMacroFromExternalMacroModel(externalProvider, externalMacroModel);
                    //TODO: Insert or Update imported macro model to the database
                }
                
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Importing Macros", caught);
                throw;
            }
        }

        /// <summary>
        /// Export Macros (overwrite)
        /// </summary>
        /// <param name="provider">The Provider</param>
        public void ExportMacros(Model.Metadata.ExternalProvider provider)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Macro Action Assembly Source
        /// </summary>
        /// <param name="providerCode">The Provider</param>
        /// <param name="macro">The Macro</param>
        /// <returns>The Updated Macro</returns>
        public Model.Macro.Macro RegenerateMacroSource(Model.Metadata.ExternalProvider provider, Model.Macro.Macro macro)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }
                var externalProvider = _installedProviders[provider.Code];

                var externalSource = (from es in macro.ExternalSources
                                      where es.Provider.Code == provider.Code
                                      select es).FirstOrDefault();
                if (externalSource == null)
                {
                    externalSource = new Model.Macro.MacroExternalSource();
                    macro.ExternalSources.Add(externalSource);
                    externalSource.Macro = macro;

                    externalSource.CreateDate = DateTime.UtcNow;
                    externalSource.Provider = provider;
                    externalSource.QualifiedName = externalProvider.GenerateQualifiedName();
                }

                var assembler = externalProvider.Assembler;
                var dissassembledSource = assembler.Disassemble(macro.Assembly);
                externalSource.MacroSource = dissassembledSource;

                return macro;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Regenerating Macro Source", caught);
                throw;
            }
        }

        #region [Model Building Helpers]

        /// <summary>
        /// Build External Provider Model
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <returns>The External Provider Model</returns>
        private Model.Metadata.ExternalProvider BuildExternalProviderModel(IProvider provider)
        {
            try
            {
                var externalProviderModel = new Model.Metadata.ExternalProvider();
                externalProviderModel.Code = provider.ProviderCode;
                externalProviderModel.Name = provider.ProviderName;
                return externalProviderModel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building External Provider Model", caught);
                throw;
            }
        }

        #endregion

        #region [Label Helpers]



        #endregion

        #region [Macro Model Helpers]

        /// <summary>
        /// Build Macro from External Macro Model
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <param name="externalMacroModel">The External Macro Model</param>
        /// <returns>The Macro</returns>
        private Model.Macro.Macro BuildMacroFromExternalMacroModel(IProvider provider, External.Models.IExternalMacroModel externalMacroModel)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                if (externalMacroModel == null)
                {
                    throw new ArgumentNullException("externalMacroModel");
                }
                var externalProvider = _installedProviders[provider.ProviderCode];
                var externalProviderModel = BuildExternalProviderModel(externalProvider);
                var existingMacro = _macroManagementService.GetMacroByQualifiedName(externalProviderModel, externalMacroModel.QualifiedName).FirstOrDefault();

                //If the existing macro is null, we must build it fresh
                if (existingMacro == null)
                {
                    existingMacro = new Model.Macro.Macro();
                }
                existingMacro.Name = externalMacroModel.FriendlyName;
                existingMacro.ListOrder = externalMacroModel.ListOrder;
                
                /*
                 * Now that we have an existing macro, either newly created or updated
                 * we should attempt to pull the external source.
                 * This will typically be an update for an existing macro, or a new external source if
                 * this is a newly created macro
                 */
                var externalSource = (from es in existingMacro.ExternalSources
                                      where es.Provider.Code == provider.ProviderCode
                                      select es).FirstOrDefault();
                if (externalSource == null)
                {
                    externalSource = new Model.Macro.MacroExternalSource();
                    existingMacro.ExternalSources.Add(externalSource);
                    externalSource.Macro = existingMacro;
                    externalSource.Provider = BuildExternalProviderModel(externalProvider);
                }
                externalSource.QualifiedName = externalMacroModel.QualifiedName;
                externalSource.CreateDate = externalMacroModel.CreateDate;
                externalSource.Accelerator = externalMacroModel.Accelerator;
                externalSource.Interval = externalMacroModel.Interval;
                externalSource.Mode = externalMacroModel.Mode;
                externalSource.PlaySeconds = externalMacroModel.PlaySeconds;
                externalSource.RepeatTimes = externalMacroModel.RepeatTimes;

                externalSource.MacroSource = externalMacroModel.MacroSource;

                /*
                 * Regenerate the macro assembly
                 */

                existingMacro.Assembly.Clear();
                var assembler = externalProvider.Assembler;
                try
                {
                    var assembly = assembler.Build(externalSource.MacroSource);
                    var orderedAssembly = assembly.OrderBy(ma => ma.ActionDelay);
                    orderedAssembly.ToList().ForEach(ma => existingMacro.Assembly.Add(ma));
                    externalSource.DesignerSupported = true;
                }
                catch (Exception assemblerCaught)
                {
                    logger.Warn("Macro Source Is Not Understood", assemblerCaught);
                    externalSource.DesignerSupported = false;
                }

                //TODO: Consider if we will have to ever support or update other external providers

                return existingMacro;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Macro from External Macro Model", caught);
                throw;
            }
        }

        #endregion

        //#region [External Source Helpers]

        ///// <summary>
        ///// Build Macro External Source 
        ///// </summary>
        ///// <param name="provider">The External Provider</param>
        ///// <param name="source">The Macro Source</param>
        ///// <returns>The Model</returns>
        //private Model.Macro.MacroExternalSource BuildMacroExternalSource(IProvider provider, string source)
        //{
        //    try
        //    {
        //        // TODO: Allow Provider to Emit A Macro External Source
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception caught)
        //    {
        //        logger.Error("Unexpected Error Building Macro External Source", caught);
        //        throw;
        //    }
        //}

        //#endregion

    }
}
