/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLUNITTEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLUNITTEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#if !defined(_WIN32_WINNT) || (_WIN32_WINNT < 0x0400)
#error VSLUnitTest.h requires _WIN32_WINNT to be set to 0x0400 or higher.
#endif

#ifndef _VSL_RETAIL_SOURCE_INFO
#ifdef VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#error VSLUnitTest.h requires _VSL_RETAIL_SOURCE_INFO to be defined prior to the first inclusion of VSL.h
#else // VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define _VSL_RETAIL_SOURCE_INFO
#endif // VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#endif // _VSL_RETAIL_SOURCE_INFO

// VSL includes and pre-defines

// For unit tests, disable error reporting, by default
#ifndef VSL_REPORT_ERROR_HRESULT
#define VSL_REPORT_ERROR_HRESULT(hr, bDisplayErrorToUser) (hr, bDisplayErrorToUser)
#endif

#ifndef VSL_REPORT_ERROR_HRESULT_EX
#define VSL_REPORT_ERROR_HRESULT_EX(hr, extended, bDisplayErrorToUser) (hr, extended, bDisplayErrorToUser)
#endif

// For unit tests, assume variants of types the system doesn't know how to compare, are equivalent
#ifndef VSL_VARIANT_EQUIVALENCE_DISP_E_BADVARTYPE_RETURN 
#define VSL_VARIANT_EQUIVALENCE_DISP_E_BADVARTYPE_RETURN true
#endif

// Since unit tests will generate errors on purpose, disable this so no asserts will be raised
// by the default error processors.
#ifndef VSL_ERROR_PROCESSOR_ASSERTEX
#define VSL_ERROR_PROCESSOR_ASSERTEX(exp, szMsg) ((void)0)
#endif

#ifndef VSL_UTASSERTEX
#define VSL_UTASSERTEX(exp, szMsg) _ASSERT_BASE(exp, szMsg)
#endif

#include <VSL.h>
#include <VSLCommon.h>
#include <VSLComparison.h>

#pragma warning(push)

// REVIEW - next version these warnings may be fixed.
#pragma warning(disable : 6011)

#include <iostream>
#include <crtdbg.h>
#include <queue>

#pragma warning(pop)

namespace VSL
{

#ifndef VSL_UTPASSEX
#define VSL_UTPASSEX(szTestName, szTestStep, szFailure, szFileName, iLineNumber) ((void)0)
#endif

#define VSL_UTPASS(szTestName, szTestStep, szFailure) VSL_UTPASSEX(szTestName, szTestStep, szFailure, __VSL_FILE__, __LINE__)

class FailedTest {};    // This class is used to identify the counter of failed tests.
typedef GlobalRefCount<FailedTest> FailureCounter;

static void HandleUnitTestFailure(
	const char* szTestName,
	const TCHAR* szTestStep, 
	const TCHAR* szExpText, 
	const TCHAR* szFileName, 
	int iLineNumber)
{
	if (FailureCounter::CanIncrement())
	{
		FailureCounter::Get()++;
	}
	_ASSERTE(szFileName != NULL);
	_ASSERTE(iLineNumber > 0);

#ifdef _UNICODE
	std::wostream& streamOut = std::wcerr;
#else
	std::ostream& streamOut = std::cpit;
#endif

	streamOut << szFileName << _T('(') << iLineNumber << _T(')') << _T(" : FAILED");

	if(szTestName != NULL)
	{
		streamOut << _T(" : ") << szTestName;
	}

	if(szTestStep != NULL)
	{
		streamOut << _T(" : ") << szTestStep;
	}

	if(szExpText != NULL)
	{
		streamOut << _T(" : ") << szExpText;
	}

	streamOut << _T('\n');

	if(IsDebuggerPresent() != 0)
	{
		DebugBreak();
	}
}

#ifndef VSL_UTFAILEX
#define VSL_UTFAILEX(szTestName, szTestStep, szFailure, szFileName, iLineNumber) VSL::HandleUnitTestFailure(szTestName, szTestStep, szFailure, szFileName, iLineNumber)
#endif // VSL_UTFAILEX

#define VSL_UTFAIL(szTestName, szTestStep, szFailure) VSL_UTFAILEX(szTestName, szTestStep, szFailure, __VSL_FILE__, __LINE__)

class UnitTestBase
{
private:

VSL_DECLARE_NOT_COPYABLE(UnitTestBase)

protected:

	explicit UnitTestBase(_In_opt_ const char* const szTestName):
		m_szTestName(szTestName)
	{
		SetUnitTestBase(*this);
	}

	~UnitTestBase() {}

public:

	bool Check(
		bool bExpValue,
		const TCHAR* szTestStep, 
		const TCHAR* szExpText, 
		const TCHAR* szFileName, 
		int iLineNumber) const
	{
		if(bExpValue)
		{
			// Success
			VSL_UTPASSEX(m_szTestName, szTestStep, szExpText, szFileName, iLineNumber);
		}
		else
		{
			// Failure
			VSL_UTFAILEX(m_szTestName, szTestStep, szExpText, szFileName, iLineNumber);
		}

		return bExpValue;
	}

public:

	static void SetUnitTestBase(const UnitTestBase& rUnitTestBase)
	{
		GetCurrentUnitTestBase() = &rUnitTestBase;
	}

	typedef const UnitTestBase* UnitTestBasePtr;
	static UnitTestBasePtr& GetCurrentUnitTestBase()
	{
		static UnitTestBasePtr pUnitTestBase = NULL;
		return pUnitTestBase;
	}

protected:

	const char* const m_szTestName;

};

#ifdef _UNICODE
#define VSL_UTHELPERCHECK_EX(exp, szTestStep, pUnitTest) pUnitTest->VSL::UnitTestBase::Check(exp, szTestStep, L#exp, __WFILE__, __LINE__)
#else
#define VSL_UTHELPERCHECK_EX(exp, szTestStep, pUnitTest) pUnitTest->VSL::UnitTestBase::Check(exp, szTestStep, #exp, __FILE__, __LINE__)
#endif

#define VSL_UTHELPERCHECK(exp, pUnitTest) VSL_UTHELPERCHECK_EX(exp, NULL, pUnitTest)
#define VSL_UTCHECK_EX(exp, szTestStep) VSL_UTHELPERCHECK_EX(exp, szTestStep, this)
#define VSL_UTCHECK(exp) VSL_UTHELPERCHECK_EX(exp, NULL, this)

template <class Test_T>
class UnitTestWrapper
{
private:

