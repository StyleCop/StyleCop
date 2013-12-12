/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleComponentUIManagerNotImpl :
	public IOleComponentUIManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentUIManagerNotImpl)

public:

	typedef IOleComponentUIManager Interface;

	STDMETHOD(Deleted1)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Deleted2)()VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE OnUIEvent(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidComp*/,
		/*[in]*/ const GUID* /*pguidUIEventGroup*/,
		/*[in]*/ DWORD /*nUIEventId*/,
		/*[in]*/ DWORD /*dwUIEventStatus*/,
		/*[in]*/ DWORD /*dwEventFreq*/,
		/*[in]*/ RECT* /*prcEventRegion*/,
		/*[in]*/ VARIANT* /*pvarEventArg*/){ return ; }

	STDMETHOD(OnUIEventProgress)(
		/*[in,out]*/ DWORD_PTR* /*pdwCookie*/,
		/*[in]*/ BOOL /*fInProgress*/,
		/*[in]*/ _In_ LPOLESTR /*pwszLabel*/,
		/*[in]*/ ULONG /*nComplete*/,
		/*[in]*/ ULONG /*nTotal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStatus)(
		/*[in]*/ LPCOLESTR /*pwszStatusText*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowContextMenu)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidActive*/,
		/*[in]*/ LONG /*nMenuId*/,
		/*[in]*/ REFPOINTS /*pos*/,
		/*[in]*/ IOleCommandTarget* /*pCmdTrgtActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowHelp)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidComp*/,
		/*[in]*/ POINT /*posMouse*/,
		/*[in]*/ DWORD /*dwHelpCmd*/,
		/*[in]*/ _In_ LPOLESTR /*pszHelpFile*/,
		/*[in]*/ DWORD /*dwData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowMessage)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidComp*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszTitle*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszText*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszHelpFile*/,
		/*[in]*/ DWORD /*dwHelpContextID*/,
		/*[in]*/ OLEMSGBUTTON /*msgbtn*/,
		/*[in]*/ OLEMSGDEFBUTTON /*msgdefbtn*/,
		/*[in]*/ OLEMSGICON /*msgicon*/,
		/*[in]*/ BOOL /*fSysAlert*/,
		/*[out,retval]*/ LONG* /*pnResult*/)VSL_STDMETHOD_NOTIMPL
};

