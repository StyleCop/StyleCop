/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSASYNCENUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSASYNCENUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAsyncEnumNotImpl :
	public IVsAsyncEnum
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsyncEnumNotImpl)

public:

	typedef IVsAsyncEnum Interface;

	STDMETHOD(AdviseAsyncEnumCallback)(
		/*[in]*/ IVsAsyncEnumCallback* /*pIVsAsyncEnumCallback*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseAsyncEnumCallback)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Stop)(
		/*[in]*/ BOOL /*fSync*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAsyncEnumMockImpl :
	public IVsAsyncEnum,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsyncEnumMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAsyncEnumMockImpl)

	typedef IVsAsyncEnum Interface;
	struct AdviseAsyncEnumCallbackValidValues
	{
		/*[in]*/ IVsAsyncEnumCallback* pIVsAsyncEnumCallback;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseAsyncEnumCallback)(
		/*[in]*/ IVsAsyncEnumCallback* pIVsAsyncEnumCallback,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseAsyncEnumCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsAsyncEnumCallback);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseAsyncEnumCallbackValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseAsyncEnumCallback)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseAsyncEnumCallback)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopValidValues
	{
		/*[in]*/ BOOL fSync;
		HRESULT retValue;
	};

	STDMETHOD(Stop)(
		/*[in]*/ BOOL fSync)
	{
		VSL_DEFINE_MOCK_METHOD(Stop)

		VSL_CHECK_VALIDVALUE(fSync);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSASYNCENUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
