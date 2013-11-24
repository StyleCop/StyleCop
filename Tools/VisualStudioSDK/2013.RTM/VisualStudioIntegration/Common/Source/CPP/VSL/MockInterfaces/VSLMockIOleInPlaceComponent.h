/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleInPlaceComponentNotImpl :
	public IOleInPlaceComponent
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceComponentNotImpl)

public:

	typedef IOleInPlaceComponent Interface;

	STDMETHOD(UseComponentUIManager)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[out]*/ DWORD* /*pgrfCompFlags*/,
		/*[in]*/ IOleComponentUIManager* /*pCompUIMgr*/,
		/*[in]*/ IOleInPlaceComponentSite* /*pIPCompSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnWindowActivate)(
		/*[in]*/ DWORD /*dwWindowType*/,
		/*[in]*/ BOOL /*fActivate*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE OnEnterState(
		/*[in]*/ DWORD /*dwStateId*/,
		/*[in]*/ BOOL /*fEnter*/){ return ; }

	virtual BOOL STDMETHODCALLTYPE FDoIdle(
		/*[in]*/ DWORD /*grfidlef*/){ return BOOL(); }

	virtual BOOL STDMETHODCALLTYPE FQueryClose(
		/*[in]*/ BOOL /*fPromptUser*/){ return BOOL(); }

	STDMETHOD(TranslateCntrAccelerator)(
		/*[in]*/ MSG* /*pMsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCntrContextMenu)(
		/*[in]*/ DWORD /*dwRoleActiveObj*/,
		/*[in]*/ REFCLSID /*rclsidActiveObj*/,
		/*[in]*/ LONG /*nMenuIdActiveObj*/,
		/*[in]*/ REFPOINTS /*pos*/,
		/*[out]*/ CLSID* /*pclsidCntr*/,
		/*[out]*/ OLEMENUID* /*menuid*/,
		/*[out]*/ DWORD* /*pgrf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCntrHelp)(
		/*[in,out]*/ DWORD* /*pdwRole*/,
		/*[in,out]*/ CLSID* /*pclsid*/,
		/*[in]*/ POINT /*posMouse*/,
		/*[in]*/ DWORD /*dwHelpCmd*/,
		/*[in]*/ LPOLESTR /*pszHelpFileIn*/,
		/*[out]*/ LPOLESTR* /*ppszHelpFileOut*/,
		/*[in]*/ DWORD /*dwDataIn*/,
		/*[out]*/ DWORD* /*pdwDataOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCntrMessage)(
		/*[in,out]*/ DWORD* /*pdwRole*/,
		/*[in,out]*/ CLSID* /*pclsid*/,
		/*[in]*/ LPOLESTR /*pszTitleIn*/,
		/*[in]*/ LPOLESTR /*pszTextIn*/,
		/*[in]*/ LPOLESTR /*pszHelpFileIn*/,
		/*[out]*/ LPOLESTR* /*ppszTitleOut*/,
		/*[out]*/ LPOLESTR* /*ppszTextOut*/,
		/*[out]*/ LPOLESTR* /*ppszHelpFileOut*/,
		/*[in,out]*/ DWORD* /*pdwHelpContextID*/,
		/*[in,out]*/ OLEMSGBUTTON* /*pmsgbtn*/,
		/*[in,out]*/ OLEMSGDEFBUTTON* /*pmsgdefbtn*/,
		/*[in,out]*/ OLEMSGICON* /*pmsgicon*/,
		/*[in,out]*/ BOOL* /*pfSysAlert*/)VSL_STDMETHOD_NOTIMPL
};

