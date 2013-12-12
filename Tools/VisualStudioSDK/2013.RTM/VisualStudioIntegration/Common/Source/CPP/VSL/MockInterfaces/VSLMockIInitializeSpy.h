/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IINITIALIZESPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IINITIALIZESPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IInitializeSpyNotImpl :
	public IInitializeSpy
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IInitializeSpyNotImpl)

public:

	typedef IInitializeSpy Interface;

	STDMETHOD(PreInitialize)(
		/*[in]*/ DWORD /*dwCoInit*/,
		/*[in]*/ DWORD /*dwCurThreadAptRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PostInitialize)(
		/*[in]*/ HRESULT /*hrCoInit*/,
		/*[in]*/ DWORD /*dwCoInit*/,
		/*[in]*/ DWORD /*dwNewThreadAptRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PreUninitialize)(
		/*[in]*/ DWORD /*dwCurThreadAptRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PostUninitialize)(
		/*[in]*/ DWORD /*dwNewThreadAptRefs*/)VSL_STDMETHOD_NOTIMPL
};

class IInitializeSpyMockImpl :
	public IInitializeSpy,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IInitializeSpyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IInitializeSpyMockImpl)

	typedef IInitializeSpy Interface;
	struct PreInitializeValidValues
	{
		/*[in]*/ DWORD dwCoInit;
		/*[in]*/ DWORD dwCurThreadAptRefs;
		HRESULT retValue;
	};

	STDMETHOD(PreInitialize)(
		/*[in]*/ DWORD dwCoInit,
		/*[in]*/ DWORD dwCurThreadAptRefs)
	{
		VSL_DEFINE_MOCK_METHOD(PreInitialize)

		VSL_CHECK_VALIDVALUE(dwCoInit);

		VSL_CHECK_VALIDVALUE(dwCurThreadAptRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostInitializeValidValues
	{
		/*[in]*/ HRESULT hrCoInit;
		/*[in]*/ DWORD dwCoInit;
		/*[in]*/ DWORD dwNewThreadAptRefs;
		HRESULT retValue;
	};

	STDMETHOD(PostInitialize)(
		/*[in]*/ HRESULT hrCoInit,
		/*[in]*/ DWORD dwCoInit,
		/*[in]*/ DWORD dwNewThreadAptRefs)
	{
		VSL_DEFINE_MOCK_METHOD(PostInitialize)

		VSL_CHECK_VALIDVALUE(hrCoInit);

		VSL_CHECK_VALIDVALUE(dwCoInit);

		VSL_CHECK_VALIDVALUE(dwNewThreadAptRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreUninitializeValidValues
	{
		/*[in]*/ DWORD dwCurThreadAptRefs;
		HRESULT retValue;
	};

	STDMETHOD(PreUninitialize)(
		/*[in]*/ DWORD dwCurThreadAptRefs)
	{
		VSL_DEFINE_MOCK_METHOD(PreUninitialize)

		VSL_CHECK_VALIDVALUE(dwCurThreadAptRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostUninitializeValidValues
	{
		/*[in]*/ DWORD dwNewThreadAptRefs;
		HRESULT retValue;
	};

	STDMETHOD(PostUninitialize)(
		/*[in]*/ DWORD dwNewThreadAptRefs)
	{
		VSL_DEFINE_MOCK_METHOD(PostUninitialize)

		VSL_CHECK_VALIDVALUE(dwNewThreadAptRefs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IINITIALIZESPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
