/*
 * Copyright (C) 2018  Mike Jamer
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.External.Models
{

    /// <summary>
    /// The External Macro Model
    /// </summary>
    public interface IExternalMacroModel
    {

        /// <summary>
        /// The Qualified Name
        /// </summary>
        string QualifiedName { get; set; }

        /// <summary>
        /// The Friendly Name
        /// </summary>
        string FriendlyName { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// The Source FileName
        /// </summary>
        /// <remarks>
        /// *NOTE*
        /// For Nox, this is the same as the qualified name,
        /// for Memu, this is also the qualified name, but with characters and html codes stripped
        /// </remarks>
        string SourceFileName { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        string MacroSource { get; set; }

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
        /// Is the Assembler (basically designer) Supported?
        /// </summary>
        /// <remarks>
        /// This is a flag that can get set, if we test the source to see if it's
        /// a macro which follows the intended conventions of this editor.
        /// 
        /// For example, some TMR Farming scripts use a different approach to our
        /// chainging macros.  It's the chaining macros we are mostly concerned about
        /// at this point
        /// </remarks>
        bool AssemblerSupported { get; set; }

    }
}
