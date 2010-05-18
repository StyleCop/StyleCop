/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGETEXTOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGETEXTOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageTextOpsNotImpl :
	public IVsLanguageTextOps
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageTextOpsNotImpl)

public:

	typedef IVsLanguageTextOps Interface;

	STDMETHOD(GetDataTip)(
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[in]*/ const TextSpan* /*ptsSel*/,
		/*[out]*/ TextSpan* /*ptsTip*/,
		/*[out,retval]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPairExtent)(
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[in]*/ TextAddress /*ta*/,
		/*[out,retval]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWordExtent)(
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[in]*/ TextAddress /*ta*/,
		/*[in]*/ WORDEXTFLAGS /*flags*/,
		/*[out,retval]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Format)(
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[in]*/ const TextSpan* /*ptsSel*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageTextOpsMockImpl :
	public IVsLanguageTextOps,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageTextOpsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageTextOpsMockImpl)

	typedef IVsLanguageTextOps Interface;
	struct GetDataTipValidValues
	{
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[in]*/ TextSpan* ptsSel;
		/*[out]*/ TextSpan* ptsTip;
		/*[out,retval]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetDataTip)(
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[in]*/ const TextSpan* ptsSel,
		/*[out]*/ TextSpan* ptsTip,
		/*[out,retval]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetDataTip)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_CHECK_VALIDVALUE_POINTER(ptsSel);

		VSL_SET_VALIDVALUE(ptsTip);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPairExtentValidValues
	{
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[in]*/ TextAddress ta;
		/*[out,retval]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetPairExtent)(
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[in]*/ TextAddress ta,
		/*[out,retval]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetPairExtent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_CHECK_VALIDVALUE(ta);

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWordExtentValidValues
	{
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[in]*/ TextAddress ta;
		/*[in]*/ WORDEXTFLAGS flags;
		/*[out,retval]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetWordExtent)(
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[in]*/ TextAddress ta,
		/*[in]*/ WORDEXTFLAGS flags,
		/*[out,retval]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetWordExtent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_CHECK_VALIDVALUE(ta);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct FormatValidValues
	{
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[in]*/ TextSpan* ptsSel;
		HRESULT retValue;
	};

	STDMETHOD(Format)(
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[in]*/ const TextSpan* ptsSel)
	{
		VSL_DEFINE_MOCK_METHOD(Format)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_CHECK_VALIDVALUE_POINTER(ptsSel);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGETEXTOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
