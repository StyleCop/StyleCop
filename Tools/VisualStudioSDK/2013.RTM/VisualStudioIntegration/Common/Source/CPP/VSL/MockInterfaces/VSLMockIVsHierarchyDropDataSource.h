/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYDROPDATASOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYDROPDATASOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyDropDataSourceNotImpl :
	public IVsHierarchyDropDataSource
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataSourceNotImpl)

public:

	typedef IVsHierarchyDropDataSource Interface;

	STDMETHOD(GetDropInfo)(
		/*[out]*/ DWORD* /*pdwOKEffects*/,
		/*[out]*/ IDataObject** /*ppDataObject*/,
		/*[out]*/ IDropSource** /*ppDropSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDropNotify)(
		/*[in]*/ BOOL /*fDropped*/,
		/*[in]*/ DWORD /*dwEffects*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyDropDataSourceMockImpl :
	public IVsHierarchyDropDataSource,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataSourceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyDropDataSourceMockImpl)

	typedef IVsHierarchyDropDataSource Interface;
	struct GetDropInfoValidValues
	{
		/*[out]*/ DWORD* pdwOKEffects;
		/*[out]*/ IDataObject** ppDataObject;
		/*[out]*/ IDropSource** ppDropSource;
		HRESULT retValue;
	};

	STDMETHOD(GetDropInfo)(
		/*[out]*/ DWORD* pdwOKEffects,
		/*[out]*/ IDataObject** ppDataObject,
		/*[out]*/ IDropSource** ppDropSource)
	{
		VSL_DEFINE_MOCK_METHOD(GetDropInfo)

		VSL_SET_VALIDVALUE(pdwOKEffects);

		VSL_SET_VALIDVALUE_INTERFACE(ppDataObject);

		VSL_SET_VALIDVALUE_INTERFACE(ppDropSource);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDropNotifyValidValues
	{
		/*[in]*/ BOOL fDropped;
		/*[in]*/ DWORD dwEffects;
		HRESULT retValue;
	};

	STDMETHOD(OnDropNotify)(
		/*[in]*/ BOOL fDropped,
		/*[in]*/ DWORD dwEffects)
	{
		VSL_DEFINE_MOCK_METHOD(OnDropNotify)

		VSL_CHECK_VALIDVALUE(fDropped);

		VSL_CHECK_VALIDVALUE(dwEffects);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYDROPDATASOURCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
