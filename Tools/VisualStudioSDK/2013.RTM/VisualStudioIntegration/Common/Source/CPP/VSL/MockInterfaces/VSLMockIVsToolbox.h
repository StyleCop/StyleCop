/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolboxNotImpl :
	public IVsToolbox
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxNotImpl)

public:

	typedef IVsToolbox Interface;

	STDMETHOD(SetCursor)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetData)(
		/*[out,retval]*/ IDataObject** /*ppDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DataUsed)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFrame)(
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddItem)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[in]*/ PTBXITEMINFO /*ptif*/,
		/*[in]*/ LPCOLESTR /*lpszTab*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveItem)(
		/*[in]*/ IDataObject* /*pDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterDataProvider)(
		/*[in]*/ IVsToolboxDataProvider* /*pDP*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterDataProvider)(
		/*[in]*/ VSCOOKIE /*dwProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTab)(
		/*[out,retval]*/ BSTR* /*pbstrTab*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddTab)(
		/*[in]*/ LPCOLESTR /*lpszTab*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveTab)(
		/*[in]*/ LPCOLESTR /*lpszTab*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectTab)(
		/*[in]*/ LPCOLESTR /*lpszTab*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumTabs)(
		/*[out,retval]*/ IEnumToolboxTabs** /*pEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectItem)(
		/*[in]*/ IDataObject* /*pDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumItems)(
		/*[in]*/ LPCOLESTR /*lpszTab*/,
		/*[out]*/ IEnumToolboxItems** /*pEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetItemInfo)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[in]*/ PTBXITEMINFO /*ptif*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddActiveXItem)(
		/*[in]*/ REFCLSID /*clsid*/,
		/*[in]*/ LPCOLESTR /*lpszTab*/,
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateToolboxUI)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddItemFromFile)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ IVsHierarchy* /*pHierSource*/,
		/*[out,retval]*/ BOOL* /*pfItemAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCurrentUser)(
		/*[in]*/ IVsToolboxUser* /*pUser*/,
		/*[out,retval]*/ BOOL* /*pfCurrent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddTabEx)(
		/*[in]*/ LPCOLESTR /*lpszTab*/,
		/*[in]*/ VSTBXTABVIEW /*tv*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTabView)(
		/*[in]*/ LPCOLESTR /*lpszTab*/,
		/*[in]*/ VSTBXTABVIEW /*tv*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTabView)(
		/*[in]*/ LPCOLESTR /*lpszTab*/,
		/*[out,retval]*/ VSTBXTABVIEW* /*ptv*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxMockImpl :
	public IVsToolbox,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxMockImpl)

	typedef IVsToolbox Interface;
	struct SetCursorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetCursor)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetCursor)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDataValidValues
	{
		/*[out,retval]*/ IDataObject** ppDO;
		HRESULT retValue;
	};

	STDMETHOD(GetData)(
		/*[out,retval]*/ IDataObject** ppDO)
	{
		VSL_DEFINE_MOCK_METHOD(GetData)

		VSL_SET_VALIDVALUE_INTERFACE(ppDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct DataUsedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DataUsed)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DataUsed)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFrameValidValues
	{
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(GetFrame)(
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(GetFrame)

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddItemValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[in]*/ PTBXITEMINFO ptif;
		/*[in]*/ LPCOLESTR lpszTab;
		HRESULT retValue;
	};

	STDMETHOD(AddItem)(
		/*[in]*/ IDataObject* pDO,
		/*[in]*/ PTBXITEMINFO ptif,
		/*[in]*/ LPCOLESTR lpszTab)
	{
		VSL_DEFINE_MOCK_METHOD(AddItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_CHECK_VALIDVALUE(ptif);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveItemValidValues
	{
		/*[in]*/ IDataObject* pDO;
		HRESULT retValue;
	};

	STDMETHOD(RemoveItem)(
		/*[in]*/ IDataObject* pDO)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterDataProviderValidValues
	{
		/*[in]*/ IVsToolboxDataProvider* pDP;
		/*[out,retval]*/ VSCOOKIE* pdwProvider;
		HRESULT retValue;
	};

	STDMETHOD(RegisterDataProvider)(
		/*[in]*/ IVsToolboxDataProvider* pDP,
		/*[out,retval]*/ VSCOOKIE* pdwProvider)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterDataProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDP);

		VSL_SET_VALIDVALUE(pdwProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterDataProviderValidValues
	{
		/*[in]*/ VSCOOKIE dwProvider;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterDataProvider)(
		/*[in]*/ VSCOOKIE dwProvider)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterDataProvider)

		VSL_CHECK_VALIDVALUE(dwProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTab;
		HRESULT retValue;
	};

	STDMETHOD(GetTab)(
		/*[out,retval]*/ BSTR* pbstrTab)
	{
		VSL_DEFINE_MOCK_METHOD(GetTab)

		VSL_SET_VALIDVALUE_BSTR(pbstrTab);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddTabValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		HRESULT retValue;
	};

	STDMETHOD(AddTab)(
		/*[in]*/ LPCOLESTR lpszTab)
	{
		VSL_DEFINE_MOCK_METHOD(AddTab)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveTabValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		HRESULT retValue;
	};

	STDMETHOD(RemoveTab)(
		/*[in]*/ LPCOLESTR lpszTab)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveTab)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectTabValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		HRESULT retValue;
	};

	STDMETHOD(SelectTab)(
		/*[in]*/ LPCOLESTR lpszTab)
	{
		VSL_DEFINE_MOCK_METHOD(SelectTab)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumTabsValidValues
	{
		/*[out,retval]*/ IEnumToolboxTabs** pEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumTabs)(
		/*[out,retval]*/ IEnumToolboxTabs** pEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumTabs)

		VSL_SET_VALIDVALUE_INTERFACE(pEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectItemValidValues
	{
		/*[in]*/ IDataObject* pDO;
		HRESULT retValue;
	};

	STDMETHOD(SelectItem)(
		/*[in]*/ IDataObject* pDO)
	{
		VSL_DEFINE_MOCK_METHOD(SelectItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumItemsValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		/*[out]*/ IEnumToolboxItems** pEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumItems)(
		/*[in]*/ LPCOLESTR lpszTab,
		/*[out]*/ IEnumToolboxItems** pEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumItems)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_SET_VALIDVALUE_INTERFACE(pEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetItemInfoValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[in]*/ PTBXITEMINFO ptif;
		HRESULT retValue;
	};

	STDMETHOD(SetItemInfo)(
		/*[in]*/ IDataObject* pDO,
		/*[in]*/ PTBXITEMINFO ptif)
	{
		VSL_DEFINE_MOCK_METHOD(SetItemInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_CHECK_VALIDVALUE(ptif);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddActiveXItemValidValues
	{
		/*[in]*/ REFCLSID clsid;
		/*[in]*/ LPCOLESTR lpszTab;
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(AddActiveXItem)(
		/*[in]*/ REFCLSID clsid,
		/*[in]*/ LPCOLESTR lpszTab,
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(AddActiveXItem)

		VSL_CHECK_VALIDVALUE(clsid);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateToolboxUIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdateToolboxUI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdateToolboxUI)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddItemFromFileValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ IVsHierarchy* pHierSource;
		/*[out,retval]*/ BOOL* pfItemAdded;
		HRESULT retValue;
	};

	STDMETHOD(AddItemFromFile)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ IVsHierarchy* pHierSource,
		/*[out,retval]*/ BOOL* pfItemAdded)
	{
		VSL_DEFINE_MOCK_METHOD(AddItemFromFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierSource);

		VSL_SET_VALIDVALUE(pfItemAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCurrentUserValidValues
	{
		/*[in]*/ IVsToolboxUser* pUser;
		/*[out,retval]*/ BOOL* pfCurrent;
		HRESULT retValue;
	};

	STDMETHOD(IsCurrentUser)(
		/*[in]*/ IVsToolboxUser* pUser,
		/*[out,retval]*/ BOOL* pfCurrent)
	{
		VSL_DEFINE_MOCK_METHOD(IsCurrentUser)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_SET_VALIDVALUE(pfCurrent);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddTabExValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		/*[in]*/ VSTBXTABVIEW tv;
		HRESULT retValue;
	};

	STDMETHOD(AddTabEx)(
		/*[in]*/ LPCOLESTR lpszTab,
		/*[in]*/ VSTBXTABVIEW tv)
	{
		VSL_DEFINE_MOCK_METHOD(AddTabEx)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_CHECK_VALIDVALUE(tv);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTabViewValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		/*[in]*/ VSTBXTABVIEW tv;
		HRESULT retValue;
	};

	STDMETHOD(SetTabView)(
		/*[in]*/ LPCOLESTR lpszTab,
		/*[in]*/ VSTBXTABVIEW tv)
	{
		VSL_DEFINE_MOCK_METHOD(SetTabView)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_CHECK_VALIDVALUE(tv);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabViewValidValues
	{
		/*[in]*/ LPCOLESTR lpszTab;
		/*[out,retval]*/ VSTBXTABVIEW* ptv;
		HRESULT retValue;
	};

	STDMETHOD(GetTabView)(
		/*[in]*/ LPCOLESTR lpszTab,
		/*[out,retval]*/ VSTBXTABVIEW* ptv)
	{
		VSL_DEFINE_MOCK_METHOD(GetTabView)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTab);

		VSL_SET_VALIDVALUE(ptv);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
