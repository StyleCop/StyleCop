/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHICALOUTPUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHICALOUTPUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchicalOutputNotImpl :
	public IVsHierarchicalOutput
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchicalOutputNotImpl)

public:

	typedef IVsHierarchicalOutput Interface;

	STDMETHOD(EnumSubOutputs)(
		/*[out]*/ IVsEnumOutputs** /*ppIVsEnumOutputs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* /*pbstrDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CanonicalName)(
		/*[out]*/ BSTR* /*pbstrCanonicalName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DeploySourceURL)(
		/*[out]*/ BSTR* /*pbstrDeploySourceURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Type)(
		/*[out]*/ GUID* /*pguidType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchicalOutputMockImpl :
	public IVsHierarchicalOutput,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchicalOutputMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchicalOutputMockImpl)

	typedef IVsHierarchicalOutput Interface;
	struct EnumSubOutputsValidValues
	{
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs;
		HRESULT retValue;
	};

	STDMETHOD(EnumSubOutputs)(
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs)
	{
		VSL_DEFINE_MOCK_METHOD(EnumSubOutputs)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsEnumOutputs);

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

#endif // IVSHIERARCHICALOUTPUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
