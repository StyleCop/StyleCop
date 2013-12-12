/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYPAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYPAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPropertyPageNotImpl :
	public IVsPropertyPage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageNotImpl)

public:

	typedef IVsPropertyPage Interface;

	STDMETHOD(get_CategoryTitle)(
		/*[in]*/ UINT /*iLevel*/,
		/*[out,retval]*/ BSTR* /*pbstrCategory*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyPageMockImpl :
	public IVsPropertyPage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyPageMockImpl)

	typedef IVsPropertyPage Interface;
	struct get_CategoryTitleValidValues
	{
		/*[in]*/ UINT iLevel;
		/*[out,retval]*/ BSTR* pbstrCategory;
		HRESULT retValue;
	};

	STDMETHOD(get_CategoryTitle)(
		/*[in]*/ UINT iLevel,
		/*[out,retval]*/ BSTR* pbstrCategory)
	{
		VSL_DEFINE_MOCK_METHOD(get_CategoryTitle)

		VSL_CHECK_VALIDVALUE(iLevel);

		VSL_SET_VALIDVALUE_BSTR(pbstrCategory);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYPAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
