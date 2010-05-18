/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUISHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUISHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUIShell2NotImpl :
	public IVsUIShell2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShell2NotImpl)

public:

	typedef IVsUIShell2 Interface;

	STDMETHOD(GetOpenFileNameViaDlgEx)(
		/*[in,out]*/ VSOPENFILENAMEW* /*pOpenFileName*/,
		/*[in]*/ LPCOLESTR /*pszHelpTopic*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSaveFileNameViaDlgEx)(
		/*[in,out]*/ VSSAVEFILENAMEW* /*pSaveFileName*/,
		/*[in]*/ LPCOLESTR /*pszHelpTopic*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDirectoryViaBrowseDlgEx)(
		/*[in,out]*/ VSBROWSEINFOW* /*pBrowse*/,
		/*[in]*/ LPCOLESTR /*pszHelpTopic*/,
		/*[in]*/ LPCOLESTR /*pszOpenButtonLabel*/,
		/*[in]*/ LPCOLESTR /*pszCeilingDir*/,
		/*[in]*/ VSNSEBROWSEINFOW* /*pNSEBrowseInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveItemsViaDlg)(
		/*[in]*/ UINT /*cItems*/,
		/*[in,size_is(cItems)]*/ VSSAVETREEITEM[] /*rgSaveItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVSSysColorEx)(
		/*[in]*/ VSSYSCOLOREX /*dwSysColIndex*/,
		/*[out]*/ DWORD* /*pdwRGBval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateGradient)(
		/*[in]*/ GRADIENTTYPE /*gradientType*/,
		/*[out]*/ IVsGradient** /*pGradient*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVSCursor)(
		/*[in]*/ VSCURSORTYPE /*cursor*/,
		/*[out]*/ HCURSOR* /*phIcon*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsAutoRecoverSavingCheckpoints)(
		/*[out]*/ BOOL* /*pfARSaving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VsDialogBoxParam)(
		/*[in]*/ HINSTANCE /*hinst*/,
		/*[in]*/ DWORD /*dwId*/,
		/*[in]*/ DLGPROC /*lpDialogFunc*/,
		/*[in]*/ LPARAM /*lp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateIconImageButton)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ HICON /*hicon*/,
		/*[in]*/ BWI_IMAGE_POS /*bwiPos*/,
		/*[out]*/ IVsImageButton** /*ppImageButton*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateGlyphImageButton)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ WCHAR /*chGlyph*/,
		/*[in]*/ int /*xShift*/,
		/*[in]*/ int /*yShift*/,
		/*[in]*/ BWI_IMAGE_POS /*bwiPos*/,
		/*[out]*/ IVsImageButton** /*ppImageButton*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIShell2MockImpl :
	public IVsUIShell2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShell2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIShell2MockImpl)

	typedef IVsUIShell2 Interface;
	struct GetOpenFileNameViaDlgExValidValues
	{
		/*[in,out]*/ VSOPENFILENAMEW* pOpenFileName;
		/*[in]*/ LPCOLESTR pszHelpTopic;
		HRESULT retValue;
	};

	STDMETHOD(GetOpenFileNameViaDlgEx)(
		/*[in,out]*/ VSOPENFILENAMEW* pOpenFileName,
		/*[in]*/ LPCOLESTR pszHelpTopic)
	{
		VSL_DEFINE_MOCK_METHOD(GetOpenFileNameViaDlgEx)

		VSL_SET_VALIDVALUE(pOpenFileName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpTopic);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSaveFileNameViaDlgExValidValues
	{
		/*[in,out]*/ VSSAVEFILENAMEW* pSaveFileName;
		/*[in]*/ LPCOLESTR pszHelpTopic;
		HRESULT retValue;
	};

	STDMETHOD(GetSaveFileNameViaDlgEx)(
		/*[in,out]*/ VSSAVEFILENAMEW* pSaveFileName,
		/*[in]*/ LPCOLESTR pszHelpTopic)
	{
		VSL_DEFINE_MOCK_METHOD(GetSaveFileNameViaDlgEx)

		VSL_SET_VALIDVALUE(pSaveFileName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpTopic);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDirectoryViaBrowseDlgExValidValues
	{
		/*[in,out]*/ VSBROWSEINFOW* pBrowse;
		/*[in]*/ LPCOLESTR pszHelpTopic;
		/*[in]*/ LPCOLESTR pszOpenButtonLabel;
		/*[in]*/ LPCOLESTR pszCeilingDir;
		/*[in]*/ VSNSEBROWSEINFOW* pNSEBrowseInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetDirectoryViaBrowseDlgEx)(
		/*[in,out]*/ VSBROWSEINFOW* pBrowse,
		/*[in]*/ LPCOLESTR pszHelpTopic,
		/*[in]*/ LPCOLESTR pszOpenButtonLabel,
		/*[in]*/ LPCOLESTR pszCeilingDir,
		/*[in]*/ VSNSEBROWSEINFOW* pNSEBrowseInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetDirectoryViaBrowseDlgEx)

		VSL_SET_VALIDVALUE(pBrowse);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpTopic);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOpenButtonLabel);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCeilingDir);

		VSL_CHECK_VALIDVALUE_POINTER(pNSEBrowseInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveItemsViaDlgValidValues
	{
		/*[in]*/ UINT cItems;
		/*[in,size_is(cItems)]*/ VSSAVETREEITEM* rgSaveItems;
		HRESULT retValue;
	};

	STDMETHOD(SaveItemsViaDlg)(
		/*[in]*/ UINT cItems,
		/*[in,size_is(cItems)]*/ VSSAVETREEITEM rgSaveItems[])
	{
		VSL_DEFINE_MOCK_METHOD(SaveItemsViaDlg)

		VSL_CHECK_VALIDVALUE(cItems);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSaveItems, cItems*sizeof(rgSaveItems[0]), validValues.cItems*sizeof(validValues.rgSaveItems[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVSSysColorExValidValues
	{
		/*[in]*/ VSSYSCOLOREX dwSysColIndex;
		/*[out]*/ DWORD* pdwRGBval;
		HRESULT retValue;
	};

	STDMETHOD(GetVSSysColorEx)(
		/*[in]*/ VSSYSCOLOREX dwSysColIndex,
		/*[out]*/ DWORD* pdwRGBval)
	{
		VSL_DEFINE_MOCK_METHOD(GetVSSysColorEx)

		VSL_CHECK_VALIDVALUE(dwSysColIndex);

		VSL_SET_VALIDVALUE(pdwRGBval);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateGradientValidValues
	{
		/*[in]*/ GRADIENTTYPE gradientType;
		/*[out]*/ IVsGradient** pGradient;
		HRESULT retValue;
	};

	STDMETHOD(CreateGradient)(
		/*[in]*/ GRADIENTTYPE gradientType,
		/*[out]*/ IVsGradient** pGradient)
	{
		VSL_DEFINE_MOCK_METHOD(CreateGradient)

		VSL_CHECK_VALIDVALUE(gradientType);

		VSL_SET_VALIDVALUE_INTERFACE(pGradient);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVSCursorValidValues
	{
		/*[in]*/ VSCURSORTYPE cursor;
		/*[out]*/ HCURSOR* phIcon;
		HRESULT retValue;
	};

	STDMETHOD(GetVSCursor)(
		/*[in]*/ VSCURSORTYPE cursor,
		/*[out]*/ HCURSOR* phIcon)
	{
		VSL_DEFINE_MOCK_METHOD(GetVSCursor)

		VSL_CHECK_VALIDVALUE(cursor);

		VSL_SET_VALIDVALUE(phIcon);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsAutoRecoverSavingCheckpointsValidValues
	{
		/*[out]*/ BOOL* pfARSaving;
		HRESULT retValue;
	};

	STDMETHOD(IsAutoRecoverSavingCheckpoints)(
		/*[out]*/ BOOL* pfARSaving)
	{
		VSL_DEFINE_MOCK_METHOD(IsAutoRecoverSavingCheckpoints)

		VSL_SET_VALIDVALUE(pfARSaving);

		VSL_RETURN_VALIDVALUES();
	}
	struct VsDialogBoxParamValidValues
	{
		/*[in]*/ HINSTANCE hinst;
		/*[in]*/ DWORD dwId;
		/*[in]*/ DLGPROC lpDialogFunc;
		/*[in]*/ LPARAM lp;
		HRESULT retValue;
	};

	STDMETHOD(VsDialogBoxParam)(
		/*[in]*/ HINSTANCE hinst,
		/*[in]*/ DWORD dwId,
		/*[in]*/ DLGPROC lpDialogFunc,
		/*[in]*/ LPARAM lp)
	{
		VSL_DEFINE_MOCK_METHOD(VsDialogBoxParam)

		VSL_CHECK_VALIDVALUE(hinst);

		VSL_CHECK_VALIDVALUE(dwId);

		VSL_CHECK_VALIDVALUE(lpDialogFunc);

		VSL_CHECK_VALIDVALUE(lp);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateIconImageButtonValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ HICON hicon;
		/*[in]*/ BWI_IMAGE_POS bwiPos;
		/*[out]*/ IVsImageButton** ppImageButton;
		HRESULT retValue;
	};

	STDMETHOD(CreateIconImageButton)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ HICON hicon,
		/*[in]*/ BWI_IMAGE_POS bwiPos,
		/*[out]*/ IVsImageButton** ppImageButton)
	{
		VSL_DEFINE_MOCK_METHOD(CreateIconImageButton)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(hicon);

		VSL_CHECK_VALIDVALUE(bwiPos);

		VSL_SET_VALIDVALUE_INTERFACE(ppImageButton);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateGlyphImageButtonValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ WCHAR chGlyph;
		/*[in]*/ int xShift;
		/*[in]*/ int yShift;
		/*[in]*/ BWI_IMAGE_POS bwiPos;
		/*[out]*/ IVsImageButton** ppImageButton;
		HRESULT retValue;
	};

	STDMETHOD(CreateGlyphImageButton)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ WCHAR chGlyph,
		/*[in]*/ int xShift,
		/*[in]*/ int yShift,
		/*[in]*/ BWI_IMAGE_POS bwiPos,
		/*[out]*/ IVsImageButton** ppImageButton)
	{
		VSL_DEFINE_MOCK_METHOD(CreateGlyphImageButton)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(chGlyph);

		VSL_CHECK_VALIDVALUE(xShift);

		VSL_CHECK_VALIDVALUE(yShift);

		VSL_CHECK_VALIDVALUE(bwiPos);

		VSL_SET_VALIDVALUE_INTERFACE(ppImageButton);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUISHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
