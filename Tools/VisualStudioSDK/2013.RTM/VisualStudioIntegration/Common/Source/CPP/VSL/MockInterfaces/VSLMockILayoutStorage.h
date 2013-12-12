/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ILAYOUTSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ILAYOUTSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ILayoutStorageNotImpl :
	public ILayoutStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILayoutStorageNotImpl)

public:

	typedef ILayoutStorage Interface;

	STDMETHOD(LayoutScript)(
		/*[in]*/ StorageLayout* /*pStorageLayout*/,
		/*[in]*/ DWORD /*nEntries*/,
		/*[in]*/ DWORD /*glfInterleavedFlag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginMonitor)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndMonitor)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReLayoutDocfile)(
		/*[in]*/ OLECHAR* /*pwcsNewDfName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReLayoutDocfileOnILockBytes)(
		/*[in]*/ ILockBytes* /*pILockBytes*/)VSL_STDMETHOD_NOTIMPL
};

class ILayoutStorageMockImpl :
	public ILayoutStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILayoutStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ILayoutStorageMockImpl)

	typedef ILayoutStorage Interface;
	struct LayoutScriptValidValues
	{
		/*[in]*/ StorageLayout* pStorageLayout;
		/*[in]*/ DWORD nEntries;
		/*[in]*/ DWORD glfInterleavedFlag;
		HRESULT retValue;
	};

	STDMETHOD(LayoutScript)(
		/*[in]*/ StorageLayout* pStorageLayout,
		/*[in]*/ DWORD nEntries,
		/*[in]*/ DWORD glfInterleavedFlag)
	{
		VSL_DEFINE_MOCK_METHOD(LayoutScript)

		VSL_CHECK_VALIDVALUE_POINTER(pStorageLayout);

		VSL_CHECK_VALIDVALUE(nEntries);

		VSL_CHECK_VALIDVALUE(glfInterleavedFlag);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginMonitorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeginMonitor)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeginMonitor)

		VSL_RETURN_VALIDVALUES();
	}
	struct EndMonitorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EndMonitor)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EndMonitor)

		VSL_RETURN_VALIDVALUES();
	}
	struct ReLayoutDocfileValidValues
	{
		/*[in]*/ OLECHAR* pwcsNewDfName;
		HRESULT retValue;
	};

	STDMETHOD(ReLayoutDocfile)(
		/*[in]*/ OLECHAR* pwcsNewDfName)
	{
		VSL_DEFINE_MOCK_METHOD(ReLayoutDocfile)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcsNewDfName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReLayoutDocfileOnILockBytesValidValues
	{
		/*[in]*/ ILockBytes* pILockBytes;
		HRESULT retValue;
	};

	STDMETHOD(ReLayoutDocfileOnILockBytes)(
		/*[in]*/ ILockBytes* pILockBytes)
	{
		VSL_DEFINE_MOCK_METHOD(ReLayoutDocfileOnILockBytes)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pILockBytes);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ILAYOUTSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
