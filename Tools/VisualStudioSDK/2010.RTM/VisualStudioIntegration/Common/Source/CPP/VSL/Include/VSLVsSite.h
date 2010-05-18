/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLVSSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLVSSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLCommon.h>

namespace VSL
{

// TODO - rename this to something more generic as it is used by all VS Site Caches (not just packages)
namespace IVsPackageEnums
{
	enum SetSiteResult {
		NothingCached,
		Cached,
		AlreadyCached,
		Cleared,
	};
};

class IServiceProviderRefCountGlobal
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(IServiceProviderRefCountGlobal)

private:
	class Private {}; // Used to make a private instatiation of GlobalRefCount
	typedef GlobalRefCount<Private> RefCount;
public:
	static bool CanDetach()
	{
		VSL_CHECKBOOLEAN(RefCount::CanDecrement(), E_UNEXPECTED);
		return (--RefCount::Get()) == 0;
	}
	static void RecordAttach()
	{
		VSL_CHECKBOOLEAN(RefCount::CanIncrement(), E_UNEXPECTED);
		++RefCount::Get();
	}
};

template <
	class BaseCache_T = LocalCache<PointerWithNullDefault<IServiceProvider> >,
	class IServiceProviderRefCount_T = TypeNull>
struct IServiceProviderCacheTraits
{
	typedef BaseCache_T BaseCache;
	typedef IServiceProviderRefCount_T IServiceProviderRefCount;
};

typedef IServiceProviderCacheTraits<> IServiceProviderCacheTraitsLocal;

template <class Traits_T = IServiceProviderCacheTraitsLocal >
class IServiceProviderCache :
	public Traits_T::BaseCache
{

VSL_DECLARE_NOT_COPYABLE(IServiceProviderCache)

public:

	typedef typename Traits_T::IServiceProviderRefCount IServiceProviderRefCount;
	typedef typename Traits_T::BaseCache Cache;

	enum { bIsGlobal = Cache::bIsGlobal };

	IServiceProviderCache()	{}

	~IServiceProviderCache()
	{
		__if_not_exists(Cache::IsGlobal)
		{

		if(Get() != NULL)
		{
			Get()->Release();
		}

		}
	}

	IVsPackageEnums::SetSiteResult SetSite(_In_ IServiceProvider* pServiceProvider)
	{
		CachedType& pCached = Get();
		if(pServiceProvider == NULL)
		{
			if(pCached != NULL)
			{
				__if_exists(IServiceProviderRefCount::CanDetach)
				{
				if(IServiceProviderRefCount::CanDetach())
				}
				{
					pCached->Release();
					pCached = NULL;
					return IVsPackageEnums::Cleared;
				}
			}
			return IVsPackageEnums::NothingCached;
		}

		__if_exists(IServiceProviderRefCount::RecordAttach)
		{
			IServiceProviderRefCount::RecordAttach();
		}

		if(pCached == NULL)
		{
			pCached = pServiceProvider;
			pCached->AddRef();
			return IVsPackageEnums::Cached;
		}

		VSL_ASSERT(pServiceProvider == pCached); // These should always be the same

		return IVsPackageEnums::AlreadyCached;
	}
};

typedef IServiceProviderCache<> IServiceProviderLocalCache;

typedef IServiceProviderCacheTraits<
	GlobalCache<PointerWithNullDefault<IServiceProvider> >, 
	IServiceProviderRefCountGlobal>
		IServiceProviderCacheTraitsGlobal;

typedef IServiceProviderCache<IServiceProviderCacheTraitsGlobal> IServiceProviderGlobalCache;

/*
FUTURE - Caches for Apartment threading model objects, Both threading model objects,
and Multithreaded threading model objects could also be supplied if needed.
*/

class CommonServiceCacheGlobal
{

VSL_DECLARE_NOT_COPYABLE(CommonServiceCacheGlobal)

public:
	enum
	{
		bIsGlobal = 1, // For run-time
		IsGlobal, // For compile-time
	};

	CommonServiceCacheGlobal() {}

	template<class Interface_T, REFGUID Service_T>
	CComPtr<Interface_T>& Get()
	{
		static CComPtr<Interface_T> pInterface;
		return pInterface;
	}

	template<class Interface_T, REFGUID Service_T>
	const CComPtr<Interface_T>& Get() const
	{
		return (*const_cast<CommonServiceCacheGlobal*>(this)).Get<Interface_T, Service_T>();
	}
};

class CommonServiceCacheLocal
{

VSL_DECLARE_NOT_COPYABLE(CommonServiceCacheLocal)

public:
	CommonServiceCacheLocal() {}

