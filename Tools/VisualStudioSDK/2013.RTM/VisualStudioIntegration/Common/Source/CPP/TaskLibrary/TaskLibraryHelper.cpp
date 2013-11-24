/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include "stdafx.h"
#include "vsshell110.h"
#include "TaskLibraryHelper.h"

#define IfFailRet(expr)              { hr = (expr); if(FAILED(hr)) return hr; }
#define IfFalseRet(EXPR, HR, STR)  { if(!(EXPR)) { return HR; } }

namespace {

    // Implementation of IVsTaskBody for native anonymous functions
    // This object uses a free threaded marshaler since the worker method can be called from
    // background threads and it shouldn't marshal back to main thread
    class NativeVsTaskBody : 
        public CComObjectRootEx<CComMultiThreadModel>,
        public IVsTaskBody,
        public ISupportErrorInfo
    {
    public:
        BEGIN_COM_MAP(NativeVsTaskBody)
            COM_INTERFACE_ENTRY(IVsTaskBody)
            COM_INTERFACE_ENTRY(ISupportErrorInfo)
            COM_INTERFACE_ENTRY_AGGREGATE(IID_IMarshal, m_pUnkMarshaler.p)
        END_COM_MAP()

        DECLARE_GET_CONTROLLING_UNKNOWN()

    private:
        VsTaskBody m_WorkerMethod;
        CComPtr<IUnknown> m_pUnkMarshaler;

    public:
        STDMETHOD(DoWork)(
            _In_ IVsTask *pTask, 
            _In_ DWORD dwCount, 
            _In_ IVsTask **pPredecessorTasks, 
            _Out_ VARIANT *pResult)
        {
            // Ensure that implementation is not destroyed during task execution. This can happen
            // in shutdown scenarios when CLR releases all of its RCWs
            CComPtr<IVsTaskBody> spHolder(this);

            // We implement ISupportErrorInfo for this interface, and thereby guarantee that any IErrorInfo returned from GetErrorInfo
            // after this method returns is related to this method.  In case the actual task body does not do SetErrorInfo, set it to
            // null in advance, so that any leftover error info is not mistakenly associated with our call.
            ::SetErrorInfo(0, nullptr);

            if (m_WorkerMethod != nullptr)
            {
                return m_WorkerMethod(pTask, dwCount, pPredecessorTasks, pResult);
            }

            // Fail since object must not have been initialized
            return E_FAIL;
        }

        STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid)
        {
            return riid == IID_IVsTaskBody ? S_OK : S_FALSE;
        }

        HRESULT Init(VsTaskBody workerMethod) 
        {
            IfFalseRet(m_WorkerMethod == nullptr, E_UNEXPECTED, "NativeVsTaskBody already initialized.");
            m_WorkerMethod = workerMethod; 
            return ::CoCreateFreeThreadedMarshaler(GetControllingUnknown(), &m_pUnkMarshaler);
        }
    };

    HRESULT GetTaskSchedulerService(
        _In_ IServiceProvider* pSP,
        _Out_ IVsTaskSchedulerService** ppTaskSchedulerService)
    {
        return pSP->QueryService(__uuidof(SVsTaskSchedulerService), ppTaskSchedulerService);
    }
}

namespace VsTaskLibraryHelper
{
    HRESULT __stdcall CreateAndStartTask(
        _In_ VSTASKRUNCONTEXT context,
        _In_ VSTASKCREATIONOPTIONS options,
        _In_ std::function<HRESULT __stdcall ()> taskBody, 
        _In_ IVsTaskSchedulerService* pTaskSchedulerService,
        _In_opt_z_ LPCWSTR szDiagDescription,
        _Out_ IVsTask **ppTaskBody)
    {
        HRESULT hr = S_OK;

        if (nullptr == ppTaskBody || nullptr == pTaskSchedulerService)
        {
            return E_POINTER;
        }

        VsTaskBody realTaskBody = VsTaskBody_Method
        {
            return taskBody();
        };

        CComPtr<IVsTaskBody> spTaskBody;
        CreateTaskBody(realTaskBody, &spTaskBody);

        IfFailRet(pTaskSchedulerService->CreateTaskEx(
            context, 
            options,
            spTaskBody,
            CComVariant(),
            ppTaskBody));

        IfFailRet((*ppTaskBody)->Start());

		if (szDiagDescription)
		{
			IfFailRet((*ppTaskBody)->put_Description(szDiagDescription));
		}

		return hr;
    }

    // Creates a task body to be passed in when creating a task or continuation from an anonymous function
    HRESULT __stdcall CreateTaskBody(VsTaskBody workerMethod, _Out_ IVsTaskBody **ppTaskBody)
    {
        HRESULT hr = NOERROR;
        if (ppTaskBody == nullptr) return E_POINTER;

        CComObject<NativeVsTaskBody> *pTaskBodyObject;
        IfFailRet(CComObject<NativeVsTaskBody>::CreateInstance(&pTaskBodyObject));
        IfFailRet(pTaskBodyObject->Init(workerMethod));
		return pTaskBodyObject->QueryInterface(IID_PPV_ARGS(ppTaskBody));
    }

    // Helper method to get result of a task as a boolean
    HRESULT __stdcall GetTaskResultAsBool(_In_ IVsTask *pTask, _Out_ bool * pResult)
    {
        HRESULT hr = NOERROR;

        if (pTask == nullptr) return E_INVALIDARG;
        if (pResult == nullptr) return E_POINTER;

        CComVariant varResult;
        IfFailRet(pTask->GetResult(&varResult));

        if (V_VT(&varResult) != VT_BOOL) return E_UNEXPECTED;
        *pResult = V_BOOL(&varResult) != VARIANT_FALSE;
        return hr;
    }
}