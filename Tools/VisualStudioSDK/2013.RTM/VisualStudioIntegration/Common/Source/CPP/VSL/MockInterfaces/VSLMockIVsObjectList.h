/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJECTLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJECTLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsObjectListNotImpl :
	public IVsObjectList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectListNotImpl)

public:

	typedef IVsObjectList Interface;

	STDMETHOD(GetCapabilities)(
		/*[out]*/ LIB_LISTCAPABILITIES* /*pCapabilities*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetList)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ LIB_LISTTYPE /*ListType*/,
		/*[in]*/ LIB_LISTFLAGS /*Flags*/,
		/*[in]*/ VSOBSEARCHCRITERIA* /*pobSrch*/,
		/*[out]*/ IVsObjectList** /*ppList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategoryField)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ LIB_CATEGORY /*Category*/,
		/*[out,retval]*/ DWORD* /*pField*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpandable2)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ LIB_LISTTYPE /*ListTypeExcluded*/,
		/*[out]*/ BOOL* /*pfExpandable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNavigationInfo)(
		/*[in]*/ ULONG /*Index*/,
		/*[in,out]*/ VSOBNAVIGATIONINFO2* /*pobNav*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LocateNavigationInfo)(
		/*[in]*/ VSOBNAVIGATIONINFO2* /*pobNav*/,
		/*[in]*/ VSOBNAVNAMEINFONODE* /*pobName*/,
		/*[in]*/ BOOL /*fDontUpdate*/,
		/*[out]*/ BOOL* /*pfMatchedName*/,
		/*[out]*/ ULONG* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBrowseObject)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ IDispatch** /*ppdispBrowseObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserContext)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ IUnknown** /*ppunkUserCtx*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowHelp)(
		/*[in]*/ ULONG /*Index*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSourceContext)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ const WCHAR** /*pszFileName*/,
		/*[out]*/ ULONG* /*pulLineNum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountSourceItems)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out,retval]*/ ULONG* /*pcItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMultipleSourceItems)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSGSIFLAGS /*grfGSI*/,
		/*[in]*/ ULONG /*cItems*/,
		/*[out,size_is(cItems)]*/ VSITEMSELECTION[] /*rgItemSel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanGoToSource)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJGOTOSRCTYPE /*SrcType*/,
		/*[out]*/ BOOL* /*pfOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GoToSource)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJGOTOSRCTYPE /*SrcType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextMenu)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ CLSID* /*pclsidActive*/,
		/*[out]*/ LONG* /*pnMenuId*/,
		/*[out]*/ IOleCommandTarget** /*ppCmdTrgtActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryDragDrop)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*grfKeyState*/,
		/*[in,out]*/ DWORD* /*pdwEffect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoDragDrop)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*grfKeyState*/,
		/*[in,out]*/ DWORD* /*pdwEffect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanRename)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ LPCOLESTR /*pszNewName*/,
		/*[out]*/ BOOL* /*pfOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoRename)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ LPCOLESTR /*pszNewName*/,
		/*[in]*/ VSOBJOPFLAGS /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanDelete)(
		/*[in]*/ ULONG /*Index*/,
		/*[out]*/ BOOL* /*pfOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoDelete)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJOPFLAGS /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FillDescription)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJDESCOPTIONS /*grfOptions*/,
		/*[in]*/ IVsObjectBrowserDescription2* /*pobDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumClipboardFormats)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJCFFLAGS /*grfFlags*/,
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ VSOBJCLIPFORMAT[] /*rgcfFormats*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClipboardFormat)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJCFFLAGS /*grfFlags*/,
		/*[in]*/ FORMATETC* /*pFormatetc*/,
		/*[in]*/ STGMEDIUM* /*pMedium*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtendedClipboardVariant)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSOBJCFFLAGS /*grfFlags*/,
		/*[in]*/ const VSOBJCLIPFORMAT* /*pcfFormat*/,
		/*[out]*/ VARIANT* /*pvarFormat*/)VSL_STDMETHOD_NOTIMPL

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
		/*[out]*/ const WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipText)(
		/*[in]*/ ULONG /*Index*/,
		/*[in]*/ VSTREETOOLTIPTYPE /*eTipType*/,
		/*[out]*/ const WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

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
};

