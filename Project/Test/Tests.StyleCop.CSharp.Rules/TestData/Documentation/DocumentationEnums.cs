using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum ValidDocumentationEnum1
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum ValidDocumentationEnum2
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    protected enum ValidDocumentationEnum3
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    protected enum ValidDocumentationEnum4
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    internal enum ValidDocumentationEnum5
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    internal enum ValidDocumentationEnum6
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    internal protected enum ValidDocumentationEnum7
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    internal protected enum ValidDocumentationEnum8
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    private enum ValidDocumentationEnum9
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    private enum ValidDocumentationEnum10
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum ValidDocumentationEnum11 : int
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum ValidDocumentationEnum12 : int
    {
        /// <summary>
        /// This is the summary for the item.
        /// </summary>
        Item = 1
    }

    /// <summary>
    /// Summary description for enum.
    /// </summary>
    public enum InvalidDocumentationEnum1
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum2
    {
        /// <summary>
        /// Summary description for item.
        /// </summary>
        Item
    }

    /// <summary>
    /// Invalid Xml
    /// </summary2>
    public enum InvalidDocumentationEnum3
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum4
    {
        /// <summary>
        /// Invalid xml
        /// </summary3>
        Item
    }

    public enum InvalidDocumentationEnum5
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum6
    {
        Item
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum7
    {
        /// <summary>
        /// This is the first item.
        /// </summary>
        FirstItem,

        SecondItem
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum8
    {
        FirstItem,

        /// <summary>
        /// This is the second item.
        /// </summary>
        SecondItem
    }


    /// <summary>
    /// 
    /// </summary>
    public enum InvalidDocumentationEnum9
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum10
    {
        /// <summary>
        /// 
        /// </summary>
        Item
    }

    /// <summary>
    /// Nospaceshereatall.
    /// </summary>
    public enum InvalidDocumentationEnum11
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum12
    {
        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        Item
    }

    /// <summary>
    /// Short.
    /// </summary>
    public enum InvalidDocumentationEnum13
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum14
    {
        /// <summary>
        /// Short.
        /// </summary>
        Item
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public enum InvalidDocumentationEnum15
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum16
    {
        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        Item
    }

    /// <summary>
    /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
    /// </summary>
    public class InvalidDocumentationClass17
    {
    }

    /// <summary>
    /// no capital letter.
    /// </summary>
    public enum InvalidDocumentationEnum18
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum19
    {
        /// <summary>
        /// no capital letter.
        /// </summary>
        Item
    }

    /// <summary>
    /// No closing period
    /// </summary>
    public enum InvalidDocumentationEnum20
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum21
    {
        /// <summary>
        /// No closing period
        /// </summary>
        Item
    }

    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class InvalidDocumentationEnumClass
    {
        /// <summary>
        /// This is the private class summary.
        /// </summary>
        private class PrivateClass
        {
            public enum Enum1
            {
            }

            /// <summary>
            /// This is the summary for the enum.
            /// </summary>
            public enum Enum2
            {
                Item
            }
        }
    }

    protected enum InvalidDocumentationEnum22
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    protected enum InvalidDocumentationEnum23
    {
        Item
    }

    internal enum InvalidDocumentationEnum24
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    internal enum InvalidDocumentationEnum25
    {
        Item
    }

    protected internal enum InvalidDocumentationEnum26
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    protected internal enum InvalidDocumentationEnum27
    {
        Item
    }

    private enum InvalidDocumentationEnum28
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    private enum InvalidDocumentationEnum29
    {
        Item
    }

    /// <summary>
    /// This is the summary.
    /// </summary>
    /// <remarks></remarks>
    public enum InvalidDocumentationEnum30
    {
    }

    /// <summary>
    /// This is the summary for the enum.
    /// </summary>
    public enum InvalidDocumentationEnum31
    {
        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <remarks></remarks>
        Item
    }

    public enum RedGreen
    {
        Red,

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "This is fine.")]
        Green
    }
}
