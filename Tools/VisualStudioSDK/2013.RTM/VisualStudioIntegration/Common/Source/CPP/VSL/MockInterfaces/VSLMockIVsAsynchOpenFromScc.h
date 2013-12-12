/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSASYNCHOPENFROMSCC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSASYNCHOPENFROMSCC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAsynchOpenFromSccNotImpl :
	public IVsAsynchOpenFromScc
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsynchOpenFromSccNotImpl)

public:

	typedef IVsAsynchOpenFromScc Interface;

	STDMETHOD(LoadProjectAsynchronously)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[out]*/ BOOL* /*pReturnValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadProject)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsLoadingContent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ BOOL* /*pfIsLoading*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAsynchOpenFromSccMockImpl :
	public IVsAsynchOpenFromScc,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAsynchOpenFromSccMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAsynchOpenFromSccMockImpl)

	typedef IVsAsynchOpenFromScc Interface;
	struct LoadProjectAsynchronouslyValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[out]*/ BOOL* pReturnValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadProjectAsynchronously)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[out]*/ BOOL* pReturnValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadProjectAsynchronously)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_SET_VALIDVALUE(pReturnValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadProjectValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		HRESULT retValue;
	};

	STDMETHOD(LoadProject)(
		/*[in]*/ LPCOLESTR lpszProjectPath)
	{
		VSL_DEFINE_MOCK_METHOD(LoadProject)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsLoadingContentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ BOOL* pfIsLoading;
		HRESULT retValue;
	};

	STDMETHOD(IsLoadingContent)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ BOOL* pfIsLoading)
	{
		VSL_DEFINE_MOCK_METHOD(IsLoadingContent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE(pfIsLoading);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSASYNCHOPENFROMSCC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
