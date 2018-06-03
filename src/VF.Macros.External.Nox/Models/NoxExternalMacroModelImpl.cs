using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.External.Models;

namespace VF.Macros.External.Nox.Models
{

    /// <summary>
    /// The Nox External Macro Model Implementation
    /// </summary>
    public class NoxExternalMacroModelImpl : IExternalMacroModel
    {

        /// <summary>
        /// The Qualified Name
        /// </summary>
        public string QualifiedName { get; set; }

        /// <summary>
        /// The Friendly Name
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The Source FileName
        /// </summary>
        public string SourceFileName { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        public string MacroSource { get; set; }

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

        /// <summary>
        /// Assembler Supported
        /// </summary>
        public bool AssemblerSupported { get; set; }
    }
}
