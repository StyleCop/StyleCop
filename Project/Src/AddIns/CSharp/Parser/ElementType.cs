//-----------------------------------------------------------------------
// <copyright file="ElementType.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.CSharp
{
    // The elements are listed in the order they should appear in the code.

    /// <summary>
    /// The various types of elements in a C# code file.
    /// </summary>
    /// <subcategory>element</subcategory>
    public enum ElementType
    {
        /// <summary>
        /// A code file.
        /// </summary>
        File = 0,

        /// <summary>
        /// The root of a document.
        /// </summary>
        Root = 1,

        /// <summary>
        /// An extern alias directive.
        /// </summary>
        ExternAliasDirective = 2,

        /// <summary>
        /// A using directive.
        /// </summary>
        UsingDirective = 3,
       
        /// <summary>
        /// A namespace element.
        /// </summary>
        Namespace = 4,

        /// <summary>
        /// A field element.
        /// </summary>
        Field = 5,

        /// <summary>
        /// A constructor element. 
        /// </summary>
        Constructor = 6,

        /// <summary>
        /// A destructor element.
        /// </summary>
        Destructor = 7,

        /// <summary>
        /// A delegate element.
        /// </summary>
        Delegate = 8,

        /// <summary>
        /// An event element.
        /// </summary>
        Event = 9,

        /// <summary>
        /// An enum element.
        /// </summary>
        Enum = 10,

        /// <summary>
        /// An interface element.
        /// </summary>
        Interface = 11,

        /// <summary>
        /// A property element.
        /// </summary>
        Property = 12,

        /// <summary>
        /// An accessor inside of a property, indexer, or event.
        /// </summary>
        Accessor = 13,

        /// <summary>
        /// An indexer element.
        /// </summary>
        Indexer = 14,

        /// <summary>
        /// A method element.
        /// </summary>
        Method = 15,

        /// <summary>
        /// A struct element.
        /// </summary>
        Struct = 16,

        /// <summary>
        /// A class element.
        /// </summary>
        Class = 17,

        /// <summary>
        /// An item in an enumeration.
        /// </summary>
        EnumItem = 18,

        /// <summary>
        /// The initialization code within a constructor's declaration.
        /// </summary>
        ConstructorInitializer = 19,

        /// <summary>
        /// An element consisting only of a single semicolon.
        /// </summary>
        EmptyElement = 20,
    }
}