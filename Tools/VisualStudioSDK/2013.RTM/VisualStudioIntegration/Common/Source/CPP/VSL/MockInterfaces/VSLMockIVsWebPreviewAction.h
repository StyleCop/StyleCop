/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBPREVIEWACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBPREVIEWACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebPreviewActionNotImpl :
	public IVsWebPreviewAction
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebPreviewActionNotImpl)

public:

	typedef IVsWebPreviewAction Interface;

	STDMETHOD(OnPreviewLoadStart)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPreviewClose)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPreviewLoaded)(
		/*[in]*/ IDispatch* /*pDispDocument*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebPreviewActionMockImpl :
	public IVsWebPreviewAction,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebPreviewActionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebPreviewActionMockImpl)

	typedef IVsWebPreviewAction Interface;
	struct OnPreviewLoadStartValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnPreviewLoadStart)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnPreviewLoadStart)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPreviewCloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnPreviewClose)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnPreviewClose)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPreviewLoadedValidValues
	{
		/*[in]*/ IDispatch* pDispDocument;
		HRESULT retValue;
	};

	STDMETHOD(OnPreviewLoaded)(
		/*[in]*/ IDispatch* pDispDocument)
	{
		VSL_DEFINE_MOCK_METHOD(OnPreviewLoaded)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDispDocument);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBPREVIEWACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
