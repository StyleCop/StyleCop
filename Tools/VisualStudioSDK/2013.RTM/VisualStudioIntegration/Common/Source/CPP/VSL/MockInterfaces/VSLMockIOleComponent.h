/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "olecm.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleComponentNotImpl :
	public IOleComponent
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentNotImpl)

public:

	typedef IOleComponent Interface;

	virtual BOOL STDMETHODCALLTYPE FReserved1(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ UINT /*message*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FPreTranslateMessage(
		/*[in,out]*/ MSG* /*pMsg*/){ return BOOL(); }

	virtual void STDMETHODCALLTYPE OnEnterState(
		/*[in]*/ OLECSTATE /*uStateID*/,
		/*[in]*/ BOOL /*fEnter*/){ return ; }

	virtual void STDMETHODCALLTYPE OnAppActivate(
		/*[in]*/ BOOL /*fActive*/,
		/*[in]*/ DWORD /*dwOtherThreadID*/){ return ; }

	virtual void STDMETHODCALLTYPE OnLoseActivation(){ return ; }

	virtual void STDMETHODCALLTYPE OnActivationChange(
		/*[in]*/ IOleComponent* /*pic*/,
		/*[in]*/ BOOL /*fSameComponent*/,
		/*[in]*/ const OLECRINFO* /*pcrinfo*/,
		/*[in]*/ BOOL /*fHostIsActivating*/,
		/*[in]*/ const OLECHOSTINFO* /*pchostinfo*/,
		/*[in]*/ DWORD /*dwReserved*/){ return ; }

	virtual BOOL STDMETHODCALLTYPE FDoIdle(
		/*[in]*/ OLEIDLEF /*grfidlef*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FContinueMessageLoop(
		/*[in]*/ OLELOOP /*uReason*/,
		/*[in]*/ void* /*pvLoopData*/,
		/*[in]*/ MSG* /*pMsgPeeked*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FQueryTerminate(
		/*[in]*/ BOOL /*fPromptUser*/){ return BOOL(); }

	virtual void STDMETHODCALLTYPE Terminate(){ return ; }

	virtual HWND STDMETHODCALLTYPE HwndGetWindow(
		/*[in]*/ OLECWINDOW /*dwWhich*/,
		/*[in]*/ DWORD /*dwReserved*/){ return HWND(); }
};

