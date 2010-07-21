//-----------------------------------------------------------------------
// <copyright file="ICodeUnit.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes an event element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# event")]
    public sealed class Event : Element
    {
        #region Private Fields

        /// <summary>
        /// The event handler type.
        /// </summary>
        private TypeToken eventHandlerType;

        /// <summary>
        /// The add accessor for the event.
        /// </summary>
        private Accessor add;

        /// <summary>
        /// The remove accessor for the event.
        /// </summary>
        private Accessor remove;

        /// <summary>
        /// An optional initialization expression for the event.
        /// </summary>
        private Expression initializationExpression;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Event class.
        /// </summary>
        /// <param name="proxy">Proxy object for the event.</param>
        /// <param name="name">The name of the event.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="eventHandlerType">The type of the event handler.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Event(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken eventHandlerType, bool unsafeCode)
            : base(proxy, ElementType.Event, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.AssertNotNull(eventHandlerType, "eventHandlerType");
            Param.Ignore(unsafeCode);

            this.eventHandlerType = eventHandlerType;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the event handler's return type.
        /// </summary>
        public TypeToken EventHandlerType
        {
            get
            {
                return this.eventHandlerType;
            }
        }

        /// <summary>
        /// Gets the add accessor for the event, if there is one.
        /// </summary>
        public Accessor AddAccessor
        {
            get
            {
                return this.add;
            }
        }

        /// <summary>
        /// Gets the remove accessor for the event, if there is one.
        /// </summary>
        public Accessor RemoveAccessor
        {
            get
            {
                return this.remove;
            }
        }

        /// <summary>
        /// Gets the optional initialization expression.
        /// </summary>
        public Expression InitializationExpression
        {
            get
            {
                return this.initializationExpression;
            }

            internal set
            {
                Param.AssertNotNull(value, "InitializationExpression");

                this.initializationExpression = value;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return CodeParser.EventModifiers;
            }
        }

        #endregion Protected Override Properties

        #region Internal Override Methods

        /// <summary>
        /// Initializes the contents of the event.
        /// </summary>
        /// <param name="document">The document that contains the element.</param>
        internal override void Initialize(CsDocument document)
        {
            Param.AssertNotNull(document, "document");
            base.Initialize(document);

            // Find the add and remove accessors for this event, if they exist.
            for (Element child = this.FindFirstChild<Element>(); child != null; child = child.FindNextSibling<Element>())
            {
                Accessor accessor = child as Accessor;
                if (accessor == null)
                {
                    throw new SyntaxException(document.SourceCode, accessor.LineNumber);
                }

                if (accessor.AccessorType == AccessorType.Add)
                {
                    if (this.add != null)
                    {
                        throw new SyntaxException(document.SourceCode, accessor.LineNumber);
                    }

                    this.add = accessor;
                }
                else if (accessor.AccessorType == AccessorType.Remove)
                {
                    if (this.remove != null)
                    {
                        throw new SyntaxException(document.SourceCode, accessor.LineNumber);
                    }

                    this.remove = accessor;
                }
                else
                {
                    throw new SyntaxException(document.SourceCode, accessor.LineNumber);
                }
            }
        }

        #endregion Internal Override Methods
    }
}
