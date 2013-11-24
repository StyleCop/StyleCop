/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPATHVARIABLERESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPATHVARIABLERESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsPathVariableResolverNotImpl :
	public IVsPathVariableResolver
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPathVariableResolverNotImpl)

public:

	typedef IVsPathVariableResolver Interface;

	STDMETHOD(ResolvePath)(
		/*[in]*/ LPCOLESTR /*strEncodedPath*/,
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS /*dwFlags*/,
		/*[out]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodePath)(
		/*[in]*/ LPCOLESTR /*strPath*/,
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS /*dwFlags*/,
		/*[out]*/ BSTR* /*pbstrEncodedPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPathVariableResolverMockImpl :
	public IVsPathVariableResolver,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPathVariableResolverMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPathVariableResolverMockImpl)

	typedef IVsPathVariableResolver Interface;
	struct ResolvePathValidValues
	{
		/*[in]*/ LPCOLESTR strEncodedPath;
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS dwFlags;
		/*[out]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(ResolvePath)(
		/*[in]*/ LPCOLESTR strEncodedPath,
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS dwFlags,
		/*[out]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(ResolvePath)

		VSL_CHECK_VALIDVALUE_STRINGW(strEncodedPath);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodePathValidValues
	{
		/*[in]*/ LPCOLESTR strPath;
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS dwFlags;
		/*[out]*/ BSTR* pbstrEncodedPath;
		HRESULT retValue;
	};

	STDMETHOD(EncodePath)(
		/*[in]*/ LPCOLESTR strPath,
		/*[in]*/ VSPROFILEPATHRESOLVERFLAGS dwFlags,
		/*[out]*/ BSTR* pbstrEncodedPath)
	{
		VSL_DEFINE_MOCK_METHOD(EncodePath)

		VSL_CHECK_VALIDVALUE_STRINGW(strPath);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_BSTR(pbstrEncodedPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPATHVARIABLERESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
