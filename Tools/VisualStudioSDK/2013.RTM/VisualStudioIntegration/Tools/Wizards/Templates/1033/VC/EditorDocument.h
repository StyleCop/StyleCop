// EditorDocument.h

#pragma once

/***************************************************************************

EditorDocument provides the implementation of a single view editor (as opposed to a 
multi-view editor that can display the same file in multiple modes like the HTML editor).

%ProjectName%.pkgdef contains:

[$RootKey$\KeyBindingTables\{%DocumentGuid%}]
@="#1"
"AllowNavKeyBinding"=dword:00000000
"Package"="{%PackageGuid%}"

which is required for some, but not all, of the key bindings, which are located at the bottom of 
%ProjectClass%UI.vsct, to work correctly so that the appropriate command handler below will be
called.

***************************************************************************/

// This is provided as a template parameter to facilitate unit testing
// One traits class is provided rather then multiple template arguments
// so that when an new type is added, it isn't necessary to update all
// instances of the template declaration
class EditorDocumentDefaultTraits
{
public:
	// The rich edit control needs to be contained in another window, as the list view will send 
	// it's notifications to it's parent window; however, if the VS frame window is subclassed, VS
	// may stomp on the window proc we have set, so we have to provide our own parent window
	// for the control.
	typedef Win32ControlContainer<RichEditWin32Control<> > RichEditContainer;
	typedef VSL::Cursor Cursor;
	typedef VSL::Keyboard Keyboard;
	typedef VSL::File File;
};

