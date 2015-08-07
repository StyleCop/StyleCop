// EditorFindAndReplace.inl

#pragma once

/***************************************************************************
IVsFindTarget implementation
***************************************************************************/

// Called by VSL::IVsFindTargetImpl::GetCapabilities and 
// VSL::IVsFindTargetImpl::GetSearchImage
template <class Traits_T>
DWORD EditorDocument<Traits_T>::GetCapabilityOptions()
{
	DWORD dwOptions =
		FR_MatchCase |    // Match case
		FR_WholeWord |    // Match whole word
		FR_Hidden |       // Hidden text
		FR_Backwards |    // Backwards from insertion point
		FR_Selection |    // Search selection only
		FR_SubFolders |   // Support subfolders
		FR_KeepOpen |     // Keep Open
		FR_Plain |        // Plain (as opposed to reg expression)
		FR_TargetMask |   // All targets (FR_Document, FR_OpenDocuments, FR_Files, FR_Project, FR_Solution)
		FR_ActionMask |   // All actions (FR_MarkAll, FR_Find, FR_FindAll, FR_Replace, FR_ReplaceAll)
		FR_FromStart |    // Search from beginning
		FR_OneMatchPerLine | // One match per line
		FR_Report;        // Report

	// If the file is "Read Only" then disable the replace options
	if(IsFileReadOnly())
	{
		dwOptions &= ~(FR_ReplaceAll | FR_Replace);
	}

	// If the selection is empty then disable the "Search Selection Only" option
	if(IsSelectionEmpty())
	{
		dwOptions &= ~FR_Selection;
	}

	return dwOptions;
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetProperty(VSFTPROPID propid, _Out_ VARIANT *pvar)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pvar, E_INVALIDARG);

	::VariantClear(pvar);

	switch(propid)
	{
	case VSFTPROPID_DocName: 
		CHK(!GetFileName().IsEmpty(), E_UNEXPECTED);
		// Return a copy of the file name as the document name
		pvar->vt = VT_BSTR;
		pvar->bstrVal = ::SysAllocString(GetFileName());
		CHKPTR(pvar->bstrVal, E_OUTOFMEMORY);
		break;

	case VSFTPROPID_IsDiskFile: 
		pvar->vt = VT_BOOL;
		pvar->boolVal = GetFile().IsOnDisk() ? TRUE : FALSE;
		break;

	case VSFTPROPID_InitialPatternAggressive:
		// Intentional fall through
	case VSFTPROPID_InitialPattern: 
		pvar->vt = VT_BSTR;
		GetInitialPattern(&pvar->bstrVal);
		break;

	case VSFTPROPID_WindowFrame: 
		pvar->vt = VT_UNKNOWN;
		// Query the same site provided to the SetSite method of this instance
		CHKHR(GetVsSiteCache().QueryService(SID_SVsWindowFrame, &pvar->punkVal));
		CHKPTR(pvar->punkVal, E_NOINTERFACE); // paranoid
		break;
	default:
		VSL_SET_STDMETHOD_HRESULT(E_NOTIMPL);
	}

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

// Callers call into this to tell us to highlight a span in the document
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::NavigateTo(const TextSpan* pts)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pts, E_INVALIDARG);

	// Make sure the window is visible
	CComPtr<IVsWindowFrame> spFrame;
	CHKHR(GetVsSiteCache().QueryService(SID_SVsWindowFrame, &spFrame));
	CHKHR(spFrame->Show());

	// Now, tell the editor control to select the span given
	long lStartIndex = GetControl().GetIndexFromLineAndCharacter(pts->iStartLine, pts->iStartIndex);
	if(lStartIndex < 0)
	{
		return E_INVALIDARG;  // Caller gave us a faulty text span
	}

	long lEndIndex = GetControl().GetIndexFromLineAndCharacter(pts->iEndLine, pts->iEndIndex);
	if(lEndIndex < 0)	
	{
		return E_INVALIDARG;  // Caller gave us a faulty text span
	}

	GetControl().SetSelection(lStartIndex, lEndIndex);
	
	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetCurrentSpan(_Out_ TextSpan* pts)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pts, E_INVALIDARG);

	CComPtr<ITextSelection> spTextSelection;
	GetTextSelection(spTextSelection);

	long iSpanStart = 0;
	CHKHR(spTextSelection->GetStart(&iSpanStart));

	long iSpanEnd = 0;
	CHKHR(spTextSelection->GetEnd(&iSpanEnd));

	pts->iStartLine = GetControl().GetLineFromIndex(iSpanStart);
	pts->iStartIndex = GetControl().GetCharacterPositionFromIndex(iSpanStart);
	pts->iEndLine = GetControl().GetLineFromIndex(iSpanEnd);
	pts->iEndIndex = GetControl().GetCharacterPositionFromIndex(iSpanEnd);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

/***************************************************************************
IVsTextImage implementation
***************************************************************************/

