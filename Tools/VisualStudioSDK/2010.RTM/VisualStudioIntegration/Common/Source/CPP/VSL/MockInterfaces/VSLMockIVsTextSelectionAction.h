/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTSELECTIONACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTSELECTIONACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextSelectionActionNotImpl :
	public IVsTextSelectionAction
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextSelectionActionNotImpl)

public:

	typedef IVsTextSelectionAction Interface;

	STDMETHOD(GetOrigin)(
		/*[out]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDestination)(
		/*[out]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetOrigin)(
		/*[in]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDestination)(
		/*[in]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextSelectionActionMockImpl :
	public IVsTextSelectionAction,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextSelectionActionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextSelectionActionMockImpl)

	typedef IVsTextSelectionAction Interface;
	struct GetOriginValidValues
	{
		/*[out]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(GetOrigin)(
		/*[out]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(GetOrigin)

		VSL_SET_VALIDVALUE(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDestinationValidValues
	{
		/*[out]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(GetDestination)(
		/*[out]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(GetDestination)

		VSL_SET_VALIDVALUE(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetOriginValidValues
	{
		/*[in]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(SetOrigin)(
		/*[in]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(SetOrigin)

		VSL_CHECK_VALIDVALUE_POINTER(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDestinationValidValues
	{
		/*[in]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(SetDestination)(
		/*[in]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(SetDestination)

		VSL_CHECK_VALIDVALUE_POINTER(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTSELECTIONACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
