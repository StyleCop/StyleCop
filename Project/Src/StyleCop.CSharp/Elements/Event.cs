// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="https://github.com/StyleCop">
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
//   Describes an event element.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes an event element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# event")]
    public sealed class Event : CsElement
    {
        #region Fields

        /// <summary>
        /// Optional declarators for the event.
        /// </summary>
        private readonly ICollection<EventDeclaratorExpression> eventDeclarators;

        /// <summary>
        /// The event handler type.
        /// </summary>
        private readonly TypeToken eventHandlerType;

        /// <summary>
        /// The add accessor for the event.
        /// </summary>
        private Accessor add;

        /// <summary>
        /// The remove accessor for the event.
        /// </summary>
        private Accessor remove;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Event class.
        /// </summary>
        /// <param name="document">
        /// The document that contains this element.
        /// </param>
        /// <param name="parent">
        /// The parent of the element.
        /// </param>
        /// <param name="header">
        /// The Xml header for this element.
        /// </param>
        /// <param name="attributes">
        /// The list of attributes attached to this element.
        /// </param>
        /// <param name="declaration">
        /// The declaration code for this element.
        /// </param>
        /// <param name="eventHandlerType">
        /// The type of the event handler.
        /// </param>
        /// <param name="eventDeclarators">
        /// Declarators for the event.
        /// </param>
        /// <param name="unsafeCode">
        /// Indicates whether the element resides within a block of unsafe code.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the code element was generated or written by hand.
        /// </param>
        internal Event(
            CsDocument document, 
            CsElement parent, 
            XmlHeader header, 
            ICollection<Attribute> attributes, 
            Declaration declaration, 
            TypeToken eventHandlerType, 
            ICollection<EventDeclaratorExpression> eventDeclarators, 
            bool unsafeCode, 
            bool generated)
            : base(document, parent, ElementType.Event, "event " + declaration.Name, header, attributes, declaration, unsafeCode, generated)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(header);
            Param.Ignore(attributes);
            Param.AssertNotNull(declaration, "declaration");
            Param.AssertNotNull(eventHandlerType, "eventHandlerType");
            Param.AssertNotNull(eventDeclarators, "eventDeclarators");
            Param.Ignore(unsafeCode);
            Param.Ignore(generated);

            this.eventHandlerType = eventHandlerType;
            this.eventDeclarators = eventDeclarators;

            foreach (EventDeclaratorExpression expression in this.eventDeclarators)
            {
                this.AddExpression(expression);
                expression.ParentEvent = this;
            }
        }

        #endregion

        #region Public Properties

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
        /// Gets the optional initialization expression.
        /// </summary>
        public ICollection<EventDeclaratorExpression> Declarators
        {
            get
            {
                return this.eventDeclarators;
            }

            ////internal set
            ////{
            ////    Param.AssertNotNull(value, "Declarators");
            ////    Debug.Assert(this.eventDeclarators == null, "Declarators has already been set.");
            ////    this.eventDeclarators = value;
            ////    foreach (Expression expression in this.eventDeclarators)
            ////    {
            ////        this.AddExpression(expression);
            ////    }
            ////}
        }

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
        /// Gets the remove accessor for the event, if there is one.
        /// </summary>
        public Accessor RemoveAccessor
        {
            get
            {
                return this.remove;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the contents of the event.
        /// </summary>
        internal override void Initialize()
        {
            base.Initialize();

            // Find the add and remove accessors for this event, if they exist.
            foreach (CsElement child in this.ChildElements)
            {
                Accessor accessor = child as Accessor;
                if (accessor == null)
                {
                    throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                }

                if (accessor.AccessorType == AccessorType.Add)
                {
                    if (this.add != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                    }

                    this.add = accessor;
                }
                else if (accessor.AccessorType == AccessorType.Remove)
                {
                    if (this.remove != null)
                    {
                        throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                    }

                    this.remove = accessor;
                }
                else
                {
                    throw new SyntaxException(this.Document.SourceCode, accessor.LineNumber);
                }
            }
        }

        #endregion
    }
}