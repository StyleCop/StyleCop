/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLFINDANDREPLACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLFINDANDREPLACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

namespace VSL
{

// TODO - 3/16/2006 - clean-up this file to be consistent with the rest of VSL

/***************************************************************************
IVsFindTarget implementation
***************************************************************************/

#define VSL_IVSFINDTARGETIMPL_AUTO_DETERMINE_IVSTEXTIMAGE TRUE + 1

template <class Derived_T, const BOOL bImage_T = VSL_IVSFINDTARGETIMPL_AUTO_DETERMINE_IVSTEXTIMAGE>
class IVsFindTargetImpl :
	public IVsFindTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindTargetImpl)

public:

	/*
	This function indicates to the caller which Find/Replace options are supported via the pgrfOptions
	out parameter. The pfImage parameter indicates whether the IVsTextImage interface is supported.
	*/
	STDMETHOD(GetCapabilities)(_Out_opt_ BOOL* pfImage, _Out_opt_ DWORD* pgrfOptions)
	{
		VSL_STDMETHODTRY{

		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		if(NULL != pfImage)
		{
			static BOOL s_bImage = bImage_T;
			if(s_bImage == VSL_IVSFINDTARGETIMPL_AUTO_DETERMINE_IVSTEXTIMAGE)
			{
				CComPtr<IVsTextImage> spIVsTextImage;
				if(S_OK == rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextImage, reinterpret_cast<void**>(&spIVsTextImage)))
				{
					s_bImage = TRUE;
				}
			}
			*pfImage = s_bImage;
		}

		if(NULL != pgrfOptions)
		{
			*pgrfOptions = FR_None;

			*pgrfOptions = rDerived.GetCapabilityOptions();
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(GetSearchImage)(
		DWORD grfOptions,
		_Out_opt_ IVsTextSpanSet** ppSpans, // May be NULL
		_Out_ IVsTextImage** ppTextImage)
	{
		VSL_STDMETHODTRY{

		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		DWORD grfSupportedOptions = rDerived.GetCapabilityOptions();
		// Use grfSupportedOptions to mask grfOptions and compare the results to grfOptions
		// If the result of the mask isn't the same, then unsupported options were specified
		VSL_CHECKBOOLEAN(grfOptions == (grfSupportedOptions & grfOptions), E_INVALIDARG);

		VSL_CHECKPOINTER(ppTextImage, E_INVALIDARG);
		*ppTextImage = NULL;

		if(NULL != ppSpans)
		{
			*ppSpans = NULL;
			VSL_CHECKHRESULT(rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextSpanSet, reinterpret_cast<void**>(ppSpans)));
			VSL_CHECKPOINTER(*ppSpans, E_NOINTERFACE); // paranoid
		}

		VSL_CHECKHRESULT(rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextImage, reinterpret_cast<void**>(ppTextImage)));
		VSL_CHECKPOINTER(*ppTextImage, E_NOINTERFACE); // paranoid

		if(NULL != ppSpans)
		{
			// Attach this text image to this span
			(*ppSpans)->AttachTextImage(*ppTextImage);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// It isn't necessary to implement Find as GetSearchImage which results in hooking into 
	// into VS find/replace engine.
	STDMETHOD(Find)(
		LPCOLESTR /*pszSearch*/,
		VSFINDOPTIONS /*grfOptions*/,
		BOOL /*fResetStartPoint*/,
		_In_ IVsFindHelper* /*pHelper*/, 
		_Out_ VSFINDRESULT* /*pResult*/)
	{
		return E_NOTIMPL;
	}

	// It isn't necessary to implement Replace as GetSearchImage which results in hooking into 
	// into VS find/replace engine.
	STDMETHOD(Replace)(
		LPCOLESTR /*pszSearch*/,
		LPCOLESTR /*pszReplace*/,
		VSFINDOPTIONS /*grfOptions*/,
		BOOL /*fResetStartPoint*/,
		_In_ IVsFindHelper * /*pHelper*/,
		_Out_ BOOL * /*pbReplaced*/)
	{    
		return E_NOTIMPL;
	}

#pragma warning(push)
#pragma warning(disable : 4702) // unreachable code
	STDMETHOD(SetFindState)(IUnknown* pIUnknown)
	{
		VSL_STDMETHODTRY{

		m_spFindState = pIUnknown;

		// NOTE - the catch block are currently, but leave this here so it's not forgoten
		// in the future if it is needed.
		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
#pragma warning(pop)

	STDMETHOD(GetFindState)(IUnknown** ppIUnknown)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppIUnknown, E_INVALIDARG);

		*ppIUnknown = m_spFindState;
		if(*ppIUnknown)
		{
			(*ppIUnknown)->AddRef();
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(GetMatchRect)(_Out_ PRECT /*prc*/)
	{
		return E_NOTIMPL;
	}

	STDMETHOD(NotifyFindTarget)(VSFTNOTIFY /*notification*/)
	{
		return S_OK;
	}

	STDMETHOD(MarkSpan)(const TextSpan* /*pts*/)
	{
		return E_NOTIMPL;
	}

private:

	CComPtr<IUnknown> m_spFindState;

};

/***************************************************************************
IVsTextImage implementation
***************************************************************************/

class ImageLockSimple
{

public:

	ImageLockSimple():
		 m_bLock(false)
	{
	}

	HRESULT Lock(/* [in] */ DWORD /*dwLock*/)
	{
		// Only one reader/writer is allowed at a time, so there is only one lock
		if(!m_bLock)
		{
			m_bLock = true;
			return S_OK;
		}

		return E_FAIL;
	}

	HRESULT Unlock(/* [in] */ DWORD /*dwLock*/)
	{
		m_bLock = false;
		return S_OK;
	}

private:

	bool m_bLock;

};

template <class ImageLock_T = ImageLockSimple>
class IVsTextImageImpl :
	public IVsTextImage
{

public:

	STDMETHOD(GetCharSize)( 
		/* [retval][out] */ _Out_ LONG* pcch)
	{
		(pcch);

		return E_NOTIMPL;
	}

	STDMETHOD(GetOffsetOfTextAddress)( 
		/* [in] */ TextAddress ta,
		/* [retval][out] */ _Out_ LONG* piOffset)
	{
		(ta, piOffset);

		return E_NOTIMPL;
	}

	STDMETHOD(GetTextAddressOfOffset)( 
		/* [in] */ LONG iOffset,
		/* [retval][out] */ _Out_ TextAddress* pta)
	{
		(iOffset, pta);

		return E_NOTIMPL;
	}

	STDMETHOD(GetTextBSTR)( 
		/* [in] */ const TextSpan* pts,
		/* [retval][out] */ _Deref_out_z_ BSTR* pbstrText)
	{
		(pts, pbstrText);

		return E_NOTIMPL;
	}

	STDMETHOD(GetText)( 
		/* [in] */ const TextSpan* pts,
		/* [in] */ LONG cch,
		/* [size_is][out] */ _Out_z_cap_(cch) LPOLESTR psz)
	{
		(pts, cch, psz);

		return E_NOTIMPL;
	}

	// NOTE - If the derived class does not utilize operator new [] to allocate
	// the line text, then the derived class must implement ReleaseLine itself
	STDMETHOD(ReleaseLine)( 
		/* [in] */ _In_ LINEDATAEX* pLineData)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pLineData, E_INVALIDARG);

		// The memory pointed to by pLineData was created by GetLine in the derived class.
		// Assign it to the correct smart pointer type and it will be correctly released in the destructor
		// when the variable goes out of scope.
		Pointer<StdArrayPointerTraits<WCHAR> > szText = const_cast<WCHAR*>(pLineData->pszText);
		pLineData->pszText = L'\0';

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// No text image events to send out to callers, so this just returns S_OK
	STDMETHOD(AdviseTextImageEvents)( 
		/* [in] */ _In_ IVsTextImageEvents* pSink,
		/* [retval][out] */ _Out_ DWORD* pCookie)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pSink, E_INVALIDARG);
		VSL_CHECKPOINTER(pCookie, E_INVALIDARG);

		return S_OK;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// No text image events to send out to callers, so this just returns S_OK
	STDMETHOD(UnadviseTextImageEvents)( 
		/* [in] */ DWORD Cookie)
	{
		(Cookie);

		return S_OK;
	}

	STDMETHOD(LockImage)( 
		/* [in] */ DWORD grfLock)
	{
		return m_lock.Lock(grfLock);
	}

	STDMETHOD(UnlockImage)( 
		/* [in] */ DWORD grfLock)
	{
		return m_lock.Unlock(grfLock);
	}
private:

	ImageLock_T m_lock;
};

/***************************************************************************
IVsTextSpanSet implementation
***************************************************************************/

class IVsTextSpanSetImpl :
	public IVsTextSpanSet
{

public:


STDMETHODIMP AttachTextImage( 
	/* [in] */ IUnknown* pText)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pText, E_INVALIDARG);

	// If m_spTextImage isn't NULL, see if it's the same as pText
	if(!!m_spTextImage)
	{
		if(m_spTextImage.IsEqualObject(pText))
		{
			return S_OK;  // Don't need to do any more, this text image has already been attached to 
		}
		else
		{
			m_spTextImage = NULL;
		}
	}

	VSL_CHECKHRESULT(pText->QueryInterface(IID_IVsTextImage, reinterpret_cast<void**>(&m_spTextImage)));
	VSL_CHECKPOINTER(m_spTextImage.p, E_NOINTERFACE); // paranoid

	// Now add the size span of this text to the array
	long iLineCount = 0;
	VSL_CHECKHRESULT(m_spTextImage->GetLineSize(&iLineCount));

	// Get the length of the last line
	long iLastLineLength = 0;
	long iLastLine = 0;
	if(iLineCount >= 1)
	{
		iLastLine = iLineCount-1;
		VSL_CHECKHRESULT(m_spTextImage->GetLineLength(iLineCount-1, &iLastLineLength));
	}

	TextSpan textSpan;
	textSpan.iStartLine = 0;
	textSpan.iStartIndex = 0;
	textSpan.iEndLine = iLastLine;
	textSpan.iEndIndex = iLastLineLength;

	m_pTextSpanArray.Add(textSpan);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
	
}
		

STDMETHODIMP Detach()
{
	m_spTextImage = NULL;
	m_pTextSpanArray.RemoveAll();

	return S_OK;
}
		

STDMETHODIMP SuspendTracking()
{
	return E_NOTIMPL;
}
		

STDMETHODIMP ResumeTracking()
{
	return E_NOTIMPL;
}
		

STDMETHODIMP Add( 
	/* [in] */ LONG cel,
	/* [size_is][in] */ const TextSpan* pSpan)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pSpan, E_INVALIDARG);

	m_pTextSpanArray.SetAtGrow(cel, *pSpan);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}
		

