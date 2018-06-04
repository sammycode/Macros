using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Common.Models.Macro
{

    /// <summary>
    /// The Action Data Contract
    /// </summary>
    public class Action
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Action));

        /// <summary>
        /// The Action Type
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// The Screen Resolution
        /// </summary>
        public Dimensions ScreenResolution { get; set; }

        /// <summary>
        /// The Screen Position
        /// </summary>
        public Dimensions ScreenPosition { get; set; }

        /// <summary>
        /// The Action Delay
        /// </summary>
        public int ActionDelay { get; set; }

        /// <summary>
        /// Initialize Action Data Contract
        /// </summary>
        public Action()
        {
            try
            {
                ActionType = ActionType.Screen;
                ScreenResolution = new Dimensions { X = 720, Y = 1280 };
                ScreenPosition = new Dimensions { X = 0, Y = 0 };
                ActionDelay = 1;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Action", caught);
                throw;
            }
        }

    }
}
