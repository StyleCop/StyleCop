/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDCODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDCODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsContainedCodeNotImpl :
	public IVsContainedCode
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedCodeNotImpl)

public:

	typedef IVsContainedCode Interface;

	STDMETHOD(EnumOriginalCodeBlocks)(
		/*[out]*/ IVsEnumCodeBlocks** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HostSpansUpdated)()VSL_STDMETHOD_NOTIMPL
};

class IVsContainedCodeMockImpl :
	public IVsContainedCode,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedCodeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedCodeMockImpl)

	typedef IVsContainedCode Interface;
	struct EnumOriginalCodeBlocksValidValues
	{
		/*[out]*/ IVsEnumCodeBlocks** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumOriginalCodeBlocks)(
		/*[out]*/ IVsEnumCodeBlocks** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumOriginalCodeBlocks)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct HostSpansUpdatedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HostSpansUpdated)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HostSpansUpdated)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDCODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
