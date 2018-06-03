using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.External.Nox.Models.Json
{

    /// <summary>
    /// The Nox Macro Header Model
    /// </summary>
    internal class NoxMacroHeaderModel
    {

        /// <summary>
        /// The Macro Name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// New Macro
        /// </summary>
        public string New { get; set; }

        /// <summary>
        /// The PlaySet Configuration
        /// </summary>
        public NoxMacroPlaySetModel playSet { get; set; }

        /// <summary>
        /// The Priority
        /// </summary>
        /// <remarks>
        /// This appears to map to the order it appears in the list
        /// </remarks>
        public string priority { get; set; }

        /// <summary>
        /// The Create Date/Time (This is stored in epoch)
        /// </summary>
        public string time { get; set; }

    }

}
