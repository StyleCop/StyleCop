/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IREQUIRECLASSES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IREQUIRECLASSES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IRequireClassesNotImpl :
	public IRequireClasses
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRequireClassesNotImpl)

public:

	typedef IRequireClasses Interface;

	STDMETHOD(CountRequiredClasses)(
		/*[out]*/ ULONG* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRequiredClasses)(
		/*[in]*/ ULONG /*index*/,
		/*[in]*/ CLSID* /*pclsid*/)VSL_STDMETHOD_NOTIMPL
};

class IRequireClassesMockImpl :
	public IRequireClasses,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRequireClassesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRequireClassesMockImpl)

	typedef IRequireClasses Interface;
	struct CountRequiredClassesValidValues
	{
		/*[out]*/ ULONG* pCount;
		HRESULT retValue;
	};

	STDMETHOD(CountRequiredClasses)(
		/*[out]*/ ULONG* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(CountRequiredClasses)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRequiredClassesValidValues
	{
		/*[in]*/ ULONG index;
		/*[in]*/ CLSID* pclsid;
		HRESULT retValue;
	};

	STDMETHOD(GetRequiredClasses)(
		/*[in]*/ ULONG index,
		/*[in]*/ CLSID* pclsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetRequiredClasses)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_POINTER(pclsid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IREQUIRECLASSES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
