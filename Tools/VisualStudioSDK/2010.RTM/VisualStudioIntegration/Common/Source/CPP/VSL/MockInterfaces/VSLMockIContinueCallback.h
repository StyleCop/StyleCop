/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICONTINUECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICONTINUECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DocObj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IContinueCallbackNotImpl :
	public IContinueCallback
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IContinueCallbackNotImpl)

public:

	typedef IContinueCallback Interface;

	STDMETHOD(FContinue)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FContinuePrinting)(
		/*[in]*/ LONG /*nCntPrinted*/,
		/*[in]*/ LONG /*nCurPage*/,
		/*[in,unique]*/ wchar_t* /*pwszPrintStatus*/)VSL_STDMETHOD_NOTIMPL
};

class IContinueCallbackMockImpl :
	public IContinueCallback,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IContinueCallbackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IContinueCallbackMockImpl)

	typedef IContinueCallback Interface;
	struct FContinueValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FContinue)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FContinue)

		VSL_RETURN_VALIDVALUES();
	}
	struct FContinuePrintingValidValues
	{
		/*[in]*/ LONG nCntPrinted;
		/*[in]*/ LONG nCurPage;
		/*[in,unique]*/ wchar_t* pwszPrintStatus;
		HRESULT retValue;
	};

	STDMETHOD(FContinuePrinting)(
		/*[in]*/ LONG nCntPrinted,
		/*[in]*/ LONG nCurPage,
		/*[in,unique]*/ wchar_t* pwszPrintStatus)
	{
		VSL_DEFINE_MOCK_METHOD(FContinuePrinting)

		VSL_CHECK_VALIDVALUE(nCntPrinted);

		VSL_CHECK_VALIDVALUE(nCurPage);

		VSL_CHECK_VALIDVALUE_POINTER(pwszPrintStatus);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICONTINUECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
