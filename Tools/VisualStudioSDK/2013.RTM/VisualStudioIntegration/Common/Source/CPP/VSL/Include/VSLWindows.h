/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLWINDOWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLWINDOWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>
#include <VSLVsSite.h>
#include <VSLContainers.h>

namespace VSL
{

// REVIEW - determine if there is a good way to unit test this
template <class Parent_T = ATL::CWindow>
class Window :
	public Parent_T
{

VSL_DECLARE_NOT_COPYABLE(Window)

public:

	Window():
		Parent()
	{
	}

	Window(const ATL::CWindow& rWindow):
		Parent(rWindow)
	{
	}

	virtual ~Window() {}

	typedef Parent_T Parent;

	HWND& GetHWND()
	{
		return m_hWnd;
	}

	void CreateDialogParam(
		HINSTANCE hInstance,
		LPCTSTR lpTemplateName,
		HWND hWndParent,
		DLGPROC lpDialogFunc,
		LPARAM dwInitParam)
	{
		GetHWND() = ::CreateDialogParam(
				hInstance, 
				lpTemplateName, 
				hWndParent, 
				lpDialogFunc, 
				dwInitParam);
		VSL_CHECKHANDLE_GLE(GetHWND());
	}

	template<class WPARAM_T, class LPARAM_T>
	LRESULT SendMessage(UINT uMsg, WPARAM_T wParam, LPARAM_T lParam) const throw()
	{
		// cast away constness, since ATL::CWindow doesn't have a const SendMessage method
		return const_cast<Parent_T*>(static_cast<const Parent_T*>(this))->
			// C-style casts used here as they can function as both static_cast and reinterpret_cast
			SendMessage(uMsg, (WPARAM)wParam, (LPARAM)lParam);
	}

	LRESULT CallWindowProc(
		_In_ WNDPROC pWndProc,
		_In_ UINT msg,
		_In_ WPARAM wParam,
		_In_ LPARAM lParam)
	{
		return ::CallWindowProc(pWndProc, m_hWnd, msg, wParam, lParam);
	}

	static HWND GetActiveWindow()
	{
		return ::GetActiveWindow();
	}
};

class Cursor
{
VSL_DECLARE_NOT_COPYABLE(Cursor)

private:

	// FUTURE - could add default construction, not needed currently
	Cursor();

public:

	Cursor(_In_ LPWSTR szCursorName, HINSTANCE hInstance = NULL):
		m_hCursor(static_cast<HCURSOR>(VSL_CHECKHANDLE_GLE(::LoadCursor(hInstance, szCursorName))))
	{
	}

	~Cursor()
	{
		BOOL bDestroyed = ::DestroyCursor(m_hCursor);
		VSL_ASSERT(bDestroyed != FALSE); // paranoid, this should never fire
		(bDestroyed);
	}

	HCURSOR Activate()
	{
		return ::SetCursor(m_hCursor);
	}

private:
	HCURSOR m_hCursor;
};

// TODO - 2/21/2006 - move this someplace else
class Keyboard
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(Keyboard)

public:

	static bool IsKeyDown(_In_ int nVirtKey)
	{
		return (::GetKeyState(nVirtKey) & 0x8000 ? true : false);
	}
};

template <
	class Derived_T,
	class PackageVsSiteCache_T = IVsPackageImplDefaults<>::VsSiteCache,
	// This must not be a global cache, as the site is window specific
	class VsSiteCache_T = VsSiteCacheLocal> 
class ToolWindowBase
{

VSL_DECLARE_NOT_COPYABLE(ToolWindowBase)

private:

	// No default construction, rPackageVsSiteCache must be provided.
	ToolWindowBase();

protected:

	// Since this is not virtual, classes with access should not cast to a pointer of this
	// type and call delete on it
	~ToolWindowBase() {}

public:

	typedef VsSiteCache_T VsSiteCache;
	typedef PackageVsSiteCache_T PackageVsSiteCache;

