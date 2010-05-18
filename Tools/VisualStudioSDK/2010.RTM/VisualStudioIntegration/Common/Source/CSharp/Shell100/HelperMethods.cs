//------------------------------------------------------------------------------
// <copyright file="HelperMethods.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Shell
{
    using System;

    /// <summary>
    /// Static helper class that contains common routines.
    /// </summary>
    internal static class HelperMethods
    {
        /// <summary>
        /// Checks if the argument passed is null. If so, it throws ArgumentNullException.
        /// </summary>        
        internal static void CheckNullArgument(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Checks if the string argument is null or empty. If it is null, it throws ArgumentNullException
        /// and if it is empty, it throws ArgumentException.
        /// </summary>
        internal static void CheckNullOrEmptyString(string argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argument);
            }

            if (argument == String.Empty)
            {
                throw new ArgumentException(Resources.Argument_EmptyString, name);
            }
        }
    }
}