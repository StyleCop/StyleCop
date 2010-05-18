/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCADDWEBPROJECTFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCADDWEBPROJECTFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccAddWebProjectFromSourceControl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccAddWebProjectFromSourceControlNotImpl :
	public IVsSccAddWebProjectFromSourceControl
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccAddWebProjectFromSourceControlNotImpl)

public:

	typedef IVsSccAddWebProjectFromSourceControl Interface;

	STDMETHOD(IsAddWebProjectSupported)(
		/*[out]*/ VARIANT_BOOL* /*pfResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BrowseForServerLocation)(
		/*[out]*/ BSTR* /*pbstrLocationDescription*/,
		/*[out]*/ BSTR* /*pbstrLocalPath*/,
		/*[out]*/ BSTR* /*pbstrDatabasePath*/,
		/*[out]*/ BSTR* /*pbstrAuxiliarPath*/,
		/*[out]*/ BSTR* /*pbstrProviderName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddWebProjectFromSourceControl)(
		/*[in]*/ BSTR /*bstrLocalPath*/,
		/*[in]*/ BSTR /*bstrDatabasePath*/,
		/*[in]*/ BSTR /*bstrAuxiliarPath*/,
		/*[in]*/ BSTR /*bstrProviderName*/,
		/*[in]*/ BSTR /*bstrDebuggingPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccAddWebProjectFromSourceControlMockImpl :
	public IVsSccAddWebProjectFromSourceControl,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccAddWebProjectFromSourceControlMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccAddWebProjectFromSourceControlMockImpl)

	typedef IVsSccAddWebProjectFromSourceControl Interface;
	struct IsAddWebProjectSupportedValidValues
	{
		/*[out]*/ VARIANT_BOOL* pfResult;
		HRESULT retValue;
	};

	STDMETHOD(IsAddWebProjectSupported)(
		/*[out]*/ VARIANT_BOOL* pfResult)
	{
		VSL_DEFINE_MOCK_METHOD(IsAddWebProjectSupported)

		VSL_SET_VALIDVALUE(pfResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct BrowseForServerLocationValidValues
	{
		/*[out]*/ BSTR* pbstrLocationDescription;
		/*[out]*/ BSTR* pbstrLocalPath;
		/*[out]*/ BSTR* pbstrDatabasePath;
		/*[out]*/ BSTR* pbstrAuxiliarPath;
		/*[out]*/ BSTR* pbstrProviderName;
		HRESULT retValue;
	};

	STDMETHOD(BrowseForServerLocation)(
		/*[out]*/ BSTR* pbstrLocationDescription,
		/*[out]*/ BSTR* pbstrLocalPath,
		/*[out]*/ BSTR* pbstrDatabasePath,
		/*[out]*/ BSTR* pbstrAuxiliarPath,
		/*[out]*/ BSTR* pbstrProviderName)
	{
		VSL_DEFINE_MOCK_METHOD(BrowseForServerLocation)

		VSL_SET_VALIDVALUE_BSTR(pbstrLocationDescription);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocalPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrDatabasePath);

		VSL_SET_VALIDVALUE_BSTR(pbstrAuxiliarPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrProviderName);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddWebProjectFromSourceControlValidValues
	{
		/*[in]*/ BSTR bstrLocalPath;
		/*[in]*/ BSTR bstrDatabasePath;
		/*[in]*/ BSTR bstrAuxiliarPath;
		/*[in]*/ BSTR bstrProviderName;
		/*[in]*/ BSTR bstrDebuggingPath;
		HRESULT retValue;
	};

	STDMETHOD(AddWebProjectFromSourceControl)(
		/*[in]*/ BSTR bstrLocalPath,
		/*[in]*/ BSTR bstrDatabasePath,
		/*[in]*/ BSTR bstrAuxiliarPath,
		/*[in]*/ BSTR bstrProviderName,
		/*[in]*/ BSTR bstrDebuggingPath)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebProjectFromSourceControl)

		VSL_CHECK_VALIDVALUE_BSTR(bstrLocalPath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDatabasePath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrAuxiliarPath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrProviderName);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDebuggingPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCADDWEBPROJECTFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
