/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLAYEREDTEXTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLAYEREDTEXTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLayeredTextViewNotImpl :
	public IVsLayeredTextView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLayeredTextViewNotImpl)

public:

	typedef IVsLayeredTextView Interface;

	STDMETHOD(GetSelectedAtom)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ IUnknown** /*ppunkAtom*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRelativeSelectionState)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IVsTextLayer* /*pReferenceLayer*/,
		/*[out]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRelativeSelectionState)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IVsTextLayer* /*pReferenceLayer*/,
		/*[in]*/ SELECTIONSTATE* /*pSelState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTopmostLayer)(
		/*[out]*/ IVsTextLayer** /*ppLayer*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLayeredTextViewMockImpl :
	public IVsLayeredTextView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLayeredTextViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLayeredTextViewMockImpl)

	typedef IVsLayeredTextView Interface;
	struct GetSelectedAtomValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ IUnknown** ppunkAtom;
		HRESULT retValue;
	};

	STDMETHOD(GetSelectedAtom)(
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ IUnknown** ppunkAtom)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelectedAtom)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkAtom);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRelativeSelectionStateValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IVsTextLayer* pReferenceLayer;
		/*[out]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(GetRelativeSelectionState)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IVsTextLayer* pReferenceLayer,
		/*[out]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(GetRelativeSelectionState)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReferenceLayer);

		VSL_SET_VALIDVALUE(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRelativeSelectionStateValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IVsTextLayer* pReferenceLayer;
		/*[in]*/ SELECTIONSTATE* pSelState;
		HRESULT retValue;
	};

	STDMETHOD(SetRelativeSelectionState)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IVsTextLayer* pReferenceLayer,
		/*[in]*/ SELECTIONSTATE* pSelState)
	{
		VSL_DEFINE_MOCK_METHOD(SetRelativeSelectionState)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReferenceLayer);

		VSL_CHECK_VALIDVALUE_POINTER(pSelState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTopmostLayerValidValues
	{
		/*[out]*/ IVsTextLayer** ppLayer;
		HRESULT retValue;
	};

	STDMETHOD(GetTopmostLayer)(
		/*[out]*/ IVsTextLayer** ppLayer)
	{
		VSL_DEFINE_MOCK_METHOD(GetTopmostLayer)

		VSL_SET_VALIDVALUE_INTERFACE(ppLayer);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLAYEREDTEXTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
