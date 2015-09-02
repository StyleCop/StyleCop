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
#include "resource.h"

#include "VSLShortNameDefines.h"
#include "VSLPackage.h"
// TODO - 3/2/2006 - make a better home the automation unit tests
#include "VSLAutomation.h"

#include "Package.h"

using namespace VSL;

EXTERN_C const GUID g_FakeServiceGUID;
EXTERN_C const CComBSTR g_FakeString;

typedef PointerWithNullDefault<void> VoidPointerWithNullDefault;

class PointerWithNullDefaultTest :
	public UnitTestBase
{
public:
	PointerWithNullDefaultTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		VoidPointerWithNullDefault::Type pVoid = VoidPointerWithNullDefault::GetDefault();
		UTCHKEX(pVoid == NULL, L"pVoid is NULL after being set to the default");
	}
};

template <class Cache_T>
class CacheTestBase :
	public UnitTestBase
{
protected:
	void CheckCacheValue(Cache_T &cache, void* pVoid)
	{
		const Cache_T& rCache = cache;
		const Cache_T::CachedType& crpVoid = rCache.Get();
		UTCHK(crpVoid == pVoid);
		Cache_T::CachedType& rpVoid = cache.Get();
		UTCHK(rpVoid == pVoid);
	}
public:
	CacheTestBase(const char* const szTestName):
		UnitTestBase(szTestName)
	{
	}
};

typedef LocalCache<VoidPointerWithNullDefault> LocalCacheOfVoidPointer;
class LocalCacheTest :
	public CacheTestBase<LocalCacheOfVoidPointer>
{
public:
	LocalCacheTest(_In_opt_ const char* const szTestName):
		CacheTestBase(szTestName)
	{
		LocalCacheOfVoidPointer cache;
		CheckCacheValue(cache, NULL);
		void* pVoid = reinterpret_cast<void*>(1);
		cache.Set(pVoid);
		CheckCacheValue(cache, pVoid);

		// Make sure the cache is not global
		LocalCacheOfVoidPointer cache2;
		CheckCacheValue(cache2, NULL);
	}
};

typedef GlobalCache<VoidPointerWithNullDefault> GlobalCacheOfVoidPointer;
class GlobalCacheTest :
	public CacheTestBase<GlobalCacheOfVoidPointer>
{
public:
	GlobalCacheTest(_In_opt_ const char* const szTestName):
		CacheTestBase(szTestName)
	{
		GlobalCacheOfVoidPointer cache;
		CheckCacheValue(cache, NULL);
		void* pVoid = reinterpret_cast<void*>(1);
		cache.Set(pVoid);
		CheckCacheValue(cache, pVoid);

		// Make sure the cache is global
		GlobalCacheOfVoidPointer cache2;
		CheckCacheValue(cache2, pVoid);
	}
};

class GlobalRefCountTest :
	public UnitTestBase
{
public:
	GlobalRefCountTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(GlobalRefCount<int>::Get() == 0);
		UTCHK(GlobalRefCount<int>::CanIncrement() == true);
		UTCHK(GlobalRefCount<int>::CanDecrement() == false);
		++GlobalRefCount<int>::Get();
		UTCHK(GlobalRefCount<int>::Get() == 1);
		GlobalRefCount<int>::Count& iCount = GlobalRefCount<int>::Get();
		iCount -= 2;
		UTCHK(GlobalRefCount<int>::CanIncrement() == false);
		UTCHK(GlobalRefCount<int>::CanDecrement() == true);
		// Now make sure the values are unique by type
		UTCHK(GlobalRefCount<long>::Get() == 0);

		VSL_STDMETHODTRY{

		GlobalRefCount<int>::ErrorIfCanNotIncrement();

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
	}
};

class IVsPackageEnumsCompileTest :
	public UnitTestBase
{
public:
	IVsPackageEnumsCompileTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsPackageEnums::SetSiteResult values[] =
		{
			IVsPackageEnums::NothingCached,
			IVsPackageEnums::Cached,
			IVsPackageEnums::AlreadyCached,
			IVsPackageEnums::Cleared
		};
		C_ASSERT(ARRAYSIZE(values) == IVsPackageEnums::Cleared+1);
		(values);
	}
};

// NOTE - Unit tests for IServiceProviderRefCountGlobal and IServiceProviderRefCountNotImplemented
// are ommited, as they have trivial implementations and are fully tested by the unit tests for 
// IServiceProviderLocalCache and IServiceProviderGlobalCache

VSL_DEFINE_SERVICE_MOCK(IVsShellServiceMock, IVsShellNotImpl);
VSL_DEFINE_SERVICE_MOCK(IVsUIShellServiceMock, IVsUIShellNotImpl);

typedef ServiceList<IVsShellServiceMock, ServiceList<IVsUIShellServiceMock, ServiceListTerminator> > IServiceProviderServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IServiceProviderServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IServiceProviderMockInterfaceList;

VSL_DECLARE_COM_MOCK(IServiceProviderMock, IServiceProviderMockInterfaceList){};

class IServiceProviderLocalCacheTest :
	public UnitTestBase
{
private:
	void CycleStates(IServiceProviderLocalCache& cache)
	{
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		UTCHKEX(cache.SetSite(NULL) == IVsPackageEnums::NothingCached, NULL);
		UTCHKEX(cache.SetSite(spIServiceProvider) == IVsPackageEnums::Cached, NULL);
		UTCHKEX(cache.SetSite(spIServiceProvider) == IVsPackageEnums::AlreadyCached, NULL);
		UTCHKEX(cache.SetSite(NULL) == IVsPackageEnums::Cleared, NULL);
	}
public:
	IServiceProviderLocalCacheTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		// This needs to come before the cache decleration, so they get destructed in the correct order
		IServiceProviderMock mock;

		IServiceProviderLocalCache cache;
		// Cycle the states twice to make sure it doesn't break after just one cycle
		CycleStates(cache);
		CycleStates(cache);

		// Test the destructor, which should release this
		// (if not IServiceProviderMock's parent's destructor will complain)
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		UTCHKEX(cache.SetSite(spIServiceProvider) == IVsPackageEnums::Cached, NULL);
	}
};

class IServiceProviderGlobalCacheTest :
	public UnitTestBase
{
private:
	void CycleStates(IServiceProviderGlobalCache& cache)
	{
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		UTCHK(cache.SetSite(NULL) == IVsPackageEnums::NothingCached);
		UTCHK(cache.SetSite(spIServiceProvider) == IVsPackageEnums::Cached);
		UTCHK(cache.SetSite(spIServiceProvider) == IVsPackageEnums::AlreadyCached);
		UTCHK(cache.SetSite(NULL) == IVsPackageEnums::NothingCached);
		UTCHK(cache.SetSite(NULL) == IVsPackageEnums::Cleared);
	}

	void CycleStates2(IServiceProviderGlobalCache& cache1, IServiceProviderGlobalCache& cache2)
	{
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		UTCHK(cache1.SetSite(NULL) == IVsPackageEnums::NothingCached);
		UTCHK(cache2.SetSite(spIServiceProvider) == IVsPackageEnums::Cached);
		UTCHK(cache1.SetSite(spIServiceProvider) == IVsPackageEnums::AlreadyCached);
		UTCHK(cache2.SetSite(NULL) == IVsPackageEnums::NothingCached);
		UTCHK(cache1.SetSite(NULL) == IVsPackageEnums::Cleared);
	}
public:
	IServiceProviderGlobalCacheTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IServiceProviderGlobalCache cache;
		// Cycle the states twice to make sure it doesn't break after just one cycle
		CycleStates(cache);
		CycleStates(cache);

		// Now introduce a second cache, and cycle the states using both instances
		// but swap the roles the second time through.  Repeat the process twice,
		// just to make sure.
		IServiceProviderGlobalCache cache2;
		CycleStates2(cache, cache2);
		CycleStates2(cache2, cache);
		CycleStates2(cache, cache2);
		CycleStates2(cache2, cache);
	}
};

// NOTE - Unit tests for CommonServiceCacheGlobal and CommonServiceCacheLocal are ommited, as they
// are fully tested by the unit tests for VsSiteCacheTestGlobal and VsSiteCacheTestLocal

class GeneralServiceCacheLocalNotImplementedTest :
	public UnitTestBase
{
public:
	GeneralServiceCacheLocalNotImplementedTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		GeneralServiceCacheNotImplemented cache;

		IServiceProviderMock mock;
		CComQIPtr<IVsShell> spIVsShell = mock.GetIUnknownNoAddRef();

		__if_exists(GeneralServiceCacheNotImplemented::Put)
		{
			C_ASSERT(false); // Should not implement Put
		}
		UTCHK((cache.Get<IVsShell, SID_SVsShell>() == NULL));
		cache.Clear();
	}
};


