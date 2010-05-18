/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDETERMINEWIZARDTRUST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDETERMINEWIZARDTRUST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDetermineWizardTrustNotImpl :
	public IVsDetermineWizardTrust
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDetermineWizardTrustNotImpl)

public:

	typedef IVsDetermineWizardTrust Interface;

	STDMETHOD(OnWizardInitiated)(
		/*[in]*/ LPCOLESTR /*pszTemplateFilename*/,
		/*[in]*/ REFGUID /*guidProjectType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnWizardCompleted)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsWizardRunning)(
		/*[out]*/ BOOL* /*pfWizardRunning*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRunningWizardTemplateName)(
		/*[out]*/ BSTR* /*pbstrRunningTemplate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWizardTrustLevel)(
		/*[out]*/ VSWIZARDTRUSTLEVEL* /*pdwWizardTrustLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetWizardTrustLevel)(
		/*[in]*/ VSWIZARDTRUSTLEVEL /*dwWizardTrustLevel*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDetermineWizardTrustMockImpl :
	public IVsDetermineWizardTrust,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDetermineWizardTrustMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDetermineWizardTrustMockImpl)

	typedef IVsDetermineWizardTrust Interface;
	struct OnWizardInitiatedValidValues
	{
		/*[in]*/ LPCOLESTR pszTemplateFilename;
		/*[in]*/ REFGUID guidProjectType;
		HRESULT retValue;
	};

	STDMETHOD(OnWizardInitiated)(
		/*[in]*/ LPCOLESTR pszTemplateFilename,
		/*[in]*/ REFGUID guidProjectType)
	{
		VSL_DEFINE_MOCK_METHOD(OnWizardInitiated)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateFilename);

		VSL_CHECK_VALIDVALUE(guidProjectType);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnWizardCompletedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnWizardCompleted)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnWizardCompleted)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsWizardRunningValidValues
	{
		/*[out]*/ BOOL* pfWizardRunning;
		HRESULT retValue;
	};

	STDMETHOD(IsWizardRunning)(
		/*[out]*/ BOOL* pfWizardRunning)
	{
		VSL_DEFINE_MOCK_METHOD(IsWizardRunning)

		VSL_SET_VALIDVALUE(pfWizardRunning);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRunningWizardTemplateNameValidValues
	{
		/*[out]*/ BSTR* pbstrRunningTemplate;
		HRESULT retValue;
	};

	STDMETHOD(GetRunningWizardTemplateName)(
		/*[out]*/ BSTR* pbstrRunningTemplate)
	{
		VSL_DEFINE_MOCK_METHOD(GetRunningWizardTemplateName)

		VSL_SET_VALIDVALUE_BSTR(pbstrRunningTemplate);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWizardTrustLevelValidValues
	{
		/*[out]*/ VSWIZARDTRUSTLEVEL* pdwWizardTrustLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetWizardTrustLevel)(
		/*[out]*/ VSWIZARDTRUSTLEVEL* pdwWizardTrustLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetWizardTrustLevel)

		VSL_SET_VALIDVALUE(pdwWizardTrustLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetWizardTrustLevelValidValues
	{
		/*[in]*/ VSWIZARDTRUSTLEVEL dwWizardTrustLevel;
		HRESULT retValue;
	};

	STDMETHOD(SetWizardTrustLevel)(
		/*[in]*/ VSWIZARDTRUSTLEVEL dwWizardTrustLevel)
	{
		VSL_DEFINE_MOCK_METHOD(SetWizardTrustLevel)

		VSL_CHECK_VALIDVALUE(dwWizardTrustLevel);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDETERMINEWIZARDTRUST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
