// EditorWindowing.inl

template <class Traits_T>
void EditorDocument<Traits_T>::SetFontName(_In_ VARIANT *pvarNew)
{
	VSL_ASSERT(NULL != pvarNew); // Caller should ensure this isn't NULL, so no retail check

	// The user may manually select any font rather than selecting a font from the drop-down list.
	// So make sure the string length is sufficiently short for the CHARFORMATW structure
	VSL_CHECKBOOL(::SysStringLen(pvarNew->bstrVal) < LF_FACESIZE, E_INVALIDARG);

	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	// NOTE - since this doesn't take a character set, some fonts may not render correctly,
	// but this scenario has no bearing on integrating into Visual Studio correctly.
	CHKHR(spITextFont->SetName(pvarNew->bstrVal));
}

template <class Traits_T>
void EditorDocument<Traits_T>::SetFontSize(_In_ VARIANT *pvarNew)
{
	VSL_ASSERT(NULL != pvarNew); // Caller should ensure this isn't NULL, so no retail check

	long iFontSize = ::wcstol(V_BSTR(pvarNew), NULL, 10);
	CHK((iFontSize != 0 && iFontSize != LONG_MAX && iFontSize != LONG_MIN), E_INVALIDARG);

	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	CHKHR(spITextFont->SetSize(static_cast<float>(iFontSize)));
}


template <class Traits_T>
void EditorDocument<Traits_T>::GetFontName(_Out_ VARIANT *pvarOut)
{
	VSL_ASSERT(NULL != pvarOut); // Caller should ensure this isn't NULL, so no retail check

	// Clear the out value here in case of failure
    ::VariantClear(pvarOut);

	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	CHKHR(spITextFont->GetName(&pvarOut->bstrVal));

	// Set the variant type on success
	V_VT(pvarOut) = VT_BSTR;
}

template <class Traits_T>
void EditorDocument<Traits_T>::GetFontSize(_Out_ VARIANT *pvarOut)
{
	VSL_ASSERT(NULL != pvarOut); // Caller should ensure this isn't NULL, so no retail check

	// Clear the out value here in case of failure
    ::VariantClear(pvarOut);

	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	float fFontSize;
	CHKHR(spITextFont->GetSize(&fFontSize));

	// Convert font size to int, which will truncate, so add 0.5 to get rounding rather then 
	// truncation
	int iFontSize = static_cast<long>(fFontSize + 0.5);

	// Less than 0 indicates more then one font size selected, so return empty string.
	wchar_t szFontSize[12] = L""; // 11 characters is the max needed for signed int, +1 for terminator
	if(iFontSize >= 0)
	{
		// No return value indicates an error
		::_itow_s(iFontSize, szFontSize, _countof(szFontSize), 10);
	}

	pvarOut->bstrVal = ::SysAllocString(szFontSize);
	CHKPTR(pvarOut->bstrVal, E_OUTOFMEMORY);

	// Set the variant type on success
	V_VT(pvarOut) = VT_BSTR;
}

/***************************************************************************
	IVsStatusBarUser Implementation
***************************************************************************/

// Displays the current insertion point line\column and insert\overstrike etc. in the status bar.
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::SetInfo()
{
	VSL_STDMETHODTRY{

	CComPtr<IVsStatusbar> spIVsStatusBar;
	CHKHR(GetVsSiteCache().QueryService(SID_SVsStatusbar, &spIVsStatusBar));

	// Set the selection (or insertion point) position
	StatusBarUpdatePos(spIVsStatusBar);

	// Only STREAM selection mode is supported, so just set that
	CComVariant vtSelMode(static_cast<__int32>(UIE_TEXTSELMODE_STREAM), VT_I4);
	spIVsStatusBar->SetSelMode(&vtSelMode);

	// Set insert or overstrike
	StatusBarUpdateInsMode(spIVsStatusBar);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
void EditorDocument<Traits_T>::StatusBarUpdatePos(_In_ IVsStatusbar* pIVsStatusBar)
{
	CComPtr<IVsStatusbar> spIVsStatusBar = pIVsStatusBar;

	if(!spIVsStatusBar)
	{
		CHKHR(GetVsSiteCache().QueryService(SID_SVsStatusbar, &spIVsStatusBar));
	}

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);

	long iMin = 0;
	CHKHR(spITextSelection->GetStart(&iMin));
	long iMax = 0;
	CHKHR(spITextSelection->GetEnd(&iMax));

	// The presence of tomSelStartActive indicates that the cursor is at the
	// beginning of current selection, rather then the end.
	long iCursorIndex = (GetTextSelectionFlags() & tomSelStartActive) ? iMin : iMax;

	// add one to the line and column to get an origin of of 1,1 rather then 0,0
	CComVariant varLine(static_cast<__int32>(GetControl().GetLineFromIndex(iCursorIndex)+1), VT_I4);
	CComVariant varCharacterPosition(static_cast<__int32>(GetControl().GetCharacterPositionFromIndex(iCursorIndex)+1), VT_I4);

	// Now update the status bar's line and character position; however,
	// do not update the column, as that requires properly accounting for tab settings
	CHKHR(spIVsStatusBar->SetLineChar(&varLine, &varCharacterPosition));
}

template <class Traits_T>
void EditorDocument<Traits_T>::StatusBarUpdateInsMode(_In_ IVsStatusbar* pIVsStatusBar)
{
	CComPtr<IVsStatusbar> spIVsStatusBar = pIVsStatusBar;

	if(!spIVsStatusBar)
	{
		CHKHR(GetVsSiteCache().QueryService(SID_SVsStatusbar, &spIVsStatusBar));
	}

	CComVariant varInsertionMode(static_cast<__int32>(GetTextSelectionFlags() & tomSelOvertype ? UIE_TEXTINSMODE_OVERSTRIKE : UIE_TEXTINSMODE_INSERT), VT_I4);
	spIVsStatusBar->SetInsMode(&varInsertionMode);
}    

template <class Traits_T>
long EditorDocument<Traits_T>::GetTextSelectionFlags()
{
	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);

	long iFlags = 0;
	VSL_CHECKHRESULT(spITextSelection->GetFlags(&iFlags));
	
	return iFlags;
}