template <class VSSiteCache_T>
class VsSiteCacheTest :
	public UnitTestBase
{
protected:

	void CheckUnsited(VSSiteCache_T& cache)
	{
		UTCHK(cache.GetSite() == NULL);

		CComPtr<IVsShell> spIVsShell;
		UTCHK(cache.QueryService(SID_SVsShell, &spIVsShell) == E_UNEXPECTED);

		CComPtr<IVsShell> spIVsShellCached;
		UTCHK((cache.QueryCachedService<IVsShell, SID_SVsShell>(&spIVsShellCached) == E_UNEXPECTED));
		UTCHK((spIVsShellCached == NULL));
		UTCHK((cache.GetCachedService<IVsShell, SID_SVsShell>() == NULL));
	}

	template <class Interface_T, REFGUID Service_T>
	void CheckQS(VSSiteCache_T& cache)
	{
		CComPtr<Interface_T> spInterface;
		UTCHK(cache.QueryService(Service_T, &spInterface) == S_OK);
		UTCHK(spInterface != NULL);
		
		spInterface.Release();
		UTCHK(SUCCEEDED((cache.QueryCachedService<Interface_T, Service_T>(&spInterface))));
		UTCHK(spInterface != NULL);
		UTCHK((spInterface = cache.GetCachedService<Interface_T, Service_T>()) != NULL);
	}

	void CheckAlreadySited(VSSiteCache_T& cache, IServiceProvider* pServiceProvider)
	{
		UTCHK(cache.GetSite() == pServiceProvider);

		IUnknown* pIUnknown;
		UTCHK(cache.QueryService(g_FakeServiceGUID, &pIUnknown) == E_NOINTERFACE);

		IUnknown* pIUnknownCached;
		UTCHK((cache.QueryCachedService<IUnknown, GUID_NULL>(&pIUnknownCached) == E_NOINTERFACE));
		UTCHK((pIUnknownCached == NULL));
		UTCHK((cache.GetCachedService<IUnknown, GUID_NULL>() == NULL));

		CheckQS<IVsShell, SID_SVsShell>(cache);
		CheckQS<IVsUIShell, SID_SVsUIShell>(cache);
	}

	void CheckSited(VSSiteCache_T& cache)
	{
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();

		cache.SetSite(spIServiceProvider);

		CheckAlreadySited(cache, spIServiceProvider);

		cache.SetSite(NULL);
	}

public:
	VsSiteCacheTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		VSSiteCache_T cache;
		CheckUnsited(cache);
		cache.SetSite(NULL);
		CheckUnsited(cache);

		// Cycle the state twice to make sure it doesn't breack after just one cycle
		CheckSited(cache);
		CheckUnsited(cache);
		CheckSited(cache);
		CheckUnsited(cache);
	}
};

class VsSiteCacheGlobalTest :
	public VsSiteCacheTest<VsSiteCacheGlobal>
{
public:
	VsSiteCacheGlobalTest(_In_opt_ const char* const szTestName):
		VsSiteCacheTest(szTestName)
	{
		VsSiteCacheGlobal cache1;

		VsSiteCacheGlobal cache2;
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		cache2.SetSite(spIServiceProvider);
		CheckAlreadySited(cache2, spIServiceProvider);

		// Make sure a the first global cache, which was not sited, is sited after the second is sited
		CheckAlreadySited(cache1, spIServiceProvider);

		// Make sure a new third global cache is sited after the second is sited
		VsSiteCacheGlobal cache3;
		CheckAlreadySited(cache3, spIServiceProvider);

		// Unsite through the third
		cache3.SetSite(NULL);

		// Make sure all three are now unsited
		CheckUnsited(cache1);
		CheckUnsited(cache2);
		CheckUnsited(cache3);
	}
};

class VsSiteCacheLocalTest :
	public VsSiteCacheTest<VsSiteCacheLocal>
{
public:
	VsSiteCacheLocalTest(_In_opt_ const char* const szTestName):
		VsSiteCacheTest(szTestName)
	{
		VsSiteCacheLocal cache1;

		VsSiteCacheLocal cache2;
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		cache2.SetSite(spIServiceProvider);
		CheckAlreadySited(cache2, spIServiceProvider);

		// Make sure the first Local cache, which was not sited, is still not sited after the second is sited
		CheckUnsited(cache1);

		// Make sure a new third Local cache is not sited now that one is sited
		VsSiteCacheLocal cache3;
		CheckUnsited(cache3);

		// Unsite the second
		cache2.SetSite(NULL);
		CheckUnsited(cache2);
	}
};

class VsIServiceProviderUtilitiesTest :
	public UnitTestBase
{
	void CheckUnsited()
	{
		CComPtr<IVsShell> spIVsShell;
		UTCHK(VsIServiceProviderUtilities<>::QueryService(
			SID_SVsShell,
			&spIVsShell) == E_UNEXPECTED);
		CComPtr<IVsShell> spIVsShellCached;
		UTCHK((VsIServiceProviderUtilities<>::QueryCachedService<IVsShell, SID_SVsShell>(&spIVsShellCached) == E_UNEXPECTED));
		UTCHK((spIVsShellCached == NULL));
		UTCHK((VsIServiceProviderUtilities<>::GetCachedService<IVsShell, SID_SVsShell>() == NULL));
	}
	template <class Interface_T, REFGUID Service_T>
	void CheckQS()
	{
		CComPtr<Interface_T> spInterface;
		UTCHK(VsIServiceProviderUtilities<>::QueryService(
			__uuidof(Interface_T),
			&spInterface) == S_OK);
		UTCHK(spInterface != NULL);
		
		spInterface.Release();
		UTCHK(SUCCEEDED((VsIServiceProviderUtilities<>::QueryCachedService<Interface_T, Service_T>(&spInterface))));
		UTCHK(spInterface != NULL);
		UTCHK((spInterface = VsIServiceProviderUtilities<>::GetCachedService<Interface_T, Service_T>()) != NULL);

		spInterface = NULL;
		UTCHK(VSQS(
			__uuidof(Interface_T),
			&spInterface) == S_OK);
		UTCHK(spInterface != NULL);
		spInterface.Release();
		UTCHK(SUCCEEDED((VSQCS(Service_T, Interface_T, &spInterface))));
		UTCHK(spInterface != NULL);
	}
public:
	VsIServiceProviderUtilitiesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		CheckUnsited();

		VsSiteCacheGlobal cache;
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		cache.SetSite(spIServiceProvider);

		CheckQS<IVsShell, SID_SVsShell>();
		CheckQS<IVsUIShell, SID_SVsUIShell>();

		cache.SetSite(NULL);
		CheckUnsited();
	}
};

#define RegPartSoftware L"Software"
#define RegPartMicrosoft L"Microsoft"
#define RegPartVisualStudio L"VisualStudio"
#define RegPartConfiguration L"Configuration"
#define MockRegRoot RegPartSoftware L"\\" RegPartMicrosoft L"\\" RegPartVisualStudio

