//////-----------------------------------------------------------------------
////// <copyright file="CodePart.cs" company="Microsoft">
//////     Copyright (c) Microsoft Corporation. All rights reserved.
////// </copyright>
////// <author>Jason Allor</author>
//////-----------------------------------------------------------------------
////namespace Microsoft.StyleCop.CSharp
////{
////    using System;
////    using System.Collections.Generic;
////    using System.Diagnostics;
////    using System.Diagnostics.CodeAnalysis;
////    using Microsoft.StyleCop.Collections;

////    /// <summary>
////    /// A basic code unit, either an expression or a statement.
////    /// </summary>
////    public abstract class CodePart : ICodePart, ILinkNode<CodeUnit>
////    {
////        #region Private Fields

////        /// <summary>
////        /// The reference to the parent code unit.
////        /// </summary>
////        private Reference<ICodePart> parentReference;

////        /// <summary>
////        /// The type of the code part.
////        /// </summary>
////        private int codePartType;

////        /// <summary>
////        /// The linked list node.
////        /// </summary>
////        private LinkNode<CodePart> linkNode;

////        #endregion Private Fields

////        #region Internal Constructors

////        /// <summary>
////        /// Initializes a new instance of the CodePart class.
////        /// </summary>
////        /// <param name="codePartType">The type of the code part.</param>
////        internal CodePart(CodePartType codePartType)
////            : this((int)codePartType)
////        {
////            Param.Ignore(codePartType);
////        }

////        /// <summary>
////        /// Initializes a new instance of the CodePart class.
////        /// </summary>
////        /// <param name="codePartType">The type of the code Part.</param>
////        internal CodePart(int codePartType)
////        {
////            Param.Ignore(codePartType);

////            this.linkNode = new LinkNode<ICodePart>(this);
////            this.codePartType = codePartType;
////            Debug.Assert(System.Enum.IsDefined(typeof(CodePartType), this.CodePartType), "The type is invalid.");
////        }

////        #endregion Internal Constructors

////        #region Public Properties

////        /// <summary>
////        /// Gets the parent of the code part.
////        /// </summary>
////        public ICodePart Parent
////        {
////            get
////            {
////                if (this.parentReference == null)
////                {
////                    return null;
////                }

////                return this.parentReference.Target;
////            }
////        }

////        /// <summary>
////        /// Gets the location of this code unit within the document.
////        /// </summary>
////        public override CodeLocation Location
////        {
////            get
////            {
////                return CodeLocation.Empty;
////            }
////        }

////        /// <summary>
////        /// Gets the line number that this code unit appears on in the document.
////        /// </summary>
////        public override int LineNumber
////        {
////            get
////            {
////                return 0;
////            }
////        }

////        /// <summary>
////        /// Gets the type of the code part.
////        /// </summary>
////        public CodePartType CodePartType
////        {
////            get
////            {
////                return (CodePartType)(this.codePartType & (int)CodeUnitMasks.CodeUnit); // todo
////            }
////        }

////        /// <summary>
////        /// Gets the back and forward links for the node.
////        /// </summary>
////        public LinkNode<CodePart> LinkNode
////        {
////            get 
////            { 
////                return this.linkNode; 
////            }
////        }

////        #endregion Public Properties

////        #region Internal Virtual Properties

////        /// <summary>
////        /// Gets or sets the parent reference.
////        /// </summary>
////        internal virtual Reference<ICodePart> ParentReference
////        {
////            get
////            {
////                return this.parentReference;
////            }

////            set
////            {
////                Param.Ignore(value);

////                if (value != this.parentReference)
////                {
////                    if (this.parentReference != null)
////                    {
////                        this.parentReference.ReferenceChanged -= new EventHandler(this.ParentReferenceChanged);
////                    }

////                    this.parentReference = value;

////                    if (value != null)
////                    {
////                        value.ReferenceChanged += new EventHandler(this.ParentReferenceChanged);
////                    }

////                    this.OnParentChanged();
////                }
////            }
////        }

////        #endregion Internal Virtual Properties

////        #region Protected Internal Properties

////        /// <summary>
////        /// Gets the unmodified code part type.
////        /// </summary>
////        protected internal int ComplexCodePartType
////        {
////            get
////            {
////                return this.codePartType;
////            }
////        }

