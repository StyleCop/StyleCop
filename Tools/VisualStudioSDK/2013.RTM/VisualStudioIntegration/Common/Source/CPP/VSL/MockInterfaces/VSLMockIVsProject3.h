/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProject3NotImpl :
	public IVsProject3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProject3NotImpl)

public:

	typedef IVsProject3 Interface;

	STDMETHOD(AddItemWithSpecific)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ VSADDITEMOPERATION /*dwAddItemOperation*/,
		/*[in]*/ LPCOLESTR /*pszItemName*/,
		/*[in]*/ ULONG /*cFilesToOpen*/,
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR[] /*rgpszFilesToOpen*/,
		/*[in]*/ HWND /*hwndDlgOwner*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ VSADDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenItemWithSpecific)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TransferItem)(
		/*[in]*/ LPCOLESTR /*pszMkDocumentOld*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentNew*/,
		/*[in]*/ IVsWindowFrame* /*punkWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveItem)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out,retval]*/ BOOL* /*pfResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReopenItem)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[out,retval]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocumentInProject)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out]*/ BOOL* /*pfFound*/,
		/*[out]*/ VSDOCUMENTPRIORITY* /*pdwPriority*/,
		/*[out]*/ VSITEMID* /*pitemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMkDocument)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ BSTR* /*pbstrMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenItem)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemContext)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ IServiceProvider** /*ppSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GenerateUniqueItemName)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ LPCOLESTR /*pszExt*/,
		/*[in]*/ LPCOLESTR /*pszSuggestedRoot*/,
		/*[out]*/ BSTR* /*pbstrItemName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddItem)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ VSADDITEMOPERATION /*dwAddItemOperation*/,
		/*[in]*/ LPCOLESTR /*pszItemName*/,
		/*[in]*/ ULONG /*cFilesToOpen*/,
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR[] /*rgpszFilesToOpen*/,
		/*[in]*/ HWND /*hwndDlgOwner*/,
		/*[out,retval]*/ VSADDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProject3MockImpl :
	public IVsProject3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProject3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProject3MockImpl)

	typedef IVsProject3 Interface;
	struct AddItemWithSpecificValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation;
		/*[in]*/ LPCOLESTR pszItemName;
		/*[in]*/ ULONG cFilesToOpen;
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR* rgpszFilesToOpen;
		/*[in]*/ HWND hwndDlgOwner;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ VSADDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(AddItemWithSpecific)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation,
		/*[in]*/ LPCOLESTR pszItemName,
		/*[in]*/ ULONG cFilesToOpen,
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR rgpszFilesToOpen[],
		/*[in]*/ HWND hwndDlgOwner,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ VSADDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(AddItemWithSpecific)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(dwAddItemOperation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszItemName);

		VSL_CHECK_VALIDVALUE(cFilesToOpen);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFilesToOpen, cFilesToOpen*sizeof(rgpszFilesToOpen[0]), validValues.cFilesToOpen*sizeof(validValues.rgpszFilesToOpen[0]));

		VSL_CHECK_VALIDVALUE(hwndDlgOwner);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenItemWithSpecificValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenItemWithSpecific)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenItemWithSpecific)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct TransferItemValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocumentOld;
		/*[in]*/ LPCOLESTR pszMkDocumentNew;
		/*[in]*/ IVsWindowFrame* punkWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(TransferItem)(
		/*[in]*/ LPCOLESTR pszMkDocumentOld,
		/*[in]*/ LPCOLESTR pszMkDocumentNew,
		/*[in]*/ IVsWindowFrame* punkWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(TransferItem)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentOld);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentNew);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveItemValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ VSITEMID itemid;
		/*[out,retval]*/ BOOL* pfResult;
		HRESULT retValue;
	};

	STDMETHOD(RemoveItem)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ VSITEMID itemid,
		/*[out,retval]*/ BOOL* pfResult)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveItem)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pfResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReopenItemValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(ReopenItem)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[out,retval]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(ReopenItem)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocumentInProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out]*/ BOOL* pfFound;
		/*[out]*/ VSDOCUMENTPRIORITY* pdwPriority;
		/*[out]*/ VSITEMID* pitemid;
		HRESULT retValue;
	};

	STDMETHOD(IsDocumentInProject)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out]*/ BOOL* pfFound,
		/*[out]*/ VSDOCUMENTPRIORITY* pdwPriority,
		/*[out]*/ VSITEMID* pitemid)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocumentInProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE(pfFound);

		VSL_SET_VALIDVALUE(pdwPriority);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMkDocumentValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ BSTR* pbstrMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(GetMkDocument)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ BSTR* pbstrMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(GetMkDocument)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenItemValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(OpenItem)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(OpenItem)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemContextValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ IServiceProvider** ppSP;
		HRESULT retValue;
	};

	STDMETHOD(GetItemContext)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ IServiceProvider** ppSP)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemContext)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct GenerateUniqueItemNameValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ LPCOLESTR pszExt;
		/*[in]*/ LPCOLESTR pszSuggestedRoot;
		/*[out]*/ BSTR* pbstrItemName;
		HRESULT retValue;
	};

	STDMETHOD(GenerateUniqueItemName)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ LPCOLESTR pszExt,
		/*[in]*/ LPCOLESTR pszSuggestedRoot,
		/*[out]*/ BSTR* pbstrItemName)
	{
		VSL_DEFINE_MOCK_METHOD(GenerateUniqueItemName)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE_STRINGW(pszExt);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSuggestedRoot);

		VSL_SET_VALIDVALUE_BSTR(pbstrItemName);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddItemValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation;
		/*[in]*/ LPCOLESTR pszItemName;
		/*[in]*/ ULONG cFilesToOpen;
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR* rgpszFilesToOpen;
		/*[in]*/ HWND hwndDlgOwner;
		/*[out,retval]*/ VSADDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(AddItem)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation,
		/*[in]*/ LPCOLESTR pszItemName,
		/*[in]*/ ULONG cFilesToOpen,
		/*[in,size_is(cFilesToOpen)]*/ LPCOLESTR rgpszFilesToOpen[],
		/*[in]*/ HWND hwndDlgOwner,
		/*[out,retval]*/ VSADDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(AddItem)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(dwAddItemOperation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszItemName);

		VSL_CHECK_VALIDVALUE(cFilesToOpen);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFilesToOpen, cFilesToOpen*sizeof(rgpszFilesToOpen[0]), validValues.cFilesToOpen*sizeof(validValues.rgpszFilesToOpen[0]));

		VSL_CHECK_VALIDVALUE(hwndDlgOwner);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
