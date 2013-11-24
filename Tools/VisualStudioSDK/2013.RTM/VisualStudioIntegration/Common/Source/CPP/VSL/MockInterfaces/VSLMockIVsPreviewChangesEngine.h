/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPREVIEWCHANGESENGINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPREVIEWCHANGESENGINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsPreviewChangesEngineNotImpl :
	public IVsPreviewChangesEngine
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPreviewChangesEngineNotImpl)

public:

	typedef IVsPreviewChangesEngine Interface;

	STDMETHOD(GetTitle)(
		/*[out]*/ BSTR* /*pbstrTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextViewDescription)(
		/*[out]*/ BSTR* /*pbstrTextViewDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWarning)(
		/*[out]*/ BSTR* /*pbstrWarning*/,
		/*[out]*/ PREVIEWCHANGESWARNINGLEVEL* /*ppcwlWarningLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHelpContext)(
		/*[out]*/ BSTR* /*pbstrHelpContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetConfirmation)(
		/*[out]*/ BSTR* /*pbstrConfirmation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRootChangesList)(
		/*[out]*/ IUnknown** /*ppIUnknownPreviewChangesList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ApplyChanges)()VSL_STDMETHOD_NOTIMPL
};

class IVsPreviewChangesEngineMockImpl :
	public IVsPreviewChangesEngine,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPreviewChangesEngineMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPreviewChangesEngineMockImpl)

	typedef IVsPreviewChangesEngine Interface;
	struct GetTitleValidValues
	{
		/*[out]*/ BSTR* pbstrTitle;
		HRESULT retValue;
	};

	STDMETHOD(GetTitle)(
		/*[out]*/ BSTR* pbstrTitle)
	{
		VSL_DEFINE_MOCK_METHOD(GetTitle)

		VSL_SET_VALIDVALUE_BSTR(pbstrTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextViewDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrTextViewDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetTextViewDescription)(
		/*[out]*/ BSTR* pbstrTextViewDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextViewDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrTextViewDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWarningValidValues
	{
		/*[out]*/ BSTR* pbstrWarning;
		/*[out]*/ PREVIEWCHANGESWARNINGLEVEL* ppcwlWarningLevel;
		HRESULT retValue;
	};

	STDMETHOD(GetWarning)(
		/*[out]*/ BSTR* pbstrWarning,
		/*[out]*/ PREVIEWCHANGESWARNINGLEVEL* ppcwlWarningLevel)
	{
		VSL_DEFINE_MOCK_METHOD(GetWarning)

		VSL_SET_VALIDVALUE_BSTR(pbstrWarning);

		VSL_SET_VALIDVALUE(ppcwlWarningLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHelpContextValidValues
	{
		/*[out]*/ BSTR* pbstrHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(GetHelpContext)(
		/*[out]*/ BSTR* pbstrHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetHelpContext)

		VSL_SET_VALIDVALUE_BSTR(pbstrHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetConfirmationValidValues
	{
		/*[out]*/ BSTR* pbstrConfirmation;
		HRESULT retValue;
	};

	STDMETHOD(GetConfirmation)(
		/*[out]*/ BSTR* pbstrConfirmation)
	{
		VSL_DEFINE_MOCK_METHOD(GetConfirmation)

		VSL_SET_VALIDVALUE_BSTR(pbstrConfirmation);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRootChangesListValidValues
	{
		/*[out]*/ IUnknown** ppIUnknownPreviewChangesList;
		HRESULT retValue;
	};

	STDMETHOD(GetRootChangesList)(
		/*[out]*/ IUnknown** ppIUnknownPreviewChangesList)
	{
		VSL_DEFINE_MOCK_METHOD(GetRootChangesList)

		VSL_SET_VALIDVALUE_INTERFACE(ppIUnknownPreviewChangesList);

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplyChangesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ApplyChanges)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ApplyChanges)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPREVIEWCHANGESENGINE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
