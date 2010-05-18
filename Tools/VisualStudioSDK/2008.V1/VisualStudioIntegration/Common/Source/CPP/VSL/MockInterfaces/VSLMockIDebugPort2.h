/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPORT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPORT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugPort2NotImpl :
	public IDebugPort2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPort2NotImpl)

public:

	typedef IDebugPort2 Interface;

	STDMETHOD(GetPortName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortId)(
		/*[out]*/ GUID* /*pguidPort*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortRequest)(
		/*[out]*/ IDebugPortRequest2** /*ppRequest*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortSupplier)(
		/*[out]*/ IDebugPortSupplier2** /*ppSupplier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProcess)(
		/*[in]*/ AD_PROCESS_ID /*ProcessId*/,
		/*[out]*/ IDebugProcess2** /*ppProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumProcesses)(
		/*[out]*/ IEnumDebugProcesses2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugPort2MockImpl :
	public IDebugPort2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPort2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPort2MockImpl)

	typedef IDebugPort2 Interface;
	struct GetPortNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetPortName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortIdValidValues
	{
		/*[out]*/ GUID* pguidPort;
		HRESULT retValue;
	};

	STDMETHOD(GetPortId)(
		/*[out]*/ GUID* pguidPort)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortId)

		VSL_SET_VALIDVALUE(pguidPort);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortRequestValidValues
	{
		/*[out]*/ IDebugPortRequest2** ppRequest;
		HRESULT retValue;
	};

	STDMETHOD(GetPortRequest)(
		/*[out]*/ IDebugPortRequest2** ppRequest)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortRequest)

		VSL_SET_VALIDVALUE_INTERFACE(ppRequest);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortSupplierValidValues
	{
		/*[out]*/ IDebugPortSupplier2** ppSupplier;
		HRESULT retValue;
	};

	STDMETHOD(GetPortSupplier)(
		/*[out]*/ IDebugPortSupplier2** ppSupplier)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortSupplier)

		VSL_SET_VALIDVALUE_INTERFACE(ppSupplier);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProcessValidValues
	{
		/*[in]*/ AD_PROCESS_ID ProcessId;
		/*[out]*/ IDebugProcess2** ppProcess;
		HRESULT retValue;
	};

	STDMETHOD(GetProcess)(
		/*[in]*/ AD_PROCESS_ID ProcessId,
		/*[out]*/ IDebugProcess2** ppProcess)
	{
		VSL_DEFINE_MOCK_METHOD(GetProcess)

		VSL_CHECK_VALIDVALUE(ProcessId);

		VSL_SET_VALIDVALUE_INTERFACE(ppProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumProcessesValidValues
	{
		/*[out]*/ IEnumDebugProcesses2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumProcesses)(
		/*[out]*/ IEnumDebugProcesses2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumProcesses)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPORT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
