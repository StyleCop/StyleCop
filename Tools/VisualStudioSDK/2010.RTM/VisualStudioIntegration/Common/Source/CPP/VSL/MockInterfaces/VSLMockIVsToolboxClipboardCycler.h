/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOXCLIPBOARDCYCLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOXCLIPBOARDCYCLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsToolboxClipboardCyclerNotImpl :
	public IVsToolboxClipboardCycler
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxClipboardCyclerNotImpl)

public:

	typedef IVsToolboxClipboardCycler Interface;

	STDMETHOD(AreDataObjectsAvailable)(
		/*[in]*/ IVsToolboxUser* /*pTarget*/,
		/*[out]*/ BOOL* /*pbItemsAvailable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAndSelectNextDataObject)(
		/*[in]*/ IVsToolboxUser* /*pTarget*/,
		/*[out]*/ IDataObject** /*ppDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginCycle)()VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxClipboardCyclerMockImpl :
	public IVsToolboxClipboardCycler,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxClipboardCyclerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxClipboardCyclerMockImpl)

	typedef IVsToolboxClipboardCycler Interface;
	struct AreDataObjectsAvailableValidValues
	{
		/*[in]*/ IVsToolboxUser* pTarget;
		/*[out]*/ BOOL* pbItemsAvailable;
		HRESULT retValue;
	};

	STDMETHOD(AreDataObjectsAvailable)(
		/*[in]*/ IVsToolboxUser* pTarget,
		/*[out]*/ BOOL* pbItemsAvailable)
	{
		VSL_DEFINE_MOCK_METHOD(AreDataObjectsAvailable)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTarget);

		VSL_SET_VALIDVALUE(pbItemsAvailable);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAndSelectNextDataObjectValidValues
	{
		/*[in]*/ IVsToolboxUser* pTarget;
		/*[out]*/ IDataObject** ppDO;
		HRESULT retValue;
	};

	STDMETHOD(GetAndSelectNextDataObject)(
		/*[in]*/ IVsToolboxUser* pTarget,
		/*[out]*/ IDataObject** ppDO)
	{
		VSL_DEFINE_MOCK_METHOD(GetAndSelectNextDataObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTarget);

		VSL_SET_VALIDVALUE_INTERFACE(ppDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginCycleValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeginCycle)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeginCycle)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOXCLIPBOARDCYCLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
