/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUPGRADELOGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUPGRADELOGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUpgradeLoggerNotImpl :
	public IVsUpgradeLogger
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpgradeLoggerNotImpl)

public:

	typedef IVsUpgradeLogger Interface;

	STDMETHOD(LogMessage)(
		/*[in]*/ VSUL_ERRORLEVEL /*ErrorLevel*/,
		/*[in]*/ BSTR /*bstrProject*/,
		/*[in]*/ BSTR /*bstrSource*/,
		/*[in]*/ BSTR /*bstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Flush)()VSL_STDMETHOD_NOTIMPL
};

class IVsUpgradeLoggerMockImpl :
	public IVsUpgradeLogger,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpgradeLoggerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUpgradeLoggerMockImpl)

	typedef IVsUpgradeLogger Interface;
	struct LogMessageValidValues
	{
		/*[in]*/ VSUL_ERRORLEVEL ErrorLevel;
		/*[in]*/ BSTR bstrProject;
		/*[in]*/ BSTR bstrSource;
		/*[in]*/ BSTR bstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(LogMessage)(
		/*[in]*/ VSUL_ERRORLEVEL ErrorLevel,
		/*[in]*/ BSTR bstrProject,
		/*[in]*/ BSTR bstrSource,
		/*[in]*/ BSTR bstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(LogMessage)

		VSL_CHECK_VALIDVALUE(ErrorLevel);

		VSL_CHECK_VALIDVALUE_BSTR(bstrProject);

		VSL_CHECK_VALIDVALUE_BSTR(bstrSource);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct FlushValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Flush)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Flush)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUPGRADELOGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
