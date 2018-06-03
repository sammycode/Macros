using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Model = VF.Macros.Common.Models;
using VF.Macros.Data;
using VF.Macros.External;
using VF.Macros.Service;


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
        /// The Macro Importer
        /// </summary>
        private IMacroImporter _macroImporter;

        /// <summary>
        /// The Macro Assembler
        /// </summary>
        private IMacroAssembler _macroAssembler;

        /// <summary>
        /// The Label Management Service
        /// </summary>
        private ILabelManagementService _labelManagementService;

        /// <summary>
        /// Initialize Standard External Integration Service Implementation
        /// </summary>
        /// <param name="dataRepository">The Data Repository</param>
        /// <param name="macroImporter">The Macro Importer</param>
        /// <param name="labelManagementService">The Label Management Service</param>
        /// <param name="macroAssembler">The Macro Assembler</param>
        public StdExternalIntegrationServiceImpl(IDataRepository dataRepository, IMacroImporter macroImporter, ILabelManagementService labelManagementService,
            IMacroAssembler macroAssembler)
        {
            try
            {
                _dataRepository = dataRepository;
                _macroImporter = macroImporter;
                _labelManagementService = labelManagementService;
                _macroAssembler = macroAssembler;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Standard External Integration Service Implementation", caught);
                throw;
            }
        }

        /// <summary>
        /// Import Macros
        /// </summary>
        public void ImportMacros()
        {
            try
            {

                //TODO: Come back and Implement this

                throw new NotImplementedException();
                //logger.Info($"Importing Macros using External Provider: {_macroImporter.ExternalProvider}");
                //var importLabel = GetExternalProviderImportLabel();
                //var importedMacros = _macroImporter.ImportMacros();

                //foreach (var importedMacro in importedMacros)
                //{

                //    var existingMacro = _dataRepository.MacroRepository.GetMacroByQualifiedName(importedMacro.QualifiedName).FirstOrDefault();
                //    if (existingMacro == null)
                //    {
                //        // This will insert the macro, but we should see if we have it already
                //        _dataRepository.MacroRepository.CreateMacro(
                //            importLabel.ID,
                //            importedMacro.QualifiedName,
                //            importedMacro.FriendlyName,
                //            importedMacro.ListOrder,
                //            importedMacro.CreateDate,
                //            _macroImporter.ExternalProvider,
                //            true,
                //            importedMacro.Accelerator,
                //            importedMacro.Interval,
                //            importedMacro.Mode,
                //            importedMacro.PlaySeconds,
                //            importedMacro.RepeatTimes);
                //        //We need to create macro source more than likely...
                //        existingMacro = _dataRepository.MacroRepository.GetMacroByQualifiedName(importedMacro.QualifiedName).FirstOrDefault();
                //        if (existingMacro == null)
                //        {
                //            throw new ApplicationException("Unable to create macro");
                //        }
                //        logger.Info($"Imported New Macro - {importedMacro.QualifiedName} {importedMacro.FriendlyName}");
                //    }
                //    else
                //    {
                //        existingMacro.Name = importedMacro.FriendlyName;
                //        existingMacro.ListOrder = importedMacro.ListOrder;
                //        existingMacro.ExternalProvider = _macroImporter.ExternalProvider;
                //        existingMacro.Enabled = true;
                //        existingMacro.Accelerator = importedMacro.Accelerator;
                //        existingMacro.Interval = importedMacro.Interval;
                //        existingMacro.Mode = importedMacro.Mode;
                //        existingMacro.PlaySeconds = importedMacro.PlaySeconds;
                //        existingMacro.RepeatTimes = importedMacro.RepeatTimes;
                //        _dataRepository.MacroRepository.UpdateMacro(existingMacro);

                //        logger.Info($"Updated Existing Macro - {existingMacro.QualifiedName} {existingMacro.Name}");
                //    }
                    
                //    var existingMacroSource = _dataRepository.MacroRepository.GetMacroSource(existingMacro).FirstOrDefault();
                //    if (existingMacroSource == null)
                //    {
                //        _dataRepository.MacroRepository.CreateMacroSource(existingMacro, importedMacro.MacroSource);
                //        existingMacroSource = _dataRepository.MacroRepository.GetMacroSource(existingMacro).FirstOrDefault();
                //        if (existingMacroSource == null)
                //        {
                //            throw new ApplicationException("Unable to Create Macro Source");
                //        }
                //        else
                //        {
                //            existingMacroSource.MacroSource = importedMacro.MacroSource;
                //            _dataRepository.MacroRepository.UpdateMacroSource(existingMacroSource);
                //        }
                //    }
                //}
                //logger.Info("Import Complete");
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Importing Macros", caught);
            }
        }

        /// <summary>
        /// Build Macro Action Assembly
        /// </summary>
        /// <param name="source">The External Macro Source</param>
        /// <returns>The Macro Action Assembly</returns>
        public IEnumerable<Model.Macro.Action> BuildMacroActionAssembly(string source)
        {
            try
            {
                var assembly = _macroAssembler.Build(source);
                return assembly;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Macro Action Assembly", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro Action Assembly Source
        /// </summary>
        /// <param name="assembly">The Macro Action Assembly</param>
        /// <returns>The Macro Action Assembly Source</returns>
        public string GetMacroActionAssemblySource(IEnumerable<Model.Macro.Action> assembly)
        {
            try
            {
                var assemblySource = _macroAssembler.Disassemble(assembly);
                return assemblySource;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Action Assembly Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Export Macros
        /// </summary>
        public void ExportMacros()
        {
            throw new NotImplementedException();
        }

        #region [Label Helpers]

        /// <summary>
        /// Get Import Label
        /// </summary>
        /// <returns>The Import Label</returns>
        private Model.Metadata.Label GetImportLabel()
        {
            try
            {
                var labels = _labelManagementService.GetAllLabels();
                var importLabel = (from il in labels
                                  where il.ParentID == null && il.Name == "Imported"
                                  select il).FirstOrDefault();
                if (importLabel == null)
                {
                    _labelManagementService.CreateLabel(new Model.Metadata.Label { ParentID = null, Name = "Imported" });
                    labels = _labelManagementService.GetAllLabels();
                    importLabel = (from il in labels
                                   where il.ParentID == null && il.Name == "Imported"
                                   select il).FirstOrDefault();
                    if (importLabel == null)
                    {
                        throw new ApplicationException("Unable to create Import Label");
                    }
                }
                return importLabel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Import Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Get External Provider Import Label
        /// </summary>
        /// <returns>The External Provider Import Label</returns>
        private Model.Metadata.Label GetExternalProviderImportLabel()
        {
            try
            {

                var labels = _labelManagementService.GetAllLabels();
                var importLabel = GetImportLabel();
                var externalProviderImportLabel = (from il in labels
                                   where il.ParentID == importLabel.ID && il.Name == _macroImporter.ExternalProvider
                                   select il).FirstOrDefault();
                if (externalProviderImportLabel == null)
                {
                     _labelManagementService.CreateLabel(new Model.Metadata.Label { ParentID = importLabel.ID, Name = _macroImporter.ExternalProvider });
                    labels = _labelManagementService.GetAllLabels();
                    externalProviderImportLabel = (from il in labels
                                   where il.ParentID == importLabel.ID && il.Name == _macroImporter.ExternalProvider
                                                   select il).FirstOrDefault();
                    if (externalProviderImportLabel == null)
                    {
                        throw new ApplicationException("Unable to create External Provider Import Label");
                    }
                }
                return externalProviderImportLabel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting External Provider Import Label", caught);
                throw;
            }
        }

        #endregion

        

    }
}
