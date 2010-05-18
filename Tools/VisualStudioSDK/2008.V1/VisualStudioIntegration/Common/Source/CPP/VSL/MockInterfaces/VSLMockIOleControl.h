/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleControlNotImpl :
	public IOleControl
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleControlNotImpl)

public:

	typedef IOleControl Interface;

	STDMETHOD(GetControlInfo)(
		/*[out]*/ CONTROLINFO* /*pCI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnMnemonic)(
		/*[in]*/ MSG* /*pMsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAmbientPropertyChange)(
		/*[in]*/ DISPID /*dispID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreezeEvents)(
		/*[in]*/ BOOL /*bFreeze*/)VSL_STDMETHOD_NOTIMPL
};

class IOleControlMockImpl :
	public IOleControl,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleControlMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleControlMockImpl)

	typedef IOleControl Interface;
	struct GetControlInfoValidValues
	{
		/*[out]*/ CONTROLINFO* pCI;
		HRESULT retValue;
	};

	STDMETHOD(GetControlInfo)(
		/*[out]*/ CONTROLINFO* pCI)
	{
		VSL_DEFINE_MOCK_METHOD(GetControlInfo)

		VSL_SET_VALIDVALUE(pCI);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnMnemonicValidValues
	{
		/*[in]*/ MSG* pMsg;
		HRESULT retValue;
	};

	STDMETHOD(OnMnemonic)(
		/*[in]*/ MSG* pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(OnMnemonic)

		VSL_CHECK_VALIDVALUE_POINTER(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAmbientPropertyChangeValidValues
	{
		/*[in]*/ DISPID dispID;
		HRESULT retValue;
	};

	STDMETHOD(OnAmbientPropertyChange)(
		/*[in]*/ DISPID dispID)
	{
		VSL_DEFINE_MOCK_METHOD(OnAmbientPropertyChange)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreezeEventsValidValues
	{
		/*[in]*/ BOOL bFreeze;
		HRESULT retValue;
	};

	STDMETHOD(FreezeEvents)(
		/*[in]*/ BOOL bFreeze)
	{
		VSL_DEFINE_MOCK_METHOD(FreezeEvents)

		VSL_CHECK_VALIDVALUE(bFreeze);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
