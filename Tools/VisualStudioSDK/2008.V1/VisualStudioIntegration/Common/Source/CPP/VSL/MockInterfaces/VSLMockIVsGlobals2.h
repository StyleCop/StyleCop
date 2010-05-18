/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSGLOBALS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSGLOBALS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsGlobals2NotImpl :
	public IVsGlobals2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGlobals2NotImpl)

public:

	typedef IVsGlobals2 Interface;

	STDMETHOD(Load)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Empty)()VSL_STDMETHOD_NOTIMPL
};

class IVsGlobals2MockImpl :
	public IVsGlobals2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGlobals2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsGlobals2MockImpl)

	typedef IVsGlobals2 Interface;
	struct LoadValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Load)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Load)

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Save)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Save)

		VSL_RETURN_VALIDVALUES();
	}
	struct EmptyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Empty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Empty)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSGLOBALS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