STDMETHODIMP GetCount( 
	/* [retval][out] */ LONG* pcel)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pcel, E_INVALIDARG);

	*pcel = static_cast<LONG>(m_pTextSpanArray.GetCount());

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
	
}
		

STDMETHODIMP GetAt( 
	/* [in] */ LONG iEl,
	/* [retval][out] */ TextSpan* pSpan)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pSpan, E_INVALIDARG);

	if(iEl >= static_cast<LONG>(m_pTextSpanArray.GetCount()))
	{
		return E_INVALIDARG;
	}

	*pSpan = m_pTextSpanArray.GetAt(iEl);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}
		

STDMETHODIMP RemoveAll()
{
	m_pTextSpanArray.RemoveAll();

	return S_OK;
}
		

STDMETHODIMP Sort( 
	/* [in] */ DWORD SortOptions)
{
	(SortOptions);

	return E_NOTIMPL;
}
		

STDMETHODIMP AddFromEnum( 
	/* [in] */ IVsEnumTextSpans* pEnum)
{
	(pEnum);

	return E_NOTIMPL;
}

private:

	CAtlArray<TextSpan> m_pTextSpanArray;

	CComPtr<IVsTextImage> m_spTextImage;

};

/***************************************************************************
IVsTextView implementation

This is just provided so that the find in files scenario will work 
properly.  It isn't necesary to implement most of the methods for this
scenario to work correctly.
***************************************************************************/

