/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMANDWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMANDWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCommandWindowNotImpl :
	public IVsCommandWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindowNotImpl)

public:

	typedef IVsCommandWindow Interface;

	STDMETHOD(ExecuteCommand)(
		/*[in,ref]*/ LPCOLESTR /*szCommand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrepareCommand)(
		/*[in,ref]*/ LPCOLESTR /*szCommand*/,
		/*[out]*/ GUID* /*pguidCmdGroup*/,
		/*[out]*/ DWORD* /*pdwCmdId*/,
		/*[out]*/ VARIANT** /*ppvaCmdArg*/,
		/*[out,retval]*/ PREPARECOMMANDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Create)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Show)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Print)(
		/*[in,ref]*/ LPCOLESTR /*szTextToPrint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EchoCommand)(
		/*[in,ref]*/ LPCOLESTR /*szCommand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMode)(
		/*[in]*/ COMMANDWINDOWMODE /*mode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogToFile)(
		/*[in,ref]*/ LPCOLESTR /*szLogFile*/,
		/*[in]*/ LOGTOFILEOPTIONS /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopLogging)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCurrentLanguageService)(
		/*[in]*/ REFGUID /*rguidLanguageService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RunningCommandWindowCommand)(
		/*[out,retval]*/ BOOL* /*pfCmdWin*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrintNoShow)(
		/*[in,ref]*/ LPCOLESTR /*szTextToPrint*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCommandWindowMockImpl :
	public IVsCommandWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommandWindowMockImpl)

	typedef IVsCommandWindow Interface;
	struct ExecuteCommandValidValues
	{
		/*[in,ref]*/ LPCOLESTR szCommand;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteCommand)(
		/*[in,ref]*/ LPCOLESTR szCommand)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(szCommand);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrepareCommandValidValues
	{
		/*[in,ref]*/ LPCOLESTR szCommand;
		/*[out]*/ GUID* pguidCmdGroup;
		/*[out]*/ DWORD* pdwCmdId;
		/*[out]*/ VARIANT** ppvaCmdArg;
		/*[out,retval]*/ PREPARECOMMANDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(PrepareCommand)(
		/*[in,ref]*/ LPCOLESTR szCommand,
		/*[out]*/ GUID* pguidCmdGroup,
		/*[out]*/ DWORD* pdwCmdId,
		/*[out]*/ VARIANT** ppvaCmdArg,
		/*[out,retval]*/ PREPARECOMMANDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(PrepareCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(szCommand);

		VSL_SET_VALIDVALUE(pguidCmdGroup);

		VSL_SET_VALIDVALUE(pdwCmdId);

		VSL_SET_VALIDVALUE(ppvaCmdArg);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Create)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Create)

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Show)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Show)

		VSL_RETURN_VALIDVALUES();
	}
	struct PrintValidValues
	{
		/*[in,ref]*/ LPCOLESTR szTextToPrint;
		HRESULT retValue;
	};

	STDMETHOD(Print)(
		/*[in,ref]*/ LPCOLESTR szTextToPrint)
	{
		VSL_DEFINE_MOCK_METHOD(Print)

		VSL_CHECK_VALIDVALUE_STRINGW(szTextToPrint);

		VSL_RETURN_VALIDVALUES();
	}
	struct EchoCommandValidValues
	{
		/*[in,ref]*/ LPCOLESTR szCommand;
		HRESULT retValue;
	};

	STDMETHOD(EchoCommand)(
		/*[in,ref]*/ LPCOLESTR szCommand)
	{
		VSL_DEFINE_MOCK_METHOD(EchoCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(szCommand);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetModeValidValues
	{
		/*[in]*/ COMMANDWINDOWMODE mode;
		HRESULT retValue;
	};

	STDMETHOD(SetMode)(
		/*[in]*/ COMMANDWINDOWMODE mode)
	{
		VSL_DEFINE_MOCK_METHOD(SetMode)

		VSL_CHECK_VALIDVALUE(mode);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogToFileValidValues
	{
		/*[in,ref]*/ LPCOLESTR szLogFile;
		/*[in]*/ LOGTOFILEOPTIONS grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(LogToFile)(
		/*[in,ref]*/ LPCOLESTR szLogFile,
		/*[in]*/ LOGTOFILEOPTIONS grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(LogToFile)

		VSL_CHECK_VALIDVALUE_STRINGW(szLogFile);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopLoggingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StopLogging)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StopLogging)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCurrentLanguageServiceValidValues
	{
		/*[in]*/ REFGUID rguidLanguageService;
		HRESULT retValue;
	};

	STDMETHOD(SetCurrentLanguageService)(
		/*[in]*/ REFGUID rguidLanguageService)
	{
		VSL_DEFINE_MOCK_METHOD(SetCurrentLanguageService)

		VSL_CHECK_VALIDVALUE(rguidLanguageService);

		VSL_RETURN_VALIDVALUES();
	}
	struct RunningCommandWindowCommandValidValues
	{
		/*[out,retval]*/ BOOL* pfCmdWin;
		HRESULT retValue;
	};

	STDMETHOD(RunningCommandWindowCommand)(
		/*[out,retval]*/ BOOL* pfCmdWin)
	{
		VSL_DEFINE_MOCK_METHOD(RunningCommandWindowCommand)

		VSL_SET_VALIDVALUE(pfCmdWin);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrintNoShowValidValues
	{
		/*[in,ref]*/ LPCOLESTR szTextToPrint;
		HRESULT retValue;
	};

	STDMETHOD(PrintNoShow)(
		/*[in,ref]*/ LPCOLESTR szTextToPrint)
	{
		VSL_DEFINE_MOCK_METHOD(PrintNoShow)

		VSL_CHECK_VALIDVALUE_STRINGW(szTextToPrint);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMANDWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
