/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCENLISTMENTPATHTRANSLATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCENLISTMENTPATHTRANSLATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccEnlistmentPathTranslation.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccEnlistmentPathTranslationNotImpl :
	public IVsSccEnlistmentPathTranslation
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccEnlistmentPathTranslationNotImpl)

public:

	typedef IVsSccEnlistmentPathTranslation Interface;

	STDMETHOD(TranslateProjectPathToEnlistmentPath)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[out]*/ BSTR* /*pbstrEnlistmentPath*/,
		/*[out]*/ BSTR* /*pbstrEnlistmentPathUNC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateEnlistmentPathToProjectPath)(
		/*[in]*/ LPCOLESTR /*lpszEnlistmentPath*/,
		/*[out,retval]*/ BSTR* /*pbstrProjectPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccEnlistmentPathTranslationMockImpl :
	public IVsSccEnlistmentPathTranslation,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccEnlistmentPathTranslationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccEnlistmentPathTranslationMockImpl)

	typedef IVsSccEnlistmentPathTranslation Interface;
	struct TranslateProjectPathToEnlistmentPathValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[out]*/ BSTR* pbstrEnlistmentPath;
		/*[out]*/ BSTR* pbstrEnlistmentPathUNC;
		HRESULT retValue;
	};

	STDMETHOD(TranslateProjectPathToEnlistmentPath)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[out]*/ BSTR* pbstrEnlistmentPath,
		/*[out]*/ BSTR* pbstrEnlistmentPathUNC)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateProjectPathToEnlistmentPath)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrEnlistmentPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrEnlistmentPathUNC);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateEnlistmentPathToProjectPathValidValues
	{
		/*[in]*/ LPCOLESTR lpszEnlistmentPath;
		/*[out,retval]*/ BSTR* pbstrProjectPath;
		HRESULT retValue;
	};

	STDMETHOD(TranslateEnlistmentPathToProjectPath)(
		/*[in]*/ LPCOLESTR lpszEnlistmentPath,
		/*[out,retval]*/ BSTR* pbstrProjectPath)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateEnlistmentPathToProjectPath)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszEnlistmentPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjectPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCENLISTMENTPATHTRANSLATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
