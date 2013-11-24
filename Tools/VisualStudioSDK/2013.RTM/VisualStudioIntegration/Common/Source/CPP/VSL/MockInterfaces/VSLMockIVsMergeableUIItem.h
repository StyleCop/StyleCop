/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMERGEABLEUIITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMERGEABLEUIITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMergeableUIItemNotImpl :
	public IVsMergeableUIItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMergeableUIItemNotImpl)

public:

	typedef IVsMergeableUIItem Interface;

	STDMETHOD(GetCanonicalName)(
		/*[out]*/ BSTR* /*pbstrNonLocalizeName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* /*pbstrDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMergingPriority)(
		/*[out]*/ long* /*piMergingPriority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pbstrDesc*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMergeableUIItemMockImpl :
	public IVsMergeableUIItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMergeableUIItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMergeableUIItemMockImpl)

	typedef IVsMergeableUIItem Interface;
	struct GetCanonicalNameValidValues
	{
		/*[out]*/ BSTR* pbstrNonLocalizeName;
		HRESULT retValue;
	};

	STDMETHOD(GetCanonicalName)(
		/*[out]*/ BSTR* pbstrNonLocalizeName)
	{
		VSL_DEFINE_MOCK_METHOD(GetCanonicalName)

		VSL_SET_VALIDVALUE_BSTR(pbstrNonLocalizeName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* pbstrDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMergingPriorityValidValues
	{
		/*[out]*/ long* piMergingPriority;
		HRESULT retValue;
	};

	STDMETHOD(GetMergingPriority)(
		/*[out]*/ long* piMergingPriority)
	{
		VSL_DEFINE_MOCK_METHOD(GetMergingPriority)

		VSL_SET_VALIDVALUE(piMergingPriority);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrDesc;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pbstrDesc)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrDesc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMERGEABLEUIITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
