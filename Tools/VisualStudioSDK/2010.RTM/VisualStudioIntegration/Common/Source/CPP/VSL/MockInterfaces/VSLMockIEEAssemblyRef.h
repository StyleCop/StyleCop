/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEEASSEMBLYREF_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEEASSEMBLYREF_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IEEAssemblyRefNotImpl :
	public IEEAssemblyRef
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEAssemblyRefNotImpl)

public:

	typedef IEEAssemblyRef Interface;

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*bstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVersion)(
		/*[out]*/ USHORT* /*major*/,
		/*[out]*/ USHORT* /*minor*/,
		/*[out]*/ USHORT* /*build*/,
		/*[out]*/ USHORT* /*revision*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCulture)(
		/*[out]*/ BSTR* /*bstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPublicKey)(
		/*[out]*/ BSTR* /*key*/)VSL_STDMETHOD_NOTIMPL
};

class IEEAssemblyRefMockImpl :
	public IEEAssemblyRef,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEAssemblyRefMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEEAssemblyRefMockImpl)

	typedef IEEAssemblyRef Interface;
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* bstr;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* bstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(bstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVersionValidValues
	{
		/*[out]*/ USHORT* major;
		/*[out]*/ USHORT* minor;
		/*[out]*/ USHORT* build;
		/*[out]*/ USHORT* revision;
		HRESULT retValue;
	};

	STDMETHOD(GetVersion)(
		/*[out]*/ USHORT* major,
		/*[out]*/ USHORT* minor,
		/*[out]*/ USHORT* build,
		/*[out]*/ USHORT* revision)
	{
		VSL_DEFINE_MOCK_METHOD(GetVersion)

		VSL_SET_VALIDVALUE(major);

		VSL_SET_VALIDVALUE(minor);

		VSL_SET_VALIDVALUE(build);

		VSL_SET_VALIDVALUE(revision);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCultureValidValues
	{
		/*[out]*/ BSTR* bstr;
		HRESULT retValue;
	};

	STDMETHOD(GetCulture)(
		/*[out]*/ BSTR* bstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetCulture)

		VSL_SET_VALIDVALUE_BSTR(bstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPublicKeyValidValues
	{
		/*[out]*/ BSTR* key;
		HRESULT retValue;
	};

	STDMETHOD(GetPublicKey)(
		/*[out]*/ BSTR* key)
	{
		VSL_DEFINE_MOCK_METHOD(GetPublicKey)

		VSL_SET_VALIDVALUE_BSTR(key);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEEASSEMBLYREF_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
