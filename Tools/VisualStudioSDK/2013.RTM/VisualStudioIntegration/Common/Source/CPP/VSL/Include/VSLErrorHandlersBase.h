/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLERRORHANDLERSBASE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLERRORHANDLERSBASE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL Includes
#include <VSLExceptions.h>

// Win32 includes
#include <winerror.h>
#include <objbase.h>

// CRT includes
#include <TCHAR.h>

namespace VSL
{

/**************************************************************************************************
Evalutators
**************************************************************************************************/

#define VSL_DECLARE_EVALUATOR(CLASS, TYPE, EVALUATOR) \
class CLASS \
{ \
private: \
\
	CLASS(); \
\
public:\
\
	typedef TYPE ExpressionType; \
\
	static bool Evaluate(const ExpressionType expressionValue) \
	{ \
		return EVALUATOR; \
	} \
};

VSL_DECLARE_EVALUATOR(BooleanEvaluator, bool, (false == expressionValue));
VSL_DECLARE_EVALUATOR(BOOLEvaluator, BOOL, (FALSE == expressionValue));
VSL_DECLARE_EVALUATOR(DWORDIsZeroEvaluator, DWORD, (0 == expressionValue));
VSL_DECLARE_EVALUATOR(HANDLEIsNullEvaluator, HANDLE, (NULL == expressionValue));
VSL_DECLARE_EVALUATOR(HANDLEIsInvalidEvaluator, HANDLE, (INVALID_HANDLE_VALUE == expressionValue));
VSL_DECLARE_EVALUATOR(HRESULTEvaluator, HRESULT, FAILED(expressionValue));
VSL_DECLARE_EVALUATOR(Win32Evaluator, DWORD, (ERROR_SUCCESS != expressionValue));
VSL_DECLARE_EVALUATOR(PointerEvaluator, void*, (NULL == expressionValue));

/**************************************************************************************************
Overrides
**************************************************************************************************/

template<class Expression_T, class OverrideType_T = Expression_T>
class DefaultOverride
{
private:

	DefaultOverride();

public:

	typedef typename OverrideType_T OverrideType;

	static inline const OverrideType Override(const Expression_T expressionValue)
	{
		return static_cast<OverrideType>(expressionValue);
	}
};

template<class Expression_T, class OverrideType_T, OverrideType_T OverriderValue_T>
class ConstantOverride
{
private:

	ConstantOverride();

public:

	typedef typename OverrideType_T OverrideType;

	static inline const OverrideType Override(const Expression_T /*expressionValue*/)
	{
		return OverriderValue_T;
	}
};

template<class Expression_T>
class GetLastErrorOverride
{
private:

	GetLastErrorOverride();

public:

	typedef DWORD OverrideType;

