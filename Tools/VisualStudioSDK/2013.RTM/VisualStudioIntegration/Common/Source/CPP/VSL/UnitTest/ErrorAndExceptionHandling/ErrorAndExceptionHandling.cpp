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

#define VSL_ASSERT _ASSERTE
#define VSL_ASSERTEX(exp, szMsg) _ASSERT_BASE(exp, szMsg)
#define VSL_TRACE ATLTRACE

#include "VSLUnitTest.h"
#include "VSLShortNameDefines.h"
#include "VSLExceptions.h"
#include "VSLExceptionHandlers.h"
#include "VSLErrorHandlers.h"

using namespace VSL;

static const TCHAR g_szExpression[] = L"test exp";
static const TCHAR g_szFilename[] = L"test.cpp";
static const TCHAR g_iLineNumber = 1;
static const TCHAR g_szExtra[] = L"test message";
static const HANDLE g_hNotNull = reinterpret_cast<HANDLE>(1);

/*******************************************************************************
Validate VSLExceptions.h
*******************************************************************************/

class ExceptionBaseHasVirtualDestructorTestHelper :
	public VirtualDestructorUnitTestHelper<ExceptionBase>
{
public:
	virtual ~ExceptionBaseHasVirtualDestructorTestHelper() {}

	virtual HRESULT GetHRESULT() const
	{
		return HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY);
	}
};

class ExceptionBaseBaseTest :
	public UnitTestBase
{
protected:
	void TestExceptionBase(const ExceptionBase& toTest)
	{
		UTCHK(toTest.GetHRESULT() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(static_cast<HRESULT>(toTest) == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(toTest.GetWin32Error() == ERROR_OUTOFMEMORY);
		UTCHK(static_cast<DWORD>(toTest) == ERROR_OUTOFMEMORY);
		// TODO - test ReportError
	}

public:
	ExceptionBaseBaseTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
	}
};

class ExceptionBaseTest :
	public ExceptionBaseBaseTest
{
public:
	ExceptionBaseTest(_In_opt_ const char* const szTestName):
		ExceptionBaseBaseTest(szTestName)
	{
		ExceptionBaseHasVirtualDestructorTestHelper testObj;
		TestExceptionBase(testObj);
	}
};

class unknown_exception : public std::exception
{
public:
	unknown_exception(const char *_Message = "bad exception")
		_THROW0()
		: exception(_Message)
		{	// construct from message string
		}
	virtual ~unknown_exception() _THROW0()
		{	// destroy the object
		}
};

template <class Exception_T, ExceptionStd::TypeID customTypeID, HRESULT hrExpected>
class ExceptionStdConstructorTest :
	UnitTestBase
{
public:
	void ValidateObject(const ExceptionStd& rToValidate, const TCHAR* szTestStep)
	{
		UTCHKEX(rToValidate.GetStdExceptionTypeID() == customTypeID, szTestStep);
		UTCHKEX(rToValidate.GetHRESULT() == hrExpected, szTestStep);
	}

	ExceptionStdConstructorTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		Exception_T parm1("test message");

		ExceptionStd testObj(parm1);
		ValidateObject(testObj, _T("Test the \"const std::exception&\" constructor"));

		ExceptionStd testCopyObj = testObj;
		ValidateObject(testCopyObj, _T("Test the copy constructor"));
	}
};

template <ExceptionStd::TypeID customTypeID, HRESULT hrExpected>
class ExceptionStdConstructorTest<std::bad_alloc, customTypeID, hrExpected> :
	UnitTestBase
{
public:
	void ValidateObject(const ExceptionStd& rToValidate, const TCHAR* szTestStep)
	{
		UTCHKEX(rToValidate.GetStdExceptionTypeID() == customTypeID, szTestStep);
		UTCHKEX(rToValidate.GetHRESULT() == hrExpected, szTestStep);
	}

	ExceptionStdConstructorTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		std::bad_alloc parm1;

		ExceptionStd testObj(parm1);
		ValidateObject(testObj, _T("Test the \"const std::exception&\" constructor"));

		ExceptionStd testCopyObj = testObj;
		ValidateObject(testCopyObj, _T("Test the copy constructor"));
	}
};

#define ADD_CEXCEPTIONSTD_TEST(exception, typeID, hr) UnitTestList<UnitTestWrapper<ExceptionStdConstructorTest<exception, typeID, hr> >,

