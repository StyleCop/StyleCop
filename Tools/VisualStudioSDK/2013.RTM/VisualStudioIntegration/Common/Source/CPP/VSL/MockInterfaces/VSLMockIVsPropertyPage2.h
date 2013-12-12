/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPropertyPage2NotImpl :
	public IVsPropertyPage2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPage2NotImpl)

public:

	typedef IVsPropertyPage2 Interface;

	STDMETHOD(GetProperty)(
		/*[in]*/ VSPPPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSPPPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyPage2MockImpl :
	public IVsPropertyPage2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPage2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyPage2MockImpl)

	typedef IVsPropertyPage2 Interface;
	struct GetPropertyValidValues
	{
		/*[in]*/ VSPPPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSPPPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSPPPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSPPPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
