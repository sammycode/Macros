using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.Client.Controls
{

    /// <summary>
    /// The Label Event Arguments
    /// </summary>
    public class LabelEventArgs : EventArgs
    {

        /// <summary>
        /// The Label
        /// </summary>
        public DataContract.Metadata.Label Label { get; set; }

    }
}
