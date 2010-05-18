/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTHREADPOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTHREADPOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsThreadPoolNotImpl :
	public IVsThreadPool
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsThreadPoolNotImpl)

public:

	typedef IVsThreadPool Interface;

	STDMETHOD(ScheduleTask)(
		/*[in]*/ DWORD_PTR /*pTaskProc*/,
		/*[in]*/ DWORD_PTR /*pvParam*/,
		/*[in]*/ VSBACKGROUNDTASKPRIORITY /*priority*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ScheduleWaitableTask)(
		/*[in]*/ DWORD_PTR /*hWait*/,
		/*[in]*/ DWORD_PTR /*pTaskProc*/,
		/*[in]*/ DWORD_PTR /*pvParam*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnscheduleWaitableTask)(
		/*[in]*/ DWORD_PTR /*hWait*/)VSL_STDMETHOD_NOTIMPL
};

class IVsThreadPoolMockImpl :
	public IVsThreadPool,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsThreadPoolMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsThreadPoolMockImpl)

	typedef IVsThreadPool Interface;
	struct ScheduleTaskValidValues
	{
		/*[in]*/ DWORD_PTR pTaskProc;
		/*[in]*/ DWORD_PTR pvParam;
		/*[in]*/ VSBACKGROUNDTASKPRIORITY priority;
		HRESULT retValue;
	};

	STDMETHOD(ScheduleTask)(
		/*[in]*/ DWORD_PTR pTaskProc,
		/*[in]*/ DWORD_PTR pvParam,
		/*[in]*/ VSBACKGROUNDTASKPRIORITY priority)
	{
		VSL_DEFINE_MOCK_METHOD(ScheduleTask)

		VSL_CHECK_VALIDVALUE(pTaskProc);

		VSL_CHECK_VALIDVALUE(pvParam);

		VSL_CHECK_VALIDVALUE(priority);

		VSL_RETURN_VALIDVALUES();
	}
	struct ScheduleWaitableTaskValidValues
	{
		/*[in]*/ DWORD_PTR hWait;
		/*[in]*/ DWORD_PTR pTaskProc;
		/*[in]*/ DWORD_PTR pvParam;
		HRESULT retValue;
	};

	STDMETHOD(ScheduleWaitableTask)(
		/*[in]*/ DWORD_PTR hWait,
		/*[in]*/ DWORD_PTR pTaskProc,
		/*[in]*/ DWORD_PTR pvParam)
	{
		VSL_DEFINE_MOCK_METHOD(ScheduleWaitableTask)

		VSL_CHECK_VALIDVALUE(hWait);

		VSL_CHECK_VALIDVALUE(pTaskProc);

		VSL_CHECK_VALIDVALUE(pvParam);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnscheduleWaitableTaskValidValues
	{
		/*[in]*/ DWORD_PTR hWait;
		HRESULT retValue;
	};

	STDMETHOD(UnscheduleWaitableTask)(
		/*[in]*/ DWORD_PTR hWait)
	{
		VSL_DEFINE_MOCK_METHOD(UnscheduleWaitableTask)

		VSL_CHECK_VALIDVALUE(hWait);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTHREADPOOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
