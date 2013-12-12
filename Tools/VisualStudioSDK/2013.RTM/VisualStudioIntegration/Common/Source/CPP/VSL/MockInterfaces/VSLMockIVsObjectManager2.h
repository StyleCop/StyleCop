/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJECTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJECTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsObjectManager2NotImpl :
	public IVsObjectManager2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectManager2NotImpl)

public:

	typedef IVsObjectManager2 Interface;

	STDMETHOD(RegisterLibrary)(
		/*[in]*/ IVsLibrary2* /*pLib*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterSimpleLibrary)(
		/*[in]*/ IVsSimpleLibrary2* /*pLib*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterLibrary)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumLibraries)(
		/*[out]*/ IVsEnumLibraries2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindLibrary)(
		/*[in]*/ REFGUID /*guidLibrary*/,
		/*[out]*/ IVsLibrary2** /*ppLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListAndIndex)(
		/*[in]*/ IVsNavInfo* /*pNavInfo*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ IVsObjectList2** /*ppList*/,
		/*[out]*/ ULONG* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseDataObject)(
		/*[in]*/ IDataObject* /*pIDataObject*/,
		/*[out]*/ IVsSelectedSymbols** /*ppSymbols*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateSimpleBrowseComponentSet)(
		/*[in]*/ BROWSE_COMPONENT_SET_TYPE /*Type*/,
		/*[in,size_is(ulcLibs)]*/ const GUID[] /*rgguidLibs*/,
		/*[in]*/ ULONG /*ulcLibs*/,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** /*ppSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateProjectReferenceSet)(
		/*[in]*/ IUnknown* /*pProject*/,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** /*ppSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateCombinedBrowseComponentSet)(
		/*[out,retval]*/ IVsCombinedBrowseComponentSet** /*ppCombinedSet*/)VSL_STDMETHOD_NOTIMPL
};

class IVsObjectManager2MockImpl :
	public IVsObjectManager2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectManager2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjectManager2MockImpl)

	typedef IVsObjectManager2 Interface;
	struct RegisterLibraryValidValues
	{
		/*[in]*/ IVsLibrary2* pLib;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterLibrary)(
		/*[in]*/ IVsLibrary2* pLib,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterLibrary)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLib);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterSimpleLibraryValidValues
	{
		/*[in]*/ IVsSimpleLibrary2* pLib;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterSimpleLibrary)(
		/*[in]*/ IVsSimpleLibrary2* pLib,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterSimpleLibrary)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLib);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterLibraryValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterLibrary)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterLibrary)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumLibrariesValidValues
	{
		/*[out]*/ IVsEnumLibraries2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumLibraries)(
		/*[out]*/ IVsEnumLibraries2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumLibraries)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindLibraryValidValues
	{
		/*[in]*/ REFGUID guidLibrary;
		/*[out]*/ IVsLibrary2** ppLib;
		HRESULT retValue;
	};

	STDMETHOD(FindLibrary)(
		/*[in]*/ REFGUID guidLibrary,
		/*[out]*/ IVsLibrary2** ppLib)
	{
		VSL_DEFINE_MOCK_METHOD(FindLibrary)

		VSL_CHECK_VALIDVALUE(guidLibrary);

		VSL_SET_VALIDVALUE_INTERFACE(ppLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListAndIndexValidValues
	{
		/*[in]*/ IVsNavInfo* pNavInfo;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ IVsObjectList2** ppList;
		/*[out]*/ ULONG* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetListAndIndex)(
		/*[in]*/ IVsNavInfo* pNavInfo,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ IVsObjectList2** ppList,
		/*[out]*/ ULONG* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetListAndIndex)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNavInfo);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseDataObjectValidValues
	{
		/*[in]*/ IDataObject* pIDataObject;
		/*[out]*/ IVsSelectedSymbols** ppSymbols;
		HRESULT retValue;
	};

	STDMETHOD(ParseDataObject)(
		/*[in]*/ IDataObject* pIDataObject,
		/*[out]*/ IVsSelectedSymbols** ppSymbols)
	{
		VSL_DEFINE_MOCK_METHOD(ParseDataObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIDataObject);

		VSL_SET_VALIDVALUE_INTERFACE(ppSymbols);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateSimpleBrowseComponentSetValidValues
	{
		/*[in]*/ BROWSE_COMPONENT_SET_TYPE Type;
		/*[in,size_is(ulcLibs)]*/ GUID* rgguidLibs;
		/*[in]*/ ULONG ulcLibs;
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet;
		HRESULT retValue;
	};

	STDMETHOD(CreateSimpleBrowseComponentSet)(
		/*[in]*/ BROWSE_COMPONENT_SET_TYPE Type,
		/*[in,size_is(ulcLibs)]*/ const GUID rgguidLibs[],
		/*[in]*/ ULONG ulcLibs,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet)
	{
		VSL_DEFINE_MOCK_METHOD(CreateSimpleBrowseComponentSet)

		VSL_CHECK_VALIDVALUE(Type);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidLibs, ulcLibs*sizeof(rgguidLibs[0]), validValues.ulcLibs*sizeof(validValues.rgguidLibs[0]));

		VSL_CHECK_VALIDVALUE(ulcLibs);

		VSL_SET_VALIDVALUE_INTERFACE(ppSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateProjectReferenceSetValidValues
	{
		/*[in]*/ IUnknown* pProject;
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet;
		HRESULT retValue;
	};

	STDMETHOD(CreateProjectReferenceSet)(
		/*[in]*/ IUnknown* pProject,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet)
	{
		VSL_DEFINE_MOCK_METHOD(CreateProjectReferenceSet)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_SET_VALIDVALUE_INTERFACE(ppSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateCombinedBrowseComponentSetValidValues
	{
		/*[out,retval]*/ IVsCombinedBrowseComponentSet** ppCombinedSet;
		HRESULT retValue;
	};

	STDMETHOD(CreateCombinedBrowseComponentSet)(
		/*[out,retval]*/ IVsCombinedBrowseComponentSet** ppCombinedSet)
	{
		VSL_DEFINE_MOCK_METHOD(CreateCombinedBrowseComponentSet)

		VSL_SET_VALIDVALUE_INTERFACE(ppCombinedSet);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJECTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
