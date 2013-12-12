/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSNAVINFONODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSNAVINFONODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsNavInfoNodeNotImpl :
	public IVsNavInfoNode
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavInfoNodeNotImpl)

public:

	typedef IVsNavInfoNode Interface;

	STDMETHOD(get_Type)(
		/*[out]*/ DWORD* /*pllt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Name)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsNavInfoNodeMockImpl :
	public IVsNavInfoNode,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsNavInfoNodeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsNavInfoNodeMockImpl)

	typedef IVsNavInfoNode Interface;
	struct get_TypeValidValues
	{
		/*[out]*/ DWORD* pllt;
		HRESULT retValue;
	};

	STDMETHOD(get_Type)(
		/*[out]*/ DWORD* pllt)
	{
		VSL_DEFINE_MOCK_METHOD(get_Type)

		VSL_SET_VALIDVALUE(pllt);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_NameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_Name)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_Name)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSNAVINFONODE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
