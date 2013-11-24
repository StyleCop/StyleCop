/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMETHODDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMETHODDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMethodDataNotImpl :
	public IVsMethodData
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodDataNotImpl)

public:

	typedef IVsMethodData Interface;

	virtual long STDMETHODCALLTYPE GetOverloadCount(){ return long(); }

	virtual const WCHAR* STDMETHODCALLTYPE GetMethodText(
		/*[in]*/ long /*iMethod*/,
		/*[in]*/ MethodTextType /*type*/){ return NULL; }

	virtual long STDMETHODCALLTYPE GetParameterCount(
		/*[in]*/ long /*iMethod*/){ return long(); }

	virtual const WCHAR* STDMETHODCALLTYPE GetParameterText(
		/*[in]*/ long /*iMethod*/,
		/*[in]*/ long /*iParm*/,
		/*[in]*/ ParameterTextType /*type*/){ return NULL; }

	virtual long STDMETHODCALLTYPE GetCurrentParameter(
		/*[in]*/ long /*iMethod*/){ return long(); }

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* /*piPos*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE OnDismiss(){ return ; }

	virtual long STDMETHODCALLTYPE GetCurMethod(){ return long(); }

	virtual void STDMETHODCALLTYPE UpdateView(){ return ; }

	virtual long STDMETHODCALLTYPE NextMethod(){ return long(); }

	virtual long STDMETHODCALLTYPE PrevMethod(){ return long(); }
};

class IVsMethodDataMockImpl :
	public IVsMethodData,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodDataMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMethodDataMockImpl)

	typedef IVsMethodData Interface;
	struct GetOverloadCountValidValues
	{
		long retValue;
	};

	virtual long _stdcall GetOverloadCount()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetOverloadCount)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMethodTextValidValues
	{
		/*[in]*/ long iMethod;
		/*[in]*/ MethodTextType type;
		const WCHAR* retValue;
	};

	virtual const WCHAR* _stdcall GetMethodText(
		/*[in]*/ long iMethod,
		/*[in]*/ MethodTextType type)
	{
		VSL_DEFINE_MOCK_METHOD(GetMethodText)

		VSL_CHECK_VALIDVALUE(iMethod);

		VSL_CHECK_VALIDVALUE(type);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParameterCountValidValues
	{
		/*[in]*/ long iMethod;
		long retValue;
	};

	virtual long _stdcall GetParameterCount(
		/*[in]*/ long iMethod)
	{
		VSL_DEFINE_MOCK_METHOD(GetParameterCount)

		VSL_CHECK_VALIDVALUE(iMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParameterTextValidValues
	{
		/*[in]*/ long iMethod;
		/*[in]*/ long iParm;
		/*[in]*/ ParameterTextType type;
		const WCHAR* retValue;
	};

	virtual const WCHAR* _stdcall GetParameterText(
		/*[in]*/ long iMethod,
		/*[in]*/ long iParm,
		/*[in]*/ ParameterTextType type)
	{
		VSL_DEFINE_MOCK_METHOD(GetParameterText)

		VSL_CHECK_VALIDVALUE(iMethod);

		VSL_CHECK_VALIDVALUE(iParm);

		VSL_CHECK_VALIDVALUE(type);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentParameterValidValues
	{
		/*[in]*/ long iMethod;
		long retValue;
	};

	virtual long _stdcall GetCurrentParameter(
		/*[in]*/ long iMethod)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentParameter)

		VSL_CHECK_VALIDVALUE(iMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextStreamValidValues
	{
		/*[out]*/ long* piPos;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* piPos,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextStream)

		VSL_SET_VALIDVALUE(piPos);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall OnDismiss()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(OnDismiss)

	}
	struct GetCurMethodValidValues
	{
		long retValue;
	};

	virtual long _stdcall GetCurMethod()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetCurMethod)

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall UpdateView()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(UpdateView)

	}
	struct NextMethodValidValues
	{
		long retValue;
	};

	virtual long _stdcall NextMethod()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NextMethod)

		VSL_RETURN_VALIDVALUES();
	}
	struct PrevMethodValidValues
	{
		long retValue;
	};

	virtual long _stdcall PrevMethod()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(PrevMethod)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMETHODDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
