using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.External.Nox
{

    /// <summary>
    /// The Nox Macro Assembler
    /// </summary>
    /// <remarks>
    /// TODO: A crucial thing to consider, is that the macro assembly is not the same thing as a macro
    /// it's the instructions that the macro uses.
    /// 
    /// Still kind of on the fence if I want to even persist the macro assembly, since the source is all 
    /// that really matters for this...
    /// </remarks>
    public class NoxMacroAssembler : IMacroAssembler
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(NoxMacroAssembler));

        /// <summary>
        /// The Separator Sequence in the macro action
        /// </summary>
        private const string SEPARATOR_SEQUENCE = "ScRiPtSePaRaToR";

        /// <summary>
        /// The Multi Command
        /// </summary>
        private const string COMMAND_MULTI = "MULTI";

        /// <summary>
        /// Build Macro Assembly
        /// </summary>
        /// <param name="source">The Macro Source</param>
        /// <returns>The Macro Assembly</returns>
        public IEnumerable<DataContract.Macro.Action> Build(string source)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(source))
                {
                    throw new ArgumentNullException("source");
                }

                var macroAssembly = new List<DataContract.Macro.Action>();


                var sourceLines = GetSourceLines(source);
                if (sourceLines.Count % 4 != 0)
                {
                    throw new ApplicationException("Source is not new, or lines not divisible by 4");
                }

                while (sourceLines.Count > 0)
                {
                    var actionSource = GetNextActionSource(sourceLines);
                    //TODO: Create Macro Action from it's source
                    var macroAction = BuildMacroAction(actionSource);
                    //TODO: Then Add it to the collection
                    macroAssembly.Add(macroAction);
                }

                return macroAssembly;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Macro from Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Disassemble Macro Assembly
        /// </summary>
        /// <param name="assembly">The Macro Assembly</param>
        /// <returns>The Macro Source</returns>
        public string Disassemble(IEnumerable<DataContract.Macro.Action> assembly)
        {
            try
            {
                var sbActionSource = new StringBuilder();
                var assemblyQuery = from a in assembly
                                    orderby a.ActionDelay ascending
                                    select a;
                foreach (var action in assemblyQuery)
                {
                    var actionSource = GetActionSource(action);
                    sbActionSource.Append(actionSource);
                }
                return sbActionSource.ToString();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Disassembling Macro", caught);
                throw;
            }
        }

        #region [Build Helpers]

        /// <summary>
        /// Assemble Macro
        /// </summary>
        /// <param name="macroSource">The Macro Source</param>
        /// <returns>The Macro Assembly</returns>
        private List<DataContract.Macro.Action> AssembleMacro(string macroSource)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(macroSource))
                {
                    throw new ArgumentNullException("macroSource");
                }

                var sourceLines = GetSourceLines(macroSource);
                if (sourceLines.Count %4 != 0)
                {
                    throw new ApplicationException("Source is not new, or lines not divisible by 4");
                }

                var macroAssembly = new List<DataContract.Macro.Action>();
                while (sourceLines.Count > 0)
                {
                    var actionSource = GetNextActionSource(sourceLines);
                    var macroAction = BuildMacroAction(actionSource);
                    macroAssembly.Add(macroAction);
                }
                return macroAssembly;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Assembling Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Gets Source Lines
        /// </summary>
        /// <param name="source">The Macro Source</param>
        /// <returns>The Source Lines</returns>
        private List<string> GetSourceLines(string source)
        {
            try
            {
                var sourceTok = source.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return sourceTok.ToList();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Source Lines", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Next Action Source
        /// </summary>
        /// <param name="sourceLines">The Source Lines</param>
        /// <returns>The Next Action Source, which is a collection of several lines</returns>
        private string GetNextActionSource(List<string> sourceLines)
        {
            try
            {
                if (sourceLines == null)
                {
                    throw new ArgumentNullException("sourceLines");
                }

                var sbActionSource = new StringBuilder();
                sbActionSource.Append(sourceLines[0]); sbActionSource.Append("\r\n"); sourceLines.RemoveAt(0);
                sbActionSource.Append(sourceLines[0]); sbActionSource.Append("\r\n"); sourceLines.RemoveAt(0);
                sbActionSource.Append(sourceLines[0]); sbActionSource.Append("\r\n"); sourceLines.RemoveAt(0);
                sbActionSource.Append(sourceLines[0]); sbActionSource.Append("\r\n"); sourceLines.RemoveAt(0);
                return sbActionSource.ToString();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Next Action Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Build Macro Action
        /// </summary>
        /// <param name="actionSource">The Action Source</param>
        /// <returns>The Macro Action Data Contract</returns>
        /// <remarks>
        /// Not really sure what to say about this.
        /// This is a result of haste, and discovery.  What I would really like to do
        /// is build a lexical parser of some sort, and draw meaning behind the language
        /// of the source, which might allow for interesting capabilities...
        /// 
        /// Whatever... will get there
        /// </remarks>
        private DataContract.Macro.Action BuildMacroAction(string actionSource)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(actionSource))
                {
                    throw new ArgumentNullException("actionSource");
                }

                var macroAction = new DataContract.Macro.Action();

                var sourceTok = actionSource.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (sourceTok.Count() != 4)
                {
                    //But really we are only concerned about the first line, it has the information we need...
                    throw new ApplicationException("Expectng 4 source lines to represent this action");
                }

                var firstLine = sourceTok[0];
                var firstLineTok = firstLine.Split(new[] { SEPARATOR_SEQUENCE }, StringSplitOptions.RemoveEmptyEntries);
                if (firstLineTok.Count() != 3)
                {
                    throw new ApplicationException("Expectng 3 action segments");
                }

                int parseOut = -1;
                if (int.TryParse(firstLineTok[0], out parseOut))
                {
                    macroAction.ActionType = parseOut == 0 ? DataContract.Macro.ActionType.Screen : DataContract.Macro.ActionType.Keyboard;
                }

                //Extract Screen dimensions and tap position from second segment
                var secondSegmentTok = firstLineTok[1].Split(new[] { "|", ":", COMMAND_MULTI }, StringSplitOptions.RemoveEmptyEntries);
                if (secondSegmentTok.Count() != 6)
                {
                    throw new ApplicationException("Expecting 6 Arguments in second segment");
                }
                if (int.TryParse(secondSegmentTok[0], out parseOut))
                {
                    macroAction.ScreenResolution.Y = parseOut;
                }
                if (int.TryParse(secondSegmentTok[1], out parseOut))
                {
                    macroAction.ScreenResolution.X = parseOut;
                }
                if (int.TryParse(secondSegmentTok[4], out parseOut))
                {
                    macroAction.ScreenPosition.Y = parseOut;
                }
                if (int.TryParse(secondSegmentTok[5], out parseOut))
                {
                    macroAction.ScreenPosition.X = parseOut;
                }

                //Extract Action Delay from last segment
                if (int.TryParse(firstLineTok[2], out parseOut))
                {
                    macroAction.ActionDelay = parseOut;
                }

                return macroAction;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Building Macro Action", caught);
                throw;
            }
        }

        #endregion

        #region [Disassemble Helpers]

        /// <summary>
        /// Get Action Source
        /// </summary>
        /// <param name="action">The Action</param>
        /// <returns>The Action Source</returns>
        private string GetActionSource(DataContract.Macro.Action action)
        {
            try
            {
                var sbAction = new StringBuilder();

                var actionTypeValue = action.ActionType == DataContract.Macro.ActionType.Screen ? 0 : 1;
                sbAction.Append($"{actionTypeValue}{SEPARATOR_SEQUENCE}{action.ScreenResolution.Y}|{action.ScreenResolution.X}|{COMMAND_MULTI}:1:0:{action.ScreenPosition.Y}:{action.ScreenPosition.X}{SEPARATOR_SEQUENCE}{action.ActionDelay}\r\n");
                sbAction.Append($"{actionTypeValue}{SEPARATOR_SEQUENCE}{action.ScreenResolution.Y}|{action.ScreenResolution.X}|{COMMAND_MULTI}:0:6{SEPARATOR_SEQUENCE}{action.ActionDelay + 1}\r\n");
                sbAction.Append($"{actionTypeValue}{SEPARATOR_SEQUENCE}{action.ScreenResolution.Y}|{action.ScreenResolution.X}|{COMMAND_MULTI}:0:6{SEPARATOR_SEQUENCE}{action.ActionDelay + 1}\r\n");
                sbAction.Append($"{actionTypeValue}{SEPARATOR_SEQUENCE}{action.ScreenResolution.Y}|{action.ScreenResolution.X}|{COMMAND_MULTI}:0:1{SEPARATOR_SEQUENCE}{action.ActionDelay + 1}\r\n");

                return sbAction.ToString();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Action Source", caught);
                throw;
            }
        }

        #endregion

    }
}
