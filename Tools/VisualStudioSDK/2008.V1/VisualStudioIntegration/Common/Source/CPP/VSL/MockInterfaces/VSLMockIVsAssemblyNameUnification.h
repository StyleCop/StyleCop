/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSASSEMBLYNAMEUNIFICATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSASSEMBLYNAMEUNIFICATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsAssemblyNameUnificationNotImpl :
	public IVsAssemblyNameUnification
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAssemblyNameUnificationNotImpl)

public:

	typedef IVsAssemblyNameUnification Interface;

	STDMETHOD(GetUnifiedAssemblyName)(
		/*[in]*/ LPCOLESTR /*wszFrameworkDirectory*/,
		/*[in]*/ LPCOLESTR /*wszSimpleAssemblyName*/,
		/*[in]*/ LPCOLESTR /*wszFullAssemblyName*/,
		/*[out]*/ BSTR* /*pbstrUnifiedAssemblyName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAssemblyNameUnificationMockImpl :
	public IVsAssemblyNameUnification,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAssemblyNameUnificationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAssemblyNameUnificationMockImpl)

	typedef IVsAssemblyNameUnification Interface;
	struct GetUnifiedAssemblyNameValidValues
	{
		/*[in]*/ LPCOLESTR wszFrameworkDirectory;
		/*[in]*/ LPCOLESTR wszSimpleAssemblyName;
		/*[in]*/ LPCOLESTR wszFullAssemblyName;
		/*[out]*/ BSTR* pbstrUnifiedAssemblyName;
		HRESULT retValue;
	};

	STDMETHOD(GetUnifiedAssemblyName)(
		/*[in]*/ LPCOLESTR wszFrameworkDirectory,
		/*[in]*/ LPCOLESTR wszSimpleAssemblyName,
		/*[in]*/ LPCOLESTR wszFullAssemblyName,
		/*[out]*/ BSTR* pbstrUnifiedAssemblyName)
	{
		VSL_DEFINE_MOCK_METHOD(GetUnifiedAssemblyName)

		VSL_CHECK_VALIDVALUE_STRINGW(wszFrameworkDirectory);

		VSL_CHECK_VALIDVALUE_STRINGW(wszSimpleAssemblyName);

		VSL_CHECK_VALIDVALUE_STRINGW(wszFullAssemblyName);

		VSL_SET_VALIDVALUE_BSTR(pbstrUnifiedAssemblyName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSASSEMBLYNAMEUNIFICATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
