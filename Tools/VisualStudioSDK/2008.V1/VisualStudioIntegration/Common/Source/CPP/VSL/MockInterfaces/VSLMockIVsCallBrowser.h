/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCALLBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCALLBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCallBrowserNotImpl :
	public IVsCallBrowser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCallBrowserNotImpl)

public:

	typedef IVsCallBrowser Interface;

	STDMETHOD(SetRootAtSymbol)(
		/*[in]*/ CALLBROWSERMODE /*cbMode*/,
		/*[in]*/ REFGUID /*guidLib*/,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE[] /*rgSymbolNodes*/,
		/*[in]*/ ULONG /*ulcNodes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRootAtNavInfo)(
		/*[in]*/ CALLBROWSERMODE /*cbMode*/,
		/*[in]*/ IVsNavInfo* /*pNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanCreateNewInstance)(
		/*[out]*/ BOOL* /*pfOK*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCallBrowserMockImpl :
	public IVsCallBrowser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCallBrowserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCallBrowserMockImpl)

	typedef IVsCallBrowser Interface;
	struct SetRootAtSymbolValidValues
	{
		/*[in]*/ CALLBROWSERMODE cbMode;
		/*[in]*/ REFGUID guidLib;
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE* rgSymbolNodes;
		/*[in]*/ ULONG ulcNodes;
		HRESULT retValue;
	};

	STDMETHOD(SetRootAtSymbol)(
		/*[in]*/ CALLBROWSERMODE cbMode,
		/*[in]*/ REFGUID guidLib,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE rgSymbolNodes[],
		/*[in]*/ ULONG ulcNodes)
	{
		VSL_DEFINE_MOCK_METHOD(SetRootAtSymbol)

		VSL_CHECK_VALIDVALUE(cbMode);

		VSL_CHECK_VALIDVALUE(guidLib);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSymbolNodes, ulcNodes*sizeof(rgSymbolNodes[0]), validValues.ulcNodes*sizeof(validValues.rgSymbolNodes[0]));

		VSL_CHECK_VALIDVALUE(ulcNodes);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRootAtNavInfoValidValues
	{
		/*[in]*/ CALLBROWSERMODE cbMode;
		/*[in]*/ IVsNavInfo* pNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(SetRootAtNavInfo)(
		/*[in]*/ CALLBROWSERMODE cbMode,
		/*[in]*/ IVsNavInfo* pNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(SetRootAtNavInfo)

		VSL_CHECK_VALIDVALUE(cbMode);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanCreateNewInstanceValidValues
	{
		/*[out]*/ BOOL* pfOK;
		HRESULT retValue;
	};

	STDMETHOD(CanCreateNewInstance)(
		/*[out]*/ BOOL* pfOK)
	{
		VSL_DEFINE_MOCK_METHOD(CanCreateNewInstance)

		VSL_SET_VALIDVALUE(pfOK);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCALLBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
