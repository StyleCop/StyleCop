/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLEXCEPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLEXCEPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSL.h>

// SCL includes
#include <memory>
#include <typeinfo>
#include <stdexcept>
#include <xiosbase>

// VS Platform includes
#include <VsShellInterfaces.h>

namespace VSL
{

// FUTURE - add support for help keyword and possibly source string.
class ExtendedErrorInfo
{
private:

	// No default construction, a description resource ID or string must be provided.
	ExtendedErrorInfo();

public:

	ExtendedErrorInfo(UINT iResourceID):
		m_iResourceID(iResourceID),
		m_strMessage()
	{
	}

	ExtendedErrorInfo(const TCHAR* szErrorMessage):
		m_iResourceID(0),
		m_strMessage(szErrorMessage)
	{
	}

	// The compiler generated destructor is fine

	UINT GetDescriptionID() const
	{
		return m_iResourceID;
	}

	operator const TCHAR*() const
	{
		if(!m_strMessage && m_iResourceID != 0)
		{
			// Could have loaded the string in the res ID contstructor, but it isn't always needed,
			// so we are lazy caching the actual string
			if(!const_cast<ExtendedErrorInfo*>(this)->m_strMessage.LoadString(_AtlBaseModule.GetResourceInstance(), m_iResourceID))
			{
				// Ignore failure, so the application error will still get thrown,
				// even if it doesn't have extended information
				VSL_TRACE("ResourceString default constructor - failed to load resource string!");
			}
		}
		return m_strMessage;
	}

	const ExtendedErrorInfo& operator=(const ExtendedErrorInfo& rToCopy)
	{
		if(&rToCopy != this)
		{
			m_iResourceID = rToCopy.m_iResourceID;
			m_strMessage = rToCopy.m_strMessage;
		}
		return *this;
	}

	bool operator==(UINT iResourceID) const
	{
		return iResourceID == m_iResourceID;
	}

	friend bool operator==(UINT iResourceID, const ExtendedErrorInfo& rThis)
	{
		return rThis.operator==(iResourceID);
	}
private:

	UINT m_iResourceID;
	ATL::CString m_strMessage;

};

// TODO - move this to another file
#ifndef	VSL_GET_VSUISHELL_SERVICE
class GlobalVSServiceProvider; // forward decleration
#define VSL_GET_VSUISHELL_SERVICE() GlobalVSServiceProvider::GetVsUIShellService()
#endif

// NOTE - the string resource provided for source does not get shown to the user by VS
// There may not be much purpose in setting this value.
// FUTURE - the type of iSourceID_T parameter may change to a TCHAR*, something else, or be removed
template <UINT iSourceID_T = 0>
class VsReportErrorUtilities
{

	VSL_DECLARE_NOT_COPYABLE(VsReportErrorUtilities)

public:

	VsReportErrorUtilities():
		m_spIVsUIShell(VSL_GET_VSUISHELL_SERVICE())
	{
		
	}

	VsReportErrorUtilities(IVsUIShell* pIVsUIShell):
		m_spIVsUIShell(pIVsUIShell)
	{
	}

	// The compiler generated destructor is fine

	// FUTURE - The parameter iSourceID may change to be a TCHAR*, something else, or be removed.
	// The other parameters may be reordered.  It is recommended that method not be called 
	// directly for the time being.

