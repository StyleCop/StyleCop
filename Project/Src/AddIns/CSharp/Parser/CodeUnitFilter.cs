//////-----------------------------------------------------------------------
////// <copyright file="CodeUnitFilter.cs" company="Microsoft">
//////     Copyright (c) Microsoft Corporation. All rights reserved.
////// </copyright>
////// <license>
//////   This source code is subject to terms and conditions of the Microsoft 
//////   Public License. A copy of the license can be found in the License.html 
//////   file at the root of this distribution. If you cannot locate the  
//////   Microsoft Public License, please send an email to dlr@microsoft.com. 
//////   By using this source code in any fashion, you are agreeing to be bound 
//////   by the terms of the Microsoft Public License. You must not remove this 
//////   notice, or any other, from this software.
////// </license>
//////-----------------------------------------------------------------------
////namespace Microsoft.StyleCop.CSharp
////{
////    using System;
////    using System.Collections.Generic;
////    using System.Diagnostics;
////    using System.Diagnostics.CodeAnalysis;

////    /// <summary>
////    /// Delegate used for callbacks from the Next and Previous properties.
////    /// </summary>
////    /// <param name="codeUnit">The code unit to match against.</param>
////    /// <returns>Returns true if the code unit is a match, false otherwise.</returns>
////    public delegate bool CodeUnitFilterHandler(CodeUnit codeUnit);

////    /// <summary>
////    /// Filters the values returned from the various Next, Previous, First and Last methods on CodeUnit and derived classes.
////    /// </summary>
////    public class CodeUnitFilter
////    {
////        #region Public Constructors

////        /// <summary>
////        /// Initializes a new instance of the CodeUnitFilter class.
////        /// </summary>
////        public CodeUnitFilter()
////        {
////        }

////        /// <summary>
////        /// Initializes a new instance of the CodeUnitFilter class.
////        /// </summary>
////        /// <param name="root">Restricts code units to those below this root in the hierarchy.</param>
////        public CodeUnitFilter(CodeUnit root)
////            : this(root, false, null)
////        {
////            Param.Ignore(root);
////        }

////        /// <summary>
////        /// Initializes a new instance of the CodeUnitFilter class.
////        /// </summary>
////        /// <param name="root">Restricts code units to those below this root in the hierarchy.</param>
////        /// <param name="directChildrenOnly">Determindes whether to include only those children one level below the root node.</param>
////        public CodeUnitFilter(CodeUnit root, bool directChildrenOnly)
////            : this(root, directChildrenOnly, null)
////        {
////            Param.Ignore(root, directChildrenOnly);
////        }

////        /// <summary>
////        /// Initializes a new instance of the CodeUnitFilter class.
////        /// </summary>
////        /// <param name="customFilter">A custom filter.</param>
////        public CodeUnitFilter(CodeUnitFilterHandler customFilter)
////            : this(null, false, customFilter)
////        {
////            Param.Ignore(customFilter);
////        }

////        /// <summary>
////        /// Initializes a new instance of the CodeUnitFilter class.
////        /// </summary>
////        /// <param name="root">Restricts code units to those below this root in the hierarchy.</param>
////        /// <param name="directChildrenOnly">Determindes whether to include only those children one level below the root node.</param>
////        /// <param name="customFilter">A custom filter.</param>
////        public CodeUnitFilter(CodeUnit root, bool directChildrenOnly, CodeUnitFilterHandler customFilter)
////        {
////            Param.Ignore(root, directChildrenOnly, customFilter);

////            this.Root = root;
////            this.DirectChildrenOnly = directChildrenOnly;
////            this.CustomFilter = customFilter;
////        }

////        #endregion Public Constructors

////        #region Public Properties

////        /// <summary>
////        /// Gets or sets the root code unit.
////        /// </summary>
////        /// <remarks>Setting the value of this property causes the CodeUnit iterator and walker methods to limit 
////        /// the returned CodeUnits to those which lie below this CodeUnit in the hierarchy.</remarks>
////        public CodeUnit Root
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets a value indicating whether to match direct children of the root only.
////        /// </summary>
////        /// <remarks>If the Root property is set, and this property is set to true, then the CodeUnit iterator and walker methods will
////        /// only return CodeUnits which are direct children of the Root CodeUnit.</remarks>
////        public bool DirectChildrenOnly
////        {
////            get;
////            set;
////        }

////        /// <summary>
////        /// Gets or sets a custom filter handler.
////        /// </summary>
////        public CodeUnitFilterHandler CustomFilter
////        {
////            get;
////            set;
////        }

////        #endregion Public Properties
////    }
////}
