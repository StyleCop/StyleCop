/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITEXTPARA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITEXTPARA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITextParaNotImpl :
	public ITextPara
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextParaNotImpl)

public:

	typedef ITextPara Interface;

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextPara** /*ppPara*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDuplicate)(
		/*[in]*/ ITextPara* /*ppPara*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanChange)(
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextPara* /*pPara*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)(
		/*[in]*/ long /*Value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStyle)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStyle)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAlignment)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAlignment)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHyphenation)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHyphenation)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFirstLineIndent)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetKeepTogether)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetKeepTogether)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetKeepWithNext)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetKeepWithNext)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLeftIndent)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineSpacing)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineSpacingRule)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListAlignment)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetListAlignment)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListLevelIndex)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetListLevelIndex)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListStart)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetListStart)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListTab)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetListTab)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListType)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetListType)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNoLineNumber)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetNoLineNumber)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPageBreakBefore)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPageBreakBefore)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRightIndent)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRightIndent)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetIndents)(
		/*[in]*/ single /*StartIndent*/,
		/*[in]*/ single /*LeftIndent*/,
		/*[in]*/ single /*RightIndent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLineSpacing)(
		/*[in]*/ long /*LineSpacingRule*/,
		/*[in]*/ single /*LineSpacing*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpaceAfter)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpaceAfter)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpaceBefore)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSpaceBefore)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWidowControl)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetWidowControl)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTabCount)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddTab)(
		/*[in]*/ single /*tbPos*/,
		/*[in]*/ long /*tbAlign*/,
		/*[in]*/ long /*tbLeader*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearAllTabs)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteTab)(
		/*[in]*/ single /*tbPos*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTab)(
		/*[in]*/ long /*iTab*/,
		/*[out]*/ single* /*ptbPos*/,
		/*[out]*/ long* /*ptbAlign*/,
		/*[out]*/ long* /*ptbLeader*/)VSL_STDMETHOD_NOTIMPL

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