	template<class Interface_T, REFGUID Service_T>
	CComPtr<Interface_T>& Get()
	{
		// Intentionally left empty, as a compile error for this location indicates a missing
		// specialization below or an incorect usage.
#if 0
		static CComPtr<Interface_T> p;
		return p;
#endif
	}

	template<class Interface_T, REFGUID Service_T>
	const CComPtr<Interface_T>& Get() const
	{
		// Intentionally left empty, as a compile error for this location indicates a missing
		// specialization below or an incorect usage.
#if 0
		static CComPtr<Interface_T> p;
		return p;
#endif
	}

	template<>
	CComPtr<IVsShell>& Get<IVsShell, SID_SVsShell>()
	{
		return m_spIVsShell;
	}

	template<>
	CComPtr<IVsUIShell>& Get<IVsUIShell, SID_SVsUIShell>()
	{
		return m_spIVsUIShell;
	}

	template<>
	const CComPtr<IVsShell>& Get<IVsShell, SID_SVsShell>() const
	{
		return m_spIVsShell;
	}
	template<>
	const CComPtr<IVsUIShell>& Get<IVsUIShell, SID_SVsUIShell>() const
	{
		return m_spIVsUIShell;
	}
	
private:
	CComPtr<IVsShell> m_spIVsShell;
	CComPtr<IVsUIShell> m_spIVsUIShell;
};

class GeneralServiceCacheNotImplemented
{

VSL_DECLARE_NOT_COPYABLE(GeneralServiceCacheNotImplemented)

public:

	// Not being implemented qualifies as global
	enum
	{
		bIsGlobal = 1, // For run-time
		IsGlobal, // For compile-time
	};

	GeneralServiceCacheNotImplemented() {}

	~GeneralServiceCacheNotImplemented() {}

	void Clear() {}

	template<class Interface_T, REFGUID Service_T>
	Interface_T* Get() const
	{
		return NULL;
	}

};

/*
FUTURE - An implementation for a local general service cache could be supplied if needed.
*/

template <
	class IServiceProviderCache_T = IServiceProviderGlobalCache,
	class CommonServiceCache_T = CommonServiceCacheGlobal,
	class GeneralServiceCache_T = GeneralServiceCacheNotImplemented>
class VsSiteCache
{

VSL_DECLARE_NOT_COPYABLE(VsSiteCache)

public:

	typedef typename VsSiteCache<IServiceProviderCache_T, CommonServiceCache_T, GeneralServiceCache_T> This;
	typedef typename IServiceProviderCache_T IServiceProviderCache;
	typedef typename CommonServiceCache_T CommonServiceCache;
	typedef typename GeneralServiceCache_T GeneralServiceCache;

	VsSiteCache():
		m_IServiceProviderCache(),
		m_CommonServiceCache(),
		m_GeneralServiceCache()
	{
	}

	// Returns the site interface IServiceProvider or NULL if it is not set.
	// Caller should AddRef and Release the interface.
	IServiceProvider* GetSite() const
	{
		return m_IServiceProviderCache.Get();
	}

	IVsPackageEnums::SetSiteResult SetSite(_In_ IServiceProvider* pSeriveProvider)
	{
		IVsPackageEnums::SetSiteResult result = m_IServiceProviderCache.SetSite(pSeriveProvider);
		switch(result)
		{
		// TODO - see about using a static list to ensure the AddRefs and Releases are balanced
		case IVsPackageEnums::Cached:
			{
				// Pre-cache common interfaces
				VSL_CHECKHRESULT(QueryService(SID_SVsShell, &m_CommonServiceCache.Get<IVsShell, SID_SVsShell>()));
				VSL_CHECKHRESULT(QueryService(SID_SVsUIShell, &m_CommonServiceCache.Get<IVsUIShell, SID_SVsUIShell>()));
			}
			break;
		case IVsPackageEnums::Cleared:
			{
				// Tell any dependents we've been unsited.
				if(m_UnsitedDelegate.IsBound())
				{
					m_UnsitedDelegate();
				}

				// Clear out the common interfaces
				m_CommonServiceCache.Get<IVsShell, SID_SVsShell>().Release();
				m_CommonServiceCache.Get<IVsUIShell, SID_SVsUIShell>().Release();

				// Clear out the general cache
				m_GeneralServiceCache.Clear();
			}
			break;
		case IVsPackageEnums::NothingCached:
		case IVsPackageEnums::AlreadyCached:
			break;
		default:
			VSL_ASSERT(0); // This should never happen.
		}

		return result;
	}