	// Does not throw, so can be called outside of try/catch block
	void __declspec(nothrow) ReportExtendedError(
		HRESULT hrError,
		unsigned int iErrorDescriptionID = 0,
		bool bDisplayErrorToUser = false,
		const wchar_t* const szHelpKeyword = NULL,
		unsigned int iSourceID = iSourceID_T) 
	{
		if(!m_spIVsUIShell)
		{
			// Don't have a pointer to the VsUIShell service, bail
			VSL_TRACE(L"VsReportErrorUtilities::ReportExtendedError - VsUIShell not available!");
			return;
		}

		// Load the description from the string table, but ignore failure to ensure that at least 
		// the HRESULT is reported
		CStringW strDescription;
		if(iErrorDescriptionID != 0)
		{
			strDescription.LoadString(iErrorDescriptionID);
			if(!strDescription || strDescription[0] == L'\0')
			{
				VSL_TRACE(L"VsReportErrorUtilities::ReportExtendedError - error description string not loaded!");
			}
		}

		// Load the source, if any, from the string table.  A CStringW is an empty string by default,
		// but NULL is needed if it is not set, so two variables are used here.
		CStringW strSource;
		if(iSourceID != 0)
		{
			// Load the source from the string table, but ignore failure to ensure at least the 
			// HRESULT is reported
			strSource.LoadString(iSourceID);
			if(!strSource || strSource[0] == L'\0')
			{
				VSL_TRACE(L"VsReportErrorUtilities::ReportExtendedError - error source string not loaded!");
			}
		}

		if(strDescription[0] != L'\0' || szHelpKeyword != NULL || strSource[0] != L'\0')
		{
			// Have VS create an object implementing IErrorInfo with the extended error info provided
			// Need to pass in NULL rather then empty string, as VS display's a better error message that
			// way (i.e. it treats a empty string a valid string).
			HRESULT hr = m_spIVsUIShell->SetErrorInfo(
				hrError,
				strDescription[0] != L'\0' ? strDescription.GetString() : NULL,
				0,
				szHelpKeyword,
				strSource[0] != L'\0' ? strSource.GetString() : NULL);

				// Just trace, so hopefully something will get reported to the user
				if(FAILED(hr))
				{
					VSL_TRACE(L"VsReportErrorUtilities::ReportExtendedError - call to IVsUIShell::SetErrorInfo failed");
				}

				if(bDisplayErrorToUser)
				{
					// Have VS report the application error to the user
					hr = m_spIVsUIShell->ReportErrorInfo(hrError);

					// Just trace, as there is nothing to be done about this call failing.
					if(FAILED(hr))
					{
						VSL_TRACE(L"VsReportErrorUtilities::ReportExtendedError - call to IVsUIShell::ReportErrorInfo failed");
					}
				}
		}
		else
		{
			// No extra error information to report, just report it as a standard error
			// which ensures that any previously set error info is cleared.
			ReportStandardError(hrError, bDisplayErrorToUser);
		}
	}

	// Does not throw, so can be called outside of try/catch block
	void __declspec(nothrow) ReportExtendedError(
		HRESULT hrError,
		const ExtendedErrorInfo& rExtendedError,
		bool bDisplayErrorToUser = false)
	{
		ReportExtendedError(hrError, rExtendedError.GetDescriptionID(), bDisplayErrorToUser);
	}

	// Does not throw, so can be called outside of try/catch block
	void __declspec(nothrow) ReportStandardError(HRESULT hrError, bool bDisplayErrorToUser = false)
	{
		if(!m_spIVsUIShell)
		{
			// Don't have a pointer to the VsUIShell service, bail
			VSL_TRACE(L"VsReportErrorUtilities::ReportStandardError - VsUIShell not available!");
			return;
		}

		// Clear any current error info
		HRESULT hr = ::SetErrorInfo(0, NULL);
		// Just trace, so hopefully something will get reported to the user
		if(FAILED(hr))
		{
			VSL_TRACE(L"VsReportErrorUtilities::ReportStandardError - call to ::SetErrorInfo failed");
		}

		if(bDisplayErrorToUser)
		{
			// Have VS report the system error to the user
			hr = m_spIVsUIShell->ReportErrorInfo(hrError);

			// Just trace, so hopefully something will get reported to the user
			if(FAILED(hr))
			{
				VSL_TRACE(L"VsReportErrorUtilities::ReportStandardError - call to ::SetErrorInfo failed");
			}
		}
	}

private:
	CComPtr<IVsUIShell> m_spIVsUIShell;
};

#ifndef VSL_REPORT_ERROR_HRESULT
#define VSL_REPORT_ERROR_HRESULT(hr, bDisplayErrorToUser) \
	VsReportErrorUtilities<> util; \
	util.ReportStandardError(hr, bDisplayErrorToUser);
#endif

#define _VSL_REPORT_ERROR_HRESULT_EX(hr, extended, bDisplayErrorToUser) \
	VsReportErrorUtilities<> util; \
	util.ReportExtendedError(hr, extended, bDisplayErrorToUser);

#ifndef VSL_REPORT_ERROR_HRESULT_EX
#define VSL_REPORT_ERROR_HRESULT_EX _VSL_REPORT_ERROR_HRESULT_EX
#endif

class ExceptionBase
{
public:

