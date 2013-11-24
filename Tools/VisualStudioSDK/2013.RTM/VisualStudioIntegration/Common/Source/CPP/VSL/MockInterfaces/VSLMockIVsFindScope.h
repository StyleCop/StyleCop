/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFindScopeNotImpl :
	public IVsFindScope
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindScopeNotImpl)

public:

	typedef IVsFindScope Interface;

	STDMETHOD(GetUIName)(
		/*[out,retval]*/ BSTR* /*pbsName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetQuery)(
		/*[out]*/ BSTR* /*pbstrBaseDirectory*/,
		/*[out,retval]*/ BSTR* /*pbstrQuery*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumFilenames)(
		/*[out,retval]*/ IEnumString** /*ppEnumString*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindScopeMockImpl :
	public IVsFindScope,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindScopeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindScopeMockImpl)

	typedef IVsFindScope Interface;
	struct GetUINameValidValues
	{
		/*[out,retval]*/ BSTR* pbsName;
		HRESULT retValue;
	};

	STDMETHOD(GetUIName)(
		/*[out,retval]*/ BSTR* pbsName)
	{
		VSL_DEFINE_MOCK_METHOD(GetUIName)

		VSL_SET_VALIDVALUE_BSTR(pbsName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetQueryValidValues
	{
		/*[out]*/ BSTR* pbstrBaseDirectory;
		/*[out,retval]*/ BSTR* pbstrQuery;
		HRESULT retValue;
	};

	STDMETHOD(GetQuery)(
		/*[out]*/ BSTR* pbstrBaseDirectory,
		/*[out,retval]*/ BSTR* pbstrQuery)
	{
		VSL_DEFINE_MOCK_METHOD(GetQuery)

		VSL_SET_VALIDVALUE_BSTR(pbstrBaseDirectory);

		VSL_SET_VALIDVALUE_BSTR(pbstrQuery);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumFilenamesValidValues
	{
		/*[out,retval]*/ IEnumString** ppEnumString;
		HRESULT retValue;
	};

	STDMETHOD(EnumFilenames)(
		/*[out,retval]*/ IEnumString** ppEnumString)
	{
		VSL_DEFINE_MOCK_METHOD(EnumFilenames)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumString);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
