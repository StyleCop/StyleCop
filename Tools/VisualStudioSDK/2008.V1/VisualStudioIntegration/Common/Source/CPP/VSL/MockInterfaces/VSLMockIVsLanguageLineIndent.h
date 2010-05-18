/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGELINEINDENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGELINEINDENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageLineIndentNotImpl :
	public IVsLanguageLineIndent
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageLineIndentNotImpl)

public:

	typedef IVsLanguageLineIndent Interface;

	STDMETHOD(GetIndentPosition)(
		/*[in]*/ IVsTextLayer* /*pBaseLayer*/,
		/*[in]*/ long /*BaseBufferLineIndex*/,
		/*[out]*/ long* /*pIndentPosition*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageLineIndentMockImpl :
	public IVsLanguageLineIndent,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageLineIndentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageLineIndentMockImpl)

	typedef IVsLanguageLineIndent Interface;
	struct GetIndentPositionValidValues
	{
		/*[in]*/ IVsTextLayer* pBaseLayer;
		/*[in]*/ long BaseBufferLineIndex;
		/*[out]*/ long* pIndentPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetIndentPosition)(
		/*[in]*/ IVsTextLayer* pBaseLayer,
		/*[in]*/ long BaseBufferLineIndex,
		/*[out]*/ long* pIndentPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetIndentPosition)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBaseLayer);

		VSL_CHECK_VALIDVALUE(BaseBufferLineIndex);

		VSL_SET_VALIDVALUE(pIndentPosition);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGELINEINDENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
