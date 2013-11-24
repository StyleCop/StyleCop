/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTBUFFERCOORDINATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTBUFFERCOORDINATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextBufferCoordinatorNotImpl :
	public IVsTextBufferCoordinator
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferCoordinatorNotImpl)

public:

	typedef IVsTextBufferCoordinator Interface;

	STDMETHOD(SetBuffers)(
		/*[in]*/ IVsTextLines* /*pPrimaryBuffer*/,
		/*[in]*/ IVsTextLines* /*pSecondaryBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpanMappings)(
		/*[in]*/ long /*cSpans*/,
		/*[in,size_is(cSpans)]*/ NewSpanMapping* /*rgSpans*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapPrimaryToSecondarySpan)(
		/*[in]*/ TextSpan /*tsPrimary*/,
		/*[out]*/ TextSpan* /*ptsSecondary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapSecondaryToPrimarySpan)(
		/*[in]*/ TextSpan /*tsSecondary*/,
		/*[out]*/ TextSpan* /*ptsPrimary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPrimaryBuffer)(
		/*[out]*/ IVsTextLines** /*ppBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSecondaryBuffer)(
		/*[out]*/ IVsTextLines** /*ppBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableReplication)(
		/*[in]*/ DWORD /*bcrd*/,
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMappingOfPrimaryPosition)(
		/*[in]*/ long /*lPosition*/,
		/*[out]*/ TextSpan* /*ptsPrimary*/,
		/*[out]*/ TextSpan* /*ptsSecondary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBufferMappingModes)(
		/*[in]*/ DWORD /*bcmmPrimary*/,
		/*[in]*/ DWORD /*bcmmSecondary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumSpans)(
		/*[in]*/ IVsEnumBufferCoordinatorSpans** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextBufferCoordinatorMockImpl :
	public IVsTextBufferCoordinator,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferCoordinatorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextBufferCoordinatorMockImpl)

	typedef IVsTextBufferCoordinator Interface;
	struct SetBuffersValidValues
	{
		/*[in]*/ IVsTextLines* pPrimaryBuffer;
		/*[in]*/ IVsTextLines* pSecondaryBuffer;
		HRESULT retValue;
	};

	STDMETHOD(SetBuffers)(
		/*[in]*/ IVsTextLines* pPrimaryBuffer,
		/*[in]*/ IVsTextLines* pSecondaryBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(SetBuffers)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPrimaryBuffer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSecondaryBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpanMappingsValidValues
	{
		/*[in]*/ long cSpans;
		/*[in,size_is(cSpans)]*/ NewSpanMapping* rgSpans;
		HRESULT retValue;
	};

	STDMETHOD(SetSpanMappings)(
		/*[in]*/ long cSpans,
		/*[in,size_is(cSpans)]*/ NewSpanMapping* rgSpans)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpanMappings)

		VSL_CHECK_VALIDVALUE(cSpans);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgSpans, cSpans*sizeof(rgSpans[0]), validValues.cSpans*sizeof(validValues.rgSpans[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct MapPrimaryToSecondarySpanValidValues
	{
		/*[in]*/ TextSpan tsPrimary;
		/*[out]*/ TextSpan* ptsSecondary;
		HRESULT retValue;
	};

	STDMETHOD(MapPrimaryToSecondarySpan)(
		/*[in]*/ TextSpan tsPrimary,
		/*[out]*/ TextSpan* ptsSecondary)
	{
		VSL_DEFINE_MOCK_METHOD(MapPrimaryToSecondarySpan)

		VSL_CHECK_VALIDVALUE(tsPrimary);

		VSL_SET_VALIDVALUE(ptsSecondary);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapSecondaryToPrimarySpanValidValues
	{
		/*[in]*/ TextSpan tsSecondary;
		/*[out]*/ TextSpan* ptsPrimary;
		HRESULT retValue;
	};

	STDMETHOD(MapSecondaryToPrimarySpan)(
		/*[in]*/ TextSpan tsSecondary,
		/*[out]*/ TextSpan* ptsPrimary)
	{
		VSL_DEFINE_MOCK_METHOD(MapSecondaryToPrimarySpan)

		VSL_CHECK_VALIDVALUE(tsSecondary);

		VSL_SET_VALIDVALUE(ptsPrimary);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPrimaryBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetPrimaryBuffer)(
		/*[out]*/ IVsTextLines** ppBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetPrimaryBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSecondaryBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetSecondaryBuffer)(
		/*[out]*/ IVsTextLines** ppBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetSecondaryBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableReplicationValidValues
	{
		/*[in]*/ DWORD bcrd;
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(EnableReplication)(
		/*[in]*/ DWORD bcrd,
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(EnableReplication)

		VSL_CHECK_VALIDVALUE(bcrd);

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMappingOfPrimaryPositionValidValues
	{
		/*[in]*/ long lPosition;
		/*[out]*/ TextSpan* ptsPrimary;
		/*[out]*/ TextSpan* ptsSecondary;
		HRESULT retValue;
	};

	STDMETHOD(GetMappingOfPrimaryPosition)(
		/*[in]*/ long lPosition,
		/*[out]*/ TextSpan* ptsPrimary,
		/*[out]*/ TextSpan* ptsSecondary)
	{
		VSL_DEFINE_MOCK_METHOD(GetMappingOfPrimaryPosition)

		VSL_CHECK_VALIDVALUE(lPosition);

		VSL_SET_VALIDVALUE(ptsPrimary);

		VSL_SET_VALIDVALUE(ptsSecondary);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBufferMappingModesValidValues
	{
		/*[in]*/ DWORD bcmmPrimary;
		/*[in]*/ DWORD bcmmSecondary;
		HRESULT retValue;
	};

	STDMETHOD(SetBufferMappingModes)(
		/*[in]*/ DWORD bcmmPrimary,
		/*[in]*/ DWORD bcmmSecondary)
	{
		VSL_DEFINE_MOCK_METHOD(SetBufferMappingModes)

		VSL_CHECK_VALIDVALUE(bcmmPrimary);

		VSL_CHECK_VALIDVALUE(bcmmSecondary);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumSpansValidValues
	{
		/*[in]*/ IVsEnumBufferCoordinatorSpans** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumSpans)(
		/*[in]*/ IVsEnumBufferCoordinatorSpans** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumSpans)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTBUFFERCOORDINATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
