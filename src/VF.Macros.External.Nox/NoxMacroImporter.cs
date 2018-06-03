using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Newtonsoft.Json;

using VF.Macros.Common.Settings;
using VF.Macros.Common.Utility;
using VF.Macros.External.Models;

namespace VF.Macros.External.Nox
{

    /// <summary>
    /// The Nox Macro Importer
    /// </summary>
    public class NoxMacroImporter : IMacroImporter
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(NoxMacroImporter));

        /// <summary>
        /// The External Provider
        /// </summary>
        public string ExternalProvider { get { return "Nox"; } }

        /// <summary>
        /// Import Macros
        /// </summary>
        /// <returns>The Macros</returns>
        public IEnumerable<IExternalMacroModel> ImportMacros()
        {
            try
            {
                logger.Info("Importing Nox Macros");
                var results = new List<IExternalMacroModel>();
                var macroDefinitions = ReadNoxMacroDefinitions();

                foreach (var macroKvp in macroDefinitions)
                {
                    var externalMacroModel = BuildExternalMacroModel(macroKvp.Key, macroKvp.Value);
                    results.Add(externalMacroModel);
                }

                logger.Info("Import Complete");
                return results;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Importing Macros", caught);
                throw;
            }
        }

        #region [Import Helpers]

        /// <summary>
        /// Build External Macro Model
        /// </summary>
        /// <param name="qualifiedName">Qualified Macro Name</param>
        /// <param name="noxMacroDefinition">The Nox Macro Definition</param>
        /// <returns>The External Macro Model</returns>
        private IExternalMacroModel BuildExternalMacroModel(string qualifiedName, Models.Json.NoxMacroHeaderModel noxMacroDefinition)
        {
            try
            {
                var externalModel = new Models.NoxExternalMacroModelImpl();
                externalModel.QualifiedName = qualifiedName;
                externalModel.FriendlyName = noxMacroDefinition.name;

                int parsePriorityOut;
                externalModel.ListOrder = int.TryParse(noxMacroDefinition.priority, out parsePriorityOut) ? parsePriorityOut : 0;

                /*
                 * The Create Date in Nox is stored as an epoch time stamp.
                 * If this value isn't sored correctly (it cannot parse to a double) just stick now in.
                 * Note that Epoch stores in UTC, not sure if its really relevant in Nox, but I'm choosing
                 * to store a fallback of now, in UTC in case it does compensate for that.
                 */
                double parseTimeOut;
                externalModel.CreateDate = double.TryParse(noxMacroDefinition.time, out parseTimeOut) ? DateUtility.EpochToDate(parseTimeOut) : DateTime.UtcNow;


                //The path to the macro source file, is simply the Nox Macro Directory, and the filename is the qualified name
                externalModel.SourceFileName = Path.Combine(Environment.GetNoxMacroDirectory(), qualifiedName);

                /*
                 * For a source of the macro, which will be cached in the database, we simply read the contents of the macro file
                 * If unable to read this file for any reason, log that, and then just set the macro source to null.
                 * It's techncially fine for this software to not have a macro source file, as this tool rebuilds the source after
                 * user modifications.  So this would just net in a new or empty macro
                 */
                try
                {
                    externalModel.MacroSource = File.ReadAllText(externalModel.SourceFileName);
                }
                catch (Exception caught)
                {
                    logger.Warn("Unable to read macro source file", caught);
                    externalModel.MacroSource = null;
                }

                /*
                 * TODO: Review this; it just kind of dawned on me that the values for play settings will be different if more than
                 * one emulator is used.  So it would definately make more sense to break the play settings down, from within the application management
                 * definately something to look into.
                 * 
                 * This, which I view as a pretty high proprity thing to do; is not yet critical, as I don't think many have multiple emulators
                 * that they frequently use.  I'd just not like to corrupt a macro records file with foreign values,
                 * and potentially risk unexpected behavior. (potentially crashing?)
                 */

                /*
                 * The play settings are a separate object, and it's therefor technically
                 * possible that it's not present.  If the play settings are not present, just
                 * stick some good default for the affected values.
                 */
                var playSettings = noxMacroDefinition.playSet;
                if (playSettings == null)
                {
                    externalModel.Accelerator = "1";
                    externalModel.Interval = "0";
                    externalModel.Mode = "0";
                    externalModel.PlaySeconds = "0#0#0";
                    externalModel.RepeatTimes = "1";
                }
                else
                {
                    externalModel.Accelerator = playSettings.accelerator;
                    externalModel.Interval = playSettings.interval;
                    externalModel.Mode = playSettings.mode;
                    externalModel.PlaySeconds = playSettings.playSeconds;
                    externalModel.RepeatTimes = playSettings.repeatTimes;
                }

                //TODO: VALIDATE SOURCE, ENSURE ASSEMBLER IS SUPPORTED!

                return externalModel;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building External Macro Model", caught);
                throw;
            }
        }

        /// <summary>
        /// Read Nox Macro Definitions
        /// </summary>
        /// <returns>The Nox Macro Definitions</returns>
        private Dictionary<string, Models.Json.NoxMacroHeaderModel> ReadNoxMacroDefinitions()
        {
            try
            {
                var jsonSerializer = new JsonSerializer();
                var recordsFilePath = Environment.GetNoxMacroRecordsFilePath();
                if (!File.Exists(recordsFilePath))
                {
                    logger.Warn("Macro Records File does not exist, creating an empty one");
                    File.Create(recordsFilePath).Dispose();
                }
                
                using (var streamReader = new StreamReader(recordsFilePath, TextSettings.Encoding))
                {
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var macroDefinitions = jsonSerializer.Deserialize<Dictionary<string, Models.Json.NoxMacroHeaderModel>>(jsonTextReader);
                        return macroDefinitions;
                    }
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Reading Nox Macro Definitions", caught);
                throw;
            }
        }

        #endregion

    }
}
