/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREPORTEXTERNALERRORS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREPORTEXTERNALERRORS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsReportExternalErrorsNotImpl :
	public IVsReportExternalErrors
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsReportExternalErrorsNotImpl)

public:

	typedef IVsReportExternalErrors Interface;

	STDMETHOD(ClearAllErrors)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddNewErrors)(
		/*[in]*/ IVsEnumExternalErrors* /*pErrors*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetErrors)(
		/*[out]*/ IVsEnumExternalErrors** /*pErrors*/)VSL_STDMETHOD_NOTIMPL
};

class IVsReportExternalErrorsMockImpl :
	public IVsReportExternalErrors,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsReportExternalErrorsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsReportExternalErrorsMockImpl)

	typedef IVsReportExternalErrors Interface;
	struct ClearAllErrorsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearAllErrors)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearAllErrors)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddNewErrorsValidValues
	{
		/*[in]*/ IVsEnumExternalErrors* pErrors;
		HRESULT retValue;
	};

	STDMETHOD(AddNewErrors)(
		/*[in]*/ IVsEnumExternalErrors* pErrors)
	{
		VSL_DEFINE_MOCK_METHOD(AddNewErrors)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrors);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetErrorsValidValues
	{
		/*[out]*/ IVsEnumExternalErrors** pErrors;
		HRESULT retValue;
	};

	STDMETHOD(GetErrors)(
		/*[out]*/ IVsEnumExternalErrors** pErrors)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrors)

		VSL_SET_VALIDVALUE_INTERFACE(pErrors);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREPORTEXTERNALERRORS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
