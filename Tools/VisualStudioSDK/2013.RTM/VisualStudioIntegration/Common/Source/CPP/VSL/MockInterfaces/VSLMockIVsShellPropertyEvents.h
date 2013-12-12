/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSHELLPROPERTYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSHELLPROPERTYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsShellPropertyEventsNotImpl :
	public IVsShellPropertyEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShellPropertyEventsNotImpl)

public:

	typedef IVsShellPropertyEvents Interface;

	STDMETHOD(OnShellPropertyChange)(
		/*[in]*/ VSSPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL
};

class IVsShellPropertyEventsMockImpl :
	public IVsShellPropertyEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShellPropertyEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsShellPropertyEventsMockImpl)

	typedef IVsShellPropertyEvents Interface;
	struct OnShellPropertyChangeValidValues
	{
		/*[in]*/ VSSPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(OnShellPropertyChange)(
		/*[in]*/ VSSPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(OnShellPropertyChange)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSHELLPROPERTYEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
