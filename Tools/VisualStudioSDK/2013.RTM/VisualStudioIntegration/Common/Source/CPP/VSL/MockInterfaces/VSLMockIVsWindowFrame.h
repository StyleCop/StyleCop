/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWindowFrameNotImpl :
	public IVsWindowFrame
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameNotImpl)

public:

	typedef IVsWindowFrame Interface;

	STDMETHOD(Show)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsVisible)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowNoActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseFrame)(
		/*[in]*/ FRAMECLOSE /*grfSaveOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFramePos)(
		/*[in]*/ VSSETFRAMEPOS /*dwSFP*/,
		/*[in]*/ REFGUID /*rguidRelativeTo*/,
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFramePos)(
		/*[out]*/ VSSETFRAMEPOS* /*pdwSFP*/,
		/*[out]*/ GUID* /*pguidRelativeTo*/,
		/*[out]*/ int* /*px*/,
		/*[out]*/ int* /*py*/,
		/*[out]*/ int* /*pcx*/,
		/*[out]*/ int* /*pcy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProperty)(
		/*[in]*/ VSFPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSFPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSFPROPID /*propid*/,
		/*[out]*/ GUID* /*pguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSFPROPID /*propid*/,
		/*[in]*/ REFGUID /*rguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryViewInterface)(
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppv*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsOnScreen)(
		/*[out,retval]*/ BOOL* /*pfOnScreen*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowFrameMockImpl :
	public IVsWindowFrame,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowFrameMockImpl)

	typedef IVsWindowFrame Interface;
	struct ShowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Show)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Show)

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Hide)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Hide)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsVisibleValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsVisible)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsVisible)

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowNoActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowNoActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowNoActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseFrameValidValues
	{
		/*[in]*/ FRAMECLOSE grfSaveOptions;
		HRESULT retValue;
	};

	STDMETHOD(CloseFrame)(
		/*[in]*/ FRAMECLOSE grfSaveOptions)
	{
		VSL_DEFINE_MOCK_METHOD(CloseFrame)

		VSL_CHECK_VALIDVALUE(grfSaveOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFramePosValidValues
	{
		/*[in]*/ VSSETFRAMEPOS dwSFP;
		/*[in]*/ REFGUID rguidRelativeTo;
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		HRESULT retValue;
	};

	STDMETHOD(SetFramePos)(
		/*[in]*/ VSSETFRAMEPOS dwSFP,
		/*[in]*/ REFGUID rguidRelativeTo,
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ int cx,
		/*[in]*/ int cy)
	{
		VSL_DEFINE_MOCK_METHOD(SetFramePos)

		VSL_CHECK_VALIDVALUE(dwSFP);

		VSL_CHECK_VALIDVALUE(rguidRelativeTo);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFramePosValidValues
	{
		/*[out]*/ VSSETFRAMEPOS* pdwSFP;
		/*[out]*/ GUID* pguidRelativeTo;
		/*[out]*/ int* px;
		/*[out]*/ int* py;
		/*[out]*/ int* pcx;
		/*[out]*/ int* pcy;
		HRESULT retValue;
	};

	STDMETHOD(GetFramePos)(
		/*[out]*/ VSSETFRAMEPOS* pdwSFP,
		/*[out]*/ GUID* pguidRelativeTo,
		/*[out]*/ int* px,
		/*[out]*/ int* py,
		/*[out]*/ int* pcx,
		/*[out]*/ int* pcy)
	{
		VSL_DEFINE_MOCK_METHOD(GetFramePos)

		VSL_SET_VALIDVALUE(pdwSFP);

		VSL_SET_VALIDVALUE(pguidRelativeTo);

		VSL_SET_VALIDVALUE(px);

		VSL_SET_VALIDVALUE(py);

		VSL_SET_VALIDVALUE(pcx);

		VSL_SET_VALIDVALUE(pcy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyValidValues
	{
		/*[in]*/ VSFPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSFPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSFPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSFPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidPropertyValidValues
	{
		/*[in]*/ VSFPROPID propid;
		/*[out]*/ GUID* pguid;
		HRESULT retValue;
	};

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSFPROPID propid,
		/*[out]*/ GUID* pguid)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuidProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE(pguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetGuidPropertyValidValues
	{
		/*[in]*/ VSFPROPID propid;
		/*[in]*/ REFGUID rguid;
		HRESULT retValue;
	};

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSFPROPID propid,
		/*[in]*/ REFGUID rguid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGuidProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(rguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryViewInterfaceValidValues
	{
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppv;
		HRESULT retValue;
	};

	STDMETHOD(QueryViewInterface)(
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(QueryViewInterface)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsOnScreenValidValues
	{
		/*[out,retval]*/ BOOL* pfOnScreen;
		HRESULT retValue;
	};

	STDMETHOD(IsOnScreen)(
		/*[out,retval]*/ BOOL* pfOnScreen)
	{
		VSL_DEFINE_MOCK_METHOD(IsOnScreen)

		VSL_SET_VALIDVALUE(pfOnScreen);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
