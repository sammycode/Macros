using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The Macro Contract
    /// </summary>
    /// <remarks>
    /// For the time being, not sure what to do with the time,
    /// this is stamped in Nox as Time, and in Memu a timestamp is used to mark the qualified name
    /// for a particular macro.
    /// So, I'll capture it, but it's notable that in Memu, it might be undesirable to actually ever
    /// modify it.  I guess maybe we never will need to really modify it...
    /// </remarks>
    public interface IMacro
    {

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// The Label ID
        /// </summary>
        long? LabelID { get; set; }

        /// <summary>
        /// The is a Friendly Name for the Macro
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        /// <remarks>
        /// For Nox, this is the Priority Field
        /// For Memu, I believe this is the order in which it appears in the INI file
        /// </remarks>
        int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        /// <remarks>
        /// In Nox, this is an epoch timestamp.
        /// In memu this is dirived from the Qualified Macro Name. *Might end up with some special handling there*
        /// </remarks>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Macro Enabled
        /// </summary>
        bool Enabled { get; set; }

    }
}
