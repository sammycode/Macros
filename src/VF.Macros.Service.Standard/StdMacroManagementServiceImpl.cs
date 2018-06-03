using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data;
using VF.Macros.External;
using DataContract = VF.Macros.Common.Models;
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
        /// The Macro Assembler
        /// </summary>
        private IMacroAssembler _macroAssembler;

        /// <summary>
        /// Initialize Standard Macro Management Service Implementation
        /// </summary>
        /// <param name="dataRepository">The Data Repository</param>
        /// <param name="macroAssembler">The Macro Assembler</param>
        public StdMacroManagementServiceImpl(IDataRepository dataRepository, IMacroAssembler macroAssembler)
        {
            try
            {
                _dataRepository = dataRepository;
                _macroAssembler = macroAssembler;
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
        public IEnumerable<DataContract.Macro.Macro> GetAllMacros()
        {
            try
            {
                //We are not assembling yet...
                var macros = _dataRepository.MacroRepository.GetAllMacros();
                var results = new List<DataContract.Macro.Macro>();
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
        /// <param name="qualifiedName">The Qualified Macro Name</param>
        /// <returns>The Macro</returns>
        public IEnumerable<DataContract.Macro.Macro> GetMacroByQualifiedName(string qualifiedName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(qualifiedName))
                {
                    throw new ArgumentNullException("qualifiedName");
                }
                var macros = _dataRepository.MacroRepository.GetMacroByQualifiedName(qualifiedName);
                var results = new List<DataContract.Macro.Macro>();
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
        public IEnumerable<DataContract.Macro.Macro> GetMacrosByLabel(DataContract.Metadata.Label label)
        {
            try
            {

                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                var macros = _dataRepository.MacroRepository.GetMacrosByLabelID(label.ID);
                var results = new List<DataContract.Macro.Macro>();
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
        public void CreateMacro(DataContract.Macro.Macro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                //TODO: Implement Create Macro with new model

                throw new NotImplementedException();

                //_dataRepository.MacroRepository.CreateMacro(
                //        macro.LabelID,
                //        macro.QualifiedName,
                //        macro.Name,
                //        macro.ListOrder,
                //        DateTime.Now,
                //        macro.ExternalProvider,
                //        true,
                //        "1",
                //        "0",
                //        "0",
                //        "0#0#0",
                //        "1");

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
        public void UpdateMacro(DataContract.Macro.Macro macro)
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
        public void DeleteMacro(DataContract.Macro.Macro macro)
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
        private DataContract.Macro.Macro BuildMacroDataContract(DataEntity.IMacro macroEntity)
        {
            try
            {
                if (macroEntity == null)
                {
                    throw new ArgumentNullException("macroEntity");
                }

                //TODO: Implement this after refactor
                throw new NotImplementedException();

                //var macro = new DataContract.Macro.Macro
                //{
                //    LabelID = macroEntity.LabelID,
                //    QualifiedName = macroEntity.QualifiedName,
                //    Name = macroEntity.Name,
                //    ListOrder = macroEntity.ListOrder,
                //    Enabled = macroEntity.Enabled,
                //    ExternalProvider = macroEntity.ExternalProvider
                //};

                ////TODO: We worrying about the assembly yet?

                //return macro;
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
