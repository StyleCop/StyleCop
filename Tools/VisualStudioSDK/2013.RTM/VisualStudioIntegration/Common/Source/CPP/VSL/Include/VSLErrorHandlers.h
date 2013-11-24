/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLERRORHANDLERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLERRORHANDLERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL Includes
#include <VSLErrorHandlersBase.h>

/**************************************************************************************************
VSL_CHECKBOOLEAN and related
**************************************************************************************************/

#ifndef VSL_CHECKBOOLEAN_TRAITS
#define VSL_CHECKBOOLEAN_TRAITS(hrErr) \
	VSL::Traits< \
		VSL::BooleanEvaluator, \
		VSL_OVERRIDE_HRESULT_CONSTANT(VSL::BooleanEvaluator::ExpressionType, hrErr), \
		VSL::ExceptionHRESULT<>, \
		VSL::HRESULTProcessor > 
#endif // VSL_CHECKBOOLEAN_TRAITS

#ifndef VSL_CHECKBOOLEAN_EX
#define VSL_CHECKBOOLEAN_EX(exp, hrErr, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKBOOLEAN_TRAITS(hrErr), exp, extraData)
#endif // VSL_CHECKBOOLEAN_EX

#ifndef VSL_CHECKBOOLEAN
#define VSL_CHECKBOOLEAN(exp, hrErr) \
	VSL_CHECKEXPRESSION(VSL_CHECKBOOLEAN_TRAITS(hrErr), exp)
#endif // VSL_CHECKBOOL

/**************************************************************************************************
VSL_CHECKBOOLEAN_GLE and related

TODO - 1/21/2006 - unit test this

**************************************************************************************************/

#ifndef VSL_CHECKBOOLEAN_GLE_TRAITS
#define VSL_CHECKBOOLEAN_GLE_TRAITS VSL::BooleanGetLastErrorTraits
#endif // VSL_CHKBOOLEAN_TRAITS

#ifndef VSL_CHECKBOOLEAN_GLE_EX
#define VSL_CHECKBOOLEAN_GLE_EX(exp, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKBOOLEAN_GLE_TRAITS, exp, extraData)
#endif // VSL_CHKBOOLEAN_EX

#ifndef VSL_CHECKBOOLEAN_GLE
#define VSL_CHECKBOOLEAN_GLE(exp) \
	VSL_CHECKEXPRESSION(VSL_CHECKBOOLEAN_GLE_TRAITS, exp)
#endif // VSL_CHKBOOLEAN

/**************************************************************************************************
VSL_CHECKBOOL and related
**************************************************************************************************/

#ifndef VSL_CHECKBOOL_TRAITS
#define VSL_CHECKBOOL_TRAITS(hrErr) \
	VSL::Traits< \
		VSL::BOOLEvaluator, \
		VSL_OVERRIDE_HRESULT_CONSTANT(VSL::BOOLEvaluator::ExpressionType, hrErr), \
		VSL::ExceptionHRESULT<>, \
		VSL::HRESULTProcessor > 
#endif // VSL_CHECKBOOL_TRAITS

#ifndef VSL_CHECKBOOL_EX
#define VSL_CHECKBOOL_EX(exp, hrErr, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKBOOL_TRAITS(hrErr), exp, extraData)
#endif // VSL_CHECKBOOL_EX

#ifndef VSL_CHECKBOOL
#define VSL_CHECKBOOL(exp, hrErr) \
	VSL_CHECKEXPRESSION(VSL_CHECKBOOL_TRAITS(hrErr), exp)
#endif // VSL_CHECKBOOL

/**************************************************************************************************
VSL_CHECKBOOL_GLE and related
**************************************************************************************************/

#ifndef VSL_CHECKBOOL_GLE_TRAITS
#define VSL_CHECKBOOL_GLE_TRAITS VSL::BOOLGetLastErrorTraits
#endif // VSL_CHKBOOL_TRAITS

#ifndef VSL_CHECKBOOL_GLE_EX
#define VSL_CHECKBOOL_GLE_EX(exp, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKBOOL_GLE_TRAITS, exp, extraData)
#endif // VSL_CHKBOOL_EX

#ifndef VSL_CHECKBOOL_GLE
#define VSL_CHECKBOOL_GLE(exp) \
	VSL_CHECKEXPRESSION(VSL_CHECKBOOL_GLE_TRAITS, exp)
#endif // VSL_CHKBOOL

/**************************************************************************************************
VSL_CHECKHANDLE_GLE and related
**************************************************************************************************/

#ifndef VSL_CHECKHANDLE_GLE_TRAITS
#define VSL_CHECKHANDLE_GLE_TRAITS VSL::HANDLEGetLastErrorTraits
#endif // VSL_CHECKHANDLE_GLE_TRAITS

#ifndef VSL_CHECKHANDLE_GLE_EX
#define VSL_CHECKHANDLE_GLE_EX(exp, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKHANDLE_GLE_TRAITS, exp, extraData)
#endif // VSL_CHECKHANDLE_GLE_EX

#ifndef VSL_CHECKHANDLE_GLE
#define VSL_CHECKHANDLE_GLE(exp) \
	VSL_CHECKEXPRESSION(VSL_CHECKHANDLE_GLE_TRAITS, exp)
#endif // VSL_CHECKHANDLE_GLE

