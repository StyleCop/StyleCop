/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IUIHOSTLOCALE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IUIHOSTLOCALE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "uilocale.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IUIHostLocale2NotImpl :
	public IUIHostLocale2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIHostLocale2NotImpl)

public:

	typedef IUIHostLocale2 Interface;

	STDMETHOD(LoadUILibrary)(
		/*[in]*/ LPCOLESTR /*lpstrPath*/,
		/*[in]*/ LPCOLESTR /*lpstrDllName*/,
		/*[in]*/ DWORD /*dwExFlags*/,
		/*[out,retval]*/ DWORD_PTR* /*phinstOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MungeDialogFont)(
		/*[in]*/ DWORD /*dwSize*/,
		/*[in,size_is(dwSize)]*/ const BYTE* /*pDlgTemplate*/,
		/*[out]*/ BYTE** /*ppDlgTemplateOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadDialog)(
		/*[in]*/ DWORD_PTR /*hMod*/,
		/*[in]*/ DWORD /*dwDlgResId*/,
		/*[out]*/ BYTE** /*ppDlgTemplate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUILibraryFileName)(
		/*[in]*/ LPCOLESTR /*lpstrPath*/,
		/*[in]*/ LPCOLESTR /*lpstrDllName*/,
		/*[out,retval]*/ BSTR* /*pbstrOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUILocale)(
		/*[out,retval]*/ LCID* /*plcid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDialogFont)(
		/*[out]*/ UIDLGLOGFONT* /*plogfont*/)VSL_STDMETHOD_NOTIMPL
};

class IUIHostLocale2MockImpl :
	public IUIHostLocale2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIHostLocale2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IUIHostLocale2MockImpl)

	typedef IUIHostLocale2 Interface;
	struct LoadUILibraryValidValues
	{
		/*[in]*/ LPCOLESTR lpstrPath;
		/*[in]*/ LPCOLESTR lpstrDllName;
		/*[in]*/ DWORD dwExFlags;
		/*[out,retval]*/ DWORD_PTR* phinstOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadUILibrary)(
		/*[in]*/ LPCOLESTR lpstrPath,
		/*[in]*/ LPCOLESTR lpstrDllName,
		/*[in]*/ DWORD dwExFlags,
		/*[out,retval]*/ DWORD_PTR* phinstOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadUILibrary)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDllName);

		VSL_CHECK_VALIDVALUE(dwExFlags);

		VSL_SET_VALIDVALUE(phinstOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct MungeDialogFontValidValues
	{
		/*[in]*/ DWORD dwSize;
		/*[in,size_is(dwSize)]*/ BYTE* pDlgTemplate;
		/*[out]*/ BYTE** ppDlgTemplateOut;
		HRESULT retValue;
	};

	STDMETHOD(MungeDialogFont)(
		/*[in]*/ DWORD dwSize,
		/*[in,size_is(dwSize)]*/ const BYTE* pDlgTemplate,
		/*[out]*/ BYTE** ppDlgTemplateOut)
	{
		VSL_DEFINE_MOCK_METHOD(MungeDialogFont)

		VSL_CHECK_VALIDVALUE(dwSize);

		VSL_CHECK_VALIDVALUE_MEMCMP(pDlgTemplate, dwSize*sizeof(pDlgTemplate[0]), validValues.dwSize*sizeof(validValues.pDlgTemplate[0]));

		VSL_SET_VALIDVALUE(ppDlgTemplateOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadDialogValidValues
	{
		/*[in]*/ DWORD_PTR hMod;
		/*[in]*/ DWORD dwDlgResId;
		/*[out]*/ BYTE** ppDlgTemplate;
		HRESULT retValue;
	};

	STDMETHOD(LoadDialog)(
		/*[in]*/ DWORD_PTR hMod,
		/*[in]*/ DWORD dwDlgResId,
		/*[out]*/ BYTE** ppDlgTemplate)
	{
		VSL_DEFINE_MOCK_METHOD(LoadDialog)

		VSL_CHECK_VALIDVALUE(hMod);

		VSL_CHECK_VALIDVALUE(dwDlgResId);

		VSL_SET_VALIDVALUE(ppDlgTemplate);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUILibraryFileNameValidValues
	{
		/*[in]*/ LPCOLESTR lpstrPath;
		/*[in]*/ LPCOLESTR lpstrDllName;
		/*[out,retval]*/ BSTR* pbstrOut;
		HRESULT retValue;
	};

	STDMETHOD(GetUILibraryFileName)(
		/*[in]*/ LPCOLESTR lpstrPath,
		/*[in]*/ LPCOLESTR lpstrDllName,
		/*[out,retval]*/ BSTR* pbstrOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetUILibraryFileName)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDllName);

		VSL_SET_VALIDVALUE_BSTR(pbstrOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUILocaleValidValues
	{
		/*[out,retval]*/ LCID* plcid;
		HRESULT retValue;
	};

	STDMETHOD(GetUILocale)(
		/*[out,retval]*/ LCID* plcid)
	{
		VSL_DEFINE_MOCK_METHOD(GetUILocale)

		VSL_SET_VALIDVALUE(plcid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDialogFontValidValues
	{
		/*[out]*/ UIDLGLOGFONT* plogfont;
		HRESULT retValue;
	};

	STDMETHOD(GetDialogFont)(
		/*[out]*/ UIDLGLOGFONT* plogfont)
	{
		VSL_DEFINE_MOCK_METHOD(GetDialogFont)

		VSL_SET_VALIDVALUE(plogfont);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IUIHOSTLOCALE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