class VsRegistryUtilitiesTest :
	public UnitTestBase
{
public:
	static const CComBSTR& GetRootBeginControlValue(bool isRanu = false)
	{
		static const CComBSTR bstr = 
			L" NoRemove " RegPartSoftware L"\n{\n"
			L" NoRemove " RegPartMicrosoft L"\n{\n"
			L" NoRemove " RegPartVisualStudio L"\n{\n";
		static const CComBSTR bstrRanu = 
			L" NoRemove " RegPartSoftware L"\n{\n"
			L" NoRemove " RegPartMicrosoft L"\n{\n"
			L" NoRemove " RegPartVisualStudio L"\n{\n"
			L" NoRemove " RegPartConfiguration L"\n{\n";
		if(isRanu)
		{
			return bstrRanu;
		}
		else
		{
			return bstr;
		}
	}
	static const CComBSTR& GetRootEndControlValue(bool isRanu = false)
	{
		static const CComBSTR bstr = L"\n}\n" L"\n}\n" L"\n}\n";
		static const CComBSTR bstrRanu = L"\n}\n" L"\n}\n" L"\n}\n" L"\n}\n";
		if(isRanu)
		{
			return bstrRanu;
		}
		else
		{
			return bstr;
		}
	}
private:
	void CheckGetRegHiveString()
	{
		CComBSTR bstrRegHive;
		VsRegistryUtilities::GetRegHiveString(bstrRegHive);
		UTCHK(bstrRegHive == L"HKCU");
	}
	void CheckGetRegRootStrings(bool isRanu = false)
	{
		CComBSTR bstrRootBegin;
		CComBSTR bstrRootEnd;
		VsRegistryUtilities::GetRegRootStrings(bstrRootBegin, bstrRootEnd);
		UTCHK(bstrRootBegin == GetRootBeginControlValue(isRanu));
		UTCHK(bstrRootEnd == GetRootEndControlValue(isRanu));
	}
	void CheckGetRegDefaultResourceStrings()
	{
		CComBSTR bstrResDllPath;
		CComBSTR bstrResDllName;
		VsRegistryUtilities::GetRegDefaultResourceStrings(bstrResDllPath, bstrResDllName);

		// bstrResDllName should be in the form of *UI.* where * does not have any colons or 
		// slashes
		CStringW szResDllName(bstrResDllName);
		UTCHK(szResDllName.FindOneOf(L"\\/:") == -1);
		bool bUIFound = false;
		if(bstrResDllPath)
		{
			for(wchar_t* psz = bstrResDllName; *psz != L'\0'; ++psz)
			{
				wchar_t character = *psz;
				if(character == L'.' && *(psz-1) == L'I' && *(psz-2) == L'U' && // find "UI."
					// Make sure there is at least one character on either side of "UI."
					*(psz+1) != L'\0' && (psz - static_cast<wchar_t*>(bstrResDllName)) >= 3)
				{
					bUIFound = true;
				}
			}
		}
		UTCHKEX(bUIFound, L"\"UI.\" not found in bstrResDllName");

		// bstrResDllPath should be a full path without the filename, so it should contain
		// at least one slash, and it should not end in bstrResDllName
		CStringW szResDllPath(bstrResDllPath);
		UTCHK(szResDllPath.FindOneOf(L"\\/") >= 0);
		UTCHK(szResDllPath.Find(bstrResDllName) == -1);
	}
public:
	VsRegistryUtilitiesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CheckGetRegRootStrings();

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED, 
			_T("VsRegistryUtilities::GetRegRootStrings didn't handle reg root not being set yet"));

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		CheckGetRegDefaultResourceStrings();

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == VSL_STDMETHOD_HRESULT_INIT,
			_T("VsRegistryUtilities::GetRegDefaultResourceStrings failed with reg root being NULL"));

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		VsRegistryUtilities::SetRegRoot(NULL);

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_POINTER,
			_T("VsRegistryUtilities::SetRegRoot failed to detect NULL arg"));

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		VsRegistryUtilities::SetRegRoot(L"");

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG,
			_T("VsRegistryUtilities::SetRegRoot failed to detect bad (empty string) arg"));

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		//                                   10        20        30        40        50        60
		wchar_t* sz65Characters = L"12345678901234567890123456789012345678901234567890123456789012345";
		VsRegistryUtilities::SetRegRoot(sz65Characters);
		CheckGetRegRootStrings();

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG,
			_T("VsRegistryUtilities::GetRegRootStrings failed to detect excessively long string"));

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		wchar_t* szBadRegPath = L" \\\\";
		VsRegistryUtilities::SetRegRoot(szBadRegPath);
		CheckGetRegRootStrings();

		}VSL_STDMETHODCATCH()

		UTCHKEX(VSL_GET_STDMETHOD_HRESULT() == E_INVALIDARG,
			_T("VsRegistryUtilities::GetRegRootStrings failed to detect bad reg path"));

		VsRegistryUtilities::SetRegRoot(MockRegRoot);
		CheckGetRegRootStrings();
		CheckGetRegDefaultResourceStrings();

		//Test that the HKCU hive is set in the RANU case
		VsRegistryUtilities::SetRegRoot(MockRegRoot, true);
		CheckGetRegRootStrings(true);
		CheckGetRegHiveString();
		CheckGetRegDefaultResourceStrings();

		VsRegistryUtilities::SetRegRoot(MockRegRoot L"\\");
		CheckGetRegRootStrings();
		CheckGetRegDefaultResourceStrings();
	}
};

class RegistryMacrosTest;

template <class Implementation_T>
class AtlModuleMock
{
public:

	HRESULT UpdateRegistryFromResourceS(
		UINT nResID,
		BOOL bRegister,
		struct _ATL_REGMAP_ENTRY* pMapEntries)
	{
		return Implementation_T::GetInstance()->UpdateRegistryFromResourceS(nResID, bRegister, pMapEntries);
	}
};

static AtlModuleMock<RegistryMacrosTest> _Module;

#define FAKEPLK 5
#define FAKEPLKASSTRING L"5"
#define EXP_TO_STRING(exp) L#exp

#define FAKESTRID 6
#define FAKESTRIDASSTRING L"#6"
#define FAKESTRING L"Test"

class RegistryMacrosTest :
	public UnitTestBase
{
public:

	enum
	{
		ExpectedMapEntries = 11,
		FakeResourceID = 100,
	};

	HRESULT UpdateRegistryFromResourceS(
		UINT nResID,
		BOOL bRegister,
		struct _ATL_REGMAP_ENTRY* pMapEntries)
	{
		UTCHK(nResID == FakeResourceID);
		UTCHK(bRegister == m_bRegister);
		for(size_t i = 0; i < ExpectedMapEntries; ++i)
		{
			if(pMapEntries[i].szData == NULL || pMapEntries[i].szKey == NULL)
			{
				UTCHKEX(i == ExpectedMapEntries-1, _T("NULL value found before expected end of map"));
				break;
			}
			if(i == ExpectedMapEntries-1)
			{
			}
			switch(i)
			{
			case 0:
				UTCHK(::wcscmp(pMapEntries[i].szKey, _VSL_SZ_REGROOTBEGIN) == 0);
				UTCHK(::wcscmp(pMapEntries[i].szData, VsRegistryUtilitiesTest::GetRootBeginControlValue()) == 0);
				break;
			case 1:
				UTCHK(::wcscmp(pMapEntries[i].szKey, _VSL_SZ_REGROOTEND) == 0);
				UTCHK(::wcscmp(pMapEntries[i].szData, VsRegistryUtilitiesTest::GetRootEndControlValue()) == 0);
				break;
			case 2:
				UTCHK(::wcscmp(pMapEntries[i].szKey, _VSL_SZ_REGHIVE) == 0);
				UTCHK(::wcscmp(pMapEntries[i].szData, L"HKLM") == 0);
				break;
			case 3:
				UTCHK(::wcscmp(pMapEntries[i].szKey, _VSL_SZ_RESOURCE_PATH) == 0);
				UTCHK(pMapEntries[i].szData[0] != L'\0'); // TODO - better test
				break;
			case 4:
				UTCHK(::wcscmp(pMapEntries[i].szKey, _VSL_SZ_RESOURCE_DLL) == 0);
				UTCHK(pMapEntries[i].szData[0] != L'\0'); // TODO - better test
				break;
			case 5:
				UTCHK(::wcscmp(pMapEntries[i].szKey, EXP_TO_STRING(g_FakeServiceGUID)) == 0);
				UTCHK(CComBSTR(pMapEntries[i].szData) == CComBSTR(g_FakeServiceGUID));
				break;
			case 6:
				UTCHK(::wcscmp(pMapEntries[i].szKey, EXP_TO_STRING(FAKEPLK)) == 0);
				UTCHK(::wcscmp(pMapEntries[i].szData, FAKEPLKASSTRING) == 0);
				break;
			case 7:
				{
				UTCHK(::wcscmp(pMapEntries[i].szKey, EXP_TO_STRING(IDS_SOURCENAME1)) == 0);
				CStringW strSourceName1;
				UTCHK(strSourceName1.LoadString(IDS_SOURCENAME1) == TRUE);
				UTCHK(::wcscmp(pMapEntries[i].szData, strSourceName1) == 0);
				}
				break;
			case 8:
				UTCHK(::wcscmp(pMapEntries[i].szKey, EXP_TO_STRING(FAKESTRID)) == 0);
				UTCHK(::wcscmp(pMapEntries[i].szData, FAKESTRIDASSTRING) == 0);
				break;
			case 9:
				UTCHK(::wcscmp(pMapEntries[i].szKey, EXP_TO_STRING(g_FakeString)) == 0);
				UTCHK(CComBSTR(pMapEntries[i].szData) == CComBSTR(g_FakeString));
				break;
			case ExpectedMapEntries-1:
				UTCHKEX(pMapEntries[i].szData == NULL && pMapEntries[i].szKey == NULL, _T("NULL values not found at end of map"));
				break;
			default:
				VSLASSERT(false); // should never happen
			}
		}
		return S_OK;
	}

	static RegistryMacrosTest*& GetInstance()
	{
		static RegistryMacrosTest* p = NULL;
		return p;
	}

	class ExTest
	{
	public:
	VSL_BEGIN_REGISTRY_MAP_EX(FakeResourceID)
		VSL_REGISTRY_MAP_REGROOT_ENTRY()
		VSL_REGISTRY_MAP_RESOURCEDLL_ENTRY()
		VSL_REGISTRY_MAP_GUID_ENTRY(g_FakeServiceGUID)
		VSL_REGISTRY_MAP_NUMBER_ENTRY(FAKEPLK)
		VSL_REGISTRY_RESOURCE_STRING_ENTRY(IDS_SOURCENAME1)
		VSL_REGISTRY_RESOURCEID_ENTRY(FAKESTRID)
		VSL_REGISTRY_MAP_STRING_ENTRY(g_FakeString)
	// NOTE - this has two implementations based on the presence of _Module
	// The _Module exists path is test here, and the other is tested in
	// the Package reference sample.
	VSL_END_REGISTRY_MAP() 
	};

	class SimpleTest
	{
	public:
	VSL_BEGIN_REGISTRY_MAP(FakeResourceID)
		VSL_REGISTRY_MAP_GUID_ENTRY(g_FakeServiceGUID)
		VSL_REGISTRY_MAP_NUMBER_ENTRY(FAKEPLK)
		VSL_REGISTRY_RESOURCE_STRING_ENTRY(IDS_SOURCENAME1)
		VSL_REGISTRY_RESOURCEID_ENTRY(FAKESTRID)
		VSL_REGISTRY_MAP_STRING_ENTRY(g_FakeString)
	// NOTE - this has two implementations based on the presence of _Module
	// The _Module exists path is test here, and the other is tested in
	// the Package reference sample.
	VSL_END_REGISTRY_MAP() 
	};

	RegistryMacrosTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName),
		m_bRegister(TRUE)
	{
		GetInstance() = this;

		VsRegistryUtilities::SetRegRoot(MockRegRoot);

		ExTest::UpdateRegistry(m_bRegister);
		m_bRegister = FALSE;
		ExTest::UpdateRegistry(m_bRegister);

		m_bRegister = TRUE;
		SimpleTest::UpdateRegistry(m_bRegister);
		m_bRegister = FALSE;
		SimpleTest::UpdateRegistry(m_bRegister);
	}
