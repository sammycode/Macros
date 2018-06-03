using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Common.Models.Macro
{

    /// <summary>
    /// The Macro External Source
    /// </summary>
    public class MacroExternalSource
    {

        /// <summary>
        /// The Macro External Source Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Macro Header
        /// </summary>
        public Macro Macro { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The Qualified Name
        /// </summary>
        public string QualifiedName { get; set; }

        /// <summary>
        /// The External Provider
        /// </summary>
        public Metadata.ExternalProvider Provider { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        public string MacroSource { get; set; }

    }
}