	UnitTestWrapper();

public:

	static void DoTest()
	{
		const char* szTestName = NULL;

		try
		{
			szTestName = typeid(Test_T).name();
		}
		catch(...)
		{
			VSL_UTFAIL(NULL, NULL, _T("Get name for test failed"));
			return;
		}

		try
		{
			Test_T test(szTestName);
		}
		catch(const ExceptionExBase& rException)
		{
			VSL_UTFAILEX(szTestName, rException.GetErrorString(), rException.GetExpressionString(), rException.GetSourceFilenamePath(), rException.GetSourceLinenumber());
		}
		catch(const ExceptionBase& /*rException*/)
		{
			VSL_UTFAIL(szTestName, NULL, _T("Threw an non-ExceptionExImpl ExceptionBase"));
		}
		catch(...)
		{
			VSL_UTFAIL(szTestName, NULL, _T("Threw an unknown exception"));
		}
	}
};

class UnitTestListTerminator
{
private:

	const UnitTestListTerminator& operator=(const UnitTestListTerminator& rToCopy);

public:

	// Allow use of compiler generated constructors and destructor

	enum { NumTests = 0 };
};

template <class Test_T, class Next_T>
class UnitTestList
{
private:

	const UnitTestList& operator=(const UnitTestList& rToCopy);

public:

	enum { NumTests = Next_T::NumTests + 1 };

	UnitTestList():
		m_Next()
	{
		Test_T::DoTest();
	}

	// Allow use of compiler generated copy constructor and destructor

private:

	Next_T m_Next;

};

// FUTURE - this may get removed
class VirtualDestructorUnitTestHelperBase
{
private:

	const VirtualDestructorUnitTestHelperBase& operator=(const VirtualDestructorUnitTestHelperBase& rToCopy);

public:

	// Allow use of compiler generated constructors and destructor

	static int& GetRefcount()
	{
		static int iRefCount = 0;
		return iRefCount;
	}
};

// FUTURE - this may get removed, it doesn't work flawlessly
template <class BaseClass_T>
class VirtualDestructorUnitTestHelper :
	public VirtualDestructorUnitTestHelperBase,
	public BaseClass_T
{
private:

	const VirtualDestructorUnitTestHelper& operator=(const VirtualDestructorUnitTestHelper& rToCopy);

public:
	typedef BaseClass_T BaseClass;

	VirtualDestructorUnitTestHelper()
	{
		++(GetRefcount());
	}

	VirtualDestructorUnitTestHelper(const VirtualDestructorUnitTestHelper& rToCopy)
	{
		++(GetRefcount());
	}

	virtual ~VirtualDestructorUnitTestHelper()
	{
		--(GetRefcount());
	}
};

template <class DerivedClass_T>
class BaseClassHasVirtualDestructorUnitTest :
	UnitTestBase
{
private:

	BaseClassHasVirtualDestructorUnitTest(const BaseClassHasVirtualDestructorUnitTest& rToCopy);
	const BaseClassHasVirtualDestructorUnitTest& operator=(const BaseClassHasVirtualDestructorUnitTest& rToCopy);

public:

	explicit BaseClassHasVirtualDestructorUnitTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		VSL_UTCHECK_EX(DerivedClass_T::GetRefcount() == 0, _T("0 static ref count before construction"));
		{
			DerivedClass_T obj;
			VSL_UTCHECK_EX(DerivedClass_T::GetRefcount() == 1, _T("1 static ref count after construction"));
		}
		// obj destructor will be called when it goes out of scope.
		VSL_UTCHECK_EX(DerivedClass_T::GetRefcount() == 0, _T("0 static ref count after out of scope destruction and before construction via new"));
		DerivedClass_T::BaseClass* p = new DerivedClass_T;
		VSL_UTCHECK_EX(DerivedClass_T::GetRefcount() == 1, _T("1 static ref count after construction via new"));
		delete p;
		VSL_UTCHECK_EX(DerivedClass_T::GetRefcount() == 0, _T("0 static ref count after destruction via delete through base class pointer"));
	}
};

#define VSL_DEFINE_VIRTUAL_DESTRUCTOR_TEST_HELPER(toTest) \
class toTest##HasVirtualDestructorTestHelper : \
	public VirtualDestructorUnitTestHelper<toTest> \
{ \
public: \
	virtual ~toTest##HasVirtualDestructorTestHelper() {} \
}

#define VSL_UTRUN(test) VSL::UnitTestWrapper<test >::DoTest()

