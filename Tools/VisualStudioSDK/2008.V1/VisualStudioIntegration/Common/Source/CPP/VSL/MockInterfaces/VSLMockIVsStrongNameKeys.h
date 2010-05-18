/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSTRONGNAMEKEYS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSTRONGNAMEKEYS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsStrongNameKeysNotImpl :
	public IVsStrongNameKeys
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStrongNameKeysNotImpl)

public:

	typedef IVsStrongNameKeys Interface;

	STDMETHOD(EnumProviders)(
		/*[out]*/ IVsEnumCryptoProviders** /*ppEnumProviders*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumContainers)(
		/*[in]*/ LPCOLESTR /*szProvider*/,
		/*[out]*/ IVsEnumCryptoProviderContainers** /*ppEnumContainers*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNewKey)(
		/*[in]*/ LPCOLESTR /*szFileLocation*/,
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNewKeyNoUI)(
		/*[in]*/ LPCOLESTR /*szFile*/,
		/*[in]*/ LPCOLESTR /*szPassword*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateNewKeyWithName)(
		/*[in]*/ LPCOLESTR /*szFile*/,
		/*[in]*/ LPCOLESTR /*szPassword*/,
		/*[in]*/ LPCOLESTR /*szSubjectName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ImportKeyFromPFX)(
		/*[in]*/ LPCOLESTR /*szFile*/,
		/*[out]*/ BSTR* /*pbstrContainerName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ChangePassword)(
		/*[in]*/ LPCOLESTR /*szPfxFile*/,
		/*[in]*/ LPCOLESTR /*szOldPassword*/,
		/*[in]*/ LPCOLESTR /*szNewPassword*/)VSL_STDMETHOD_NOTIMPL
};

class IVsStrongNameKeysMockImpl :
	public IVsStrongNameKeys,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStrongNameKeysMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsStrongNameKeysMockImpl)

	typedef IVsStrongNameKeys Interface;
	struct EnumProvidersValidValues
	{
		/*[out]*/ IVsEnumCryptoProviders** ppEnumProviders;
		HRESULT retValue;
	};

	STDMETHOD(EnumProviders)(
		/*[out]*/ IVsEnumCryptoProviders** ppEnumProviders)
	{
		VSL_DEFINE_MOCK_METHOD(EnumProviders)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumProviders);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumContainersValidValues
	{
		/*[in]*/ LPCOLESTR szProvider;
		/*[out]*/ IVsEnumCryptoProviderContainers** ppEnumContainers;
		HRESULT retValue;
	};

	STDMETHOD(EnumContainers)(
		/*[in]*/ LPCOLESTR szProvider,
		/*[out]*/ IVsEnumCryptoProviderContainers** ppEnumContainers)
	{
		VSL_DEFINE_MOCK_METHOD(EnumContainers)

		VSL_CHECK_VALIDVALUE_STRINGW(szProvider);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumContainers);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateNewKeyValidValues
	{
		/*[in]*/ LPCOLESTR szFileLocation;
		/*[out]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(CreateNewKey)(
		/*[in]*/ LPCOLESTR szFileLocation,
		/*[out]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNewKey)

		VSL_CHECK_VALIDVALUE_STRINGW(szFileLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateNewKeyNoUIValidValues
	{
		/*[in]*/ LPCOLESTR szFile;
		/*[in]*/ LPCOLESTR szPassword;
		HRESULT retValue;
	};

	STDMETHOD(CreateNewKeyNoUI)(
		/*[in]*/ LPCOLESTR szFile,
		/*[in]*/ LPCOLESTR szPassword)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNewKeyNoUI)

		VSL_CHECK_VALIDVALUE_STRINGW(szFile);

		VSL_CHECK_VALIDVALUE_STRINGW(szPassword);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateNewKeyWithNameValidValues
	{
		/*[in]*/ LPCOLESTR szFile;
		/*[in]*/ LPCOLESTR szPassword;
		/*[in]*/ LPCOLESTR szSubjectName;
		HRESULT retValue;
	};

	STDMETHOD(CreateNewKeyWithName)(
		/*[in]*/ LPCOLESTR szFile,
		/*[in]*/ LPCOLESTR szPassword,
		/*[in]*/ LPCOLESTR szSubjectName)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNewKeyWithName)

		VSL_CHECK_VALIDVALUE_STRINGW(szFile);

		VSL_CHECK_VALIDVALUE_STRINGW(szPassword);

		VSL_CHECK_VALIDVALUE_STRINGW(szSubjectName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ImportKeyFromPFXValidValues
	{
		/*[in]*/ LPCOLESTR szFile;
		/*[out]*/ BSTR* pbstrContainerName;
		HRESULT retValue;
	};

	STDMETHOD(ImportKeyFromPFX)(
		/*[in]*/ LPCOLESTR szFile,
		/*[out]*/ BSTR* pbstrContainerName)
	{
		VSL_DEFINE_MOCK_METHOD(ImportKeyFromPFX)

		VSL_CHECK_VALIDVALUE_STRINGW(szFile);

		VSL_SET_VALIDVALUE_BSTR(pbstrContainerName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ChangePasswordValidValues
	{
		/*[in]*/ LPCOLESTR szPfxFile;
		/*[in]*/ LPCOLESTR szOldPassword;
		/*[in]*/ LPCOLESTR szNewPassword;
		HRESULT retValue;
	};

	STDMETHOD(ChangePassword)(
		/*[in]*/ LPCOLESTR szPfxFile,
		/*[in]*/ LPCOLESTR szOldPassword,
		/*[in]*/ LPCOLESTR szNewPassword)
	{
		VSL_DEFINE_MOCK_METHOD(ChangePassword)

		VSL_CHECK_VALIDVALUE_STRINGW(szPfxFile);

		VSL_CHECK_VALIDVALUE_STRINGW(szOldPassword);

		VSL_CHECK_VALIDVALUE_STRINGW(szNewPassword);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSTRONGNAMEKEYS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