class IVsObjectListMockImpl :
	public IVsObjectList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjectListMockImpl)

	typedef IVsObjectList Interface;
	struct GetCapabilitiesValidValues
	{
		/*[out]*/ LIB_LISTCAPABILITIES* pCapabilities;
		HRESULT retValue;
	};

	STDMETHOD(GetCapabilities)(
		/*[out]*/ LIB_LISTCAPABILITIES* pCapabilities)
	{
		VSL_DEFINE_MOCK_METHOD(GetCapabilities)

		VSL_SET_VALIDVALUE(pCapabilities);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ LIB_LISTTYPE ListType;
		/*[in]*/ LIB_LISTFLAGS Flags;
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch;
		/*[out]*/ IVsObjectList** ppList;
		HRESULT retValue;
	};

	STDMETHOD(GetList)(
		/*[in]*/ ULONG Index,
		/*[in]*/ LIB_LISTTYPE ListType,
		/*[in]*/ LIB_LISTFLAGS Flags,
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch,
		/*[out]*/ IVsObjectList** ppList)
	{
		VSL_DEFINE_MOCK_METHOD(GetList)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(ListType);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryFieldValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ LIB_CATEGORY Category;
		/*[out,retval]*/ DWORD* pField;
		HRESULT retValue;
	};

	STDMETHOD(GetCategoryField)(
		/*[in]*/ ULONG Index,
		/*[in]*/ LIB_CATEGORY Category,
		/*[out,retval]*/ DWORD* pField)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategoryField)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(Category);

		VSL_SET_VALIDVALUE(pField);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpandable2ValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ LIB_LISTTYPE ListTypeExcluded;
		/*[out]*/ BOOL* pfExpandable;
		HRESULT retValue;
	};

	STDMETHOD(GetExpandable2)(
		/*[in]*/ ULONG Index,
		/*[in]*/ LIB_LISTTYPE ListTypeExcluded,
		/*[out]*/ BOOL* pfExpandable)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpandable2)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(ListTypeExcluded);

		VSL_SET_VALIDVALUE(pfExpandable);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNavigationInfoValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in,out]*/ VSOBNAVIGATIONINFO2* pobNav;
		HRESULT retValue;
	};

	STDMETHOD(GetNavigationInfo)(
		/*[in]*/ ULONG Index,
		/*[in,out]*/ VSOBNAVIGATIONINFO2* pobNav)
	{
		VSL_DEFINE_MOCK_METHOD(GetNavigationInfo)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pobNav);

		VSL_RETURN_VALIDVALUES();
	}
	struct LocateNavigationInfoValidValues
	{
		/*[in]*/ VSOBNAVIGATIONINFO2* pobNav;
		/*[in]*/ VSOBNAVNAMEINFONODE* pobName;
		/*[in]*/ BOOL fDontUpdate;
		/*[out]*/ BOOL* pfMatchedName;
		/*[out]*/ ULONG* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(LocateNavigationInfo)(
		/*[in]*/ VSOBNAVIGATIONINFO2* pobNav,
		/*[in]*/ VSOBNAVNAMEINFONODE* pobName,
		/*[in]*/ BOOL fDontUpdate,
		/*[out]*/ BOOL* pfMatchedName,
		/*[out]*/ ULONG* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(LocateNavigationInfo)

		VSL_CHECK_VALIDVALUE_POINTER(pobNav);

		VSL_CHECK_VALIDVALUE_POINTER(pobName);

		VSL_CHECK_VALIDVALUE(fDontUpdate);

		VSL_SET_VALIDVALUE(pfMatchedName);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBrowseObjectValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ IDispatch** ppdispBrowseObj;
		HRESULT retValue;
	};

	STDMETHOD(GetBrowseObject)(
		/*[in]*/ ULONG Index,
		/*[out]*/ IDispatch** ppdispBrowseObj)
	{
		VSL_DEFINE_MOCK_METHOD(GetBrowseObject)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE_INTERFACE(ppdispBrowseObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserContextValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ IUnknown** ppunkUserCtx;
		HRESULT retValue;
	};

	STDMETHOD(GetUserContext)(
		/*[in]*/ ULONG Index,
		/*[out]*/ IUnknown** ppunkUserCtx)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserContext)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkUserCtx);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowHelpValidValues
	{
		/*[in]*/ ULONG Index;
		HRESULT retValue;
	};

	STDMETHOD(ShowHelp)(
		/*[in]*/ ULONG Index)
	{
		VSL_DEFINE_MOCK_METHOD(ShowHelp)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSourceContextValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ WCHAR** pszFileName;
		/*[out]*/ ULONG* pulLineNum;
		HRESULT retValue;
	};

	STDMETHOD(GetSourceContext)(
		/*[in]*/ ULONG Index,
		/*[out]*/ const WCHAR** pszFileName,
		/*[out]*/ ULONG* pulLineNum)
	{
		VSL_DEFINE_MOCK_METHOD(GetSourceContext)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE_CONST(pszFileName, WCHAR**);

		VSL_SET_VALIDVALUE(pulLineNum);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountSourceItemsValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out,retval]*/ ULONG* pcItems;
		HRESULT retValue;
	};

	STDMETHOD(CountSourceItems)(
		/*[in]*/ ULONG Index,
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out,retval]*/ ULONG* pcItems)
	{
		VSL_DEFINE_MOCK_METHOD(CountSourceItems)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE(pcItems);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMultipleSourceItemsValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSGSIFLAGS grfGSI;
		/*[in]*/ ULONG cItems;
		/*[out,size_is(cItems)]*/ VSITEMSELECTION* rgItemSel;
		HRESULT retValue;
	};

	STDMETHOD(GetMultipleSourceItems)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSGSIFLAGS grfGSI,
		/*[in]*/ ULONG cItems,
		/*[out,size_is(cItems)]*/ VSITEMSELECTION rgItemSel[])
	{
		VSL_DEFINE_MOCK_METHOD(GetMultipleSourceItems)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfGSI);

		VSL_CHECK_VALIDVALUE(cItems);

		VSL_SET_VALIDVALUE_MEMCPY(rgItemSel, cItems*sizeof(rgItemSel[0]), validValues.cItems*sizeof(validValues.rgItemSel[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct CanGoToSourceValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJGOTOSRCTYPE SrcType;
		/*[out]*/ BOOL* pfOK;
		HRESULT retValue;
	};

	STDMETHOD(CanGoToSource)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJGOTOSRCTYPE SrcType,
		/*[out]*/ BOOL* pfOK)
	{
		VSL_DEFINE_MOCK_METHOD(CanGoToSource)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(SrcType);

		VSL_SET_VALIDVALUE(pfOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct GoToSourceValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJGOTOSRCTYPE SrcType;
		HRESULT retValue;
	};

	STDMETHOD(GoToSource)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJGOTOSRCTYPE SrcType)
	{
		VSL_DEFINE_MOCK_METHOD(GoToSource)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(SrcType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextMenuValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ CLSID* pclsidActive;
		/*[out]*/ LONG* pnMenuId;
		/*[out]*/ IOleCommandTarget** ppCmdTrgtActive;
		HRESULT retValue;
	};

	STDMETHOD(GetContextMenu)(
		/*[in]*/ ULONG Index,
		/*[out]*/ CLSID* pclsidActive,
		/*[out]*/ LONG* pnMenuId,
		/*[out]*/ IOleCommandTarget** ppCmdTrgtActive)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextMenu)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pclsidActive);

		VSL_SET_VALIDVALUE(pnMenuId);

		VSL_SET_VALIDVALUE_INTERFACE(ppCmdTrgtActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryDragDropValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD grfKeyState;
		/*[in,out]*/ DWORD* pdwEffect;
		HRESULT retValue;
	};

	STDMETHOD(QueryDragDrop)(
		/*[in]*/ ULONG Index,
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD grfKeyState,
		/*[in,out]*/ DWORD* pdwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDragDrop)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_SET_VALIDVALUE(pdwEffect);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoDragDropValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD grfKeyState;
		/*[in,out]*/ DWORD* pdwEffect;
		HRESULT retValue;
	};

	STDMETHOD(DoDragDrop)(
		/*[in]*/ ULONG Index,
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD grfKeyState,
		/*[in,out]*/ DWORD* pdwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(DoDragDrop)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_SET_VALIDVALUE(pdwEffect);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanRenameValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ LPCOLESTR pszNewName;
		/*[out]*/ BOOL* pfOK;
		HRESULT retValue;
	};

	STDMETHOD(CanRename)(
		/*[in]*/ ULONG Index,
		/*[in]*/ LPCOLESTR pszNewName,
		/*[out]*/ BOOL* pfOK)
	{
		VSL_DEFINE_MOCK_METHOD(CanRename)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNewName);

		VSL_SET_VALIDVALUE(pfOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoRenameValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ LPCOLESTR pszNewName;
		/*[in]*/ VSOBJOPFLAGS grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(DoRename)(
		/*[in]*/ ULONG Index,
		/*[in]*/ LPCOLESTR pszNewName,
		/*[in]*/ VSOBJOPFLAGS grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(DoRename)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNewName);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanDeleteValidValues
	{
		/*[in]*/ ULONG Index;
		/*[out]*/ BOOL* pfOK;
		HRESULT retValue;
	};

	STDMETHOD(CanDelete)(
		/*[in]*/ ULONG Index,
		/*[out]*/ BOOL* pfOK)
	{
		VSL_DEFINE_MOCK_METHOD(CanDelete)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_SET_VALIDVALUE(pfOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoDeleteValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJOPFLAGS grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(DoDelete)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJOPFLAGS grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(DoDelete)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct FillDescriptionValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJDESCOPTIONS grfOptions;
		/*[in]*/ IVsObjectBrowserDescription2* pobDesc;
		HRESULT retValue;
	};

	STDMETHOD(FillDescription)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJDESCOPTIONS grfOptions,
		/*[in]*/ IVsObjectBrowserDescription2* pobDesc)
	{
		VSL_DEFINE_MOCK_METHOD(FillDescription)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pobDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumClipboardFormatsValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJCFFLAGS grfFlags;
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ VSOBJCLIPFORMAT* rgcfFormats;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(EnumClipboardFormats)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJCFFLAGS grfFlags,
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ VSOBJCLIPFORMAT rgcfFormats[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(EnumClipboardFormats)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgcfFormats, celt*sizeof(rgcfFormats[0]), validValues.celt*sizeof(validValues.rgcfFormats[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClipboardFormatValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJCFFLAGS grfFlags;
		/*[in]*/ FORMATETC* pFormatetc;
		/*[in]*/ STGMEDIUM* pMedium;
		HRESULT retValue;
	};

	STDMETHOD(GetClipboardFormat)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJCFFLAGS grfFlags,
		/*[in]*/ FORMATETC* pFormatetc,
		/*[in]*/ STGMEDIUM* pMedium)
	{
		VSL_DEFINE_MOCK_METHOD(GetClipboardFormat)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_POINTER(pFormatetc);

		VSL_CHECK_VALIDVALUE_POINTER(pMedium);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtendedClipboardVariantValidValues
	{
		/*[in]*/ ULONG Index;
		/*[in]*/ VSOBJCFFLAGS grfFlags;
		/*[in]*/ VSOBJCLIPFORMAT* pcfFormat;
		/*[out]*/ VARIANT* pvarFormat;
		HRESULT retValue;
	};

	STDMETHOD(GetExtendedClipboardVariant)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSOBJCFFLAGS grfFlags,
		/*[in]*/ const VSOBJCLIPFORMAT* pcfFormat,
		/*[out]*/ VARIANT* pvarFormat)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtendedClipboardVariant)

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_POINTER(pcfFormat);

		VSL_SET_VALIDVALUE_VARIANT(pvarFormat);

		VSL_RETURN_VALIDVALUES();
	}
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
		/*[out]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETEXTOPTIONS tto,
		/*[out]*/ const WCHAR** ppszText)
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
		/*[out]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipText)(
		/*[in]*/ ULONG Index,
		/*[in]*/ VSTREETOOLTIPTYPE eTipType,
		/*[out]*/ const WCHAR** ppszText)
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
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJECTLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
