/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include "stdafx.h"

#include "VSLWindows.h"
#include "WindowFrameEventSinkTest.h"

// Disable these warnings inorder to test the failure runtime failure handling
#pragma warning(disable : 6309) // Argument '1' is null: this does not adhere to function specification of
#pragma warning(disable : 6387) // 'argument 1' might be '0': this does not adhere to the specification for the function

using namespace VSL;

// NOTE - ListViewWin32Control and Win32ControlContainer are unit tested in the course of unit testing the Tool Window reference sample.
// NOTE - RichEditWin32Control and Win32ControlContainer are unit tested in the course of unit testing the Single View Editor reference sample.

VSL_DEFINE_SERVICE_MOCK(IVsUIShellServiceMock, IVsUIShellMockImpl);
VSL_DEFINE_SERVICE_MOCK(IVsShellServiceMock, IVsShellNotImpl);

typedef ServiceList<IVsShellServiceMock, ServiceList<IVsUIShellServiceMock, ServiceListTerminator> > PackageIServiceProviderServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<PackageIServiceProviderServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > PackageIServiceProviderInterfaceList;

VSL_DECLARE_COM_MOCK(PackageIServiceProviderMock, PackageIServiceProviderInterfaceList){};

class TestToolWindow :
	public ToolWindowBase<TestToolWindow, VsSiteCacheLocal, VsSiteCacheLocal>,
	public MockBase
{
public:

	typedef void (TestToolWindow::*CalledMethod)();

private:

public:

	bool HasIVsWindowFrame() const
	{
		return (GetIVsWindowFrame() != NULL);
	}

	TestToolWindow(const PackageVsSiteCache& rPackageVsSiteCache):
		ToolWindowBase(rPackageVsSiteCache)
	{
	}

	VSCREATETOOLWIN GetCreationFlags() const
	{
		return CTW_fInitNew;
	}

	REFCLSID GetToolWindowGuid() const
	{
		return GUID_NULL;
	}

	const wchar_t* const GetCaption() const
	{
		return L"";
	}

	void PreCreate()
	{
		Called<CalledMethod, &TestToolWindow::PreCreate>(true);
	}

	void PostCreate()
	{
		Called<CalledMethod, &TestToolWindow::PostCreate>(true);
	}

	void PreShowActivate()
	{
		Called<CalledMethod, &TestToolWindow::PreShowActivate>(true);
	}

	void PreShowNoActivate()
	{
		Called<CalledMethod, &TestToolWindow::PreShowNoActivate>(true);
	}

	void PreShow(bool bActivate)
	{
		bActivate ? PreShowActivate() : PreShowNoActivate();
	}

	void PostShowActivate()
	{
		Called<CalledMethod, &TestToolWindow::PostShowActivate>(true);
	}

	void PostShowNoActivate()
	{
		Called<CalledMethod, &TestToolWindow::PostShowNoActivate>(true);
	}

	void PostShow(bool bActivate)
	{
		bActivate ? PostShowActivate() : PostShowNoActivate();
	}
};

class TestToolWindow2Controls
{
public:
class ControlViewObject { enum { ViewObject	}; };

class ControlViewCLSID { enum { ViewCLSID }; };
};

template <class Control_T>
class TestToolWindow2 :
	public ToolWindowBase<TestToolWindow2<Control_T>, VsSiteCacheLocal, VsSiteCacheLocal>
{
public:

	bool HasIVsWindowFrame() const
	{
		return (GetIVsWindowFrame() != NULL);
	}

	static IVsUIShellMockImpl::CreateToolWindowValidValues& GetValidValues()
	{
	__if_exists(Control_T::ViewCLSID)
	{
	}
		static BOOL fDefaultPosition = FALSE;
		static IVsWindowFrame* pWindowFrame = NULL;
		static IVsUIShellMockImpl::CreateToolWindowValidValues values =
		{
			CTW_fInitNew, // VSCREATETOOLWIN grfCTW;
			1, // DWORD dwToolWindowId;

			__if_exists(Control_T::ViewObject)
			{
			reinterpret_cast<IUnknown*>(1), // IUnknown* punkTool;
			}
			__if_not_exists(Control_T::ViewObject)
			{
			NULL, // IUnknown* punkTool;
			}

			__if_exists(Control_T::ViewCLSID)
			{
			__uuidof(IUnknown), // REFCLSID rclsidTool;
			}
			__if_not_exists(Control_T::ViewCLSID)
			{
			GUID_NULL, // REFCLSID rclsidTool;
			}

			__uuidof(IUnknown), // REFGUID rguidPersistenceSlot;
			GUID_NULL, // REFGUID rguidAutoActivate;
			reinterpret_cast<IServiceProvider*>(1), // IServiceProvider* pSP;
			L"", // LPCOLESTR pszCaption;
			&fDefaultPosition, // BOOL* pfDefaultPosition;
			&pWindowFrame, // IVsWindowFrame** ppWindowFrame;
			S_OK // HRESULT hr;
		};
		return values;
	}

	TestToolWindow2(const PackageVsSiteCache& rPackageVsSiteCache):
		ToolWindowBase(rPackageVsSiteCache)
	{
	}

	VSCREATETOOLWIN GetCreationFlags() const
	{
		return GetValidValues().grfCTW;
	}

	REFCLSID GetToolWindowGuid() const
	{
		return GetValidValues().rguidPersistenceSlot;
	}

	const wchar_t* const GetCaption() const
	{
		return GetValidValues().pszCaption;
	}

	DWORD GetInstanceID() const 
	{
		return GetValidValues().dwToolWindowId;
	}

	__if_exists(Control_T::ViewObject)
	{

	IUnknown* GetViewObject() const
	{
		return GetValidValues().punkTool;
	}

	}

	__if_exists(Control_T::ViewCLSID)
	{

	REFCLSID GetLocalRegistryCLSIDViewObject() const
	{
		return GetValidValues().rclsidTool;
	}

	}

	IServiceProvider* GetToolWindowServiceProvider() const
	{
		return GetValidValues().pSP;
	}
};

class VsServiceProvider
{
public:
	static IServiceProvider* GetServiceProvider()
	{
		static PackageIServiceProviderMock packageIServiceProviderMock;
		static CComQIPtr<IServiceProvider> spIServiceProvider = packageIServiceProviderMock.GetIUnknownNoAddRef();
		static CComPtr<IVsShell> spIVsShell;
		if(spIVsShell == NULL)
		{
			spIServiceProvider->QueryService(SID_SVsShell, &spIVsShell);
		}
		static CComPtr<IVsUIShell> spIVsUIShell;
		if(spIVsUIShell == NULL)
		{
			spIServiceProvider->QueryService(SID_SVsUIShell, &spIVsUIShell);
		}
		return spIServiceProvider;
	}
};

typedef InterfaceImplList<IVsWindowFrameMockImpl, IUnknownInterfaceListTerminator<> > IVsWindowFrameInterfaceList;

VSL_DECLARE_COM_MOCK(IVsWindowFrameMock, IVsWindowFrameInterfaceList){};

