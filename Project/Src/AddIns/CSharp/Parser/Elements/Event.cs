//-----------------------------------------------------------------------
// <copyright file="Event.cs" company="Microsoft">
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
        private CodeUnitProperty<TypeToken> eventHandlerType;

        /// <summary>
        /// The declarators on the event.
        /// </summary>
        private CodeUnitProperty<ICollection<EventDeclaratorExpression>> declarators;

        /// <summary>
        /// The add accessor.
        /// </summary>
        private CodeUnitProperty<Accessor> add;

        /// <summary>
        /// The remove accessor.
        /// </summary>
        private CodeUnitProperty<Accessor> remove;

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

            this.eventHandlerType.Value = eventHandlerType;
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
                this.ValidateEditVersion();

                if (!this.eventHandlerType.Initialized)
                {
                    this.eventHandlerType.Value = this.FindFirstChild<TypeToken>();
                }

                return this.eventHandlerType.Value;
            }
        }

        /// <summary>
        /// Gets the optional declarator expressions.
        /// </summary>
        public ICollection<EventDeclaratorExpression> Declarators
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.declarators.Initialized)
                {
                    this.declarators.Value = new List<EventDeclaratorExpression>(this.GetChildren<EventDeclaratorExpression>()).AsReadOnly();
                }

                return this.declarators.Value;
            }
        }

        /// <summary>
        /// Gets the add accessor for the event, if there is one.
        /// </summary>
        public Accessor AddAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.add.Initialized)
                {
                    this.add.Value = null;

                    // Find the add and remove accessors for this event, if they exist.
                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Add)
                        {
                            this.add.Value = child;
                        }
                    }
                }

                return this.add.Value;
            }
        }

        /// <summary>
        /// Gets the remove accessor for the event, if there is one.
        /// </summary>
        public Accessor RemoveAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.remove.Initialized)
                {
                    this.remove.Value = null;

                    // Find the add and remove accessors for this event, if they exist.
                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Remove)
                        {
                            this.remove.Value = child;
                        }
                    }
                }

                return this.remove.Value;
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

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            // For an event, the name of the first event declarator is the name of the event.
            EventDeclaratorExpression declarator = this.FindFirstChild<EventDeclaratorExpression>();
            if (declarator != null)
            {
                return declarator.Identifier.Text;
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.eventHandlerType.Reset();
            this.declarators.Reset();
            this.add.Reset();
            this.remove.Reset();
        }

        #endregion Protected Override Methods
    }
}
