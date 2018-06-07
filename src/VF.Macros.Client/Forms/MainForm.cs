using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using VF.Macros.Service;

namespace VF.Macros.Client.Forms
{
    /// <summary>
    /// The Main Form
    /// </summary>
    /// <remarks>
    /// I dropped designer support for the main form, and opted to use user controls to better
    /// support the dependancy injection.  I was initially sort of forced to break the DI
    /// pattern, with a more anti-pattern of using a static container to grab service handles
    /// from.
    /// Anyways, I think this is a good solution. (even if only temporary) 
    /// 
    /// I don't often work in the client space, I'd be super open to any helpful suggestions to help clean this up...
    /// 
    /// </remarks>
    public class MainForm : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainForm));

        #region [Service Handles]

        /// <summary>
        /// The External Integration Service Handle
        /// </summary>
        private IExternalIntegrationService _externalIntegrationService;

        #endregion

        #region [Controls]

        /// <summary>
        /// The Navigation TreeView
        /// </summary>
        private Controls.NavigationTreeView NavigationTreeView;

        /// <summary>
        /// The Macros ListView
        /// </summary>
        private Controls.MacrosListView MacrosListView;

        /// <summary>
        /// The Navigation Panel (this is the left side of the form)
        /// </summary>
        private Panel NavigatePanel;

        /// <summary>
        /// The Navigation Panel Splitter (this is the bar that allows user to resize the panels in the middle)
        /// </summary>
        private Splitter NavigationPaneSplitter;

        /// <summary>
        /// The Content Panel (this is the right side of the form)
        /// </summary>
        private Panel ContentPanel;

        /// <summary>
        /// The Status Strip
        /// </summary>
        private StatusStrip StatusStrip;

        #endregion

        #region [File Menu Controls]

        /// <summary>
        /// The MenuStrip
        /// </summary>
        private MenuStrip MenuStrip;

        /// <summary>
        /// The File MenuItem
        /// </summary>
        private ToolStripMenuItem fileToolStripMenuItem;

        /// <summary>
        /// The File->Import MenuStrip Item
        /// </summary>
        private ToolStripMenuItem importMacrosToolStripMenuItem;

        /// <summary>
        /// The File->Export MenuStrip Item
        /// </summary>
        private ToolStripMenuItem exportMacrosToolStripMenuItem;

        /// <summary>
        /// The Separator above Exit on the File Menu
        /// </summary>
        private ToolStripSeparator toolStripMenuItem1;

        /// <summary>
        /// The File->Exit MenuStrip Item
        /// </summary>
        private ToolStripMenuItem exitToolStripMenuItem;

        #endregion

        /// <summary>
        /// Initialize MainForm
        /// </summary>
        /// <param name="navigationTreeView">Injected Navigation TreeView</param>
        /// <param name="macrosListView">Injected Macros ListView</param>
        /// <param name="externalIntegrationService">Injected External Integration Service Handle</param>
        public MainForm(Controls.NavigationTreeView navigationTreeView,
            Controls.MacrosListView macrosListView,
            IExternalIntegrationService externalIntegrationService)
        {
            try
            {
                _externalIntegrationService = externalIntegrationService;

                NavigationTreeView = navigationTreeView;
                MacrosListView = macrosListView;

                AssembleUI();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing MainForm", caught);
                throw;
            }
        }

        #region [UI Assembly Helpers]

        /// <summary>
        /// Assemble User Interface
        /// </summary>
        private void AssembleUI()
        {
            try
            {
                /*
                 * Initializing all incidental controls,
                 * NOT initializing the controls which were injected
                 */
                this.MenuStrip = new MenuStrip();
                this.fileToolStripMenuItem = new ToolStripMenuItem();
                this.importMacrosToolStripMenuItem = new ToolStripMenuItem();
                this.exportMacrosToolStripMenuItem = new ToolStripMenuItem();
                this.toolStripMenuItem1 = new ToolStripSeparator();
                this.exitToolStripMenuItem = new ToolStripMenuItem();
                this.StatusStrip = new StatusStrip();
                this.NavigatePanel = new Panel();
                this.NavigationPaneSplitter = new Splitter();
                this.ContentPanel = new Panel();
                this.MenuStrip.SuspendLayout();

                /*
                 * Suspending Layout Engine while controls are set up and wired up
                 */
                this.NavigatePanel.SuspendLayout();
                this.ContentPanel.SuspendLayout();
                this.SuspendLayout();

                // 
                // MenuStrip
                // 
                this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.fileToolStripMenuItem});
                this.MenuStrip.Location = new System.Drawing.Point(0, 0);
                this.MenuStrip.Name = "MenuStrip";
                this.MenuStrip.Size = new System.Drawing.Size(784, 24);
                this.MenuStrip.TabIndex = 0;
                this.MenuStrip.Text = "menuStrip1";
                // 
                // fileToolStripMenuItem
                // 
                this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                    this.importMacrosToolStripMenuItem,
                    this.exportMacrosToolStripMenuItem,
                    this.toolStripMenuItem1,
                    this.exitToolStripMenuItem});
                this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
                this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
                this.fileToolStripMenuItem.Text = "File";
                // 
                // importMacrosToolStripMenuItem
                // 
                this.importMacrosToolStripMenuItem.Name = "importMacrosToolStripMenuItem";
                this.importMacrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
                this.importMacrosToolStripMenuItem.Text = "Import Macros";
                this.importMacrosToolStripMenuItem.Click += new System.EventHandler(this.HandleFileImportMacrosMenuClick);
                // 
                // exportMacrosToolStripMenuItem
                // 
                this.exportMacrosToolStripMenuItem.Name = "exportMacrosToolStripMenuItem";
                this.exportMacrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
                this.exportMacrosToolStripMenuItem.Text = "Export Macros";
                this.exportMacrosToolStripMenuItem.Click += new System.EventHandler(this.HandleFileExportMacrosMenuClick);
                // 
                // toolStripMenuItem1
                // 
                this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
                // 
                // exitToolStripMenuItem
                // 
                this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
                this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
                this.exitToolStripMenuItem.Text = "Exit";
                this.exitToolStripMenuItem.Click += new System.EventHandler(this.HandleFileExitMenuClick);
                // 
                // StatusStrip
                // 
                this.StatusStrip.Location = new System.Drawing.Point(0, 539);
                this.StatusStrip.Name = "StatusStrip";
                this.StatusStrip.Size = new System.Drawing.Size(784, 22);
                this.StatusStrip.TabIndex = 1;
                this.StatusStrip.Text = "statusStrip1";
                // 
                // NavigatePanel
                // 
                this.NavigatePanel.Controls.Add(this.NavigationTreeView);
                this.NavigatePanel.Dock = System.Windows.Forms.DockStyle.Left;
                this.NavigatePanel.Location = new System.Drawing.Point(0, 24);
                this.NavigatePanel.MaximumSize = new System.Drawing.Size(300, 0);
                this.NavigatePanel.MinimumSize = new System.Drawing.Size(100, 0);
                this.NavigatePanel.Name = "NavigatePanel";
                this.NavigatePanel.Size = new System.Drawing.Size(300, 515);
                this.NavigatePanel.TabIndex = 2;
                // 
                // NavigationTreeView
                // 
                this.NavigationTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
                this.NavigationTreeView.Location = new System.Drawing.Point(0, 0);
                this.NavigationTreeView.Margin = new System.Windows.Forms.Padding(5);
                this.NavigationTreeView.Name = "NavigationTreeView";
                this.NavigationTreeView.Size = new System.Drawing.Size(300, 515);
                this.NavigationTreeView.TabIndex = 0;
                this.NavigationTreeView.LabelSelected += new System.Action<object, VF.Macros.Client.Controls.LabelEventArgs>(this.HandleLabelSelected);
                this.NavigationTreeView.AllMacrosSelected += new System.Action<object, System.EventArgs>(this.HandleAllMacrosSelected);
                // 
                // NavigationPaneSplitter
                // 
                this.NavigationPaneSplitter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.NavigationPaneSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.NavigationPaneSplitter.Location = new System.Drawing.Point(300, 24);
                this.NavigationPaneSplitter.Name = "NavigationPaneSplitter";
                this.NavigationPaneSplitter.Size = new System.Drawing.Size(3, 515);
                this.NavigationPaneSplitter.TabIndex = 3;
                this.NavigationPaneSplitter.TabStop = false;
                // 
                // ContentPanel
                // 
                this.ContentPanel.Controls.Add(this.MacrosListView);
                this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                this.ContentPanel.Location = new System.Drawing.Point(303, 24);
                this.ContentPanel.Name = "ContentPanel";
                this.ContentPanel.Size = new System.Drawing.Size(481, 515);
                this.ContentPanel.TabIndex = 4;
                // 
                // MacrosListView
                // 
                this.MacrosListView.Dock = System.Windows.Forms.DockStyle.Fill;
                this.MacrosListView.Location = new System.Drawing.Point(0, 0);
                this.MacrosListView.Margin = new System.Windows.Forms.Padding(5);
                this.MacrosListView.Name = "MacrosListView";
                this.MacrosListView.Size = new System.Drawing.Size(481, 515);
                this.MacrosListView.TabIndex = 0;
                // 
                // MainForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(784, 561);
                this.Controls.Add(this.ContentPanel);
                this.Controls.Add(this.NavigationPaneSplitter);
                this.Controls.Add(this.NavigatePanel);
                this.Controls.Add(this.StatusStrip);
                this.Controls.Add(this.MenuStrip);
                this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.MainMenuStrip = this.MenuStrip;
                this.Margin = new System.Windows.Forms.Padding(5);
                this.MinimumSize = new System.Drawing.Size(600, 400);
                this.Name = "MainForm";
                this.Text = "Macros!";

                /*
                 * Resuming Layout Engine
                 */
                this.MenuStrip.ResumeLayout(false);
                this.MenuStrip.PerformLayout();
                this.NavigatePanel.ResumeLayout(false);
                this.ContentPanel.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();


            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Assembling User Interface", caught);
                throw;
            }
        }

        #endregion

        #region [Form Event Handlers]

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
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Label Selected", caught);
                throw;
            }
        }

        #endregion

        #region [Menu Event Handlers]

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
                //_externalIntegrationService.ImportMacros("Nox");
                //TODO: Import using external integration service
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
