/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTYPELIBRARYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTYPELIBRARYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTypeLibraryWrapperNotImpl :
	public IVsTypeLibraryWrapper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTypeLibraryWrapperNotImpl)

public:

	typedef IVsTypeLibraryWrapper Interface;

	STDMETHOD(WrapTypeLibrary)(
		/*[in]*/ TLIBATTR* /*pTypeLibToWrap*/,
		/*[in]*/ LPCOLESTR /*wszDestinationDirectory*/,
		/*[in]*/ LPCOLESTR /*wszKeyFile*/,
		/*[in]*/ LPCOLESTR /*wszKeyContainer*/,
		/*[in]*/ BOOL /*bDelaySign*/,
		/*[in]*/ IVsTypeLibraryWrapperCallback* /*pCallback*/,
		/*[out]*/ BSTR** /*rgbstrWrapperPaths*/,
		/*[out]*/ TLIBATTR** /*rgWrappedTypeLibs*/,
		/*[out]*/ BOOL** /*rgbGenerated*/,
		/*[out]*/ BSTR** /*rgbstrWrapperTools*/,
		/*[out]*/ ULONG* /*pcWrappedTypeLibs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMainWrapperFilename)(
		/*[in]*/ TLIBATTR* /*pTypeLibToWrap*/,
		/*[out,retval]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NeedsRegeneration)(
		/*[in]*/ TLIBATTR* /*pTypeLibToWrap*/,
		/*[in]*/ LPCOLESTR /*wszKeyFile*/,
		/*[in]*/ LPCOLESTR /*wszKeyContainerName*/,
		/*[in]*/ BOOL /*bDelaySign*/,
		/*[in]*/ BOOL /*bCurrentlyDelaySigned*/,
		/*[in]*/ LPCOLESTR /*wszExistingWrapperFilename*/,
		/*[out,retval]*/ BOOL* /*pbNeedsRegeneration*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMainWrapperFriendlyName)(
		/*[in]*/ TLIBATTR* /*pTypeLibToWrap*/,
		/*[out,retval]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTypeLibraryWrapperMockImpl :
	public IVsTypeLibraryWrapper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTypeLibraryWrapperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTypeLibraryWrapperMockImpl)

	typedef IVsTypeLibraryWrapper Interface;
	struct WrapTypeLibraryValidValues
	{
		/*[in]*/ TLIBATTR* pTypeLibToWrap;
		/*[in]*/ LPCOLESTR wszDestinationDirectory;
		/*[in]*/ LPCOLESTR wszKeyFile;
		/*[in]*/ LPCOLESTR wszKeyContainer;
		/*[in]*/ BOOL bDelaySign;
		/*[in]*/ IVsTypeLibraryWrapperCallback* pCallback;
		/*[out]*/ BSTR** rgbstrWrapperPaths;
		/*[out]*/ TLIBATTR** rgWrappedTypeLibs;
		/*[out]*/ BOOL** rgbGenerated;
		/*[out]*/ BSTR** rgbstrWrapperTools;
		/*[out]*/ ULONG* pcWrappedTypeLibs;
		HRESULT retValue;
	};

	STDMETHOD(WrapTypeLibrary)(
		/*[in]*/ TLIBATTR* pTypeLibToWrap,
		/*[in]*/ LPCOLESTR wszDestinationDirectory,
		/*[in]*/ LPCOLESTR wszKeyFile,
		/*[in]*/ LPCOLESTR wszKeyContainer,
		/*[in]*/ BOOL bDelaySign,
		/*[in]*/ IVsTypeLibraryWrapperCallback* pCallback,
		/*[out]*/ BSTR** rgbstrWrapperPaths,
		/*[out]*/ TLIBATTR** rgWrappedTypeLibs,
		/*[out]*/ BOOL** rgbGenerated,
		/*[out]*/ BSTR** rgbstrWrapperTools,
		/*[out]*/ ULONG* pcWrappedTypeLibs)
	{
		VSL_DEFINE_MOCK_METHOD(WrapTypeLibrary)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeLibToWrap);

		VSL_CHECK_VALIDVALUE_STRINGW(wszDestinationDirectory);

		VSL_CHECK_VALIDVALUE_STRINGW(wszKeyFile);

		VSL_CHECK_VALIDVALUE_STRINGW(wszKeyContainer);

		VSL_CHECK_VALIDVALUE(bDelaySign);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_SET_VALIDVALUE(rgbstrWrapperPaths);

		VSL_SET_VALIDVALUE(rgWrappedTypeLibs);

		VSL_SET_VALIDVALUE(rgbGenerated);

		VSL_SET_VALIDVALUE(rgbstrWrapperTools);

		VSL_SET_VALIDVALUE(pcWrappedTypeLibs);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMainWrapperFilenameValidValues
	{
		/*[in]*/ TLIBATTR* pTypeLibToWrap;
		/*[out,retval]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetMainWrapperFilename)(
		/*[in]*/ TLIBATTR* pTypeLibToWrap,
		/*[out,retval]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetMainWrapperFilename)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeLibToWrap);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct NeedsRegenerationValidValues
	{
		/*[in]*/ TLIBATTR* pTypeLibToWrap;
		/*[in]*/ LPCOLESTR wszKeyFile;
		/*[in]*/ LPCOLESTR wszKeyContainerName;
		/*[in]*/ BOOL bDelaySign;
		/*[in]*/ BOOL bCurrentlyDelaySigned;
		/*[in]*/ LPCOLESTR wszExistingWrapperFilename;
		/*[out,retval]*/ BOOL* pbNeedsRegeneration;
		HRESULT retValue;
	};

	STDMETHOD(NeedsRegeneration)(
		/*[in]*/ TLIBATTR* pTypeLibToWrap,
		/*[in]*/ LPCOLESTR wszKeyFile,
		/*[in]*/ LPCOLESTR wszKeyContainerName,
		/*[in]*/ BOOL bDelaySign,
		/*[in]*/ BOOL bCurrentlyDelaySigned,
		/*[in]*/ LPCOLESTR wszExistingWrapperFilename,
		/*[out,retval]*/ BOOL* pbNeedsRegeneration)
	{
		VSL_DEFINE_MOCK_METHOD(NeedsRegeneration)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeLibToWrap);

		VSL_CHECK_VALIDVALUE_STRINGW(wszKeyFile);

		VSL_CHECK_VALIDVALUE_STRINGW(wszKeyContainerName);

		VSL_CHECK_VALIDVALUE(bDelaySign);

		VSL_CHECK_VALIDVALUE(bCurrentlyDelaySigned);

		VSL_CHECK_VALIDVALUE_STRINGW(wszExistingWrapperFilename);

		VSL_SET_VALIDVALUE(pbNeedsRegeneration);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMainWrapperFriendlyNameValidValues
	{
		/*[in]*/ TLIBATTR* pTypeLibToWrap;
		/*[out,retval]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetMainWrapperFriendlyName)(
		/*[in]*/ TLIBATTR* pTypeLibToWrap,
		/*[out,retval]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetMainWrapperFriendlyName)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeLibToWrap);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTYPELIBRARYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
