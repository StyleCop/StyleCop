/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSETSPANMAPPINGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSETSPANMAPPINGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSetSpanMappingEventsNotImpl :
	public IVsSetSpanMappingEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSetSpanMappingEventsNotImpl)

public:

	typedef IVsSetSpanMappingEvents Interface;

	STDMETHOD(OnBeginSetSpanMappings)(
		/*[in]*/ long /*cSpans*/,
		/*[in,size_is(cSpans)]*/ NewSpanMapping* /*rgSpans*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnEndSetSpanMappings)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnMarkerInvalidated)(
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ IVsTextMarker* /*pMarker*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSetSpanMappingEventsMockImpl :
	public IVsSetSpanMappingEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSetSpanMappingEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSetSpanMappingEventsMockImpl)

	typedef IVsSetSpanMappingEvents Interface;
	struct OnBeginSetSpanMappingsValidValues
	{
		/*[in]*/ long cSpans;
		/*[in,size_is(cSpans)]*/ NewSpanMapping* rgSpans;
		HRESULT retValue;
	};

	STDMETHOD(OnBeginSetSpanMappings)(
		/*[in]*/ long cSpans,
		/*[in,size_is(cSpans)]*/ NewSpanMapping* rgSpans)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeginSetSpanMappings)

		VSL_CHECK_VALIDVALUE(cSpans);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSpans, cSpans*sizeof(rgSpans[0]), validValues.cSpans*sizeof(validValues.rgSpans[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEndSetSpanMappingsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnEndSetSpanMappings)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnEndSetSpanMappings)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnMarkerInvalidatedValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ IVsTextMarker* pMarker;
		HRESULT retValue;
	};

	STDMETHOD(OnMarkerInvalidated)(
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ IVsTextMarker* pMarker)
	{
		VSL_DEFINE_MOCK_METHOD(OnMarkerInvalidated)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMarker);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSETSPANMAPPINGEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