private:
	BOOL m_bRegister;
};

typedef InterfaceImplList<IVsShellMockImpl, IUnknownInterfaceListTerminatorDefault> IVsShellLoadUILibraryMockInterfaceList;

VSL_DECLARE_COM_MOCK(IVsShellLoadUILibraryMock, IVsShellLoadUILibraryMockInterfaceList){};

class VsShellUtilitiesTest :
	public UnitTestBase
{
private:
	HMODULE GetSystemDll()
	{
		static HMODULE hDll = ::LoadLibraryExW(L"ksuser.dll", NULL, LOAD_LIBRARY_AS_DATAFILE);
		CHKHANDLEGLE(hDll);
		return hDll;
	}
	void CheckResourceInstance(HINSTANCE hModule)
	{
        HINSTANCE hResource = _AtlBaseModule.GetResourceInstance();
		UTCHK(hResource == hModule);
	}
public:
	VsShellUtilitiesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		// Verify calling UnloadUILibrary before LoadUILibrary is safe
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());
		VsShellUtilities::UnloadUILibrary();
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());

		// Verify that passing a NULL IVsShell* is handled
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		VsShellUtilities invalid(NULL);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_POINTER);

		IVsShellLoadUILibraryMock mock;
		CComQIPtr<IVsShell> spIVsShell = mock.GetIUnknownNoAddRef();
		VsShellUtilities util(spIVsShell);

		// Verify that creating a instance has no global effect
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());
		VsShellUtilities::UnloadUILibrary();
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());

		// Verify that LoadUILibrary handles VS failure properly
		PushIVsShellLoadUILibrary(g_FakeServiceGUID, NULL, E_FAIL);
		UTCHK(util.LoadUILibrary(g_FakeServiceGUID) == E_FAIL);
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());

		// Verify that LoadUILibrary handles VS returning NULL without failing
		DWORD_PTR pdwMock = NULL;
		PushIVsShellLoadUILibrary(g_FakeServiceGUID, &pdwMock);
		UTCHK(util.LoadUILibrary(g_FakeServiceGUID) == E_UNEXPECTED);
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());

		// Verify that LoadUILibrary works
		pdwMock = reinterpret_cast<DWORD_PTR>(GetSystemDll());
		PushIVsShellLoadUILibrary(g_FakeServiceGUID, &pdwMock);
		UTCHK(util.LoadUILibrary(g_FakeServiceGUID) == S_OK);
		CheckResourceInstance(GetSystemDll());

		// Verify that UnloadUILibrary throws if
		// _AtlBaseModule.GetResourceInstance() == _AtlBaseModule.GetModuleInstance()
		_AtlBaseModule.SetResourceInstance(_AtlBaseModule.GetModuleInstance());
		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		VsShellUtilities::UnloadUILibrary();

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
		_AtlBaseModule.SetResourceInstance(GetSystemDll());

		// Verify that LoadUILibrary can be called again
		UTCHK(util.LoadUILibrary(g_FakeServiceGUID) == S_OK);
		CheckResourceInstance(GetSystemDll());

		// Verify that UnloadUILibrary will not unload if the still ref counted
		VsShellUtilities::UnloadUILibrary();
		CheckResourceInstance(GetSystemDll());

		// Verify that UnloadUILibrary will unload on last decrement of ref count
		VsShellUtilities::UnloadUILibrary();
		CheckResourceInstance(_AtlBaseModule.GetModuleInstance());
	}
};

typedef InterfaceImplList<IVsUIShellMockImpl, IUnknownInterfaceListTerminatorDefault> IVsUIShellMockInterfaceList;

VSL_DECLARE_COM_MOCK(IVsUIShellMock, IVsUIShellMockInterfaceList){};

// TODO move this to ErrorAndExceptionHandling
// Update it to reflect current design.
class VsReportErrorUtilitiesTest :
	public UnitTestBase
{
public:
	VsReportErrorUtilitiesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IVsUIShellMock mock;
		CComQIPtr<IVsUIShell> spIVsUIShell = mock.GetIUnknownNoAddRef();

		CREATEVV(IVsUIShell, SetErrorInfo, values)
		{
			E_FAIL,
			VVNOT0(LPCOLESTR),
			0,
			NULL,
			NULL,
			E_FAIL
		};
		SETVV(values);

		SETVV2(IVsUIShell, ReportErrorInfo, E_FAIL, S_OK);

		const UINT iBogusResourceID = 300000000;

		// Test that passing a NULL IVsUIShell* is handled without crashing
		VsReportErrorUtilities<> invalid(NULL);
		invalid.ReportExtendedError(E_FAIL, iBogusResourceID);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 0));
		invalid.ReportStandardError(values.hr);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 0));

		// Now test a it when properly initialized
		VsReportErrorUtilities<> util(spIVsUIShell);

		// Test that iErrorMessageID not being found is handled
		util.ReportExtendedError(E_FAIL, iBogusResourceID, true);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test that iSourceID not being found is handled
		CStringW szErrorMessage;
		UTCHK(szErrorMessage.LoadString(IDS_E_ERRORMESSAGE) == TRUE);
		values.pszDescription = szErrorMessage;

		util.ReportExtendedError(E_FAIL, IDS_E_ERRORMESSAGE, true, NULL, iBogusResourceID);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test that IVsUIShell::SetErrorInfo failing is handled
		util.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test that IVsUIShell::ReportErrorInfo failing is handled
		values.retValue = S_OK;
		SETVV2(IVsUIShell, ReportErrorInfo, E_FAIL, E_UNEXPECTED);

		util.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test the 2 parameter success case
		values.retValue = S_OK;

		util.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test the 3 parameter success case
		values.pszHelpKeyword = L"TestKeyWord";
		util.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true, values.pszHelpKeyword);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test the 4 parameter success case
		CStringW szSourceName1;
		UTCHK(szSourceName1.LoadString(IDS_SOURCENAME1) == TRUE);
		values.pszSource = szSourceName1;
		util.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true, values.pszHelpKeyword, IDS_SOURCENAME1);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Test the 3 parameter, non-default template parameter success case
		VsReportErrorUtilities<IDS_SOURCENAME2> util2(spIVsUIShell);
		CStringW szSourceName2;
		UTCHK(szSourceName2.LoadString(IDS_SOURCENAME2) == TRUE);
		values.pszSource = szSourceName2;
		util2.ReportExtendedError(values.hr, IDS_E_ERRORMESSAGE, true, values.pszHelpKeyword);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Set the system error info
		ICreateErrorInfo *pICreateErrorInfo = NULL;
		UTCHK(S_OK == ::CreateErrorInfo(&pICreateErrorInfo));
		CComQIPtr<IErrorInfo> spIErrorInfo = pICreateErrorInfo;
		UTCHK(spIErrorInfo != NULL);
		UTCHK(S_OK == ::SetErrorInfo(0, spIErrorInfo));

		// Test ReportStandardError and ensure it calls IVsUIShell::ReportErrorInfo
		util2.ReportStandardError(values.hr, true);
		UTCHK(WASCALLED(IVsUIShell, ReportErrorInfo, 1));

		// Make sure that the system error info was cleared
		IErrorInfo *pIErrorInfo = NULL;
		++pIErrorInfo;
		UTCHK(S_FALSE == ::GetErrorInfo(0, &pIErrorInfo));
		UTCHK(pIErrorInfo == NULL);
	}
};

VSL_DEFINE_SERVICE_MOCK(IVsShellServiceMockImpl, IVsShellMockImpl);
VSL_DEFINE_SERVICE_MOCK(IVsUIShellErrorsServiceMock, IVsUIShellMockImpl);

typedef ServiceList<IVsShellServiceMockImpl, ServiceList<IVsUIShellErrorsServiceMock, ServiceListTerminator> > IServiceProviderVsUIShellErrorsServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IServiceProviderVsUIShellErrorsServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IServiceProviderVsUIShellErrorsMockInterfaceList;

VSL_DECLARE_COM_MOCK(IServiceProviderVsUIShellErrorsMock, IServiceProviderVsUIShellErrorsMockInterfaceList){};

