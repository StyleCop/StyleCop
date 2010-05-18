/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDOCOUTLINEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDOCOUTLINEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDocOutlineProviderNotImpl :
	public IVsDocOutlineProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocOutlineProviderNotImpl)

public:

	typedef IVsDocOutlineProvider Interface;

	STDMETHOD(GetOutlineCaption)(
		/*[in]*/ VSOUTLINECAPTION /*nCaptionType*/,
		/*[out]*/ BSTR* /*pbstrCaption*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOutline)(
		/*[out]*/ HWND* /*phwnd*/,
		/*[out]*/ IOleCommandTarget** /*ppCmdTarget*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseOutline)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ IOleCommandTarget* /*pCmdTarget*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnOutlineStateChange)(
		/*[in]*/ VSOUTLINESTATES /*dwMask*/,
		/*[in]*/ VSOUTLINESTATES /*dwState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDocOutlineProviderMockImpl :
	public IVsDocOutlineProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDocOutlineProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDocOutlineProviderMockImpl)

	typedef IVsDocOutlineProvider Interface;
	struct GetOutlineCaptionValidValues
	{
		/*[in]*/ VSOUTLINECAPTION nCaptionType;
		/*[out]*/ BSTR* pbstrCaption;
		HRESULT retValue;
	};

	STDMETHOD(GetOutlineCaption)(
		/*[in]*/ VSOUTLINECAPTION nCaptionType,
		/*[out]*/ BSTR* pbstrCaption)
	{
		VSL_DEFINE_MOCK_METHOD(GetOutlineCaption)

		VSL_CHECK_VALIDVALUE(nCaptionType);

		VSL_SET_VALIDVALUE_BSTR(pbstrCaption);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOutlineValidValues
	{
		/*[out]*/ HWND* phwnd;
		/*[out]*/ IOleCommandTarget** ppCmdTarget;
		HRESULT retValue;
	};

	STDMETHOD(GetOutline)(
		/*[out]*/ HWND* phwnd,
		/*[out]*/ IOleCommandTarget** ppCmdTarget)
	{
		VSL_DEFINE_MOCK_METHOD(GetOutline)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_SET_VALIDVALUE_INTERFACE(ppCmdTarget);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseOutlineValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ IOleCommandTarget* pCmdTarget;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseOutline)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ IOleCommandTarget* pCmdTarget)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseOutline)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdTarget);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnOutlineStateChangeValidValues
	{
		/*[in]*/ VSOUTLINESTATES dwMask;
		/*[in]*/ VSOUTLINESTATES dwState;
		HRESULT retValue;
	};

	STDMETHOD(OnOutlineStateChange)(
		/*[in]*/ VSOUTLINESTATES dwMask,
		/*[in]*/ VSOUTLINESTATES dwState)
	{
		VSL_DEFINE_MOCK_METHOD(OnOutlineStateChange)

		VSL_CHECK_VALIDVALUE(dwMask);

		VSL_CHECK_VALIDVALUE(dwState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDOCOUTLINEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
