/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXTERNALCOMPLETIONSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXTERNALCOMPLETIONSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExternalCompletionSetNotImpl :
	public IVsExternalCompletionSet
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExternalCompletionSetNotImpl)

public:

	typedef IVsExternalCompletionSet Interface;

	STDMETHOD(SetIntellisenseHost)(
		/*[in]*/ IVsIntellisenseHost* /*pHost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCompSet)()VSL_STDMETHOD_NOTIMPL
};

class IVsExternalCompletionSetMockImpl :
	public IVsExternalCompletionSet,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExternalCompletionSetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExternalCompletionSetMockImpl)

	typedef IVsExternalCompletionSet Interface;
	struct SetIntellisenseHostValidValues
	{
		/*[in]*/ IVsIntellisenseHost* pHost;
		HRESULT retValue;
	};

	STDMETHOD(SetIntellisenseHost)(
		/*[in]*/ IVsIntellisenseHost* pHost)
	{
		VSL_DEFINE_MOCK_METHOD(SetIntellisenseHost)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateCompSetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdateCompSet)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdateCompSet)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXTERNALCOMPLETIONSET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
