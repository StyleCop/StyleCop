/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSIMPLEBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSIMPLEBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSimpleBrowseComponentSetNotImpl :
	public IVsSimpleBrowseComponentSet
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSimpleBrowseComponentSetNotImpl)

public:

	typedef IVsSimpleBrowseComponentSet Interface;

	STDMETHOD(put_RootNavInfo)(
		/*[in]*/ IVsNavInfo* /*pRootNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RootNavInfo)(
		/*[out,retval]*/ IVsNavInfo** /*pRootNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Owner)(
		/*[in]*/ IUnknown* /*pOwner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Owner)(
		/*[out,retval]*/ IUnknown** /*ppOwner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindComponent)(
		/*[in]*/ REFGUID /*guidLib*/,
		/*[in]*/ VSCOMPONENTSELECTORDATA* /*pcsdComponent*/,
		/*[out]*/ IVsNavInfo** /*ppRealLibNavInfo*/,
		/*[out]*/ VSCOMPONENTSELECTORDATA* /*pcsdExistingComponent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddComponent)(
		/*[in]*/ REFGUID /*guidLib*/,
		/*[in]*/ VSCOMPONENTSELECTORDATA* /*pcsdComponent*/,
		/*[out]*/ IVsNavInfo** /*ppRealLibNavInfo*/,
		/*[out]*/ VSCOMPONENTSELECTORDATA* /*pcsdAddedComponent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveComponent)(
		/*[in]*/ IVsNavInfo* /*pRealLibNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAllComponents)()VSL_STDMETHOD_NOTIMPL

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

class IVsSimpleBrowseComponentSetMockImpl :
	public IVsSimpleBrowseComponentSet,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSimpleBrowseComponentSetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSimpleBrowseComponentSetMockImpl)

	typedef IVsSimpleBrowseComponentSet Interface;
	struct put_RootNavInfoValidValues
	{
		/*[in]*/ IVsNavInfo* pRootNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(put_RootNavInfo)(
		/*[in]*/ IVsNavInfo* pRootNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(put_RootNavInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRootNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RootNavInfoValidValues
	{
		/*[out,retval]*/ IVsNavInfo** pRootNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(get_RootNavInfo)(
		/*[out,retval]*/ IVsNavInfo** pRootNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(get_RootNavInfo)

		VSL_SET_VALIDVALUE_INTERFACE(pRootNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OwnerValidValues
	{
		/*[in]*/ IUnknown* pOwner;
		HRESULT retValue;
	};

	STDMETHOD(put_Owner)(
		/*[in]*/ IUnknown* pOwner)
	{
		VSL_DEFINE_MOCK_METHOD(put_Owner)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwner);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OwnerValidValues
	{
		/*[out,retval]*/ IUnknown** ppOwner;
		HRESULT retValue;
	};

	STDMETHOD(get_Owner)(
		/*[out,retval]*/ IUnknown** ppOwner)
	{
		VSL_DEFINE_MOCK_METHOD(get_Owner)

		VSL_SET_VALIDVALUE_INTERFACE(ppOwner);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindComponentValidValues
	{
		/*[in]*/ REFGUID guidLib;
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent;
		/*[out]*/ IVsNavInfo** ppRealLibNavInfo;
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdExistingComponent;
		HRESULT retValue;
	};

	STDMETHOD(FindComponent)(
		/*[in]*/ REFGUID guidLib,
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent,
		/*[out]*/ IVsNavInfo** ppRealLibNavInfo,
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdExistingComponent)
	{
		VSL_DEFINE_MOCK_METHOD(FindComponent)

		VSL_CHECK_VALIDVALUE(guidLib);

		VSL_CHECK_VALIDVALUE_POINTER(pcsdComponent);

		VSL_SET_VALIDVALUE_INTERFACE(ppRealLibNavInfo);

		VSL_SET_VALIDVALUE(pcsdExistingComponent);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddComponentValidValues
	{
		/*[in]*/ REFGUID guidLib;
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent;
		/*[out]*/ IVsNavInfo** ppRealLibNavInfo;
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdAddedComponent;
		HRESULT retValue;
	};

	STDMETHOD(AddComponent)(
		/*[in]*/ REFGUID guidLib,
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent,
		/*[out]*/ IVsNavInfo** ppRealLibNavInfo,
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdAddedComponent)
	{
		VSL_DEFINE_MOCK_METHOD(AddComponent)

		VSL_CHECK_VALIDVALUE(guidLib);

		VSL_CHECK_VALIDVALUE_POINTER(pcsdComponent);

		VSL_SET_VALIDVALUE_INTERFACE(ppRealLibNavInfo);

		VSL_SET_VALIDVALUE(pcsdAddedComponent);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveComponentValidValues
	{
		/*[in]*/ IVsNavInfo* pRealLibNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(RemoveComponent)(
		/*[in]*/ IVsNavInfo* pRealLibNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveComponent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealLibNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAllComponentsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveAllComponents)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveAllComponents)

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

#endif // IVSSIMPLEBROWSECOMPONENTSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
