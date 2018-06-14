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
                //kernel.Bind<External.Models.IExternalMacroModel>()
                //   .To<External.Models.IExternalMacroModel>()
                //   .InTransientScope();
                kernel.Bind<External.IProvider>()
                    .To<External.Nox.NoxProvider>()
                    .InSingletonScope().Named(External.Nox.ProviderSettings.PROVIDER_CODE);
                //kernel.Bind<External.IMacroAssembler>()
                //    .To<External.Nox.NoxMacroAssembler>()
                //    .InSingletonScope().Named(External.Nox.ProviderSettings.PROVIDER_CODE);
                //kernel.Bind<External.IMacroImporter>()
                //    .To<External.Nox.NoxMacroImporter>()
                //    .InSingletonScope().Named(External.Nox.ProviderSettings.PROVIDER_CODE);

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
