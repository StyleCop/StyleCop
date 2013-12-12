/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDATAADVISEHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDATAADVISEHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDataAdviseHolderNotImpl :
	public IDataAdviseHolder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDataAdviseHolderNotImpl)

public:

	typedef IDataAdviseHolder Interface;

	STDMETHOD(Advise)(
		/*[in,unique]*/ IDataObject* /*pDataObject*/,
		/*[in,unique]*/ FORMATETC* /*pFetc*/,
		/*[in]*/ DWORD /*advf*/,
		/*[in,unique]*/ IAdviseSink* /*pAdvise*/,
		/*[out]*/ DWORD* /*pdwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD /*dwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumAdvise)(
		/*[out]*/ IEnumSTATDATA** /*ppenumAdvise*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SendOnDataChange)(
		/*[in,unique]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ DWORD /*advf*/)VSL_STDMETHOD_NOTIMPL
};

class IDataAdviseHolderMockImpl :
	public IDataAdviseHolder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDataAdviseHolderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDataAdviseHolderMockImpl)

	typedef IDataAdviseHolder Interface;
	struct AdviseValidValues
	{
		/*[in,unique]*/ IDataObject* pDataObject;
		/*[in,unique]*/ FORMATETC* pFetc;
		/*[in]*/ DWORD advf;
		/*[in,unique]*/ IAdviseSink* pAdvise;
		/*[out]*/ DWORD* pdwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Advise)(
		/*[in,unique]*/ IDataObject* pDataObject,
		/*[in,unique]*/ FORMATETC* pFetc,
		/*[in]*/ DWORD advf,
		/*[in,unique]*/ IAdviseSink* pAdvise,
		/*[out]*/ DWORD* pdwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Advise)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE_POINTER(pFetc);

		VSL_CHECK_VALIDVALUE(advf);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAdvise);

		VSL_SET_VALIDVALUE(pdwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseValidValues
	{
		/*[in]*/ DWORD dwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Unadvise)(
		/*[in]*/ DWORD dwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Unadvise)

		VSL_CHECK_VALIDVALUE(dwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumAdviseValidValues
	{
		/*[out]*/ IEnumSTATDATA** ppenumAdvise;
		HRESULT retValue;
	};

	STDMETHOD(EnumAdvise)(
		/*[out]*/ IEnumSTATDATA** ppenumAdvise)
	{
		VSL_DEFINE_MOCK_METHOD(EnumAdvise)

		VSL_SET_VALIDVALUE_INTERFACE(ppenumAdvise);

		VSL_RETURN_VALIDVALUES();
	}
	struct SendOnDataChangeValidValues
	{
		/*[in,unique]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ DWORD advf;
		HRESULT retValue;
	};

	STDMETHOD(SendOnDataChange)(
		/*[in,unique]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ DWORD advf)
	{
		VSL_DEFINE_MOCK_METHOD(SendOnDataChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(advf);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDATAADVISEHOLDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
