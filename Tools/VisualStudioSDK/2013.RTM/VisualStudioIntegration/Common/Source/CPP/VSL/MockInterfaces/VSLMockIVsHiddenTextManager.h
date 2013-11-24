/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiddenTextManagerNotImpl :
	public IVsHiddenTextManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextManagerNotImpl)

public:

	typedef IVsHiddenTextManager Interface;

	STDMETHOD(GetHiddenTextSession)(
		/*[in]*/ IUnknown* /*pOwningObject*/,
		/*[out]*/ IVsHiddenTextSession** /*ppSession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateHiddenTextSession)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IUnknown* /*pOwningObject*/,
		/*[in]*/ IVsHiddenTextClient* /*pClient*/,
		/*[out]*/ IVsHiddenTextSession** /*ppState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenTextManagerMockImpl :
	public IVsHiddenTextManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenTextManagerMockImpl)

	typedef IVsHiddenTextManager Interface;
	struct GetHiddenTextSessionValidValues
	{
		/*[in]*/ IUnknown* pOwningObject;
		/*[out]*/ IVsHiddenTextSession** ppSession;
		HRESULT retValue;
	};

	STDMETHOD(GetHiddenTextSession)(
		/*[in]*/ IUnknown* pOwningObject,
		/*[out]*/ IVsHiddenTextSession** ppSession)
	{
		VSL_DEFINE_MOCK_METHOD(GetHiddenTextSession)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwningObject);

		VSL_SET_VALIDVALUE_INTERFACE(ppSession);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateHiddenTextSessionValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IUnknown* pOwningObject;
		/*[in]*/ IVsHiddenTextClient* pClient;
		/*[out]*/ IVsHiddenTextSession** ppState;
		HRESULT retValue;
	};

	STDMETHOD(CreateHiddenTextSession)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IUnknown* pOwningObject,
		/*[in]*/ IVsHiddenTextClient* pClient,
		/*[out]*/ IVsHiddenTextSession** ppState)
	{
		VSL_DEFINE_MOCK_METHOD(CreateHiddenTextSession)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOwningObject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_SET_VALIDVALUE_INTERFACE(ppState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
