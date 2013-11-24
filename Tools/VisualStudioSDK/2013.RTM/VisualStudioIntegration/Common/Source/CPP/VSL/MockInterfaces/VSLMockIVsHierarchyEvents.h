/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyEventsNotImpl :
	public IVsHierarchyEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyEventsNotImpl)

public:

	typedef IVsHierarchyEvents Interface;

	STDMETHOD(OnItemAdded)(
		/*[in]*/ VSITEMID /*itemidParent*/,
		/*[in]*/ VSITEMID /*itemidSiblingPrev*/,
		/*[in]*/ VSITEMID /*itemidAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemsAppended)(
		/*[in]*/ VSITEMID /*itemidParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemDeleted)(
		/*[in]*/ VSITEMID /*itemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPropertyChanged)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHPROPID /*propid*/,
		/*[in]*/ DWORD /*flags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInvalidateItems)(
		/*[in]*/ VSITEMID /*itemidParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInvalidateIcon)(
		/*[in]*/ HICON /*hicon*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyEventsMockImpl :
	public IVsHierarchyEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyEventsMockImpl)

	typedef IVsHierarchyEvents Interface;
	struct OnItemAddedValidValues
	{
		/*[in]*/ VSITEMID itemidParent;
		/*[in]*/ VSITEMID itemidSiblingPrev;
		/*[in]*/ VSITEMID itemidAdded;
		HRESULT retValue;
	};

	STDMETHOD(OnItemAdded)(
		/*[in]*/ VSITEMID itemidParent,
		/*[in]*/ VSITEMID itemidSiblingPrev,
		/*[in]*/ VSITEMID itemidAdded)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemAdded)

		VSL_CHECK_VALIDVALUE(itemidParent);

		VSL_CHECK_VALIDVALUE(itemidSiblingPrev);

		VSL_CHECK_VALIDVALUE(itemidAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemsAppendedValidValues
	{
		/*[in]*/ VSITEMID itemidParent;
		HRESULT retValue;
	};

	STDMETHOD(OnItemsAppended)(
		/*[in]*/ VSITEMID itemidParent)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemsAppended)

		VSL_CHECK_VALIDVALUE(itemidParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemDeletedValidValues
	{
		/*[in]*/ VSITEMID itemid;
		HRESULT retValue;
	};

	STDMETHOD(OnItemDeleted)(
		/*[in]*/ VSITEMID itemid)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemDeleted)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPropertyChangedValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHPROPID propid;
		/*[in]*/ DWORD flags;
		HRESULT retValue;
	};

	STDMETHOD(OnPropertyChanged)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHPROPID propid,
		/*[in]*/ DWORD flags)
	{
		VSL_DEFINE_MOCK_METHOD(OnPropertyChanged)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInvalidateItemsValidValues
	{
		/*[in]*/ VSITEMID itemidParent;
		HRESULT retValue;
	};

	STDMETHOD(OnInvalidateItems)(
		/*[in]*/ VSITEMID itemidParent)
	{
		VSL_DEFINE_MOCK_METHOD(OnInvalidateItems)

		VSL_CHECK_VALIDVALUE(itemidParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInvalidateIconValidValues
	{
		/*[in]*/ HICON hicon;
		HRESULT retValue;
	};

	STDMETHOD(OnInvalidateIcon)(
		/*[in]*/ HICON hicon)
	{
		VSL_DEFINE_MOCK_METHOD(OnInvalidateIcon)

		VSL_CHECK_VALIDVALUE(hicon);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
