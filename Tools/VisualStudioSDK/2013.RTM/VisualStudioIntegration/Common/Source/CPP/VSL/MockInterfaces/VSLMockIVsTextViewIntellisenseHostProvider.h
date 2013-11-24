/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTVIEWINTELLISENSEHOSTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTVIEWINTELLISENSEHOSTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextViewIntellisenseHostProviderNotImpl :
	public IVsTextViewIntellisenseHostProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewIntellisenseHostProviderNotImpl)

public:

	typedef IVsTextViewIntellisenseHostProvider Interface;

	STDMETHOD(CreateIntellisenseHost)(
		/*[in]*/ IVsTextBufferCoordinator* /*pBufferCoordinator*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppunkHost*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextViewIntellisenseHostProviderMockImpl :
	public IVsTextViewIntellisenseHostProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewIntellisenseHostProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextViewIntellisenseHostProviderMockImpl)

	typedef IVsTextViewIntellisenseHostProvider Interface;
	struct CreateIntellisenseHostValidValues
	{
		/*[in]*/ IVsTextBufferCoordinator* pBufferCoordinator;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppunkHost;
		HRESULT retValue;
	};

	STDMETHOD(CreateIntellisenseHost)(
		/*[in]*/ IVsTextBufferCoordinator* pBufferCoordinator,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppunkHost)
	{
		VSL_DEFINE_MOCK_METHOD(CreateIntellisenseHost)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBufferCoordinator);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppunkHost);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTVIEWINTELLISENSEHOSTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
