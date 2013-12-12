/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMANDWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMANDWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCommandWindow2NotImpl :
	public IVsCommandWindow2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindow2NotImpl)

public:

	typedef IVsCommandWindow2 Interface;

	STDMETHOD(SetMode)(
		/*[in]*/ COMMANDWINDOWMODE2 /*mode*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCommandWindow2MockImpl :
	public IVsCommandWindow2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindow2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommandWindow2MockImpl)

	typedef IVsCommandWindow2 Interface;
	struct SetModeValidValues
	{
		/*[in]*/ COMMANDWINDOWMODE2 mode;
		HRESULT retValue;
	};

	STDMETHOD(SetMode)(
		/*[in]*/ COMMANDWINDOWMODE2 mode)
	{
		VSL_DEFINE_MOCK_METHOD(SetMode)

		VSL_CHECK_VALIDVALUE(mode);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMANDWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
