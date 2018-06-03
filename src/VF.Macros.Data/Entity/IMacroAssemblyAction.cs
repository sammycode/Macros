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
