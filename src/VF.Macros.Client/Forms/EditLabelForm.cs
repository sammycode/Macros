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

namespace VF.Macros.Client.Forms
{

    /// <summary>
    /// The Label Editor Form
    /// </summary>
    public partial class EditLabelForm : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(EditLabelForm));

        /// <summary>
        /// The Bound Label
        /// </summary>
        public Model.Metadata.Label BoundLabel { get; private set; }

        /// <summary>
        /// Initialize Edit Label Button
        /// </summary>
        public EditLabelForm() : this(new Model.Metadata.Label()) {}

        /// <summary>
        /// Initialize Edit Label Button
        /// </summary>
        /// <param name="label">The Label to Edit</param>
        public EditLabelForm(Model.Metadata.Label label)
        {
            try
            {
                InitializeComponent();
                BoundLabel = label; 
                //TODO: Deal with the Parent Label Display and selection
                LabelNameTextBox.DataBindings.Add("Text", BoundLabel, "Name");
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Edit Label Form", caught);
                throw;
            }
        }

        #region [Form Event Handlers]

        /// <summary>
        /// Handle OK Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleOKClick(object sender, EventArgs e)
        {
            try
            {
                if (ValidateUserInput())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling OK Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Cancel Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleCancelClick(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Cancel Click", caught);
                throw;
            }
        }

        #endregion

        #region [Validation Helpers]

        /// <summary>
        /// Validate User Input
        /// </summary>
        /// <returns>True if user input is valid</returns>
        private bool ValidateUserInput()
        {
            try
            {
                bool isValid = true;

                ErrorProvider.Clear();
                if (string.IsNullOrWhiteSpace(BoundLabel.Name))
                {
                    ErrorProvider.SetError(LabelNameTextBox, "Label Name Required");
                    isValid = false;
                }
                return isValid;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Validating User Input", caught);
                throw;
            }
        }

        #endregion

    }
}
