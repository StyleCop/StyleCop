/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGECOLORIZER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGECOLORIZER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsContainedLanguageColorizerNotImpl :
	public IVsContainedLanguageColorizer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageColorizerNotImpl)

public:

	typedef IVsContainedLanguageColorizer Interface;

	STDMETHOD(ColorizeLineFragment)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iIndex*/,
		/*[in]*/ long /*iLength*/,
		/*[in]*/ const WCHAR* /*pszText*/,
		/*[in]*/ long /*iState*/,
		/*[out]*/ ULONG* /*pAttributes*/,
		/*[out]*/ long* /*piNewState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageColorizerMockImpl :
	public IVsContainedLanguageColorizer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageColorizerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageColorizerMockImpl)

	typedef IVsContainedLanguageColorizer Interface;
	struct ColorizeLineFragmentValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ long iIndex;
		/*[in]*/ long iLength;
		/*[in]*/ WCHAR* pszText;
		/*[in]*/ long iState;
		/*[out]*/ ULONG* pAttributes;
		/*[out]*/ long* piNewState;
		HRESULT retValue;
	};

	STDMETHOD(ColorizeLineFragment)(
		/*[in]*/ long iLine,
		/*[in]*/ long iIndex,
		/*[in]*/ long iLength,
		/*[in]*/ const WCHAR* pszText,
		/*[in]*/ long iState,
		/*[out]*/ ULONG* pAttributes,
		/*[out]*/ long* piNewState)
	{
		VSL_DEFINE_MOCK_METHOD(ColorizeLineFragment)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_CHECK_VALIDVALUE(iLength);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iState);

		VSL_SET_VALIDVALUE(pAttributes);

		VSL_SET_VALIDVALUE(piNewState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGECOLORIZER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