#ifndef VSL_CHECKHRESULT_TRAITS
#define VSL_CHECKHRESULT_TRAITS VSL::HRESULTTraits
#endif // VSL_CHECKHRESULT_TRAITS

/**************************************************************************************************
VSL_CHECKHRESULT and related
**************************************************************************************************/

#ifndef VSL_CHECKHRESULT_EX
#define VSL_CHECKHRESULT_EX(exp, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKHRESULT_TRAITS, exp, extraData)
#endif // VSL_CHECKHRESULT_EX

#ifndef VSL_CHECKHRESULT
#define VSL_CHECKHRESULT(exp) \
	VSL_CHECKEXPRESSION(VSL_CHECKHRESULT_TRAITS, exp)
#endif // VSL_CHECKHRESULT

/**************************************************************************************************
VSL_CREATE_ERROR_HRESULT and related
**************************************************************************************************/

#ifndef VSL_CREATE_ERROR_HRESULT_TRAITS
#define VSL_CREATE_ERROR_HRESULT_TRAITS  VSL::HRESULTTraits
#endif // VSL_CREATE_ERROR_HRESULT_TRAITS

#ifndef VSL_CREATE_ERROR_HRESULT_EX
#define VSL_CREATE_ERROR_HRESULT_EX(exp, extraData) \
	VSL_CREATE_ERROR_EX(VSL_CREATE_ERROR_HRESULT_TRAITS, exp, extraData)
#endif // VSL_CREATE_ERROR_HRESULT_EX

#ifndef VSL_CREATE_ERROR_HRESULT
#define VSL_CREATE_ERROR_HRESULT(exp) \
	VSL_CREATE_ERROR(VSL_CREATE_ERROR_HRESULT_TRAITS, exp)
#endif // VSL_CREATE_ERROR_HRESULT

/**************************************************************************************************
VSL_CHECKHRESULT and related
**************************************************************************************************/

#ifndef VSL_CHECKWIN32_TRAITS
#define VSL_CHECKWIN32_TRAITS VSL::Win32Traits
#endif // VSL_CHECKWIN32_TRAITS

#ifndef VSL_CHECKWIN32_EX
#define VSL_CHECKWIN32_EX(exp, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKWIN32_TRAITS, exp, extraData)
#endif // VSL_CHECKWIN32_EX

#ifndef VSL_CHECKWIN32
#define VSL_CHECKWIN32(exp) \
	VSL_CHECKEXPRESSION(VSL_CHECKWIN32_TRAITS, exp)
#endif // VSL_CHECKWIN32

/**************************************************************************************************
VSL_CREATE_ERROR_WIN32 and related
**************************************************************************************************/

#ifndef VSL_CREATE_ERROR_WIN32_TRAITS
#define VSL_CREATE_ERROR_WIN32_TRAITS VSL::Win32Traits
#endif // VSL_CREATE_ERROR_WIN32_TRAITS

#ifndef VSL_CREATE_ERROR_WIN32_EX
#define VSL_CREATE_ERROR_WIN32_EX(exp, extraData) \
	VSL_CREATE_ERROR_EX(VSL_CREATE_ERROR_WIN32_TRAITS, exp, extraData)
#endif // VSL_CREATE_ERROR_WIN32_EX

#ifndef VSL_CREATE_ERROR_WIN32
#define VSL_CREATE_ERROR_WIN32(exp) \
	VSL_CREATE_ERROR(VSL_CREATE_ERROR_WIN32_TRAITS, exp)
#endif // VSL_CREATE_ERROR_WIN32

/**************************************************************************************************
VSL_CHECKPOINTER and related
**************************************************************************************************/

#ifndef VSL_CHECKPOINTER_TRAITS
#define VSL_CHECKPOINTER_TRAITS(hrErr) \
	VSL::Traits< \
		VSL::PointerEvaluator, \
		VSL_OVERRIDE_HRESULT_CONSTANT(VSL::PointerEvaluator::ExpressionType, hrErr), \
		VSL::ExceptionHRESULT<>, \
		VSL::HRESULTProcessor > 
#endif // VSL_CHECKPOINTER_TRAITS

#ifndef VSL_CHECKPOINTER_EX
#define VSL_CHECKPOINTER_EX(exp, hrErr, extraData) \
	VSL_CHECKEXPRESSION_EX(VSL_CHECKPOINTER_TRAITS(hrErr), exp, extraData)
#endif // VSL_CHECKPOINTER_EX

#ifndef VSL_CHECKPOINTER
#define VSL_CHECKPOINTER(exp, hrErr) \
	VSL_CHECKEXPRESSION_CAST(VSL_CHECKPOINTER_TRAITS(hrErr), exp)
#endif // VSL_CHECKPOINTER

#define VSL_CHECKPOINTER_DEFAULT(exp) VSL_CHECKPOINTER(exp, E_POINTER)

// FUTURE - 1/23/2006 - this will be removed, use VSL_CHECKPOINTER_DEFAULT instead
#ifndef ErrorOnNullPointer
#define ErrorOnNullPointer(p) VSL_CHECKPOINTER_DEFAULT(p)
#endif

#ifndef VSL_RETURN_E_INVALIDARG_IF_NULL
#define VSL_RETURN_E_INVALIDARG_IF_NULL(p) \
    if(NULL == p) \
	{ \
        return E_INVALIDARG; \
	}
#endif

#endif // VSLERRORHANDLERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
