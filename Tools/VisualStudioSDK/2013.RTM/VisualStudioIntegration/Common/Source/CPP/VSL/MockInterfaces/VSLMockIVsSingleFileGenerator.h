/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSINGLEFILEGENERATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSINGLEFILEGENERATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSingleFileGeneratorNotImpl :
	public IVsSingleFileGenerator
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSingleFileGeneratorNotImpl)

public:

	typedef IVsSingleFileGenerator Interface;

	STDMETHOD(get_DefaultExtension)(
		/*[out,retval]*/ BSTR* /*pbstrDefaultExtension*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Generate)(
		/*[in]*/ LPCOLESTR /*wszInputFilePath*/,
		/*[in]*/ BSTR /*bstrInputFileContents*/,
		/*[in]*/ LPCOLESTR /*wszDefaultNamespace*/,
		/*[out]*/ BYTE** /*rgbOutputFileContents*/,
		/*[out]*/ ULONG* /*pcbOutput*/,
		/*[in]*/ IVsGeneratorProgress* /*pGenerateProgress*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSingleFileGeneratorMockImpl :
	public IVsSingleFileGenerator,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSingleFileGeneratorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSingleFileGeneratorMockImpl)

	typedef IVsSingleFileGenerator Interface;
	struct get_DefaultExtensionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDefaultExtension;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultExtension)(
		/*[out,retval]*/ BSTR* pbstrDefaultExtension)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultExtension)

		VSL_SET_VALIDVALUE_BSTR(pbstrDefaultExtension);

		VSL_RETURN_VALIDVALUES();
	}
	struct GenerateValidValues
	{
		/*[in]*/ LPCOLESTR wszInputFilePath;
		/*[in]*/ BSTR bstrInputFileContents;
		/*[in]*/ LPCOLESTR wszDefaultNamespace;
		/*[out]*/ BYTE** rgbOutputFileContents;
		/*[out]*/ ULONG* pcbOutput;
		/*[in]*/ IVsGeneratorProgress* pGenerateProgress;
		HRESULT retValue;
	};

	STDMETHOD(Generate)(
		/*[in]*/ LPCOLESTR wszInputFilePath,
		/*[in]*/ BSTR bstrInputFileContents,
		/*[in]*/ LPCOLESTR wszDefaultNamespace,
		/*[out]*/ BYTE** rgbOutputFileContents,
		/*[out]*/ ULONG* pcbOutput,
		/*[in]*/ IVsGeneratorProgress* pGenerateProgress)
	{
		VSL_DEFINE_MOCK_METHOD(Generate)

		VSL_CHECK_VALIDVALUE_STRINGW(wszInputFilePath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrInputFileContents);

		VSL_CHECK_VALIDVALUE_STRINGW(wszDefaultNamespace);

		VSL_SET_VALIDVALUE(rgbOutputFileContents);

		VSL_SET_VALIDVALUE(pcbOutput);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pGenerateProgress);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSINGLEFILEGENERATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
