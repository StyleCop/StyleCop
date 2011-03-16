//--------------------------------------------------------------------------
// <copyright file="StyleCopThreadCompletedEventArgs.cs">
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
namespace StyleCop
{
    using System;

    /// <summary>
    /// Event arguments for the StyleCopCompleted event.
    /// </summary>
    internal class StyleCopThreadCompletedEventArgs : EventArgs
    {
        #region Private Fields

        /// <summary>
        /// The thread data.
        /// </summary>
        private StyleCopThread.Data data;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopThreadCompletedEventArgs class.
        /// </summary>
        /// <param name="data">The thread data.</param>
        public StyleCopThreadCompletedEventArgs(StyleCopThread.Data data)
        {
            Param.AssertNotNull(data, "data");
            this.data = data;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the thread data object.
        /// </summary>
        public StyleCopThread.Data Data
        {
            get
            {
                return this.data;
            }
        }

        #endregion Public Properties
    }
}
