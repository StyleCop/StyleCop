/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEEHOSTSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEEHOSTSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IEEHostServicesNotImpl :
	public IEEHostServices
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEHostServicesNotImpl)

public:

	typedef IEEHostServices Interface;

	STDMETHOD(GetHostValue)(
		/*[in]*/ LPCOLESTR /*valueCatagory*/,
		/*[in]*/ LPCOLESTR /*valueKind*/,
		/*[out]*/ VARIANT* /*result*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHostValue)(
		/*[in]*/ LPCOLESTR /*valueCatagory*/,
		/*[in]*/ LPCOLESTR /*valueKind*/,
		/*[in]*/ VARIANT /*newValue*/)VSL_STDMETHOD_NOTIMPL
};

class IEEHostServicesMockImpl :
	public IEEHostServices,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEHostServicesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEEHostServicesMockImpl)

	typedef IEEHostServices Interface;
	struct GetHostValueValidValues
	{
		/*[in]*/ LPCOLESTR valueCatagory;
		/*[in]*/ LPCOLESTR valueKind;
		/*[out]*/ VARIANT* result;
		HRESULT retValue;
	};

	STDMETHOD(GetHostValue)(
		/*[in]*/ LPCOLESTR valueCatagory,
		/*[in]*/ LPCOLESTR valueKind,
		/*[out]*/ VARIANT* result)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostValue)

		VSL_CHECK_VALIDVALUE_STRINGW(valueCatagory);

		VSL_CHECK_VALIDVALUE_STRINGW(valueKind);

		VSL_SET_VALIDVALUE_VARIANT(result);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHostValueValidValues
	{
		/*[in]*/ LPCOLESTR valueCatagory;
		/*[in]*/ LPCOLESTR valueKind;
		/*[in]*/ VARIANT newValue;
		HRESULT retValue;
	};

	STDMETHOD(SetHostValue)(
		/*[in]*/ LPCOLESTR valueCatagory,
		/*[in]*/ LPCOLESTR valueKind,
		/*[in]*/ VARIANT newValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetHostValue)

		VSL_CHECK_VALIDVALUE_STRINGW(valueCatagory);

		VSL_CHECK_VALIDVALUE_STRINGW(valueKind);

		VSL_CHECK_VALIDVALUE(newValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEEHOSTSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
