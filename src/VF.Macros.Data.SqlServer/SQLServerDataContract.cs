using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.SqlServer
{

    /// <summary>
    /// The SQL Server DataContract
    /// </summary>
    internal class SQLServerDataContract
    {

        /// <summary>
        /// The Macros Data Contract
        /// </summary>
        public static class Macros {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "Macros";

            /// <summary>
            /// The ID Column Name
            /// </summary>
            public const string COLUMN_ID_NAME = "ID";

            /// <summary>
            /// The LabelID Column Name
            /// </summary>
            public const string COLUMN_LABEL_ID_NAME = "LabelID";

            /// <summary>
            /// The Friendly Name, Column Name
            /// </summary>
            public const string COLUMN_NAME_NAME = "Name";

            /// <summary>
            /// The List Order Column Name
            /// </summary>
            public const string COLUMN_LIST_ORDER_NAME = "ListOrder";

            /// <summary>
            /// The Create Date Name
            /// </summary>
            public const string COLUMN_CREATE_DATE_NAME = "CreateDate";

            /// <summary>
            /// The Enabled Name
            /// </summary>
            public const string COLUMN_ENABLED_NAME = "Enabled";

        }

        /// <summary>
        /// The External Macro Source Data Contract
        /// </summary>
        public static class ExternalMacroSource {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "ExternalMacroSources";

            /// <summary>
            /// The ID Column Name
            /// </summary>
            public const string COLUMN_ID_NAME = "ID";

            /// <summary>
            /// The MacroID Column Name
            /// </summary>
            public const string COLUMN_MACRO_ID_NAME = "MacroID";

            /// <summary>
            /// The CreateDate Column Name
            /// </summary>
            public const string COLUMN_CREATE_DATE_NAME = "CreateDate";

            /// <summary>
            /// The Qualified Name, Column Name
            /// </summary>
            public const string COLUMN_QUALIFIED_NAME_NAME = "QualifiedName";

            /// <summary>
            /// The External Source Code Column Name
            /// </summary>
            public const string COLUMN_EXTERNAL_SOURCE_CODE_NAME = "ExternalSourceCode";

            /// <summary>
            /// The Accelerator Column Name
            /// </summary>
            public const string COLUMN_ACCELERATOR_NAME = "Accelerator";

            /// <summary>
            /// The Interval Column Name
            /// </summary>
            public const string COLUMN_INTERVAL_NAME = "Interval";

            /// <summary>
            /// The Mode Column Name
            /// </summary>
            public const string COLUMN_MODE_NAME = "Mode";

            /// <summary>
            /// The Play Seconds Column Name
            /// </summary>
            public const string COLUMN_PLAY_SECONDS_NAME = "PlaySeconds";

            /// <summary>
            /// The Repeat Times Column Name
            /// </summary>
            public const string COLUMN_REPEAT_TIMES_NAME = "RepeatTimes";

            /// <summary>
            /// The Macro Source Column Name
            /// </summary>
            public const string COLUMN_MACRO_SOURCE_NAME = "MacroSource";

        }
        
        /// <summary>
        /// The Labels Data Contract
        /// </summary>
        public static class Labels
        {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "Labels";

            /// <summary>
            /// The ID Column Name
            /// </summary>
            public const string COLUMN_ID_NAME = "ID";

            /// <summary>
            /// The Parent ID Column Name
            /// </summary>
            public const string COLUMN_PARENT_ID_NAME = "ParentID";

            /// <summary>
            /// The Name, Column Name
            /// </summary>
            public const string COLUMN_NAME_NAME = "Name";

        }

        /// <summary>
        /// The External Providers Data Contract
        /// </summary>
        /// <remarks>
        /// This is a normalized lookup table
        /// </remarks>
        public static class ExternalProviders
        {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "ExternalProviders";

            /// <summary>
            /// The Lookup Code Column Name
            /// </summary>
            public const string COLUMN_CODE_NAME = "Code";

            /// <summary>
            /// The External Provider Name, Column Name
            /// </summary>
            public const string COLUMN_NAME_NAME = "Name";

        }

        /// <summary>
        /// The Macro Assembly Actions DataContract
        /// </summary>
        public static class MacroAssemblyActions
        {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "MacroAssemblyActions";

            /// <summary>
            /// The ID Column Name
            /// </summary>
            public const string COLUMN_ID_NAME = "ID";

            /// <summary>
            /// The MacroID Column Name
            /// </summary>
            public const string COLUMN_MACRO_ID_NAME = "MacroID";

            /// <summary>
            /// The ActionType Column Name
            /// </summary>
            public const string COLUMN_ACTION_TYPE_NAME = "ActionType";

            /// <summary>
            /// The Screen Height Column Name
            /// </summary>
            public const string COLUMN_SCREEN_HEIGHT_NAME = "ScreenHeight";

            /// <summary>
            /// The Screen Width Column Name
            /// </summary>
            public const string COLUMN_SCREEN_WIDTH_NAME = "ScreenWidth";

            /// <summary>
            /// The PositionX Column Name
            /// </summary>
            public const string COLUMN_POSITION_X_NAME = "PositionX";

            /// <summary>
            /// The PositionY Column Name
            /// </summary>
            public const string COLUMN_POSITION_Y_NAME = "PositionY";

            /// <summary>
            /// The Action Delay Column Name
            /// </summary>
            public const string COLUMN_ACTION_DELAY_NAME = "ActionDelay";

        }

    }
}
