/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMACRORECORDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMACRORECORDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vbapkg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMacroRecorderNotImpl :
	public IVsMacroRecorder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMacroRecorderNotImpl)

public:

	typedef IVsMacroRecorder Interface;

	STDMETHOD(RecordStart)(
		/*[in]*/ LPCOLESTR /*pszReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordEnd)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordLine)(
		/*[in]*/ LPCOLESTR /*pszLine*/,
		/*[in]*/ REFGUID /*rguidEmitter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastEmitterId)(
		/*[out]*/ GUID* /*pguidEmitter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReplaceLine)(
		/*[in]*/ LPCOLESTR /*pszLine*/,
		/*[in]*/ REFGUID /*rguidEmitter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordCancel)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordPause)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RecordResume)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCodeEmittedFlag)(
		/*[in]*/ BOOL /*fFlag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeEmittedFlag)(
		/*[out]*/ BOOL* /*pfFlag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetKeyWord)(
		/*[in]*/ UINT /*uiKeyWordId*/,
		/*[out]*/ BSTR* /*pbstrKeyWord*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValidIdentifier)(
		/*[in]*/ LPCOLESTR /*pszIdentifier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRecordMode)(
		/*[out]*/ VSRECORDMODE* /*peRecordMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRecordMode)(
		/*[in]*/ VSRECORDMODE /*eRecordMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStringLiteralExpression)(
		/*[in]*/ LPCOLESTR /*pszStringValue*/,
		/*[out]*/ BSTR* /*pbstrLiteralExpression*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecuteLine)(
		/*[in]*/ LPCOLESTR /*pszLine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddTypeLibRef)(
		/*[in]*/ REFGUID /*guidTypeLib*/,
		/*[in]*/ UINT /*uVerMaj*/,
		/*[in]*/ UINT /*uVerMin*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMacroRecorderMockImpl :
	public IVsMacroRecorder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMacroRecorderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMacroRecorderMockImpl)

	typedef IVsMacroRecorder Interface;
	struct RecordStartValidValues
	{
		/*[in]*/ LPCOLESTR pszReserved;
		HRESULT retValue;
	};

	STDMETHOD(RecordStart)(
		/*[in]*/ LPCOLESTR pszReserved)
	{
		VSL_DEFINE_MOCK_METHOD(RecordStart)

		VSL_CHECK_VALIDVALUE_STRINGW(pszReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordEndValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordEnd)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordEnd)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordLineValidValues
	{
		/*[in]*/ LPCOLESTR pszLine;
		/*[in]*/ REFGUID rguidEmitter;
		HRESULT retValue;
	};

	STDMETHOD(RecordLine)(
		/*[in]*/ LPCOLESTR pszLine,
		/*[in]*/ REFGUID rguidEmitter)
	{
		VSL_DEFINE_MOCK_METHOD(RecordLine)

		VSL_CHECK_VALIDVALUE_STRINGW(pszLine);

		VSL_CHECK_VALIDVALUE(rguidEmitter);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastEmitterIdValidValues
	{
		/*[out]*/ GUID* pguidEmitter;
		HRESULT retValue;
	};

	STDMETHOD(GetLastEmitterId)(
		/*[out]*/ GUID* pguidEmitter)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastEmitterId)

		VSL_SET_VALIDVALUE(pguidEmitter);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceLineValidValues
	{
		/*[in]*/ LPCOLESTR pszLine;
		/*[in]*/ REFGUID rguidEmitter;
		HRESULT retValue;
	};

	STDMETHOD(ReplaceLine)(
		/*[in]*/ LPCOLESTR pszLine,
		/*[in]*/ REFGUID rguidEmitter)
	{
		VSL_DEFINE_MOCK_METHOD(ReplaceLine)

		VSL_CHECK_VALIDVALUE_STRINGW(pszLine);

		VSL_CHECK_VALIDVALUE(rguidEmitter);

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordCancelValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordCancel)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordCancel)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordPauseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordPause)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordPause)

		VSL_RETURN_VALIDVALUES();
	}
	struct RecordResumeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RecordResume)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RecordResume)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCodeEmittedFlagValidValues
	{
		/*[in]*/ BOOL fFlag;
		HRESULT retValue;
	};

	STDMETHOD(SetCodeEmittedFlag)(
		/*[in]*/ BOOL fFlag)
	{
		VSL_DEFINE_MOCK_METHOD(SetCodeEmittedFlag)

		VSL_CHECK_VALIDVALUE(fFlag);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeEmittedFlagValidValues
	{
		/*[out]*/ BOOL* pfFlag;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeEmittedFlag)(
		/*[out]*/ BOOL* pfFlag)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeEmittedFlag)

		VSL_SET_VALIDVALUE(pfFlag);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetKeyWordValidValues
	{
		/*[in]*/ UINT uiKeyWordId;
		/*[out]*/ BSTR* pbstrKeyWord;
		HRESULT retValue;
	};

	STDMETHOD(GetKeyWord)(
		/*[in]*/ UINT uiKeyWordId,
		/*[out]*/ BSTR* pbstrKeyWord)
	{
		VSL_DEFINE_MOCK_METHOD(GetKeyWord)

		VSL_CHECK_VALIDVALUE(uiKeyWordId);

		VSL_SET_VALIDVALUE_BSTR(pbstrKeyWord);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsValidIdentifierValidValues
	{
		/*[in]*/ LPCOLESTR pszIdentifier;
		HRESULT retValue;
	};

	STDMETHOD(IsValidIdentifier)(
		/*[in]*/ LPCOLESTR pszIdentifier)
	{
		VSL_DEFINE_MOCK_METHOD(IsValidIdentifier)

		VSL_CHECK_VALIDVALUE_STRINGW(pszIdentifier);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRecordModeValidValues
	{
		/*[out]*/ VSRECORDMODE* peRecordMode;
		HRESULT retValue;
	};

	STDMETHOD(GetRecordMode)(
		/*[out]*/ VSRECORDMODE* peRecordMode)
	{
		VSL_DEFINE_MOCK_METHOD(GetRecordMode)

		VSL_SET_VALIDVALUE(peRecordMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRecordModeValidValues
	{
		/*[in]*/ VSRECORDMODE eRecordMode;
		HRESULT retValue;
	};

	STDMETHOD(SetRecordMode)(
		/*[in]*/ VSRECORDMODE eRecordMode)
	{
		VSL_DEFINE_MOCK_METHOD(SetRecordMode)

		VSL_CHECK_VALIDVALUE(eRecordMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStringLiteralExpressionValidValues
	{
		/*[in]*/ LPCOLESTR pszStringValue;
		/*[out]*/ BSTR* pbstrLiteralExpression;
		HRESULT retValue;
	};

	STDMETHOD(GetStringLiteralExpression)(
		/*[in]*/ LPCOLESTR pszStringValue,
		/*[out]*/ BSTR* pbstrLiteralExpression)
	{
		VSL_DEFINE_MOCK_METHOD(GetStringLiteralExpression)

		VSL_CHECK_VALIDVALUE_STRINGW(pszStringValue);

		VSL_SET_VALIDVALUE_BSTR(pbstrLiteralExpression);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecuteLineValidValues
	{
		/*[in]*/ LPCOLESTR pszLine;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteLine)(
		/*[in]*/ LPCOLESTR pszLine)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteLine)

		VSL_CHECK_VALIDVALUE_STRINGW(pszLine);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddTypeLibRefValidValues
	{
		/*[in]*/ REFGUID guidTypeLib;
		/*[in]*/ UINT uVerMaj;
		/*[in]*/ UINT uVerMin;
		HRESULT retValue;
	};

	STDMETHOD(AddTypeLibRef)(
		/*[in]*/ REFGUID guidTypeLib,
		/*[in]*/ UINT uVerMaj,
		/*[in]*/ UINT uVerMin)
	{
		VSL_DEFINE_MOCK_METHOD(AddTypeLibRef)

		VSL_CHECK_VALIDVALUE(guidTypeLib);

		VSL_CHECK_VALIDVALUE(uVerMaj);

		VSL_CHECK_VALIDVALUE(uVerMin);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMACRORECORDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
