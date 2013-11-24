/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUserSettingsNotImpl :
	public IVsUserSettings
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserSettingsNotImpl)

public:

	typedef IVsUserSettings Interface;

	STDMETHOD(ExportSettings)(
		/*[in]*/ LPCOLESTR /*pszCategoryGUID*/,
		/*[in]*/ IVsSettingsWriter* /*pSettings*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ImportSettings)(
		/*[in]*/ LPCOLESTR /*pszCategoryGUID*/,
		/*[in]*/ IVsSettingsReader* /*pSettings*/,
		/*[in]*/ UserSettingsFlags /*flags*/,
		/*[in,out]*/ BOOL* /*pfRestartRequired*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserSettingsMockImpl :
	public IVsUserSettings,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserSettingsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserSettingsMockImpl)

	typedef IVsUserSettings Interface;
	struct ExportSettingsValidValues
	{
		/*[in]*/ LPCOLESTR pszCategoryGUID;
		/*[in]*/ IVsSettingsWriter* pSettings;
		HRESULT retValue;
	};

	STDMETHOD(ExportSettings)(
		/*[in]*/ LPCOLESTR pszCategoryGUID,
		/*[in]*/ IVsSettingsWriter* pSettings)
	{
		VSL_DEFINE_MOCK_METHOD(ExportSettings)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCategoryGUID);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSettings);

		VSL_RETURN_VALIDVALUES();
	}
	struct ImportSettingsValidValues
	{
		/*[in]*/ LPCOLESTR pszCategoryGUID;
		/*[in]*/ IVsSettingsReader* pSettings;
		/*[in]*/ UserSettingsFlags flags;
		/*[in,out]*/ BOOL* pfRestartRequired;
		HRESULT retValue;
	};

	STDMETHOD(ImportSettings)(
		/*[in]*/ LPCOLESTR pszCategoryGUID,
		/*[in]*/ IVsSettingsReader* pSettings,
		/*[in]*/ UserSettingsFlags flags,
		/*[in,out]*/ BOOL* pfRestartRequired)
	{
		VSL_DEFINE_MOCK_METHOD(ImportSettings)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCategoryGUID);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSettings);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE(pfRestartRequired);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