	// FUTURE - rPackageVsSiteCache may be removed
	ToolWindowBase(const PackageVsSiteCache& rPackageVsSiteCache) :
		m_spIVsWindowFrame(),
		m_VsSiteCache(),
		m_rPackageVsSiteCache(rPackageVsSiteCache)
	{
		C_ASSERT(!VsSiteCache_T::IServiceProviderCache::bIsGlobal);
	}

	bool HasBeenCreated() const
	{
		return m_spIVsWindowFrame != NULL;
	}

	void Show(bool bActivate = GetShowActivateDefault())
	{
		VSL_CHECKBOOLEAN(HasBeenCreated(), E_UNEXPECTED);

		InternalShow(bActivate);
	}

	// FUTURE - rPackageVsSiteCache may be added as a parameter
	bool Create()
	{
		VSL_CHECKBOOLEAN(!HasBeenCreated(), E_UNEXPECTED);

		CComPtr<IVsUIShell> spIVsUIShell = m_rPackageVsSiteCache.GetCachedService<IVsUIShell, SID_SVsUIShell>();
		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		__if_exists(Derived_T::PreCreate)
		{
			rDerived.PreCreate();
		}

		DWORD dwInstanceId = 0;
		__if_exists(Derived_T::GetInstanceID)
		{
			dwInstanceId = rDerived.GetInstanceID();
		}

		// TODO - 1/18/2006 - add Derived_T::CreateViewObject, with precedence over
		// GetViewObject.  GetViewObject returns a pointer to a member pointer.
		// CreateViewObject set the incoming value to an AddRef'ed pointer.
		// GetViewObject should be callable more then once.  Have UIEventsToolWindow
		// provide CreateViewObject rather then GetViewObject, as the later does
		// not need a reference to the view object for itself.

		IUnknown* pViewObject = NULL;
		__if_exists(Derived_T::GetViewObject)
		{
			__if_exists(Derived_T::GetLocalRegistryCLSIDViewObject)
			{
				// Can't speceify both an object and a clsid
				C_ASSERT(0);
			}
			pViewObject = rDerived.GetViewObject();
		}

		const IID* pLocalRegistryCLSIDViewObject = &GUID_NULL;
		__if_exists(Derived_T::GetLocalRegistryCLSIDViewObject)
		{
			__if_exists(Derived_T::GetViewObject)
			{
				// Can't speceify both an object and a clsid
				C_ASSERT(0);
			}
			pLocalRegistryCLSIDViewObject = &(rDerived.GetLocalRegistryCLSIDViewObject());
			VSL_CHECKBOOLEAN(pLocalRegistryCLSIDViewObject != NULL, E_UNEXPECTED);
		}

		IServiceProvider* pToolWindowServiceProvider = NULL;
		__if_exists(Derived_T::GetToolWindowServiceProvider)
		{
			pToolWindowServiceProvider = rDerived.GetToolWindowServiceProvider();
		}

		BOOL bDefaultPosition = TRUE;

		HRESULT hr = spIVsUIShell->CreateToolWindow(
			rDerived.GetCreationFlags(), 
			dwInstanceId, 
			pViewObject, 
			*pLocalRegistryCLSIDViewObject, 
			rDerived.GetToolWindowGuid(),
			GUID_NULL,
			pToolWindowServiceProvider,
			rDerived.GetCaption(),
			&bDefaultPosition,
			&m_spIVsWindowFrame);

		VSL_CHECKHRESULT(hr);

		CComVariant varServiceProvider;
		VSL_CHECKHRESULT(m_spIVsWindowFrame->GetProperty(VSFPROPID_SPFrame, &varServiceProvider));
		VSL_CHECKBOOLEAN(varServiceProvider.vt == ::VT_UNKNOWN, E_FAIL);
		CComQIPtr<IServiceProvider> spIServiceProvider = varServiceProvider.punkVal;
		VSL_CHECKBOOLEAN(spIServiceProvider != NULL, E_FAIL);
		m_VsSiteCache.SetSite(spIServiceProvider);

		__if_exists(Derived_T::PostCreate)
		{
			rDerived.PostCreate();
		}

		return static_cast<bool>(bDefaultPosition);
	}

