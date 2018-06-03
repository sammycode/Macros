using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.External.Nox.Models.Json
{

    /// <summary>
    /// The Nox Macro PlaySet Model
    /// </summary>
    internal class NoxMacroPlaySetModel
    {

        /// <summary>
        /// The Acceleration
        /// </summary>
        public string accelerator { get; set; }

        /// <summary>
        /// The Loop Interval
        /// </summary>
        public string interval { get; set; }

        /// <summary>
        /// The Play/Mode
        /// </summary>
        /// <remarks>
        /// I'm not really using this yet.  But I think in nox this is the 
        /// radio button, where it can be set to loop X times,
        /// Loop until stop button is pressed
        /// or Loop for a time duration
        /// 
        /// The subsequent fields appear to be related to that.
        /// </remarks>
        public string mode { get; set; }

        /// <summary>
        /// The Play Seconds
        /// </summary>
        public string playSeconds { get; set; }

        /// <summary>
        /// The Repeat Times
        /// </summary>
        public string repeatTimes { get; set; }

    }

}