class IOleInPlaceComponentMockImpl :
	public IOleInPlaceComponent,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceComponentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceComponentMockImpl)

	typedef IOleInPlaceComponent Interface;
	struct UseComponentUIManagerValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[out]*/ DWORD* pgrfCompFlags;
		/*[in]*/ IOleComponentUIManager* pCompUIMgr;
		/*[in]*/ IOleInPlaceComponentSite* pIPCompSite;
		HRESULT retValue;
	};

	STDMETHOD(UseComponentUIManager)(
		/*[in]*/ DWORD dwCompRole,
		/*[out]*/ DWORD* pgrfCompFlags,
		/*[in]*/ IOleComponentUIManager* pCompUIMgr,
		/*[in]*/ IOleInPlaceComponentSite* pIPCompSite)
	{
		VSL_DEFINE_MOCK_METHOD(UseComponentUIManager)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_SET_VALIDVALUE(pgrfCompFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCompUIMgr);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIPCompSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnWindowActivateValidValues
	{
		/*[in]*/ DWORD dwWindowType;
		/*[in]*/ BOOL fActivate;
		HRESULT retValue;
	};

	STDMETHOD(OnWindowActivate)(
		/*[in]*/ DWORD dwWindowType,
		/*[in]*/ BOOL fActivate)
	{
		VSL_DEFINE_MOCK_METHOD(OnWindowActivate)

		VSL_CHECK_VALIDVALUE(dwWindowType);

		VSL_CHECK_VALIDVALUE(fActivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEnterStateValidValues
	{
		/*[in]*/ DWORD dwStateId;
		/*[in]*/ BOOL fEnter;
	};

	virtual void _stdcall OnEnterState(
		/*[in]*/ DWORD dwStateId,
		/*[in]*/ BOOL fEnter)
	{
		VSL_DEFINE_MOCK_METHOD(OnEnterState)

		VSL_CHECK_VALIDVALUE(dwStateId);

		VSL_CHECK_VALIDVALUE(fEnter);

	}
	struct FDoIdleValidValues
	{
		/*[in]*/ DWORD grfidlef;
		BOOL retValue;
	};

	virtual BOOL _stdcall FDoIdle(
		/*[in]*/ DWORD grfidlef)
	{
		VSL_DEFINE_MOCK_METHOD(FDoIdle)

		VSL_CHECK_VALIDVALUE(grfidlef);

		VSL_RETURN_VALIDVALUES();
	}
	struct FQueryCloseValidValues
	{
		/*[in]*/ BOOL fPromptUser;
		BOOL retValue;
	};

	virtual BOOL _stdcall FQueryClose(
		/*[in]*/ BOOL fPromptUser)
	{
		VSL_DEFINE_MOCK_METHOD(FQueryClose)

		VSL_CHECK_VALIDVALUE(fPromptUser);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateCntrAcceleratorValidValues
	{
		/*[in]*/ MSG* pMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateCntrAccelerator)(
		/*[in]*/ MSG* pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateCntrAccelerator)

		VSL_CHECK_VALIDVALUE_POINTER(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCntrContextMenuValidValues
	{
		/*[in]*/ DWORD dwRoleActiveObj;
		/*[in]*/ REFCLSID rclsidActiveObj;
		/*[in]*/ LONG nMenuIdActiveObj;
		/*[in]*/ REFPOINTS pos;
		/*[out]*/ CLSID* pclsidCntr;
		/*[out]*/ OLEMENUID* menuid;
		/*[out]*/ DWORD* pgrf;
		HRESULT retValue;
	};

	STDMETHOD(GetCntrContextMenu)(
		/*[in]*/ DWORD dwRoleActiveObj,
		/*[in]*/ REFCLSID rclsidActiveObj,
		/*[in]*/ LONG nMenuIdActiveObj,
		/*[in]*/ REFPOINTS pos,
		/*[out]*/ CLSID* pclsidCntr,
		/*[out]*/ OLEMENUID* menuid,
		/*[out]*/ DWORD* pgrf)
	{
		VSL_DEFINE_MOCK_METHOD(GetCntrContextMenu)

		VSL_CHECK_VALIDVALUE(dwRoleActiveObj);

		VSL_CHECK_VALIDVALUE(rclsidActiveObj);

		VSL_CHECK_VALIDVALUE(nMenuIdActiveObj);

		VSL_CHECK_VALIDVALUE(pos);

		VSL_SET_VALIDVALUE(pclsidCntr);

		VSL_SET_VALIDVALUE(menuid);

		VSL_SET_VALIDVALUE(pgrf);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCntrHelpValidValues
	{
		/*[in,out]*/ DWORD* pdwRole;
		/*[in,out]*/ CLSID* pclsid;
		/*[in]*/ POINT posMouse;
		/*[in]*/ DWORD dwHelpCmd;
		/*[in]*/ LPOLESTR pszHelpFileIn;
		/*[out]*/ LPOLESTR* ppszHelpFileOut;
		/*[in]*/ DWORD dwDataIn;
		/*[out]*/ DWORD* pdwDataOut;
		HRESULT retValue;
	};

	STDMETHOD(GetCntrHelp)(
		/*[in,out]*/ DWORD* pdwRole,
		/*[in,out]*/ CLSID* pclsid,
		/*[in]*/ POINT posMouse,
		/*[in]*/ DWORD dwHelpCmd,
		/*[in]*/ LPOLESTR pszHelpFileIn,
		/*[out]*/ LPOLESTR* ppszHelpFileOut,
		/*[in]*/ DWORD dwDataIn,
		/*[out]*/ DWORD* pdwDataOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetCntrHelp)

		VSL_SET_VALIDVALUE(pdwRole);

		VSL_SET_VALIDVALUE(pclsid);

		VSL_CHECK_VALIDVALUE(posMouse);

		VSL_CHECK_VALIDVALUE(dwHelpCmd);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFileIn);

		VSL_SET_VALIDVALUE(ppszHelpFileOut);

		VSL_CHECK_VALIDVALUE(dwDataIn);

		VSL_SET_VALIDVALUE(pdwDataOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCntrMessageValidValues
	{
		/*[in,out]*/ DWORD* pdwRole;
		/*[in,out]*/ CLSID* pclsid;
		/*[in]*/ LPOLESTR pszTitleIn;
		/*[in]*/ LPOLESTR pszTextIn;
		/*[in]*/ LPOLESTR pszHelpFileIn;
		/*[out]*/ LPOLESTR* ppszTitleOut;
		/*[out]*/ LPOLESTR* ppszTextOut;
		/*[out]*/ LPOLESTR* ppszHelpFileOut;
		/*[in,out]*/ DWORD* pdwHelpContextID;
		/*[in,out]*/ OLEMSGBUTTON* pmsgbtn;
		/*[in,out]*/ OLEMSGDEFBUTTON* pmsgdefbtn;
		/*[in,out]*/ OLEMSGICON* pmsgicon;
		/*[in,out]*/ BOOL* pfSysAlert;
		HRESULT retValue;
	};

	STDMETHOD(GetCntrMessage)(
		/*[in,out]*/ DWORD* pdwRole,
		/*[in,out]*/ CLSID* pclsid,
		/*[in]*/ LPOLESTR pszTitleIn,
		/*[in]*/ LPOLESTR pszTextIn,
		/*[in]*/ LPOLESTR pszHelpFileIn,
		/*[out]*/ LPOLESTR* ppszTitleOut,
		/*[out]*/ LPOLESTR* ppszTextOut,
		/*[out]*/ LPOLESTR* ppszHelpFileOut,
		/*[in,out]*/ DWORD* pdwHelpContextID,
		/*[in,out]*/ OLEMSGBUTTON* pmsgbtn,
		/*[in,out]*/ OLEMSGDEFBUTTON* pmsgdefbtn,
		/*[in,out]*/ OLEMSGICON* pmsgicon,
		/*[in,out]*/ BOOL* pfSysAlert)
	{
		VSL_DEFINE_MOCK_METHOD(GetCntrMessage)

		VSL_SET_VALIDVALUE(pdwRole);

		VSL_SET_VALIDVALUE(pclsid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTitleIn);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTextIn);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFileIn);

		VSL_SET_VALIDVALUE(ppszTitleOut);

		VSL_SET_VALIDVALUE(ppszTextOut);

		VSL_SET_VALIDVALUE(ppszHelpFileOut);

		VSL_SET_VALIDVALUE(pdwHelpContextID);

		VSL_SET_VALIDVALUE(pmsgbtn);

		VSL_SET_VALIDVALUE(pmsgdefbtn);

		VSL_SET_VALIDVALUE(pmsgicon);

		VSL_SET_VALIDVALUE(pfSysAlert);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEINPLACECOMPONENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