#define VSL_UTRUN_BASE_CLASS_HAS_VIRTUAL_DESTRUCTOR(toTest) \
	VSL_UTRUN(BaseClassHasVirtualDestructorUnitTest<toTest##HasVirtualDestructorTestHelper>)

#define VSL_VALIDVALUE_SIMPLE_VERIFY(type) reinterpret_cast<type>(-1)

// TODO - unit test this (everything is covered in usage at the moment, so low pri)
class MockBase
{
private:

VSL_DECLARE_NOT_COPYABLE(MockBase)

protected:

	MockBase()
	{
	}

	~MockBase()
	{
	}

public:

	template <class ValidValues_T>
	static void SetValidValues(const ValidValues_T& rValidValues)
	{
		ValidValues<const ValidValues_T*>() = &rValidValues;
	}

	template <class ValidValues_T>
	static void PushValidValues(const ValidValues_T& rValidValues, unsigned int iNumTimes = 1)
	{
		VSL_ASSERT(iNumTimes > 0);
		for(unsigned int i = 1; i <= iNumTimes; ++i)
		{
			GetValidValuesQueue<ValidValues_T>().push(rValidValues);
		}
	}

	template <class Signature_T, Signature_T Unique_T>
	static bool WasMethodCalled(int iTimesCalled)
	{
		return (Called<Signature_T, Unique_T>(false) == iTimesCalled);
	}

protected:

	template <class ValidValues_T>
	static const ValidValues_T& GetValidValues()
	{
		const ValidValues_T* pValidValues = ValidValues<const ValidValues_T*>();

		VSL_UTASSERTEX(pValidValues != NULL, _T("ValidValues was not set!"));
		VSL_CHECKBOOLEAN(pValidValues != NULL, E_UNEXPECTED);
#pragma warning(push) // compiler doesn't get that the above line will throw if pValidValues is NULL
#pragma warning(disable : 6011) // Dereferencing NULL pointer 'pValidValues'
		return *pValidValues;
#pragma warning(pop)
	}

	template <class ValidValues_T>
	static std::queue<ValidValues_T>& GetValidValuesQueue()
	{
		static std::queue<ValidValues_T> queue;
		return queue;
	}

	template <class Signature_T, Signature_T Unique_T>
	static int Called(bool bIncrement = true)
	{
		static int iCalled = 0;
		// This will be called with false to get the number of times it was called
		int iRet = iCalled;
		if (bIncrement)
		{
			++iCalled;
		}
		else
		{
			iCalled = 0;
		}
		return iRet;
	}

public:

#pragma warning(push)
#pragma warning(disable : 4480) // warning C4480: nonstandard extension used: specifying underlying type for enum 'VSL::MockBase::CheckPointerResult'
	enum CheckPointerResult : unsigned int
	{
		DoCheck = 0,
		Fail,
		SkipCheck
	};
#pragma warning(pop)

	template <class PointerType1_T, class PointerType2_T>
	static CheckPointerResult ShouldCheckPointerValue(PointerType1_T* pValidValue, const PointerType2_T* pPassedIn)
	{
		if(pValidValue == VSL_VALIDVALUE_SIMPLE_VERIFY(PointerType1_T*))
		{
			// Just make sure the value isn't null
			if(pPassedIn != NULL)
			{
				return SkipCheck;
			}
			else
			{
				VSL_UTHELPERCHECK(pPassedIn != NULL, VSL::UnitTestBase::GetCurrentUnitTestBase());
				return Fail;
			}
		}
		if(pValidValue == NULL)
		{
			if(pPassedIn == NULL)
			{
				return SkipCheck;
			}
			else
			{
				VSL_UTHELPERCHECK(pPassedIn == NULL, VSL::UnitTestBase::GetCurrentUnitTestBase());
				return Fail;
			}
		}
		if(pPassedIn == NULL)
		{
			VSL_UTHELPERCHECK(pPassedIn != NULL, VSL::UnitTestBase::GetCurrentUnitTestBase());
			return Fail;
		}
		return DoCheck;
	}

	static bool CheckPointerResultToBoolean(CheckPointerResult result)
	{
		return (result != Fail);
	}

	static bool CheckValidStringW(_In_opt_ const wchar_t * const pszValid, _In_opt_ const wchar_t * const pszParam)
	{
		bool bRet;
		if(pszValid == VSL_VALIDVALUE_SIMPLE_VERIFY(const wchar_t * const))
		{
			// Just make sure the value isn't null or empty string
			if(pszParam != NULL)
			{
				bRet = (pszParam[0] != L'\0');
			}
			else
			{
				bRet = false;
			}
		}
		else if(pszValid == NULL)
		{
			bRet = (pszParam == NULL);
		}
		else if(pszParam != NULL)
		{
			bRet = (0 == ::wcscmp(pszValid, pszParam));
		}
		else
		{
			bRet = false;
		}
		return bRet;
	}

	static bool CheckValidStringA(_In_opt_ const char * const pszValid, _In_opt_ const char * const pszParam)
	{
		bool bRet = true;
		if(pszValid == VSL_VALIDVALUE_SIMPLE_VERIFY(const char * const))
		{
			// Just make sure the value isn't null or empty string
			if(pszParam != NULL)
			{
				bRet = (pszParam[0] != '\0');
			}
			else
			{
				bRet = false;
			}
		}
		else if(pszValid == NULL)
		{
			bRet = (pszParam == NULL);
		}
		else if(pszParam != NULL)
		{
			bRet = (0 == ::strcmp(pszValid, pszParam));
		}
		else
		{
			bRet = false;
		}
		return bRet;
	}

	static bool CheckValidBSTR(const BSTR bstrValid, const BSTR bstrParam)
	{
		bool bRet = true;
		if(bstrValid == VSL_VALIDVALUE_SIMPLE_VERIFY(const BSTR))
		{
			// Just make sure the value isn't null or empty string
			if(bstrParam != NULL)
			{
				bRet = (bstrParam[0] != L'\0');
			}
			else
			{
				bRet = false;
			}
		}
		else if(bstrValid == NULL)
		{
			bRet = (bstrParam == NULL);
		}
		else
		{
			bRet = (VARCMP_EQ == ::VarBstrCmp(bstrValid, bstrParam, LOCALE_USER_DEFAULT, 0));
		}
		return bRet;
	}

	template <class PointerType1_T, class PointerType2_T>
	static bool CheckValidPointer(PointerType1_T pValidValue, PointerType2_T pPassedIn)
	{
		CheckPointerResult result = ShouldCheckPointerValue(pValidValue, pPassedIn);
		if(result == DoCheck)
		{
			return (*pValidValue == *pPassedIn);
		}
		return CheckPointerResultToBoolean(result);
	}

	template <class Interface1_T, class Interface2_T>
	static bool CheckValidInterfacePointer(Interface1_T* pValidValue, Interface2_T* pPassedIn)
	{
		CheckPointerResult result = ShouldCheckPointerValue(pValidValue, pPassedIn);
		if(result == DoCheck)
		{
			return (pValidValue == pPassedIn);
		}
		return CheckPointerResultToBoolean(result);
	}

	static bool CheckValidVoidPointer(void* pValidValue, void* pPassedIn, size_t iSizeInBytes)
	{
		CheckPointerResult result = ShouldCheckPointerValue(pValidValue, pPassedIn);
		if(result == DoCheck)
		{
			return (0 == ::memcmp(pPassedIn, pValidValue, iSizeInBytes));
		}
		return CheckPointerResultToBoolean(result);
	}

	static bool CheckValidSAFEARRAY(SAFEARRAY* pValidValue, SAFEARRAY* pPassedIn)
	{
		CheckPointerResult result = ShouldCheckPointerValue(pValidValue, pPassedIn);
		if(result == DoCheck)
		{
			// TODO implement this properly
			return true;
		}
		return CheckPointerResultToBoolean(result);
	}

	template <class Type>
	static void SetValidValue(Type* pValidValue, Type* pPassedIn)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			*pPassedIn = *pValidValue;
		}
	}

	template <class Type>
	static void SetValidInterface(Type* pValidValue, Type* pPassedIn)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			*pPassedIn = *pValidValue;
			if((*pPassedIn) != NULL)
			{
				(*pPassedIn)->AddRef();
			}
		}
	}

	static void SetValidBSTR(BSTR* pValidValue, BSTR* pPassedIn)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			VSL_UTHELPERCHECK(NULL != (*pPassedIn = ::SysAllocString(*(pValidValue))), VSL::UnitTestBase::GetCurrentUnitTestBase());
		}
	}

	static void SetValidVariant(VARIANT* pValidValue, VARIANT* pPassedIn)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			VSL_UTHELPERCHECK(S_OK == ::VariantCopy(pPassedIn, pValidValue), VSL::UnitTestBase::GetCurrentUnitTestBase());
		}
	}

	static void SetValidStringW(_Out_z_cap_(iLength) wchar_t* pValidValue, _In_z_ wchar_t* pPassedIn, size_t iLength)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			VSL_UTHELPERCHECK(0 == ::wcscpy_s(pPassedIn, iLength, pValidValue), VSL::UnitTestBase::GetCurrentUnitTestBase());
		}
	}

	static void SetValidStringA(_Out_z_cap_(iLength) char* pValidValue, _In_z_ char* pPassedIn, size_t iLength)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			VSL_UTHELPERCHECK(0 == ::strcpy_s(pPassedIn, iLength, pValidValue), VSL::UnitTestBase::GetCurrentUnitTestBase());
		}
	}

	static void SetValidVoidPointer(void* pValidValue, void* pPassedIn, size_t iByteLength)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			::memcpy(pPassedIn, pValidValue, iByteLength);
		}
	}

	static void SetValidSAFEARRAY(SAFEARRAY** pValidValue, SAFEARRAY** pPassedIn)
	{
		if(pPassedIn != NULL && pValidValue != NULL)
		{
			VSL_UTHELPERCHECK(S_OK == ::SafeArrayCopy(*pValidValue, pPassedIn), VSL::UnitTestBase::GetCurrentUnitTestBase());
		}
	}

