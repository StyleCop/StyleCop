/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYFILEIN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYFILEIN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsPropertyFileInNotImpl :
	public IVsPropertyFileIn
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyFileInNotImpl)

public:

	typedef IVsPropertyFileIn Interface;

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Read)(
		/*[in]*/ ULONG /*cchPropertyName*/,
		/*[in,out,size_is(cchPropertyName)]*/ OLECHAR[] /*szPropertyName*/,
		/*[out]*/ ULONG* /*pcchPropertyNameActual*/,
		/*[out]*/ VSPROPERTYSTREAMPROPERTYTYPE* /*pvspspt*/,
		/*[out]*/ VARIANT* /*pvarValue*/,
		/*[in]*/ IErrorLog* /*pIErrorLog*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SkipToEnd)()VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyFileInMockImpl :
	public IVsPropertyFileIn,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyFileInMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyFileInMockImpl)

	typedef IVsPropertyFileIn Interface;
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadValidValues
	{
		/*[in]*/ ULONG cchPropertyName;
		/*[in,out,size_is(cchPropertyName)]*/ OLECHAR* szPropertyName;
		/*[out]*/ ULONG* pcchPropertyNameActual;
		/*[out]*/ VSPROPERTYSTREAMPROPERTYTYPE* pvspspt;
		/*[out]*/ VARIANT* pvarValue;
		/*[in]*/ IErrorLog* pIErrorLog;
		HRESULT retValue;
	};

	STDMETHOD(Read)(
		/*[in]*/ ULONG cchPropertyName,
		/*[in,out,size_is(cchPropertyName)]*/ OLECHAR szPropertyName[],
		/*[out]*/ ULONG* pcchPropertyNameActual,
		/*[out]*/ VSPROPERTYSTREAMPROPERTYTYPE* pvspspt,
		/*[out]*/ VARIANT* pvarValue,
		/*[in]*/ IErrorLog* pIErrorLog)
	{
		VSL_DEFINE_MOCK_METHOD(Read)

		VSL_CHECK_VALIDVALUE(cchPropertyName);

		VSL_SET_VALIDVALUE_STRINGW(szPropertyName, cchPropertyName);

		VSL_SET_VALIDVALUE(pcchPropertyNameActual);

		VSL_SET_VALIDVALUE(pvspspt);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIErrorLog);

		VSL_RETURN_VALIDVALUES();
	}
	struct SkipToEndValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SkipToEnd)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SkipToEnd)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYFILEIN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
