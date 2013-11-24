/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPreviewChangesListNotImpl :
	public IVsPreviewChangesList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPreviewChangesListNotImpl)

public:

	typedef IVsPreviewChangesList Interface;

	STDMETHOD(GetFlags)(
		/*[out]*/ VSTREEFLAGS* /*pFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemCount)(
		/*[out]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandedList)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfCanRecurse*/,
		/*[out]*/ IVsLiteTreeList** /*pptlNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LocateExpandedList)(
		/*[in]*/ IVsLiteTreeList* /*ExpandedList*/,
		/*[out]*/ ULONG* /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnClose)(
		/*[out]*/ VSTREECLOSEACTIONS* /*ptca*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSTREETEXTOPTIONS /*tto*/,
		/*[out,string]*/ const WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipText)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSTREETOOLTIPTYPE /*eTipType*/,
		/*[out,string]*/ const WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandable)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfExpandable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayData)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ VSTREEDISPLAYDATA* /*pData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* /*pCurUpdate*/,
		/*[out]*/ VSTREEITEMCHANGESMASK* /*pgrfChanges*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListChanges)(
		/*[in,out]*/ ULONG* /*pcChanges*/,
		/*[in,size_is(*pcChanges)]*/ VSTREELISTITEMCHANGE* /*prgListChanges*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleState)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ VSTREESTATECHANGEREFRESH* /*ptscr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRequestSource)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ IUnknown* /*pIUnknownTextView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPreviewChangesListMockImpl :
	public IVsPreviewChangesList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPreviewChangesListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPreviewChangesListMockImpl)

	typedef IVsPreviewChangesList Interface;
	struct GetFlagsValidValues
	{
		/*[out]*/ VSTREEFLAGS* pFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetFlags)(
		/*[out]*/ VSTREEFLAGS* pFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetFlags)

		VSL_SET_VALIDVALUE(pFlags);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct GetExpandedListValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ BOOL* pfCanRecurse;
		/*[out]*/ IVsLiteTreeList** pptlNode;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandedList)(
		/*[in]*/ ULONG Index,
		/*[out]*/ BOOL* pfCanRecurse,
		/*[out]*/ IVsLiteTreeList** pptlNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandedList)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pfCanRecurse);

		VSL_SET_VALIDVALUE_INTERFACE(pptlNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct LocateExpandedListValidValues
	{
		/*[in]*/ IVsLiteTreeList* ExpandedList;
		/*[out]*/ ULONG* iIndex;
		HRESULT retValue;
	};

	STDMETHOD(LocateExpandedList)(
		/*[in]*/ IVsLiteTreeList* ExpandedList,
		/*[out]*/ ULONG* iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(LocateExpandedList)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ExpandedList);

		VSL_SET_VALIDVALUE(iIndex);

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
	struct GetTextValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSTREETEXTOPTIONS tto;
		/*[out,string]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETEXTOPTIONS tto,
		/*[out,string]*/ const WCHAR** ppszText)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(tto);

		VSL_SET_VALIDVALUE_CONST(ppszText, WCHAR**);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTipTextValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSTREETOOLTIPTYPE eTipType;
		/*[out,string]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipText)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETOOLTIPTYPE eTipType,
		/*[out,string]*/ const WCHAR** ppszText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTipText)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(eTipType);

		VSL_SET_VALIDVALUE_CONST(ppszText, WCHAR**);

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
	struct UpdateCounterValidValues
	{
		/*[out]*/ ULONG* pCurUpdate;
		/*[out]*/ VSTREEITEMCHANGESMASK* pgrfChanges;
		HRESULT retValue;
	};

	STDMETHOD(UpdateCounter)(
		/*[out]*/ ULONG* pCurUpdate,
		/*[out]*/ VSTREEITEMCHANGESMASK* pgrfChanges)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateCounter)

		VSL_SET_VALIDVALUE(pCurUpdate);

		VSL_SET_VALIDVALUE(pgrfChanges);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListChangesValidValues
	{
		/*[in,out]*/ ULONG* pcChanges;
		/*[in,size_is(*pcChanges)]*/ VSTREELISTITEMCHANGE* prgListChanges;
		HRESULT retValue;
	};

	STDMETHOD(GetListChanges)(
		/*[in,out]*/ ULONG* pcChanges,
		/*[in,size_is(*pcChanges)]*/ VSTREELISTITEMCHANGE* prgListChanges)
	{
		VSL_DEFINE_MOCK_METHOD(GetListChanges)

		VSL_SET_VALIDVALUE(pcChanges);

		VSL_CHECK_VALIDVALUE_MEMCMP(prgListChanges, *pcChanges*sizeof(prgListChanges[0]), *(validValues.pcChanges)*sizeof(validValues.prgListChanges[0]));

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPREVIEWCHANGESLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
