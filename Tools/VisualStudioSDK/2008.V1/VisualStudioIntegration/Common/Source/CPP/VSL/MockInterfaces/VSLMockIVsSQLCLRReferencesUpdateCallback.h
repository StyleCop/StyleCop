/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSQLCLRREFERENCESUPDATECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSQLCLRREFERENCESUPDATECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSQLCLRReferencesUpdateCallbackNotImpl :
	public IVsSQLCLRReferencesUpdateCallback
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSQLCLRReferencesUpdateCallbackNotImpl)

public:

	typedef IVsSQLCLRReferencesUpdateCallback Interface;

	STDMETHOD(UpdateResult)(
		/*[in]*/ LPCWSTR /*szAssembly*/,
		/*[in]*/ DWORD /*dwPermisionLevel*/,
		/*[in]*/ HRESULT /*hrUpdateResult*/,
		/*[in]*/ IErrorInfo* /*pErrorInfo*/,
		/*[in]*/ SqlReferenceUpdateAction /*updateAction*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSQLCLRReferencesUpdateCallbackMockImpl :
	public IVsSQLCLRReferencesUpdateCallback,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSQLCLRReferencesUpdateCallbackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSQLCLRReferencesUpdateCallbackMockImpl)

	typedef IVsSQLCLRReferencesUpdateCallback Interface;
	struct UpdateResultValidValues
	{
		/*[in]*/ LPCWSTR szAssembly;
		/*[in]*/ DWORD dwPermisionLevel;
		/*[in]*/ HRESULT hrUpdateResult;
		/*[in]*/ IErrorInfo* pErrorInfo;
		/*[in]*/ SqlReferenceUpdateAction updateAction;
		HRESULT retValue;
	};

	STDMETHOD(UpdateResult)(
		/*[in]*/ LPCWSTR szAssembly,
		/*[in]*/ DWORD dwPermisionLevel,
		/*[in]*/ HRESULT hrUpdateResult,
		/*[in]*/ IErrorInfo* pErrorInfo,
		/*[in]*/ SqlReferenceUpdateAction updateAction)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateResult)

		VSL_CHECK_VALIDVALUE_STRINGW(szAssembly);

		VSL_CHECK_VALIDVALUE(dwPermisionLevel);

		VSL_CHECK_VALIDVALUE(hrUpdateResult);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrorInfo);

		VSL_CHECK_VALIDVALUE(updateAction);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSQLCLRREFERENCESUPDATECALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