////        #endregion Protected Internal Properties

////        #region Public Static Methods

////        /// <summary>
////        /// Determines whether the given start token lies at the start of a string of tokens matching the given array of strings.
////        /// comments.
////        /// </summary>
////        /// <param name="start">Begins matching the given strings with this token.</param>
////        /// <param name="root">The code unit that contains the tokens.</param>
////        /// <param name="values">The collection of strings to match against.</param>
////        /// <returns>Returns true if the tokens match the collection of strings.</returns>
////        /// <remarks>Only considers tokens at the same level in the hierarchy as the start token.</remarks>
////        public static bool MatchTokens(Token start, ICodePart root, params string[] values)
////        {
////            Param.RequireNotNull(start, "start");
////            Param.RequireNotNull(root, "root");
////            Param.RequireNotNull(values, "values");

////            int index = 0;
            
////            for (Token token = start; token != null && index < values.Length; token = token.NextInTree<Token>(root))
////            {
////                if (!token.Text.Equals(values[index], StringComparison.Ordinal))
////                {
////                    return false;
////                }

////                ++index;
////            }

////            return index >= values.Length;
////        }

////        #endregion Public Static Methods

////        #region Public Methods

////        /// <summary>
////        /// Gets the element that contains this code part, if there is one.
////        /// </summary>
////        /// <returns>Returns the parent element or null if there is none.</returns>
////        public Element FindParentElement()
////        {
////            return GetParent<Element>(this.Parent);
////        }

////        /// <summary>
////        /// Gets the statement that contains this code part, if there is one.
////        /// </summary>
////        /// <returns>Returns the parent statement or null if there is none.</returns>
////        public Statement FindParentStatement()
////        {
////            return GetParent<Statement>(this.Parent);
////        }

////        /// <summary>
////        /// Gets the expression that contains this code part, if there is one.
////        /// </summary>
////        /// <returns>Returns the parent expression or null if there is none.</returns>
////        public Expression FindParentExpression()
////        {
////            return GetParent<Expression>(this.Parent);
////        }

////        /// <summary>
////        /// Gets the next code part of the given type at any level in the hierarchy.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the next code unit or null if there are no code parts of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T Next<T>() where T : ICodePart
////        {
////            ICodePart codeUnit = this;
////            while (codeUnit != null)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        return typedItem;
////                    }
////                }

////                // Move down to the first of the codeUnit's children.
////                if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                {
////                    codeUnit = codeUnit.Children.First;
////                }
////                else if (codeUnit.linkNode.Next != null)
////                {
////                    // The codeUnit has no children. Move to its next sibling.
////                    codeUnit = codeUnit.linkNode.Next;
////                }
////                else
////                {
////                    // The codeUnit has no children and no siblings. Find the first ancestor with a sibling.
////                    // If the root is set, then ensure that we do not navigate above the root.
////                    CodeUnit parent = codeUnit.Parent;
////                    while (parent != null && parent.linkNode.Next == null)
////                    {
////                        parent = parent.Parent;
////                    }

////                    if (parent != null)
////                    {
////                        codeUnit = parent.linkNode.Next;
////                    }
////                    else
////                    {
////                        break;
////                    }
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the next code unit of the given type which is a descendent of the given root.
////        /// </summary>
////        /// <param name="root">The root ancenstor of the next codeUnit.</param>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T NextDescendentOf<T>(CodeUnit root) where T : CodeUnit
////        {
////            Param.Ignore(root);

////            CodeUnit codeUnit = this;
////            while (codeUnit != null)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        return typedItem;
////                    }
////                }

////                // Move down to the first of the codeUnit's children.
////                if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                {
////                    codeUnit = codeUnit.Children.First;
////                }
////                else if (codeUnit.linkNode.Next != null)
////                {
////                    // The codeUnit has no children. Move to its next sibling.
////                    codeUnit = codeUnit.linkNode.Next;
////                }
////                else
////                {
////                    // The codeUnit has no children and no siblings. Find the first ancestor with a sibling.
////                    // Ensure that we do not navigate above the root.
////                    if (codeUnit != root)
////                    {
////                        CodeUnit parent = codeUnit.Parent;
////                        while (parent != null && parent.linkNode.Next == null && parent != root)
////                        {
////                            parent = parent.Parent;
////                        }