class LoadUILibraryRequiredTest :
	public UnitTestBase
{
private:
	HMODULE GetSystemDll()
	{
		static HMODULE hDll = ::LoadLibraryExW(L"ksuser.dll", NULL, LOAD_LIBRARY_AS_DATAFILE);
		CHKHANDLEGLE(hDll);
		return hDll;
	}
public:
	LoadUILibraryRequiredTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IServiceProviderVsUIShellErrorsMock mock;
		VsSiteCacheGlobal cache;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();
		cache.SetSite(spIServiceProvider);

		CComPtr<IVsUIShell> spIVsUIShell = cache.GetCachedService<IVsUIShell, SID_SVsUIShell>();

		ExtendedErrorInfo errorInfo(IDS_E_ERRORMESSAGE);

		// Test the failure case
		CStringW szErrorMessage;
		UTCHK(szErrorMessage.LoadString(IDS_E_ERRORMESSAGE) == TRUE);

		CREATEVV(IVsUIShell, SetErrorInfo, values)
		{
			E_FAIL,
			VVNOT0(LPCOLESTR),
			0,
			NULL,
			NULL,
			E_FAIL
		};
		SETVV(values);

		SETVV2(IVsUIShell, ReportErrorInfo, E_FAIL, S_OK);

		PushIVsShellLoadUILibrary(g_FakeServiceGUID, NULL, E_FAIL);

		typedef LoadUILibraryRequired<
			&g_FakeServiceGUID, 
			VsSiteCacheGlobal, 
			VsShellUtilities, 
			VsReportErrorUtilities<> > LoaderFail;

		VSL_STDMETHODTRY
		{

		LoaderFail::LoadUILibrary(cache, errorInfo);

		}VSL_STDMETHODCATCH()
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_FAIL);

		LoaderFail::UnloadUILibrary();

		DWORD_PTR pdwMock = reinterpret_cast<DWORD_PTR>(GetSystemDll());
		PushIVsShellLoadUILibrary(g_FakeServiceGUID, &pdwMock, S_OK);

		// Test the success case
		typedef LoadUILibraryRequired<
			&g_FakeServiceGUID, 
			VsSiteCacheGlobal, 
			VsShellUtilities, 
			VsReportErrorUtilities<> > Loader;

		Loader::LoadUILibrary(cache, errorInfo);
		Loader::UnloadUILibrary();

		cache.SetSite(NULL);
	}
};

// NOTE LoadUILibraryNoop is not unit tested as it does nothing and it's ability to compile is 
// validated by IVsPackageImplLoadUILibraryNoopTest

class LoadUILibraryRequiredMock
{

	VSL_DECLARE_NOT_COPYABLE(LoadUILibraryRequiredMock)

public:

	typedef ExtendedErrorInfo ExtendedErrorInfo;

	typedef GlobalRefCount<IServiceProviderRefCountGlobal, int> RefCount;

	LoadUILibraryRequiredMock(IVsShell* pIVsShell)
	{
		CHK(pIVsShell != NULL, E_POINTER);
	}

	static UnitTestBase*& GetUnitTestBase()
	{
		static UnitTestBase* pUnitTestBase = NULL;
		return pUnitTestBase;
	}

	static void LoadUILibrary(
		const VsSiteCacheGlobal& rVsSiteCache,
		const ExtendedErrorInfo& rExtendedErrorInfo)
	{
		CComPtr<IVsShell> spIVsShell = rVsSiteCache.GetCachedService<IVsShell, SID_SVsShell>();
		UTHCHK((spIVsShell != NULL), GetUnitTestBase());
		CComPtr<IVsUIShell> spIVsUIShell = rVsSiteCache.GetCachedService<IVsUIShell, SID_SVsUIShell>();
		UTHCHK((spIVsUIShell != NULL), GetUnitTestBase());
		UTHCHK((rExtendedErrorInfo.GetDescriptionID() == IDS_E_ERRORMESSAGE), GetUnitTestBase());
#if 0 - FUTURE
		UTHCHK((rExtendedErrorInfo.GetHelpKeyword() == NULL), GetUnitTestBase());
		UTHCHK((rExtendedErrorInfo.GetSourceID() == 0), GetUnitTestBase());
#endif
		++RefCount::Get();
	}

	static void UnloadUILibrary()
	{
		--RefCount::Get();
	}
};

template <class DeriveClass_T, class LoadUILibrary_T>
class IVsPackageImplTestBase :
	public UnitTestBase
{
protected:

	virtual ~IVsPackageImplTestBase() {}

	void Test()
	{
		__if_exists(DeriveClass_T::GetLoadUILibraryErrorInfo)
		{
			LoadUILibrary_T::GetUnitTestBase() = this;
		}

		IVsPackage* pIVsPackage = dynamic_cast<IVsPackage*>(this);
		UTCHK(pIVsPackage->SetSite(NULL) == S_OK);

		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();

		UTCHK(pIVsPackage->SetSite(spIServiceProvider) == S_OK);
		__if_exists(DeriveClass_T::GetLoadUILibraryErrorInfo)
		{
			UTCHK(LoadUILibrary_T::RefCount::Get() == 1);
		}

		DeriveClass_T::VsSiteCache& rVsSiteCache = dynamic_cast<DeriveClass_T*>(this)->GetVsSiteCache();
		CComPtr<IServiceProvider> spCachedIServiceProvider = rVsSiteCache.GetSite();
		UTCHK(spCachedIServiceProvider == spIServiceProvider);

		UTCHK(pIVsPackage->QueryClose(NULL) == E_POINTER);
		BOOL bCanClose = FALSE;
		UTCHK(pIVsPackage->QueryClose(&bCanClose) == S_OK);
		UTCHK(bCanClose == TRUE);

		UTCHK(pIVsPackage->GetAutomationObject(NULL, NULL) == E_POINTER);
		IDispatch* pDispatch = NULL;
		++pDispatch;
		UTCHK(pIVsPackage->GetAutomationObject(NULL, &pDispatch) == E_NOTIMPL);
		UTCHK(pDispatch == NULL);

		UTCHK(pIVsPackage->CreateTool(g_FakeServiceGUID) == E_NOTIMPL);
		UTCHK(pIVsPackage->ResetDefaults(0) == E_NOTIMPL);
		VSPROPSHEETPAGE page;
		UTCHK(pIVsPackage->GetPropertyPage(g_FakeServiceGUID, &page) == E_NOTIMPL);

		UTCHK(pIVsPackage->Close() == S_OK);
		__if_exists(DeriveClass_T::GetLoadUILibraryErrorInfo)
		{
		UTCHK(LoadUILibrary_T::RefCount::Get() == 0);
		}

		UTCHK(pIVsPackage->Close() == E_UNEXPECTED);
		__if_exists(DeriveClass_T::GetLoadUILibraryErrorInfo)
		{
		UTCHK(LoadUILibrary_T::RefCount::Get() == 0);
		}

		UTCHK(pIVsPackage->SetSite(NULL) == E_UNEXPECTED);
		__if_exists(DeriveClass_T::GetLoadUILibraryErrorInfo)
		{
		UTCHK(LoadUILibrary_T::RefCount::Get() == 0);
		}
	}
public:
	IVsPackageImplTestBase(const char* const szTestName):
		UnitTestBase(szTestName)
	{
	}
};

class IVsPackageImplTest :
	public IVsPackageImplTestBase<IVsPackageImplTest, LoadUILibraryRequiredMock>,
	public IVsPackageImpl<IVsPackageImplTest, &g_FakeServiceGUID, VsSiteCacheGlobal, LoadUILibraryRequiredMock>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	static const LoadUILibrary::ExtendedErrorInfo& GetLoadUILibraryErrorInfo()
	{
		static LoadUILibrary::ExtendedErrorInfo errorInfo(IDS_E_ERRORMESSAGE);
		return errorInfo;
	}

	IVsPackageImplTest(_In_opt_ const char* const szTestName):
		IVsPackageImplTestBase(szTestName)
	{
		Test();
	}
};

class IVsPackageImplLoadUILibraryNoopTest :
	public IVsPackageImplTestBase<IVsPackageImplLoadUILibraryNoopTest, LoadUILibraryNoop<VsSiteCacheGlobal> >,
	public IVsPackageImpl<IVsPackageImplLoadUILibraryNoopTest, &g_FakeServiceGUID, VsSiteCacheGlobal, LoadUILibraryNoop<VsSiteCacheGlobal> >
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsPackageImplLoadUILibraryNoopTest(_In_opt_ const char* const szTestName):
		IVsPackageImplTestBase(szTestName)
	{
		Test();
	}
};

