/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYDROPDATASOURCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYDROPDATASOURCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyDropDataSource2NotImpl :
	public IVsHierarchyDropDataSource2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataSource2NotImpl)

public:

	typedef IVsHierarchyDropDataSource2 Interface;

	STDMETHOD(OnBeforeDropNotify)(
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*dwEffect*/,
		/*[out,retval]*/ BOOL* /*pfCancelDrop*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDropInfo)(
		/*[out]*/ DWORD* /*pdwOKEffects*/,
		/*[out]*/ IDataObject** /*ppDataObject*/,
		/*[out]*/ IDropSource** /*ppDropSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDropNotify)(
		/*[in]*/ BOOL /*fDropped*/,
		/*[in]*/ DWORD /*dwEffects*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyDropDataSource2MockImpl :
	public IVsHierarchyDropDataSource2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataSource2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyDropDataSource2MockImpl)

	typedef IVsHierarchyDropDataSource2 Interface;
	struct OnBeforeDropNotifyValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD dwEffect;
		/*[out,retval]*/ BOOL* pfCancelDrop;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeDropNotify)(
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD dwEffect,
		/*[out,retval]*/ BOOL* pfCancelDrop)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeDropNotify)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(dwEffect);

		VSL_SET_VALIDVALUE(pfCancelDrop);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // IVSHIERARCHYDROPDATASOURCE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
