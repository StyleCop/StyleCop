/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXTEXPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXTEXPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUserContextExportNotImpl :
	public IVsUserContextExport
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextExportNotImpl)

public:

	typedef IVsUserContextExport Interface;

	STDMETHOD(GetUserContextAsText)(
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS /*dwFlags*/,
		/*[in]*/ BSTR /*bstrOptions*/,
		/*[in]*/ BSTR* /*pbstrKeywords*/,
		/*[in]*/ BSTR* /*pbstrAttributes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserContextAsSafeArray)(
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS /*dwFlags*/,
		/*[in]*/ BSTR /*bstrF1Keyword*/,
		/*[in]*/ SAFEARRAY** /*ppKeywords*/,
		/*[in]*/ SAFEARRAY** /*ppAttributes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateSubcontextsFromSafeArrays)(
		/*[in]*/ IVsMonitorUserContext* /*pMUC*/,
		/*[in]*/ SAFEARRAY* /*pKeywords*/,
		/*[in]*/ SAFEARRAY* /*pAttributes*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextExportMockImpl :
	public IVsUserContextExport,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextExportMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextExportMockImpl)

	typedef IVsUserContextExport Interface;
	struct GetUserContextAsTextValidValues
	{
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS dwFlags;
		/*[in]*/ BSTR bstrOptions;
		/*[in]*/ BSTR* pbstrKeywords;
		/*[in]*/ BSTR* pbstrAttributes;
		HRESULT retValue;
	};

	STDMETHOD(GetUserContextAsText)(
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS dwFlags,
		/*[in]*/ BSTR bstrOptions,
		/*[in]*/ BSTR* pbstrKeywords,
		/*[in]*/ BSTR* pbstrAttributes)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserContextAsText)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_BSTR(bstrOptions);

		VSL_CHECK_VALIDVALUE_POINTER(pbstrKeywords);

		VSL_CHECK_VALIDVALUE_POINTER(pbstrAttributes);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserContextAsSafeArrayValidValues
	{
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS dwFlags;
		/*[in]*/ BSTR bstrF1Keyword;
		/*[in]*/ SAFEARRAY** ppKeywords;
		/*[in]*/ SAFEARRAY** ppAttributes;
		HRESULT retValue;
	};

	STDMETHOD(GetUserContextAsSafeArray)(
		/*[in]*/ VSUSERCONTEXTEXPORTTEXTFLAGS dwFlags,
		/*[in]*/ BSTR bstrF1Keyword,
		/*[in]*/ SAFEARRAY** ppKeywords,
		/*[in]*/ SAFEARRAY** ppAttributes)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserContextAsSafeArray)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_BSTR(bstrF1Keyword);

		VSL_CHECK_VALIDVALUE_SAFEARRAY(ppKeywords);

		VSL_CHECK_VALIDVALUE_SAFEARRAY(ppAttributes);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateSubcontextsFromSafeArraysValidValues
	{
		/*[in]*/ IVsMonitorUserContext* pMUC;
		/*[in]*/ SAFEARRAY* pKeywords;
		/*[in]*/ SAFEARRAY* pAttributes;
		HRESULT retValue;
	};

	STDMETHOD(CreateSubcontextsFromSafeArrays)(
		/*[in]*/ IVsMonitorUserContext* pMUC,
		/*[in]*/ SAFEARRAY* pKeywords,
		/*[in]*/ SAFEARRAY* pAttributes)
	{
		VSL_DEFINE_MOCK_METHOD(CreateSubcontextsFromSafeArrays)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMUC);

		VSL_CHECK_VALIDVALUE(pKeywords);

		VSL_CHECK_VALIDVALUE(pAttributes);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXTEXPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
