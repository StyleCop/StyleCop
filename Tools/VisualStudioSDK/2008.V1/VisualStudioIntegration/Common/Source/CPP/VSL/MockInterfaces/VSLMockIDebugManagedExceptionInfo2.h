/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMANAGEDEXCEPTIONINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMANAGEDEXCEPTIONINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugManagedExceptionInfo2NotImpl :
	public IDebugManagedExceptionInfo2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugManagedExceptionInfo2NotImpl)

public:

	typedef IDebugManagedExceptionInfo2 Interface;

	STDMETHOD(GetExceptionMessage)(
		/*[out]*/ BSTR* /*pbstrExceptionMessage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExceptionBoundaryType)(
		/*[out]*/ EXCEPTION_BOUNDARY_TYPE* /*pType*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugManagedExceptionInfo2MockImpl :
	public IDebugManagedExceptionInfo2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugManagedExceptionInfo2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugManagedExceptionInfo2MockImpl)

	typedef IDebugManagedExceptionInfo2 Interface;
	struct GetExceptionMessageValidValues
	{
		/*[out]*/ BSTR* pbstrExceptionMessage;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionMessage)(
		/*[out]*/ BSTR* pbstrExceptionMessage)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionMessage)

		VSL_SET_VALIDVALUE_BSTR(pbstrExceptionMessage);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExceptionBoundaryTypeValidValues
	{
		/*[out]*/ EXCEPTION_BOUNDARY_TYPE* pType;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionBoundaryType)(
		/*[out]*/ EXCEPTION_BOUNDARY_TYPE* pType)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionBoundaryType)

		VSL_SET_VALIDVALUE(pType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMANAGEDEXCEPTIONINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