	void CreateAndShow(bool bActivate = GetShowActivateDefault())
	{
		if(!HasBeenCreated())
		{
			Create();
		}

		InternalShow(bActivate);
	}

	const VsSiteCache& GetVsSiteCache() const
	{
		return m_VsSiteCache;
	}

	const PackageVsSiteCache& GetPackageVsSiteCache() const
	{
		return m_rPackageVsSiteCache;
	}

protected:

	IVsWindowFrame* GetIVsWindowFrame() const
	{
		return m_spIVsWindowFrame;
	}

private:
	static bool GetShowActivateDefault()
	{
		return true;
	}

	void InternalShow(bool bActivate)
	{
		Derived_T& rDerived = *(static_cast<Derived_T*>(this));
		(rDerived); // quite compiler warning

		__if_exists(Derived_T::PreShow)
		{
			rDerived.PreShow(bActivate);
		}

		if(bActivate)
		{
			VSL_CHECKHRESULT(m_spIVsWindowFrame->Show());
		}
		else
		{
			VSL_CHECKHRESULT(m_spIVsWindowFrame->ShowNoActivate());
		}

		__if_exists(Derived_T::PostShow)
		{
			rDerived.PostShow(bActivate);
		}
	}

	CComPtr<IVsWindowFrame> m_spIVsWindowFrame;
	VsSiteCache m_VsSiteCache;
	// REVIEW - if nothing besides Create ends up using this, remove this and just pass IVsUIShell 
	// to Create and CreateAndShow
	const PackageVsSiteCache& m_rPackageVsSiteCache;
};