template <class Traits_T = EditorDocumentDefaultTraits>
class EditorDocument : 
	// Use ATL to take care of common COM infrastructure
	public CComObjectRootEx<CComSingleThreadModel>,
	// IVsWindowPane is required to be a document
	public IVsWindowPaneImpl<EditorDocument<Traits_T> >,
	// IOleCommandTarget is required to be a document that handles commands (as any editor will need to do)
	public IOleCommandTargetImpl<EditorDocument<Traits_T> >,
	// DocumentPersistanceBase provides the persistence related interfaces: IVsPersistDocData, 
	// IVsDocDataFileChangeContro, IVsFileChangeEvents, IPersistFileFormat, and IVsFileBackup.
	public DocumentPersistanceBase<EditorDocument<Traits_T>, typename Traits_T::File>,
	// ISelectionContainer is required for the properties windows to be updated.
	// The document only has one item to display properties for, so ISelectionContainerSingleItemImpl
	// is used rather then ISelectionContainerImpl
	public ISelectionContainerSingleItemImpl<EditorDocument<Traits_T>, ITextDocument>,
	// IVsToolboxUser is required for items be dragged from the toolbox on to the document
	public IVsToolboxUser,
	// IVsStatusbarUser is required to update the line and character position on the status bar,
	// as well as the insertion (INS at the right most end of the status bar) state.
	public IVsStatusbarUser,
	// Custom automation interface used with macro recording and playback
	public IDispatchImpl<ISingleViewEditor, &__uuidof(ISingleViewEditor), &LIBID_%ProjectClass%Lib>,
	// IExtensibleObject or IVsExtensibleObject is required to be an automation object
	// IExtensibleObject is newer and preferred.
	public IExtensibleObjectImpl<EditorDocument<Traits_T> >,
	// IVsFindTarget, IVsTextImage, and IVsTextSpanSet are required for find and replace to work correctly
	public IVsFindTargetImpl<EditorDocument<Traits_T>, TRUE>,
	public IVsTextImageImpl<>,
	public IVsTextSpanSetImpl,
	// IVsTextView, IVsTextViewEvents, IVsCodeWindow, IVsTextLines along with the a connection point 
	// for IVsTextViewEvents, are required so that double-clicking on results of a find in files in the 
	// output window will correctly navigate to the location in the document.  That is the only
	// scenario these interfaces are required for.
	public SingleViewFindInFilesOutputWindowIntegrationImpl<EditorDocument<Traits_T> >,
	public ATL::IConnectionPointContainerImpl<EditorDocument<Traits_T> >,
	// This is required in addition to IConnectionPointContainer for the connection map to compile properly
	// This interface is not included in the interface map though, so it can not be QI'ed for.
	public ATL::IConnectionPointImpl<EditorDocument<Traits_T>, &IID_IVsTextViewEvents>,
	// The container for the rich edit control is the actual window associated with IVsWindowPane
	// rather then the rich edit control, as the the parent window of IVsWindowPane is owned by
	// the Visual Studio IDE and can not be used as the parent window of the rich edit control,
	// it it can not be reliably sub-classed (VS doesn't guarantee it will not overwrite the
	// window procedure).
	public Traits_T::RichEditContainer
{

// COM objects typically should not be cloned, and this prevents cloning by declaring the 
// copy constructor and assignment operator private (NOTE:  this macro includes the declaration of
// a private section, so everything following this macro and preceding a public or protected 
// section will be private).
VSL_DECLARE_NOT_COPYABLE(EditorDocument)

public:

	typedef typename Traits_T::File File;

// Provides a portion of the implementation of IUnknown, in particular the list of interfaces
// the EditorDocument object will support via QueryInterface
BEGIN_COM_MAP(EditorDocument)
	COM_INTERFACE_ENTRY(IVsWindowPane)    
	COM_INTERFACE_ENTRY(ISelectionContainer)
	COM_INTERFACE_ENTRY(IOleCommandTarget)
	COM_INTERFACE_ENTRY(IPersistFileFormat)
	COM_INTERFACE_ENTRY(IPersist)
	COM_INTERFACE_ENTRY(IVsPersistDocData)
	COM_INTERFACE_ENTRY(IVsFileChangeEvents)
	COM_INTERFACE_ENTRY(IVsDocDataFileChangeControl)
	COM_INTERFACE_ENTRY(IVsFileBackup)
	COM_INTERFACE_ENTRY(IVsToolboxUser)
	COM_INTERFACE_ENTRY(IVsStatusbarUser)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISingleViewEditor)
	COM_INTERFACE_ENTRY(IExtensibleObject)
	COM_INTERFACE_ENTRY(IVsFindTarget)
	COM_INTERFACE_ENTRY(IVsTextImage)
	COM_INTERFACE_ENTRY(IVsTextSpanSet)
	COM_INTERFACE_ENTRY(IVsTextBuffer)
	COM_INTERFACE_ENTRY(IVsTextView)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	// IConnectionPoint is purposefully omitted
	COM_INTERFACE_ENTRY(IVsTextViewEvents)
	COM_INTERFACE_ENTRY(IVsCodeWindow)
	COM_INTERFACE_ENTRY(IVsTextLines)
END_COM_MAP()

// Defines the command handlers. IOleCommandTargetImpl will use these handlers to implement
// IOleCommandTarget.
VSL_BEGIN_COMMAND_MAP()
	// Every command is identified by the shell using a GUID/DWORD pair, so every the definition of
	// commands must contain this information.

	// The following command map entries define a GUID/DWORD pair to identify the command and a 
	// callback for the command execution and status queries.
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidCopy, &OnQueryCopy, &OnCopy)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidCut, &OnQueryCut, &OnCut)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidDelete, NULL, &OnDelete)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidPaste, &OnQueryPaste, &OnPaste)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidBold, &OnQueryBold, &OnBold)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidItalic, &OnQueryItalic, &OnItalic)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidUnderline, &OnQueryUnderline, &OnUnderline)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidJustifyLeft, &OnQueryJustifyLeft, &OnJustifyLeft)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidJustifyRight, &OnQueryJustifyRight, &OnJustifyRight)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidJustifyCenter, &OnQueryJustifyCenter, &OnJustifyCenter)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidFontNameGetList, &OnQueryFontNameGetList, &OnFontNameGetList)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidFontName, &OnQueryFontName, &OnFontName)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidFontSizeGetList, &OnQueryFontSizeGetList, &OnFontSizeGetList)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidFontSize, &OnQueryFontSize, &OnFontSize)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet97, cmdidPasteNextTBXCBItem, &OnQueryPasteNextTBXCBItem, &OnPasteNextTBXCBItem)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet2K, ECMD_BULLETEDLIST, &OnQueryBulletedList, &OnBulletedList)
	VSL_COMMAND_MAP_ENTRY(CMDSETID_StandardCommandSet2K, ECMD_INSERT, &OnQueryInsert, &OnInsert)
	VSL_COMMAND_MAP_ENTRY(CLSID_%ProjectClass%CmdSet, commandIDStrike, &OnQueryStrikeOut, &OnStrikeOut)

