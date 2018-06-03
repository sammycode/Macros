using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.External
{

    /// <summary>
    /// The Macro Assembler Contract
    /// </summary>
    public interface IMacroAssembler
    {

        /// <summary>
        /// Build Macro from Source
        /// </summary>
        /// <param name="source">The Macro Source</param>
        /// <returns>The Macro Assembly</returns>
        IEnumerable<DataContract.Macro.Action> Build(string source);

        /// <summary>
        /// Disassemble Macro to Source
        /// </summary>
        /// <param name="assembly">The Macro Assembly</param>
        /// <returns>The Macro Source</returns>
        string Disassemble(IEnumerable<DataContract.Macro.Action> assembly);

    }
}
