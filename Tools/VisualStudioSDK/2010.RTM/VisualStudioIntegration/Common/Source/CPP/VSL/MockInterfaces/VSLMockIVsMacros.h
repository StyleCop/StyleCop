/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMACROS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMACROS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vbapkg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMacrosNotImpl :
	public IVsMacros
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMacrosNotImpl)

public:

	typedef IVsMacros Interface;

	STDMETHOD(GetMacroCommands)(
		/*[out]*/ SAFEARRAY** /*ppsaMacroCanonicalNames*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMacrosMockImpl :
	public IVsMacros,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMacrosMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMacrosMockImpl)

	typedef IVsMacros Interface;
	struct GetMacroCommandsValidValues
	{
		/*[out]*/ SAFEARRAY** ppsaMacroCanonicalNames;
		HRESULT retValue;
	};

	STDMETHOD(GetMacroCommands)(
		/*[out]*/ SAFEARRAY** ppsaMacroCanonicalNames)
	{
		VSL_DEFINE_MOCK_METHOD(GetMacroCommands)

		VSL_SET_VALIDVALUE_SAFEARRAY(ppsaMacroCanonicalNames);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMACROS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
