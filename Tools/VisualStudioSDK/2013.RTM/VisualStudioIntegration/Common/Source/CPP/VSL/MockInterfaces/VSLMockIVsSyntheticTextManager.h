/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSYNTHETICTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSYNTHETICTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSyntheticTextManagerNotImpl :
	public IVsSyntheticTextManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSyntheticTextManagerNotImpl)

public:

	typedef IVsSyntheticTextManager Interface;

	STDMETHOD(GetSyntheticTextSession)(
		/*[in]*/ IUnknown* /*pOwningObject*/,
		/*[out]*/ IVsSyntheticTextSession** /*ppSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateSyntheticTextSession)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IUnknown* /*pOwningObject*/,
		/*[in]*/ IVsSyntheticTextClient* /*pClient*/,
		/*[out]*/ IVsSyntheticTextSession** /*ppState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSyntheticTextManagerMockImpl :
	public IVsSyntheticTextManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSyntheticTextManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSyntheticTextManagerMockImpl)

	typedef IVsSyntheticTextManager Interface;
	struct GetSyntheticTextSessionValidValues
	{
		/*[in]*/ IUnknown* pOwningObject;
		/*[out]*/ IVsSyntheticTextSession** ppSession;
		HRESULT retValue;
	};

	STDMETHOD(GetSyntheticTextSession)(
		/*[in]*/ IUnknown* pOwningObject,
		/*[out]*/ IVsSyntheticTextSession** ppSession)
	{
		VSL_DEFINE_MOCK_METHOD(GetSyntheticTextSession)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwningObject);

		VSL_SET_VALIDVALUE_INTERFACE(ppSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateSyntheticTextSessionValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IUnknown* pOwningObject;
		/*[in]*/ IVsSyntheticTextClient* pClient;
		/*[out]*/ IVsSyntheticTextSession** ppState;
		HRESULT retValue;
	};

	STDMETHOD(CreateSyntheticTextSession)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IUnknown* pOwningObject,
		/*[in]*/ IVsSyntheticTextClient* pClient,
		/*[out]*/ IVsSyntheticTextSession** ppState)
	{
		VSL_DEFINE_MOCK_METHOD(CreateSyntheticTextSession)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwningObject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_SET_VALIDVALUE_INTERFACE(ppState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSYNTHETICTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
