/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEITEMCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEITEMCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleItemContainerNotImpl :
	public IOleItemContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleItemContainerNotImpl)

public:

	typedef IOleItemContainer Interface;

	STDMETHOD(GetObject)(
		/*[in]*/ LPOLESTR /*pszItem*/,
		/*[in]*/ DWORD /*dwSpeedNeeded*/,
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetObjectStorage)(
		/*[in]*/ LPOLESTR /*pszItem*/,
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvStorage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsRunning)(
		/*[in]*/ LPOLESTR /*pszItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumObjects)(
		/*[in]*/ DWORD /*grfFlags*/,
		/*[out]*/ IEnumUnknown** /*ppenum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockContainer)(
		/*[in]*/ BOOL /*fLock*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in]*/ LPOLESTR /*pszDisplayName*/,
		/*[out]*/ ULONG* /*pchEaten*/,
		/*[out]*/ IMoniker** /*ppmkOut*/)VSL_STDMETHOD_NOTIMPL
};

class IOleItemContainerMockImpl :
	public IOleItemContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleItemContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleItemContainerMockImpl)

	typedef IOleItemContainer Interface;
	struct GetObjectValidValues
	{
		/*[in]*/ LPOLESTR pszItem;
		/*[in]*/ DWORD dwSpeedNeeded;
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(GetObject)(
		/*[in]*/ LPOLESTR pszItem,
		/*[in]*/ DWORD dwSpeedNeeded,
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetObject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszItem);

		VSL_CHECK_VALIDVALUE(dwSpeedNeeded);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetObjectStorageValidValues
	{
		/*[in]*/ LPOLESTR pszItem;
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvStorage;
		HRESULT retValue;
	};

	STDMETHOD(GetObjectStorage)(
		/*[in]*/ LPOLESTR pszItem,
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvStorage)
	{
		VSL_DEFINE_MOCK_METHOD(GetObjectStorage)

		VSL_CHECK_VALIDVALUE_STRINGW(pszItem);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvStorage);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsRunningValidValues
	{
		/*[in]*/ LPOLESTR pszItem;
		HRESULT retValue;
	};

	STDMETHOD(IsRunning)(
		/*[in]*/ LPOLESTR pszItem)
	{
		VSL_DEFINE_MOCK_METHOD(IsRunning)

		VSL_CHECK_VALIDVALUE_STRINGW(pszItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumObjectsValidValues
	{
		/*[in]*/ DWORD grfFlags;
		/*[out]*/ IEnumUnknown** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumObjects)(
		/*[in]*/ DWORD grfFlags,
		/*[out]*/ IEnumUnknown** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumObjects)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockContainerValidValues
	{
		/*[in]*/ BOOL fLock;
		HRESULT retValue;
	};

	STDMETHOD(LockContainer)(
		/*[in]*/ BOOL fLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockContainer)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseDisplayNameValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in]*/ LPOLESTR pszDisplayName;
		/*[out]*/ ULONG* pchEaten;
		/*[out]*/ IMoniker** ppmkOut;
		HRESULT retValue;
	};

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in]*/ LPOLESTR pszDisplayName,
		/*[out]*/ ULONG* pchEaten,
		/*[out]*/ IMoniker** ppmkOut)
	{
		VSL_DEFINE_MOCK_METHOD(ParseDisplayName)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDisplayName);

		VSL_SET_VALIDVALUE(pchEaten);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEITEMCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
