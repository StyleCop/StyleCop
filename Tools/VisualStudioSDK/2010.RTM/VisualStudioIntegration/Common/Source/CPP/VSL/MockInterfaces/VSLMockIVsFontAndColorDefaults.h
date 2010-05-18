/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORDEFAULTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORDEFAULTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorDefaultsNotImpl :
	public IVsFontAndColorDefaults
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorDefaultsNotImpl)

public:

	typedef IVsFontAndColorDefaults Interface;

	STDMETHOD(GetFlags)(
		/*[out]*/ FONTCOLORFLAGS* /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriority)(
		/*[out]*/ FCPRIORITY* /*pPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategoryName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseCategory)(
		/*[out]*/ GUID* /*pguidBase*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFont)(
		/*[out]*/ FontInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemCount)(
		/*[out]*/ LONG* /*pcItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItem)(
		/*[in]*/ LONG /*iItem*/,
		/*[out]*/ AllColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemByName)(
		/*[in]*/ LPCOLESTR /*szItem*/,
		/*[out]*/ AllColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorDefaultsMockImpl :
	public IVsFontAndColorDefaults,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorDefaultsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorDefaultsMockImpl)

	typedef IVsFontAndColorDefaults Interface;
	struct GetFlagsValidValues
	{
		/*[out]*/ FONTCOLORFLAGS* dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetFlags)(
		/*[out]*/ FONTCOLORFLAGS* dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetFlags)

		VSL_SET_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPriorityValidValues
	{
		/*[out]*/ FCPRIORITY* pPriority;
		HRESULT retValue;
	};

	STDMETHOD(GetPriority)(
		/*[out]*/ FCPRIORITY* pPriority)
	{
		VSL_DEFINE_MOCK_METHOD(GetPriority)

		VSL_SET_VALIDVALUE(pPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetCategoryName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategoryName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseCategoryValidValues
	{
		/*[out]*/ GUID* pguidBase;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseCategory)(
		/*[out]*/ GUID* pguidBase)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseCategory)

		VSL_SET_VALIDVALUE(pguidBase);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFontValidValues
	{
		/*[out]*/ FontInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetFont)(
		/*[out]*/ FontInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetFont)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemCountValidValues
	{
		/*[out]*/ LONG* pcItems;
		HRESULT retValue;
	};

	STDMETHOD(GetItemCount)(
		/*[out]*/ LONG* pcItems)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemCount)

		VSL_SET_VALIDVALUE(pcItems);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemValidValues
	{
		/*[in]*/ LONG iItem;
		/*[out]*/ AllColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetItem)(
		/*[in]*/ LONG iItem,
		/*[out]*/ AllColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetItem)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemByNameValidValues
	{
		/*[in]*/ LPCOLESTR szItem;
		/*[out]*/ AllColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetItemByName)(
		/*[in]*/ LPCOLESTR szItem,
		/*[out]*/ AllColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemByName)

		VSL_CHECK_VALIDVALUE_STRINGW(szItem);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORDEFAULTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
