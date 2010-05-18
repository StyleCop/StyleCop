/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERINDEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERINDEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsXMLMemberIndexNotImpl :
	public IVsXMLMemberIndex
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberIndexNotImpl)

public:

	typedef IVsXMLMemberIndex Interface;

	STDMETHOD(BuildMemberIndex)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseMemberSignature)(
		/*[in]*/ LPCOLESTR /*pszSignature*/,
		/*[out]*/ DWORD_PTR* /*pdwID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemberXML)(
		/*[in]*/ DWORD_PTR /*dwID*/,
		/*[out]*/ BSTR* /*pbstrXML*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemberDataFromXML)(
		/*[in]*/ LPCOLESTR /*pszXML*/,
		/*[out]*/ IVsXMLMemberData** /*ppObj*/)VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberIndexMockImpl :
	public IVsXMLMemberIndex,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberIndexMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberIndexMockImpl)

	typedef IVsXMLMemberIndex Interface;
	struct BuildMemberIndexValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BuildMemberIndex)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BuildMemberIndex)

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseMemberSignatureValidValues
	{
		/*[in]*/ LPCOLESTR pszSignature;
		/*[out]*/ DWORD_PTR* pdwID;
		HRESULT retValue;
	};

	STDMETHOD(ParseMemberSignature)(
		/*[in]*/ LPCOLESTR pszSignature,
		/*[out]*/ DWORD_PTR* pdwID)
	{
		VSL_DEFINE_MOCK_METHOD(ParseMemberSignature)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSignature);

		VSL_SET_VALIDVALUE(pdwID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemberXMLValidValues
	{
		/*[in]*/ DWORD_PTR dwID;
		/*[out]*/ BSTR* pbstrXML;
		HRESULT retValue;
	};

	STDMETHOD(GetMemberXML)(
		/*[in]*/ DWORD_PTR dwID,
		/*[out]*/ BSTR* pbstrXML)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemberXML)

		VSL_CHECK_VALIDVALUE(dwID);

		VSL_SET_VALIDVALUE_BSTR(pbstrXML);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemberDataFromXMLValidValues
	{
		/*[in]*/ LPCOLESTR pszXML;
		/*[out]*/ IVsXMLMemberData** ppObj;
		HRESULT retValue;
	};

	STDMETHOD(GetMemberDataFromXML)(
		/*[in]*/ LPCOLESTR pszXML,
		/*[out]*/ IVsXMLMemberData** ppObj)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemberDataFromXML)

		VSL_CHECK_VALIDVALUE_STRINGW(pszXML);

		VSL_SET_VALIDVALUE_INTERFACE(ppObj);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSXMLMEMBERINDEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
