/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLVsSite.h>

// ATL includes
#include <ATLColl.h>

// VS Platform includes
#include <vssplash.h>
#include <dte.h> // required for IExtensibleObjectImpl

namespace VSL
{

/*
A non-NULL non-empty string must be passed to VsRegistryUtilities::SetRegRoot in 
VSDllRegisterServer, VSDllUnregisterServer, DllRegisterServer, and DllUnregisterServer 
in any module intending to expose a VS package implemented using VSL.
	
If the VSL package registration macros are utilized it is not necessary to call 
GetRegRootStrings or GetRegDefaultResourceStrings directly.
*/
class VsRegistryUtilities
{
private:
	static bool& GetUseHKCU()
	{
		static bool useHKCU = false;
		return useHKCU;
	}

	static wchar_t*& GetRegRoot()
	{
		static wchar_t* szRegRoot = NULL;
		return szRegRoot;
	}
	static void ErrorIfUninitialized()
	{
		if(GetRegRoot() == NULL)
		{
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}
	}	
public:
	
	/*
	The string passed SetRegRoot needs have lifetime lasting until the end of the registration
	process.  This is true for the strings passed into VSDllRegisterServer and
	VSDllUnregisterServer, and as well as string literals, static and global strings,
	and local strings declared in DllRegisterServer and DllUnregisterServer.
	The one thing this would not be true for, is passing in a string on the heap, which
	is deleted immediately after the call to SetRegRoot, so this should be avoided.
	*/
	static void SetRegRoot(_In_z_ wchar_t* szRegRoot, bool isRanu = FALSE)
	{
		VSL_CHECKBOOLEAN(szRegRoot != NULL, E_POINTER);
#pragma warning(push) // compiler doesn't get that the above line will throw if szRegRoot is NULL
#pragma warning(disable : 6011) // Dereferencing NULL pointer 'szRegRoot'
		VSL_CHECKBOOLEAN(szRegRoot[0] != L'\0', E_INVALIDARG);
#pragma warning(pop)
		GetRegRoot() = szRegRoot;
		GetUseHKCU() = isRanu;
	}
	
	// SetRegRoot must be called before GetRegHiveString.
	static void GetRegHiveString(CComBSTR& bstrRegHive)
	{
		ErrorIfUninitialized();
		(bstrRegHive);
		if(GetUseHKCU())
		{
			VSL_CHECKHRESULT(bstrRegHive.Append(L"HKCU"));
		}
		else
		{
			VSL_CHECKHRESULT(bstrRegHive.Append(L"HKLM"));
		}
	}

	// SetRegRoot must be called before GetRegRootStrings.
	static void GetRegRootStrings(CComBSTR& bstrRootBegin, CComBSTR& bstrRootEnd)
	{
		ErrorIfUninitialized();
		(bstrRootBegin, bstrRootEnd);

		wchar_t segmentCopy[225];
		wchar_t * pszStartSegment = segmentCopy;
		wchar_t * pszEndSegment = segmentCopy;

		wcscpy_s(segmentCopy, _countof(segmentCopy), GetRegRoot());
		if(GetUseHKCU())
		{
			wcscat_s(segmentCopy, _countof(segmentCopy), L"\\Configuration");
		}

#pragma warning(push)
#pragma warning(disable : 4127) // conditional expression is constant
		while(true)
#pragma warning(pop)
		{
			// Find the end of this segment
			for(; *pszEndSegment != L'\\' && *pszEndSegment != L'\0'; ++pszEndSegment)
			{
				// 64 characters seems like a resaonable limit on each segment,
				// so error out if it's longer.
				if(pszEndSegment - pszStartSegment + 1 > 64) // +1 to turn diff into count
				{
					VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
				}
			}

			const int iSegmentLenth = static_cast<int>(pszEndSegment - pszStartSegment);
			VSL_CHECKBOOLEAN(iSegmentLenth > 0, E_INVALIDARG);
			
			VSL_CHECKHRESULT(bstrRootBegin.Append(L" NoRemove "));
			VSL_CHECKHRESULT(bstrRootBegin.Append(pszStartSegment, iSegmentLenth));
			VSL_CHECKHRESULT(bstrRootBegin.Append(L"\n{\n"));
			VSL_CHECKHRESULT(bstrRootEnd.Append(L"\n}\n"));

			// The second check deals with the string ending with a L'\\'
			if(*pszEndSegment == L'\0' || *(pszEndSegment+1) == L'\0')
			{
				break;
			}

			++pszEndSegment;

			pszStartSegment = pszEndSegment;
		}
	}

