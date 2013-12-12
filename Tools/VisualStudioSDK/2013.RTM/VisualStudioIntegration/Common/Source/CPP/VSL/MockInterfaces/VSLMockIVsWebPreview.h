/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBPREVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBPREVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsbrowse.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebPreviewNotImpl :
	public IVsWebPreview
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebPreviewNotImpl)

public:

	typedef IVsWebPreview Interface;

	STDMETHOD(PreviewURL)(
		/*[in]*/ IVsWebPreviewAction* /*pAction*/,
		/*[in]*/ LPCOLESTR /*lpszURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PreviewURLEx)(
		/*[in]*/ IVsWebPreviewAction* /*pAction*/,
		/*[in]*/ LPCOLESTR /*lpszURL*/,
		/*[in]*/ VSWBPREVIEWOPTIONS /*opt*/,
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ActivatePreview)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Resize)(
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebPreviewMockImpl :
	public IVsWebPreview,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebPreviewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebPreviewMockImpl)

	typedef IVsWebPreview Interface;
	struct PreviewURLValidValues
	{
		/*[in]*/ IVsWebPreviewAction* pAction;
		/*[in]*/ LPCOLESTR lpszURL;
		HRESULT retValue;
	};

	STDMETHOD(PreviewURL)(
		/*[in]*/ IVsWebPreviewAction* pAction,
		/*[in]*/ LPCOLESTR lpszURL)
	{
		VSL_DEFINE_MOCK_METHOD(PreviewURL)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreviewURLExValidValues
	{
		/*[in]*/ IVsWebPreviewAction* pAction;
		/*[in]*/ LPCOLESTR lpszURL;
		/*[in]*/ VSWBPREVIEWOPTIONS opt;
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		HRESULT retValue;
	};

	STDMETHOD(PreviewURLEx)(
		/*[in]*/ IVsWebPreviewAction* pAction,
		/*[in]*/ LPCOLESTR lpszURL,
		/*[in]*/ VSWBPREVIEWOPTIONS opt,
		/*[in]*/ int cx,
		/*[in]*/ int cy)
	{
		VSL_DEFINE_MOCK_METHOD(PreviewURLEx)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_CHECK_VALIDVALUE(opt);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivatePreviewValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ActivatePreview)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ActivatePreview)

		VSL_RETURN_VALIDVALUES();
	}
	struct ResizeValidValues
	{
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		HRESULT retValue;
	};

	STDMETHOD(Resize)(
		/*[in]*/ int cx,
		/*[in]*/ int cy)
	{
		VSL_DEFINE_MOCK_METHOD(Resize)

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBPREVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
