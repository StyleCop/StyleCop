/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSNAVIGABLELOCATIONRESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSNAVIGABLELOCATIONRESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsNavigableLocationResolverNotImpl :
	public IVsNavigableLocationResolver
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavigableLocationResolverNotImpl)

public:

	typedef IVsNavigableLocationResolver Interface;

	STDMETHOD(GetDisplayText)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ TextSpan* /*ptsBase*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[out]*/ NavigableLocationResolverFlags* /*dwOutFlags*/,
		/*[out,retval]*/ BSTR* /*pbstrDisplayText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPathFromLocation)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ TextSpan* /*ptsBase*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ const WCHAR* /*pszDisplayText*/,
		/*[out]*/ NavigableLocationResolverFlags* /*dwOutFlags*/,
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsNavigableLocationResolverMockImpl :
	public IVsNavigableLocationResolver,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavigableLocationResolverMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsNavigableLocationResolverMockImpl)

	typedef IVsNavigableLocationResolver Interface;
	struct GetDisplayTextValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ TextSpan* ptsBase;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[out]*/ NavigableLocationResolverFlags* dwOutFlags;
		/*[out,retval]*/ BSTR* pbstrDisplayText;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayText)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ TextSpan* ptsBase,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[out]*/ NavigableLocationResolverFlags* dwOutFlags,
		/*[out,retval]*/ BSTR* pbstrDisplayText)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayText)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_POINTER(ptsBase);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE(dwOutFlags);

		VSL_SET_VALIDVALUE_BSTR(pbstrDisplayText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPathFromLocationValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ TextSpan* ptsBase;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ WCHAR* pszDisplayText;
		/*[out]*/ NavigableLocationResolverFlags* dwOutFlags;
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetPathFromLocation)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ TextSpan* ptsBase,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ const WCHAR* pszDisplayText,
		/*[out]*/ NavigableLocationResolverFlags* dwOutFlags,
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetPathFromLocation)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_POINTER(ptsBase);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDisplayText);

		VSL_SET_VALIDVALUE(dwOutFlags);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSNAVIGABLELOCATIONRESOLVER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