////                        if (parent != null && parent != root)
////                        {
////                            codeUnit = parent.linkNode.Next;
////                        }
////                        else
////                        {
////                            break;
////                        }
////                    }
////                    else
////                    {
////                        break;
////                    }
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the next code unit of the given type which is a descendent of the given root or is the root itself.
////        /// </summary>
////        /// <param name="root">The root codeUnit.</param>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T NextInTree<T>(CodeUnit root) where T : CodeUnit
////        {
////            Param.Ignore(root);

////            CodeUnit codeUnit = this;
////            while (codeUnit != null)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        return typedItem;
////                    }
////                }

////                // Move down to the first of the codeUnit's children.
////                if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                {
////                    codeUnit = codeUnit.Children.First;
////                }
////                else if (codeUnit.linkNode.Next != null && codeUnit != root)
////                {
////                    // The codeUnit has no children. Move to its next sibling.
////                    codeUnit = codeUnit.linkNode.Next;
////                }
////                else
////                {
////                    // The codeUnit has no children and no siblings. Find the first ancestor with a sibling.
////                    if (codeUnit != root)
////                    {
////                        CodeUnit parent = codeUnit.Parent;
////                        while (parent != null && parent.linkNode.Next == null && parent != root)
////                        {
////                            parent = parent.Parent;
////                        }

////                        if (parent != null && parent != root)
////                        {
////                            codeUnit = parent.linkNode.Next;
////                        }
////                        else
////                        {
////                            break;
////                        }
////                    }
////                    else
////                    {
////                        break;
////                    }
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the next code unit of the given type which is a direct child of the given parent.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the next code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T NextSibling<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this.linkNode.Next;
////            while (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                codeUnit = codeUnit.linkNode.Next;
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the previous code unit of the given type at any level in the hierarchy.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T Previous<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this;
////            while (codeUnit != null)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        // We've found an codeUnit which is of the requested type and passes all the checks.
////                        return typedItem;
////                    }
////                }

////                // Move to the previous sibling if one exists.
////                if (codeUnit.linkNode.Previous != null)
////                {
////                    codeUnit = codeUnit.linkNode.Previous;

////                    // If the previous codeUnit has any children, move to the very last codeUnit
////                    // under this node.
////                    if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                    {
////                        codeUnit = codeUnit.LastDescendent<T>();
////                    }
////                }
////                else if (codeUnit.Parent != null)
////                {
////                    // The codeUnit has no previous sibling. Move to the codeUnit's parent.
////                    codeUnit = codeUnit.Parent;
////                }
////                else
////                {
////                    // The codeUnit has no previous sibling and no parent. 
////                    break;
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the previous code unit of the given type at any level in the hierarchy which is not a parent or ancestor of this code unit.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T PreviousNonParent<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this;
////            bool itemIsParent = false;

////            while (codeUnit != null)
////            {
////                if (codeUnit != this && !itemIsParent)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        // We've found an codeUnit which is of the requested type and passes all the checks.
////                        return typedItem;
////                    }
////                }

////                itemIsParent = false;

////                // Move to the previous sibling if one exists.
////                if (codeUnit.linkNode.Previous != null)
////                {
////                    codeUnit = codeUnit.linkNode.Previous;

////                    // If the previous codeUnit has any children, move to the very last codeUnit
////                    // under this node.
////                    if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                    {
////                        codeUnit = codeUnit.LastDescendent<T>();
////                    }
////                }
////                else if (codeUnit.Parent != null)
////                {
////                    // The codeUnit has no previous sibling. Move to the codeUnit's parent.
////                    codeUnit = codeUnit.Parent;
////                    itemIsParent = true;
////                }
////                else
////                {
////                    // The codeUnit has no previous sibling and no parent. 
////                    break;
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the previous code unit of the given type which is a descendent of the given root.
////        /// </summary>
////        /// <param name="root">The root ancenstor of the previous codeUnit.</param>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T PreviousDescendentOf<T>(CodeUnit root) where T : CodeUnit
////        {
////            Param.Ignore(root);

////            CodeUnit codeUnit = this;
////            while (codeUnit != null && codeUnit != root)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        // We've found an codeUnit which is of the requested type and passes all the checks.
////                        return typedItem;
////                    }
////                }

