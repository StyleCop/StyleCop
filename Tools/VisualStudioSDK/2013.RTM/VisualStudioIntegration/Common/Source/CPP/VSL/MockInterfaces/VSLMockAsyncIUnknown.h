/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ASYNCIUNKNOWN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ASYNCIUNKNOWN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "Unknwn.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class AsyncIUnknownNotImpl :
	public AsyncIUnknown
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(AsyncIUnknownNotImpl)

public:

	typedef AsyncIUnknown Interface;

	STDMETHOD(Begin_QueryInterface)(
		/*[in]*/ REFIID /*riid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Finish_QueryInterface)(
		/*[out]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Begin_AddRef)()VSL_STDMETHOD_NOTIMPL

	virtual ULONG STDMETHODCALLTYPE Finish_AddRef(){ return ULONG(); }

	STDMETHOD(Begin_Release)()VSL_STDMETHOD_NOTIMPL

	virtual ULONG STDMETHODCALLTYPE Finish_Release(){ return ULONG(); }
};

class AsyncIUnknownMockImpl :
	public AsyncIUnknown,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(AsyncIUnknownMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(AsyncIUnknownMockImpl)

	typedef AsyncIUnknown Interface;
	struct Begin_QueryInterfaceValidValues
	{
		/*[in]*/ REFIID riid;
		HRESULT retValue;
	};

	STDMETHOD(Begin_QueryInterface)(
		/*[in]*/ REFIID riid)
	{
		VSL_DEFINE_MOCK_METHOD(Begin_QueryInterface)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_RETURN_VALIDVALUES();
	}
	struct Finish_QueryInterfaceValidValues
	{
		/*[out]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(Finish_QueryInterface)(
		/*[out]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(Finish_QueryInterface)

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct Begin_AddRefValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Begin_AddRef)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Begin_AddRef)

		VSL_RETURN_VALIDVALUES();
	}
	struct Finish_AddRefValidValues
	{
		ULONG retValue;
	};

	virtual ULONG _stdcall Finish_AddRef()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Finish_AddRef)

		VSL_RETURN_VALIDVALUES();
	}
	struct Begin_ReleaseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Begin_Release)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Begin_Release)

		VSL_RETURN_VALIDVALUES();
	}
	struct Finish_ReleaseValidValues
	{
		ULONG retValue;
	};

	virtual ULONG _stdcall Finish_Release()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Finish_Release)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ASYNCIUNKNOWN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
