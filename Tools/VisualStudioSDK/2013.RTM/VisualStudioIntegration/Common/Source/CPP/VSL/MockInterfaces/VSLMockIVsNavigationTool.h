/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSNAVIGATIONTOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSNAVIGATIONTOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsNavigationToolNotImpl :
	public IVsNavigationTool
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavigationToolNotImpl)

public:

	typedef IVsNavigationTool Interface;

	STDMETHOD(NavigateToSymbol)(
		/*[in]*/ REFGUID /*guidLib*/,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE[] /*rgSymbolNodes*/,
		/*[in]*/ ULONG /*ulcNodes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToNavInfo)(
		/*[in]*/ IVsNavInfo* /*pNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSelectedSymbols)(
		/*[out]*/ IVsSelectedSymbols** /*ppIVsSelectedSymbols*/)VSL_STDMETHOD_NOTIMPL
};

class IVsNavigationToolMockImpl :
	public IVsNavigationTool,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavigationToolMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsNavigationToolMockImpl)

	typedef IVsNavigationTool Interface;
	struct NavigateToSymbolValidValues
	{
		/*[in]*/ REFGUID guidLib;
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE* rgSymbolNodes;
		/*[in]*/ ULONG ulcNodes;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToSymbol)(
		/*[in]*/ REFGUID guidLib,
		/*[in,size_is(ulcNodes)]*/ SYMBOL_DESCRIPTION_NODE rgSymbolNodes[],
		/*[in]*/ ULONG ulcNodes)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToSymbol)

		VSL_CHECK_VALIDVALUE(guidLib);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSymbolNodes, ulcNodes*sizeof(rgSymbolNodes[0]), validValues.ulcNodes*sizeof(validValues.rgSymbolNodes[0]));

		VSL_CHECK_VALIDVALUE(ulcNodes);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToNavInfoValidValues
	{
		/*[in]*/ IVsNavInfo* pNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToNavInfo)(
		/*[in]*/ IVsNavInfo* pNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToNavInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSelectedSymbolsValidValues
	{
		/*[out]*/ IVsSelectedSymbols** ppIVsSelectedSymbols;
		HRESULT retValue;
	};

	STDMETHOD(GetSelectedSymbols)(
		/*[out]*/ IVsSelectedSymbols** ppIVsSelectedSymbols)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelectedSymbols)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsSelectedSymbols);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSNAVIGATIONTOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
