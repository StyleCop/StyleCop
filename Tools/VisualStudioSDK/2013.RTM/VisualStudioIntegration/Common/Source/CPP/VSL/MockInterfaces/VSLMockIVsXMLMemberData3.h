/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERDATA3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERDATA3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsXMLMemberData3NotImpl :
	public IVsXMLMemberData3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberData3NotImpl)

public:

	typedef IVsXMLMemberData3 Interface;

	STDMETHOD(SetOptions)(
		/*[in]*/ XMLMEMBERDATA_OPTIONS /*options*/)VSL_STDMETHOD_NOTIMPL

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

	STDMETHOD(GetExceptionCount)(
		/*[out]*/ long* /*piExceptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExceptionTextAt)(
		/*[in]*/ long /*iException*/,
		/*[out]*/ BSTR* /*pbstrType*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFilterPriority)(
		/*[out]*/ long* /*piFilterPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompletionListText)(
		/*[out]*/ BSTR* /*pbstrCompletionList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompletionListTextAt)(
		/*[in]*/ long /*iParam*/,
		/*[out]*/ BSTR* /*pbstrCompletionList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPermissionSet)(
		/*[out]*/ BSTR* /*pbstrPermissionSetXML*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeParamCount)(
		/*[out]*/ long* /*piTypeParams*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeParamTextAt)(
		/*[in]*/ long /*iTypeParam*/,
		/*[out]*/ BSTR* /*pbstrName*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberData3MockImpl :
	public IVsXMLMemberData3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberData3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberData3MockImpl)

	typedef IVsXMLMemberData3 Interface;
	struct SetOptionsValidValues
	{
		/*[in]*/ XMLMEMBERDATA_OPTIONS options;
		HRESULT retValue;
	};

	STDMETHOD(SetOptions)(
		/*[in]*/ XMLMEMBERDATA_OPTIONS options)
	{
		VSL_DEFINE_MOCK_METHOD(SetOptions)

		VSL_CHECK_VALIDVALUE(options);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct GetExceptionCountValidValues
	{
		/*[out]*/ long* piExceptions;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionCount)(
		/*[out]*/ long* piExceptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionCount)

		VSL_SET_VALIDVALUE(piExceptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExceptionTextAtValidValues
	{
		/*[in]*/ long iException;
		/*[out]*/ BSTR* pbstrType;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionTextAt)(
		/*[in]*/ long iException,
		/*[out]*/ BSTR* pbstrType,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionTextAt)

		VSL_CHECK_VALIDVALUE(iException);

		VSL_SET_VALIDVALUE_BSTR(pbstrType);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFilterPriorityValidValues
	{
		/*[out]*/ long* piFilterPriority;
		HRESULT retValue;
	};

	STDMETHOD(GetFilterPriority)(
		/*[out]*/ long* piFilterPriority)
	{
		VSL_DEFINE_MOCK_METHOD(GetFilterPriority)

		VSL_SET_VALIDVALUE(piFilterPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompletionListTextValidValues
	{
		/*[out]*/ BSTR* pbstrCompletionList;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletionListText)(
		/*[out]*/ BSTR* pbstrCompletionList)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletionListText)

		VSL_SET_VALIDVALUE_BSTR(pbstrCompletionList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompletionListTextAtValidValues
	{
		/*[in]*/ long iParam;
		/*[out]*/ BSTR* pbstrCompletionList;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletionListTextAt)(
		/*[in]*/ long iParam,
		/*[out]*/ BSTR* pbstrCompletionList)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletionListTextAt)

		VSL_CHECK_VALIDVALUE(iParam);

		VSL_SET_VALIDVALUE_BSTR(pbstrCompletionList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPermissionSetValidValues
	{
		/*[out]*/ BSTR* pbstrPermissionSetXML;
		HRESULT retValue;
	};

	STDMETHOD(GetPermissionSet)(
		/*[out]*/ BSTR* pbstrPermissionSetXML)
	{
		VSL_DEFINE_MOCK_METHOD(GetPermissionSet)

		VSL_SET_VALIDVALUE_BSTR(pbstrPermissionSetXML);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeParamCountValidValues
	{
		/*[out]*/ long* piTypeParams;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeParamCount)(
		/*[out]*/ long* piTypeParams)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeParamCount)

		VSL_SET_VALIDVALUE(piTypeParams);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeParamTextAtValidValues
	{
		/*[in]*/ long iTypeParam;
		/*[out]*/ BSTR* pbstrName;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeParamTextAt)(
		/*[in]*/ long iTypeParam,
		/*[out]*/ BSTR* pbstrName,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeParamTextAt)

		VSL_CHECK_VALIDVALUE(iTypeParam);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSXMLMEMBERDATA3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