template <class Derived_T>
class VsWindowFrameEventSink :
	public IVsWindowFrameNotify,
	public IVsWindowFrameNotify3
{

VSL_DECLARE_NOT_COPYABLE(VsWindowFrameEventSink)

protected:
	VsWindowFrameEventSink() :
		m_spFrame(NULL),
		m_cookie(0)
	{
	}

	virtual ~VsWindowFrameEventSink()
	{
		Unadvise();
	}

public:

	template <class VsSiteCache_T>
	void SetSite(const VsSiteCache_T& rVsSiteCache)
	{
		Unadvise();
		VSL_CHECKHRESULT(rVsSiteCache.QueryService(SID_SVsWindowFrame, &m_spFrame));
		VSL_CHECKHRESULT(m_spFrame->Advise(static_cast<IVsWindowFrameNotify*>(this), &m_cookie));
	}

	// The OnShow method is the same for the two notify interfaces.
	STDMETHOD(OnShow)(FRAMESHOW2 fShow)
	{
		VSL_STDMETHODTRY{

		(fShow); // quite compiler warning
		__if_exists(Derived_T::OnFrameShow)
		{
			static_cast<Derived_T*>(this)->OnFrameShow(fShow);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// Old version of the interface; the shell should detect that this object
	// implements IVsFrameNotify3 and never call this method.
	STDMETHOD(OnMove)()
	{
		VSL_TRACE(_T("IVsWindowFrameNotify::OnMove is not implemented\n"));

		return E_NOTIMPL;
	}

	// This is the new version (IVsFrameNotify3) of the OnMove event.
	STDMETHOD(OnMove)(int x, int y, int w, int h)
	{
		VSL_STDMETHODTRY{

		(x, y, w, h); // quite compiler warning
		__if_exists(Derived_T::OnFrameMove)
		{
			static_cast<Derived_T*>(this)->OnFrameMove(x, y, w, h);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// Old version of the interface; the shell should detect that this object
	// implements IVsFrameNotify3 and never call this method.
	STDMETHOD(OnSize)()
	{
		VSL_TRACE(_T("IVsWindowFrameNotify::OnSize is not implemented\n"));

		return E_NOTIMPL;
	}

	// This is the new version (IVsFrameNotify3) of the OnSize event.
	STDMETHOD(OnSize)(int x, int y, int w, int h)
	{
		VSL_STDMETHODTRY{

		(x, y, w, h); // quite compiler warning
		__if_exists(Derived_T::OnFrameSize)
		{
			static_cast<Derived_T*>(this)->OnFrameSize(x, y, w, h);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// Old version of the interface; the shell should detect that this object
	// implements IVsFrameNotify3 and never call this method.
	STDMETHOD(OnDockableChange)(BOOL /*fDockable*/)
	{
		VSL_TRACE(_T("IVsWindowFrameNotify::OnDockableChange is not implemented\n"));

		return E_NOTIMPL;
	}

	// This is the new version (IVsFrameNotify3) of the OnDockableChange event.
	STDMETHOD(OnDockableChange)(BOOL fDockable, int x, int y, int w, int h)
	{
		VSL_STDMETHODTRY{

		(fDockable, x, y, w, h); // quite compiler warning
		__if_exists(Derived_T::OnFrameDockableChange)
		{
			static_cast<Derived_T*>(this)->OnFrameDockableChange(fDockable, x, y, w, h);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(OnClose)(FRAMECLOSE *pgrfSaveOptions)
	{
		VSL_STDMETHODTRY{

		(pgrfSaveOptions);  // quite compiler warning
		__if_exists(Derived_T::OnFrameClose)
		{
			static_cast<Derived_T*>(this)->OnFrameClose(pgrfSaveOptions);
		}

		// If the frame is closing this sink have to remove itself from the list of
		// notification interfaces.
		Unadvise();

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

private:
	void Unadvise()
	{
		if(m_spFrame && (0 != m_cookie))
		{
			m_spFrame->Unadvise(m_cookie);
		}
		m_spFrame.Release();
		m_cookie = 0;
	}

	CComPtr<IVsWindowFrame2> m_spFrame;
	VSCOOKIE m_cookie;
};

// TODO - unit test this
template<class Derived_T, class VsSiteCache_T = VsSiteCacheLocal>
class IVsWindowPaneImpl :
	public IVsWindowPane
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowPaneImpl)

protected:

	typedef VsSiteCache_T VsSiteCache;

public:

	STDMETHOD(SetSite)(IServiceProvider* pSP)
	{
		VSL_STDMETHODTRY{

		IVsPackageEnums::SetSiteResult result = m_VsSiteCache.SetSite(pSP);
		(result); // Quite compiler warning

		__if_exists(Derived_T::PostSited)
		{
			if(result == IVsPackageEnums::Cached || result == IVsPackageEnums::AlreadyCached)
			{
				static_cast<Derived_T*>(this)->PostSited(result);
			}
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(GetDefaultSize)(SIZE* /*psize*/)
	{
		return E_NOTIMPL;
	}

	STDMETHOD(ClosePane)()
	{
		__if_exists(Derived_T::PostClosed)
		{
			static_cast<Derived_T*>(this)->PostClosed();
		}

		return S_OK;
	}

	STDMETHOD(LoadViewState)(IStream* /*pstream*/)
	{
		return E_NOTIMPL;
	}

	STDMETHOD(SaveViewState)(IStream* /*pstream*/)
	{
		return E_NOTIMPL;
	}

	STDMETHOD(TranslateAccelerator)(LPMSG /*lpmsg*/)
	{
		// This tells Visual Studio to process the message itself
		// Failing to return S_FALSE for unhandled message will
		// result in Visual Stuio becoming unresponsive
		return S_FALSE;
	}

	const VsSiteCache& GetVsSiteCache() const
	{
		return m_VsSiteCache;
	}

protected:

	VsSiteCache m_VsSiteCache;
};


template <WORD DialogResource_T>
class Dialog : public ATL::CDialogImpl<Dialog<DialogResource_T> >
{
public:
	enum { IDD = DialogResource_T };

	BEGIN_MSG_MAP(Dialog)
	END_MSG_MAP()
};


// Base implementation for tool window pane
template<class Derived_T, WORD DialogResource_T, class Window_T = Window<VSL::Dialog<DialogResource_T> >, class IVsWindowPaneImpl_T = IVsWindowPaneImpl<Derived_T> >
class VsWindowPaneFromResource :
	public IVsWindowPaneImpl_T,
	public Window_T
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VsWindowPaneFromResource)

public:

	STDMETHOD(CreatePaneWindow)(HWND hwndParent, int x, int y, int cx, int cy, HWND *phwnd)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(phwnd);

		*phwnd = NULL;

		Derived_T& rDerived = *(static_cast<Derived_T*>(this));
		(rDerived);

		LPARAM initParam = NULL;
		__if_exists(Derived_T::GetDialogInitParam)
		{
			initParam = rDerived.GetDialogInitParam();
		}

		Window_T::Create(hwndParent, initParam);
		VSL_CHECKBOOL_GLE(NULL != GetHWND());

		// REVIEW - test if the message was actually processed?
		MoveWindow(x, y, cx, cy, TRUE);
		ShowWindow(SW_SHOW);

		*phwnd = GetHWND();

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(TranslateAccelerator)(LPMSG lpmsg)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKBOOLEAN(NULL != GetHWND(), E_UNEXPECTED);

		// Check if the shell can process this message.
		CComPtr<IVsUIShell> spUiShell = m_VsSiteCache.GetCachedService<IVsUIShell, SID_SVsUIShell>();
		VSL_CHECKBOOLEAN(spUiShell != NULL, E_UNEXPECTED);
		HRESULT hr = spUiShell->TranslateAcceleratorAsACmd(lpmsg);
		VSL_CHECKHRESULT(hr);

		// The shell will return S_OK if it has proccessed the message, S_FALSE otherwise.
		if(S_OK != hr)
		{
			// If this is a dialog message, then we can handle it.
			VSL_SET_STDMETHOD_HRESULT(IsDialogMessage(lpmsg) ? S_OK : S_FALSE);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

};

// TODO - unit test this
template <class Derived_T, bool bSingleSelection_T = true, class DerivedForVsSiteCache_T = Derived_T>
class ISelectionContainerImpl :
	public ISelectionContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISelectionContainerImpl)

public:

	STDMETHOD(CountObjects)(DWORD dwFlags, ULONG *pCount)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(pCount);

		if(dwFlags & GETOBJS_ALL)
		{
			*pCount = static_cast<ULONG>(GetDerived()->GetItemsContainer().size());
		}
		else if(dwFlags & GETOBJS_SELECTED)
		{
			const Derived_T::ItemsContainer& rContainer = GetDerived()->GetItemsContainer();

			ULONG i = 0;

			for(Derived_T::ItemsContainer::const_iterator item = rContainer.begin(); 
				item < rContainer.end();
				++item)
			{
				if((*item)->GetCppClass().IsSelected())
				{
					++i;
				}
			}

			*pCount = i;
		}
		else
		{
			VSL_SET_STDMETHOD_HRESULT(E_INVALIDARG);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
    
	STDMETHOD(GetObjects)(DWORD dwFlags, ULONG cObjects, IUnknown **pUnknown)
	{
		VSL_STDMETHODTRY_EX(E_FAIL){

		VSL_CHECKPOINTER_DEFAULT(pUnknown);

		if(dwFlags & GETOBJS_ALL)
		{
			EnsureRequestInRange(cObjects);

			const Derived_T::ItemsContainer& rContainer = GetDerived()->GetItemsContainer();

			Derived_T::ItemsContainer::const_iterator item = rContainer.begin();

			for(unsigned int i = 0; 
				item < rContainer.end() && i < cObjects;
				++item, ++i)
			{
				CComPtr<IUnknown> spIUnknown;
				VSL_CHECKHRESULT((*item).QueryInterface(&spIUnknown));
				pUnknown[i] = spIUnknown.Detach();
			}

			return S_OK;
		}
		else if(dwFlags & GETOBJS_SELECTED)
		{
			const Derived_T::ItemsContainer& rContainer = GetDerived()->GetItemsContainer();

			for(Derived_T::ItemsContainer::const_iterator item = rContainer.begin(); 
				item < rContainer.end();
				++item)
			{
				if((*item)->GetCppClass().IsSelected())
				{
					CComPtr<IUnknown> spIUnknown;
					VSL_CHECKHRESULT((*item).QueryInterface(&spIUnknown));
					if(bSingleSelection_T)
					{
						EnsureRequestIsOne(cObjects);
						*pUnknown = spIUnknown.Detach();
						return S_OK;
					}
					else
					{
						C_ASSERT(bSingleSelection_T); // FUTURE - support multi-selection
					}
				}
			}
		}
		else
		{
			VSL_SET_STDMETHOD_HRESULT(E_INVALIDARG);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
    

	STDMETHOD(SelectObjects)(ULONG cSelect, IUnknown** apUnkSelect, DWORD dwFlags)
	{
        // This container can handle only one selected object out of a list of one selectable
        // objects, so all this method have to do is to check that the user is selecting
        // the only element in this container.
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(apUnkSelect);

		if(bSingleSelection_T)
		{
			EnsureRequestIsOne(cSelect);
			GetDerived()->SelectItem(*apUnkSelect);
		}
		else
		{
			EnsureRequestInRange(cSelect);
			C_ASSERT(bSingleSelection_T); // FUTURE - support multi-selection
		}

		if(dwFlags & SELOBJS_ACTIVATE_WINDOW)
		{
			CComPtr<IVsWindowFrame> spFrame;
			VSL_CHECKHRESULT(GetDerivedForVsSiteCache()->GetVsSiteCache().QueryService(SID_SVsWindowFrame, &spFrame));
			VSL_CHECKHRESULT(spFrame->Show());
		}

        }VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	void FireSelectionChange()
	{
		// In order to get to the STrackSelection service provider, we have to get the 
		// service provider the window was sited with, as selection traction is per window
		// and is not global, so it can't be done through the site provide to the package.
		CComPtr<ITrackSelection> spITrackSelection;
		HRESULT hr = GetDerivedForVsSiteCache()->GetVsSiteCache().QueryCachedService<ITrackSelection, SID_STrackSelection>(&spITrackSelection);
		VSL_CHECKHRESULT(hr);
		VSL_CHECKBOOLEAN(spITrackSelection != NULL, E_FAIL); // paranoid

		hr = spITrackSelection->OnSelectChange(this);
		VSL_CHECKHRESULT(hr);
	}

private:

	void EnsureRequestInRange(ULONG iRequested)
	{
		VSL_CHECKBOOLEAN(iRequested != 0 && iRequested <= GetDerived()->GetItemsContainer().size(), E_INVALIDARG);
	}

	void EnsureRequestIsOne(ULONG iRequested)
	{
		VSL_CHECKBOOLEAN(iRequested == 1, E_INVALIDARG);
	}

	Derived_T* GetDerived()
	{
		return static_cast<Derived_T*>(this);
	}

	DerivedForVsSiteCache_T* GetDerivedForVsSiteCache()
	{
		return static_cast<DerivedForVsSiteCache_T*>(this);
	}
};

template <class IDispatchInterface_T>
class IDispatchInterfaceToVsSelectionConainterItemAdapter
{

VSL_DECLARE_NOT_COPYABLE(IDispatchInterfaceToVsSelectionConainterItemAdapter)

public:

	IDispatchInterfaceToVsSelectionConainterItemAdapter()
	{
	}

	// Compiler generated destructor is sufficient

	IDispatchInterfaceToVsSelectionConainterItemAdapter& operator=(const CComPtr<IDispatchInterface_T>& rspToCopy)
	{
		m_spInterface = rspToCopy;
		return *this;
	}

	const IDispatchInterfaceToVsSelectionConainterItemAdapter* operator->() const
	{
		return this;
	}
	
	const IDispatchInterfaceToVsSelectionConainterItemAdapter& GetCppClass() const
	{
		return *this;
	}

	bool IsSelected() const
	{
		return true;
	}

	template <class Q>
	HRESULT QueryInterface(_Out_ Q** pp) const throw()
	{
		return m_spInterface.QueryInterface(pp);
	}

private:

	CComPtr<IDispatchInterface_T> m_spInterface;
};

template <class Derived_T, class IDispatchInterface_T>
class ISelectionContainerSingleItemImpl :
	public ISelectionContainerImpl<ISelectionContainerSingleItemImpl<Derived_T, IDispatchInterface_T>, true, Derived_T>
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISelectionContainerSingleItemImpl)

public:
	typedef VSL::StaticArray<IDispatchInterfaceToVsSelectionConainterItemAdapter<IDispatchInterface_T>, 1> ItemsContainer;

	// Called by ISelectionContainer::CountObjects and ISelectionContainer::GetObjects 
	// implemented by VSL::ISelectionContainerImpl
	ItemsContainer& GetItemsContainer()
	{
		return m_SelectionItemContainer;
	}

	// Called by ISelectionContainer::SelectObjects implemented on VSL::ISelectionContainerImpl 
	void SelectItem(IUnknown* /*apUnkSelect*/)
	{
		// Nothing to do, there is just one item, and it's always selected.
	}

private:

	ItemsContainer m_SelectionItemContainer;
};

template <
	class Derived_T,
	class VsSiteCache_T = IVsPackageImplDefaults<>::VsSiteCache>
class IVsEditorFactoryImpl :
	public VsSiteBaseImpl<Derived_T, IVsEditorFactoryImpl<Derived_T, VsSiteCache_T>, IVsEditorFactory, VsSiteCache_T>
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEditorFactoryImpl)

public:

	STDMETHOD(CreateEditorInstance)( 
		VSCREATEEDITORFLAGS grfCreateDoc,
		LPCOLESTR /*pszMkDocument*/,
		LPCOLESTR pszPhysicalView,
		_In_ IVsHierarchy* /*pvHier*/,
		VSITEMID /*itemid*/,
		_In_ IUnknown* punkDocDataExisting,
		_Out_ IUnknown** ppunkDocView,
		_Out_ IUnknown** ppunkDocData,
		_Deref_out_z_ BSTR* pbstrEditorCaption,
		_Out_ GUID* pguidCmdUI,
		_Out_ VSEDITORCREATEDOCWIN* pgrfCDW)
	{
		VSL_STDMETHODTRY{

		// Only open or silent is valid according to the interface specification
		VSL_CHECKBOOL(grfCreateDoc & (CEF_OPENFILE | CEF_SILENT), E_INVALIDARG);

		// Make sure all of the out parameters are valid and null them out.
		VSL_CHECKPOINTER(ppunkDocView, E_INVALIDARG);
		*ppunkDocView = NULL;

		VSL_CHECKPOINTER(ppunkDocData, E_INVALIDARG);
		*ppunkDocData = NULL;

		VSL_CHECKPOINTER(pbstrEditorCaption, E_INVALIDARG);
		*pbstrEditorCaption = NULL;

		VSL_CHECKPOINTER(pguidCmdUI, E_INVALIDARG);
		*pguidCmdUI = GUID_NULL;

		VSL_CHECKPOINTER(pgrfCDW, E_INVALIDARG);
		*pgrfCDW = 0;

		ErrorIfClosed();

		Derived_T& rDerived = *(static_cast<Derived_T*>(this));

		Derived_T::PhysicalViewId physicalViewID = 
			rDerived.GetPhysicalViewId(pszPhysicalView);

		if(physicalViewID == Derived_T::Unsupported)
		{
			return E_INVALIDARG;
		}

		if(!rDerived.CanShareBuffer(physicalViewID) && punkDocDataExisting != NULL)
		{
			// punkDocDataExisting not being NULL indicates that the buffer already
			// exists; however, if the derived class indicates it can not share the
			// buffer we return VS_E_INCOMPATIBLEDOCDATA so that VS will ask the 
			// user to close the existing document inorder to terminate the existing
			// buffer
			return VS_E_INCOMPATIBLEDOCDATA;
		}

		CComPtr<IUnknown> spDataObject;
		CComPtr<IUnknown> spViewObject;
		CComBSTR bstrEditorCaption;
		const GUID* pguidCommandUI = NULL;
		VSEDITORCREATEDOCWIN createDocumentWindowUI = 0;

		__if_exists(Derived_T::CreateDataAndViewObjects)
		{
			__if_exists(Derived_T::CreateSingleViewObject)
			{
				C_ASSERT(false); // Can't provide both multi-instance view and single view
			}
			rDerived.CreateDataAndViewObjects(
				physicalViewID, 
				spDataObject,
				spViewObject, 
				bstrEditorCaption, 
				pguidCommandUI, 
				createDocumentWindowUI);
		}
		__if_exists(Derived_T::CreateSingleViewObject)
		{
			rDerived.CreateSingleViewObject(
				physicalViewID, 
				spViewObject, 
				bstrEditorCaption, 
				pguidCommandUI, 
				createDocumentWindowUI);

			spDataObject = spViewObject;
		}

		VSL_CHECKPOINTER(spViewObject.p, E_FAIL);
		VSL_CHECKPOINTER(spDataObject.p, E_FAIL);
		VSL_CHECKPOINTER(pguidCommandUI, E_FAIL);

		// After this point, we need to continue execution to completion,
		// so that all parameters are properly set and nothing is leaked.
		// Anything that can realistically fail should be done before this point.

		*ppunkDocData = spDataObject.Detach();
		*ppunkDocView = spViewObject.Detach();

		*pbstrEditorCaption = bstrEditorCaption.Detach(); 

		*pguidCmdUI = *pguidCommandUI;

		if(createDocumentWindowUI != 0)
		{
			*pgrfCDW = createDocumentWindowUI;
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(MapLogicalView)( 
		REFGUID rguidLogicalView,
		_Deref_out_z_ BSTR* pbstrPhysicalView)
	{
		VSL_STDMETHODTRY_EX(E_NOTIMPL){ // must return E_NOTIMPL for any unrecognized rguidLogicalView values

		VSL_CHECKPOINTER(pbstrPhysicalView, E_INVALIDARG);
		*pbstrPhysicalView = NULL;

		ErrorIfClosed();

		__if_exists(Derived_T::GetPhysicalViewBSTR)
		{
			Derived_T& rDerived = *(static_cast<Derived_T*>(this));

			Derived_T::PhysicalViewId physicalViewID = 
				rDerived.GetPhysicalViewId(rguidLogicalView);

			if(physicalViewID != Derived_T::Unsupported)
			{
				*pbstrPhysicalView = rDerived.GetPhysicalViewBSTR(physicalViewID);
				return S_OK;
			}
		}
		__if_not_exists(Derived_T::GetPhysicalViewBSTR)
		{
			if(rguidLogicalView == LOGVIEWID_Primary)
			{
				*pbstrPhysicalView = ::SysAllocString(L"");
				return S_OK;
			}
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
};

} // namespace VSL

// NOTE - this should be an exact clone of ATL's BEGIN_MSG_MAP, except with a try
#define VSL_BEGIN_MSG_MAP(theClass) \
public: \
	BOOL ProcessWindowMessage(_In_ HWND hWnd, UINT uMsg, _In_ WPARAM wParam, _In_ LPARAM lParam, LRESULT& lResult, DWORD dwMsgMapID = 0) \
	{ \
		BOOL bHandled = TRUE; \
		(hWnd); \
		(uMsg); \
		(wParam); \
		(lParam); \
		(lResult); \
		(bHandled); \
		VSL_STDMETHODTRY { \
		switch(dwMsgMapID) \
		{ \
		case 0:

// NOTE - this should be an exact clone of ATL's END_MSG_MAP, except with a the VSL catch blocks
#define VSL_END_MSG_MAP() \
			break; \
		default: \
			ATLTRACE(ATL::atlTraceWindowing, 0, _T("Invalid message map ID (%i)\n"), dwMsgMapID); \
			ATLASSERT(FALSE); \
			break; \
		} \
		}VSL_STDMETHODCATCH() \
		return FALSE; \
	}

#endif // VSLWINDOWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
