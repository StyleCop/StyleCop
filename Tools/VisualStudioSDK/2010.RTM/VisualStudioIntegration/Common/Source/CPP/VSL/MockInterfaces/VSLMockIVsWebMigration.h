/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBMIGRATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBMIGRATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "webmigration.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebMigrationNotImpl :
	public IVsWebMigration
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebMigrationNotImpl)

public:

	typedef IVsWebMigration Interface;

	STDMETHOD(LoadAssembly)(
		/*[in]*/ BSTR /*bstrFilePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseType)(
		/*[in]*/ BSTR /*bstrClassName*/,
		/*[out]*/ BSTR* /*pbstrBaseClass*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unload)()VSL_STDMETHOD_NOTIMPL
};

class IVsWebMigrationMockImpl :
	public IVsWebMigration,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebMigrationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebMigrationMockImpl)

	typedef IVsWebMigration Interface;
	struct LoadAssemblyValidValues
	{
		/*[in]*/ BSTR bstrFilePath;
		HRESULT retValue;
	};

	STDMETHOD(LoadAssembly)(
		/*[in]*/ BSTR bstrFilePath)
	{
		VSL_DEFINE_MOCK_METHOD(LoadAssembly)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseTypeValidValues
	{
		/*[in]*/ BSTR bstrClassName;
		/*[out]*/ BSTR* pbstrBaseClass;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseType)(
		/*[in]*/ BSTR bstrClassName,
		/*[out]*/ BSTR* pbstrBaseClass)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseType)

		VSL_CHECK_VALIDVALUE_BSTR(bstrClassName);

		VSL_SET_VALIDVALUE_BSTR(pbstrBaseClass);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnloadValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unload)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unload)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBMIGRATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
