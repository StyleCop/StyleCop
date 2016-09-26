using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvDTE;

namespace VSPackageUnitTest.Mocks
{
    internal class MockDocuments : EnvDTE.Documents
    {
        private readonly MockDTE _dte;
        public MockDocuments(MockDTE dte)
        {
            this._dte = dte;
        }

        public MockDocuments()
        {

        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DTE DTE
        {
            get
            {
                return this._dte;
            }
        }

        public DTE Parent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Document Add(string Kind)
        {
            throw new NotImplementedException();
        }

        public void CloseAll(vsSaveChanges Save = vsSaveChanges.vsSaveChangesPrompt)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new MockDocument(this._dte);
        }

        public Document Item(object index)
        {
            throw new NotImplementedException();
        }

        public Document Open(string PathName, string Kind = "Auto", bool ReadOnly = false)
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
