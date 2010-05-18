/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERSISTDOCDATA2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERSISTDOCDATA2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPersistDocData2NotImpl :
	public IVsPersistDocData2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistDocData2NotImpl)

public:

	typedef IVsPersistDocData2 Interface;

	STDMETHOD(SetDocDataDirty)(
		/*[in]*/ BOOL /*fDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocDataReadOnly)(
		/*[out]*/ BOOL* /*pfReadOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDocDataReadOnly)(
		/*[in]*/ BOOL /*fReadOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuidEditorType)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocDataDirty)(
		/*[out]*/ BOOL* /*pfDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUntitledDocPath)(
		/*[in]*/ LPCOLESTR /*pszDocDataPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadDocData)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveDocData)(
		/*[in]*/ VSSAVEFLAGS /*dwSave*/,
		/*[out]*/ BSTR* /*pbstrMkDocumentNew*/,
		/*[out]*/ BOOL* /*pfSaveCanceled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRegisterDocData)(
		/*[in]*/ VSCOOKIE /*docCookie*/,
		/*[in]*/ IVsHierarchy* /*pHierNew*/,
		/*[in]*/ VSITEMID /*itemidNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameDocData)(
		/*[in]*/ VSRDTATTRIB /*grfAttribs*/,
		/*[in]*/ IVsHierarchy* /*pHierNew*/,
		/*[in]*/ VSITEMID /*itemidNew*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocDataReloadable)(
		/*[out]*/ BOOL* /*pfReloadable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReloadDocData)(
		/*[in]*/ VSRELOADDOCDATA /*grfFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPersistDocData2MockImpl :
	public IVsPersistDocData2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistDocData2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPersistDocData2MockImpl)

	typedef IVsPersistDocData2 Interface;
	struct SetDocDataDirtyValidValues
	{
		/*[in]*/ BOOL fDirty;
		HRESULT retValue;
	};

	STDMETHOD(SetDocDataDirty)(
		/*[in]*/ BOOL fDirty)
	{
		VSL_DEFINE_MOCK_METHOD(SetDocDataDirty)

		VSL_CHECK_VALIDVALUE(fDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocDataReadOnlyValidValues
	{
		/*[out]*/ BOOL* pfReadOnly;
		HRESULT retValue;
	};

	STDMETHOD(IsDocDataReadOnly)(
		/*[out]*/ BOOL* pfReadOnly)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocDataReadOnly)

		VSL_SET_VALIDVALUE(pfReadOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDocDataReadOnlyValidValues
	{
		/*[in]*/ BOOL fReadOnly;
		HRESULT retValue;
	};

	STDMETHOD(SetDocDataReadOnly)(
		/*[in]*/ BOOL fReadOnly)
	{
		VSL_DEFINE_MOCK_METHOD(SetDocDataReadOnly)

		VSL_CHECK_VALIDVALUE(fReadOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidEditorTypeValidValues
	{
		/*[out]*/ CLSID* pClassID;
		HRESULT retValue;
	};

	STDMETHOD(GetGuidEditorType)(
		/*[out]*/ CLSID* pClassID)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuidEditorType)

		VSL_SET_VALIDVALUE(pClassID);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocDataDirtyValidValues
	{
		/*[out]*/ BOOL* pfDirty;
		HRESULT retValue;
	};

	STDMETHOD(IsDocDataDirty)(
		/*[out]*/ BOOL* pfDirty)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocDataDirty)

		VSL_SET_VALIDVALUE(pfDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUntitledDocPathValidValues
	{
		/*[in]*/ LPCOLESTR pszDocDataPath;
		HRESULT retValue;
	};

	STDMETHOD(SetUntitledDocPath)(
		/*[in]*/ LPCOLESTR pszDocDataPath)
	{
		VSL_DEFINE_MOCK_METHOD(SetUntitledDocPath)

		VSL_CHECK_VALIDVALUE_STRINGW(pszDocDataPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadDocDataValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(LoadDocData)(
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(LoadDocData)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveDocDataValidValues
	{
		/*[in]*/ VSSAVEFLAGS dwSave;
		/*[out]*/ BSTR* pbstrMkDocumentNew;
		/*[out]*/ BOOL* pfSaveCanceled;
		HRESULT retValue;
	};

	STDMETHOD(SaveDocData)(
		/*[in]*/ VSSAVEFLAGS dwSave,
		/*[out]*/ BSTR* pbstrMkDocumentNew,
		/*[out]*/ BOOL* pfSaveCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(SaveDocData)

		VSL_CHECK_VALIDVALUE(dwSave);

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDocumentNew);

		VSL_SET_VALIDVALUE(pfSaveCanceled);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRegisterDocDataValidValues
	{
		/*[in]*/ VSCOOKIE docCookie;
		/*[in]*/ IVsHierarchy* pHierNew;
		/*[in]*/ VSITEMID itemidNew;
		HRESULT retValue;
	};

	STDMETHOD(OnRegisterDocData)(
		/*[in]*/ VSCOOKIE docCookie,
		/*[in]*/ IVsHierarchy* pHierNew,
		/*[in]*/ VSITEMID itemidNew)
	{
		VSL_DEFINE_MOCK_METHOD(OnRegisterDocData)

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierNew);

		VSL_CHECK_VALIDVALUE(itemidNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameDocDataValidValues
	{
		/*[in]*/ VSRDTATTRIB grfAttribs;
		/*[in]*/ IVsHierarchy* pHierNew;
		/*[in]*/ VSITEMID itemidNew;
		/*[in]*/ LPCOLESTR pszMkDocumentNew;
		HRESULT retValue;
	};

	STDMETHOD(RenameDocData)(
		/*[in]*/ VSRDTATTRIB grfAttribs,
		/*[in]*/ IVsHierarchy* pHierNew,
		/*[in]*/ VSITEMID itemidNew,
		/*[in]*/ LPCOLESTR pszMkDocumentNew)
	{
		VSL_DEFINE_MOCK_METHOD(RenameDocData)

		VSL_CHECK_VALIDVALUE(grfAttribs);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierNew);

		VSL_CHECK_VALIDVALUE(itemidNew);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocDataReloadableValidValues
	{
		/*[out]*/ BOOL* pfReloadable;
		HRESULT retValue;
	};

	STDMETHOD(IsDocDataReloadable)(
		/*[out]*/ BOOL* pfReloadable)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocDataReloadable)

		VSL_SET_VALIDVALUE(pfReloadable);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReloadDocDataValidValues
	{
		/*[in]*/ VSRELOADDOCDATA grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(ReloadDocData)(
		/*[in]*/ VSRELOADDOCDATA grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(ReloadDocData)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPERSISTDOCDATA2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
