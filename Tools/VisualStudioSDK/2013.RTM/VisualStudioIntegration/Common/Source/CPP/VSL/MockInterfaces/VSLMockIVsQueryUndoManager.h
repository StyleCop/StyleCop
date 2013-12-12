/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSQUERYUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSQUERYUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsQueryUndoManagerNotImpl :
	public IVsQueryUndoManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryUndoManagerNotImpl)

public:

	typedef IVsQueryUndoManager Interface;

	STDMETHOD(IsLinkedTransactionOpen)(
		/*[out]*/ BOOL* /*pbTransactionIsOpen*/)VSL_STDMETHOD_NOTIMPL
};

class IVsQueryUndoManagerMockImpl :
	public IVsQueryUndoManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryUndoManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsQueryUndoManagerMockImpl)

	typedef IVsQueryUndoManager Interface;
	struct IsLinkedTransactionOpenValidValues
	{
		/*[out]*/ BOOL* pbTransactionIsOpen;
		HRESULT retValue;
	};

	STDMETHOD(IsLinkedTransactionOpen)(
		/*[out]*/ BOOL* pbTransactionIsOpen)
	{
		VSL_DEFINE_MOCK_METHOD(IsLinkedTransactionOpen)

		VSL_SET_VALIDVALUE(pbTransactionIsOpen);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSQUERYUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
