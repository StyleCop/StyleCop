/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPACKAGEDYNAMICTOOLOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPACKAGEDYNAMICTOOLOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPackageDynamicToolOwnerNotImpl :
	public IVsPackageDynamicToolOwner
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageDynamicToolOwnerNotImpl)

public:

	typedef IVsPackageDynamicToolOwner Interface;

	STDMETHOD(QueryShowTool)(
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[out]*/ BOOL* /*pfShowTool*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPackageDynamicToolOwnerMockImpl :
	public IVsPackageDynamicToolOwner,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageDynamicToolOwnerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPackageDynamicToolOwnerMockImpl)

	typedef IVsPackageDynamicToolOwner Interface;
	struct QueryShowToolValidValues
	{
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[out]*/ BOOL* pfShowTool;
		HRESULT retValue;
	};

	STDMETHOD(QueryShowTool)(
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[out]*/ BOOL* pfShowTool)
	{
		VSL_DEFINE_MOCK_METHOD(QueryShowTool)

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_SET_VALIDVALUE(pfShowTool);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPACKAGEDYNAMICTOOLOWNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