	static void GetRegDefaultResourceStrings(CComBSTR& bstrResDllPath, CComBSTR& bstrResDllName)
	{
		wchar_t szModuleFullName[_MAX_PATH];
		DWORD dwLen = ::GetModuleFileNameW(_AtlBaseModule.GetModuleInstance(), szModuleFullName, ARRAYSIZE(szModuleFullName));
		VSL_CHECKBOOL_GLE(static_cast<BOOL>(dwLen > 0));
		VSL_CHECKBOOLEAN(static_cast<BOOL>(dwLen != ARRAYSIZE(szModuleFullName)), __HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER));
	    
		LPTSTR pszModuleFileName = ::PathFindFileName(szModuleFullName);
		VSL_CHECKBOOLEAN(pszModuleFileName != szModuleFullName, E_FAIL);

		VSL_CHECKHRESULT(bstrResDllPath.Append(szModuleFullName, static_cast<int>(pszModuleFileName - szModuleFullName)));

		LPTSTR pszModuleFileExtension = ::PathFindExtension(szModuleFullName);

		VSL_CHECKHRESULT(bstrResDllName.Append(pszModuleFileName, static_cast<int>(pszModuleFileExtension - pszModuleFileName)));
		VSL_CHECKHRESULT(bstrResDllName.Append(L"UI"));
		VSL_CHECKHRESULT(bstrResDllName.Append(pszModuleFileExtension));
	}
};

