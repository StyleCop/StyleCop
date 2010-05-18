/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTVIEWINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTVIEWINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextViewIntellisenseHostNotImpl :
	public IVsTextViewIntellisenseHost
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewIntellisenseHostNotImpl)

public:

	typedef IVsTextViewIntellisenseHost Interface;

	STDMETHOD(SetSubjectFromPrimaryBuffer)(
		/*[in]*/ TextSpan* /*pSpanInPrimary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostFlags)(
		/*[out,retval]*/ DWORD* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextBuffer)(
		/*[out,retval]*/ IVsTextLines** /*ppCtxBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextFocalPoint)(
		/*[out]*/ TextSpan* /*pSpan*/,
		/*[in]*/ long* /*piLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContextCaretPos)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextCaretPos)(
		/*[out]*/ long* /*piLine*/,
		/*[out]*/ long* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContextSelection)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ long /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ long /*iEndIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextSelection)(
		/*[out]*/ TextSpan* /*pSelectionSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSubjectText)(
		/*[out,retval]*/ BSTR* /*pbstrSubjectText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSubjectCaretPos)(
		/*[in]*/ long /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSubjectCaretPos)(
		/*[out]*/ long* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSubjectSelection)(
		/*[in]*/ long /*iAnchorIndex*/,
		/*[in]*/ long /*iEndIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSubjectSelection)(
		/*[out]*/ long* /*piAnchorIndex*/,
		/*[out]*/ long* /*piEndIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReplaceSubjectTextSpan)(
		/*[in]*/ long /*iStartIndex*/,
		/*[in]*/ long /*iEndIndex*/,
		/*[in]*/ LPCWSTR /*pszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCompletionStatus)(
		/*[in]*/ IVsCompletionSet* /*pCompSet*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateTipWindow)(
		/*[in]*/ IVsTipWindow* /*pTipWindow*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HighlightMatchingBrace)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ ULONG /*cSpans*/,
		/*[in,size_is(cSpans)]*/ TextSpan* /*rgBaseSpans*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeforeCompletorCommit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AfterCompletorCommit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetServiceProvider)(
		/*[out]*/ IServiceProvider** /*ppSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostWindow)(
		/*[out]*/ HWND* /*hwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextLocation)(
		/*[in]*/ long /*iPos*/,
		/*[in]*/ long /*iLen*/,
		/*[in]*/ BOOL /*fUseCaretPosition*/,
		/*[out]*/ RECT* /*prc*/,
		/*[out]*/ long* /*piTopX*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSmartTagWindow)(
		/*[in]*/ IVsSmartTagTipWindow* /*pSmartTagWnd*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSmartTagRect)(
		/*[out]*/ RECT* /*rcSmartTag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ ULONG /*cCmds*/,
		/*[size_is(cCmds),in,out]*/ OLECMD[] /*prgCmds*/,
		/*[in,out,unique]*/ OLECMDTEXT* /*pCmdText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdID*/,
		/*[in]*/ DWORD /*nCmdexecopt*/,
		/*[in,unique]*/ VARIANT* /*pvaIn*/,
		/*[in,out,unique]*/ VARIANT* /*pvaOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextViewIntellisenseHostMockImpl :
	public IVsTextViewIntellisenseHost,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewIntellisenseHostMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextViewIntellisenseHostMockImpl)

	typedef IVsTextViewIntellisenseHost Interface;
	struct SetSubjectFromPrimaryBufferValidValues
	{
		/*[in]*/ TextSpan* pSpanInPrimary;
		HRESULT retValue;
	};

	STDMETHOD(SetSubjectFromPrimaryBuffer)(
		/*[in]*/ TextSpan* pSpanInPrimary)
	{
		VSL_DEFINE_MOCK_METHOD(SetSubjectFromPrimaryBuffer)

		VSL_CHECK_VALIDVALUE_POINTER(pSpanInPrimary);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostFlagsValidValues
	{
		/*[out,retval]*/ DWORD* pdwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetHostFlags)(
		/*[out,retval]*/ DWORD* pdwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostFlags)

		VSL_SET_VALIDVALUE(pdwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextBufferValidValues
	{
		/*[out,retval]*/ IVsTextLines** ppCtxBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetContextBuffer)(
		/*[out,retval]*/ IVsTextLines** ppCtxBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppCtxBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextFocalPointValidValues
	{
		/*[out]*/ TextSpan* pSpan;
		/*[in]*/ long* piLen;
		HRESULT retValue;
	};

	STDMETHOD(GetContextFocalPoint)(
		/*[out]*/ TextSpan* pSpan,
		/*[in]*/ long* piLen)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextFocalPoint)

		VSL_SET_VALIDVALUE(pSpan);

		VSL_CHECK_VALIDVALUE_POINTER(piLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetContextCaretPosValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ long iIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetContextCaretPos)(
		/*[in]*/ long iLine,
		/*[in]*/ long iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetContextCaretPos)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextCaretPosValidValues
	{
		/*[out]*/ long* piLine;
		/*[out]*/ long* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetContextCaretPos)(
		/*[out]*/ long* piLine,
		/*[out]*/ long* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextCaretPos)

		VSL_SET_VALIDVALUE(piLine);

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetContextSelectionValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ long iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ long iEndIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetContextSelection)(
		/*[in]*/ long iStartLine,
		/*[in]*/ long iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ long iEndIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetContextSelection)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextSelectionValidValues
	{
		/*[out]*/ TextSpan* pSelectionSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetContextSelection)(
		/*[out]*/ TextSpan* pSelectionSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextSelection)

		VSL_SET_VALIDVALUE(pSelectionSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSubjectTextValidValues
	{
		/*[out,retval]*/ BSTR* pbstrSubjectText;
		HRESULT retValue;
	};

	STDMETHOD(GetSubjectText)(
		/*[out,retval]*/ BSTR* pbstrSubjectText)
	{
		VSL_DEFINE_MOCK_METHOD(GetSubjectText)

		VSL_SET_VALIDVALUE_BSTR(pbstrSubjectText);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSubjectCaretPosValidValues
	{
		/*[in]*/ long iIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetSubjectCaretPos)(
		/*[in]*/ long iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetSubjectCaretPos)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSubjectCaretPosValidValues
	{
		/*[out]*/ long* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetSubjectCaretPos)(
		/*[out]*/ long* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetSubjectCaretPos)

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSubjectSelectionValidValues
	{
		/*[in]*/ long iAnchorIndex;
		/*[in]*/ long iEndIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetSubjectSelection)(
		/*[in]*/ long iAnchorIndex,
		/*[in]*/ long iEndIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetSubjectSelection)

		VSL_CHECK_VALIDVALUE(iAnchorIndex);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSubjectSelectionValidValues
	{
		/*[out]*/ long* piAnchorIndex;
		/*[out]*/ long* piEndIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetSubjectSelection)(
		/*[out]*/ long* piAnchorIndex,
		/*[out]*/ long* piEndIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetSubjectSelection)

		VSL_SET_VALIDVALUE(piAnchorIndex);

		VSL_SET_VALIDVALUE(piEndIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceSubjectTextSpanValidValues
	{
		/*[in]*/ long iStartIndex;
		/*[in]*/ long iEndIndex;
		/*[in]*/ LPCWSTR pszText;
		HRESULT retValue;
	};

	STDMETHOD(ReplaceSubjectTextSpan)(
		/*[in]*/ long iStartIndex,
		/*[in]*/ long iEndIndex,
		/*[in]*/ LPCWSTR pszText)
	{
		VSL_DEFINE_MOCK_METHOD(ReplaceSubjectTextSpan)

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateCompletionStatusValidValues
	{
		/*[in]*/ IVsCompletionSet* pCompSet;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UpdateCompletionStatus)(
		/*[in]*/ IVsCompletionSet* pCompSet,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateCompletionStatus)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCompSet);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateTipWindowValidValues
	{
		/*[in]*/ IVsTipWindow* pTipWindow;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UpdateTipWindow)(
		/*[in]*/ IVsTipWindow* pTipWindow,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateTipWindow)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTipWindow);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct HighlightMatchingBraceValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ ULONG cSpans;
		/*[in,size_is(cSpans)]*/ TextSpan* rgBaseSpans;
		HRESULT retValue;
	};

	STDMETHOD(HighlightMatchingBrace)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ ULONG cSpans,
		/*[in,size_is(cSpans)]*/ TextSpan* rgBaseSpans)
	{
		VSL_DEFINE_MOCK_METHOD(HighlightMatchingBrace)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(cSpans);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgBaseSpans, cSpans*sizeof(rgBaseSpans[0]), validValues.cSpans*sizeof(validValues.rgBaseSpans[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct BeforeCompletorCommitValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeforeCompletorCommit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeforeCompletorCommit)

		VSL_RETURN_VALIDVALUES();
	}
	struct AfterCompletorCommitValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AfterCompletorCommit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AfterCompletorCommit)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetServiceProviderValidValues
	{
		/*[out]*/ IServiceProvider** ppSP;
		HRESULT retValue;
	};

	STDMETHOD(GetServiceProvider)(
		/*[out]*/ IServiceProvider** ppSP)
	{
		VSL_DEFINE_MOCK_METHOD(GetServiceProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostWindowValidValues
	{
		/*[out]*/ HWND* hwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetHostWindow)(
		/*[out]*/ HWND* hwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostWindow)

		VSL_SET_VALIDVALUE(hwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextLocationValidValues
	{
		/*[in]*/ long iPos;
		/*[in]*/ long iLen;
		/*[in]*/ BOOL fUseCaretPosition;
		/*[out]*/ RECT* prc;
		/*[out]*/ long* piTopX;
		HRESULT retValue;
	};

	STDMETHOD(GetContextLocation)(
		/*[in]*/ long iPos,
		/*[in]*/ long iLen,
		/*[in]*/ BOOL fUseCaretPosition,
		/*[out]*/ RECT* prc,
		/*[out]*/ long* piTopX)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextLocation)

		VSL_CHECK_VALIDVALUE(iPos);

		VSL_CHECK_VALIDVALUE(iLen);

		VSL_CHECK_VALIDVALUE(fUseCaretPosition);

		VSL_SET_VALIDVALUE(prc);

		VSL_SET_VALIDVALUE(piTopX);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSmartTagWindowValidValues
	{
		/*[in]*/ IVsSmartTagTipWindow* pSmartTagWnd;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSmartTagWindow)(
		/*[in]*/ IVsSmartTagTipWindow* pSmartTagWnd,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSmartTagWindow)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSmartTagWnd);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSmartTagRectValidValues
	{
		/*[out]*/ RECT* rcSmartTag;
		HRESULT retValue;
	};

	STDMETHOD(GetSmartTagRect)(
		/*[out]*/ RECT* rcSmartTag)
	{
		VSL_DEFINE_MOCK_METHOD(GetSmartTagRect)

		VSL_SET_VALIDVALUE(rcSmartTag);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ ULONG cCmds;
		/*[size_is(cCmds),in,out]*/ OLECMD* prgCmds;
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ ULONG cCmds,
		/*[size_is(cCmds),in,out]*/ OLECMD prgCmds[],
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatus)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(cCmds);

		VSL_SET_VALIDVALUE_MEMCPY(prgCmds, cCmds*sizeof(prgCmds[0]), validValues.cCmds*sizeof(validValues.prgCmds[0]));

		VSL_SET_VALIDVALUE(pCmdText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdID;
		/*[in]*/ DWORD nCmdexecopt;
		/*[in,unique]*/ VARIANT* pvaIn;
		/*[in,out,unique]*/ VARIANT* pvaOut;
		HRESULT retValue;
	};

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdID,
		/*[in]*/ DWORD nCmdexecopt,
		/*[in,unique]*/ VARIANT* pvaIn,
		/*[in,out,unique]*/ VARIANT* pvaOut)
	{
		VSL_DEFINE_MOCK_METHOD(Exec)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdID);

		VSL_CHECK_VALIDVALUE(nCmdexecopt);

		VSL_CHECK_VALIDVALUE_POINTER(pvaIn);

		VSL_SET_VALIDVALUE_VARIANT(pvaOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTVIEWINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
