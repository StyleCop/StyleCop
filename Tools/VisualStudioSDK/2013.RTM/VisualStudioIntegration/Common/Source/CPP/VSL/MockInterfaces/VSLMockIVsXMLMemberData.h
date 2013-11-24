/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsXMLMemberDataNotImpl :
	public IVsXMLMemberData
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataNotImpl)

public:

	typedef IVsXMLMemberData Interface;

	STDMETHOD(GetSummaryText)(
		/*[out]*/ BSTR* /*pbstrSummary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParamCount)(
		/*[out]*/ long* /*piParams*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParamTextAt)(
		/*[in]*/ long /*iParam*/,
		/*[out]*/ BSTR* /*pbstrName*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReturnsText)(
		/*[out]*/ BSTR* /*pbstrReturns*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRemarksText)(
		/*[out]*/ BSTR* /*pbstrRemarks*/)VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberDataMockImpl :
	public IVsXMLMemberData,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberDataMockImpl)

	typedef IVsXMLMemberData Interface;
	struct GetSummaryTextValidValues
	{
		/*[out]*/ BSTR* pbstrSummary;
		HRESULT retValue;
	};

	STDMETHOD(GetSummaryText)(
		/*[out]*/ BSTR* pbstrSummary)
	{
		VSL_DEFINE_MOCK_METHOD(GetSummaryText)

		VSL_SET_VALIDVALUE_BSTR(pbstrSummary);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParamCountValidValues
	{
		/*[out]*/ long* piParams;
		HRESULT retValue;
	};

	STDMETHOD(GetParamCount)(
		/*[out]*/ long* piParams)
	{
		VSL_DEFINE_MOCK_METHOD(GetParamCount)

		VSL_SET_VALIDVALUE(piParams);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParamTextAtValidValues
	{
		/*[in]*/ long iParam;
		/*[out]*/ BSTR* pbstrName;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetParamTextAt)(
		/*[in]*/ long iParam,
		/*[out]*/ BSTR* pbstrName,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetParamTextAt)

		VSL_CHECK_VALIDVALUE(iParam);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReturnsTextValidValues
	{
		/*[out]*/ BSTR* pbstrReturns;
		HRESULT retValue;
	};

	STDMETHOD(GetReturnsText)(
		/*[out]*/ BSTR* pbstrReturns)
	{
		VSL_DEFINE_MOCK_METHOD(GetReturnsText)

		VSL_SET_VALIDVALUE_BSTR(pbstrReturns);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRemarksTextValidValues
	{
		/*[out]*/ BSTR* pbstrRemarks;
		HRESULT retValue;
	};

	STDMETHOD(GetRemarksText)(
		/*[out]*/ BSTR* pbstrRemarks)
	{
		VSL_DEFINE_MOCK_METHOD(GetRemarksText)

		VSL_SET_VALIDVALUE_BSTR(pbstrRemarks);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSXMLMEMBERDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