	// Directly query for a service, by-passing the interface cache.
	// Caller must Release the interface.
	template <class Interface_T>
	HRESULT QueryService(REFGUID serviceID, _Out_ Interface_T** ppInterface) const
	{
		if(GetSite() == NULL)
		{
			return E_UNEXPECTED;
		}
		
		HRESULT hr = GetSite()->QueryService(serviceID, __uuidof(Interface_T), reinterpret_cast<void**>(ppInterface));

		if(SUCCEEDED(hr)) // TODO - 2/9/2006 - unit test this case
		{
			VSL_CHECKBOOLEAN(NULL != *ppInterface, E_NOINTERFACE);
		}

		return hr;
	}

	// Returns the service interface only if it already cached
	// Returns NULL otherwise.
	// Caller should AddRef and Release the interface.
	template <class Interface_T, REFGUID Service_T>
	Interface_T* GetCachedService() const
	{
		return m_GeneralServiceCache.Get<Interface_T, Service_T>();
	}

	template <>
	IVsShell* GetCachedService<IVsShell, SID_SVsShell>() const
	{
		return m_CommonServiceCache.Get<IVsShell, SID_SVsShell>();
	}

	template <>
	IVsUIShell* GetCachedService<IVsUIShell, SID_SVsUIShell>() const
	{
		return m_CommonServiceCache.Get<IVsUIShell, SID_SVsUIShell>();
	}

	// Returns an HRESULT. After the call, ppService will be pointing to a
	// pointer to the service interface or NULL if it can't be found.
	// Will try to get the interface from the cache first
	// and QueryService if necessary.  If QueryService is successful,
	// the interface will be cached in the general cache, if it is implemented.
	// Caller must Release the interface.
	template <class Interface_T, REFGUID Service_T>
	HRESULT QueryCachedService(_Out_ Interface_T** ppService) const
	{
		VSL_CHECKPOINTER_DEFAULT(ppService);

		HRESULT hr = S_OK;

		Interface_T* pService = GetCachedService<Interface_T, Service_T>();

		if(pService == NULL)
		{
			hr = QueryService(Service_T, &pService);

			__if_exists(GeneralServiceCache::Put)
			{

			if(SUCCEEDED(hr) && pService != NULL)
			{
				// Lazy cache general (non-common) interfaces
				const_cast<This*>(this)->m_GeneralServiceCache.Put<Interface_T, Service_T>(pService);
			}

			}
		}
		else
		{
			pService->AddRef();
		}

		*ppService = pService;

		return hr;
	}

	typedef Delegate<void ()> UnsitedDelegate;

	UnsitedDelegate& GetUnsited()
	{
		return m_UnsitedDelegate;
	}

private:

	IServiceProviderCache_T m_IServiceProviderCache;
	CommonServiceCache_T m_CommonServiceCache;
	GeneralServiceCache_T m_GeneralServiceCache;
__if_exists(IServiceProviderCache::IsGlobal)
{
	static
}
	UnsitedDelegate m_UnsitedDelegate;
};

typedef VsSiteCache<> VsSiteCacheGlobal;

__declspec(selectany) VsSiteCacheGlobal::UnsitedDelegate VsSiteCacheGlobal::m_UnsitedDelegate;

typedef VsSiteCache<
	IServiceProviderLocalCache, 
	CommonServiceCacheLocal >
		VsSiteCacheLocal;

// See equivalent method on VsSiteCache for usage.
// It is recommended that that VsSiteCache_T only be set to the default as provided
// VsSiteCache_T should not be set to VsSiteCacheLocal.
// VsSiteCache_T needs to be a global cache callable from the desired thread context.
// If VsSiteCache_T is set to something other then default GlobalVSServiceProvider
// will not function correctly, and VSL_GET_VSUISHELL_SERVICE will need to be defined
// such that it will function correctly.
template <class VsSiteCache_T = VsSiteCacheGlobal>
class VsIServiceProviderUtilities
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(VsIServiceProviderUtilities)

public:

	typedef VsSiteCache_T VsSiteCache;

	template <class Interface_T>
	static HRESULT QueryService(REFGUID serviceID, _Out_ Interface_T** ppInteface)
	{
		C_ASSERT(VsSiteCache_T::IServiceProviderCache::bIsGlobal);
		VsSiteCache_T cache;
		return cache.QueryService<Interface_T>(serviceID, ppInteface);
	}

	template <class Interface_T, REFGUID Service_T>
	static Interface_T* GetCachedService()
	{
		C_ASSERT(VsSiteCache_T::CommonServiceCache::bIsGlobal);
		VsSiteCache_T cache;
		return cache.GetCachedService<Interface_T, Service_T>();
	}

	template <class Interface_T, REFGUID Service_T>
	static HRESULT QueryCachedService(_Out_ Interface_T** ppService)
	{
		C_ASSERT(VsSiteCache_T::GeneralServiceCache::bIsGlobal);
		VsSiteCache_T cache;
		return cache.QueryCachedService<Interface_T, Service_T>(ppService);
	}

	static typename VsSiteCache_T::UnsitedDelegate& GetUnsited()
	{
		VsSiteCache_T cache;
		return cache.GetUnsited();
	}
};