class ToolWindowBaseTest :
	public UnitTestBase
{
private:

	template <class ToolWindow_T>
	void CheckCreated(const ToolWindow_T& testToolWindow, const VsSiteCacheLocal& siteCache, bool bCreated = false)
	{
		UTCHK(testToolWindow.HasBeenCreated() == bCreated);
		// Should have the same site cache that was passed in
		const VsSiteCacheLocal& rSiteCache = testToolWindow.GetPackageVsSiteCache();
		UTCHK(&rSiteCache == &siteCache);
		UTCHK((testToolWindow.GetVsSiteCache().GetSite() != NULL) == bCreated);
		UTCHK(testToolWindow.HasIVsWindowFrame() == bCreated);
	}

	void CheckCreate(int iPreCreateNTimes = 0, int iPostCreateNTimes = 0)
	{
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PreCreate>(iPreCreateNTimes)));
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PostCreate>(iPostCreateNTimes)));
	}

	void CheckShow(int iActivateNTimes = 0, int iNoActivateNTimes = 0)
	{
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PreShowActivate>(iActivateNTimes)));
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PostShowActivate>(iActivateNTimes)));
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PreShowNoActivate>(iNoActivateNTimes)));
		UTCHK((TestToolWindow::WasMethodCalled<TestToolWindow::CalledMethod, &TestToolWindow::PostShowNoActivate>(iNoActivateNTimes)));
	}

	void TestCreateAndShowActivate(TestToolWindow& testToolWindow)
	{
		testToolWindow.CreateAndShow(true);
		CheckShow(true);
		UTCHK(testToolWindow.HasBeenCreated() == true);
	}

	void TestCreateAndShowNoActivate(TestToolWindow& testToolWindow)
	{
		testToolWindow.CreateAndShow(false);
		CheckShow(false, true);
		UTCHK(testToolWindow.HasBeenCreated() == true);
	}

	void CheckShowAlreadyCreated(
		TestToolWindow& testToolWindow, 
		const VsSiteCacheLocal& siteCache, 
		bool bActivate = false, 
		bool bNoActivate = false)
	{
		CheckCreate();
		CheckCreated(testToolWindow, siteCache, true);
		CheckShow(bActivate, bNoActivate);
	}

	void SetCreateToolWindowValidValues(const TestToolWindow& testToolWindow, IVsWindowFrame** ppWindowFrame, HRESULT retValue = S_OK)
	{
		static BOOL fDefaultPosition = TRUE;
		CREATEVV(IVsUIShell, CreateToolWindow, values)
		{
			testToolWindow.GetCreationFlags(), // VSCREATETOOLWIN grfCTW;
			0, // DWORD dwToolWindowId;
			NULL, // IUnknown* punkTool;
			GUID_NULL, // REFCLSID rclsidTool;
			testToolWindow.GetToolWindowGuid(), // REFGUID rguidPersistenceSlot;
			GUID_NULL, // REFGUID rguidAutoActivate;
			NULL, // IServiceProvider* pSP;
			testToolWindow.GetCaption(), // LPCOLESTR pszCaption;
			&fDefaultPosition, // BOOL* pfDefaultPosition;
			ppWindowFrame, // IVsWindowFrame** ppWindowFrame;
			retValue // HRESULT hr;
		};

		PUSHVV(values);
	}

public:
	ToolWindowBaseTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		// This need to be declared before testToolWindow, so it will get destroyed after,
		// so that testToolWindow will have the chance to release it before it is destroyed.
		IVsWindowFrameMock mockIVsWindowFrame;
		CComQIPtr<IVsWindowFrame> spIVsWindowFrame = mockIVsWindowFrame.GetIUnknownNoAddRef();

		// Create the tool window with an uninitialized site cache
		VsSiteCacheLocal siteCache;

		SETVV1(IVsWindowFrame, ShowNoActivate, S_OK);
		SETVV1(IVsWindowFrame, Show, S_OK);

		CComVariant varServiceProvider(VsServiceProvider::GetServiceProvider());
		SETVV3(IVsWindowFrame, GetProperty, VSFPROPID_SPFrame, &varServiceProvider, S_OK);

		{
		TestToolWindow testToolWindow(siteCache);
		CheckCreated(testToolWindow, siteCache);

		// Initialize the site cache
		siteCache.SetSite(VsServiceProvider::GetServiceProvider());
		CheckCreated(testToolWindow, siteCache);
		UTCHK(testToolWindow.GetPackageVsSiteCache().GetSite() != NULL);

		// Fail the Create method and Show calls.
		IVsWindowFrame* pWindowFrame = NULL;
		SetCreateToolWindowValidValues(testToolWindow, &pWindowFrame, E_FAIL);

		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		testToolWindow.Create();

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_FAIL);
		CheckCreate(true);
		CheckCreated(testToolWindow, siteCache);
		CheckShow();

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		testToolWindow.Show(true);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
		CheckCreate();
		CheckCreated(testToolWindow, siteCache);
		CheckShow();

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		testToolWindow.Show(false);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
		CheckCreate();
		CheckCreated(testToolWindow, siteCache);
		CheckShow();

		// Have CreateToolWindow pass so that Create will not throw.
		SetCreateToolWindowValidValues(testToolWindow, &(spIVsWindowFrame.p));

		// Test Create succeeding
		UTCHK(testToolWindow.Create() == true);
		CheckCreate(true, true);
		CheckCreated(testToolWindow, siteCache, true);

		// Test that Create fails now
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		testToolWindow.Create();

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
		CheckCreate();
		CheckCreated(testToolWindow, siteCache, true);
		CheckShow();

		// Test Show no activate succeeding
		testToolWindow.Show(false);
		CheckShowAlreadyCreated(testToolWindow, siteCache, false, true);

		// Test Show activate succeeding
		testToolWindow.Show();
		CheckShowAlreadyCreated(testToolWindow, siteCache, true);

		// Test CreateAndShow no activate succeeding
		testToolWindow.CreateAndShow(false);
		CheckShowAlreadyCreated(testToolWindow, siteCache, false, true);

		// Test CreateAndShow activate succeeding
		testToolWindow.CreateAndShow();
		CheckShowAlreadyCreated(testToolWindow, siteCache, true);

		}

		// Test CreateAndShow
		{
		TestToolWindow testToolWindow(siteCache);
		SetCreateToolWindowValidValues(testToolWindow, &(spIVsWindowFrame.p));
		CheckCreated(testToolWindow, siteCache);
		TestCreateAndShowActivate(testToolWindow);
		CheckCreate(true, true);
		CheckCreated(testToolWindow, siteCache, true);
		TestCreateAndShowNoActivate(testToolWindow);
		CheckCreate();
		CheckCreated(testToolWindow, siteCache, true);
		}

		// Test CreateAndShow again in reverse order
		{
		TestToolWindow testToolWindow(siteCache);
		SetCreateToolWindowValidValues(testToolWindow, &(spIVsWindowFrame.p));
		CheckCreated(testToolWindow, siteCache);
		TestCreateAndShowNoActivate(testToolWindow);
		CheckCreate(true, true);
		CheckCreated(testToolWindow, siteCache, true);
		TestCreateAndShowActivate(testToolWindow);
		CheckCreate();
		CheckCreated(testToolWindow, siteCache, true);
		}

		// Test that the various optional methods are made use of  by Create
		// ViewObject and ViewCLSID are mutually exclusive, test the former here
		{
		typedef TestToolWindow2<TestToolWindow2Controls::ControlViewObject> TestToolWindow2Specialized;
		TestToolWindow2Specialized::GetValidValues().ppWindowFrame = &(spIVsWindowFrame.p);
		IVsUIShellMockImpl::PushValidValues(TestToolWindow2Specialized::GetValidValues());

		TestToolWindow2Specialized testToolWindow(siteCache);
		CheckCreated(testToolWindow, siteCache);
		UTCHK(testToolWindow.Create() == false);
		CheckCreated(testToolWindow, siteCache, true);
		}

		// Test that the various optional methods are made use of  by Create
		// ViewObject and ViewCLSID are mutually exclusive, test the later here
		{
		typedef TestToolWindow2<TestToolWindow2Controls::ControlViewCLSID> TestToolWindow2Specialized;
		TestToolWindow2Specialized::GetValidValues().ppWindowFrame = &(spIVsWindowFrame.p);
		IVsUIShellMockImpl::PushValidValues(TestToolWindow2Specialized::GetValidValues());

		TestToolWindow2Specialized testToolWindow(siteCache);
		CheckCreated(testToolWindow, siteCache);
		UTCHK(testToolWindow.Create() == false);
		CheckCreated(testToolWindow, siteCache, true);
		}

		siteCache.SetSite(NULL);
	}
};

