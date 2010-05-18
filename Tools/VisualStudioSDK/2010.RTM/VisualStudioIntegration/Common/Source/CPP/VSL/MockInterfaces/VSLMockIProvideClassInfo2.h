/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDECLASSINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDECLASSINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IProvideClassInfo2NotImpl :
	public IProvideClassInfo2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideClassInfo2NotImpl)

public:

	typedef IProvideClassInfo2 Interface;

	STDMETHOD(GetGUID)(
		/*[in]*/ DWORD /*dwGuidKind*/,
		/*[out]*/ GUID* /*pGUID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassInfo)(
		/*[out]*/ ITypeInfo** /*ppTI*/)VSL_STDMETHOD_NOTIMPL
};

class IProvideClassInfo2MockImpl :
	public IProvideClassInfo2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideClassInfo2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvideClassInfo2MockImpl)

	typedef IProvideClassInfo2 Interface;
	struct GetGUIDValidValues
	{
		/*[in]*/ DWORD dwGuidKind;
		/*[out]*/ GUID* pGUID;
		HRESULT retValue;
	};

	STDMETHOD(GetGUID)(
		/*[in]*/ DWORD dwGuidKind,
		/*[out]*/ GUID* pGUID)
	{
		VSL_DEFINE_MOCK_METHOD(GetGUID)

		VSL_CHECK_VALIDVALUE(dwGuidKind);

		VSL_SET_VALIDVALUE(pGUID);

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

#endif // IPROVIDECLASSINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