class IVsPackageImplSetSiteEventsTest :
	public IVsPackageImpl<IVsPackageImplSetSiteEventsTest, &g_FakeServiceGUID, VsSiteCacheGlobal, LoadUILibraryNoop<VsSiteCacheGlobal> >,
	public UnitTestBase
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsPackageImplSetSiteEventsTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName),
		m_bPostSitedCalled(false)
	{
		// Test that PostSited is called when SetSite is called and that the
		// parameter is the one expected.
		IVsPackage* pPackage = static_cast<IVsPackage*>(this);
		IServiceProviderMock mock;
		CComQIPtr<IServiceProvider> spIServiceProvider = mock.GetIUnknownNoAddRef();

		m_SetSiteResultExpected = IVsPackageEnums::NothingCached;
		UTCHK(S_OK == pPackage->SetSite(NULL));
		UTCHK(!m_bPostSitedCalled);

		m_SetSiteResultExpected = IVsPackageEnums::Cached;
		m_bPostSitedCalled = false;
		UTCHK(S_OK == pPackage->SetSite(spIServiceProvider));
		UTCHK(m_bPostSitedCalled);

		m_SetSiteResultExpected = IVsPackageEnums::AlreadyCached;
		m_bPostSitedCalled = false;
		UTCHK(S_OK == pPackage->SetSite(spIServiceProvider));
		UTCHK(m_bPostSitedCalled);

		m_SetSiteResultExpected = IVsPackageEnums::NothingCached;
		m_bPostSitedCalled = false;
		UTCHK(S_OK == pPackage->SetSite(NULL));
		UTCHK(!m_bPostSitedCalled);

		m_SetSiteResultExpected = IVsPackageEnums::Cleared;
		m_bPostSitedCalled = false;
		UTCHK(S_OK == pPackage->SetSite(NULL));
		UTCHK(!m_bPostSitedCalled);
	}

	void PostSited(IVsPackageEnums::SetSiteResult result)
	{
		m_bPostSitedCalled = true;
		UTCHK(result == m_SetSiteResultExpected);
	}
private:
	bool m_bPostSitedCalled;
	IVsPackageEnums::SetSiteResult m_SetSiteResultExpected;
};

#define FAKE_RESOURCE 34567

class IVsInstalledProductImplTest :
	public UnitTestBase,
	public IVsInstalledProductImpl<IDS_E_ERRORMESSAGE, IDS_E_ERRORMESSAGE, IDS_E_ERRORMESSAGE, FAKE_RESOURCE>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsInstalledProductImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		// Test bad NULL arg case
		UTCHK(get_OfficialName(NULL) == E_POINTER);
		UTCHK(get_ProductID(NULL) == E_POINTER);
		UTCHK(get_ProductDetails(NULL) == E_POINTER);
		UTCHK(get_IdIcoLogoForAboutbox(NULL) == E_POINTER);
		UTCHK(get_IdBmpSplash(NULL) == E_POINTER);

		// Test success case
		CComBSTR bstrOfficialName;
		UTCHK(get_OfficialName(&bstrOfficialName) == S_OK);
		CStringW szOfficialName;
		UTCHK(TRUE == szOfficialName.LoadString(IDS_E_ERRORMESSAGE));
		UTCHK(bstrOfficialName == static_cast<LPCOLESTR>(szOfficialName));

		CComBSTR bstrProductID;
		UTCHK(get_ProductID(&bstrProductID) == S_OK);
		CStringW szProductID;
		UTCHK(TRUE == szProductID.LoadString(IDS_E_ERRORMESSAGE));
		UTCHK(bstrProductID == static_cast<LPCOLESTR>(szProductID));

		CComBSTR bstrProductDetails;
		UTCHK(get_ProductDetails(&bstrProductDetails) == S_OK);
		CStringW szProductDetails;
		UTCHK(TRUE == szProductDetails.LoadString(IDS_E_ERRORMESSAGE));
		UTCHK(bstrProductDetails == static_cast<LPCOLESTR>(szProductDetails));

		UINT iIdIcoLogoForAboutbox = 0;
		UTCHK(get_IdIcoLogoForAboutbox(&iIdIcoLogoForAboutbox) == S_OK);
		UTCHK(iIdIcoLogoForAboutbox == FAKE_RESOURCE);
	}
};

class IVsInstalledProductImplBadTemplateArgsTest :
	public UnitTestBase,
	public IVsInstalledProductImpl<FAKE_RESOURCE, FAKE_RESOURCE, FAKE_RESOURCE, FAKE_RESOURCE>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IVsInstalledProductImplBadTemplateArgsTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		CComBSTR bstrOfficialName;
		UTCHK(get_OfficialName(&bstrOfficialName) == HRESULT_FROM_WIN32(ERROR_RESOURCE_NAME_NOT_FOUND));
		UTCHK(bstrOfficialName == L'\0');

		CComBSTR bstrProductID;
		UTCHK(get_ProductID(&bstrProductID) == HRESULT_FROM_WIN32(ERROR_RESOURCE_NAME_NOT_FOUND));
		UTCHK(bstrProductID == L'\0');

		CComBSTR bstrProductDetails;
		UTCHK(get_ProductDetails(&bstrProductDetails) == HRESULT_FROM_WIN32(ERROR_RESOURCE_NAME_NOT_FOUND));
		UTCHK(bstrProductDetails == L'\0');

		// Skip get_IdIcoLogoForAboutbox since it just parrots the template arg
	}
};

class AtlModuleEntryPointMock
{
public:
    BOOL WINAPI DllMain(DWORD /*dwReason*/, LPVOID /*lpReserved*/)
	{
		return TRUE;
	}
	HRESULT DllCanUnloadNow()
	{
		return S_OK;
	}

	HRESULT GetClassObject(REFCLSID /*rclsid*/, REFIID /*riid*/, LPVOID* /*ppv*/)
	{
		return S_OK;
	}

	HRESULT RegisterServer(BOOL bRegTypeLib = TRUE)
	{
		VSL_CHECKBOOLEAN(bRegTypeLib == FALSE, E_INVALIDARG);
		return S_OK;
	}

	HRESULT UnregisterServer(BOOL bUnRegTypeLib = TRUE)
	{
		VSL_CHECKBOOLEAN(bUnRegTypeLib == FALSE, E_INVALIDARG);
		return S_OK;
	}

};

AtlModuleEntryPointMock _AtlModule;

#define DEFAULT_REGISTRY_ROOT LREGKEY_VISUALSTUDIOROOT L"Exp"

// Must come after decleration of _AtlModule and DEFAULT_REGISTRY_ROOT
#include <VSLPackageDllEntryPoints.cpp>

class DllEntryPointsTest :
	public UnitTestBase
{
public:
	DllEntryPointsTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(::DllMain(NULL, 0 , NULL) == TRUE);
		UTCHK(DllCanUnloadNow() == S_OK);
		UTCHK(DllGetClassObject(GUID_NULL, GUID_NULL, NULL) == S_OK);
		UTCHK(VSDllRegisterServer(NULL) == S_OK);
		UTCHK(VSDllRegisterServer(L"") == E_INVALIDARG);
		UTCHK(VSDllUnregisterServer(NULL) == S_OK);
		UTCHK(VSDllUnregisterServer(L"") == E_INVALIDARG);

		UTCHK(VSDllRegisterServerUser(NULL) == S_OK);
		UTCHK(VSDllRegisterServerUser(L"") == E_INVALIDARG);
		UTCHK(VSDllUnregisterServerUser(NULL) == S_OK);
		UTCHK(VSDllUnregisterServerUser(L"") == E_INVALIDARG);
		
		UTCHK(DllRegisterServer() == S_OK);
		UTCHK(DllUnregisterServer() == S_OK);
	}
};

typedef InterfaceImplList<IOleComponentUIManagerMockImpl, IUnknownInterfaceListTerminatorDefault> IOleComponentUIManagerMockImplList;
VSL_DEFINE_SERVICE_MOCK_EX(IOleComponentUIManagerServiceMock, IOleComponentUIManagerMockImplList, SID_SOleComponentUIManager);

typedef ServiceList<IOleComponentUIManagerServiceMock, ServiceList<IVsShellServiceMock, ServiceList<IVsUIShellServiceMock, ServiceListTerminator> > > IOleComponentUIManagerProviderServiceList;
typedef InterfaceImplList<VSL::IServiceProviderImpl<IOleComponentUIManagerProviderServiceList>, IUnknownInterfaceListTerminator<IServiceProvider> > IOleComponentUIManagerProviderMockInterfaceList;

VSL_DECLARE_COM_MOCK(IOleComponentUIManagerProviderMock, IOleComponentUIManagerProviderMockInterfaceList){};

