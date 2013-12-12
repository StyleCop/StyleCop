/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREGISTERPRIORITYCOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREGISTERPRIORITYCOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRegisterPriorityCommandTargetNotImpl :
	public IVsRegisterPriorityCommandTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterPriorityCommandTargetNotImpl)

public:

	typedef IVsRegisterPriorityCommandTarget Interface;

	STDMETHOD(RegisterPriorityCommandTarget)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IOleCommandTarget* /*pCmdTrgt*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterPriorityCommandTarget)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRegisterPriorityCommandTargetMockImpl :
	public IVsRegisterPriorityCommandTarget,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterPriorityCommandTargetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRegisterPriorityCommandTargetMockImpl)

	typedef IVsRegisterPriorityCommandTarget Interface;
	struct RegisterPriorityCommandTargetValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IOleCommandTarget* pCmdTrgt;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterPriorityCommandTarget)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IOleCommandTarget* pCmdTrgt,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterPriorityCommandTarget)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdTrgt);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterPriorityCommandTargetValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterPriorityCommandTarget)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterPriorityCommandTarget)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREGISTERPRIORITYCOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
