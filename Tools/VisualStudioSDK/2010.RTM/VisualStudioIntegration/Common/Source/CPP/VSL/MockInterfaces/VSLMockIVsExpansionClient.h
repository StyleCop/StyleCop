/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsExpansionClientNotImpl :
	public IVsExpansionClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionClientNotImpl)

public:

	typedef IVsExpansionClient Interface;

	STDMETHOD(GetExpansionFunction)(
		/*[in]*/ IXMLDOMNode* /*xmlFunctionNode*/,
		/*[in]*/ BSTR /*bstrFieldName*/,
		/*[out]*/ IVsExpansionFunction** /*pFunc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FormatSpan)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ TextSpan* /*ts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndExpansion)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValidType)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ TextSpan* /*ts*/,
		/*[in,size_is(iCountTypes)]*/ BSTR* /*rgTypes*/,
		/*[in]*/ int /*iCountTypes*/,
		/*[out]*/ BOOL* /*pfIsValidType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValidKind)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ TextSpan* /*ts*/,
		/*[in]*/ BSTR /*bstrKind*/,
		/*[out]*/ BOOL* /*pfIsValidKind*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeInsertion)(
		/*[in]*/ IVsExpansionSession* /*pSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterInsertion)(
		/*[in]*/ IVsExpansionSession* /*pSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PositionCaretForEditing)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ TextSpan* /*ts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemChosen)(
		/*[in]*/ BSTR /*pszTitle*/,
		/*[in]*/ BSTR /*pszPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionClientMockImpl :
	public IVsExpansionClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionClientMockImpl)

	typedef IVsExpansionClient Interface;
	struct GetExpansionFunctionValidValues
	{
		/*[in]*/ IXMLDOMNode* xmlFunctionNode;
		/*[in]*/ BSTR bstrFieldName;
		/*[out]*/ IVsExpansionFunction** pFunc;
		HRESULT retValue;
	};

	STDMETHOD(GetExpansionFunction)(
		/*[in]*/ IXMLDOMNode* xmlFunctionNode,
		/*[in]*/ BSTR bstrFieldName,
		/*[out]*/ IVsExpansionFunction** pFunc)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpansionFunction)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(xmlFunctionNode);

		VSL_CHECK_VALIDVALUE_BSTR(bstrFieldName);

		VSL_SET_VALIDVALUE_INTERFACE(pFunc);

		VSL_RETURN_VALIDVALUES();
	}
	struct FormatSpanValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ TextSpan* ts;
		HRESULT retValue;
	};

	STDMETHOD(FormatSpan)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ TextSpan* ts)
	{
		VSL_DEFINE_MOCK_METHOD(FormatSpan)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ts);

		VSL_RETURN_VALIDVALUES();
	}
	struct EndExpansionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EndExpansion)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EndExpansion)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsValidTypeValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ TextSpan* ts;
		/*[in,size_is(iCountTypes)]*/ BSTR* rgTypes;
		/*[in]*/ int iCountTypes;
		/*[out]*/ BOOL* pfIsValidType;
		HRESULT retValue;
	};

	STDMETHOD(IsValidType)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ TextSpan* ts,
		/*[in,size_is(iCountTypes)]*/ BSTR* rgTypes,
		/*[in]*/ int iCountTypes,
		/*[out]*/ BOOL* pfIsValidType)
	{
		VSL_DEFINE_MOCK_METHOD(IsValidType)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ts);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgTypes, iCountTypes*sizeof(rgTypes[0]), validValues.iCountTypes*sizeof(validValues.rgTypes[0]));

		VSL_CHECK_VALIDVALUE(iCountTypes);

		VSL_SET_VALIDVALUE(pfIsValidType);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsValidKindValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ TextSpan* ts;
		/*[in]*/ BSTR bstrKind;
		/*[out]*/ BOOL* pfIsValidKind;
		HRESULT retValue;
	};

	STDMETHOD(IsValidKind)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ TextSpan* ts,
		/*[in]*/ BSTR bstrKind,
		/*[out]*/ BOOL* pfIsValidKind)
	{
		VSL_DEFINE_MOCK_METHOD(IsValidKind)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ts);

		VSL_CHECK_VALIDVALUE_BSTR(bstrKind);

		VSL_SET_VALIDVALUE(pfIsValidKind);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeInsertionValidValues
	{
		/*[in]*/ IVsExpansionSession* pSession;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeInsertion)(
		/*[in]*/ IVsExpansionSession* pSession)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeInsertion)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterInsertionValidValues
	{
		/*[in]*/ IVsExpansionSession* pSession;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterInsertion)(
		/*[in]*/ IVsExpansionSession* pSession)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterInsertion)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct PositionCaretForEditingValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ TextSpan* ts;
		HRESULT retValue;
	};

	STDMETHOD(PositionCaretForEditing)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ TextSpan* ts)
	{
		VSL_DEFINE_MOCK_METHOD(PositionCaretForEditing)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ts);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemChosenValidValues
	{
		/*[in]*/ BSTR pszTitle;
		/*[in]*/ BSTR pszPath;
		HRESULT retValue;
	};

	STDMETHOD(OnItemChosen)(
		/*[in]*/ BSTR pszTitle,
		/*[in]*/ BSTR pszPath)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemChosen)

		VSL_CHECK_VALIDVALUE_BSTR(pszTitle);

		VSL_CHECK_VALIDVALUE_BSTR(pszPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
