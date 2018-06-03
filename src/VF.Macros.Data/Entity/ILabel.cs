using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The Label Contract
    /// </summary>
    public interface ILabel
    {

        /// <summary>
        /// The Label ID
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// The Parent Label ID
        /// </summary>
        long? ParentID { get; set; }

        /// <summary>
        /// The Label Name
        /// </summary>
        string Name { get; set; }

    }
}
