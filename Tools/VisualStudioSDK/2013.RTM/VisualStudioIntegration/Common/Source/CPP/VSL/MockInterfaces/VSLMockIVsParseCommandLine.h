/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPARSECOMMANDLINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPARSECOMMANDLINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsParseCommandLineNotImpl :
	public IVsParseCommandLine
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParseCommandLineNotImpl)

public:

	typedef IVsParseCommandLine Interface;

	STDMETHOD(ParseCommandLine)(
		/*[in,ref]*/ LPCOLESTR /*szCommandLine*/,
		/*[in]*/ int /*iMaxParams*/,
		/*[in]*/ int /*iCursorPos*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseCommandTail)(
		/*[in,ref]*/ LPCOLESTR /*szCommandTail*/,
		/*[in]*/ int /*iMaxParams*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HasParams)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HasSwitches)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HasSwitchValues)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParamCount)(
		/*[out,retval]*/ int* /*piParamCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSwitchCount)(
		/*[out,retval]*/ int* /*piSwitchCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSwitchValueCount)(
		/*[out,retval]*/ int* /*piSwitchValueCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SwitchHasValue)(
		/*[in]*/ int /*iIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCommand)(
		/*[out,retval]*/ BSTR* /*pbstrCommand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParam)(
		/*[in]*/ int /*iIndex*/,
		/*[out,retval]*/ BSTR* /*pbstrParam*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRawSwitch)(
		/*[in]*/ int /*iIndex*/,
		/*[out,retval]*/ BSTR* /*pbstrRawSwitch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRawSwitchValue)(
		/*[in]*/ int /*iIndex*/,
		/*[out,retval]*/ BSTR* /*pbstrRawSwitchValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCommandTail)(
		/*[out,retval]*/ BSTR* /*pbstrCommandTail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetACParam)(
		/*[out]*/ int* /*piACIndex*/,
		/*[out]*/ int* /*piACStart*/,
		/*[out]*/ int* /*pcchACLength*/,
		/*[out,retval]*/ BSTR* /*pbstrACParam*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RejectAllSwitches)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ValidateParamCount)(
		/*[in]*/ int /*cParamsMin*/,
		/*[in]*/ int /*cParamsMax*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EvaluateSwitches)(
		/*[in,ref]*/ LPCOLESTR /*szSwitchDefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsSwitchPresent)(
		/*[in]*/ int /*iSwitchIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSwitchValue)(
		/*[in]*/ int /*iSwitchIndex*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QuoteParam)(
		/*[in]*/ LPCOLESTR /*szParam*/,
		/*[out,retval]*/ BSTR* /*pbstrQuotedParam*/)VSL_STDMETHOD_NOTIMPL
};