////                // Move to the previous sibling if one exists.
////                if (codeUnit.linkNode.Previous != null)
////                {
////                    codeUnit = codeUnit.linkNode.Previous;

////                    // If the previous codeUnit has any children, move to the very last codeUnit
////                    // under this node.
////                    if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                    {
////                        codeUnit = codeUnit.LastDescendent<T>();
////                    }
////                }
////                else if (codeUnit.Parent != null)
////                {
////                    // The codeUnit has no previous sibling. Move to the codeUnit's parent.
////                    codeUnit = codeUnit.Parent;
////                }
////                else
////                {
////                    // The codeUnit has no previous sibling and no parent. 
////                    break;
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the previous code unit of the given type which is a descendent of the given root or is the root itself.
////        /// </summary>
////        /// <param name="root">The root codeUnit.</param>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T PreviousInTree<T>(CodeUnit root) where T : CodeUnit
////        {
////            Param.Ignore(root);

////            CodeUnit codeUnit = this;
////            while (codeUnit != null)
////            {
////                if (codeUnit != this)
////                {
////                    T typedItem = Compare<T>(codeUnit);
////                    if (typedItem != null)
////                    {
////                        // We've found an codeUnit which is of the requested type and passes all the checks.
////                        return typedItem;
////                    }
////                }

////                // Move to the previous sibling if one exists.
////                if (codeUnit.linkNode.Previous != null && codeUnit != root)
////                {
////                    codeUnit = codeUnit.linkNode.Previous;

////                    // If the previous codeUnit has any children, move to the very last codeUnit
////                    // under this node.
////                    if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                    {
////                        codeUnit = codeUnit.LastDescendent<T>();
////                    }
////                }
////                else if (codeUnit.Parent != null && codeUnit != root)
////                {
////                    // The codeUnit has no previous sibling. Move to the codeUnit's parent.
////                    codeUnit = codeUnit.Parent;
////                }
////                else
////                {
////                    // The codeUnit has no previous sibling and no parent. 
////                    break;
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the previous code unit of the given type which is a direct child of the given parent.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the previous code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T PreviousSibling<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this.linkNode.Previous;
////            while (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    // We've found an codeUnit which is of the requested type and passes all the checks.
////                    return typedItem;
////                }

////                codeUnit = codeUnit.linkNode.Previous;
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the first code unit of the given type which is a direct child of this code unit.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T FirstChild<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this.children.First;
////            while (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                codeUnit = codeUnit.linkNode.Next;
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the first code unit of the given type which is a descendent of this code unit.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T FirstDescendent<T>() where T : CodeUnit
////        {
////            return this.NextDescendentOf<T>(this);
////        }

////        /// <summary>
////        /// Gets the first code unit of the given type which is a descendent of this code unit or this code unit itself.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the first code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T FirstInTree<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this;
////            while (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                // Move down to the first of the codeUnit's children.
////                if (codeUnit.Children != null && codeUnit.Children.Count > 0)
////                {
////                    codeUnit = codeUnit.Children.First;
////                }
////                else if (codeUnit.linkNode.Next != null)
////                {
////                    // The codeUnit has no children. Move to its next sibling.
////                    codeUnit = codeUnit.linkNode.Next;
////                }
////                else
////                {
////                    // The codeUnit has no children and no siblings. Find the first ancestor with a sibling.
////                    // Ensure that we do not navigate above this instance.
////                    if (codeUnit != this)
////                    {
////                        CodeUnit parent = codeUnit.Parent;
////                        while (parent != null && parent.linkNode.Next == null && parent != this)
////                        {
////                            parent = parent.Parent;
////                        }

////                        if (parent != null && parent != this)
////                        {
////                            codeUnit = parent.linkNode.Next;
////                        }
////                        else
////                        {
////                            break;
////                        }
////                    }
////                    else
////                    {
////                        break;
////                    }
////                }
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the last code unit of the given type which is a direct child of this code unit.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T LastChild<T>() where T : CodeUnit
////        {
////            CodeUnit codeUnit = this.children.Last;
////            while (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                codeUnit = codeUnit.linkNode.Previous;
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the last code unit of the given type which is a descendent of this code unit.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T LastDescendent<T>() where T : CodeUnit
////        {
////            // Move to the very last codeUnit in the hierarchy.
////            CodeUnit codeUnit = this.Children.Last;
////            while (codeUnit != null && codeUnit.Children.Count > 0)
////            {
////                codeUnit = codeUnit.Children.Last;
////            }

