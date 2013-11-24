/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMBINEDBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMBINEDBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCombinedBrowseComponentSetNotImpl :
	public IVsCombinedBrowseComponentSet
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCombinedBrowseComponentSetNotImpl)

public:

	typedef IVsCombinedBrowseComponentSet Interface;

	STDMETHOD(AddSet)(
		/*[in]*/ IVsSimpleBrowseComponentSet* /*pSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSetCount)(
		/*[in]*/ ULONG* /*pulCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSetAt)(
		/*[in]*/ ULONG /*ulIndex*/,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** /*ppSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveSetAt)(
		/*[in]*/ ULONG /*ulIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAllSets)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveOwnerSets)(
		/*[in]*/ IUnknown* /*pOwner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ComponentsListOptions)(
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ComponentsListOptions)(
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* /*pdwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ChildListOptions)(
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ChildListOptions)(
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* /*pdwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetList2)(
		/*[in]*/ LIB_LISTTYPE2 /*ListType*/,
		/*[in]*/ LIB_LISTFLAGS /*Flags*/,
		/*[in]*/ VSOBSEARCHCRITERIA2* /*pobSrch*/,
		/*[in]*/ IVsObjectList2* /*pExtraListToCombineWith*/,
		/*[out,retval]*/ IVsObjectList2** /*ppIVsObjectList2*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSupportedCategoryFields2)(
		/*[in]*/ LIB_CATEGORY2 /*Category*/,
		/*[out,retval]*/ DWORD* /*pgrfCatField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNavInfo)(
		/*[in]*/ REFGUID /*guidLib*/,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE[] /*rgSymbolNodes*/,
		/*[in]*/ ULONG /*ulcNodes*/,
		/*[out,retval]*/ IVsNavInfo** /*ppNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* /*pCurUpdate*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCombinedBrowseComponentSetMockImpl :
	public IVsCombinedBrowseComponentSet,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCombinedBrowseComponentSetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCombinedBrowseComponentSetMockImpl)

	typedef IVsCombinedBrowseComponentSet Interface;
	struct AddSetValidValues
	{
		/*[in]*/ IVsSimpleBrowseComponentSet* pSet;
		HRESULT retValue;
	};

	STDMETHOD(AddSet)(
		/*[in]*/ IVsSimpleBrowseComponentSet* pSet)
	{
		VSL_DEFINE_MOCK_METHOD(AddSet)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSetCountValidValues
	{
		/*[in]*/ ULONG* pulCount;
		HRESULT retValue;
	};

	STDMETHOD(GetSetCount)(
		/*[in]*/ ULONG* pulCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetSetCount)

		VSL_CHECK_VALIDVALUE_POINTER(pulCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSetAtValidValues
	{
		/*[in]*/ ULONG ulIndex;
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet;
		HRESULT retValue;
	};

	STDMETHOD(GetSetAt)(
		/*[in]*/ ULONG ulIndex,
		/*[out,retval]*/ IVsSimpleBrowseComponentSet** ppSet)
	{
		VSL_DEFINE_MOCK_METHOD(GetSetAt)

		VSL_CHECK_VALIDVALUE(ulIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveSetAtValidValues
	{
		/*[in]*/ ULONG ulIndex;
		HRESULT retValue;
	};

	STDMETHOD(RemoveSetAt)(
		/*[in]*/ ULONG ulIndex)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveSetAt)

		VSL_CHECK_VALIDVALUE(ulIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAllSetsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveAllSets)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveAllSets)

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveOwnerSetsValidValues
	{
		/*[in]*/ IUnknown* pOwner;
		HRESULT retValue;
	};

	STDMETHOD(RemoveOwnerSets)(
		/*[in]*/ IUnknown* pOwner)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveOwnerSets)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwner);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ComponentsListOptionsValidValues
	{
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(put_ComponentsListOptions)(
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(put_ComponentsListOptions)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ComponentsListOptionsValidValues
	{
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* pdwOptions;
		HRESULT retValue;
	};

	STDMETHOD(get_ComponentsListOptions)(
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* pdwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(get_ComponentsListOptions)

		VSL_SET_VALIDVALUE(pdwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ChildListOptionsValidValues
	{
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(put_ChildListOptions)(
		/*[in]*/ BROWSE_COMPONENT_SET_OPTIONS dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(put_ChildListOptions)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ChildListOptionsValidValues
	{
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* pdwOptions;
		HRESULT retValue;
	};

	STDMETHOD(get_ChildListOptions)(
		/*[out,retval]*/ BROWSE_COMPONENT_SET_OPTIONS* pdwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(get_ChildListOptions)

		VSL_SET_VALIDVALUE(pdwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetList2ValidValues
	{
		/*[in]*/ LIB_LISTTYPE2 ListType;
		/*[in]*/ LIB_LISTFLAGS Flags;
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch;
		/*[in]*/ IVsObjectList2* pExtraListToCombineWith;
		/*[out,retval]*/ IVsObjectList2** ppIVsObjectList2;
		HRESULT retValue;
	};

	STDMETHOD(GetList2)(
		/*[in]*/ LIB_LISTTYPE2 ListType,
		/*[in]*/ LIB_LISTFLAGS Flags,
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch,
		/*[in]*/ IVsObjectList2* pExtraListToCombineWith,
		/*[out,retval]*/ IVsObjectList2** ppIVsObjectList2)
	{
		VSL_DEFINE_MOCK_METHOD(GetList2)

		VSL_CHECK_VALIDVALUE(ListType);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExtraListToCombineWith);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsObjectList2);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct CreateNavInfoValidValues
	{
		/*[in]*/ REFGUID guidLib;
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE* rgSymbolNodes;
		/*[in]*/ ULONG ulcNodes;
		/*[out,retval]*/ IVsNavInfo** ppNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(CreateNavInfo)(
		/*[in]*/ REFGUID guidLib,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE rgSymbolNodes[],
		/*[in]*/ ULONG ulcNodes,
		/*[out,retval]*/ IVsNavInfo** ppNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNavInfo)

		VSL_CHECK_VALIDVALUE(guidLib);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSymbolNodes, ulcNodes*sizeof(rgSymbolNodes[0]), validValues.ulcNodes*sizeof(validValues.rgSymbolNodes[0]));

		VSL_CHECK_VALIDVALUE(ulcNodes);

		VSL_SET_VALIDVALUE_INTERFACE(ppNavInfo);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMBINEDBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
