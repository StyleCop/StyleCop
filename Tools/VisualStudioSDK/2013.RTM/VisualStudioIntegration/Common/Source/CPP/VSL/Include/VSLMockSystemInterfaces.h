/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLMOCKSYSTEMINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLMOCKSYSTEMINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>
#include <VSLErrorHandlers.h>

namespace VSL
{

template <class BaseClass_T>
class AddRefAndReleaseMockBase :
	public BaseClass_T
{

VSL_DECLARE_NOT_COPYABLE(AddRefAndReleaseMockBase)

private:

	LONG m_iRefCount;
	bool m_bRefCountBackToZero;

public:

	AddRefAndReleaseMockBase():
		m_iRefCount(0),
		m_bRefCountBackToZero(false)
	{
	}

	virtual ~AddRefAndReleaseMockBase()
	{
		const TCHAR* szNotReleased = _T("Mock object not fully released");
		if(m_iRefCount != 0)
		{
			if(IsDebuggerPresent() != 0)
			{
				DebugBreak();
			}
			VSL_TRACE(_T("ERROR: %s"), szNotReleased);
#ifndef VSL_UNIT_TEST_AddRefAndReleaseMockBase_Destructor_Supress_Assert
			VSL_UTASSERTEX(m_iRefCount == 0, _T("Mock object not fully released.  Ignoring this assert will frequently cause abnormal program termination."));
#endif
		}
		// This may cause terminate to get called, but we want to make sure the error doesn't get
		// ignored, so we live with that.
		VSL_CHECKBOOLEAN_EX(m_iRefCount == 0, E_FAIL, szNotReleased);
	}

	virtual ULONG STDMETHODCALLTYPE AddRef()
	{
		VSL_CHECKBOOLEAN_EX(!m_bRefCountBackToZero, E_FAIL, _T("Mock object AddRefed again after ref count arleady back to 0"));
		VSL_CHECKBOOLEAN_EX(m_iRefCount != LONG_MAX, E_FAIL, _T("Mock object AddRef ref counted beyond LONG_MAX"));
		::InterlockedIncrement(&m_iRefCount);
		return m_iRefCount;
	}
	virtual ULONG STDMETHODCALLTYPE Release()
	{
		VSL_CHECKBOOLEAN_EX(!m_bRefCountBackToZero, E_FAIL, _T("Mock object Releaseed again after ref count arleady back to 0"));
		if(m_bRefCountBackToZero && IsDebuggerPresent() != 0)
		{
			DebugBreak();
		}
		::InterlockedDecrement(&m_iRefCount);
		if(m_iRefCount == 0)
		{
			m_bRefCountBackToZero = true;
		}
		return m_iRefCount;
	}

	LONG GetRefCount() const
	{
		return m_iRefCount;
	}

	void SetRefCount(LONG iRefCount)
	{
		m_iRefCount = iRefCount;
	}
};

template <class PrimaryDerived_T = IUnknown>
class IUnknownInterfaceListTerminator
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUnknownInterfaceListTerminator)

protected:

	template<typename This_T>
	static IUnknown* InternalGetIUnknownNoAddRef(This_T* pThis)
	{
		// NOTE - getting an error like:
		//
		//   ambiguous conversions from 'IVsWindowFrameMock *' to 'IUnknown *'
		//
		// here indicates that PrimaryDerived_T need to be set to a parent
		// of your equivalent of IVsWindowFrameMock in this example error.
		//
		// The parent should have only one direct derivation path to IUnknown.
		return static_cast<IUnknown*>(static_cast<PrimaryDerived_T*>(pThis));
	}

public:

	enum { NumberOfInterfaces = 1 };

	template<typename This_T>
	static HRESULT InternalQueryInterface(This_T* pThis, REFIID iid, void** ppObject)
	{
		if(__uuidof(IUnknown) == iid)
		{
			*ppObject = InternalGetIUnknownNoAddRef(pThis);
			pThis->AddRef();
			return S_OK;
		}
		*ppObject = NULL;
		return E_NOINTERFACE;
	}
};

typedef IUnknownInterfaceListTerminator<> IUnknownInterfaceListTerminatorDefault;

template <class Interface_T, class Next_T, class PrimaryDerived_T = Interface_T>
class InterfaceList :
	public Interface_T,
	public Next_T
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(InterfaceList)

public:

	enum { NumberOfInterfaces = Next_T::NumberOfInterfaces + 1 };

	template<class This_T>
	static HRESULT InternalQueryInterface(This_T* pThis, REFIID iid, void** ppObject)
	{
		if(__uuidof(Interface_T) == iid)
		{
			*ppObject = static_cast<Interface_T*>(static_cast<PrimaryDerived_T*>(pThis));
			pThis->AddRef();
			return S_OK;
		}
		return Next_T::InternalQueryInterface(pThis, iid, ppObject);
	}
};

template <class InterfaceList_T, class ImplementationClass_T>
class QueryInterfaceMockBase :
	public InterfaceList_T
{

VSL_DECLARE_NOT_COPYABLE(QueryInterfaceMockBase)

public:

	QueryInterfaceMockBase() {}

	virtual ~QueryInterfaceMockBase() = 0 {}

	STDMETHOD(QueryInterface)(REFIID iid, void** ppObject)
	{
		if(ppObject == NULL)
		{
			return E_POINTER;
		}
		return InterfaceList_T::InternalQueryInterface(static_cast<ImplementationClass_T*>(this), iid, ppObject);
	}
};

