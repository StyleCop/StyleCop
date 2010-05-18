/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENUMHIERARCHYITEMSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENUMHIERARCHYITEMSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsEnumHierarchyItemsFactoryNotImpl :
	public IVsEnumHierarchyItemsFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumHierarchyItemsFactoryNotImpl)

public:

	typedef IVsEnumHierarchyItemsFactory Interface;

	STDMETHOD(EnumHierarchyItems)(
		/*[in]*/ IVsHierarchy* /*pHierRoot*/,
		/*[in]*/ VSEHI /*grfItems*/,
		/*[in]*/ VSITEMID /*itemidRoot*/,
		/*[out]*/ IEnumHierarchyItems** /*ppenum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEnumHierarchyItemsFactoryMockImpl :
	public IVsEnumHierarchyItemsFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumHierarchyItemsFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEnumHierarchyItemsFactoryMockImpl)

	typedef IVsEnumHierarchyItemsFactory Interface;
	struct EnumHierarchyItemsValidValues
	{
		/*[in]*/ IVsHierarchy* pHierRoot;
		/*[in]*/ VSEHI grfItems;
		/*[in]*/ VSITEMID itemidRoot;
		/*[out]*/ IEnumHierarchyItems** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(EnumHierarchyItems)(
		/*[in]*/ IVsHierarchy* pHierRoot,
		/*[in]*/ VSEHI grfItems,
		/*[in]*/ VSITEMID itemidRoot,
		/*[out]*/ IEnumHierarchyItems** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumHierarchyItems)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierRoot);

		VSL_CHECK_VALIDVALUE(grfItems);

		VSL_CHECK_VALIDVALUE(itemidRoot);

		VSL_SET_VALIDVALUE_INTERFACE(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENUMHIERARCHYITEMSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