#define FAKE_DIALOG_RESOURCE_STRING 121
class VsWindowPaneFromResourceMockImpl :
	public VsWindowPaneFromResource<VsWindowPaneFromResourceMockImpl, FAKE_DIALOG_RESOURCE_STRING, WindowMock, IVsWindowPaneImpl<VsWindowPaneFromResourceMockImpl> >,
	public UnitTestBase
{

VSL_DEFINE_IUNKNOWN_NOTIMPL

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(VsWindowPaneFromResourceMockImpl)

private:

	void IsSited(bool bSited)
	{
		UTCHK((GetVsSiteCache().GetSite() != NULL) == bSited);
	}

	void IsCreated(bool bCreated)
	{
		UTCHK((GetHWND() != NULL) == bCreated);
	}

	void CheckConstantReturnValues()
	{
		UTCHK(GetDefaultSize(NULL) == E_NOTIMPL);
		UTCHK(ClosePane() == S_OK);
		UTCHK(LoadViewState(NULL) == E_NOTIMPL);
		UTCHK(SaveViewState(NULL) == E_NOTIMPL);
	}

	void GetMethodsCalled(int /*iCalledNTimes*/)
	{
//		UTCHK(WASCALLED0(VsWindowPaneFromResource, GetDialogProc, iCalledNTimes));
//		UTCHK(WASCALLED0(VsWindowPaneFromResource, GetDialogInitParam, iCalledNTimes));
	}


	struct PostSitedValidValues
	{
		// In
		IVsPackageEnums::SetSiteResult result;
	};

public:
	void PostSited(IVsPackageEnums::SetSiteResult result)
	{
		VSL_DEFINE_MOCK_METHOD(PostSited);

		VSL_CHECK_VALIDVALUE(result);
	}

	DLGPROC GetDialogProc()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(GetDialogProc);

		return reinterpret_cast<DLGPROC>(reinterpret_cast<void*>(10101));
	}

	LPARAM GetDialogInitParam()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(GetDialogInitParam);

		return reinterpret_cast<LPARAM>(reinterpret_cast<void*>(10102));
	}

	VsWindowPaneFromResourceMockImpl(_In_opt_ const char* const szTestName):
		VsWindowPaneFromResource(),
		UnitTestBase(szTestName)
	{
		// Check unsited and uncreated
		IsSited(false);
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);
		UTCHK(GetHWND() == NULL);

		{

		// Improperly site it
		UTCHK(SetSite(NULL) == S_OK);
		IsSited(false);
		UTCHK(WASCALLED(VsWindowPaneFromResource, PostSited, 0));
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);

		// Site it
		PUSHVV1(VsWindowPaneFromResource, PostSited, IVsPackageEnums::Cached);
		UTCHK(SetSite(VsServiceProvider::GetServiceProvider()) == S_OK);
		IsSited(true);
		UTCHK(WASCALLED(VsWindowPaneFromResource, PostSited, 1));
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);

		// Site it again
		PUSHVV1(VsWindowPaneFromResource, PostSited, IVsPackageEnums::AlreadyCached);
		UTCHK(SetSite(VsServiceProvider::GetServiceProvider()) == S_OK);
		IsSited(true);
		UTCHK(WASCALLED(VsWindowPaneFromResource, PostSited, 1));
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);

		}

		{

		// Reset the call counter after the calls to setup the mock above.
		GetMethodsCalled(1);

		SETVV2(VsWindowPaneFromResource, InternalCreate, NULL, ERROR_OUTOFMEMORY);

		CREATEVV(VsWindowPaneFromResource, MoveWindow, moveWindowValidValues)
		{
			5,
			6,
			7,
			8,
			TRUE,
			TRUE,
		};

		SETVV(moveWindowValidValues);

		SETVV1(VsWindowPaneFromResource, ShowWindow, SW_SHOW);

		// Test handling of phwnd being NULL
		UTCHK(CreatePaneWindow(
			reinterpret_cast<HWND>(2),
			moveWindowValidValues.x,
			moveWindowValidValues.y,
			moveWindowValidValues.nWidth,
			moveWindowValidValues.nHeight,
			NULL)
				== E_POINTER);
		IsCreated(false);
		GetMethodsCalled(0);
		IsSited(true);
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);

		// Test CreateDialogParam failing
		HWND hwnd = reinterpret_cast<HWND>(1077);
		UTCHK(CreatePaneWindow(
			reinterpret_cast<HWND>(2),
			moveWindowValidValues.x,
			moveWindowValidValues.y,
			moveWindowValidValues.nWidth,
			moveWindowValidValues.nHeight,
			&hwnd)
				== HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		IsCreated(false);
		UTCHK(hwnd == NULL);
		GetMethodsCalled(1);
		IsSited(true);
		CheckConstantReturnValues();
		UTCHK(TranslateAccelerator(NULL) == E_UNEXPECTED);

		// Create it successfully
		SETVV2(VsWindowPaneFromResource, InternalCreate, (HWND)1, ERROR_SUCCESS);
		UTCHK(CreatePaneWindow(
			reinterpret_cast<HWND>(2),
			moveWindowValidValues.x,
			moveWindowValidValues.y,
			moveWindowValidValues.nWidth,
			moveWindowValidValues.nHeight,
			&hwnd)
				== S_OK);
		IsCreated(true);
		UTCHK(GetHWND() == hwnd);
		GetMethodsCalled(1);
		IsSited(true);
		CheckConstantReturnValues();

		PUSHVV2(IVsUIShell, TranslateAcceleratorAsACmd, NULL, E_NOTIMPL);

		// E_NOTIMPL is returned by IVsUIShell::TranslateAcceleratorAsACmd as we haven't provided 
		// an implementation for it here, that is tested below
		UTCHK(TranslateAccelerator(NULL) == E_NOTIMPL);

		}

		// TODO - test unsited case for TranslateAccelerator and TranslateAcceleratorAsACmd returning S_FALSE
	}
};

// TODO - unit test the selection contain impl class
#if 0
class SingleSelectionContainerTest :
	public UnitTestBase
{
public:
	SingleSelectionContainerTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		CComPtr<ISelectionContainer> pISelectionContainer;
		UTCHK((SingleSelectionContainer<&GUID_NULL, VxDTE::SelectedItem>::CreateInstance(&pISelectionContainer) == S_OK));
		UTCHK(pISelectionContainer != NULL);
		if(pISelectionContainer != NULL)
		{

		}
	}
};
#endif


