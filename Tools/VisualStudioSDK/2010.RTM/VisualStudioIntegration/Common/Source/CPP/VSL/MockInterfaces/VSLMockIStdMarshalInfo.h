/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISTDMARSHALINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISTDMARSHALINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IStdMarshalInfoNotImpl :
	public IStdMarshalInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStdMarshalInfoNotImpl)

public:

	typedef IStdMarshalInfo Interface;

	STDMETHOD(GetClassForHandler)(
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in,unique]*/ void* /*pvDestContext*/,
		/*[out]*/ CLSID* /*pClsid*/)VSL_STDMETHOD_NOTIMPL
};

class IStdMarshalInfoMockImpl :
	public IStdMarshalInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStdMarshalInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IStdMarshalInfoMockImpl)

	typedef IStdMarshalInfo Interface;
	struct GetClassForHandlerValidValues
	{
		/*[in]*/ DWORD dwDestContext;
		/*[in,unique]*/ void* pvDestContext;
		/*[out]*/ CLSID* pClsid;
		HRESULT retValue;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(GetClassForHandler)(
		/*[in]*/ DWORD dwDestContext,
		/*[in,unique]*/ void* pvDestContext,
		/*[out]*/ CLSID* pClsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassForHandler)

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_SET_VALIDVALUE(pClsid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISTDMARSHALINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
