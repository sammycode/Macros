using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Common.Models.Metadata
{

    /// <summary>
    /// The Label Data Contract
    /// </summary>
    public class Label
    {

        /// <summary>
        /// The Label Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Parent Label Identifier (Null for top level label)
        /// </summary>
        public long? ParentID { get; set; }

        /// <summary>
        /// The Label Name
        /// </summary>
        public string Name { get; set; }

    }
}