class OleComponentUIManagerUtilitiesGlobalTest :
	public UnitTestBase
{
public:
	OleComponentUIManagerUtilitiesGlobalTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IOleComponentUIManagerProviderMock serviceProviderMock;
		VsSiteCacheGlobal cache;
		cache.SetSite(&serviceProviderMock);

	// ShowMessage

		LONG nResult = IDYES;
		CREATEVV(IOleComponentUIManager, ShowMessage, values)
		{
			OLEROLE_TOPLEVELCOMPONENT, //* [in] */ DWORD dwCompRole,
			GUID_NULL, //* [in] */ REFCLSID rclsidComp,
			L"Test Title", //* [in] */ LPOLESTR pszTitle,
			L"Test Text", //* [in] */ LPOLESTR pszText,
			NULL, //* [in] */ LPOLESTR pszHelpFile,
			NULL, //* [in] */ DWORD dwHelpContextID,
			OLEMSGBUTTON_OK, //* [in] */ OLEMSGBUTTON msgbtn,
			OLEMSGDEFBUTTON_FIRST, //* [in] */ OLEMSGDEFBUTTON msgdefbtn,
			OLEMSGICON_CRITICAL, //* [in] */ OLEMSGICON msgicon,
			FALSE, //* [in] */ BOOL fSysAlert,
			&nResult, //* [retval][out] */ LONG *pnResult) = 0;
			E_UNEXPECTED
		};

		SETVV(values);
		
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			values.pszText);

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT);

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		values.retValue = S_OK;

		UTCHK(nResult == OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			values.pszText));

		UTCHK(nResult == OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT));

		values.msgbtn = OLEMSGBUTTON_OKCANCEL;
		values.msgdefbtn = OLEMSGDEFBUTTON_SECOND;
		values.msgicon = OLEMSGICON_QUERY;
		values.fSysAlert = TRUE;

		UTCHK(nResult == OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			values.pszText,
			values.msgbtn,
			values.msgdefbtn,
			values.msgicon,
			values.fSysAlert));

		UTCHK(nResult == OleComponentUIManagerUtilities<>::ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT,
			values.msgbtn,
			values.msgdefbtn,
			values.msgicon,
			values.fSysAlert));

	// ShowContextMenu

		POINTS pts = {0, 0};
		CREATEVV(IOleComponentUIManager, ShowContextMenu, valuesShowContextMenu)
		{
            0, //* [in] */ DWORD dwCompRole,
            GUID_NULL, //* [in] */ REFCLSID rclsidActive,
            0, //* [in] */ LONG nMenuId,
            pts, //* [in] */ REFPOINTS pos,
            NULL, //* [in] */ IOleCommandTarget *pCmdTrgtActive) = 0;
			E_UNEXPECTED
		};

		SETVV(valuesShowContextMenu);

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		OleComponentUIManagerUtilities<>::ShowContextMenu(
			0, 
			GUID_NULL,
			0,
			pts,
			NULL);

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		cache.SetSite(NULL);
	}
};

class OleComponentUIManagerUtilitiesLocalTest :
	public UnitTestBase
{
public:
	OleComponentUIManagerUtilitiesLocalTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		IOleComponentUIManagerProviderMock serviceProviderMock;
		VsSiteCacheLocal cache;
		cache.SetSite(&serviceProviderMock);

		LONG nResult = IDYES;
		CREATEVV(IOleComponentUIManager, ShowMessage, values)
		{
			OLEROLE_TOPLEVELCOMPONENT, //* [in] */ DWORD dwCompRole,
			GUID_NULL, //* [in] */ REFCLSID rclsidComp,
			L"Test Title", //* [in] */ LPOLESTR pszTitle,
			L"Test Text", //* [in] */ LPOLESTR pszText,
			NULL, //* [in] */ LPOLESTR pszHelpFile,
			NULL, //* [in] */ DWORD dwHelpContextID,
			OLEMSGBUTTON_OK, //* [in] */ OLEMSGBUTTON msgbtn,
			OLEMSGDEFBUTTON_FIRST, //* [in] */ OLEMSGDEFBUTTON msgdefbtn,
			OLEMSGICON_CRITICAL, //* [in] */ OLEMSGICON msgicon,
			FALSE, //* [in] */ BOOL fSysAlert,
			&nResult, //* [retval][out] */ LONG *pnResult) = 0;
			E_UNEXPECTED
		};

		SETVV(values);

		OleComponentUIManagerUtilities<VsUtilityLocalSiteControl> util;
		util.SetSite(cache);
		
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		util.ShowMessage(
			values.pszTitle, 
			values.pszText);

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		util.ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT);

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);

		values.retValue = S_OK;

		UTCHK(nResult == util.ShowMessage(
			values.pszTitle, 
			values.pszText));

		UTCHK(nResult == util.ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT));

		values.msgbtn = OLEMSGBUTTON_OKCANCEL;
		values.msgdefbtn = OLEMSGDEFBUTTON_SECOND;
		values.msgicon = OLEMSGICON_QUERY;
		values.fSysAlert = TRUE;

		UTCHK(nResult == util.ShowMessage(
			values.pszTitle, 
			values.pszText,
			values.msgbtn,
			values.msgdefbtn,
			values.msgicon,
			values.fSysAlert));

		UTCHK(nResult == util.ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT,
			values.msgbtn,
			values.msgdefbtn,
			values.msgicon,
			values.fSysAlert));

		CComPtr<IOleComponentUIManager> spIOleComponentUIManager;
		cache.QueryCachedService<IOleComponentUIManager, SID_SOleComponentUIManager>(&spIOleComponentUIManager);
		OleComponentUIManagerUtilities<VsUtilityLocalSiteControl> util2(spIOleComponentUIManager);

		UTCHK(nResult == util2.ShowMessage(
			values.pszTitle, 
			IDS_TESTTEXT,
			values.msgbtn,
			values.msgdefbtn,
			values.msgicon,
			values.fSysAlert));

		cache.SetSite(NULL);
	}
};

// TODO - 1/17/2006 - this unit test needs to move elsewhere, and could stand improvment

void Method()
{
	ERRHR(E_NOTIMPL);
}

static const int iMethod0Return = 53;
int Method0()
{
	return iMethod0Return;
}

int Method1(int i)
{
	return i;
}

int Method2(int i, int j)
{
	return i+j;
}

int Method3(int i, int j, int k)
{
	return i+j+k;
}

class StaticMethods
{
public:
	static Delegate<void ()>* m_spDelegate;
	static FunctionPointerFunctor<CallingConventionDefault, void ()>* m_spFunctorToRemove1;
	static FunctionPointerFunctor<CallingConventionDefault, void ()>* m_spFunctorToRemove2;
	static FunctionPointerFunctor<CallingConventionDefault, void ()>* m_spFunctorToRemove3;

	static void RemoveFromDelegate1()
	{
		*m_spDelegate -= m_spFunctorToRemove1;
	}

	static void RemoveFromDelegate2()
	{
		*m_spDelegate -= m_spFunctorToRemove2;
	}

	static void RemoveFromDelegate3()
	{
		*m_spDelegate -= m_spFunctorToRemove3;
	}

	static void Method()
	{
		ERRHR(E_FAIL);
	}

	static int Method0()
	{
		return iMethod0Return;
	}

	static int Method1(int i)
	{
		return i+1;
	}

	static int Method2(int i, int j)
	{
		return i+j+1;
	}

	static int Method3(int i, int j, int k)
	{
		return i+j+k+1;
	}
};

Delegate<void ()>* StaticMethods::m_spDelegate;
FunctionPointerFunctor<CallingConventionDefault, void ()>* StaticMethods::m_spFunctorToRemove1;
FunctionPointerFunctor<CallingConventionDefault, void ()>* StaticMethods::m_spFunctorToRemove2;
FunctionPointerFunctor<CallingConventionDefault, void ()>* StaticMethods::m_spFunctorToRemove3;

class Methods
{
public:
	void Method()
	{
		ERRHR(E_UNEXPECTED);
	}
	int Method0()
	{
		return iMethod0Return;
	}
	int Method1(int i)
	{
		return i+2;
	}
	int Method2(int i, int j)
	{
		return i+j+2;
	}
	int Method3(int i, int j, int k)
	{
		return i+j+k+2;
	}
};

