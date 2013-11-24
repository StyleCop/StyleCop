/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#ifndef __cplusplus
	#error VSL requires C++; use a .cpp extension instead of .c
#endif

/*
FUTURE - the global disabling of the following warnings could be removed if it is causing
anyone hardship.
*/

// 'int' : forcing value to bool 'true' or 'false' (performance warning)
// This fires even with an explicit cast!!!
#pragma warning(disable : 4800)

#define VSL VSL

// forward declration of the namespace
namespace VSL {}

// By default debug builds contain source line information in exception objects
// which makes the binary larger.  By default retail builds do not contain source line
// information inorder to save both size and avoid having source file information in the binary,
// can be considered a security or legal risk.
#if !defined(DEBUG) && !defined(_DEBUG) && !defined(DBG) && !defined(_VSL_RETAIL_SOURCE_INFO)
#define _VSL_NO_SOURCE_INFO
#endif

// Used to prepend L a literal string
#ifndef WIDEN2
#define WIDEN2(x) L ## x
#endif

#ifndef WIDEN
#define WIDEN(x) WIDEN2(x)
#endif

// Compiler doesn't provide this so we define it here.
#ifndef __WFILE__
#define __WFILE__ WIDEN(__FILE__)
#endif

/*
Placing the following code in each object file making use of the Visual Studio
Library can reduce the size of the compiled executable, if the string pooling 
optimization is not enabled.

static const TCHAR cszObjectFilename[] = _T(__FILE__);
#undef __VSL_FILE__
#define __VSL_FILE__ cszObjectFilename
*/

#ifndef __VSL_FILE__
#if defined(_UNICODE) || defined(UNICODE)
#define __VSL_FILE__ __WFILE__
#else
#define __VSL_FILE__ __FILE__
#endif
#endif // __VSL_FILE__

// It is left to the consumer of the VSL library to define the assertion mechanism
// of their choosing
#ifndef VSL_ASSERT
#define VSL_ASSERT(exp) ((void)0)
#endif

#ifndef VSL_ASSERTEX
#define VSL_ASSERTEX(exp, szMsg) VSL_ASSERT(exp)
#endif

#ifndef VSL_ERROR_PROCESSOR_ASSERTEX
#define VSL_ERROR_PROCESSOR_ASSERTEX(exp, szMsg) VSL_ASSERTEX(exp, szMsg)
#endif

// It is left to the consumer of the VSL library to define the tracing mechanism
// of their choosing
#ifndef VSL_TRACE
#define VSL_TRACE __noop
#endif // VSL_TRACE

// ARRAY_SIZE is supplied by newer Windows Platform SDKs only.
#ifndef ARRAYSIZE 
#define ARRAYSIZE(A) (sizeof(A)/sizeof((A)[0]))
#endif ARRAYSIZE

#ifndef VSL_STDMETHOD_NOTIMPL 
#define VSL_STDMETHOD_NOTIMPL { return E_NOTIMPL; }
#endif

#define VSL_DECLARE_ASSIGNMENT_OPERATOR(type) const type& operator=(const type& rToCopy)

#define VSL_DECLARE_COPY_CONSTRUCTOR(type) type(const type& rToCopy)

#define VSL_DECLARE_NOT_COPYABLE(type) \
private: \
	VSL_DECLARE_ASSIGNMENT_OPERATOR(type); \
	VSL_DECLARE_COPY_CONSTRUCTOR(type);

#define VSL_DEFINE_BINARY_COPY_THROUGH_DERIVED_ONLY(type) \
protected: \
	const type& operator=(const type& rToCopy) \
	{ \
		if(&rToCopy != this) \
		{ \
			::memcpy(this, &rToCopy, sizeof(this)); \
		} \
		return *this; \
	} \
	type(const type& rToCopy) \
	{ \
		::memcpy(this, &rToCopy, sizeof(this)); \
	}

#define VSL_DECLARE_PRIVATE_DEFAULT_CONSTURCTOR_AND_DESTRUCTOR(type) \
private: \
	type(); \
	~type();

#define VSL_DEFINE_NON_DEFAULT_CONSTRUCTABLE_BASE_CLASS_WITH_PROTECTED_COPY(type) \
protected: \
	type() {} \
	~type() {} \
VSL_DEFINE_BINARY_COPY_THROUGH_DERIVED_ONLY(type)

#define VSL_DEFINE_DEFAULT_CONSTRUCTOR_AND_PURE_VIRTUAL_DESTRUCTOR(type) \
	type() {} \
	virtual ~type() = 0 {}

#define VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(type) \
VSL_DECLARE_NOT_COPYABLE(type) \
\
protected: \
\
	type() {} \
	~type() {} // Not virtual, but it is protected, so it can't be accessed through a pointer to type, except by derived classes, which can delete using their own this pointer.

#define VSL_DECLARE_NONINSTANTIABLE_CLASS(type) \
VSL_DECLARE_NOT_COPYABLE(type) \
VSL_DECLARE_PRIVATE_DEFAULT_CONSTURCTOR_AND_DESTRUCTOR(type)

// DEPRECATED - 5/18/2006 - this will be removed in the future
#define VSL_DECLARE_NONINSTANTIABLE_NONBASE_CLASS VSL_DECLARE_NONINSTANTIABLE_CLASS

#define VSL_DECLARE_NOT_COPYABLE_OR_DEFAULT_CONSTRUCTABLE(type) \
VSL_DECLARE_NOT_COPYABLE(type) \
	type(); \

#endif // VSL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
