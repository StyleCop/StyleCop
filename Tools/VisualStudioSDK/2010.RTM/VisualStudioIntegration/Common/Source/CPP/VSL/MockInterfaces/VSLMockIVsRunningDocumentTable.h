/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSRUNNINGDOCUMENTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSRUNNINGDOCUMENTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRunningDocumentTableNotImpl :
	public IVsRunningDocumentTable
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocumentTableNotImpl)

public:

	typedef IVsRunningDocumentTable Interface;

	STDMETHOD(RegisterAndLockDocument)(
		/*[in]*/ VSRDTFLAGS /*grfRDTLockType*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockDocument)(
		/*[in]*/ VSRDTFLAGS /*grfRDTLockType*/,
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockDocument)(
		/*[in]*/ VSRDTFLAGS /*grfRDTLockType*/,
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindAndLockDocument)(
		/*[in]*/ VSRDTFLAGS /*dwRDTLockType*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IUnknown** /*ppunkDocData*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameDocument)(
		/*[in]*/ LPCOLESTR /*pszMkDocumentOld*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentNew*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemidNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseRunningDocTableEvents)(
		/*[in]*/ IVsRunningDocTableEvents* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseRunningDocTableEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentInfo)(
		/*[in]*/ VSCOOKIE /*docCookie*/,
		/*[out]*/ VSRDTFLAGS* /*pgrfRDTFlags*/,
		/*[out]*/ DWORD* /*pdwReadLocks*/,
		/*[out]*/ DWORD* /*pdwEditLocks*/,
		/*[out]*/ BSTR* /*pbstrMkDocument*/,
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IUnknown** /*ppunkDocData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyDocumentChanged)(
		/*[in]*/ VSCOOKIE /*dwCookie*/,
		/*[in]*/ VSRDTATTRIB /*grfDocChanged*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnAfterSave)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRunningDocumentsEnum)(
		/*[out]*/ IEnumRunningDocuments** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveDocuments)(
		/*[in]*/ VSRDTSAVEOPTIONS /*grfSaveOpts*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSCOOKIE /*docCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnBeforeSave)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterDocumentLockHolder)(
		/*[in]*/ VSREGDOCLOCKHOLDER /*grfRDLH*/,
		/*[in]*/ VSCOOKIE /*dwCookie*/,
		/*[in]*/ IVsDocumentLockHolder* /*pLockHolder*/,
		/*[out]*/ VSCOOKIE* /*pdwLHCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterDocumentLockHolder)(
		/*[in]*/ VSCOOKIE /*dwLHCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ModifyDocumentFlags)(
		/*[in]*/ VSCOOKIE /*docCookie*/,
		/*[in]*/ VSRDTFLAGS /*grfFlags*/,
		/*[in]*/ BOOL /*fSet*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRunningDocumentTableMockImpl :
	public IVsRunningDocumentTable,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRunningDocumentTableMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRunningDocumentTableMockImpl)

	typedef IVsRunningDocumentTable Interface;
	struct RegisterAndLockDocumentValidValues
	{
		/*[in]*/ VSRDTFLAGS grfRDTLockType;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocData;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterAndLockDocument)(
		/*[in]*/ VSRDTFLAGS grfRDTLockType,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocData,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterAndLockDocument)

		VSL_CHECK_VALIDVALUE(grfRDTLockType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockDocumentValidValues
	{
		/*[in]*/ VSRDTFLAGS grfRDTLockType;
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(LockDocument)(
		/*[in]*/ VSRDTFLAGS grfRDTLockType,
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(LockDocument)

		VSL_CHECK_VALIDVALUE(grfRDTLockType);

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockDocumentValidValues
	{
		/*[in]*/ VSRDTFLAGS grfRDTLockType;
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnlockDocument)(
		/*[in]*/ VSRDTFLAGS grfRDTLockType,
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnlockDocument)

		VSL_CHECK_VALIDVALUE(grfRDTLockType);

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindAndLockDocumentValidValues
	{
		/*[in]*/ VSRDTFLAGS dwRDTLockType;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IUnknown** ppunkDocData;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(FindAndLockDocument)(
		/*[in]*/ VSRDTFLAGS dwRDTLockType,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IUnknown** ppunkDocData,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(FindAndLockDocument)

		VSL_CHECK_VALIDVALUE(dwRDTLockType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocData);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameDocumentValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocumentOld;
		/*[in]*/ LPCOLESTR pszMkDocumentNew;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemidNew;
		HRESULT retValue;
	};

	STDMETHOD(RenameDocument)(
		/*[in]*/ LPCOLESTR pszMkDocumentOld,
		/*[in]*/ LPCOLESTR pszMkDocumentNew,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemidNew)
	{
		VSL_DEFINE_MOCK_METHOD(RenameDocument)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentOld);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentNew);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemidNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseRunningDocTableEventsValidValues
	{
		/*[in]*/ IVsRunningDocTableEvents* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseRunningDocTableEvents)(
		/*[in]*/ IVsRunningDocTableEvents* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseRunningDocTableEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseRunningDocTableEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseRunningDocTableEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseRunningDocTableEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentInfoValidValues
	{
		/*[in]*/ VSCOOKIE docCookie;
		/*[out]*/ VSRDTFLAGS* pgrfRDTFlags;
		/*[out]*/ DWORD* pdwReadLocks;
		/*[out]*/ DWORD* pdwEditLocks;
		/*[out]*/ BSTR* pbstrMkDocument;
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IUnknown** ppunkDocData;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentInfo)(
		/*[in]*/ VSCOOKIE docCookie,
		/*[out]*/ VSRDTFLAGS* pgrfRDTFlags,
		/*[out]*/ DWORD* pdwReadLocks,
		/*[out]*/ DWORD* pdwEditLocks,
		/*[out]*/ BSTR* pbstrMkDocument,
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IUnknown** ppunkDocData)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentInfo)

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_SET_VALIDVALUE(pgrfRDTFlags);

		VSL_SET_VALIDVALUE(pdwReadLocks);

		VSL_SET_VALIDVALUE(pdwEditLocks);

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDocument);

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocData);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyDocumentChangedValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		/*[in]*/ VSRDTATTRIB grfDocChanged;
		HRESULT retValue;
	};

	STDMETHOD(NotifyDocumentChanged)(
		/*[in]*/ VSCOOKIE dwCookie,
		/*[in]*/ VSRDTATTRIB grfDocChanged)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyDocumentChanged)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_CHECK_VALIDVALUE(grfDocChanged);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnAfterSaveValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnAfterSave)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnAfterSave)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRunningDocumentsEnumValidValues
	{
		/*[out]*/ IEnumRunningDocuments** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(GetRunningDocumentsEnum)(
		/*[out]*/ IEnumRunningDocuments** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(GetRunningDocumentsEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveDocumentsValidValues
	{
		/*[in]*/ VSRDTSAVEOPTIONS grfSaveOpts;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSCOOKIE docCookie;
		HRESULT retValue;
	};

	STDMETHOD(SaveDocuments)(
		/*[in]*/ VSRDTSAVEOPTIONS grfSaveOpts,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSCOOKIE docCookie)
	{
		VSL_DEFINE_MOCK_METHOD(SaveDocuments)

		VSL_CHECK_VALIDVALUE(grfSaveOpts);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnBeforeSaveValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnBeforeSave)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnBeforeSave)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterDocumentLockHolderValidValues
	{
		/*[in]*/ VSREGDOCLOCKHOLDER grfRDLH;
		/*[in]*/ VSCOOKIE dwCookie;
		/*[in]*/ IVsDocumentLockHolder* pLockHolder;
		/*[out]*/ VSCOOKIE* pdwLHCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterDocumentLockHolder)(
		/*[in]*/ VSREGDOCLOCKHOLDER grfRDLH,
		/*[in]*/ VSCOOKIE dwCookie,
		/*[in]*/ IVsDocumentLockHolder* pLockHolder,
		/*[out]*/ VSCOOKIE* pdwLHCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterDocumentLockHolder)

		VSL_CHECK_VALIDVALUE(grfRDLH);

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLockHolder);

		VSL_SET_VALIDVALUE(pdwLHCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterDocumentLockHolderValidValues
	{
		/*[in]*/ VSCOOKIE dwLHCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterDocumentLockHolder)(
		/*[in]*/ VSCOOKIE dwLHCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterDocumentLockHolder)

		VSL_CHECK_VALIDVALUE(dwLHCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct ModifyDocumentFlagsValidValues
	{
		/*[in]*/ VSCOOKIE docCookie;
		/*[in]*/ VSRDTFLAGS grfFlags;
		/*[in]*/ BOOL fSet;
		HRESULT retValue;
	};

	STDMETHOD(ModifyDocumentFlags)(
		/*[in]*/ VSCOOKIE docCookie,
		/*[in]*/ VSRDTFLAGS grfFlags,
		/*[in]*/ BOOL fSet)
	{
		VSL_DEFINE_MOCK_METHOD(ModifyDocumentFlags)

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE(fSet);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSRUNNINGDOCUMENTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