	static inline const OverrideType Override(const Expression_T /*expressionValue*/)
	{
		return ::GetLastError();
	}
};

typedef DefaultOverride<HRESULT> DefaultHRESULTOverride;

typedef DefaultOverride<DWORD> DefaultWin32Override;

#define VSL_OVERRIDE_HRESULT_CONSTANT(expType, hrErr) VSL::ConstantOverride<expType, HRESULT, hrErr>

/**************************************************************************************************
Processors
**************************************************************************************************/

class HRESULTProcessor
{
public:
	static void ProcessError(const ExceptionHRESULT<>& rErrObj)
	{
		if(static_cast<HRESULT>(rErrObj) != E_NOTIMPL)
		{
			VSL_TRACE(_T("General error, please include callstack in defect report."));
			VSL_ERROR_PROCESSOR_ASSERTEX(SUCCEEDED(static_cast<HRESULT>(rErrObj)), _T("General error, please include callstack in defect report."));
		}
		throw rErrObj;
	}
};

class Win32Processor
{
public:
	static void ProcessError(const ExceptionWin32<>& rErrObj)
	{
		VSL_TRACE(_T("General error, please include callstack in defect report."));
		VSL_ERROR_PROCESSOR_ASSERTEX(SUCCEEDED(static_cast<HRESULT>(rErrObj)), _T("General error, please include callstack in defect report."));
		throw rErrObj;
	}
};

/**************************************************************************************************
Traits
**************************************************************************************************/

template<
	class ExpressionEvaluator_T,
	class ExpressionValueOverride_T,
	class Exception_T,
	class ErrorProcessor_T>
class Traits
{
public:
	typedef ExpressionEvaluator_T ExpressionEvaluator;
	typedef typename ExpressionEvaluator_T::ExpressionType ExpressionType;
	typedef ExpressionValueOverride_T ExpressionValueOverride;
	typedef Exception_T Exception;
	typedef typename Exception_T::ExtraDataType ExtraDataType;
	typedef typename Exception_T::ExtraDataTypeContainer ExtraDataTypeContainer;
	typedef typename Exception_T::StringType StringType;
	typedef ErrorProcessor_T ErrorProcessor;
};

typedef Traits<
	HRESULTEvaluator,
	DefaultHRESULTOverride,
	ExceptionHRESULT<>,
	HRESULTProcessor >
		HRESULTTraits;

typedef Traits<
	Win32Evaluator, 
	DefaultWin32Override, 
	ExceptionWin32<>, 
	Win32Processor >
		Win32Traits;

typedef Traits<
	BooleanEvaluator,
	GetLastErrorOverride<bool>,
	ExceptionWin32<>,
	Win32Processor >
		BooleanGetLastErrorTraits;

typedef Traits<
	BOOLEvaluator,
	GetLastErrorOverride<BOOL>,
	ExceptionWin32<>,
	Win32Processor >
		BOOLGetLastErrorTraits;

typedef Traits<
	HANDLEIsNullEvaluator,
	GetLastErrorOverride<HANDLE>,
	ExceptionWin32<>,
	Win32Processor >
		HANDLEGetLastErrorTraits;

/**************************************************************************************************
CreateAndProcessError
**************************************************************************************************/

template<class Traits_T>
class CreateAndProcessError
{
public:

	static void Invoke(
		typename const Traits_T::ExpressionType expressionValue,
#ifndef _VSL_NO_SOURCE_INFO
		typename Traits_T::StringType szExpression,
		typename Traits_T::StringType szFilename,
		int iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
		const typename Traits_T::ExtraDataType& extraData = Traits_T::ExtraDataTypeContainer::DefaultValue())
	{
		Traits_T::Exception exception(
			Traits_T::ExpressionValueOverride::Override(expressionValue),
#ifndef _VSL_NO_SOURCE_INFO
			szExpression,
			szFilename,
			iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
			extraData);

		Traits_T::ErrorProcessor::ProcessError(exception);
	}
};

/**************************************************************************************************
VSL_CREATE_ERROR macros
**************************************************************************************************/

#ifndef _VSL_NO_SOURCE_INFO
#define __INVOKE_PARAMETERS(expressionValue, expText) expressionValue, expText, __VSL_FILE__, __LINE__
#define __INVOKE_PARAMETERS_EX(expressionValue, expText, extraData) expressionValue, expText, __VSL_FILE__, __LINE__, extraData
#else // _VSL_NO_SOURCE_INFO
#define __INVOKE_PARAMETERS(expressionValue, expText) expressionValue
#define __INVOKE_PARAMETERS_EX(expressionValue, expText, extraData) expressionValue, extraData
#endif // _VSL_NO_SOURCE_INFO

#ifndef VSL_CREATE_ERROR_EX
#define VSL_CREATE_ERROR_EX(traits, expressionValue, extraData) \
	VSL::CreateAndProcessError<traits >::Invoke(__INVOKE_PARAMETERS_EX(expressionValue, NULL, extraData))
#endif // VSL_CREATE_ERROR_EX

#ifndef VSL_CREATE_ERROR
#define VSL_CREATE_ERROR(traits, expressionValue) \
	VSL::CreateAndProcessError<traits >::Invoke(__INVOKE_PARAMETERS(expressionValue, NULL))
#endif // VSL_CREATE_ERROR

/**************************************************************************************************
FailOnError
**************************************************************************************************/

template<class Traits_T>
class FailOnError
{
public:

	static typename Traits_T::ExpressionType Invoke(
		typename Traits_T::ExpressionType expressionValue
#ifndef _VSL_NO_SOURCE_INFO
		, typename Traits_T::StringType szExpression,
		typename Traits_T::StringType szFilename,
		int iLineNumber
#endif // _VSL_NO_SOURCE_INFO
		)
	{
		if(Traits_T::ExpressionEvaluator::Evaluate(expressionValue))
		{
			CreateAndProcessError<Traits_T>::Invoke(
				expressionValue
#ifndef _VSL_NO_SOURCE_INFO
				, szExpression,
				szFilename,
				iLineNumber
#endif // _VSL_NO_SOURCE_INFO
				);
		}

		return expressionValue;
	}
	
