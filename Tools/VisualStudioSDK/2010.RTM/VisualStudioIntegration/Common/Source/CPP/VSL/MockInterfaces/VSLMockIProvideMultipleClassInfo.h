/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDEMULTIPLECLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDEMULTIPLECLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IProvideMultipleClassInfoNotImpl :
	public IProvideMultipleClassInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideMultipleClassInfoNotImpl)

public:

	typedef IProvideMultipleClassInfo Interface;

	STDMETHOD(GetMultiTypeInfoCount)(
		/*[out]*/ ULONG* /*pcti*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInfoOfIndex)(
		/*[in]*/ ULONG /*iti*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ ITypeInfo** /*pptiCoClass*/,
		/*[out]*/ DWORD* /*pdwTIFlags*/,
		/*[out]*/ ULONG* /*pcdispidReserved*/,
		/*[out]*/ IID* /*piidPrimary*/,
		/*[out]*/ IID* /*piidSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGUID)(
		/*[in]*/ DWORD /*dwGuidKind*/,
		/*[out]*/ GUID* /*pGUID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassInfo)(
		/*[out]*/ ITypeInfo** /*ppTI*/)VSL_STDMETHOD_NOTIMPL
};

class IProvideMultipleClassInfoMockImpl :
	public IProvideMultipleClassInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvideMultipleClassInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvideMultipleClassInfoMockImpl)

	typedef IProvideMultipleClassInfo Interface;
	struct GetMultiTypeInfoCountValidValues
	{
		/*[out]*/ ULONG* pcti;
		HRESULT retValue;
	};

	STDMETHOD(GetMultiTypeInfoCount)(
		/*[out]*/ ULONG* pcti)
	{
		VSL_DEFINE_MOCK_METHOD(GetMultiTypeInfoCount)

		VSL_SET_VALIDVALUE(pcti);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInfoOfIndexValidValues
	{
		/*[in]*/ ULONG iti;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ ITypeInfo** pptiCoClass;
		/*[out]*/ DWORD* pdwTIFlags;
		/*[out]*/ ULONG* pcdispidReserved;
		/*[out]*/ IID* piidPrimary;
		/*[out]*/ IID* piidSource;
		HRESULT retValue;
	};

	STDMETHOD(GetInfoOfIndex)(
		/*[in]*/ ULONG iti,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ ITypeInfo** pptiCoClass,
		/*[out]*/ DWORD* pdwTIFlags,
		/*[out]*/ ULONG* pcdispidReserved,
		/*[out]*/ IID* piidPrimary,
		/*[out]*/ IID* piidSource)
	{
		VSL_DEFINE_MOCK_METHOD(GetInfoOfIndex)

		VSL_CHECK_VALIDVALUE(iti);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(pptiCoClass);

		VSL_SET_VALIDVALUE(pdwTIFlags);

		VSL_SET_VALIDVALUE(pcdispidReserved);

		VSL_SET_VALIDVALUE(piidPrimary);

		VSL_SET_VALIDVALUE(piidSource);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // IPROVIDEMULTIPLECLASSINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
