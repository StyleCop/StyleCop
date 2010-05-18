/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTSTREAMMARKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTSTREAMMARKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextStreamMarkerNotImpl :
	public IVsTextStreamMarker
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextStreamMarkerNotImpl)

public:

	typedef IVsTextStreamMarker Interface;

	STDMETHOD(GetStreamBuffer)(
		/*[out]*/ IVsTextStream** /*ppBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetSpan)(
		/*[in]*/ long /*iNewPos*/,
		/*[in]*/ long /*iNewLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentSpan)(
		/*[out]*/ long* /*piPos*/,
		/*[out]*/ long* /*piLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetType)(
		/*[out]*/ long* /*piMarkerType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetType)(
		/*[in]*/ long /*iMarkerType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVisualStyle)(
		/*[out]*/ DWORD* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVisualStyle)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invalidate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawGlyph)(
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTipText)(
		/*[out,optional]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseClient)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMarkerCommandInfo)(
		/*[in]*/ long /*iItem*/,
		/*[out,custom(uuid_IVsTextMarker,"optional")]*/ BSTR* /*pbstrText*/,
		/*[out]*/ DWORD* /*pcmdf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecMarkerCommand)(
		/*[in]*/ long /*iItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBehavior)(
		/*[out]*/ DWORD* /*pdwBehavior*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBehavior)(
		/*[in]*/ DWORD /*dwBehavior*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriorityIndex)(
		/*[out]*/ long* /*piPriorityIndex*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextStreamMarkerMockImpl :
	public IVsTextStreamMarker,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextStreamMarkerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextStreamMarkerMockImpl)

	typedef IVsTextStreamMarker Interface;
	struct GetStreamBufferValidValues
	{
		/*[out]*/ IVsTextStream** ppBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetStreamBuffer)(
		/*[out]*/ IVsTextStream** ppBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetStreamBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetSpanValidValues
	{
		/*[in]*/ long iNewPos;
		/*[in]*/ long iNewLen;
		HRESULT retValue;
	};

	STDMETHOD(ResetSpan)(
		/*[in]*/ long iNewPos,
		/*[in]*/ long iNewLen)
	{
		VSL_DEFINE_MOCK_METHOD(ResetSpan)

		VSL_CHECK_VALIDVALUE(iNewPos);

		VSL_CHECK_VALIDVALUE(iNewLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentSpanValidValues
	{
		/*[out]*/ long* piPos;
		/*[out]*/ long* piLen;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentSpan)(
		/*[out]*/ long* piPos,
		/*[out]*/ long* piLen)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentSpan)

		VSL_SET_VALIDVALUE(piPos);

		VSL_SET_VALIDVALUE(piLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeValidValues
	{
		/*[out]*/ long* piMarkerType;
		HRESULT retValue;
	};

	STDMETHOD(GetType)(
		/*[out]*/ long* piMarkerType)
	{
		VSL_DEFINE_MOCK_METHOD(GetType)

		VSL_SET_VALIDVALUE(piMarkerType);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTypeValidValues
	{
		/*[in]*/ long iMarkerType;
		HRESULT retValue;
	};

	STDMETHOD(SetType)(
		/*[in]*/ long iMarkerType)
	{
		VSL_DEFINE_MOCK_METHOD(SetType)

		VSL_CHECK_VALIDVALUE(iMarkerType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVisualStyleValidValues
	{
		/*[out]*/ DWORD* pdwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetVisualStyle)(
		/*[out]*/ DWORD* pdwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetVisualStyle)

		VSL_SET_VALIDVALUE(pdwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVisualStyleValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetVisualStyle)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetVisualStyle)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvalidateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Invalidate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Invalidate)

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawGlyphValidValues
	{
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		HRESULT retValue;
	};

	STDMETHOD(DrawGlyph)(
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect)
	{
		VSL_DEFINE_MOCK_METHOD(DrawGlyph)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTipTextValidValues
	{
		/*[out,optional]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetTipText)(
		/*[out,optional]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTipText)

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseClientValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnadviseClient)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnadviseClient)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMarkerCommandInfoValidValues
	{
		/*[in]*/ long iItem;
		/*[out,custom(uuid_IVsTextMarker,"optional")]*/ BSTR* pbstrText;
		/*[out]*/ DWORD* pcmdf;
		HRESULT retValue;
	};

	STDMETHOD(GetMarkerCommandInfo)(
		/*[in]*/ long iItem,
		/*[out,custom(uuid_IVsTextMarker,"optional")]*/ BSTR* pbstrText,
		/*[out]*/ DWORD* pcmdf)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarkerCommandInfo)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_SET_VALIDVALUE(pcmdf);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecMarkerCommandValidValues
	{
		/*[in]*/ long iItem;
		HRESULT retValue;
	};

	STDMETHOD(ExecMarkerCommand)(
		/*[in]*/ long iItem)
	{
		VSL_DEFINE_MOCK_METHOD(ExecMarkerCommand)

		VSL_CHECK_VALIDVALUE(iItem);

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
	struct SetBehaviorValidValues
	{
		/*[in]*/ DWORD dwBehavior;
		HRESULT retValue;
	};

	STDMETHOD(SetBehavior)(
		/*[in]*/ DWORD dwBehavior)
	{
		VSL_DEFINE_MOCK_METHOD(SetBehavior)

		VSL_CHECK_VALIDVALUE(dwBehavior);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPriorityIndexValidValues
	{
		/*[out]*/ long* piPriorityIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetPriorityIndex)(
		/*[out]*/ long* piPriorityIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetPriorityIndex)

		VSL_SET_VALIDVALUE(piPriorityIndex);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTSTREAMMARKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
