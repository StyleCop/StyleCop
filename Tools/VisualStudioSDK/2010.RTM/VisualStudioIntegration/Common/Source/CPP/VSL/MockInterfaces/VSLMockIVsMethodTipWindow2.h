/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMETHODTIPWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMETHODTIPWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMethodTipWindow2NotImpl :
	public IVsMethodTipWindow2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodTipWindow2NotImpl)

public:

	typedef IVsMethodTipWindow2 Interface;

	STDMETHOD(NextMethod)(
		/*[out]*/ BOOL* /*pfSuccess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrevMethod)(
		/*[out]*/ BOOL* /*pfSuccess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOverloadCount)(
		/*[in]*/ long* /*piCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMethodTipWindow2MockImpl :
	public IVsMethodTipWindow2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodTipWindow2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMethodTipWindow2MockImpl)

	typedef IVsMethodTipWindow2 Interface;
	struct NextMethodValidValues
	{
		/*[out]*/ BOOL* pfSuccess;
		HRESULT retValue;
	};

	STDMETHOD(NextMethod)(
		/*[out]*/ BOOL* pfSuccess)
	{
		VSL_DEFINE_MOCK_METHOD(NextMethod)

		VSL_SET_VALIDVALUE(pfSuccess);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrevMethodValidValues
	{
		/*[out]*/ BOOL* pfSuccess;
		HRESULT retValue;
	};

	STDMETHOD(PrevMethod)(
		/*[out]*/ BOOL* pfSuccess)
	{
		VSL_DEFINE_MOCK_METHOD(PrevMethod)

		VSL_SET_VALIDVALUE(pfSuccess);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOverloadCountValidValues
	{
		/*[in]*/ long* piCount;
		HRESULT retValue;
	};

	STDMETHOD(GetOverloadCount)(
		/*[in]*/ long* piCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetOverloadCount)

		VSL_CHECK_VALIDVALUE_POINTER(piCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMETHODTIPWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
