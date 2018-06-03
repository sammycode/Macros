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

using Model = VF.Macros.Common.Models.Macro;

namespace VF.Macros.Client.Controls
{
    public partial class MacroActionEditorControl : UserControl
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MacroActionEditorControl));

        /// <summary>
        /// The Source Action
        /// </summary>
        public Model.Action SourceAction { get; private set; }

        /// <summary>
        /// The Remove Action Event
        /// </summary>
        public event Action<object, ActionEditorControlEventArgs> RemoveAction;

        /// <summary>
        /// The Duplicate Action Event
        /// </summary>
        public event Action<object, ActionEditorControlEventArgs> DuplicateAction;

        /// <summary>
        /// Initialzie Macro Editor Control
        /// </summary>
        public MacroActionEditorControl() : this(new Model.Action()) {}


        /// <summary>
        /// The Known Positions
        /// </summary>
        private static Dictionary<string, Model.Dimensions> KnownPositions;

        /// <summary>
        /// Initialize Macro Editor Control
        /// </summary>
        /// <param name="action"></param>
        public MacroActionEditorControl(Model.Action action)
        {
            try
            {
                InitializeComponent();
                SourceAction = action;
                BindControlsToSource();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macro Action Editor Control", caught);
                throw;
            }
        }

        /// <summary>
        /// Initialize Macro Editor Control Class
        /// </summary>
        static MacroActionEditorControl()
        {
            try
            {
                //Specify Known Positions
                KnownPositions = new Dictionary<string, Model.Dimensions>();
                KnownPositions.Add("Slot 1", new Model.Dimensions { X = 500, Y = 875 });
                KnownPositions.Add("Slot 2", new Model.Dimensions { X = 500, Y = 1000 });
                KnownPositions.Add("Slot 3", new Model.Dimensions { X = 500, Y = 1125 });
                KnownPositions.Add("Slot 4", new Model.Dimensions { X = 185, Y = 875 });
                KnownPositions.Add("Slot 5", new Model.Dimensions { X = 185, Y = 1000 });
                KnownPositions.Add("Slot 6", new Model.Dimensions { X = 185, Y = 1125 });
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macro Action Editor Control Class", caught);
                throw;
            }
        }
        #region [Control Event Handlers]

        /// <summary>
        /// Handles Remove Action Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleRemoveActionClick(object sender, EventArgs e)
        {
            try
            {
                var eventArguments = new ActionEditorControlEventArgs { Action = SourceAction };
                OnRemoveAction(this, eventArguments);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Remove Action Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Duplicate Action Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleDuplicateActionClick(object sender, EventArgs e)
        {
            try
            {
                var eventArguments = new ActionEditorControlEventArgs { Action = SourceAction };
                OnDuplicateAction(this, eventArguments);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Duplicate Action Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Control Load
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleControlLoad(object sender, EventArgs e)
        {
            try
            {
                KnownPositionComboBox.Items.Clear();
                KnownPositionComboBox.DataSource = KnownPositions.ToList();
                KnownPositionComboBox.DisplayMember = "Key";
                KnownPositionComboBox.ValueMember = "Value";
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Control Load", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Known Position Index Changed
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleKnownPositionIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var position = KnownPositionComboBox.SelectedValue as Model.Dimensions;
                if (position == null)
                {
                    return;
                }
                SourceAction.ScreenPosition.X = position.X;
                SourceAction.ScreenPosition.Y = position.Y;
                TapXTextBox.Text = Convert.ToString(position.X);
                TapYTextbox.Text = Convert.ToString(position.Y);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Known Position Index Changed", caught);
                throw;
            }
        }

        #endregion

        #region [Event Implementations]

        /// <summary>
        /// Fire Remvoe Action Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        protected virtual void OnRemoveAction(object sender, ActionEditorControlEventArgs args)
        {
            try
            {
                RemoveAction?.Invoke(sender, args);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Firing Remove Action Event", caught);
                throw;
            }
        }

        /// <summary>
        /// Fire Duplicate Action Event
        /// </summary>
        protected virtual void OnDuplicateAction(object sender, ActionEditorControlEventArgs args)
        {
            try
            {
                DuplicateAction?.Invoke(sender, args);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Firing Duplicate Action Event", caught);
                throw;
            }
        }

        #endregion

        #region [Data Binding Helpers]

        /// <summary>
        /// Bind Controls to Source
        /// </summary>
        private void BindControlsToSource()
        {
            try
            {
                ScreenHeightTextBox.DataBindings.Add("Text", SourceAction.ScreenResolution, "Y");
                ScreenWidthTextbox.DataBindings.Add("Text", SourceAction.ScreenResolution, "X");
                TapYTextbox.DataBindings.Add("Text", SourceAction.ScreenPosition, "Y");
                TapXTextBox.DataBindings.Add("Text", SourceAction.ScreenPosition, "X");
                ActionDelayTextbox.DataBindings.Add("Text", SourceAction, "ActionDelay");
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Binding Controls to Source", caught);
                throw;
            }
        }

        #endregion

    }
}
