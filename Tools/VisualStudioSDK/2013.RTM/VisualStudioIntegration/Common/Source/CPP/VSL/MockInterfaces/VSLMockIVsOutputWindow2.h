/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTPUTWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTPUTWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsOutputWindow2NotImpl :
	public IVsOutputWindow2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindow2NotImpl)

public:

	typedef IVsOutputWindow2 Interface;

	STDMETHOD(GetActivePaneGUID)(
		/*[out]*/ GUID* /*pguidPane*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutputWindow2MockImpl :
	public IVsOutputWindow2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindow2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutputWindow2MockImpl)

	typedef IVsOutputWindow2 Interface;
	struct GetActivePaneGUIDValidValues
	{
		/*[out]*/ GUID* pguidPane;
		HRESULT retValue;
	};

	STDMETHOD(GetActivePaneGUID)(
		/*[out]*/ GUID* pguidPane)
	{
		VSL_DEFINE_MOCK_METHOD(GetActivePaneGUID)

		VSL_SET_VALIDVALUE(pguidPane);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTPUTWINDOW2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
