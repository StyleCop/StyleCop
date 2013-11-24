/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMACHINEEX2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMACHINEEX2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugMachineEx2_V7NotImpl :
	public IDebugMachineEx2_V7
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMachineEx2_V7NotImpl)

public:

	typedef IDebugMachineEx2_V7 Interface;

	STDMETHOD(EnableAutoAttachOnProgramCreate)(
		/*[in]*/ LPCWSTR /*pszProcessNames*/,
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ LPCWSTR /*pszSessionId*/,
		/*[out]*/ DWORD* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisableAutoAttachOnEvent)(
		/*[in]*/ DWORD /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortSupplierEx)(
		/*[in]*/ LPCOLESTR /*wstrRegistryRoot*/,
		/*[in]*/ REFGUID /*guidPortSupplier*/,
		/*[out]*/ IDebugPortSupplier2** /*ppPortSupplier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortEx)(
		/*[in]*/ LPCOLESTR /*wstrRegistryRoot*/,
		/*[in]*/ REFGUID /*guidPort*/,
		/*[out]*/ IDebugPort2** /*ppPort*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPortsEx)(
		/*[in]*/ LPCOLESTR /*wstrRegistryRoot*/,
		/*[out]*/ IEnumDebugPorts2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPortSuppliersEx)(
		/*[in]*/ LPCOLESTR /*wstrRegistryRoot*/,
		/*[out]*/ IEnumDebugPortSuppliers2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugMachineEx2_V7MockImpl :
	public IDebugMachineEx2_V7,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMachineEx2_V7MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugMachineEx2_V7MockImpl)

	typedef IDebugMachineEx2_V7 Interface;
	struct EnableAutoAttachOnProgramCreateValidValues
	{
		/*[in]*/ LPCWSTR pszProcessNames;
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ LPCWSTR pszSessionId;
		/*[out]*/ DWORD* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(EnableAutoAttachOnProgramCreate)(
		/*[in]*/ LPCWSTR pszProcessNames,
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ LPCWSTR pszSessionId,
		/*[out]*/ DWORD* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(EnableAutoAttachOnProgramCreate)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProcessNames);

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSessionId);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisableAutoAttachOnEventValidValues
	{
		/*[in]*/ DWORD dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(DisableAutoAttachOnEvent)(
		/*[in]*/ DWORD dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(DisableAutoAttachOnEvent)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortSupplierExValidValues
	{
		/*[in]*/ LPCOLESTR wstrRegistryRoot;
		/*[in]*/ REFGUID guidPortSupplier;
		/*[out]*/ IDebugPortSupplier2** ppPortSupplier;
		HRESULT retValue;
	};

	STDMETHOD(GetPortSupplierEx)(
		/*[in]*/ LPCOLESTR wstrRegistryRoot,
		/*[in]*/ REFGUID guidPortSupplier,
		/*[out]*/ IDebugPortSupplier2** ppPortSupplier)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortSupplierEx)

		VSL_CHECK_VALIDVALUE_STRINGW(wstrRegistryRoot);

		VSL_CHECK_VALIDVALUE(guidPortSupplier);

		VSL_SET_VALIDVALUE_INTERFACE(ppPortSupplier);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortExValidValues
	{
		/*[in]*/ LPCOLESTR wstrRegistryRoot;
		/*[in]*/ REFGUID guidPort;
		/*[out]*/ IDebugPort2** ppPort;
		HRESULT retValue;
	};

	STDMETHOD(GetPortEx)(
		/*[in]*/ LPCOLESTR wstrRegistryRoot,
		/*[in]*/ REFGUID guidPort,
		/*[out]*/ IDebugPort2** ppPort)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortEx)

		VSL_CHECK_VALIDVALUE_STRINGW(wstrRegistryRoot);

		VSL_CHECK_VALIDVALUE(guidPort);

		VSL_SET_VALIDVALUE_INTERFACE(ppPort);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumPortsExValidValues
	{
		/*[in]*/ LPCOLESTR wstrRegistryRoot;
		/*[out]*/ IEnumDebugPorts2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPortsEx)(
		/*[in]*/ LPCOLESTR wstrRegistryRoot,
		/*[out]*/ IEnumDebugPorts2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPortsEx)

		VSL_CHECK_VALIDVALUE_STRINGW(wstrRegistryRoot);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumPortSuppliersExValidValues
	{
		/*[in]*/ LPCOLESTR wstrRegistryRoot;
		/*[out]*/ IEnumDebugPortSuppliers2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPortSuppliersEx)(
		/*[in]*/ LPCOLESTR wstrRegistryRoot,
		/*[out]*/ IEnumDebugPortSuppliers2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPortSuppliersEx)

		VSL_CHECK_VALIDVALUE_STRINGW(wstrRegistryRoot);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMACHINEEX2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
