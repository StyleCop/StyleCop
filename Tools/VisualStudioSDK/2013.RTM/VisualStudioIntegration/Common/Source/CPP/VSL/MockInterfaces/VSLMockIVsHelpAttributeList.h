/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHELPATTRIBUTELIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHELPATTRIBUTELIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHelpAttributeListNotImpl :
	public IVsHelpAttributeList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHelpAttributeListNotImpl)

public:

	typedef IVsHelpAttributeList Interface;

	STDMETHOD(GetAttributeName)(
		/*[out]*/ BSTR* /*bstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCount)(
		/*[out]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateAttributeStatus)(
		/*[in]*/ BOOL* /*afActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttributeStatusVal)(
		/*[in]*/ BSTR /*bstrValue*/,
		/*[in]*/ ATTRVALUETYPE /*type*/,
		/*[out]*/ BOOL* /*pfActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttributeStatusIndex)(
		/*[in]*/ int /*index*/,
		/*[out]*/ BOOL* /*pfActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttributeValue)(
		/*[in]*/ int /*index*/,
		/*[in]*/ ATTRVALUETYPE /*type*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHelpAttributeListMockImpl :
	public IVsHelpAttributeList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHelpAttributeListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHelpAttributeListMockImpl)

	typedef IVsHelpAttributeList Interface;
	struct GetAttributeNameValidValues
	{
		/*[out]*/ BSTR* bstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributeName)(
		/*[out]*/ BSTR* bstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributeName)

		VSL_SET_VALIDVALUE_BSTR(bstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCountValidValues
	{
		/*[out]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateAttributeStatusValidValues
	{
		/*[in]*/ BOOL* afActive;
		HRESULT retValue;
	};

	STDMETHOD(UpdateAttributeStatus)(
		/*[in]*/ BOOL* afActive)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateAttributeStatus)

		VSL_CHECK_VALIDVALUE_POINTER(afActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributeStatusValValidValues
	{
		/*[in]*/ BSTR bstrValue;
		/*[in]*/ ATTRVALUETYPE type;
		/*[out]*/ BOOL* pfActive;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributeStatusVal)(
		/*[in]*/ BSTR bstrValue,
		/*[in]*/ ATTRVALUETYPE type,
		/*[out]*/ BOOL* pfActive)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributeStatusVal)

		VSL_CHECK_VALIDVALUE_BSTR(bstrValue);

		VSL_CHECK_VALIDVALUE(type);

		VSL_SET_VALIDVALUE(pfActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributeStatusIndexValidValues
	{
		/*[in]*/ int index;
		/*[out]*/ BOOL* pfActive;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributeStatusIndex)(
		/*[in]*/ int index,
		/*[out]*/ BOOL* pfActive)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributeStatusIndex)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pfActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributeValueValidValues
	{
		/*[in]*/ int index;
		/*[in]*/ ATTRVALUETYPE type;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributeValue)(
		/*[in]*/ int index,
		/*[in]*/ ATTRVALUETYPE type,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributeValue)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(type);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHELPATTRIBUTELIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
