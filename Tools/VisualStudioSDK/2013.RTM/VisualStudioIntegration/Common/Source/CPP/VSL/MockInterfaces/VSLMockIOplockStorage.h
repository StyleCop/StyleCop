/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOPLOCKSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOPLOCKSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOplockStorageNotImpl :
	public IOplockStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOplockStorageNotImpl)

public:

	typedef IOplockStorage Interface;

	STDMETHOD(CreateStorageEx)(
		/*[in]*/ LPCWSTR /*pwcsName*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in]*/ DWORD /*stgfmt*/,
		/*[in]*/ DWORD /*grfAttrs*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppstgOpen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenStorageEx)(
		/*[in]*/ LPCWSTR /*pwcsName*/,
		/*[in]*/ DWORD /*grfMode*/,
		/*[in]*/ DWORD /*stgfmt*/,
		/*[in]*/ DWORD /*grfAttrs*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppstgOpen*/)VSL_STDMETHOD_NOTIMPL
};

class IOplockStorageMockImpl :
	public IOplockStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOplockStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOplockStorageMockImpl)

	typedef IOplockStorage Interface;
	struct CreateStorageExValidValues
	{
		/*[in]*/ LPCWSTR pwcsName;
		/*[in]*/ DWORD grfMode;
		/*[in]*/ DWORD stgfmt;
		/*[in]*/ DWORD grfAttrs;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppstgOpen;
		HRESULT retValue;
	};

	STDMETHOD(CreateStorageEx)(
		/*[in]*/ LPCWSTR pwcsName,
		/*[in]*/ DWORD grfMode,
		/*[in]*/ DWORD stgfmt,
		/*[in]*/ DWORD grfAttrs,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppstgOpen)
	{
		VSL_DEFINE_MOCK_METHOD(CreateStorageEx)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(stgfmt);

		VSL_CHECK_VALIDVALUE(grfAttrs);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppstgOpen);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenStorageExValidValues
	{
		/*[in]*/ LPCWSTR pwcsName;
		/*[in]*/ DWORD grfMode;
		/*[in]*/ DWORD stgfmt;
		/*[in]*/ DWORD grfAttrs;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppstgOpen;
		HRESULT retValue;
	};

	STDMETHOD(OpenStorageEx)(
		/*[in]*/ LPCWSTR pwcsName,
		/*[in]*/ DWORD grfMode,
		/*[in]*/ DWORD stgfmt,
		/*[in]*/ DWORD grfAttrs,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppstgOpen)
	{
		VSL_DEFINE_MOCK_METHOD(OpenStorageEx)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsName);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_CHECK_VALIDVALUE(stgfmt);

		VSL_CHECK_VALIDVALUE(grfAttrs);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppstgOpen);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOPLOCKSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
