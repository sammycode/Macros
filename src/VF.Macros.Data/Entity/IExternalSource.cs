using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The External Source Entity
    /// </summary>
    public interface IExternalSource
    {

        /// <summary>
        /// The Lookup Code
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// The External Source Name
        /// </summary>
        string Name { get; set; }

    }
}
