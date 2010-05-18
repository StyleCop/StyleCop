/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGSPECIFICSYNTAX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGSPECIFICSYNTAX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLangSpecificSyntaxNotImpl :
	public IVsLangSpecificSyntax
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLangSpecificSyntaxNotImpl)

public:

	typedef IVsLangSpecificSyntax Interface;

	STDMETHOD(GetText)(
		/*[in]*/ VSOBJECTINFO* /*pobjInfo*/,
		/*[in]*/ VSTREETEXTOPTIONS /*tto*/,
		/*[out]*/ const WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FillDescription)(
		/*[in]*/ VSOBJECTINFO* /*pobjInfo*/,
		/*[in]*/ IVsObjectBrowserDescription2* /*pobDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSyntaxGuid)(
		/*[out]*/ const GUID* /*pguid*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLangSpecificSyntaxMockImpl :
	public IVsLangSpecificSyntax,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLangSpecificSyntaxMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLangSpecificSyntaxMockImpl)

	typedef IVsLangSpecificSyntax Interface;
	struct GetTextValidValues
	{
		/*[in]*/ VSOBJECTINFO* pobjInfo;
		/*[in]*/ VSTREETEXTOPTIONS tto;
		/*[out]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[in]*/ VSOBJECTINFO* pobjInfo,
		/*[in]*/ VSTREETEXTOPTIONS tto,
		/*[out]*/ const WCHAR** ppszText)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_CHECK_VALIDVALUE_POINTER(pobjInfo);

		VSL_CHECK_VALIDVALUE(tto);

		VSL_SET_VALIDVALUE_CONST(ppszText, WCHAR**);

		VSL_RETURN_VALIDVALUES();
	}
	struct FillDescriptionValidValues
	{
		/*[in]*/ VSOBJECTINFO* pobjInfo;
		/*[in]*/ IVsObjectBrowserDescription2* pobDesc;
		HRESULT retValue;
	};

	STDMETHOD(FillDescription)(
		/*[in]*/ VSOBJECTINFO* pobjInfo,
		/*[in]*/ IVsObjectBrowserDescription2* pobDesc)
	{
		VSL_DEFINE_MOCK_METHOD(FillDescription)

		VSL_CHECK_VALIDVALUE_POINTER(pobjInfo);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pobDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSyntaxGuidValidValues
	{
		/*[out]*/ GUID* pguid;
		HRESULT retValue;
	};

	STDMETHOD(GetSyntaxGuid)(
		/*[out]*/ const GUID* pguid)
	{
		VSL_DEFINE_MOCK_METHOD(GetSyntaxGuid)

		VSL_SET_VALIDVALUE_CONST(pguid, GUID*);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGSPECIFICSYNTAX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
