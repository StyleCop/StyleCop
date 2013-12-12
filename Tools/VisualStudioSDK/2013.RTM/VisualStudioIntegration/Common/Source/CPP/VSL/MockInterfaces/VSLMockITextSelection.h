/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITEXTSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITEXTSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITextSelectionNotImpl :
	public ITextSelection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextSelectionNotImpl)

public:

	typedef ITextSelection Interface;

	STDMETHOD(GetFlags)(
		/*[out,retval]*/ long* /*pFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFlags)(
		/*[in]*/ long /*pFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetType)(
		/*[out,retval]*/ long* /*pType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveLeft)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveRight)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveUp)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveDown)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HomeKey)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndKey)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TypeText)(
		/*[in]*/ BSTR /*bstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[out,retval]*/ BSTR* /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetText)(
		/*[in]*/ BSTR /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetChar)(
		/*[out,retval]*/ long* /*pch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetChar)(
		/*[in]*/ long /*pch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextRange** /*ppRange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFormattedText)(
		/*[out,retval]*/ ITextRange** /*ppRange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFormattedText)(
		/*[in]*/ ITextRange* /*ppRange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStart)(
		/*[out,retval]*/ long* /*pcpFirst*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStart)(
		/*[in]*/ long /*pcpFirst*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEnd)(
		/*[out,retval]*/ long* /*pcpLim*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEnd)(
		/*[in]*/ long /*pcpLim*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFont)(
		/*[out,retval]*/ ITextFont** /*pFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFont)(
		/*[in]*/ ITextFont* /*pFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPara)(
		/*[out,retval]*/ ITextPara** /*pPara*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPara)(
		/*[in]*/ ITextPara* /*pPara*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStoryLength)(
		/*[out,retval]*/ long* /*pcch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStoryType)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Collapse)(
		/*[in]*/ long /*bStart*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Expand)(
		/*[in]*/ long /*Unit*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIndex)(
		/*[in]*/ long /*Unit*/,
		/*[out,retval]*/ long* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetIndex)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Index*/,
		/*[in]*/ long /*Extend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRange)(
		/*[in]*/ long /*cpActive*/,
		/*[in]*/ long /*cpOther*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InRange)(
		/*[in]*/ ITextRange* /*pRange*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InStory)(
		/*[in]*/ ITextRange* /*pRange*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextRange* /*pRange*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Select)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartOf)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndOf)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Extend*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Move)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveStart)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveEnd)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveWhile)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveStartWhile)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveEndWhile)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveUntil)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveStartUntil)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveEndUntil)(
		/*[in]*/ VARIANT* /*Cset*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindText)(
		/*[in]*/ BSTR /*bstr*/,
		/*[in]*/ long /*cch*/,
		/*[in]*/ long /*Flags*/,
		/*[out,retval]*/ long* /*pLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindTextStart)(
		/*[in]*/ BSTR /*bstr*/,
		/*[in]*/ long /*cch*/,
		/*[in]*/ long /*Flags*/,
		/*[out,retval]*/ long* /*pLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindTextEnd)(
		/*[in]*/ BSTR /*bstr*/,
		/*[in]*/ long /*cch*/,
		/*[in]*/ long /*Flags*/,
		/*[out,retval]*/ long* /*pLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Delete)(
		/*[in]*/ long /*Unit*/,
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*pDelta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Cut)(
		/*[out]*/ VARIANT* /*pVar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Copy)(
		/*[out]*/ VARIANT* /*pVar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Paste)(
		/*[in]*/ VARIANT* /*pVar*/,
		/*[in]*/ long /*Format*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanPaste)(
		/*[in]*/ VARIANT* /*pVar*/,
		/*[in]*/ long /*Format*/,
		/*[out,retval]*/ long* /*pb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanEdit)(
		/*[out,retval]*/ long* /*pbCanEdit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ChangeCase)(
		/*[in]*/ long /*Type*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPoint)(
		/*[in]*/ long /*Type*/,
		/*[out]*/ long* /*px*/,
		/*[out]*/ long* /*py*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPoint)(
		/*[in]*/ long /*x*/,
		/*[in]*/ long /*y*/,
		/*[in]*/ long /*Type*/,
		/*[in]*/ long /*Extend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ScrollIntoView)(
		/*[in]*/ long /*Value*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEmbeddedObject)(
		/*[out,retval]*/ IUnknown** /*ppv*/)VSL_STDMETHOD_NOTIMPL

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

