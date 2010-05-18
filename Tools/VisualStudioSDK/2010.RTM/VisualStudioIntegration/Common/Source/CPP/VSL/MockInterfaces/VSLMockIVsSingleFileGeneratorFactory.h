/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSINGLEFILEGENERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSINGLEFILEGENERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSingleFileGeneratorFactoryNotImpl :
	public IVsSingleFileGeneratorFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSingleFileGeneratorFactoryNotImpl)

public:

	typedef IVsSingleFileGeneratorFactory Interface;

	STDMETHOD(GetDefaultGenerator)(
		/*[in]*/ LPCOLESTR /*wszFilename*/,
		/*[out,retval]*/ BSTR* /*pbstrGenProgID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateGeneratorInstance)(
		/*[in]*/ LPCOLESTR /*wszProgId*/,
		/*[out]*/ BOOL* /*pbGeneratesDesignTimeSource*/,
		/*[out]*/ BOOL* /*pbGeneratesSharedDesignTimeSource*/,
		/*[out]*/ BOOL* /*pbUseTempPEFlag*/,
		/*[out]*/ IVsSingleFileGenerator** /*ppGenerate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGeneratorInformation)(
		/*[in]*/ LPCWSTR /*wszProgID*/,
		/*[out]*/ BOOL* /*pbGeneratesDesignTimeSource*/,
		/*[out]*/ BOOL* /*pbGeneratesSharedDesignTimeSource*/,
		/*[out]*/ BOOL* /*pbUseTempPEFlag*/,
		/*[out]*/ GUID* /*pguidGenerator*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSingleFileGeneratorFactoryMockImpl :
	public IVsSingleFileGeneratorFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSingleFileGeneratorFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSingleFileGeneratorFactoryMockImpl)

	typedef IVsSingleFileGeneratorFactory Interface;
	struct GetDefaultGeneratorValidValues
	{
		/*[in]*/ LPCOLESTR wszFilename;
		/*[out,retval]*/ BSTR* pbstrGenProgID;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultGenerator)(
		/*[in]*/ LPCOLESTR wszFilename,
		/*[out,retval]*/ BSTR* pbstrGenProgID)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultGenerator)

		VSL_CHECK_VALIDVALUE_STRINGW(wszFilename);

		VSL_SET_VALIDVALUE_BSTR(pbstrGenProgID);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateGeneratorInstanceValidValues
	{
		/*[in]*/ LPCOLESTR wszProgId;
		/*[out]*/ BOOL* pbGeneratesDesignTimeSource;
		/*[out]*/ BOOL* pbGeneratesSharedDesignTimeSource;
		/*[out]*/ BOOL* pbUseTempPEFlag;
		/*[out]*/ IVsSingleFileGenerator** ppGenerate;
		HRESULT retValue;
	};

	STDMETHOD(CreateGeneratorInstance)(
		/*[in]*/ LPCOLESTR wszProgId,
		/*[out]*/ BOOL* pbGeneratesDesignTimeSource,
		/*[out]*/ BOOL* pbGeneratesSharedDesignTimeSource,
		/*[out]*/ BOOL* pbUseTempPEFlag,
		/*[out]*/ IVsSingleFileGenerator** ppGenerate)
	{
		VSL_DEFINE_MOCK_METHOD(CreateGeneratorInstance)

		VSL_CHECK_VALIDVALUE_STRINGW(wszProgId);

		VSL_SET_VALIDVALUE(pbGeneratesDesignTimeSource);

		VSL_SET_VALIDVALUE(pbGeneratesSharedDesignTimeSource);

		VSL_SET_VALIDVALUE(pbUseTempPEFlag);

		VSL_SET_VALIDVALUE_INTERFACE(ppGenerate);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGeneratorInformationValidValues
	{
		/*[in]*/ LPCWSTR wszProgID;
		/*[out]*/ BOOL* pbGeneratesDesignTimeSource;
		/*[out]*/ BOOL* pbGeneratesSharedDesignTimeSource;
		/*[out]*/ BOOL* pbUseTempPEFlag;
		/*[out]*/ GUID* pguidGenerator;
		HRESULT retValue;
	};

	STDMETHOD(GetGeneratorInformation)(
		/*[in]*/ LPCWSTR wszProgID,
		/*[out]*/ BOOL* pbGeneratesDesignTimeSource,
		/*[out]*/ BOOL* pbGeneratesSharedDesignTimeSource,
		/*[out]*/ BOOL* pbUseTempPEFlag,
		/*[out]*/ GUID* pguidGenerator)
	{
		VSL_DEFINE_MOCK_METHOD(GetGeneratorInformation)

		VSL_CHECK_VALIDVALUE_STRINGW(wszProgID);

		VSL_SET_VALIDVALUE(pbGeneratesDesignTimeSource);

		VSL_SET_VALIDVALUE(pbGeneratesSharedDesignTimeSource);

		VSL_SET_VALIDVALUE(pbUseTempPEFlag);

		VSL_SET_VALIDVALUE(pguidGenerator);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSINGLEFILEGENERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
