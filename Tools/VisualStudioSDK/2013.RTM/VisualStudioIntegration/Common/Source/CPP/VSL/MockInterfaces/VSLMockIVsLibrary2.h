/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLIBRARY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLIBRARY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLibrary2NotImpl :
	public IVsLibrary2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibrary2NotImpl)

public:

	typedef IVsLibrary2 Interface;

	STDMETHOD(GetSupportedCategoryFields2)(
		/*[in]*/ LIB_CATEGORY2 /*Category*/,
		/*[out,retval]*/ DWORD* /*pgrfCatField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetList2)(
		/*[in]*/ LIB_LISTTYPE2 /*ListType*/,
		/*[in]*/ LIB_LISTFLAGS /*Flags*/,
		/*[in]*/ VSOBSEARCHCRITERIA2* /*pobSrch*/,
		/*[out,retval]*/ IVsObjectList2** /*ppIVsObjectList2*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibList)(
		/*[in]*/ LIB_PERSISTTYPE /*lptType*/,
		/*[out,retval]*/ IVsLiteTreeList** /*ppList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibFlags2)(
		/*[out,retval]*/ LIB_FLAGS2* /*pgrfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* /*pCurUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuid)(
		/*[out]*/ const GUID** /*ppguidLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSeparatorString)(
		/*[out,string]*/ LPCWSTR* /*pszSeparator*/)VSL_STDMETHOD_NOTIMPL

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
		/*[out,optional]*/ BSTR* /*pbstrComponentAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveBrowseContainer)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ LPCWSTR /*pszLibName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNavInfo)(
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE[] /*rgSymbolNodes*/,
		/*[in]*/ ULONG /*ulcNodes*/,
		/*[out]*/ IVsNavInfo** /*ppNavInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLibrary2MockImpl :
	public IVsLibrary2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibrary2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLibrary2MockImpl)

	typedef IVsLibrary2 Interface;
	struct GetSupportedCategoryFields2ValidValues
	{
		/*[in]*/ LIB_CATEGORY2 Category;
		/*[out,retval]*/ DWORD* pgrfCatField;
		HRESULT retValue;
	};

	STDMETHOD(GetSupportedCategoryFields2)(
		/*[in]*/ LIB_CATEGORY2 Category,
		/*[out,retval]*/ DWORD* pgrfCatField)
	{
		VSL_DEFINE_MOCK_METHOD(GetSupportedCategoryFields2)

		VSL_CHECK_VALIDVALUE(Category);

		VSL_SET_VALIDVALUE(pgrfCatField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetList2ValidValues
	{
		/*[in]*/ LIB_LISTTYPE2 ListType;
		/*[in]*/ LIB_LISTFLAGS Flags;
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch;
		/*[out,retval]*/ IVsObjectList2** ppIVsObjectList2;
		HRESULT retValue;
	};

	STDMETHOD(GetList2)(
		/*[in]*/ LIB_LISTTYPE2 ListType,
		/*[in]*/ LIB_LISTFLAGS Flags,
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch,
		/*[out,retval]*/ IVsObjectList2** ppIVsObjectList2)
	{
		VSL_DEFINE_MOCK_METHOD(GetList2)

		VSL_CHECK_VALIDVALUE(ListType);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsObjectList2);

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
	struct GetLibFlags2ValidValues
	{
		/*[out,retval]*/ LIB_FLAGS2* pgrfFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetLibFlags2)(
		/*[out,retval]*/ LIB_FLAGS2* pgrfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibFlags2)

		VSL_SET_VALIDVALUE(pgrfFlags);

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
		/*[out]*/ GUID** ppguidLib;
		HRESULT retValue;
	};

	STDMETHOD(GetGuid)(
		/*[out]*/ const GUID** ppguidLib)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuid)

		VSL_SET_VALIDVALUE_CONST(ppguidLib, GUID**);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSeparatorStringValidValues
	{
		/*[out,string]*/ LPCWSTR* pszSeparator;
		HRESULT retValue;
	};

	STDMETHOD(GetSeparatorString)(
		/*[out,string]*/ LPCWSTR* pszSeparator)
	{
		VSL_DEFINE_MOCK_METHOD(GetSeparatorString)

		VSL_SET_VALIDVALUE(pszSeparator);

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
		/*[out,optional]*/ BSTR* pbstrComponentAdded;
		HRESULT retValue;
	};

	STDMETHOD(AddBrowseContainer)(
		/*[in]*/ PVSCOMPONENTSELECTORDATA pcdComponent,
		/*[in,out]*/ LIB_ADDREMOVEOPTIONS* pgrfOptions,
		/*[out,optional]*/ BSTR* pbstrComponentAdded)
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
	struct CreateNavInfoValidValues
	{
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE* rgSymbolNodes;
		/*[in]*/ ULONG ulcNodes;
		/*[out]*/ IVsNavInfo** ppNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(CreateNavInfo)(
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE rgSymbolNodes[],
		/*[in]*/ ULONG ulcNodes,
		/*[out]*/ IVsNavInfo** ppNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNavInfo)

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSymbolNodes, ulcNodes*sizeof(rgSymbolNodes[0]), validValues.ulcNodes*sizeof(validValues.rgSymbolNodes[0]));

		VSL_CHECK_VALIDVALUE(ulcNodes);

		VSL_SET_VALIDVALUE_INTERFACE(ppNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLIBRARY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
