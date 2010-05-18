/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERINDEXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERINDEXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsXMLMemberIndexServiceNotImpl :
	public IVsXMLMemberIndexService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberIndexServiceNotImpl)

public:

	typedef IVsXMLMemberIndexService Interface;

	STDMETHOD(CreateXMLMemberIndex)(
		/*[in]*/ LPCOLESTR /*pszBinaryName*/,
		/*[out]*/ IVsXMLMemberIndex** /*ppIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemberDataFromXML)(
		/*[in]*/ LPCOLESTR /*pszXML*/,
		/*[out]*/ IVsXMLMemberData** /*ppObj*/)VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberIndexServiceMockImpl :
	public IVsXMLMemberIndexService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberIndexServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberIndexServiceMockImpl)

	typedef IVsXMLMemberIndexService Interface;
	struct CreateXMLMemberIndexValidValues
	{
		/*[in]*/ LPCOLESTR pszBinaryName;
		/*[out]*/ IVsXMLMemberIndex** ppIndex;
		HRESULT retValue;
	};

	STDMETHOD(CreateXMLMemberIndex)(
		/*[in]*/ LPCOLESTR pszBinaryName,
		/*[out]*/ IVsXMLMemberIndex** ppIndex)
	{
		VSL_DEFINE_MOCK_METHOD(CreateXMLMemberIndex)

		VSL_CHECK_VALIDVALUE_STRINGW(pszBinaryName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIndex);

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

#endif // IVSXMLMEMBERINDEXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
