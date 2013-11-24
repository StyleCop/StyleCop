/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODESHAREHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODESHAREHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCodeShareHandlerNotImpl :
	public IVsCodeShareHandler
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeShareHandlerNotImpl)

public:

	typedef IVsCodeShareHandler Interface;

	STDMETHOD(DlgInit)(
		/*[in]*/ HWND /*hwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VBDialogBoxParam)(
		/*[in]*/ HINSTANCE /*hinst*/,
		/*[in]*/ DWORD /*dwId*/,
		/*[in]*/ DWORD* /*pFARPROC*/,
		/*[in]*/ LPARAM /*lp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VBDialogCover)(
		/*[in]*/ DWORD* /*pFARPROC*/,
		/*[in]*/ DWORD* /*lpvoid*/,
		/*[out]*/ HWND* /*lphwndParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VsGetOpenFileName)(
		/*[in]*/ DWORD* /*pOPENFILENAMEA*/,
		/*[in]*/ LONG /*dwHelpTopic*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStdHelp)(
		/*[in]*/ UINT /*wCmd*/,
		/*[in]*/ LONG /*lContext*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeShareHandlerMockImpl :
	public IVsCodeShareHandler,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeShareHandlerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeShareHandlerMockImpl)

	typedef IVsCodeShareHandler Interface;
	struct DlgInitValidValues
	{
		/*[in]*/ HWND hwnd;
		HRESULT retValue;
	};

	STDMETHOD(DlgInit)(
		/*[in]*/ HWND hwnd)
	{
		VSL_DEFINE_MOCK_METHOD(DlgInit)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct VBDialogBoxParamValidValues
	{
		/*[in]*/ HINSTANCE hinst;
		/*[in]*/ DWORD dwId;
		/*[in]*/ DWORD* pFARPROC;
		/*[in]*/ LPARAM lp;
		HRESULT retValue;
	};

	STDMETHOD(VBDialogBoxParam)(
		/*[in]*/ HINSTANCE hinst,
		/*[in]*/ DWORD dwId,
		/*[in]*/ DWORD* pFARPROC,
		/*[in]*/ LPARAM lp)
	{
		VSL_DEFINE_MOCK_METHOD(VBDialogBoxParam)

		VSL_CHECK_VALIDVALUE(hinst);

		VSL_CHECK_VALIDVALUE(dwId);

		VSL_CHECK_VALIDVALUE_POINTER(pFARPROC);

		VSL_CHECK_VALIDVALUE(lp);

		VSL_RETURN_VALIDVALUES();
	}
	struct VBDialogCoverValidValues
	{
		/*[in]*/ DWORD* pFARPROC;
		/*[in]*/ DWORD* lpvoid;
		/*[out]*/ HWND* lphwndParent;
		HRESULT retValue;
	};

	STDMETHOD(VBDialogCover)(
		/*[in]*/ DWORD* pFARPROC,
		/*[in]*/ DWORD* lpvoid,
		/*[out]*/ HWND* lphwndParent)
	{
		VSL_DEFINE_MOCK_METHOD(VBDialogCover)

		VSL_CHECK_VALIDVALUE_POINTER(pFARPROC);

		VSL_CHECK_VALIDVALUE_POINTER(lpvoid);

		VSL_SET_VALIDVALUE(lphwndParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct VsGetOpenFileNameValidValues
	{
		/*[in]*/ DWORD* pOPENFILENAMEA;
		/*[in]*/ LONG dwHelpTopic;
		HRESULT retValue;
	};

	STDMETHOD(VsGetOpenFileName)(
		/*[in]*/ DWORD* pOPENFILENAMEA,
		/*[in]*/ LONG dwHelpTopic)
	{
		VSL_DEFINE_MOCK_METHOD(VsGetOpenFileName)

		VSL_CHECK_VALIDVALUE_POINTER(pOPENFILENAMEA);

		VSL_CHECK_VALIDVALUE(dwHelpTopic);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStdHelpValidValues
	{
		/*[in]*/ UINT wCmd;
		/*[in]*/ LONG lContext;
		HRESULT retValue;
	};

	STDMETHOD(GetStdHelp)(
		/*[in]*/ UINT wCmd,
		/*[in]*/ LONG lContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetStdHelp)

		VSL_CHECK_VALIDVALUE(wCmd);

		VSL_CHECK_VALIDVALUE(lContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODESHAREHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
