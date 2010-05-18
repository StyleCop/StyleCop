/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROJECTENLISTMENTCHOICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROJECTENLISTMENTCHOICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProjectEnlistmentChoice.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProjectEnlistmentChoiceNotImpl :
	public IVsSccProjectEnlistmentChoice
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectEnlistmentChoiceNotImpl)

public:

	typedef IVsSccProjectEnlistmentChoice Interface;

	STDMETHOD(GetEnlistmentChoice)(
		/*[out,retval]*/ VSSCCENLISTMENTCHOICE* /*pvscecEnlistmentChoice*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProjectEnlistmentChoiceMockImpl :
	public IVsSccProjectEnlistmentChoice,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProjectEnlistmentChoiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProjectEnlistmentChoiceMockImpl)

	typedef IVsSccProjectEnlistmentChoice Interface;
	struct GetEnlistmentChoiceValidValues
	{
		/*[out,retval]*/ VSSCCENLISTMENTCHOICE* pvscecEnlistmentChoice;
		HRESULT retValue;
	};

	STDMETHOD(GetEnlistmentChoice)(
		/*[out,retval]*/ VSSCCENLISTMENTCHOICE* pvscecEnlistmentChoice)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnlistmentChoice)

		VSL_SET_VALIDVALUE(pvscecEnlistmentChoice);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROJECTENLISTMENTCHOICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