//////////////////////////////////////////////////////////////////
//IVsToolBoxUser methods
//////////////////////////////////////////////////////////////////

// Called determine if a toolbox item can be added to the document.
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::IsSupported(_In_ IDataObject* pDataObject)
{
	VSL_STDMETHODTRY{

	// Determine if pDataObject can be pasted by querying the control
	ATL::CComVariant vt;
	IVsToolboxUserHelper(pDataObject, vt);

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);

	long bCanPaste;
	VSL_CHECKHRESULT(spITextSelection->CanPaste(&vt, 0, &bCanPaste));

	// returning S_FALSE indicates an inability to paste pDataObject
	if(tomTrue != bCanPaste)
	{
		return S_FALSE;
	}

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

// Called when the user adds a supported toolbox item to the document.
template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::ItemPicked(_In_ IDataObject* pDataObject)
{
	VSL_STDMETHODTRY{

	ATL::CComVariant vt;
	IVsToolboxUserHelper(pDataObject, vt);

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);

	// Add the item by pasting it in
	VSL_CHECKHRESULT(spITextSelection->Paste(&vt, 0));

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

//////////////////////////////////////////////////////////////////
// Helper methods
//////////////////////////////////////////////////////////////////

template <class Traits_T>
void EditorDocument<Traits_T>::IVsToolboxUserHelper(_In_ IDataObject* pDataObject, ATL::CComVariant& vt)
{
	VSL_CHECKPOINTER(pDataObject, E_INVALIDARG);

	VSL_CHECKHRESULT(pDataObject->QueryInterface(IID_IUnknown, reinterpret_cast<void**>(&vt.punkVal)));
	VSL_CHECKPOINTER(vt.punkVal, E_FAIL);
	vt.vt = VT_UNKNOWN;
}

template <class Traits_T>
bool EditorDocument<Traits_T>::CanCycleClipboard()
{
	BOOL bCanCycle = FALSE;

	CComPtr<IVsToolboxClipboardCycler> spIVsToolboxClipboardCycler;
	CHKHR(GetVsSiteCache().QueryService(SID_SVsToolbox, &spIVsToolboxClipboardCycler));

	// This will call back into IVsToolboxUser::IsSupported
	spIVsToolboxClipboardCycler->AreDataObjectsAvailable(static_cast<IVsToolboxUser*>(this), &bCanCycle);

	return bCanCycle ? true : false;
}

template <class Traits_T>
void EditorDocument<Traits_T>::PasteClipboardObject()
{
	CComPtr<IVsToolboxClipboardCycler> spIVsToolboxClipboardCycler;
	CHKHR(GetVsSiteCache().QueryService(SID_SVsToolbox, &spIVsToolboxClipboardCycler));

	// Ask the toolbox for what to paste
	CComPtr<IDataObject> spIDataObject;
	CHKHR(spIVsToolboxClipboardCycler->GetAndSelectNextDataObject(static_cast<IVsToolboxUser*>(this), &spIDataObject));

	CComPtr<ITextSelection> spITextSelection;
	GetTextSelection(spITextSelection);

	// Get the current position of the start of the current selection. 
	// After the paste the position of the start of current selection
	// will be moved to the end of inserted text, so it needs to
	// move back to original position so that inserted text can be highlighted to 
	// allow cycling through our clipboard items.
	long iOriginalStart;
	CHKHR(spITextSelection->GetStart(&iOriginalStart));

	// This will do the actual pasting of the object
	ItemPicked(spIDataObject);

	// Now move the start position backwards to the original position.
	long iCurrentStart;
	CHKHR(spITextSelection->GetStart(&iCurrentStart));
	CHKHR(spITextSelection->MoveStart(tomCharacter, iOriginalStart - iCurrentStart, NULL));

	// Select the pasted text
	CHKHR(spITextSelection->Select());
}

template <class Traits_T>
bool EditorDocument<Traits_T>::IsSelectionEmpty()
{
	CComPtr<ITextSelection> spITextSelection;
	GetTextSelection(spITextSelection);
	long iStart = 0;
	CHKHR(spITextSelection->GetStart(&iStart));
	long iEnd = 0;
	CHKHR(spITextSelection->GetEnd(&iEnd));

	return (iStart == iEnd);
}

template <class Traits_T>
DWORD EditorDocument<Traits_T>::GetFontFormatState(DWORD dwEffect)
{
	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	long iState = tomFalse;

	switch(dwEffect)
	{
	case CFE_BOLD:
		CHKHR(spITextFont->GetBold(&iState));
		break;

	case CFE_ITALIC:
		CHKHR(spITextFont->GetItalic(&iState));
		break;

	case CFE_UNDERLINE:
		CHKHR(spITextFont->GetUnderline(&iState));
		if(iState == tomTrue || iState == tomSingle || iState == tomWords || iState == tomDouble || iState == tomDotted)
		{
			// Any of these indicate underlined
			iState = tomTrue;
		}
		else
		{
			// Anything else, such as tomNone or tomUndefined, is considered not underlined
			iState = tomFalse;
		}
		break;

	case CFE_STRIKEOUT:
		CHKHR(spITextFont->GetStrikeThrough(&iState));
		break;
	}

	return iState == tomTrue ? OLECMDSTATE_DOWN : OLECMDSTATE_UP;
}

template <class Traits_T>
VOID EditorDocument<Traits_T>::SetFontFormatState(DWORD dwEffect)
{
	CComPtr<ITextFont> spITextFont;
	GetTextFont(spITextFont);

	switch(dwEffect)
	{
	case CFE_BOLD:
		CHKHR(spITextFont->SetBold(tomToggle));
		break;

	case CFE_ITALIC:
		CHKHR(spITextFont->SetItalic(tomToggle));
		break;

	case CFE_UNDERLINE:
		{
		long iUnderlineState = tomNone;
		CHKHR(spITextFont->GetUnderline(&iUnderlineState));
		if(tomNone == iUnderlineState || tomUndefined == iUnderlineState)
		{
			// Only single underlining is supported
			CHKHR(spITextFont->SetUnderline(tomSingle));
		}
		else
		{
			// Anything other then tomNone or tomUndefined, is considered underlined
			// even if it isn't single underlined.
			CHKHR(spITextFont->SetUnderline(tomNone));
		}
		}
		break;

	case CFE_STRIKEOUT:
		CHKHR(spITextFont->SetStrikeThrough(tomToggle));
		break;
	}
}

template <class Traits_T>
DWORD EditorDocument<Traits_T>::QueryParagraphAlignmentState(long iToQuery)
{
	CComPtr<ITextPara> spITextPara;
	GetTextPara(spITextPara);

	long iAlignment = tomNone;
	CHKHR(spITextPara->GetAlignment(&iAlignment));

	// If the alignment being queried for is the same as the current one, then it's active (down)
	return iAlignment == iToQuery ? OLECMDSTATE_DOWN : OLECMDSTATE_UP;
}

template <class Traits_T>
DWORD EditorDocument<Traits_T>::GetBulletState()
{
	CComPtr<ITextPara> spITextPara;
	GetTextPara(spITextPara);

	// There are multiple list types but only support bulleted is supported.
	long iListType = tomListNone;
	CHKHR(spITextPara->GetListType(&iListType));

	return iListType == tomListBullet ? OLECMDSTATE_DOWN : OLECMDSTATE_UP;
}

template <class Traits_T>
void EditorDocument<Traits_T>::SetParagraphAlignment(long iAlignment)
{
	CComPtr<ITextPara> spITextPara;
	GetTextPara(spITextPara);

	CHKHR(spITextPara->SetAlignment(iAlignment));
}

template <class Traits_T>
void EditorDocument<Traits_T>::ToggleBulleted()
{
	CComPtr<ITextPara> spITextPara;
	GetTextPara(spITextPara);

	// There are multiple list types but only support bulleted is supported.
	long lCurrent = tomListNone;
	CHKHR(spITextPara->GetListType(&lCurrent));
	if(tomListBullet == lCurrent)
	{
		// If set, toggle bulleted
		CHKHR(spITextPara->SetListType(tomListNone));
	}
	else
	{
		// If not bulleted, toggle to bulleted (even if another list type)
		CHKHR(spITextPara->SetListType(tomListBullet));
	}
}

template <class Traits_T>
void EditorDocument<Traits_T>::UpdateVSCommandUI()
{
	CComPtr<IVsUIShell> spIVsUIShell = GetVsSiteCache().GetCachedService<IVsUIShell, SID_SVsUIShell>();
	if(!!spIVsUIShell)
	{
		// Tell VS to update the menus and toolbars
		CHKHR(spIVsUIShell->UpdateCommandUI(FALSE));
	}
}