class IVsEditorFactoryImplTest :
	public UnitTestBase,
	public IVsEditorFactoryImpl<IVsEditorFactoryImplTest>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

#pragma warning(push)
#pragma warning(disable : 4480) // // warning C4480: nonstandard extension used: specifying underlying type for enum
	enum PhysicalViewId : unsigned int
	{
		Unsupported,
		Primary
	};
#pragma warning(pop)

	PhysicalViewId GetPhysicalViewId(LPCOLESTR szPhysicalView)
	{
		// pszPhysicalView being NULL indicates the primary physical view
		if(szPhysicalView == NULL)
		{
			return Primary;
		}

		return Unsupported;
	}

	PhysicalViewId GetPhysicalViewId(REFGUID rguidLogicalView)
	{
		if(rguidLogicalView == LOGVIEWID_Primary)
		{
			return Primary;
		}

		return Unsupported;
	}

	BSTR GetPhysicalViewBSTR(PhysicalViewId physicalViewId)
	{
		UTCHK(physicalViewId == Primary);
		return NULL;
	}

	bool CanShareBuffer(PhysicalViewId /*physicalViewId*/)
	{
		return true;
	}

	IUnknown* GetDataObject()
	{
		return static_cast<IUnknown*>(this);
	}

	IUnknown* GetViewObject()
	{
		return static_cast<IUnknown*>(this);
	}

	wchar_t* GetCaption()
	{
		return L"Test Catpion";
	}

	const GUID* GetGUID()
	{
		return &__uuidof(IUnknown);
	}

	VSEDITORCREATEDOCWIN GetUI()
	{
		return ECDW_UserCanceled;
	}

	typedef const GUID* PGUID;

	void CreateDataAndViewObjects(
		PhysicalViewId physicalViewId, 
		CComPtr<IUnknown>& rspDataObject, 
		CComPtr<IUnknown>& rspViewObject, 
		CComBSTR& rbstrEditorCaption, 
		PGUID& rpguidCommandUI, 
		VSEDITORCREATEDOCWIN& rCreateDocumentWindowUI)
	{
		UTCHK(physicalViewId == Primary);
		rspDataObject = GetDataObject();
		rspViewObject = GetViewObject();
		rbstrEditorCaption = GetCaption();
		rpguidCommandUI = GetGUID();
		rCreateDocumentWindowUI = GetUI();
	}

	IVsEditorFactoryImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(E_INVALIDARG == CreateEditorInstance(
			0,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL));

		UTCHK(E_INVALIDARG == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL));

		IUnknown* punkDocView;
		IUnknown* punkDocData;
		BSTR bstrEditorCaption;
		GUID guidCmdUI;
		VSEDITORCREATEDOCWIN grfCDW;

		UTCHK(E_INVALIDARG == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			NULL,
			NULL,
			NULL,
			NULL));

		UTCHK(E_INVALIDARG == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			&punkDocData,
			NULL,
			NULL,
			NULL));

		UTCHK(E_INVALIDARG == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			&punkDocData,
			&bstrEditorCaption,
			NULL,
			NULL));

		UTCHK(E_INVALIDARG == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			&punkDocData,
			&bstrEditorCaption,
			&guidCmdUI,
			NULL));

		// NOTE - returning VS_E_INCOMPATIBLEDOCDATA when punkDocDataExisting is not NULL
		// is tested by the sample unit test for SingleViewEditorFactory
		UTCHK(S_OK == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			GetDataObject(), // simulate punkDocDataExisting not being NULL, value doesn't matter
			&punkDocView,
			&punkDocData,
			&bstrEditorCaption,
			&guidCmdUI,
			&grfCDW));

		UTCHK(punkDocView == GetDataObject());
		UTCHK(punkDocData == GetViewObject());
		UTCHK(CComBSTR(bstrEditorCaption) == CComBSTR(GetCaption()));
		UTCHK(guidCmdUI == *(GetGUID()));
		UTCHK(grfCDW == GetUI());

		UTCHK(S_OK == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			&punkDocData,
			&bstrEditorCaption,
			&guidCmdUI,
			&grfCDW));

		UTCHK(punkDocView == GetDataObject());
		UTCHK(punkDocData == GetViewObject());
		UTCHK(CComBSTR(bstrEditorCaption) == CComBSTR(GetCaption()));
		UTCHK(guidCmdUI == *(GetGUID()));
		UTCHK(grfCDW == GetUI());

		// NOTE - we test grfCDW being NULLed with the sample unit test for SingleViewEditorFactory

		// NOTE - we test the case of Derived_T providing CreateSingelViewObject rather then
		// CreateDataAndViewObjects with the sample unit test for SingleViewEditorFactory

		// NOTE - we skip SetSite as this is provided by IVsEditorFactoryImpl  inheriting from 
		// VsSiteBaseImpl

		// Check bad args are handled correctly
		UTCHK(E_INVALIDARG == MapLogicalView(LOGVIEWID_Designer, NULL));

		BSTR bstrPhysicalView;
		UTCHK(E_NOTIMPL == MapLogicalView(LOGVIEWID_Designer, &bstrPhysicalView));
		UTCHK(S_OK == MapLogicalView(LOGVIEWID_Primary, &bstrPhysicalView));
		UTCHK(bstrPhysicalView == NULL);

		// NOTE - we test the case of Derived_T not providing GetPhysicalViewBSTR
		// with the sample unit test for SingleViewEditorFactory

		// Check calling work methods after Close fails correctly
		Close();
		UTCHK(E_UNEXPECTED == MapLogicalView(LOGVIEWID_Designer, &bstrPhysicalView));
		UTCHK(E_UNEXPECTED == CreateEditorInstance(
			CEF_OPENFILE,
			NULL,
			NULL,
			NULL,
			0,
			NULL,
			&punkDocView,
			&punkDocData,
			&bstrEditorCaption,
			&guidCmdUI,
			&grfCDW));
	}
};

#include "VSLFindAndReplace.h"

