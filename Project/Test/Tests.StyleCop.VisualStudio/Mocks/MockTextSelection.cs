using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSPackageUnitTest.Mocks
{
    internal class MockTextSelection : TextSelection
    {
        private readonly MockVirtualPoint _virtualPoint = new MockVirtualPoint();

        public VirtualPoint ActivePoint
        {
            get
            {
                return this._virtualPoint;
            }
        }

        public int AnchorColumn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public VirtualPoint AnchorPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int BottomLine
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public VirtualPoint BottomPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int CurrentColumn
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int CurrentLine
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
                throw new NotImplementedException();
            }
        }

        public bool IsActiveEndGreater
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public vsSelectionMode Mode
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

        public TextDocument Parent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Text
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

        public TextPane TextPane
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TextRanges TextRanges
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TopLine
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public VirtualPoint TopPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Backspace(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void ChangeCase(vsCaseOptions How)
        {
            throw new NotImplementedException();
        }

        public void CharLeft(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void CharRight(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void ClearBookmark()
        {
            throw new NotImplementedException();
        }

        public void Collapse()
        {
            throw new NotImplementedException();
        }

        public void Copy()
        {
            throw new NotImplementedException();
        }

        public void Cut()
        {
            throw new NotImplementedException();
        }

        public void Delete(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteLeft(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhitespace(vsWhitespaceOptions Direction = vsWhitespaceOptions.vsWhitespaceOptionsHorizontal)
        {
            throw new NotImplementedException();
        }

        public void DestructiveInsert(string Text)
        {
            throw new NotImplementedException();
        }

        public void EndOfDocument(bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void EndOfLine(bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public bool FindPattern(string Pattern, int vsFindOptionsValue, ref TextRanges Tags)
        {
            throw new NotImplementedException();
        }

        public bool FindText(string Pattern, int vsFindOptionsValue = 0)
        {
            throw new NotImplementedException();
        }

        public void GotoLine(int Line, bool Select = false)
        {
        }

        public void Indent(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void Insert(string Text, int vsInsertFlagsCollapseToEndValue = 1)
        {
            throw new NotImplementedException();
        }

        public void InsertFromFile(string File)
        {
            throw new NotImplementedException();
        }

        public void LineDown(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void LineUp(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void MoveTo(int Line, int Column, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void MoveToAbsoluteOffset(int Offset, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void MoveToDisplayColumn(int Line, int Column, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void MoveToLineAndOffset(int Line, int Offset, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void MoveToPoint(TextPoint Point, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void NewLine(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public bool NextBookmark()
        {
            throw new NotImplementedException();
        }

        public void OutlineSection()
        {
            throw new NotImplementedException();
        }

        public void PadToColumn(int Column)
        {
            throw new NotImplementedException();
        }

        public void PageDown(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void PageUp(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void Paste()
        {
            throw new NotImplementedException();
        }

        public bool PreviousBookmark()
        {
            throw new NotImplementedException();
        }

        public bool ReplacePattern(string Pattern, string Replace, int vsFindOptionsValue, ref TextRanges Tags)
        {
            throw new NotImplementedException();
        }

        public bool ReplaceText(string Pattern, string Replace, int vsFindOptionsValue = 0)
        {
            throw new NotImplementedException();
        }

        public void SelectAll()
        {
            throw new NotImplementedException();
        }

        public void SelectLine()
        {
            throw new NotImplementedException();
        }

        public void SetBookmark()
        {
            throw new NotImplementedException();
        }

        public void SmartFormat()
        {
            throw new NotImplementedException();
        }

        public void StartOfDocument(bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void StartOfLine(vsStartOfLineOptions Where = vsStartOfLineOptions.vsStartOfLineOptionsFirstColumn, bool Extend = false)
        {
            throw new NotImplementedException();
        }

        public void SwapAnchor()
        {
            throw new NotImplementedException();
        }

        public void Tabify()
        {
            throw new NotImplementedException();
        }

        public void Unindent(int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void Untabify()
        {
            throw new NotImplementedException();
        }

        public void WordLeft(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }

        public void WordRight(bool Extend = false, int Count = 1)
        {
            throw new NotImplementedException();
        }
    }
}
