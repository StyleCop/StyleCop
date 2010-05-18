/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPORTSUPPLIER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPORTSUPPLIER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugPortSupplier2NotImpl :
	public IDebugPortSupplier2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortSupplier2NotImpl)

public:

	typedef IDebugPortSupplier2 Interface;

	STDMETHOD(GetPortSupplierName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortSupplierId)(
		/*[out]*/ GUID* /*pguidPortSupplier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPort)(
		/*[in]*/ REFGUID /*guidPort*/,
		/*[out]*/ IDebugPort2** /*ppPort*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPorts)(
		/*[out]*/ IEnumDebugPorts2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanAddPort)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddPort)(
		/*[in]*/ IDebugPortRequest2* /*pRequest*/,
		/*[out]*/ IDebugPort2** /*ppPort*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemovePort)(
		/*[in]*/ IDebugPort2* /*pPort*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugPortSupplier2MockImpl :
	public IDebugPortSupplier2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortSupplier2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPortSupplier2MockImpl)

	typedef IDebugPortSupplier2 Interface;
	struct GetPortSupplierNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetPortSupplierName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortSupplierName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortSupplierIdValidValues
	{
		/*[out]*/ GUID* pguidPortSupplier;
		HRESULT retValue;
	};

	STDMETHOD(GetPortSupplierId)(
		/*[out]*/ GUID* pguidPortSupplier)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortSupplierId)

		VSL_SET_VALIDVALUE(pguidPortSupplier);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortValidValues
	{
		/*[in]*/ REFGUID guidPort;
		/*[out]*/ IDebugPort2** ppPort;
		HRESULT retValue;
	};

	STDMETHOD(GetPort)(
		/*[in]*/ REFGUID guidPort,
		/*[out]*/ IDebugPort2** ppPort)
	{
		VSL_DEFINE_MOCK_METHOD(GetPort)

		VSL_CHECK_VALIDVALUE(guidPort);

		VSL_SET_VALIDVALUE_INTERFACE(ppPort);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumPortsValidValues
	{
		/*[out]*/ IEnumDebugPorts2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPorts)(
		/*[out]*/ IEnumDebugPorts2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPorts)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanAddPortValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanAddPort)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanAddPort)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddPortValidValues
	{
		/*[in]*/ IDebugPortRequest2* pRequest;
		/*[out]*/ IDebugPort2** ppPort;
		HRESULT retValue;
	};

	STDMETHOD(AddPort)(
		/*[in]*/ IDebugPortRequest2* pRequest,
		/*[out]*/ IDebugPort2** ppPort)
	{
		VSL_DEFINE_MOCK_METHOD(AddPort)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRequest);

		VSL_SET_VALIDVALUE_INTERFACE(ppPort);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemovePortValidValues
	{
		/*[in]*/ IDebugPort2* pPort;
		HRESULT retValue;
	};

	STDMETHOD(RemovePort)(
		/*[in]*/ IDebugPort2* pPort)
	{
		VSL_DEFINE_MOCK_METHOD(RemovePort)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPORTSUPPLIER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
