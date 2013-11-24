/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IBINDCTX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IBINDCTX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IBindCtxNotImpl :
	public IBindCtx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBindCtxNotImpl)

public:

	typedef IBindCtx Interface;

	STDMETHOD(RegisterObjectBound)(
		/*[in,unique]*/ IUnknown* /*punk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevokeObjectBound)(
		/*[in,unique]*/ IUnknown* /*punk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseBoundObjects)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBindOptions)(
		/*[in]*/ BIND_OPTS* /*pbindopts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBindOptions)(
		/*[in,out]*/ BIND_OPTS* /*pbindopts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRunningObjectTable)(
		/*[out]*/ IRunningObjectTable** /*pprot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterObjectParam)(
		/*[in]*/ LPOLESTR /*pszKey*/,
		/*[in,unique]*/ IUnknown* /*punk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetObjectParam)(
		/*[in]*/ LPOLESTR /*pszKey*/,
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumObjectParam)(
		/*[out]*/ IEnumString** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevokeObjectParam)(
		/*[in]*/ LPOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL
};

class IBindCtxMockImpl :
	public IBindCtx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBindCtxMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IBindCtxMockImpl)

	typedef IBindCtx Interface;
	struct RegisterObjectBoundValidValues
	{
		/*[in,unique]*/ IUnknown* punk;
		HRESULT retValue;
	};

	STDMETHOD(RegisterObjectBound)(
		/*[in,unique]*/ IUnknown* punk)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterObjectBound)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevokeObjectBoundValidValues
	{
		/*[in,unique]*/ IUnknown* punk;
		HRESULT retValue;
	};

	STDMETHOD(RevokeObjectBound)(
		/*[in,unique]*/ IUnknown* punk)
	{
		VSL_DEFINE_MOCK_METHOD(RevokeObjectBound)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseBoundObjectsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ReleaseBoundObjects)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ReleaseBoundObjects)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBindOptionsValidValues
	{
		/*[in]*/ BIND_OPTS* pbindopts;
		HRESULT retValue;
	};

	STDMETHOD(SetBindOptions)(
		/*[in]*/ BIND_OPTS* pbindopts)
	{
		VSL_DEFINE_MOCK_METHOD(SetBindOptions)

		VSL_CHECK_VALIDVALUE_POINTER(pbindopts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBindOptionsValidValues
	{
		/*[in,out]*/ BIND_OPTS* pbindopts;
		HRESULT retValue;
	};

	STDMETHOD(GetBindOptions)(
		/*[in,out]*/ BIND_OPTS* pbindopts)
	{
		VSL_DEFINE_MOCK_METHOD(GetBindOptions)

		VSL_SET_VALIDVALUE(pbindopts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRunningObjectTableValidValues
	{
		/*[out]*/ IRunningObjectTable** pprot;
		HRESULT retValue;
	};

	STDMETHOD(GetRunningObjectTable)(
		/*[out]*/ IRunningObjectTable** pprot)
	{
		VSL_DEFINE_MOCK_METHOD(GetRunningObjectTable)

		VSL_SET_VALIDVALUE_INTERFACE(pprot);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterObjectParamValidValues
	{
		/*[in]*/ LPOLESTR pszKey;
		/*[in,unique]*/ IUnknown* punk;
		HRESULT retValue;
	};

	STDMETHOD(RegisterObjectParam)(
		/*[in]*/ LPOLESTR pszKey,
		/*[in,unique]*/ IUnknown* punk)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterObjectParam)

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetObjectParamValidValues
	{
		/*[in]*/ LPOLESTR pszKey;
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetObjectParam)(
		/*[in]*/ LPOLESTR pszKey,
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetObjectParam)

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumObjectParamValidValues
	{
		/*[out]*/ IEnumString** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumObjectParam)(
		/*[out]*/ IEnumString** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumObjectParam)

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevokeObjectParamValidValues
	{
		/*[in]*/ LPOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(RevokeObjectParam)(
		/*[in]*/ LPOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(RevokeObjectParam)

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IBINDCTX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