private:

	template <class ValidValuesPtr_T>
	static ValidValuesPtr_T& ValidValues()
	{
		static ValidValuesPtr_T pValidValues = NULL;
		return pValidValues;
	}

};

// TODO - unit test these
#define VSL_DEFINE_MOCK_CLASS_TYPDEFS(className) \
	typedef className This; \
	typedef void (className::*ClassMethodNoArgs)(); \
	typedef void (className::*ClassMethod)(...);

#define VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(methodName) \
	Called<This::ClassMethodNoArgs, reinterpret_cast<This::ClassMethodNoArgs>(&This::methodName)>()

#define VSL_DEFINE_VALIDVALUES(type) \
	const type validValues = !GetValidValuesQueue<type>().empty() ? GetValidValuesQueue<type>().front() : GetValidValues<type>(); \
	if(!GetValidValuesQueue<type>().empty()) \
	{ \
		GetValidValuesQueue<type>().pop(); \
	}

#define VSL_NOTE_METHOD_WAS_CALLED(methodName) \
	Called<This::ClassMethod, reinterpret_cast<This::ClassMethod>(&This::methodName)>() \

#define VSL_DEFINE_MOCK_METHOD(methodName) \
	VSL_NOTE_METHOD_WAS_CALLED(methodName); \
	VSL_DEFINE_VALIDVALUES(methodName##ValidValues)

#define VSL_DEFINE_MOCK_METHOD_NOARGS(methodName) \
	VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(methodName); \
	VSL_DEFINE_VALIDVALUES(methodName##ValidValues)

#define VSL_NOTE_STATIC_METHOD_WAS_CALLED(methodName) \
	Called<void (*)(...), reinterpret_cast<void (*)(...)>(&This::methodName)>() \

#define VSL_DEFINE_MOCK_STATIC_METHOD(methodName) \
	VSL_NOTE_STATIC_METHOD_WAS_CALLED(methodName); \
	VSL_DEFINE_VALIDVALUES(methodName##ValidValues)

#define VSL_VALIDVALUD_STRINGW_LENGTH(sz) (sz == NULL ? 0 : ::wcslen(sz)+1)
#define VSL_VALIDVALUD_STRINGA_LENGTH(sz) (sz == NULL ? 0 : ::strlen(sz)+1)

#define VSL_CHECK_VALIDVALUE(value)	VSL_UTHELPERCHECK(validValues.value == value, VSL::UnitTestBase::GetCurrentUnitTestBase())
#if defined(UNICODE) || defined(_UNICODE)
#define VSL_CHECK_VALIDVALUE_STRING(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidStringW(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#else
#define VSL_CHECK_VALIDVALUE_STRING(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidStringA(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#endif
#define VSL_CHECK_VALIDVALUE_STRINGW(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidStringW(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_STRINGA(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidStringA(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_BSTR(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidBSTR(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_POINTER(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidPointer(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_PVOID(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidVoidPointer(validValues.value, value, validValues.value##_size_in_bytes), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_SAFEARRAY(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidSAFEARRAY(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(value) VSL_UTHELPERCHECK(VSL::MockBase::CheckValidInterfacePointer(validValues.value, value), VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_RANGE(value) VSL_UTHELPERCHECK(validValues.value##Min <= value && validValues.value##Max >= value, VSL::UnitTestBase::GetCurrentUnitTestBase())
#define VSL_CHECK_VALIDVALUE_HWND(value) VSL_UTHELPERCHECK(::IsWindow(value), VSL::UnitTestBase::GetCurrentUnitTestBase())

#define _VSL_CHECK_VALIDVALUE_IF(value) \
		{ \
		VSL::MockBase::CheckPointerResult result = VSL::MockBase::ShouldCheckPointerValue(validValues.value, value); \
		if(result == Fail) \
		{ \
			VSL_UTHELPERCHECK(false, VSL::UnitTestBase::GetCurrentUnitTestBase()); \
		} \
		else if(result == DoCheck) \
		{

#define _VSL_CHECK_VALIDVALUE_CLOSE_IF \
		} \
		}

#define VSL_CHECK_VALIDVALUE_ARRAY(value, sizeParam, sizeMember) \
		_VSL_CHECK_VALIDVALUE_IF(value) \
			VSL_UTHELPERCHECK(sizeParam == sizeMember, VSL::UnitTestBase::GetCurrentUnitTestBase()); \
			unsigned int iCount = static_cast<unsigned int>(sizeParam < sizeMember ? sizeParam : sizeMember); \
			for(unsigned int i = 0; i < iCount; ++i) \
			{ \
				VSL_UTHELPERCHECK(value[i] == validValues.value[i], VSL::UnitTestBase::GetCurrentUnitTestBase()); \
			} \
		_VSL_CHECK_VALIDVALUE_CLOSE_IF

#define VSL_CHECK_VALIDVALUE_MEMCMP(value, bytesParam, bytesMember) \
		_VSL_CHECK_VALIDVALUE_IF(value) \
			VSL_UTHELPERCHECK(bytesParam == bytesMember, VSL::UnitTestBase::GetCurrentUnitTestBase()); \
			VSL_UTHELPERCHECK(0 == ::memcmp(value, validValues.value, static_cast<size_t>(bytesParam < bytesMember ? bytesParam : bytesMember)), VSL::UnitTestBase::GetCurrentUnitTestBase()); \
		_VSL_CHECK_VALIDVALUE_CLOSE_IF

#define _VSL_SET_VALIDVALUE_IF(value) if(value != NULL && validValues.value != NULL)

#define VSL_SET_VALIDVALUE(value) VSL::MockBase::SetValidValue(validValues.value, value)

#define VSL_SET_VALIDVALUE_CONST(value, type) \
		_VSL_SET_VALIDVALUE_IF(value) \
		{ \
			*const_cast<type>(value) = *validValues.value; \
		}

#define VSL_SET_VALIDVALUE_PVOID(value)	VSL::MockBase::SetValidVoidPointer(validValues.value, value, validValues.value##_size_in_bytes)

#define VSL_SET_VALIDVALUE_INTERFACE(value)	VSL::MockBase::SetValidInterface(validValues.value, value)

#define VSL_SET_VALIDVALUE_INTERFACEARRAY(value, sizeParam, sizeMember) \
		_VSL_SET_VALIDVALUE_IF(value) \
		{ \
			unsigned int iCount = static_cast<unsigned int>(sizeParam < sizeMember ? sizeParam : sizeMember); \
			for(unsigned int i = 0; i < iCount; ++i) \
			{ \
				value[i] = validValues.value[i]; \
				if(value[i] != NULL) \
				{ \
					(value[i])->AddRef(); \
				} \
			} \
		}

#define VSL_SET_VALIDVALUE_MEMCPY(value, bytesParam, bytesMember) \
		_VSL_SET_VALIDVALUE_IF(value) \
		{ \
			::memcpy(value, validValues.value, static_cast<size_t>(bytesParam < bytesMember ? bytesParam : bytesMember)); \
		}

#define VSL_SET_VALIDVALUE_STRINGW(value, iLength) VSL::MockBase::SetValidStringW(validValues.value, value, iLength)

#define VSL_SET_VALIDVALUE_STRINGA(value, iLength) VSL::MockBase::SetValidStringA(validValues.value, value, iLength)

#define VSL_SET_VALIDVALUE_BSTR(value) VSL::MockBase::SetValidBSTR(validValues.value, value)

#define VSL_SET_VALIDVALUE_VARIANT(value) VSL::MockBase::SetValidVariant(validValues.value, value)

#define VSL_SET_VALIDVALUE_SAFEARRAY(value)	VSL::MockBase::SetValidSAFEARRAY(validValues.value, value)

#define VSL_SET_VALIDVALUE_REFERENCE(value) (value = validValues.value)

#define VSL_RETURN_VALIDVALUES() return validValues.retValue

#define VSL_CREATE_VALIDVALUES(CLASS, METHOD, variableName)	CLASS##MockImpl::METHOD##ValidValues variableName =

#define VSL_SET_VALIDVALUES(rValidValues) VSL::MockBase::SetValidValues(rValidValues)

#define VSL_PUSH_VALIDVALUES(rValidValues) VSL::MockBase::PushValidValues(rValidValues)

#define VSL_PUSH_VALIDVALUES_EX(rValidValues, iNumTimes) VSL::MockBase::PushValidValues(rValidValues, iNumTimes)

#define VSL_START_VALIDVALUES(CLASS, METHOD) \
		{ \
		__if_exists(CLASS##MockImpl) \
		{ \
		CLASS##MockImpl::METHOD##ValidValues __validValues__ \
		} \
		__if_not_exists(CLASS##MockImpl) \
		{ \
		CLASS::METHOD##ValidValues __validValues__ \
		} = \
		{

#define VSL_START_VALIDVALUES_STATIC(CLASS, METHOD) \
		{ \
		__if_exists(CLASS##MockImpl) \
		{ \
		static CLASS##MockImpl::METHOD##ValidValues __validValues__ \
		} \
		__if_not_exists(CLASS##MockImpl) \
		{ \
		static CLASS::METHOD##ValidValues __validValues__ \
		} = \
		{ \

#define VSL_END_VALIDVALUES_SET() \
		}; \
		VSL_SET_VALIDVALUES(__validValues__); \
		} 

#define VSL_END_VALIDVALUES_PUSH() \
		}; \
		VSL_PUSH_VALIDVALUES(__validValues__); \
		} 

#define VSL_END_VALIDVALUES_EX(iNumTimes) \
		}; \
		VSL_PUSH_VALIDVALUES_EX(__validValues__, iNumTimes); \
		} 

#define VSL_PUSH_VALIDVALUES1(CLASS, METHOD, param1) \
		VSL_START_VALIDVALUES(CLASS, METHOD) \
			param1 \
		VSL_END_VALIDVALUES_PUSH()

#define VSL_PUSH_VALIDVALUES2(CLASS, METHOD, param1, param2) \
		VSL_START_VALIDVALUES(CLASS, METHOD) \
			param1, \
			param2 \
		VSL_END_VALIDVALUES_PUSH()

#define VSL_PUSH_VALIDVALUES3(CLASS, METHOD, param1, param2, param3) \
		VSL_START_VALIDVALUES(CLASS, METHOD) \
			param1, \
			param2, \
			param3 \
		VSL_END_VALIDVALUES_PUSH()

#define VSL_PUSH_VALIDVALUES4(CLASS, METHOD, param1, param2, param3, param4) \
		VSL_START_VALIDVALUES(CLASS, METHOD) \
			param1, \
			param2, \
			param3, \
			param4 \
		VSL_END_VALIDVALUES_PUSH()

#define VSL_SET_VALIDVALUES1(CLASS, METHOD, param1) \
		VSL_START_VALIDVALUES_STATIC(CLASS, METHOD) \
			param1 \
		VSL_END_VALIDVALUES_SET()

#define VSL_SET_VALIDVALUES2(CLASS, METHOD, param1, param2) \
		VSL_START_VALIDVALUES_STATIC(CLASS, METHOD) \
			param1, \
			param2 \
		VSL_END_VALIDVALUES_SET()

#define VSL_SET_VALIDVALUES3(CLASS, METHOD, param1, param2, param3) \
		VSL_START_VALIDVALUES_STATIC(CLASS, METHOD) \
			param1, \
			param2, \
			param3 \
		VSL_END_VALIDVALUES_SET()

#define VSL_SET_VALIDVALUES4(CLASS, METHOD, param1, param2, param3, param4) \
		VSL_START_VALIDVALUES_STATIC(CLASS, METHOD) \
			param1, \
			param2, \
			param3, \
			param4 \
		VSL_END_VALIDVALUES_SET()

#define VSL_WAS_METHOD_CALLED(CLASS, METHOD, iNumTimes) (VSL::MockBase::WasMethodCalled<CLASS##MockImpl::ClassMethod, reinterpret_cast<CLASS##MockImpl::ClassMethod>(&CLASS##MockImpl::METHOD)>(iNumTimes))
#define VSL_WAS_METHODNOARGS_CALLED(CLASS, METHOD, iNumTimes) (VSL::MockBase::WasMethodCalled<CLASS##MockImpl::ClassMethodNoArgs, reinterpret_cast<CLASS##MockImpl::ClassMethodNoArgs>(&CLASS##MockImpl::METHOD)>(iNumTimes))

// TODO - move these elsewhere

#ifdef __ATLWIN_H__

class WindowMock :
	public MockBase
{
public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(WindowMock)

	WindowMock():
		m_bCreated(false)
	{
	}

	WindowMock(HWND hwnd):
		m_bCreated(hwnd == NULL ? false : true)
	{
	}

	HWND Create(LPCTSTR /*lpstrWndClass*/, HWND /*hWndParent*/, _U_RECT /*rect*/ = NULL, LPCTSTR /*szWindowName*/ = NULL,
			DWORD /*dwStyle*/ = 0, DWORD /*dwExStyle*/ = 0,
			_U_MENUorID /*MenuOrID*/ = 0U, LPVOID /*lpCreateParam*/ = NULL)
	{
		m_bCreated = true;
		return NULL;
	}

	HWND Create(HWND /*hWndParent*/, LPARAM /*dwInitParam*/ = NULL)
	{
		return InternalCreate();
	}

	struct InternalCreateValidValues
	{
		// In
		// TODO
		// Out
		HWND retValue;
		DWORD dwLastError;
	};

	// Mock method infrastructure doesn't work with overloaded methods
	HWND InternalCreate()
	{
		VSL_DEFINE_MOCK_METHOD(InternalCreate);

		m_bCreated = (validValues.retValue == NULL ? false : true);

		::SetLastError(validValues.dwLastError);

		VSL_RETURN_VALIDVALUES();
	}

	struct CreateDialogParamValidValues
	{
		// In
		HINSTANCE hInstance;
		LPCTSTR lpTemplateName;
		HWND hWndParent;
		DLGPROC lpDialogFunc;
		LPARAM dwInitParam;
		// Out
		DWORD dwErrorCode;
	};

	void CreateDialogParam(
		HINSTANCE hInstance,
		LPCTSTR lpTemplateName,
		HWND hWndParent,
		DLGPROC lpDialogFunc,
		LPARAM dwInitParam)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDialogParam);

		VSL_CHECK_VALIDVALUE(hInstance);
		VSL_CHECK_VALIDVALUE(lpTemplateName);
		VSL_CHECK_VALIDVALUE(hWndParent);
		VSL_CHECK_VALIDVALUE(lpDialogFunc);
		VSL_CHECK_VALIDVALUE(dwInitParam);

		::SetLastError(validValues.dwErrorCode);

		m_bCreated = validValues.dwErrorCode == 0 ? true : false;
	}

	struct MoveWindowValidValues
	{
		// In
		int x;
		int y;
		int nWidth;
		int nHeight;
		BOOL bRepaint;
		// Out
		BOOL bRet;
	};

	BOOL MoveWindow(
		int x,
		int y,
		int nWidth,
		int nHeight,
		BOOL bRepaint = TRUE)
	{
		VSL_DEFINE_MOCK_METHOD(MoveWindow);

		VSL_CHECK_VALIDVALUE(x);
		VSL_CHECK_VALIDVALUE(y);
		VSL_CHECK_VALIDVALUE(nWidth);
		VSL_CHECK_VALIDVALUE(nHeight);
		VSL_CHECK_VALIDVALUE(bRepaint);

		return validValues.bRet;
	}

	struct ShowWindowValidValues
	{
		// In
		int nCmdShow;
		// Out
		BOOL bRet;
	};

	BOOL ShowWindow(int nCmdShow)
	{
		VSL_DEFINE_MOCK_METHOD(ShowWindow);

		VSL_CHECK_VALIDVALUE(nCmdShow);

		return validValues.bRet;
	}

	struct IsDialogMessageValidValues
	{
		// In
		LPMSG lpMsg;
		// Out
		BOOL bRet;
	};
	
	BOOL IsDialogMessage(LPMSG lpMsg)
	{
		VSL_DEFINE_MOCK_METHOD(IsDialogMessage);

		VSL_CHECK_VALIDVALUE(lpMsg);

		return validValues.bRet;
	}

	struct SendDlgItemMessageValidValues
	{
		// In
		int nID;
		UINT message;
		WPARAM wParam;
		LPARAM lParam;
		// Out
		LRESULT retValue;
	};

	LRESULT SendDlgItemMessage(
		int nID,
		UINT message,
		WPARAM wParam = 0,
		LPARAM lParam = 0)
	{
		VSL_DEFINE_MOCK_METHOD(SendDlgItemMessage);

		VSL_CHECK_VALIDVALUE(nID);
		VSL_CHECK_VALIDVALUE(message);
		VSL_CHECK_VALIDVALUE(wParam);
		VSL_CHECK_VALIDVALUE(lParam);

		return validValues.retValue;
	}

	struct GetDlgItemValidValues
	{
		// In
		int nID;
		// Out
		HWND retValue;
	};

	HWND GetDlgItem(int nID) const
	{
		VSL_DEFINE_MOCK_METHOD(GetDlgItem);

		VSL_CHECK_VALIDVALUE(nID);

		return validValues.retValue;
	}

	struct SetWindowTextValidValues
	{
		// In
		LPCTSTR lpszString;
		// Out
		BOOL retValue;
	};

	BOOL SetWindowText(LPCTSTR lpszString)
	{
		VSL_DEFINE_MOCK_METHOD(SetWindowText);

		VSL_CHECK_VALIDVALUE_STRING(lpszString);

		VSL_RETURN_VALIDVALUES();
	}

	HWND GetHWND()
	{
		return reinterpret_cast<HWND>(m_bCreated);
	}


	template<class WPARAM_T, class LPARAM_T>
	struct SendMessageValidValues
	{
		UINT uMsg;
		WPARAM_T wParam;
		LPARAM_T lParam;
		LRESULT retValue;
	};

	template<class WPARAM_T, class LPARAM_T>
	class SendMessageTraits
	{
	public:
		static void wParam(const SendMessageValidValues<WPARAM_T, LPARAM_T>& /*validValues*/, WPARAM_T /*wParam*/)
		{
		}
		static void lParam(const SendMessageValidValues<WPARAM_T, LPARAM_T>& /*validValues*/, LPARAM_T /*lParam*/)
		{
		}
	};

	template<>
	class SendMessageTraits<int, int>
	{
	public:
		static void wParam(const SendMessageValidValues<int, int>& validValues, int wParam)
		{
			VSL_CHECK_VALIDVALUE(wParam);
		}
		static void lParam(const SendMessageValidValues<int , int>& validValues, int lParam)
		{
			VSL_CHECK_VALIDVALUE(lParam);
		}
	};

	template<>
	class SendMessageTraits<int, IUnknown**>
	{
	public:
		static void wParam(const SendMessageValidValues<int, IUnknown**>& /*validValues*/, int /*wParam*/)
		{
		}
		static void lParam(const SendMessageValidValues<int, IUnknown**>& validValues, IUnknown** lParam)
		{
			VSL_SET_VALIDVALUE_INTERFACE(lParam);
		}
	};

	template<>
	class SendMessageTraits<unsigned int, WCHAR*>
	{
	public:
		static void wParam(const SendMessageValidValues<unsigned int, WCHAR*>& /*validValues*/, int /*wParam*/)
		{
		}
		static void lParam(const SendMessageValidValues<unsigned int, WCHAR*>& validValues, WCHAR* lParam)
		{
			// The first word of the lParam tells us the size of the array
			WORD cchText = reinterpret_cast<WORD *>(lParam)[0];
			::wcscpy_s(lParam, cchText, validValues.lParam);
		}
	};

#ifdef _RICHEDIT_
	template<>
	class SendMessageTraits<int, EDITSTREAM*>
	{
	public:
		static void wParam(const SendMessageValidValues<int, EDITSTREAM*>& validValues, int wParam)
		{
			VSL_CHECK_VALIDVALUE(wParam);
		}
		static void lParam(const SendMessageValidValues<int, EDITSTREAM*>& validValues, EDITSTREAM* lParam)
		{
			VSL_SET_VALIDVALUE(lParam);
		}
	};
#endif // _RICHEDIT_

	template<class WPARAM_T, class LPARAM_T>
	LRESULT SendMessage(UINT uMsg, WPARAM_T wParam, LPARAM_T lParam) const
	{
		Called<This::ClassMethod, reinterpret_cast<This::ClassMethod>(&This::SendMessage<WPARAM_T, LPARAM_T>)>();

		if(GetValidValuesQueue<SendMessageValidValues<WPARAM_T, LPARAM_T> >().empty())
		{
			return 0;
		}

		const SendMessageValidValues<WPARAM_T, LPARAM_T> validValues = GetValidValuesQueue<SendMessageValidValues<WPARAM_T, LPARAM_T> >().front();
		GetValidValuesQueue<SendMessageValidValues<WPARAM_T, LPARAM_T> >().pop();

		VSL_CHECK_VALIDVALUE(uMsg);

		SendMessageTraits<WPARAM_T, LPARAM_T>::wParam(validValues, wParam);

		SendMessageTraits<WPARAM_T, LPARAM_T>::lParam(validValues, lParam);

		VSL_RETURN_VALIDVALUES();
	}

	UINT_PTR SetTimer(UINT_PTR /*nIDEvent*/, UINT /*nElapse*/, void (CALLBACK* /*lpfnTimer*/)(HWND, UINT, UINT_PTR, DWORD) = NULL)
	{
		return 1;
	}

	LONG_PTR SetWindowLongPtr(int /*nIndex*/, LONG_PTR /*dwNewLong*/)
	{
		return NULL;
	}

	struct GetWindowLongPtrWValidValues
	{
		int nIndex;
		LONG_PTR retValue;
	};

	LONG_PTR GetWindowLongPtr(int nIndex) const
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowLongPtrW);

		VSL_CHECK_VALIDVALUE(nIndex);

		VSL_RETURN_VALIDVALUES();
	}

	BOOL DestroyWindow()
	{
		return TRUE;
	}

	HWND SetFocus()
	{
		return NULL;
	}

	BOOL InvalidateRect(LPCRECT /*lpRect*/, BOOL /*bErase*/ = TRUE)
	{
		return TRUE;
	}

	BOOL UpdateWindow()
	{
		return TRUE;
	}

	LRESULT CallWindowProc(
		_In_ WNDPROC /*pWndProc*/,
		_In_ UINT /*msg*/,
		_In_ WPARAM /*wParam*/,
		_In_ LPARAM /*lParam*/)
	{
		return 0;
	}

	BOOL ClientToScreen(LPPOINT /*lpPoint*/) const
	{
		return TRUE;
	}

	bool IsWindow()
	{
		return m_bCreated;
	}

	static HWND GetActiveWindow()
	{
		return reinterpret_cast<HWND>(1);
	}

	DWORD GetWindowProcessID()
	{
		return ::GetCurrentProcessId();
	}

	BOOL KillTimer(_In_ UINT_PTR/*uIDEvent*/)
	{
		return TRUE;
	}

protected:
	bool m_bCreated;
};

class CursorMock
{

VSL_DECLARE_NOT_COPYABLE(CursorMock)

private:

	// FUTURE - could add default construction, not needed currently
	CursorMock();

public:

	CursorMock(_In_ LPWSTR /*szCursorName*/, HINSTANCE /*hInstance*/ = NULL)
	{
	}

	~CursorMock()
	{
	}

	HCURSOR Activate()
	{
		return NULL;
	}

};

class KeyboardMock :
	public MockBase
{
public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(KeyboardMock)

	struct IsKeyDownValidValues
	{
		int nVirtKey;
		bool retValue;
	};

	static bool IsKeyDown(_In_ int nVirtKey)
	{
		VSL_DEFINE_MOCK_STATIC_METHOD(IsKeyDown);

		VSL_CHECK_VALIDVALUE(nVirtKey);

		VSL_RETURN_VALIDVALUES();
	}
};

// REVIEW - is this necessary, or can the normal class be used with a little tweaking?
template <class Control_T, class WindowBase_T = WindowMock>
class Win32ControlContainerMock :
	public WindowBase_T
{
public:
	typedef Control_T Control;

	static const unsigned short iContainedControlID = 1;

	__if_exists(_U_RECT)
	{
	void Create(HWND hWndParent, _U_RECT rect)
	{
		m_bCreated = true;
		m_Control.Create(hWndParent, iContainedControlID, rect);
	}
	}

// Can't have a dependency on VSLWindows.h here, need to move these mocks elsewhere
//VSL_BEGIN_MSG_MAP(Win32ControlContainer)
BEGIN_MSG_MAP(Win32ControlContainer)
	MESSAGE_HANDLER(WM_SIZE, OnSize)
//	MESSAGE_HANDLER(WM_SETFOCUS, OnSetFocus)
//	REFLECT_NOTIFICATIONS()
//VSL_END_MSG_MAP()
END_MSG_MAP()

	LRESULT OnSize(UINT uMsg, WPARAM wParam, LPARAM lParam, BOOL& bHandled)
	{
		(uMsg, wParam, lParam, bHandled);
		return 0;
	}
protected:
	Control_T& GetControl()
	{
		return m_Control;
	}

	void Destroy()
	{
		__if_exists(Control::Destroy)
		{
			m_Control.Destroy();
		}
	}

private:
	Control_T m_Control;
};

#endif // __ATLWIN_H__

class FileMock :
	public MockBase
{
public:

	VSL_DEFINE_MOCK_CLASS_TYPDEFS(FileMock);

	FileMock() :
		m_szFullPathName(),
		bHandleSet(false)
	{
	}

	// Does not open the file handle
	explicit FileMock(_In_z_ const wchar_t* szFullPathName) :
		m_szFullPathName(szFullPathName),
		bHandleSet(false)
	{
	}

	const ATL::CStringW& GetFullPathName() const
	{
		return m_szFullPathName;
	}

	ATL::CStringW& GetFullPathName()
	{
		return m_szFullPathName;
	}

	operator const wchar_t*() const
	{
		return m_szFullPathName;
	}

	struct IsFileReadOnlyValidValues
	{
		bool retValue;
	};

	bool IsFileReadOnly()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsFileReadOnly);

		VSL_RETURN_VALIDVALUES();
	}

	void Create(
		_In_ DWORD dwDesiredAccess,
		_In_ DWORD dwShareMode,
		_In_ DWORD dwCreationDisposition,
		_In_ DWORD dwFlagsAndAttributes = FILE_ATTRIBUTE_NORMAL,
		_In_opt_ LPSECURITY_ATTRIBUTES lpsa = NULL,
		_In_opt_ HANDLE hTemplateFile = NULL)
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(Close);

		VSL_CHECKBOOLEAN(!m_szFullPathName.IsEmpty(), E_FAIL);

		bHandleSet = true;

		(dwDesiredAccess, dwShareMode, dwCreationDisposition, dwFlagsAndAttributes, lpsa, hTemplateFile);
	}

	struct IsZeroLengthValidValues
	{
		bool retValue;
	};

	bool IsZeroLength()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsZeroLength);

		VSL_RETURN_VALIDVALUES();
	}

	void Close()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(Close);

		bHandleSet = false;
	}

	operator HANDLE()
	{
		return bHandleSet ? reinterpret_cast<HANDLE>(1) : NULL;
	}

	struct GetFileTypeValidValues
	{
		DWORD retValue;
	};

	DWORD GetFileType()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetFileType);

		VSL_RETURN_VALIDVALUES();
	}

	bool IsOnDisk()
	{
		return FILE_TYPE_DISK == GetFileType();
	}

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512)  // assignment operator could not be generated
	struct ReadValidValues
	{
		LPVOID pBuffer;
		DWORD nBufSize;
		DWORD& nBytesRead;
		HRESULT hrException;
	};
