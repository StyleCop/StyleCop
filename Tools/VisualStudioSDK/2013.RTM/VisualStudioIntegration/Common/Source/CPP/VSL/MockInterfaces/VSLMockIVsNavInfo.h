/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSNAVINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSNAVINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsNavInfoNotImpl :
	public IVsNavInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavInfoNotImpl)

public:

	typedef IVsNavInfo Interface;

	STDMETHOD(GetLibGuid)(
		/*[out]*/ GUID* /*pGuid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSymbolType)(
		/*[out]*/ DWORD* /*pdwType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPresentationNodes)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ IVsEnumNavInfoNodes** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCanonicalNodes)(
		/*[out]*/ IVsEnumNavInfoNodes** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsNavInfoMockImpl :
	public IVsNavInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsNavInfoMockImpl)

	typedef IVsNavInfo Interface;
	struct GetLibGuidValidValues
	{
		/*[out]*/ GUID* pGuid;
		HRESULT retValue;
	};

	STDMETHOD(GetLibGuid)(
		/*[out]*/ GUID* pGuid)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibGuid)

		VSL_SET_VALIDVALUE(pGuid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSymbolTypeValidValues
	{
		/*[out]*/ DWORD* pdwType;
		HRESULT retValue;
	};

	STDMETHOD(GetSymbolType)(
		/*[out]*/ DWORD* pdwType)
	{
		VSL_DEFINE_MOCK_METHOD(GetSymbolType)

		VSL_SET_VALIDVALUE(pdwType);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumPresentationNodesValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ IVsEnumNavInfoNodes** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPresentationNodes)(
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ IVsEnumNavInfoNodes** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPresentationNodes)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCanonicalNodesValidValues
	{
		/*[out]*/ IVsEnumNavInfoNodes** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumCanonicalNodes)(
		/*[out]*/ IVsEnumNavInfoNodes** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCanonicalNodes)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSNAVINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