class ITextParaMockImpl :
	public ITextPara,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextParaMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITextParaMockImpl)

	typedef ITextPara Interface;
	struct GetDuplicateValidValues
	{
		/*[out,retval]*/ ITextPara** ppPara;
		HRESULT retValue;
	};

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextPara** ppPara)
	{
		VSL_DEFINE_MOCK_METHOD(GetDuplicate)

		VSL_SET_VALIDVALUE_INTERFACE(ppPara);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDuplicateValidValues
	{
		/*[in]*/ ITextPara* ppPara;
		HRESULT retValue;
	};

	STDMETHOD(SetDuplicate)(
		/*[in]*/ ITextPara* ppPara)
	{
		VSL_DEFINE_MOCK_METHOD(SetDuplicate)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppPara);

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
		/*[in]*/ ITextPara* pPara;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextPara* pPara,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPara);

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
	struct GetAlignmentValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAlignment)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAlignment)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAlignmentValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetAlignment)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetAlignment)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHyphenationValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetHyphenation)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetHyphenation)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHyphenationValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetHyphenation)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetHyphenation)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFirstLineIndentValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetFirstLineIndent)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetFirstLineIndent)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetKeepTogetherValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetKeepTogether)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetKeepTogether)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetKeepTogetherValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetKeepTogether)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetKeepTogether)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetKeepWithNextValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetKeepWithNext)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetKeepWithNext)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetKeepWithNextValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetKeepWithNext)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetKeepWithNext)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLeftIndentValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetLeftIndent)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetLeftIndent)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineSpacingValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetLineSpacing)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineSpacing)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineSpacingRuleValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetLineSpacingRule)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineSpacingRule)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListAlignmentValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetListAlignment)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetListAlignment)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetListAlignmentValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetListAlignment)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetListAlignment)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListLevelIndexValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetListLevelIndex)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetListLevelIndex)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetListLevelIndexValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetListLevelIndex)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetListLevelIndex)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListStartValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetListStart)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetListStart)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetListStartValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetListStart)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetListStart)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListTabValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetListTab)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetListTab)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetListTabValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetListTab)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetListTab)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListTypeValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetListType)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetListType)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetListTypeValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetListType)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetListType)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNoLineNumberValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetNoLineNumber)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetNoLineNumber)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNoLineNumberValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetNoLineNumber)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetNoLineNumber)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPageBreakBeforeValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetPageBreakBefore)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetPageBreakBefore)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPageBreakBeforeValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetPageBreakBefore)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetPageBreakBefore)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRightIndentValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetRightIndent)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetRightIndent)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRightIndentValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetRightIndent)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetRightIndent)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetIndentsValidValues
	{
		/*[in]*/ single StartIndent;
		/*[in]*/ single LeftIndent;
		/*[in]*/ single RightIndent;
		HRESULT retValue;
	};

	STDMETHOD(SetIndents)(
		/*[in]*/ single StartIndent,
		/*[in]*/ single LeftIndent,
		/*[in]*/ single RightIndent)
	{
		VSL_DEFINE_MOCK_METHOD(SetIndents)

		VSL_CHECK_VALIDVALUE(StartIndent);

		VSL_CHECK_VALIDVALUE(LeftIndent);

		VSL_CHECK_VALIDVALUE(RightIndent);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLineSpacingValidValues
	{
		/*[in]*/ long LineSpacingRule;
		/*[in]*/ single LineSpacing;
		HRESULT retValue;
	};

	STDMETHOD(SetLineSpacing)(
		/*[in]*/ long LineSpacingRule,
		/*[in]*/ single LineSpacing)
	{
		VSL_DEFINE_MOCK_METHOD(SetLineSpacing)

		VSL_CHECK_VALIDVALUE(LineSpacingRule);

		VSL_CHECK_VALIDVALUE(LineSpacing);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpaceAfterValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSpaceAfter)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpaceAfter)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpaceAfterValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSpaceAfter)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpaceAfter)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpaceBeforeValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSpaceBefore)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpaceBefore)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSpaceBeforeValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSpaceBefore)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSpaceBefore)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWidowControlValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetWidowControl)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetWidowControl)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetWidowControlValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetWidowControl)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetWidowControl)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabCountValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetTabCount)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetTabCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddTabValidValues
	{
		/*[in]*/ single tbPos;
		/*[in]*/ long tbAlign;
		/*[in]*/ long tbLeader;
		HRESULT retValue;
	};

	STDMETHOD(AddTab)(
		/*[in]*/ single tbPos,
		/*[in]*/ long tbAlign,
		/*[in]*/ long tbLeader)
	{
		VSL_DEFINE_MOCK_METHOD(AddTab)

		VSL_CHECK_VALIDVALUE(tbPos);

		VSL_CHECK_VALIDVALUE(tbAlign);

		VSL_CHECK_VALIDVALUE(tbLeader);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearAllTabsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearAllTabs)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearAllTabs)

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteTabValidValues
	{
		/*[in]*/ single tbPos;
		HRESULT retValue;
	};

	STDMETHOD(DeleteTab)(
		/*[in]*/ single tbPos)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteTab)

		VSL_CHECK_VALIDVALUE(tbPos);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabValidValues
	{
		/*[in]*/ long iTab;
		/*[out]*/ single* ptbPos;
		/*[out]*/ long* ptbAlign;
		/*[out]*/ long* ptbLeader;
		HRESULT retValue;
	};

	STDMETHOD(GetTab)(
		/*[in]*/ long iTab,
		/*[out]*/ single* ptbPos,
		/*[out]*/ long* ptbAlign,
		/*[out]*/ long* ptbLeader)
	{
		VSL_DEFINE_MOCK_METHOD(GetTab)

		VSL_CHECK_VALIDVALUE(iTab);

		VSL_SET_VALIDVALUE(ptbPos);

		VSL_SET_VALIDVALUE(ptbAlign);

		VSL_SET_VALIDVALUE(ptbLeader);

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

#endif // ITEXTPARA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
