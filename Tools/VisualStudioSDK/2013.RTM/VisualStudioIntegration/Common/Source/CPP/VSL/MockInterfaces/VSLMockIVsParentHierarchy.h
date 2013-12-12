/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPARENTHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPARENTHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsParentHierarchyNotImpl :
	public IVsParentHierarchy
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentHierarchyNotImpl)

public:

	typedef IVsParentHierarchy Interface;

	STDMETHOD(ExtendsBrowseObjects)(
		/*[out]*/ VSEXTENDSHIERARCHY* /*peExtends*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBrowseExtender)(
		/*[in]*/ IVsHierarchy* /*pHierarchyChild*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ IDispatch** /*ppDispatchExtension*/)VSL_STDMETHOD_NOTIMPL
};

class IVsParentHierarchyMockImpl :
	public IVsParentHierarchy,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentHierarchyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsParentHierarchyMockImpl)

	typedef IVsParentHierarchy Interface;
	struct ExtendsBrowseObjectsValidValues
	{
		/*[out]*/ VSEXTENDSHIERARCHY* peExtends;
		HRESULT retValue;
	};

	STDMETHOD(ExtendsBrowseObjects)(
		/*[out]*/ VSEXTENDSHIERARCHY* peExtends)
	{
		VSL_DEFINE_MOCK_METHOD(ExtendsBrowseObjects)

		VSL_SET_VALIDVALUE(peExtends);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBrowseExtenderValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchyChild;
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ IDispatch** ppDispatchExtension;
		HRESULT retValue;
	};

	STDMETHOD(GetBrowseExtender)(
		/*[in]*/ IVsHierarchy* pHierarchyChild,
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ IDispatch** ppDispatchExtension)
	{
		VSL_DEFINE_MOCK_METHOD(GetBrowseExtender)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchyChild);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppDispatchExtension);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPARENTHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
