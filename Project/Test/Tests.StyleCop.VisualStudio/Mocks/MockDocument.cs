using EnvDTE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSPackageUnitTest.Mocks
{
    internal class MockDocument : Document
    {
        private readonly string _fullName = "C:\\MockDocument.cs";

        private readonly MockTextSelection _textSelection = new MockTextSelection();

        private readonly MockDTE _dte;
        public MockDocument(MockDTE dte)
        {
            this._dte = dte;
        }

        public MockDocument()
        {

        }

        public Window ActiveWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Documents Collection
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

        public string ExtenderCATID
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object ExtenderNames
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FullName
        {
            get
            {
                return this._fullName;
            }
        }

        public int IndentSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Kind
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Language
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Path
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ProjectItem ProjectItem
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Saved
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public object Selection
        {
            get
            {
                return this._textSelection;
            }
        }

        public int TabSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Windows Windows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Activate()
        {
        }

        public void ClearBookmarks()
        {
            throw new NotImplementedException();
        }

        public void Close(vsSaveChanges Save = vsSaveChanges.vsSaveChangesPrompt)
        {
            throw new NotImplementedException();
        }

        public object get_Extender(string ExtenderName)
        {
            throw new NotImplementedException();
        }

        public bool MarkText(string Pattern, int Flags = 0)
        {
            throw new NotImplementedException();
        }

        public Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public object Object(string ModelKind = "")
        {
            throw new NotImplementedException();
        }

        public void PrintOut()
        {
            throw new NotImplementedException();
        }

        public bool Redo()
        {
            throw new NotImplementedException();
        }

        public bool ReplaceText(string FindText, string ReplaceText, int Flags = 0)
        {
            throw new NotImplementedException();
        }

        public vsSaveStatus Save(string FileName = "")
        {
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            throw new NotImplementedException();
        }
    }
}
