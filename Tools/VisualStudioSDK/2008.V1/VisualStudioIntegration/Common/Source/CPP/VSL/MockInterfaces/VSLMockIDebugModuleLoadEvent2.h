/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMODULELOADEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMODULELOADEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugModuleLoadEvent2NotImpl :
	public IDebugModuleLoadEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModuleLoadEvent2NotImpl)

public:

	typedef IDebugModuleLoadEvent2 Interface;

	STDMETHOD(GetModule)(
		/*[out]*/ IDebugModule2** /*pModule*/,
		/*[in,out]*/ BSTR* /*pbstrDebugMessage*/,
		/*[in,out]*/ BOOL* /*pbLoad*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugModuleLoadEvent2MockImpl :
	public IDebugModuleLoadEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModuleLoadEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugModuleLoadEvent2MockImpl)

	typedef IDebugModuleLoadEvent2 Interface;
	struct GetModuleValidValues
	{
		/*[out]*/ IDebugModule2** pModule;
		/*[in,out]*/ BSTR* pbstrDebugMessage;
		/*[in,out]*/ BOOL* pbLoad;
		HRESULT retValue;
	};

	STDMETHOD(GetModule)(
		/*[out]*/ IDebugModule2** pModule,
		/*[in,out]*/ BSTR* pbstrDebugMessage,
		/*[in,out]*/ BOOL* pbLoad)
	{
		VSL_DEFINE_MOCK_METHOD(GetModule)

		VSL_SET_VALIDVALUE_INTERFACE(pModule);

		VSL_SET_VALIDVALUE_BSTR(pbstrDebugMessage);

		VSL_SET_VALIDVALUE(pbLoad);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMODULELOADEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
