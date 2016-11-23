// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyControlSaveResult.cs" company="https://github.com/StyleCop">
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
//   The possible results of saving the settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// The possible results of saving the settings.
    /// </summary>
    internal enum PropertyControlSaveResult
    {
        /// <summary>
        /// The save succeeded.
        /// </summary>
        Success, 

        /// <summary>
        /// One of the pages aborted the save operation.
        /// </summary>
        PageAbort, 

        /// <summary>
        /// An error occurred while saving the file.
        /// </summary>
        SaveError
    }
}