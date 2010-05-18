/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDTARGET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDTARGET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFindTarget2NotImpl :
	public IVsFindTarget2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindTarget2NotImpl)

public:

	typedef IVsFindTarget2 Interface;

	STDMETHOD(NavigateTo2)(
		/*[in]*/ IVsTextSpanSet* /*pSpans*/,
		/*[in]*/ _TextSelMode /*iSelMode*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindTarget2MockImpl :
	public IVsFindTarget2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindTarget2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindTarget2MockImpl)

	typedef IVsFindTarget2 Interface;
	struct NavigateTo2ValidValues
	{
		/*[in]*/ IVsTextSpanSet* pSpans;
		/*[in]*/ _TextSelMode iSelMode;
		HRESULT retValue;
	};

	STDMETHOD(NavigateTo2)(
		/*[in]*/ IVsTextSpanSet* pSpans,
		/*[in]*/ _TextSelMode iSelMode)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateTo2)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSpans);

		VSL_CHECK_VALIDVALUE(iSelMode);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDTARGET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
