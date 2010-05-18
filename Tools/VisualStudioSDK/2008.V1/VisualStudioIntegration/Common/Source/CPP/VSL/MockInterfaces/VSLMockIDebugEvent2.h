/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEvent2NotImpl :
	public IDebugEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEvent2NotImpl)

public:

	typedef IDebugEvent2 Interface;

	STDMETHOD(GetAttributes)(
		/*[out]*/ DWORD* /*pdwAttrib*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugEvent2MockImpl :
	public IDebugEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEvent2MockImpl)

	typedef IDebugEvent2 Interface;
	struct GetAttributesValidValues
	{
		/*[out]*/ DWORD* pdwAttrib;
		HRESULT retValue;
	};

	STDMETHOD(GetAttributes)(
		/*[out]*/ DWORD* pdwAttrib)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttributes)

		VSL_SET_VALIDVALUE(pdwAttrib);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
