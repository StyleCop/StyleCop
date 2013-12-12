/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPOUNDVIEWCHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPOUNDVIEWCHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCompoundViewChangeNotImpl :
	public IVsCompoundViewChange
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompoundViewChangeNotImpl)

public:

	typedef IVsCompoundViewChange Interface;

	STDMETHOD(OpenCompoundViewChange)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseCompoundViewChange)()VSL_STDMETHOD_NOTIMPL
};

class IVsCompoundViewChangeMockImpl :
	public IVsCompoundViewChange,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompoundViewChangeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCompoundViewChangeMockImpl)

	typedef IVsCompoundViewChange Interface;
	struct OpenCompoundViewChangeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OpenCompoundViewChange)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OpenCompoundViewChange)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseCompoundViewChangeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseCompoundViewChange)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseCompoundViewChange)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPOUNDVIEWCHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
