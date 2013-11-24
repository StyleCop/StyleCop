/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsObjectManagerNotImpl :
	public IVsObjectManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectManagerNotImpl)

public:

	typedef IVsObjectManager Interface;

	STDMETHOD(RegisterLibMgr)(
		/*[in]*/ REFGUID /*rguidLibMgr*/,
		/*[in]*/ IVsLibraryMgr* /*pLibMgr*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterLibMgr)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumLibMgrs)(
		/*[out]*/ ULONG* /*pCount*/,
		/*[out]*/ IVsLibraryMgr** /*rgpLibMgrs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshLists)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetList)(
		/*[in]*/ LIB_LISTTYPE /*ListType*/,
		/*[in]*/ LIB_LISTFLAGS /*Flags*/,
		/*[in]*/ IVsLibraryMgr* /*pLibMgr*/,
		/*[in]*/ VSOBSEARCHCRITERIA* /*pobSrch*/,
		/*[out]*/ IVsObjectList** /*ppList*/)VSL_STDMETHOD_NOTIMPL
};

class IVsObjectManagerMockImpl :
	public IVsObjectManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjectManagerMockImpl)

	typedef IVsObjectManager Interface;
	struct RegisterLibMgrValidValues
	{
		/*[in]*/ REFGUID rguidLibMgr;
		/*[in]*/ IVsLibraryMgr* pLibMgr;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterLibMgr)(
		/*[in]*/ REFGUID rguidLibMgr,
		/*[in]*/ IVsLibraryMgr* pLibMgr,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterLibMgr)

		VSL_CHECK_VALIDVALUE(rguidLibMgr);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLibMgr);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterLibMgrValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterLibMgr)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterLibMgr)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumLibMgrsValidValues
	{
		/*[out]*/ ULONG* pCount;
		/*[out]*/ IVsLibraryMgr** rgpLibMgrs;
		HRESULT retValue;
	};

	STDMETHOD(EnumLibMgrs)(
		/*[out]*/ ULONG* pCount,
		/*[out]*/ IVsLibraryMgr** rgpLibMgrs)
	{
		VSL_DEFINE_MOCK_METHOD(EnumLibMgrs)

		VSL_SET_VALIDVALUE(pCount);

		VSL_SET_VALIDVALUE_INTERFACE(rgpLibMgrs);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshListsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RefreshLists)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RefreshLists)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListValidValues
	{
		/*[in]*/ LIB_LISTTYPE ListType;
		/*[in]*/ LIB_LISTFLAGS Flags;
		/*[in]*/ IVsLibraryMgr* pLibMgr;
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch;
		/*[out]*/ IVsObjectList** ppList;
		HRESULT retValue;
	};

	STDMETHOD(GetList)(
		/*[in]*/ LIB_LISTTYPE ListType,
		/*[in]*/ LIB_LISTFLAGS Flags,
		/*[in]*/ IVsLibraryMgr* pLibMgr,
		/*[in]*/ VSOBSEARCHCRITERIA* pobSrch,
		/*[out]*/ IVsObjectList** ppList)
	{
		VSL_DEFINE_MOCK_METHOD(GetList)

		VSL_CHECK_VALIDVALUE(ListType);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLibMgr);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
