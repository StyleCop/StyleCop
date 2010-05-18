/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IENUMACTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IENUMACTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "undoredo.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IEnumActionsNotImpl :
	public IEnumActions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumActionsNotImpl)

public:

	typedef IEnumActions Interface;

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*celt*/,
		/*[in]*/ IAction** /*rgelt*/,
		/*[in]*/ ULONG* /*pceltFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Skip)(
		/*[in]*/ ULONG /*celt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[in]*/ IEnumActions** /*ppenum*/)VSL_STDMETHOD_NOTIMPL
};

class IEnumActionsMockImpl :
	public IEnumActions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumActionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEnumActionsMockImpl)

	typedef IEnumActions Interface;
	struct NextValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in]*/ IAction** rgelt;
		/*[in]*/ ULONG* pceltFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG celt,
		/*[in]*/ IAction** rgelt,
		/*[in]*/ ULONG* pceltFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(rgelt);

		VSL_CHECK_VALIDVALUE_POINTER(pceltFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct SkipValidValues
	{
		/*[in]*/ ULONG celt;
		HRESULT retValue;
	};

	STDMETHOD(Skip)(
		/*[in]*/ ULONG celt)
	{
		VSL_DEFINE_MOCK_METHOD(Skip)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneValidValues
	{
		/*[in]*/ IEnumActions** ppenum;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[in]*/ IEnumActions** ppenum)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppenum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IENUMACTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
