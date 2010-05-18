/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTEDITORPROPERTYCATEGORYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTEDITORPROPERTYCATEGORYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextEditorPropertyCategoryContainerNotImpl :
	public IVsTextEditorPropertyCategoryContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextEditorPropertyCategoryContainerNotImpl)

public:

	typedef IVsTextEditorPropertyCategoryContainer Interface;

	STDMETHOD(GetPropertyCategory)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[out]*/ IVsTextEditorPropertyContainer** /*ppProp*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextEditorPropertyCategoryContainerMockImpl :
	public IVsTextEditorPropertyCategoryContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextEditorPropertyCategoryContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextEditorPropertyCategoryContainerMockImpl)

	typedef IVsTextEditorPropertyCategoryContainer Interface;
	struct GetPropertyCategoryValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[out]*/ IVsTextEditorPropertyContainer** ppProp;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyCategory)(
		/*[in]*/ REFGUID rguidCategory,
		/*[out]*/ IVsTextEditorPropertyContainer** ppProp)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyCategory)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_SET_VALIDVALUE_INTERFACE(ppProp);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTEDITORPROPERTYCATEGORYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
