/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAMHOST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAMHOST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProgramHost2NotImpl :
	public IDebugProgramHost2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramHost2NotImpl)

public:

	typedef IDebugProgramHost2 Interface;

	STDMETHOD(GetHostName)(
		/*[in]*/ DWORD /*dwType*/,
		/*[out]*/ BSTR* /*pbstrHostName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostId)(
		/*[out]*/ AD_PROCESS_ID* /*pProcessId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostMachineName)(
		/*[out]*/ BSTR* /*pbstrHostMachineName*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProgramHost2MockImpl :
	public IDebugProgramHost2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramHost2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgramHost2MockImpl)

	typedef IDebugProgramHost2 Interface;
	struct GetHostNameValidValues
	{
		/*[in]*/ DWORD dwType;
		/*[out]*/ BSTR* pbstrHostName;
		HRESULT retValue;
	};

	STDMETHOD(GetHostName)(
		/*[in]*/ DWORD dwType,
		/*[out]*/ BSTR* pbstrHostName)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostName)

		VSL_CHECK_VALIDVALUE(dwType);

		VSL_SET_VALIDVALUE_BSTR(pbstrHostName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostIdValidValues
	{
		/*[out]*/ AD_PROCESS_ID* pProcessId;
		HRESULT retValue;
	};

	STDMETHOD(GetHostId)(
		/*[out]*/ AD_PROCESS_ID* pProcessId)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostId)

		VSL_SET_VALIDVALUE(pProcessId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostMachineNameValidValues
	{
		/*[out]*/ BSTR* pbstrHostMachineName;
		HRESULT retValue;
	};

	STDMETHOD(GetHostMachineName)(
		/*[out]*/ BSTR* pbstrHostMachineName)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostMachineName)

		VSL_SET_VALIDVALUE_BSTR(pbstrHostMachineName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAMHOST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