#define VSL_BEGIN_REGISTRY_MAP_EX(resourceID) \
	static HRESULT WINAPI UpdateRegistry(BOOL bRegister) \
	{ \
		const UINT iResourceID = resourceID; \
		\
		VSL_STDMETHODTRY{ \
		\
		ATL::CAtlArray<ATL::_ATL_REGMAP_ENTRY> regMapEntries; \
		\
		/* Set array to grow by to 10 as that is more then required by basic packages */ \
		/* We don't set the count though as each item will be default constructed. */ \
		regMapEntries.SetCount(0, 10);

#define _VSL_SZ_REGROOTBEGIN L"REGROOTBEGIN"
#define _VSL_SZ_REGROOTEND L"REGROOTEND"
#define _VSL_SZ_REGHIVE L"REGHIVE"

#define VSL_REGISTRY_MAP_REGROOT_ENTRY() \
	    ATL::CComBSTR bstrRegRootBegin; \
		ATL::CComBSTR bstrRegRootEnd; \
		ATL::CComBSTR bstrRegHive; \
		VSL::VsRegistryUtilities::GetRegRootStrings( \
			bstrRegRootBegin, \
			bstrRegRootEnd); \
		VSL::VsRegistryUtilities::GetRegHiveString( \
			bstrRegHive); \
		ATL::_ATL_REGMAP_ENTRY regRootBeginEntry = {_VSL_SZ_REGROOTBEGIN, bstrRegRootBegin}; \
		regMapEntries.Add(regRootBeginEntry); \
		ATL::_ATL_REGMAP_ENTRY regRootEndEntry = {_VSL_SZ_REGROOTEND, bstrRegRootEnd}; \
		regMapEntries.Add(regRootEndEntry); \
		ATL::_ATL_REGMAP_ENTRY regHiveEntry = {_VSL_SZ_REGHIVE, bstrRegHive}; \
		regMapEntries.Add(regHiveEntry);

#define _VSL_SZ_RESOURCE_PATH L"RESOURCE_PATH"
#define _VSL_SZ_RESOURCE_DLL L"RESOURCE_DLL"

#define VSL_REGISTRY_MAP_RESOURCEDLL_ENTRY() \
	    ATL::CComBSTR bstrResDllPath; \
		ATL::CComBSTR bstrResDllName; \
		VSL::VsRegistryUtilities::GetRegDefaultResourceStrings( \
			bstrResDllPath, \
			bstrResDllName); \
		ATL::_ATL_REGMAP_ENTRY resDllPathEntry = {_VSL_SZ_RESOURCE_PATH, bstrResDllPath}; \
		regMapEntries.Add(resDllPathEntry); \
		ATL::_ATL_REGMAP_ENTRY resDllNameEntry = {_VSL_SZ_RESOURCE_DLL, bstrResDllName}; \
		regMapEntries.Add(resDllNameEntry);

#define VSL_BEGIN_REGISTRY_MAP(resourceID) \
VSL_BEGIN_REGISTRY_MAP_EX(resourceID) \
	VSL_REGISTRY_MAP_REGROOT_ENTRY() \
	VSL_REGISTRY_MAP_RESOURCEDLL_ENTRY()

#define _VSL_SZ_TEMPLATE_PATH L"TEMPLATE_PATH"

// VSL_REGISTRY_MAP_RESOURCEDLL_ENTRY must come after VSL_REGISTRY_MAP_RESOURCEDLL_ENTRY in the map
// This is automatic so long as the map begins with VSL_BEGIN_REGISTRY_MAP rather then
// VSL_BEGIN_REGISTRY_MAP_EX
#define VSL_REGISTRY_MAP_TEMPLATE_PATH_ENTRY() \
		ATL::_ATL_REGMAP_ENTRY resTemplatePathEntry = {_VSL_SZ_TEMPLATE_PATH, bstrResDllPath}; \
		regMapEntries.Add(resTemplatePathEntry); \

#define VSL_REGISTRY_MAP_GUID_ENTRY(guid) \
		ATL::CComBSTR bstr##guid(guid); \
		if(!bstr##guid) \
		{ \
			return E_OUTOFMEMORY; \
		} \
		wchar_t szNameOf_##guid[] = L#guid; \
		C_ASSERT(_countof(szNameOf_##guid) <= 31); \
		ATL::_ATL_REGMAP_ENTRY guid##Entry = {szNameOf_##guid, bstr##guid}; \
		regMapEntries.Add(guid##Entry); \

#define VSL_REGISTRY_MAP_GUID_ENTRY_EX(guid, name) \
		ATL::CComBSTR bstr##name(guid); \
		if(!bstr##name) \
		{ \
			return E_OUTOFMEMORY; \
		} \
		wchar_t szNameOf_##name[] = L#name; \
		C_ASSERT(_countof(szNameOf_##name) <= 31); \
		ATL::_ATL_REGMAP_ENTRY name##Entry = {szNameOf_##name, bstr##name}; \
		regMapEntries.Add(name##Entry); \

#define VSL_REGISTRY_MAP_NUMBER_ENTRY(number) \
		/* A signed int can have 10 digits, a '-', and is should be NULL terminated totally 12 characters max. */ \
		wchar_t sz##number[12]; \
		if(0 != ::_ultow_s(number, sz##number, ARRAYSIZE(sz##number), 10)) \
		{ \
			return E_FAIL; \
		} \
		wchar_t szNameOf_##number[] = L#number; \
		C_ASSERT(_countof(szNameOf_##number) <= 31); \
		ATL::_ATL_REGMAP_ENTRY number##Entry = {szNameOf_##number, sz##number}; \
		regMapEntries.Add(number##Entry);

#define VSL_REGISTRY_MAP_STRING_ENTRY(str) \
		if(!str) \
		{ \
			return E_POINTER; \
		} \
		wchar_t szNameOf_##str[] = L#str; \
		C_ASSERT(_countof(szNameOf_##str) <= 31); \
		ATL::_ATL_REGMAP_ENTRY str##Entry = {szNameOf_##str, str}; \
		regMapEntries.Add(str##Entry);

#define VSL_REGISTRY_RESOURCEID_ENTRY(resourceID) \
		/* A signed int can have 10 digits, a '-', and is should be NULL terminated totally 12 characters max. */ \
		/* We also have to add '#' in front of it to tell the shell that this is a resource id, so the total */ \
		/* number or characters needed is 13 */ \
		wchar_t sz##resourceID[13]; \
		sz##resourceID[0] = _T('#'); \
		if(0 != ::_ultow_s(resourceID, &sz##resourceID[1], ARRAYSIZE(sz##resourceID)-1, 10)) \
		{ \
			return E_FAIL; \
		} \
		wchar_t szNameOf_##resourceID[] = L#resourceID; \
		C_ASSERT(_countof(szNameOf_##resourceID) <= 31); \
		ATL::_ATL_REGMAP_ENTRY resourceID##Entry = {szNameOf_##resourceID, sz##resourceID}; \
		regMapEntries.Add(resourceID##Entry);

#define VSL_REGISTRY_RESOURCE_STRING_ENTRY(resourceID) \
		ATL::CComBSTR bstr##resourceID; \
		VSL_CHECKBOOL_GLE(bstr##resourceID.LoadString(_AtlBaseModule.GetResourceInstance(), resourceID)); \
		wchar_t szNameOf_##resourceID[] = L#resourceID; \
		C_ASSERT(_countof(szNameOf_##resourceID) <= 31); \
		ATL::_ATL_REGMAP_ENTRY resourceID##StringEntry = {szNameOf_##resourceID, bstr##resourceID}; \
		regMapEntries.Add(resourceID##StringEntry);

#define VSL_END_REGISTRY_MAP() \
	    ATL::_ATL_REGMAP_ENTRY regMapTerminator = {NULL, NULL}; \
		regMapEntries.Add(regMapTerminator); \
		\
		__if_exists(::_Module) \
		{ \
			return ::_Module.UpdateRegistryFromResourceS(iResourceID, bRegister, regMapEntries.GetData()); \
		} \
		__if_not_exists(::_Module) \
		{ \
			return ATL::_pAtlModule->UpdateRegistryFromResourceS(iResourceID, bRegister, regMapEntries.GetData()); \
		} \
		\
		}VSL_STDMETHODCATCH() \
		\
		return VSL_GET_STDMETHOD_HRESULT(); \
	}

// TODO - 6/21/2006 - unit test this
class VsShellUtilities
{

	VSL_DECLARE_NOT_COPYABLE(VsShellUtilities)

private:
	class Private {}; // Used to make a private instatiation of GlobalRefCount
	typedef GlobalRefCount<Private> RefCount;

public:

	VsShellUtilities(IVsShell* pIVsShell):
		m_spIVsShell(VSL_CHECKPOINTER_DEFAULT(pIVsShell))
	{
	}

	HRESULT LoadUILibrary(REFCLSID rclsidPackage)
	{
		RefCount::ErrorIfCanNotIncrement();

		if(RefCount::Get() > 0)
		{
			++RefCount::Get();
			return S_OK;
		}

		HINSTANCE hInstance = NULL;
		HRESULT hr = m_spIVsShell->LoadUILibrary(rclsidPackage, 0, reinterpret_cast<DWORD_PTR *>(&hInstance));
		if(FAILED(hr))
		{
			return hr;
		}

		if(hInstance == NULL)
		{
			return E_UNEXPECTED;
		}

		// Set the resource instance
		_AtlBaseModule.SetResourceInstance(hInstance);

		++RefCount::Get();
		return S_OK;
	}

	static void UnloadUILibrary()
	{
		if(!RefCount::CanDecrement())
		{
			// Just ignore excessive UnloadUILibrary() calls, since wrapping is prevented
			return;
		}

		if(RefCount::Get() > 1)
		{
			--RefCount::Get();
			return;
		}

		HINSTANCE hResource = _AtlBaseModule.GetResourceInstance();
		HINSTANCE hModule = _AtlBaseModule.GetModuleInstance();

		VSL_CHECKBOOLEAN(hResource != hModule, E_UNEXPECTED);
		if(hResource != NULL)
		{   
			::FreeLibrary(hResource);
		}
		_AtlBaseModule.SetResourceInstance(hModule);

		--RefCount::Get();
	}
private:
	CComPtr<IVsShell> m_spIVsShell;
};

template <
	const CLSID * const clsidPackage_T,
	class VsSiteCache_T,
	class VsShellUtilities_T = VsShellUtilities,
	class ExtendedErrorInfo_T = ExtendedErrorInfo >
class LoadUILibraryRequired
{
public:
	typedef ExtendedErrorInfo ExtendedErrorInfo;

	static void LoadUILibrary(
		const VsSiteCache_T& rVsSiteCache, 
		const ExtendedErrorInfo& rExtendedErrorInfo)
	{
		VsShellUtilities_T utilVsShell(rVsSiteCache.GetCachedService<IVsShell, SID_SVsShell>());
		HRESULT hr = utilVsShell.LoadUILibrary(*clsidPackage_T);
		VSL_CHECKHRESULT_EX(hr, rExtendedErrorInfo);
	}
	static void UnloadUILibrary()
	{
		VsShellUtilities_T::UnloadUILibrary();
	}
};

// FUTURE - could provide LoadUILibraryOptional, which would attempt to load the resource DLL, 
// but not report an or throw and exception if it fails to load.

template <class VsSiteCache_T>
class LoadUILibraryNoop
{
public:
	static void LoadUILibrary(const VsSiteCache_T& /*rVsSiteCache*/)
	{
	}
	static void UnloadUILibrary()
	{
	}
};

template <const GUID * const clsidPackage_T = &GUID_NULL>
class IVsPackageImplDefaults
{
public:
	typedef VsSiteCacheGlobal VsSiteCache;
	typedef LoadUILibraryRequired<clsidPackage_T, VsSiteCache> LoadUILibrary;
};


template <
	class DerivedClass_T,
	const GUID * const clsidPackage_T,
	class VsSiteCache_T = IVsPackageImplDefaults<clsidPackage_T>::VsSiteCache,
	class LoadUILibrary_T = IVsPackageImplDefaults<clsidPackage_T>::LoadUILibrary >
class IVsPackageImpl :
	public VsSiteBaseImpl<DerivedClass_T, IVsPackageImpl<DerivedClass_T, clsidPackage_T, VsSiteCache_T, LoadUILibrary_T>, IVsPackage, VsSiteCache_T>
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageImpl)

public:

	typedef LoadUILibrary_T LoadUILibrary;

    STDMETHOD(GetAutomationObject)(LPCOLESTR /*pszPropName*/, IDispatch** ppIDispatch)
	{
		VSL_TRACE(_T("IVSPackageImpl::GetAutomationObject is not implemented\n"));

		VSL_STDMETHODTRY_EX(E_NOTIMPL){

		VSL_CHECKPOINTER_DEFAULT(ppIDispatch);

		*ppIDispatch = NULL;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

    STDMETHOD(CreateTool)(REFGUID /*rguidPersistanceSlot*/)
	{
		VSL_TRACE(_T("IVSPackageImpl::CreateTool is not implemented\n"));

		return E_NOTIMPL;
	}

    STDMETHOD(ResetDefaults)(PKGRESETFLAGS /*dwFlags*/)
	{
		VSL_TRACE(_T("IVSPackageImpl::ResetDefaults is not implemented\n"));

		return E_NOTIMPL;
	}

    STDMETHOD(GetPropertyPage)(REFGUID /*rguidPage*/, VSPROPSHEETPAGE* /*ppage*/)
	{
		VSL_TRACE(_T("IVSPackageImpl::GetPropertyPage is not implemented\n"));

		return E_NOTIMPL;
	}
};

// TODO - unit test these
#define VSL_BEGIN_TOOL_MAP() \
	STDMETHOD(CreateTool)(REFGUID rguidPersistanceSlot) \
	{ \
		VSL_STDMETHODTRY_EX(E_FAIL){ \

#define VSL_TOOL_ENTRY(guidPersistanceSlot, creator) \
		if(rguidPersistanceSlot == guidPersistanceSlot) \
		{ \
			creator; \
			return S_OK; \
		}

#define VSL_END_TOOL_MAP() \
		}VSL_STDMETHODCATCH() \
		return VSL_GET_STDMETHOD_HRESULT(); \
	}

template <
	unsigned int OfficialNameID_T,
	unsigned int ProductID_T,
	unsigned int ProductDetailsID_T,
	unsigned int LogoIconID_T>
class IVsInstalledProductImpl :
	public IVsInstalledProduct
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInstalledProductImpl)

protected:
	void SetBSTRFromResourceID(BSTR *pbstrToSet, unsigned int iResourceID)
	{
		VSL_CHECKPOINTER_DEFAULT(pbstrToSet);
		CComBSTR bstr;
		VSL_CHECKBOOL_GLE(bstr.LoadString(_AtlBaseModule.GetResourceInstance(), iResourceID));
		*pbstrToSet = bstr.Detach();
	}
public:
	STDMETHOD(get_OfficialName)(BSTR *pbstrName)
	{
		VSL_STDMETHODTRY{

		SetBSTRFromResourceID(pbstrName, OfficialNameID_T);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(get_ProductID)(BSTR *pbstrPID)
	{
		VSL_STDMETHODTRY{

		SetBSTRFromResourceID(pbstrPID, ProductID_T);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(get_ProductDetails)(BSTR *pbstrProductDetails)
	{
		VSL_STDMETHODTRY{

		SetBSTRFromResourceID(pbstrProductDetails, ProductDetailsID_T);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(get_IdIcoLogoForAboutbox)(UINT *pIdIco)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(pIdIco);
		*pIdIco = LogoIconID_T;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(get_IdBmpSplash)(UINT* pIdBmp)
	{
		VSL_TRACE(_T("IVsInstalledProduct::get_IdBmpSplash is not implemented, as it is no longer called by Visaul Studio\n"));

		VSL_STDMETHODTRY_EX(E_NOTIMPL){

		VSL_CHECKPOINTER_DEFAULT(pIdBmp);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
};

class VsUtilityLocalSiteControl
{
	enum {
		Local = 1
	};
};

class VsUtilityGlobalSiteControl
{
	enum {
		Global = 1
	};
};

// TODO - unit test this
// REVIEW - should this be global by default instead?
template <class SiteControl_T = VsUtilityLocalSiteControl>
class VsOutputWindowUtilities
{

	VSL_DECLARE_NOT_COPYABLE(VsOutputWindowUtilities)

public:

	VsOutputWindowUtilities()
	{
	}

	// The compiler generated destructor is fine
 
__if_exists(SiteControl_T::Local) // TODO - Using __if_not_exists(SiteControl_T::Global) here causes and ICE, report to compiler team
{

	VsOutputWindowUtilities(IVsOutputWindowPane* pIVsOutputWindowPane):
		m_spIVsOutputWindowPane(VSL_CHECKPOINTER_DEFAULT(pIVsOutputWindowPane))
	{
	}

	template <class VsSiteCache_T>
	void SetSite(const VsSiteCache_T& rVsSiteCache)
	{
		rVsSiteCache.QueryCachedService<IVsOutputWindowPane, SID_SVsGeneralOutputWindowPane>(&m_spIVsOutputWindowPane);
	}

}

	void OutputMessage(const wchar_t* const szMessage)
	{
		VSL_CHECKPOINTER_DEFAULT(szMessage);

		// Write a message on the debug output.
		VSL_TRACE(szMessage);

		EnsureInitialized();

		HRESULT hr = m_spIVsOutputWindowPane->OutputString(szMessage);
		VSL_CHECKHRESULT(hr);
	}

	void OutputMessageWithPreAndPostBarsOfEquals(const wchar_t* const szMessage)
	{
		VSL_CHECKPOINTER_DEFAULT(szMessage);

		// Write a message on the debug output.
		VSL_TRACE(szMessage);

		EnsureInitialized();

		HRESULT hr = m_spIVsOutputWindowPane->OutputString(L" ================================================\n  ");
		if(SUCCEEDED(hr)) 
		{
			hr = m_spIVsOutputWindowPane->OutputString(szMessage);
		}
		if(SUCCEEDED(hr))
		{
			hr = m_spIVsOutputWindowPane->OutputString(L"\n ================================================\n");
		}
		if(FAILED(hr))
		{
			VSL_TRACE(L"Can not write the message on the output window pane.");
			VSL_CREATE_ERROR_HRESULT(hr);
		}
	}

private:

	void EnsureInitialized()
	{
		HRESULT hr = E_NOINTERFACE;
		__if_exists(SiteControl_T::Global)
		{
			if(m_spIVsOutputWindowPane == NULL)
			{
				hr = VsIServiceProviderUtilities<>::QueryCachedService<IVsOutputWindowPane, SID_SVsGeneralOutputWindowPane>(&m_spIVsOutputWindowPane);
			}
		}
		if(m_spIVsOutputWindowPane == NULL)
		{
			// If the output window is not available all we can do is write a message on the debug output
			// and exit.
			VSL_TRACE(L"Can not get the GeneralOutputWindowPane service.");
			VSL_CREATE_ERROR_HRESULT(hr);
		}
	}

	CComPtr<IVsOutputWindowPane> m_spIVsOutputWindowPane;

};

#ifdef __proffserv_h__

// TODO - unit test this
class ProfferServiceUtilities
{
public:

	ProfferServiceUtilities(IProfferService* pIProfferService):
		m_spIProfferService(VSL_CHECKPOINTER_DEFAULT(pIProfferService))
	{
	}

	template <class VsSiteCache_T>
	ProfferServiceUtilities(const VsSiteCache_T& rVsSiteCache)
	{
		HRESULT hr = rVsSiteCache.QueryCachedService<IProfferService, SID_SProfferService>(&m_spIProfferService);
		VSL_CHECKHRESULT(hr);
		VSL_CHECKBOOLEAN(m_spIProfferService != NULL, E_FAIL);
	}

	// Used for services that are not revoked
	// Not revoking services is the typical case
	void ProfferService(REFGUID rguidService, IServiceProvider *pServiceProvider)
	{
		DWORD dwCookie = 0;
		ProfferService(rguidService, pServiceProvider, &dwCookie);
	}

	// Used for services that are revoked
	void ProfferService(REFGUID rguidService, IServiceProvider *pServiceProvider, DWORD* pdwCookie)
	{
		VSL_CHECKPOINTER_DEFAULT(pdwCookie);
		HRESULT hr = m_spIProfferService->ProfferService(rguidService, pServiceProvider, pdwCookie);
		VSL_CHECKHRESULT(hr);
	}

private:

	CComPtr<IProfferService> m_spIProfferService;

};

#endif

template <class SiteControl_T = VsUtilityGlobalSiteControl>
class OleComponentUIManagerUtilities
{

VSL_DECLARE_NOT_COPYABLE(OleComponentUIManagerUtilities)

// This is done, as we can't have two copies of a method under different
// __if_exists (get a multiply defined error if that is tried)
__if_exists(SiteControl_T::Global)
{
// Global version is not instantiable.
private:
}
__if_exists(SiteControl_T::Local)
{
public:
}

	OleComponentUIManagerUtilities()
	{
	}

	~OleComponentUIManagerUtilities()
	{
	}

public:

__if_exists(SiteControl_T::Local) // TODO - Using __if_not_exists(SiteControl_T::Global) here causes and ICE, report to compiler team
{

	OleComponentUIManagerUtilities(IOleComponentUIManager* pIOleComponentUIManager):
		m_spIOleComponentUIManager(VSL_CHECKPOINTER_DEFAULT(pIOleComponentUIManager))
	{
	}

	template <class VsSiteCache_T>
	void SetSite(const VsSiteCache_T& rVsSiteCache)
	{
		rVsSiteCache.QueryCachedService<IOleComponentUIManager, SID_SOleComponentUIManager>(&m_spIOleComponentUIManager);
	}

}

__if_exists(SiteControl_T::Global)
{
	static
}
	LONG ShowMessage(
		_In_ LPOLESTR szTitle, 
		_In_ UINT iMessageID, 
		_In_ OLEMSGBUTTON iButtons = OLEMSGBUTTON_OK, 
		_In_ OLEMSGDEFBUTTON iDefButton = OLEMSGDEFBUTTON_FIRST,
		_In_ OLEMSGICON iIcon = OLEMSGICON_CRITICAL, 
		_In_ BOOL bAlert = FALSE)
	{
		ATL::CStringW strMessage;
		strMessage.LoadString(iMessageID);
		return ShowMessage(
			szTitle,
			static_cast<LPOLESTR>(strMessage.GetBuffer()), 
			iButtons, 
			iDefButton,
			iIcon, 
			bAlert);
	}

__if_exists(SiteControl_T::Global)
{
	static
}
    LONG ShowMessage(
		_In_ LPOLESTR szTitle, 
		_In_ LPOLESTR szMessage, 
		_In_ OLEMSGBUTTON iButtons = OLEMSGBUTTON_OK, 
		_In_ OLEMSGDEFBUTTON iDefButton = OLEMSGDEFBUTTON_FIRST,
		_In_ OLEMSGICON iIcon = OLEMSGICON_CRITICAL, 
		_In_ BOOL bAlert = FALSE)
	{
		EnsureInitialized();
		LONG nResult;
		HRESULT hr = m_spIOleComponentUIManager->ShowMessage(
			OLEROLE_TOPLEVELCOMPONENT,
			GUID_NULL,
			szTitle,
			szMessage,
			NULL,
			NULL,
			iButtons,
			iDefButton,
			iIcon,
			bAlert,
			&nResult);
		VSL_CHECKHRESULT(hr);
		return nResult;
	}

__if_exists(SiteControl_T::Global)
{
	static
}
    void ShowContextMenu( 
        _In_ DWORD dwCompRole,
        _In_ REFCLSID rclsidActive,
        _In_ LONG nMenuId,
        _In_ REFPOINTS pos,
        _In_ IOleCommandTarget *pCmdTrgtActive)
	{
		EnsureInitialized();
		VSL_CHECKHRESULT(m_spIOleComponentUIManager->ShowContextMenu(dwCompRole,
		   rclsidActive,
		   nMenuId,
		   pos,
		   pCmdTrgtActive));
	}

private:


__if_exists(SiteControl_T::Global)
{
	static Functor<void ()>* GetUnsitedFunctor()
	{
		static FunctionPointerFunctor<CallingConventionDefault, void ()> functor(&OnUnsited);
		return &functor;
	}

	static void OnUnsited()
	{
		m_spIOleComponentUIManager.Release();
		VSL_SERVICE_PROVIDER::GetUnsited() -= GetUnsitedFunctor();
	}
}

__if_exists(SiteControl_T::Global)
{
	static
}
	void EnsureInitialized()
	{
		HRESULT hr = E_NOINTERFACE;
		__if_exists(SiteControl_T::Global)
		{
			if(m_spIOleComponentUIManager == NULL)
			{
				hr = VSL_SERVICE_PROVIDER::QueryCachedService<IOleComponentUIManager, SID_SOleComponentUIManager>(&m_spIOleComponentUIManager);
				VSL_CHECKHRESULT(hr);
				// Subscribe to the global service providers Unsited event, so that
				// that static members reference will get released properly.
				VSL_SERVICE_PROVIDER::GetUnsited() += GetUnsitedFunctor();
			}
		}
		if(m_spIOleComponentUIManager == NULL)
		{
			// If the output window is not available all we can do is write a message on the debug output
			// and exit.
			VSL_TRACE(L"Can not get the OleComponentUIManager service.");
			VSL_CREATE_ERROR_HRESULT(hr);
		}
	}

	__if_exists(SiteControl_T::Global)
	{
	static
	}
	CComPtr<IOleComponentUIManager> m_spIOleComponentUIManager;
};

__declspec(selectany) CComPtr<IOleComponentUIManager> OleComponentUIManagerUtilities<>::m_spIOleComponentUIManager;

template <class SiteControl_T = VsUtilityGlobalSiteControl>
class VsUIShellUtilities
{

VSL_DECLARE_NOT_COPYABLE(VsUIShellUtilities)

// This is done, as we can't have two copies of a method under different
// __if_exists (get a multiply defined error if that is tried)
__if_exists(SiteControl_T::Global)
{
// Global version is not instantiable.
private:
}
__if_exists(SiteControl_T::Local)
{
public:
}

	VsUIShellUtilities()
	{
	}

	~VsUIShellUtilities()
	{
	}

public:

__if_exists(SiteControl_T::Local)
{

	VsUIShellUtilities(IVsUIShell* pIVsUIShell):
		m_spIVsUIShell(VSL_CHECKPOINTER_DEFAULT(pIVsUIShell))
	{
	}

	template <class VsSiteCache_T>
	void SetSite(const VsSiteCache_T& rVsSiteCache)
	{
		rVsSiteCache.QueryCachedService<IVsUIShell, SID_SVsUIShell>(&m_spIVsUIShell);
	}

}

__if_exists(SiteControl_T::Global)
{
	static
}
    void FindToolWindow( 
		_In_ VSFINDTOOLWIN grfFTW,
		_In_ REFGUID rguidPersistenceSlot,
		_Out_ IVsWindowFrame **ppWindowFrame)
	{
		EnsureInitialized();
		VSL_CHECKHRESULT(m_spIVsUIShell->FindToolWindow(
			grfFTW,
			rguidPersistenceSlot,
			ppWindowFrame));
	}

__if_exists(SiteControl_T::Global)
{
	static
}
    bool AttemptToFindToolWindow( 
		_In_ VSFINDTOOLWIN grfFTW,
		_In_ REFGUID rguidPersistenceSlot,
		_Out_ IVsWindowFrame **ppWindowFrame)
	{
		EnsureInitialized();
		HRESULT hr = m_spIVsUIShell->FindToolWindow(
			grfFTW,
			rguidPersistenceSlot,
			ppWindowFrame);
		if(SUCCEEDED(hr) && *ppWindowFrame != NULL)
		{
			return true;
		}
		else if(E_FAIL != hr)
		{
			// Anything other then E_FAIL is unexpected
			VSL_CREATE_ERROR_HRESULT(hr);
		}
		return false;
	}

private:


__if_exists(SiteControl_T::Global)
{
	static Functor<void ()>* GetUnsitedFunctor()
	{
		static FunctionPointerFunctor<CallingConventionDefault, void ()> functor(&OnUnsited);
		return &functor;
	}

	static void OnUnsited()
	{
		m_spIVsUIShell.Release();
		VSL_SERVICE_PROVIDER::GetUnsited() -= GetUnsitedFunctor();
	}
}

__if_exists(SiteControl_T::Global)
{
	static
}
	void EnsureInitialized()
	{
		__if_exists(SiteControl_T::Global)
		{
			if(m_spIVsUIShell == NULL)
			{
				m_spIVsUIShell = VSL_SERVICE_PROVIDER::GetCachedService<IVsUIShell, SID_SVsUIShell>();
				// Subscribe to the global service providers Unsited event, so that
				// that static members reference will get released properly.
				VSL_SERVICE_PROVIDER::GetUnsited() += GetUnsitedFunctor();
			}
		}
		if(m_spIVsUIShell == NULL)
		{
			// If the output window is not available all we can do is write a message on the debug output
			// and exit.
			VSL_TRACE(L"Can not get the VsUIShell service.");
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		}
	}

	__if_exists(SiteControl_T::Global)
	{
	static
	}
	CComPtr<IVsUIShell> m_spIVsUIShell;
};

__declspec(selectany) CComPtr<IVsUIShell> VsUIShellUtilities<>::m_spIVsUIShell;

} // namespace VSL

#endif // VSLPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
