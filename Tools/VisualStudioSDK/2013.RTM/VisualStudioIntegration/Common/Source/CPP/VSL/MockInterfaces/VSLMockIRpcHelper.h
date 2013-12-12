/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IRPCHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IRPCHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IRpcHelperNotImpl :
	public IRpcHelper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRpcHelperNotImpl)

public:

	typedef IRpcHelper Interface;

	STDMETHOD(GetDCOMProtocolVersion)(
		/*[out]*/ DWORD* /*pComVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIIDFromOBJREF)(
		/*[in]*/ void* /*pObjRef*/,
		/*[out]*/ IID** /*piid*/)VSL_STDMETHOD_NOTIMPL
};

class IRpcHelperMockImpl :
	public IRpcHelper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRpcHelperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRpcHelperMockImpl)

	typedef IRpcHelper Interface;
	struct GetDCOMProtocolVersionValidValues
	{
		/*[out]*/ DWORD* pComVersion;
		HRESULT retValue;
	};

	STDMETHOD(GetDCOMProtocolVersion)(
		/*[out]*/ DWORD* pComVersion)
	{
		VSL_DEFINE_MOCK_METHOD(GetDCOMProtocolVersion)

		VSL_SET_VALIDVALUE(pComVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIIDFromOBJREFValidValues
	{
		/*[in]*/ void* pObjRef;
		/*[out]*/ IID** piid;
		HRESULT retValue;
		size_t pObjRef_size_in_bytes;
	};

	STDMETHOD(GetIIDFromOBJREF)(
		/*[in]*/ void* pObjRef,
		/*[out]*/ IID** piid)
	{
		VSL_DEFINE_MOCK_METHOD(GetIIDFromOBJREF)

		VSL_CHECK_VALIDVALUE_PVOID(pObjRef);

		VSL_SET_VALIDVALUE(piid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IRPCHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
