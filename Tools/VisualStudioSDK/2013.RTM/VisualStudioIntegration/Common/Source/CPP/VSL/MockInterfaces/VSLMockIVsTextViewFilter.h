/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTVIEWFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTVIEWFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextViewFilterNotImpl :
	public IVsTextViewFilter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewFilterNotImpl)

public:

	typedef IVsTextViewFilter Interface;

	STDMETHOD(GetWordExtent)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDataTipText)(
		/*[in,out]*/ TextSpan* /*pSpan*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPairExtents)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[out]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextViewFilterMockImpl :
	public IVsTextViewFilter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewFilterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextViewFilterMockImpl)

	typedef IVsTextViewFilter Interface;
	struct GetWordExtentValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetWordExtent)(
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetWordExtent)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE(pSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDataTipTextValidValues
	{
		/*[in,out]*/ TextSpan* pSpan;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetDataTipText)(
		/*[in,out]*/ TextSpan* pSpan,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetDataTipText)

		VSL_SET_VALIDVALUE(pSpan);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPairExtentsValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[out]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetPairExtents)(
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[out]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetPairExtents)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(pSpan);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTVIEWFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
