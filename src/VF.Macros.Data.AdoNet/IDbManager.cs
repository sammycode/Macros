using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.AdoNet
{

    /// <summary>
    /// The Database Manager Contract
    /// </summary>
    public interface IDbManager
    {

        /// <summary>
        /// Determine if Database Exists
        /// </summary>
        /// <returns>True if database exists</returns>
        bool DatabaseExists();

        /// <summary>
        /// Create Database
        /// </summary>
        void CreateDatabase();

    }
}
