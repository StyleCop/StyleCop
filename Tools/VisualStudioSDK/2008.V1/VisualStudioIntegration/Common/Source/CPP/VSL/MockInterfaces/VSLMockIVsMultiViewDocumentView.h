/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMULTIVIEWDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMULTIVIEWDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMultiViewDocumentViewNotImpl :
	public IVsMultiViewDocumentView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMultiViewDocumentViewNotImpl)

public:

	typedef IVsMultiViewDocumentView Interface;

	STDMETHOD(ActivateLogicalView)(
		/*[in]*/ REFGUID /*rguidLogicalView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetActiveLogicalView)(
		/*[out]*/ GUID* /*pguidLogicalView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsLogicalViewActive)(
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ BOOL* /*pIsActive*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMultiViewDocumentViewMockImpl :
	public IVsMultiViewDocumentView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMultiViewDocumentViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMultiViewDocumentViewMockImpl)

	typedef IVsMultiViewDocumentView Interface;
	struct ActivateLogicalViewValidValues
	{
		/*[in]*/ REFGUID rguidLogicalView;
		HRESULT retValue;
	};

	STDMETHOD(ActivateLogicalView)(
		/*[in]*/ REFGUID rguidLogicalView)
	{
		VSL_DEFINE_MOCK_METHOD(ActivateLogicalView)

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetActiveLogicalViewValidValues
	{
		/*[out]*/ GUID* pguidLogicalView;
		HRESULT retValue;
	};

	STDMETHOD(GetActiveLogicalView)(
		/*[out]*/ GUID* pguidLogicalView)
	{
		VSL_DEFINE_MOCK_METHOD(GetActiveLogicalView)

		VSL_SET_VALIDVALUE(pguidLogicalView);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsLogicalViewActiveValidValues
	{
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ BOOL* pIsActive;
		HRESULT retValue;
	};

	STDMETHOD(IsLogicalViewActive)(
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ BOOL* pIsActive)
	{
		VSL_DEFINE_MOCK_METHOD(IsLogicalViewActive)

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE(pIsActive);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMULTIVIEWDOCUMENTVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
