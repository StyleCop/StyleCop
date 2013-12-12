/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLIBRARY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLIBRARY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsLibraryNotImpl :
	public IVsLibrary
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryNotImpl)

public:

	typedef IVsLibrary Interface;

	STDMETHOD(GetSupportedCategoryFields)(
		/*[in]*/ LIB_CATEGORY /*Category*/,
		/*[out,retval]*/ DWORD* /*pCatField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetList)(
		/*[in]*/ LIB_LISTTYPE /*ListType*/,
		/*[in]*/ LIB_LISTFLAGS /*Flags*/,
		/*[in]*/ VSOBSEARCHCRITERIA* /*pobSrch*/,
		/*[out,retval]*/ IVsObjectList** /*ppList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibList)(
		/*[in]*/ LIB_PERSISTTYPE /*lptType*/,
		/*[out,retval]*/ IVsLiteTreeList** /*ppList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibFlags)(
		/*[out,retval]*/ LIB_FLAGS* /*pfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* /*pCurUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuid)(
		/*[in]*/ const GUID** /*ppguidLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSeparatorString)(
		/*[in]*/ LPCWSTR* /*pszSeparator*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadState)(
		/*[in]*/ IStream* /*pIStream*/,
		/*[in]*/ LIB_PERSISTTYPE /*lptType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveState)(
		/*[in]*/ IStream* /*pIStream*/,
		/*[in]*/ LIB_PERSISTTYPE /*lptType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBrowseContainersForHierarchy)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ VSBROWSECONTAINER[] /*rgBrowseContainers*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddBrowseContainer)(
		/*[in]*/ PVSCOMPONENTSELECTORDATA /*pcdComponent*/,
		/*[in,out]*/ LIB_ADDREMOVEOPTIONS* /*pgrfOptions*/,
		/*[out]*/ BSTR* /*pbstrComponentAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveBrowseContainer)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ LPCWSTR /*pszLibName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLibraryMockImpl :
	public IVsLibrary,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLibraryMockImpl)

	typedef IVsLibrary Interface;
	struct GetSupportedCategoryFieldsValidValues
	{
		/*[in]*/ LIB_CATEGORY Category;
		/*[out,retval]*/ DWORD* pCatField;
		HRESULT retValue;
	};

	STDMETHOD(GetSupportedCategoryFields)(
		/*[in]*/ LIB_CATEGORY Category,
		/*[out,retval]*/ DWORD* pCatField)
	{
		VSL_DEFINE_MOCK_METHOD(GetSupportedCategoryFields)

		VSL_CHECK_VALIDVALUE(Category);

		VSL_SET_VALIDVALUE(pCatField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListValidValues
	{
		/*[in]*/ LIB_LISTTYPE ListType;
		/*[in]*/ LIB_LISTFLAGS Flags;
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch;
		/*[out,retval]*/ IVsObjectList** ppList;
		HRESULT retValue;
	};

	STDMETHOD(GetList)(
		/*[in]*/ LIB_LISTTYPE ListType,
		/*[in]*/ LIB_LISTFLAGS Flags,
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch,
		/*[out,retval]*/ IVsObjectList** ppList)
	{
		VSL_DEFINE_MOCK_METHOD(GetList)

		VSL_CHECK_VALIDVALUE(ListType);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLibListValidValues
	{
		/*[in]*/ LIB_PERSISTTYPE lptType;
		/*[out,retval]*/ IVsLiteTreeList** ppList;
		HRESULT retValue;
	};

	STDMETHOD(GetLibList)(
		/*[in]*/ LIB_PERSISTTYPE lptType,
		/*[out,retval]*/ IVsLiteTreeList** ppList)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibList)

		VSL_CHECK_VALIDVALUE(lptType);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLibFlagsValidValues
	{
		/*[out,retval]*/ LIB_FLAGS* pfFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetLibFlags)(
		/*[out,retval]*/ LIB_FLAGS* pfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibFlags)

		VSL_SET_VALIDVALUE(pfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateCounterValidValues
	{
		/*[out]*/ ULONG* pCurUpdate;
		HRESULT retValue;
	};

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* pCurUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateCounter)

		VSL_SET_VALIDVALUE(pCurUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidValidValues
	{
		/*[in]*/ GUID** ppguidLib;
		HRESULT retValue;
	};

	STDMETHOD(GetGuid)(
		/*[in]*/ const GUID** ppguidLib)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuid)

		VSL_CHECK_VALIDVALUE_POINTER(ppguidLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSeparatorStringValidValues
	{
		/*[in]*/ LPCWSTR* pszSeparator;
		HRESULT retValue;
	};

	STDMETHOD(GetSeparatorString)(
		/*[in]*/ LPCWSTR* pszSeparator)
	{
		VSL_DEFINE_MOCK_METHOD(GetSeparatorString)

		VSL_CHECK_VALIDVALUE_POINTER(pszSeparator);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadStateValidValues
	{
		/*[in]*/ IStream* pIStream;
		/*[in]*/ LIB_PERSISTTYPE lptType;
		HRESULT retValue;
	};

	STDMETHOD(LoadState)(
		/*[in]*/ IStream* pIStream,
		/*[in]*/ LIB_PERSISTTYPE lptType)
	{
		VSL_DEFINE_MOCK_METHOD(LoadState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIStream);

		VSL_CHECK_VALIDVALUE(lptType);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveStateValidValues
	{
		/*[in]*/ IStream* pIStream;
		/*[in]*/ LIB_PERSISTTYPE lptType;
		HRESULT retValue;
	};

	STDMETHOD(SaveState)(
		/*[in]*/ IStream* pIStream,
		/*[in]*/ LIB_PERSISTTYPE lptType)
	{
		VSL_DEFINE_MOCK_METHOD(SaveState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIStream);

		VSL_CHECK_VALIDVALUE(lptType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBrowseContainersForHierarchyValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ VSBROWSECONTAINER* rgBrowseContainers;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetBrowseContainersForHierarchy)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ VSBROWSECONTAINER rgBrowseContainers[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetBrowseContainersForHierarchy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgBrowseContainers, celt*sizeof(rgBrowseContainers[0]), validValues.celt*sizeof(validValues.rgBrowseContainers[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddBrowseContainerValidValues
	{
		/*[in]*/ PVSCOMPONENTSELECTORDATA pcdComponent;
		/*[in,out]*/ LIB_ADDREMOVEOPTIONS* pgrfOptions;
		/*[out]*/ BSTR* pbstrComponentAdded;
		HRESULT retValue;
	};

	STDMETHOD(AddBrowseContainer)(
		/*[in]*/ PVSCOMPONENTSELECTORDATA pcdComponent,
		/*[in,out]*/ LIB_ADDREMOVEOPTIONS* pgrfOptions,
		/*[out]*/ BSTR* pbstrComponentAdded)
	{
		VSL_DEFINE_MOCK_METHOD(AddBrowseContainer)

		VSL_CHECK_VALIDVALUE(pcdComponent);

		VSL_SET_VALIDVALUE(pgrfOptions);

		VSL_SET_VALIDVALUE_BSTR(pbstrComponentAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveBrowseContainerValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ LPCWSTR pszLibName;
		HRESULT retValue;
	};

	STDMETHOD(RemoveBrowseContainer)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ LPCWSTR pszLibName)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveBrowseContainer)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLibName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLIBRARY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