////            // Check to see if the last descendent matches the filter.
////            if (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                // The very last codeUnit does not match, so find the previous descendent of this codeUnit that matches.
////                return codeUnit.PreviousDescendentOf<T>(this);
////            }

////            return null;
////        }

////        /// <summary>
////        /// Gets the last code unit of the given type which is a descendent of this code unit or this code unit itself.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to return.</typeparam>
////        /// <returns>Returns the last code unit or null if there are no code units of the requested type.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public T LastInTree<T>() where T : CodeUnit
////        {
////            // Move to the very last codeUnit in the hierarchy.
////            CodeUnit codeUnit = this;
////            while (codeUnit != null && codeUnit.Children.Count > 0)
////            {
////                codeUnit = codeUnit.Children.Last;
////            }

////            // Check to see if the last descendent matches the filter.
////            if (codeUnit != null)
////            {
////                T typedItem = Compare<T>(codeUnit);
////                if (typedItem != null)
////                {
////                    return typedItem;
////                }

////                // The very last codeUnit does not match, so find the previous descendent of this codeUnit that matches.
////                return codeUnit.PreviousInTree<T>(this);
////            }

////            return null;
////        }

////        /// <summary>
////        /// Iterates through the descendents of the CodeUnit.
////        /// </summary>
////        /// <typeparam name="T">The type of the items to return.</typeparam>
////        /// <returns>Returns the enumerable object.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        public IEnumerable<T> Iterator<T>() where T : CodeUnit
////        {
////            return new CodeUnitEnumerable<T>(this);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="type">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(CodeUnitType type)
////        {
////            Param.Ignore(type);
////            return this.Is((int)type, CodeUnitMasks.CodeUnit);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="lexicalElementType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(LexicalElementType lexicalElementType)
////        {
////            Param.Ignore(lexicalElementType);
////            return this.Is((int)lexicalElementType, CodeUnitMasks.LexicalElement);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="tokenType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(TokenType tokenType)
////        {
////            Param.Ignore(tokenType);
////            return this.Is((int)tokenType, CodeUnitMasks.Token);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="operatorType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(OperatorType operatorType)
////        {
////            Param.Ignore(operatorType);
////            return this.Is((int)operatorType, CodeUnitMasks.Operator);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="commentType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(CommentType commentType)
////        {
////            Param.Ignore(commentType);
////            return this.Is((int)commentType, CodeUnitMasks.Comment);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="preprocessorType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(PreprocessorType preprocessorType)
////        {
////            Param.Ignore(preprocessorType);
////            return this.Is((int)preprocessorType, CodeUnitMasks.Preprocessor);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="queryClauseType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(QueryClauseType queryClauseType)
////        {
////            Param.Ignore(queryClauseType);
////            return this.Is((int)queryClauseType, CodeUnitMasks.QueryClause);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="expressionType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(ExpressionType expressionType)
////        {
////            Param.Ignore(expressionType);
////            return this.Is((int)expressionType, CodeUnitMasks.Expression);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="statementType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(StatementType statementType)
////        {
////            Param.Ignore(statementType);
////            return this.Is((int)statementType, CodeUnitMasks.Statement);
////        }

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="elementType">The type to compare against.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        public bool Is(ElementType elementType)
////        {
////            Param.Ignore(elementType);
////            return this.Is((int)elementType, CodeUnitMasks.Element);
////        }

////        /// <summary>
////        /// Walks through the code units beneath this code unit.
////        /// </summary>
////        /// <param name="callback">Callback executed when a code unit is visited.</param>
////        /// <param name="context">The optional visitor context data.</param>
////        /// <param name="codeUnitTypes">The types of the code units to return.</param>
////        /// <typeparam name="T">The type of the context codeUnit.</typeparam>
////        public void WalkCodeModel<T>(CodeUnitVisitor<T> callback, T context, params CodeUnitType[] codeUnitTypes)
////        {
////            Param.RequireNotNull(callback, "callback");
////            Param.Ignore(context);
////            Param.Ignore(codeUnitTypes);

