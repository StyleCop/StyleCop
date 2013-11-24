/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENUMINDEPENDENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENUMINDEPENDENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsEnumIndependentViewsNotImpl :
	public IVsEnumIndependentViews
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumIndependentViewsNotImpl)

public:

	typedef IVsEnumIndependentViews Interface;

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*celt*/,
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ IUnknown** /*rgelt*/,
		/*[out]*/ ULONG* /*pceltFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCount)(
		/*[in]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEnumIndependentViewsMockImpl :
	public IVsEnumIndependentViews,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumIndependentViewsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEnumIndependentViewsMockImpl)

	typedef IVsEnumIndependentViews Interface;
	struct NextValidValues
	{
		/*[in]*/ ULONG celt;
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ IUnknown** rgelt;
		/*[out]*/ ULONG* pceltFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG celt,
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ IUnknown** rgelt,
		/*[out]*/ ULONG* pceltFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgelt, celt, *(validValues.pceltFetched));

		VSL_SET_VALIDVALUE(pceltFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCountValidValues
	{
		/*[in]*/ ULONG* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[in]*/ ULONG* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_CHECK_VALIDVALUE_POINTER(pCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENUMINDEPENDENTVIEWS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
