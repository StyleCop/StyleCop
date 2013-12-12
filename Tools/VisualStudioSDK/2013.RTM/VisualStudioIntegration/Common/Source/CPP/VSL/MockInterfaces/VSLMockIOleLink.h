/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLELINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLELINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleLinkNotImpl :
	public IOleLink
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleLinkNotImpl)

public:

	typedef IOleLink Interface;

	STDMETHOD(SetUpdateOptions)(
		/*[in]*/ DWORD /*dwUpdateOpt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUpdateOptions)(
		/*[out]*/ DWORD* /*pdwUpdateOpt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSourceMoniker)(
		/*[in,unique]*/ IMoniker* /*pmk*/,
		/*[in]*/ REFCLSID /*rclsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSourceMoniker)(
		/*[out]*/ IMoniker** /*ppmk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSourceDisplayName)(
		/*[in]*/ LPCOLESTR /*pszStatusText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSourceDisplayName)(
		/*[out]*/ LPOLESTR* /*ppszDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BindToSource)(
		/*[in]*/ DWORD /*bindflags*/,
		/*[in,unique]*/ IBindCtx* /*pbc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BindIfRunning)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBoundSource)(
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnbindSource)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)(
		/*[in,unique]*/ IBindCtx* /*pbc*/)VSL_STDMETHOD_NOTIMPL
};

class IOleLinkMockImpl :
	public IOleLink,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleLinkMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleLinkMockImpl)

	typedef IOleLink Interface;
	struct SetUpdateOptionsValidValues
	{
		/*[in]*/ DWORD dwUpdateOpt;
		HRESULT retValue;
	};

	STDMETHOD(SetUpdateOptions)(
		/*[in]*/ DWORD dwUpdateOpt)
	{
		VSL_DEFINE_MOCK_METHOD(SetUpdateOptions)

		VSL_CHECK_VALIDVALUE(dwUpdateOpt);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUpdateOptionsValidValues
	{
		/*[out]*/ DWORD* pdwUpdateOpt;
		HRESULT retValue;
	};

	STDMETHOD(GetUpdateOptions)(
		/*[out]*/ DWORD* pdwUpdateOpt)
	{
		VSL_DEFINE_MOCK_METHOD(GetUpdateOptions)

		VSL_SET_VALIDVALUE(pdwUpdateOpt);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSourceMonikerValidValues
	{
		/*[in,unique]*/ IMoniker* pmk;
		/*[in]*/ REFCLSID rclsid;
		HRESULT retValue;
	};

	STDMETHOD(SetSourceMoniker)(
		/*[in,unique]*/ IMoniker* pmk,
		/*[in]*/ REFCLSID rclsid)
	{
		VSL_DEFINE_MOCK_METHOD(SetSourceMoniker)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmk);

		VSL_CHECK_VALIDVALUE(rclsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSourceMonikerValidValues
	{
		/*[out]*/ IMoniker** ppmk;
		HRESULT retValue;
	};

	STDMETHOD(GetSourceMoniker)(
		/*[out]*/ IMoniker** ppmk)
	{
		VSL_DEFINE_MOCK_METHOD(GetSourceMoniker)

		VSL_SET_VALIDVALUE_INTERFACE(ppmk);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSourceDisplayNameValidValues
	{
		/*[in]*/ LPCOLESTR pszStatusText;
		HRESULT retValue;
	};

	STDMETHOD(SetSourceDisplayName)(
		/*[in]*/ LPCOLESTR pszStatusText)
	{
		VSL_DEFINE_MOCK_METHOD(SetSourceDisplayName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszStatusText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSourceDisplayNameValidValues
	{
		/*[out]*/ LPOLESTR* ppszDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(GetSourceDisplayName)(
		/*[out]*/ LPOLESTR* ppszDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(GetSourceDisplayName)

		VSL_SET_VALIDVALUE(ppszDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct BindToSourceValidValues
	{
		/*[in]*/ DWORD bindflags;
		/*[in,unique]*/ IBindCtx* pbc;
		HRESULT retValue;
	};

	STDMETHOD(BindToSource)(
		/*[in]*/ DWORD bindflags,
		/*[in,unique]*/ IBindCtx* pbc)
	{
		VSL_DEFINE_MOCK_METHOD(BindToSource)

		VSL_CHECK_VALIDVALUE(bindflags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_RETURN_VALIDVALUES();
	}
	struct BindIfRunningValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BindIfRunning)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BindIfRunning)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBoundSourceValidValues
	{
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetBoundSource)(
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetBoundSource)

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnbindSourceValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnbindSource)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnbindSource)

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		HRESULT retValue;
	};

	STDMETHOD(Update)(
		/*[in,unique]*/ IBindCtx* pbc)
	{
		VSL_DEFINE_MOCK_METHOD(Update)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLELINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
