/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMULTIQI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMULTIQI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IMultiQINotImpl :
	public IMultiQI
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMultiQINotImpl)

public:

	typedef IMultiQI Interface;

	STDMETHOD(QueryMultipleInterfaces)(
		/*[in]*/ ULONG /*cMQIs*/,
		/*[in,out]*/ MULTI_QI* /*pMQIs*/)VSL_STDMETHOD_NOTIMPL
};

class IMultiQIMockImpl :
	public IMultiQI,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMultiQIMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMultiQIMockImpl)

	typedef IMultiQI Interface;
	struct QueryMultipleInterfacesValidValues
	{
		/*[in]*/ ULONG cMQIs;
		/*[in,out]*/ MULTI_QI* pMQIs;
		HRESULT retValue;
	};

	STDMETHOD(QueryMultipleInterfaces)(
		/*[in]*/ ULONG cMQIs,
		/*[in,out]*/ MULTI_QI* pMQIs)
	{
		VSL_DEFINE_MOCK_METHOD(QueryMultipleInterfaces)

		VSL_CHECK_VALIDVALUE(cMQIs);

		VSL_SET_VALIDVALUE(pMQIs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMULTIQI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