#ifndef VSL_SERVICE_PROVIDER
#define VSL_SERVICE_PROVIDER VsIServiceProviderUtilities<>
#endif

// The purpose of this is to provide a class without defaulted template arguments
// for forward decleration at the top of VSLExceptions.h
class GlobalVSServiceProvider
{
public:
	static IVsUIShell* GetVsUIShellService()
	{
		return VSL_SERVICE_PROVIDER::GetCachedService<IVsUIShell, SID_SVsUIShell>();
	};
};

template <
	class DerivedClass_T,
	class DirectlyDerivedClass_T,
	class Base_T,
	class VsSiteCache_T = VsSiteCacheGlobal>
class VsSiteBaseImpl :
	public Base_T
{

VSL_DECLARE_NOT_COPYABLE(VsSiteBaseImpl)

protected:

	VsSiteBaseImpl():
		m_VsSiteCache(),
		m_bClosed(false)
	{
	}

	virtual ~VsSiteBaseImpl() = 0 {}

public:


	typedef VsSiteCache_T VsSiteCache;

    STDMETHOD(SetSite)(_In_ IServiceProvider* pIServiceProvider)
	{
		VSL_STDMETHODTRY{

		ErrorIfClosed();

		IVsPackageEnums::SetSiteResult result = m_VsSiteCache.SetSite(pIServiceProvider);
		switch(result)
		{
		case IVsPackageEnums::Cached:
			__if_exists(DirectlyDerivedClass_T::LoadUILibrary)
			{
				__if_exists(DirectlyDerivedClass_T::LoadUILibrary::ExtendedErrorInfo)
				{
					DirectlyDerivedClass_T::LoadUILibrary::LoadUILibrary(m_VsSiteCache, DerivedClass_T::GetLoadUILibraryErrorInfo());
				}
				__if_not_exists(DirectlyDerivedClass_T::LoadUILibrary::ExtendedErrorInfo)
				{
					DirectlyDerivedClass_T::LoadUILibrary::LoadUILibrary(m_VsSiteCache);
				}
			}
			__if_exists(DerivedClass_T::PostSited)
			{
				static_cast<DerivedClass_T*>(this)->PostSited(result);
			}
			break;
		case IVsPackageEnums::Cleared:
			__if_exists(DirectlyDerivedClass_T::LoadUILibrary)
			{
				DirectlyDerivedClass_T::LoadUILibrary::UnloadUILibrary();
			}
			break;
		case IVsPackageEnums::NothingCached:
			break;
		case IVsPackageEnums::AlreadyCached:
			__if_exists(DerivedClass_T::PostSited)
			{
				static_cast<DerivedClass_T*>(this)->PostSited(result);
			}
			break;
		default:
			VSL_ASSERT(0); // This should never happen.
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(GetSite)(_Out_ IServiceProvider **ppSP)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppSP, E_INVALIDARG);

		*ppSP = m_VsSiteCache.GetSite();

		VSL_CHECKPOINTER(*ppSP, E_UNEXPECTED); // called before site is set

		(*ppSP)->AddRef();

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
    STDMETHOD(QueryClose)(_Out_ BOOL* pbCanClose)
	{
		if(pbCanClose == NULL)
		{
			return E_POINTER;
		}

		*pbCanClose = TRUE;

		return S_OK;
	}

	// This is expected to be called only once per instance
    STDMETHOD(Close)()
	{
		VSL_STDMETHODTRY{

		ErrorIfClosed();

		__if_exists(DerivedClass_T::PreClosing)
		{
			static_cast<DerivedClass_T*>(this)->PreClosing();
		}

		SetSite(NULL);

		m_bClosed = true;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	VsSiteCache& GetVsSiteCache()
	{
		return m_VsSiteCache;
	}

protected:

	void ErrorIfClosed()
	{
		if(m_bClosed)
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}
	}

private:

	VsSiteCache m_VsSiteCache;
	bool m_bClosed;
};

} // namespace VSL

#endif // VSLVSSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
