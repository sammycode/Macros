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
    /// The SQLite Macro Data Repository
    /// </summary>
    public class SQLiteMacroDataRepository : BaseAdoNetDataRepository, IMacroDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteMacroDataRepository));

        /// <summary>
        /// Initialize SQLite Macro Data Repository
        /// </summary>
        /// <param name="dbManager">The Database Manager</param>
        public SQLiteMacroDataRepository(IDbManager dbManager) : base(DEFAULT_CONNECTION_STRING_NAME, dbManager) {}

        public IExternalSource CreateExternalSource(string code, string name)
        {
            throw new NotImplementedException();
        }

        public IMacro CreateMacro(long? labelID, string name, int listOrder, DateTime createDate, bool enabled)
        {
            throw new NotImplementedException();
        }

        public IMacroAssemblyAction CreateMacroAssemblyAction(IMacro macro, int actionType, int screenHeight, int screenWidth, int positionX, int positionY, int actionDelay)
        {
            throw new NotImplementedException();
        }

        public void CreateMacroSource(IMacro macro, DateTime createDate, string externalSourceCode, string acceleratorName, string interval, string mode, string playSeconds, string playTimes, string source)
        {
            throw new NotImplementedException();
        }

        public void DeleteExternalSource(IExternalSource externalSource)
        {
            throw new NotImplementedException();
        }

        public void DeleteMacro(IMacro macro)
        {
            throw new NotImplementedException();
        }

        public void DeleteMacroAssemblyAction(IMacroAssemblyAction assemblyAction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMacro> GetAllMacros()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMacroAssemblyAction> GetMacroAssembly(IMacro macro)
        {
            throw new NotImplementedException();
        }

        public IMacroAssemblyAction GetMacroAssemblyAction(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMacro> GetMacroByID(long macroID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMacro> GetMacroByQualifiedName(string qualifiedName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IMacro> GetMacrosByLabelID(long? labelID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IExternalMacroSource> GetExternalMacroSource(IMacro macro)
        {
            throw new NotImplementedException();
        }

        public IExternalSource LookupExternalSource(string code)
        {
            throw new NotImplementedException();
        }

        public void UpdateExternalSource(IExternalSource externalSource)
        {
            throw new NotImplementedException();
        }

        public void UpdateMacro(IMacro macro)
        {
            throw new NotImplementedException();
        }

        public void UpdateMacroAssemblyAction(IMacroAssemblyAction assemblyAction)
        {
            throw new NotImplementedException();
        }

        public void UpdateExternalMacroSource(IExternalMacroSource macroSource)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IExternalMacroSource> GetExternalMacroSourceByID(long id)
        {
            throw new NotImplementedException();
        }

        public IExternalMacroSource CreateExternalMacroSource(IMacro macro, DateTime createDate, string externalSourceCode, string acceleratorName, string interval, string mode, string playSeconds, string playTimes, string source)
        {
            throw new NotImplementedException();
        }

        public void DeleteExternalMacroSource(IExternalMacroSource externalMacroSource)
        {
            throw new NotImplementedException();
        }
    }
}
