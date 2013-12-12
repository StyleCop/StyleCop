/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IACTIVEDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IACTIVEDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "designer.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IActiveDesignerNotImpl :
	public IActiveDesigner
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActiveDesignerNotImpl)

public:

	typedef IActiveDesigner Interface;

	STDMETHOD(GetRuntimeClassID)(
		/*[out]*/ CLSID* /*pclsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRuntimeMiscStatusFlags)(
		/*[out]*/ DWORD* /*pdwMiscFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryPersistenceInterface)(
		/*[in]*/ REFIID /*riidPersist*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveRuntimeState)(
		/*[in]*/ REFIID /*riidPersist*/,
		/*[in]*/ REFIID /*riidObjStgMed*/,
		/*[in]*/ void* /*pObjStgMed*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtensibilityObject)(
		/*[out]*/ IDispatch** /*ppvObjOut*/)VSL_STDMETHOD_NOTIMPL
};

class IActiveDesignerMockImpl :
	public IActiveDesigner,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActiveDesignerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IActiveDesignerMockImpl)

	typedef IActiveDesigner Interface;
	struct GetRuntimeClassIDValidValues
	{
		/*[out]*/ CLSID* pclsid;
		HRESULT retValue;
	};

	STDMETHOD(GetRuntimeClassID)(
		/*[out]*/ CLSID* pclsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetRuntimeClassID)

		VSL_SET_VALIDVALUE(pclsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRuntimeMiscStatusFlagsValidValues
	{
		/*[out]*/ DWORD* pdwMiscFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetRuntimeMiscStatusFlags)(
		/*[out]*/ DWORD* pdwMiscFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetRuntimeMiscStatusFlags)

		VSL_SET_VALIDVALUE(pdwMiscFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryPersistenceInterfaceValidValues
	{
		/*[in]*/ REFIID riidPersist;
		HRESULT retValue;
	};

	STDMETHOD(QueryPersistenceInterface)(
		/*[in]*/ REFIID riidPersist)
	{
		VSL_DEFINE_MOCK_METHOD(QueryPersistenceInterface)

		VSL_CHECK_VALIDVALUE(riidPersist);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveRuntimeStateValidValues
	{
		/*[in]*/ REFIID riidPersist;
		/*[in]*/ REFIID riidObjStgMed;
		/*[in]*/ void* pObjStgMed;
		HRESULT retValue;
		size_t pObjStgMed_size_in_bytes;
	};

	STDMETHOD(SaveRuntimeState)(
		/*[in]*/ REFIID riidPersist,
		/*[in]*/ REFIID riidObjStgMed,
		/*[in]*/ void* pObjStgMed)
	{
		VSL_DEFINE_MOCK_METHOD(SaveRuntimeState)

		VSL_CHECK_VALIDVALUE(riidPersist);

		VSL_CHECK_VALIDVALUE(riidObjStgMed);

		VSL_CHECK_VALIDVALUE_PVOID(pObjStgMed);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtensibilityObjectValidValues
	{
		/*[out]*/ IDispatch** ppvObjOut;
		HRESULT retValue;
	};

	STDMETHOD(GetExtensibilityObject)(
		/*[out]*/ IDispatch** ppvObjOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtensibilityObject)

		VSL_SET_VALIDVALUE_INTERFACE(ppvObjOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IACTIVEDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
