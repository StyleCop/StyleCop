/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLINKEDUNDOCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLINKEDUNDOCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLinkedUndoClientNotImpl :
	public IVsLinkedUndoClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLinkedUndoClientNotImpl)

public:

	typedef IVsLinkedUndoClient Interface;

	STDMETHOD(OnInterveningUnitBlockingLinkedUndo)()VSL_STDMETHOD_NOTIMPL
};

class IVsLinkedUndoClientMockImpl :
	public IVsLinkedUndoClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLinkedUndoClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLinkedUndoClientMockImpl)

	typedef IVsLinkedUndoClient Interface;
	struct OnInterveningUnitBlockingLinkedUndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnInterveningUnitBlockingLinkedUndo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnInterveningUnitBlockingLinkedUndo)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLINKEDUNDOCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