typedef 
	ADD_CEXCEPTIONSTD_TEST(unknown_exception, ExceptionStd::UNKNOWN, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::exception, ExceptionStd::EXCEPTION, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::bad_exception, ExceptionStd::BAD_EXCEPTION, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::bad_alloc, ExceptionStd::BAD_ALLOC, E_OUTOFMEMORY)
	ADD_CEXCEPTIONSTD_TEST(std::bad_cast, ExceptionStd::BAD_CAST, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::bad_typeid, ExceptionStd::BAD_TYPEID, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::__non_rtti_object, ExceptionStd::__NON_RTTI_OBJECT, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::logic_error, ExceptionStd::LOGIC_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::domain_error, ExceptionStd::DOMAIN_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::invalid_argument, ExceptionStd::INVALID_ARGUMENT, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::length_error, ExceptionStd::LENGTH_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::out_of_range, ExceptionStd::OUT_OF_RANGE, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::runtime_error, ExceptionStd::RUNTIME_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::range_error, ExceptionStd::RANGE_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::overflow_error, ExceptionStd::OVERFLOW_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::underflow_error, ExceptionStd::UNDERFLOW_ERROR, DISP_E_EXCEPTION)
	ADD_CEXCEPTIONSTD_TEST(std::ios_base::failure, ExceptionStd::IOS_BASE_FAILURE, DISP_E_EXCEPTION)
	UnitTestListTerminator> > > > > > > > > > > > > > > > >
		ExceptionStdUnitTestList;

// This will fail to compile if the number of entries above does not match
// the number of enums
_STATIC_ASSERT(ExceptionStdUnitTestList::NumTests == ExceptionStd::NUM_EXCEPTION_TYPES);

#if 0 // Add back if corresponding class is added back
class ExtraTypeContainerStringTest :
	public UnitTestBase
{
public:
	ExtraTypeContainerStringTest(const char* const szTestName):
		UnitTestBase(szTestName)
	{
		ExtraDataTypeContainerString::Type szDefault = ExtraDataTypeContainerString::DefaultValue();
		UTCHKEX(szDefault == NULL, NULL);
	}
};
#endif

// TODO - test ErrorMessageFromResource and ExtraDataTypeContainerResourceString

class ErrorVirtualDestructorTestHelper :
	public VirtualDestructorUnitTestHelperBase,
	public ExceptionExImpl<HRESULT>
{
public:
	typedef ExceptionExImpl<HRESULT> BaseClass;

	ErrorVirtualDestructorTestHelper():
		VirtualDestructorUnitTestHelperBase(),
		BaseClass(
			HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY),
			g_szExpression,
			g_szFilename,
			g_iLineNumber)
	{
		++(GetRefcount());
	}

	ErrorVirtualDestructorTestHelper(const ErrorVirtualDestructorTestHelper& rToCopy):
		VirtualDestructorUnitTestHelperBase(rToCopy),
		BaseClass(rToCopy)
	{
	}

	virtual ~ErrorVirtualDestructorTestHelper()
	{
		--(GetRefcount());
	}

	virtual HRESULT GetHRESULT() const
	{
		return m_expValue;
	}
};

class CErrorBaseTest :
	public ExceptionBaseBaseTest
{
protected:

	template<class ExceptionExImplSpec_T>
	void TestCErrorObject(const ExceptionExImplSpec_T& rToTest)
	{
		TestExceptionBase(rToTest);
		UTCHK(0 == ::memcmp(rToTest.GetExpressionString(), g_szExpression, ARRAYSIZE(g_szExpression)));
		UTCHK(0 == ::memcmp(rToTest.GetExpressionStringTyped(), g_szExpression, ARRAYSIZE(g_szExpression)));
		UTCHK(0 == ::memcmp(rToTest.GetSourceFilenamePath(), g_szFilename, ARRAYSIZE(g_szFilename)));
		UTCHK(0 == ::memcmp(rToTest.GetSourceFilenamePathTyped(), g_szFilename, ARRAYSIZE(g_szFilename)));
		UTCHK(rToTest.GetSourceLinenumber() == g_iLineNumber);
		UTCHK(CString(rToTest.GetErrorString()) == CString(ExceptionExImplSpec_T::ExtraDataTypeContainer::DefaultString()));
		UTCHK(rToTest.GetExtraData() == ExceptionExImplSpec_T::ExtraDataTypeContainer::DefaultValue());
	}

	template<class CErrorDerived_T>
	void TestCError()
	{
		CErrorDerived_T testObj;
		TestCErrorObject<CErrorDerived_T::BaseClass>(testObj);
		CErrorDerived_T testObjCopy(testObj);
		TestCErrorObject<CErrorDerived_T::BaseClass>(testObjCopy);
	}

public:
	CErrorBaseTest(_In_opt_ const char* const szTestName):
		ExceptionBaseBaseTest(szTestName)
	{
	}
};