////            CodeWalker<T>.Start(this, callback, context, codeUnitTypes);
////        }

////        /// <summary>
////        /// Walks through the code units beneath this code unit.
////        /// </summary>
////        /// <param name="callback">Callback executed when a code unit is visited.</param>
////        /// <param name="context">The optional visitor context data.</param>
////        /// <typeparam name="T">The type of the context codeUnit.</typeparam>
////        public void WalkCodeModel<T>(CodeUnitVisitor<T> callback, T context)
////        {
////            Param.RequireNotNull(callback, "callback");
////            Param.Ignore(context);

////            CodeWalker<T>.Start(this, callback, context, null);
////        }

////        /// <summary>
////        /// Walks through the code units beneath this code unit.
////        /// </summary>
////        /// <param name="callback">Callback executed when a code unit is visited.</param>
////        /// <param name="codeUnitTypes">The types of code units to visit.</param>
////        public void WalkCodeModel(CodeUnitVisitor<object> callback, params CodeUnitType[] codeUnitTypes)
////        {
////            Param.RequireNotNull(callback, "callback");
////            Param.Ignore(codeUnitTypes);

////            CodeWalker<object>.Start(this, callback, null, codeUnitTypes);
////        }

////        /// <summary>
////        /// Walks through the code units beneath this code unit.
////        /// </summary>
////        /// <param name="callback">Callback executed when a code unit is visited.</param>
////        public void WalkCodeModel(CodeUnitVisitor<object> callback)
////        {
////            Param.RequireNotNull(callback, "callback");

////            CodeWalker<object>.Start(this, callback, null, null);
////        }

////        #endregion Public Methods

////        #region Internal Static Methods

////        /// <summary>
////        /// Given a parent code unit, traverses through the parent hierarchy to find a parent element, if there is one.
////        /// </summary>
////        /// <param name="parent">The parent.</param>
////        /// <typeparam name="T">The type of the parent to return.</typeparam>
////        /// <returns>Returns the parent element or null if there is none.</returns>
////        internal static T GetParent<T>(CodeUnit parent) where T : CodeUnit
////        {
////            Param.Ignore(parent);

////            if (parent != null)
////            {
////                CodeUnit parentCodeUnit = parent;
////                while (parentCodeUnit != null)
////                {
////                    T codeUnit = parentCodeUnit as T;
////                    if (codeUnit != null)
////                    {
////                        return codeUnit;
////                    }

////                    parentCodeUnit = parentCodeUnit.Parent;
////                }
////            }

////            return null;
////        }

////        #endregion Internal Static Methods

////        #region Internal Methods

////        /// <summary>
////        /// Gets the friendly name of the code unit type, which can be used in user output.
////        /// </summary>
////        /// <param name="typeName">The name of the type.</param>
////        /// <returns>Returns the friendly name text.</returns>
////        internal string GetFriendlyTypeText(string typeName)
////        {
////            Param.Ignore(typeName);

////            if (this.friendlyTypeName == null && typeName != null)
////            {
////                this.friendlyTypeName = TypeNames.ResourceManager.GetString(typeName, TypeNames.Culture);
////            }

////            return this.friendlyTypeName;
////        }

////        /// <summary>
////        /// Gets the friendly name of the code unit type as a plural noun, which can be used in user output.
////        /// </summary>
////        /// <param name="typeName">The name of the type.</param>
////        /// <returns>Returns the plural friendly name text.</returns>
////        internal string GetFriendlyPluralTypeText(string typeName)
////        {
////            Param.Ignore(typeName);

////            if (this.friendlyPluralTypeName == null && typeName != null)
////            {
////                this.friendlyPluralTypeName = TypeNames.ResourceManager.GetString(typeName + "Plural", TypeNames.Culture);
////            }

////            return this.friendlyPluralTypeName;
////        }

////        /// <summary>
////        /// Validates that the token's parent code unit references has been set.
////        /// </summary>
////        [Conditional("DEBUG")]
////        internal void ValidateCodeUnitReference()
////        {
////            if ((this.parentReference == null || this.parentReference.CodeUnit == null) && !(this is DocumentRoot))
////            {
////                Debug.Fail("Parent code unit reference has not been set for token. DocumentRoot is the only code unit type which is allowed to have a null parent.");
////            }
////        }

