using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.Service
{

    /// <summary>
    /// The Label Management Service Contract
    /// </summary>
    public interface ILabelManagementService
    {

        /// <summary>
        /// Get All Labels
        /// </summary>
        /// <returns>The Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetAllLabels();

        /// <summary>
        /// Get Top Level Labels
        /// </summary>
        /// <returns>The Top Level Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetTopLevelLabels();

        /// <summary>
        /// Get Child Labels
        /// </summary>
        /// <param name="parentLabel">The Parent Label</param>
        /// <returns>The Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetChildLabels(DataContract.Metadata.Label parentLabel);

        /// <summary>
        /// Create Label
        /// </summary>
        /// <param name="label">The Label</param>
        DataContract.Metadata.Label CreateLabel(DataContract.Metadata.Label label);

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label">The Label</param>
        void UpdateLabel(DataContract.Metadata.Label label);

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="label">The Label</param>
        void DeleteLabel(DataContract.Metadata.Label label);

    }
}
