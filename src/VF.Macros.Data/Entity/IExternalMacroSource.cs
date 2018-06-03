using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The External Macro Source
    /// </summary>
    public interface IExternalMacroSource
    {

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// The Macro ID
        /// </summary>
        long MacroID { get; set; }

        /// <summary>
        /// The CreateDate
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// The Qualified Name
        /// </summary>
        string QualifiedName { get; set; }

        /// <summary>
        /// The External Source Code
        /// </summary>
        /// <remarks>
        /// External Sources are being normalized, so this is now a code.
        /// The provider name is on that lookup table.
        /// </remarks>
        string ExternalSourceCode { get; set; }

        /// <summary>
        /// The Accelerator
        /// </summary>
        /// <remarks>
        /// *NOTE* Not used by this software,
        /// retained to properly restore back to emulator
        /// 
        /// Nox: PlaySet/Accelerator
        /// Memu: replayAccelRates
        /// 
        /// </remarks>
        string Accelerator { get; set; }

        /// <summary>
        /// The Interval
        /// </summary>
        /// <remarks>
        /// *NOTE* Not used by this software,
        /// retained to properly restore back to emulator
        /// 
        /// Nox: PlaySet/Interval
        /// Memu: ReplayInterval
        /// 
        /// </remarks>
        string Interval { get; set; }

        /// <summary>
        /// The Mode
        /// </summary>
        /// <remarks>
        /// *NOTE* Not used by this software,
        /// retained to properly restore back to emulator
        /// 
        /// Nox: PlaySet/Mode
        /// Memu: CycleInfinite
        /// 
        /// </remarks>
        string Mode { get; set; }

        /// <summary>
        /// The PlaySeconds
        /// </summary>
        /// <remarks>
        /// *NOTE* Not used by this software,
        /// retained to properly restore back to emulator
        /// 
        /// Nox: PlaySet/PlaySeconds
        /// Memu: ReplayTime
        /// 
        /// </remarks>
        string PlaySeconds { get; set; }

        /// <summary>
        /// The RepeatTimes
        /// </summary>
        /// <remarks>
        /// *NOTE* Not used by this software,
        /// retained to properly restore back to emulator
        /// 
        /// Nox: PlaySet/RepeatTimes
        /// Memu: ReplayCycles
        /// 
        /// </remarks>
        string RepeatTimes { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        string MacroSource { get; set; }

    }
}
