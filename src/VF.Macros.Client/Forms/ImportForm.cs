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

using Model = VF.Macros.Common.Models;
using VF.Macros.Service;

namespace VF.Macros.Client.Forms
{

    /// <summary>
    /// The Import Form
    /// </summary>
    public partial class ImportForm : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(ImportForm));

        /// <summary>
        /// The External Integration Service
        /// </summary>
        private IExternalIntegrationService _externalIntegrationService;

        /// <summary>
        /// The Installed Providers
        /// </summary>
        private Dictionary<string, Model.Metadata.ExternalProvider> InstalledProviders;

        /// <summary>
        /// The Imported Macros
        /// </summary>
        private List<Model.Macro.Macro> ImportedMacros;

        /// <summary>
        /// The Selected External Provider
        /// </summary>
        private Model.Metadata.ExternalProvider SelectedExternalProvider {
            get {
                var selectedCode = ExternalProvidersComboBox.SelectedValue as string;
                var selectedProvider = InstalledProviders[selectedCode];
                return selectedProvider;
            }
        }

        /// <summary>
        /// The Selected Macros for Import
        /// </summary>
        private IEnumerable<Model.Macro.Macro> SelectedMacrosToImport {
            get {
                
                var selectedItems = ImportedMacrosListView.CheckedItems;
                var macrosToImport = new List<Model.Macro.Macro>();
                foreach (ListViewItem selectedMacro in selectedItems)
                {
                    try
                    {
                        macrosToImport.Add((Model.Macro.Macro)selectedMacro.Tag);
                    }
                    catch (Exception)
                    {
                        //Each item should have a tag which is a macro model, but if for some reason it doesn't,
                        //dont attach it.  It's fine, this isnt't mission critical or anything
                        logger.Warn($"Unable to select {selectedMacro.Name}, it's not attached to the ListViewItem as expected");
                        continue;
                    }
                }
                return macrosToImport;
            }
        }

        /// <summary>
        /// Initialize Import Form
        /// </summary>
        protected ImportForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Import Form", caught);
                throw;
            }
        }

        /// <summary>
        /// The Import Form
        /// </summary>
        /// <param name="externalIntegrationService">The External Integration Service</param>
        public ImportForm(IExternalIntegrationService externalIntegrationService)
        {
            try
            {
                InitializeComponent();
                _externalIntegrationService = externalIntegrationService;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Import Form", caught);
                throw;
            }
        }

        #region [Fill Form Helpers]

        /// <summary>
        /// Fill Form
        /// </summary>
        private void FillForm()
        {
            try
            {
                FillExternalProvidersComboBox();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Filling Form", caught);
                throw;
            }
        }

        /// <summary>
        /// Fill External Providers Combo Box
        /// </summary>
        private void FillExternalProvidersComboBox()
        {
            try
            {
                /*
                 * Simple process hear, clear the combo box bindings, then grab the installed providers,
                 * and then bind the combo box to the external providers.
                 * Because this source is built up as part of the application composition,
                 * this should never have to be called more than once, but safety..
                 */
                
                var externalProviders = _externalIntegrationService.GetInstalledProviders();
                InstalledProviders = new Dictionary<string, Model.Metadata.ExternalProvider>();
                foreach (var provider in externalProviders)
                {
                    InstalledProviders.Add(provider.Code, provider);
                }

                ExternalProvidersComboBox.DisplayMember = "Name";
                ExternalProvidersComboBox.ValueMember = "Code";
                ExternalProvidersComboBox.DataSource = externalProviders;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Filling External Provers Combo Box", caught);
                throw;
            }
        }

        /// <summary>
        /// Fill Imported Macros ListView
        /// </summary>
        private void FillImportedMacrosListView()
        {
            try
            {
                ImportedMacrosListView.Items.Clear();

                foreach (var importedMacro in ImportedMacros)
                {
                    var importedMacroLVI = CreateImportedMacroListViewItem(importedMacro);
                    if (importedMacroLVI == null)
                    {
                        //This shouldn't happen, but if the imported macro has no underlying source, just don't show it.
                        //I'll clean this up, just sort of running through possible weird things while I model this
                        continue;
                    }
                    ImportedMacrosListView.Items.Add(importedMacroLVI);
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Filling Imported Macros ListView", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Imported Macro ListViewItem
        /// </summary>
        /// <param name="importedMacro">The Imported Macro</param>
        /// <returns>The Imported Macro ListViewItem</returns>
        private ListViewItem CreateImportedMacroListViewItem(Model.Macro.Macro importedMacro)
        {
            try
            {
                if (importedMacro == null)
                {
                    throw new ArgumentNullException("importedMacro");
                }

                var macroExternalSource = importedMacro.ExternalSources.FirstOrDefault();
                if (macroExternalSource == null)
                {
                    logger.Warn("Imported Macro Has no Source.  This shouldn't have happened, but since it did, ignoring it");
                    return null;
                }
                var lvi = new ListViewItem(new[] {
                    importedMacro.Name,
                    macroExternalSource.Provider.Name,
                    macroExternalSource.QualifiedName,
                    macroExternalSource.CreateDate.ToShortDateString()
                });
                lvi.Tag = importedMacro;
                lvi.ImageIndex = 0;
                return lvi;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Imported Macro ListViewItem", caught);
                throw;
            }
        }

        #endregion

        #region [Form Event Handlers]

        /// <summary>
        /// Handle Form Load
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleFormLoad(object sender, EventArgs e)
        {
            try
            {
                FillForm();
            }
            catch (Exception caught)
            {
                logger.Error("Unepxected Error Handling Form Load", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Import Button Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleImportClick(object sender, EventArgs e)
        {
            try
            {
                ImportedMacros = _externalIntegrationService.ImportMacros(SelectedExternalProvider).ToList();
                FillImportedMacrosListView();

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Import Button Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle OK Button Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleOKClick(object sender, EventArgs e)
        {
            try
            {
                var macrosToImport = SelectedMacrosToImport;
                if (macrosToImport != null && macrosToImport.Count() == 0)
                {
                    MessageBox.Show("No Macros are selected to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                } 
                
                var selectedMacros = SelectedMacrosToImport;
                var userResponse = MessageBox.Show("Are you sure you would like to import the selected macros?",
                    "Import Macros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (userResponse == DialogResult.Yes)
                {
                    //TODO: Save Selected Items
                    //TODO: Update Macros Management Service to take bulk macros to insert or update
                    Close();
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling OK Button Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Cancel Button Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleCancelClick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Cancel Button Click", caught);
                throw;
            }
        }

        #endregion


    }
}
