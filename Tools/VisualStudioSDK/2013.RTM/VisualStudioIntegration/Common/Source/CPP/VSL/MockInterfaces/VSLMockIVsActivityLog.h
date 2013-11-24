/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSACTIVITYLOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSACTIVITYLOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsActivityLogNotImpl :
	public IVsActivityLog
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsActivityLogNotImpl)

public:

	typedef IVsActivityLog Interface;

	STDMETHOD(LogEntry)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryGuid)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ GUID /*guid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryHr)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ HRESULT /*hr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryGuidHr)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ GUID /*guid*/,
		/*[in]*/ HRESULT /*hr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ LPCOLESTR /*pszPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryGuidPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ GUID /*guid*/,
		/*[in]*/ LPCOLESTR /*pszPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryHrPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ HRESULT /*hr*/,
		/*[in]*/ LPCOLESTR /*pszPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LogEntryGuidHrPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE /*actType*/,
		/*[in]*/ LPCOLESTR /*pszSource*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ GUID /*guid*/,
		/*[in]*/ HRESULT /*hr*/,
		/*[in]*/ LPCOLESTR /*pszPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsActivityLogMockImpl :
	public IVsActivityLog,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsActivityLogMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsActivityLogMockImpl)

	typedef IVsActivityLog Interface;
	struct LogEntryValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		HRESULT retValue;
	};

	STDMETHOD(LogEntry)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntry)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryGuidValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ GUID guid;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryGuid)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ GUID guid)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryGuid)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryHrValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ HRESULT hr;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryHr)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ HRESULT hr)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryHr)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(hr);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryGuidHrValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ GUID guid;
		/*[in]*/ HRESULT hr;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryGuidHr)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ GUID guid,
		/*[in]*/ HRESULT hr)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryGuidHr)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE(hr);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryPathValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ LPCOLESTR pszPath;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ LPCOLESTR pszPath)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryPath)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryGuidPathValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ GUID guid;
		/*[in]*/ LPCOLESTR pszPath;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryGuidPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ GUID guid,
		/*[in]*/ LPCOLESTR pszPath)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryGuidPath)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryHrPathValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ HRESULT hr;
		/*[in]*/ LPCOLESTR pszPath;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryHrPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ HRESULT hr,
		/*[in]*/ LPCOLESTR pszPath)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryHrPath)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(hr);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct LogEntryGuidHrPathValidValues
	{
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType;
		/*[in]*/ LPCOLESTR pszSource;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ GUID guid;
		/*[in]*/ HRESULT hr;
		/*[in]*/ LPCOLESTR pszPath;
		HRESULT retValue;
	};

	STDMETHOD(LogEntryGuidHrPath)(
		/*[in]*/ ACTIVITYLOG_ENTRYTYPE actType,
		/*[in]*/ LPCOLESTR pszSource,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ GUID guid,
		/*[in]*/ HRESULT hr,
		/*[in]*/ LPCOLESTR pszPath)
	{
		VSL_DEFINE_MOCK_METHOD(LogEntryGuidHrPath)

		VSL_CHECK_VALIDVALUE(actType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE(hr);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSACTIVITYLOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
