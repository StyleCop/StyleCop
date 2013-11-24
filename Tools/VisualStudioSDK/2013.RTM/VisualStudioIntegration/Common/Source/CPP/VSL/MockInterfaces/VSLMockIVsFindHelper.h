/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFindHelperNotImpl :
	public IVsFindHelper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindHelperNotImpl)

public:

	typedef IVsFindHelper Interface;

	STDMETHOD(FindInText)(
		/*[in]*/ LPCOLESTR /*pszFind*/,
		/*[in]*/ LPCOLESTR /*pszReplace*/,
		/*[in]*/ VSFINDOPTIONS /*grfFindOptions*/,
		/*[in]*/ VSFINDBUFFERFLAGS /*grfBufferFlags*/,
		/*[in]*/ ULONG /*cchText*/,
		/*[in,size_is(cchText)]*/ LPCOLESTR /*pchText*/,
		/*[out]*/ ULONG* /*piFound*/,
		/*[out]*/ ULONG* /*pcchFound*/,
		/*[out]*/ BSTR* /*pbstrReplaceText*/,
		/*[out,retval]*/ BOOL* /*pfFound*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindHelperMockImpl :
	public IVsFindHelper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindHelperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindHelperMockImpl)

	typedef IVsFindHelper Interface;
	struct FindInTextValidValues
	{
		/*[in]*/ LPCOLESTR pszFind;
		/*[in]*/ LPCOLESTR pszReplace;
		/*[in]*/ VSFINDOPTIONS grfFindOptions;
		/*[in]*/ VSFINDBUFFERFLAGS grfBufferFlags;
		/*[in]*/ ULONG cchText;
		/*[in,size_is(cchText)]*/ LPCOLESTR pchText;
		/*[out]*/ ULONG* piFound;
		/*[out]*/ ULONG* pcchFound;
		/*[out]*/ BSTR* pbstrReplaceText;
		/*[out,retval]*/ BOOL* pfFound;
		HRESULT retValue;
	};

	STDMETHOD(FindInText)(
		/*[in]*/ LPCOLESTR pszFind,
		/*[in]*/ LPCOLESTR pszReplace,
		/*[in]*/ VSFINDOPTIONS grfFindOptions,
		/*[in]*/ VSFINDBUFFERFLAGS grfBufferFlags,
		/*[in]*/ ULONG cchText,
		/*[in,size_is(cchText)]*/ LPCOLESTR pchText,
		/*[out]*/ ULONG* piFound,
		/*[out]*/ ULONG* pcchFound,
		/*[out]*/ BSTR* pbstrReplaceText,
		/*[out,retval]*/ BOOL* pfFound)
	{
		VSL_DEFINE_MOCK_METHOD(FindInText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFind);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReplace);

		VSL_CHECK_VALIDVALUE(grfFindOptions);

		VSL_CHECK_VALIDVALUE(grfBufferFlags);

		VSL_CHECK_VALIDVALUE(cchText);

		VSL_CHECK_VALIDVALUE_STRINGW(pchText);

		VSL_SET_VALIDVALUE(piFound);

		VSL_SET_VALIDVALUE(pcchFound);

		VSL_SET_VALIDVALUE_BSTR(pbstrReplaceText);

		VSL_SET_VALIDVALUE(pfFound);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
