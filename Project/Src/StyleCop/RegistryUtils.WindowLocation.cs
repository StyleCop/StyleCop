// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryUtils.WindowLocation.cs" company="https://github.com/StyleCop">
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
//   The registry utils.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// The registry utils.
    /// </summary>
    /// <content>
    /// Performs operations in the registry.
    /// </content>
    public partial class RegistryUtils
    {
        /// <summary>
        /// Used to save the location and size of a form in the registry.
        /// </summary>
        private class WindowLocation
        {
            #region Fields

            /// <summary>
            /// The current location of the form.
            /// </summary>
            private Point location;

            /// <summary>
            /// The current size of the form.
            /// </summary>
            private Size size;

            /// <summary>
            /// The current state of the form.
            /// </summary>
            private FormWindowState state;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the WindowLocation class.
            /// </summary>
            public WindowLocation()
            {
            }

            /// <summary>
            /// Initializes a new instance of the WindowLocation class.
            /// </summary>
            /// <param name="input">
            /// The input string.
            /// </param>
            public WindowLocation(string input)
            {
                Param.AssertValidString(input, "input");

                string[] sections = input.Split(',');
                if (sections.Length < 5)
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Strings.InvalidWindowLocationInputString, input));
                }

                this.location.X = Convert.ToInt32(sections[0], null);
                this.location.Y = Convert.ToInt32(sections[1], null);
                this.size.Height = Convert.ToInt32(sections[2], null);
                this.size.Width = Convert.ToInt32(sections[3], null);

                int state = Convert.ToInt32(sections[4], null);
                if (state < 0)
                {
                    this.state = FormWindowState.Minimized;
                }
                else if (state > 0)
                {
                    this.state = FormWindowState.Maximized;
                }
                else if (state == 0)
                {
                    this.state = FormWindowState.Normal;
                }
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets or sets the location value.
            /// </summary>
            public Point Location
            {
                get
                {
                    return this.location;
                }

                set
                {
                    Param.Ignore(value);
                    this.location = value;
                }
            }

            /// <summary>
            /// Gets or sets the size value.
            /// </summary>
            public Size Size
            {
                get
                {
                    return this.size;
                }

                set
                {
                    Param.Ignore(value);
                    this.size = value;
                }
            }

            /// <summary>
            /// Gets or sets the window state value.
            /// </summary>
            public FormWindowState State
            {
                get
                {
                    return this.state;
                }

                set
                {
                    Param.Ignore(value);
                    this.state = value;
                }
            }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// Converts the values to a string.
            /// </summary>
            /// <returns>Returns the string representations of the values.</returns>
            public override string ToString()
            {
                StringBuilder output = new StringBuilder();
                output.AppendFormat(CultureInfo.CurrentUICulture, "{0},{1},{2},{3},", this.location.X, this.location.Y, this.size.Height, this.size.Width);

                if (this.state == FormWindowState.Maximized)
                {
                    output.Append("1");
                }
                else
                {
                    output.Append("0");
                }

                return output.ToString();
            }

            #endregion
        }
    }
}