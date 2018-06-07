using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.Repositories
{

    /// <summary>
    /// The External Provider Data Repository
    /// </summary>
    public interface IExternalProviderDataRepository
    {

        #region [External Sources]

        /// <summary>
        /// Lookup External Source
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <returns>The External Source</returns>
        IExternalProvider LookupExternalProvider(string code);

        /// <summary>
        /// Create External Source
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <param name="name">The External Source Name</param>
        /// <returns>
        /// The External Source
        /// </returns>
        IExternalProvider CreateExternalProvider(string code, string name);

        /// <summary>
        /// Update External Source
        /// </summary>
        /// <param name="externalProvider">The External Provider</param>
        void UpdateExternalProvider(IExternalProvider externalProvider);

        /// <summary>
        /// Delete External Source
        /// </summary>
        /// <param name="externalProvider">The External Provider</param>
        void DeleteExternalProvider(IExternalProvider externalProvider);

        #endregion

    }
}
