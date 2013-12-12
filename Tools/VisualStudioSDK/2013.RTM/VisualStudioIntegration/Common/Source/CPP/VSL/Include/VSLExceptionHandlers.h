/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLEXCEPTIONHANDLERS_H_DA737291_2E81_11D3_A504_00C04F5E0BA5
#define VSLEXCEPTIONHANDLERS_H_DA737291_2E81_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "VSLExceptions.h"

namespace VSL
{

#ifndef VSL_STDMETHOD_HRESULT
#define VSL_STDMETHOD_HRESULT ___hr___
#endif // VSL_STDMETHOD_HRESULT

#ifndef VSL_STDMETHOD_HRESULT_INIT
#define VSL_STDMETHOD_HRESULT_INIT S_OK
#endif

#ifndef VSL_GET_STDMETHOD_HRESULT
#define VSL_GET_STDMETHOD_HRESULT() VSL_STDMETHOD_HRESULT
#endif // VSL_GET_STDMETHOD_HRESULT

#ifndef VSL_SET_STDMETHOD_HRESULT
#define VSL_SET_STDMETHOD_HRESULT(hr) (VSL_STDMETHOD_HRESULT = hr)
#endif // VSL_SET_STDMETHOD_HRESULT

#ifndef VSL_STDMETHODTRY_EX
#define VSL_STDMETHODTRY_EX(hrInit) \
	HRESULT VSL_STDMETHOD_HRESULT = hrInit; \
	try
#endif // VSL_STDMETHODTRY_EX

/*
By default, VSL_STDMETHODTRY will expand to:
	HRESULT ___hr___ = S_OK;
	try
*/
#ifndef VSL_STDMETHODTRY
#define VSL_STDMETHODTRY VSL_STDMETHODTRY_EX(VSL_STDMETHOD_HRESULT_INIT)
#endif // VSL_STDMETHODTRY 


#ifndef VSL_STDMETHOD_ON_CATCH_CEXCEPTION

inline HRESULT OnCatchExceptionBase(const ExceptionBase& rException)
{
	VSL_TRACE(_T("Exception caught in OnCatchExceptionBase, which is a generic exception handler, please include callstack in error report."));

	rException.ReportError();

	return static_cast<HRESULT>(rException);
}

#define VSL_STDMETHOD_ON_CATCH_CEXCEPTION VSL::OnCatchExceptionBase

#endif // VSL_STDMETHOD_ON_CATCH_CEXCEPTION


#ifndef VSL_STDMETHOD_ON_CATCH_STDEXCEPTION

inline HRESULT OnCatchStdException(const std::exception& rStdException)
{
	VSL_TRACE(_T("Exception caught in OnCatchStdException, which is a generic exception handler, please include callstack in error report."));

	ExceptionStd exception(rStdException);

	exception.ReportError();

	return static_cast<HRESULT>(exception);
}

#define VSL_STDMETHOD_ON_CATCH_STDEXCEPTION VSL::OnCatchStdException

#endif // VSL_STDMETHOD_ON_CATCH_STDEXCEPTION

#ifndef VSL_STDMETHOD_ON_CATCH_ATLEXCEPTION

inline HRESULT OnCatchAtlException(const ATL::CAtlException &rAtlException)
{
	VSL_TRACE(_T("Exception caught in OnCatchAtlException, which is a generic exception handler, please include callstack in error report."));

	VSL_REPORT_ERROR_HRESULT(static_cast<HRESULT>(rAtlException), false);

	return static_cast<HRESULT>(rAtlException);
}

#define VSL_STDMETHOD_ON_CATCH_ATLEXCEPTION VSL::OnCatchAtlException

#endif // VSL_STDMETHOD_ON_CATCH_ATLEXCEPTION

#ifndef VSL_STDMETHOD_ON_CATCH_ALL

inline HRESULT OnCatchAll()
{
	VSL_TRACE(_T("Exception caught in OnCatchAll, which is a generic exception handler, please include callstack in error report."));

	return E_UNEXPECTED;
}

#define VSL_STDMETHOD_ON_CATCH_ALL VSL::OnCatchAll

#endif // VSL_STDMETHOD_ON_CATCH_ALL


#ifndef VSL_STDMETHODCATCH_EX

/*
onExceptionBase:  defined to accept a ExceptionBase and evalutuate to an HRESULT
onStdException:  defined to accept a std::exception and evalutuate to an HRESULT
onCatchAll:  defined to accept no parameters and evalutuate to an HRESULT
*/

#define VSL_STDMETHODCATCH_EX(onExceptionBase, onStdException, onCatchAll) \
	catch(const VSL::ExceptionBase &rException) \
	{ \
		VSL_SET_STDMETHOD_HRESULT(VSL_STDMETHOD_ON_CATCH_CEXCEPTION(rException)); \
	} \
	catch(const std::exception &rStdException) \
	{ \
		VSL_SET_STDMETHOD_HRESULT(VSL_STDMETHOD_ON_CATCH_STDEXCEPTION(rStdException)); \
	} \
	catch(const ATL::CAtlException &rAtlException) \
	{ \
		VSL_SET_STDMETHOD_HRESULT(VSL_STDMETHOD_ON_CATCH_ATLEXCEPTION(rAtlException)); \
	} \
	catch(...) \
	{ \
		VSL_SET_STDMETHOD_HRESULT(onCatchAll()); \
	}

#endif // VSL_STDMETHODCATCH_EX


#ifndef VSL_STDMETHODCATCH
#define VSL_STDMETHODCATCH() VSL_STDMETHODCATCH_EX(VSL_STDMETHOD_ON_CATCH_CEXCEPTION, VSL_STDMETHOD_ON_CATCH_STDEXCEPTION, VSL_STDMETHOD_ON_CATCH_ALL)
#endif // VSL_STDMETHODCATCH

} // namespace VSL

#endif // VSLEXCEPTIONHANDLERS_H_DA737291_2E81_11D3_A504_00C04F5E0BA5

