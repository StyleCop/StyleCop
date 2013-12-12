/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGEPROJECTNAMEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGEPROJECTNAMEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsContainedLanguageProjectNameProviderNotImpl :
	public IVsContainedLanguageProjectNameProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageProjectNameProviderNotImpl)

public:

	typedef IVsContainedLanguageProjectNameProvider Interface;

	STDMETHOD(GetProjectName)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out,retval]*/ BSTR* /*pbstrProjectName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageProjectNameProviderMockImpl :
	public IVsContainedLanguageProjectNameProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageProjectNameProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageProjectNameProviderMockImpl)

	typedef IVsContainedLanguageProjectNameProvider Interface;
	struct GetProjectNameValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out,retval]*/ BSTR* pbstrProjectName;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectName)(
		/*[in]*/ VSITEMID itemid,
		/*[out,retval]*/ BSTR* pbstrProjectName)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectName)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjectName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGEPROJECTNAMEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
