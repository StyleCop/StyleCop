/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBROWSECONTAINERSLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBROWSECONTAINERSLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBrowseContainersListNotImpl :
	public IVsBrowseContainersList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBrowseContainersListNotImpl)

public:

	typedef IVsBrowseContainersList Interface;

	STDMETHOD(GetContainerData)(
		/*[in]*/ ULONG /*ulIndex*/,
		/*[out]*/ VSCOMPONENTSELECTORDATA* /*pData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindContainer)(
		/*[in]*/ VSCOMPONENTSELECTORDATA* /*pData*/,
		/*[out]*/ ULONG* /*pulIndex*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBrowseContainersListMockImpl :
	public IVsBrowseContainersList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBrowseContainersListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBrowseContainersListMockImpl)

	typedef IVsBrowseContainersList Interface;
	struct GetContainerDataValidValues
	{
		/*[in]*/ ULONG ulIndex;
		/*[out]*/ VSCOMPONENTSELECTORDATA* pData;
		HRESULT retValue;
	};

	STDMETHOD(GetContainerData)(
		/*[in]*/ ULONG ulIndex,
		/*[out]*/ VSCOMPONENTSELECTORDATA* pData)
	{
		VSL_DEFINE_MOCK_METHOD(GetContainerData)

		VSL_CHECK_VALIDVALUE(ulIndex);

		VSL_SET_VALIDVALUE(pData);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindContainerValidValues
	{
		/*[in]*/ VSCOMPONENTSELECTORDATA* pData;
		/*[out]*/ ULONG* pulIndex;
		HRESULT retValue;
	};

	STDMETHOD(FindContainer)(
		/*[in]*/ VSCOMPONENTSELECTORDATA* pData,
		/*[out]*/ ULONG* pulIndex)
	{
		VSL_DEFINE_MOCK_METHOD(FindContainer)

		VSL_CHECK_VALIDVALUE_POINTER(pData);

		VSL_SET_VALIDVALUE(pulIndex);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBROWSECONTAINERSLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
