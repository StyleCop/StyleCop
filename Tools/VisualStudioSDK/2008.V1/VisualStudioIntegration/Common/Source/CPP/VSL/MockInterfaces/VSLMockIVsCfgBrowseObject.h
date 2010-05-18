/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCFGBROWSEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCFGBROWSEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCfgBrowseObjectNotImpl :
	public IVsCfgBrowseObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgBrowseObjectNotImpl)

public:

	typedef IVsCfgBrowseObject Interface;

	STDMETHOD(GetCfg)(
		/*[out]*/ IVsCfg** /*ppCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectItem)(
		/*[out]*/ IVsHierarchy** /*pHier*/,
		/*[out]*/ VSITEMID* /*pItemid*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCfgBrowseObjectMockImpl :
	public IVsCfgBrowseObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgBrowseObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCfgBrowseObjectMockImpl)

	typedef IVsCfgBrowseObject Interface;
	struct GetCfgValidValues
	{
		/*[out]*/ IVsCfg** ppCfg;
		HRESULT retValue;
	};

	STDMETHOD(GetCfg)(
		/*[out]*/ IVsCfg** ppCfg)
	{
		VSL_DEFINE_MOCK_METHOD(GetCfg)

		VSL_SET_VALIDVALUE_INTERFACE(ppCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectItemValidValues
	{
		/*[out]*/ IVsHierarchy** pHier;
		/*[out]*/ VSITEMID* pItemid;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectItem)(
		/*[out]*/ IVsHierarchy** pHier,
		/*[out]*/ VSITEMID* pItemid)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectItem)

		VSL_SET_VALIDVALUE_INTERFACE(pHier);

		VSL_SET_VALIDVALUE(pItemid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCFGBROWSEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
