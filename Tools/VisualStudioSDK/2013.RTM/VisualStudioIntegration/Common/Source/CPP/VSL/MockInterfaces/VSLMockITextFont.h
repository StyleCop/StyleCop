/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITEXTFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITEXTFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <TOM.h>

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ITextFontNotImpl :
	public ITextFont
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextFontNotImpl)

public:

	typedef ITextFont Interface;

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextFont** /*ppFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDuplicate)(
		/*[in]*/ ITextFont* /*ppFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanChange)(
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextFont* /*pFont*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)(
		/*[in]*/ long /*Value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStyle)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStyle)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllCaps)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAllCaps)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAnimation)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAnimation)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBackColor)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBackColor)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBold)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBold)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEmboss)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEmboss)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetForeColor)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetForeColor)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHidden)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHidden)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngrave)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEngrave)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItalic)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetItalic)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetKerning)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetKerning)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageID)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLanguageID)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out,retval]*/ BSTR* /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetName)(
		/*[in]*/ BSTR /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOutline)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetOutline)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPosition)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPosition)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProtected)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProtected)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetShadow)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetShadow)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSize)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSmallCaps)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSmallCaps)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpacing)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpacing)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStrikeThrough)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStrikeThrough)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSubscript)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSubscript)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSuperscript)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSuperscript)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUnderline)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUnderline)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWeight)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetWeight)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ _In_ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,size_is(cNames)]*/ DISPID* /*rgDispId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID /*dispIdMember*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL
};

class ITextFontMockImpl :
	public ITextFont,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextFontMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITextFontMockImpl)

	typedef ITextFont Interface;
	struct GetDuplicateValidValues
	{
		/*[out,retval]*/ ITextFont** ppFont;
		HRESULT retValue;
	};

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextFont** ppFont)
	{
		VSL_DEFINE_MOCK_METHOD(GetDuplicate)

		VSL_SET_VALIDVALUE_INTERFACE(ppFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDuplicateValidValues
	{
		/*[in]*/ ITextFont* ppFont;
		HRESULT retValue;
	};

	STDMETHOD(SetDuplicate)(
		/*[in]*/ ITextFont* ppFont)
	{
		VSL_DEFINE_MOCK_METHOD(SetDuplicate)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanChangeValidValues
	{
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(CanChange)(
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(CanChange)

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEqualValidValues
	{
		/*[in]*/ ITextFont* pFont;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextFont* pFont,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFont);

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		/*[in]*/ long Value;
		HRESULT retValue;
	};

	STDMETHOD(Reset)(
		/*[in]*/ long Value)
	{
		VSL_DEFINE_MOCK_METHOD(Reset)

		VSL_CHECK_VALIDVALUE(Value);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStyleValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetStyle)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetStyle)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStyleValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetStyle)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetStyle)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllCapsValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAllCaps)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllCaps)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAllCapsValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetAllCaps)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetAllCaps)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAnimationValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAnimation)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAnimation)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAnimationValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetAnimation)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetAnimation)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBackColorValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetBackColor)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetBackColor)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBackColorValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetBackColor)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetBackColor)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBoldValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetBold)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetBold)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBoldValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetBold)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetBold)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEmbossValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEmboss)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEmboss)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEmbossValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetEmboss)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetEmboss)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetForeColorValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetForeColor)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetForeColor)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetForeColorValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetForeColor)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetForeColor)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHiddenValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetHidden)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetHidden)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHiddenValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetHidden)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetHidden)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEngraveValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEngrave)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngrave)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEngraveValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetEngrave)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetEngrave)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItalicValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetItalic)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetItalic)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetItalicValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetItalic)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetItalic)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetKerningValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetKerning)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetKerning)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetKerningValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetKerning)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetKerning)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLanguageIDValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageID)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageID)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLanguageIDValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetLanguageID)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetLanguageID)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstr;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out,retval]*/ BSTR* pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNameValidValues
	{
		/*[in]*/ BSTR pbstr;
		HRESULT retValue;
	};

	STDMETHOD(SetName)(
		/*[in]*/ BSTR pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(SetName)

		VSL_CHECK_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOutlineValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetOutline)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetOutline)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetOutlineValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetOutline)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetOutline)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPositionValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetPosition)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetPosition)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPositionValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetPosition)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetPosition)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProtectedValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetProtected)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetProtected)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetProtectedValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetProtected)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetProtected)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetShadowValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetShadow)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetShadow)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetShadowValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetShadow)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetShadow)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSizeValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSize)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSize)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSmallCapsValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSmallCaps)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSmallCaps)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSmallCapsValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSmallCaps)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSmallCaps)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpacingValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSpacing)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpacing)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpacingValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSpacing)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpacing)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStrikeThroughValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetStrikeThrough)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetStrikeThrough)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStrikeThroughValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetStrikeThrough)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetStrikeThrough)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSubscriptValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSubscript)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSubscript)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSubscriptValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSubscript)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSubscript)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSuperscriptValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSuperscript)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSuperscript)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSuperscriptValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSuperscript)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSuperscript)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUnderlineValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetUnderline)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetUnderline)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUnderlineValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetUnderline)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetUnderline)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWeightValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetWeight)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetWeight)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetWeightValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetWeight)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetWeight)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoCountValidValues
	{
		/*[out]*/ UINT* pctinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* pctinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoCount)

		VSL_SET_VALIDVALUE(pctinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT iTInfo;
		/*[in]*/ LCID lcid;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT iTInfo,
		/*[in]*/ LCID lcid,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(iTInfo);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[in]*/ LCID lcid;
		/*[out,size_is(cNames)]*/ DISPID* rgDispId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID riid,
		/*[in,size_is(cNames)]*/ _In_ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[in]*/ LCID lcid,
		/*[out,size_is(cNames)]*/ DISPID* rgDispId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_MEMCPY(rgDispId, cNames*sizeof(rgDispId[0]), validValues.cNames*sizeof(validValues.rgDispId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ DISPID dispIdMember;
		/*[in]*/ REFIID riid;
		/*[in]*/ LCID lcid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID dispIdMember,
		/*[in]*/ REFIID riid,
		/*[in]*/ LCID lcid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE(dispIdMember);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITEXTFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