// Returns the number of lines in the editor
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetLineSize( 
	/* [retval][out] */ _Out_ LONG* pcLines)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pcLines, E_INVALIDARG);

	long iLines = GetControl().GetLineCount();

	*pcLines = iLines;

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::Replace( 
	/* [in] */ DWORD dwFlags,
	/* [in] */ const TextSpan* pts,
	/* [in] */ LONG /*cch*/,
	/* [size_is][in] */ LPCOLESTR pchText,
	/* [retval][out] */ _Out_ TextSpan* ptsChanged)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pts, E_INVALIDARG);

	// pts contains the span of the text to replace.  Set the selection to be pts.
	long iStartIndex = GetControl().GetIndexFromLineAndCharacter(pts->iStartLine, pts->iStartIndex);
	if(iStartIndex < 0)
	{
		return E_INVALIDARG; // pts is bad
	}

	long iEndIndex = GetControl().GetIndexFromLineAndCharacter(pts->iEndLine, pts->iEndIndex);
	if(iEndIndex < 0)
	{
		return E_INVALIDARG; // pts is bad
	}

	// Set the selection
	GetControl().SetSelection(iStartIndex, iEndIndex);

	CComPtr<ITextSelection> spTextSelection;
	GetTextSelection(spTextSelection);

	// Store the starting position of this selection
	long iSelectionStart = 0;
	CHKHR(spTextSelection->GetStart(&iSelectionStart));

	// Call the function to replace the currently selected text
	// with the given replacement string
	CComBSTR bstrReplace = pchText;    // Replacement text

	// Do the actual replace
	CHKHR(spTextSelection->SetText(bstrReplace));

	long iEndPosition = 0;
	CHKHR(spTextSelection->GetEnd(&iEndPosition));

	if ((dwFlags & FR_Backwards) == 0)
	{
		// In case of forward search place the insertion point at the end of the new text, 
		// so it will be skipped during the next call to Find.
		CHKHR(spTextSelection->SetStart(iEndPosition));
	}
	else
	{
		// If the search is backward, then set the end position at the
		// beginning of the new text.
		CHKHR(spTextSelection->SetEnd(iSelectionStart));
	}

	// Set ptsSpan to contain the replaced text's span info if caller requests for it
	if(ptsChanged)
	{
		ptsChanged->iStartLine = GetControl().GetLineFromIndex(iSelectionStart);
		ptsChanged->iStartIndex = GetControl().GetCharacterPositionFromIndex(iSelectionStart);
		ptsChanged->iEndLine = GetControl().GetLineFromIndex(iEndPosition);
		ptsChanged->iEndIndex = GetControl().GetCharacterPositionFromIndex(iEndPosition);
	}

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

// Note, line endings are included in the length of a span
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetSpanLength( 
	/* [in] */ const TextSpan* pts,
	/* [retval][out] */ _Out_ LONG* pcch)
{
	
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pts, E_INVALIDARG);
	VSL_CHECKPOINTER(pcch, E_INVALIDARG);

	// Need to convert the starting and end points of the span into their index equivalent
	long iStartIndex = GetControl().GetIndexFromLineAndCharacter(pts->iStartLine, pts->iStartIndex);
	if(iStartIndex < 0)
	{
		return E_INVALIDARG;  // pts is bad
	}

	long iEndIndex = GetControl().GetIndexFromLineAndCharacter(pts->iEndLine, pts->iEndIndex);
	if(iEndIndex < 0)
	{
		return E_INVALIDARG;  // pts is bad
	}

	*pcch = ::abs(iEndIndex - iStartIndex);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}
		
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetLineLength( 
	/* [in] */ LONG iLine,
	/* [retval][out] */ _Out_ LONG* piLength)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(piLength, E_INVALIDARG);

	if(iLine < 0)
	{
		return E_INVALIDARG;
	}

	// Convert the line number into an index equivalent
	*piLength = GetControl().GetLineLength(iLine);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetLine( 
	/* [in] */ DWORD grfGet,
	/* [in] */ LONG iLine,
	/* [in] */ LONG iStartIndex,
	/* [in] */ LONG iEndIndex,
	/* [retval][out] */ _Out_ LINEDATAEX* pLineData)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(pLineData, E_INVALIDARG);

	// Initialize pLineData
	pLineData->iLength = 0;
	pLineData->pszText = NULL;
	pLineData->iEolType = eolCR;
	pLineData->pAttributes = 0;
	pLineData->dwFlags = static_cast<USHORT>(ldfDefault);
	pLineData->dwReserved = 0;
	pLineData->pAtomicTextChain = NULL;

	// First, make sure all of the inputs make sense
	long iLineCount = GetControl().GetLineCount();

	if( iLine < 0 ||
		iLine >= iLineCount ||
		iStartIndex < 0 ||
		iEndIndex < 0 ||
		iStartIndex > iEndIndex)  // An empty span is valid
	{
		return E_INVALIDARG;
	}

	// Length of the line is the span between the start and end index
	long iLineLength = GetControl().GetLineLength(iLine);
	// Check if the line is empty and the caller asks for an empty span.
	if (0 == iLineLength && 0 == iStartIndex && 0 == iEndIndex)
	{
		pLineData->pszText = NULL;
		return S_OK;
	}

	// Get the length of the span.
	long iLineSpanLength = iEndIndex - iStartIndex +1;

	// If the span length determined by the start and end index is greater than the length of the line, this is an error
	if(iLineSpanLength > iLineLength)
	{
		return E_INVALIDARG;
	}

	// Now, grab the text
	Pointer<StdArrayPointerTraits<WCHAR> > szText;
	GetControl().GetLineText(iLine, szText);

	if(grfGet & gldeSubset)
	{
		pLineData->iLength = iLineSpanLength;
		Pointer<StdArrayPointerTraits<WCHAR> > szSubText = new WCHAR[iLineSpanLength+1]; // Plus 1 for NULL
		// Now, copy the substring
		CHK(0 == ::wcsncpy_s(szSubText, iLineSpanLength+1, szText+iStartIndex, iLineSpanLength), E_FAIL);
		pLineData->pszText = szSubText.Detach();
	}
	// Else, whole line
	else
	{
		pLineData->iLength = iLineLength;
		pLineData->pszText = szText.Detach();
	}

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

