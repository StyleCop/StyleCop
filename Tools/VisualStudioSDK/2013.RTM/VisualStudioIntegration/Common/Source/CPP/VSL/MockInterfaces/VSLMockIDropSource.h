/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDROPSOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDROPSOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDropSourceNotImpl :
	public IDropSource
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDropSourceNotImpl)

public:

	typedef IDropSource Interface;

	STDMETHOD(QueryContinueDrag)(
		/*[in]*/ BOOL /*fEscapePressed*/,
		/*[in]*/ DWORD /*grfKeyState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GiveFeedback)(
		/*[in]*/ DWORD /*dwEffect*/)VSL_STDMETHOD_NOTIMPL
};

class IDropSourceMockImpl :
	public IDropSource,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDropSourceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDropSourceMockImpl)

	typedef IDropSource Interface;
	struct QueryContinueDragValidValues
	{
		/*[in]*/ BOOL fEscapePressed;
		/*[in]*/ DWORD grfKeyState;
		HRESULT retValue;
	};

	STDMETHOD(QueryContinueDrag)(
		/*[in]*/ BOOL fEscapePressed,
		/*[in]*/ DWORD grfKeyState)
	{
		VSL_DEFINE_MOCK_METHOD(QueryContinueDrag)

		VSL_CHECK_VALIDVALUE(fEscapePressed);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GiveFeedbackValidValues
	{
		/*[in]*/ DWORD dwEffect;
		HRESULT retValue;
	};

	STDMETHOD(GiveFeedback)(
		/*[in]*/ DWORD dwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(GiveFeedback)

		VSL_CHECK_VALIDVALUE(dwEffect);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDROPSOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