// Terminate the definition of the command map
VSL_END_VSCOMMAND_MAP()

VSL_BEGIN_MSG_MAP(EditorDocument)
	// Whenever the content changes, need to check and see if the file can be edited,
	// if not then the changes will be rejected.
	COMMAND_HANDLER(RichEditContainer::iContainedControlID, EN_CHANGE, OnContentChange)
	// Whenever the selection changes, need to update the Visual Studio UI (i.e. status bar, menus, 
	// and toolbars).
	NOTIFY_HANDLER(RichEditContainer::iContainedControlID, EN_SELCHANGE, OnSelectionChange)
	// On this event the context menu will be shown if needed, and some keyboard commands will be
	// dealt with.
	NOTIFY_HANDLER(RichEditContainer::iContainedControlID, EN_MSGFILTER, OnUserInteractionEvent)
	MESSAGE_HANDLER(WM_TIMER, OnTimer)
	MESSAGE_HANDLER(WM_SETFOCUS, OnSetFocus)
	// Let the rich edit container process all other messages
	CHAIN_MSG_MAP(RichEditContainer)
VSL_END_MSG_MAP()

// This is necessary to implement the connection point for IVsTextViewEvents
// See comment above SingleViewFindInFilesOutputWindowIntegrationImpl
BEGIN_CONNECTION_POINT_MAP(EditorDocument)
	CONNECTION_POINT_ENTRY(IID_IVsTextViewEvents)
END_CONNECTION_POINT_MAP()

// IVsWindowPane methods overridden or not provided by IVsWindowPaneImpl

	STDMETHOD(CreatePaneWindow)(
		/*[in] */ _In_ HWND hwndParent,
		/*[in] */ _In_ int x,
		/*[in] */ _In_ int y,
		/*[in] */ _In_ int cx,
		/*[in] */ _In_ int cy,
		/*[out]*/ _Out_ HWND *hwnd);
	STDMETHOD(GetDefaultSize)(
		/*[out]*/ _Out_ SIZE *psize);
	STDMETHOD(ClosePane)();

// IVsToolboxUser method

	STDMETHOD(IsSupported)(/*[in] */ _In_ IDataObject* pDO);
	STDMETHOD(ItemPicked)(/*[in] */ _In_ IDataObject* pDO);

