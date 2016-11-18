using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderEnums
    {
        // Valid enums
        enum ValidEnum1
        {
        }

        public enum ValidEnum2
        {
        }

        internal enum ValidEnum3
        {
        }

        protected enum ValidEnum4
        {
        }

        protected internal enum ValidEnum5
        {
        }

        private enum ValidEnum6
        {
        }

        new enum ValidEnum7
        {
        }

        public new enum ValidEnum8
        {
        }

        internal new enum ValidEnum9
        {
        }

        protected new enum ValidEnum10
        {
        }

        protected internal new enum ValidEnum11
        {
        }

        private new enum ValidEnum112
        {
        }

        // Invalid enums
        internal protected enum InvalidEnum1
        {
        }

        new public enum InvalidEnum2
        {
        }

        new internal enum InvalidEnum3
        {
        }

        new protected enum InvalidEnum4
        {
        }

        new protected internal enum InvalidEnum5
        {
        }

        new internal protected enum InvalidEnum6
        {
        }

        protected new internal enum InvalidEnum7
        {
        }

        internal new protected enum InvalidEnum8
        {
        }

        internal protected new enum InvalidEnum9
        {
        }

        new private enum InvalidEnum10
        {
        }
    }
}
