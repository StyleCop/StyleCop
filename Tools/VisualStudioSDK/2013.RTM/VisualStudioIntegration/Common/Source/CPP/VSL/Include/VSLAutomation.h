/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLAUTOMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLAUTOMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLErrorHandlers.h>
#include <VSLExceptionHandlers.h>

// VS Platform includes
#include <vbapkg.h> // for IVsMacroRecorder

namespace VSL
{

template <class Derived_T>
class IExtensibleObjectImpl :
	public IExtensibleObject
{

VSL_DECLARE_NOT_COPYABLE(IExtensibleObjectImpl)

public:

	STDMETHOD(GetAutomationObject)(_In_z_ BSTR bstrName, _In_ IExtensibleObjectSite* pParent, _Deref_out_ IDispatch** ppDisp)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppDisp, E_INVALIDARG);

		*ppDisp = NULL;

		Derived_T& rDerived = *(static_cast<Derived_T*>(this));
		*ppDisp = rDerived.GetNamedAutomationObject(bstrName);
		VSL_ASSERT(NULL != *ppDisp);
#if defined(_DEBUG) || defined(DEBUG)
		ATL::CComPtr<IUnknown> spIUnknown(this);
		VSL_ASSERT(spIUnknown.IsEqualObject(ppDisp));
#endif // _DEBUG

		if(NULL != pParent)
		{
			// Do not AddRef m_pParent, as doing so will create a circular dependency
			m_pParent = pParent;
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

protected:

	IExtensibleObjectImpl():
		 m_pParent(NULL)
	{
	}

	~IExtensibleObjectImpl()
	{
		if(NULL != m_pParent)
		{
			// Pass the IUnknown for identity, in case a comparison is made in NotifyDelete without
			// QI'ing for the IUnknown for identity first
			HRESULT hr = m_pParent->NotifyDelete(static_cast<Derived_T*>(this)->_GetRawUnknown());
			VSL_ASSERT(SUCCEEDED(hr));
			(hr);
			// Do not Release m_pParent, since it was not AddRef'ed above
			m_pParent = NULL;
		}
	}

private:

	IExtensibleObjectSite* m_pParent;
};

template <const GUID* pguidEmitter_T, class Macro_T, Macro_T NoLastMacroRecorded_T>
class VsMacroRecorder
{

VSL_DECLARE_NOT_COPYABLE(VsMacroRecorder)

public:

	VsMacroRecorder():
		m_spIVsMacroRecorder(),
		m_iLastMacroRecorded(NoLastMacroRecorded_T),
		m_iTimesPreviouslyRecorded(0)
	{
	}

	// Compiler generated destructor is fine

    void Reset()    
    { 
        m_iLastMacroRecorded = NoLastMacroRecorded_T;
        m_iTimesPreviouslyRecorded = 0;
    }

	void Stop()
	{
		Reset();
		m_spIVsMacroRecorder.Release();
	}

	bool IsLastRecordedMacro(Macro_T iMacro)
	{
		return (iMacro == m_iLastMacroRecorded && ObjectIsLastMacroEmitter()) ? true : false;
	}

	template <class VsSiteCache_T>
	bool IsRecording(VsSiteCache_T &rVsSiteCache)
	{
		// If the property can not be retreived it is assumeed no macro is being recorded.
		VSRECORDSTATE recordState = VSRECORDSTATE_OFF;

		// Retrieve the macro recording state.
		ATL::CComVariant var;
		if(SUCCEEDED((rVsSiteCache.GetCachedService<IVsShell, SID_SVsShell>()->GetProperty(VSSPROPID_RecordState, &var))))
		{
			recordState = static_cast<VSRECORDSTATE>(var.lVal);
		}
		
		// If there is a change in the record state to OFF or ON we must either obtain
		// or release the macro recorder. 
		if(recordState == VSRECORDSTATE_ON && !m_spIVsMacroRecorder)
		{
			// If this QueryService fails we no macro recording
			HRESULT hr = rVsSiteCache.QueryService(SID_SVsMacroRecorder, &m_spIVsMacroRecorder);
			VSL_ASSERT(SUCCEEDED(hr));
			if(FAILED(hr))
			{
				// Ensure value is NULL on failure
				m_spIVsMacroRecorder = NULL;
			}
		}
		else if(recordState == VSRECORDSTATE_OFF && !!m_spIVsMacroRecorder)
		{
			// If the macro recording state has been switched off then we can release
			// the service. Note that if the state has become paused we take no action.
			Stop();
		}
		return !!m_spIVsMacroRecorder;
	}

	void RecordLine(LPCOLESTR szLine)
	{
		VSL_CHECKHRESULT(m_spIVsMacroRecorder->RecordLine(szLine, *pguidEmitter_T));
		Reset();
	}

	bool RecordBatchedLine(Macro_T iMacroRecorded, ATL::CStringW strLine, int iMaxLineLength = 0)
	{
		if(iMaxLineLength > 0 && strLine.GetLength() >= iMaxLineLength)
		{
			// Reset the state after recording the line, so it will not be appended to further
			RecordLine(strLine);
			// Notify the caller that the this line will not be appended to further
			return true;
		}

		if(IsLastRecordedMacro(iMacroRecorded))
		{
			VSL_CHECKHRESULT(m_spIVsMacroRecorder->ReplaceLine(strLine, *pguidEmitter_T));
			// m_iLastMacroRecorded can stay the same
			++m_iTimesPreviouslyRecorded;
		}
		else
		{
			VSL_CHECKHRESULT(m_spIVsMacroRecorder->RecordLine(strLine, *pguidEmitter_T));
			m_iLastMacroRecorded = iMacroRecorded;
			m_iTimesPreviouslyRecorded = 1;
		}

		return false;
	}

	unsigned int GetTimesPreviouslyRecorded(Macro_T iMacro)
	{
		return IsLastRecordedMacro(iMacro) ? m_iTimesPreviouslyRecorded : 0;
	}

private:

    // This function determines if the last line sent to the macro recorder was
    // sent from this emitter. Note it is not valid to call this function if
    // macro recording is switched off.
    BOOL ObjectIsLastMacroEmitter()
    {
        GUID guid;
        VSL_CHECKHRESULT(m_spIVsMacroRecorder->GetLastEmitterId(&guid));
		return ::IsEqualGUID(guid, *pguidEmitter_T);
    }

	ATL::CComPtr<IVsMacroRecorder> m_spIVsMacroRecorder;
	Macro_T m_iLastMacroRecorded;
	unsigned int m_iTimesPreviouslyRecorded;
};

} // namespace VSL

#endif // VSLAUTOMATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
