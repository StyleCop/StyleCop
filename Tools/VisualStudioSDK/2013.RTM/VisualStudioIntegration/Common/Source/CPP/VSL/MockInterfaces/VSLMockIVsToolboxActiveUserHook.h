/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOXACTIVEUSERHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOXACTIVEUSERHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolboxActiveUserHookNotImpl :
	public IVsToolboxActiveUserHook
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxActiveUserHookNotImpl)

public:

	typedef IVsToolboxActiveUserHook Interface;

	STDMETHOD(InterceptDataObject)(
		/*[in]*/ IDataObject* /*pIn*/,
		/*[out]*/ IDataObject** /*ppOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToolboxSelectionChanged)(
		/*[in]*/ IDataObject* /*pSelected*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxActiveUserHookMockImpl :
	public IVsToolboxActiveUserHook,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxActiveUserHookMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxActiveUserHookMockImpl)

	typedef IVsToolboxActiveUserHook Interface;
	struct InterceptDataObjectValidValues
	{
		/*[in]*/ IDataObject* pIn;
		/*[out]*/ IDataObject** ppOut;
		HRESULT retValue;
	};

	STDMETHOD(InterceptDataObject)(
		/*[in]*/ IDataObject* pIn,
		/*[out]*/ IDataObject** ppOut)
	{
		VSL_DEFINE_MOCK_METHOD(InterceptDataObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIn);

		VSL_SET_VALIDVALUE_INTERFACE(ppOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToolboxSelectionChangedValidValues
	{
		/*[in]*/ IDataObject* pSelected;
		HRESULT retValue;
	};

	STDMETHOD(ToolboxSelectionChanged)(
		/*[in]*/ IDataObject* pSelected)
	{
		VSL_DEFINE_MOCK_METHOD(ToolboxSelectionChanged)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSelected);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOXACTIVEUSERHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
