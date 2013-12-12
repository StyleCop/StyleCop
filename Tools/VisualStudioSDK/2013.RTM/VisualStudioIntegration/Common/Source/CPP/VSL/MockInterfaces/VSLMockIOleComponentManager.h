/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECOMPONENTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECOMPONENTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleComponentManagerNotImpl :
	public IOleComponentManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentManagerNotImpl)

public:

	typedef IOleComponentManager Interface;

	STDMETHOD(QueryService)(
		/*[in]*/ REFGUID /*guidService*/,
		/*[in]*/ REFIID /*iid*/,
		/*[out]*/ void** /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	virtual BOOL STDMETHODCALLTYPE FReserved1(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ UINT /*message*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FRegisterComponent(
		/*[in]*/ IOleComponent* /*piComponent*/,
		/*[in]*/ const OLECRINFO* /*pcrinfo*/,
		/*[out]*/ DWORD_PTR* /*pdwComponentID*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FRevokeComponent(
		/*[in]*/ DWORD_PTR /*dwComponentID*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FUpdateComponentRegistration(
		/*[in]*/ DWORD_PTR /*dwComponentID*/,
		/*[in]*/ const OLECRINFO* /*pcrinfo*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FOnComponentActivate(
		/*[in]*/ DWORD_PTR /*dwComponentID*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FSetTrackingComponent(
		/*[in]*/ DWORD_PTR /*dwComponentID*/,
		/*[in]*/ BOOL /*fTrack*/){ return BOOL(); }

	virtual void STDMETHODCALLTYPE OnComponentEnterState(
		/*[in]*/ DWORD_PTR /*dwComponentID*/,
		/*[in]*/ OLECSTATE /*uStateID*/,
		/*[in]*/ OLECCONTEXT /*uContext*/,
		/*[in]*/ ULONG /*cpicmExclude*/,
		/*[in]*/ IOleComponentManager** /*rgpicmExclude*/,
		/*[in]*/ DWORD /*dwReserved*/){ return ; }

	virtual BOOL STDMETHODCALLTYPE FOnComponentExitState(
		/*[in]*/ DWORD_PTR /*dwComponentID*/,
		/*[in]*/ OLECSTATE /*uStateID*/,
		/*[in]*/ OLECCONTEXT /*uContext*/,
		/*[in]*/ ULONG /*cpicmExclude*/,
		/*[in]*/ IOleComponentManager** /*rgpicmExclude*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FInState(
		/*[in]*/ OLECSTATE /*uStateID*/,
		/*[in]*/ void* /*pvoid*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FContinueIdle(){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FPushMessageLoop(
		/*[in]*/ DWORD_PTR /*dwComponentID*/,
		/*[in]*/ OLELOOP /*uReason*/,
		/*[in]*/ void* /*pvLoopData*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FCreateSubComponentManager(
		/*[in]*/ IUnknown* /*piunkOuter*/,
		/*[in]*/ IUnknown* /*piunkServProv*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ void** /*ppvObj*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FGetParentComponentManager(
		/*[out]*/ IOleComponentManager** /*ppicm*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FGetActiveComponent(
		/*[in]*/ OLEGAC /*dwgac*/,
		/*[out]*/ IOleComponent** /*ppic*/,
		/*[in,out]*/ OLECRINFO* /*pcrinfo*/,
		/*[in]*/ DWORD /*dwReserved*/){ return BOOL(); }
};

