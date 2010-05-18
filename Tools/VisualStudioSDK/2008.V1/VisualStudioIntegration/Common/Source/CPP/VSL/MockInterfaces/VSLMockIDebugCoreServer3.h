/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGCORESERVER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGCORESERVER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugCoreServer3NotImpl :
	public IDebugCoreServer3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCoreServer3NotImpl)

public:

	typedef IDebugCoreServer3 Interface;

	STDMETHOD(GetServerName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetServerFriendlyName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableAutoAttach)(
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* /*rgguidSpecificEngines*/,
		/*[in]*/ DWORD /*celtSpecificEngines*/,
		/*[in,ptr]*/ LPCOLESTR /*pszStartPageUrl*/,
		/*[out]*/ BSTR* /*pbstrSessionId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiagnoseWebDebuggingError)(
		/*[in,ptr]*/ LPCWSTR /*pszUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateInstanceInServer)(
		/*[in,ptr]*/ LPCWSTR /*szDll*/,
		/*[in]*/ WORD /*wLangId*/,
		/*[in]*/ REFCLSID /*clsidObject*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryIsLocal)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetConnectionProtocol)(
		/*[out]*/ CONNECTION_PROTOCOL* /*pProtocol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisableAutoAttach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMachineInfo)(
		/*[in]*/ MACHINE_INFO_FIELDS /*Fields*/,
		/*[out]*/ MACHINE_INFO* /*pMachineInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMachineName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPortSupplier)(
		/*[in]*/ REFGUID /*guidPortSupplier*/,
		/*[out]*/ IDebugPortSupplier2** /*ppPortSupplier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPort)(
		/*[in]*/ REFGUID /*guidPort*/,
		/*[out]*/ IDebugPort2** /*ppPort*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPorts)(
		/*[out]*/ IEnumDebugPorts2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPortSuppliers)(
		/*[out]*/ IEnumDebugPortSuppliers2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMachineUtilities_V7)(
		/*[out]*/ IDebugMDMUtil2_V7** /*ppUtil*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugCoreServer3MockImpl :
	public IDebugCoreServer3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCoreServer3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugCoreServer3MockImpl)

	typedef IDebugCoreServer3 Interface;
	struct GetServerNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetServerName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetServerName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetServerFriendlyNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetServerFriendlyName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetServerFriendlyName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableAutoAttachValidValues
	{
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* rgguidSpecificEngines;
		/*[in]*/ DWORD celtSpecificEngines;
		/*[in,ptr]*/ LPCOLESTR pszStartPageUrl;
		/*[out]*/ BSTR* pbstrSessionId;
		HRESULT retValue;
	};

	STDMETHOD(EnableAutoAttach)(
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* rgguidSpecificEngines,
		/*[in]*/ DWORD celtSpecificEngines,
		/*[in,ptr]*/ LPCOLESTR pszStartPageUrl,
		/*[out]*/ BSTR* pbstrSessionId)
	{
		VSL_DEFINE_MOCK_METHOD(EnableAutoAttach)

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidSpecificEngines, celtSpecificEngines*sizeof(rgguidSpecificEngines[0]), validValues.celtSpecificEngines*sizeof(validValues.rgguidSpecificEngines[0]));

		VSL_CHECK_VALIDVALUE(celtSpecificEngines);

		VSL_CHECK_VALIDVALUE_STRINGW(pszStartPageUrl);

		VSL_SET_VALIDVALUE_BSTR(pbstrSessionId);

		VSL_RETURN_VALIDVALUES();
	}
	struct DiagnoseWebDebuggingErrorValidValues
	{
		/*[in,ptr]*/ LPCWSTR pszUrl;
		HRESULT retValue;
	};

	STDMETHOD(DiagnoseWebDebuggingError)(
		/*[in,ptr]*/ LPCWSTR pszUrl)
	{
		VSL_DEFINE_MOCK_METHOD(DiagnoseWebDebuggingError)

		VSL_CHECK_VALIDVALUE_STRINGW(pszUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateInstanceInServerValidValues
	{
		/*[in,ptr]*/ LPCWSTR szDll;
		/*[in]*/ WORD wLangId;
		/*[in]*/ REFCLSID clsidObject;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstanceInServer)(
		/*[in,ptr]*/ LPCWSTR szDll,
		/*[in]*/ WORD wLangId,
		/*[in]*/ REFCLSID clsidObject,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstanceInServer)

		VSL_CHECK_VALIDVALUE_STRINGW(szDll);

		VSL_CHECK_VALIDVALUE(wLangId);

		VSL_CHECK_VALIDVALUE(clsidObject);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryIsLocalValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(QueryIsLocal)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(QueryIsLocal)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetConnectionProtocolValidValues
	{
		/*[out]*/ CONNECTION_PROTOCOL* pProtocol;
		HRESULT retValue;
	};

	STDMETHOD(GetConnectionProtocol)(
		/*[out]*/ CONNECTION_PROTOCOL* pProtocol)
	{
		VSL_DEFINE_MOCK_METHOD(GetConnectionProtocol)

		VSL_SET_VALIDVALUE(pProtocol);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisableAutoAttachValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DisableAutoAttach)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DisableAutoAttach)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMachineInfoValidValues
	{
		/*[in]*/ MACHINE_INFO_FIELDS Fields;
		/*[out]*/ MACHINE_INFO* pMachineInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetMachineInfo)(
		/*[in]*/ MACHINE_INFO_FIELDS Fields,
		/*[out]*/ MACHINE_INFO* pMachineInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetMachineInfo)

		VSL_CHECK_VALIDVALUE(Fields);

		VSL_SET_VALIDVALUE(pMachineInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMachineNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetMachineName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetMachineName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPortSupplierValidValues
	{
		/*[in]*/ REFGUID guidPortSupplier;
		/*[out]*/ IDebugPortSupplier2** ppPortSupplier;
		HRESULT retValue;
	};

	STDMETHOD(GetPortSupplier)(
		/*[in]*/ REFGUID guidPortSupplier,
		/*[out]*/ IDebugPortSupplier2** ppPortSupplier)
	{
		VSL_DEFINE_MOCK_METHOD(GetPortSupplier)

		VSL_CHECK_VALIDVALUE(guidPortSupplier);

		VSL_SET_VALIDVALUE_INTERFACE(ppPortSupplier);

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
	struct EnumPortSuppliersValidValues
	{
		/*[out]*/ IEnumDebugPortSuppliers2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPortSuppliers)(
		/*[out]*/ IEnumDebugPortSuppliers2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPortSuppliers)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMachineUtilities_V7ValidValues
	{
		/*[out]*/ IDebugMDMUtil2_V7** ppUtil;
		HRESULT retValue;
	};

	STDMETHOD(GetMachineUtilities_V7)(
		/*[out]*/ IDebugMDMUtil2_V7** ppUtil)
	{
		VSL_DEFINE_MOCK_METHOD(GetMachineUtilities_V7)

		VSL_SET_VALIDVALUE_INTERFACE(ppUtil);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGCORESERVER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
