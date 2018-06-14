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

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The Macro Assembly Action
    /// </summary>
    public interface IMacroAssemblyAction
    {

        /// <summary>
        /// The Macro Action Assembly Identifier
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        long MacroID { get; set; }

        /// <summary>
        /// The Action Type
        /// </summary>
        int ActionType { get; set; }

        /// <summary>
        /// The Screen Height
        /// </summary>
        int ScreenHeight { get; set; }

        /// <summary>
        /// The Screen Width
        /// </summary>
        int ScreenWidth { get; set; }

        /// <summary>
        /// The X Position of the Action
        /// </summary>
        int PositionX { get; set; }

        /// <summary>
        /// The Y Position of the Action
        /// </summary>
        int PositionY { get; set; }

        /// <summary>
        /// The Action Delay
        /// </summary>
        int ActionDelay { get; set; }

    }
}
