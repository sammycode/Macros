using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.SqlServer.Entity
{

    /// <summary>
    /// The Sql Server External Macro Source Implementation
    /// </summary>
    public class SqlServerExternalMacroSourceImpl : IExternalMacroSource
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerExternalMacroSourceImpl));

        #region [Fields]

        /// <summary>
        /// The External Macro Source Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        public long MacroID { get; set; }

        /// <summary>
        /// The Qualified Name
        /// </summary>
        public string QualifiedName { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The External Source Code
        /// </summary>
        public string ExternalSourceCode { get; set; }

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
        /// The Macro Source
        /// </summary>
        public string MacroSource { get; set; }

        #endregion

        #region [Bindings]

        /// <summary>
        /// Flag to indicate fields are already mapped
        /// </summary>
        private static bool _mapped = false;

        /// <summary>
        /// The ID Column Index
        /// </summary>
        private static int _indexID;

        /// <summary>
        /// The MacroID Column Index
        /// </summary>
        private static int _indexMacroID;

        /// <summary>
        /// The Create Date Index
        /// </summary>
        private static int _indexCreateDate;

        /// <summary>
        /// The External Provider Column Index
        /// </summary>
        private static int _indexExternalSourceCode;

        /// <summary>
        /// The Accelerator Column Index
        /// </summary>
        private static int _indexAccelerator;

        /// <summary>
        /// The Interval Column Index
        /// </summary>
        private static int _indexInterval;

        /// <summary>
        /// The Mode Column Index
        /// </summary>
        private static int _indexMode;

        /// <summary>
        /// The Play Seconds Column Index
        /// </summary>
        private static int _indexPlaySeconds;

        /// <summary>
        /// The Repeat Times Column index
        /// </summary>
        private static int _indexRepeatTimes;

        /// <summary>
        /// The Macro Source Index
        /// </summary>
        private static int _indexMacroSource;

        #endregion

        /// <summary>
        /// Initialize Sql Server External Macro Source Implementation
        /// </summary>
        public SqlServerExternalMacroSourceImpl() {}

        /// <summary>
        /// Initialize Sql Server External Macro Source Implementation
        /// </summary>
        /// <param name="reader"></param>
        public SqlServerExternalMacroSourceImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);
                ID = reader.GetInt64(_indexID);
                MacroID = reader.GetInt64(_indexMacroID);
                CreateDate = reader.GetDateTime(_indexCreateDate);
                ExternalSourceCode = reader.GetString(_indexExternalSourceCode);
                Accelerator = reader.GetString(_indexAccelerator);
                Interval = reader.GetString(_indexInterval);
                Mode = reader.GetString(_indexMode);
                PlaySeconds = reader.GetString(_indexPlaySeconds);
                RepeatTimes = reader.GetString(_indexRepeatTimes);
                MacroSource = reader.GetString(_indexMacroSource);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Sql Server External Macro Source Implementation", caught);
            }
        }

        #region [BInding Helpers]

        /// <summary>
        /// Realize Column Mappings
        /// </summary>
        /// <param name="reader">The DataReader</param>
        private static void RealizeColumnMappings(IDataReader reader)
        {
            try
            {
                if (_mapped)
                {
                    return;
                }

                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }

                _indexID = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_ID_NAME);
                _indexMacroID = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME);
                _indexCreateDate = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME);
                _indexExternalSourceCode = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME);
                _indexAccelerator = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME);
                _indexInterval = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME);
                _indexMode = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_MODE_NAME);
                _indexPlaySeconds = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME);
                _indexRepeatTimes = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME);
                _indexMacroSource = reader.GetOrdinal(SQLServerDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME);
                _mapped = true;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Realizing Column Mappings", caught);
                throw;
            }
        }

        #endregion

    }
}
