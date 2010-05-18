/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccToolsOptions.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccToolsOptionsNotImpl :
	public IVsSccToolsOptions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccToolsOptionsNotImpl)

public:

	typedef IVsSccToolsOptions Interface;

	STDMETHOD(SetSccToolsOption)(
		/*[in]*/ SccToolsOptionsEnum /*sctoOptionToBeSet*/,
		/*[in]*/ VARIANT /*varValueToBeSet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccToolsOption)(
		/*[in]*/ SccToolsOptionsEnum /*sctoOptionToBeSet*/,
		/*[out,retval]*/ VARIANT* /*pvarValueToGet*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccToolsOptionsMockImpl :
	public IVsSccToolsOptions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccToolsOptionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccToolsOptionsMockImpl)

	typedef IVsSccToolsOptions Interface;
	struct SetSccToolsOptionValidValues
	{
		/*[in]*/ SccToolsOptionsEnum sctoOptionToBeSet;
		/*[in]*/ VARIANT varValueToBeSet;
		HRESULT retValue;
	};

	STDMETHOD(SetSccToolsOption)(
		/*[in]*/ SccToolsOptionsEnum sctoOptionToBeSet,
		/*[in]*/ VARIANT varValueToBeSet)
	{
		VSL_DEFINE_MOCK_METHOD(SetSccToolsOption)

		VSL_CHECK_VALIDVALUE(sctoOptionToBeSet);

		VSL_CHECK_VALIDVALUE(varValueToBeSet);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccToolsOptionValidValues
	{
		/*[in]*/ SccToolsOptionsEnum sctoOptionToBeSet;
		/*[out,retval]*/ VARIANT* pvarValueToGet;
		HRESULT retValue;
	};

	STDMETHOD(GetSccToolsOption)(
		/*[in]*/ SccToolsOptionsEnum sctoOptionToBeSet,
		/*[out,retval]*/ VARIANT* pvarValueToGet)
	{
		VSL_DEFINE_MOCK_METHOD(GetSccToolsOption)

		VSL_CHECK_VALIDVALUE(sctoOptionToBeSet);

		VSL_SET_VALIDVALUE_VARIANT(pvarValueToGet);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
