using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.AdoNet;
using VF.Macros.Data.Entity;
using VF.Macros.Data.Repositories;

namespace VF.Macros.Data.SQLite.Repositories
{

    /// <summary>
    /// The SQLite Label Data Repository
    /// </summary>
    public class SQLiteLabelDataRepository : BaseAdoNetDataRepository, ILabelDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteLabelDataRepository));

        /// <summary>
        /// Initialize SQLite Label Data Repository
        /// </summary>
        /// <param name="dbManager">The Database Manager</param>
        public SQLiteLabelDataRepository(IDbManager dbManager) : base(DEFAULT_CONNECTION_STRING_NAME, dbManager) {}

        public ILabel CreateLabel(long? parentID, string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteLabel(ILabel label)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILabel> GetAllLabels()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILabel> GetChildLabels(long parentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILabel> GetLabelByID(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ILabel> GetTopLevelLabels()
        {
            throw new NotImplementedException();
        }

        public void UpdateLabel(ILabel label)
        {
            throw new NotImplementedException();
        }
    }
}
