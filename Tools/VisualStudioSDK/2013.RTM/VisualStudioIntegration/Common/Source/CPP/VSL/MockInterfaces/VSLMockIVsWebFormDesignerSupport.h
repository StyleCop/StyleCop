/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBFORMDESIGNERSUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBFORMDESIGNERSUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebFormDesignerSupportNotImpl :
	public IVsWebFormDesignerSupport
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebFormDesignerSupportNotImpl)

public:

	typedef IVsWebFormDesignerSupport Interface;

	STDMETHOD(GetCodeDomProvider)(
		/*[out]*/ IUnknown** /*ppProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddReference)(
		/*[in]*/ LPCWSTR /*pszReference*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebFormDesignerSupportMockImpl :
	public IVsWebFormDesignerSupport,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebFormDesignerSupportMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebFormDesignerSupportMockImpl)

	typedef IVsWebFormDesignerSupport Interface;
	struct GetCodeDomProviderValidValues
	{
		/*[out]*/ IUnknown** ppProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeDomProvider)(
		/*[out]*/ IUnknown** ppProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeDomProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddReferenceValidValues
	{
		/*[in]*/ LPCWSTR pszReference;
		HRESULT retValue;
	};

	STDMETHOD(AddReference)(
		/*[in]*/ LPCWSTR pszReference)
	{
		VSL_DEFINE_MOCK_METHOD(AddReference)

		VSL_CHECK_VALIDVALUE_STRINGW(pszReference);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBFORMDESIGNERSUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
