/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMARKERCONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMARKERCONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextMarkerContextProviderNotImpl :
	public IVsTextMarkerContextProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerContextProviderNotImpl)

public:

	typedef IVsTextMarkerContextProvider Interface;

	STDMETHOD(UpdateContextForMarker)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IVsUserContext* /*pUC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveLastContext)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IVsUserContext* /*pUC*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextMarkerContextProviderMockImpl :
	public IVsTextMarkerContextProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerContextProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextMarkerContextProviderMockImpl)

	typedef IVsTextMarkerContextProvider Interface;
	struct UpdateContextForMarkerValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IVsUserContext* pUC;
		HRESULT retValue;
	};

	STDMETHOD(UpdateContextForMarker)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IVsUserContext* pUC)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateContextForMarker)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUC);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveLastContextValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IVsUserContext* pUC;
		HRESULT retValue;
	};

	STDMETHOD(RemoveLastContext)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IVsUserContext* pUC)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveLastContext)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUC);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMARKERCONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
