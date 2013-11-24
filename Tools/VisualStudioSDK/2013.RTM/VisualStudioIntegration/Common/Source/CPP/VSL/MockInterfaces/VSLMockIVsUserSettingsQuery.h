/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERSETTINGSQUERY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERSETTINGSQUERY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUserSettingsQueryNotImpl :
	public IVsUserSettingsQuery
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserSettingsQueryNotImpl)

public:

	typedef IVsUserSettingsQuery Interface;

	STDMETHOD(NeedExport)(
		/*[in]*/ LPCOLESTR /*szCategoryGUID*/,
		/*[out]*/ BOOL* /*pfNeedExport*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserSettingsQueryMockImpl :
	public IVsUserSettingsQuery,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserSettingsQueryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserSettingsQueryMockImpl)

	typedef IVsUserSettingsQuery Interface;
	struct NeedExportValidValues
	{
		/*[in]*/ LPCOLESTR szCategoryGUID;
		/*[out]*/ BOOL* pfNeedExport;
		HRESULT retValue;
	};

	STDMETHOD(NeedExport)(
		/*[in]*/ LPCOLESTR szCategoryGUID,
		/*[out]*/ BOOL* pfNeedExport)
	{
		VSL_DEFINE_MOCK_METHOD(NeedExport)

		VSL_CHECK_VALIDVALUE_STRINGW(szCategoryGUID);

		VSL_SET_VALIDVALUE(pfNeedExport);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERSETTINGSQUERY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
