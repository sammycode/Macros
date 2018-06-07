using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data;
using VF.Macros.External;
using Models = VF.Macros.Common.Models;
using DataEntity = VF.Macros.Data.Entity;

namespace VF.Macros.Service.Standard
{

    /// <summary>
    /// The Standard Macro Management Service Implementation
    /// </summary>
    /// <remarks>
    /// TODO: This will largely need to be re-written to fit the heavily changing model.
    /// 
    /// </remarks>
    public sealed class StdMacroManagementServiceImpl : IMacroManagementService
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(StdMacroManagementServiceImpl));

        /// <summary>
        /// The Data Repository
        /// </summary>
        private IDataRepository _dataRepository;

        /// <summary>
        /// Initialize Standard Macro Management Service Implementation
        /// </summary>
        /// <param name="dataRepository">The Data Repository</param>
        public StdMacroManagementServiceImpl(IDataRepository dataRepository)
        {
            try
            {
                _dataRepository = dataRepository;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Standard Macro Management Service Implementation", caught);
                throw;
            }
        }

        /// <summary>
        /// Get All Macros
        /// </summary>
        /// <returns>The Macros</returns>
        public IEnumerable<Models.Macro.Macro> GetAllMacros()
        {
            try
            {
                //We are not assembling yet...
                var macros = _dataRepository.MacroRepository.GetAllMacros();
                var results = new List<Models.Macro.Macro>();
                macros.ToList().ForEach(me => results.Add(BuildMacroDataContract(me)));
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting All Macros", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro by Qualified Name
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <param name="qualifiedName">The Qualified Macro Name</param>
        /// <returns>The Macro</returns>
        public IEnumerable<Models.Macro.Macro> GetMacroByQualifiedName(Models.Metadata.ExternalProvider provider, string qualifiedName)
        {
            try
            {
                if (provider == null)
                {
                    throw new ArgumentNullException("provider");
                }
                if (string.IsNullOrWhiteSpace(qualifiedName))
                {
                    throw new ArgumentNullException("qualifiedName");
                }
                var macros = _dataRepository.MacroRepository.GetMacroByQualifiedName(provider.Code, qualifiedName);
                var results = new List<Models.Macro.Macro>();
                macros.ToList().ForEach(me => results.Add(BuildMacroDataContract(me)));
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro by Qualified Name", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macros by Label
        /// </summary>
        /// <param name="label">The Label</param>
        /// <returns></returns>
        public IEnumerable<Models.Macro.Macro> GetMacrosByLabel(Models.Metadata.Label label)
        {
            try
            {

                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                var macros = _dataRepository.MacroRepository.GetMacrosByLabelID(label.ID);
                var results = new List<Models.Macro.Macro>();
                macros.ToList().ForEach(me => results.Add(BuildMacroDataContract(me)));
                return results;

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macros by Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Macro
        /// </summary>
        /// <param name="macro">The Macro Data Contract</param>
        /// <remarks>The Created Macro</remarks>
        public Models.Macro.Macro CreateMacro(Models.Macro.Macro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                //TODO: Implement Create Macro with new model

                var newMacro = _dataRepository.MacroRepository.CreateMacro(
                        macro.Label == null ? null as long? : macro.Label.ID,
                        macro.Name,
                        macro.ListOrder, 
                        DateTime.UtcNow,
                        macro.Enabled
                    );

                foreach (var macroAction in macro.Assembly)
                {
                    _dataRepository.MacroRepository.CreateMacroAssemblyAction(newMacro,
                        macroAction.ActionType == Models.Macro.ActionType.Screen ? 0 : 1,
                        macroAction.ScreenResolution.Y,
                        macroAction.ScreenResolution.X,
                        macroAction.ScreenPosition.X,
                        macroAction.ScreenPosition.Y,
                        macroAction.ActionDelay
                        );
                }

                

                return BuildMacroDataContract(newMacro);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Macro
        /// </summary>
        /// <param name="macro">The Macro Data Contract</param>
        public void UpdateMacro(Models.Macro.Macro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                //TODO: Implement this since re-structure
                throw new NotImplementedException();

                ///*
                // * First need to lookup the macro entity from the database, using the qualified name
                // */
                //var macroEntity = _dataRepository.MacroRepository.GetMacroByQualifiedName(macro.QualifiedName).FirstOrDefault();
                //if (macroEntity == null)
                //{
                //    throw new ApplicationException("Macro does not exist");
                //}
                ///*
                // * Then we update the entity accordingly and persist the changes in the repository
                // */
                //macroEntity.LabelID = macro.LabelID;
                //macroEntity.Name = macro.Name;
                //macroEntity.ListOrder = macro.ListOrder;
                //macroEntity.ExternalProvider = macro.ExternalProvider;
                //macroEntity.Enabled = macro.Enabled;
                //_dataRepository.MacroRepository.UpdateMacro(macroEntity);

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Deleting Macro
        /// </summary>
        /// <param name="macro">The Macro Data Contract</param>
        public void DeleteMacro(Models.Macro.Macro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                //TODO: Implement this after refactor

                throw new NotImplementedException();

                ///*
                // * First need to lookup the macro entity from the database, using the qualified name
                // */
                //var macroEntity = _dataRepository.MacroRepository.GetMacroByQualifiedName(macro.QualifiedName).FirstOrDefault();
                //if (macroEntity == null)
                //{
                //    throw new ApplicationException("Macro does not exist");
                //}

                ///*
                // * Then just remove the Macro
                // */
                //_dataRepository.MacroRepository.DeleteMacro(macroEntity);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting Macro", caught);
                throw;
            }
        }

        #region [Data Contract Assembly Helpers]

        /// <summary>
        /// Build Macro Data Contract
        /// </summary>
        /// <param name="macroEntity">The Macro Data Entity</param>
        /// <returns>The Macro Data Contract</returns>
        private Models.Macro.Macro BuildMacroDataContract(DataEntity.IMacro macroEntity)
        {
            try
            {
                if (macroEntity == null)
                {
                    throw new ArgumentNullException("macroEntity");
                }

                Models.Metadata.Label label = null;
                if (macroEntity.LabelID != null)
                {
                    var labelResults = _dataRepository.LabelRepository.GetLabelByID(macroEntity.LabelID.Value).FirstOrDefault();
                    if (labelResults != null) {
                        label = new Models.Metadata.Label { ID = labelResults.ID, ParentID = labelResults.ParentID, Name = labelResults.Name };
                    }
                }

                var macro = new Models.Macro.Macro
                {
                    ID = macroEntity.ID,
                    Label = label,
                    Name = macroEntity.Name,
                    ListOrder = macroEntity.ListOrder,
                    Enabled = macroEntity.Enabled
                };

                return macro;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Macro Data Contract", caught);
                throw;
            }
        }

        #endregion

    }
}
