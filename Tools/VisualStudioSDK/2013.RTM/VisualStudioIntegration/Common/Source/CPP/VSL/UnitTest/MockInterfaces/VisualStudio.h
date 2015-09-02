/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#pragma warning(push)
#pragma warning(disable : 4239) // warning C4239: nonstandard extension used : 'argument' : conversion from <struct> to <struct &>

typedef InterfaceImplList<IVsShellNotImpl, IUnknownInterfaceListTerminatorDefault> IVsShellNotImplInterfaceList;

class IVsShellNotImplMock :
	public COMMockBase<IVsShellNotImplInterfaceList, IVsShellNotImplMock>
{
};

// TODO - this isn't testing that IVsShellNotImpl has a virtual destructor correctly
VSL_DEFINE_VIRTUAL_DESTRUCTOR_TEST_HELPER(IVsShellNotImplMock);

class IVsShellNotImplTest :
	public UnitTestBase
{
public:

	IVsShellNotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsShellNotImplMock mock;
		IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();
		IVsShell* pIVsShell = NULL;
		UTCHKEX(pIUnknown->QueryInterface(SID_SVsShell, reinterpret_cast<void**>(&pIVsShell)) == S_OK, _T(""));
		UTCHKEX(mock.GetRefCount() == 1, _T("Check AddRef was called before returning IVsShell"));
		UTCHKEX(pIVsShell != NULL, _T("Check pIVsShell isn't still NULL"));

		// TODO - determine if IntelliSense/Class View APIs be used to autogenerate this 
		// (IVsShellNotImpl itself if possible as well)
		if(pIVsShell != NULL)
		{
			UTCHKEX(pIVsShell->GetPackageEnum(0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->GetProperty(VSSPROPID(), 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->SetProperty(VSSPROPID(), VARIANT()) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->AdviseBroadcastMessages(0, 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->UnadviseBroadcastMessages(VSCOOKIE()) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->AdviseShellPropertyChanges(0, 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->UnadviseShellPropertyChanges(VSCOOKIE()) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->LoadPackage(GUID(), 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->LoadPackageString(GUID(), 0, 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->LoadUILibrary(GUID(), 0, 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->IsPackageInstalled(GUID(), 0) == E_NOTIMPL, _T(""));
			UTCHKEX(pIVsShell->IsPackageLoaded(GUID(), 0) == E_NOTIMPL, _T(""));
		}

		mock.SetRefCount(0);
	}
};


// TODO - create a unit test just for containers

class StaticArrayTest :
	public UnitTestBase
{
public:

	template <class StaticArray_T>
	void VerifyElementValues(const StaticArray_T& rArray)
	{
		// Since StaticArray isn't designed to be robust against overruns
		// we don't test against that here.
		for(StaticArray_T::Type i = 0; i < StaticArray_T::NumberOfElements; ++i)
		{
			// const Type_T& operator[](size_t i) const
			UTCHKEX(rArray[i] == i+1, _T(""));
		}
	}

	StaticArrayTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		// default constructor
		StaticArray<int, 2> defaultArray;
		// Type_T& operator[](size_t i)
		defaultArray[0] = 1;
		defaultArray[1] = 2;

		VerifyElementValues(defaultArray);

		// Don't test copy construction, as it isn't intended to be utilized; however,
		// the copy constructor can't be declared private and still allow initialization 
		// via aggregation.

		// Don't test direct access of the public member, as it isn't intended to be
		// utilized; however, member must be public inorder to allow initialization via
		// aggregation

		StaticArray<int, 3> initializedArray =
		{
			{
				1,
				2,
				3
			}
		};

		VerifyElementValues(initializedArray);

	}
};

typedef InterfaceImplList<IVsUIShellNotImpl, IUnknownInterfaceListTerminatorDefault> IVsUIShellNotImplInterfaceList;

VSL_DECLARE_COM_MOCK(IVsUIShellNotImplMock, IVsUIShellNotImplInterfaceList){};

class IVsUIShellNotImplTest :
	public UnitTestBase
{
public:

	IVsUIShellNotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsUIShellNotImplMock mock;
		IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();
		IVsUIShell* pIVsUIShell = NULL;
		UTCHK(pIUnknown->QueryInterface(__uuidof(IVsUIShell), reinterpret_cast<void**>(&pIVsUIShell)) == S_OK);
		UTCHKEX(mock.GetRefCount() == 1, _T("Check AddRef was called before returning IVsUIShell"));
		UTCHKEX(pIVsUIShell != NULL, _T("Check pIVsUIShell isn't still NULL"));

		if(pIVsUIShell != NULL)
		{
			UTCHK(pIVsUIShell->GetToolWindowEnum(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetDocumentWindowEnum(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->FindToolWindow(
				VSFINDTOOLWIN(),
				GUID(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->CreateToolWindow(
				VSCREATETOOLWIN(),
				DWORD(),
				NULL,
				GUID(),
				GUID(),
				GUID(),
				NULL,
				LPCOLESTR(),
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->CreateDocumentWindow(
				VSCREATEDOCWIN(),
				LPCOLESTR(),
				NULL,
				VSITEMID(),
				NULL,
				NULL,
				GUID(),
				LPCOLESTR(),
				GUID(),
				NULL,
				LPCOLESTR(),
				LPCOLESTR(),
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetErrorInfo(
				HRESULT(),
				LPCOLESTR(),
				DWORD(),
				LPCOLESTR(),
				LPCOLESTR()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->ReportErrorInfo(
				HRESULT()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetDialogOwnerHwnd(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->EnableModeless(
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SaveDocDataToFile(
				VSSAVEFLAGS(),
				NULL,
				LPCOLESTR(),
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetupToolbar(
				HWND(),
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetForegroundWindow() == E_NOTIMPL);

			UTCHK(pIVsUIShell->TranslateAcceleratorAsACmd(
				LPMSG()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->UpdateCommandUI(
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->UpdateDocDataIsDirtyFeedback(
				VSCOOKIE(),
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->RefreshPropertyBrowser(
				DISPID()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetWaitCursor() == E_NOTIMPL);

			UTCHK(pIVsUIShell->PostExecCommand(
				NULL,
				DWORD(),
				DWORD(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->ShowContextMenu(
				DWORD(),
				GUID(),
				LONG(),
				POINTS(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->ShowMessageBox(
				DWORD(),
				GUID(),
				LPOLESTR(),
				LPOLESTR(),
				LPOLESTR(),
				DWORD(),
				OLEMSGBUTTON(),
				OLEMSGDEFBUTTON(),
				OLEMSGICON(),
				BOOL(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetMRUComboText(
				NULL,
				DWORD(),
				LPSTR(),
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetToolbarVisibleInFullScreen(
				NULL,
				DWORD(),
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->FindToolWindowEx(
				VSFINDTOOLWIN(),
				GUID(),
				DWORD(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetAppName(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetVSSysColor(
				VSSYSCOLOR(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->SetMRUComboTextW(
				NULL,
				DWORD(),
				LPWSTR(),
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->PostSetFocusMenuCommand(
				NULL,
				DWORD()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetCurrentBFNavigationItem(
				NULL,
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->AddNewBFNavigationItem(
				NULL,
				BSTR(),
				NULL,
				BOOL()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->OnModeChange(
				DBGMODE()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetErrorInfo(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetOpenFileNameViaDlg(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetSaveFileNameViaDlg(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetDirectoryViaBrowseDlg(
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->CenterDialogOnWindow(
				HWND(),
				HWND()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetPreviousBFNavigationItem(
				NULL,
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetNextBFNavigationItem(
				NULL,
				NULL,
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->GetURLViaDlg(
				LPCOLESTR(),
				LPCOLESTR(),
				LPCOLESTR(),
				NULL) == E_NOTIMPL);

			UTCHK(pIVsUIShell->RemoveAdjacentBFNavigationItem(
				RemoveBFDirection()) == E_NOTIMPL);

			UTCHK(pIVsUIShell->RemoveCurrentNavigationDupes(
				RemoveBFDirection()) == E_NOTIMPL);
		}

		mock.SetRefCount(0);
	}
};

// Test the mock object for IVsOutputWindowPane

typedef InterfaceImplList<IVsOutputWindowPaneNotImpl, IUnknownInterfaceListTerminatorDefault> IVsOutputWindowPaneNotImplInterfaceList;

class IVsOutputWindowPaneNotImplMock :
	public COMMockBase<IVsOutputWindowPaneNotImplInterfaceList, IVsOutputWindowPaneNotImplMock>
{
};

VSL_DEFINE_VIRTUAL_DESTRUCTOR_TEST_HELPER(IVsOutputWindowPaneNotImplMock);

class IVsOutputWindowPaneNotImplTest :
	public UnitTestBase
{
public:

	IVsOutputWindowPaneNotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
        IVsOutputWindowPaneNotImplMock mock;
        {
	        IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();
            CComPtr<IVsOutputWindowPane> srpOutputWindow;
            // Check the implementation of IUnknown.
            UTCHK(SUCCEEDED(pIUnknown->QueryInterface(__uuidof(IVsOutputWindowPane), (void**)&srpOutputWindow)));
            UTCHK(1 == mock.GetRefCount());
            UTCHK(srpOutputWindow);
            if (srpOutputWindow)
            {
                // Now check that every method returns E_NOTIMPL;
                UTCHK(E_NOTIMPL == srpOutputWindow->Activate());
                UTCHK(E_NOTIMPL == srpOutputWindow->Clear());
                UTCHK(E_NOTIMPL == srpOutputWindow->FlushToTaskList());
                UTCHK(E_NOTIMPL == srpOutputWindow->GetName(NULL));
                UTCHK(E_NOTIMPL == srpOutputWindow->Hide());
                UTCHK(E_NOTIMPL == srpOutputWindow->OutputString(NULL));
                UTCHK(E_NOTIMPL == srpOutputWindow->OutputStringThreadSafe(NULL));
                UTCHK(E_NOTIMPL == srpOutputWindow->OutputTaskItemString(NULL, (VSTASKPRIORITY)0, (VSTASKCATEGORY)0, NULL, 0, NULL, 0, NULL));
                UTCHK(E_NOTIMPL == srpOutputWindow->OutputTaskItemStringEx(NULL, (VSTASKPRIORITY)0, (VSTASKCATEGORY)0, NULL, 0, NULL, 0, NULL, NULL));
                UTCHK(E_NOTIMPL == srpOutputWindow->SetName(NULL));
            }
        }
    }
};

typedef InterfaceImplList<IVsWindowFrameNotImpl, IUnknownInterfaceListTerminatorDefault> IVsWindowFrameNotImplInterfaceList;

VSL_DECLARE_COM_MOCK(IVsWindowFrameNotImplMock, IVsWindowFrameNotImplInterfaceList){};

class IVsWindowFrameNotImplTest :
	public UnitTestBase
{
public:

	IVsWindowFrameNotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsWindowFrameNotImplMock mock;
		IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();
		IVsWindowFrame* pIVsWindowFrame = NULL;
		UTCHK(pIUnknown->QueryInterface(__uuidof(IVsWindowFrame), reinterpret_cast<void**>(&pIVsWindowFrame)) == S_OK);
		UTCHKEX(mock.GetRefCount() == 1, _T("Check AddRef was called before returning IVsWindowFrame"));
		UTCHKEX(pIVsWindowFrame != NULL, _T("Check pIVsWindowFrame isn't still NULL"));

		if(pIVsWindowFrame != NULL)
		{
			UTCHK(pIVsWindowFrame->Show() == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->Hide() == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->IsVisible() == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->ShowNoActivate() == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->CloseFrame(FRAMECLOSE()) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->SetFramePos( 
				VSSETFRAMEPOS(),
				GUID_NULL,
				0,
				0,
				0,
				0) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->GetFramePos( 
				NULL,
				NULL,
				NULL,
				NULL,
				NULL,
				NULL) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->GetProperty( 
				VSFPROPID(),
				NULL) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->SetProperty( 
				VSFPROPID(),
				VARIANT()) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->GetGuidProperty( 
				VSFPROPID(),
				NULL) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->SetGuidProperty( 
				VSFPROPID(),
				GUID_NULL) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->QueryViewInterface( 
				GUID_NULL,
				NULL) == E_NOTIMPL);
		    
			UTCHK(pIVsWindowFrame->IsOnScreen( 
				NULL) == E_NOTIMPL);
		}

		mock.SetRefCount(0);
	}
};

typedef InterfaceImplList<IVsWindowFrame2NotImpl, IUnknownInterfaceListTerminatorDefault> IVsWindowFrame2NotImplInterfaceList;
VSL_DECLARE_COM_MOCK(IVsWindowFrame2NotImplMock, IVsWindowFrame2NotImplInterfaceList){};

class IVsWindowFrame2NotImplTest :
	public UnitTestBase
{
public:

	IVsWindowFrame2NotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsWindowFrame2NotImplMock mock;
		IUnknown* pIUnknown = mock.GetIUnknownNoAddRef();
		CComPtr<IVsWindowFrame2> spIVsWindowFrame = NULL;
		UTCHK(pIUnknown->QueryInterface(__uuidof(IVsWindowFrame2), reinterpret_cast<void**>(&spIVsWindowFrame)) == S_OK);
		UTCHKEX(mock.GetRefCount() == 1, _T("Check AddRef was called before returning IVsWindowFrame"));
		UTCHKEX(spIVsWindowFrame != NULL, _T("Check pIVsWindowFrame isn't still NULL"));

		if(spIVsWindowFrame != NULL)
		{
			UTCHK(E_NOTIMPL == spIVsWindowFrame->Advise(NULL, NULL));
			UTCHK(E_NOTIMPL == spIVsWindowFrame->Unadvise(0));
			UTCHK(E_NOTIMPL == spIVsWindowFrame->ActivateOwnerDockedWindow());
		}
	}
};

class IProfferServiceNotImplTest :
	public IProfferServiceNotImpl,
	public UnitTestBase
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IProfferServiceNotImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(E_NOTIMPL == ProfferService(GUID_NULL, NULL, NULL));
		UTCHK(E_NOTIMPL == RevokeService(0));
	}
};

#pragma warning(pop)
