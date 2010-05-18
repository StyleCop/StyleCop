/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCHANGETRACKINGUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCHANGETRACKINGUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsChangeTrackingUndoManagerNotImpl :
	public IVsChangeTrackingUndoManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsChangeTrackingUndoManagerNotImpl)

public:

	typedef IVsChangeTrackingUndoManager Interface;

	STDMETHOD(MarkCleanState)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryCleanState)(
		/*[out]*/ BOOL* /*pfClean*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseTrackingClient)(
		/*[in]*/ IVsUndoTrackingEvents* /*pUndoTrackingEvents*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseTrackingClient)()VSL_STDMETHOD_NOTIMPL
};

class IVsChangeTrackingUndoManagerMockImpl :
	public IVsChangeTrackingUndoManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsChangeTrackingUndoManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsChangeTrackingUndoManagerMockImpl)

	typedef IVsChangeTrackingUndoManager Interface;
	struct MarkCleanStateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(MarkCleanState)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(MarkCleanState)

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCleanStateValidValues
	{
		/*[out]*/ BOOL* pfClean;
		HRESULT retValue;
	};

	STDMETHOD(QueryCleanState)(
		/*[out]*/ BOOL* pfClean)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCleanState)

		VSL_SET_VALIDVALUE(pfClean);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseTrackingClientValidValues
	{
		/*[in]*/ IVsUndoTrackingEvents* pUndoTrackingEvents;
		HRESULT retValue;
	};

	STDMETHOD(AdviseTrackingClient)(
		/*[in]*/ IVsUndoTrackingEvents* pUndoTrackingEvents)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseTrackingClient)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUndoTrackingEvents);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseTrackingClientValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnadviseTrackingClient)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnadviseTrackingClient)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCHANGETRACKINGUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
