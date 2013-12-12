/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONSECURITYOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONSECURITYOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionSecurityOptionsNotImpl :
	public IVsSolutionSecurityOptions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionSecurityOptionsNotImpl)

public:

	typedef IVsSolutionSecurityOptions Interface;

	STDMETHOD(get_SignCabinets)(
		/*[out]*/ BOOL* /*pfSignCabinets*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_UseTestCertificate)(
		/*[out]*/ BOOL* /*pfUseTestCertificate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_UseCertificateFile)(
		/*[out]*/ BOOL* /*pfUseCertificateFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CertificateFile)(
		/*[out]*/ BSTR* /*pbstrCertificateFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_PrivateKeyFile)(
		/*[out]*/ BSTR* /*pbstrPrivateKeyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TimestampServerURL)(
		/*[out]*/ BSTR* /*pbstrTimestampServerURL*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionSecurityOptionsMockImpl :
	public IVsSolutionSecurityOptions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionSecurityOptionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionSecurityOptionsMockImpl)

	typedef IVsSolutionSecurityOptions Interface;
	struct get_SignCabinetsValidValues
	{
		/*[out]*/ BOOL* pfSignCabinets;
		HRESULT retValue;
	};

	STDMETHOD(get_SignCabinets)(
		/*[out]*/ BOOL* pfSignCabinets)
	{
		VSL_DEFINE_MOCK_METHOD(get_SignCabinets)

		VSL_SET_VALIDVALUE(pfSignCabinets);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_UseTestCertificateValidValues
	{
		/*[out]*/ BOOL* pfUseTestCertificate;
		HRESULT retValue;
	};

	STDMETHOD(get_UseTestCertificate)(
		/*[out]*/ BOOL* pfUseTestCertificate)
	{
		VSL_DEFINE_MOCK_METHOD(get_UseTestCertificate)

		VSL_SET_VALIDVALUE(pfUseTestCertificate);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_UseCertificateFileValidValues
	{
		/*[out]*/ BOOL* pfUseCertificateFile;
		HRESULT retValue;
	};

	STDMETHOD(get_UseCertificateFile)(
		/*[out]*/ BOOL* pfUseCertificateFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_UseCertificateFile)

		VSL_SET_VALIDVALUE(pfUseCertificateFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CertificateFileValidValues
	{
		/*[out]*/ BSTR* pbstrCertificateFile;
		HRESULT retValue;
	};

	STDMETHOD(get_CertificateFile)(
		/*[out]*/ BSTR* pbstrCertificateFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_CertificateFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrCertificateFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PrivateKeyFileValidValues
	{
		/*[out]*/ BSTR* pbstrPrivateKeyFile;
		HRESULT retValue;
	};

	STDMETHOD(get_PrivateKeyFile)(
		/*[out]*/ BSTR* pbstrPrivateKeyFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_PrivateKeyFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrPrivateKeyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TimestampServerURLValidValues
	{
		/*[out]*/ BSTR* pbstrTimestampServerURL;
		HRESULT retValue;
	};

	STDMETHOD(get_TimestampServerURL)(
		/*[out]*/ BSTR* pbstrTimestampServerURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_TimestampServerURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrTimestampServerURL);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONSECURITYOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
