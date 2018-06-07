using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.External
{

    /// <summary>
    /// The Provider
    /// </summary>
    public interface IProvider
    {

        /// <summary>
        /// The Provider Code
        /// </summary>
        string ProviderCode { get; }

        /// <summary>
        /// The Provider Name
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// The Assembler
        /// </summary>
        IMacroAssembler Assembler { get; }

        /// <summary>
        /// The Importer
        /// </summary>
        IMacroImporter Importer { get; }

        /// <summary>
        /// Generate Qualified Name
        /// </summary>
        /// <returns></returns>
        string GenerateQualifiedName();

    }
}
