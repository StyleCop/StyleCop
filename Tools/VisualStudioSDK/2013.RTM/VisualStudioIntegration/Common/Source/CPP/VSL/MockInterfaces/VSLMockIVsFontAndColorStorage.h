/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFontAndColorStorageNotImpl :
	public IVsFontAndColorStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorStorageNotImpl)

public:

	typedef IVsFontAndColorStorage Interface;

	STDMETHOD(OpenCategory)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[in]*/ FCSTORAGEFLAGS /*fFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseCategory)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveCategory)(
		/*[in]*/ REFGUID /*rguidCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFont)(
		/*[in,out]*/ LOGFONTW* /*pLOGFONT*/,
		/*[in,out]*/ FontInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItem)(
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in,out]*/ ColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFont)(
		/*[in]*/ FontInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetItem)(
		/*[in]*/ LPCOLESTR /*szName*/,
		/*[in]*/ ColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorStorageMockImpl :
	public IVsFontAndColorStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorStorageMockImpl)

	typedef IVsFontAndColorStorage Interface;
	struct OpenCategoryValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[in]*/ FCSTORAGEFLAGS fFlags;
		HRESULT retValue;
	};

	STDMETHOD(OpenCategory)(
		/*[in]*/ REFGUID rguidCategory,
		/*[in]*/ FCSTORAGEFLAGS fFlags)
	{
		VSL_DEFINE_MOCK_METHOD(OpenCategory)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_CHECK_VALIDVALUE(fFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseCategoryValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseCategory)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseCategory)

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveCategoryValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(RemoveCategory)(
		/*[in]*/ REFGUID rguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveCategory)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFontValidValues
	{
		/*[in,out]*/ LOGFONTW* pLOGFONT;
		/*[in,out]*/ FontInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetFont)(
		/*[in,out]*/ LOGFONTW* pLOGFONT,
		/*[in,out]*/ FontInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetFont)

		VSL_SET_VALIDVALUE(pLOGFONT);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		/*[in,out]*/ ColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetItem)(
		/*[in]*/ LPCOLESTR szName,
		/*[in,out]*/ ColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetItem)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFontValidValues
	{
		/*[in]*/ FontInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(SetFont)(
		/*[in]*/ FontInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(SetFont)

		VSL_CHECK_VALIDVALUE_POINTER(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetItemValidValues
	{
		/*[in]*/ LPCOLESTR szName;
		/*[in]*/ ColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(SetItem)(
		/*[in]*/ LPCOLESTR szName,
		/*[in]*/ ColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(SetItem)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE_POINTER(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
