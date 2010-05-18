/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCFGPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCFGPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCfgProviderEventsNotImpl :
	public IVsCfgProviderEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProviderEventsNotImpl)

public:

	typedef IVsCfgProviderEvents Interface;

	STDMETHOD(OnCfgNameAdded)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCfgNameDeleted)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCfgNameRenamed)(
		/*[in]*/ LPCOLESTR /*pszOldName*/,
		/*[in]*/ LPCOLESTR /*lszNewName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPlatformNameAdded)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPlatformNameDeleted)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCfgProviderEventsMockImpl :
	public IVsCfgProviderEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProviderEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCfgProviderEventsMockImpl)

	typedef IVsCfgProviderEvents Interface;
	struct OnCfgNameAddedValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		HRESULT retValue;
	};

	STDMETHOD(OnCfgNameAdded)(
		/*[in]*/ LPCOLESTR pszCfgName)
	{
		VSL_DEFINE_MOCK_METHOD(OnCfgNameAdded)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCfgNameDeletedValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		HRESULT retValue;
	};

	STDMETHOD(OnCfgNameDeleted)(
		/*[in]*/ LPCOLESTR pszCfgName)
	{
		VSL_DEFINE_MOCK_METHOD(OnCfgNameDeleted)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCfgNameRenamedValidValues
	{
		/*[in]*/ LPCOLESTR pszOldName;
		/*[in]*/ LPCOLESTR lszNewName;
		HRESULT retValue;
	};

	STDMETHOD(OnCfgNameRenamed)(
		/*[in]*/ LPCOLESTR pszOldName,
		/*[in]*/ LPCOLESTR lszNewName)
	{
		VSL_DEFINE_MOCK_METHOD(OnCfgNameRenamed)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(lszNewName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPlatformNameAddedValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		HRESULT retValue;
	};

	STDMETHOD(OnPlatformNameAdded)(
		/*[in]*/ LPCOLESTR pszPlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(OnPlatformNameAdded)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPlatformNameDeletedValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		HRESULT retValue;
	};

	STDMETHOD(OnPlatformNameDeleted)(
		/*[in]*/ LPCOLESTR pszPlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(OnPlatformNameDeleted)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCFGPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
