/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExpansionSessionNotImpl :
	public IVsExpansionSession
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionSessionNotImpl)

public:

	typedef IVsExpansionSession Interface;

	STDMETHOD(EndCurrentExpansion)(
		/*[in]*/ BOOL /*fLeaveCaret*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GoToNextExpansionField)(
		/*[in]*/ BOOL /*fCommitIfLast*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GoToPreviousExpansionField)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFieldValue)(
		/*[in]*/ BSTR /*bstrFieldName*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFieldDefault)(
		/*[in]*/ BSTR /*bstrFieldName*/,
		/*[in]*/ BSTR /*bstrNewValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFieldSpan)(
		/*[in]*/ BSTR /*bstrField*/,
		/*[out]*/ TextSpan* /*ptsSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHeaderNode)(
		/*[in]*/ BSTR /*bstrNode*/,
		/*[out]*/ IXMLDOMNode** /*pNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDeclarationNode)(
		/*[in]*/ BSTR /*bstrNode*/,
		/*[out]*/ IXMLDOMNode** /*pNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSnippetNode)(
		/*[in]*/ BSTR /*bstrNode*/,
		/*[out]*/ IXMLDOMNode** /*pNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSnippetSpan)(
		/*[out]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEndSpan)(
		/*[in]*/ TextSpan /*ts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEndSpan)(
		/*[out]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionSessionMockImpl :
	public IVsExpansionSession,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionSessionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionSessionMockImpl)

	typedef IVsExpansionSession Interface;
	struct EndCurrentExpansionValidValues
	{
		/*[in]*/ BOOL fLeaveCaret;
		HRESULT retValue;
	};

	STDMETHOD(EndCurrentExpansion)(
		/*[in]*/ BOOL fLeaveCaret)
	{
		VSL_DEFINE_MOCK_METHOD(EndCurrentExpansion)

		VSL_CHECK_VALIDVALUE(fLeaveCaret);

		VSL_RETURN_VALIDVALUES();
	}
	struct GoToNextExpansionFieldValidValues
	{
		/*[in]*/ BOOL fCommitIfLast;
		HRESULT retValue;
	};

	STDMETHOD(GoToNextExpansionField)(
		/*[in]*/ BOOL fCommitIfLast)
	{
		VSL_DEFINE_MOCK_METHOD(GoToNextExpansionField)

		VSL_CHECK_VALIDVALUE(fCommitIfLast);

		VSL_RETURN_VALIDVALUES();
	}
	struct GoToPreviousExpansionFieldValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(GoToPreviousExpansionField)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GoToPreviousExpansionField)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFieldValueValidValues
	{
		/*[in]*/ BSTR bstrFieldName;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetFieldValue)(
		/*[in]*/ BSTR bstrFieldName,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetFieldValue)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFieldName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFieldDefaultValidValues
	{
		/*[in]*/ BSTR bstrFieldName;
		/*[in]*/ BSTR bstrNewValue;
		HRESULT retValue;
	};

	STDMETHOD(SetFieldDefault)(
		/*[in]*/ BSTR bstrFieldName,
		/*[in]*/ BSTR bstrNewValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetFieldDefault)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFieldName);

		VSL_CHECK_VALIDVALUE_BSTR(bstrNewValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFieldSpanValidValues
	{
		/*[in]*/ BSTR bstrField;
		/*[out]*/ TextSpan* ptsSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetFieldSpan)(
		/*[in]*/ BSTR bstrField,
		/*[out]*/ TextSpan* ptsSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetFieldSpan)

		VSL_CHECK_VALIDVALUE_BSTR(bstrField);

		VSL_SET_VALIDVALUE(ptsSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHeaderNodeValidValues
	{
		/*[in]*/ BSTR bstrNode;
		/*[out]*/ IXMLDOMNode** pNode;
		HRESULT retValue;
	};

	STDMETHOD(GetHeaderNode)(
		/*[in]*/ BSTR bstrNode,
		/*[out]*/ IXMLDOMNode** pNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetHeaderNode)

		VSL_CHECK_VALIDVALUE_BSTR(bstrNode);

		VSL_SET_VALIDVALUE_INTERFACE(pNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDeclarationNodeValidValues
	{
		/*[in]*/ BSTR bstrNode;
		/*[out]*/ IXMLDOMNode** pNode;
		HRESULT retValue;
	};

	STDMETHOD(GetDeclarationNode)(
		/*[in]*/ BSTR bstrNode,
		/*[out]*/ IXMLDOMNode** pNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetDeclarationNode)

		VSL_CHECK_VALIDVALUE_BSTR(bstrNode);

		VSL_SET_VALIDVALUE_INTERFACE(pNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSnippetNodeValidValues
	{
		/*[in]*/ BSTR bstrNode;
		/*[out]*/ IXMLDOMNode** pNode;
		HRESULT retValue;
	};

	STDMETHOD(GetSnippetNode)(
		/*[in]*/ BSTR bstrNode,
		/*[out]*/ IXMLDOMNode** pNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetSnippetNode)

		VSL_CHECK_VALIDVALUE_BSTR(bstrNode);

		VSL_SET_VALIDVALUE_INTERFACE(pNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSnippetSpanValidValues
	{
		/*[out]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetSnippetSpan)(
		/*[out]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetSnippetSpan)

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEndSpanValidValues
	{
		/*[in]*/ TextSpan ts;
		HRESULT retValue;
	};

	STDMETHOD(SetEndSpan)(
		/*[in]*/ TextSpan ts)
	{
		VSL_DEFINE_MOCK_METHOD(SetEndSpan)

		VSL_CHECK_VALIDVALUE(ts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEndSpanValidValues
	{
		/*[out]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetEndSpan)(
		/*[out]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetEndSpan)

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
