// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopLogLevel.cs" company="https://github.com/StyleCop">
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
//   Available log levels for controlling log output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Available log levels for controlling log output.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public enum StyleCopLogLevel
    {
        /// <summary>
        /// No logging.
        /// </summary>
        None, 

        /// <summary>
        /// Low log output. Only the most basic log strings use this level.
        /// </summary>
        Low, 

        /// <summary>
        /// Medium log output. Data that is interesting, but not necessarily essential,
        /// should use this level.
        /// </summary>
        Medium, 

        /// <summary>
        /// The highest log output. Highly detailed log output should use this level.
        /// </summary>
        High
    }
}