// ISingleViewEditor - this is the object model exposed by the editor in order to
// facilitate macro recording.

	STDMETHOD(get_DTE)(/* [out] */ _Deref_out_ _DTE** ppDTE);
	STDMETHOD(get_Parent)(/* [out] */ _Deref_out_ _DTE** ppDTE);
	STDMETHOD(get_DefaultTabStop)(/* [out] */ _Out_ float* pdVal);
	STDMETHOD(put_DefaultTabStop)(/* [in] */ float dVal);
	STDMETHOD(get_Range)(/* [out] */ _Deref_out_ /*ITextRange*/IDispatch** ppRange);
	STDMETHOD(get_Selection)(/* [out] */ _Deref_out_ /*ITextSelection*/IDispatch** ppSelection);
	STDMETHOD(get_Flags)(/* [out] */ _Out_ long* plFlags);
	STDMETHOD(put_Flags)(/* [in] */ long lFlags);
	STDMETHOD(FindText)(/* [in] */ _In_ BSTR pStr);
	STDMETHOD(SetText)(/* [in] */ _In_ BSTR pStr);
	STDMETHOD(TypeText)(/* [in] */ _In_ BSTR pStr);
	STDMETHOD(Cut)();
	STDMETHOD(Copy)();
	STDMETHOD(Paste)();
	STDMETHOD(Delete)(
		/* [in] */ long lUnit,
		/* [in] */ long cUnit);
	STDMETHOD(MoveUp)(
		/* [in] */ long lUnit,
		/* [in] */ long cUnit,
		/* [in] */ long lExtend);
	STDMETHOD(MoveDown)(
		/* [in] */ long lUnit,
		/* [in] */ long cUnit,
		/* [in] */ long lExtend);
	STDMETHOD(MoveLeft)(
		/* [in] */ long lUnit,
		/* [in] */ long cUnit,
		/* [in] */ long lExtend);
	STDMETHOD(MoveRight)(
		/* [in] */ long lUnit,
		/* [in] */ long cUnit,
		/* [in] */ long lExtend);
	STDMETHOD(EndKey)(
		/* [in] */ long lUnit,
		/* [in] */ long lExtend);
	STDMETHOD(HomeKey)(
		/* [in] */ long lUnit,
		/* [in] */ long lExtend);
					
// IVsStatusbarUser methods

	STDMETHOD(SetInfo)();

// IVsFindTarget methods

	STDMETHOD(GetProperty)( 
		/* [in] */ VSFTPROPID propid,
		/* [out]*/ _Out_ VARIANT* pvar);
	STDMETHOD(NavigateTo)(
		/* [in] */ const TextSpan* pts);
	STDMETHOD(GetCurrentSpan)(
		/* [out]*/ _Out_ TextSpan* pts);

// IVsTextImage methods

	 STDMETHOD(GetLineSize)( 
		/* [retval][out] */ _Out_ LONG* pcLines); 
	 STDMETHOD(Replace)( 
		/* [in] */ DWORD dwFlags,
		/* [in] */ const TextSpan* pts,
		/* [in] */ LONG cch,
		/* [size_is][in] */ LPCOLESTR pchText,
		/* [retval][out] */ _Out_ TextSpan* ptsChanged); 
	 STDMETHOD(GetSpanLength)( 
		/* [in] */ const TextSpan* pts,
		/* [retval][out] */ _Out_ LONG* pcch); 
	 STDMETHOD(GetLineLength)( 
		/* [in] */ LONG iLine,
		/* [retval][out] */ _Out_ LONG* piLength); 
	 STDMETHOD(GetLine)( 
		/* [in] */ DWORD grfGet,
		/* [in] */ LONG iLine,
		/* [in] */ LONG iStartIndex,
		/* [in] */ LONG iEndIndex,
		/* [retval][out] */ _Out_ LINEDATAEX* pLineData); 

// IVsTextLines methods not provided by SingleViewFindInFilesOutputWindowIntegrationImpl

	STDMETHOD(GetLengthOfLine)(
        /* [in] */ long iLine,
        /* [out] */ _Out_ long *piLength);
	STDMETHOD(GetLastLineIndex)(
        /* [out] */ _Out_ long *piLine,
        /* [out] */ _Out_ long *piIndex);

// IVsTextView methods not provided by SingleViewFindInFilesOutputWindowIntegrationImpl

	STDMETHOD(SetSelection)(
        /* [in] */ long iAnchorLine,
        /* [in] */ ViewCol iAnchorCol,
        /* [in] */ long iEndLine,
        /* [in] */ ViewCol iEndCol);