class IOleComponentManagerMockImpl :
	public IOleComponentManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleComponentManagerMockImpl)

	typedef IOleComponentManager Interface;
	struct QueryServiceValidValues
	{
		/*[in]*/ REFGUID guidService;
		/*[in]*/ REFIID iid;
		/*[out]*/ void** ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(QueryService)(
		/*[in]*/ REFGUID guidService,
		/*[in]*/ REFIID iid,
		/*[out]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(QueryService)

		VSL_CHECK_VALIDVALUE(guidService);

		VSL_CHECK_VALIDVALUE(iid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct FRegisterComponentValidValues
	{
		/*[in]*/ IOleComponent* piComponent;
		/*[in]*/ OLECRINFO* pcrinfo;
		/*[out]*/ DWORD_PTR* pdwComponentID;
		BOOL retValue;
	};

	virtual BOOL _stdcall FRegisterComponent(
		/*[in]*/ IOleComponent* piComponent,
		/*[in]*/ const OLECRINFO* pcrinfo,
		/*[out]*/ DWORD_PTR* pdwComponentID)
	{
		VSL_DEFINE_MOCK_METHOD(FRegisterComponent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(piComponent);

		VSL_CHECK_VALIDVALUE_POINTER(pcrinfo);

		VSL_SET_VALIDVALUE(pdwComponentID);

		VSL_RETURN_VALIDVALUES();
	}
	struct FRevokeComponentValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		BOOL retValue;
	};

	virtual BOOL _stdcall FRevokeComponent(
		/*[in]*/ DWORD_PTR dwComponentID)
	{
		VSL_DEFINE_MOCK_METHOD(FRevokeComponent)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_RETURN_VALIDVALUES();
	}
	struct FUpdateComponentRegistrationValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		/*[in]*/ OLECRINFO* pcrinfo;
		BOOL retValue;
	};

	virtual BOOL _stdcall FUpdateComponentRegistration(
		/*[in]*/ DWORD_PTR dwComponentID,
		/*[in]*/ const OLECRINFO* pcrinfo)
	{
		VSL_DEFINE_MOCK_METHOD(FUpdateComponentRegistration)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_CHECK_VALIDVALUE_POINTER(pcrinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct FOnComponentActivateValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		BOOL retValue;
	};

	virtual BOOL _stdcall FOnComponentActivate(
		/*[in]*/ DWORD_PTR dwComponentID)
	{
		VSL_DEFINE_MOCK_METHOD(FOnComponentActivate)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_RETURN_VALIDVALUES();
	}
	struct FSetTrackingComponentValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		/*[in]*/ BOOL fTrack;
		BOOL retValue;
	};

	virtual BOOL _stdcall FSetTrackingComponent(
		/*[in]*/ DWORD_PTR dwComponentID,
		/*[in]*/ BOOL fTrack)
	{
		VSL_DEFINE_MOCK_METHOD(FSetTrackingComponent)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_CHECK_VALIDVALUE(fTrack);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnComponentEnterStateValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		/*[in]*/ OLECSTATE uStateID;
		/*[in]*/ OLECCONTEXT uContext;
		/*[in]*/ ULONG cpicmExclude;
		/*[in]*/ IOleComponentManager** rgpicmExclude;
		/*[in]*/ DWORD dwReserved;
	};

	virtual void _stdcall OnComponentEnterState(
		/*[in]*/ DWORD_PTR dwComponentID,
		/*[in]*/ OLECSTATE uStateID,
		/*[in]*/ OLECCONTEXT uContext,
		/*[in]*/ ULONG cpicmExclude,
		/*[in]*/ IOleComponentManager** rgpicmExclude,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnComponentEnterState)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_CHECK_VALIDVALUE(uStateID);

		VSL_CHECK_VALIDVALUE(uContext);

		VSL_CHECK_VALIDVALUE(cpicmExclude);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(rgpicmExclude);

		VSL_CHECK_VALIDVALUE(dwReserved);

	}
	struct FOnComponentExitStateValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		/*[in]*/ OLECSTATE uStateID;
		/*[in]*/ OLECCONTEXT uContext;
		/*[in]*/ ULONG cpicmExclude;
		/*[in]*/ IOleComponentManager** rgpicmExclude;
		BOOL retValue;
	};

	virtual BOOL _stdcall FOnComponentExitState(
		/*[in]*/ DWORD_PTR dwComponentID,
		/*[in]*/ OLECSTATE uStateID,
		/*[in]*/ OLECCONTEXT uContext,
		/*[in]*/ ULONG cpicmExclude,
		/*[in]*/ IOleComponentManager** rgpicmExclude)
	{
		VSL_DEFINE_MOCK_METHOD(FOnComponentExitState)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_CHECK_VALIDVALUE(uStateID);

		VSL_CHECK_VALIDVALUE(uContext);

		VSL_CHECK_VALIDVALUE(cpicmExclude);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(rgpicmExclude);

		VSL_RETURN_VALIDVALUES();
	}
	struct FInStateValidValues
	{
		/*[in]*/ OLECSTATE uStateID;
		/*[in]*/ void* pvoid;
		BOOL retValue;
		size_t pvoid_size_in_bytes;
	};

	virtual BOOL _stdcall FInState(
		/*[in]*/ OLECSTATE uStateID,
		/*[in]*/ void* pvoid)
	{
		VSL_DEFINE_MOCK_METHOD(FInState)

		VSL_CHECK_VALIDVALUE(uStateID);

		VSL_CHECK_VALIDVALUE_PVOID(pvoid);

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
	struct FPushMessageLoopValidValues
	{
		/*[in]*/ DWORD_PTR dwComponentID;
		/*[in]*/ OLELOOP uReason;
		/*[in]*/ void* pvLoopData;
		BOOL retValue;
		size_t pvLoopData_size_in_bytes;
	};

	virtual BOOL _stdcall FPushMessageLoop(
		/*[in]*/ DWORD_PTR dwComponentID,
		/*[in]*/ OLELOOP uReason,
		/*[in]*/ void* pvLoopData)
	{
		VSL_DEFINE_MOCK_METHOD(FPushMessageLoop)

		VSL_CHECK_VALIDVALUE(dwComponentID);

		VSL_CHECK_VALIDVALUE(uReason);

		VSL_CHECK_VALIDVALUE_PVOID(pvLoopData);

		VSL_RETURN_VALIDVALUES();
	}
	struct FCreateSubComponentManagerValidValues
	{
		/*[in]*/ IUnknown* piunkOuter;
		/*[in]*/ IUnknown* piunkServProv;
		/*[in]*/ REFIID riid;
		/*[out]*/ void** ppvObj;
		BOOL retValue;
	};

	virtual BOOL _stdcall FCreateSubComponentManager(
		/*[in]*/ IUnknown* piunkOuter,
		/*[in]*/ IUnknown* piunkServProv,
		/*[in]*/ REFIID riid,
		/*[out]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(FCreateSubComponentManager)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(piunkOuter);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(piunkServProv);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct FGetParentComponentManagerValidValues
	{
		/*[out]*/ IOleComponentManager** ppicm;
		BOOL retValue;
	};

	virtual BOOL _stdcall FGetParentComponentManager(
		/*[out]*/ IOleComponentManager** ppicm)
	{
		VSL_DEFINE_MOCK_METHOD(FGetParentComponentManager)

		VSL_SET_VALIDVALUE_INTERFACE(ppicm);

		VSL_RETURN_VALIDVALUES();
	}
	struct FGetActiveComponentValidValues
	{
		/*[in]*/ OLEGAC dwgac;
		/*[out]*/ IOleComponent** ppic;
		/*[in,out]*/ OLECRINFO* pcrinfo;
		/*[in]*/ DWORD dwReserved;
		BOOL retValue;
	};

	virtual BOOL _stdcall FGetActiveComponent(
		/*[in]*/ OLEGAC dwgac,
		/*[out]*/ IOleComponent** ppic,
		/*[in,out]*/ OLECRINFO* pcrinfo,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(FGetActiveComponent)

		VSL_CHECK_VALIDVALUE(dwgac);

		VSL_SET_VALIDVALUE_INTERFACE(ppic);

		VSL_SET_VALIDVALUE(pcrinfo);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECOMPONENTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
