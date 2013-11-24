/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENUMOUTPUTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENUMOUTPUTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsEnumOutputsNotImpl :
	public IVsEnumOutputs
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumOutputsNotImpl)

public:

	typedef IVsEnumOutputs Interface;

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*cElements*/,
		/*[in,out,size_is(cElements)]*/ IVsOutput*[] /*rgpIVsOutput*/,
		/*[out,optional]*/ ULONG* /*pcElementsFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Skip)(
		/*[in]*/ ULONG /*cElements*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[out]*/ IVsEnumOutputs** /*ppIVsEnumOutputs*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEnumOutputsMockImpl :
	public IVsEnumOutputs,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnumOutputsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEnumOutputsMockImpl)

	typedef IVsEnumOutputs Interface;
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct NextValidValues
	{
		/*[in]*/ ULONG cElements;
		/*[in,out,size_is(cElements)]*/ IVsOutput** rgpIVsOutput;
		/*[out,optional]*/ ULONG* pcElementsFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG cElements,
		/*[in,out,size_is(cElements)]*/ IVsOutput* rgpIVsOutput[],
		/*[out,optional]*/ ULONG* pcElementsFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(cElements);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgpIVsOutput, cElements, validValues.cElements);

		VSL_SET_VALIDVALUE(pcElementsFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct SkipValidValues
	{
		/*[in]*/ ULONG cElements;
		HRESULT retValue;
	};

	STDMETHOD(Skip)(
		/*[in]*/ ULONG cElements)
	{
		VSL_DEFINE_MOCK_METHOD(Skip)

		VSL_CHECK_VALIDVALUE(cElements);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneValidValues
	{
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsEnumOutputs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENUMOUTPUTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
