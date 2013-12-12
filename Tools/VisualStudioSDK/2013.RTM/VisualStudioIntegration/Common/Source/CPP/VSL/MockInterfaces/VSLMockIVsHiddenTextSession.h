/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENTEXTSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENTEXTSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiddenTextSessionNotImpl :
	public IVsHiddenTextSession
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextSessionNotImpl)

public:

	typedef IVsHiddenTextSession Interface;

	STDMETHOD(AddHiddenRegions)(
		/*[in]*/ DWORD /*dwUpdateFlags*/,
		/*[in]*/ long /*cRegions*/,
		/*[in,size_is(cRegions)]*/ NewHiddenRegion* /*rgHidReg*/,
		/*[out]*/ IVsEnumHiddenRegions** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumHiddenRegions)(
		/*[in]*/ DWORD /*dwFindFlags*/,
		/*[in]*/ DWORD_PTR /*dwCookie*/,
		/*[in]*/ TextSpan* /*ptsRange*/,
		/*[out]*/ IVsEnumHiddenRegions** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseClient)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Terminate)()VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenTextSessionMockImpl :
	public IVsHiddenTextSession,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextSessionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenTextSessionMockImpl)

	typedef IVsHiddenTextSession Interface;
	struct AddHiddenRegionsValidValues
	{
		/*[in]*/ DWORD dwUpdateFlags;
		/*[in]*/ long cRegions;
		/*[in,size_is(cRegions)]*/ NewHiddenRegion* rgHidReg;
		/*[out]*/ IVsEnumHiddenRegions** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(AddHiddenRegions)(
		/*[in]*/ DWORD dwUpdateFlags,
		/*[in]*/ long cRegions,
		/*[in,size_is(cRegions)]*/ NewHiddenRegion* rgHidReg,
		/*[out]*/ IVsEnumHiddenRegions** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(AddHiddenRegions)

		VSL_CHECK_VALIDVALUE(dwUpdateFlags);

		VSL_CHECK_VALIDVALUE(cRegions);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgHidReg, cRegions*sizeof(rgHidReg[0]), validValues.cRegions*sizeof(validValues.rgHidReg[0]));

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumHiddenRegionsValidValues
	{
		/*[in]*/ DWORD dwFindFlags;
		/*[in]*/ DWORD_PTR dwCookie;
		/*[in]*/ TextSpan* ptsRange;
		/*[out]*/ IVsEnumHiddenRegions** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumHiddenRegions)(
		/*[in]*/ DWORD dwFindFlags,
		/*[in]*/ DWORD_PTR dwCookie,
		/*[in]*/ TextSpan* ptsRange,
		/*[out]*/ IVsEnumHiddenRegions** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumHiddenRegions)

		VSL_CHECK_VALIDVALUE(dwFindFlags);

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_CHECK_VALIDVALUE_POINTER(ptsRange);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseClientValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnadviseClient)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnadviseClient)

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Terminate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Terminate)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENTEXTSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
