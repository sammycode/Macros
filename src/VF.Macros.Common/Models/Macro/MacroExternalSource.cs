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
        
        /// <summary>
        /// Is the Designer Supported?
        /// </summary>
        public bool DesignerSupported { get; set; }

        /// <summary>
        /// The Accelerator
        /// </summary>
        public string Accelerator { get; set; }

        /// <summary>
        /// The Interval
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// The Mode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// The Play Seconds
        /// </summary>
        public string PlaySeconds { get; set; }

        /// <summary>
        /// The Repeat Times
        /// </summary>
        public string RepeatTimes { get; set; }

    }
}
