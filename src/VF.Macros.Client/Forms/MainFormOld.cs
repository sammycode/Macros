using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;
using Ninject;

using VF.Macros.Service;

namespace VF.Macros.Client.Forms
{

    /// <summary>
    /// The Macros! MainForm
    /// </summary>
    public partial class MainFormOld : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainFormOld));

        /// <summary>
        /// The External Integration Service
        /// </summary>
        [Inject]
        private IExternalIntegrationService _externalIntegrationService;

        /// <summary>
        /// Initialize the MainForm
        /// </summary>
        public MainFormOld()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macros! MainForm", caught);
                throw;
            }
        }

        #region [Event Handlers]

        /// <summary>
        /// Handle All Macros Selected
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        private void HandleAllMacrosSelected(object sender, EventArgs args)
        {
            try
            {
                MacrosListView.RefreshMacros();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling All Macros Selected", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Label Selected
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        private void HandleLabelSelected(object sender, Controls.LabelEventArgs args)
        {
            try
            {
                MacrosListView.RefreshMacros(args.Label);
            }
            catch(Exception caught)
            {
                logger.Error("Unexpected Error Handling Label Selected", caught);
                throw;
            }
        }

        #endregion


        #region [File Menu Event Handlers]

        /// <summary>
        /// Handles File->Import Macros MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleFileImportMacrosMenuClick(object sender, EventArgs e)
        {
            try
            {
                //var externalIntegrationService = IoC.GetComponent<VF.Macros.Service.IExternalIntegrationService>();
                ///externalIntegrationService.ImportMacros();
                _externalIntegrationService.ImportMacros();
                MessageBox.Show("Successfully Imported Macros", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling File->Import MenuClick", caught);
                MessageBox.Show("Unable to Import Macros.  Please Review Logs.", "Error Importing Macros", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Handles File->Export Macros MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleFileExportMacrosMenuClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles File->Exit MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleFileExitMenuClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
