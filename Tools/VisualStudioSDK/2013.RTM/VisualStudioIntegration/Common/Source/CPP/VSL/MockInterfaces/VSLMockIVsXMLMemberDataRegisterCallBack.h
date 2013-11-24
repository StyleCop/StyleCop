/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSXMLMEMBERDATAREGISTERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSXMLMEMBERDATAREGISTERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsXMLMemberDataRegisterCallBackNotImpl :
	public IVsXMLMemberDataRegisterCallBack
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataRegisterCallBackNotImpl)

public:

	typedef IVsXMLMemberDataRegisterCallBack Interface;

	STDMETHOD(RegisterCallBack)(
		/*[in]*/ IVsXMLMemberDataCallBack* /*pIVsXMLMemberDataCallBack*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterCallBack)()VSL_STDMETHOD_NOTIMPL
};

class IVsXMLMemberDataRegisterCallBackMockImpl :
	public IVsXMLMemberDataRegisterCallBack,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsXMLMemberDataRegisterCallBackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsXMLMemberDataRegisterCallBackMockImpl)

	typedef IVsXMLMemberDataRegisterCallBack Interface;
	struct RegisterCallBackValidValues
	{
		/*[in]*/ IVsXMLMemberDataCallBack* pIVsXMLMemberDataCallBack;
		HRESULT retValue;
	};

	STDMETHOD(RegisterCallBack)(
		/*[in]*/ IVsXMLMemberDataCallBack* pIVsXMLMemberDataCallBack)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterCallBack)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsXMLMemberDataCallBack);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterCallBackValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnregisterCallBack)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnregisterCallBack)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSXMLMEMBERDATAREGISTERCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
