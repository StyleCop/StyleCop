/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISPECIFYPROPERTYPAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISPECIFYPROPERTYPAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ISpecifyPropertyPagesNotImpl :
	public ISpecifyPropertyPages
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISpecifyPropertyPagesNotImpl)

public:

	typedef ISpecifyPropertyPages Interface;

	STDMETHOD(GetPages)(
		/*[out]*/ CAUUID* /*pPages*/)VSL_STDMETHOD_NOTIMPL
};

class ISpecifyPropertyPagesMockImpl :
	public ISpecifyPropertyPages,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISpecifyPropertyPagesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISpecifyPropertyPagesMockImpl)

	typedef ISpecifyPropertyPages Interface;
	struct GetPagesValidValues
	{
		/*[out]*/ CAUUID* pPages;
		HRESULT retValue;
	};

	STDMETHOD(GetPages)(
		/*[out]*/ CAUUID* pPages)
	{
		VSL_DEFINE_MOCK_METHOD(GetPages)

		VSL_SET_VALIDVALUE(pPages);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISPECIFYPROPERTYPAGES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