class IVsTextViewSimpleImpl :
	public IVsTextView
{

public:

STDMETHODIMP Initialize(
	IVsTextLines* pBuffer, 
	HWND hwndParent, 
	DWORD dwInitFlags, 
	const INITVIEW* pPrefs)
{
	(pBuffer, hwndParent, dwInitFlags, pPrefs);

	return E_NOTIMPL;
}


STDMETHODIMP CloseView()
{
	return E_NOTIMPL;
}


STDMETHODIMP GetCaretPos(long* piLine, ViewCol* piColumn)
{
	(piLine, piColumn);

	return E_NOTIMPL;
}


STDMETHODIMP SetCaretPos(long iLine, ViewCol iColumn)
{
	(iLine, iColumn);

	return E_NOTIMPL;
}


STDMETHODIMP GetSelectionSpan(TextSpan* pSpan)
{
	(pSpan);

	return E_NOTIMPL;
}


STDMETHODIMP GetSelection(
	long* piAnchorLine, 
	ViewCol* piAnchorCol, 
	long* piEndLine, 
	ViewCol* piEndCol)
{
	(piAnchorLine, piAnchorCol, piEndLine, piEndCol);

	return E_NOTIMPL;
}

// SetSelection is implementation specific


virtual TextSelMode STDMETHODCALLTYPE GetSelectionMode()
{
	return SM_STREAM;
}


STDMETHODIMP SetSelectionMode(TextSelMode iSelMode)
{
	(iSelMode);

	return E_NOTIMPL;
}


STDMETHODIMP ClearSelection(BOOL fMoveToAnchor)
{
	(fMoveToAnchor);

	return E_NOTIMPL;
}


STDMETHODIMP CenterLines(long iLine, long iCount)
{
	(iLine, iCount);

	return E_NOTIMPL;
}


STDMETHODIMP GetSelectedText(BSTR* bstrText)
{
	(bstrText);

	return E_NOTIMPL;
}


STDMETHODIMP GetSelectionDataObject(IDataObject** ppIDataObject)
{
	(ppIDataObject);

	return E_NOTIMPL;
}


STDMETHODIMP GetTextStream(
	long iTopLine, 
	ViewCol iTopCol, 
	long iBottomLine, 
	ViewCol iBottomCol, 
	BSTR* pbstrText)
{
	(iTopLine, iTopCol, iBottomLine, iBottomCol, pbstrText);

	return E_NOTIMPL;
}


STDMETHODIMP GetBuffer(IVsTextLines** ppBuffer)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(ppBuffer, E_INVALIDARG);
	*ppBuffer = NULL;
	
	VSL_CHECKHRESULT(QueryInterface(IID_IVsTextLines, reinterpret_cast<void**>(ppBuffer)));
	VSL_CHECKPOINTER(*ppBuffer, E_NOINTERFACE); // paranoid

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}


