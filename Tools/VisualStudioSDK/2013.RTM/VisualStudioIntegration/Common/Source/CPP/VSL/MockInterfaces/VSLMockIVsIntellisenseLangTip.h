/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSELANGTIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSELANGTIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsIntellisenseLangTipNotImpl :
	public IVsIntellisenseLangTip
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseLangTipNotImpl)

public:

	typedef IVsIntellisenseLangTip Interface;

	STDMETHOD(Initialize)(
		/*[in]*/ IVsIntellisenseHost* /*pHost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizePreferences)(
		/*[in]*/ RECT* /*prcCtxBounds*/,
		/*[in]*/ TIPSIZEDATA* /*pSizeData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Create)(
		/*[in]*/ IVsTipWindow* /*pTipWnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)(
		/*[in]*/ IVsTipWindow* /*pTipWnd*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdatePosition)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizeY)(
		/*[out]*/ short* /*pSizeY*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ BOOL /*fDeleteThis*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsActive)(
		/*[out]*/ BOOL* /*pfIsActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOverloadCount)(
		/*[out]*/ long* /*plOverloadCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ScrollUp)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ScrollDown)()VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseLangTipMockImpl :
	public IVsIntellisenseLangTip,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseLangTipMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseLangTipMockImpl)

	typedef IVsIntellisenseLangTip Interface;
	struct InitializeValidValues
	{
		/*[in]*/ IVsIntellisenseHost* pHost;
		HRESULT retValue;
	};

	STDMETHOD(Initialize)(
		/*[in]*/ IVsIntellisenseHost* pHost)
	{
		VSL_DEFINE_MOCK_METHOD(Initialize)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizePreferencesValidValues
	{
		/*[in]*/ RECT* prcCtxBounds;
		/*[in]*/ TIPSIZEDATA* pSizeData;
		HRESULT retValue;
	};

	STDMETHOD(GetSizePreferences)(
		/*[in]*/ RECT* prcCtxBounds,
		/*[in]*/ TIPSIZEDATA* pSizeData)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizePreferences)

		VSL_CHECK_VALIDVALUE_POINTER(prcCtxBounds);

		VSL_CHECK_VALIDVALUE_POINTER(pSizeData);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateValidValues
	{
		/*[in]*/ IVsTipWindow* pTipWnd;
		HRESULT retValue;
	};

	STDMETHOD(Create)(
		/*[in]*/ IVsTipWindow* pTipWnd)
	{
		VSL_DEFINE_MOCK_METHOD(Create)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTipWnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateValidValues
	{
		/*[in]*/ IVsTipWindow* pTipWnd;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(Update)(
		/*[in]*/ IVsTipWindow* pTipWnd,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(Update)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTipWnd);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdatePositionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdatePosition)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdatePosition)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeYValidValues
	{
		/*[out]*/ short* pSizeY;
		HRESULT retValue;
	};

	STDMETHOD(GetSizeY)(
		/*[out]*/ short* pSizeY)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizeY)

		VSL_SET_VALIDVALUE(pSizeY);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		/*[in]*/ BOOL fDeleteThis;
		HRESULT retValue;
	};

	STDMETHOD(Close)(
		/*[in]*/ BOOL fDeleteThis)
	{
		VSL_DEFINE_MOCK_METHOD(Close)

		VSL_CHECK_VALIDVALUE(fDeleteThis);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsActiveValidValues
	{
		/*[out]*/ BOOL* pfIsActive;
		HRESULT retValue;
	};

	STDMETHOD(IsActive)(
		/*[out]*/ BOOL* pfIsActive)
	{
		VSL_DEFINE_MOCK_METHOD(IsActive)

		VSL_SET_VALIDVALUE(pfIsActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOverloadCountValidValues
	{
		/*[out]*/ long* plOverloadCount;
		HRESULT retValue;
	};

	STDMETHOD(GetOverloadCount)(
		/*[out]*/ long* plOverloadCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetOverloadCount)

		VSL_SET_VALIDVALUE(plOverloadCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct ScrollUpValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ScrollUp)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ScrollUp)

		VSL_RETURN_VALIDVALUES();
	}
	struct ScrollDownValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ScrollDown)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ScrollDown)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSELANGTIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
