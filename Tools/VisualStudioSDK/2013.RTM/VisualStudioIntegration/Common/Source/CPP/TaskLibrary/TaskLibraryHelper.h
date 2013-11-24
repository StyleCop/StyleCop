/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#pragma once

#include <functional>
#include "vsshell110.h"

typedef std::function<HRESULT __stdcall (IVsTask * /* current task */, DWORD dwCount, IVsTask ** /* dependent tasks */, VARIANT * /* result */)> VsTaskBody;

#define VsTaskBody_Params IVsTask *, DWORD, IVsTask **, VARIANT *
#define VsTaskBodyWithResult_Params(ResultName) IVsTask *, DWORD, IVsTask **, VARIANT *ResultName
#define VsTaskBody_Method [=](IVsTask *, DWORD, IVsTask **, VARIANT *) -> HRESULT
#define VsTaskBodyWithResult_Method(ResultName) [=](IVsTask *, DWORD, IVsTask **, VARIANT *ResultName) -> HRESULT

// Helper methods for Visual Studio Task Scheduler service.
// These methods can be used by native clients to create task bodies out of anonymous functions
namespace VsTaskLibraryHelper
{
    // CreateAndStartTask takes a HRESULT function with zero arguments and wraps the 
    // function in a task body, creates a new task to call the body and starts the task.
    HRESULT __stdcall CreateAndStartTask(
        _In_ VSTASKRUNCONTEXT context,
        _In_ VSTASKCREATIONOPTIONS options,
        _In_ std::function<HRESULT __stdcall ()> taskBody,
        _In_ IVsTaskSchedulerService* pTaskSchedulerService,
        _In_opt_z_ LPCWSTR szDiagDescription,
        _Out_ IVsTask **ppTaskBody);

    // Creates a task body to be passed in when creating a task or continuation from an anonymous function
    HRESULT __stdcall CreateTaskBody(_In_ VsTaskBody taskBody, _Out_ IVsTaskBody **ppTaskBody);

    // Helper method to get result of a task as a boolean
    HRESULT __stdcall GetTaskResultAsBool(_In_ IVsTask *pTask, _Out_ bool *pResult);
}