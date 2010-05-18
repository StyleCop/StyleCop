/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSIMPLEPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSIMPLEPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSimplePreviewChangesListNotImpl :
	public IVsSimplePreviewChangesList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSimplePreviewChangesListNotImpl)

public:

	typedef IVsSimplePreviewChangesList Interface;

	STDMETHOD(GetItemCount)(
		/*[out]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayData)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ VSTREEDISPLAYDATA* /*pData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextWithOwnership)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSTREETEXTOPTIONS /*tto*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipTextWithOwnership)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSTREETOOLTIPTYPE /*eTipType*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandable)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfExpandable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandedList)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfCanRecurse*/,
		/*[out]*/ IVsSimplePreviewChangesList** /*ppIVsSimplePreviewChangesList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LocateExpandedList)(
		/*[in]*/ IVsSimplePreviewChangesList* /*pIVsSimplePreviewChangesListChild*/,
		/*[out]*/ ULONG* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleState)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ VSTREESTATECHANGEREFRESH* /*ptscr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRequestSource)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ IUnknown* /*pIUnknownTextView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnClose)(
		/*[out]*/ VSTREECLOSEACTIONS* /*ptca*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSimplePreviewChangesListMockImpl :
	public IVsSimplePreviewChangesList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSimplePreviewChangesListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSimplePreviewChangesListMockImpl)

	typedef IVsSimplePreviewChangesList Interface;
	struct GetItemCountValidValues
	{
		/*[out]*/ ULONG* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetItemCount)(
		/*[out]*/ ULONG* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayDataValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ VSTREEDISPLAYDATA* pData;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayData)(
		/*[in]*/ ULONG Index,
		/*[out]*/ VSTREEDISPLAYDATA* pData)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayData)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextWithOwnershipValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSTREETEXTOPTIONS tto;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetTextWithOwnership)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETEXTOPTIONS tto,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextWithOwnership)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(tto);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTipTextWithOwnershipValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSTREETOOLTIPTYPE eTipType;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipTextWithOwnership)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETOOLTIPTYPE eTipType,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTipTextWithOwnership)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(eTipType);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandableValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ BOOL* pfExpandable;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandable)(
		/*[in]*/ ULONG Index,
		/*[out]*/ BOOL* pfExpandable)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandable)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pfExpandable);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandedListValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ BOOL* pfCanRecurse;
		/*[out]*/ IVsSimplePreviewChangesList** ppIVsSimplePreviewChangesList;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandedList)(
		/*[in]*/ ULONG Index,
		/*[out]*/ BOOL* pfCanRecurse,
		/*[out]*/ IVsSimplePreviewChangesList** ppIVsSimplePreviewChangesList)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandedList)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pfCanRecurse);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsSimplePreviewChangesList);

		VSL_RETURN_VALIDVALUES();
	}
	struct LocateExpandedListValidValues
	{
		/*[in]*/ IVsSimplePreviewChangesList* pIVsSimplePreviewChangesListChild;
		/*[out]*/ ULONG* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(LocateExpandedList)(
		/*[in]*/ IVsSimplePreviewChangesList* pIVsSimplePreviewChangesListChild,
		/*[out]*/ ULONG* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(LocateExpandedList)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsSimplePreviewChangesListChild);

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleStateValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ VSTREESTATECHANGEREFRESH* ptscr;
		HRESULT retValue;
	};

	STDMETHOD(ToggleState)(
		/*[in]*/ ULONG Index,
		/*[out]*/ VSTREESTATECHANGEREFRESH* ptscr)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleState)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(ptscr);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRequestSourceValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ IUnknown* pIUnknownTextView;
		HRESULT retValue;
	};

	STDMETHOD(OnRequestSource)(
		/*[in]*/ ULONG Index,
		/*[in]*/ IUnknown* pIUnknownTextView)
	{
		VSL_DEFINE_MOCK_METHOD(OnRequestSource)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIUnknownTextView);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCloseValidValues
	{
		/*[out]*/ VSTREECLOSEACTIONS* ptca;
		HRESULT retValue;
	};

	STDMETHOD(OnClose)(
		/*[out]*/ VSTREECLOSEACTIONS* ptca)
	{
		VSL_DEFINE_MOCK_METHOD(OnClose)

		VSL_SET_VALIDVALUE(ptca);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSIMPLEPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
