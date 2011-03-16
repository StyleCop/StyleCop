//--------------------------------------------------------------------------
// <copyright file="InvisibleForm.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.VisualStudio
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Class that handles creating an invisible form on the UI thread.
    /// </summary>
    internal class InvisibleForm : Form
    {
        #region Fields
        /// <summary>
        /// Singleton instance of the InvisibleForm.
        /// </summary>
        private static InvisibleForm instanceForm;

        /// <summary>
        /// Mutex for thread safety.
        /// </summary>
        private static volatile object mutex = new object();

        #endregion Fields
        
        #region Constructors

        /// <summary>
        /// Prevents a default instance of the InvisibleForm class from being created.
        /// </summary>
        private InvisibleForm()
        {
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the singleton instance of the InvisibleForm.
        /// </summary>
        internal static InvisibleForm Instance
        {
            get
            {
                lock (mutex)
                {
                    if (instanceForm == null)
                    {
                        instanceForm = new InvisibleForm();

                        // This causes the form to get created.
                        instanceForm.Visible = true;
                        instanceForm.Visible = false;

                        instanceForm.Location = new System.Drawing.Point(0, Screen.PrimaryScreen.WorkingArea.Bottom + 100);
                    }

                    return instanceForm;
                }
            }
        }

        #endregion Properties
    }
}
