/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLITETREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLITETREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLiteTreeNotImpl :
	public IVsLiteTree
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLiteTreeNotImpl)

public:

	typedef IVsLiteTree Interface;

	STDMETHOD(SetRoot)(
		/*[in]*/ IVsLiteTreeList* /*pList*/,
		/*[out]*/ IVsLiteTree** /*ppClone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloneTreeAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out,retval]*/ IVsLiteTree** /*retVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReAlign)(
		/*[in]*/ IVsLiteTreeList* /*pNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertItems)(
		/*[in]*/ IVsLiteTreeList* /*pNode*/,
		/*[in]*/ ULONG /*iAfter*/,
		/*[in]*/ ULONG /*Count*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteItems)(
		/*[in]*/ IVsLiteTreeList* /*pNode*/,
		/*[in]*/ ULONG /*iStart*/,
		/*[in]*/ ULONG /*Count*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleExpansionAbsolute)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfCanRecurse*/,
		/*[out]*/ long* /*pChange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandedAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ BOOL* /*pfExpanded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandableAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ BOOL* /*pfCanExpand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemInfoAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ IVsLiteTreeList** /*pptl*/,
		/*[out]*/ ULONG* /*pIndex*/,
		/*[out]*/ ULONG* /*pLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VisibleItemCount)(
		/*[out]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Refresh)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescendantItemCount)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParentIndexAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ ULONG* /*pParentIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandedListAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ ULONG* /*pLevel*/,
		/*[out]*/ IVsLiteTreeList** /*pptl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleStateAbsolute)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ VSTREESTATECHANGEREFRESH* /*ptscr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseTreeEvents)(
		/*[in]*/ IVsLiteTreeEvents* /*pEventSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseTreeEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableTreeEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/,
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumAbsoluteIndices)(
		/*[in]*/ IVsLiteTreeList* /*pList*/,
		/*[in]*/ ULONG /*Index*/,
		/*[in,out]*/ void** /*ppvNext*/,
		/*[out]*/ ULONG* /*pAbsIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOffsetFromParent)(
		/*[in]*/ ULONG /*ParentAbsIndex*/,
		/*[in]*/ ULONG /*RelIndex*/,
		/*[out]*/ ULONG* /*pOffset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumOrderedListItems)(
		/*[in,out]*/ ULONG* /*pNextStartIndex*/,
		/*[out]*/ IVsLiteTreeList** /*pptl*/,
		/*[out]*/ ULONG* /*pFirstRelIndex*/,
		/*[out]*/ ULONG* /*pLastRelIndex*/,
		/*[out]*/ ULONG* /*pLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRedraw)(
		/*[in]*/ BOOL /*fOn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DelayRedraw)(
		/*[in]*/ BOOL /*fOn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryItemVisible)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Init)(
		/*[in]*/ VSLITETREEOPTS /*grfOpts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInitFlags)(
		/*[out]*/ VSLITETREEOPTS* /*pgrfOpts*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLiteTreeMockImpl :
	public IVsLiteTree,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLiteTreeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLiteTreeMockImpl)

	typedef IVsLiteTree Interface;
	struct SetRootValidValues
	{
		/*[in]*/ IVsLiteTreeList* pList;
		/*[out]*/ IVsLiteTree** ppClone;
		HRESULT retValue;
	};

	STDMETHOD(SetRoot)(
		/*[in]*/ IVsLiteTreeList* pList,
		/*[out]*/ IVsLiteTree** ppClone)
	{
		VSL_DEFINE_MOCK_METHOD(SetRoot)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pList);

		VSL_SET_VALIDVALUE_INTERFACE(ppClone);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneTreeAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out,retval]*/ IVsLiteTree** retVal;
		HRESULT retValue;
	};

	STDMETHOD(CloneTreeAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out,retval]*/ IVsLiteTree** retVal)
	{
		VSL_DEFINE_MOCK_METHOD(CloneTreeAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE_INTERFACE(retVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReAlignValidValues
	{
		/*[in]*/ IVsLiteTreeList* pNode;
		HRESULT retValue;
	};

	STDMETHOD(ReAlign)(
		/*[in]*/ IVsLiteTreeList* pNode)
	{
		VSL_DEFINE_MOCK_METHOD(ReAlign)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertItemsValidValues
	{
		/*[in]*/ IVsLiteTreeList* pNode;
		/*[in]*/ ULONG iAfter;
		/*[in]*/ ULONG Count;
		HRESULT retValue;
	};

	STDMETHOD(InsertItems)(
		/*[in]*/ IVsLiteTreeList* pNode,
		/*[in]*/ ULONG iAfter,
		/*[in]*/ ULONG Count)
	{
		VSL_DEFINE_MOCK_METHOD(InsertItems)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNode);

		VSL_CHECK_VALIDVALUE(iAfter);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteItemsValidValues
	{
		/*[in]*/ IVsLiteTreeList* pNode;
		/*[in]*/ ULONG iStart;
		/*[in]*/ ULONG Count;
		HRESULT retValue;
	};

	STDMETHOD(DeleteItems)(
		/*[in]*/ IVsLiteTreeList* pNode,
		/*[in]*/ ULONG iStart,
		/*[in]*/ ULONG Count)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteItems)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNode);

		VSL_CHECK_VALIDVALUE(iStart);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleExpansionAbsoluteValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ BOOL* pfCanRecurse;
		/*[out]*/ long* pChange;
		HRESULT retValue;
	};

	STDMETHOD(ToggleExpansionAbsolute)(
		/*[in]*/ ULONG Index,
		/*[out]*/ BOOL* pfCanRecurse,
		/*[out]*/ long* pChange)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleExpansionAbsolute)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pfCanRecurse);

		VSL_SET_VALIDVALUE(pChange);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandedAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ BOOL* pfExpanded;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandedAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ BOOL* pfExpanded)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandedAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pfExpanded);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandableAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ BOOL* pfCanExpand;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandableAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ BOOL* pfCanExpand)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandableAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pfCanExpand);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemInfoAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ IVsLiteTreeList** pptl;
		/*[out]*/ ULONG* pIndex;
		/*[out]*/ ULONG* pLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetItemInfoAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ IVsLiteTreeList** pptl,
		/*[out]*/ ULONG* pIndex,
		/*[out]*/ ULONG* pLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemInfoAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE_INTERFACE(pptl);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_SET_VALIDVALUE(pLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct VisibleItemCountValidValues
	{
		/*[out]*/ ULONG* pCount;
		HRESULT retValue;
	};

	STDMETHOD(VisibleItemCount)(
		/*[out]*/ ULONG* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(VisibleItemCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Refresh)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Refresh)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescendantItemCountValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ ULONG* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetDescendantItemCount)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ ULONG* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescendantItemCount)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentIndexAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ ULONG* pParentIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetParentIndexAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ ULONG* pParentIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetParentIndexAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pParentIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandedListAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ ULONG* pLevel;
		/*[out]*/ IVsLiteTreeList** pptl;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandedListAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ ULONG* pLevel,
		/*[out]*/ IVsLiteTreeList** pptl)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandedListAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pLevel);

		VSL_SET_VALIDVALUE_INTERFACE(pptl);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleStateAbsoluteValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ VSTREESTATECHANGEREFRESH* ptscr;
		HRESULT retValue;
	};

	STDMETHOD(ToggleStateAbsolute)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ VSTREESTATECHANGEREFRESH* ptscr)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleStateAbsolute)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(ptscr);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseTreeEventsValidValues
	{
		/*[in]*/ IVsLiteTreeEvents* pEventSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseTreeEvents)(
		/*[in]*/ IVsLiteTreeEvents* pEventSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseTreeEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEventSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseTreeEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseTreeEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseTreeEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableTreeEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(EnableTreeEvents)(
		/*[in]*/ VSCOOKIE dwCookie,
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(EnableTreeEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumAbsoluteIndicesValidValues
	{
		/*[in]*/ IVsLiteTreeList* pList;
		/*[in]*/ ULONG Index;
		/*[in,out]*/ void** ppvNext;
		/*[out]*/ ULONG* pAbsIndex;
		HRESULT retValue;
	};

	STDMETHOD(EnumAbsoluteIndices)(
		/*[in]*/ IVsLiteTreeList* pList,
		/*[in]*/ ULONG Index,
		/*[in,out]*/ void** ppvNext,
		/*[out]*/ ULONG* pAbsIndex)
	{
		VSL_DEFINE_MOCK_METHOD(EnumAbsoluteIndices)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pList);

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(ppvNext);

		VSL_SET_VALIDVALUE(pAbsIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOffsetFromParentValidValues
	{
		/*[in]*/ ULONG ParentAbsIndex;
		/*[in]*/ ULONG RelIndex;
		/*[out]*/ ULONG* pOffset;
		HRESULT retValue;
	};

	STDMETHOD(GetOffsetFromParent)(
		/*[in]*/ ULONG ParentAbsIndex,
		/*[in]*/ ULONG RelIndex,
		/*[out]*/ ULONG* pOffset)
	{
		VSL_DEFINE_MOCK_METHOD(GetOffsetFromParent)

		VSL_CHECK_VALIDVALUE(ParentAbsIndex);

		VSL_CHECK_VALIDVALUE(RelIndex);

		VSL_SET_VALIDVALUE(pOffset);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumOrderedListItemsValidValues
	{
		/*[in,out]*/ ULONG* pNextStartIndex;
		/*[out]*/ IVsLiteTreeList** pptl;
		/*[out]*/ ULONG* pFirstRelIndex;
		/*[out]*/ ULONG* pLastRelIndex;
		/*[out]*/ ULONG* pLevel;
		HRESULT retValue;
	};

	STDMETHOD(EnumOrderedListItems)(
		/*[in,out]*/ ULONG* pNextStartIndex,
		/*[out]*/ IVsLiteTreeList** pptl,
		/*[out]*/ ULONG* pFirstRelIndex,
		/*[out]*/ ULONG* pLastRelIndex,
		/*[out]*/ ULONG* pLevel)
	{
		VSL_DEFINE_MOCK_METHOD(EnumOrderedListItems)

		VSL_SET_VALIDVALUE(pNextStartIndex);

		VSL_SET_VALIDVALUE_INTERFACE(pptl);

		VSL_SET_VALIDVALUE(pFirstRelIndex);

		VSL_SET_VALIDVALUE(pLastRelIndex);

		VSL_SET_VALIDVALUE(pLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRedrawValidValues
	{
		/*[in]*/ BOOL fOn;
		HRESULT retValue;
	};

	STDMETHOD(SetRedraw)(
		/*[in]*/ BOOL fOn)
	{
		VSL_DEFINE_MOCK_METHOD(SetRedraw)

		VSL_CHECK_VALIDVALUE(fOn);

		VSL_RETURN_VALIDVALUES();
	}
	struct DelayRedrawValidValues
	{
		/*[in]*/ BOOL fOn;
		HRESULT retValue;
	};

	STDMETHOD(DelayRedraw)(
		/*[in]*/ BOOL fOn)
	{
		VSL_DEFINE_MOCK_METHOD(DelayRedraw)

		VSL_CHECK_VALIDVALUE(fOn);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryItemVisibleValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(QueryItemVisible)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(QueryItemVisible)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitValidValues
	{
		/*[in]*/ VSLITETREEOPTS grfOpts;
		HRESULT retValue;
	};

	STDMETHOD(Init)(
		/*[in]*/ VSLITETREEOPTS grfOpts)
	{
		VSL_DEFINE_MOCK_METHOD(Init)

		VSL_CHECK_VALIDVALUE(grfOpts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInitFlagsValidValues
	{
		/*[out]*/ VSLITETREEOPTS* pgrfOpts;
		HRESULT retValue;
	};

	STDMETHOD(GetInitFlags)(
		/*[out]*/ VSLITETREEOPTS* pgrfOpts)
	{
		VSL_DEFINE_MOCK_METHOD(GetInitFlags)

		VSL_SET_VALIDVALUE(pgrfOpts);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLITETREE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
