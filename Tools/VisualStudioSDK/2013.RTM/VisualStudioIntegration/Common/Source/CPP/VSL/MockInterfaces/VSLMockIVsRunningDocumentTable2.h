/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSRUNNINGDOCUMENTTABLE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSRUNNINGDOCUMENTTABLE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRunningDocumentTable2NotImpl :
	public IVsRunningDocumentTable2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocumentTable2NotImpl)

public:

	typedef IVsRunningDocumentTable2 Interface;

	STDMETHOD(CloseDocuments)(
		/*[in]*/ FRAMECLOSE /*grfSaveOptions*/,
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSCOOKIE /*docCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryCloseRunningDocument)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out]*/ BOOL* /*pfFoundAndClosed*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindAndLockDocumentEx)(
		/*[in]*/ VSRDTFLAGS /*grfRDTLockType*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IVsHierarchy* /*pHierPreferred*/,
		/*[in]*/ VSITEMID /*itemidPreferred*/,
		/*[out]*/ IVsHierarchy** /*ppHierActual*/,
		/*[out]*/ VSITEMID* /*pitemidActual*/,
		/*[out]*/ IUnknown** /*ppunkDocDataActual*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindOrRegisterAndLockDocument)(
		/*[in]*/ VSRDTFLAGS /*grfRDTLockType*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IVsHierarchy* /*pHierPreferred*/,
		/*[in]*/ VSITEMID /*itemidPreferred*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[out]*/ IVsHierarchy** /*ppHierActual*/,
		/*[out]*/ VSITEMID* /*pitemidActual*/,
		/*[out]*/ IUnknown** /*ppunkDocDataActual*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRunningDocumentTable2MockImpl :
	public IVsRunningDocumentTable2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocumentTable2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRunningDocumentTable2MockImpl)

	typedef IVsRunningDocumentTable2 Interface;
	struct CloseDocumentsValidValues
	{
		/*[in]*/ FRAMECLOSE grfSaveOptions;
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSCOOKIE docCookie;
		HRESULT retValue;
	};

	STDMETHOD(CloseDocuments)(
		/*[in]*/ FRAMECLOSE grfSaveOptions,
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSCOOKIE docCookie)
	{
		VSL_DEFINE_MOCK_METHOD(CloseDocuments)

		VSL_CHECK_VALIDVALUE(grfSaveOptions);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCloseRunningDocumentValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out]*/ BOOL* pfFoundAndClosed;
		HRESULT retValue;
	};

	STDMETHOD(QueryCloseRunningDocument)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out]*/ BOOL* pfFoundAndClosed)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCloseRunningDocument)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE(pfFoundAndClosed);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindAndLockDocumentExValidValues
	{
		/*[in]*/ VSRDTFLAGS grfRDTLockType;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IVsHierarchy* pHierPreferred;
		/*[in]*/ VSITEMID itemidPreferred;
		/*[out]*/ IVsHierarchy** ppHierActual;
		/*[out]*/ VSITEMID* pitemidActual;
		/*[out]*/ IUnknown** ppunkDocDataActual;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(FindAndLockDocumentEx)(
		/*[in]*/ VSRDTFLAGS grfRDTLockType,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IVsHierarchy* pHierPreferred,
		/*[in]*/ VSITEMID itemidPreferred,
		/*[out]*/ IVsHierarchy** ppHierActual,
		/*[out]*/ VSITEMID* pitemidActual,
		/*[out]*/ IUnknown** ppunkDocDataActual,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(FindAndLockDocumentEx)

		VSL_CHECK_VALIDVALUE(grfRDTLockType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierPreferred);

		VSL_CHECK_VALIDVALUE(itemidPreferred);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierActual);

		VSL_SET_VALIDVALUE(pitemidActual);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocDataActual);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindOrRegisterAndLockDocumentValidValues
	{
		/*[in]*/ VSRDTFLAGS grfRDTLockType;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IVsHierarchy* pHierPreferred;
		/*[in]*/ VSITEMID itemidPreferred;
		/*[in]*/ IUnknown* punkDocData;
		/*[out]*/ IVsHierarchy** ppHierActual;
		/*[out]*/ VSITEMID* pitemidActual;
		/*[out]*/ IUnknown** ppunkDocDataActual;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(FindOrRegisterAndLockDocument)(
		/*[in]*/ VSRDTFLAGS grfRDTLockType,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IVsHierarchy* pHierPreferred,
		/*[in]*/ VSITEMID itemidPreferred,
		/*[in]*/ IUnknown* punkDocData,
		/*[out]*/ IVsHierarchy** ppHierActual,
		/*[out]*/ VSITEMID* pitemidActual,
		/*[out]*/ IUnknown** ppunkDocDataActual,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(FindOrRegisterAndLockDocument)

		VSL_CHECK_VALIDVALUE(grfRDTLockType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierPreferred);

		VSL_CHECK_VALIDVALUE(itemidPreferred);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_SET_VALIDVALUE_INTERFACE(ppHierActual);

		VSL_SET_VALIDVALUE(pitemidActual);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocDataActual);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSRUNNINGDOCUMENTTABLE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
