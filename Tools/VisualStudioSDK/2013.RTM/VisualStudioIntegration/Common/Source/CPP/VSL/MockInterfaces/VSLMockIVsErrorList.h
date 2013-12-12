/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSERRORLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSERRORLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsErrorListNotImpl :
	public IVsErrorList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsErrorListNotImpl)

public:

	typedef IVsErrorList Interface;

	STDMETHOD(BringToFront)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ForceShowErrors)()VSL_STDMETHOD_NOTIMPL
};

class IVsErrorListMockImpl :
	public IVsErrorList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsErrorListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsErrorListMockImpl)

	typedef IVsErrorList Interface;
	struct BringToFrontValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BringToFront)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BringToFront)

		VSL_RETURN_VALIDVALUES();
	}
	struct ForceShowErrorsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ForceShowErrors)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ForceShowErrors)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSERRORLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
