using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using Model = VF.Macros.Common.Models;
using VF.Macros.Service;

namespace VF.Macros.Client.Controls
{

    /// <summary>
    /// The Label TreeView
    /// </summary>
    /// <remarks>
    /// This is a simplified control, which will render just labels, and 
    /// will allow the container form or control to view which label is selected. 
    /// or emit a null if no label is selected
    /// </remarks>
    public partial class LabelTreeView : UserControl
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(LabelTreeView));

        /// <summary>
        /// The Selected Label
        /// </summary>
        public Model.Metadata.Label SelectedLabel { get; private set; }

        /// <summary>
        /// Initialize Label TreeView
        /// </summary>
        public LabelTreeView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Label TreeView", caught);
                throw;
            }
        }
    }
}
