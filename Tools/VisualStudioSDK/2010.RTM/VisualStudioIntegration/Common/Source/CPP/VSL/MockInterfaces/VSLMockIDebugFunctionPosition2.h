/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGFUNCTIONPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGFUNCTIONPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugFunctionPosition2NotImpl :
	public IDebugFunctionPosition2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugFunctionPosition2NotImpl)

public:

	typedef IDebugFunctionPosition2 Interface;

	STDMETHOD(GetFunctionName)(
		/*[out]*/ BSTR* /*pbstrFunctionName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOffset)(
		/*[in,out,ptr]*/ TEXT_POSITION* /*pPosition*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugFunctionPosition2MockImpl :
	public IDebugFunctionPosition2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugFunctionPosition2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugFunctionPosition2MockImpl)

	typedef IDebugFunctionPosition2 Interface;
	struct GetFunctionNameValidValues
	{
		/*[out]*/ BSTR* pbstrFunctionName;
		HRESULT retValue;
	};

	STDMETHOD(GetFunctionName)(
		/*[out]*/ BSTR* pbstrFunctionName)
	{
		VSL_DEFINE_MOCK_METHOD(GetFunctionName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFunctionName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOffsetValidValues
	{
		/*[in,out,ptr]*/ TEXT_POSITION* pPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetOffset)(
		/*[in,out,ptr]*/ TEXT_POSITION* pPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetOffset)

		VSL_SET_VALIDVALUE(pPosition);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGFUNCTIONPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
