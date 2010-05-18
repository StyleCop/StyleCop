/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDOCOUTLINEPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDOCOUTLINEPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDocOutlineProvider2NotImpl :
	public IVsDocOutlineProvider2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocOutlineProvider2NotImpl)

public:

	typedef IVsDocOutlineProvider2 Interface;

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG /*lpMsg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDocOutlineProvider2MockImpl :
	public IVsDocOutlineProvider2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocOutlineProvider2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDocOutlineProvider2MockImpl)

	typedef IVsDocOutlineProvider2 Interface;
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ LPMSG lpMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG lpMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE(lpMsg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDOCOUTLINEPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
