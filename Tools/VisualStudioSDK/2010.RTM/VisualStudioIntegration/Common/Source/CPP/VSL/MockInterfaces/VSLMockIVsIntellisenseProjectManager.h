/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSEPROJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSEPROJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsIntellisenseProjectManagerNotImpl :
	public IVsIntellisenseProjectManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectManagerNotImpl)

public:

	typedef IVsIntellisenseProjectManager Interface;

	STDMETHOD(AdviseIntellisenseProjectEvents)(
		/*[in]*/ IVsIntellisenseProjectEventSink* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseIntellisenseProjectEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContainedLanguageFactory)(
		/*[in]*/ BSTR /*bstrLanguage*/,
		/*[out]*/ IVsContainedLanguageFactory** /*ppContainedLanguageFactory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseIntellisenseProject)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnEditorReady)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CompleteIntellisenseProjectLoad)()VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseProjectManagerMockImpl :
	public IVsIntellisenseProjectManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseProjectManagerMockImpl)

	typedef IVsIntellisenseProjectManager Interface;
	struct AdviseIntellisenseProjectEventsValidValues
	{
		/*[in]*/ IVsIntellisenseProjectEventSink* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseIntellisenseProjectEvents)(
		/*[in]*/ IVsIntellisenseProjectEventSink* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseIntellisenseProjectEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseIntellisenseProjectEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseIntellisenseProjectEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseIntellisenseProjectEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContainedLanguageFactoryValidValues
	{
		/*[in]*/ BSTR bstrLanguage;
		/*[out]*/ IVsContainedLanguageFactory** ppContainedLanguageFactory;
		HRESULT retValue;
	};

	STDMETHOD(GetContainedLanguageFactory)(
		/*[in]*/ BSTR bstrLanguage,
		/*[out]*/ IVsContainedLanguageFactory** ppContainedLanguageFactory)
	{
		VSL_DEFINE_MOCK_METHOD(GetContainedLanguageFactory)

		VSL_CHECK_VALIDVALUE_BSTR(bstrLanguage);

		VSL_SET_VALIDVALUE_INTERFACE(ppContainedLanguageFactory);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseIntellisenseProjectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseIntellisenseProject)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseIntellisenseProject)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEditorReadyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnEditorReady)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnEditorReady)

		VSL_RETURN_VALIDVALUES();
	}
	struct CompleteIntellisenseProjectLoadValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CompleteIntellisenseProjectLoad)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CompleteIntellisenseProjectLoad)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSEPROJECTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
