/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTPUT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTPUT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsOutput2NotImpl :
	public IVsOutput2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutput2NotImpl)

public:

	typedef IVsOutput2 Interface;

	STDMETHOD(get_RootRelativeURL)(
		/*[out]*/ BSTR* /*pbstrRelativePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Property)(
		/*[in]*/ LPCOLESTR /*szProperty*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* /*pbstrDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CanonicalName)(
		/*[out]*/ BSTR* /*pbstrCanonicalName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DeploySourceURL)(
		/*[out]*/ BSTR* /*pbstrDeploySourceURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Type)(
		/*[out]*/ GUID* /*pguidType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutput2MockImpl :
	public IVsOutput2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutput2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutput2MockImpl)

	typedef IVsOutput2 Interface;
	struct get_RootRelativeURLValidValues
	{
		/*[out]*/ BSTR* pbstrRelativePath;
		HRESULT retValue;
	};

	STDMETHOD(get_RootRelativeURL)(
		/*[out]*/ BSTR* pbstrRelativePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_RootRelativeURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrRelativePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PropertyValidValues
	{
		/*[in]*/ LPCOLESTR szProperty;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(get_Property)(
		/*[in]*/ LPCOLESTR szProperty,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(get_Property)

		VSL_CHECK_VALIDVALUE_STRINGW(szProperty);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* pbstrDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(get_DisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CanonicalNameValidValues
	{
		/*[out]*/ BSTR* pbstrCanonicalName;
		HRESULT retValue;
	};

	STDMETHOD(get_CanonicalName)(
		/*[out]*/ BSTR* pbstrCanonicalName)
	{
		VSL_DEFINE_MOCK_METHOD(get_CanonicalName)

		VSL_SET_VALIDVALUE_BSTR(pbstrCanonicalName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DeploySourceURLValidValues
	{
		/*[out]*/ BSTR* pbstrDeploySourceURL;
		HRESULT retValue;
	};

	STDMETHOD(get_DeploySourceURL)(
		/*[out]*/ BSTR* pbstrDeploySourceURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_DeploySourceURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrDeploySourceURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TypeValidValues
	{
		/*[out]*/ GUID* pguidType;
		HRESULT retValue;
	};

	STDMETHOD(get_Type)(
		/*[out]*/ GUID* pguidType)
	{
		VSL_DEFINE_MOCK_METHOD(get_Type)

		VSL_SET_VALIDVALUE(pguidType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTPUT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
