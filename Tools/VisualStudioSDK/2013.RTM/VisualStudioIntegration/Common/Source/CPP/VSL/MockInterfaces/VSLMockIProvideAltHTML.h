/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDEALTHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDEALTHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IProvideAltHTMLNotImpl :
	public IProvideAltHTML
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideAltHTMLNotImpl)

public:

	typedef IProvideAltHTML Interface;

	STDMETHOD(GetAltHTML)(
		/*[out,retval]*/ BSTR* /*pstrAltHTML*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsAltHTMLEditable)(
		/*[out,retval]*/ boolean* /*pfIsEditable*/)VSL_STDMETHOD_NOTIMPL
};

class IProvideAltHTMLMockImpl :
	public IProvideAltHTML,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideAltHTMLMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvideAltHTMLMockImpl)

	typedef IProvideAltHTML Interface;
	struct GetAltHTMLValidValues
	{
		/*[out,retval]*/ BSTR* pstrAltHTML;
		HRESULT retValue;
	};

	STDMETHOD(GetAltHTML)(
		/*[out,retval]*/ BSTR* pstrAltHTML)
	{
		VSL_DEFINE_MOCK_METHOD(GetAltHTML)

		VSL_SET_VALIDVALUE_BSTR(pstrAltHTML);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsAltHTMLEditableValidValues
	{
		/*[out,retval]*/ boolean* pfIsEditable;
		HRESULT retValue;
	};

	STDMETHOD(IsAltHTMLEditable)(
		/*[out,retval]*/ boolean* pfIsEditable)
	{
		VSL_DEFINE_MOCK_METHOD(IsAltHTMLEditable)

		VSL_SET_VALIDVALUE(pfIsEditable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROVIDEALTHTML_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