////        /// <summary>
////        /// Detaches the code unit from the code unit collection that contains it.
////        /// </summary>
////        internal void Detach()
////        {
////            if (this.parentReference != null && this.parentReference.CodeUnit != null)
////            {
////                this.parentReference.CodeUnit.Children.Remove(this);
                
////                // Null the parent reference. Use the property to make sure the appropriate events get fired.
////                this.ParentReference = null;
////            }
////        }

////        #endregion Internal Methods

////        #region Protected Virtual Methods

////        /// <summary>
////        /// Called when the parent of the element changes.
////        /// </summary>
////        protected virtual void OnParentChanged()
////        {
////        }

////        /// <summary>
////        /// Collects the variables declared by the code unit.
////        /// </summary>
////        protected virtual void CollectVariables()
////        {
////        }

////        #endregion Protected Virtual Methods

////        #region Protected Override Methods

////        /// <summary>
////        /// Gets the collection of children beneath this code unit.
////        /// </summary>
////        /// <returns>Returns the child collection.</returns>
////        protected override ICollection<CodePart> GetChildCodeParts()
////        {
////            return new CollectionAdapter<CodeUnit, CodePart>(this.children, delegate(CodeUnit c) { return c; });
////        }

////        /// <summary>
////        /// Gets the parent of this code unit.
////        /// </summary>
////        /// <returns>Returns the parent.</returns>
////        protected override CodePart GetParentCodePart()
////        {
////            return this.Parent;
////        }

////        #endregion Protected Override Methods

////        #region Protected Methods

////        /// <summary>
////        /// Iterates through the tokens in the element declaration and extracts the parameters, if any.
////        /// </summary>
////        /// <param name="startToken">The first token to begin searching for the parameter list.</param>
////        /// <param name="parameterListEndBracket">The type of the end bracket.</param>
////        /// <returns>Returns the parameters.</returns>
////        protected IList<Parameter> CollectFormalParameters(Token startToken, TokenType parameterListEndBracket)
////        {
////            Param.Ignore(startToken);
////            Param.Ignore(parameterListEndBracket);

////            if (startToken == null)
////            {
////                return Parameter.EmptyParameterArray;
////            }

////            var list = new List<Parameter>();
////            for (CodeUnit codeUnit = startToken; codeUnit != null; codeUnit = codeUnit.NextSibling<CodeUnit>())
////            {
////                // If we hit the closing bracket before we've seen a parameter list, then quit.
////                if (codeUnit.Is(parameterListEndBracket))
////                {
////                    break;
////                }

////                if (codeUnit.CodeUnitType == CodeUnitType.ParameterList)
////                {
////                    // We've found the parameter list. Add each child parameter then quit.
////                    for (Parameter parameter = codeUnit.FirstChild<Parameter>(); parameter != null; parameter = parameter.NextSibling<Parameter>())
////                    {
////                        list.Add(parameter);
////                    }

////                    break;
////                }
////            }

////            return list.ToArray();
////        }

////        #endregion Protected Methods

////        #region Private Static Methods

////        /// <summary>
////        /// Checks the given CodeUnit to see if it is of the expected type and passes the filter.
////        /// </summary>
////        /// <typeparam name="T">The type of the codeUnit to match against.</typeparam>
////        /// <param name="codeUnit">The codeUnit to check.</param>
////        /// <returns>Returns true if the codeUnit matches; false otherwise.</returns>
////        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The method does not require a parameter of type T.")]
////        private static T Compare<T>(CodeUnit codeUnit) where T : CodeUnit
////        {
////            Param.Ignore(codeUnit);

////            T typedItem = codeUnit as T;
////            if (typedItem != null)
////            {
////                return typedItem;
////            }

////            return null;
////        }

////        #endregion Private Statics Methods

////        #region Private Methods

////        /// <summary>
////        /// Determines whether the codeUnit is of the given type.
////        /// </summary>
////        /// <param name="type">The type of CodeUnit to search for.</param>
////        /// <param name="mask">The mask to apply to the type.</param>
////        /// <returns>Returns true if the codeUnit is of the given type; false otherwise.</returns>
////        private bool Is(int type, CodeUnitMasks mask)
////        {
////            Param.Ignore(type, mask);
////            return (this.codeUnitType & (int)mask) == type;
////        }

