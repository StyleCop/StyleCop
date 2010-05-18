/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSERRORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSERRORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsErrorItemNotImpl :
	public IVsErrorItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsErrorItemNotImpl)

public:

	typedef IVsErrorItem Interface;

	STDMETHOD(GetHierarchy)(
		/*[out]*/ IVsHierarchy** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategory)(
		/*[out]*/ VSERRORCATEGORY* /*pCategory*/)VSL_STDMETHOD_NOTIMPL
};

class IVsErrorItemMockImpl :
	public IVsErrorItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsErrorItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsErrorItemMockImpl)

	typedef IVsErrorItem Interface;
	struct GetHierarchyValidValues
	{
		/*[out]*/ IVsHierarchy** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(GetHierarchy)(
		/*[out]*/ IVsHierarchy** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(GetHierarchy)

		VSL_SET_VALIDVALUE_INTERFACE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryValidValues
	{
		/*[out]*/ VSERRORCATEGORY* pCategory;
		HRESULT retValue;
	};

	STDMETHOD(GetCategory)(
		/*[out]*/ VSERRORCATEGORY* pCategory)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategory)

		VSL_SET_VALIDVALUE(pCategory);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSERRORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
