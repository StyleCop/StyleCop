/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskProviderNotImpl :
	public IVsTaskProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskProviderNotImpl)

public:

	typedef IVsTaskProvider Interface;

	STDMETHOD(EnumTaskItems)(
		/*[out]*/ IVsEnumTaskItems** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ImageList)(
		/*[out,retval]*/ HANDLE* /*phImageList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SubcategoryList)(
		/*[in]*/ ULONG /*cbstr*/,
		/*[out,size_is(cbstr)]*/ BSTR[] /*rgbstr*/,
		/*[out]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ReRegistrationKey)(
		/*[out]*/ BSTR* /*pbstrKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnTaskListFinalRelease)(
		/*[in]*/ IVsTaskList* /*pTaskList*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTaskProviderMockImpl :
	public IVsTaskProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskProviderMockImpl)

	typedef IVsTaskProvider Interface;
	struct EnumTaskItemsValidValues
	{
		/*[out]*/ IVsEnumTaskItems** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumTaskItems)(
		/*[out]*/ IVsEnumTaskItems** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumTaskItems)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ImageListValidValues
	{
		/*[out,retval]*/ HANDLE* phImageList;
		HRESULT retValue;
	};

	STDMETHOD(get_ImageList)(
		/*[out,retval]*/ HANDLE* phImageList)
	{
		VSL_DEFINE_MOCK_METHOD(get_ImageList)

		VSL_SET_VALIDVALUE(phImageList);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SubcategoryListValidValues
	{
		/*[in]*/ ULONG cbstr;
		/*[out,size_is(cbstr)]*/ BSTR* rgbstr;
		/*[out]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(get_SubcategoryList)(
		/*[in]*/ ULONG cbstr,
		/*[out,size_is(cbstr)]*/ BSTR rgbstr[],
		/*[out]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(get_SubcategoryList)

		VSL_CHECK_VALIDVALUE(cbstr);

		VSL_SET_VALIDVALUE_MEMCPY(rgbstr, cbstr*sizeof(rgbstr[0]), validValues.cbstr*sizeof(validValues.rgbstr[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ReRegistrationKeyValidValues
	{
		/*[out]*/ BSTR* pbstrKey;
		HRESULT retValue;
	};

	STDMETHOD(get_ReRegistrationKey)(
		/*[out]*/ BSTR* pbstrKey)
	{
		VSL_DEFINE_MOCK_METHOD(get_ReRegistrationKey)

		VSL_SET_VALIDVALUE_BSTR(pbstrKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnTaskListFinalReleaseValidValues
	{
		/*[in]*/ IVsTaskList* pTaskList;
		HRESULT retValue;
	};

	STDMETHOD(OnTaskListFinalRelease)(
		/*[in]*/ IVsTaskList* pTaskList)
	{
		VSL_DEFINE_MOCK_METHOD(OnTaskListFinalRelease)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTaskList);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
