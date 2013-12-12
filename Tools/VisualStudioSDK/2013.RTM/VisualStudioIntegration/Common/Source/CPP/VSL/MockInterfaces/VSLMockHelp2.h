/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef HELP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define HELP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "VSHelp80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class Help2NotImpl :
	public Help2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(Help2NotImpl)

public:

	typedef Help2 Interface;

	STDMETHOD(SearchEx)(
		/*[in]*/ BSTR /*bstrSearchFilterTransform*/,
		/*[in]*/ BSTR /*pszSearchTerm*/,
		/*[in]*/ vsSearchFlags /*vssfSearchFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HowDoI)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Favorites)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AskAQuestion)(
		/*[in]*/ vsAskQuestionFlags /*askQuestionFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromURLEx2)(
		/*[in]*/ BSTR /*bstrURL*/,
		/*[in]*/ vsHelpDisplayUrlFlags /*displayUrlFlags*/,
		/*[in]*/ BSTR /*bstrParam*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeSettingsToken)(
		/*[in]*/ BSTR /*bstrSettingsToken*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Contents)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Index)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Search)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IndexResults)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SearchResults)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromId)(
		/*[in]*/ BSTR /*bstrFile*/,
		/*[in]*/ DWORD /*Id*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromURL)(
		/*[in]*/ BSTR /*pszURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromURLEx)(
		/*[in]*/ BSTR /*pszURL*/,
		/*[in]*/ IVsHelpTopicShowEvents* /*pIVsHelpTopicShowEvents*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromKeyword)(
		/*[in]*/ BSTR /*pszKeyword*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFromF1Keyword)(
		/*[in]*/ BSTR /*pszKeyword*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayTopicFrom_OLD_Help)(
		/*[in]*/ BSTR /*bstrFile*/,
		/*[in]*/ DWORD /*Id*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SyncContents)(
		/*[in]*/ BSTR /*bstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanSyncContents)(
		/*[in]*/ BSTR /*bstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNextTopic)(
		/*[in]*/ BSTR /*bstrURL*/,
		/*[out,retval]*/ BSTR* /*pbstrNext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPrevTopic)(
		/*[in]*/ BSTR /*bstrURL*/,
		/*[out,retval]*/ BSTR* /*pbstrPrev*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterUI)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanShowFilterUI)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SyncIndex)(
		/*[in]*/ BSTR /*bstrKeyword*/,
		/*[in]*/ BOOL /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCollection)(
		/*[in]*/ BSTR /*bstrCollection*/,
		/*[in]*/ BSTR /*bstrFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Collection)(
		/*[out,retval]*/ BSTR* /*pbstrCollection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Filter)(
		/*[out,retval]*/ BSTR* /*pbstrFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Filter)(
		/*[in]*/ BSTR /*bstrFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FilterQuery)(
		/*[out,retval]*/ BSTR* /*pbstrFilterQuery*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_HelpOwner)(
		/*[out,retval]*/ IVsHelpOwner** /*ppObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_HelpOwner)(
		/*[in]*/ IVsHelpOwner* /*pObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_HxSession)(
		/*[out,retval]*/ IDispatch** /*ppObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Help)(
		/*[out,retval]*/ IDispatch** /*ppObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetObject)(
		/*[in]*/ BSTR /*bstrMoniker*/,
		/*[in]*/ BSTR /*bstrOptions*/,
		/*[out,retval]*/ IDispatch** /*ppDisp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
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

class Help2MockImpl :
	public Help2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(Help2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(Help2MockImpl)

	typedef Help2 Interface;
	struct SearchExValidValues
	{
		/*[in]*/ BSTR bstrSearchFilterTransform;
		/*[in]*/ BSTR pszSearchTerm;
		/*[in]*/ vsSearchFlags vssfSearchFlags;
		HRESULT retValue;
	};

	STDMETHOD(SearchEx)(
		/*[in]*/ BSTR bstrSearchFilterTransform,
		/*[in]*/ BSTR pszSearchTerm,
		/*[in]*/ vsSearchFlags vssfSearchFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SearchEx)

		VSL_CHECK_VALIDVALUE_BSTR(bstrSearchFilterTransform);

		VSL_CHECK_VALIDVALUE_BSTR(pszSearchTerm);

		VSL_CHECK_VALIDVALUE(vssfSearchFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct HowDoIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HowDoI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HowDoI)

		VSL_RETURN_VALIDVALUES();
	}
	struct FavoritesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Favorites)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Favorites)

		VSL_RETURN_VALIDVALUES();
	}
	struct AskAQuestionValidValues
	{
		/*[in]*/ vsAskQuestionFlags askQuestionFlags;
		HRESULT retValue;
	};

	STDMETHOD(AskAQuestion)(
		/*[in]*/ vsAskQuestionFlags askQuestionFlags)
	{
		VSL_DEFINE_MOCK_METHOD(AskAQuestion)

		VSL_CHECK_VALIDVALUE(askQuestionFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromURLEx2ValidValues
	{
		/*[in]*/ BSTR bstrURL;
		/*[in]*/ vsHelpDisplayUrlFlags displayUrlFlags;
		/*[in]*/ BSTR bstrParam;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromURLEx2)(
		/*[in]*/ BSTR bstrURL,
		/*[in]*/ vsHelpDisplayUrlFlags displayUrlFlags,
		/*[in]*/ BSTR bstrParam)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromURLEx2)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_CHECK_VALIDVALUE(displayUrlFlags);

		VSL_CHECK_VALIDVALUE_BSTR(bstrParam);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeSettingsTokenValidValues
	{
		/*[in]*/ BSTR bstrSettingsToken;
		HRESULT retValue;
	};

	STDMETHOD(InitializeSettingsToken)(
		/*[in]*/ BSTR bstrSettingsToken)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeSettingsToken)

		VSL_CHECK_VALIDVALUE_BSTR(bstrSettingsToken);

		VSL_RETURN_VALIDVALUES();
	}
	struct ContentsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Contents)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Contents)

		VSL_RETURN_VALIDVALUES();
	}
	struct IndexValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Index)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Index)

		VSL_RETURN_VALIDVALUES();
	}
	struct SearchValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Search)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Search)

		VSL_RETURN_VALIDVALUES();
	}
	struct IndexResultsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IndexResults)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IndexResults)

		VSL_RETURN_VALIDVALUES();
	}
	struct SearchResultsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SearchResults)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SearchResults)

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromIdValidValues
	{
		/*[in]*/ BSTR bstrFile;
		/*[in]*/ DWORD Id;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromId)(
		/*[in]*/ BSTR bstrFile,
		/*[in]*/ DWORD Id)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromId)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFile);

		VSL_CHECK_VALIDVALUE(Id);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromURLValidValues
	{
		/*[in]*/ BSTR pszURL;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromURL)(
		/*[in]*/ BSTR pszURL)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromURL)

		VSL_CHECK_VALIDVALUE_BSTR(pszURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromURLExValidValues
	{
		/*[in]*/ BSTR pszURL;
		/*[in]*/ IVsHelpTopicShowEvents* pIVsHelpTopicShowEvents;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromURLEx)(
		/*[in]*/ BSTR pszURL,
		/*[in]*/ IVsHelpTopicShowEvents* pIVsHelpTopicShowEvents)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromURLEx)

		VSL_CHECK_VALIDVALUE_BSTR(pszURL);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsHelpTopicShowEvents);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromKeywordValidValues
	{
		/*[in]*/ BSTR pszKeyword;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromKeyword)(
		/*[in]*/ BSTR pszKeyword)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromKeyword)

		VSL_CHECK_VALIDVALUE_BSTR(pszKeyword);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFromF1KeywordValidValues
	{
		/*[in]*/ BSTR pszKeyword;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFromF1Keyword)(
		/*[in]*/ BSTR pszKeyword)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFromF1Keyword)

		VSL_CHECK_VALIDVALUE_BSTR(pszKeyword);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayTopicFrom_OLD_HelpValidValues
	{
		/*[in]*/ BSTR bstrFile;
		/*[in]*/ DWORD Id;
		HRESULT retValue;
	};

	STDMETHOD(DisplayTopicFrom_OLD_Help)(
		/*[in]*/ BSTR bstrFile,
		/*[in]*/ DWORD Id)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayTopicFrom_OLD_Help)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFile);

		VSL_CHECK_VALIDVALUE(Id);

		VSL_RETURN_VALIDVALUES();
	}
	struct SyncContentsValidValues
	{
		/*[in]*/ BSTR bstrURL;
		HRESULT retValue;
	};

	STDMETHOD(SyncContents)(
		/*[in]*/ BSTR bstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(SyncContents)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanSyncContentsValidValues
	{
		/*[in]*/ BSTR bstrURL;
		HRESULT retValue;
	};

	STDMETHOD(CanSyncContents)(
		/*[in]*/ BSTR bstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(CanSyncContents)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNextTopicValidValues
	{
		/*[in]*/ BSTR bstrURL;
		/*[out,retval]*/ BSTR* pbstrNext;
		HRESULT retValue;
	};

	STDMETHOD(GetNextTopic)(
		/*[in]*/ BSTR bstrURL,
		/*[out,retval]*/ BSTR* pbstrNext)
	{
		VSL_DEFINE_MOCK_METHOD(GetNextTopic)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_SET_VALIDVALUE_BSTR(pbstrNext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPrevTopicValidValues
	{
		/*[in]*/ BSTR bstrURL;
		/*[out,retval]*/ BSTR* pbstrPrev;
		HRESULT retValue;
	};

	STDMETHOD(GetPrevTopic)(
		/*[in]*/ BSTR bstrURL,
		/*[out,retval]*/ BSTR* pbstrPrev)
	{
		VSL_DEFINE_MOCK_METHOD(GetPrevTopic)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_SET_VALIDVALUE_BSTR(pbstrPrev);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterUIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FilterUI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FilterUI)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanShowFilterUIValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanShowFilterUI)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanShowFilterUI)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct SyncIndexValidValues
	{
		/*[in]*/ BSTR bstrKeyword;
		/*[in]*/ BOOL fShow;
		HRESULT retValue;
	};

	STDMETHOD(SyncIndex)(
		/*[in]*/ BSTR bstrKeyword,
		/*[in]*/ BOOL fShow)
	{
		VSL_DEFINE_MOCK_METHOD(SyncIndex)

		VSL_CHECK_VALIDVALUE_BSTR(bstrKeyword);

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCollectionValidValues
	{
		/*[in]*/ BSTR bstrCollection;
		/*[in]*/ BSTR bstrFilter;
		HRESULT retValue;
	};

	STDMETHOD(SetCollection)(
		/*[in]*/ BSTR bstrCollection,
		/*[in]*/ BSTR bstrFilter)
	{
		VSL_DEFINE_MOCK_METHOD(SetCollection)

		VSL_CHECK_VALIDVALUE_BSTR(bstrCollection);

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CollectionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCollection;
		HRESULT retValue;
	};

	STDMETHOD(get_Collection)(
		/*[out,retval]*/ BSTR* pbstrCollection)
	{
		VSL_DEFINE_MOCK_METHOD(get_Collection)

		VSL_SET_VALIDVALUE_BSTR(pbstrCollection);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FilterValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFilter;
		HRESULT retValue;
	};

	STDMETHOD(get_Filter)(
		/*[out,retval]*/ BSTR* pbstrFilter)
	{
		VSL_DEFINE_MOCK_METHOD(get_Filter)

		VSL_SET_VALIDVALUE_BSTR(pbstrFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_FilterValidValues
	{
		/*[in]*/ BSTR bstrFilter;
		HRESULT retValue;
	};

	STDMETHOD(put_Filter)(
		/*[in]*/ BSTR bstrFilter)
	{
		VSL_DEFINE_MOCK_METHOD(put_Filter)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FilterQueryValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFilterQuery;
		HRESULT retValue;
	};

	STDMETHOD(get_FilterQuery)(
		/*[out,retval]*/ BSTR* pbstrFilterQuery)
	{
		VSL_DEFINE_MOCK_METHOD(get_FilterQuery)

		VSL_SET_VALIDVALUE_BSTR(pbstrFilterQuery);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HelpOwnerValidValues
	{
		/*[out,retval]*/ IVsHelpOwner** ppObj;
		HRESULT retValue;
	};

	STDMETHOD(get_HelpOwner)(
		/*[out,retval]*/ IVsHelpOwner** ppObj)
	{
		VSL_DEFINE_MOCK_METHOD(get_HelpOwner)

		VSL_SET_VALIDVALUE_INTERFACE(ppObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_HelpOwnerValidValues
	{
		/*[in]*/ IVsHelpOwner* pObj;
		HRESULT retValue;
	};

	STDMETHOD(put_HelpOwner)(
		/*[in]*/ IVsHelpOwner* pObj)
	{
		VSL_DEFINE_MOCK_METHOD(put_HelpOwner)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HxSessionValidValues
	{
		/*[out,retval]*/ IDispatch** ppObj;
		HRESULT retValue;
	};

	STDMETHOD(get_HxSession)(
		/*[out,retval]*/ IDispatch** ppObj)
	{
		VSL_DEFINE_MOCK_METHOD(get_HxSession)

		VSL_SET_VALIDVALUE_INTERFACE(ppObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HelpValidValues
	{
		/*[out,retval]*/ IDispatch** ppObj;
		HRESULT retValue;
	};

	STDMETHOD(get_Help)(
		/*[out,retval]*/ IDispatch** ppObj)
	{
		VSL_DEFINE_MOCK_METHOD(get_Help)

		VSL_SET_VALIDVALUE_INTERFACE(ppObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetObjectValidValues
	{
		/*[in]*/ BSTR bstrMoniker;
		/*[in]*/ BSTR bstrOptions;
		/*[out,retval]*/ IDispatch** ppDisp;
		HRESULT retValue;
	};

	STDMETHOD(GetObject)(
		/*[in]*/ BSTR bstrMoniker,
		/*[in]*/ BSTR bstrOptions,
		/*[out,retval]*/ IDispatch** ppDisp)
	{
		VSL_DEFINE_MOCK_METHOD(GetObject)

		VSL_CHECK_VALIDVALUE_BSTR(bstrMoniker);

		VSL_CHECK_VALIDVALUE_BSTR(bstrOptions);

		VSL_SET_VALIDVALUE_INTERFACE(ppDisp);

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
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
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

#endif // HELP2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
