/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSELECTEDSYMBOLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSELECTEDSYMBOLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSelectedSymbolsNotImpl :
	public IVsSelectedSymbols
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectedSymbolsNotImpl)

public:

	typedef IVsSelectedSymbols Interface;

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* /*pcItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItem)(
		/*[in]*/ ULONG /*iItem*/,
		/*[out]*/ IVsSelectedSymbol** /*ppIVsSelectedSymbol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumSelectedSymbols)(
		/*[out]*/ IVsEnumSelectedSymbols** /*ppIVsEnumSelectedSymbols*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemTypes)(
		/*[out]*/ DWORD* /*pgrfTypes*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSelectedSymbolsMockImpl :
	public IVsSelectedSymbols,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectedSymbolsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSelectedSymbolsMockImpl)

	typedef IVsSelectedSymbols Interface;
	struct GetCountValidValues
	{
		/*[out]*/ ULONG* pcItems;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* pcItems)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pcItems);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemValidValues
	{
		/*[in]*/ ULONG iItem;
		/*[out]*/ IVsSelectedSymbol** ppIVsSelectedSymbol;
		HRESULT retValue;
	};

	STDMETHOD(GetItem)(
		/*[in]*/ ULONG iItem,
		/*[out]*/ IVsSelectedSymbol** ppIVsSelectedSymbol)
	{
		VSL_DEFINE_MOCK_METHOD(GetItem)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsSelectedSymbol);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumSelectedSymbolsValidValues
	{
		/*[out]*/ IVsEnumSelectedSymbols** ppIVsEnumSelectedSymbols;
		HRESULT retValue;
	};

	STDMETHOD(EnumSelectedSymbols)(
		/*[out]*/ IVsEnumSelectedSymbols** ppIVsEnumSelectedSymbols)
	{
		VSL_DEFINE_MOCK_METHOD(EnumSelectedSymbols)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsEnumSelectedSymbols);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemTypesValidValues
	{
		/*[out]*/ DWORD* pgrfTypes;
		HRESULT retValue;
	};

	STDMETHOD(GetItemTypes)(
		/*[out]*/ DWORD* pgrfTypes)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemTypes)

		VSL_SET_VALIDVALUE(pgrfTypes);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSELECTEDSYMBOLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
