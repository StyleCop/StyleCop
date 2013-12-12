/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSECOMPLETOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSECOMPLETOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsIntellisenseCompletorNotImpl :
	public IVsIntellisenseCompletor
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseCompletorNotImpl)

public:

	typedef IVsIntellisenseCompletor Interface;

	STDMETHOD(Initialize)(
		/*[in]*/ IVsIntellisenseHost* /*pHost*/,
		/*[in]*/ HWND /*hwndParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)(
		/*[in]*/ IVsCompletionSet* /*pCompSet*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWidth)(
		/*[in]*/ DWORD* /*dwWidth*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHeight)(
		/*[in]*/ DWORD* /*dwHeight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompletionSpan)(
		/*[in]*/ TextSpan* /*ts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLocation)(
		/*[in]*/ POINT* /*p*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsActive)(
		/*[out]*/ BOOL* /*pfIsActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ ULONG /*cCmds*/,
		/*[size_is(cCmds),in,out]*/ OLECMD[] /*prgCmds*/,
		/*[in,out,unique]*/ OLECMDTEXT* /*pCmdText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdID*/,
		/*[in]*/ DWORD /*nCmdexecopt*/,
		/*[in,unique]*/ VARIANT* /*pvaIn*/,
		/*[in,out,unique]*/ VARIANT* /*pvaOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseCompletorMockImpl :
	public IVsIntellisenseCompletor,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseCompletorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseCompletorMockImpl)

	typedef IVsIntellisenseCompletor Interface;
	struct InitializeValidValues
	{
		/*[in]*/ IVsIntellisenseHost* pHost;
		/*[in]*/ HWND hwndParent;
		HRESULT retValue;
	};

	STDMETHOD(Initialize)(
		/*[in]*/ IVsIntellisenseHost* pHost,
		/*[in]*/ HWND hwndParent)
	{
		VSL_DEFINE_MOCK_METHOD(Initialize)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_CHECK_VALIDVALUE(hwndParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateValidValues
	{
		/*[in]*/ IVsCompletionSet* pCompSet;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(Update)(
		/*[in]*/ IVsCompletionSet* pCompSet,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(Update)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCompSet);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWidthValidValues
	{
		/*[in]*/ DWORD* dwWidth;
		HRESULT retValue;
	};

	STDMETHOD(GetWidth)(
		/*[in]*/ DWORD* dwWidth)
	{
		VSL_DEFINE_MOCK_METHOD(GetWidth)

		VSL_CHECK_VALIDVALUE_POINTER(dwWidth);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHeightValidValues
	{
		/*[in]*/ DWORD* dwHeight;
		HRESULT retValue;
	};

	STDMETHOD(GetHeight)(
		/*[in]*/ DWORD* dwHeight)
	{
		VSL_DEFINE_MOCK_METHOD(GetHeight)

		VSL_CHECK_VALIDVALUE_POINTER(dwHeight);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompletionSpanValidValues
	{
		/*[in]*/ TextSpan* ts;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletionSpan)(
		/*[in]*/ TextSpan* ts)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletionSpan)

		VSL_CHECK_VALIDVALUE_POINTER(ts);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLocationValidValues
	{
		/*[in]*/ POINT* p;
		HRESULT retValue;
	};

	STDMETHOD(SetLocation)(
		/*[in]*/ POINT* p)
	{
		VSL_DEFINE_MOCK_METHOD(SetLocation)

		VSL_CHECK_VALIDVALUE_POINTER(p);

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Hide)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Hide)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsActiveValidValues
	{
		/*[out]*/ BOOL* pfIsActive;
		HRESULT retValue;
	};

	STDMETHOD(IsActive)(
		/*[out]*/ BOOL* pfIsActive)
	{
		VSL_DEFINE_MOCK_METHOD(IsActive)

		VSL_SET_VALIDVALUE(pfIsActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWindowHandleValidValues
	{
		/*[out]*/ HWND* phwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* phwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowHandle)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ ULONG cCmds;
		/*[size_is(cCmds),in,out]*/ OLECMD* prgCmds;
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ ULONG cCmds,
		/*[size_is(cCmds),in,out]*/ OLECMD prgCmds[],
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatus)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(cCmds);

		VSL_SET_VALIDVALUE_MEMCPY(prgCmds, cCmds*sizeof(prgCmds[0]), validValues.cCmds*sizeof(validValues.prgCmds[0]));

		VSL_SET_VALIDVALUE(pCmdText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdID;
		/*[in]*/ DWORD nCmdexecopt;
		/*[in,unique]*/ VARIANT* pvaIn;
		/*[in,out,unique]*/ VARIANT* pvaOut;
		HRESULT retValue;
	};

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdID,
		/*[in]*/ DWORD nCmdexecopt,
		/*[in,unique]*/ VARIANT* pvaIn,
		/*[in,out,unique]*/ VARIANT* pvaOut)
	{
		VSL_DEFINE_MOCK_METHOD(Exec)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdID);

		VSL_CHECK_VALIDVALUE(nCmdexecopt);

		VSL_CHECK_VALIDVALUE_POINTER(pvaIn);

		VSL_SET_VALIDVALUE_VARIANT(pvaOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSECOMPLETOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
