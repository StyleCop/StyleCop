/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSITEMTYPERESOLUTIONSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSITEMTYPERESOLUTIONSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsItemTypeResolutionSiteNotImpl :
	public IVsItemTypeResolutionSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsItemTypeResolutionSiteNotImpl)

public:

	typedef IVsItemTypeResolutionSite Interface;

	STDMETHOD(AddReference)(
		/*[in]*/ BSTR /*bstrReferencePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitForReferencesReady)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCodeDirectoryAssembly)(
		/*[in]*/ BSTR /*bstrAssembly*/,
		/*[out]*/ BOOL* /*pfIsCodeAssembly*/)VSL_STDMETHOD_NOTIMPL
};

class IVsItemTypeResolutionSiteMockImpl :
	public IVsItemTypeResolutionSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsItemTypeResolutionSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsItemTypeResolutionSiteMockImpl)

	typedef IVsItemTypeResolutionSite Interface;
	struct AddReferenceValidValues
	{
		/*[in]*/ BSTR bstrReferencePath;
		HRESULT retValue;
	};

	STDMETHOD(AddReference)(
		/*[in]*/ BSTR bstrReferencePath)
	{
		VSL_DEFINE_MOCK_METHOD(AddReference)

		VSL_CHECK_VALIDVALUE_BSTR(bstrReferencePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitForReferencesReadyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(WaitForReferencesReady)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(WaitForReferencesReady)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCodeDirectoryAssemblyValidValues
	{
		/*[in]*/ BSTR bstrAssembly;
		/*[out]*/ BOOL* pfIsCodeAssembly;
		HRESULT retValue;
	};

	STDMETHOD(IsCodeDirectoryAssembly)(
		/*[in]*/ BSTR bstrAssembly,
		/*[out]*/ BOOL* pfIsCodeAssembly)
	{
		VSL_DEFINE_MOCK_METHOD(IsCodeDirectoryAssembly)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAssembly);

		VSL_SET_VALIDVALUE(pfIsCodeAssembly);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSITEMTYPERESOLUTIONSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
