/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICONNECTIONPOINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICONNECTIONPOINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IConnectionPointNotImpl :
	public IConnectionPoint
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IConnectionPointNotImpl)

public:

	typedef IConnectionPoint Interface;

	STDMETHOD(GetConnectionInterface)(
		/*[out]*/ IID* /*pIID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetConnectionPointContainer)(
		/*[out]*/ IConnectionPointContainer** /*ppCPC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Advise)(
		/*[in]*/ IUnknown* /*pUnkSink*/,
		/*[out]*/ DWORD* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumConnections)(
		/*[out]*/ IEnumConnections** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IConnectionPointMockImpl :
	public IConnectionPoint,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IConnectionPointMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IConnectionPointMockImpl)

	typedef IConnectionPoint Interface;
	struct GetConnectionInterfaceValidValues
	{
		/*[out]*/ IID* pIID;
		HRESULT retValue;
	};

	STDMETHOD(GetConnectionInterface)(
		/*[out]*/ IID* pIID)
	{
		VSL_DEFINE_MOCK_METHOD(GetConnectionInterface)

		VSL_SET_VALIDVALUE(pIID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetConnectionPointContainerValidValues
	{
		/*[out]*/ IConnectionPointContainer** ppCPC;
		HRESULT retValue;
	};

	STDMETHOD(GetConnectionPointContainer)(
		/*[out]*/ IConnectionPointContainer** ppCPC)
	{
		VSL_DEFINE_MOCK_METHOD(GetConnectionPointContainer)

		VSL_SET_VALIDVALUE_INTERFACE(ppCPC);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseValidValues
	{
		/*[in]*/ IUnknown* pUnkSink;
		/*[out]*/ DWORD* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(Advise)(
		/*[in]*/ IUnknown* pUnkSink,
		/*[out]*/ DWORD* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Advise)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseValidValues
	{
		/*[in]*/ DWORD dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Unadvise)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumConnectionsValidValues
	{
		/*[out]*/ IEnumConnections** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumConnections)(
		/*[out]*/ IEnumConnections** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumConnections)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICONNECTIONPOINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
