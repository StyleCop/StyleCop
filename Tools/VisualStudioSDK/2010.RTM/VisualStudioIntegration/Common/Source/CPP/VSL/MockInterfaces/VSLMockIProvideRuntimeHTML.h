/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDERUNTIMEHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDERUNTIMEHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ocdesign.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IProvideRuntimeHTMLNotImpl :
	public IProvideRuntimeHTML
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideRuntimeHTMLNotImpl)

public:

	typedef IProvideRuntimeHTML Interface;

	STDMETHOD(GetRuntimeHTML)(
		/*[out,retval]*/ BSTR* /*pstrRuntimeHTML*/)VSL_STDMETHOD_NOTIMPL
};

class IProvideRuntimeHTMLMockImpl :
	public IProvideRuntimeHTML,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideRuntimeHTMLMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvideRuntimeHTMLMockImpl)

	typedef IProvideRuntimeHTML Interface;
	struct GetRuntimeHTMLValidValues
	{
		/*[out,retval]*/ BSTR* pstrRuntimeHTML;
		HRESULT retValue;
	};

	STDMETHOD(GetRuntimeHTML)(
		/*[out,retval]*/ BSTR* pstrRuntimeHTML)
	{
		VSL_DEFINE_MOCK_METHOD(GetRuntimeHTML)

		VSL_SET_VALIDVALUE_BSTR(pstrRuntimeHTML);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROVIDERUNTIMEHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