STDMETHODIMP SetBuffer(IVsTextLines* pBuffer)
{
	(pBuffer);

	return E_NOTIMPL;
}


virtual HWND STDMETHODCALLTYPE GetWindowHandle()
{
	return NULL;
}


STDMETHODIMP GetScrollInfo(
	long iBar, 
	long* piFirst, 
	long* piLast, 
	long* piVisible, 
	long* piTop)
{
	(iBar, piFirst, piLast, piVisible, piTop);

	return E_NOTIMPL;
}


STDMETHODIMP SetScrollPosition(long iBar, long iPos)
{
	(iBar, iPos);

	return E_NOTIMPL;
}


STDMETHODIMP AddCommandFilter(
	IOleCommandTarget* pNewCmdTarg, 
	IOleCommandTarget** ppNextCmdTarg)
{
	(pNewCmdTarg, ppNextCmdTarg);

	return E_NOTIMPL;
}


STDMETHODIMP RemoveCommandFilter(IOleCommandTarget* pCmdTarg)
{
	(pCmdTarg);

	return E_NOTIMPL;
}


STDMETHODIMP UpdateCompletionStatus(IVsCompletionSet* pCompSet, DWORD dwFlags)
{
	(pCompSet, dwFlags);

	return E_NOTIMPL;
}


STDMETHODIMP UpdateTipWindow(IVsTipWindow* pTipWnd, DWORD dwFlags)
{
	(pTipWnd, dwFlags);

	return E_NOTIMPL;
}


STDMETHODIMP GetWordExtent(
	long iLine, 
	CharIndex iCharIndex, 
	DWORD dwFlags, 
	TextSpan* pSpan)
{
	(iLine, iCharIndex, dwFlags, pSpan);

	return E_NOTIMPL;
}


STDMETHODIMP RestrictViewRange(
	long iMinLine, 
	long iMaxLine, 
	IVsViewRangeClient* pClient)
{
	(iMinLine, iMaxLine, pClient);

	return E_NOTIMPL;
}