class ITextSelectionMockImpl :
	public ITextSelection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextSelectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITextSelectionMockImpl)

	typedef ITextSelection Interface;
	struct GetFlagsValidValues
	{
		/*[out,retval]*/ long* pFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetFlags)(
		/*[out,retval]*/ long* pFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetFlags)

		VSL_SET_VALIDVALUE(pFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFlagsValidValues
	{
		/*[in]*/ long pFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetFlags)(
		/*[in]*/ long pFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetFlags)

		VSL_CHECK_VALIDVALUE(pFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeValidValues
	{
		/*[out,retval]*/ long* pType;
		HRESULT retValue;
	};

	STDMETHOD(GetType)(
		/*[out,retval]*/ long* pType)
	{
		VSL_DEFINE_MOCK_METHOD(GetType)

		VSL_SET_VALIDVALUE(pType);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveLeftValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveLeft)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveLeft)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveRightValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveRight)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveRight)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveUpValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveUp)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveUp)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveDownValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveDown)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveDown)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct HomeKeyValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(HomeKey)(
		/*[in]*/ long Unit,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(HomeKey)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct EndKeyValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(EndKey)(
		/*[in]*/ long Unit,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(EndKey)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct TypeTextValidValues
	{
		/*[in]*/ BSTR bstr;
		HRESULT retValue;
	};

	STDMETHOD(TypeText)(
		/*[in]*/ BSTR bstr)
	{
		VSL_DEFINE_MOCK_METHOD(TypeText)

		VSL_CHECK_VALIDVALUE_BSTR(bstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[out,retval]*/ BSTR* pbstr;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[out,retval]*/ BSTR* pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_SET_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTextValidValues
	{
		/*[in]*/ BSTR pbstr;
		HRESULT retValue;
	};

	STDMETHOD(SetText)(
		/*[in]*/ BSTR pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(SetText)

		VSL_CHECK_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCharValidValues
	{
		/*[out,retval]*/ long* pch;
		HRESULT retValue;
	};

	STDMETHOD(GetChar)(
		/*[out,retval]*/ long* pch)
	{
		VSL_DEFINE_MOCK_METHOD(GetChar)

		VSL_SET_VALIDVALUE(pch);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCharValidValues
	{
		/*[in]*/ long pch;
		HRESULT retValue;
	};

	STDMETHOD(SetChar)(
		/*[in]*/ long pch)
	{
		VSL_DEFINE_MOCK_METHOD(SetChar)

		VSL_CHECK_VALIDVALUE(pch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDuplicateValidValues
	{
		/*[out,retval]*/ ITextRange** ppRange;
		HRESULT retValue;
	};

	STDMETHOD(GetDuplicate)(
		/*[out,retval]*/ ITextRange** ppRange)
	{
		VSL_DEFINE_MOCK_METHOD(GetDuplicate)

		VSL_SET_VALIDVALUE_INTERFACE(ppRange);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFormattedTextValidValues
	{
		/*[out,retval]*/ ITextRange** ppRange;
		HRESULT retValue;
	};

	STDMETHOD(GetFormattedText)(
		/*[out,retval]*/ ITextRange** ppRange)
	{
		VSL_DEFINE_MOCK_METHOD(GetFormattedText)

		VSL_SET_VALIDVALUE_INTERFACE(ppRange);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFormattedTextValidValues
	{
		/*[in]*/ ITextRange* ppRange;
		HRESULT retValue;
	};

	STDMETHOD(SetFormattedText)(
		/*[in]*/ ITextRange* ppRange)
	{
		VSL_DEFINE_MOCK_METHOD(SetFormattedText)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppRange);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStartValidValues
	{
		/*[out,retval]*/ long* pcpFirst;
		HRESULT retValue;
	};

	STDMETHOD(GetStart)(
		/*[out,retval]*/ long* pcpFirst)
	{
		VSL_DEFINE_MOCK_METHOD(GetStart)

		VSL_SET_VALIDVALUE(pcpFirst);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStartValidValues
	{
		/*[in]*/ long pcpFirst;
		HRESULT retValue;
	};

	STDMETHOD(SetStart)(
		/*[in]*/ long pcpFirst)
	{
		VSL_DEFINE_MOCK_METHOD(SetStart)

		VSL_CHECK_VALIDVALUE(pcpFirst);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEndValidValues
	{
		/*[out,retval]*/ long* pcpLim;
		HRESULT retValue;
	};

	STDMETHOD(GetEnd)(
		/*[out,retval]*/ long* pcpLim)
	{
		VSL_DEFINE_MOCK_METHOD(GetEnd)

		VSL_SET_VALIDVALUE(pcpLim);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEndValidValues
	{
		/*[in]*/ long pcpLim;
		HRESULT retValue;
	};

	STDMETHOD(SetEnd)(
		/*[in]*/ long pcpLim)
	{
		VSL_DEFINE_MOCK_METHOD(SetEnd)

		VSL_CHECK_VALIDVALUE(pcpLim);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFontValidValues
	{
		/*[out,retval]*/ ITextFont** pFont;
		HRESULT retValue;
	};

	STDMETHOD(GetFont)(
		/*[out,retval]*/ ITextFont** pFont)
	{
		VSL_DEFINE_MOCK_METHOD(GetFont)

		VSL_SET_VALIDVALUE_INTERFACE(pFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFontValidValues
	{
		/*[in]*/ ITextFont* pFont;
		HRESULT retValue;
	};

	STDMETHOD(SetFont)(
		/*[in]*/ ITextFont* pFont)
	{
		VSL_DEFINE_MOCK_METHOD(SetFont)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParaValidValues
	{
		/*[out,retval]*/ ITextPara** pPara;
		HRESULT retValue;
	};

	STDMETHOD(GetPara)(
		/*[out,retval]*/ ITextPara** pPara)
	{
		VSL_DEFINE_MOCK_METHOD(GetPara)

		VSL_SET_VALIDVALUE_INTERFACE(pPara);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetParaValidValues
	{
		/*[in]*/ ITextPara* pPara;
		HRESULT retValue;
	};

	STDMETHOD(SetPara)(
		/*[in]*/ ITextPara* pPara)
	{
		VSL_DEFINE_MOCK_METHOD(SetPara)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPara);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStoryLengthValidValues
	{
		/*[out,retval]*/ long* pcch;
		HRESULT retValue;
	};

	STDMETHOD(GetStoryLength)(
		/*[out,retval]*/ long* pcch)
	{
		VSL_DEFINE_MOCK_METHOD(GetStoryLength)

		VSL_SET_VALIDVALUE(pcch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStoryTypeValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetStoryType)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetStoryType)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct CollapseValidValues
	{
		/*[in]*/ long bStart;
		HRESULT retValue;
	};

	STDMETHOD(Collapse)(
		/*[in]*/ long bStart)
	{
		VSL_DEFINE_MOCK_METHOD(Collapse)

		VSL_CHECK_VALIDVALUE(bStart);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExpandValidValues
	{
		/*[in]*/ long Unit;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(Expand)(
		/*[in]*/ long Unit,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(Expand)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIndexValidValues
	{
		/*[in]*/ long Unit;
		/*[out,retval]*/ long* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetIndex)(
		/*[in]*/ long Unit,
		/*[out,retval]*/ long* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetIndex)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetIndexValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Index;
		/*[in]*/ long Extend;
		HRESULT retValue;
	};

	STDMETHOD(SetIndex)(
		/*[in]*/ long Unit,
		/*[in]*/ long Index,
		/*[in]*/ long Extend)
	{
		VSL_DEFINE_MOCK_METHOD(SetIndex)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Index);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRangeValidValues
	{
		/*[in]*/ long cpActive;
		/*[in]*/ long cpOther;
		HRESULT retValue;
	};

	STDMETHOD(SetRange)(
		/*[in]*/ long cpActive,
		/*[in]*/ long cpOther)
	{
		VSL_DEFINE_MOCK_METHOD(SetRange)

		VSL_CHECK_VALIDVALUE(cpActive);

		VSL_CHECK_VALIDVALUE(cpOther);

		VSL_RETURN_VALIDVALUES();
	}
	struct InRangeValidValues
	{
		/*[in]*/ ITextRange* pRange;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(InRange)(
		/*[in]*/ ITextRange* pRange,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(InRange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRange);

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct InStoryValidValues
	{
		/*[in]*/ ITextRange* pRange;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(InStory)(
		/*[in]*/ ITextRange* pRange,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(InStory)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRange);

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEqualValidValues
	{
		/*[in]*/ ITextRange* pRange;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in]*/ ITextRange* pRange,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRange);

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Select)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Select)

		VSL_RETURN_VALIDVALUES();
	}
	struct StartOfValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(StartOf)(
		/*[in]*/ long Unit,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(StartOf)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct EndOfValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Extend;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(EndOf)(
		/*[in]*/ long Unit,
		/*[in]*/ long Extend,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(EndOf)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(Move)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(Move)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveStartValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveStart)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveStart)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveEndValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveEnd)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveEnd)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveWhileValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveWhile)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveWhile)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveStartWhileValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveStartWhile)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveStartWhile)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveEndWhileValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveEndWhile)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveEndWhile)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveUntilValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveUntil)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveUntil)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveStartUntilValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveStartUntil)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveStartUntil)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveEndUntilValidValues
	{
		/*[in]*/ VARIANT* Cset;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(MoveEndUntil)(
		/*[in]*/ VARIANT* Cset,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(MoveEndUntil)

		VSL_CHECK_VALIDVALUE_POINTER(Cset);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindTextValidValues
	{
		/*[in]*/ BSTR bstr;
		/*[in]*/ long cch;
		/*[in]*/ long Flags;
		/*[out,retval]*/ long* pLength;
		HRESULT retValue;
	};

	STDMETHOD(FindText)(
		/*[in]*/ BSTR bstr,
		/*[in]*/ long cch,
		/*[in]*/ long Flags,
		/*[out,retval]*/ long* pLength)
	{
		VSL_DEFINE_MOCK_METHOD(FindText)

		VSL_CHECK_VALIDVALUE_BSTR(bstr);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_SET_VALIDVALUE(pLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindTextStartValidValues
	{
		/*[in]*/ BSTR bstr;
		/*[in]*/ long cch;
		/*[in]*/ long Flags;
		/*[out,retval]*/ long* pLength;
		HRESULT retValue;
	};

	STDMETHOD(FindTextStart)(
		/*[in]*/ BSTR bstr,
		/*[in]*/ long cch,
		/*[in]*/ long Flags,
		/*[out,retval]*/ long* pLength)
	{
		VSL_DEFINE_MOCK_METHOD(FindTextStart)

		VSL_CHECK_VALIDVALUE_BSTR(bstr);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_SET_VALIDVALUE(pLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindTextEndValidValues
	{
		/*[in]*/ BSTR bstr;
		/*[in]*/ long cch;
		/*[in]*/ long Flags;
		/*[out,retval]*/ long* pLength;
		HRESULT retValue;
	};

	STDMETHOD(FindTextEnd)(
		/*[in]*/ BSTR bstr,
		/*[in]*/ long cch,
		/*[in]*/ long Flags,
		/*[out,retval]*/ long* pLength)
	{
		VSL_DEFINE_MOCK_METHOD(FindTextEnd)

		VSL_CHECK_VALIDVALUE_BSTR(bstr);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_SET_VALIDVALUE(pLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteValidValues
	{
		/*[in]*/ long Unit;
		/*[in]*/ long Count;
		/*[out,retval]*/ long* pDelta;
		HRESULT retValue;
	};

	STDMETHOD(Delete)(
		/*[in]*/ long Unit,
		/*[in]*/ long Count,
		/*[out,retval]*/ long* pDelta)
	{
		VSL_DEFINE_MOCK_METHOD(Delete)

		VSL_CHECK_VALIDVALUE(Unit);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(pDelta);

		VSL_RETURN_VALIDVALUES();
	}
	struct CutValidValues
	{
		/*[out]*/ VARIANT* pVar;
		HRESULT retValue;
	};

	STDMETHOD(Cut)(
		/*[out]*/ VARIANT* pVar)
	{
		VSL_DEFINE_MOCK_METHOD(Cut)

		VSL_SET_VALIDVALUE_VARIANT(pVar);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyValidValues
	{
		/*[out]*/ VARIANT* pVar;
		HRESULT retValue;
	};

	STDMETHOD(Copy)(
		/*[out]*/ VARIANT* pVar)
	{
		VSL_DEFINE_MOCK_METHOD(Copy)

		VSL_SET_VALIDVALUE_VARIANT(pVar);

		VSL_RETURN_VALIDVALUES();
	}
	struct PasteValidValues
	{
		/*[in]*/ VARIANT* pVar;
		/*[in]*/ long Format;
		HRESULT retValue;
	};

	STDMETHOD(Paste)(
		/*[in]*/ VARIANT* pVar,
		/*[in]*/ long Format)
	{
		VSL_DEFINE_MOCK_METHOD(Paste)

		VSL_CHECK_VALIDVALUE_POINTER(pVar);

		VSL_CHECK_VALIDVALUE(Format);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanPasteValidValues
	{
		/*[in]*/ VARIANT* pVar;
		/*[in]*/ long Format;
		/*[out,retval]*/ long* pb;
		HRESULT retValue;
	};

	STDMETHOD(CanPaste)(
		/*[in]*/ VARIANT* pVar,
		/*[in]*/ long Format,
		/*[out,retval]*/ long* pb)
	{
		VSL_DEFINE_MOCK_METHOD(CanPaste)

		VSL_CHECK_VALIDVALUE_POINTER(pVar);

		VSL_CHECK_VALIDVALUE(Format);

		VSL_SET_VALIDVALUE(pb);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanEditValidValues
	{
		/*[out,retval]*/ long* pbCanEdit;
		HRESULT retValue;
	};

	STDMETHOD(CanEdit)(
		/*[out,retval]*/ long* pbCanEdit)
	{
		VSL_DEFINE_MOCK_METHOD(CanEdit)

		VSL_SET_VALIDVALUE(pbCanEdit);

		VSL_RETURN_VALIDVALUES();
	}
	struct ChangeCaseValidValues
	{
		/*[in]*/ long Type;
		HRESULT retValue;
	};

	STDMETHOD(ChangeCase)(
		/*[in]*/ long Type)
	{
		VSL_DEFINE_MOCK_METHOD(ChangeCase)

		VSL_CHECK_VALIDVALUE(Type);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPointValidValues
	{
		/*[in]*/ long Type;
		/*[out]*/ long* px;
		/*[out]*/ long* py;
		HRESULT retValue;
	};

	STDMETHOD(GetPoint)(
		/*[in]*/ long Type,
		/*[out]*/ long* px,
		/*[out]*/ long* py)
	{
		VSL_DEFINE_MOCK_METHOD(GetPoint)

		VSL_CHECK_VALIDVALUE(Type);

		VSL_SET_VALIDVALUE(px);

		VSL_SET_VALIDVALUE(py);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPointValidValues
	{
		/*[in]*/ long x;
		/*[in]*/ long y;
		/*[in]*/ long Type;
		/*[in]*/ long Extend;
		HRESULT retValue;
	};

	STDMETHOD(SetPoint)(
		/*[in]*/ long x,
		/*[in]*/ long y,
		/*[in]*/ long Type,
		/*[in]*/ long Extend)
	{
		VSL_DEFINE_MOCK_METHOD(SetPoint)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(Type);

		VSL_CHECK_VALIDVALUE(Extend);

		VSL_RETURN_VALIDVALUES();
	}
	struct ScrollIntoViewValidValues
	{
		/*[in]*/ long Value;
		HRESULT retValue;
	};

	STDMETHOD(ScrollIntoView)(
		/*[in]*/ long Value)
	{
		VSL_DEFINE_MOCK_METHOD(ScrollIntoView)

		VSL_CHECK_VALIDVALUE(Value);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEmbeddedObjectValidValues
	{
		/*[out,retval]*/ IUnknown** ppv;
		HRESULT retValue;
	};

	STDMETHOD(GetEmbeddedObject)(
		/*[out,retval]*/ IUnknown** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(GetEmbeddedObject)

		VSL_SET_VALIDVALUE_INTERFACE(ppv);

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

#endif // ITEXTSELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
