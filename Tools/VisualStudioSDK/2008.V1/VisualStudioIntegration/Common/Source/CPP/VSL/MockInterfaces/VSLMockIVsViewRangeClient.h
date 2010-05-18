/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSVIEWRANGECLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSVIEWRANGECLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsViewRangeClientNotImpl :
	public IVsViewRangeClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsViewRangeClientNotImpl)

public:

	typedef IVsViewRangeClient Interface;

	STDMETHOD(AdjustViewRange)(
		/*[in]*/ IVsTextView* /*pView*/,
		/*[in]*/ TextViewAction /*action*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsViewRangeClientMockImpl :
	public IVsViewRangeClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsViewRangeClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsViewRangeClientMockImpl)

	typedef IVsViewRangeClient Interface;
	struct AdjustViewRangeValidValues
	{
		/*[in]*/ IVsTextView* pView;
		/*[in]*/ TextViewAction action;
		/*[in]*/ long iLine;
		/*[in]*/ long iCount;
		HRESULT retValue;
	};

	STDMETHOD(AdjustViewRange)(
		/*[in]*/ IVsTextView* pView,
		/*[in]*/ TextViewAction action,
		/*[in]*/ long iLine,
		/*[in]*/ long iCount)
	{
		VSL_DEFINE_MOCK_METHOD(AdjustViewRange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_CHECK_VALIDVALUE(action);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSVIEWRANGECLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
