/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsLanguageInfoNotImpl :
	public IVsLanguageInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageInfoNotImpl)

public:

	typedef IVsLanguageInfo Interface;

	STDMETHOD(GetLanguageName)(
		/*[out]*/ BSTR* /*bstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFileExtensions)(
		/*[out]*/ BSTR* /*pbstrExtensions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColorizer)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[out]*/ IVsColorizer** /*ppColorizer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeWindowManager)(
		/*[in]*/ IVsCodeWindow* /*pCodeWin*/,
		/*[out]*/ IVsCodeWindowManager** /*ppCodeWinMgr*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageInfoMockImpl :
	public IVsLanguageInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageInfoMockImpl)

	typedef IVsLanguageInfo Interface;
	struct GetLanguageNameValidValues
	{
		/*[out]*/ BSTR* bstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageName)(
		/*[out]*/ BSTR* bstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageName)

		VSL_SET_VALIDVALUE_BSTR(bstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFileExtensionsValidValues
	{
		/*[out]*/ BSTR* pbstrExtensions;
		HRESULT retValue;
	};

	STDMETHOD(GetFileExtensions)(
		/*[out]*/ BSTR* pbstrExtensions)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileExtensions)

		VSL_SET_VALIDVALUE_BSTR(pbstrExtensions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColorizerValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[out]*/ IVsColorizer** ppColorizer;
		HRESULT retValue;
	};

	STDMETHOD(GetColorizer)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[out]*/ IVsColorizer** ppColorizer)
	{
		VSL_DEFINE_MOCK_METHOD(GetColorizer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE_INTERFACE(ppColorizer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeWindowManagerValidValues
	{
		/*[in]*/ IVsCodeWindow* pCodeWin;
		/*[out]*/ IVsCodeWindowManager** ppCodeWinMgr;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeWindowManager)(
		/*[in]*/ IVsCodeWindow* pCodeWin,
		/*[out]*/ IVsCodeWindowManager** ppCodeWinMgr)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeWindowManager)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeWin);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeWinMgr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
