/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLWINDOWTOOLBARHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLWINDOWTOOLBARHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolWindowToolbarHostNotImpl :
	public IVsToolWindowToolbarHost
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolWindowToolbarHostNotImpl)

public:

	typedef IVsToolWindowToolbarHost Interface;

	STDMETHOD(AddToolbar)(
		/*[in]*/ VSTWT_LOCATION /*dwLoc*/,
		/*[in]*/ const GUID* /*pguid*/,
		/*[in]*/ DWORD /*dwId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BorderChanged)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowHideToolbar)(
		/*[in]*/ const GUID* /*pguid*/,
		/*[in]*/ DWORD /*dwId*/,
		/*[in]*/ BOOL /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ProcessMouseActivation)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*msg*/,
		/*[in]*/ WPARAM /*wp*/,
		/*[in]*/ LPARAM /*lp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ForceUpdateUI)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ProcessMouseActivationModal)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*msg*/,
		/*[in]*/ WPARAM /*wp*/,
		/*[in]*/ LPARAM /*lp*/,
		/*[out]*/ LRESULT* /*plResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Show)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolWindowToolbarHostMockImpl :
	public IVsToolWindowToolbarHost,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolWindowToolbarHostMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolWindowToolbarHostMockImpl)

	typedef IVsToolWindowToolbarHost Interface;
	struct AddToolbarValidValues
	{
		/*[in]*/ VSTWT_LOCATION dwLoc;
		/*[in]*/ GUID* pguid;
		/*[in]*/ DWORD dwId;
		HRESULT retValue;
	};

	STDMETHOD(AddToolbar)(
		/*[in]*/ VSTWT_LOCATION dwLoc,
		/*[in]*/ const GUID* pguid,
		/*[in]*/ DWORD dwId)
	{
		VSL_DEFINE_MOCK_METHOD(AddToolbar)

		VSL_CHECK_VALIDVALUE(dwLoc);

		VSL_CHECK_VALIDVALUE_POINTER(pguid);

		VSL_CHECK_VALIDVALUE(dwId);

		VSL_RETURN_VALIDVALUES();
	}
	struct BorderChangedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BorderChanged)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BorderChanged)

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowHideToolbarValidValues
	{
		/*[in]*/ GUID* pguid;
		/*[in]*/ DWORD dwId;
		/*[in]*/ BOOL fShow;
		HRESULT retValue;
	};

	STDMETHOD(ShowHideToolbar)(
		/*[in]*/ const GUID* pguid,
		/*[in]*/ DWORD dwId,
		/*[in]*/ BOOL fShow)
	{
		VSL_DEFINE_MOCK_METHOD(ShowHideToolbar)

		VSL_CHECK_VALIDVALUE_POINTER(pguid);

		VSL_CHECK_VALIDVALUE(dwId);

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct ProcessMouseActivationValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT msg;
		/*[in]*/ WPARAM wp;
		/*[in]*/ LPARAM lp;
		HRESULT retValue;
	};

	STDMETHOD(ProcessMouseActivation)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT msg,
		/*[in]*/ WPARAM wp,
		/*[in]*/ LPARAM lp)
	{
		VSL_DEFINE_MOCK_METHOD(ProcessMouseActivation)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(msg);

		VSL_CHECK_VALIDVALUE(wp);

		VSL_CHECK_VALIDVALUE(lp);

		VSL_RETURN_VALIDVALUES();
	}
	struct ForceUpdateUIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ForceUpdateUI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ForceUpdateUI)

		VSL_RETURN_VALIDVALUES();
	}
	struct ProcessMouseActivationModalValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT msg;
		/*[in]*/ WPARAM wp;
		/*[in]*/ LPARAM lp;
		/*[out]*/ LRESULT* plResult;
		HRESULT retValue;
	};

	STDMETHOD(ProcessMouseActivationModal)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT msg,
		/*[in]*/ WPARAM wp,
		/*[in]*/ LPARAM lp,
		/*[out]*/ LRESULT* plResult)
	{
		VSL_DEFINE_MOCK_METHOD(ProcessMouseActivationModal)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(msg);

		VSL_CHECK_VALIDVALUE(wp);

		VSL_CHECK_VALIDVALUE(lp);

		VSL_SET_VALIDVALUE(plResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(Close)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(Close)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(Show)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(Show)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(Hide)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(Hide)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLWINDOWTOOLBARHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
