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

#include "WindowFrameEventSinkTest.h"
#include <VSLWindows.h>

using namespace VSL;

typedef VSL::AddRefAndReleaseMockBase<TypeNull> RefCountedBase;

template <class Derived_T>
class TestSinkBase :
	public VSL::VsWindowFrameEventSink<Derived_T>,
	public RefCountedBase
{
public:
	virtual ULONG _stdcall AddRef() { return RefCountedBase::AddRef(); }
    virtual ULONG _stdcall Release() { return RefCountedBase::Release(); }
	STDMETHOD(QueryInterface)(REFGUID iid, void** ppOut)
	{
		if (NULL == ppOut)
		{
			return E_POINTER;
		}
		*ppOut = NULL;
		if ((IID_IUnknown == iid) || (IID_IVsWindowFrameNotify == iid))
		{
			*ppOut = static_cast<IVsWindowFrameNotify*>(this);
		}
		else if (IID_IVsWindowFrameNotify3 == iid)
		{
			*ppOut = static_cast<IVsWindowFrameNotify3*>(this);
		}
		else
		{
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}
};

class TestSinkNoEvents :
	public TestSinkBase<TestSinkNoEvents>
{
};

class TestSinkWithEvents :
	public TestSinkBase<TestSinkWithEvents>
{
public:
	enum EventType
	{
		OnShowEvent,
		OnMoveEvent,
		OnSizeEvent,
		OnDockableChangeEvent,
		OnCloseEvent
	};

	template <EventType event_T>
	bool& IsCalled()
	{
		static bool bIsCalled = false;
		return bIsCalled;
	}

	void OnFrameShow(FRAMESHOW2 /*fShow*/)
	{
		IsCalled<OnShowEvent>() = true;
	}

	void OnFrameMove(int /*x*/, int /*y*/, int /*w*/, int /*h*/)
	{
		IsCalled<OnMoveEvent>() = true;
	}

	void OnFrameSize(int /*x*/, int /*y*/, int /*w*/, int /*h*/)
	{
		IsCalled<OnSizeEvent>() = true;
	}

	void OnFrameDockableChange(BOOL /*fDockable*/, int /*x*/, int /*y*/, int /*w*/, int /*h*/)
	{
		IsCalled<OnDockableChangeEvent>() = true;
	}

	void OnFrameClose(FRAMECLOSE* /*pgrfSaveOptions*/)
	{
		IsCalled<OnCloseEvent>() = true;
	}
};

class WindowFrameServiceProvider :
	public VSL::IVsWindowFrameNotImpl,
	public VSL::IVsWindowFrame2NotImpl,
	public ATL::IServiceProviderImpl<WindowFrameServiceProvider>,
	public VSL::IVsShellNotImpl,
	public VSL::IVsUIShellNotImpl
{
public:

	BEGIN_SERVICE_MAP(WindowFrameServiceProvider)
		SERVICE_ENTRY(SID_SVsWindowFrame)
		SERVICE_ENTRY(SID_SVsShell)
		SERVICE_ENTRY(SID_SVsUIShell)
	END_SERVICE_MAP()

	virtual ULONG _stdcall AddRef() 
	{
		return ++m_uiRefCount;
	}
    virtual ULONG _stdcall Release() 
	{ 
		VSL_CHECKBOOL(0 < m_uiRefCount, E_FAIL);
		return --m_uiRefCount; 
	}
	STDMETHOD(QueryInterface)(REFGUID iid, void** ppOut)
	{
		if (NULL == ppOut)
		{
			return E_POINTER;
		}
		*ppOut = NULL;
		if ((IID_IUnknown == iid) || (IID_IVsWindowFrame == iid))
		{
			*ppOut = static_cast<IVsWindowFrame*>(this);
		}
		else if (IID_IVsWindowFrame2 == iid)
		{
			*ppOut = static_cast<IVsWindowFrame2*>(this);
		}
		else if (__uuidof(IVsShell) == iid)
		{
			*ppOut = static_cast<IVsShell*>(this);
		}
		else if (__uuidof(IVsUIShell) == iid)
		{
			*ppOut = static_cast<IVsUIShell*>(this);
		}
		else
		{
			return E_NOINTERFACE;
		}
		AddRef();
		return S_OK;
	}

	WindowFrameServiceProvider() :
		m_uiNextCookie(0),
		m_uiRefCount(0)
	{
	}

	~WindowFrameServiceProvider()
	{
		VSL_CHECKBOOL(0 == m_uiRefCount, E_FAIL);
		for (int i=0; i<s_MaxSubscriptions; ++i)
			VSL_CHECKBOOL(m_srpCallbacks[i]==NULL, E_FAIL);
	}

	STDMETHOD(CloseFrame)(FRAMECLOSE /*grfSaveOptions*/)
	{
		for (int i=0; i<s_MaxSubscriptions; ++i)
		{
			CComPtr<IVsWindowFrameNotify3> srpNotify;
			if ( (m_srpCallbacks[i] != NULL) && 
				 SUCCEEDED(m_srpCallbacks[i]->QueryInterface(IID_IVsWindowFrameNotify3, (void**)&srpNotify)) )
			{
				VSL_CHECKHRESULT(srpNotify->OnClose(0));
			}
		}
		return S_OK;
	}

	STDMETHOD(Advise)(IVsWindowFrameNotify* pNotify, VSCOOKIE* pdwCookie)
	{
		VSL_CHECKBOOL(NULL != pdwCookie, E_POINTER);
		m_srpCallbacks[m_uiNextCookie] = pNotify;
		++m_uiNextCookie;
		// Disable warning 6011 because prefast doesn't realize that VSL_CHECKBOOL will throw
		// if NULL == pdwCookie
		#pragma warning(push)
		#pragma warning(disable:6011)
		*pdwCookie = m_uiNextCookie;
		#pragma warning(pop)
		return S_OK;
	}
	STDMETHOD(Unadvise)(VSCOOKIE dwCookie)
	{
		UINT dwSubscription = (UINT)dwCookie;
		VSL_CHECKBOOL(dwSubscription <= s_MaxSubscriptions, E_UNEXPECTED);
		VSL_CHECKBOOL(dwSubscription > 0, E_UNEXPECTED);
		// Disable warning 6386 because prefast does not realize that an exception is thrown
		// if any of the previous tests fail.
		#pragma warning(push)
		#pragma warning(disable:6386)
		VSL_CHECKBOOL(m_srpCallbacks[dwSubscription-1]!=NULL, E_UNEXPECTED);
		m_srpCallbacks[dwSubscription-1].Release();
		#pragma warning(pop)
		return S_OK;
	}

private:
	UINT m_uiNextCookie;
	UINT m_uiRefCount;
	static const size_t s_MaxSubscriptions = 8; // 8 is arbitrary; this test will use at most 2 subscriptions.
	CComPtr<IVsWindowFrameNotify> m_srpCallbacks[s_MaxSubscriptions]; 
};

void WindowFrameEventsSinkTest::CheckSubscribeUnsubscribe()
{
// TODO - fix up the mock provider, so this will actually work
// Need to have the above use the standard mock infrastructure.
#if 0
	// Create the service provider that contains the window frame.
	WindowFrameServiceProvider providerWithWindowFrame;
	IServiceProvider* pProvider = static_cast<IServiceProvider*>(&providerWithWindowFrame);
	{
		CComPtr<IVsWindowFrame> spFrame;
		VSL_CHECKHRESULT(pProvider->QueryService(SID_SVsWindowFrame, IID_IVsWindowFrame, (void**)&spFrame));
		// Create the event sink
		TestSinkNoEvents sink;
		CComPtr<IVsWindowFrameNotify> spFrameNotify;
		VSL_CHECKHRESULT(sink.QueryInterface(IID_IVsWindowFrameNotify, (void**)&spFrameNotify));
		VsSiteCache<> cache;
		cache.SetSite(pProvider);
		// Check that calling it again will release the previous subscription.
		sink.SetSite(cache);
		spFrame->CloseFrame(0);
	}
#endif
}

void WindowFrameEventsSinkTest::CheckEvents()
{
	TestSinkWithEvents sink;
	// Get a pointer to the old interface.
	CComPtr<IVsWindowFrameNotify> spOldNotify;
	VSL_CHECKHRESULT(sink.QueryInterface(IID_IVsWindowFrameNotify, (void**)&spOldNotify));

	// Check that the methods specific of the old callback interface returns E_NOTIMPL.
	VSL_CHECKBOOL(E_NOTIMPL == spOldNotify->OnMove(), E_FAIL);
	VSL_CHECKBOOL(!sink.IsCalled<TestSinkWithEvents::OnMoveEvent>(), E_FAIL);

	VSL_CHECKBOOL(E_NOTIMPL == spOldNotify->OnSize(), E_FAIL);
	VSL_CHECKBOOL(!sink.IsCalled<TestSinkWithEvents::OnSizeEvent>(), E_FAIL);

	VSL_CHECKBOOL(E_NOTIMPL == spOldNotify->OnDockableChange(TRUE), E_FAIL);
	VSL_CHECKBOOL(!sink.IsCalled<TestSinkWithEvents::OnDockableChangeEvent>(), E_FAIL);

	// Now check that the method that is common to the two interfaces have the same effect.
	VSL_CHECKHRESULT(spOldNotify->OnShow(0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnShowEvent>(), E_FAIL);
	sink.IsCalled<TestSinkWithEvents::OnShowEvent>() = false;

	// Get the pointer to the new version of the interface.
	CComPtr<IVsWindowFrameNotify3> spNewNotify;
	VSL_CHECKHRESULT(sink.QueryInterface(IID_IVsWindowFrameNotify3, (void**)&spNewNotify));

	VSL_CHECKHRESULT(spNewNotify->OnShow(0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnShowEvent>(), E_FAIL);

	VSL_CHECKHRESULT(spNewNotify->OnMove(0, 0, 0, 0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnMoveEvent>(), E_FAIL);

	VSL_CHECKHRESULT(spNewNotify->OnSize(0, 0, 0, 0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnSizeEvent>(), E_FAIL);

	VSL_CHECKHRESULT(spNewNotify->OnDockableChange(TRUE, 0, 0, 0, 0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnDockableChangeEvent>(), E_FAIL);

	VSL_CHECKHRESULT(spNewNotify->OnDockableChange(TRUE, 0, 0, 0, 0));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnDockableChangeEvent>(), E_FAIL);

	FRAMECLOSE frameClose = 0;
	VSL_CHECKHRESULT(spNewNotify->OnClose(&frameClose));
	VSL_CHECKBOOL(sink.IsCalled<TestSinkWithEvents::OnCloseEvent>(), E_FAIL);
}

WindowFrameEventsSinkTest::WindowFrameEventsSinkTest(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	CheckSubscribeUnsubscribe();
	CheckEvents();
}
