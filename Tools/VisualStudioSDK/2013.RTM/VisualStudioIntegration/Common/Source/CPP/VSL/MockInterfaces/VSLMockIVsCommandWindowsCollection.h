/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMANDWINDOWSCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMANDWINDOWSCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCommandWindowsCollectionNotImpl :
	public IVsCommandWindowsCollection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindowsCollectionNotImpl)

public:

	typedef IVsCommandWindowsCollection Interface;

	STDMETHOD(Create)(
		/*[in]*/ COMMANDWINDOWMODE2 /*mode*/,
		/*[in]*/ DWORD /*dwToolWindowId*/,
		/*[in]*/ BOOL /*fShow*/,
		/*[out]*/ UINT* /*puCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenExistingOrCreateNewCommandWindow)(
		/*[in]*/ COMMANDWINDOWMODE2 /*mode*/,
		/*[in]*/ BOOL /*fShow*/,
		/*[out]*/ UINT* /*puCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCommandWindowFromCookie)(
		/*[in]*/ UINT /*uCookie*/,
		/*[out]*/ IUnknown** /*ppunkCmdWindow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCommandWindowFromMode)(
		/*[in]*/ COMMANDWINDOWMODE2 /*mode*/,
		/*[out]*/ IUnknown** /*ppunkCmdWindow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRunningCommandWindowCommand)(
		/*[in]*/ UINT /*uCookie*/,
		/*[in]*/ BOOL /*fCmdWin*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsOutputWaiting)(
		/*[in]*/ UINT /*uCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ UINT /*uCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseAllCommandWindows)()VSL_STDMETHOD_NOTIMPL
};

class IVsCommandWindowsCollectionMockImpl :
	public IVsCommandWindowsCollection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindowsCollectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommandWindowsCollectionMockImpl)

	typedef IVsCommandWindowsCollection Interface;
	struct CreateValidValues
	{
		/*[in]*/ COMMANDWINDOWMODE2 mode;
		/*[in]*/ DWORD dwToolWindowId;
		/*[in]*/ BOOL fShow;
		/*[out]*/ UINT* puCookie;
		HRESULT retValue;
	};

	STDMETHOD(Create)(
		/*[in]*/ COMMANDWINDOWMODE2 mode,
		/*[in]*/ DWORD dwToolWindowId,
		/*[in]*/ BOOL fShow,
		/*[out]*/ UINT* puCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Create)

		VSL_CHECK_VALIDVALUE(mode);

		VSL_CHECK_VALIDVALUE(dwToolWindowId);

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_SET_VALIDVALUE(puCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenExistingOrCreateNewCommandWindowValidValues
	{
		/*[in]*/ COMMANDWINDOWMODE2 mode;
		/*[in]*/ BOOL fShow;
		/*[out]*/ UINT* puCookie;
		HRESULT retValue;
	};

	STDMETHOD(OpenExistingOrCreateNewCommandWindow)(
		/*[in]*/ COMMANDWINDOWMODE2 mode,
		/*[in]*/ BOOL fShow,
		/*[out]*/ UINT* puCookie)
	{
		VSL_DEFINE_MOCK_METHOD(OpenExistingOrCreateNewCommandWindow)

		VSL_CHECK_VALIDVALUE(mode);

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_SET_VALIDVALUE(puCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCommandWindowFromCookieValidValues
	{
		/*[in]*/ UINT uCookie;
		/*[out]*/ IUnknown** ppunkCmdWindow;
		HRESULT retValue;
	};

	STDMETHOD(GetCommandWindowFromCookie)(
		/*[in]*/ UINT uCookie,
		/*[out]*/ IUnknown** ppunkCmdWindow)
	{
		VSL_DEFINE_MOCK_METHOD(GetCommandWindowFromCookie)

		VSL_CHECK_VALIDVALUE(uCookie);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkCmdWindow);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCommandWindowFromModeValidValues
	{
		/*[in]*/ COMMANDWINDOWMODE2 mode;
		/*[out]*/ IUnknown** ppunkCmdWindow;
		HRESULT retValue;
	};

	STDMETHOD(GetCommandWindowFromMode)(
		/*[in]*/ COMMANDWINDOWMODE2 mode,
		/*[out]*/ IUnknown** ppunkCmdWindow)
	{
		VSL_DEFINE_MOCK_METHOD(GetCommandWindowFromMode)

		VSL_CHECK_VALIDVALUE(mode);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkCmdWindow);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRunningCommandWindowCommandValidValues
	{
		/*[in]*/ UINT uCookie;
		/*[in]*/ BOOL fCmdWin;
		HRESULT retValue;
	};

	STDMETHOD(SetRunningCommandWindowCommand)(
		/*[in]*/ UINT uCookie,
		/*[in]*/ BOOL fCmdWin)
	{
		VSL_DEFINE_MOCK_METHOD(SetRunningCommandWindowCommand)

		VSL_CHECK_VALIDVALUE(uCookie);

		VSL_CHECK_VALIDVALUE(fCmdWin);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsOutputWaitingValidValues
	{
		/*[in]*/ UINT uCookie;
		HRESULT retValue;
	};

	STDMETHOD(IsOutputWaiting)(
		/*[in]*/ UINT uCookie)
	{
		VSL_DEFINE_MOCK_METHOD(IsOutputWaiting)

		VSL_CHECK_VALIDVALUE(uCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		/*[in]*/ UINT uCookie;
		HRESULT retValue;
	};

	STDMETHOD(Close)(
		/*[in]*/ UINT uCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Close)

		VSL_CHECK_VALIDVALUE(uCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseAllCommandWindowsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseAllCommandWindows)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseAllCommandWindows)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMANDWINDOWSCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
