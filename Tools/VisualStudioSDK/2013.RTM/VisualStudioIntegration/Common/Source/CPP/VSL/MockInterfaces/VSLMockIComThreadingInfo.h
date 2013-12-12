/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICOMTHREADINGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICOMTHREADINGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IComThreadingInfoNotImpl :
	public IComThreadingInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IComThreadingInfoNotImpl)

public:

	typedef IComThreadingInfo Interface;

	STDMETHOD(GetCurrentApartmentType)(
		/*[out]*/ APTTYPE* /*pAptType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentThreadType)(
		/*[out]*/ THDTYPE* /*pThreadType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentLogicalThreadId)(
		/*[out]*/ GUID* /*pguidLogicalThreadId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCurrentLogicalThreadId)(
		/*[in]*/ REFGUID /*rguid*/)VSL_STDMETHOD_NOTIMPL
};

class IComThreadingInfoMockImpl :
	public IComThreadingInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IComThreadingInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IComThreadingInfoMockImpl)

	typedef IComThreadingInfo Interface;
	struct GetCurrentApartmentTypeValidValues
	{
		/*[out]*/ APTTYPE* pAptType;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentApartmentType)(
		/*[out]*/ APTTYPE* pAptType)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentApartmentType)

		VSL_SET_VALIDVALUE(pAptType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentThreadTypeValidValues
	{
		/*[out]*/ THDTYPE* pThreadType;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentThreadType)(
		/*[out]*/ THDTYPE* pThreadType)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentThreadType)

		VSL_SET_VALIDVALUE(pThreadType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentLogicalThreadIdValidValues
	{
		/*[out]*/ GUID* pguidLogicalThreadId;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentLogicalThreadId)(
		/*[out]*/ GUID* pguidLogicalThreadId)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentLogicalThreadId)

		VSL_SET_VALIDVALUE(pguidLogicalThreadId);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCurrentLogicalThreadIdValidValues
	{
		/*[in]*/ REFGUID rguid;
		HRESULT retValue;
	};

	STDMETHOD(SetCurrentLogicalThreadId)(
		/*[in]*/ REFGUID rguid)
	{
		VSL_DEFINE_MOCK_METHOD(SetCurrentLogicalThreadId)

		VSL_CHECK_VALIDVALUE(rguid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICOMTHREADINGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