class IOleComponentMockImpl :
	public IOleComponent,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleComponentMockImpl)

	typedef IOleComponent Interface;
	struct FReserved1ValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ UINT message;
		/*[in]*/ WPARAM wParam;
		/*[in]*/ LPARAM lParam;
		BOOL retValue;
	};

	virtual BOOL _stdcall FReserved1(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ UINT message,
		/*[in]*/ WPARAM wParam,
		/*[in]*/ LPARAM lParam)
	{
		VSL_DEFINE_MOCK_METHOD(FReserved1)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(message);

		VSL_CHECK_VALIDVALUE(wParam);

		VSL_CHECK_VALIDVALUE(lParam);

		VSL_RETURN_VALIDVALUES();
	}
	struct FPreTranslateMessageValidValues
	{
		/*[in,out]*/ MSG* pMsg;
		BOOL retValue;
	};

	virtual BOOL _stdcall FPreTranslateMessage(
		/*[in,out]*/ MSG* pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(FPreTranslateMessage)

		VSL_SET_VALIDVALUE(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEnterStateValidValues
	{
		/*[in]*/ OLECSTATE uStateID;
		/*[in]*/ BOOL fEnter;
	};

	virtual void _stdcall OnEnterState(
		/*[in]*/ OLECSTATE uStateID,
		/*[in]*/ BOOL fEnter)
	{
		VSL_DEFINE_MOCK_METHOD(OnEnterState)

		VSL_CHECK_VALIDVALUE(uStateID);

		VSL_CHECK_VALIDVALUE(fEnter);

	}
	struct OnAppActivateValidValues
	{
		/*[in]*/ BOOL fActive;
		/*[in]*/ DWORD dwOtherThreadID;
	};

	virtual void _stdcall OnAppActivate(
		/*[in]*/ BOOL fActive,
		/*[in]*/ DWORD dwOtherThreadID)
	{
		VSL_DEFINE_MOCK_METHOD(OnAppActivate)

		VSL_CHECK_VALIDVALUE(fActive);

		VSL_CHECK_VALIDVALUE(dwOtherThreadID);

	}

	virtual void _stdcall OnLoseActivation()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(OnLoseActivation)

	}
	struct OnActivationChangeValidValues
	{
		/*[in]*/ IOleComponent* pic;
		/*[in]*/ BOOL fSameComponent;
		/*[in]*/ OLECRINFO* pcrinfo;
		/*[in]*/ BOOL fHostIsActivating;
		/*[in]*/ OLECHOSTINFO* pchostinfo;
		/*[in]*/ DWORD dwReserved;
	};

	virtual void _stdcall OnActivationChange(
		/*[in]*/ IOleComponent* pic,
		/*[in]*/ BOOL fSameComponent,
		/*[in]*/ const OLECRINFO* pcrinfo,
		/*[in]*/ BOOL fHostIsActivating,
		/*[in]*/ const OLECHOSTINFO* pchostinfo,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnActivationChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pic);

		VSL_CHECK_VALIDVALUE(fSameComponent);

		VSL_CHECK_VALIDVALUE_POINTER(pcrinfo);

		VSL_CHECK_VALIDVALUE(fHostIsActivating);

		VSL_CHECK_VALIDVALUE_POINTER(pchostinfo);

		VSL_CHECK_VALIDVALUE(dwReserved);

	}
	struct FDoIdleValidValues
	{
		/*[in]*/ OLEIDLEF grfidlef;
		BOOL retValue;
	};

	virtual BOOL _stdcall FDoIdle(
		/*[in]*/ OLEIDLEF grfidlef)
	{
		VSL_DEFINE_MOCK_METHOD(FDoIdle)

		VSL_CHECK_VALIDVALUE(grfidlef);

		VSL_RETURN_VALIDVALUES();
	}
	struct FContinueMessageLoopValidValues
	{
		/*[in]*/ OLELOOP uReason;
		/*[in]*/ void* pvLoopData;
		/*[in]*/ MSG* pMsgPeeked;
		BOOL retValue;
		size_t pvLoopData_size_in_bytes;
	};

	virtual BOOL _stdcall FContinueMessageLoop(
		/*[in]*/ OLELOOP uReason,
		/*[in]*/ void* pvLoopData,
		/*[in]*/ MSG* pMsgPeeked)
	{
		VSL_DEFINE_MOCK_METHOD(FContinueMessageLoop)

		VSL_CHECK_VALIDVALUE(uReason);

		VSL_CHECK_VALIDVALUE_PVOID(pvLoopData);

		VSL_CHECK_VALIDVALUE_POINTER(pMsgPeeked);

		VSL_RETURN_VALIDVALUES();
	}
	struct FQueryTerminateValidValues
	{
		/*[in]*/ BOOL fPromptUser;
		BOOL retValue;
	};

	virtual BOOL _stdcall FQueryTerminate(
		/*[in]*/ BOOL fPromptUser)
	{
		VSL_DEFINE_MOCK_METHOD(FQueryTerminate)

		VSL_CHECK_VALIDVALUE(fPromptUser);

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall Terminate()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(Terminate)

	}
	struct HwndGetWindowValidValues
	{
		/*[in]*/ OLECWINDOW dwWhich;
		/*[in]*/ DWORD dwReserved;
		HWND retValue;
	};

	virtual HWND _stdcall HwndGetWindow(
		/*[in]*/ OLECWINDOW dwWhich,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(HwndGetWindow)

		VSL_CHECK_VALIDVALUE(dwWhich);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
