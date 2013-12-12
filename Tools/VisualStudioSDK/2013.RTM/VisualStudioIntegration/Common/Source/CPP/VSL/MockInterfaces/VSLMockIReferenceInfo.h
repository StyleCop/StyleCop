/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IREFERENCEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IREFERENCEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DiscoveryService.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IReferenceInfoNotImpl :
	public IReferenceInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IReferenceInfoNotImpl)

public:

	typedef IReferenceInfo Interface;

	STDMETHOD(GetNodeType)(
		/*[out,retval]*/ DiscoveryNodeType* /*pType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUrl)(
		/*[out,retval]*/ BSTR* /*ppbstrUrl*/)VSL_STDMETHOD_NOTIMPL
};

class IReferenceInfoMockImpl :
	public IReferenceInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IReferenceInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IReferenceInfoMockImpl)

	typedef IReferenceInfo Interface;
	struct GetNodeTypeValidValues
	{
		/*[out,retval]*/ DiscoveryNodeType* pType;
		HRESULT retValue;
	};

	STDMETHOD(GetNodeType)(
		/*[out,retval]*/ DiscoveryNodeType* pType)
	{
		VSL_DEFINE_MOCK_METHOD(GetNodeType)

		VSL_SET_VALIDVALUE(pType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUrlValidValues
	{
		/*[out,retval]*/ BSTR* ppbstrUrl;
		HRESULT retValue;
	};

	STDMETHOD(GetUrl)(
		/*[out,retval]*/ BSTR* ppbstrUrl)
	{
		VSL_DEFINE_MOCK_METHOD(GetUrl)

		VSL_SET_VALIDVALUE_BSTR(ppbstrUrl);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IREFERENCEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
