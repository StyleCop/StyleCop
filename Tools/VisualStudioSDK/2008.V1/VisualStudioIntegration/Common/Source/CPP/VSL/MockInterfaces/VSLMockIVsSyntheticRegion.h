/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSYNTHETICREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSYNTHETICREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSyntheticRegionNotImpl :
	public IVsSyntheticRegion
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSyntheticRegionNotImpl)

public:

	typedef IVsSyntheticRegion Interface;

	STDMETHOD(GetMarkerType)(
		/*[out]*/ long* /*piMarkerType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBehavior)(
		/*[out]*/ DWORD* /*pdwBehavior*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetText)(
		/*[in]*/ LPCWSTR /*pszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseBufferAnchor)(
		/*[out]*/ long* /*piAnchorLine*/,
		/*[out]*/ long* /*piAnchorIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBaseBufferAnchor)(
		/*[in]*/ long /*iAnchorLine*/,
		/*[in]*/ long /*iAnchorIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClientData)(
		/*[out]*/ DWORD_PTR* /*pdwData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetClientData)(
		/*[in]*/ DWORD_PTR /*dwData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invalidate)(
		/*[in]*/ DWORD /*dwUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValid)(
		/*[out]*/ BOOL* /*pfValid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextLayer)(
		/*[out]*/ IVsTextLayer** /*ppLayer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSyntheticLayerSpan)(
		/*[out]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextImage)(
		/*[out]*/ IVsTextImage** /*ppImage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSyntheticRegionMockImpl :
	public IVsSyntheticRegion,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSyntheticRegionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSyntheticRegionMockImpl)

	typedef IVsSyntheticRegion Interface;
	struct GetMarkerTypeValidValues
	{
		/*[out]*/ long* piMarkerType;
		HRESULT retValue;
	};

	STDMETHOD(GetMarkerType)(
		/*[out]*/ long* piMarkerType)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarkerType)

		VSL_SET_VALIDVALUE(piMarkerType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBehaviorValidValues
	{
		/*[out]*/ DWORD* pdwBehavior;
		HRESULT retValue;
	};

	STDMETHOD(GetBehavior)(
		/*[out]*/ DWORD* pdwBehavior)
	{
		VSL_DEFINE_MOCK_METHOD(GetBehavior)

		VSL_SET_VALIDVALUE(pdwBehavior);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTextValidValues
	{
		/*[in]*/ LPCWSTR pszText;
		HRESULT retValue;
	};

	STDMETHOD(SetText)(
		/*[in]*/ LPCWSTR pszText)
	{
		VSL_DEFINE_MOCK_METHOD(SetText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseBufferAnchorValidValues
	{
		/*[out]*/ long* piAnchorLine;
		/*[out]*/ long* piAnchorIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseBufferAnchor)(
		/*[out]*/ long* piAnchorLine,
		/*[out]*/ long* piAnchorIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseBufferAnchor)

		VSL_SET_VALIDVALUE(piAnchorLine);

		VSL_SET_VALIDVALUE(piAnchorIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBaseBufferAnchorValidValues
	{
		/*[in]*/ long iAnchorLine;
		/*[in]*/ long iAnchorIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetBaseBufferAnchor)(
		/*[in]*/ long iAnchorLine,
		/*[in]*/ long iAnchorIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetBaseBufferAnchor)

		VSL_CHECK_VALIDVALUE(iAnchorLine);

		VSL_CHECK_VALIDVALUE(iAnchorIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClientDataValidValues
	{
		/*[out]*/ DWORD_PTR* pdwData;
		HRESULT retValue;
	};

	STDMETHOD(GetClientData)(
		/*[out]*/ DWORD_PTR* pdwData)
	{
		VSL_DEFINE_MOCK_METHOD(GetClientData)

		VSL_SET_VALIDVALUE(pdwData);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetClientDataValidValues
	{
		/*[in]*/ DWORD_PTR dwData;
		HRESULT retValue;
	};

	STDMETHOD(SetClientData)(
		/*[in]*/ DWORD_PTR dwData)
	{
		VSL_DEFINE_MOCK_METHOD(SetClientData)

		VSL_CHECK_VALIDVALUE(dwData);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvalidateValidValues
	{
		/*[in]*/ DWORD dwUpdate;
		HRESULT retValue;
	};

	STDMETHOD(Invalidate)(
		/*[in]*/ DWORD dwUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(Invalidate)

		VSL_CHECK_VALIDVALUE(dwUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsValidValidValues
	{
		/*[out]*/ BOOL* pfValid;
		HRESULT retValue;
	};

	STDMETHOD(IsValid)(
		/*[out]*/ BOOL* pfValid)
	{
		VSL_DEFINE_MOCK_METHOD(IsValid)

		VSL_SET_VALIDVALUE(pfValid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextLayerValidValues
	{
		/*[out]*/ IVsTextLayer** ppLayer;
		HRESULT retValue;
	};

	STDMETHOD(GetTextLayer)(
		/*[out]*/ IVsTextLayer** ppLayer)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextLayer)

		VSL_SET_VALIDVALUE_INTERFACE(ppLayer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSyntheticLayerSpanValidValues
	{
		/*[out]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetSyntheticLayerSpan)(
		/*[out]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetSyntheticLayerSpan)

		VSL_SET_VALIDVALUE(pSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextImageValidValues
	{
		/*[out]*/ IVsTextImage** ppImage;
		HRESULT retValue;
	};

	STDMETHOD(GetTextImage)(
		/*[out]*/ IVsTextImage** ppImage)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextImage)

		VSL_SET_VALIDVALUE_INTERFACE(ppImage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSYNTHETICREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
