using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The External Provider Entity
    /// </summary>
    public interface IExternalProvider
    {

        /// <summary>
        /// The Lookup Code
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// The Provider Name
        /// </summary>
        string Name { get; set; }

    }
}
