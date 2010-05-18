/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENREGIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENREGIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiddenRegionExNotImpl :
	public IVsHiddenRegionEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenRegionExNotImpl)

public:

	typedef IVsHiddenRegionEx Interface;

	STDMETHOD(GetBannerAttr)(
		/*[in]*/ DWORD /*dwLength*/,
		/*[out,size_is(dwLength)]*/ ULONG* /*pColorAttr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBannerAttr)(
		/*[in]*/ DWORD /*dwLength*/,
		/*[in,size_is(dwLength)]*/ ULONG* /*pColorAttr*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenRegionExMockImpl :
	public IVsHiddenRegionEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenRegionExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenRegionExMockImpl)

	typedef IVsHiddenRegionEx Interface;
	struct GetBannerAttrValidValues
	{
		/*[in]*/ DWORD dwLength;
		/*[out,size_is(dwLength)]*/ ULONG* pColorAttr;
		HRESULT retValue;
	};

	STDMETHOD(GetBannerAttr)(
		/*[in]*/ DWORD dwLength,
		/*[out,size_is(dwLength)]*/ ULONG* pColorAttr)
	{
		VSL_DEFINE_MOCK_METHOD(GetBannerAttr)

		VSL_CHECK_VALIDVALUE(dwLength);

		VSL_SET_VALIDVALUE_MEMCPY(pColorAttr, dwLength*sizeof(pColorAttr[0]), validValues.dwLength*sizeof(validValues.pColorAttr[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBannerAttrValidValues
	{
		/*[in]*/ DWORD dwLength;
		/*[in,size_is(dwLength)]*/ ULONG* pColorAttr;
		HRESULT retValue;
	};

	STDMETHOD(SetBannerAttr)(
		/*[in]*/ DWORD dwLength,
		/*[in,size_is(dwLength)]*/ ULONG* pColorAttr)
	{
		VSL_DEFINE_MOCK_METHOD(SetBannerAttr)

		VSL_CHECK_VALIDVALUE(dwLength);

		VSL_CHECK_VALIDVALUE_MEMCMP(pColorAttr, dwLength*sizeof(pColorAttr[0]), validValues.dwLength*sizeof(validValues.pColorAttr[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENREGIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