template <class InterfaceList_T, class ImplementationClass_T>
class COMMockBase : 
	public AddRefAndReleaseMockBase<QueryInterfaceMockBase<InterfaceList_T, ImplementationClass_T> >
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(COMMockBase)

public:

	IUnknown* GetIUnknownNoAddRef()
	{
		return InternalGetIUnknownNoAddRef(static_cast<ImplementationClass_T*>(this));
	}
};

#define VSL_DECLARE_COM_MOCK(className, interfaceList) \
class className : \
	public COMMockBase<interfaceList , className>

template <class InterfaceImpl_T, class Next_T>
class InterfaceImplList :
	public InterfaceImpl_T,
	public Next_T
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(InterfaceImplList)

public:

	enum { NumberOfInterfaces = Next_T::NumberOfInterfaces + 1 };

	template<class This_T>
	static HRESULT InternalQueryInterface(This_T* pThis, REFIID iid, void** ppObject)
	{
		if(__uuidof(InterfaceImpl_T::Interface) == iid)
		{
			*ppObject = static_cast<InterfaceImpl_T::Interface*>(static_cast<InterfaceImpl_T*>(pThis));
			pThis->AddRef();
			return S_OK;
		}
		return Next_T::InternalQueryInterface(pThis, iid, ppObject);
	}
};

// If the mock object provides all of the interfaces itself
// AtlIServiceProviderImplAdaptor can be used to make use of
// ATL::IServiceProviderImpl should be utilized instead.
template <class Base_T>
class AtlIServiceProviderImplAdaptor :
	public ATL::IServiceProviderImpl<Base_T>
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(AtlIServiceProviderImplAdaptor)

public:

	typedef IServiceProvider Interface;
};

#define VSL_DEFINE_SERVICE_MOCK_EX(Name, InterfaceImplList, ServiceGuid) \
\
VSL_DECLARE_COM_MOCK(Name, InterfaceImplList) \
{ \
public: \
	static REFGUID GetServiceID() \
	{ \
		return ServiceGuid; \
	} \
}

// TODO - add ServiceGuid parameter to this, service GUID should always be specified
#define VSL_DEFINE_SERVICE_MOCK(Name, InterfaceImpl) \
typedef InterfaceImplList<InterfaceImpl, IUnknownInterfaceListTerminatorDefault> Name##InterfaceList; \
\
VSL_DEFINE_SERVICE_MOCK_EX(Name, Name##InterfaceList, __uuidof(InterfaceImpl::Interface))

class ServiceListTerminator
{
private:

	const ServiceListTerminator& operator=(const ServiceListTerminator& rToCopy);

public:

	// Allow use of compiler generated constructors and destructor

	enum { NumServices = 0 };

	HRESULT InternalQueryService(REFGUID /*serviceID*/, REFIID /*interfaceID*/, void** ppObject)
	{
		*ppObject = NULL;
		return E_NOINTERFACE;
	}
};

template <class Service_T, class Next_T>
class ServiceList
{
private:

	const ServiceList& operator=(const ServiceList& rToCopy);

public:

	enum { NumServices = Next_T::NumServices + 1 };

	// Allow use of compiler generated constructors and destructor
	ServiceList():
		m_Next(),
		m_Service()
	{
		m_Service.AddRef();
	}

	~ServiceList()
	{
		m_Service.Release();
	}

	HRESULT InternalQueryService(REFGUID serviceID, REFIID interfaceID, void** ppObject)
	{
		if(Service_T::GetServiceID() == serviceID)
		{
			return m_Service.QueryInterface(interfaceID, ppObject);
		}
		return m_Next.InternalQueryService(serviceID, interfaceID, ppObject);
	}

private:

	Next_T m_Next;
	Service_T m_Service;

};

// If the mock object aggregates the services as seperate objects
// IServiceProviderImpl needs to be used.
template <class ServiceList_T>
class IServiceProviderImpl :
	public IServiceProvider
{
private:

	ServiceList_T m_ServiceList;

public:
	typedef IServiceProvider Interface;

	STDMETHOD(QueryService)(REFGUID serviceID, REFIID interfaceID, void** ppObject)
	{
		if(ppObject == NULL)
		{
			return E_POINTER;
		}
		return m_ServiceList.InternalQueryService(serviceID, interfaceID, ppObject);
	}
};

// REVIEW - should this be in this file or a new one (VSLMock.h?)
// TODO - unit test this
template <const GUID* ServiceGuid_T>
class ServiceMockAdapter
{
public:
	static REFGUID GetServiceID()
	{
		return *ServiceGuid_T;
	}

	STDMETHOD(QueryInterface)(REFIID iid, void** ppObject)
	{
		return GetAdapted()->QueryInterface(iid, ppObject);
	}

	static CComPtr<IUnknown>& GetAdapted()
	{
		static CComPtr<IUnknown> pAdapted;
		return pAdapted;
	}

	ULONG AddRef()
	{
		// Do nothing, the owner of what pAdapted is set to need to ref count, it rather then the 
		// service list
		return 0;
	}

	ULONG Release()
	{
		// Do nothing, the owner of what pAdapted is set to need to ref count, it rather then the 
		// service list
		return 0;
	}
};

} // namespace VSL

#endif VSLMOCKSYSTEMINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5