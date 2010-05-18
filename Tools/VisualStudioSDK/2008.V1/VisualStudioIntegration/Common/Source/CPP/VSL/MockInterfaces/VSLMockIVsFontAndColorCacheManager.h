/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORCACHEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORCACHEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorCacheManagerNotImpl :
	public IVsFontAndColorCacheManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorCacheManagerNotImpl)

public:

	typedef IVsFontAndColorCacheManager Interface;

	STDMETHOD(CheckCache)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[out]*/ BOOL* /*pfHasData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearCache)(
		/*[in]*/ REFGUID /*rguidCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshCache)(
		/*[in]*/ REFGUID /*rguidCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CheckCacheable)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[out]*/ BOOL* /*pfCacheable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearAllCaches)()VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorCacheManagerMockImpl :
	public IVsFontAndColorCacheManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorCacheManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorCacheManagerMockImpl)

	typedef IVsFontAndColorCacheManager Interface;
	struct CheckCacheValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[out]*/ BOOL* pfHasData;
		HRESULT retValue;
	};

	STDMETHOD(CheckCache)(
		/*[in]*/ REFGUID rguidCategory,
		/*[out]*/ BOOL* pfHasData)
	{
		VSL_DEFINE_MOCK_METHOD(CheckCache)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_SET_VALIDVALUE(pfHasData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearCacheValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(ClearCache)(
		/*[in]*/ REFGUID rguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(ClearCache)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshCacheValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(RefreshCache)(
		/*[in]*/ REFGUID rguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(RefreshCache)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct CheckCacheableValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[out]*/ BOOL* pfCacheable;
		HRESULT retValue;
	};

	STDMETHOD(CheckCacheable)(
		/*[in]*/ REFGUID rguidCategory,
		/*[out]*/ BOOL* pfCacheable)
	{
		VSL_DEFINE_MOCK_METHOD(CheckCacheable)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_SET_VALIDVALUE(pfCacheable);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearAllCachesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearAllCaches)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearAllCaches)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORCACHEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
