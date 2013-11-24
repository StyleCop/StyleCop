/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDROPDOWNBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDROPDOWNBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDropdownBarClientNotImpl :
	public IVsDropdownBarClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDropdownBarClientNotImpl)

public:

	typedef IVsDropdownBarClient Interface;

	STDMETHOD(SetDropdownBar)(
		/*[in]*/ IVsDropdownBar* /*pDropdownBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetComboAttributes)(
		/*[in]*/ long /*iCombo*/,
		/*[out]*/ ULONG* /*pcEntries*/,
		/*[out]*/ ULONG* /*puEntryType*/,
		/*[out]*/ HANDLE* /*phImageList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEntryText)(
		/*[in]*/ long /*iCombo*/,
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ WCHAR** /*ppszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEntryAttributes)(
		/*[in]*/ long /*iCombo*/,
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ ULONG* /*pAttr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEntryImage)(
		/*[in]*/ long /*iCombo*/,
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ long* /*piImageIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemSelected)(
		/*[in]*/ long /*iCombo*/,
		/*[in]*/ long /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemChosen)(
		/*[in]*/ long /*iCombo*/,
		/*[in]*/ long /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnComboGetFocus)(
		/*[in]*/ long /*iCombo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetComboTipText)(
		/*[in]*/ long /*iCombo*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDropdownBarClientMockImpl :
	public IVsDropdownBarClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDropdownBarClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDropdownBarClientMockImpl)

	typedef IVsDropdownBarClient Interface;
	struct SetDropdownBarValidValues
	{
		/*[in]*/ IVsDropdownBar* pDropdownBar;
		HRESULT retValue;
	};

	STDMETHOD(SetDropdownBar)(
		/*[in]*/ IVsDropdownBar* pDropdownBar)
	{
		VSL_DEFINE_MOCK_METHOD(SetDropdownBar)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDropdownBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetComboAttributesValidValues
	{
		/*[in]*/ long iCombo;
		/*[out]*/ ULONG* pcEntries;
		/*[out]*/ ULONG* puEntryType;
		/*[out]*/ HANDLE* phImageList;
		HRESULT retValue;
	};

	STDMETHOD(GetComboAttributes)(
		/*[in]*/ long iCombo,
		/*[out]*/ ULONG* pcEntries,
		/*[out]*/ ULONG* puEntryType,
		/*[out]*/ HANDLE* phImageList)
	{
		VSL_DEFINE_MOCK_METHOD(GetComboAttributes)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_SET_VALIDVALUE(pcEntries);

		VSL_SET_VALIDVALUE(puEntryType);

		VSL_SET_VALIDVALUE(phImageList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEntryTextValidValues
	{
		/*[in]*/ long iCombo;
		/*[in]*/ long iIndex;
		/*[out]*/ WCHAR** ppszText;
		HRESULT retValue;
	};

	STDMETHOD(GetEntryText)(
		/*[in]*/ long iCombo,
		/*[in]*/ long iIndex,
		/*[out]*/ WCHAR** ppszText)
	{
		VSL_DEFINE_MOCK_METHOD(GetEntryText)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(ppszText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEntryAttributesValidValues
	{
		/*[in]*/ long iCombo;
		/*[in]*/ long iIndex;
		/*[out]*/ ULONG* pAttr;
		HRESULT retValue;
	};

	STDMETHOD(GetEntryAttributes)(
		/*[in]*/ long iCombo,
		/*[in]*/ long iIndex,
		/*[out]*/ ULONG* pAttr)
	{
		VSL_DEFINE_MOCK_METHOD(GetEntryAttributes)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(pAttr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEntryImageValidValues
	{
		/*[in]*/ long iCombo;
		/*[in]*/ long iIndex;
		/*[out]*/ long* piImageIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetEntryImage)(
		/*[in]*/ long iCombo,
		/*[in]*/ long iIndex,
		/*[out]*/ long* piImageIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetEntryImage)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(piImageIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemSelectedValidValues
	{
		/*[in]*/ long iCombo;
		/*[in]*/ long iIndex;
		HRESULT retValue;
	};

	STDMETHOD(OnItemSelected)(
		/*[in]*/ long iCombo,
		/*[in]*/ long iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemSelected)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemChosenValidValues
	{
		/*[in]*/ long iCombo;
		/*[in]*/ long iIndex;
		HRESULT retValue;
	};

	STDMETHOD(OnItemChosen)(
		/*[in]*/ long iCombo,
		/*[in]*/ long iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemChosen)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnComboGetFocusValidValues
	{
		/*[in]*/ long iCombo;
		HRESULT retValue;
	};

	STDMETHOD(OnComboGetFocus)(
		/*[in]*/ long iCombo)
	{
		VSL_DEFINE_MOCK_METHOD(OnComboGetFocus)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetComboTipTextValidValues
	{
		/*[in]*/ long iCombo;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetComboTipText)(
		/*[in]*/ long iCombo,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetComboTipText)

		VSL_CHECK_VALIDVALUE(iCombo);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDROPDOWNBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
