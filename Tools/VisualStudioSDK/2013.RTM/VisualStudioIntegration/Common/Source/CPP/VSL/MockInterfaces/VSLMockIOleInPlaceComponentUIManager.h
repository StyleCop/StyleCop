/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "oleipc.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleInPlaceComponentUIManagerNotImpl :
	public IOleInPlaceComponentUIManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceComponentUIManagerNotImpl)

public:

	typedef IOleInPlaceComponentUIManager Interface;

	STDMETHOD(UIActivateForMe)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidActive*/,
		/*[in]*/ IOleInPlaceActiveObject* /*pIPActObj*/,
		/*[in]*/ IOleCommandTarget* /*pCmdTrgtActive*/,
		/*[in]*/ ULONG /*cCmdGrpId*/,
		/*[in]*/ LONG* /*rgnCmdGrpId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateUI)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ BOOL /*fImmediateUpdate*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetActiveUI)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsid*/,
		/*[in]*/ ULONG /*cCmdGrpId*/,
		/*[in]*/ LONG* /*rgnCmdGrpId*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE OnUIComponentEnterState(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ DWORD /*dwStateId*/,
		/*[in]*/ DWORD /*dwReserved*/){ return ; }

	virtual BOOL STDMETHODCALLTYPE FOnUIComponentExitState(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ DWORD /*dwStateId*/,
		/*[in]*/ DWORD /*dwReserved*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FUIComponentInState(
		/*[in]*/ DWORD /*dwStateId*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FContinueIdle(){ return BOOL(); }
};

class IOleInPlaceComponentUIManagerMockImpl :
	public IOleInPlaceComponentUIManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceComponentUIManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceComponentUIManagerMockImpl)

	typedef IOleInPlaceComponentUIManager Interface;
	struct UIActivateForMeValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidActive;
		/*[in]*/ IOleInPlaceActiveObject* pIPActObj;
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive;
		/*[in]*/ ULONG cCmdGrpId;
		/*[in]*/ LONG* rgnCmdGrpId;
		HRESULT retValue;
	};

	STDMETHOD(UIActivateForMe)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidActive,
		/*[in]*/ IOleInPlaceActiveObject* pIPActObj,
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive,
		/*[in]*/ ULONG cCmdGrpId,
		/*[in]*/ LONG* rgnCmdGrpId)
	{
		VSL_DEFINE_MOCK_METHOD(UIActivateForMe)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidActive);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIPActObj);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdTrgtActive);

		VSL_CHECK_VALIDVALUE(cCmdGrpId);

		VSL_CHECK_VALIDVALUE_POINTER(rgnCmdGrpId);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateUIValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ BOOL fImmediateUpdate;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(UpdateUI)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ BOOL fImmediateUpdate,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateUI)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(fImmediateUpdate);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetActiveUIValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsid;
		/*[in]*/ ULONG cCmdGrpId;
		/*[in]*/ LONG* rgnCmdGrpId;
		HRESULT retValue;
	};

	STDMETHOD(SetActiveUI)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsid,
		/*[in]*/ ULONG cCmdGrpId,
		/*[in]*/ LONG* rgnCmdGrpId)
	{
		VSL_DEFINE_MOCK_METHOD(SetActiveUI)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsid);

		VSL_CHECK_VALIDVALUE(cCmdGrpId);

		VSL_CHECK_VALIDVALUE_POINTER(rgnCmdGrpId);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUIComponentEnterStateValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ DWORD dwStateId;
		/*[in]*/ DWORD dwReserved;
	};

	virtual void _stdcall OnUIComponentEnterState(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ DWORD dwStateId,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnUIComponentEnterState)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(dwStateId);

		VSL_CHECK_VALIDVALUE(dwReserved);

	}
	struct FOnUIComponentExitStateValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ DWORD dwStateId;
		/*[in]*/ DWORD dwReserved;
		BOOL retValue;
	};

	virtual BOOL _stdcall FOnUIComponentExitState(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ DWORD dwStateId,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(FOnUIComponentExitState)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(dwStateId);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct FUIComponentInStateValidValues
	{
		/*[in]*/ DWORD dwStateId;
		BOOL retValue;
	};

	virtual BOOL _stdcall FUIComponentInState(
		/*[in]*/ DWORD dwStateId)
	{
		VSL_DEFINE_MOCK_METHOD(FUIComponentInState)

		VSL_CHECK_VALIDVALUE(dwStateId);

		VSL_RETURN_VALIDVALUES();
	}
	struct FContinueIdleValidValues
	{
		BOOL retValue;
	};

	virtual BOOL _stdcall FContinueIdle()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FContinueIdle)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEINPLACECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
