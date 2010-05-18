/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleDocumentViewNotImpl :
	public IOleDocumentView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleDocumentViewNotImpl)

public:

	typedef IOleDocumentView Interface;

	STDMETHOD(SetInPlaceSite)(
		/*[in,unique]*/ IOleInPlaceSite* /*pIPSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInPlaceSite)(
		/*[out]*/ IOleInPlaceSite** /*ppIPSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocument)(
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRect)(
		/*[in]*/ LPRECT /*prcView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRect)(
		/*[out]*/ LPRECT /*prcView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRectComplex)(
		/*[in,unique]*/ LPRECT /*prcView*/,
		/*[in,unique]*/ LPRECT /*prcHScroll*/,
		/*[in,unique]*/ LPRECT /*prcVScroll*/,
		/*[in,unique]*/ LPRECT /*prcSizeBox*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Show)(
		/*[in]*/ BOOL /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UIActivate)(
		/*[in]*/ BOOL /*fUIActivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Open)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseView)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveViewState)(
		/*[in]*/ LPSTREAM /*pstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ApplyViewState)(
		/*[in]*/ LPSTREAM /*pstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[in]*/ IOleInPlaceSite* /*pIPSiteNew*/,
		/*[out]*/ IOleDocumentView** /*ppViewNew*/)VSL_STDMETHOD_NOTIMPL
};

class IOleDocumentViewMockImpl :
	public IOleDocumentView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleDocumentViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleDocumentViewMockImpl)

	typedef IOleDocumentView Interface;
	struct SetInPlaceSiteValidValues
	{
		/*[in,unique]*/ IOleInPlaceSite* pIPSite;
		HRESULT retValue;
	};

	STDMETHOD(SetInPlaceSite)(
		/*[in,unique]*/ IOleInPlaceSite* pIPSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetInPlaceSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIPSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInPlaceSiteValidValues
	{
		/*[out]*/ IOleInPlaceSite** ppIPSite;
		HRESULT retValue;
	};

	STDMETHOD(GetInPlaceSite)(
		/*[out]*/ IOleInPlaceSite** ppIPSite)
	{
		VSL_DEFINE_MOCK_METHOD(GetInPlaceSite)

		VSL_SET_VALIDVALUE_INTERFACE(ppIPSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentValidValues
	{
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetDocument)(
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocument)

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRectValidValues
	{
		/*[in]*/ LPRECT prcView;
		HRESULT retValue;
	};

	STDMETHOD(SetRect)(
		/*[in]*/ LPRECT prcView)
	{
		VSL_DEFINE_MOCK_METHOD(SetRect)

		VSL_CHECK_VALIDVALUE(prcView);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRectValidValues
	{
		/*[out]*/ LPRECT prcView;
		HRESULT retValue;
	};

	STDMETHOD(GetRect)(
		/*[out]*/ LPRECT prcView)
	{
		VSL_DEFINE_MOCK_METHOD(GetRect)

		VSL_SET_VALIDVALUE(prcView);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRectComplexValidValues
	{
		/*[in,unique]*/ LPRECT prcView;
		/*[in,unique]*/ LPRECT prcHScroll;
		/*[in,unique]*/ LPRECT prcVScroll;
		/*[in,unique]*/ LPRECT prcSizeBox;
		HRESULT retValue;
	};

	STDMETHOD(SetRectComplex)(
		/*[in,unique]*/ LPRECT prcView,
		/*[in,unique]*/ LPRECT prcHScroll,
		/*[in,unique]*/ LPRECT prcVScroll,
		/*[in,unique]*/ LPRECT prcSizeBox)
	{
		VSL_DEFINE_MOCK_METHOD(SetRectComplex)

		VSL_CHECK_VALIDVALUE(prcView);

		VSL_CHECK_VALIDVALUE(prcHScroll);

		VSL_CHECK_VALIDVALUE(prcVScroll);

		VSL_CHECK_VALIDVALUE(prcSizeBox);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowValidValues
	{
		/*[in]*/ BOOL fShow;
		HRESULT retValue;
	};

	STDMETHOD(Show)(
		/*[in]*/ BOOL fShow)
	{
		VSL_DEFINE_MOCK_METHOD(Show)

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct UIActivateValidValues
	{
		/*[in]*/ BOOL fUIActivate;
		HRESULT retValue;
	};

	STDMETHOD(UIActivate)(
		/*[in]*/ BOOL fUIActivate)
	{
		VSL_DEFINE_MOCK_METHOD(UIActivate)

		VSL_CHECK_VALIDVALUE(fUIActivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Open)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Open)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseViewValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(CloseView)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(CloseView)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveViewStateValidValues
	{
		/*[in]*/ LPSTREAM pstm;
		HRESULT retValue;
	};

	STDMETHOD(SaveViewState)(
		/*[in]*/ LPSTREAM pstm)
	{
		VSL_DEFINE_MOCK_METHOD(SaveViewState)

		VSL_CHECK_VALIDVALUE(pstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplyViewStateValidValues
	{
		/*[in]*/ LPSTREAM pstm;
		HRESULT retValue;
	};

	STDMETHOD(ApplyViewState)(
		/*[in]*/ LPSTREAM pstm)
	{
		VSL_DEFINE_MOCK_METHOD(ApplyViewState)

		VSL_CHECK_VALIDVALUE(pstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneValidValues
	{
		/*[in]*/ IOleInPlaceSite* pIPSiteNew;
		/*[out]*/ IOleDocumentView** ppViewNew;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[in]*/ IOleInPlaceSite* pIPSiteNew,
		/*[out]*/ IOleDocumentView** ppViewNew)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIPSiteNew);

		VSL_SET_VALIDVALUE_INTERFACE(ppViewNew);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
