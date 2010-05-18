/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGEBLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGEBLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageBlockNotImpl :
	public IVsLanguageBlock
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageBlockNotImpl)

public:

	typedef IVsLanguageBlock Interface;

	STDMETHOD(GetCurrentBlock)(
		/*[in]*/ IVsTextLines* /*pTextLines*/,
		/*[in]*/ LONG /*iCurrentLine*/,
		/*[in]*/ LONG /*iCurrentChar*/,
		/*[out]*/ TextSpan* /*ptsBlockSpan*/,
		/*[out]*/ BSTR* /*pbstrDescription*/,
		/*[out,retval]*/ BOOL* /*pfBlockAvailable*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageBlockMockImpl :
	public IVsLanguageBlock,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageBlockMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageBlockMockImpl)

	typedef IVsLanguageBlock Interface;
	struct GetCurrentBlockValidValues
	{
		/*[in]*/ IVsTextLines* pTextLines;
		/*[in]*/ LONG iCurrentLine;
		/*[in]*/ LONG iCurrentChar;
		/*[out]*/ TextSpan* ptsBlockSpan;
		/*[out]*/ BSTR* pbstrDescription;
		/*[out,retval]*/ BOOL* pfBlockAvailable;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentBlock)(
		/*[in]*/ IVsTextLines* pTextLines,
		/*[in]*/ LONG iCurrentLine,
		/*[in]*/ LONG iCurrentChar,
		/*[out]*/ TextSpan* ptsBlockSpan,
		/*[out]*/ BSTR* pbstrDescription,
		/*[out,retval]*/ BOOL* pfBlockAvailable)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentBlock)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLines);

		VSL_CHECK_VALIDVALUE(iCurrentLine);

		VSL_CHECK_VALIDVALUE(iCurrentChar);

		VSL_SET_VALIDVALUE(ptsBlockSpan);

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_SET_VALIDVALUE(pfBlockAvailable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGEBLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
