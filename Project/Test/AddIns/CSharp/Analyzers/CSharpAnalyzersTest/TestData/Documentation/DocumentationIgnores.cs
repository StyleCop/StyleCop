using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class PublicClass
    {
        public void PublicMethod() { }
        internal void InternalMethod() { }
        protected void ProtectedMethod() { }
        protected internal void ProtectedInternalMethod() { }
        private void PrivateMethod() { }

        public class PublicClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        protected class ProtectedClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        internal class InternalClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        protected internal class ProtectedInternalClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        private class PrivateClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }
    }

    internal class InternalClass
    {
        public void PublicMethod() { }
        internal void InternalMethod() { }
        protected void ProtectedMethod() { }
        protected internal void ProtectedInternalMethod() { }
        private void PrivateMethod() { }

        public class PublicClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        protected class ProtectedClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        internal class InternalClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        protected internal class ProtectedInternalClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }

        private class PrivateClass
        {
            public void PublicMethod() { }
            internal void InternalMethod() { }
            protected void ProtectedMethod() { }
            protected internal void ProtectedInternalMethod() { }
            private void PrivateMethod() { }
        }
    }
}