class IVsFindTargetImplTest :
	public UnitTestBase,
	public IVsFindTargetImpl<IVsFindTargetImplTest>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsFindTargetImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(E_INVALIDARG == IVsFindTargetImpl::GetFindState(NULL));

		CComPtr<IUnknown> spIUnknown;
		UTCHK(S_OK == IVsFindTargetImpl::GetFindState(&spIUnknown));
		// Should start out NULL
		UTCHK(!spIUnknown);

		UTCHK(S_OK == IVsFindTargetImpl::SetFindState(NULL));

		UTCHK(S_OK == IVsFindTargetImpl::GetFindState(&spIUnknown));
		// Should still be NULL
		UTCHK(!spIUnknown);

		// It doesn't matter what type this, just that it get's AddRef'ed, Released, and returned properly
		IVsWindowFrameMock mock;
		CComPtr<IUnknown> spMock = mock.GetIUnknownNoAddRef();

		UTCHK(S_OK == IVsFindTargetImpl::SetFindState(spMock));
		UTCHK(S_OK == IVsFindTargetImpl::GetFindState(&spIUnknown));
		// Now should be equal to the mock
		UTCHK(spIUnknown == spMock);

		spIUnknown.Release();

		UTCHK(S_OK == IVsFindTargetImpl::SetFindState(NULL));
		UTCHK(S_OK == IVsFindTargetImpl::GetFindState(&spIUnknown));
		// Should be NULL again
		UTCHK(!spIUnknown);
	}

	STDMETHOD(GetProperty)( 
		/* [in] */ VSFTPROPID ,
		/* [out]*/ VARIANT *)VSL_STDMETHOD_NOTIMPL
	STDMETHOD(Find)(    
		/* [in] */ LPCOLESTR ,
		/* [in] */ VSFINDOPTIONS ,
		/* [in] */ BOOL ,
		/* [in] */ IVsFindHelper * ,
		/* [out]*/ VSFINDRESULT * )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(Replace)(  
		/* [in] */ LPCOLESTR ,
		/* [in] */ LPCOLESTR ,
		/* [in] */ VSFINDOPTIONS ,
		/* [in] */ BOOL ,
		/* [in] */ IVsFindHelper * ,
		/* [out]*/ BOOL * )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(GetMatchRect)(
		/* [out]*/ PRECT )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(NavigateTo)(
		/* [in] */ const TextSpan * )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(GetCurrentSpan)(
		/* [out]*/ TextSpan * )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(NotifyFindTarget)(
		/* [in] */ VSFTNOTIFY )VSL_STDMETHOD_NOTIMPL
	STDMETHOD(MarkSpan)( 
		/* [in] */ const TextSpan __RPC_FAR *)VSL_STDMETHOD_NOTIMPL

	IUnknown* _GetRawUnknown() throw()
	{
		return NULL;
	}

	DWORD GetCapabilityOptions()
	{
		return 0;
	}
};

class VSLMessageMapTest :
	public UnitTestBase
{
public:

VSL_BEGIN_MSG_MAP(VSLMessageMapTest)
	throw CAtlException(E_UNEXPECTED);
VSL_END_MSG_MAP()

	VSLMessageMapTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		LRESULT lResult = 0;
		UTCHK(FALSE == ProcessWindowMessage(NULL, 0, 0, 0, lResult));
	}
};

// TODO - 1/27/2006 - make a File unit test for the following
#include "VSLFile.h"

typedef InterfaceImplList<IVsQueryEditQuerySave2MockImpl, IUnknownInterfaceListTerminatorDefault> IVsQueryEditQuerySave2MockImplList;
VSL_DEFINE_SERVICE_MOCK_EX(IVsQueryEditQuerySave2ServiceMock, IVsQueryEditQuerySave2MockImplList, SID_SVsQueryEditQuerySave);
typedef InterfaceImplList<IVsFileChangeExMockImpl, IUnknownInterfaceListTerminatorDefault> IVsFileChangeExMockImplList;
VSL_DEFINE_SERVICE_MOCK_EX(IVsFileChangeExServiceMock, IVsFileChangeExMockImplList, SID_SVsFileChangeEx);
typedef InterfaceImplList<IVsRunningDocumentTableMockImpl, IUnknownInterfaceListTerminatorDefault> IVsRunningDocumentTableMockImplList;
VSL_DEFINE_SERVICE_MOCK_EX(IVsRunningDocumentTableMock, IVsRunningDocumentTableMockImplList, SID_SVsRunningDocumentTable);

typedef ServiceList<IVsRunningDocumentTableMock, ServiceList<IVsFileChangeExServiceMock, ServiceList<IVsQueryEditQuerySave2ServiceMock, ServiceList<IVsShellServiceMock, ServiceList<IVsUIShellServiceMock, ServiceListTerminator> > > > > IVsQueryEditQuerySave2ProviderServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IVsQueryEditQuerySave2ProviderServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IVsQueryEditQuerySave2ProviderMockInterfaceList;

VSL_DECLARE_COM_MOCK(IVsQueryEditQuerySave2ProviderMock, IVsQueryEditQuerySave2ProviderMockInterfaceList){};