	// The compiler generated default constructor, copy constructor, assignment operator are 
	// are fine as this is an abstract base class as signified by the pure virtual destructor.

	virtual ~ExceptionBase() = 0 {}

	operator HRESULT() const
	{
		return GetHRESULT();
	}

	operator DWORD() const
	{
		return GetWin32Error();
	}

	virtual HRESULT GetHRESULT() const = 0;

	virtual DWORD GetWin32Error() const
	{
		HRESULT hr = GetHRESULT();
	    return (FAILED(hr) ? (hr & 0x0000FFFF) : ERROR_SUCCESS);
	}

	virtual void ReportError(bool bDisplayErrorToUser = false) const
	{
		VSL_REPORT_ERROR_HRESULT(GetHRESULT(), bDisplayErrorToUser);
	}
};

class ExceptionStd : 
	public ExceptionBase
{
public:

	enum TypeID
	{
		UNKNOWN = 0,
		EXCEPTION,
			BAD_ALLOC,
			BAD_CAST,
			BAD_EXCEPTION,
			BAD_TYPEID,
				__NON_RTTI_OBJECT,
			LOGIC_ERROR,
				DOMAIN_ERROR,
				INVALID_ARGUMENT,
				LENGTH_ERROR,
				OUT_OF_RANGE,
			RUNTIME_ERROR,
				RANGE_ERROR,
				OVERFLOW_ERROR,
				UNDERFLOW_ERROR,
				IOS_BASE_FAILURE,
		NUM_EXCEPTION_TYPES
	};

private:

	ExceptionStd();
	ExceptionStd& operator=(ExceptionStd& rhs);

public:

	// Let the compiler generate the copy constructor since a bit copy is fine

	explicit ExceptionStd(const std::exception& e):
		m_eTypeID(UNKNOWN)
	{
		try
		{
			const type_info& rType = typeid(e);

			if(rType == typeid(std::exception))
			{
				m_eTypeID = EXCEPTION;
			}
			else if(rType == typeid(std::bad_alloc))
			{
				m_eTypeID = BAD_ALLOC;
			}
			else if(rType == typeid(std::bad_cast))
			{
				m_eTypeID = BAD_CAST;
			}
			else if(rType == typeid(std::bad_exception))
			{
				m_eTypeID = BAD_EXCEPTION;
			}
			else if(rType == typeid(std::bad_typeid))
			{
				m_eTypeID = BAD_TYPEID;
			}
			else if(rType == typeid(std::__non_rtti_object))
			{
				m_eTypeID = __NON_RTTI_OBJECT;
			}
			else if(rType == typeid(std::logic_error))
			{
				m_eTypeID = LOGIC_ERROR;
			}
			else if(rType == typeid(std::domain_error))
			{
				m_eTypeID = DOMAIN_ERROR;
			}
			else if(rType == typeid(std::invalid_argument))
			{
				m_eTypeID = INVALID_ARGUMENT;
			}
			else if(rType == typeid(std::length_error))
			{
				m_eTypeID = LENGTH_ERROR;
			}
			else if(rType == typeid(std::out_of_range))
			{
				m_eTypeID = OUT_OF_RANGE;
			}
			else if(rType == typeid(std::runtime_error))
			{
				m_eTypeID = RUNTIME_ERROR;
			}
			else if(rType == typeid(std::range_error))
			{
				m_eTypeID = RANGE_ERROR;
			}
			else if(rType == typeid(std::overflow_error))
			{
				m_eTypeID = OVERFLOW_ERROR;
			}
			else if(rType == typeid(std::underflow_error))
			{
				m_eTypeID = UNDERFLOW_ERROR;
			}
			else if(rType == typeid(std::ios_base::failure))
			{
				m_eTypeID = IOS_BASE_FAILURE;
			}
		}
		catch(...)
		{
			// typeid should only throw if passed a null pointer, so this should never happen
			VSL_ASSERT(false);
		}
	}

	virtual ~ExceptionStd() {}

    virtual HRESULT GetHRESULT() const
	{
		if(BAD_ALLOC == m_eTypeID)
		{
			return E_OUTOFMEMORY;
		}

		return DISP_E_EXCEPTION;
	}

    TypeID GetStdExceptionTypeID() const
	{
		return m_eTypeID;
	}

protected:

    TypeID m_eTypeID;

};

class ExceptionExBase : 
	public ExceptionBase
{
public:
	// The compiler generated default constructor, copy constructor, assignment operator are 
	// are fine as this is an abstract base class as signified by the pure virtual destructor.

	virtual ~ExceptionExBase() = 0 {}

#ifndef _VSL_NO_SOURCE_INFO
	virtual const TCHAR* GetExpressionString() const = 0;

	virtual const TCHAR* GetSourceFilenamePath() const = 0;

	virtual int GetSourceLinenumber() const = 0;
#endif

	virtual const TCHAR* GetErrorString() const = 0;
};

#if 0 // FUTURE - can be added back if needed.
class ExtraDataTypeContainerString
{
private:

