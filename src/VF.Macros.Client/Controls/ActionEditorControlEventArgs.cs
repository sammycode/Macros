using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model = VF.Macros.Common.Models;

namespace VF.Macros.Client.Controls
{
    
    /// <summary>
    /// The Action Editor Control Event Arguments
    /// </summary>
    public class ActionEditorControlEventArgs : EventArgs
    {

        /// <summary>
        /// The Action
        /// </summary>
        public Model.Macro.Action Action { get; set; }

    }
}
