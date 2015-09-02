//-----------------------------------------------------------------------
// <copyright file="StyleCopBug.cs" company="ACME">
// Copyright (c) ACME Corporation. All rights reserved.
// </copyright>
// <summary>This class exposes StyleCop SA1101 Bug.</summary>
//-----------------------------------------------------------------------

namespace StyleCopTest
{
    using System.Collections.Generic;

    /// <summary>
    /// Exposes StyleCop SA1101 Bug
    /// </summary>
    public class StyleCopBug
    {
        /// <summary>
        /// Private dictionary
        /// </summary>
        private Dictionary<string, string> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopBug"/> class.
        /// </summary>
        public StyleCopBug()
        {
            this.dictionary = new Dictionary<string, string>(5);

            // Warning 1 SA1101: The call to dictionary must begin with the 'this.' prefix to indicate that the item is a member of the class. <snip>\Documents\Visual Studio 2008\Projects\StyleCopTest\StyleCopTest\StyleCopBug.cs 28 1
            this.dictionary.Add("key", "value");
        }
    }
}