class IVsParseCommandLineMockImpl :
	public IVsParseCommandLine,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParseCommandLineMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsParseCommandLineMockImpl)

	typedef IVsParseCommandLine Interface;
	struct ParseCommandLineValidValues
	{
		/*[in,ref]*/ LPCOLESTR szCommandLine;
		/*[in]*/ int iMaxParams;
		/*[in]*/ int iCursorPos;
		HRESULT retValue;
	};

	STDMETHOD(ParseCommandLine)(
		/*[in,ref]*/ LPCOLESTR szCommandLine,
		/*[in]*/ int iMaxParams,
		/*[in]*/ int iCursorPos)
	{
		VSL_DEFINE_MOCK_METHOD(ParseCommandLine)

		VSL_CHECK_VALIDVALUE_STRINGW(szCommandLine);

		VSL_CHECK_VALIDVALUE(iMaxParams);

		VSL_CHECK_VALIDVALUE(iCursorPos);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseCommandTailValidValues
	{
		/*[in,ref]*/ LPCOLESTR szCommandTail;
		/*[in]*/ int iMaxParams;
		HRESULT retValue;
	};

	STDMETHOD(ParseCommandTail)(
		/*[in,ref]*/ LPCOLESTR szCommandTail,
		/*[in]*/ int iMaxParams)
	{
		VSL_DEFINE_MOCK_METHOD(ParseCommandTail)

		VSL_CHECK_VALIDVALUE_STRINGW(szCommandTail);

		VSL_CHECK_VALIDVALUE(iMaxParams);

		VSL_RETURN_VALIDVALUES();
	}
	struct HasParamsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HasParams)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HasParams)

		VSL_RETURN_VALIDVALUES();
	}
	struct HasSwitchesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HasSwitches)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HasSwitches)

		VSL_RETURN_VALIDVALUES();
	}
	struct HasSwitchValuesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HasSwitchValues)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HasSwitchValues)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParamCountValidValues
	{
		/*[out,retval]*/ int* piParamCount;
		HRESULT retValue;
	};

	STDMETHOD(GetParamCount)(
		/*[out,retval]*/ int* piParamCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetParamCount)

		VSL_SET_VALIDVALUE(piParamCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSwitchCountValidValues
	{
		/*[out,retval]*/ int* piSwitchCount;
		HRESULT retValue;
	};

	STDMETHOD(GetSwitchCount)(
		/*[out,retval]*/ int* piSwitchCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetSwitchCount)

		VSL_SET_VALIDVALUE(piSwitchCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSwitchValueCountValidValues
	{
		/*[out,retval]*/ int* piSwitchValueCount;
		HRESULT retValue;
	};

	STDMETHOD(GetSwitchValueCount)(
		/*[out,retval]*/ int* piSwitchValueCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetSwitchValueCount)

		VSL_SET_VALIDVALUE(piSwitchValueCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct SwitchHasValueValidValues
	{
		/*[in]*/ int iIndex;
		HRESULT retValue;
	};

	STDMETHOD(SwitchHasValue)(
		/*[in]*/ int iIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SwitchHasValue)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCommandValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCommand;
		HRESULT retValue;
	};

	STDMETHOD(GetCommand)(
		/*[out,retval]*/ BSTR* pbstrCommand)
	{
		VSL_DEFINE_MOCK_METHOD(GetCommand)

		VSL_SET_VALIDVALUE_BSTR(pbstrCommand);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParamValidValues
	{
		/*[in]*/ int iIndex;
		/*[out,retval]*/ BSTR* pbstrParam;
		HRESULT retValue;
	};

	STDMETHOD(GetParam)(
		/*[in]*/ int iIndex,
		/*[out,retval]*/ BSTR* pbstrParam)
	{
		VSL_DEFINE_MOCK_METHOD(GetParam)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrParam);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRawSwitchValidValues
	{
		/*[in]*/ int iIndex;
		/*[out,retval]*/ BSTR* pbstrRawSwitch;
		HRESULT retValue;
	};

	STDMETHOD(GetRawSwitch)(
		/*[in]*/ int iIndex,
		/*[out,retval]*/ BSTR* pbstrRawSwitch)
	{
		VSL_DEFINE_MOCK_METHOD(GetRawSwitch)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrRawSwitch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRawSwitchValueValidValues
	{
		/*[in]*/ int iIndex;
		/*[out,retval]*/ BSTR* pbstrRawSwitchValue;
		HRESULT retValue;
	};

	STDMETHOD(GetRawSwitchValue)(
		/*[in]*/ int iIndex,
		/*[out,retval]*/ BSTR* pbstrRawSwitchValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetRawSwitchValue)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrRawSwitchValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCommandTailValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCommandTail;
		HRESULT retValue;
	};

	STDMETHOD(GetCommandTail)(
		/*[out,retval]*/ BSTR* pbstrCommandTail)
	{
		VSL_DEFINE_MOCK_METHOD(GetCommandTail)

		VSL_SET_VALIDVALUE_BSTR(pbstrCommandTail);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetACParamValidValues
	{
		/*[out]*/ int* piACIndex;
		/*[out]*/ int* piACStart;
		/*[out]*/ int* pcchACLength;
		/*[out,retval]*/ BSTR* pbstrACParam;
		HRESULT retValue;
	};

	STDMETHOD(GetACParam)(
		/*[out]*/ int* piACIndex,
		/*[out]*/ int* piACStart,
		/*[out]*/ int* pcchACLength,
		/*[out,retval]*/ BSTR* pbstrACParam)
	{
		VSL_DEFINE_MOCK_METHOD(GetACParam)

		VSL_SET_VALIDVALUE(piACIndex);

		VSL_SET_VALIDVALUE(piACStart);

		VSL_SET_VALIDVALUE(pcchACLength);

		VSL_SET_VALIDVALUE_BSTR(pbstrACParam);

		VSL_RETURN_VALIDVALUES();
	}
	struct RejectAllSwitchesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RejectAllSwitches)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RejectAllSwitches)

		VSL_RETURN_VALIDVALUES();
	}
	struct ValidateParamCountValidValues
	{
		/*[in]*/ int cParamsMin;
		/*[in]*/ int cParamsMax;
		HRESULT retValue;
	};

	STDMETHOD(ValidateParamCount)(
		/*[in]*/ int cParamsMin,
		/*[in]*/ int cParamsMax)
	{
		VSL_DEFINE_MOCK_METHOD(ValidateParamCount)

		VSL_CHECK_VALIDVALUE(cParamsMin);

		VSL_CHECK_VALIDVALUE(cParamsMax);

		VSL_RETURN_VALIDVALUES();
	}
	struct EvaluateSwitchesValidValues
	{
		/*[in,ref]*/ LPCOLESTR szSwitchDefs;
		HRESULT retValue;
	};

	STDMETHOD(EvaluateSwitches)(
		/*[in,ref]*/ LPCOLESTR szSwitchDefs)
	{
		VSL_DEFINE_MOCK_METHOD(EvaluateSwitches)

		VSL_CHECK_VALIDVALUE_STRINGW(szSwitchDefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsSwitchPresentValidValues
	{
		/*[in]*/ int iSwitchIndex;
		HRESULT retValue;
	};

	STDMETHOD(IsSwitchPresent)(
		/*[in]*/ int iSwitchIndex)
	{
		VSL_DEFINE_MOCK_METHOD(IsSwitchPresent)

		VSL_CHECK_VALIDVALUE(iSwitchIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSwitchValueValidValues
	{
		/*[in]*/ int iSwitchIndex;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSwitchValue)(
		/*[in]*/ int iSwitchIndex,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSwitchValue)

		VSL_CHECK_VALIDVALUE(iSwitchIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct QuoteParamValidValues
	{
		/*[in]*/ LPCOLESTR szParam;
		/*[out,retval]*/ BSTR* pbstrQuotedParam;
		HRESULT retValue;
	};

	STDMETHOD(QuoteParam)(
		/*[in]*/ LPCOLESTR szParam,
		/*[out,retval]*/ BSTR* pbstrQuotedParam)
	{
		VSL_DEFINE_MOCK_METHOD(QuoteParam)

		VSL_CHECK_VALIDVALUE_STRINGW(szParam);

		VSL_SET_VALIDVALUE_BSTR(pbstrQuotedParam);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPARSECOMMANDLINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
