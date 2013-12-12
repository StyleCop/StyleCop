/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ILOCALREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ILOCALREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ILocalRegistryNotImpl :
	public ILocalRegistry
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILocalRegistryNotImpl)

public:

	typedef ILocalRegistry Interface;

	STDMETHOD(CreateInstance)(
		/*[in]*/ CLSID /*clsid*/,
		/*[in]*/ IUnknown* /*punkOuter*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ void** /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeLibOfClsid)(
		/*[in]*/ CLSID /*clsid*/,
		/*[out]*/ ITypeLib** /*pptlib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassObjectOfClsid)(
		/*[in]*/ REFCLSID /*clsid*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPVOID /*lpReserved*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ void** /*ppvClassObject*/)VSL_STDMETHOD_NOTIMPL
};

class ILocalRegistryMockImpl :
	public ILocalRegistry,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILocalRegistryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ILocalRegistryMockImpl)

	typedef ILocalRegistry Interface;
	struct CreateInstanceValidValues
	{
		/*[in]*/ CLSID clsid;
		/*[in]*/ IUnknown* punkOuter;
		/*[in]*/ REFIID riid;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ void** ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstance)(
		/*[in]*/ CLSID clsid,
		/*[in]*/ IUnknown* punkOuter,
		/*[in]*/ REFIID riid,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstance)

		VSL_CHECK_VALIDVALUE(clsid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkOuter);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeLibOfClsidValidValues
	{
		/*[in]*/ CLSID clsid;
		/*[out]*/ ITypeLib** pptlib;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeLibOfClsid)(
		/*[in]*/ CLSID clsid,
		/*[out]*/ ITypeLib** pptlib)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeLibOfClsid)

		VSL_CHECK_VALIDVALUE(clsid);

		VSL_SET_VALIDVALUE_INTERFACE(pptlib);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassObjectOfClsidValidValues
	{
		/*[in]*/ REFCLSID clsid;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPVOID lpReserved;
		/*[in]*/ REFIID riid;
		/*[in]*/ void** ppvClassObject;
		HRESULT retValue;
		size_t lpReserved_size_in_bytes;
	};

	STDMETHOD(GetClassObjectOfClsid)(
		/*[in]*/ REFCLSID clsid,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPVOID lpReserved,
		/*[in]*/ REFIID riid,
		/*[in]*/ void** ppvClassObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassObjectOfClsid)

		VSL_CHECK_VALIDVALUE(clsid);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_PVOID(lpReserved);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_POINTER(ppvClassObject);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ILOCALREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
