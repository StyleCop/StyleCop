/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISURROGATESERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISURROGATESERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ISurrogateServiceNotImpl :
	public ISurrogateService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISurrogateServiceNotImpl)

public:

	typedef ISurrogateService Interface;

	STDMETHOD(Init)(
		/*[in]*/ REFGUID /*rguidProcessID*/,
		/*[in]*/ IProcessLock* /*pProcessLock*/,
		/*[out]*/ BOOL* /*pfApplicationAware*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ApplicationLaunch)(
		/*[in]*/ REFGUID /*rguidApplID*/,
		/*[in]*/ ApplicationType /*appType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ApplicationFree)(
		/*[in]*/ REFGUID /*rguidApplID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CatalogRefresh)(
		/*[in]*/ ULONG /*ulReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ProcessShutdown)(
		/*[in]*/ ShutdownType /*shutdownType*/)VSL_STDMETHOD_NOTIMPL
};

class ISurrogateServiceMockImpl :
	public ISurrogateService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISurrogateServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISurrogateServiceMockImpl)

	typedef ISurrogateService Interface;
	struct InitValidValues
	{
		/*[in]*/ REFGUID rguidProcessID;
		/*[in]*/ IProcessLock* pProcessLock;
		/*[out]*/ BOOL* pfApplicationAware;
		HRESULT retValue;
	};

	STDMETHOD(Init)(
		/*[in]*/ REFGUID rguidProcessID,
		/*[in]*/ IProcessLock* pProcessLock,
		/*[out]*/ BOOL* pfApplicationAware)
	{
		VSL_DEFINE_MOCK_METHOD(Init)

		VSL_CHECK_VALIDVALUE(rguidProcessID);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcessLock);

		VSL_SET_VALIDVALUE(pfApplicationAware);

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplicationLaunchValidValues
	{
		/*[in]*/ REFGUID rguidApplID;
		/*[in]*/ ApplicationType appType;
		HRESULT retValue;
	};

	STDMETHOD(ApplicationLaunch)(
		/*[in]*/ REFGUID rguidApplID,
		/*[in]*/ ApplicationType appType)
	{
		VSL_DEFINE_MOCK_METHOD(ApplicationLaunch)

		VSL_CHECK_VALIDVALUE(rguidApplID);

		VSL_CHECK_VALIDVALUE(appType);

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplicationFreeValidValues
	{
		/*[in]*/ REFGUID rguidApplID;
		HRESULT retValue;
	};

	STDMETHOD(ApplicationFree)(
		/*[in]*/ REFGUID rguidApplID)
	{
		VSL_DEFINE_MOCK_METHOD(ApplicationFree)

		VSL_CHECK_VALIDVALUE(rguidApplID);

		VSL_RETURN_VALIDVALUES();
	}
	struct CatalogRefreshValidValues
	{
		/*[in]*/ ULONG ulReserved;
		HRESULT retValue;
	};

	STDMETHOD(CatalogRefresh)(
		/*[in]*/ ULONG ulReserved)
	{
		VSL_DEFINE_MOCK_METHOD(CatalogRefresh)

		VSL_CHECK_VALIDVALUE(ulReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct ProcessShutdownValidValues
	{
		/*[in]*/ ShutdownType shutdownType;
		HRESULT retValue;
	};

	STDMETHOD(ProcessShutdown)(
		/*[in]*/ ShutdownType shutdownType)
	{
		VSL_DEFINE_MOCK_METHOD(ProcessShutdown)

		VSL_CHECK_VALIDVALUE(shutdownType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISURROGATESERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
