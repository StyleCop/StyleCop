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
        private TypeToken eventHandlerType;

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
        /// Gets the optional declarator expressions.
        /// </summary>
        public IEnumerable<EventDeclaratorExpression> Declarators
        {
            get
            {
                return this.GetChildren<EventDeclaratorExpression>();
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

        #region Public Methods

        /// <summary>
        /// Gets the add accessor for the event, if there is one.
        /// </summary>
        /// <returns>Returns the add accessor or null if there is none.</returns>
        public Accessor FindAddAccessor()
        {
            // Find the add and remove accessors for this event, if they exist.
            for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
            {
                if (child.AccessorType == AccessorType.Add)
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the remove accessor for the event, if there is one.
        /// </summary>
        /// <returns>Returns the remove accessor or null if there is none.</returns>
        public Accessor FindRemoveAccessor()
        {
            // Find the add and remove accessors for this event, if they exist.
            for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
            {
                if (child.AccessorType == AccessorType.Add)
                {
                    return child;
                }
            }

            return null;
        }

        #endregion Public Methods

        #region Public Override Methods

        /// <summary>
        /// Gets the variables defined within this event.
        /// </summary>
        /// <returns>Returns the collection of variables.</returns>
        public override IList<IVariable> GetVariables()
        {
            List<IVariable> variables = new List<IVariable>();

            for (EventDeclaratorExpression declarator = this.FindFirstChild<EventDeclaratorExpression>(); declarator != null; declarator.FindNextSibling<EventDeclaratorExpression>())
            {
                variables.Add(declarator);
            }

            return variables.AsReadOnly();
        }

        #endregion Public Override Methods
    }
}
