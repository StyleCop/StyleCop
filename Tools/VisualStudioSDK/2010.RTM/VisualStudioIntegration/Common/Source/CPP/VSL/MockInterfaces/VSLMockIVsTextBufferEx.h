/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTBUFFEREX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTBUFFEREX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextBufferExNotImpl :
	public IVsTextBufferEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferExNotImpl)

public:

	typedef IVsTextBufferEx Interface;

	STDMETHOD(GetTrackChanges)(
		/*[out]*/ BOOL* /*pfIsTracking*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTrackChangesSuppression)(
		/*[in]*/ BOOL /*fSupress*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextBufferExMockImpl :
	public IVsTextBufferEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextBufferExMockImpl)

	typedef IVsTextBufferEx Interface;
	struct GetTrackChangesValidValues
	{
		/*[out]*/ BOOL* pfIsTracking;
		HRESULT retValue;
	};

	STDMETHOD(GetTrackChanges)(
		/*[out]*/ BOOL* pfIsTracking)
	{
		VSL_DEFINE_MOCK_METHOD(GetTrackChanges)

		VSL_SET_VALIDVALUE(pfIsTracking);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTrackChangesSuppressionValidValues
	{
		/*[in]*/ BOOL fSupress;
		HRESULT retValue;
	};

	STDMETHOD(SetTrackChangesSuppression)(
		/*[in]*/ BOOL fSupress)
	{
		VSL_DEFINE_MOCK_METHOD(SetTrackChangesSuppression)

		VSL_CHECK_VALIDVALUE(fSupress);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTBUFFEREX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
