/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENUMTEXTSPANS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENUMTEXTSPANS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsEnumTextSpansNotImpl :
	public IVsEnumTextSpans
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumTextSpansNotImpl)

public:

	typedef IVsEnumTextSpans Interface;

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*cEl*/,
		/*[out,size_is(cEl)]*/ TextSpan* /*ppOut*/,
		/*[out]*/ ULONG* /*pcElFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* /*pcSpans*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEnumTextSpansMockImpl :
	public IVsEnumTextSpans,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumTextSpansMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEnumTextSpansMockImpl)

	typedef IVsEnumTextSpans Interface;
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct NextValidValues
	{
		/*[in]*/ ULONG cEl;
		/*[out,size_is(cEl)]*/ TextSpan* ppOut;
		/*[out]*/ ULONG* pcElFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG cEl,
		/*[out,size_is(cEl)]*/ TextSpan* ppOut,
		/*[out]*/ ULONG* pcElFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(cEl);

		VSL_SET_VALIDVALUE_MEMCPY(ppOut, cEl*sizeof(ppOut[0]), validValues.cEl*sizeof(validValues.ppOut[0]));

		VSL_SET_VALIDVALUE(pcElFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCountValidValues
	{
		/*[out]*/ ULONG* pcSpans;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* pcSpans)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pcSpans);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENUMTEXTSPANS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