STDMETHODIMP BeginCompoundEdit(const WCHAR *pszDescription)
{
	(pszDescription);

	return E_NOTIMPL;
}


STDMETHODIMP EndCompoundEdit()
{
	return E_NOTIMPL;
}


STDMETHODIMP AbortCompoundEdit()
{
	return E_NOTIMPL;
}


STDMETHODIMP ReplaceTextOnLine(
	long iLine, 
	CharIndex iStartCol, 
	long iCharsToReplace, 
	const WCHAR* pszNewText,
	long iNewLen)
{
	(iLine, iStartCol, iCharsToReplace, pszNewText, iNewLen);

	return E_NOTIMPL;
}


STDMETHODIMP GetLineAndColumn(
	long iPos, 
	long* piLine, 
	CharIndex* piCol)
{
	(iPos, piLine, piCol);

	return E_NOTIMPL;
}


STDMETHODIMP GetNearestPosition(
	long iLine, 
	long iCol,
	long* piPos,
	long* piVirtualSpaces)
{
	(iLine, iCol, piPos, piVirtualSpaces);

	return E_NOTIMPL;
}


STDMETHODIMP UpdateViewFrameCaption()
{
	return E_NOTIMPL;
}


STDMETHODIMP CenterColumns(
	long iLine, 
	long iLeftCol,
	long iColCount)
{
	(iLine, iLeftCol, iColCount);

	return E_NOTIMPL;
}


STDMETHODIMP EnsureSpanVisible(TextSpan span)
{
	(span);

	return E_NOTIMPL;
}


STDMETHODIMP PositionCaretForEditing(long iLine, long cIndentLevels)
{
	(iLine, cIndentLevels);

	return E_NOTIMPL;
}


STDMETHODIMP GetPointOfLineColumn(long iLine, ViewCol iCol, POINT* ppt)
{
	(iLine, iCol, ppt);

	return E_NOTIMPL;
}


STDMETHODIMP GetLineHeight(long* piLineHeight)
{
	(piLineHeight);

	return E_NOTIMPL;
}


STDMETHODIMP HighlightMatchingBrace(
	DWORD dwFlags, 
	ULONG cSpans, 
	TextSpan* rgBaseTextSpans)
{
	(dwFlags, cSpans, rgBaseTextSpans);

	return E_NOTIMPL;
}


STDMETHODIMP SendExplicitFocus()
{
	return E_NOTIMPL;
}


STDMETHODIMP SetTopLine(long iBaseLine)
{
	(iBaseLine);

	return E_NOTIMPL;
}

};

/***************************************************************************
IVsTextViewEvents implementation

This is just provided so that the find in files scenario will work 
properly.  It isn't necesary to implement any of the methods; however,
the it must be possible to create a connection point to this event
inteface for the scenario to work correctly.
***************************************************************************/

class IVsTextViewEventsNotImpl :
	public IVsTextViewEvents
{

public:

void STDMETHODCALLTYPE OnSetFocus(IVsTextView* pView)
{
	(pView);
}


void STDMETHODCALLTYPE OnKillFocus(IVsTextView* pView)
{
	(pView);
}


void STDMETHODCALLTYPE OnSetBuffer(IVsTextView* pView, IVsTextLines* pBuffer)
{
	(pView, pBuffer);
}


void STDMETHODCALLTYPE OnChangeScrollInfo(
	IVsTextView* pView, 
	long iBar, 
	long iMinUnit, 
	long iMaxUnits, 
	long iVisibleUnits, 
	long iFirstVisibleUnit)
{
	(pView, iBar, iMinUnit, iMaxUnits, iVisibleUnits, iFirstVisibleUnit);
}


void STDMETHODCALLTYPE OnChangeCaretLine(
	IVsTextView* pView, 
	long iNewLine, 
	long iOldLine)
{
	(pView, iNewLine, iOldLine);
}

};

/***************************************************************************
IVsCodeWindow implementation

This is just provided so that the find in files scenario will work 
properly.  It isn't necesary to implement most of the methods for this
scenario to work correctly.

TODO - 3/13/2006 - push this up into VSL
***************************************************************************/

