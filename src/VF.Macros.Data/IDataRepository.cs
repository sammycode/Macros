using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data
{

    /// <summary>
    /// The Data Repository Contract
    /// </summary>
    public interface IDataRepository : IDisposable
    {

        /// <summary>
        /// The Macros Data Repsitory
        /// </summary>
        Repositories.IMacroDataRepository MacroRepository { get; }

        /// <summary>
        /// The Label Data Repository
        /// </summary>
        Repositories.ILabelDataRepository LabelRepository { get; }

        /// <summary>
        /// The External Provider Repository
        /// </summary>
        Repositories.IExternalProviderDataRepository ExternalProviderRepository { get; }

    }
}
