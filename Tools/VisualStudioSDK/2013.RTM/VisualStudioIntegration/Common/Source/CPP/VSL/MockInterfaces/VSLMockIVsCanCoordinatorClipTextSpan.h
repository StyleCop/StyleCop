/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCANCOORDINATORCLIPTEXTSPAN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCANCOORDINATORCLIPTEXTSPAN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCanCoordinatorClipTextSpanNotImpl :
	public IVsCanCoordinatorClipTextSpan
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCanCoordinatorClipTextSpanNotImpl)

public:

	typedef IVsCanCoordinatorClipTextSpan Interface;

	STDMETHOD(ShouldClipSpanToValidSpanInSecondaryBuffer)(
		/*[in]*/ const IVsTextLines* /*pPrimaryBuffer*/,
		/*[in]*/ const IVsTextLines* /*pSecondaryBuffer*/,
		/*[in]*/ const TextSpan* /*ptsTextSpanInPrimaryBuffer*/,
		/*[out]*/ BOOL* /*pfShouldClipTextSpan*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCanCoordinatorClipTextSpanMockImpl :
	public IVsCanCoordinatorClipTextSpan,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCanCoordinatorClipTextSpanMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCanCoordinatorClipTextSpanMockImpl)

	typedef IVsCanCoordinatorClipTextSpan Interface;
	struct ShouldClipSpanToValidSpanInSecondaryBufferValidValues
	{
		/*[in]*/ IVsTextLines* pPrimaryBuffer;
		/*[in]*/ IVsTextLines* pSecondaryBuffer;
		/*[in]*/ TextSpan* ptsTextSpanInPrimaryBuffer;
		/*[out]*/ BOOL* pfShouldClipTextSpan;
		HRESULT retValue;
	};

	STDMETHOD(ShouldClipSpanToValidSpanInSecondaryBuffer)(
		/*[in]*/ const IVsTextLines* pPrimaryBuffer,
		/*[in]*/ const IVsTextLines* pSecondaryBuffer,
		/*[in]*/ const TextSpan* ptsTextSpanInPrimaryBuffer,
		/*[out]*/ BOOL* pfShouldClipTextSpan)
	{
		VSL_DEFINE_MOCK_METHOD(ShouldClipSpanToValidSpanInSecondaryBuffer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPrimaryBuffer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSecondaryBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ptsTextSpanInPrimaryBuffer);

		VSL_SET_VALIDVALUE(pfShouldClipTextSpan);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCANCOORDINATORCLIPTEXTSPAN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