class IVsCodeWindowSingleViewSimpleImpl:
	public IVsCodeWindow
{

public:

STDMETHODIMP GetBuffer(IVsTextLines** ppBuffer)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(ppBuffer, E_INVALIDARG);
	*ppBuffer = NULL;
	
	VSL_CHECKHRESULT(QueryInterface(IID_IVsTextLines, reinterpret_cast<void**>(ppBuffer)));
	VSL_CHECKPOINTER(*ppBuffer, E_NOINTERFACE); // paranoid

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}


STDMETHODIMP SetBuffer(IVsTextLines* pBuffer)
{
	(pBuffer);

	return E_NOTIMPL;
}

STDMETHODIMP GetPrimaryView(IVsTextView** ppView)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(ppView, E_INVALIDARG);
	*ppView = NULL;

	VSL_CHECKHRESULT(QueryInterface(IID_IVsTextView, reinterpret_cast<void**>(ppView)));
	VSL_CHECKPOINTER(*ppView, E_NOINTERFACE); // paranoid

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}


STDMETHODIMP GetSecondaryView(IVsTextView** ppView)
{
	(ppView);

	return E_NOTIMPL;
}


STDMETHODIMP SetViewClassID(REFCLSID clsidView)
{
	(clsidView);

	return E_NOTIMPL;
}


STDMETHODIMP GetViewClassID(CLSID* pclsidView)
{
	(pclsidView);

	return E_NOTIMPL;
}


STDMETHODIMP SetBaseEditorCaption(LPCOLESTR* pszBaseEditorCaption)
{
	(pszBaseEditorCaption);

	return E_NOTIMPL;
}


STDMETHODIMP GetEditorCaption(READONLYSTATUS dwReadOnly, BSTR* pbstrEditorCaption)
{
	(dwReadOnly, pbstrEditorCaption);

	return E_NOTIMPL;
}


STDMETHODIMP Close(void)
{
	return E_NOTIMPL;
}


STDMETHODIMP GetLastActiveView(IVsTextView** ppView)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(ppView, E_INVALIDARG);
	*ppView = NULL;
	
	VSL_CHECKHRESULT(QueryInterface(IID_IVsTextView, reinterpret_cast<void**>(ppView)));
	VSL_CHECKPOINTER(*ppView, E_NOINTERFACE); // paranoid

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

};

/***************************************************************************
IVsTextLines implementation

All methods return E_NOTIMPL as this is is just needed inorder to return
from IVsTextView::GetBuffer, IVsCodeWindow::GetPrimaryView,
IVsCodeWindow::GetLastActiveView during a find in files, as the caller 
in that scenario only does a QI from this interface and doesn't actually 
make use of any methods.
***************************************************************************/

