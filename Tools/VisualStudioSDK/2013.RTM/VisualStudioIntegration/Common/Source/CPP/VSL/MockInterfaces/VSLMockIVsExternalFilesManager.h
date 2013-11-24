/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXTERNALFILESMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXTERNALFILESMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsExternalFilesManagerNotImpl :
	public IVsExternalFilesManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExternalFilesManagerNotImpl)

public:

	typedef IVsExternalFilesManager Interface;

	STDMETHOD(GetExternalFilesProject)(
		/*[out]*/ IVsProject** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TransferDocument)(
		/*[in]*/ LPCOLESTR /*pszMkDocumentOld*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentNew*/,
		/*[in]*/ IVsWindowFrame* /*punkWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddDocument)(
		/*[in]*/ VSCREATEDOCWIN /*dwCDW*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IUnknown* /*punkDocView*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidCmdUI*/,
		/*[in]*/ LPCOLESTR /*pszOwnerCaption*/,
		/*[in]*/ LPCOLESTR /*pszEditorCaption*/,
		/*[out]*/ BOOL* /*pfDefaultPosition*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsVisible)(
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExternalFilesManagerMockImpl :
	public IVsExternalFilesManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExternalFilesManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExternalFilesManagerMockImpl)

	typedef IVsExternalFilesManager Interface;
	struct GetExternalFilesProjectValidValues
	{
		/*[out]*/ IVsProject** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(GetExternalFilesProject)(
		/*[out]*/ IVsProject** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(GetExternalFilesProject)

		VSL_SET_VALIDVALUE_INTERFACE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct TransferDocumentValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocumentOld;
		/*[in]*/ LPCOLESTR pszMkDocumentNew;
		/*[in]*/ IVsWindowFrame* punkWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(TransferDocument)(
		/*[in]*/ LPCOLESTR pszMkDocumentOld,
		/*[in]*/ LPCOLESTR pszMkDocumentNew,
		/*[in]*/ IVsWindowFrame* punkWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(TransferDocument)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentOld);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentNew);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddDocumentValidValues
	{
		/*[in]*/ VSCREATEDOCWIN dwCDW;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IUnknown* punkDocView;
		/*[in]*/ IUnknown* punkDocData;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidCmdUI;
		/*[in]*/ LPCOLESTR pszOwnerCaption;
		/*[in]*/ LPCOLESTR pszEditorCaption;
		/*[out]*/ BOOL* pfDefaultPosition;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(AddDocument)(
		/*[in]*/ VSCREATEDOCWIN dwCDW,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IUnknown* punkDocView,
		/*[in]*/ IUnknown* punkDocData,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidCmdUI,
		/*[in]*/ LPCOLESTR pszOwnerCaption,
		/*[in]*/ LPCOLESTR pszEditorCaption,
		/*[out]*/ BOOL* pfDefaultPosition,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(AddDocument)

		VSL_CHECK_VALIDVALUE(dwCDW);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidCmdUI);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOwnerCaption);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEditorCaption);

		VSL_SET_VALIDVALUE(pfDefaultPosition);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsVisibleValidValues
	{
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(IsVisible)(
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(IsVisible)

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXTERNALFILESMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
