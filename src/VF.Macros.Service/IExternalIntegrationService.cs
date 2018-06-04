using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model = VF.Macros.Common.Models;

namespace VF.Macros.Service
{

    /// <summary>
    /// The External Integration Service
    /// </summary>
    /// <remarks>
    /// I wasn't sure what to call this currently.
    /// 
    /// This is a service that will allow foreign macros (installed on an emulator)
    /// to be imported into this system.
    /// 
    /// Additionally it will allow the user to install new or modified macros,
    /// or perhaps import from one emulator, and export to another.
    /// 
    /// I'm going to keep the usage painstakingly simple for now, 
    /// which means the user would always be safest to Import and then export.
    /// This will however very likely turn to "sync" and not have these called
    /// explicitly.
    /// 
    /// I think the most desirable effect would be to have all macros on the system
    /// managed here, and then have the user select "export" on those they would like to use.
    /// So it would be ideal to bring in any incidental macros that existed.
    /// 
    /// Of course the "enabled" state will be default on all macros, so new unmanaged macros will
    /// become managed, but remain on the emulator anyways.
    /// 
    /// </remarks>
    public interface IExternalIntegrationService
    {

        /// <summary>
        /// Import New Macros
        /// </summary>
        void ImportMacros();

        /// <summary>
        /// Export Macros (overwrite)
        /// </summary>
        void ExportMacros();

        /// <summary>
        /// Build Macro Action Assembly
        /// </summary>
        /// <param name="source">The External Macro Source</param>
        /// <returns>The Macro Action Assembly</returns>
        IEnumerable<Model.Macro.Action> BuildMacroActionAssembly(string source);

        /// <summary>
        /// Get Macro Action Assembly Source
        /// </summary>
        /// <param name="assembly">The Macro Action Assembly</param>
        /// <returns>The Macro Action Assembly Source</returns>
        string GetMacroActionAssemblySource(IEnumerable<Model.Macro.Action> assembly);

        /// <summary>
        /// Get External Provider
        /// </summary>
        /// <returns>The External Provider</returns>
        Model.Metadata.ExternalProvider GetExternalProvider();

    }
}