class IVsTextLinesNotImpl :
	public IVsTextLines
{

public:

STDMETHODIMP LockBuffer()
{
	return E_NOTIMPL;
}


STDMETHODIMP UnlockBuffer()
{
	return E_NOTIMPL;
}


STDMETHODIMP InitializeContent(const WCHAR* pszText, long iLength)
{
	(pszText, iLength);

	return E_NOTIMPL;
}


STDMETHODIMP GetStateFlags(DWORD* pdwReadOnlyFlags)
{
	(pdwReadOnlyFlags);

	return E_NOTIMPL;
}


STDMETHODIMP SetStateFlags(DWORD dwReadOnlyFlags)
{
	(dwReadOnlyFlags);

	return E_NOTIMPL;
}


STDMETHODIMP GetPositionOfLine(long iLine, long* piPosition)
{
	(iLine, piPosition);

	return E_NOTIMPL;
}


STDMETHODIMP GetPositionOfLineIndex(
	long iLine, 
	CharIndex iIndex, 
	long* piPosition)
{
	(iLine, iIndex, piPosition);

	return E_NOTIMPL;
}


STDMETHODIMP GetLineIndexOfPosition(
	long iPosition, 
	long* piLine, 
	CharIndex* piColumn)
{
	(iPosition, piLine, piColumn);

	return E_NOTIMPL;
}

// GetLengthOfLine is implemenation specific


STDMETHODIMP GetLineCount(long* piLineCount)
{
	(piLineCount);

	return E_NOTIMPL;
}


STDMETHODIMP GetSize(long* piLength)
{
	(piLength);

	return E_NOTIMPL;
}


STDMETHODIMP GetLanguageServiceID(GUID* pguidLangService)
{
	(pguidLangService);

	return E_NOTIMPL;
}


STDMETHODIMP SetLanguageServiceID(REFGUID guidLangService)
{
	(guidLangService);

	return E_NOTIMPL;
}


STDMETHODIMP GetUndoManager(IOleUndoManager** ppUndoManager)
{
	(ppUndoManager);

	return E_NOTIMPL;
}


STDMETHODIMP Reserved1()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved2()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved3()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved4()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reload(BOOL fUndoable)
{
	(fUndoable);

	return E_NOTIMPL;
}


STDMETHODIMP LockBufferEx(DWORD dwFlags)
{
	(dwFlags);

	return E_NOTIMPL;
}


STDMETHODIMP UnlockBufferEx(DWORD dwFlags)
{
	(dwFlags);

	return E_NOTIMPL;
}

// GetLastLineIndex is implementation specific


STDMETHODIMP Reserved5()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved6()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved7()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved8()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved9()
{
	return E_NOTIMPL;
}


STDMETHODIMP Reserved10()
{
	return E_NOTIMPL;
}

STDMETHODIMP GetMarkerData( 
	/* [in] */ long iTopLine,
	/* [in] */ long iBottomLine,
	/* [out] */ MARKERDATA* pMarkerData)
{
	(iTopLine, iBottomLine, pMarkerData);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReleaseMarkerData( 
	/* [in] */ MARKERDATA* pMarkerData)
{
	(pMarkerData);

	return E_NOTIMPL;
}
		

STDMETHODIMP GetLineData( 
	/* [in] */ long iLine,
	/* [out] */ LINEDATA* pLineData,
	/* [in] */ MARKERDATA* pMarkerData)
{
	(iLine, pLineData, pMarkerData);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReleaseLineData( 
	/* [in] */ LINEDATA* pLineData)
{
	(pLineData);

	return E_NOTIMPL;
}
		

STDMETHODIMP GetLineText( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [out] */ BSTR* pbstrBuf)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, pbstrBuf);

	return E_NOTIMPL;
}
		

STDMETHODIMP CopyLineText( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ _In_ LPWSTR pszBuf,
	/* [out][in] */ long* pcchBuf)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, pszBuf, pcchBuf);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReplaceLines( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ LPCWSTR pszText,
	/* [in] */ long iNewLen,
	/* [out] */ TextSpan* pChangedSpan)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, pszText, iNewLen, pChangedSpan);

	return E_NOTIMPL;
}
		

STDMETHODIMP CanReplaceLines( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ long iNewLen)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, iNewLen);

	return E_NOTIMPL;
}
		

STDMETHODIMP CreateLineMarker( 
	/* [in] */ long iMarkerType,
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ IVsTextMarkerClient *pClient,
	/* [out] */ IVsTextLineMarker **ppMarker)
{
	(iMarkerType, iStartLine, iStartIndex, iEndLine, iEndIndex, pClient, ppMarker);

	return E_NOTIMPL;
}
		

STDMETHODIMP EnumMarkers( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ long iMarkerType,
	/* [in] */ DWORD dwFlags,
	/* [out] */ IVsEnumLineMarkers** ppEnum)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, iMarkerType, dwFlags, ppEnum);

	return E_NOTIMPL;
}
		

STDMETHODIMP FindMarkerByLineIndex( 
	/* [in] */ long iMarkerType,
	/* [in] */ long iStartingLine,
	/* [in] */ CharIndex iStartingIndex,
	/* [in] */ DWORD dwFlags,
	/* [out] */ IVsTextLineMarker** ppMarker)
{
	(iMarkerType, iStartingLine, iStartingIndex, dwFlags, ppMarker);

	return E_NOTIMPL;
}
		

STDMETHODIMP AdviseTextLinesEvents( 
	/* [in] */ IVsTextLinesEvents* pSink,
	/* [out] */ DWORD* pdwCookie)
{
	(pSink, pdwCookie);

	return E_NOTIMPL;
}
		

STDMETHODIMP UnadviseTextLinesEvents( 
	/* [in] */ DWORD dwCookie)
{
	(dwCookie);

	return E_NOTIMPL;
}
		

