using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// Summary for the class.
    /// </summary>
    public class DocumentationEventClass
    {
        /// <summary>
        /// This is the summary for the event.
        /// </summary>
        public event EventHandler ValidDocumentationEvent1;

        /// <summary>
        /// This is the summary for the event.
        /// </summary>
        protected event EventHandler ValidDocumentationEvent2;

        /// <summary>
        /// This is the summary for the event.
        /// </summary>
        internal event EventHandler ValidDocumentationEvent3;

        /// <summary>
        /// This is the summary for the event.
        /// </summary>
        internal protected event EventHandler ValidDocumentationEvent4;

        /// <summary>
        /// This is the summary for the event.
        /// </summary>
        private event EventHandler ValidDocumentationEvent5;

        /// <summary>
        /// Summary description for event.
        /// </summary>
        public event EventHandler InvalidDocumentationEvent1;

        /// <summary>
        /// Invalid Xml
        /// </summary2>
        public event EventHandler InvalidDocumentationEvent2;

        public event EventHandler InvalidDocumentationEvent3;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler InvalidDocumentationEvent4;

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        public event EventHandler InvalidDocumentationEvent5;

        /// <summary>
        /// Short.
        /// </summary>
        public event EventHandler InvalidDocumentationEvent6;

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        public event EventHandler InvalidDocumentationEvent7;

        /// <summary>
        /// no capital letter.
        /// </summary>
        public event EventHandler InvalidDocumentationEvent8;

        /// <summary>
        /// No closing period
        /// </summary>
        public event EventHandler InvalidDocumentationEvent9;

        /// <summary>
        /// This is the class summary.
        /// </summary>
        internal class InvalidDocumentationEventClass
        {
            /// <summary>
            /// This is the private class summary.
            /// </summary>
            private class PrivateClass
            {
                public event EventHandler Event1;
            }
        }

        protected event EventHandler InvalidDocumentationEvent10;

        internal event EventHandler InvalidDocumentationEvent11;

        protected internal event EventHandler InvalidDocumentationEvent12;

        private event EventHandler InvalidDocumentationEvent13;

        /////// <summary>
        /////// This is the summary.
        /////// </summary>
        /////// <remarks></remarks>
        ////public event EventHandler InvalidDocumentationEvent14;
    }
}
