/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCFGPROVIDEREVENTSHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCFGPROVIDEREVENTSHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCfgProviderEventsHelperNotImpl :
	public IVsCfgProviderEventsHelper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProviderEventsHelperNotImpl)

public:

	typedef IVsCfgProviderEventsHelper Interface;

	STDMETHOD(AdviseCfgProviderEvents)(
		/*[in]*/ IVsCfgProviderEvents* /*pCPE*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseCfgProviderEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnCfgNameAdded)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnCfgNameDeleted)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnCfgNameRenamed)(
		/*[in]*/ LPCOLESTR /*pszOldName*/,
		/*[in]*/ LPCOLESTR /*lszNewName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnPlatformNameAdded)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyOnPlatformNameDeleted)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCfgProviderEventsHelperMockImpl :
	public IVsCfgProviderEventsHelper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProviderEventsHelperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCfgProviderEventsHelperMockImpl)

	typedef IVsCfgProviderEventsHelper Interface;
	struct AdviseCfgProviderEventsValidValues
	{
		/*[in]*/ IVsCfgProviderEvents* pCPE;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseCfgProviderEvents)(
		/*[in]*/ IVsCfgProviderEvents* pCPE,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseCfgProviderEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCPE);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseCfgProviderEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseCfgProviderEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseCfgProviderEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnCfgNameAddedValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnCfgNameAdded)(
		/*[in]*/ LPCOLESTR pszCfgName)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnCfgNameAdded)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnCfgNameDeletedValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnCfgNameDeleted)(
		/*[in]*/ LPCOLESTR pszCfgName)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnCfgNameDeleted)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnCfgNameRenamedValidValues
	{
		/*[in]*/ LPCOLESTR pszOldName;
		/*[in]*/ LPCOLESTR lszNewName;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnCfgNameRenamed)(
		/*[in]*/ LPCOLESTR pszOldName,
		/*[in]*/ LPCOLESTR lszNewName)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnCfgNameRenamed)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(lszNewName);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnPlatformNameAddedValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnPlatformNameAdded)(
		/*[in]*/ LPCOLESTR pszPlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnPlatformNameAdded)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyOnPlatformNameDeletedValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		HRESULT retValue;
	};

	STDMETHOD(NotifyOnPlatformNameDeleted)(
		/*[in]*/ LPCOLESTR pszPlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyOnPlatformNameDeleted)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCFGPROVIDEREVENTSHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
