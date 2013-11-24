/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMENUITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMENUITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMenuItemNotImpl :
	public IVsMenuItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuItemNotImpl)

public:

	typedef IVsMenuItem Interface;

	STDMETHOD(IMISetProp)(
		/*[in]*/ VSMEPROPID /*PropId*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IMIGetProp)(
		/*[in]*/ VSMEPROPID /*PropId*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IMISetExtraProps)(
		/*[in]*/ LPSTREAM /*pstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IMIGetExtraProps)(
		/*[in]*/ LPSTREAM /*pstm*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMenuItemMockImpl :
	public IVsMenuItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMenuItemMockImpl)

	typedef IVsMenuItem Interface;
	struct IMISetPropValidValues
	{
		/*[in]*/ VSMEPROPID PropId;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(IMISetProp)(
		/*[in]*/ VSMEPROPID PropId,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(IMISetProp)

		VSL_CHECK_VALIDVALUE(PropId);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct IMIGetPropValidValues
	{
		/*[in]*/ VSMEPROPID PropId;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(IMIGetProp)(
		/*[in]*/ VSMEPROPID PropId,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(IMIGetProp)

		VSL_CHECK_VALIDVALUE(PropId);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct IMISetExtraPropsValidValues
	{
		/*[in]*/ LPSTREAM pstm;
		HRESULT retValue;
	};

	STDMETHOD(IMISetExtraProps)(
		/*[in]*/ LPSTREAM pstm)
	{
		VSL_DEFINE_MOCK_METHOD(IMISetExtraProps)

		VSL_CHECK_VALIDVALUE(pstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct IMIGetExtraPropsValidValues
	{
		/*[in]*/ LPSTREAM pstm;
		HRESULT retValue;
	};

	STDMETHOD(IMIGetExtraProps)(
		/*[in]*/ LPSTREAM pstm)
	{
		VSL_DEFINE_MOCK_METHOD(IMIGetExtraProps)

		VSL_CHECK_VALIDVALUE(pstm);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMENUITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
