/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsShell2NotImpl :
	public IVsShell2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShell2NotImpl)

public:

	typedef IVsShell2 Interface;

	STDMETHOD(LoadPackageStringWithLCID)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ ULONG /*resid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,retval]*/ BSTR* /*pbstrOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsShell2MockImpl :
	public IVsShell2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShell2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsShell2MockImpl)

	typedef IVsShell2 Interface;
	struct LoadPackageStringWithLCIDValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ ULONG resid;
		/*[in]*/ LCID lcid;
		/*[out,retval]*/ BSTR* pbstrOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadPackageStringWithLCID)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ ULONG resid,
		/*[in]*/ LCID lcid,
		/*[out,retval]*/ BSTR* pbstrOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadPackageStringWithLCID)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(resid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_BSTR(pbstrOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSHELL2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
