/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERSISTHIERARCHYITEM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERSISTHIERARCHYITEM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPersistHierarchyItem2NotImpl :
	public IVsPersistHierarchyItem2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistHierarchyItem2NotImpl)

public:

	typedef IVsPersistHierarchyItem2 Interface;

	STDMETHOD(IsItemReloadable)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out,retval]*/ BOOL* /*pfReloadable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReloadItem)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IgnoreItemFileChanges)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ BOOL /*fIgnore*/)VSL_STDMETHOD_NOTIMPL

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

class IVsPersistHierarchyItem2MockImpl :
	public IVsPersistHierarchyItem2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistHierarchyItem2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPersistHierarchyItem2MockImpl)

	typedef IVsPersistHierarchyItem2 Interface;
	struct IsItemReloadableValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out,retval]*/ BOOL* pfReloadable;
		HRESULT retValue;
	};

	STDMETHOD(IsItemReloadable)(
		/*[in]*/ VSITEMID itemid,
		/*[out,retval]*/ BOOL* pfReloadable)
	{
		VSL_DEFINE_MOCK_METHOD(IsItemReloadable)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pfReloadable);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReloadItemValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(ReloadItem)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(ReloadItem)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct IgnoreItemFileChangesValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ BOOL fIgnore;
		HRESULT retValue;
	};

	STDMETHOD(IgnoreItemFileChanges)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ BOOL fIgnore)
	{
		VSL_DEFINE_MOCK_METHOD(IgnoreItemFileChanges)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(fIgnore);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // IVSPERSISTHIERARCHYITEM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