STDMETHODIMP GetPairExtents( 
	/* [in] */ const TextSpan* pSpanIn,
	/* [out] */ TextSpan* pSpanOut)
{
	(pSpanIn, pSpanOut);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReloadLines( 
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ LPCWSTR pszText,
	/* [in] */ long iNewLen,
	/* [out] */ TextSpan* pChangedSpan)
{
	(iStartLine, iStartIndex, iEndLine, iEndIndex, pszText, iNewLen, pChangedSpan);

	return E_NOTIMPL;
}
		

STDMETHODIMP IVsTextLinesReserved1(
	/* [in] */ long iLine,
	/* [out] */ LINEDATA* pLineData,
	/* [in] */ BOOL fAttributes)
{
	(iLine, pLineData, fAttributes);

	return E_NOTIMPL;
}
		

STDMETHODIMP GetLineDataEx(
	/* [in] */ DWORD dwFlags,
	/* [in] */ long iLine,
	/* [in] */ long iStartIndex,
	/* [in] */ long iEndIndex,
	/* [out] */ LINEDATAEX* pLineData,
	/* [in] */ MARKERDATA* pMarkerData)
{
	(dwFlags, iLine, iStartIndex, iEndIndex, pLineData, pMarkerData);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReleaseLineDataEx(
	/* [in] */ LINEDATAEX* pLineData)
{
	(pLineData);

	return E_NOTIMPL;
}
		

STDMETHODIMP CreateEditPoint(
	/* [in] */ long iLine,
	/* [in] */ CharIndex iIndex,
	/* [out] */ IDispatch** ppEditPoint)
{
	(iLine, iIndex, ppEditPoint);

	return E_NOTIMPL;
}
		

STDMETHODIMP ReplaceLinesEx( 
	/* [in] */ DWORD dwFlags,
	/* [in] */ long iStartLine,
	/* [in] */ CharIndex iStartIndex,
	/* [in] */ long iEndLine,
	/* [in] */ CharIndex iEndIndex,
	/* [in] */ LPCWSTR pszText,
	/* [in] */ long iNewLen,
	/* [out] */ TextSpan* pChangedSpan)
{
	(dwFlags, iStartLine, iStartIndex, iEndLine, iEndIndex, pszText, iNewLen, pChangedSpan);

	return E_NOTIMPL;
}
		

STDMETHODIMP CreateTextPoint( 
	/* [in] */ long iLine,
	/* [in] */ CharIndex iIndex,
	/* [out] */ IDispatch** ppTextPoint)
{
	(iLine, iIndex, ppTextPoint);

	return E_NOTIMPL;
}

};

/*
All four of these interfaces, as well as a connection point for IVsTextViewEvents, are required so 
that double-clicking on results of a find in files in the output window will correctly naviagate 
to the location in the document.  That is the only only scenario these interfaces are required for.
*/
template <class Derived_T>
class SingleViewFindInFilesOutputWindowIntegrationImpl :
	public IVsTextViewSimpleImpl,
	public IVsTextViewEventsNotImpl,
	public IVsCodeWindowSingleViewSimpleImpl,
	public IVsTextLinesNotImpl
{
protected:

	// Call in CreatePaneWindow
	void RegisterToTextManager()
	{
		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		CComPtr<IVsTextManager> spTextManager;
		// REVIEW - 3/17/2006 - is this ever not present?
		if(SUCCEEDED(rDerived.GetVsSiteCache().QueryService(SID_SVsTextManager, &spTextManager)))
		{
			CComPtr<IVsTextView> spTextView;
			VSL_CHECKHRESULT(rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextView, reinterpret_cast<void**>(&spTextView)));

			CComPtr<IVsTextBuffer> spTextBuffer;
			VSL_CHECKHRESULT(rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextBuffer, reinterpret_cast<void**>(&spTextBuffer)));

			VSL_CHECKHRESULT(spTextManager->RegisterView(spTextView, spTextBuffer));
		}
	}

	void UnregisterFromTextManager()
	{
		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		CComPtr<IVsTextManager> spTextManager;
		// REVIEW - 3/17/2006 - is this ever not present?
		if(SUCCEEDED(rDerived.GetVsSiteCache().QueryService(SID_SVsTextManager, &spTextManager)))
		{
			CComPtr<IVsTextView> spTextView;
			VSL_CHECKHRESULT(rDerived._GetRawUnknown()->QueryInterface(IID_IVsTextView, reinterpret_cast<void**>(&spTextView)));

			VSL_CHECKHRESULT(spTextManager->UnregisterView(spTextView));
		}
	}

};

} // namespace VSL

#endif VSLFINDANDREPLACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
