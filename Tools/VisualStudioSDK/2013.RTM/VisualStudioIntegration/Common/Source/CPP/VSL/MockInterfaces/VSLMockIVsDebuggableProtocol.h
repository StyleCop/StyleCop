/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEBUGGABLEPROTOCOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEBUGGABLEPROTOCOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDebuggableProtocolNotImpl :
	public IVsDebuggableProtocol
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebuggableProtocolNotImpl)

public:

	typedef IVsDebuggableProtocol Interface;

	STDMETHOD(AddDebuggableProtocol)(
		/*[in]*/ LPOLESTR /*bstrProtocol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveDebuggableProtocol)(
		/*[in]*/ LPOLESTR /*bstrProtocol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsProtocolDebuggable)(
		/*[in]*/ LPOLESTR /*bstrProtocol*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDebuggableProtocolMockImpl :
	public IVsDebuggableProtocol,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebuggableProtocolMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDebuggableProtocolMockImpl)

	typedef IVsDebuggableProtocol Interface;
	struct AddDebuggableProtocolValidValues
	{
		/*[in]*/ LPOLESTR bstrProtocol;
		HRESULT retValue;
	};

	STDMETHOD(AddDebuggableProtocol)(
		/*[in]*/ LPOLESTR bstrProtocol)
	{
		VSL_DEFINE_MOCK_METHOD(AddDebuggableProtocol)

		VSL_CHECK_VALIDVALUE_STRINGW(bstrProtocol);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveDebuggableProtocolValidValues
	{
		/*[in]*/ LPOLESTR bstrProtocol;
		HRESULT retValue;
	};

	STDMETHOD(RemoveDebuggableProtocol)(
		/*[in]*/ LPOLESTR bstrProtocol)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveDebuggableProtocol)

		VSL_CHECK_VALIDVALUE_STRINGW(bstrProtocol);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsProtocolDebuggableValidValues
	{
		/*[in]*/ LPOLESTR bstrProtocol;
		HRESULT retValue;
	};

	STDMETHOD(IsProtocolDebuggable)(
		/*[in]*/ LPOLESTR bstrProtocol)
	{
		VSL_DEFINE_MOCK_METHOD(IsProtocolDebuggable)

		VSL_CHECK_VALIDVALUE_STRINGW(bstrProtocol);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEBUGGABLEPROTOCOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
