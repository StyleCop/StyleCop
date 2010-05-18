/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExpansionIntellisenseHostNotImpl :
	public IVsExpansionIntellisenseHost
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionIntellisenseHostNotImpl)

public:

	typedef IVsExpansionIntellisenseHost Interface;

	STDMETHOD(GetTextLen)(
		/*[out]*/ long* /*iLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* /*bstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSelection)(
		/*[out]*/ long* /*iStart*/,
		/*[out]*/ long* /*iEnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSelection)(
		/*[in]*/ long /*iStart*/,
		/*[in]*/ long /*iEnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetText)(
		/*[in]*/ BSTR /*bstrText*/,
		/*[in]*/ BOOL /*fReplaceAll*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentLevel)(
		/*[out]*/ long* /*pLevel*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionIntellisenseHostMockImpl :
	public IVsExpansionIntellisenseHost,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionIntellisenseHostMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionIntellisenseHostMockImpl)

	typedef IVsExpansionIntellisenseHost Interface;
	struct GetTextLenValidValues
	{
		/*[out]*/ long* iLen;
		HRESULT retValue;
	};

	STDMETHOD(GetTextLen)(
		/*[out]*/ long* iLen)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextLen)

		VSL_SET_VALIDVALUE(iLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[out]*/ BSTR* bstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* bstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_SET_VALIDVALUE_BSTR(bstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSelectionValidValues
	{
		/*[out]*/ long* iStart;
		/*[out]*/ long* iEnd;
		HRESULT retValue;
	};

	STDMETHOD(GetSelection)(
		/*[out]*/ long* iStart,
		/*[out]*/ long* iEnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelection)

		VSL_SET_VALIDVALUE(iStart);

		VSL_SET_VALIDVALUE(iEnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSelectionValidValues
	{
		/*[in]*/ long iStart;
		/*[in]*/ long iEnd;
		HRESULT retValue;
	};

	STDMETHOD(SetSelection)(
		/*[in]*/ long iStart,
		/*[in]*/ long iEnd)
	{
		VSL_DEFINE_MOCK_METHOD(SetSelection)

		VSL_CHECK_VALIDVALUE(iStart);

		VSL_CHECK_VALIDVALUE(iEnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTextValidValues
	{
		/*[in]*/ BSTR bstrText;
		/*[in]*/ BOOL fReplaceAll;
		HRESULT retValue;
	};

	STDMETHOD(SetText)(
		/*[in]*/ BSTR bstrText,
		/*[in]*/ BOOL fReplaceAll)
	{
		VSL_DEFINE_MOCK_METHOD(SetText)

		VSL_CHECK_VALIDVALUE_BSTR(bstrText);

		VSL_CHECK_VALIDVALUE(fReplaceAll);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentLevelValidValues
	{
		/*[out]*/ long* pLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentLevel)(
		/*[out]*/ long* pLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentLevel)

		VSL_SET_VALIDVALUE(pLevel);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONINTELLISENSEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