class ExceptionExImplTest :
	public CErrorBaseTest
{
public:
	ExceptionExImplTest(_In_opt_ const char* const szTestName):
		CErrorBaseTest(szTestName)
	{
		TestCError<ErrorVirtualDestructorTestHelper>();
	}
};

class ExceptionHRESULTVirtualDestructorTestHelper :
	public VirtualDestructorUnitTestHelperBase,
	public ExceptionHRESULT<>
{
public:
	typedef ExceptionHRESULT<> BaseClass_T_t;

	ExceptionHRESULTVirtualDestructorTestHelper():
		BaseClass_T_t(
			HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY),
			g_szExpression,
			g_szFilename,
			g_iLineNumber)
	{
		++(GetRefcount());
	}

	virtual ~ExceptionHRESULTVirtualDestructorTestHelper()
	{
		--(GetRefcount());
	}
};

class ExceptionHRESULTTest :
	public ExceptionExImplTest
{
public:
	ExceptionHRESULTTest(_In_opt_ const char* const szTestName):
		ExceptionExImplTest(szTestName)
	{
		TestCError<ExceptionHRESULTVirtualDestructorTestHelper>();
	}
};

class ExceptionWin32VirtualDestructorTestHelper :
	public VirtualDestructorUnitTestHelperBase,
	public ExceptionWin32<>
{
public:
	typedef ExceptionWin32<> BaseClass_T_t;

	ExceptionWin32VirtualDestructorTestHelper():
		BaseClass_T_t(
			ERROR_OUTOFMEMORY,
			g_szExpression,
			g_szFilename,
			g_iLineNumber)
	{
		++(GetRefcount());
	}

	virtual ~ExceptionWin32VirtualDestructorTestHelper()
	{
		--(GetRefcount());
	}
};

class ExceptionWin32Test :
	public ExceptionExImplTest
{
public:
	ExceptionWin32Test(_In_opt_ const char* const szTestName):
		ExceptionExImplTest(szTestName)
	{
		TestCError<ExceptionWin32VirtualDestructorTestHelper>();
	}
};

/*******************************************************************************
Validate VSLExceptionHandlers.h
*******************************************************************************/

