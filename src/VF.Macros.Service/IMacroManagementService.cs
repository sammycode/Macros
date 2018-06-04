using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.Service
{

    /// <summary>
    /// The Macro Management Service Contract
    /// </summary>
    public interface IMacroManagementService
    {

        /// <summary>
        /// Gets All Macros
        /// </summary>
        /// <returns>The Macros</returns>
        IEnumerable<DataContract.Macro.Macro> GetAllMacros();

        /// <summary>
        /// Gets Macro by Qualified Name
        /// </summary>
        /// <param name="qualifiedName">The Macro Qualfiied Name</param>
        /// <returns>The Macro</returns>
        IEnumerable<DataContract.Macro.Macro> GetMacroByQualifiedName(string qualifiedName);

        /// <summary>
        /// Get Macros by Label
        /// </summary>
        /// <param name="label">The Label</param>
        /// <returns></returns>
        IEnumerable<DataContract.Macro.Macro> GetMacrosByLabel(DataContract.Metadata.Label label);

        /// <summary>
        /// Create Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <remarks>The Created Macro</remarks>
        DataContract.Macro.Macro CreateMacro(DataContract.Macro.Macro macro);

        /// <summary>
        /// Update Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void UpdateMacro(DataContract.Macro.Macro macro);

        /// <summary>
        /// Delete Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void DeleteMacro(DataContract.Macro.Macro macro);

    }
}
