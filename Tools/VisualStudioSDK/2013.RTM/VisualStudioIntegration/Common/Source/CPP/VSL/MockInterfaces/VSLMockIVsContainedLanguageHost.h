/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsContainedLanguageHostNotImpl :
	public IVsContainedLanguageHost
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageHostNotImpl)

public:

	typedef IVsContainedLanguageHost Interface;

	STDMETHOD(Advise)(
		/*[in]*/ IVsContainedLanguageHostEvents* /*pHost*/,
		/*[out]*/ VSCOOKIE* /*pvsCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unadvise)(
		/*[in]*/ VSCOOKIE /*vsCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineIndent)(
		/*[in]*/ long /*lLineNumber*/,
		/*[out]*/ BSTR* /*pbstrIndentString*/,
		/*[out]*/ long* /*plParentIndentLevel*/,
		/*[out]*/ long* /*plIndentSize*/,
		/*[out]*/ BOOL* /*pfTabs*/,
		/*[out]*/ long* /*plTabSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanReformatCode)(
		/*[out]*/ BOOL* /*pfCanReformat*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNearestVisibleToken)(
		/*[in]*/ TextSpan /*tsSecondaryToken*/,
		/*[out]*/ TextSpan* /*ptsPrimaryToken*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureSpanVisible)(
		/*[in]*/ TextSpan /*tsPrimary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryEditFile)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRenamed)(
		/*[in]*/ ContainedLanguageRenameType /*clrt*/,
		/*[in]*/ BSTR /*bstrOldID*/,
		/*[in]*/ BSTR /*bstrNewID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertControl)(
		/*[in]*/ const WCHAR* /*pwcFullType*/,
		/*[in]*/ const WCHAR* /*pwcID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertReference)(
		/*[in]*/ const WCHAR* /*param1*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVSHierarchy)(
		/*[out]*/ IVsHierarchy** /*ppVsHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetErrorProviderInformation)(
		/*[out]*/ BSTR* /*pbstrTaskProviderName*/,
		/*[out]*/ GUID* /*pguidTaskProviderGuid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertImportsDirective)(
		/*[in]*/ const WCHAR* /*param1*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnContainedLanguageEditorSettingsChange)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureSecondaryBufferReady)()VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageHostMockImpl :
	public IVsContainedLanguageHost,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageHostMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageHostMockImpl)

	typedef IVsContainedLanguageHost Interface;
	struct AdviseValidValues
	{
		/*[in]*/ IVsContainedLanguageHostEvents* pHost;
		/*[out]*/ VSCOOKIE* pvsCookie;
		HRESULT retValue;
	};

	STDMETHOD(Advise)(
		/*[in]*/ IVsContainedLanguageHostEvents* pHost,
		/*[out]*/ VSCOOKIE* pvsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Advise)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_SET_VALIDVALUE(pvsCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseValidValues
	{
		/*[in]*/ VSCOOKIE vsCookie;
		HRESULT retValue;
	};

	STDMETHOD(Unadvise)(
		/*[in]*/ VSCOOKIE vsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Unadvise)

		VSL_CHECK_VALIDVALUE(vsCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineIndentValidValues
	{
		/*[in]*/ long lLineNumber;
		/*[out]*/ BSTR* pbstrIndentString;
		/*[out]*/ long* plParentIndentLevel;
		/*[out]*/ long* plIndentSize;
		/*[out]*/ BOOL* pfTabs;
		/*[out]*/ long* plTabSize;
		HRESULT retValue;
	};

	STDMETHOD(GetLineIndent)(
		/*[in]*/ long lLineNumber,
		/*[out]*/ BSTR* pbstrIndentString,
		/*[out]*/ long* plParentIndentLevel,
		/*[out]*/ long* plIndentSize,
		/*[out]*/ BOOL* pfTabs,
		/*[out]*/ long* plTabSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineIndent)

		VSL_CHECK_VALIDVALUE(lLineNumber);

		VSL_SET_VALIDVALUE_BSTR(pbstrIndentString);

		VSL_SET_VALIDVALUE(plParentIndentLevel);

		VSL_SET_VALIDVALUE(plIndentSize);

		VSL_SET_VALIDVALUE(pfTabs);

		VSL_SET_VALIDVALUE(plTabSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanReformatCodeValidValues
	{
		/*[out]*/ BOOL* pfCanReformat;
		HRESULT retValue;
	};

	STDMETHOD(CanReformatCode)(
		/*[out]*/ BOOL* pfCanReformat)
	{
		VSL_DEFINE_MOCK_METHOD(CanReformatCode)

		VSL_SET_VALIDVALUE(pfCanReformat);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNearestVisibleTokenValidValues
	{
		/*[in]*/ TextSpan tsSecondaryToken;
		/*[out]*/ TextSpan* ptsPrimaryToken;
		HRESULT retValue;
	};

	STDMETHOD(GetNearestVisibleToken)(
		/*[in]*/ TextSpan tsSecondaryToken,
		/*[out]*/ TextSpan* ptsPrimaryToken)
	{
		VSL_DEFINE_MOCK_METHOD(GetNearestVisibleToken)

		VSL_CHECK_VALIDVALUE(tsSecondaryToken);

		VSL_SET_VALIDVALUE(ptsPrimaryToken);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureSpanVisibleValidValues
	{
		/*[in]*/ TextSpan tsPrimary;
		HRESULT retValue;
	};

	STDMETHOD(EnsureSpanVisible)(
		/*[in]*/ TextSpan tsPrimary)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureSpanVisible)

		VSL_CHECK_VALIDVALUE(tsPrimary);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryEditFileValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(QueryEditFile)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(QueryEditFile)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRenamedValidValues
	{
		/*[in]*/ ContainedLanguageRenameType clrt;
		/*[in]*/ BSTR bstrOldID;
		/*[in]*/ BSTR bstrNewID;
		HRESULT retValue;
	};

	STDMETHOD(OnRenamed)(
		/*[in]*/ ContainedLanguageRenameType clrt,
		/*[in]*/ BSTR bstrOldID,
		/*[in]*/ BSTR bstrNewID)
	{
		VSL_DEFINE_MOCK_METHOD(OnRenamed)

		VSL_CHECK_VALIDVALUE(clrt);

		VSL_CHECK_VALIDVALUE_BSTR(bstrOldID);

		VSL_CHECK_VALIDVALUE_BSTR(bstrNewID);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertControlValidValues
	{
		/*[in]*/ WCHAR* pwcFullType;
		/*[in]*/ WCHAR* pwcID;
		HRESULT retValue;
	};

	STDMETHOD(InsertControl)(
		/*[in]*/ const WCHAR* pwcFullType,
		/*[in]*/ const WCHAR* pwcID)
	{
		VSL_DEFINE_MOCK_METHOD(InsertControl)

		VSL_CHECK_VALIDVALUE_STRINGW(pwcFullType);

		VSL_CHECK_VALIDVALUE_STRINGW(pwcID);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertReferenceValidValues
	{
		/*[in]*/ WCHAR* param1;
		HRESULT retValue;
	};

	STDMETHOD(InsertReference)(
		/*[in]*/ const WCHAR* param1)
	{
		VSL_DEFINE_MOCK_METHOD(InsertReference)

		VSL_CHECK_VALIDVALUE_STRINGW(param1);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVSHierarchyValidValues
	{
		/*[out]*/ IVsHierarchy** ppVsHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(GetVSHierarchy)(
		/*[out]*/ IVsHierarchy** ppVsHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(GetVSHierarchy)

		VSL_SET_VALIDVALUE_INTERFACE(ppVsHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetErrorProviderInformationValidValues
	{
		/*[out]*/ BSTR* pbstrTaskProviderName;
		/*[out]*/ GUID* pguidTaskProviderGuid;
		HRESULT retValue;
	};

	STDMETHOD(GetErrorProviderInformation)(
		/*[out]*/ BSTR* pbstrTaskProviderName,
		/*[out]*/ GUID* pguidTaskProviderGuid)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrorProviderInformation)

		VSL_SET_VALIDVALUE_BSTR(pbstrTaskProviderName);

		VSL_SET_VALIDVALUE(pguidTaskProviderGuid);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertImportsDirectiveValidValues
	{
		/*[in]*/ WCHAR* param1;
		HRESULT retValue;
	};

	STDMETHOD(InsertImportsDirective)(
		/*[in]*/ const WCHAR* param1)
	{
		VSL_DEFINE_MOCK_METHOD(InsertImportsDirective)

		VSL_CHECK_VALIDVALUE_STRINGW(param1);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnContainedLanguageEditorSettingsChangeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnContainedLanguageEditorSettingsChange)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnContainedLanguageEditorSettingsChange)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureSecondaryBufferReadyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EnsureSecondaryBufferReady)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EnsureSecondaryBufferReady)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGEHOST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