////        /// <summary>
////        /// Called when the parent reference changes.
////        /// </summary>
////        /// <param name="sender">The event sender.</param>
////        /// <param name="e">The event arguments.</param>
////        private void ParentReferenceChanged(object sender, EventArgs e)
////        {
////            Param.Ignore(sender, e);
////            this.OnParentChanged();
////        }

////        #endregion Private Methods

////        #region Protected Classes

////        /// <summary>
////        /// Gets an enumerator for iterating through the descendents of a CodeUnit.
////        /// </summary>
////        /// <typeparam name="T">The type of CodeUnits the enumerator should return.</typeparam>
////        [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "The class is not a collection.")]
////        protected class CodeUnitEnumerable<T> : IEnumerable<T> where T : CodeUnit
////        {
////            /// <summary>
////            /// The CodeUnit to iterate through.
////            /// </summary>
////            private CodeUnit codeUnit;

////            /// <summary>
////            /// Initializes a new instance of the CodeUnitEnumerable class.
////            /// </summary>
////            /// <param name="codeUnit">The CodeUnit to iterate through.</param>
////            public CodeUnitEnumerable(CodeUnit codeUnit)
////            {
////                Param.AssertNotNull(codeUnit, "codeUnit");
////                this.codeUnit = codeUnit;
////            }

////            /// <summary>
////            /// Gets an enumerator for iterating through the descendents of the CodeUnit.
////            /// </summary>
////            /// <returns>Returns the enumerator.</returns>
////            public IEnumerator<T> GetEnumerator()
////            {
////                return new CodeUnitEnumerator<T>(this.codeUnit);
////            }

////            /// <summary>
////            /// Gets an enumerator for iterating through the descendents of the CodeUnit.
////            /// </summary>
////            /// <returns>Returns the enumerator.</returns>
////            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
////            {
////                return this.GetEnumerator();
////            }
////        }

////        #endregion Protected Classes

////        #region Private Classes

////        /// <summary>
////        /// Enumerates through the descendents of a CodeUnit.
////        /// </summary>
////        /// <typeparam name="T">The type of the CodeUnits to return.</typeparam>
////        private class CodeUnitEnumerator<T> : IEnumerator<T> where T : CodeUnit
////        {
////            /// <summary>
////            /// The code unit to iterate through.
////            /// </summary>
////            private CodeUnit codeUnit;

////            /// <summary>
////            /// The current codeUnit.
////            /// </summary>
////            private T currentItem;

////            /// <summary>
////            /// Initializes a new instance of the CodeUnitEnumerator class.
////            /// </summary>
////            /// <param name="codeUnit">The code unit to iterate through.</param>
////            public CodeUnitEnumerator(CodeUnit codeUnit)
////            {
////                Param.AssertNotNull(codeUnit, "codeUnit");
////                this.codeUnit = codeUnit;
////            }

////            /// <summary>
////            /// Gets the current codeUnit.
////            /// </summary>
////            public T Current 
////            {
////                get
////                {
////                    return this.currentItem;
////                }
////            }

////            /// <summary>
////            /// Gets the current codeUnit.
////            /// </summary>
////            object System.Collections.IEnumerator.Current 
////            {
////                get
////                {
////                    return this.currentItem;
////                }
////            }

////            /// <summary>
////            /// Moves to the next codeUnit in the collection.
////            /// </summary>
////            /// <returns>Returns true if the index was moved; false if there are no more items in the collection.</returns>
////            public bool MoveNext()
////            {
////                if (this.currentItem == null)
////                {
////                    this.currentItem = this.codeUnit.FirstDescendent<T>();
////                }
////                else
////                {
////                    this.currentItem = this.currentItem.NextDescendentOf<T>(this.codeUnit);
////                }

////                return this.currentItem != null;
////            }

////            /// <summary>
////            /// Resets the enumerator.
////            /// </summary>
////            public void Reset()
////            {
////                this.currentItem = null;
////            }

////            /// <summary>
////            /// Disposes the contents of the class.
////            /// </summary>
////            public void Dispose()
////            {
////                GC.SuppressFinalize(this);
////            }
////        }

////        #endregion Private Classes
////    }
////}