class FunctorTest :
	public UnitTestBase
{
public:

	void TestRemoveWhenCalled()
	{
		Delegate<void ()> functorContainter;
		StaticMethods::m_spDelegate = &functorContainter;

		FunctionPointerFunctor<CallingConventionDefault, void ()> staticMethodFunctor1(&StaticMethods::RemoveFromDelegate1);
		functorContainter += &staticMethodFunctor1;
		StaticMethods::m_spFunctorToRemove1 = &staticMethodFunctor1;

		FunctionPointerFunctor<CallingConventionDefault, void ()> staticMethodFunctor2(&StaticMethods::RemoveFromDelegate2);
		functorContainter += &staticMethodFunctor2;
		StaticMethods::m_spFunctorToRemove2 = &staticMethodFunctor2;

		FunctionPointerFunctor<CallingConventionDefault, void ()> staticMethodFunctor3(&StaticMethods::RemoveFromDelegate3);
		functorContainter += &staticMethodFunctor3;
		StaticMethods::m_spFunctorToRemove3 = &staticMethodFunctor3;

		functorContainter();

		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		functorContainter();

		}VSL_STDMETHODCATCH()

		// Container should be empty now
		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_UNEXPECTED);
	}

	void TestVoid()
	{
		Delegate<void ()> functorContainter;
		FunctionPointerFunctor<CallingConventionDefault, void ()> functionFunctor(&Method);
		functorContainter += &functionFunctor;

		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		functorContainter();

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_NOTIMPL);

		FunctionPointerFunctor<CallingConventionDefault, void ()> staticMethodFunctor(&StaticMethods::Method);
		functorContainter += &staticMethodFunctor;

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		functorContainter();

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_NOTIMPL);

		Methods instance;
		MemberFunctionPointerFunctor<Methods, CallingConventionDefault, void ()> memberFunctionFuntor(&instance, &Methods::Method);
		functorContainter += &memberFunctionFuntor;

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		functorContainter();

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_NOTIMPL);
	}

	void Test0Parameter()
	{
		Delegate<int ()> functorContainter;
		FunctionPointerFunctor<CallingConventionDefault, int ()> functionFunctor(&Method0);
		functorContainter += &functionFunctor;

		int i = functorContainter();
		UTCHK(i == iMethod0Return);

		FunctionPointerFunctor<CallingConventionDefault, int ()> staticMethodFunctor(&StaticMethods::Method0);
		functorContainter += &staticMethodFunctor;

		i = functorContainter();
		UTCHK(i == iMethod0Return);

		Methods instance;
		MemberFunctionPointerFunctor<Methods, CallingConventionDefault, int ()> memberMethodFunctor(&instance, &Methods::Method0);
		functorContainter += &memberMethodFunctor;

		i = functorContainter();
		UTCHK(i == iMethod0Return);
	}

	void Test1Parameter()
	{
		Delegate<int (int)> functorContainter;
		const int iExpected = 1;

		FunctionPointerFunctor<CallingConventionDefault, int (int)> functionFunctor(&Method1);
		functorContainter += &functionFunctor;

		int i = functorContainter(iExpected);
		UTCHK(i == iExpected);

		FunctionPointerFunctor<CallingConventionDefault, int (int)> staticMethodfunctor(&StaticMethods::Method1);
		functorContainter += &staticMethodfunctor;

		i = functorContainter(iExpected);
		UTCHK(i == iExpected+1);

		Methods instance;
		MemberFunctionPointerFunctor<Methods, CallingConventionDefault, int (int)> memberMethodfunctor(&instance, &Methods::Method1);
		functorContainter += &memberMethodfunctor;

		i = functorContainter(iExpected);
		UTCHK(i == iExpected+2);

		functorContainter -= &memberMethodfunctor;

		i = functorContainter(iExpected);
		UTCHK(i == iExpected+1);

		functorContainter -= &staticMethodfunctor;

		i = functorContainter(iExpected);
		UTCHK(i == iExpected);
	}

	void Test2Parameter()
	{
		Delegate<int (int, int)> functorContainter;
		const int a = 1;
		const int b = 2;
		const int iExpected = a+b;

		FunctionPointerFunctor<CallingConventionDefault, int (int, int)> functionFunctor(&Method2);
		functorContainter += &functionFunctor;

		int i = functorContainter(a, b);
		UTCHK(i == iExpected);

		FunctionPointerFunctor<CallingConventionDefault, int (int, int)> staticMethodfunctor(&StaticMethods::Method2);
		functorContainter += &staticMethodfunctor;

		i = functorContainter(a, b);
		UTCHK(i == iExpected+1);

		Methods instance;
		MemberFunctionPointerFunctor<Methods, CallingConventionDefault, int (int, int)> memberMethodfunctor(&instance, &Methods::Method2);
		functorContainter += &memberMethodfunctor;

		i = functorContainter(a, b);
		UTCHK(i == iExpected+2);

		functorContainter -= &memberMethodfunctor;

		i = functorContainter(a, b);
		UTCHK(i == iExpected+1);

		functorContainter -= &staticMethodfunctor;

		i = functorContainter(a, b);
		UTCHK(i == iExpected);
	}

	void Test3Parameter()
	{
		Delegate<int (int, int, int)> functorContainter;
		const int a = 1;
		const int b = 2;
		const int c = 3;
		const int iExpected = a+b+c;

		FunctionPointerFunctor<CallingConventionDefault, int (int, int, int)> functionFunctor(&Method3);
		functorContainter += &functionFunctor;

		int i = functorContainter(a, b, c);
		UTCHK(i == iExpected);

		FunctionPointerFunctor<CallingConventionDefault, int (int, int, int)> staticMethodfunctor(&StaticMethods::Method3);
		functorContainter += &staticMethodfunctor;

		i = functorContainter(a, b, c);
		UTCHK(i == iExpected+1);

		Methods instance;
		MemberFunctionPointerFunctor<Methods, CallingConventionDefault, int (int, int, int)> memberMethodfunctor(&instance, &Methods::Method3);
		functorContainter += &memberMethodfunctor;

		i = functorContainter(a, b, c);
		UTCHK(i == iExpected+2);

		functorContainter -= &memberMethodfunctor;

		i = functorContainter(a, b, c);
		UTCHK(i == iExpected+1);

		functorContainter -= &staticMethodfunctor;

		i = functorContainter(a, b, c);
		UTCHK(i == iExpected);
	}

	FunctorTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		TestRemoveWhenCalled();
		TestVoid();
		Test0Parameter();
		Test1Parameter();
		Test2Parameter();
		Test3Parameter();
	}
};

class IExtensibleObjectImplTestHelper :
	public IExtensibleObjectImpl<IExtensibleObjectImplTestHelper>
{
public:

VSL_DEFINE_IUNKNOWN_NOTIMPL

	IUnknown* _GetRawUnknown() throw()
	{
		return this;
	}

	IDispatch* GetNamedAutomationObject(BSTR /*bstrName*/)
	{
		return reinterpret_cast<IDispatch*>(this);
	}
};

class IExtensibleObjectImplTest :
	public UnitTestBase,
	public IExtensibleObjectSite, // TODO - 2/1/2006 - determine why the mock interface for this is missing
	public MockBase
{
public:

	typedef IExtensibleObjectImplTest IExtensibleObjectImplTestMockImpl;

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IExtensibleObjectImplTest)

VSL_DEFINE_IUNKNOWN_NOTIMPL

	struct NotifyDeleteValidValues
	{
		IUnknown* pIUnknown;
		HRESULT retValue;
	};

	STDMETHOD(NotifyDelete)(IUnknown* pIUnknown)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyDelete);

		UTCHK(pIUnknown == validValues.pIUnknown);

		VSL_RETURN_VALIDVALUES();
	}

	IExtensibleObjectImplTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		{
		IExtensibleObjectImplTestHelper helper;
		UTCHK(E_INVALIDARG == helper.GetAutomationObject(NULL, NULL, NULL));
		IDispatch* pIDispatch = NULL;
		UTCHK(S_OK == helper.GetAutomationObject(NULL, NULL, &pIDispatch));
		UTCHK(pIDispatch == reinterpret_cast<IDispatch*>(&helper));
		pIDispatch = NULL;
		UTCHK(S_OK == helper.GetAutomationObject(NULL, static_cast<IExtensibleObjectSite*>(this), &pIDispatch));
		UTCHK(pIDispatch == reinterpret_cast<IDispatch*>(&helper));
		// Call it again, since this can be called repeatedly
		UTCHK(S_OK == helper.GetAutomationObject(NULL, static_cast<IExtensibleObjectSite*>(this), &pIDispatch));
		UTCHK(pIDispatch == reinterpret_cast<IDispatch*>(&helper));
		PUSHVV2(IExtensibleObjectImplTest, NotifyDelete, static_cast<IUnknown*>(static_cast<IExtensibleObject*>(&helper)), S_OK);
		}
		UTCHK(WASCALLED0(IExtensibleObjectImplTest, NotifyDelete, 1));
		{
		IExtensibleObjectImplTestHelper helper;
		}
		UTCHK(WASCALLED0(IExtensibleObjectImplTest, NotifyDelete, 0));
	}
};

int _cdecl _tmain()
{
	UTRUN(PointerWithNullDefaultTest);
	UTRUN(LocalCacheTest);
	UTRUN(GlobalCacheTest);
	UTRUN(GlobalRefCountTest);
	UTRUN(IVsPackageEnumsCompileTest);
	UTRUN(IServiceProviderLocalCacheTest);
	UTRUN(IServiceProviderGlobalCacheTest);
	UTRUN(GeneralServiceCacheLocalNotImplementedTest);
	UTRUN(VsSiteCacheGlobalTest);
	UTRUN(VsSiteCacheLocalTest);
	UTRUN(VsIServiceProviderUtilitiesTest);
	UTRUN(VsRegistryUtilitiesTest);
	UTRUN(RegistryMacrosTest);
	UTRUN(VsShellUtilitiesTest);
	UTRUN(VsReportErrorUtilitiesTest);
	UTRUN(LoadUILibraryRequiredTest);
	UTRUN(IVsPackageImplTest);
	UTRUN(IVsPackageImplLoadUILibraryNoopTest);
	UTRUN(IVsPackageImplSetSiteEventsTest);
	UTRUN(IVsInstalledProductImplTest);
	UTRUN(IVsInstalledProductImplBadTemplateArgsTest);
	UTRUN(DllEntryPointsTest);
	UTRUN(OleComponentUIManagerUtilitiesGlobalTest);
	UTRUN(OleComponentUIManagerUtilitiesLocalTest);
	UTRUN(FunctorTest);
	return VSL::FailureCounter::Get();
}

EXTERN_C const GUID DECLSPEC_SELECTANY g_FakeServiceGUID = // {25CACC6E-BDC0-47e8-883C-8A5E9581428F}
	{ 0x25cacc6e, 0xbdc0, 0x47e8, { 0x88, 0x3c, 0x8a, 0x5e, 0x95, 0x81, 0x42, 0x8f } };
EXTERN_C const CComBSTR DECLSPEC_SELECTANY g_FakeString = L"Test";
