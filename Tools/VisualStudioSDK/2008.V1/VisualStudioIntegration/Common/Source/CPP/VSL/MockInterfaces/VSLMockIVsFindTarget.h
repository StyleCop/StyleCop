/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFindTargetNotImpl :
	public IVsFindTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindTargetNotImpl)

public:

	typedef IVsFindTarget Interface;

	STDMETHOD(GetCapabilities)(
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ BOOL* /*pfImage*/,
		/*[out]*/ VSFINDOPTIONS* /*pgrfOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProperty)(
		/*[in]*/ VSFTPROPID /*propid*/,
		/*[out,retval]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSearchImage)(
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ IVsTextSpanSet** /*ppSpans*/,
		/*[out,retval]*/ IVsTextImage** /*ppTextImage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Find)(
		/*[in]*/ LPCOLESTR /*pszSearch*/,
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[in]*/ BOOL /*fResetStartPoint*/,
		/*[in]*/ IVsFindHelper* /*pHelper*/,
		/*[out,retval]*/ VSFINDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Replace)(
		/*[in]*/ LPCOLESTR /*pszSearch*/,
		/*[in]*/ LPCOLESTR /*pszReplace*/,
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[in]*/ BOOL /*fResetStartPoint*/,
		/*[in]*/ IVsFindHelper* /*pHelper*/,
		/*[out,retval]*/ BOOL* /*pfReplaced*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMatchRect)(
		/*[out,retval]*/ PRECT /*prc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateTo)(
		/*[in]*/ const TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentSpan)(
		/*[out,retval]*/ TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFindState)(
		/*[in]*/ IUnknown* /*punk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFindState)(
		/*[out,retval]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyFindTarget)(
		/*[in]*/ VSFTNOTIFY /*notification*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MarkSpan)(
		/*[in]*/ const TextSpan* /*pts*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindTargetMockImpl :
	public IVsFindTarget,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindTargetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindTargetMockImpl)

	typedef IVsFindTarget Interface;
	struct GetCapabilitiesValidValues
	{
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ BOOL* pfImage;
		/*[out]*/ VSFINDOPTIONS* pgrfOptions;
		HRESULT retValue;
	};

	STDMETHOD(GetCapabilities)(
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ BOOL* pfImage,
		/*[out]*/ VSFINDOPTIONS* pgrfOptions)
	{
		VSL_DEFINE_MOCK_METHOD(GetCapabilities)

		VSL_SET_VALIDVALUE(pfImage);

		VSL_SET_VALIDVALUE(pgrfOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyValidValues
	{
		/*[in]*/ VSFTPROPID propid;
		/*[out,retval]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSFTPROPID propid,
		/*[out,retval]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSearchImageValidValues
	{
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ IVsTextSpanSet** ppSpans;
		/*[out,retval]*/ IVsTextImage** ppTextImage;
		HRESULT retValue;
	};

	STDMETHOD(GetSearchImage)(
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[out,custom(DE89D360-C06A-11d2-936C-D714766E8B50,"optional")]*/ IVsTextSpanSet** ppSpans,
		/*[out,retval]*/ IVsTextImage** ppTextImage)
	{
		VSL_DEFINE_MOCK_METHOD(GetSearchImage)

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_SET_VALIDVALUE_INTERFACE(ppSpans);

		VSL_SET_VALIDVALUE_INTERFACE(ppTextImage);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindValidValues
	{
		/*[in]*/ LPCOLESTR pszSearch;
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[in]*/ BOOL fResetStartPoint;
		/*[in]*/ IVsFindHelper* pHelper;
		/*[out,retval]*/ VSFINDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(Find)(
		/*[in]*/ LPCOLESTR pszSearch,
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[in]*/ BOOL fResetStartPoint,
		/*[in]*/ IVsFindHelper* pHelper,
		/*[out,retval]*/ VSFINDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(Find)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSearch);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE(fResetStartPoint);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHelper);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceValidValues
	{
		/*[in]*/ LPCOLESTR pszSearch;
		/*[in]*/ LPCOLESTR pszReplace;
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[in]*/ BOOL fResetStartPoint;
		/*[in]*/ IVsFindHelper* pHelper;
		/*[out,retval]*/ BOOL* pfReplaced;
		HRESULT retValue;
	};

	STDMETHOD(Replace)(
		/*[in]*/ LPCOLESTR pszSearch,
		/*[in]*/ LPCOLESTR pszReplace,
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[in]*/ BOOL fResetStartPoint,
		/*[in]*/ IVsFindHelper* pHelper,
		/*[out,retval]*/ BOOL* pfReplaced)
	{
		VSL_DEFINE_MOCK_METHOD(Replace)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSearch);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReplace);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE(fResetStartPoint);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHelper);

		VSL_SET_VALIDVALUE(pfReplaced);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMatchRectValidValues
	{
		/*[out,retval]*/ PRECT prc;
		HRESULT retValue;
	};

	STDMETHOD(GetMatchRect)(
		/*[out,retval]*/ PRECT prc)
	{
		VSL_DEFINE_MOCK_METHOD(GetMatchRect)

		VSL_SET_VALIDVALUE(prc);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToValidValues
	{
		/*[in]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(NavigateTo)(
		/*[in]*/ const TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateTo)

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentSpanValidValues
	{
		/*[out,retval]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentSpan)(
		/*[out,retval]*/ TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentSpan)

		VSL_SET_VALIDVALUE(pts);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFindStateValidValues
	{
		/*[in]*/ IUnknown* punk;
		HRESULT retValue;
	};

	STDMETHOD(SetFindState)(
		/*[in]*/ IUnknown* punk)
	{
		VSL_DEFINE_MOCK_METHOD(SetFindState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFindStateValidValues
	{
		/*[out,retval]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetFindState)(
		/*[out,retval]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetFindState)

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyFindTargetValidValues
	{
		/*[in]*/ VSFTNOTIFY notification;
		HRESULT retValue;
	};

	STDMETHOD(NotifyFindTarget)(
		/*[in]*/ VSFTNOTIFY notification)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyFindTarget)

		VSL_CHECK_VALIDVALUE(notification);

		VSL_RETURN_VALIDVALUES();
	}
	struct MarkSpanValidValues
	{
		/*[in]*/ TextSpan* pts;
		HRESULT retValue;
	};

	STDMETHOD(MarkSpan)(
		/*[in]*/ const TextSpan* pts)
	{
		VSL_DEFINE_MOCK_METHOD(MarkSpan)

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