class IOleComponentUIManagerMockImpl :
	public IOleComponentUIManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleComponentUIManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleComponentUIManagerMockImpl)

	typedef IOleComponentUIManager Interface;
	struct Deleted1ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Deleted1)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Deleted1)

		VSL_RETURN_VALIDVALUES();
	}
	struct Deleted2ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Deleted2)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Deleted2)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUIEventValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidComp;
		/*[in]*/ GUID* pguidUIEventGroup;
		/*[in]*/ DWORD nUIEventId;
		/*[in]*/ DWORD dwUIEventStatus;
		/*[in]*/ DWORD dwEventFreq;
		/*[in]*/ RECT* prcEventRegion;
		/*[in]*/ VARIANT* pvarEventArg;
	};

	virtual void _stdcall OnUIEvent(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidComp,
		/*[in]*/ const GUID* pguidUIEventGroup,
		/*[in]*/ DWORD nUIEventId,
		/*[in]*/ DWORD dwUIEventStatus,
		/*[in]*/ DWORD dwEventFreq,
		/*[in]*/ RECT* prcEventRegion,
		/*[in]*/ VARIANT* pvarEventArg)
	{
		VSL_DEFINE_MOCK_METHOD(OnUIEvent)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidComp);

		VSL_CHECK_VALIDVALUE_POINTER(pguidUIEventGroup);

		VSL_CHECK_VALIDVALUE(nUIEventId);

		VSL_CHECK_VALIDVALUE(dwUIEventStatus);

		VSL_CHECK_VALIDVALUE(dwEventFreq);

		VSL_CHECK_VALIDVALUE_POINTER(prcEventRegion);

		VSL_CHECK_VALIDVALUE_POINTER(pvarEventArg);

	}
	struct OnUIEventProgressValidValues
	{
		/*[in,out]*/ DWORD_PTR* pdwCookie;
		/*[in]*/ BOOL fInProgress;
		/*[in]*/ LPOLESTR pwszLabel;
		/*[in]*/ ULONG nComplete;
		/*[in]*/ ULONG nTotal;
		HRESULT retValue;
	};

	STDMETHOD(OnUIEventProgress)(
		/*[in,out]*/ DWORD_PTR* pdwCookie,
		/*[in]*/ BOOL fInProgress,
		/*[in]*/ _In_ LPOLESTR pwszLabel,
		/*[in]*/ ULONG nComplete,
		/*[in]*/ ULONG nTotal)
	{
		VSL_DEFINE_MOCK_METHOD(OnUIEventProgress)

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_CHECK_VALIDVALUE(fInProgress);

		VSL_CHECK_VALIDVALUE_STRINGW(pwszLabel);

		VSL_CHECK_VALIDVALUE(nComplete);

		VSL_CHECK_VALIDVALUE(nTotal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStatusValidValues
	{
		/*[in]*/ LPCOLESTR pwszStatusText;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(SetStatus)(
		/*[in]*/ LPCOLESTR pwszStatusText,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(SetStatus)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszStatusText);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowContextMenuValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidActive;
		/*[in]*/ LONG nMenuId;
		/*[in]*/ REFPOINTS pos;
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive;
		HRESULT retValue;
	};

	STDMETHOD(ShowContextMenu)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidActive,
		/*[in]*/ LONG nMenuId,
		/*[in]*/ REFPOINTS pos,
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive)
	{
		VSL_DEFINE_MOCK_METHOD(ShowContextMenu)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidActive);

		VSL_CHECK_VALIDVALUE(nMenuId);

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdTrgtActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowHelpValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidComp;
		/*[in]*/ POINT posMouse;
		/*[in]*/ DWORD dwHelpCmd;
		/*[in]*/ LPOLESTR pszHelpFile;
		/*[in]*/ DWORD dwData;
		HRESULT retValue;
	};

	STDMETHOD(ShowHelp)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidComp,
		/*[in]*/ POINT posMouse,
		/*[in]*/ DWORD dwHelpCmd,
		/*[in]*/ _In_ LPOLESTR pszHelpFile,
		/*[in]*/ DWORD dwData)
	{
		VSL_DEFINE_MOCK_METHOD(ShowHelp)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidComp);

		VSL_CHECK_VALIDVALUE(posMouse);

		VSL_CHECK_VALIDVALUE(dwHelpCmd);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFile);

		VSL_CHECK_VALIDVALUE(dwData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowMessageValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidComp;
		/*[in]*/ LPOLESTR pszTitle;
		/*[in]*/ LPOLESTR pszText;
		/*[in]*/ LPOLESTR pszHelpFile;
		/*[in]*/ DWORD dwHelpContextID;
		/*[in]*/ OLEMSGBUTTON msgbtn;
		/*[in]*/ OLEMSGDEFBUTTON msgdefbtn;
		/*[in]*/ OLEMSGICON msgicon;
		/*[in]*/ BOOL fSysAlert;
		/*[out,retval]*/ LONG* pnResult;
		HRESULT retValue;
	};

	STDMETHOD(ShowMessage)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidComp,
		/*[in]*/ _In_z_ LPOLESTR pszTitle,
		/*[in]*/ _In_z_ LPOLESTR pszText,
		/*[in]*/ _In_z_ LPOLESTR pszHelpFile,
		/*[in]*/ DWORD dwHelpContextID,
		/*[in]*/ OLEMSGBUTTON msgbtn,
		/*[in]*/ OLEMSGDEFBUTTON msgdefbtn,
		/*[in]*/ OLEMSGICON msgicon,
		/*[in]*/ BOOL fSysAlert,
		/*[out,retval]*/ LONG* pnResult)
	{
		VSL_DEFINE_MOCK_METHOD(ShowMessage)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidComp);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFile);

		VSL_CHECK_VALIDVALUE(dwHelpContextID);

		VSL_CHECK_VALIDVALUE(msgbtn);

		VSL_CHECK_VALIDVALUE(msgdefbtn);

		VSL_CHECK_VALIDVALUE(msgicon);

		VSL_CHECK_VALIDVALUE(fSysAlert);

		VSL_SET_VALIDVALUE(pnResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECOMPONENTUIMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
