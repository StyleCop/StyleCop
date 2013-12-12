/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUTTONBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUTTONBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsButtonBarManagerNotImpl :
	public IVsButtonBarManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsButtonBarManagerNotImpl)

public:

	typedef IVsButtonBarManager Interface;

	STDMETHOD(AddButtonBar)(
		/*[in]*/ long /*cButtons*/,
		/*[in]*/ HANDLE /*hImageList*/,
		/*[in]*/ IVsButtonBarClient* /*pClient*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetButtonBar)(
		/*[out]*/ IVsButtonBar** /*ppButtonBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveButtonBar)()VSL_STDMETHOD_NOTIMPL
};

class IVsButtonBarManagerMockImpl :
	public IVsButtonBarManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsButtonBarManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsButtonBarManagerMockImpl)

	typedef IVsButtonBarManager Interface;
	struct AddButtonBarValidValues
	{
		/*[in]*/ long cButtons;
		/*[in]*/ HANDLE hImageList;
		/*[in]*/ IVsButtonBarClient* pClient;
		HRESULT retValue;
	};

	STDMETHOD(AddButtonBar)(
		/*[in]*/ long cButtons,
		/*[in]*/ HANDLE hImageList,
		/*[in]*/ IVsButtonBarClient* pClient)
	{
		VSL_DEFINE_MOCK_METHOD(AddButtonBar)

		VSL_CHECK_VALIDVALUE(cButtons);

		VSL_CHECK_VALIDVALUE(hImageList);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetButtonBarValidValues
	{
		/*[out]*/ IVsButtonBar** ppButtonBar;
		HRESULT retValue;
	};

	STDMETHOD(GetButtonBar)(
		/*[out]*/ IVsButtonBar** ppButtonBar)
	{
		VSL_DEFINE_MOCK_METHOD(GetButtonBar)

		VSL_SET_VALIDVALUE_INTERFACE(ppButtonBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveButtonBarValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveButtonBar)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveButtonBar)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUTTONBARMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
