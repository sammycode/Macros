using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Common.Models.Macro
{

    /// <summary>
    /// The Macro Data Contract
    /// </summary>
    public class Macro
    {

        /// <summary>
        /// The Macro ID
        /// </summary>
        /// <remarks>
        /// I think the Macro Identifier is going to be super important now that
        /// the primary way of keying them will no longer be by the 'Qualified Name', 
        /// which was specific to the external provider
        /// </remarks>
        public long ID { get; set; }

        /// <summary>
        /// The Label
        /// </summary>
        public Metadata.Label Label { get; set; }

        /// <summary>
        /// The Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// The Enabled Flag
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The External Sources
        /// </summary>
        public List<MacroExternalSource> ExternalSources { get; set; }

        /// <summary>
        /// The Macro Assembly
        /// </summary>
        public List<Action> Assembly { get; set; }

        /// <summary>
        /// Initialize Macro Data Contract
        /// </summary>
        public Macro()
        {
            ExternalSources = new List<MacroExternalSource>();
            Assembly = new List<Action>();
        }

    }
}
