/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICATEGORIZEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICATEGORIZEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ICategorizePropertiesNotImpl :
	public ICategorizeProperties
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICategorizePropertiesNotImpl)

public:

	typedef ICategorizeProperties Interface;

	STDMETHOD(MapPropertyToCategory)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out]*/ PROPCAT* /*ppropcat*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategoryName)(
		/*[in]*/ PROPCAT /*propcat*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL
};

class ICategorizePropertiesMockImpl :
	public ICategorizeProperties,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICategorizePropertiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICategorizePropertiesMockImpl)

	typedef ICategorizeProperties Interface;
	struct MapPropertyToCategoryValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out]*/ PROPCAT* ppropcat;
		HRESULT retValue;
	};

	STDMETHOD(MapPropertyToCategory)(
		/*[in]*/ DISPID dispid,
		/*[out]*/ PROPCAT* ppropcat)
	{
		VSL_DEFINE_MOCK_METHOD(MapPropertyToCategory)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(ppropcat);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryNameValidValues
	{
		/*[in]*/ PROPCAT propcat;
		/*[in]*/ LCID lcid;
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetCategoryName)(
		/*[in]*/ PROPCAT propcat,
		/*[in]*/ LCID lcid,
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategoryName)

		VSL_CHECK_VALIDVALUE(propcat);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICATEGORIZEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
