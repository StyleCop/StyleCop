/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiddenRegionNotImpl :
	public IVsHiddenRegion
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenRegionNotImpl)

public:

	typedef IVsHiddenRegion Interface;

	STDMETHOD(GetType)(
		/*[out]*/ long* /*piHiddenRegionType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBehavior)(
		/*[out]*/ DWORD* /*pdwBehavior*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetState)(
		/*[out]*/ DWORD* /*dwState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetState)(
		/*[in]*/ DWORD /*dwState*/,
		/*[in]*/ DWORD /*dwUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBanner)(
		/*[out]*/ BSTR* /*pbstrBanner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBanner)(
		/*[in]*/ LPCWSTR /*pszBanner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpan)(
		/*[out]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpan)(
		/*[in]*/ TextSpan* /*pSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClientData)(
		/*[out]*/ DWORD_PTR* /*pdwData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetClientData)(
		/*[in]*/ DWORD_PTR /*dwData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invalidate)(
		/*[in]*/ DWORD /*dwUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValid)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseBuffer)(
		/*[out]*/ IVsTextLines** /*ppBuffer*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenRegionMockImpl :
	public IVsHiddenRegion,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenRegionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenRegionMockImpl)

	typedef IVsHiddenRegion Interface;
	struct GetTypeValidValues
	{
		/*[out]*/ long* piHiddenRegionType;
		HRESULT retValue;
	};

	STDMETHOD(GetType)(
		/*[out]*/ long* piHiddenRegionType)
	{
		VSL_DEFINE_MOCK_METHOD(GetType)

		VSL_SET_VALIDVALUE(piHiddenRegionType);

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
	struct GetStateValidValues
	{
		/*[out]*/ DWORD* dwState;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[out]*/ DWORD* dwState)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(dwState);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStateValidValues
	{
		/*[in]*/ DWORD dwState;
		/*[in]*/ DWORD dwUpdate;
		HRESULT retValue;
	};

	STDMETHOD(SetState)(
		/*[in]*/ DWORD dwState,
		/*[in]*/ DWORD dwUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(SetState)

		VSL_CHECK_VALIDVALUE(dwState);

		VSL_CHECK_VALIDVALUE(dwUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBannerValidValues
	{
		/*[out]*/ BSTR* pbstrBanner;
		HRESULT retValue;
	};

	STDMETHOD(GetBanner)(
		/*[out]*/ BSTR* pbstrBanner)
	{
		VSL_DEFINE_MOCK_METHOD(GetBanner)

		VSL_SET_VALIDVALUE_BSTR(pbstrBanner);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBannerValidValues
	{
		/*[in]*/ LPCWSTR pszBanner;
		HRESULT retValue;
	};

	STDMETHOD(SetBanner)(
		/*[in]*/ LPCWSTR pszBanner)
	{
		VSL_DEFINE_MOCK_METHOD(SetBanner)

		VSL_CHECK_VALIDVALUE_STRINGW(pszBanner);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpanValidValues
	{
		/*[out]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(GetSpan)(
		/*[out]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpan)

		VSL_SET_VALIDVALUE(pSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpanValidValues
	{
		/*[in]*/ TextSpan* pSpan;
		HRESULT retValue;
	};

	STDMETHOD(SetSpan)(
		/*[in]*/ TextSpan* pSpan)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpan)

		VSL_CHECK_VALIDVALUE_POINTER(pSpan);

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
		HRESULT retValue;
	};

	STDMETHOD(IsValid)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsValid)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseBuffer)(
		/*[out]*/ IVsTextLines** ppBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuffer);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENREGION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