// VSL base class statically bound call back methods

	// Called by IExtensibleObjectImpl::GetAutomationObject
	IDispatch* GetNamedAutomationObject(_In_z_ BSTR bstrName);

	// Called by VSL::DocumentPersistanceBase::InitNew and VSL::DocumentPersistanceBase::Save
	bool IsValidFormat(DWORD dwFormatIndex);

	// Called by VSL::DocumentPersistanceBase::FilesChanged
	void OnFileChangedSetTimer();

	// Called by VSL::DocumentPersistanceBase::GetClassID, which is also called by 
	// VSL::DocumentPersistanceBase::GetGuidEditorType)
	const GUID& GetEditorTypeGuid() const;

	// Called by VSL::DocumentPersistanceBase::GetFormatList
	void GetFormatListString(ATL::CStringW& rstrFormatList);

	// Called indirectly by VSL::DocumentPersistanceBase::Load and VSL::DocumentPersistanceBase::Save
	void PostSetDirty();

	// Called indirectly by VSL::DocumentPersistanceBase::FilesChanged, 
	// VSL::DocumentPersistanceBase::IgnoreFileChanges, VSL::DocumentPersistanceBase::Load, and 
	// VSL::DocumentPersistanceBase::Save
	void PostSetReadOnly();

	// FUTURE - 3/17/2006 - could move the 2 following methods on to the Rich Edit control in VSL

	// Called by the IPersistFileFormat::Load implementation on DocumentPersistanceBase
	HRESULT ReadData(File& rFile, BOOL bInsert, DWORD& rdwFormatIndex) throw();

	// Called indirectly by IPersistFileFormat::Save and IVsFileBackup::BackupFile implementations 
	// on DocumentPersistanceBase
	void WriteData(File& rFile, DWORD /*dwFormatIndex*/);

	// Called by VSL::IVsFindTargetImpl::GetCapabilities and 
	// VSL::IVsFindTargetImpl::GetSearchImage
	DWORD GetCapabilityOptions();

protected:

	typedef typename Traits_T::RichEditContainer RichEditContainer;
	typedef typename Traits_T::RichEditContainer::Control Control;
	typedef typename Traits_T::Keyboard Keyboard;

	typedef typename IVsWindowPaneImpl<EditorDocument<Traits_T> >::VsSiteCache VsSiteCache;

	typedef EditorDocument<Traits_T> This;

	EditorDocument():
		m_pWindowProc(NULL),
		m_bClosed(false)
	{
	}

	~EditorDocument()
	{
		VSL_ASSERT(m_bClosed);
		if(!m_bClosed)
		{
			// Paranoid clean-up.  Ignore return value, nothing to do if this fails,
			// and execution should not have arrived here anyway.
			ClosePane();
		}
	}

	// Called by the Rich Edit control during the processing of EM_STREAMOUT and EM_STREAMIN
	template <bool bRead_T>
	static DWORD CALLBACK EditStreamCallback(
		_In_ DWORD_PTR dwpFile, 
		_Inout_bytecap_(iBufferByteSize) LPBYTE pBuffer, 
		LONG iBufferByteSize, 
		_Out_ LONG* piBytesWritten);

	// Window Proc for the rich edit control.  Necessary to implement macro recording.
	static LRESULT CALLBACK RichEditWindowProc(
		_In_ HWND hWnd, 
		UINT msg, 
		_In_ WPARAM wParam, 
		_In_ LPARAM lParam);

#pragma warning(push)
#pragma warning(disable : 4480) // // warning C4480: nonstandard extension used: specifying underlying type for enum
	enum TimerID : WPARAM
	{
		// ID of timer message sent from OnFileChangedSetTimer
		WFILECHANGEDTIMERID = 1,
		// ID of timer message sent from OnSetFocus
		WDELAYSTATUSBARUPDATETIMERID = 2,
	};
#pragma warning(pop)

private:

