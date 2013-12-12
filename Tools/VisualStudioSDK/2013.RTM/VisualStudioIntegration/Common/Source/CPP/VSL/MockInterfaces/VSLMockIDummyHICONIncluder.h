/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDUMMYHICONINCLUDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDUMMYHICONINCLUDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDummyHICONIncluderNotImpl :
	public IDummyHICONIncluder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDummyHICONIncluderNotImpl)

public:

	typedef IDummyHICONIncluder Interface;

	STDMETHOD(Dummy)(
		/*[in]*/ HICON /*h1*/,
		/*[in]*/ HDC /*h2*/)VSL_STDMETHOD_NOTIMPL
};

class IDummyHICONIncluderMockImpl :
	public IDummyHICONIncluder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDummyHICONIncluderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDummyHICONIncluderMockImpl)

	typedef IDummyHICONIncluder Interface;
	struct DummyValidValues
	{
		/*[in]*/ HICON h1;
		/*[in]*/ HDC h2;
		HRESULT retValue;
	};

	STDMETHOD(Dummy)(
		/*[in]*/ HICON h1,
		/*[in]*/ HDC h2)
	{
		VSL_DEFINE_MOCK_METHOD(Dummy)

		VSL_CHECK_VALIDVALUE(h1);

		VSL_CHECK_VALIDVALUE(h2);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDUMMYHICONINCLUDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
