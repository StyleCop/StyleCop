/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDEDYNAMICCLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDEDYNAMICCLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "designer.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IProvideDynamicClassInfoNotImpl :
	public IProvideDynamicClassInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideDynamicClassInfoNotImpl)

public:

	typedef IProvideDynamicClassInfo Interface;

	STDMETHOD(GetDynamicClassInfo)(
		/*[out]*/ ITypeInfo** /*ppTI*/,
		/*[out]*/ DWORD_PTR* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreezeShape)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassInfo)(
		/*[out]*/ ITypeInfo** /*ppTI*/)VSL_STDMETHOD_NOTIMPL
};

class IProvideDynamicClassInfoMockImpl :
	public IProvideDynamicClassInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideDynamicClassInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvideDynamicClassInfoMockImpl)

	typedef IProvideDynamicClassInfo Interface;
	struct GetDynamicClassInfoValidValues
	{
		/*[out]*/ ITypeInfo** ppTI;
		/*[out]*/ DWORD_PTR* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(GetDynamicClassInfo)(
		/*[out]*/ ITypeInfo** ppTI,
		/*[out]*/ DWORD_PTR* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(GetDynamicClassInfo)

		VSL_SET_VALIDVALUE_INTERFACE(ppTI);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreezeShapeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FreezeShape)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FreezeShape)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassInfoValidValues
	{
		/*[out]*/ ITypeInfo** ppTI;
		HRESULT retValue;
	};

	STDMETHOD(GetClassInfo)(
		/*[out]*/ ITypeInfo** ppTI)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassInfo)

		VSL_SET_VALIDVALUE_INTERFACE(ppTI);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROVIDEDYNAMICCLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
