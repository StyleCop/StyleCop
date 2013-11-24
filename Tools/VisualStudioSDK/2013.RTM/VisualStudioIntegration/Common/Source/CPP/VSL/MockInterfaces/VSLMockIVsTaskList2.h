/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKLIST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKLIST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskList2NotImpl :
	public IVsTaskList2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskList2NotImpl)

public:

	typedef IVsTaskList2 Interface;

	STDMETHOD(GetSelectionCount)(
		/*[out]*/ int* /*pnItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCaretPos)(
		/*[out]*/ IVsTaskItem** /*ppItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumSelectedItems)(
		/*[out]*/ IVsEnumTaskItems** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectItems)(
		/*[in]*/ int /*nItems*/,
		/*[in,size_is(nItems)]*/ IVsTaskItem*[] /*pItems*/,
		/*[in]*/ VSTASKLISTSELECTIONTYPE /*tsfSelType*/,
		/*[in]*/ VSTASKLISTSELECTIONSCROLLPOS /*tsspScrollPos*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginTaskEdit)(
		/*[in]*/ IVsTaskItem* /*pItem*/,
		/*[in]*/ int /*iFocusField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetActiveProvider)(
		/*[out]*/ IVsTaskProvider** /*ppProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetActiveProvider)(
		/*[in]*/ REFGUID /*rguidProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshOrAddTasks)(
		/*[in]*/ VSCOOKIE /*vsProviderCookie*/,
		/*[in]*/ int /*nTasks*/,
		/*[in,size_is(nTasks)]*/ IVsTaskItem*[] /*prgTasks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveTasks)(
		/*[in]*/ VSCOOKIE /*vsProviderCookie*/,
		/*[in]*/ int /*nTasks*/,
		/*[in,size_is(nTasks)]*/ IVsTaskItem*[] /*prgTasks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshAllProviders)()VSL_STDMETHOD_NOTIMPL
};

class IVsTaskList2MockImpl :
	public IVsTaskList2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskList2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskList2MockImpl)

	typedef IVsTaskList2 Interface;
	struct GetSelectionCountValidValues
	{
		/*[out]*/ int* pnItems;
		HRESULT retValue;
	};

	STDMETHOD(GetSelectionCount)(
		/*[out]*/ int* pnItems)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelectionCount)

		VSL_SET_VALIDVALUE(pnItems);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCaretPosValidValues
	{
		/*[out]*/ IVsTaskItem** ppItem;
		HRESULT retValue;
	};

	STDMETHOD(GetCaretPos)(
		/*[out]*/ IVsTaskItem** ppItem)
	{
		VSL_DEFINE_MOCK_METHOD(GetCaretPos)

		VSL_SET_VALIDVALUE_INTERFACE(ppItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumSelectedItemsValidValues
	{
		/*[out]*/ IVsEnumTaskItems** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumSelectedItems)(
		/*[out]*/ IVsEnumTaskItems** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumSelectedItems)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectItemsValidValues
	{
		/*[in]*/ int nItems;
		/*[in,size_is(nItems)]*/ IVsTaskItem** pItems;
		/*[in]*/ VSTASKLISTSELECTIONTYPE tsfSelType;
		/*[in]*/ VSTASKLISTSELECTIONSCROLLPOS tsspScrollPos;
		HRESULT retValue;
	};

	STDMETHOD(SelectItems)(
		/*[in]*/ int nItems,
		/*[in,size_is(nItems)]*/ IVsTaskItem* pItems[],
		/*[in]*/ VSTASKLISTSELECTIONTYPE tsfSelType,
		/*[in]*/ VSTASKLISTSELECTIONSCROLLPOS tsspScrollPos)
	{
		VSL_DEFINE_MOCK_METHOD(SelectItems)

		VSL_CHECK_VALIDVALUE(nItems);

		VSL_CHECK_VALIDVALUE_ARRAY(pItems, nItems, validValues.nItems);

		VSL_CHECK_VALIDVALUE(tsfSelType);

		VSL_CHECK_VALIDVALUE(tsspScrollPos);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginTaskEditValidValues
	{
		/*[in]*/ IVsTaskItem* pItem;
		/*[in]*/ int iFocusField;
		HRESULT retValue;
	};

	STDMETHOD(BeginTaskEdit)(
		/*[in]*/ IVsTaskItem* pItem,
		/*[in]*/ int iFocusField)
	{
		VSL_DEFINE_MOCK_METHOD(BeginTaskEdit)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pItem);

		VSL_CHECK_VALIDVALUE(iFocusField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetActiveProviderValidValues
	{
		/*[out]*/ IVsTaskProvider** ppProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetActiveProvider)(
		/*[out]*/ IVsTaskProvider** ppProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetActiveProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetActiveProviderValidValues
	{
		/*[in]*/ REFGUID rguidProvider;
		HRESULT retValue;
	};

	STDMETHOD(SetActiveProvider)(
		/*[in]*/ REFGUID rguidProvider)
	{
		VSL_DEFINE_MOCK_METHOD(SetActiveProvider)

		VSL_CHECK_VALIDVALUE(rguidProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshOrAddTasksValidValues
	{
		/*[in]*/ VSCOOKIE vsProviderCookie;
		/*[in]*/ int nTasks;
		/*[in,size_is(nTasks)]*/ IVsTaskItem** prgTasks;
		HRESULT retValue;
	};

	STDMETHOD(RefreshOrAddTasks)(
		/*[in]*/ VSCOOKIE vsProviderCookie,
		/*[in]*/ int nTasks,
		/*[in,size_is(nTasks)]*/ IVsTaskItem* prgTasks[])
	{
		VSL_DEFINE_MOCK_METHOD(RefreshOrAddTasks)

		VSL_CHECK_VALIDVALUE(vsProviderCookie);

		VSL_CHECK_VALIDVALUE(nTasks);

		VSL_CHECK_VALIDVALUE_ARRAY(prgTasks, nTasks, validValues.nTasks);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveTasksValidValues
	{
		/*[in]*/ VSCOOKIE vsProviderCookie;
		/*[in]*/ int nTasks;
		/*[in,size_is(nTasks)]*/ IVsTaskItem** prgTasks;
		HRESULT retValue;
	};

	STDMETHOD(RemoveTasks)(
		/*[in]*/ VSCOOKIE vsProviderCookie,
		/*[in]*/ int nTasks,
		/*[in,size_is(nTasks)]*/ IVsTaskItem* prgTasks[])
	{
		VSL_DEFINE_MOCK_METHOD(RemoveTasks)

		VSL_CHECK_VALIDVALUE(vsProviderCookie);

		VSL_CHECK_VALIDVALUE(nTasks);

		VSL_CHECK_VALIDVALUE_ARRAY(prgTasks, nTasks, validValues.nTasks);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshAllProvidersValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RefreshAllProviders)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RefreshAllProviders)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKLIST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
