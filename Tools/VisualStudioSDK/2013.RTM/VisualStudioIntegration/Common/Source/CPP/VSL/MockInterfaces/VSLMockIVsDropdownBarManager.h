/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDROPDOWNBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDROPDOWNBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDropdownBarManagerNotImpl :
	public IVsDropdownBarManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDropdownBarManagerNotImpl)

public:

	typedef IVsDropdownBarManager Interface;

	STDMETHOD(AddDropdownBar)(
		/*[in]*/ long /*cCombos*/,
		/*[in]*/ IVsDropdownBarClient* /*pClient*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDropdownBar)(
		/*[out]*/ IVsDropdownBar** /*ppDropdownBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveDropdownBar)()VSL_STDMETHOD_NOTIMPL
};

class IVsDropdownBarManagerMockImpl :
	public IVsDropdownBarManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDropdownBarManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDropdownBarManagerMockImpl)

	typedef IVsDropdownBarManager Interface;
	struct AddDropdownBarValidValues
	{
		/*[in]*/ long cCombos;
		/*[in]*/ IVsDropdownBarClient* pClient;
		HRESULT retValue;
	};

	STDMETHOD(AddDropdownBar)(
		/*[in]*/ long cCombos,
		/*[in]*/ IVsDropdownBarClient* pClient)
	{
		VSL_DEFINE_MOCK_METHOD(AddDropdownBar)

		VSL_CHECK_VALIDVALUE(cCombos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDropdownBarValidValues
	{
		/*[out]*/ IVsDropdownBar** ppDropdownBar;
		HRESULT retValue;
	};

	STDMETHOD(GetDropdownBar)(
		/*[out]*/ IVsDropdownBar** ppDropdownBar)
	{
		VSL_DEFINE_MOCK_METHOD(GetDropdownBar)

		VSL_SET_VALIDVALUE_INTERFACE(ppDropdownBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveDropdownBarValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveDropdownBar)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveDropdownBar)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDROPDOWNBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