#pragma warning(pop)

	void Read(
		_Out_bytecap_(nBufSize) LPVOID pBuffer,
		_In_ DWORD nBufSize,
		_Out_ DWORD& nBytesRead)
	{
		VSL_DEFINE_MOCK_METHOD(Read);

		VSL_CHECK_VALIDVALUE(nBufSize);

		VSL_SET_VALIDVALUE_REFERENCE(nBytesRead);

		VSL_CHECKHRESULT(validValues.hrException);

		VSL_SET_VALIDVALUE_MEMCPY(pBuffer, nBufSize, validValues.nBufSize);
	}

	struct WriteValidValues
	{
		LPCVOID pBuffer;
		DWORD nBufSize;
		DWORD* pnBytesWritten;
		HRESULT hrException;
	};

	void Write(
		_In_bytecount_(nBufSize) LPCVOID pBuffer,
		_In_ DWORD nBufSize,
		_Out_opt_ DWORD* pnBytesWritten = NULL)
	{
		VSL_DEFINE_MOCK_METHOD(Write);

		VSL_CHECK_VALIDVALUE(pBuffer);

		VSL_CHECK_VALIDVALUE(nBufSize);

		VSL_CHECKHRESULT(validValues.hrException);

		VSL_SET_VALIDVALUE(pnBytesWritten);
	}

	void Seek(_In_ LONGLONG nOffset, _In_ DWORD dwFrom = FILE_CURRENT)
	{
		(nOffset, dwFrom);
	}

	ATL::CStringW m_szFullPathName;
	bool bHandleSet;
};

} // namespace VSL

#endif VSLUNITTEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
