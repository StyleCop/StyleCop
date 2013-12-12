/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsExpansionNotImpl :
	public IVsExpansion
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionNotImpl)

public:

	typedef IVsExpansion Interface;

	STDMETHOD(InsertExpansion)(
		/*[in]*/ TextSpan /*tsContext*/,
		/*[in]*/ TextSpan /*tsInsertPos*/,
		/*[in]*/ IVsExpansionClient* /*pExpansionClient*/,
		/*[in]*/ GUID /*guidLang*/,
		/*[out]*/ IVsExpansionSession** /*pSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertNamedExpansion)(
		/*[in]*/ BSTR /*bstrTitle*/,
		/*[in]*/ BSTR /*bstrPath*/,
		/*[in]*/ TextSpan /*tsInsertPos*/,
		/*[in]*/ IVsExpansionClient* /*pExpansionClient*/,
		/*[in]*/ GUID /*guidLang*/,
		/*[in]*/ BOOL /*fShowDisambiguationUI*/,
		/*[out]*/ IVsExpansionSession** /*pSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertSpecificExpansion)(
		/*[in]*/ IXMLDOMNode* /*pSnippet*/,
		/*[in]*/ TextSpan /*tsInsertPos*/,
		/*[in]*/ IVsExpansionClient* /*pExpansionClient*/,
		/*[in]*/ GUID /*guidLang*/,
		/*[in]*/ BSTR /*pszRelativePath*/,
		/*[out]*/ IVsExpansionSession** /*pSession*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionMockImpl :
	public IVsExpansion,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionMockImpl)

	typedef IVsExpansion Interface;
	struct InsertExpansionValidValues
	{
		/*[in]*/ TextSpan tsContext;
		/*[in]*/ TextSpan tsInsertPos;
		/*[in]*/ IVsExpansionClient* pExpansionClient;
		/*[in]*/ GUID guidLang;
		/*[out]*/ IVsExpansionSession** pSession;
		HRESULT retValue;
	};

	STDMETHOD(InsertExpansion)(
		/*[in]*/ TextSpan tsContext,
		/*[in]*/ TextSpan tsInsertPos,
		/*[in]*/ IVsExpansionClient* pExpansionClient,
		/*[in]*/ GUID guidLang,
		/*[out]*/ IVsExpansionSession** pSession)
	{
		VSL_DEFINE_MOCK_METHOD(InsertExpansion)

		VSL_CHECK_VALIDVALUE(tsContext);

		VSL_CHECK_VALIDVALUE(tsInsertPos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExpansionClient);

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_SET_VALIDVALUE_INTERFACE(pSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertNamedExpansionValidValues
	{
		/*[in]*/ BSTR bstrTitle;
		/*[in]*/ BSTR bstrPath;
		/*[in]*/ TextSpan tsInsertPos;
		/*[in]*/ IVsExpansionClient* pExpansionClient;
		/*[in]*/ GUID guidLang;
		/*[in]*/ BOOL fShowDisambiguationUI;
		/*[out]*/ IVsExpansionSession** pSession;
		HRESULT retValue;
	};

	STDMETHOD(InsertNamedExpansion)(
		/*[in]*/ BSTR bstrTitle,
		/*[in]*/ BSTR bstrPath,
		/*[in]*/ TextSpan tsInsertPos,
		/*[in]*/ IVsExpansionClient* pExpansionClient,
		/*[in]*/ GUID guidLang,
		/*[in]*/ BOOL fShowDisambiguationUI,
		/*[out]*/ IVsExpansionSession** pSession)
	{
		VSL_DEFINE_MOCK_METHOD(InsertNamedExpansion)

		VSL_CHECK_VALIDVALUE_BSTR(bstrTitle);

		VSL_CHECK_VALIDVALUE_BSTR(bstrPath);

		VSL_CHECK_VALIDVALUE(tsInsertPos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExpansionClient);

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(fShowDisambiguationUI);

		VSL_SET_VALIDVALUE_INTERFACE(pSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertSpecificExpansionValidValues
	{
		/*[in]*/ IXMLDOMNode* pSnippet;
		/*[in]*/ TextSpan tsInsertPos;
		/*[in]*/ IVsExpansionClient* pExpansionClient;
		/*[in]*/ GUID guidLang;
		/*[in]*/ BSTR pszRelativePath;
		/*[out]*/ IVsExpansionSession** pSession;
		HRESULT retValue;
	};

	STDMETHOD(InsertSpecificExpansion)(
		/*[in]*/ IXMLDOMNode* pSnippet,
		/*[in]*/ TextSpan tsInsertPos,
		/*[in]*/ IVsExpansionClient* pExpansionClient,
		/*[in]*/ GUID guidLang,
		/*[in]*/ BSTR pszRelativePath,
		/*[out]*/ IVsExpansionSession** pSession)
	{
		VSL_DEFINE_MOCK_METHOD(InsertSpecificExpansion)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSnippet);

		VSL_CHECK_VALIDVALUE(tsInsertPos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExpansionClient);

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE_BSTR(pszRelativePath);

		VSL_SET_VALIDVALUE_INTERFACE(pSession);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
