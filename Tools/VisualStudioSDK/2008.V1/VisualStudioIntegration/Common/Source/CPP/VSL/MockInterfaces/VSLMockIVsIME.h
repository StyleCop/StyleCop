/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSIME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSIME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsIMENotImpl :
	public IVsIME
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIMENotImpl)

public:

	typedef IVsIME Interface;

	STDMETHOD(IsActive)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Activate)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Deactivate)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FDeactivate)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ BOOL /*fDisable*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFont)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ HFONT /*hf*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCurPos)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDefCurPos)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AttachContext)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ BOOL /*fAttach*/,
		/*[out]*/ VSIME_ERR* /*perr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImmContext)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ HIMC* /*phimc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseImmContext)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ HIMC /*himc*/,
		/*[out]*/ BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImmCompositionString)(
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[out]*/ BSTR* /*pbstrCompString*/,
		/*[out]*/ LONG* /*plRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetImmCompositionString)(
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[in]*/ BSTR /*bstrCompString*/,
		/*[in]*/ BSTR /*bstrReadString*/,
		/*[out]*/ BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetImmCandidateWindow)(
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ CANDIDATEFORM* /*lpcf*/,
		/*[out]*/ BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Notify)(
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ DWORD /*dwAction*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[in]*/ DWORD /*dwValue*/,
		/*[out]*/ BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Escape)(
		/*[in]*/ HKL /*hkl*/,
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ UINT /*uEsc*/,
		/*[in,out]*/ BSTR /*bstrData*/,
		/*[out]*/ LONG* /*plRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultWindow)(
		/*[in]*/ HWND /*hwnd*/,
		/*[out]*/ HWND* /*phRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImmCompositionStringW)(
		/*[in]*/ HIMC /*himc*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[out]*/ BSTR* /*pbstrCompString*/,
		/*[out]*/ LONG* /*plRetVal*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIMEMockImpl :
	public IVsIME,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIMEMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIMEMockImpl)

	typedef IVsIME Interface;
	struct IsActiveValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(IsActive)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(IsActive)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivateValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(Activate)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(Activate)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeactivateValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(Deactivate)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(Deactivate)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct FDeactivateValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ BOOL fDisable;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(FDeactivate)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ BOOL fDisable,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(FDeactivate)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(fDisable);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFontValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ HFONT hf;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(SetFont)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ HFONT hf,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(SetFont)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(hf);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCurPosValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(SetCurPos)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(SetCurPos)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDefCurPosValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(SetDefCurPos)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(SetDefCurPos)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct AttachContextValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ BOOL fAttach;
		/*[out]*/ VSIME_ERR* perr;
		HRESULT retValue;
	};

	STDMETHOD(AttachContext)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ BOOL fAttach,
		/*[out]*/ VSIME_ERR* perr)
	{
		VSL_DEFINE_MOCK_METHOD(AttachContext)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(fAttach);

		VSL_SET_VALIDVALUE(perr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImmContextValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ HIMC* phimc;
		HRESULT retValue;
	};

	STDMETHOD(GetImmContext)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ HIMC* phimc)
	{
		VSL_DEFINE_MOCK_METHOD(GetImmContext)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(phimc);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseImmContextValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ HIMC himc;
		/*[out]*/ BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseImmContext)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ HIMC himc,
		/*[out]*/ BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseImmContext)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(himc);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImmCompositionStringValidValues
	{
		/*[in]*/ HIMC himc;
		/*[in]*/ DWORD dwIndex;
		/*[out]*/ BSTR* pbstrCompString;
		/*[out]*/ LONG* plRetVal;
		HRESULT retValue;
	};

	STDMETHOD(GetImmCompositionString)(
		/*[in]*/ HIMC himc,
		/*[in]*/ DWORD dwIndex,
		/*[out]*/ BSTR* pbstrCompString,
		/*[out]*/ LONG* plRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetImmCompositionString)

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrCompString);

		VSL_SET_VALIDVALUE(plRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetImmCompositionStringValidValues
	{
		/*[in]*/ HIMC himc;
		/*[in]*/ DWORD dwIndex;
		/*[in]*/ BSTR bstrCompString;
		/*[in]*/ BSTR bstrReadString;
		/*[out]*/ BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(SetImmCompositionString)(
		/*[in]*/ HIMC himc,
		/*[in]*/ DWORD dwIndex,
		/*[in]*/ BSTR bstrCompString,
		/*[in]*/ BSTR bstrReadString,
		/*[out]*/ BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetImmCompositionString)

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCompString);

		VSL_CHECK_VALIDVALUE_BSTR(bstrReadString);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetImmCandidateWindowValidValues
	{
		/*[in]*/ HIMC himc;
		/*[in]*/ CANDIDATEFORM* lpcf;
		/*[out]*/ BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(SetImmCandidateWindow)(
		/*[in]*/ HIMC himc,
		/*[in]*/ CANDIDATEFORM* lpcf,
		/*[out]*/ BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetImmCandidateWindow)

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE_POINTER(lpcf);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyValidValues
	{
		/*[in]*/ HIMC himc;
		/*[in]*/ DWORD dwAction;
		/*[in]*/ DWORD dwIndex;
		/*[in]*/ DWORD dwValue;
		/*[out]*/ BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(Notify)(
		/*[in]*/ HIMC himc,
		/*[in]*/ DWORD dwAction,
		/*[in]*/ DWORD dwIndex,
		/*[in]*/ DWORD dwValue,
		/*[out]*/ BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(Notify)

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE(dwAction);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_CHECK_VALIDVALUE(dwValue);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct EscapeValidValues
	{
		/*[in]*/ HKL hkl;
		/*[in]*/ HIMC himc;
		/*[in]*/ UINT uEsc;
		/*[in,out]*/ BSTR bstrData;
		/*[out]*/ LONG* plRetVal;
		HRESULT retValue;
	};

	STDMETHOD(Escape)(
		/*[in]*/ HKL hkl,
		/*[in]*/ HIMC himc,
		/*[in]*/ UINT uEsc,
		/*[in,out]*/ BSTR bstrData,
		/*[out]*/ LONG* plRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(Escape)

		VSL_CHECK_VALIDVALUE(hkl);

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE(uEsc);

		VSL_SET_VALIDVALUE(bstrData);

		VSL_SET_VALIDVALUE(plRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultWindowValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[out]*/ HWND* phRetVal;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultWindow)(
		/*[in]*/ HWND hwnd,
		/*[out]*/ HWND* phRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultWindow)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_SET_VALIDVALUE(phRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImmCompositionStringWValidValues
	{
		/*[in]*/ HIMC himc;
		/*[in]*/ DWORD dwIndex;
		/*[out]*/ BSTR* pbstrCompString;
		/*[out]*/ LONG* plRetVal;
		HRESULT retValue;
	};

	STDMETHOD(GetImmCompositionStringW)(
		/*[in]*/ HIMC himc,
		/*[in]*/ DWORD dwIndex,
		/*[out]*/ BSTR* pbstrCompString,
		/*[out]*/ LONG* plRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetImmCompositionStringW)

		VSL_CHECK_VALIDVALUE(himc);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrCompString);

		VSL_SET_VALIDVALUE(plRetVal);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSIME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
