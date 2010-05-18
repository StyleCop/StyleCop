/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTFIND_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTFIND_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextFindNotImpl :
	public IVsTextFind
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextFindNotImpl)

public:

	typedef IVsTextFind Interface;

	STDMETHOD(Find)(
		/*[in]*/ const WCHAR* /*pszText*/,
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ long /*iFlags*/,
		/*[out]*/ long* /*piLine*/,
		/*[out]*/ long* /*piCol*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextFindMockImpl :
	public IVsTextFind,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextFindMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextFindMockImpl)

	typedef IVsTextFind Interface;
	struct FindValidValues
	{
		/*[in]*/ WCHAR* pszText;
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ long iFlags;
		/*[out]*/ long* piLine;
		/*[out]*/ long* piCol;
		HRESULT retValue;
	};

	STDMETHOD(Find)(
		/*[in]*/ const WCHAR* pszText,
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ long iFlags,
		/*[out]*/ long* piLine,
		/*[out]*/ long* piCol)
	{
		VSL_DEFINE_MOCK_METHOD(Find)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE(iFlags);

		VSL_SET_VALIDVALUE(piLine);

		VSL_SET_VALIDVALUE(piCol);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTFIND_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
