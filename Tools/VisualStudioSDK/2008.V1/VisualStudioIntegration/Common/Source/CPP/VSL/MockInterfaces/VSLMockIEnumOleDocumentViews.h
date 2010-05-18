/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IENUMOLEDOCUMENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IENUMOLEDOCUMENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DocObj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IEnumOleDocumentViewsNotImpl :
	public IEnumOleDocumentViews
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumOleDocumentViewsNotImpl)

public:

	typedef IEnumOleDocumentViews Interface;

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*cViews*/,
		/*[out]*/ IOleDocumentView** /*rgpView*/,
		/*[out]*/ ULONG* /*pcFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Skip)(
		/*[in]*/ ULONG /*cViews*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[out]*/ IEnumOleDocumentViews** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IEnumOleDocumentViewsMockImpl :
	public IEnumOleDocumentViews,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumOleDocumentViewsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEnumOleDocumentViewsMockImpl)

	typedef IEnumOleDocumentViews Interface;
	struct NextValidValues
	{
		/*[in]*/ ULONG cViews;
		/*[out]*/ IOleDocumentView** rgpView;
		/*[out]*/ ULONG* pcFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG cViews,
		/*[out]*/ IOleDocumentView** rgpView,
		/*[out]*/ ULONG* pcFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(cViews);

		VSL_SET_VALIDVALUE_INTERFACE(rgpView);

		VSL_SET_VALIDVALUE(pcFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct SkipValidValues
	{
		/*[in]*/ ULONG cViews;
		HRESULT retValue;
	};

	STDMETHOD(Skip)(
		/*[in]*/ ULONG cViews)
	{
		VSL_DEFINE_MOCK_METHOD(Skip)

		VSL_CHECK_VALIDVALUE(cViews);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneValidValues
	{
		/*[out]*/ IEnumOleDocumentViews** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[out]*/ IEnumOleDocumentViews** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IENUMOLEDOCUMENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
