/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSEPROJECTHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSEPROJECTHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsIntellisenseProjectHostNotImpl :
	public IVsIntellisenseProjectHost
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectHostNotImpl)

public:

	typedef IVsIntellisenseProjectHost Interface;

	STDMETHOD(GetHostProperty)(
		/*[in]*/ DWORD /*dwPropID*/,
		/*[out,retval]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompilerOptions)(
		/*[out,retval]*/ BSTR* /*pbstrOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOutputAssembly)(
		/*[out,retval]*/ BSTR* /*pbstrOutputAssembly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateFileCodeModel)(
		/*[in]*/ LPCWSTR /*pszFilename*/,
		/*[out,retval]*/ IUnknown** /*ppCodeModel*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseProjectHostMockImpl :
	public IVsIntellisenseProjectHost,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectHostMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseProjectHostMockImpl)

	typedef IVsIntellisenseProjectHost Interface;
	struct GetHostPropertyValidValues
	{
		/*[in]*/ DWORD dwPropID;
		/*[out,retval]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetHostProperty)(
		/*[in]*/ DWORD dwPropID,
		/*[out,retval]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostProperty)

		VSL_CHECK_VALIDVALUE(dwPropID);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompilerOptionsValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOptions;
		HRESULT retValue;
	};

	STDMETHOD(GetCompilerOptions)(
		/*[out,retval]*/ BSTR* pbstrOptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompilerOptions)

		VSL_SET_VALIDVALUE_BSTR(pbstrOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOutputAssemblyValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOutputAssembly;
		HRESULT retValue;
	};

	STDMETHOD(GetOutputAssembly)(
		/*[out,retval]*/ BSTR* pbstrOutputAssembly)
	{
		VSL_DEFINE_MOCK_METHOD(GetOutputAssembly)

		VSL_SET_VALIDVALUE_BSTR(pbstrOutputAssembly);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateFileCodeModelValidValues
	{
		/*[in]*/ LPCWSTR pszFilename;
		/*[out,retval]*/ IUnknown** ppCodeModel;
		HRESULT retValue;
	};

	STDMETHOD(CreateFileCodeModel)(
		/*[in]*/ LPCWSTR pszFilename,
		/*[out,retval]*/ IUnknown** ppCodeModel)
	{
		VSL_DEFINE_MOCK_METHOD(CreateFileCodeModel)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeModel);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSEPROJECTHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
