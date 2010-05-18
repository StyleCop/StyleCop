/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGLOGICALTHREAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGLOGICALTHREAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugLogicalThread2NotImpl :
	public IDebugLogicalThread2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugLogicalThread2NotImpl)

public:

	typedef IDebugLogicalThread2 Interface;

	STDMETHOD(EnumFrameInfo)(
		/*[in]*/ FRAMEINFO_FLAGS /*dwFieldSpec*/,
		/*[in]*/ UINT /*nRadix*/,
		/*[out]*/ IEnumDebugFrameInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugLogicalThread2MockImpl :
	public IDebugLogicalThread2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugLogicalThread2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugLogicalThread2MockImpl)

	typedef IDebugLogicalThread2 Interface;
	struct EnumFrameInfoValidValues
	{
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec;
		/*[in]*/ UINT nRadix;
		/*[out]*/ IEnumDebugFrameInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumFrameInfo)(
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec,
		/*[in]*/ UINT nRadix,
		/*[out]*/ IEnumDebugFrameInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumFrameInfo)

		VSL_CHECK_VALIDVALUE(dwFieldSpec);

		VSL_CHECK_VALIDVALUE(nRadix);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGLOGICALTHREAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
