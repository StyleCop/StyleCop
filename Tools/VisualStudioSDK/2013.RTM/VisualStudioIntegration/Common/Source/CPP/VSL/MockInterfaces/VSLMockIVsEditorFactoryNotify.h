/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEDITORFACTORYNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEDITORFACTORYNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsEditorFactoryNotifyNotImpl :
	public IVsEditorFactoryNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEditorFactoryNotifyNotImpl)

public:

	typedef IVsEditorFactoryNotify Interface;

	STDMETHOD(NotifyItemAdded)(
		/*[in]*/ EFNFLAGS /*grfEFN*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyItemRenamed)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentOld*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyDependentItemSaved)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemidParent*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentParent*/,
		/*[in]*/ VSITEMID /*itemidDpendent*/,
		/*[in]*/ LPCOLESTR /*pszMkDocumentDependent*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEditorFactoryNotifyMockImpl :
	public IVsEditorFactoryNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEditorFactoryNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEditorFactoryNotifyMockImpl)

	typedef IVsEditorFactoryNotify Interface;
	struct NotifyItemAddedValidValues
	{
		/*[in]*/ EFNFLAGS grfEFN;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(NotifyItemAdded)(
		/*[in]*/ EFNFLAGS grfEFN,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyItemAdded)

		VSL_CHECK_VALIDVALUE(grfEFN);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyItemRenamedValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ LPCOLESTR pszMkDocumentOld;
		/*[in]*/ LPCOLESTR pszMkDocumentNew;
		HRESULT retValue;
	};

	STDMETHOD(NotifyItemRenamed)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ LPCOLESTR pszMkDocumentOld,
		/*[in]*/ LPCOLESTR pszMkDocumentNew)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyItemRenamed)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentOld);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyDependentItemSavedValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemidParent;
		/*[in]*/ LPCOLESTR pszMkDocumentParent;
		/*[in]*/ VSITEMID itemidDpendent;
		/*[in]*/ LPCOLESTR pszMkDocumentDependent;
		HRESULT retValue;
	};

	STDMETHOD(NotifyDependentItemSaved)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemidParent,
		/*[in]*/ LPCOLESTR pszMkDocumentParent,
		/*[in]*/ VSITEMID itemidDpendent,
		/*[in]*/ LPCOLESTR pszMkDocumentDependent)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyDependentItemSaved)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemidParent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentParent);

		VSL_CHECK_VALIDVALUE(itemidDpendent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocumentDependent);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEDITORFACTORYNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
