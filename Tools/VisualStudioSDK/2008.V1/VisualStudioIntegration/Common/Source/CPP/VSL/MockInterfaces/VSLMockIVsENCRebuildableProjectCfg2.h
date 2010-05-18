/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENCREBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENCREBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "encbuild.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsENCRebuildableProjectCfg2NotImpl :
	public IVsENCRebuildableProjectCfg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsENCRebuildableProjectCfg2NotImpl)

public:

	typedef IVsENCRebuildableProjectCfg2 Interface;

	STDMETHOD(StartDebuggingPE)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnterBreakStateOnPE)(
		/*[in]*/ ENC_BREAKSTATE_REASON /*encBreakReason*/,
		/*[in]*/ ENC_ACTIVE_STATEMENT* /*pActiveStatements*/,
		/*[in]*/ UINT32 /*cActiveStatements*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BuildForEnc)(
		/*[in]*/ IUnknown* /*pUpdatePE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExitBreakStateOnPE)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopDebuggingPE)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetENCBuildState)(
		/*[out]*/ ENC_BUILD_STATE* /*pENCBuildState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentActiveStatementPosition)(
		/*[in]*/ UINT32 /*id*/,
		/*[out]*/ TextSpan* /*ptsNewPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPEidentity)(
		/*[out]*/ GUID* /*pMVID*/,
		/*[out]*/ BSTR* /*pbstrPEName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExceptionSpanCount)(
		/*[out]*/ UINT32* /*pcExceptionSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExceptionSpans)(
		/*[in]*/ UINT32 /*celt*/,
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ ENC_EXCEPTION_SPAN* /*rgelt*/,
		/*[in,out]*/ ULONG* /*pceltFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentExceptionSpanPosition)(
		/*[in]*/ UINT32 /*id*/,
		/*[out]*/ TextSpan* /*ptsNewPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncApplySucceeded)(
		/*[in]*/ HRESULT /*hrApplyResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPEBuildTimeStamp)(
		/*[in,out]*/ FILETIME* /*pTimeStamp*/)VSL_STDMETHOD_NOTIMPL
};

class IVsENCRebuildableProjectCfg2MockImpl :
	public IVsENCRebuildableProjectCfg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsENCRebuildableProjectCfg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsENCRebuildableProjectCfg2MockImpl)

	typedef IVsENCRebuildableProjectCfg2 Interface;
	struct StartDebuggingPEValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StartDebuggingPE)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StartDebuggingPE)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnterBreakStateOnPEValidValues
	{
		/*[in]*/ ENC_BREAKSTATE_REASON encBreakReason;
		/*[in]*/ ENC_ACTIVE_STATEMENT* pActiveStatements;
		/*[in]*/ UINT32 cActiveStatements;
		HRESULT retValue;
	};

	STDMETHOD(EnterBreakStateOnPE)(
		/*[in]*/ ENC_BREAKSTATE_REASON encBreakReason,
		/*[in]*/ ENC_ACTIVE_STATEMENT* pActiveStatements,
		/*[in]*/ UINT32 cActiveStatements)
	{
		VSL_DEFINE_MOCK_METHOD(EnterBreakStateOnPE)

		VSL_CHECK_VALIDVALUE(encBreakReason);

		VSL_CHECK_VALIDVALUE_POINTER(pActiveStatements);

		VSL_CHECK_VALIDVALUE(cActiveStatements);

		VSL_RETURN_VALIDVALUES();
	}
	struct BuildForEncValidValues
	{
		/*[in]*/ IUnknown* pUpdatePE;
		HRESULT retValue;
	};

	STDMETHOD(BuildForEnc)(
		/*[in]*/ IUnknown* pUpdatePE)
	{
		VSL_DEFINE_MOCK_METHOD(BuildForEnc)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUpdatePE);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExitBreakStateOnPEValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ExitBreakStateOnPE)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ExitBreakStateOnPE)

		VSL_RETURN_VALIDVALUES();
	}
	struct StopDebuggingPEValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StopDebuggingPE)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StopDebuggingPE)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetENCBuildStateValidValues
	{
		/*[out]*/ ENC_BUILD_STATE* pENCBuildState;
		HRESULT retValue;
	};

	STDMETHOD(GetENCBuildState)(
		/*[out]*/ ENC_BUILD_STATE* pENCBuildState)
	{
		VSL_DEFINE_MOCK_METHOD(GetENCBuildState)

		VSL_SET_VALIDVALUE(pENCBuildState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentActiveStatementPositionValidValues
	{
		/*[in]*/ UINT32 id;
		/*[out]*/ TextSpan* ptsNewPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentActiveStatementPosition)(
		/*[in]*/ UINT32 id,
		/*[out]*/ TextSpan* ptsNewPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentActiveStatementPosition)

		VSL_CHECK_VALIDVALUE(id);

		VSL_SET_VALIDVALUE(ptsNewPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPEidentityValidValues
	{
		/*[out]*/ GUID* pMVID;
		/*[out]*/ BSTR* pbstrPEName;
		HRESULT retValue;
	};

	STDMETHOD(GetPEidentity)(
		/*[out]*/ GUID* pMVID,
		/*[out]*/ BSTR* pbstrPEName)
	{
		VSL_DEFINE_MOCK_METHOD(GetPEidentity)

		VSL_SET_VALIDVALUE(pMVID);

		VSL_SET_VALIDVALUE_BSTR(pbstrPEName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExceptionSpanCountValidValues
	{
		/*[out]*/ UINT32* pcExceptionSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionSpanCount)(
		/*[out]*/ UINT32* pcExceptionSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionSpanCount)

		VSL_SET_VALIDVALUE(pcExceptionSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExceptionSpansValidValues
	{
		/*[in]*/ UINT32 celt;
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ ENC_EXCEPTION_SPAN* rgelt;
		/*[in,out]*/ ULONG* pceltFetched;
		HRESULT retValue;
	};

	STDMETHOD(GetExceptionSpans)(
		/*[in]*/ UINT32 celt,
		/*[out,size_is(celt),length_is(*pceltFetched)]*/ ENC_EXCEPTION_SPAN* rgelt,
		/*[in,out]*/ ULONG* pceltFetched)
	{
		VSL_DEFINE_MOCK_METHOD(GetExceptionSpans)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgelt, celt*sizeof(rgelt[0]), *(validValues.pceltFetched)*sizeof(validValues.rgelt[0]));

		VSL_SET_VALIDVALUE(pceltFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentExceptionSpanPositionValidValues
	{
		/*[in]*/ UINT32 id;
		/*[out]*/ TextSpan* ptsNewPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentExceptionSpanPosition)(
		/*[in]*/ UINT32 id,
		/*[out]*/ TextSpan* ptsNewPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentExceptionSpanPosition)

		VSL_CHECK_VALIDVALUE(id);

		VSL_SET_VALIDVALUE(ptsNewPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncApplySucceededValidValues
	{
		/*[in]*/ HRESULT hrApplyResult;
		HRESULT retValue;
	};

	STDMETHOD(EncApplySucceeded)(
		/*[in]*/ HRESULT hrApplyResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncApplySucceeded)

		VSL_CHECK_VALIDVALUE(hrApplyResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPEBuildTimeStampValidValues
	{
		/*[in,out]*/ FILETIME* pTimeStamp;
		HRESULT retValue;
	};

	STDMETHOD(GetPEBuildTimeStamp)(
		/*[in,out]*/ FILETIME* pTimeStamp)
	{
		VSL_DEFINE_MOCK_METHOD(GetPEBuildTimeStamp)

		VSL_SET_VALIDVALUE(pTimeStamp);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENCREBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
