/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEEASSEMBLYREFRESOLVECOMPARER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEEASSEMBLYREFRESOLVECOMPARER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IEEAssemblyRefResolveComparerNotImpl :
	public IEEAssemblyRefResolveComparer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEAssemblyRefResolveComparerNotImpl)

public:

	typedef IEEAssemblyRefResolveComparer Interface;

	STDMETHOD(CompareRef)(
		/*[in]*/ DWORD /*cookieFirst*/,
		/*[in]*/ DWORD /*cookieSecond*/,
		/*[in]*/ DWORD /*cookieTarget*/,
		/*[out]*/ BOOL* /*firstIsBetter*/)VSL_STDMETHOD_NOTIMPL
};

class IEEAssemblyRefResolveComparerMockImpl :
	public IEEAssemblyRefResolveComparer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEAssemblyRefResolveComparerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEEAssemblyRefResolveComparerMockImpl)

	typedef IEEAssemblyRefResolveComparer Interface;
	struct CompareRefValidValues
	{
		/*[in]*/ DWORD cookieFirst;
		/*[in]*/ DWORD cookieSecond;
		/*[in]*/ DWORD cookieTarget;
		/*[out]*/ BOOL* firstIsBetter;
		HRESULT retValue;
	};

	STDMETHOD(CompareRef)(
		/*[in]*/ DWORD cookieFirst,
		/*[in]*/ DWORD cookieSecond,
		/*[in]*/ DWORD cookieTarget,
		/*[out]*/ BOOL* firstIsBetter)
	{
		VSL_DEFINE_MOCK_METHOD(CompareRef)

		VSL_CHECK_VALIDVALUE(cookieFirst);

		VSL_CHECK_VALIDVALUE(cookieSecond);

		VSL_CHECK_VALIDVALUE(cookieTarget);

		VSL_SET_VALIDVALUE(firstIsBetter);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEEASSEMBLYREFRESOLVECOMPARER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
