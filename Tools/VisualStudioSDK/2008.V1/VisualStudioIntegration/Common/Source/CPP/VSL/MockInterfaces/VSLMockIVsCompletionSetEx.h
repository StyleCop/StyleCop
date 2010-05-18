/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPLETIONSETEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPLETIONSETEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCompletionSetExNotImpl :
	public IVsCompletionSetEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompletionSetExNotImpl)

public:

	typedef IVsCompletionSetEx Interface;

	STDMETHOD(GetCompletionItemColor)(
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ COLORREF* /*dwFGColor*/,
		/*[out]*/ COLORREF* /*dwBGColor*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFilterLevel)(
		/*[out]*/ long* /*iFilterLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IncreaseFilterLevel)(
		/*[in]*/ long /*iSelectedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DecreaseFilterLevel)(
		/*[in]*/ long /*iSelectedItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CompareItems)(
		/*[in]*/ const BSTR /*bstrSoFar*/,
		/*[in]*/ const BSTR /*bstrOther*/,
		/*[in]*/ long /*lCharactersToCompare*/,
		/*[out]*/ long* /*plResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCommitComplete)()VSL_STDMETHOD_NOTIMPL
};

class IVsCompletionSetExMockImpl :
	public IVsCompletionSetEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompletionSetExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCompletionSetExMockImpl)

	typedef IVsCompletionSetEx Interface;
	struct GetCompletionItemColorValidValues
	{
		/*[in]*/ long iIndex;
		/*[out]*/ COLORREF* dwFGColor;
		/*[out]*/ COLORREF* dwBGColor;
		HRESULT retValue;
	};

	STDMETHOD(GetCompletionItemColor)(
		/*[in]*/ long iIndex,
		/*[out]*/ COLORREF* dwFGColor,
		/*[out]*/ COLORREF* dwBGColor)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompletionItemColor)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(dwFGColor);

		VSL_SET_VALIDVALUE(dwBGColor);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFilterLevelValidValues
	{
		/*[out]*/ long* iFilterLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetFilterLevel)(
		/*[out]*/ long* iFilterLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetFilterLevel)

		VSL_SET_VALIDVALUE(iFilterLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct IncreaseFilterLevelValidValues
	{
		/*[in]*/ long iSelectedItem;
		HRESULT retValue;
	};

	STDMETHOD(IncreaseFilterLevel)(
		/*[in]*/ long iSelectedItem)
	{
		VSL_DEFINE_MOCK_METHOD(IncreaseFilterLevel)

		VSL_CHECK_VALIDVALUE(iSelectedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct DecreaseFilterLevelValidValues
	{
		/*[in]*/ long iSelectedItem;
		HRESULT retValue;
	};

	STDMETHOD(DecreaseFilterLevel)(
		/*[in]*/ long iSelectedItem)
	{
		VSL_DEFINE_MOCK_METHOD(DecreaseFilterLevel)

		VSL_CHECK_VALIDVALUE(iSelectedItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct CompareItemsValidValues
	{
		/*[in]*/ BSTR bstrSoFar;
		/*[in]*/ BSTR bstrOther;
		/*[in]*/ long lCharactersToCompare;
		/*[out]*/ long* plResult;
		HRESULT retValue;
	};

	STDMETHOD(CompareItems)(
		/*[in]*/ const BSTR bstrSoFar,
		/*[in]*/ const BSTR bstrOther,
		/*[in]*/ long lCharactersToCompare,
		/*[out]*/ long* plResult)
	{
		VSL_DEFINE_MOCK_METHOD(CompareItems)

		VSL_CHECK_VALIDVALUE_BSTR(bstrSoFar);

		VSL_CHECK_VALIDVALUE_BSTR(bstrOther);

		VSL_CHECK_VALIDVALUE(lCharactersToCompare);

		VSL_SET_VALIDVALUE(plResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCommitCompleteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnCommitComplete)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnCommitComplete)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPLETIONSETEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
