/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSWATCHCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSWATCHCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSwatchClientNotImpl :
	public IVsSwatchClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSwatchClientNotImpl)

public:

	typedef IVsSwatchClient Interface;

	STDMETHOD(GetMetrics)(
		/*[in,out]*/ VSSWATCHMETRICS* /*psm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSelection)(
		/*[in,out]*/ int* /*pxCur*/,
		/*[in,out]*/ int* /*pyCur*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectionUpdate)(
		/*[in,out]*/ int* /*pxCur*/,
		/*[in,out]*/ int* /*pyCur*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenderCell)(
		/*[in]*/ VSSWATCHRENDER* /*pRender*/,
		/*[in,out]*/ int* /*ptcidRet*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectCell)(
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCellTooltip)(
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[out,retval]*/ BSTR* /*pbstrTooltip*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnabledCount)(
		/*[in,out]*/ int* /*pcEnabled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RealizePalette)(
		/*[in]*/ HDC /*hdc*/,
		/*[out,retval]*/ HPALETTE* /*phpalOld*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSwatchClientMockImpl :
	public IVsSwatchClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSwatchClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSwatchClientMockImpl)

	typedef IVsSwatchClient Interface;
	struct GetMetricsValidValues
	{
		/*[in,out]*/ VSSWATCHMETRICS* psm;
		HRESULT retValue;
	};

	STDMETHOD(GetMetrics)(
		/*[in,out]*/ VSSWATCHMETRICS* psm)
	{
		VSL_DEFINE_MOCK_METHOD(GetMetrics)

		VSL_SET_VALIDVALUE(psm);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSelectionValidValues
	{
		/*[in,out]*/ int* pxCur;
		/*[in,out]*/ int* pyCur;
		HRESULT retValue;
	};

	STDMETHOD(GetSelection)(
		/*[in,out]*/ int* pxCur,
		/*[in,out]*/ int* pyCur)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelection)

		VSL_SET_VALIDVALUE(pxCur);

		VSL_SET_VALIDVALUE(pyCur);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectionUpdateValidValues
	{
		/*[in,out]*/ int* pxCur;
		/*[in,out]*/ int* pyCur;
		HRESULT retValue;
	};

	STDMETHOD(SelectionUpdate)(
		/*[in,out]*/ int* pxCur,
		/*[in,out]*/ int* pyCur)
	{
		VSL_DEFINE_MOCK_METHOD(SelectionUpdate)

		VSL_SET_VALIDVALUE(pxCur);

		VSL_SET_VALIDVALUE(pyCur);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenderCellValidValues
	{
		/*[in]*/ VSSWATCHRENDER* pRender;
		/*[in,out]*/ int* ptcidRet;
		HRESULT retValue;
	};

	STDMETHOD(RenderCell)(
		/*[in]*/ VSSWATCHRENDER* pRender,
		/*[in,out]*/ int* ptcidRet)
	{
		VSL_DEFINE_MOCK_METHOD(RenderCell)

		VSL_CHECK_VALIDVALUE_POINTER(pRender);

		VSL_SET_VALIDVALUE(ptcidRet);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectCellValidValues
	{
		/*[in]*/ int x;
		/*[in]*/ int y;
		HRESULT retValue;
	};

	STDMETHOD(SelectCell)(
		/*[in]*/ int x,
		/*[in]*/ int y)
	{
		VSL_DEFINE_MOCK_METHOD(SelectCell)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCellTooltipValidValues
	{
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[out,retval]*/ BSTR* pbstrTooltip;
		HRESULT retValue;
	};

	STDMETHOD(GetCellTooltip)(
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[out,retval]*/ BSTR* pbstrTooltip)
	{
		VSL_DEFINE_MOCK_METHOD(GetCellTooltip)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_SET_VALIDVALUE_BSTR(pbstrTooltip);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEnabledCountValidValues
	{
		/*[in,out]*/ int* pcEnabled;
		HRESULT retValue;
	};

	STDMETHOD(GetEnabledCount)(
		/*[in,out]*/ int* pcEnabled)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnabledCount)

		VSL_SET_VALIDVALUE(pcEnabled);

		VSL_RETURN_VALIDVALUES();
	}
	struct RealizePaletteValidValues
	{
		/*[in]*/ HDC hdc;
		/*[out,retval]*/ HPALETTE* phpalOld;
		HRESULT retValue;
	};

	STDMETHOD(RealizePalette)(
		/*[in]*/ HDC hdc,
		/*[out,retval]*/ HPALETTE* phpalOld)
	{
		VSL_DEFINE_MOCK_METHOD(RealizePalette)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_SET_VALIDVALUE(phpalOld);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSWATCHCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
