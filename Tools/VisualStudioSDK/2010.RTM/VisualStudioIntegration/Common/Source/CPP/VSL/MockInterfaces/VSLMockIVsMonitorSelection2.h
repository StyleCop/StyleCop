/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMONITORSELECTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMONITORSELECTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMonitorSelection2NotImpl :
	public IVsMonitorSelection2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorSelection2NotImpl)

public:

	typedef IVsMonitorSelection2 Interface;

	STDMETHOD(GetElementID)(
		/*[in]*/ REFGUID /*rguidElement*/,
		/*[out]*/ VSSELELEMID* /*pElementId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEmptySelectionContext)(
		/*[out]*/ IVsTrackSelectionEx** /*ppEmptySelCtxt*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMonitorSelection2MockImpl :
	public IVsMonitorSelection2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorSelection2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMonitorSelection2MockImpl)

	typedef IVsMonitorSelection2 Interface;
	struct GetElementIDValidValues
	{
		/*[in]*/ REFGUID rguidElement;
		/*[out]*/ VSSELELEMID* pElementId;
		HRESULT retValue;
	};

	STDMETHOD(GetElementID)(
		/*[in]*/ REFGUID rguidElement,
		/*[out]*/ VSSELELEMID* pElementId)
	{
		VSL_DEFINE_MOCK_METHOD(GetElementID)

		VSL_CHECK_VALIDVALUE(rguidElement);

		VSL_SET_VALIDVALUE(pElementId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEmptySelectionContextValidValues
	{
		/*[out]*/ IVsTrackSelectionEx** ppEmptySelCtxt;
		HRESULT retValue;
	};

	STDMETHOD(GetEmptySelectionContext)(
		/*[out]*/ IVsTrackSelectionEx** ppEmptySelCtxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetEmptySelectionContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppEmptySelCtxt);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMONITORSELECTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