	ExtraDataTypeContainerString();

public:

	typedef const TCHAR* Type;

	static Type DefaultValue()
	{
		return NULL;
	}

	static Type DefaultString()
	{
		return NULL;
	}

	static Type GetErrorStringFromData(Type data)
	{
		return data;
	}
};
#endif

class ExtendedErrorInfoExtraDataTypeContainer
{
private:

	ExtendedErrorInfoExtraDataTypeContainer();

public:

	typedef ExtendedErrorInfo Type;

	static UINT DefaultValue()
	{
		return 0;
	}

	static const TCHAR* DefaultString()
	{
		return _T("");
	}

	static const TCHAR* GetErrorStringFromData(const Type& data)
	{
		return data;
	}
};

typedef ExtendedErrorInfoExtraDataTypeContainer ExceptionExtraDataTypeContainerDefault;

template<
	class Expression_T,
	class ExtraDataTypeContainer_T = ExceptionExtraDataTypeContainerDefault,
	class String_T = const TCHAR* >
class ExceptionExImpl : 
	public ExceptionExBase
{
public:

	typedef Expression_T ExpressionType;
	typedef ExtraDataTypeContainer_T ExtraDataTypeContainer;
	typedef typename ExtraDataTypeContainer_T::Type ExtraDataType;
	typedef String_T StringType;

private:

	ExceptionExImpl();
	const ExceptionExImpl& operator=(const ExceptionExImpl& rToCopy);

public:

	explicit ExceptionExImpl(
		const Expression_T& expressionValue,
#ifndef _VSL_NO_SOURCE_INFO
		String_T strExpression,
		String_T strFilename,
		int iLineNumber,
#endif
		const ExtraDataType& extraData = ExtraDataTypeContainer_T::DefaultValue()):
			m_expValue(expressionValue),
#ifndef _VSL_NO_SOURCE_INFO
			m_strExpression(strExpression),
			m_strFilename(strFilename),
			m_iLineNumber(iLineNumber),
#endif
			m_ExtraData(extraData)
	{

	}

	ExceptionExImpl(const ExceptionExImpl& rToCopy):
		ExceptionExBase(rToCopy),
		m_expValue(rToCopy.m_expValue),
#ifndef _VSL_NO_SOURCE_INFO
		m_strExpression(rToCopy.m_strExpression),
		m_strFilename(rToCopy.m_strFilename),
		m_iLineNumber(rToCopy.m_iLineNumber),
#endif
		m_ExtraData(rToCopy.m_ExtraData)
	{
		
	}

	virtual ~ExceptionExImpl() = 0 {}

#ifndef _VSL_NO_SOURCE_INFO

	virtual const TCHAR* GetExpressionString() const
	{
		return m_strExpression;
	}

	const String_T& GetExpressionStringTyped() const
	{
		return m_strExpression;
	}

	virtual const TCHAR* GetSourceFilenamePath() const
	{
		return m_strFilename;
	}

	const String_T& GetSourceFilenamePathTyped() const
	{
		return m_strFilename;
	}

	virtual int GetSourceLinenumber() const
	{
		return m_iLineNumber;
	}

#endif

	virtual const TCHAR* GetErrorString() const
	{
		return ExtraDataTypeContainer_T::GetErrorStringFromData(m_ExtraData);
	}

	const ExtraDataType& GetExtraData() const
	{
		return m_ExtraData;
	}

	virtual void ReportError(bool bDisplayErrorToUser = false) const
	{
		VSL_REPORT_ERROR_HRESULT_EX(GetHRESULT(), m_ExtraData, bDisplayErrorToUser);
	}

protected:
	
	Expression_T m_expValue;
#ifndef _VSL_NO_SOURCE_INFO
	String_T m_strExpression;
	String_T m_strFilename;
	int m_iLineNumber;
#endif
	ExtraDataType m_ExtraData;

};

template<
	typename class ExtraDataTypeContainer_T = ExceptionExtraDataTypeContainerDefault,
	typename String_T = const TCHAR* >
class ExceptionHRESULT :
	public ExceptionExImpl<
		HRESULT, 
		ExtraDataTypeContainer_T, 
		String_T>
{
public:

	typedef ExceptionExImpl<
		HRESULT, 
		ExtraDataTypeContainer_T, 
		String_T> BaseClass;

private:

	ExceptionHRESULT();
	const ExceptionHRESULT& operator=(const ExceptionHRESULT& rToCopy);

public:

	virtual HRESULT GetHRESULT() const
	{
		return m_expValue;
	}

	explicit ExceptionHRESULT(
		HRESULT hr,
#ifndef _VSL_NO_SOURCE_INFO
		String_T strExpression,
		String_T strFilename,
		int iLineNumber,
#endif
		const ExtraDataType& extraData = ExtraDataTypeContainer_T::DefaultValue()):
			BaseClass(
				hr,
 #ifndef _VSL_NO_SOURCE_INFO
				strExpression,
				strFilename,
				iLineNumber,
#endif
				extraData)
	{
	}

	ExceptionHRESULT(const ExceptionHRESULT& rToCopy):
		BaseClass(rToCopy)
	{
	}
};

template<
	typename class ExtraDataTypeContainer_T = ExceptionExtraDataTypeContainerDefault,
	class String_T = const TCHAR* >
class ExceptionWin32 : 
	public ExceptionExImpl<
		DWORD, 
		ExtraDataTypeContainer_T, 
		String_T>
{
public:

	typedef ExceptionExImpl<
		DWORD, 
		ExtraDataTypeContainer_T, 
		String_T> BaseClass;

private:

	ExceptionWin32();
	const ExceptionWin32& operator=(const ExceptionWin32& rToCopy);
	
public:

	ExceptionWin32(
		DWORD dwCode,
#ifndef _VSL_NO_SOURCE_INFO
		String_T strExpression,
		String_T strFilename,
		int iLineNumber,
#endif
		const ExtraDataType& extraData = ExtraDataTypeContainer_T::DefaultValue()):
			BaseClass(
				dwCode,
 #ifndef _VSL_NO_SOURCE_INFO
				strExpression,
				strFilename,
				iLineNumber,
#endif
				extraData)
	{
	}

	ExceptionWin32(const ExceptionWin32& rToCopy):
		BaseClass(rToCopy)
	{
	}

	virtual HRESULT GetHRESULT() const
	{
		return HRESULT_FROM_WIN32(m_expValue);
	}

	virtual DWORD GetWin32Error() const
	{
		return m_expValue;
	}
};

} // namespace VSL

#endif // VSLEXCEPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

