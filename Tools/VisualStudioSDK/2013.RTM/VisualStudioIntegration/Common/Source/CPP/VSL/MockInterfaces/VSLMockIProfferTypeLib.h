/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROFFERTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROFFERTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "designer.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IProfferTypeLibNotImpl :
	public IProfferTypeLib
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProfferTypeLibNotImpl)

public:

	typedef IProfferTypeLib Interface;

	STDMETHOD(ProfferTypeLib)(
		/*[in]*/ REFGUID /*guidTypeLib*/,
		/*[in]*/ UINT /*uVerMaj*/,
		/*[in]*/ UINT /*uVerMin*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IProfferTypeLibMockImpl :
	public IProfferTypeLib,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProfferTypeLibMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProfferTypeLibMockImpl)

	typedef IProfferTypeLib Interface;
	struct ProfferTypeLibValidValues
	{
		/*[in]*/ REFGUID guidTypeLib;
		/*[in]*/ UINT uVerMaj;
		/*[in]*/ UINT uVerMin;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(ProfferTypeLib)(
		/*[in]*/ REFGUID guidTypeLib,
		/*[in]*/ UINT uVerMaj,
		/*[in]*/ UINT uVerMin,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(ProfferTypeLib)

		VSL_CHECK_VALIDVALUE(guidTypeLib);

		VSL_CHECK_VALIDVALUE(uVerMaj);

		VSL_CHECK_VALIDVALUE(uVerMin);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROFFERTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
