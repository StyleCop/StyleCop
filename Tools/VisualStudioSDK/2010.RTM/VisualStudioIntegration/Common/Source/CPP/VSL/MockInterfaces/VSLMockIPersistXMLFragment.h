/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTXMLFRAGMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTXMLFRAGMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPersistXMLFragmentNotImpl :
	public IPersistXMLFragment
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistXMLFragmentNotImpl)

public:

	typedef IPersistXMLFragment Interface;

	STDMETHOD(InitNew)(
		/*[in]*/ REFGUID /*guidFlavor*/,
		/*[in]*/ PersistStorageType /*storage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsFragmentDirty)(
		/*[in]*/ PersistStorageType /*storage*/,
		/*[out]*/ BOOL* /*pfDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in]*/ REFGUID /*guidFlavor*/,
		/*[in]*/ PersistStorageType /*storage*/,
		/*[in]*/ LPCOLESTR /*pszXMLFragment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in]*/ REFGUID /*guidFlavor*/,
		/*[in]*/ PersistStorageType /*storage*/,
		/*[out]*/ BSTR* /*pbstrXMLFragment*/,
		/*[in]*/ BOOL /*fClearDirty*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistXMLFragmentMockImpl :
	public IPersistXMLFragment,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistXMLFragmentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistXMLFragmentMockImpl)

	typedef IPersistXMLFragment Interface;
	struct InitNewValidValues
	{
		/*[in]*/ REFGUID guidFlavor;
		/*[in]*/ PersistStorageType storage;
		HRESULT retValue;
	};

	STDMETHOD(InitNew)(
		/*[in]*/ REFGUID guidFlavor,
		/*[in]*/ PersistStorageType storage)
	{
		VSL_DEFINE_MOCK_METHOD(InitNew)

		VSL_CHECK_VALIDVALUE(guidFlavor);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsFragmentDirtyValidValues
	{
		/*[in]*/ PersistStorageType storage;
		/*[out]*/ BOOL* pfDirty;
		HRESULT retValue;
	};

	STDMETHOD(IsFragmentDirty)(
		/*[in]*/ PersistStorageType storage,
		/*[out]*/ BOOL* pfDirty)
	{
		VSL_DEFINE_MOCK_METHOD(IsFragmentDirty)

		VSL_CHECK_VALIDVALUE(storage);

		VSL_SET_VALIDVALUE(pfDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in]*/ REFGUID guidFlavor;
		/*[in]*/ PersistStorageType storage;
		/*[in]*/ LPCOLESTR pszXMLFragment;
		HRESULT retValue;
	};

	STDMETHOD(Load)(
		/*[in]*/ REFGUID guidFlavor,
		/*[in]*/ PersistStorageType storage,
		/*[in]*/ LPCOLESTR pszXMLFragment)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE(guidFlavor);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszXMLFragment);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in]*/ REFGUID guidFlavor;
		/*[in]*/ PersistStorageType storage;
		/*[out]*/ BSTR* pbstrXMLFragment;
		/*[in]*/ BOOL fClearDirty;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in]*/ REFGUID guidFlavor,
		/*[in]*/ PersistStorageType storage,
		/*[out]*/ BSTR* pbstrXMLFragment,
		/*[in]*/ BOOL fClearDirty)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE(guidFlavor);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_SET_VALIDVALUE_BSTR(pbstrXMLFragment);

		VSL_CHECK_VALIDVALUE(fClearDirty);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERSISTXMLFRAGMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
