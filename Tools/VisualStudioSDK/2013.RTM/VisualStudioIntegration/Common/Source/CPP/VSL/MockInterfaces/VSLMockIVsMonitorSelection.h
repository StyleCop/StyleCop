/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMONITORSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMONITORSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMonitorSelectionNotImpl :
	public IVsMonitorSelection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorSelectionNotImpl)

public:

	typedef IVsMonitorSelection Interface;

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IVsMultiItemSelect** /*ppMIS*/,
		/*[out]*/ ISelectionContainer** /*ppSC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseSelectionEvents)(
		/*[in]*/ IVsSelectionEvents* /*psink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseSelectionEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentElementValue)(
		/*[in]*/ VSSELELEMID /*elementid*/,
		/*[out]*/ VARIANT* /*pvarValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCmdUIContextCookie)(
		/*[in]*/ REFGUID /*rguidCmdUI*/,
		/*[out]*/ VSCOOKIE* /*pdwCmdUICookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCmdUIContextActive)(
		/*[in]*/ VSCOOKIE /*dwCmdUICookie*/,
		/*[out]*/ BOOL* /*pfActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCmdUIContext)(
		/*[in]*/ VSCOOKIE /*dwCmdUICookie*/,
		/*[in]*/ BOOL /*fActive*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMonitorSelectionMockImpl :
	public IVsMonitorSelection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorSelectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMonitorSelectionMockImpl)

	typedef IVsMonitorSelection Interface;
	struct GetCurrentSelectionValidValues
	{
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IVsMultiItemSelect** ppMIS;
		/*[out]*/ ISelectionContainer** ppSC;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IVsMultiItemSelect** ppMIS,
		/*[out]*/ ISelectionContainer** ppSC)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentSelection)

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppMIS);

		VSL_SET_VALIDVALUE_INTERFACE(ppSC);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseSelectionEventsValidValues
	{
		/*[in]*/ IVsSelectionEvents* psink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseSelectionEvents)(
		/*[in]*/ IVsSelectionEvents* psink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseSelectionEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(psink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseSelectionEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseSelectionEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseSelectionEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentElementValueValidValues
	{
		/*[in]*/ VSSELELEMID elementid;
		/*[out]*/ VARIANT* pvarValue;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentElementValue)(
		/*[in]*/ VSSELELEMID elementid,
		/*[out]*/ VARIANT* pvarValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentElementValue)

		VSL_CHECK_VALIDVALUE(elementid);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCmdUIContextCookieValidValues
	{
		/*[in]*/ REFGUID rguidCmdUI;
		/*[out]*/ VSCOOKIE* pdwCmdUICookie;
		HRESULT retValue;
	};

	STDMETHOD(GetCmdUIContextCookie)(
		/*[in]*/ REFGUID rguidCmdUI,
		/*[out]*/ VSCOOKIE* pdwCmdUICookie)
	{
		VSL_DEFINE_MOCK_METHOD(GetCmdUIContextCookie)

		VSL_CHECK_VALIDVALUE(rguidCmdUI);

		VSL_SET_VALIDVALUE(pdwCmdUICookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCmdUIContextActiveValidValues
	{
		/*[in]*/ VSCOOKIE dwCmdUICookie;
		/*[out]*/ BOOL* pfActive;
		HRESULT retValue;
	};

	STDMETHOD(IsCmdUIContextActive)(
		/*[in]*/ VSCOOKIE dwCmdUICookie,
		/*[out]*/ BOOL* pfActive)
	{
		VSL_DEFINE_MOCK_METHOD(IsCmdUIContextActive)

		VSL_CHECK_VALIDVALUE(dwCmdUICookie);

		VSL_SET_VALIDVALUE(pfActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCmdUIContextValidValues
	{
		/*[in]*/ VSCOOKIE dwCmdUICookie;
		/*[in]*/ BOOL fActive;
		HRESULT retValue;
	};

	STDMETHOD(SetCmdUIContext)(
		/*[in]*/ VSCOOKIE dwCmdUICookie,
		/*[in]*/ BOOL fActive)
	{
		VSL_DEFINE_MOCK_METHOD(SetCmdUIContext)

		VSL_CHECK_VALIDVALUE(dwCmdUICookie);

		VSL_CHECK_VALIDVALUE(fActive);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMONITORSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
