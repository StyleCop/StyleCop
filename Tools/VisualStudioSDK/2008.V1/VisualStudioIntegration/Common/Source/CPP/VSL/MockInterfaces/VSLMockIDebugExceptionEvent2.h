/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGEXCEPTIONEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGEXCEPTIONEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugExceptionEvent2NotImpl :
	public IDebugExceptionEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExceptionEvent2NotImpl)

public:

	typedef IDebugExceptionEvent2 Interface;

	STDMETHOD(GetException)(
		/*[out]*/ EXCEPTION_INFO* /*pExceptionInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExceptionDescription)(
		/*[out]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanPassToDebuggee)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PassToDebuggee)(
		/*[in]*/ BOOL /*fPass*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugExceptionEvent2MockImpl :
	public IDebugExceptionEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExceptionEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugExceptionEvent2MockImpl)

	typedef IDebugExceptionEvent2 Interface;
	struct GetExceptionValidValues
	{
		/*[out]*/ EXCEPTION_INFO* pExceptionInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetException)(
		/*[out]*/ EXCEPTION_INFO* pExceptionInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetException)

		VSL_SET_VALIDVALUE(pExceptionInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExceptionDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionDescription)(
		/*[out]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanPassToDebuggeeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanPassToDebuggee)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanPassToDebuggee)

		VSL_RETURN_VALIDVALUES();
	}
	struct PassToDebuggeeValidValues
	{
		/*[in]*/ BOOL fPass;
		HRESULT retValue;
	};

	STDMETHOD(PassToDebuggee)(
		/*[in]*/ BOOL fPass)
	{
		VSL_DEFINE_MOCK_METHOD(PassToDebuggee)

		VSL_CHECK_VALIDVALUE(fPass);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGEXCEPTIONEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
