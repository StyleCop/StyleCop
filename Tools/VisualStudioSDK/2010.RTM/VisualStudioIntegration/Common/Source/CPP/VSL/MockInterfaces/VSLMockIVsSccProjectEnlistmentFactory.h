/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROJECTENLISTMENTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROJECTENLISTMENTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProjectEnlistmentFactory.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProjectEnlistmentFactoryNotImpl :
	public IVsSccProjectEnlistmentFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectEnlistmentFactoryNotImpl)

public:

	typedef IVsSccProjectEnlistmentFactory Interface;

	STDMETHOD(GetDefaultEnlistment)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[out]*/ BSTR* /*pbstrDefaultEnlistment*/,
		/*[out]*/ BSTR* /*pbstrDefaultEnlistmentUNC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnlistmentFactoryOptions)(
		/*[out,retval]*/ VSSCCENLISTMENTFACTORYOPTIONS* /*pvscefoOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ValidateEnlistmentEdit)(
		/*[in]*/ BOOL /*fQuick*/,
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[in]*/ LPCOLESTR /*lpszChosenEnlistment*/,
		/*[out]*/ BSTR* /*pbstrChosenEnlistmentUNC*/,
		/*[out]*/ BOOL* /*pfValidEnlistment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BrowseEnlistment)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[in]*/ LPCOLESTR /*lpszInitialEnlistment*/,
		/*[out]*/ BSTR* /*pbstrChosenEnlistment*/,
		/*[out]*/ BSTR* /*pbstrChosenEnlistmentUNC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeEnlistmentCreate)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[in]*/ LPCOLESTR /*lpszEnlistment*/,
		/*[in]*/ LPCOLESTR /*lpszEnlistmentUNC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterEnlistmentCreate)(
		/*[in]*/ LPCOLESTR /*lpszProjectPath*/,
		/*[in]*/ LPCOLESTR /*lpszEnlistment*/,
		/*[in]*/ LPCOLESTR /*lpszEnlistmentUNC*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProjectEnlistmentFactoryMockImpl :
	public IVsSccProjectEnlistmentFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectEnlistmentFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProjectEnlistmentFactoryMockImpl)

	typedef IVsSccProjectEnlistmentFactory Interface;
	struct GetDefaultEnlistmentValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[out]*/ BSTR* pbstrDefaultEnlistment;
		/*[out]*/ BSTR* pbstrDefaultEnlistmentUNC;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultEnlistment)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[out]*/ BSTR* pbstrDefaultEnlistment,
		/*[out]*/ BSTR* pbstrDefaultEnlistmentUNC)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultEnlistment)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrDefaultEnlistment);

		VSL_SET_VALIDVALUE_BSTR(pbstrDefaultEnlistmentUNC);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnlistmentFactoryOptionsValidValues
	{
		/*[out,retval]*/ VSSCCENLISTMENTFACTORYOPTIONS* pvscefoOptions;
		HRESULT retValue;
	};

	STDMETHOD(GetEnlistmentFactoryOptions)(
		/*[out,retval]*/ VSSCCENLISTMENTFACTORYOPTIONS* pvscefoOptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnlistmentFactoryOptions)

		VSL_SET_VALIDVALUE(pvscefoOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct ValidateEnlistmentEditValidValues
	{
		/*[in]*/ BOOL fQuick;
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[in]*/ LPCOLESTR lpszChosenEnlistment;
		/*[out]*/ BSTR* pbstrChosenEnlistmentUNC;
		/*[out]*/ BOOL* pfValidEnlistment;
		HRESULT retValue;
	};

	STDMETHOD(ValidateEnlistmentEdit)(
		/*[in]*/ BOOL fQuick,
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[in]*/ LPCOLESTR lpszChosenEnlistment,
		/*[out]*/ BSTR* pbstrChosenEnlistmentUNC,
		/*[out]*/ BOOL* pfValidEnlistment)
	{
		VSL_DEFINE_MOCK_METHOD(ValidateEnlistmentEdit)

		VSL_CHECK_VALIDVALUE(fQuick);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszChosenEnlistment);

		VSL_SET_VALIDVALUE_BSTR(pbstrChosenEnlistmentUNC);

		VSL_SET_VALIDVALUE(pfValidEnlistment);

		VSL_RETURN_VALIDVALUES();
	}
	struct BrowseEnlistmentValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[in]*/ LPCOLESTR lpszInitialEnlistment;
		/*[out]*/ BSTR* pbstrChosenEnlistment;
		/*[out]*/ BSTR* pbstrChosenEnlistmentUNC;
		HRESULT retValue;
	};

	STDMETHOD(BrowseEnlistment)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[in]*/ LPCOLESTR lpszInitialEnlistment,
		/*[out]*/ BSTR* pbstrChosenEnlistment,
		/*[out]*/ BSTR* pbstrChosenEnlistmentUNC)
	{
		VSL_DEFINE_MOCK_METHOD(BrowseEnlistment)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszInitialEnlistment);

		VSL_SET_VALIDVALUE_BSTR(pbstrChosenEnlistment);

		VSL_SET_VALIDVALUE_BSTR(pbstrChosenEnlistmentUNC);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeEnlistmentCreateValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[in]*/ LPCOLESTR lpszEnlistment;
		/*[in]*/ LPCOLESTR lpszEnlistmentUNC;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeEnlistmentCreate)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[in]*/ LPCOLESTR lpszEnlistment,
		/*[in]*/ LPCOLESTR lpszEnlistmentUNC)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeEnlistmentCreate)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszEnlistment);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszEnlistmentUNC);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterEnlistmentCreateValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectPath;
		/*[in]*/ LPCOLESTR lpszEnlistment;
		/*[in]*/ LPCOLESTR lpszEnlistmentUNC;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterEnlistmentCreate)(
		/*[in]*/ LPCOLESTR lpszProjectPath,
		/*[in]*/ LPCOLESTR lpszEnlistment,
		/*[in]*/ LPCOLESTR lpszEnlistmentUNC)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterEnlistmentCreate)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszEnlistment);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszEnlistmentUNC);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROJECTENLISTMENTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
