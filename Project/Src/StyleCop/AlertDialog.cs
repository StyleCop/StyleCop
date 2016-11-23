// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlertDialog.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Wraps the MessageBox class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// Wraps the MessageBox class.
    /// </summary>
    /// <remarks>Always use the AlertDialog class rather than MessageBox. When StyleCop is running in non-UI mode, this class
    /// will redirect the MessageBox output to the running log file.</remarks>
    public static class AlertDialog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Shows the alert dialog.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance.
        /// </param>
        /// <param name="parent">
        /// The parent control.
        /// </param>
        /// <param name="message">
        /// The message to display on the dialog.
        /// </param>
        /// <param name="title">
        /// The title of the dialog.
        /// </param>
        /// <param name="buttons">
        /// The dialog buttons.
        /// </param>
        /// <param name="icon">
        /// The dialog icon.
        /// </param>
        /// <returns>
        /// Returns the dialog result.
        /// </returns>
        public static DialogResult Show(StyleCopCore core, Control parent, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Param.RequireNotNull(core, "core");
            Param.Ignore(parent);
            Param.RequireValidString(message, "message");
            Param.RequireValidString(title, "title");
            Param.Ignore(buttons);
            Param.Ignore(icon);

            if (core.DisplayUI)
            {
                return DisplayMessageBox(parent, message, title, buttons, icon);
            }
            else
            {
                // Alert Dialogs which provide options other than OK cannot be handled when the 
                // program is running in a non-UI mode.
                if (buttons != MessageBoxButtons.OK)
                {
                    throw new InvalidOperationException(Strings.AlertDialogWithOptionsInNonUIState);
                }

                SendToOutput(core, message, icon);
                return DialogResult.OK;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows a MessageBox.
        /// </summary>
        /// <param name="parent">
        /// The parent control.
        /// </param>
        /// <param name="message">
        /// The message to display on the dialog.
        /// </param>
        /// <param name="title">
        /// The title of the dialog.
        /// </param>
        /// <param name="buttons">
        /// The dialog buttons.
        /// </param>
        /// <param name="icon">
        /// The dialog icon.
        /// </param>
        /// <returns>
        /// Returns the dialog result.
        /// </returns>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "The default MessageBoxOptions are acceptable.")]
        private static DialogResult DisplayMessageBox(Control parent, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Param.Ignore(parent);
            Param.AssertValidString(message, "message");
            Param.AssertValidString(title, "title");
            Param.Ignore(buttons);
            Param.Ignore(icon);

            Control rightToLeftParent = parent;

            while (rightToLeftParent != null)
            {
                if (rightToLeftParent.RightToLeft == RightToLeft.Inherit)
                {
                    rightToLeftParent = rightToLeftParent.Parent;
                }
                else if (rightToLeftParent.RightToLeft == RightToLeft.Yes)
                {
                    // Show the dialog in right-to-left mode.
                    return MessageBox.Show(
                        rightToLeftParent, message, title, buttons, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                }
                else
                {
                    // Show the default dialog.
                    break;
                }
            }

            // Show the dialog in the default mode.
            return MessageBox.Show(parent, message, title, buttons, icon);
        }

        /// <summary>
        /// Writes a message to do the output log.
        /// </summary>
        /// <param name="core">
        /// The StyleCop core instance.
        /// </param>
        /// <param name="message">
        /// The message to display on the dialog.
        /// </param>
        /// <param name="icon">
        /// The dialog icon.
        /// </param>
        private static void SendToOutput(StyleCopCore core, string message, MessageBoxIcon icon)
        {
            Param.Ignore(core);
            Param.AssertValidString(message, "message");
            Param.Ignore(icon);

            // Set up the appropriate tag type based on the icon.
            string tag = "{0}";
            if ((icon & MessageBoxIcon.Error) != 0 || (icon & MessageBoxIcon.Stop) != 0)
            {
                tag = Strings.ErrorTag;
            }
            else if ((icon & MessageBoxIcon.Exclamation) != 0)
            {
                tag = Strings.WarningTag;
            }

            // Send the output to the core module.
            core.SignalOutput(string.Format(CultureInfo.CurrentCulture, tag, message));
        }

        #endregion
    }
}