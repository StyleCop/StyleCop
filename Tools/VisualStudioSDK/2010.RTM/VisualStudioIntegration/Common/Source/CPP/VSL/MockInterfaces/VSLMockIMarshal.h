/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IMarshalNotImpl :
	public IMarshal
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMarshalNotImpl)

public:

	typedef IMarshal Interface;

	STDMETHOD(GetUnmarshalClass)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,unique]*/ void* /*pv*/,
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in,unique]*/ void* /*pvDestContext*/,
		/*[in]*/ DWORD /*mshlflags*/,
		/*[out]*/ CLSID* /*pCid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMarshalSizeMax)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,unique]*/ void* /*pv*/,
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in,unique]*/ void* /*pvDestContext*/,
		/*[in]*/ DWORD /*mshlflags*/,
		/*[out]*/ DWORD* /*pSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MarshalInterface)(
		/*[in,unique]*/ IStream* /*pStm*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in,unique]*/ void* /*pv*/,
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in,unique]*/ void* /*pvDestContext*/,
		/*[in]*/ DWORD /*mshlflags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnmarshalInterface)(
		/*[in,unique]*/ IStream* /*pStm*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ void** /*ppv*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseMarshalData)(
		/*[in,unique]*/ IStream* /*pStm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisconnectObject)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IMarshalMockImpl :
	public IMarshal,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMarshalMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMarshalMockImpl)

	typedef IMarshal Interface;
	struct GetUnmarshalClassValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,unique]*/ void* pv;
		/*[in]*/ DWORD dwDestContext;
		/*[in,unique]*/ void* pvDestContext;
		/*[in]*/ DWORD mshlflags;
		/*[out]*/ CLSID* pCid;
		HRESULT retValue;
		size_t pv_size_in_bytes;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(GetUnmarshalClass)(
		/*[in]*/ REFIID riid,
		/*[in,unique]*/ void* pv,
		/*[in]*/ DWORD dwDestContext,
		/*[in,unique]*/ void* pvDestContext,
		/*[in]*/ DWORD mshlflags,
		/*[out]*/ CLSID* pCid)
	{
		VSL_DEFINE_MOCK_METHOD(GetUnmarshalClass)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_CHECK_VALIDVALUE(mshlflags);

		VSL_SET_VALIDVALUE(pCid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMarshalSizeMaxValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,unique]*/ void* pv;
		/*[in]*/ DWORD dwDestContext;
		/*[in,unique]*/ void* pvDestContext;
		/*[in]*/ DWORD mshlflags;
		/*[out]*/ DWORD* pSize;
		HRESULT retValue;
		size_t pv_size_in_bytes;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(GetMarshalSizeMax)(
		/*[in]*/ REFIID riid,
		/*[in,unique]*/ void* pv,
		/*[in]*/ DWORD dwDestContext,
		/*[in,unique]*/ void* pvDestContext,
		/*[in]*/ DWORD mshlflags,
		/*[out]*/ DWORD* pSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarshalSizeMax)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_CHECK_VALIDVALUE(mshlflags);

		VSL_SET_VALIDVALUE(pSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct MarshalInterfaceValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		/*[in]*/ REFIID riid;
		/*[in,unique]*/ void* pv;
		/*[in]*/ DWORD dwDestContext;
		/*[in,unique]*/ void* pvDestContext;
		/*[in]*/ DWORD mshlflags;
		HRESULT retValue;
		size_t pv_size_in_bytes;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(MarshalInterface)(
		/*[in,unique]*/ IStream* pStm,
		/*[in]*/ REFIID riid,
		/*[in,unique]*/ void* pv,
		/*[in]*/ DWORD dwDestContext,
		/*[in,unique]*/ void* pvDestContext,
		/*[in]*/ DWORD mshlflags)
	{
		VSL_DEFINE_MOCK_METHOD(MarshalInterface)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_CHECK_VALIDVALUE(mshlflags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnmarshalInterfaceValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		/*[in]*/ REFIID riid;
		/*[out]*/ void** ppv;
		HRESULT retValue;
	};

	STDMETHOD(UnmarshalInterface)(
		/*[in,unique]*/ IStream* pStm,
		/*[in]*/ REFIID riid,
		/*[out]*/ void** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(UnmarshalInterface)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseMarshalDataValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseMarshalData)(
		/*[in,unique]*/ IStream* pStm)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseMarshalData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisconnectObjectValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(DisconnectObject)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(DisconnectObject)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
