/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ILOCALREGISTRY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ILOCALREGISTRY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ILocalRegistry3NotImpl :
	public ILocalRegistry3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILocalRegistry3NotImpl)

public:

	typedef ILocalRegistry3 Interface;

	STDMETHOD(CreateManagedInstance)(
		/*[in]*/ LPCWSTR /*codeBase*/,
		/*[in]*/ LPCWSTR /*assemblyName*/,
		/*[in]*/ LPCWSTR /*typeName*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ void** /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassObjectOfManagedClass)(
		/*[in]*/ LPCWSTR /*codeBase*/,
		/*[in]*/ LPCWSTR /*assemblyName*/,
		/*[in]*/ LPCWSTR /*typeName*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ void** /*ppvClassObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLocalRegistryRoot)(
		/*[out]*/ BSTR* /*pbstrRoot*/)VSL_STDMETHOD_NOTIMPL

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

class ILocalRegistry3MockImpl :
	public ILocalRegistry3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILocalRegistry3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ILocalRegistry3MockImpl)

	typedef ILocalRegistry3 Interface;
	struct CreateManagedInstanceValidValues
	{
		/*[in]*/ LPCWSTR codeBase;
		/*[in]*/ LPCWSTR assemblyName;
		/*[in]*/ LPCWSTR typeName;
		/*[in]*/ REFIID riid;
		/*[out]*/ void** ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(CreateManagedInstance)(
		/*[in]*/ LPCWSTR codeBase,
		/*[in]*/ LPCWSTR assemblyName,
		/*[in]*/ LPCWSTR typeName,
		/*[in]*/ REFIID riid,
		/*[out]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(CreateManagedInstance)

		VSL_CHECK_VALIDVALUE_STRINGW(codeBase);

		VSL_CHECK_VALIDVALUE_STRINGW(assemblyName);

		VSL_CHECK_VALIDVALUE_STRINGW(typeName);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassObjectOfManagedClassValidValues
	{
		/*[in]*/ LPCWSTR codeBase;
		/*[in]*/ LPCWSTR assemblyName;
		/*[in]*/ LPCWSTR typeName;
		/*[in]*/ REFIID riid;
		/*[out]*/ void** ppvClassObject;
		HRESULT retValue;
	};

	STDMETHOD(GetClassObjectOfManagedClass)(
		/*[in]*/ LPCWSTR codeBase,
		/*[in]*/ LPCWSTR assemblyName,
		/*[in]*/ LPCWSTR typeName,
		/*[in]*/ REFIID riid,
		/*[out]*/ void** ppvClassObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassObjectOfManagedClass)

		VSL_CHECK_VALIDVALUE_STRINGW(codeBase);

		VSL_CHECK_VALIDVALUE_STRINGW(assemblyName);

		VSL_CHECK_VALIDVALUE_STRINGW(typeName);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvClassObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLocalRegistryRootValidValues
	{
		/*[out]*/ BSTR* pbstrRoot;
		HRESULT retValue;
	};

	STDMETHOD(GetLocalRegistryRoot)(
		/*[out]*/ BSTR* pbstrRoot)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocalRegistryRoot)

		VSL_SET_VALIDVALUE_BSTR(pbstrRoot);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // ILOCALREGISTRY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
