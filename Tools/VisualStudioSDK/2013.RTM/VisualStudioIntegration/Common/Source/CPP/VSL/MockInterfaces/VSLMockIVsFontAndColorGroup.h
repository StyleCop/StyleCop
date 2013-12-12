/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORGROUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORGROUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorGroupNotImpl :
	public IVsFontAndColorGroup
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorGroupNotImpl)

public:

	typedef IVsFontAndColorGroup Interface;

	STDMETHOD(GetCount)(
		/*[out]*/ long* /*pnCategories*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriority)(
		/*[out]*/ FCPRIORITY* /*pPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGroupName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCategory)(
		/*[in]*/ int /*iCategory*/,
		/*[out]*/ GUID* /*pguidCategory*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorGroupMockImpl :
	public IVsFontAndColorGroup,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorGroupMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorGroupMockImpl)

	typedef IVsFontAndColorGroup Interface;
	struct GetCountValidValues
	{
		/*[out]*/ long* pnCategories;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ long* pnCategories)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pnCategories);

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
	struct GetGroupNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetGroupName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetGroupName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCategoryValidValues
	{
		/*[in]*/ int iCategory;
		/*[out]*/ GUID* pguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(GetCategory)(
		/*[in]*/ int iCategory,
		/*[out]*/ GUID* pguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(GetCategory)

		VSL_CHECK_VALIDVALUE(iCategory);

		VSL_SET_VALIDVALUE(pguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORGROUP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
