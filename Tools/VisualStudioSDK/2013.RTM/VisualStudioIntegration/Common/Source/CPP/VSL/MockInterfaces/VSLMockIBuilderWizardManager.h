/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IBUILDERWIZARDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IBUILDERWIZARDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ocdesign.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IBuilderWizardManagerNotImpl :
	public IBuilderWizardManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBuilderWizardManagerNotImpl)

public:

	typedef IBuilderWizardManager Interface;

	STDMETHOD(DoesBuilderExist)(
		/*[in]*/ REFGUID /*rguidBuilder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapObjectToBuilderCLSID)(
		/*[in]*/ REFCLSID /*rclsidObject*/,
		/*[in]*/ DWORD /*dwPromptOpt*/,
		/*[in]*/ HWND /*hwndPromptOwner*/,
		/*[out]*/ CLSID* /*pclsidBuilder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapBuilderCATIDToCLSID)(
		/*[in]*/ REFGUID /*rguidBuilder*/,
		/*[in]*/ DWORD /*dwPromptOpt*/,
		/*[in]*/ HWND /*hwndPromptOwner*/,
		/*[out]*/ CLSID* /*pclsidBuilder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuilder)(
		/*[in]*/ REFGUID /*rguidBuilder*/,
		/*[in]*/ DWORD /*grfGetOpt*/,
		/*[in]*/ HWND /*hwndPromptOwner*/,
		/*[out]*/ IDispatch** /*ppdispApp*/,
		/*[out]*/ HWND* /*pwndBuilderOwner*/,
		/*[in]*/ REFIID /*riidBuilder*/,
		/*[out]*/ IUnknown** /*ppunkBuilder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL
};

class IBuilderWizardManagerMockImpl :
	public IBuilderWizardManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBuilderWizardManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IBuilderWizardManagerMockImpl)

	typedef IBuilderWizardManager Interface;
	struct DoesBuilderExistValidValues
	{
		/*[in]*/ REFGUID rguidBuilder;
		HRESULT retValue;
	};

	STDMETHOD(DoesBuilderExist)(
		/*[in]*/ REFGUID rguidBuilder)
	{
		VSL_DEFINE_MOCK_METHOD(DoesBuilderExist)

		VSL_CHECK_VALIDVALUE(rguidBuilder);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapObjectToBuilderCLSIDValidValues
	{
		/*[in]*/ REFCLSID rclsidObject;
		/*[in]*/ DWORD dwPromptOpt;
		/*[in]*/ HWND hwndPromptOwner;
		/*[out]*/ CLSID* pclsidBuilder;
		HRESULT retValue;
	};

	STDMETHOD(MapObjectToBuilderCLSID)(
		/*[in]*/ REFCLSID rclsidObject,
		/*[in]*/ DWORD dwPromptOpt,
		/*[in]*/ HWND hwndPromptOwner,
		/*[out]*/ CLSID* pclsidBuilder)
	{
		VSL_DEFINE_MOCK_METHOD(MapObjectToBuilderCLSID)

		VSL_CHECK_VALIDVALUE(rclsidObject);

		VSL_CHECK_VALIDVALUE(dwPromptOpt);

		VSL_CHECK_VALIDVALUE(hwndPromptOwner);

		VSL_SET_VALIDVALUE(pclsidBuilder);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapBuilderCATIDToCLSIDValidValues
	{
		/*[in]*/ REFGUID rguidBuilder;
		/*[in]*/ DWORD dwPromptOpt;
		/*[in]*/ HWND hwndPromptOwner;
		/*[out]*/ CLSID* pclsidBuilder;
		HRESULT retValue;
	};

	STDMETHOD(MapBuilderCATIDToCLSID)(
		/*[in]*/ REFGUID rguidBuilder,
		/*[in]*/ DWORD dwPromptOpt,
		/*[in]*/ HWND hwndPromptOwner,
		/*[out]*/ CLSID* pclsidBuilder)
	{
		VSL_DEFINE_MOCK_METHOD(MapBuilderCATIDToCLSID)

		VSL_CHECK_VALIDVALUE(rguidBuilder);

		VSL_CHECK_VALIDVALUE(dwPromptOpt);

		VSL_CHECK_VALIDVALUE(hwndPromptOwner);

		VSL_SET_VALIDVALUE(pclsidBuilder);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuilderValidValues
	{
		/*[in]*/ REFGUID rguidBuilder;
		/*[in]*/ DWORD grfGetOpt;
		/*[in]*/ HWND hwndPromptOwner;
		/*[out]*/ IDispatch** ppdispApp;
		/*[out]*/ HWND* pwndBuilderOwner;
		/*[in]*/ REFIID riidBuilder;
		/*[out]*/ IUnknown** ppunkBuilder;
		HRESULT retValue;
	};

	STDMETHOD(GetBuilder)(
		/*[in]*/ REFGUID rguidBuilder,
		/*[in]*/ DWORD grfGetOpt,
		/*[in]*/ HWND hwndPromptOwner,
		/*[out]*/ IDispatch** ppdispApp,
		/*[out]*/ HWND* pwndBuilderOwner,
		/*[in]*/ REFIID riidBuilder,
		/*[out]*/ IUnknown** ppunkBuilder)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuilder)

		VSL_CHECK_VALIDVALUE(rguidBuilder);

		VSL_CHECK_VALIDVALUE(grfGetOpt);

		VSL_CHECK_VALIDVALUE(hwndPromptOwner);

		VSL_SET_VALIDVALUE_INTERFACE(ppdispApp);

		VSL_SET_VALIDVALUE(pwndBuilderOwner);

		VSL_CHECK_VALIDVALUE(riidBuilder);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkBuilder);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableModelessValidValues
	{
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(EnableModeless)

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IBUILDERWIZARDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
