/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGCOMPLUSPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGCOMPLUSPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugCOMPlusProgramNode2NotImpl :
	public IDebugCOMPlusProgramNode2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCOMPlusProgramNode2NotImpl)

public:

	typedef IDebugCOMPlusProgramNode2 Interface;

	STDMETHOD(GetAppDomainId)(
		/*[out]*/ ULONG32* /*pul32Id*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugCOMPlusProgramNode2MockImpl :
	public IDebugCOMPlusProgramNode2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCOMPlusProgramNode2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugCOMPlusProgramNode2MockImpl)

	typedef IDebugCOMPlusProgramNode2 Interface;
	struct GetAppDomainIdValidValues
	{
		/*[out]*/ ULONG32* pul32Id;
		HRESULT retValue;
	};

	STDMETHOD(GetAppDomainId)(
		/*[out]*/ ULONG32* pul32Id)
	{
		VSL_DEFINE_MOCK_METHOD(GetAppDomainId)

		VSL_SET_VALIDVALUE(pul32Id);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGCOMPLUSPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
