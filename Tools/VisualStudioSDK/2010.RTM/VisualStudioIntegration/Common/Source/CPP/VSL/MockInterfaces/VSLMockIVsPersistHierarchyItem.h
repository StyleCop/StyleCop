/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERSISTHIERARCHYITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERSISTHIERARCHYITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPersistHierarchyItemNotImpl :
	public IVsPersistHierarchyItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistHierarchyItemNotImpl)

public:

	typedef IVsPersistHierarchyItem Interface;

	STDMETHOD(IsItemDirty)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[out]*/ BOOL* /*pfDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveItem)(
		/*[in]*/ VSSAVEFLAGS /*dwSave*/,
		/*[in]*/ LPCOLESTR /*pszSilentSaveAsName*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[out]*/ BOOL* /*pfCanceled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPersistHierarchyItemMockImpl :
	public IVsPersistHierarchyItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistHierarchyItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPersistHierarchyItemMockImpl)

	typedef IVsPersistHierarchyItem Interface;
	struct IsItemDirtyValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocData;
		/*[out]*/ BOOL* pfDirty;
		HRESULT retValue;
	};

	STDMETHOD(IsItemDirty)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocData,
		/*[out]*/ BOOL* pfDirty)
	{
		VSL_DEFINE_MOCK_METHOD(IsItemDirty)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_SET_VALIDVALUE(pfDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveItemValidValues
	{
		/*[in]*/ VSSAVEFLAGS dwSave;
		/*[in]*/ LPCOLESTR pszSilentSaveAsName;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocData;
		/*[out]*/ BOOL* pfCanceled;
		HRESULT retValue;
	};

	STDMETHOD(SaveItem)(
		/*[in]*/ VSSAVEFLAGS dwSave,
		/*[in]*/ LPCOLESTR pszSilentSaveAsName,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocData,
		/*[out]*/ BOOL* pfCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(SaveItem)

		VSL_CHECK_VALIDVALUE(dwSave);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSilentSaveAsName);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_SET_VALIDVALUE(pfCanceled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPERSISTHIERARCHYITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
