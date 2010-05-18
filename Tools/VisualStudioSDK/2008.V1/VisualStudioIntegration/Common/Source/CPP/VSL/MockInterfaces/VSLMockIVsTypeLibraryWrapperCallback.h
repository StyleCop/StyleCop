/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTYPELIBRARYWRAPPERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTYPELIBRARYWRAPPERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTypeLibraryWrapperCallbackNotImpl :
	public IVsTypeLibraryWrapperCallback
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTypeLibraryWrapperCallbackNotImpl)

public:

	typedef IVsTypeLibraryWrapperCallback Interface;

	STDMETHOD(GetAssembly)(
		/*[in]*/ LPCOLESTR /*wszFusionName*/,
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetComClassic)(
		/*[in]*/ TLIBATTR* /*pTypeLibAttr*/,
		/*[in]*/ LPCOLESTR /*wszWrapperTool*/,
		/*[out]*/ BOOL* /*pDelaySigned*/,
		/*[out]*/ BSTR* /*pbstrWrapperTool*/,
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetComClassicByTypeLibName)(
		/*[in]*/ LPCOLESTR /*wszTypeLibName*/,
		/*[out]*/ TLIBATTR* /*pTypeLibAttr*/,
		/*[out]*/ BOOL* /*pDelaySigned*/,
		/*[out]*/ BSTR* /*pbstrWrapperTool*/,
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTypeLibraryWrapperCallbackMockImpl :
	public IVsTypeLibraryWrapperCallback,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTypeLibraryWrapperCallbackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTypeLibraryWrapperCallbackMockImpl)

	typedef IVsTypeLibraryWrapperCallback Interface;
	struct GetAssemblyValidValues
	{
		/*[in]*/ LPCOLESTR wszFusionName;
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetAssembly)(
		/*[in]*/ LPCOLESTR wszFusionName,
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetAssembly)

		VSL_CHECK_VALIDVALUE_STRINGW(wszFusionName);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetComClassicValidValues
	{
		/*[in]*/ TLIBATTR* pTypeLibAttr;
		/*[in]*/ LPCOLESTR wszWrapperTool;
		/*[out]*/ BOOL* pDelaySigned;
		/*[out]*/ BSTR* pbstrWrapperTool;
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetComClassic)(
		/*[in]*/ TLIBATTR* pTypeLibAttr,
		/*[in]*/ LPCOLESTR wszWrapperTool,
		/*[out]*/ BOOL* pDelaySigned,
		/*[out]*/ BSTR* pbstrWrapperTool,
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetComClassic)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeLibAttr);

		VSL_CHECK_VALIDVALUE_STRINGW(wszWrapperTool);

		VSL_SET_VALIDVALUE(pDelaySigned);

		VSL_SET_VALIDVALUE_BSTR(pbstrWrapperTool);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetComClassicByTypeLibNameValidValues
	{
		/*[in]*/ LPCOLESTR wszTypeLibName;
		/*[out]*/ TLIBATTR* pTypeLibAttr;
		/*[out]*/ BOOL* pDelaySigned;
		/*[out]*/ BSTR* pbstrWrapperTool;
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetComClassicByTypeLibName)(
		/*[in]*/ LPCOLESTR wszTypeLibName,
		/*[out]*/ TLIBATTR* pTypeLibAttr,
		/*[out]*/ BOOL* pDelaySigned,
		/*[out]*/ BSTR* pbstrWrapperTool,
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetComClassicByTypeLibName)

		VSL_CHECK_VALIDVALUE_STRINGW(wszTypeLibName);

		VSL_SET_VALIDVALUE(pTypeLibAttr);

		VSL_SET_VALIDVALUE(pDelaySigned);

		VSL_SET_VALIDVALUE_BSTR(pbstrWrapperTool);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTYPELIBRARYWRAPPERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