// Windows message handlers

	LRESULT OnContentChange(WORD /*iCommand*/, WORD /*iId*/, _In_ HWND hWindow, BOOL& /*bHandled*/);
	LRESULT OnSelectionChange(int /*wParam*/, _In_ LPNMHDR /*pHeader*/, BOOL& /*bHandled*/);
	LRESULT OnUserInteractionEvent(int /*wParam*/, _In_ LPNMHDR pHeader, BOOL& /*bHandled*/);
	LRESULT OnTimer(UINT /*uMsg*/, _In_ WPARAM wParam, _In_ LPARAM /*lParam*/, BOOL& /*bHandled*/);
	LRESULT OnSetFocus(UINT /*uMsg*/, _In_ WPARAM wParam, _In_ LPARAM /*lParam*/, BOOL& bHandled);

// Visual Studio command handlers

	void OnCopy(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryCopy(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnCut(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryCut(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnDelete(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnPaste(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryPaste(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnBold(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryBold(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnItalic(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryItalic(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnUnderline(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryUnderline(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnJustifyLeft(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryJustifyLeft(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnJustifyRight(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryJustifyRight(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnJustifyCenter(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryJustifyCenter(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnFontNameGetList(_In_ CommandHandler* /*pSender*/, DWORD flags, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* pOut);
	void OnQueryFontNameGetList(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnFontName(_In_ CommandHandler* /*pSender*/, DWORD flags, _In_ VARIANT* pIn, _Out_ VARIANT* pOut);
	void OnQueryFontName(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnFontSizeGetList(_In_ CommandHandler* /*pSender*/, DWORD flags, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* pOut);
	void OnQueryFontSizeGetList(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnFontSize(_In_ CommandHandler* /*pSender*/, DWORD flags, _In_ VARIANT* pIn, _Out_ VARIANT* pOut);
	void OnQueryFontSize(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnPasteNextTBXCBItem(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryPasteNextTBXCBItem(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnBulletedList(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryBulletedList(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnInsert(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryInsert(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);
	void OnStrikeOut(_In_ CommandHandler* /*pSender*/, DWORD /*flags*/, _In_ VARIANT* /*pIn*/, _Out_ VARIANT* /*pOut*/);
	void OnQueryStrikeOut(const CommandHandler& /*rSender*/, _Inout_ OLECMD* pOleCmd, _Inout_ OLECMDTEXT* /*pOleText*/);

// Rich Edit object model helper methods

	void GetTextSelection(CComPtr<ITextSelection>& rspITextSelection)
	{
		EnsureNotClosed();
		ITextDocument* pdoc = GetControl().GetITextDocument();
		CHKPTR(pdoc, E_FAIL);
		CHKHR(pdoc->GetSelection(&rspITextSelection));
		CHKPTR(rspITextSelection.p, E_FAIL);
	}

	void GetTextRange(CComPtr<ITextRange>& rspITextRange)
	{
		EnsureNotClosed();
		CHKHR(GetControl().GetITextDocument()->Range(0, tomForward, &rspITextRange));
		CHKPTR(rspITextRange.p, E_FAIL);
	}

	void GetTextFont(CComPtr<ITextFont>& rspITextFont)
	{
		CComPtr<ITextSelection>	spITextSelection;
		GetTextSelection(spITextSelection);
		CHKHR(spITextSelection->GetFont(&rspITextFont));
	}

	void GetTextPara(CComPtr<ITextPara>& rspITextPara)
	{
		CComPtr<ITextSelection>	spITextSelection;
		GetTextSelection(spITextSelection);
		CHKHR(spITextSelection->GetPara(&rspITextPara));
	}

	// Helper function to obtain the ITextSelection flags
	long GetTextSelectionFlags();

// Macro recording helper methods

	// Last command type sent to the macro recorder. Note that there are more commands
	// recorded than is implied by this list.
	enum LastMacro
	{
		eLastMacroNone = 0,
		eLastMacroText,
		eLastMacroDownArrowLine,
		eLastMacroDownArrowLineSel,
		eLastMacroDownArrowPara,
		eLastMacroDownArrowParaSel,
		eLastMacroUpArrowLine,
		eLastMacroUpArrowLineSel,
		eLastMacroUpArrowPara,
		eLastMacroUpArrowParaSel,
		eLastMacroLeftArrowChar,
		eLastMacroLeftArrowCharSel,
		eLastMacroLeftArrowWord,
		eLastMacroLeftArrowWordSel,
		eLastMacroRightArrowChar,
		eLastMacroRightArrowCharSel,
		eLastMacroRightArrowWord,
		eLastMacroRightArrowWordSel,
		eLastMacroDeleteChar,
		eLastMacroDeleteWord,
		eLastMacroBackSpaceChar,
		eLastMacroBackSpaceWord
	};

	void RecordCommand(const wchar_t* szCommand);

	// Member functions used to interface with the shell macro recording service.
	// Note that although macro recording may fail we do not return any errors.
	void RecordKeyStroke(UINT msg, _In_ WPARAM wParam, _In_ LPARAM lParam);

	// This function outputs a line to the macro recorder in response to a
	// delete or backspace key.
	void RecordDelete(bool bBackspace = false, bool bWord = false);

	// This function outputs a line to the macro recorder in response to an
	// Up, Down, Left or Right Arrow.

	enum MoveScope
	{
		Character = tomCharacter,
		Word = tomWord,
		Line = tomLine,
		Paragraph = tomParagraph
	};

	void RecordMove(LastMacro eState, LPCWSTR szDirection, MoveScope eScope, bool bExtend);

// Find and Replace helper methods

	// IVsFindTarget helper to get selection string if it is only single line
	void GetInitialPattern(_Deref_out_z_ BSTR *pbstrSelection);

// Format command handler helper methods

	// Function to obtain and set Character and paragraph properties.
	DWORD GetFontFormatState(DWORD dwEffect);
	void SetFontFormatState(DWORD dwEffect);
	DWORD QueryParagraphAlignmentState(long lState);
	DWORD GetBulletState();
	void SetParagraphAlignment(long iAlignment);
	void ToggleBulleted();

// Font command handler helper methods

	typedef std::list<BSTR> FontNameList;

	// OleCommandTarget Helper functions for selecting font names and sizes.
	void GetFontName(_Out_ VARIANT *pvarOut);
	void GetFontSize(_Out_ VARIANT *pvarOut);
	void SetFontName(_In_ VARIANT *pvarNew);
	void SetFontSize(_In_ VARIANT *pvarNew);

// Helper function for query status for command cmdidPasteNextTBXCBItem

	bool CanCycleClipboard();
	void PasteClipboardObject();

// IVsToolboxUser helper

	void IVsToolboxUserHelper(_In_ IDataObject* pDataObject, ATL::CComVariant& vt);

// Status bar helper functions

	void StatusBarUpdatePos(_In_ IVsStatusbar* pIVsStatusBar = NULL);
	void StatusBarUpdateInsMode(_In_ IVsStatusbar* pIVsStatusBar = NULL);

// Miscellaneous helper methods

	// Selection helpers
	bool IsSelectionEmpty();

	// Helper function to checkout file if necessary.
	bool ShouldDiscardChange();

	// Calls IVsUIShell method to tell the environment to update the state of 
	// the command bars (menus and toolbars).
	void UpdateVSCommandUI();

	void EnsureNotClosed()
	{
		CHK(!m_bClosed, E_UNEXPECTED);
	}

// Data members

	// Simplifies macro recording
	VsMacroRecorder<&CLSID_%ProjectClass%EditorDocument, LastMacro, eLastMacroNone> m_Recorder;

	// Window procedure pointer for the window containing the rich edit control
	WNDPROC m_pWindowProc;

	// Buffer for text input during macro recording
	CStringW m_strTextToRecord;

	// IVsWindowPane Data
	bool m_bClosed;
};
