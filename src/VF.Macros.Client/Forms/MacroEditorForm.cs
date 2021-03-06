﻿/*
 * Copyright (C) 2018  Mike Jamer
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

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
    /// The Macro Editor Form
    /// </summary>
    public partial class MacroEditorForm : Form
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MacroEditorForm));

        /// <summary>
        /// The Source Macro
        /// </summary>
        public Model.Macro.Macro SourceMacro { get; private set; }

        /// <summary>
        /// The External Provider
        /// </summary>
        private Model.Metadata.ExternalProvider ExternalProvider { get; set; }

        /// <summary>
        /// The External Integration Service
        /// </summary>
        private IExternalIntegrationService _externalIntegrationService;

        /// <summary>
        /// Initialize Macro Editor Form
        /// </summary>
        /// <param name="externalIntegrationService">The External Integration Service</param>
        public MacroEditorForm(IExternalIntegrationService externalIntegrationService) : this(externalIntegrationService, new Model.Macro.Macro()) {}

        /// <summary>
        /// Initialize Macro Editor Form
        /// </summary>
        /// <param name="externalIntegrationService">The External Integration Service</param>
        /// <param name="sourceMacro">The Source Macro</param>
        public MacroEditorForm(IExternalIntegrationService externalIntegrationService, Model.Macro.Macro sourceMacro)
        {
            try
            {
                InitializeComponent();
                SourceMacro = sourceMacro ?? throw new ArgumentNullException("macro");
                _externalIntegrationService = externalIntegrationService ?? throw new ArgumentNullException("externalIntegrationService");


                //TODO: Adjust this, this is a band-aid
                /*
                 * Moving to a model where multiple external providers are go be supported, and 
                 * at the current state, this form is no longer adequate.  So for the moment, this 
                 * component is being forced in as the first provider to allow macro code generation
                 * when switching between designer and source.
                 * 
                 * Once the external push integration is finally re-inabled, this will be less important, a
                 * and the form will only be concerned with modifying the intent model.
                 * 
                 * Though there will likely be a live update feature, and at that point the intended target will
                 * be selected by a drop down or another similar widget.
                 */
                ExternalProvider = _externalIntegrationService.GetInstalledProviders().FirstOrDefault();
                if (ExternalProvider == null)
                {
                    throw new ApplicationException("External Provider Not Installed");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macro Editor Form", caught);
                throw;
            }
        }

        #region [Form Event Handlers]

        /// <summary>
        /// Handles OK Click
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
        /// Handles Cancel Click
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
                logger.Error("Unexpected Error Handling Form Load", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Begin Resize
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        /// <remarks>
        /// Suspending Layout in this form when a user is resizing the window,
        /// because for some reason the multiples of User Controls for the Macro Actions,
        /// are causing some pretty severe lag in Windows 10.  I have no real explanation for this
        /// 
        /// It kinda makes resizing this form feel really unnatural, but it feels 
        /// better than the alternative.
        /// </remarks>
        private void HandleResizeBegin(object sender, EventArgs e)
        {
            SuspendLayout();
        }

        /// <summary>
        /// Handles End Resize
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        /// <remarks>
        /// Resuming Layout when Resizing stops, just to allow things to start redrawing again.
        /// </remarks>
        private void HandleResizeEnd(object sender, EventArgs e)
        {
            ResumeLayout();
        }

        #endregion

        #region [Validation Helpers]

        /// <summary>
        /// Validate User Input
        /// </summary>
        /// <returns>True if the values look OK</returns>
        private bool ValidateUserInput()
        {
            try
            {
                ErrorProvider.Clear();
                bool passed = true;

                // TODO: Move this to the model once binding is set up
                if(string.IsNullOrWhiteSpace(NameTextbox.Text))
                {
                    ErrorProvider.SetError(NameTextbox, "Name Required");
                    passed = false;
                }

                return passed;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Validating User Input", caught);
                throw;
            }
        }

        #endregion

        #region [Form Fill Helpers]

        /// <summary>
        /// Fill Form using Bound Macro
        /// </summary>
        private void FillForm()
        {
            try
            {
                RefreshDesigner();

                //TODO: Add additional Handlers here

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Filling Form", caught);
                throw;
            }
        }

        // <summary>
        /// Add Macro Action Editor Control
        /// </summary>
        /// <param name="macroAction">The Macro Action</param>
        private void AddMacroActonEditorControl(Model.Macro.Action macroAction)
        {
            try
            {
                if (macroAction == null)
                {
                    throw new ArgumentNullException("macroAction");
                }

                var actionEditorControl = new Controls.MacroActionEditorControl(macroAction);
                MacroActionsFlowPanel.Controls.Add(actionEditorControl);
                actionEditorControl.RemoveAction += new Action<object, Controls.ActionEditorControlEventArgs>(HandleRemoveAction);
                actionEditorControl.DuplicateAction += new Action<object, Controls.ActionEditorControlEventArgs>(HandleDuplicateAction);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Adding Macro Action Editor Control to Designer", caught);
                throw;
            }
        }

        /// <summary>
        /// Refreshing Designer
        /// </summary>
        private void RefreshDesigner()
        {
            try
            {
                if (SourceMacro == null)
                {
                    return;
                }

                SuspendLayout();

                foreach (var macroActionEditor in MacroActionsFlowPanel.Controls)
                {
                    var editorControl = macroActionEditor as Controls.MacroActionEditorControl;
                    editorControl.RemoveAction -= new Action<object, Controls.ActionEditorControlEventArgs>(HandleRemoveAction);
                    editorControl.DuplicateAction -= new Action<object, Controls.ActionEditorControlEventArgs>(HandleDuplicateAction);
                }
                MacroActionsFlowPanel.Controls.Clear();

                var actionsQuery = from ma in SourceMacro.Assembly
                                   orderby ma.ActionDelay ascending
                                   select ma;
                foreach (var action in actionsQuery)
                {
                    AddMacroActonEditorControl(action);
                }
                ResumeLayout();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing Designer", caught);
                throw;
            }
        }

        #endregion

        #region [Designer Event Handlers]

        /// <summary>
        /// Handle Add Action Click
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleAddActionClick(object sender, EventArgs e)
        {
            try
            {
                //var newAction = IoC.GetComponent<IMacroAction>();
                var newAction = new Model.Macro.Action();
                SourceMacro.Assembly.Add(newAction);
                AddMacroActonEditorControl(newAction);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Add Action Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Tab Index Changed
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleTabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedTab = EditorTabControl.SelectedTab;
                var tabTag = selectedTab.Tag as string;
                if ("DESIGN".Equals(tabTag))
                {
                    //var macroSource = MacroSourceTextbox.Text.Trim();
                    //SourceMacro.Assembly = _externalIntegrationService.BuildMacroActionAssembly("NOX", macroSource)
                    //    .ToList();
                    RefreshDesigner();
                }
                else if ("SOURCE".Equals(tabTag))
                {
                    //MacroSourceTextbox.Text = _externalIntegrationService.GetMacroActionAssemblySource("NOX", SourceMacro.Assembly);
                    SourceMacro = _externalIntegrationService.RegenerateMacroSource(ExternalProvider, SourceMacro);
                    MacroSourceTextbox.Text = SourceMacro.ToString();
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling TabIndex Changed", caught);
            }
        }

        /// <summary>
        /// Handles Remove Action
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        private void HandleRemoveAction(object sender, Controls.ActionEditorControlEventArgs args)
        {
            try
            {
                var sendingControl = sender as Control;
                SourceMacro.Assembly.Remove(args.Action);
                MacroActionsFlowPanel.Controls.Remove(sendingControl);
                sendingControl.Dispose();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Remove Action", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Duplicate Action
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        private void HandleDuplicateAction(object sender, Controls.ActionEditorControlEventArgs args)
        {
            try
            {
                var sendingControl = sender as Control;
                var existingAction = args.Action;
                var newAction = new Model.Macro.Action();

                newAction.ActionType = existingAction.ActionType;
                newAction.ActionDelay = existingAction.ActionDelay;

                newAction.ScreenResolution.X = existingAction.ScreenResolution.X;
                newAction.ScreenResolution.Y = existingAction.ScreenResolution.Y;

                newAction.ScreenPosition.X = existingAction.ScreenPosition.X;
                newAction.ScreenPosition.Y = existingAction.ScreenPosition.Y;

                SourceMacro.Assembly.Add(newAction);
                AddMacroActonEditorControl(newAction);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Duplicate Action", caught);
                throw;
            }
        }


        #endregion


    }
}
