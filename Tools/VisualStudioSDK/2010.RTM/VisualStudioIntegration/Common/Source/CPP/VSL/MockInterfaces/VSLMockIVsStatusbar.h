/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSTATUSBAR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSTATUSBAR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsStatusbarNotImpl :
	public IVsStatusbar
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStatusbarNotImpl)

public:

	typedef IVsStatusbar Interface;

	STDMETHOD(Clear)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetText)(
		/*[in]*/ LPCOLESTR /*pszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Progress)(
		/*[in,out]*/ VSCOOKIE* /*pdwCookie*/,
		/*[in]*/ BOOL /*fInProgress*/,
		/*[in]*/ LPCOLESTR /*pwszLabel*/,
		/*[in]*/ ULONG /*nComplete*/,
		/*[in]*/ ULONG /*nTotal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Animation)(
		/*[in]*/ BOOL /*fOnOff*/,
		/*[in]*/ VARIANT* /*pvIcon*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSelMode)(
		/*[in]*/ VARIANT* /*pvSelMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetInsMode)(
		/*[in]*/ VARIANT* /*pvInsMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLineChar)(
		/*[in]*/ VARIANT* /*pvLine*/,
		/*[in]*/ VARIANT* /*pvChar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetXYWH)(
		/*[in]*/ VARIANT* /*pvX*/,
		/*[in]*/ VARIANT* /*pvY*/,
		/*[in]*/ VARIANT* /*pvW*/,
		/*[in]*/ VARIANT* /*pvH*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLineColChar)(
		/*[in]*/ VARIANT* /*pvLine*/,
		/*[in]*/ VARIANT* /*pvCol*/,
		/*[in]*/ VARIANT* /*pvChar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCurrentUser)(
		/*[in]*/ IVsStatusbarUser* /*pUser*/,
		/*[in]*/ BOOL* /*pfCurrent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetColorText)(
		/*[in]*/ LPCOLESTR /*pszText*/,
		/*[in]*/ COLORREF /*crForeColor*/,
		/*[in]*/ COLORREF /*crBackColor*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* /*pszText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreezeOutput)(
		/*[in]*/ BOOL /*fFreeze*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsFrozen)(
		/*[out]*/ BOOL* /*pfFrozen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFreezeCount)(
		/*[out]*/ long* /*plCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsStatusbarMockImpl :
	public IVsStatusbar,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStatusbarMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsStatusbarMockImpl)

	typedef IVsStatusbar Interface;
	struct ClearValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Clear)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Clear)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTextValidValues
	{
		/*[in]*/ LPCOLESTR pszText;
		HRESULT retValue;
	};

	STDMETHOD(SetText)(
		/*[in]*/ LPCOLESTR pszText)
	{
		VSL_DEFINE_MOCK_METHOD(SetText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ProgressValidValues
	{
		/*[in,out]*/ VSCOOKIE* pdwCookie;
		/*[in]*/ BOOL fInProgress;
		/*[in]*/ LPCOLESTR pwszLabel;
		/*[in]*/ ULONG nComplete;
		/*[in]*/ ULONG nTotal;
		HRESULT retValue;
	};

	STDMETHOD(Progress)(
		/*[in,out]*/ VSCOOKIE* pdwCookie,
		/*[in]*/ BOOL fInProgress,
		/*[in]*/ LPCOLESTR pwszLabel,
		/*[in]*/ ULONG nComplete,
		/*[in]*/ ULONG nTotal)
	{
		VSL_DEFINE_MOCK_METHOD(Progress)

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_CHECK_VALIDVALUE(fInProgress);

		VSL_CHECK_VALIDVALUE_STRINGW(pwszLabel);

		VSL_CHECK_VALIDVALUE(nComplete);

		VSL_CHECK_VALIDVALUE(nTotal);

		VSL_RETURN_VALIDVALUES();
	}
	struct AnimationValidValues
	{
		/*[in]*/ BOOL fOnOff;
		/*[in]*/ VARIANT* pvIcon;
		HRESULT retValue;
	};

	STDMETHOD(Animation)(
		/*[in]*/ BOOL fOnOff,
		/*[in]*/ VARIANT* pvIcon)
	{
		VSL_DEFINE_MOCK_METHOD(Animation)

		VSL_CHECK_VALIDVALUE(fOnOff);

		VSL_CHECK_VALIDVALUE_POINTER(pvIcon);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSelModeValidValues
	{
		/*[in]*/ VARIANT* pvSelMode;
		HRESULT retValue;
	};

	STDMETHOD(SetSelMode)(
		/*[in]*/ VARIANT* pvSelMode)
	{
		VSL_DEFINE_MOCK_METHOD(SetSelMode)

		VSL_CHECK_VALIDVALUE_POINTER(pvSelMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetInsModeValidValues
	{
		/*[in]*/ VARIANT* pvInsMode;
		HRESULT retValue;
	};

	STDMETHOD(SetInsMode)(
		/*[in]*/ VARIANT* pvInsMode)
	{
		VSL_DEFINE_MOCK_METHOD(SetInsMode)

		VSL_CHECK_VALIDVALUE_POINTER(pvInsMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLineCharValidValues
	{
		/*[in]*/ VARIANT* pvLine;
		/*[in]*/ VARIANT* pvChar;
		HRESULT retValue;
	};

	STDMETHOD(SetLineChar)(
		/*[in]*/ VARIANT* pvLine,
		/*[in]*/ VARIANT* pvChar)
	{
		VSL_DEFINE_MOCK_METHOD(SetLineChar)

		VSL_CHECK_VALIDVALUE_POINTER(pvLine);

		VSL_CHECK_VALIDVALUE_POINTER(pvChar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetXYWHValidValues
	{
		/*[in]*/ VARIANT* pvX;
		/*[in]*/ VARIANT* pvY;
		/*[in]*/ VARIANT* pvW;
		/*[in]*/ VARIANT* pvH;
		HRESULT retValue;
	};

	STDMETHOD(SetXYWH)(
		/*[in]*/ VARIANT* pvX,
		/*[in]*/ VARIANT* pvY,
		/*[in]*/ VARIANT* pvW,
		/*[in]*/ VARIANT* pvH)
	{
		VSL_DEFINE_MOCK_METHOD(SetXYWH)

		VSL_CHECK_VALIDVALUE_POINTER(pvX);

		VSL_CHECK_VALIDVALUE_POINTER(pvY);

		VSL_CHECK_VALIDVALUE_POINTER(pvW);

		VSL_CHECK_VALIDVALUE_POINTER(pvH);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLineColCharValidValues
	{
		/*[in]*/ VARIANT* pvLine;
		/*[in]*/ VARIANT* pvCol;
		/*[in]*/ VARIANT* pvChar;
		HRESULT retValue;
	};

	STDMETHOD(SetLineColChar)(
		/*[in]*/ VARIANT* pvLine,
		/*[in]*/ VARIANT* pvCol,
		/*[in]*/ VARIANT* pvChar)
	{
		VSL_DEFINE_MOCK_METHOD(SetLineColChar)

		VSL_CHECK_VALIDVALUE_POINTER(pvLine);

		VSL_CHECK_VALIDVALUE_POINTER(pvCol);

		VSL_CHECK_VALIDVALUE_POINTER(pvChar);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCurrentUserValidValues
	{
		/*[in]*/ IVsStatusbarUser* pUser;
		/*[in]*/ BOOL* pfCurrent;
		HRESULT retValue;
	};

	STDMETHOD(IsCurrentUser)(
		/*[in]*/ IVsStatusbarUser* pUser,
		/*[in]*/ BOOL* pfCurrent)
	{
		VSL_DEFINE_MOCK_METHOD(IsCurrentUser)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_CHECK_VALIDVALUE_POINTER(pfCurrent);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetColorTextValidValues
	{
		/*[in]*/ LPCOLESTR pszText;
		/*[in]*/ COLORREF crForeColor;
		/*[in]*/ COLORREF crBackColor;
		HRESULT retValue;
	};

	STDMETHOD(SetColorText)(
		/*[in]*/ LPCOLESTR pszText,
		/*[in]*/ COLORREF crForeColor,
		/*[in]*/ COLORREF crBackColor)
	{
		VSL_DEFINE_MOCK_METHOD(SetColorText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(crForeColor);

		VSL_CHECK_VALIDVALUE(crBackColor);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[out]*/ BSTR* pszText;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[out]*/ BSTR* pszText)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_SET_VALIDVALUE_BSTR(pszText);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreezeOutputValidValues
	{
		/*[in]*/ BOOL fFreeze;
		HRESULT retValue;
	};

	STDMETHOD(FreezeOutput)(
		/*[in]*/ BOOL fFreeze)
	{
		VSL_DEFINE_MOCK_METHOD(FreezeOutput)

		VSL_CHECK_VALIDVALUE(fFreeze);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsFrozenValidValues
	{
		/*[out]*/ BOOL* pfFrozen;
		HRESULT retValue;
	};

	STDMETHOD(IsFrozen)(
		/*[out]*/ BOOL* pfFrozen)
	{
		VSL_DEFINE_MOCK_METHOD(IsFrozen)

		VSL_SET_VALIDVALUE(pfFrozen);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFreezeCountValidValues
	{
		/*[out]*/ long* plCount;
		HRESULT retValue;
	};

	STDMETHOD(GetFreezeCount)(
		/*[out]*/ long* plCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetFreezeCount)

		VSL_SET_VALIDVALUE(plCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSTATUSBAR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
