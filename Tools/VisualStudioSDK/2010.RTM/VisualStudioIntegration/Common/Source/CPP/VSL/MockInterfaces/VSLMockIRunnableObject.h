/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IRUNNABLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IRUNNABLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IRunnableObjectNotImpl :
	public IRunnableObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRunnableObjectNotImpl)

public:

	typedef IRunnableObject Interface;

	STDMETHOD(GetRunningClass)(
		/*[out]*/ LPCLSID /*lpClsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Run)(
		/*[in]*/ LPBINDCTX /*pbc*/)VSL_STDMETHOD_NOTIMPL

	virtual BOOL STDMETHODCALLTYPE IsRunning(){ return BOOL(); }

	STDMETHOD(LockRunning)(
		/*[in]*/ BOOL /*fLock*/,
		/*[in]*/ BOOL /*fLastUnlockCloses*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContainedObject)(
		/*[in]*/ BOOL /*fContained*/)VSL_STDMETHOD_NOTIMPL
};

class IRunnableObjectMockImpl :
	public IRunnableObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRunnableObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRunnableObjectMockImpl)

	typedef IRunnableObject Interface;
	struct GetRunningClassValidValues
	{
		/*[out]*/ LPCLSID lpClsid;
		HRESULT retValue;
	};

	STDMETHOD(GetRunningClass)(
		/*[out]*/ LPCLSID lpClsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetRunningClass)

		VSL_SET_VALIDVALUE(lpClsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RunValidValues
	{
		/*[in]*/ LPBINDCTX pbc;
		HRESULT retValue;
	};

	STDMETHOD(Run)(
		/*[in]*/ LPBINDCTX pbc)
	{
		VSL_DEFINE_MOCK_METHOD(Run)

		VSL_CHECK_VALIDVALUE(pbc);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsRunningValidValues
	{
		BOOL retValue;
	};

	virtual BOOL _stdcall IsRunning()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsRunning)

		VSL_RETURN_VALIDVALUES();
	}
	struct LockRunningValidValues
	{
		/*[in]*/ BOOL fLock;
		/*[in]*/ BOOL fLastUnlockCloses;
		HRESULT retValue;
	};

	STDMETHOD(LockRunning)(
		/*[in]*/ BOOL fLock,
		/*[in]*/ BOOL fLastUnlockCloses)
	{
		VSL_DEFINE_MOCK_METHOD(LockRunning)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_CHECK_VALIDVALUE(fLastUnlockCloses);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetContainedObjectValidValues
	{
		/*[in]*/ BOOL fContained;
		HRESULT retValue;
	};

	STDMETHOD(SetContainedObject)(
		/*[in]*/ BOOL fContained)
	{
		VSL_DEFINE_MOCK_METHOD(SetContainedObject)

		VSL_CHECK_VALIDVALUE(fContained);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IRUNNABLEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
