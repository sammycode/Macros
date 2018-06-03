using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.External.Nox
{

    /// <summary>
    /// The Nox Environment
    /// </summary>
    internal class Environment
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Environment));

        /// <summary>
        /// Gets Nox Data Directory
        /// </summary>
        /// <returns>The Nox Data Directory</returns>
        public static string GetNoxMacroDirectory()
        {
            try
            {
                var localAppDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                var noxMacroDirectory = Path.Combine(localAppDataDirectory, "Nox", "record");
                return noxMacroDirectory;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Nox DataDirectory", caught);
                throw;
            }
        }

        /// <summary>
        /// Gets Nox Macro Records FilePath
        /// </summary>
        /// <returns>The Nox Macro Records FilePath</returns>
        public static string GetNoxMacroRecordsFilePath()
        {
            try
            {
                var noxMacroDirectory = GetNoxMacroDirectory();
                var noxRecordsFilePath = Path.Combine(noxMacroDirectory, "records");
                return noxRecordsFilePath;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Nox Macro Records FilePath", caught);
                throw;
            }
        }

    }
}
