/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMONITORUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMONITORUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMonitorUserContextNotImpl :
	public IVsMonitorUserContext
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorUserContextNotImpl)

public:

	typedef IVsMonitorUserContext Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ApplicationContext)(
		/*[out,retval]*/ IVsUserContext** /*ppContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ApplicationContext)(
		/*[in]*/ IVsUserContext* /*pContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateEmptyContext)(
		/*[out,retval]*/ IVsUserContext** /*ppContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextItems)(
		/*[out]*/ IVsUserContextItemCollection** /*pplist*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindTargetItems)(
		/*[in]*/ LPCOLESTR /*pszTargetAttr*/,
		/*[in]*/ LPCOLESTR /*pszTargetAttrValue*/,
		/*[out]*/ IVsUserContextItemCollection** /*ppList*/,
		/*[out]*/ BOOL* /*pfF1Kwd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterItemProvider)(
		/*[in]*/ IVsUserContextItemProvider* /*pProvider*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterItemProvider)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseContextItemEvents)(
		/*[in]*/ IVsUserContextItemEvents* /*pEvents*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseContextItemEvent)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNextCtxBagAttr)(
		/*[out]*/ BSTR* /*pbstrAttrName*/,
		/*[out]*/ BSTR* /*pbstrAttrVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetNextCtxBagAttr)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPrevAttrCache)(
		/*[out]*/ BSTR** /*pbstrCacheArray*/,
		/*[out]*/ int** /*pnCurrNumStored*/,
		/*[out]*/ int* /*pnMaxNumStored*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNextCtxBag)(
		/*[out]*/ BSTR* /*pbstrAttrName*/,
		/*[out]*/ BSTR* /*pbstrAttrVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsIdleAvailable)(
		/*[out]*/ BOOL* /*pfIdleAvail*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTopicTypeFilter)(
		/*[in]*/ IVsHelpAttributeList* /*pTopicTypeList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetF1Kwd)(
		/*[out]*/ BSTR* /*pbstrKwd*/,
		/*[out]*/ BOOL* /*fF1Kwd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsF1Lookup)(
		/*[out]*/ BOOL* /*fF1Lookup*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMonitorUserContextMockImpl :
	public IVsMonitorUserContext,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMonitorUserContextMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMonitorUserContextMockImpl)

	typedef IVsMonitorUserContext Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ApplicationContextValidValues
	{
		/*[out,retval]*/ IVsUserContext** ppContext;
		HRESULT retValue;
	};

	STDMETHOD(get_ApplicationContext)(
		/*[out,retval]*/ IVsUserContext** ppContext)
	{
		VSL_DEFINE_MOCK_METHOD(get_ApplicationContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ApplicationContextValidValues
	{
		/*[in]*/ IVsUserContext* pContext;
		HRESULT retValue;
	};

	STDMETHOD(put_ApplicationContext)(
		/*[in]*/ IVsUserContext* pContext)
	{
		VSL_DEFINE_MOCK_METHOD(put_ApplicationContext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateEmptyContextValidValues
	{
		/*[out,retval]*/ IVsUserContext** ppContext;
		HRESULT retValue;
	};

	STDMETHOD(CreateEmptyContext)(
		/*[out,retval]*/ IVsUserContext** ppContext)
	{
		VSL_DEFINE_MOCK_METHOD(CreateEmptyContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContextItemsValidValues
	{
		/*[out]*/ IVsUserContextItemCollection** pplist;
		HRESULT retValue;
	};

	STDMETHOD(GetContextItems)(
		/*[out]*/ IVsUserContextItemCollection** pplist)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextItems)

		VSL_SET_VALIDVALUE_INTERFACE(pplist);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindTargetItemsValidValues
	{
		/*[in]*/ LPCOLESTR pszTargetAttr;
		/*[in]*/ LPCOLESTR pszTargetAttrValue;
		/*[out]*/ IVsUserContextItemCollection** ppList;
		/*[out]*/ BOOL* pfF1Kwd;
		HRESULT retValue;
	};

	STDMETHOD(FindTargetItems)(
		/*[in]*/ LPCOLESTR pszTargetAttr,
		/*[in]*/ LPCOLESTR pszTargetAttrValue,
		/*[out]*/ IVsUserContextItemCollection** ppList,
		/*[out]*/ BOOL* pfF1Kwd)
	{
		VSL_DEFINE_MOCK_METHOD(FindTargetItems)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTargetAttr);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTargetAttrValue);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_SET_VALIDVALUE(pfF1Kwd);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterItemProviderValidValues
	{
		/*[in]*/ IVsUserContextItemProvider* pProvider;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterItemProvider)(
		/*[in]*/ IVsUserContextItemProvider* pProvider,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterItemProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProvider);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterItemProviderValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterItemProvider)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterItemProvider)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseContextItemEventsValidValues
	{
		/*[in]*/ IVsUserContextItemEvents* pEvents;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseContextItemEvents)(
		/*[in]*/ IVsUserContextItemEvents* pEvents,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseContextItemEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvents);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseContextItemEventValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseContextItemEvent)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseContextItemEvent)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNextCtxBagAttrValidValues
	{
		/*[out]*/ BSTR* pbstrAttrName;
		/*[out]*/ BSTR* pbstrAttrVal;
		HRESULT retValue;
	};

	STDMETHOD(GetNextCtxBagAttr)(
		/*[out]*/ BSTR* pbstrAttrName,
		/*[out]*/ BSTR* pbstrAttrVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetNextCtxBagAttr)

		VSL_SET_VALIDVALUE_BSTR(pbstrAttrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrAttrVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetNextCtxBagAttrValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ResetNextCtxBagAttr)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ResetNextCtxBagAttr)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPrevAttrCacheValidValues
	{
		/*[out]*/ BSTR** pbstrCacheArray;
		/*[out]*/ int** pnCurrNumStored;
		/*[out]*/ int* pnMaxNumStored;
		HRESULT retValue;
	};

	STDMETHOD(GetPrevAttrCache)(
		/*[out]*/ BSTR** pbstrCacheArray,
		/*[out]*/ int** pnCurrNumStored,
		/*[out]*/ int* pnMaxNumStored)
	{
		VSL_DEFINE_MOCK_METHOD(GetPrevAttrCache)

		VSL_SET_VALIDVALUE(pbstrCacheArray);

		VSL_SET_VALIDVALUE(pnCurrNumStored);

		VSL_SET_VALIDVALUE(pnMaxNumStored);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNextCtxBagValidValues
	{
		/*[out]*/ BSTR* pbstrAttrName;
		/*[out]*/ BSTR* pbstrAttrVal;
		HRESULT retValue;
	};

	STDMETHOD(GetNextCtxBag)(
		/*[out]*/ BSTR* pbstrAttrName,
		/*[out]*/ BSTR* pbstrAttrVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetNextCtxBag)

		VSL_SET_VALIDVALUE_BSTR(pbstrAttrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrAttrVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsIdleAvailableValidValues
	{
		/*[out]*/ BOOL* pfIdleAvail;
		HRESULT retValue;
	};

	STDMETHOD(IsIdleAvailable)(
		/*[out]*/ BOOL* pfIdleAvail)
	{
		VSL_DEFINE_MOCK_METHOD(IsIdleAvailable)

		VSL_SET_VALIDVALUE(pfIdleAvail);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTopicTypeFilterValidValues
	{
		/*[in]*/ IVsHelpAttributeList* pTopicTypeList;
		HRESULT retValue;
	};

	STDMETHOD(SetTopicTypeFilter)(
		/*[in]*/ IVsHelpAttributeList* pTopicTypeList)
	{
		VSL_DEFINE_MOCK_METHOD(SetTopicTypeFilter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTopicTypeList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetF1KwdValidValues
	{
		/*[out]*/ BSTR* pbstrKwd;
		/*[out]*/ BOOL* fF1Kwd;
		HRESULT retValue;
	};

	STDMETHOD(GetF1Kwd)(
		/*[out]*/ BSTR* pbstrKwd,
		/*[out]*/ BOOL* fF1Kwd)
	{
		VSL_DEFINE_MOCK_METHOD(GetF1Kwd)

		VSL_SET_VALIDVALUE_BSTR(pbstrKwd);

		VSL_SET_VALIDVALUE(fF1Kwd);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsF1LookupValidValues
	{
		/*[out]*/ BOOL* fF1Lookup;
		HRESULT retValue;
	};

	STDMETHOD(IsF1Lookup)(
		/*[out]*/ BOOL* fF1Lookup)
	{
		VSL_DEFINE_MOCK_METHOD(IsF1Lookup)

		VSL_SET_VALIDVALUE(fF1Lookup);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMONITORUSERCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
