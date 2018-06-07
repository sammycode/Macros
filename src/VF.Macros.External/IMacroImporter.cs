using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.External
{

    /// <summary>
    /// The Macro Importer
    /// </summary>
    public interface IMacroImporter
    {

        ///// <summary>
        ///// The External Provider
        ///// </summary>
        //string ExternalProvider { get; }

        /// <summary>
        /// Imports Macros
        /// </summary>
        /// <returns>The Macros Imported</returns>
        IEnumerable<Models.IExternalMacroModel> ImportMacros();

    }
}
