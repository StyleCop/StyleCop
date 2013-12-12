/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITEXTDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITEXTDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITextDocumentNotImpl :
	public ITextDocument
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextDocumentNotImpl)

public:

	typedef ITextDocument Interface;

	STDMETHOD(GetName)(
		/*[out,retval]*/ BSTR* /*pName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSelection)(
		/*[out,retval]*/ ITextSelection** /*ppSel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStoryCount)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStoryRanges)(
		/*[out,retval]*/ ITextStoryRanges** /*ppStories*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSaved)(
		/*[out,retval]*/ long* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSaved)(
		/*[in]*/ long /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultTabStop)(
		/*[out,retval]*/ single* /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDefaultTabStop)(
		/*[in]*/ single /*pValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(New)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Open)(
		/*[in]*/ VARIANT* /*pVar*/,
		/*[in]*/ long /*Flags*/,
		/*[in]*/ long /*CodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in]*/ VARIANT* /*pVar*/,
		/*[in]*/ long /*Flags*/,
		/*[in]*/ long /*CodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Freeze)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unfreeze)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BeginEditCollection)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndEditCollection)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Undo)(
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*prop*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Redo)(
		/*[in]*/ long /*Count*/,
		/*[out,retval]*/ long* /*prop*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Range)(
		/*[in]*/ long /*cp1*/,
		/*[in]*/ long /*cp2*/,
		/*[out,retval]*/ ITextRange** /*ppRange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RangeFromPoint)(
		/*[in]*/ long /*x*/,
		/*[in]*/ long /*y*/,
		/*[out,retval]*/ ITextRange** /*ppRange*/)VSL_STDMETHOD_NOTIMPL

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

class ITextDocumentMockImpl :
	public ITextDocument,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITextDocumentMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITextDocumentMockImpl)

	typedef ITextDocument Interface;
	struct GetNameValidValues
	{
		/*[out,retval]*/ BSTR* pName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out,retval]*/ BSTR* pName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSelectionValidValues
	{
		/*[out,retval]*/ ITextSelection** ppSel;
		HRESULT retValue;
	};

	STDMETHOD(GetSelection)(
		/*[out,retval]*/ ITextSelection** ppSel)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelection)

		VSL_SET_VALIDVALUE_INTERFACE(ppSel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStoryCountValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetStoryCount)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetStoryCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStoryRangesValidValues
	{
		/*[out,retval]*/ ITextStoryRanges** ppStories;
		HRESULT retValue;
	};

	STDMETHOD(GetStoryRanges)(
		/*[out,retval]*/ ITextStoryRanges** ppStories)
	{
		VSL_DEFINE_MOCK_METHOD(GetStoryRanges)

		VSL_SET_VALIDVALUE_INTERFACE(ppStories);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSavedValidValues
	{
		/*[out,retval]*/ long* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetSaved)(
		/*[out,retval]*/ long* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetSaved)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSavedValidValues
	{
		/*[in]*/ long pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetSaved)(
		/*[in]*/ long pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetSaved)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultTabStopValidValues
	{
		/*[out,retval]*/ single* pValue;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultTabStop)(
		/*[out,retval]*/ single* pValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultTabStop)

		VSL_SET_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDefaultTabStopValidValues
	{
		/*[in]*/ single pValue;
		HRESULT retValue;
	};

	STDMETHOD(SetDefaultTabStop)(
		/*[in]*/ single pValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetDefaultTabStop)

		VSL_CHECK_VALIDVALUE(pValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct NewValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(New)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(New)

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenValidValues
	{
		/*[in]*/ VARIANT* pVar;
		/*[in]*/ long Flags;
		/*[in]*/ long CodePage;
		HRESULT retValue;
	};

	STDMETHOD(Open)(
		/*[in]*/ VARIANT* pVar,
		/*[in]*/ long Flags,
		/*[in]*/ long CodePage)
	{
		VSL_DEFINE_MOCK_METHOD(Open)

		VSL_CHECK_VALIDVALUE_POINTER(pVar);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE(CodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in]*/ VARIANT* pVar;
		/*[in]*/ long Flags;
		/*[in]*/ long CodePage;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in]*/ VARIANT* pVar,
		/*[in]*/ long Flags,
		/*[in]*/ long CodePage)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE_POINTER(pVar);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE(CodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreezeValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(Freeze)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(Freeze)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnfreezeValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(Unfreeze)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(Unfreeze)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct BeginEditCollectionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeginEditCollection)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeginEditCollection)

		VSL_RETURN_VALIDVALUES();
	}
	struct EndEditCollectionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EndEditCollection)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EndEditCollection)

		VSL_RETURN_VALIDVALUES();
	}
	struct UndoValidValues
	{
		/*[in]*/ long Count;
		/*[out,retval]*/ long* prop;
		HRESULT retValue;
	};

	STDMETHOD(Undo)(
		/*[in]*/ long Count,
		/*[out,retval]*/ long* prop)
	{
		VSL_DEFINE_MOCK_METHOD(Undo)

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(prop);

		VSL_RETURN_VALIDVALUES();
	}
	struct RedoValidValues
	{
		/*[in]*/ long Count;
		/*[out,retval]*/ long* prop;
		HRESULT retValue;
	};

	STDMETHOD(Redo)(
		/*[in]*/ long Count,
		/*[out,retval]*/ long* prop)
	{
		VSL_DEFINE_MOCK_METHOD(Redo)

		VSL_CHECK_VALIDVALUE(Count);

		VSL_SET_VALIDVALUE(prop);

		VSL_RETURN_VALIDVALUES();
	}
	struct RangeValidValues
	{
		/*[in]*/ long cp1;
		/*[in]*/ long cp2;
		/*[out,retval]*/ ITextRange** ppRange;
		HRESULT retValue;
	};

	STDMETHOD(Range)(
		/*[in]*/ long cp1,
		/*[in]*/ long cp2,
		/*[out,retval]*/ ITextRange** ppRange)
	{
		VSL_DEFINE_MOCK_METHOD(Range)

		VSL_CHECK_VALIDVALUE(cp1);

		VSL_CHECK_VALIDVALUE(cp2);

		VSL_SET_VALIDVALUE_INTERFACE(ppRange);

		VSL_RETURN_VALIDVALUES();
	}
	struct RangeFromPointValidValues
	{
		/*[in]*/ long x;
		/*[in]*/ long y;
		/*[out,retval]*/ ITextRange** ppRange;
		HRESULT retValue;
	};

	STDMETHOD(RangeFromPoint)(
		/*[in]*/ long x,
		/*[in]*/ long y,
		/*[out,retval]*/ ITextRange** ppRange)
	{
		VSL_DEFINE_MOCK_METHOD(RangeFromPoint)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_SET_VALIDVALUE_INTERFACE(ppRange);

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

#endif // ITEXTDOCUMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