/***************************************************************************
IVsTextBuffer implementation

This is just provided so that the find in files scenario will work 
properly.  It isn't necessary to implement most of the methods for this
scenario to work correctly.
***************************************************************************/

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetLengthOfLine(long iLine, _Out_ long* piLength)
{
	// defer to IVsTextImage::GetLineLength
	return GetLineLength(iLine, piLength);
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetLastLineIndex(_Out_ long* piLine, _Out_ long* piIndex)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(piLine, E_INVALIDARG);
	VSL_CHECKPOINTER(piIndex, E_INVALIDARG);

	*piLine = 0;
	*piIndex = 0;

	GetLineSize(piLine); // Get the number of lines in the editor
	if(*piLine >= 1)
	{
		// We need to subtract 1 to get the index
		(*piLine) -= 1;
	}

	// Now, get the line length of the last line
	long cLineLength = GetControl().GetLineLength(*piLine);
	*piIndex = (cLineLength >= 1 ? cLineLength - 1 : cLineLength);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

/***************************************************************************
IVsTextView implementation

This is just provided so that the find in files scenario will work 
properly.  It isn't necessary to implement most of the methods for this
scenario to work correctly.
***************************************************************************/

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::SetSelection(
	long iAnchorLine, 
	ViewCol iAnchorCol, 
	long iEndLine, 
	ViewCol iEndCol)
{
	// Convert the given inputs to be the start and end index
	long lStartIndex = GetControl().GetIndexFromLineAndCharacter(iAnchorLine, iAnchorCol);
	if( lStartIndex < 0 )
	{
		return E_INVALIDARG;
	}

	long lEndIndex = GetControl().GetIndexFromLineAndCharacter(iEndLine, iEndCol);
	if( lEndIndex < 0 )	
	{
		return E_INVALIDARG;
	}

	GetControl().SetSelection(lStartIndex, lEndIndex);

	return S_OK;
}

/////////////////////////////////////////////////////////////////////////////////
//    Helper Functions
/////////////////////////////////////////////////////////////////////////////////

template <class Traits_T>
void EditorDocument<Traits_T>::GetInitialPattern(_Deref_out_z_ BSTR* pbstrPattern)
{
	*pbstrPattern = NULL;

	// First check if the selection is empty.
	if(IsSelectionEmpty())
	{
		return;
	}

	// Now check if the selection is multiline by:
	//    - Getting and then duplicating the current text range.
	//    - Advancing the start of the duplicate by one line
	//    - Checking if the duplicate range is still within
	//      the original range.
	// If the check is true then the selection is multiline.
	CComPtr<ITextSelection> spITextSelection;
	GetTextSelection(spITextSelection);

	// Duplicate the text selection
	CComPtr<ITextRange> spDuplicate;
	CHKHR(spITextSelection->GetDuplicate(&spDuplicate));
	// Advance the start of the duplicate by one line
	CHKHR(spDuplicate->MoveStart(tomLine, 1, NULL));

	// Get the ends of each range. 
	long iEndOrig;
	CHKHR(spITextSelection->GetEnd(&iEndOrig));
	long iEndDup;
	CHKHR(spDuplicate->GetEnd(&iEndDup));

	// If the ends are still the same then the selection is multiline.
	if(iEndOrig == iEndDup)
	{
		return;
	}

	// The selection is all within a single line so retrieve the selection text.
	CHKHR(spITextSelection->GetText(pbstrPattern));
}
