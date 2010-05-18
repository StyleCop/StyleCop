/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMACROHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMACROHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextMacroHelperNotImpl :
	public IVsTextMacroHelper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMacroHelperNotImpl)

public:

	typedef IVsTextMacroHelper Interface;

	STDMETHOD(RecordNewLine)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordTypeChar)(
		/*[in]*/ OLECHAR /*wchChar*/,
		/*[in]*/ BOOL /*fIsOvertype*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordTypeChars)(
		/*[in]*/ LPCOLESTR /*pwszChars*/,
		/*[in]*/ BOOL /*fIsOvertype*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordRemovePreviousTyping)(
		/*[in]*/ LPCOLESTR /*pwszPrevChars*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordDelete)(
		/*[in]*/ BOOL /*fLeft*/,
		/*[in]*/ UINT /*uiReps*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordDeleteSpace)(
		/*[in]*/ BOOL /*fVertical*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordMoveSelectionRel)(
		/*[in]*/ MOVESELECTION_REL_TYPE /*mst*/,
		/*[in]*/ BOOL /*fBackwards*/,
		/*[in]*/ BOOL /*fExtend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordMoveSelectionAbs)(
		/*[in]*/ MOVESELECTION_ABS_TYPE /*mst*/,
		/*[in]*/ BOOL /*fExtend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordCollapseSelection)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordSelectAll)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordSwapAnchor)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordEnterBoxMode)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordActivateDocument)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordGotoLine)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ BOOL /*fExtend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordCut)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordCopy)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordPaste)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordBookmarkClearAll)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordBookmarkSetClear)(
		/*[in]*/ BOOL /*fSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordBookmarkNextPrev)(
		/*[in]*/ BOOL /*fNext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordChangeCase)(
		/*[in]*/ CASESELECTION_TYPE /*cst*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordIndentUnindent)(
		/*[in]*/ BOOL /*fIndent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordFormatSelection)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordTabifyUntabify)(
		/*[in]*/ BOOL /*fTabify*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordInsertFile)(
		/*[in]*/ LPCOLESTR /*pwszName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextMacroHelperMockImpl :
	public IVsTextMacroHelper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMacroHelperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextMacroHelperMockImpl)

	typedef IVsTextMacroHelper Interface;
	struct RecordNewLineValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordNewLine)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordNewLine)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordTypeCharValidValues
	{
		/*[in]*/ OLECHAR wchChar;
		/*[in]*/ BOOL fIsOvertype;
		HRESULT retValue;
	};

	STDMETHOD(RecordTypeChar)(
		/*[in]*/ OLECHAR wchChar,
		/*[in]*/ BOOL fIsOvertype)
	{
		VSL_DEFINE_MOCK_METHOD(RecordTypeChar)

		VSL_CHECK_VALIDVALUE(wchChar);

		VSL_CHECK_VALIDVALUE(fIsOvertype);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordTypeCharsValidValues
	{
		/*[in]*/ LPCOLESTR pwszChars;
		/*[in]*/ BOOL fIsOvertype;
		HRESULT retValue;
	};

	STDMETHOD(RecordTypeChars)(
		/*[in]*/ LPCOLESTR pwszChars,
		/*[in]*/ BOOL fIsOvertype)
	{
		VSL_DEFINE_MOCK_METHOD(RecordTypeChars)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszChars);

		VSL_CHECK_VALIDVALUE(fIsOvertype);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordRemovePreviousTypingValidValues
	{
		/*[in]*/ LPCOLESTR pwszPrevChars;
		HRESULT retValue;
	};

	STDMETHOD(RecordRemovePreviousTyping)(
		/*[in]*/ LPCOLESTR pwszPrevChars)
	{
		VSL_DEFINE_MOCK_METHOD(RecordRemovePreviousTyping)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszPrevChars);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordDeleteValidValues
	{
		/*[in]*/ BOOL fLeft;
		/*[in]*/ UINT uiReps;
		HRESULT retValue;
	};

	STDMETHOD(RecordDelete)(
		/*[in]*/ BOOL fLeft,
		/*[in]*/ UINT uiReps)
	{
		VSL_DEFINE_MOCK_METHOD(RecordDelete)

		VSL_CHECK_VALIDVALUE(fLeft);

		VSL_CHECK_VALIDVALUE(uiReps);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordDeleteSpaceValidValues
	{
		/*[in]*/ BOOL fVertical;
		HRESULT retValue;
	};

	STDMETHOD(RecordDeleteSpace)(
		/*[in]*/ BOOL fVertical)
	{
		VSL_DEFINE_MOCK_METHOD(RecordDeleteSpace)

		VSL_CHECK_VALIDVALUE(fVertical);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordMoveSelectionRelValidValues
	{
		/*[in]*/ MOVESELECTION_REL_TYPE mst;
		/*[in]*/ BOOL fBackwards;
		/*[in]*/ BOOL fExtend;
		HRESULT retValue;
	};

	STDMETHOD(RecordMoveSelectionRel)(
		/*[in]*/ MOVESELECTION_REL_TYPE mst,
		/*[in]*/ BOOL fBackwards,
		/*[in]*/ BOOL fExtend)
	{
		VSL_DEFINE_MOCK_METHOD(RecordMoveSelectionRel)

		VSL_CHECK_VALIDVALUE(mst);

		VSL_CHECK_VALIDVALUE(fBackwards);

		VSL_CHECK_VALIDVALUE(fExtend);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordMoveSelectionAbsValidValues
	{
		/*[in]*/ MOVESELECTION_ABS_TYPE mst;
		/*[in]*/ BOOL fExtend;
		HRESULT retValue;
	};

	STDMETHOD(RecordMoveSelectionAbs)(
		/*[in]*/ MOVESELECTION_ABS_TYPE mst,
		/*[in]*/ BOOL fExtend)
	{
		VSL_DEFINE_MOCK_METHOD(RecordMoveSelectionAbs)

		VSL_CHECK_VALIDVALUE(mst);

		VSL_CHECK_VALIDVALUE(fExtend);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCollapseSelectionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordCollapseSelection)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordCollapseSelection)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordSelectAllValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordSelectAll)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordSelectAll)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordSwapAnchorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordSwapAnchor)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordSwapAnchor)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordEnterBoxModeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordEnterBoxMode)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordEnterBoxMode)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordActivateDocumentValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordActivateDocument)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordActivateDocument)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordGotoLineValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ BOOL fExtend;
		HRESULT retValue;
	};

	STDMETHOD(RecordGotoLine)(
		/*[in]*/ long iLine,
		/*[in]*/ BOOL fExtend)
	{
		VSL_DEFINE_MOCK_METHOD(RecordGotoLine)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(fExtend);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCutValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordCut)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordCut)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCopyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordCopy)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordCopy)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordPasteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordPaste)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordPaste)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordBookmarkClearAllValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordBookmarkClearAll)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordBookmarkClearAll)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordBookmarkSetClearValidValues
	{
		/*[in]*/ BOOL fSet;
		HRESULT retValue;
	};

	STDMETHOD(RecordBookmarkSetClear)(
		/*[in]*/ BOOL fSet)
	{
		VSL_DEFINE_MOCK_METHOD(RecordBookmarkSetClear)

		VSL_CHECK_VALIDVALUE(fSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordBookmarkNextPrevValidValues
	{
		/*[in]*/ BOOL fNext;
		HRESULT retValue;
	};

	STDMETHOD(RecordBookmarkNextPrev)(
		/*[in]*/ BOOL fNext)
	{
		VSL_DEFINE_MOCK_METHOD(RecordBookmarkNextPrev)

		VSL_CHECK_VALIDVALUE(fNext);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordChangeCaseValidValues
	{
		/*[in]*/ CASESELECTION_TYPE cst;
		HRESULT retValue;
	};

	STDMETHOD(RecordChangeCase)(
		/*[in]*/ CASESELECTION_TYPE cst)
	{
		VSL_DEFINE_MOCK_METHOD(RecordChangeCase)

		VSL_CHECK_VALIDVALUE(cst);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordIndentUnindentValidValues
	{
		/*[in]*/ BOOL fIndent;
		HRESULT retValue;
	};

	STDMETHOD(RecordIndentUnindent)(
		/*[in]*/ BOOL fIndent)
	{
		VSL_DEFINE_MOCK_METHOD(RecordIndentUnindent)

		VSL_CHECK_VALIDVALUE(fIndent);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordFormatSelectionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordFormatSelection)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordFormatSelection)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordTabifyUntabifyValidValues
	{
		/*[in]*/ BOOL fTabify;
		HRESULT retValue;
	};

	STDMETHOD(RecordTabifyUntabify)(
		/*[in]*/ BOOL fTabify)
	{
		VSL_DEFINE_MOCK_METHOD(RecordTabifyUntabify)

		VSL_CHECK_VALIDVALUE(fTabify);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordInsertFileValidValues
	{
		/*[in]*/ LPCOLESTR pwszName;
		HRESULT retValue;
	};

	STDMETHOD(RecordInsertFile)(
		/*[in]*/ LPCOLESTR pwszName)
	{
		VSL_DEFINE_MOCK_METHOD(RecordInsertFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMACROHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