class VSL_STDMETHODTest :
	public UnitTestBase
{
protected:

	HRESULT Test_STDMETHOD_EX()
	{
		VSL_STDMETHODTRY_EX(E_FAIL)
		{
			UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_FAIL);
			VSL_SET_STDMETHOD_HRESULT(S_OK);
			UTCHK(VSL_GET_STDMETHOD_HRESULT() == S_OK);
			throw 0; // Doesn't matter what is thrown so long as it isn't derived from VSL::ExceptionBase or std::exception
		}
		VSL_STDMETHODCATCH_EX(VSL_STDMETHOD_ON_CATCH_CEXCEPTION, VSL_STDMETHOD_ON_CATCH_STDEXCEPTION, VSL_STDMETHOD_ON_CATCH_ALL)
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_STDMETHOD()
	{
		VSL_STDMETHODTRY
		{
			UTCHK(VSL_GET_STDMETHOD_HRESULT() == S_OK);
			VSL_SET_STDMETHOD_HRESULT(E_FAIL);
			UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_FAIL);
			throw 0; // Doesn't matter what is thrown so long as it isn't derived from VSL::ExceptionBase or std::exception
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_STDMETHODCATCH_CErrorHRESULT()
	{
		VSL_STDMETHODTRY
		{
			throw ExceptionHRESULT<>(E_FAIL, g_szExpression, g_szFilename, g_iLineNumber);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_STDMETHODCATCH_CErrorWin32Code()
	{
		VSL_STDMETHODTRY
		{
			throw ExceptionWin32<>(ERROR_OUTOFMEMORY, g_szExpression, g_szFilename, g_iLineNumber);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_STDMETHODCATCH_ExceptionStd()
	{
		VSL_STDMETHODTRY
		{
			throw ExceptionStd(std::bad_alloc());
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_STDMETHODCATCH_CAtlException()
	{
		VSL_STDMETHODTRY
		{
			throw CAtlException(E_UNEXPECTED);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_STDMETHODTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(Test_STDMETHOD_EX() == E_UNEXPECTED);
		UTCHK(Test_STDMETHOD() == E_UNEXPECTED);
		UTCHK(Test_STDMETHODCATCH_CErrorHRESULT() == E_FAIL);
		UTCHK(Test_STDMETHODCATCH_CErrorWin32Code() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(Test_STDMETHODCATCH_ExceptionStd() == E_OUTOFMEMORY);
		UTCHK(Test_STDMETHODCATCH_CAtlException() == E_UNEXPECTED);
	}
};

/*******************************************************************************
Validate VSLErrorHandlers.h
*******************************************************************************/

#include "VSLErrorHandlersBase.h"

class EvaluatorsTest :
	public UnitTestBase
{
protected:
	template <class EVALUATOR_T, typename EVALUATOR_T::ExpressionType EXPVALUE_T>
	void TestEvaluator()
	{
		EVALUATOR_T::ExpressionType testExp = EXPVALUE_T;
		UTCHK(EVALUATOR_T::Evaluate(testExp));
	}
public:
	EvaluatorsTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		TestEvaluator<BooleanEvaluator, false>();
		TestEvaluator<BOOLEvaluator, FALSE>();
		TestEvaluator<DWORDIsZeroEvaluator, 0>();
		TestEvaluator<HANDLEIsNullEvaluator, NULL>();
		TestEvaluator<HANDLEIsInvalidEvaluator, INVALID_HANDLE_VALUE>();
		TestEvaluator<HRESULTEvaluator, E_FAIL>();
		TestEvaluator<Win32Evaluator, ERROR_OUTOFMEMORY>();
	}
};

class OverridesTest :
	public UnitTestBase
{
public:
	OverridesTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef DefaultOverride<HRESULT> DefaultExpressionValueOverride;
		DefaultExpressionValueOverride::OverrideType hr = 
			DefaultExpressionValueOverride::Override(E_FAIL);
		UTCHK(hr == E_FAIL);

		typedef ConstantOverride<HRESULT, bool, false> ConstantExpressionValueOverride;
		ConstantExpressionValueOverride::OverrideType b = 
			ConstantExpressionValueOverride::Override(E_FAIL);
		UTCHK(b == false);

		typedef GetLastErrorOverride<HRESULT> GLEExpressionValueOverride;
		::SetLastError(ERROR_OUTOFMEMORY);
		GLEExpressionValueOverride::OverrideType dw = 
			GLEExpressionValueOverride::Override(E_FAIL);
		UTCHK(dw == ERROR_OUTOFMEMORY);

		typedef DefaultHRESULTOverride x;
		typedef DefaultWin32Override y;

		UTCHK(VSL_OVERRIDE_HRESULT_CONSTANT(bool, E_FAIL)::Override(true) == E_FAIL);
	}
};

class ProcessorsTest :
	public UnitTestBase
{
protected:

	HRESULT Test_HRESULTProcessor()
	{
		VSL_STDMETHODTRY
		{
			HRESULTProcessor::ProcessError(VSL::ExceptionHRESULT<>(E_FAIL, g_szExpression, g_szFilename, g_iLineNumber));
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_Win32Processor()
	{
		VSL_STDMETHODTRY
		{
			Win32Processor::ProcessError(VSL::ExceptionWin32<>(ERROR_OUTOFMEMORY, g_szExpression, g_szFilename, g_iLineNumber));
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	ProcessorsTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		UTCHK(Test_HRESULTProcessor() == E_FAIL);
		UTCHK(Test_Win32Processor() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
	}
};

template <class TRAITS_T>
void CompileTraits()
{
	typedef TRAITS_T::ExpressionEvaluator ExpressionEvaluator;
	typedef TRAITS_T::ExpressionType ExpressionType;
	typedef TRAITS_T::ExpressionValueOverride ExpressionValueOverride;
	typedef TRAITS_T::Exception Exception;
	typedef TRAITS_T::ExtraDataType ExtraDataType;
	typedef TRAITS_T::ExtraDataTypeContainer ExtraDataTypeContainer;
	typedef TRAITS_T::StringType StringType;
	typedef TRAITS_T::ErrorProcessor ErrorProcessor;
}

class CreateAndProcessErrorTest :
	public UnitTestBase
{
protected:
	void Test_VSL_CREATE_ERROR_EX()
	{
		bool bCaught = false;
		try
		{
			VSL_CREATE_ERROR_EX(HRESULTTraits, E_FAIL, g_szExtra);
		}
		catch(const HRESULTTraits::Exception& rException)
		{
			bCaught = true;
			UTCHK(rException.GetHRESULT() == E_FAIL);
			if(UTCHK(rException.GetExtraData() != NULL))
			{
				UTCHKEX(0 == ::memcmp(rException.GetExtraData(), g_szExtra, ARRAYSIZE(g_szExtra)), NULL);
			}
		}
		UTCHKEX(bCaught, _T("Exception not caught!"));
	}

	void Test_CREATE_ERROR()
	{
		bool bCaught = false;
		try
		{
			VSL_CREATE_ERROR(HRESULTTraits, E_FAIL);
		}
		catch(const HRESULTTraits::Exception& rException)
		{
			bCaught = true;
			UTCHKEX(rException.GetHRESULT() == E_FAIL, NULL);
			UTCHKEX(rException.GetExtraData() == NULL, NULL);
		}
		UTCHKEX(bCaught, _T("Exception not caught!"));
	}

public:
	CreateAndProcessErrorTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		Test_VSL_CREATE_ERROR_EX();
		Test_CREATE_ERROR();
	}
};

class FailOnErrorTest :
	public UnitTestBase
{
protected:
	void Test_CHECKEXP_EX()
	{
		bool bCaught = false;
		try
		{
			VSL_CHECKEXPRESSION_EX(HRESULTTraits, S_OK, g_szExtra); // this shouldn't throw
			VSL_CHECKEXPRESSION_EX(HRESULTTraits, E_FAIL, g_szExtra);
		}
		catch(const HRESULTTraits::Exception& rException)
		{
			bCaught = true;
			UTCHK(rException.GetHRESULT() == E_FAIL);
			if(UTCHK(rException.GetExtraData() != NULL))
			{
				UTCHK(0 == ::memcmp(rException.GetExtraData(), g_szExtra, ARRAYSIZE(g_szExtra)));
			}
		}
		UTCHKEX(bCaught, _T("Exception not caught!"));
	}

	void Test_CHECKEXP()
	{
		bool bCaught = false;
		try
		{
			VSL_CHECKEXPRESSION(HRESULTTraits, S_OK); // this shouldn't throw
			VSL_CHECKEXPRESSION(HRESULTTraits, E_FAIL);
		}
		catch(const HRESULTTraits::Exception& rException)
		{
			bCaught = true;
			UTCHK(rException.GetHRESULT() == E_FAIL);
			UTCHK(rException.GetExtraData() == NULL);
		}
		UTCHKEX(bCaught, _T("Exception not caught!"));
	}

public:
	FailOnErrorTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		Test_CHECKEXP_EX();
		Test_CHECKEXP();
	}
};

/*******************************************************************************
Validate VSLBOOLErrorHandlers.h
*******************************************************************************/

class VSL_CHECKBOOLEANTest :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKBOOLEAN_EX()
	{
		VSL_STDMETHODTRY
		{
			CHKEX(true, S_OK, g_szExtra);  // this shouldn't throw
			CHKEX(false, E_FAIL, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKBOOLEAN()
	{
		VSL_STDMETHODTRY
		{
			CHK(true, S_OK);  // this shouldn't throw
			CHK(false, E_FAIL);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKBOOLEANTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKBOOLEAN_TRAITS(E_FAIL) VSL_CHECKBOOLEAN_TRAITS_t;
		UTCHK(Test_VSL_CHECKBOOLEAN_EX() == E_FAIL);
		UTCHK(Test_VSL_CHECKBOOLEAN() == E_FAIL);
	}
};

class VSL_CHECKBOOLTest :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKBOOL_EX()
	{
		VSL_STDMETHODTRY
		{
			CHKBOOLEX(TRUE, S_OK, g_szExtra);  // this shouldn't throw
			CHKBOOLEX(FALSE, E_FAIL, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKBOOL()
	{
		VSL_STDMETHODTRY
		{
			CHKBOOL(TRUE, S_OK);  // this shouldn't throw
			CHKBOOL(FALSE, E_FAIL);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKBOOLTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKBOOL_TRAITS(E_FAIL) VSL_CHECKBOOL_TRAITS_t;
		UTCHK(Test_VSL_CHECKBOOL_EX() == E_FAIL);
		UTCHK(Test_VSL_CHECKBOOL() == E_FAIL);
	}
};

class VSL_CHECKBOOL_GLETest :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKBOOL_GLE_EX()
	{
		VSL_STDMETHODTRY
		{
			::SetLastError(ERROR_SUCCESS);
			CHKBOOLGLEEX(TRUE, g_szExtra);  // this shouldn't throw
			::SetLastError(ERROR_OUTOFMEMORY);
			CHKBOOLGLEEX(FALSE, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKBOOL_GLE()
	{
		VSL_STDMETHODTRY
		{
			::SetLastError(ERROR_SUCCESS);
			CHKBOOLGLE(TRUE);  // this shouldn't throw
			::SetLastError(ERROR_OUTOFMEMORY);
			CHKBOOLGLE(FALSE);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKBOOL_GLETest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKBOOL_GLE_TRAITS VSL_CHECKBOOL_GLE_TRAITS_t;
		UTCHK(Test_VSL_CHECKBOOL_GLE_EX() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(Test_VSL_CHECKBOOL_GLE() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
	}
};

/*******************************************************************************
Validate VSLHANDLEErrorHandlers.h
*******************************************************************************/

class VSL_CHECKHANDLE_GLETest :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKHANDLE_GLE_EX()
	{
		VSL_STDMETHODTRY
		{
			::SetLastError(ERROR_SUCCESS);
			CHKHANDLEGLEEX(g_hNotNull, g_szExtra);  // this shouldn't throw
			::SetLastError(ERROR_OUTOFMEMORY);
			CHKHANDLEGLEEX(NULL, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKHANDLE_GLE()
	{
		VSL_STDMETHODTRY
		{
			::SetLastError(ERROR_SUCCESS);
			CHKHANDLEGLE(g_hNotNull);  // this shouldn't throw
			::SetLastError(ERROR_OUTOFMEMORY);
			CHKHANDLEGLE(NULL);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKHANDLE_GLETest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKHANDLE_GLE_TRAITS VSL_CHECKHANDLE_GLE_TRAITS_t;
		UTCHK(Test_VSL_CHECKHANDLE_GLE_EX() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(Test_VSL_CHECKHANDLE_GLE() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
	}
};

/*******************************************************************************
Validate VSLHRESULTErrorHandlers.h
*******************************************************************************/

class VSL_CHECKHRESULTTest :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKHRESULT_EX()
	{
		VSL_STDMETHODTRY
		{
			CHKHREX(S_OK, g_szExtra);  // this shouldn't throw
			CHKHREX(E_FAIL, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKHRESULT()
	{
		VSL_STDMETHODTRY
		{
			CHKHR(S_OK);  // this shouldn't throw
			CHKHR(E_FAIL);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CREATE_ERROR_HRESULT_EX()
	{
		VSL_STDMETHODTRY
		{
			ERRHREX(E_FAIL, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CREATE_ERROR_HRESULT()
	{
		VSL_STDMETHODTRY
		{
			ERRHR(E_FAIL);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKHRESULTTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKHRESULT_TRAITS VSL_CHECKHRESULT_TRAITS_t;
		UTCHK(Test_VSL_CHECKHRESULT_EX() == E_FAIL);
		UTCHK(Test_VSL_CHECKHRESULT() == E_FAIL);
		typedef VSL_CREATE_ERROR_HRESULT_TRAITS VSL_CREATE_ERROR_HRESULT_TRAITS_t;
		UTCHK(Test_VSL_CREATE_ERROR_HRESULT_EX() == E_FAIL);
		UTCHK(Test_VSL_CREATE_ERROR_HRESULT() == E_FAIL);
	}
};

/*******************************************************************************
Validate VSLWin32ErrorHandlers.h
*******************************************************************************/

class VSL_CHECKWIN32Test :
	public UnitTestBase
{
protected:

	HRESULT Test_VSL_CHECKWIN32_EX()
	{
		VSL_STDMETHODTRY
		{
			CHKW32EX(ERROR_SUCCESS, g_szExtra);  // this shouldn't throw
			CHKW32EX(ERROR_OUTOFMEMORY, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CHECKWIN32()
	{
		VSL_STDMETHODTRY
		{
			CHKW32(ERROR_SUCCESS);  // this shouldn't throw
			CHKW32(ERROR_OUTOFMEMORY);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CREATE_ERROR_WIN32_EX()
	{
		VSL_STDMETHODTRY
		{
			ERRW32EX(ERROR_OUTOFMEMORY, g_szExtra);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

	HRESULT Test_VSL_CREATE_ERROR_WIN32()
	{
		VSL_STDMETHODTRY
		{
			ERRW32(ERROR_OUTOFMEMORY);
		}
		VSL_STDMETHODCATCH()
		return VSL_GET_STDMETHOD_HRESULT();
	}

public:
	VSL_CHECKWIN32Test(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		typedef VSL_CHECKWIN32_TRAITS VSL_CHECKWIN32_TRAITS_t;
		UTCHK(Test_VSL_CHECKWIN32_EX() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(Test_VSL_CHECKWIN32() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		typedef VSL_CREATE_ERROR_WIN32_TRAITS VSL_CREATE_ERROR_WIN32_TRAITS_t;
		UTCHK(Test_VSL_CREATE_ERROR_WIN32_EX() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
		UTCHK(Test_VSL_CREATE_ERROR_WIN32() == HRESULT_FROM_WIN32(ERROR_OUTOFMEMORY));
	}
};

/*******************************************************************************
Validate VSL_CHECKPOINTER_DEFAULT
*******************************************************************************/

class VSL_CHECKPOINTER_DEFAULTTest :
	public UnitTestBase
{
public:

	VSL_CHECKPOINTER_DEFAULTTest(_In_opt_ const char* const szTestName):
		UnitTestBase(szTestName)
	{
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		VSL_CHECKPOINTER_DEFAULT(reinterpret_cast<void*>(0));

		}VSL_STDMETHODCATCH()

		UTCHK(VSL_GET_STDMETHOD_HRESULT() == E_POINTER);

		VSL_CHECKPOINTER_DEFAULT(reinterpret_cast<void*>(1));
	}
};

int _cdecl _tmain()
{
	UTRUN(BaseClassHasVirtualDestructorUnitTest<ExceptionBaseHasVirtualDestructorTestHelper>);
	UTRUN(ExceptionBaseTest);
	ExceptionStdUnitTestList exceptionStdUnitTestList;
#if 0 // Add back if unit test is brought back
	UTRUN(ExtraTypeContainerStringTest);
#endif
	UTRUN(BaseClassHasVirtualDestructorUnitTest<ErrorVirtualDestructorTestHelper>);
	UTRUN(ExceptionExImplTest);
	UTRUN(ExceptionHRESULTTest);
	UTRUN(ExceptionWin32Test);
	UTRUN(VSL_STDMETHODTest);
	UTRUN(EvaluatorsTest);
	UTRUN(OverridesTest);
	UTRUN(ProcessorsTest);
	CompileTraits<HRESULTTraits>();
	CompileTraits<Win32Traits>();
	CompileTraits<BOOLGetLastErrorTraits>();
	CompileTraits<HANDLEGetLastErrorTraits>();
	UTRUN(CreateAndProcessErrorTest);
	UTRUN(FailOnErrorTest);
	UTRUN(VSL_CHECKBOOLTest);
	UTRUN(VSL_CHECKBOOL_GLETest);
	UTRUN(VSL_CHECKBOOLEANTest);
	UTRUN(VSL_CHECKHANDLE_GLETest);
	UTRUN(VSL_CHECKHRESULTTest);
	UTRUN(VSL_CHECKWIN32Test);
	UTRUN(VSL_CHECKPOINTER_DEFAULTTest);
	return VSL::FailureCounter::Get();
}

