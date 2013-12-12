/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsContainedLanguageNotImpl :
	public IVsContainedLanguage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageNotImpl)

public:

	typedef IVsContainedLanguage Interface;

	STDMETHOD(SetHost)(
		/*[in]*/ IVsContainedLanguageHost* /*pHost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColorizer)(
		/*[out,retval]*/ IVsColorizer** /*ppColorizer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextViewFilter)(
		/*[in]*/ IVsIntellisenseHost* /*pISenseHost*/,
		/*[in]*/ IOleCommandTarget* /*pNextCmdTarget*/,
		/*[out,retval]*/ IVsTextViewFilter** /*pTextViewFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageServiceID)(
		/*[out]*/ GUID* /*pguidLangService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBufferCoordinator)(
		/*[in]*/ IVsTextBufferCoordinator* /*pBC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Refresh)(
		/*[in]*/ DWORD /*dwRefreshMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitForReadyState)()VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageMockImpl :
	public IVsContainedLanguage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageMockImpl)

	typedef IVsContainedLanguage Interface;
	struct SetHostValidValues
	{
		/*[in]*/ IVsContainedLanguageHost* pHost;
		HRESULT retValue;
	};

	STDMETHOD(SetHost)(
		/*[in]*/ IVsContainedLanguageHost* pHost)
	{
		VSL_DEFINE_MOCK_METHOD(SetHost)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColorizerValidValues
	{
		/*[out,retval]*/ IVsColorizer** ppColorizer;
		HRESULT retValue;
	};

	STDMETHOD(GetColorizer)(
		/*[out,retval]*/ IVsColorizer** ppColorizer)
	{
		VSL_DEFINE_MOCK_METHOD(GetColorizer)

		VSL_SET_VALIDVALUE_INTERFACE(ppColorizer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextViewFilterValidValues
	{
		/*[in]*/ IVsIntellisenseHost* pISenseHost;
		/*[in]*/ IOleCommandTarget* pNextCmdTarget;
		/*[out,retval]*/ IVsTextViewFilter** pTextViewFilter;
		HRESULT retValue;
	};

	STDMETHOD(GetTextViewFilter)(
		/*[in]*/ IVsIntellisenseHost* pISenseHost,
		/*[in]*/ IOleCommandTarget* pNextCmdTarget,
		/*[out,retval]*/ IVsTextViewFilter** pTextViewFilter)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextViewFilter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pISenseHost);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNextCmdTarget);

		VSL_SET_VALIDVALUE_INTERFACE(pTextViewFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLanguageServiceIDValidValues
	{
		/*[out]*/ GUID* pguidLangService;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageServiceID)(
		/*[out]*/ GUID* pguidLangService)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageServiceID)

		VSL_SET_VALIDVALUE(pguidLangService);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBufferCoordinatorValidValues
	{
		/*[in]*/ IVsTextBufferCoordinator* pBC;
		HRESULT retValue;
	};

	STDMETHOD(SetBufferCoordinator)(
		/*[in]*/ IVsTextBufferCoordinator* pBC)
	{
		VSL_DEFINE_MOCK_METHOD(SetBufferCoordinator)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBC);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshValidValues
	{
		/*[in]*/ DWORD dwRefreshMode;
		HRESULT retValue;
	};

	STDMETHOD(Refresh)(
		/*[in]*/ DWORD dwRefreshMode)
	{
		VSL_DEFINE_MOCK_METHOD(Refresh)

		VSL_CHECK_VALIDVALUE(dwRefreshMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitForReadyStateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(WaitForReadyState)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(WaitForReadyState)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
