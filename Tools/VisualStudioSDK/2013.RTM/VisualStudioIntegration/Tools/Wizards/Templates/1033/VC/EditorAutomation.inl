// EditorAutomation.inl

#pragma once

/*
ISingleViewEditor is the automation interface for EditorDocument.  The implementation
of the methods is just a thin wrapper over the site cache and the rich edit control's object
model.
*/

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_DTE(_Deref_out_ _DTE** ppDTE)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(ppDTE, E_INVALIDARG);

	// Return the VS DTE service
	return GetVsSiteCache().QueryService(SID_SDTE, ppDTE);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_Parent(_Deref_out_ _DTE** ppParent)
{
	// Delegate, as the VS DTE is the parent of this automation object
	return get_DTE(ppParent);
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_DefaultTabStop(_Out_ float* pfStop)
{
	VSL_RETURN_E_INVALIDARG_IF_NULL(pfStop);

	return GetControl().GetITextDocument()->GetDefaultTabStop(pfStop);
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::put_DefaultTabStop(float fStop)
{
	return GetControl().GetITextDocument()->SetDefaultTabStop(fStop);
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_Range(_Deref_out_ /*ITextRange*/ IDispatch** ppRange)
{
	VSL_RETURN_E_INVALIDARG_IF_NULL(ppRange);

	VSL_STDMETHODTRY{

	CComPtr<ITextRange> spRange;
	CHKHR(GetControl().GetITextDocument()->Range(0, tomForward, &spRange));
	CHKHR(spRange->QueryInterface(IID_IDispatch, (void**)ppRange));

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_Selection(_Deref_out_ /*ITextSelection*/ IDispatch** ppSelection)
{
	VSL_RETURN_E_INVALIDARG_IF_NULL(ppSelection);

	VSL_STDMETHODTRY{

	CComPtr<ITextSelection> spSelection;
	CHKHR(GetControl().GetITextDocument()->GetSelection(&spSelection));
	CHKHR(spSelection->QueryInterface(IID_IDispatch, (void**)ppSelection));

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::get_Flags(_Out_ long* piFlags)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(piFlags, E_INVALIDARG);

	*piFlags = GetTextSelectionFlags();
		
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::put_Flags(long iFlags)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->SetFlags(iFlags));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::FindText(_In_ BSTR bstrToFind)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(bstrToFind, E_INVALIDARG);

	CComPtr<ITextRange>	spITextRange;
	GetTextRange(spITextRange);

	long cFound = 0;
	return spITextRange->FindText(bstrToFind, tomForward, 0, &cFound);

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::SetText(_In_ BSTR bstrToSet)
{
	// Just delegate to TypeText
	return TypeText(bstrToSet);
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::TypeText(_In_ BSTR bstrToType)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(bstrToType, E_INVALIDARG);

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->TypeText(bstrToType));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::Cut()
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->Cut(NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::Copy()
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->Copy(NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::Paste()
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->Paste(NULL, 0));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::Delete(long iUnit, long iCount)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->Delete(iUnit, iCount, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}


template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::MoveUp(long iUnit, long iCount, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->MoveUp(iUnit, iCount, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::MoveDown(long iUnit, long iCount, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->MoveDown(iUnit, iCount, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::MoveLeft(long iUnit, long iCount, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->MoveLeft(iUnit, iCount, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::MoveRight(long iUnit, long iCount, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->MoveRight(iUnit, iCount, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::EndKey(long iUnit, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->EndKey(iUnit, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::HomeKey(long iUnit, long iExtend)
{
	VSL_STDMETHODTRY{

	CComPtr<ITextSelection>	spITextSelection;
	GetTextSelection(spITextSelection);
	VSL_SET_STDMETHOD_HRESULT(spITextSelection->HomeKey(iUnit, iExtend, NULL));
	GetControl().SetFocus();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
void EditorDocument<Traits_T>::RecordCommand(const wchar_t* szCommand)
{
	if(m_Recorder.IsRecording(GetVsSiteCache()))
	{
		CStringW strLine = L"ActiveDocument.Object.";

		strLine += szCommand;

		m_Recorder.RecordLine(strLine);
	}
}

template <class Traits_T>
void EditorDocument<Traits_T>::RecordKeyStroke(UINT msg, _In_ WPARAM wParam, _In_ LPARAM /*lParam*/)
{
	CStringW strMacro;

	switch(msg)
	{
	case WM_CHAR:
		// Only deal with text characters.  Everything, space and above is a text character
		// except DEL (0x7f).  Include carriage return (enter key) and tab, which are
		// below space, since those are also text characters.
		if(	(wParam >= L' ' && wParam != 0x7f) // 0x7f is DEL, don't process that
			|| L'\r' == wParam
			|| L'\t' == wParam)
		{
			if(!m_Recorder.IsLastRecordedMacro(eLastMacroText))
			{
				// clear the buffer, the last line won't be replaced, if it wasn't also
				// for text
				m_strTextToRecord.Empty();
			}

			if(L'\r' == wParam)
			{
				// Emit "vbCr" as the standard line terminator
				m_strTextToRecord.Append(L"\" & vbCr & \"");
			}
			else if(L'\t' == wParam)
			{
				// Emit "vbTab" as the standard tab
				m_strTextToRecord.Append(L"\" & vbTab & \"");
			}
			else
			{
				m_strTextToRecord += static_cast<wchar_t>(wParam);
			}

			strMacro.Append(L"ActiveDocument.Object.TypeText(\"");
			strMacro.Append(m_strTextToRecord);
			strMacro.Append(L"\")");

			if(m_Recorder.RecordBatchedLine(eLastMacroText, strMacro, 100)) // arbitrary max length
			{
				// Clear out the buffer if the line hit max length, since
				// it will not continue to be appended to
				m_strTextToRecord.Empty();
			}
		}
		break;

	case WM_KEYDOWN:
		{
		// Obtain the CTRL and SHIFT as they modify a number of the virtual keys. 
		bool bShift = Keyboard::IsKeyDown(VK_SHIFT);
		bool bCtrl = Keyboard::IsKeyDown(VK_CONTROL);

		// wParam indicates the virtual key.
		switch(wParam)
		{
		case VK_BACK: // BackSpace key
			// Note that SHIFT does not affect this command
			RecordDelete(true, bCtrl && IsSelectionEmpty());
			break;

		case VK_DELETE:
			// Note that SHIFT completely disables this command
			if(!bShift)
			{
				RecordDelete(false, bCtrl && IsSelectionEmpty());
			}
			break;

		case VK_LEFT: // Left Arrow
			// SHIFT indicates selection, CTRL indicates words instead of characters
			{
			LastMacro macroType = bCtrl ?
			(bShift ? eLastMacroLeftArrowWordSel : eLastMacroLeftArrowWord) : 
			(bShift ? eLastMacroLeftArrowCharSel : eLastMacroLeftArrowChar);

			RecordMove(macroType, L"Left", bCtrl ? Word : Character, bShift);
			}
			break;

		case VK_RIGHT: // Right Arrow
			// SHIFT indicates selection, CTRL indicates words instead of characters
			{
			LastMacro macroType = bCtrl ?
			(bShift ? eLastMacroRightArrowWordSel : eLastMacroRightArrowWord) : 
			(bShift ? eLastMacroRightArrowCharSel : eLastMacroRightArrowChar);

			RecordMove(macroType, L"Right", bCtrl ? Word : Character, bShift);
			}
			break;

		case VK_UP: // Up Arrow
			// SHIFT indicates selection, CTRL indicates paragraphs instead of lines
			{
			LastMacro macroType = bCtrl ?
			(bShift ? eLastMacroUpArrowParaSel : eLastMacroUpArrowPara) : 
			(bShift ? eLastMacroUpArrowLineSel : eLastMacroUpArrowLine);

			RecordMove(macroType, L"Up", bCtrl ? Paragraph : Line, bShift);
			}
			break;

		case VK_DOWN: // Down Arrow
			// SHIFT indicates selection, CTRL indicates paragraphs instead of lines
			{
			LastMacro macroType = bCtrl ?
			(bShift ? eLastMacroDownArrowParaSel : eLastMacroDownArrowPara) : 
			(bShift ? eLastMacroDownArrowLineSel : eLastMacroDownArrowLine);

			RecordMove(macroType, L"Down", bCtrl ? Paragraph : Line, bShift);
			}
			break;

		case VK_PRIOR: // Page Up
		case VK_NEXT: // Page Down
			strMacro.Append(L"ActiveDocument.Object.Move");

			if(wParam == VK_PRIOR)
			{
				strMacro.Append(L"Up");
			}
			else
			{
				strMacro.Append(L"Down");
			}

			strMacro.AppendFormat(L"(%i, 1, %i)", bCtrl ? tomWindow : tomScreen, bShift ? tomExtend : tomMove);

			m_Recorder.RecordLine(strMacro);
			break;

		case VK_END:
		case VK_HOME:
			strMacro.Append(L"ActiveDocument.Object.");

			if(wParam == VK_END)
			{
				strMacro.Append(L"EndKey");
			}
			else
			{
				strMacro.Append(L"HomeKey");
			}

			strMacro.AppendFormat(
				L"(%i, %i)", 
				bCtrl ? tomStory : tomLine, 
				bShift ? tomExtend : tomMove);

			m_Recorder.RecordLine(strMacro);
			break;

		case VK_INSERT:
			// Note that the CTRL completely disables this command.  Also the SHIFT+INSERT
			// actually generates a WM_PASTE message rather than a WM_KEYDOWN
			if(!bCtrl)
			{
				strMacro = L"ActiveDocument.Object.Flags = ActiveDocument.Object.Flags Xor ";
				strMacro.AppendFormat(L"%i", tomSelOvertype);
				m_Recorder.RecordLine(strMacro);
			}
			break;

		default:
			// Note that VK_RETURN and VK_TAB are handled in the WM_CHAR message
			// case rather than in the WM_KEYDOWN case.
			break;
		}
		break;
		}
	default:
		break;
	}
}

template <class Traits_T>
void EditorDocument<Traits_T>::RecordDelete(bool bBackspace /*= false*/, bool bWord /*= false*/)
{
	if(!m_Recorder.IsRecording(GetVsSiteCache()))
	{
		return;
	}

	// If not bBackspace then it's a delete
	// If not bWord then it's a single character
	LastMacro macroType = bBackspace ?
			(bWord ? eLastMacroBackSpaceWord : eLastMacroBackSpaceChar) : 
			(bWord ? eLastMacroDeleteWord : eLastMacroDeleteChar);

	// Get the number of times the macro type calculated above has been recorded already
	// (if any) and then add one to get the current count
	unsigned int iCount = m_Recorder.GetTimesPreviouslyRecorded(macroType) + 1;

	CStringW strMacro;
	strMacro.AppendFormat(
		L"ActiveDocument.Object.Delete(%i, %i)", 
		bWord ? tomWord : tomCharacter, 
		// if this parameter is negative, it indicates a backspace, rather then a delete
		bBackspace ? -1*iCount : iCount);

	m_Recorder.RecordBatchedLine(macroType, strMacro);
}

template <class Traits_T>
void EditorDocument<Traits_T>::RecordMove(
	LastMacro eState,
	LPCWSTR szDirection,
	MoveScope eScope,
	bool bExtend)
{
	CStringW strMacro;
	strMacro.Append(L"ActiveDocument.Object.Move");
	strMacro.Append(szDirection);
	strMacro.AppendFormat(
		L"(%i, %i, %i)", 
		eScope, 
		// Get the number of times this macro type has been recorded already
		// (if any) and then add one to get the current count
		m_Recorder.GetTimesPreviouslyRecorded(eState)+1, 
		bExtend ? tomExtend : tomMove);

	m_Recorder.RecordBatchedLine(eState, strMacro);
}

// Window Proc for the rich edit control.  Necessary to implement macro recording.
template <class Traits_T>
LRESULT CALLBACK EditorDocument<Traits_T>::RichEditWindowProc(
	_In_ HWND hWnd, 
	UINT msg, 
	_In_ WPARAM wParam, 
	_In_ LPARAM lParam)
{
	VSL_STDMETHODTRY{

	// Get the document pointer, which was set by calling SetWindowLong in CreatePaneWindow
	Control::Window window(hWnd);
	EditorDocument* pDocument = reinterpret_cast<EditorDocument*>(window.GetWindowLongPtr(GWLP_USERDATA));

	if(NULL != pDocument)
	{
		pDocument->EnsureNotClosed(); // paranoid, this shouldn't happen since this proc is removed in ClosePane

		if(!pDocument->m_Recorder.IsRecording(pDocument->GetVsSiteCache()))
		{
			return pDocument->GetControl().CallWindowProc(pDocument->m_pWindowProc, msg, wParam, lParam);
		}

		switch(msg)
		{
		case WM_SETCURSOR:
			// Set the cursor to the "No" symbol, to indicate mouse actions will not be recorded, 
			// and suppress the message
			{
			static Traits_T::Cursor noCursor(IDC_NO);
			noCursor.Activate();
			}
			return 0;

		case WM_LBUTTONDOWN:
		case WM_RBUTTONDOWN:
		case WM_MBUTTONDOWN:
		case WM_LBUTTONDBLCLK:
			// The cursor has been set to the "No" symbol, just set the focus, and suppress the message
			pDocument->GetControl().SetFocus();
			return 0;

		default:
			// Need to process the message normally, as well so that user action actually occurs in the 
			// control after recording the user action
			pDocument->RecordKeyStroke(msg, wParam, lParam);
			return pDocument->GetControl().CallWindowProc(pDocument->m_pWindowProc, msg, wParam, lParam);
		}
	}

	}VSL_STDMETHODCATCH()

	VSL_ASSERT(SUCCEEDED(VSL_GET_STDMETHOD_HRESULT()));

	return 0;
}

template <class Traits_T>
IDispatch* EditorDocument<Traits_T>::GetNamedAutomationObject(_In_z_ BSTR bstrName)
{
	const wchar_t szDocumentName[] = L"Document";
	if(bstrName != NULL && bstrName[0] != L'\0')
	{
		// NULL or empty string just means the default object, but if a specific string
		// is specified, then make sure it's the correct one, but don't enforce case
		CHK(0 == ::_wcsicmp(bstrName, szDocumentName), E_INVALIDARG);
	}
	IDispatch* pIDispatch = static_cast<ISingleViewEditor*>(this);
	// Required to AddRef this once before returning it
	pIDispatch->AddRef();
	return pIDispatch;
}

