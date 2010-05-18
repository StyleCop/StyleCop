/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXTCUSTOMIZE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXTCUSTOMIZE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUserContextCustomizeNotImpl :
	public IVsUserContextCustomize
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextCustomizeNotImpl)

public:

	typedef IVsUserContextCustomize Interface;

	STDMETHOD(GetLimitKeywordSource)(
		/*[out,retval]*/ LONG* /*pLimKwdSrc*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextCustomizeMockImpl :
	public IVsUserContextCustomize,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextCustomizeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextCustomizeMockImpl)

	typedef IVsUserContextCustomize Interface;
	struct GetLimitKeywordSourceValidValues
	{
		/*[out,retval]*/ LONG* pLimKwdSrc;
		HRESULT retValue;
	};

	STDMETHOD(GetLimitKeywordSource)(
		/*[out,retval]*/ LONG* pLimKwdSrc)
	{
		VSL_DEFINE_MOCK_METHOD(GetLimitKeywordSource)

		VSL_SET_VALIDVALUE(pLimKwdSrc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXTCUSTOMIZE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