class DocumentPersistanceBaseTest :
	public UnitTestBase,
	public MockBase,
	public DocumentPersistanceBase<DocumentPersistanceBaseTest, FileMock>
{
public:

	typedef VsSiteCacheLocal VsSiteCache;

	const VsSiteCache& GetVsSiteCache() const
	{
		return m_VsSiteCache;
	}

	// Makes the convinience macros happy
	typedef DocumentPersistanceBaseTest DocumentPersistanceBaseTestMockImpl;

	VSL_DEFINE_MOCK_CLASS_TYPDEFS(DocumentPersistanceBaseTest);
	
	VSL_DEFINE_IUNKNOWN_NOTIMPL

	void OnFileChangedSetTimer()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(OnFileChangedSetTimer);
	}

	struct PostSetReadOnlyValidValues
	{
		bool bIsFileReadOnly;
	};

	void PostSetReadOnly()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(PostSetReadOnly);
	}

	bool IsValidFormat(DWORD dwFormatIndex)
	{
		return DEF_FORMAT_INDEX == dwFormatIndex;
	}

	const GUID& GetEditorTypeGuid() const
	{
		// {442EAB59-08D8-4a68-B16C-B741760D4750}
		static const GUID guid = { 0x442eab59, 0x8d8, 0x4a68, { 0xb1, 0x6c, 0xb7, 0x41, 0x76, 0xd, 0x47, 0x50 } };
		return guid;
	}

	void GetFormatListString(ATL::CStringW& rstrFormatList)
	{
		VSL_NOTE_METHOD_WAS_CALLED(GetFormatListString);
		rstrFormatList = m_strFormatList;
	}

    HRESULT ReadData(HANDLE hFile, BOOL fInsert, DWORD& rdwFormatIndex)
	{
		// TODO - improve this further after it's refactored
		VSL_NOTE_METHOD_WAS_CALLED(ReadData);
		(hFile, fInsert);
		rdwFormatIndex = DEF_FORMAT_INDEX;
		return S_OK;
	}

    HRESULT WriteData(HANDLE hFile, DWORD dwFormatIndex = DEF_FORMAT_INDEX)
	{
		VSL_NOTE_METHOD_WAS_CALLED(WriteData);
		(hFile, dwFormatIndex);
		// TODO - 1/30/2006 - improve this further after it's refactored
		return S_OK;
	}


	void PostSetDirty()
	{
		// TODO - 1/30/2006 - better mock for this
	}

	void TestServiceDependentMethods()
	{
		IVsQueryEditQuerySave2ProviderMock serviceProviderMock;
		m_VsSiteCache.SetSite(&serviceProviderMock);

		ResetFileState();
		SetFileName(NULL);

		// IPersistFileFormat::Load
		SETVV1(IVsUIShell, SetWaitCursor, S_OK);
		SETVV1(File, IsFileReadOnly, false);

		UTCHK(E_INVALIDARG == Load(NULL, 0, FALSE));
		UTCHK(WASCALLED0(IVsUIShell, SetWaitCursor, 0));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));

		PUSHVV1(File, GetFileType, FILE_TYPE_PIPE);

		UTCHK(HRESULT_FROM_WIN32(ERROR_INVALID_NAME) == Load(m_strFileName, 0, FALSE));
		UTCHK(WASCALLED0(IVsUIShell, SetWaitCursor, 1));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));

		PUSHVV1(File, GetFileType, FILE_TYPE_DISK);
		PUSHVV1(File, IsZeroLength, true);

		VSCOOKIE cookie = 57;
		CREATEVV(IVsFileChangeEx, AdviseFileChange, valuesAdviseFileChange)
		{
			m_strFileName,
			VSFILECHG_Attr | VSFILECHG_Time | VSFILECHG_Size,
			static_cast<IVsFileChangeEvents*>(this),
			&cookie,
			S_OK
		};
		PUSHVV(valuesAdviseFileChange);

		VSDOCCOOKIE docCookie = 77;
		STARTVV(IVsRunningDocumentTable, FindAndLockDocument)
			RDT_ReadLock,
			m_strFileName,
			NULL,
			NULL,
			0,
			&docCookie,
			S_OK
		ENDVVPUSH()

		PUSHVV3(IVsRunningDocumentTable, NotifyDocumentChanged, docCookie, RDTA_DocDataReloaded, S_OK);
		PUSHVV3(IVsRunningDocumentTable, UnlockDocument, RDT_ReadLock, docCookie, S_OK);

		UTCHK(S_OK == Load(m_strFileName, 0, FALSE));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));
		UTCHK(WASCALLED(IVsFileChangeEx, AdviseFileChange, 1));
		// TODO - verify state

		PUSHVV1(File, GetFileType, FILE_TYPE_DISK);
		PUSHVV1(File, IsZeroLength, false);

		UTCHK(S_OK == Load(m_strFileName, 0, FALSE));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 1));
		// TODO - verify state

		// IVsPersistDocData::LoadDocData
		UTCHK(E_INVALIDARG == LoadDocData(NULL));
		UTCHK(WASCALLED(IVsUIShell, SetWaitCursor, 0));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));

		PUSHVV1(File, GetFileType, FILE_TYPE_DISK);
		PUSHVV1(File, IsZeroLength, true);

		UTCHK(S_OK == LoadDocData(m_strFileName));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));
		// TODO - verify state

		PUSHVV1(File, GetFileType, FILE_TYPE_DISK);
		PUSHVV1(File, IsZeroLength, false);

		UTCHK(S_OK == LoadDocData(m_strFileName));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 1));
		// TODO - verify state

		// IPersistFileFormat::Save
		PUSHVV2(IVsFileChangeEx, UnadviseFileChange, cookie, S_OK); 
		SetFileName(NULL);
		UTCHK(E_INVALIDARG == Save(NULL, FALSE, DEF_FORMAT_INDEX+1));

		// NULL is valid for the first parameter, if the filename has been set already
		// but it has not, so NULL isn't valid
		UTCHK(E_INVALIDARG == Save(NULL, FALSE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 0));

		CREATEVV(IVsFileChangeEx, IgnoreFile, valuesIgnoreFile)
		{
			NULL,
			m_strFileName,
			TRUE,
			S_OK
		};
		PUSHVV(valuesIgnoreFile);

		PUSHVV2(IVsFileChangeEx, SyncFile, m_strFileName, S_OK);
		valuesIgnoreFile.fIgnore = FALSE;
		PUSHVV(valuesIgnoreFile);

		// Test the "Save" case, so set filename first
		GetFile().GetFullPathName() = m_strFileName;
		UTCHK(S_OK == Save(NULL, FALSE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));
		UTCHK(WASCALLED(IVsFileChangeEx, IgnoreFile, 2));

		valuesIgnoreFile.fIgnore = TRUE;
		PUSHVV(valuesIgnoreFile);
		PUSHVV2(IVsFileChangeEx, SyncFile, m_strFileName, S_OK);
		valuesIgnoreFile.fIgnore = FALSE;
		PUSHVV(valuesIgnoreFile);

		// Test the "Save" case, that looks like a "Save As", but has the same filename, so set filename first
		UTCHK(S_OK == Save(m_strFileName, TRUE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));
		UTCHK(WASCALLED(IVsFileChangeEx, IgnoreFile, 2));

		LPCOLESTR szFileName = L"NotTheSameFileName";

		// Test the "Save Copy As" case
		UTCHK(S_OK == Save(szFileName, FALSE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));

		cookie = 57;
		valuesAdviseFileChange.pszMkDocument = szFileName;
		PUSHVV(valuesAdviseFileChange);

		// Test the "Save As" case
		UTCHK(S_OK == Save(szFileName, TRUE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));
		UTCHK(WASCALLED(IVsFileChangeEx, AdviseFileChange, 1));

		// IVsPersistDocData::SaveDocData
		PUSHVV2(IVsFileChangeEx, UnadviseFileChange, cookie, S_OK); 
		SetFileName(NULL);

		UTCHK(E_INVALIDARG == SaveDocData(static_cast<VSSAVEFLAGS>(-1), NULL, NULL));

		BSTR bstrMkDocumentNew = reinterpret_cast<LPOLESTR>(-1);
		BOOL bSaveCanceled = 55;
		UTCHK(E_INVALIDARG == SaveDocData(static_cast<VSSAVEFLAGS>(-1), &bstrMkDocumentNew, NULL));
		UTCHK(E_UNEXPECTED == SaveDocData(static_cast<VSSAVEFLAGS>(-1), &bstrMkDocumentNew, &bSaveCanceled));
		GetFile().GetFullPathName() = m_strFileName;
		UTCHK(E_INVALIDARG == SaveDocData(static_cast<VSSAVEFLAGS>(-1), &bstrMkDocumentNew, &bSaveCanceled));

		VSQuerySaveResult result = QSR_NoSave_UserCanceled;
		STARTVV(IVsQueryEditQuerySave2, QuerySaveFile)
			m_strFileName,
			0,
			NULL,
			&result
		ENDVVSET();

		UTCHK(S_OK == SaveDocData(VSSAVE_Save, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(TRUE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 0));

		bSaveCanceled = 55;
		result = QSR_NoSave_Continue;

		UTCHK(S_OK == SaveDocData(VSSAVE_Save, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(FALSE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 0));

		bSaveCanceled = 55;
		result = QSR_ForceSaveAs;

		CComBSTR bstrDocumentNew = m_strFileName;
		BOOL fCanceled = FALSE;
		CREATEVV(IVsUIShell, SaveDocDataToFile, valuesSaveDocDataToFile)
		{
			VSSAVE_SaveAs,
			static_cast<IPersistFileFormat*>(this),
			m_strFileName,
			&bstrDocumentNew,
			&fCanceled,
			S_OK
		};
		PUSHVV(valuesSaveDocDataToFile);

		UTCHK(S_OK == SaveDocData(VSSAVE_Save, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(FALSE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 1));

		bSaveCanceled = 55;
		result = QSR_SaveOK;
		valuesSaveDocDataToFile.grfSave = VSSAVE_Save;
		PUSHVV(valuesSaveDocDataToFile);

		UTCHK(S_OK == SaveDocData(VSSAVE_Save, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(FALSE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 1));

		bSaveCanceled = 55;
		valuesSaveDocDataToFile.grfSave = VSSAVE_SaveAs;
		PUSHVV(valuesSaveDocDataToFile);

		UTCHK(S_OK == SaveDocData(VSSAVE_SaveAs, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(FALSE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 1));

		bSaveCanceled = 55;
		valuesSaveDocDataToFile.grfSave = VSSAVE_SaveCopyAs;
		PUSHVV(valuesSaveDocDataToFile);

		UTCHK(S_OK == SaveDocData(VSSAVE_SaveCopyAs, &bstrMkDocumentNew, &bSaveCanceled));
		UTCHK(FALSE == bSaveCanceled);
		UTCHK(WASCALLED(IVsUIShell, SaveDocDataToFile, 1));

		// IVsPersistDocData::ReloadDocData
		UTCHK(E_INVALIDARG == ReloadDocData(RDD_IgnoreNextFileChange));

		PUSHVV1(File, GetFileType, FILE_TYPE_DISK);
		PUSHVV1(File, IsZeroLength, true);

		UTCHK(S_OK == ReloadDocData(0));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, ReadData, 0));

		// IVsFileBackup methods
		ResetFileState();
		UTCHK(E_INVALIDARG == IsBackupFileObsolete(NULL));
		BOOL bObsolete = 55;
		UTCHK(S_OK == IsBackupFileObsolete(&bObsolete));
		// Since the state is clear, it isn't dirty, so no need for a backup
		UTCHK(FALSE == bObsolete);

		SetFileDirty(true);

		bObsolete = 55;
		UTCHK(S_OK == IsBackupFileObsolete(&bObsolete));
		// Now the state is dirty, so there need for a backup
		UTCHK(TRUE == bObsolete);

		UTCHK(E_INVALIDARG == BackupFile(NULL));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 0));
		UTCHK(S_OK == BackupFile(L"\\Test\\Backup\\z7891.rtf"));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));

		bObsolete = 55;
		UTCHK(S_OK == IsBackupFileObsolete(&bObsolete));
		// Since a backup has been made, and no state changes have occured since,
		// there is now no need for a backup.
		UTCHK(FALSE == bObsolete);

		SetFileDirty(true);

		bObsolete = 55;
		UTCHK(S_OK == IsBackupFileObsolete(&bObsolete));
		// Now the state is dirty, so there need for a backup
		UTCHK(TRUE == bObsolete);

		// Do a normal Save
		valuesIgnoreFile.fIgnore = TRUE;
		PUSHVV(valuesIgnoreFile);
		PUSHVV2(IVsFileChangeEx, SyncFile, m_strFileName, S_OK);
		valuesIgnoreFile.fIgnore = FALSE;
		PUSHVV(valuesIgnoreFile);
		GetFile().GetFullPathName() = m_strFileName;
		UTCHK(S_OK == Save(NULL, FALSE, DEF_FORMAT_INDEX));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, WriteData, 1));
		UTCHK(WASCALLED(IVsFileChangeEx, IgnoreFile, 2));

		bObsolete = 55;
		UTCHK(S_OK == IsBackupFileObsolete(&bObsolete));
		// Since a Save has occured, and no state changes have occured since,
		// there is now no need for a backup.
		UTCHK(FALSE == bObsolete);

		// Clean up
		PUSHVV2(IVsFileChangeEx, UnadviseFileChange, cookie, S_OK); 
		OnDocumentClose();

		m_VsSiteCache.SetSite(NULL);
	}

	void TestIVsPersistDocData()
	{
		// Test IPersist
		{
		UTCHK(E_INVALIDARG == GetClassID(NULL));
		CLSID clsid = GUID_NULL;
		UTCHK(S_OK == GetClassID(&clsid));
		UTCHK(GetEditorTypeGuid() == clsid);
		}

		// Test IVsPersistDocData
		{
		UTCHK(E_INVALIDARG == GetGuidEditorType(NULL));
		CLSID clsid = GUID_NULL;
		UTCHK(S_OK == GetGuidEditorType(&clsid));
		UTCHK(GetEditorTypeGuid() == clsid);
		}

		{
		UTCHK(E_INVALIDARG == IsDocDataDirty(NULL));

		// Set the state is dirty
		ResetFileState();
		SetFileDirty(true);
		BOOL bDirty = FALSE;
		UTCHK(S_OK == IsDocDataDirty(&bDirty));
		// Make sure we got dirty
		UTCHK(TRUE == bDirty);

		// Reset the state, to clear dirty
		ResetFileState();
		UTCHK(S_OK == IsDocDataDirty(&bDirty));
		// Make sure we are not dirty now
		UTCHK(FALSE == bDirty);
		}

		{
		// Parameter is ignored 
		ResetFileState();
		UTCHK(S_OK == SetUntitledDocPath(NULL));
		ResetFileState();
		UTCHK(S_OK == SetUntitledDocPath(L""));
		ResetFileState();
		UTCHK(S_OK == SetUntitledDocPath(L"\\Directory\\Directory"));
		}

		// LoadDocData and SaveDocData are tested in TestServiceDependentMethods

		// These just returns S_OK in all cases
		UTCHK(S_OK == Close());
		UTCHK(S_OK == OnRegisterDocData(0, NULL, 0));
		UTCHK(S_OK == OnRegisterDocData(55, reinterpret_cast<IVsHierarchy*>(NULL+1), 56));
		UTCHK(S_OK == RenameDocData(0, NULL, 0, NULL));
		UTCHK(S_OK == RenameDocData(55, reinterpret_cast<IVsHierarchy*>(NULL+1), 56, L""));
		UTCHK(S_OK == RenameDocData(55, reinterpret_cast<IVsHierarchy*>(NULL+1), 56, L"\\Test\\Test.rtf"));

		{
		UTCHK(E_INVALIDARG == IsDocDataReloadable(NULL));
		BOOL bReloadable;
		UTCHK(S_OK == IsDocDataReloadable(&bReloadable));
		// Always indicates it's reloadable
		UTCHK(TRUE == bReloadable);
		}

		// ReloadDocData is tested in TestServiceDependentMethods
	}

	void TestIPersistFileFormat()
	{
		{
		UTCHK(E_INVALIDARG == IsDirty(NULL));

		// Set the state is dirty
		ResetFileState();
		SetFileDirty(true);
		BOOL bDirty = FALSE;
		UTCHK(S_OK == IsDirty(&bDirty));
		// Make sure we got dirty
		UTCHK(TRUE == bDirty);

		// Reset the state, to clear dirty
		ResetFileState();
		UTCHK(S_OK == IsDirty(&bDirty));
		// Make sure we are not dirty now
		UTCHK(FALSE == bDirty);
		}

		{
		ResetFileState();
		UTCHK(E_INVALIDARG == InitNew(1));
		ResetFileState();
		UTCHK(S_OK == InitNew(DEF_FORMAT_INDEX));
		}

		// Load and Save are tested in TestServiceDependentMethods

		// This just returns S_OK in all cases
		UTCHK(S_OK == SaveCompleted(NULL));
		UTCHK(S_OK == SaveCompleted(L""));
		UTCHK(S_OK == SaveCompleted(L"\\Directory\\Directory"));

		// Clear the file name
		SetFileName(NULL);
		UTCHK(E_INVALIDARG == GetCurFile(NULL, NULL));

		LPOLESTR szFilename = reinterpret_cast<LPOLESTR>(-1);
		DWORD dwFormatIndex = 0xFFFFFFFF;
		UTCHK(E_INVALIDARG == GetCurFile(&szFilename, NULL));

		UTCHK(S_OK == GetCurFile(&szFilename, &dwFormatIndex));
		// szFilename should be NULL, since the filename has been cleared
		UTCHK(NULL == szFilename);
		// Can only be DEF_FORMAT_INDEX for this test
		UTCHK(DEF_FORMAT_INDEX == dwFormatIndex);

		GetFile().GetFullPathName() = m_strFileName;

		UTCHK(S_OK == GetCurFile(&szFilename, &dwFormatIndex));
		// Okay, now the file has been set, so szFilename should match it now
		UTCHK(szFilename != NULL);
		if(szFilename)
		{
			UTCHK(0 == m_strFileName.Compare(szFilename));
		}
		UTCHK(DEF_FORMAT_INDEX == dwFormatIndex);
		::CoTaskMemFree(szFilename);

		UTCHK(E_INVALIDARG == GetFormatList(NULL));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, GetFormatListString, 0));

		LPOLESTR szFormatList = reinterpret_cast<LPOLESTR>(-1);
		UTCHK(S_OK == GetFormatList(&szFormatList));
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, GetFormatListString, 1));
		UTCHK(0 == m_strFormatList.Compare(szFormatList));
		::CoTaskMemFree(szFormatList);
	}

	void TestFileChangeRelated()
	{
		// Test IVsFileChangeEvents and IVsDocDataFileChangeControl methods
		const DWORD iFileChanges = 2;
		LPCOLESTR changedFileNames[iFileChanges] =
		{
			L"\\Directory\\NotMyFile.rtf",
			m_strFileName,
		};
		VSFILECHANGEFLAGS changeFlags[iFileChanges] =
		{
			VSFILECHG_Time | VSFILECHG_Size,
			VSFILECHG_Attr | VSFILECHG_Time | VSFILECHG_Size,
		};
		UTCHK(E_INVALIDARG == FilesChanged(0, NULL, NULL));
		UTCHK(E_INVALIDARG == FilesChanged(iFileChanges, NULL, NULL));
		UTCHK(E_INVALIDARG == FilesChanged(iFileChanges, changedFileNames, NULL));

		// Clear call count
		WASCALLED(DocumentPersistanceBaseTest, PostSetReadOnly, 0);
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));

		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// Since the filename hasn't been set yet, these should not be called
		UTCHK(WASCALLED(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));

		// Now set the filename
		GetFile().GetFullPathName() = m_strFileName;

		// Test the read-only case
		SETVV1(File, IsFileReadOnly, true);
		SETVV1(DocumentPersistanceBaseTest, PostSetReadOnly, true);

		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// Now both of these should be called
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 1));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 1));

		// Now reverse the read-only case
		SETVV1(File, IsFileReadOnly, false);
		SETVV1(DocumentPersistanceBaseTest, PostSetReadOnly, false);

		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 1));
		// Now this shouldn't be called since NotifyFileChangedTimerHandled hasn't been called yet.
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));

		// Now remove the attribute change
		changeFlags[1] = VSFILECHG_Time | VSFILECHG_Size;

		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// Now both shouldn't be called
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));

		NotifyFileChangedTimerHandled();

		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		// Now this should be called since NotifyFileChangedTimerHandled was called
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 1));

		// Enable these to be called again
		changeFlags[1] = VSFILECHG_Attr | VSFILECHG_Time | VSFILECHG_Size;
		NotifyFileChangedTimerHandled();

		UTCHK(S_OK == IgnoreFileChanges(TRUE));
		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// but they shouldn't be called since IgnoreFileChanges has been called with TRUE and 
		// not balanced with an equal number of calls with FALSE
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));
		UTCHK(S_OK == IgnoreFileChanges(TRUE));
		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// still not balanced
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));
		UTCHK(S_OK == IgnoreFileChanges(FALSE));
		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// still not balanced
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 0));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 0));
		UTCHK(S_OK == IgnoreFileChanges(FALSE));
		UTCHK(S_OK == FilesChanged(iFileChanges, changedFileNames, changeFlags));
		// Balanced, now should get called.
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, PostSetReadOnly, 1));
		UTCHK(WASCALLED0(DocumentPersistanceBaseTest, OnFileChangedSetTimer, 1));

		// This just returns S_OK in all cases
		UTCHK(S_OK == DirectoryChanged(NULL));
		UTCHK(S_OK == DirectoryChanged(L""));
		UTCHK(S_OK == DirectoryChanged(L"\\Directory\\Directory"));
	}

	DocumentPersistanceBaseTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName),
		m_strFileName(L"\\Test\\Test.rtf"),
		m_strFormatList(L"Test Format List")
	{
		TestFileChangeRelated();
		TestIVsPersistDocData();
		TestIPersistFileFormat();
		TestServiceDependentMethods();
	}