	static typename Traits_T::ExpressionType Invoke(
		typename Traits_T::ExpressionType expressionValue,
#ifndef _VSL_NO_SOURCE_INFO
		typename Traits_T::StringType szExpression,
		typename Traits_T::StringType szFilename,
		int iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
		const typename Traits_T::ExtraDataType& extraData)
	{
		if(Traits_T::ExpressionEvaluator::Evaluate(expressionValue))
		{
			CreateAndProcessError<Traits_T>::Invoke(
				expressionValue,
#ifndef _VSL_NO_SOURCE_INFO
				szExpression,
				szFilename,
				iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
				extraData);
		}

		return expressionValue;
	}

	template <class ExpressionType>
	static ExpressionType InvokeCast(
		ExpressionType expressionValue
#ifndef _VSL_NO_SOURCE_INFO
		, typename Traits_T::StringType szExpression,
		typename Traits_T::StringType szFilename,
		int iLineNumber
#endif // _VSL_NO_SOURCE_INFO
		)
	{
		return (ExpressionType)Invoke(
			(Traits_T::ExpressionType)expressionValue
#ifndef _VSL_NO_SOURCE_INFO
			, szExpression,
			szFilename,
			iLineNumber
#endif // _VSL_NO_SOURCE_INFO
			);
	}

	template <class ExpressionType>
	static ExpressionType InvokeCast(
		ExpressionType expressionValue,
#ifndef _VSL_NO_SOURCE_INFO
		typename Traits_T::StringType szExpression,
		typename Traits_T::StringType szFilename,
		int iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
		const typename Traits_T::ExtraDataType& extraData)
	{
		return (ExpressionType)Invoke(
			(Traits_T::ExpressionType)expressionValue
#ifndef _VSL_NO_SOURCE_INFO
			szExpression,
			szFilename,
			iLineNumber,
#endif // _VSL_NO_SOURCE_INFO
			extraData);
	}
};

/**************************************************************************************************
VSL_CHECKEXPRESSION macros - Checks the expression, and, if an error is indicated, fails
**************************************************************************************************/

#ifndef VSL_CHECKEXPRESSION_EX
#if defined(_UNICODE) || defined(UNICODE)
#define VSL_CHECKEXPRESSION_EX(traits, exp, extraData) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS_EX(exp, L#exp, extraData))
#else
#define VSL_CHECKEXPRESSION_EX(traits, exp, extraData) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS_EX(exp, #exp, extraData))
#endif
#endif // VSL_CHECKEXPRESSION_EX

#ifndef VSL_CHECKEXPRESSION
#if defined(_UNICODE) || defined(UNICODE)
#define VSL_CHECKEXPRESSION(traits, exp) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS(exp, L#exp))
#else
#define VSL_CHECKEXPRESSION(traits, exp) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS(exp, #exp))
#endif
#endif // VSL_CHECKEXPRESSION

#ifndef VSL_CHECKEXPRESSION_CAST_EX
#if defined(_UNICODE) || defined(UNICODE)
#define VSL_CHECKEXPRESSION_CAST_EX(traits, exp, extraData) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS_EX(exp, L#exp, extraData))
#else
#define VSL_CHECKEXPRESSION_CAST_EX(traits, exp, extraData) \
	VSL::FailOnError<traits >::Invoke(__INVOKE_PARAMETERS_EX(exp, #exp, extraData))
#endif
#endif // VSL_CHECKEXPRESSION_CAST_EX

#ifndef VSL_CHECKEXPRESSION_CAST
#if defined(_UNICODE) || defined(UNICODE)
#define VSL_CHECKEXPRESSION_CAST(traits, exp) \
	VSL::FailOnError<traits >::InvokeCast(__INVOKE_PARAMETERS(exp, L#exp))
#else
#define VSL_CHECKEXPRESSION_CAST(traits, exp) \
	VSL::FailOnError<traits >::InvokeCast(__INVOKE_PARAMETERS(exp, #exp))
#endif
#endif // VSL_CHECKEXPRESSION_CAST

} // namespace VSL

#endif // VSLERRORHANDLERSBASE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

