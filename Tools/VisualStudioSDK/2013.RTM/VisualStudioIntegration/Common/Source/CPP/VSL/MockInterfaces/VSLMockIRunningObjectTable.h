/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IRUNNINGOBJECTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IRUNNINGOBJECTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IRunningObjectTableNotImpl :
	public IRunningObjectTable
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRunningObjectTableNotImpl)

public:

	typedef IRunningObjectTable Interface;

	STDMETHOD(Register)(
		/*[in]*/ DWORD /*grfFlags*/,
		/*[in,unique]*/ IUnknown* /*punkObject*/,
		/*[in,unique]*/ IMoniker* /*pmkObjectName*/,
		/*[out]*/ DWORD* /*pdwRegister*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Revoke)(
		/*[in]*/ DWORD /*dwRegister*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsRunning)(
		/*[in,unique]*/ IMoniker* /*pmkObjectName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetObject)(
		/*[in,unique]*/ IMoniker* /*pmkObjectName*/,
		/*[out]*/ IUnknown** /*ppunkObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NoteChangeTime)(
		/*[in]*/ DWORD /*dwRegister*/,
		/*[in]*/ FILETIME* /*pfiletime*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTimeOfLastChange)(
		/*[in,unique]*/ IMoniker* /*pmkObjectName*/,
		/*[out]*/ FILETIME* /*pfiletime*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumRunning)(
		/*[out]*/ IEnumMoniker** /*ppenumMoniker*/)VSL_STDMETHOD_NOTIMPL
};

class IRunningObjectTableMockImpl :
	public IRunningObjectTable,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRunningObjectTableMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRunningObjectTableMockImpl)

	typedef IRunningObjectTable Interface;
	struct RegisterValidValues
	{
		/*[in]*/ DWORD grfFlags;
		/*[in,unique]*/ IUnknown* punkObject;
		/*[in,unique]*/ IMoniker* pmkObjectName;
		/*[out]*/ DWORD* pdwRegister;
		HRESULT retValue;
	};

	STDMETHOD(Register)(
		/*[in]*/ DWORD grfFlags,
		/*[in,unique]*/ IUnknown* punkObject,
		/*[in,unique]*/ IMoniker* pmkObjectName,
		/*[out]*/ DWORD* pdwRegister)
	{
		VSL_DEFINE_MOCK_METHOD(Register)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkObject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkObjectName);

		VSL_SET_VALIDVALUE(pdwRegister);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevokeValidValues
	{
		/*[in]*/ DWORD dwRegister;
		HRESULT retValue;
	};

	STDMETHOD(Revoke)(
		/*[in]*/ DWORD dwRegister)
	{
		VSL_DEFINE_MOCK_METHOD(Revoke)

		VSL_CHECK_VALIDVALUE(dwRegister);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsRunningValidValues
	{
		/*[in,unique]*/ IMoniker* pmkObjectName;
		HRESULT retValue;
	};

	STDMETHOD(IsRunning)(
		/*[in,unique]*/ IMoniker* pmkObjectName)
	{
		VSL_DEFINE_MOCK_METHOD(IsRunning)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkObjectName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetObjectValidValues
	{
		/*[in,unique]*/ IMoniker* pmkObjectName;
		/*[out]*/ IUnknown** ppunkObject;
		HRESULT retValue;
	};

	STDMETHOD(GetObject)(
		/*[in,unique]*/ IMoniker* pmkObjectName,
		/*[out]*/ IUnknown** ppunkObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkObjectName);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct NoteChangeTimeValidValues
	{
		/*[in]*/ DWORD dwRegister;
		/*[in]*/ FILETIME* pfiletime;
		HRESULT retValue;
	};

	STDMETHOD(NoteChangeTime)(
		/*[in]*/ DWORD dwRegister,
		/*[in]*/ FILETIME* pfiletime)
	{
		VSL_DEFINE_MOCK_METHOD(NoteChangeTime)

		VSL_CHECK_VALIDVALUE(dwRegister);

		VSL_CHECK_VALIDVALUE_POINTER(pfiletime);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTimeOfLastChangeValidValues
	{
		/*[in,unique]*/ IMoniker* pmkObjectName;
		/*[out]*/ FILETIME* pfiletime;
		HRESULT retValue;
	};

	STDMETHOD(GetTimeOfLastChange)(
		/*[in,unique]*/ IMoniker* pmkObjectName,
		/*[out]*/ FILETIME* pfiletime)
	{
		VSL_DEFINE_MOCK_METHOD(GetTimeOfLastChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pmkObjectName);

		VSL_SET_VALIDVALUE(pfiletime);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumRunningValidValues
	{
		/*[out]*/ IEnumMoniker** ppenumMoniker;
		HRESULT retValue;
	};

	STDMETHOD(EnumRunning)(
		/*[out]*/ IEnumMoniker** ppenumMoniker)
	{
		VSL_DEFINE_MOCK_METHOD(EnumRunning)

		VSL_SET_VALIDVALUE_INTERFACE(ppenumMoniker);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IRUNNINGOBJECTTABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
