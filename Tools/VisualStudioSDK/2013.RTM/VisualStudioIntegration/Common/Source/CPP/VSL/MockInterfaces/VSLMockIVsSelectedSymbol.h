/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSELECTEDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSELECTEDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSelectedSymbolNotImpl :
	public IVsSelectedSymbol
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectedSymbolNotImpl)

public:

	typedef IVsSelectedSymbol Interface;

	STDMETHOD(GetNavInfo)(
		/*[out]*/ IVsNavInfo** /*ppNavInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSelectedSymbolMockImpl :
	public IVsSelectedSymbol,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectedSymbolMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSelectedSymbolMockImpl)

	typedef IVsSelectedSymbol Interface;
	struct GetNavInfoValidValues
	{
		/*[out]*/ IVsNavInfo** ppNavInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetNavInfo)(
		/*[out]*/ IVsNavInfo** ppNavInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetNavInfo)

		VSL_SET_VALIDVALUE_INTERFACE(ppNavInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSELECTEDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