private:
	CStringW m_strFileName;
	CStringW m_strFormatList;
	VsSiteCacheLocal m_VsSiteCache;
};

// TODO - 1/27/2006 - make a Font unit test for the following
#include "VSLFont.h"
#include "VSLContainers.h" // for StaticArray

class VsFontCommandHandlingTest :
	public UnitTestBase
{
public:

	VsFontCommandHandlingTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		std::vector<wchar_t*> emptyVector;
		{
		VSL_STDMETHODTRY{		
		VsFontCommandHandling::FontContainerToVariant(emptyVector, NULL);
		}VSL_STDMETHODCATCH()
		UTCHK(E_INVALIDARG == VSL_GET_STDMETHOD_HRESULT());
		}

		ATL::CComVariant var;
		{
		VSL_STDMETHODTRY{		
		VsFontCommandHandling::FontContainerToVariant(emptyVector, &var);
		}VSL_STDMETHODCATCH()
		UTCHK(E_FAIL == VSL_GET_STDMETHOD_HRESULT());
		}

		StaticArray<wchar_t*, 3> szFontSizeStrings =
		{
			{ 
				_T("8"), 
				_T("10"), 
				_T("12"), 
			}
		};

		{
		VSL_STDMETHODTRY{		
		VsFontCommandHandling::FontContainerToVariant(szFontSizeStrings, NULL);
		}VSL_STDMETHODCATCH()
		UTCHK(E_INVALIDARG == VSL_GET_STDMETHOD_HRESULT());
		}

		VsFontCommandHandling::FontContainerToVariant(szFontSizeStrings, &var);
		UTCHK(var.vt == (VT_ARRAY|VT_BSTR));
		ATL::CComSafeArray<BSTR> safeArray(var.parray);
		UTCHK(3 == safeArray.GetCount());
		UTCHK(safeArray[0] == szFontSizeStrings[0]);
		UTCHK(safeArray[1] == szFontSizeStrings[1]);
		UTCHK(safeArray[2] == szFontSizeStrings[2]);

		// PopulateFontNameContainer is test by the Single View Editor Sample
		// although it could be more precisely tested here.
	}
};

int _cdecl _tmain()
{
	UTRUN(ToolWindowBaseTest);
	UTRUN(VsWindowPaneFromResourceMockImpl);
#if 0
	UTRUN(SingleSelectionContainerTest);
#endif
	UTRUN(WindowFrameEventsSinkTest);
	UTRUN(IVsEditorFactoryImplTest);
	UTRUN(IVsFindTargetImplTest);
	UTRUN(VSLMessageMapTest);
	UTRUN(DocumentPersistanceBaseTest);
	UTRUN(VsFontCommandHandlingTest);
	return VSL::FailureCounter::Get();
}

