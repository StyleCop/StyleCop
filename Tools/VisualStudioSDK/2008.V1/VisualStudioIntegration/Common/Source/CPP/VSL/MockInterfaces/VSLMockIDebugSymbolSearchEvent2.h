/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGSYMBOLSEARCHEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGSYMBOLSEARCHEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugSymbolSearchEvent2NotImpl :
	public IDebugSymbolSearchEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSymbolSearchEvent2NotImpl)

public:

	typedef IDebugSymbolSearchEvent2 Interface;

	STDMETHOD(GetSymbolSearchInfo)(
		/*[out]*/ IDebugModule3** /*pModule*/,
		/*[in,out]*/ BSTR* /*pbstrDebugMessage*/,
		/*[out]*/ MODULE_INFO_FLAGS* /*pdwModuleInfoFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugSymbolSearchEvent2MockImpl :
	public IDebugSymbolSearchEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSymbolSearchEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugSymbolSearchEvent2MockImpl)

	typedef IDebugSymbolSearchEvent2 Interface;
	struct GetSymbolSearchInfoValidValues
	{
		/*[out]*/ IDebugModule3** pModule;
		/*[in,out]*/ BSTR* pbstrDebugMessage;
		/*[out]*/ MODULE_INFO_FLAGS* pdwModuleInfoFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetSymbolSearchInfo)(
		/*[out]*/ IDebugModule3** pModule,
		/*[in,out]*/ BSTR* pbstrDebugMessage,
		/*[out]*/ MODULE_INFO_FLAGS* pdwModuleInfoFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetSymbolSearchInfo)

		VSL_SET_VALIDVALUE_INTERFACE(pModule);

		VSL_SET_VALIDVALUE_BSTR(pbstrDebugMessage);

		VSL_SET_VALIDVALUE(pdwModuleInfoFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGSYMBOLSEARCHEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
