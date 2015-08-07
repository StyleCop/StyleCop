// EditorCore.inl

/*****************************************************************************
** IVsWindowPane Implementation
*****************************************************************************/

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::CreatePaneWindow(
	_In_ HWND hWndParent,
	_In_ int x,
	_In_ int y,
	_In_ int cx,
	_In_ int cy,
	_Out_ HWND *phWnd)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(phWnd, E_INVALIDARG);

	RECT rect = { x, y, x+cx, y+cy };

	RichEditContainer::Create(hWndParent, rect);

	// Subclass the rich edit control window
	m_pWindowProc = reinterpret_cast<WNDPROC>(GetControl().SetWindowLongPtr(GWLP_WNDPROC, (LONG_PTR)EditorDocument<Traits_T>::RichEditWindowProc));
	GetControl().SetWindowLongPtr(GWLP_USERDATA, (LONG_PTR)this);

	// Finally show the window
	GetControl().ShowWindow(SW_SHOWNORMAL);

	// Setup the selection container for the one selected item
	GetItemsContainer()[0] = GetControl().GetITextDocument();

	// Now fire the selection change event
	FireSelectionChange();

	// Register with the text manager, so find in files works correctly
	RegisterToTextManager();

	*phWnd = GetHWND();

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::GetDefaultSize(_Out_ SIZE *psize)
{
	VSL_STDMETHODTRY{

	VSL_CHECKPOINTER(psize, E_INVALIDARG);

	psize->cx = 50;
	psize->cy = 50;

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}

template <class Traits_T>
STDMETHODIMP EditorDocument<Traits_T>::ClosePane()
{
	if(m_bClosed)
	{
		// recursion guard
		return E_UNEXPECTED;
	}

	VSL_STDMETHODTRY{

	// Put back the original window procedure
	GetControl().SetWindowLongPtr(GWLP_WNDPROC, (LONG_PTR)m_pWindowProc);

	// Destroy the parent window, which will in turn destroy the rich edit window
	Destroy();

	// Notify the persistence base class that the document is closing
	OnDocumentClose();

	GetItemsContainer()[0] = NULL;

	// Stop any macro recording
	m_Recorder.Stop();

	// Unregister with the text manager
	UnregisterFromTextManager();

	m_bClosed = true;

	}VSL_STDMETHODCATCH()

	return VSL_GET_STDMETHOD_HRESULT();
}
