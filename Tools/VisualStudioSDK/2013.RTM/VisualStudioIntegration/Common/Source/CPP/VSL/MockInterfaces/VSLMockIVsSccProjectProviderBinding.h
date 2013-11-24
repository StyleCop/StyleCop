/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROJECTPROVIDERBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROJECTPROVIDERBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProjectProviderBinding.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProjectProviderBindingNotImpl :
	public IVsSccProjectProviderBinding
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectProviderBindingNotImpl)

public:

	typedef IVsSccProjectProviderBinding Interface;

	STDMETHOD(GetProviderBinding)(
		/*[out,retval]*/ VSSCCPROVIDERBINDING* /*pvscpbBinding*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderService)(
		/*[out,retval]*/ GUID* /*pguidService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderSession)(
		/*[out,retval]*/ IUnknown** /*punkSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateEnlistmentPath)(
		/*[in]*/ LPCOLESTR /*lpszPath*/,
		/*[out]*/ BOOL* /*pfAlternateIsDisplay*/,
		/*[out]*/ BSTR* /*pbstrAlternatePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderBindingOptions)(
		/*[out,retval]*/ VSSCCPROVIDERBINDINGOPTIONS* /*pvscpboOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ValidateServerPathEdit)(
		/*[in]*/ BOOL /*fQuick*/,
		/*[in]*/ LPCOLESTR /*lpszServerPath*/,
		/*[out,retval]*/ BOOL* /*pfValidServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BrowseServerPath)(
		/*[in]*/ LPCOLESTR /*lpszServerPath*/,
		/*[out,retval]*/ BSTR* /*pbstrNewServerPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProjectProviderBindingMockImpl :
	public IVsSccProjectProviderBinding,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectProviderBindingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProjectProviderBindingMockImpl)

	typedef IVsSccProjectProviderBinding Interface;
	struct GetProviderBindingValidValues
	{
		/*[out,retval]*/ VSSCCPROVIDERBINDING* pvscpbBinding;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderBinding)(
		/*[out,retval]*/ VSSCCPROVIDERBINDING* pvscpbBinding)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderBinding)

		VSL_SET_VALIDVALUE(pvscpbBinding);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderServiceValidValues
	{
		/*[out,retval]*/ GUID* pguidService;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderService)(
		/*[out,retval]*/ GUID* pguidService)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderService)

		VSL_SET_VALIDVALUE(pguidService);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderSessionValidValues
	{
		/*[out,retval]*/ IUnknown** punkSession;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderSession)(
		/*[out,retval]*/ IUnknown** punkSession)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderSession)

		VSL_SET_VALIDVALUE_INTERFACE(punkSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateEnlistmentPathValidValues
	{
		/*[in]*/ LPCOLESTR lpszPath;
		/*[out]*/ BOOL* pfAlternateIsDisplay;
		/*[out]*/ BSTR* pbstrAlternatePath;
		HRESULT retValue;
	};

	STDMETHOD(TranslateEnlistmentPath)(
		/*[in]*/ LPCOLESTR lpszPath,
		/*[out]*/ BOOL* pfAlternateIsDisplay,
		/*[out]*/ BSTR* pbstrAlternatePath)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateEnlistmentPath)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszPath);

		VSL_SET_VALIDVALUE(pfAlternateIsDisplay);

		VSL_SET_VALIDVALUE_BSTR(pbstrAlternatePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderBindingOptionsValidValues
	{
		/*[out,retval]*/ VSSCCPROVIDERBINDINGOPTIONS* pvscpboOptions;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderBindingOptions)(
		/*[out,retval]*/ VSSCCPROVIDERBINDINGOPTIONS* pvscpboOptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderBindingOptions)

		VSL_SET_VALIDVALUE(pvscpboOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct ValidateServerPathEditValidValues
	{
		/*[in]*/ BOOL fQuick;
		/*[in]*/ LPCOLESTR lpszServerPath;
		/*[out,retval]*/ BOOL* pfValidServer;
		HRESULT retValue;
	};

	STDMETHOD(ValidateServerPathEdit)(
		/*[in]*/ BOOL fQuick,
		/*[in]*/ LPCOLESTR lpszServerPath,
		/*[out,retval]*/ BOOL* pfValidServer)
	{
		VSL_DEFINE_MOCK_METHOD(ValidateServerPathEdit)

		VSL_CHECK_VALIDVALUE(fQuick);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszServerPath);

		VSL_SET_VALIDVALUE(pfValidServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct BrowseServerPathValidValues
	{
		/*[in]*/ LPCOLESTR lpszServerPath;
		/*[out,retval]*/ BSTR* pbstrNewServerPath;
		HRESULT retValue;
	};

	STDMETHOD(BrowseServerPath)(
		/*[in]*/ LPCOLESTR lpszServerPath,
		/*[out,retval]*/ BSTR* pbstrNewServerPath)
	{
		VSL_DEFINE_MOCK_METHOD(BrowseServerPath)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszServerPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrNewServerPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROJECTPROVIDERBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
