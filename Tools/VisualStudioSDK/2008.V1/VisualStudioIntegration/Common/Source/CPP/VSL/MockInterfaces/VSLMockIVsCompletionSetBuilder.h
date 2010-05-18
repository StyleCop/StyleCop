/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPLETIONSETBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPLETIONSETBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCompletionSetBuilderNotImpl :
	public IVsCompletionSetBuilder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompletionSetBuilderNotImpl)

public:

	typedef IVsCompletionSetBuilder Interface;

	STDMETHOD(GetBuilderCount)(
		/*[in]*/ long* /*piCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuilderDisplayText)(
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ BSTR* /*pbstrText*/,
		/*[out,optional]*/ long* /*piGlyph*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuilderDescriptionText)(
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuilderImageList)(
		/*[out]*/ HANDLE* /*phImages*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBuilderCommit)(
		/*[in]*/ long /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuilderItemColor)(
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ COLORREF* /*dwFGColor*/,
		/*[out]*/ COLORREF* /*dwBGColor*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCompletionSetBuilderMockImpl :
	public IVsCompletionSetBuilder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCompletionSetBuilderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCompletionSetBuilderMockImpl)

	typedef IVsCompletionSetBuilder Interface;
	struct GetBuilderCountValidValues
	{
		/*[in]*/ long* piCount;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilderCount)(
		/*[in]*/ long* piCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilderCount)

		VSL_CHECK_VALIDVALUE_POINTER(piCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuilderDisplayTextValidValues
	{
		/*[in]*/ long iIndex;
		/*[out]*/ BSTR* pbstrText;
		/*[out,optional]*/ long* piGlyph;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilderDisplayText)(
		/*[in]*/ long iIndex,
		/*[out]*/ BSTR* pbstrText,
		/*[out,optional]*/ long* piGlyph)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilderDisplayText)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_SET_VALIDVALUE(piGlyph);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuilderDescriptionTextValidValues
	{
		/*[in]*/ long iIndex;
		/*[out]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilderDescriptionText)(
		/*[in]*/ long iIndex,
		/*[out]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilderDescriptionText)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuilderImageListValidValues
	{
		/*[out]*/ HANDLE* phImages;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilderImageList)(
		/*[out]*/ HANDLE* phImages)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilderImageList)

		VSL_SET_VALIDVALUE(phImages);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBuilderCommitValidValues
	{
		/*[in]*/ long iIndex;
		HRESULT retValue;
	};

	STDMETHOD(OnBuilderCommit)(
		/*[in]*/ long iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(OnBuilderCommit)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuilderItemColorValidValues
	{
		/*[in]*/ long iIndex;
		/*[out]*/ COLORREF* dwFGColor;
		/*[out]*/ COLORREF* dwBGColor;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilderItemColor)(
		/*[in]*/ long iIndex,
		/*[out]*/ COLORREF* dwFGColor,
		/*[out]*/ COLORREF* dwBGColor)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilderItemColor)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(dwFGColor);

		VSL_SET_VALIDVALUE(dwBGColor);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPLETIONSETBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
