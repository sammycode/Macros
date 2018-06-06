using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;
using Ninject;

using VF.Macros.Service;

namespace VF.Macros.Client
{

    /// <summary>
    /// The Macros! Application Context
    /// </summary>
    internal class MacrosAppContext  : ApplicationContext
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static ILog logger = LogManager.GetLogger(typeof(MacrosAppContext));

        /// <summary>
        /// The Kernel
        /// </summary>
        private static StandardKernel _kernel;

        /// <summary>
        /// Initialize Macros Application Context
        /// </summary>
        public MacrosAppContext()
        {
            try
            {
                _kernel = InitializeContainer();
                MainForm = _kernel.Get<Forms.MainForm>();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macros! Application Context", caught);
                throw;
            }
        }

        /// <summary>
        /// Initialize IoC Container
        /// </summary>
        /// <returns>The IoC Container</returns>
        static StandardKernel InitializeContainer()
        {
            try
            {
                logger.Info("Initializing IoC Container");
                var kernel = new StandardKernel();

                //TODO: Finish Up bot SQL Server and SQLite Components, and then make this portion configurable, user should be able to use one engine or the other
                var configuredDataProvider = Common.Settings.DataSettings.DataProvider;
                if (Common.Settings.DataSettings.PROVIDER_SQLITE.Equals(configuredDataProvider))
                {
                    logger.Info("Installing SQLite Data Dependancies");
                    InstallSQLiteDependancies(kernel);
                }
                else if (Common.Settings.DataSettings.PROVIDER_SQL_SERVER.Equals(configuredDataProvider))
                {
                    logger.Info("Installing Sql Server Data Dependancies");
                    InstallSqlServerDependancies(kernel);
                }
                else
                {
                    logger.Fatal("Unable to determine Data Provider for application composition");
                    throw new ApplicationException("Unable to configure data provider");
                }

                /*
                 * External
                 */
                kernel.Bind<External.Models.IExternalMacroModel>()
                   .To<External.Models.IExternalMacroModel>()
                   .InTransientScope();
                kernel.Bind<External.IMacroAssembler>()
                    .To<External.Nox.NoxMacroAssembler>()
                    .InSingletonScope();
                kernel.Bind<External.IMacroImporter>()
                    .To<External.Nox.NoxMacroImporter>()
                    .InSingletonScope();

                /*
                 * Service
                 */
                kernel.Bind<Service.IExternalIntegrationService>()
                  .To<Service.Standard.StdExternalIntegrationServiceImpl>()
                  .InSingletonScope();
                kernel.Bind<Service.ILabelManagementService>()
                  .To<Service.Standard.StdLabelManagementServiceImpl>()
                  .InSingletonScope();
                kernel.Bind<Service.IMacroManagementService>()
                  .To<Service.Standard.StdMacroManagementServiceImpl>()
                  .InSingletonScope();

                /*
                 * Client Components
                 */
                kernel.Bind<Forms.MainFormOld>()
                 .ToSelf()
                 .InSingletonScope();
                kernel.Bind<Controls.NavigationTreeView>()
                 .ToSelf()
                 .InSingletonScope();
                kernel.Bind<Controls.MacrosListView>()
                 .ToSelf()
                 .InSingletonScope();


                return kernel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing IoC Container", caught);
                throw;
            }
        }

        /// <summary>
        /// Install SQLServer Dependancies
        /// </summary>
        /// <param name="kernel">The Kernel</param>
        private static void InstallSqlServerDependancies(StandardKernel kernel)
        {
            try
            {
                /*
                 * Data Entities
                 */
                kernel.Bind<Data.Entity.IExternalMacroSource>()
                    .To<Data.SqlServer.Entity.SqlServerExternalMacroSourceImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IExternalSource>()
                    .To<Data.SqlServer.Entity.SqlServerExternalSourceImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.ILabel>()
                    .To<Data.SqlServer.Entity.SqlServerLabelImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IMacro>()
                    .To<Data.SqlServer.Entity.SqlServerMacroImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IMacroAssemblyAction>()
                    .To<Data.SqlServer.Entity.SqlServerMacroAssemblyActionImpl>()
                    .InTransientScope();
                /*
                 * Data Repositories
                 */
                kernel.Bind<Data.Repositories.ILabelDataRepository>()
                   .To<Data.SqlServer.Repositories.SqlServerLabelDataRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.Repositories.IMacroDataRepository>()
                   .To<Data.SqlServer.Repositories.SqlServerMacroDataRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.IDataRepository>()
                   .To<Data.SqlServer.SqlServerRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.AdoNet.IDbManager>()
                   .To<Data.SqlServer.SqlServerDatabaseMangaer>()
                   .InSingletonScope();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Installing SQLServer Dependancies", caught);
                throw;
            }
        }

        /// <summary>
        /// Install SQLite Dependancies
        /// </summary>
        /// <param name="kernel">The Kernel</param>
        private static void InstallSQLiteDependancies(StandardKernel kernel)
        {
            try
            {
                /*
                 * Data Entities
                 */
                kernel.Bind<Data.Entity.IExternalMacroSource>()
                    .To<Data.SQLite.Entity.SQLiteExternalMacroSourceImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IExternalSource>()
                    .To<Data.SQLite.Entity.SQLiteExternalSourceImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.ILabel>()
                    .To<Data.SQLite.Entity.SQLiteLabelImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IMacro>()
                    .To<Data.SQLite.Entity.SQLiteMacroImpl>()
                    .InTransientScope();
                kernel.Bind<Data.Entity.IMacroAssemblyAction>()
                    .To<Data.SQLite.Entity.SQLiteMacroAssemblyActionImpl>()
                    .InTransientScope();
                /*
                 * Data Repositories
                 */
                kernel.Bind<Data.Repositories.ILabelDataRepository>()
                   .To<Data.SQLite.Repositories.SQLiteLabelDataRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.Repositories.IMacroDataRepository>()
                   .To<Data.SQLite.Repositories.SQLiteMacroDataRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.IDataRepository>()
                   .To<Data.SQLite.SQLiteRepository>()
                   .InSingletonScope();
                kernel.Bind<Data.AdoNet.IDbManager>()
                   .To<Data.SQLite.SQLiteDatabaseManager>()
                   .InSingletonScope();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Installing SQLite Dependancies", caught);
                throw;
            }
        }

        /// <summary>
        /// Dispose Macros! Application Context
        /// </summary>
        /// <param name="disposing">Is Disposing</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    return;
                }
                if (_kernel != null && !_kernel.IsDisposed)
                {
                    _kernel.Dispose();
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Disposing Macros! Application Context", caught);
            }
        }


    }
}
