/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCodeWindowNotImpl :
	public IVsCodeWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowNotImpl)

public:

	typedef IVsCodeWindow Interface;

	STDMETHOD(SetBuffer)(
		/*[in]*/ IVsTextLines* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuffer)(
		/*[out]*/ IVsTextLines** /*ppBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPrimaryView)(
		/*[out]*/ IVsTextView** /*ppView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSecondaryView)(
		/*[out]*/ IVsTextView** /*ppView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetViewClassID)(
		/*[in]*/ REFCLSID /*clsidView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetViewClassID)(
		/*[out]*/ CLSID* /*pclsidView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBaseEditorCaption)(
		/*[in]*/ LPCOLESTR* /*pszBaseEditorCaption*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEditorCaption)(
		/*[in]*/ READONLYSTATUS /*dwReadOnly*/,
		/*[out]*/ BSTR* /*pbstrEditorCaption*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastActiveView)(
		/*[out]*/ IVsTextView** /*ppView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeWindowMockImpl :
	public IVsCodeWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeWindowMockImpl)

	typedef IVsCodeWindow Interface;
	struct SetBufferValidValues
	{
		/*[in]*/ IVsTextLines* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(SetBuffer)(
		/*[in]*/ IVsTextLines* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(SetBuffer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetBuffer)(
		/*[out]*/ IVsTextLines** ppBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPrimaryViewValidValues
	{
		/*[out]*/ IVsTextView** ppView;
		HRESULT retValue;
	};

	STDMETHOD(GetPrimaryView)(
		/*[out]*/ IVsTextView** ppView)
	{
		VSL_DEFINE_MOCK_METHOD(GetPrimaryView)

		VSL_SET_VALIDVALUE_INTERFACE(ppView);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSecondaryViewValidValues
	{
		/*[out]*/ IVsTextView** ppView;
		HRESULT retValue;
	};

	STDMETHOD(GetSecondaryView)(
		/*[out]*/ IVsTextView** ppView)
	{
		VSL_DEFINE_MOCK_METHOD(GetSecondaryView)

		VSL_SET_VALIDVALUE_INTERFACE(ppView);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetViewClassIDValidValues
	{
		/*[in]*/ REFCLSID clsidView;
		HRESULT retValue;
	};

	STDMETHOD(SetViewClassID)(
		/*[in]*/ REFCLSID clsidView)
	{
		VSL_DEFINE_MOCK_METHOD(SetViewClassID)

		VSL_CHECK_VALIDVALUE(clsidView);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetViewClassIDValidValues
	{
		/*[out]*/ CLSID* pclsidView;
		HRESULT retValue;
	};

	STDMETHOD(GetViewClassID)(
		/*[out]*/ CLSID* pclsidView)
	{
		VSL_DEFINE_MOCK_METHOD(GetViewClassID)

		VSL_SET_VALIDVALUE(pclsidView);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBaseEditorCaptionValidValues
	{
		/*[in]*/ LPCOLESTR* pszBaseEditorCaption;
		HRESULT retValue;
	};

	STDMETHOD(SetBaseEditorCaption)(
		/*[in]*/ LPCOLESTR* pszBaseEditorCaption)
	{
		VSL_DEFINE_MOCK_METHOD(SetBaseEditorCaption)

		VSL_CHECK_VALIDVALUE_POINTER(pszBaseEditorCaption);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEditorCaptionValidValues
	{
		/*[in]*/ READONLYSTATUS dwReadOnly;
		/*[out]*/ BSTR* pbstrEditorCaption;
		HRESULT retValue;
	};

	STDMETHOD(GetEditorCaption)(
		/*[in]*/ READONLYSTATUS dwReadOnly,
		/*[out]*/ BSTR* pbstrEditorCaption)
	{
		VSL_DEFINE_MOCK_METHOD(GetEditorCaption)

		VSL_CHECK_VALIDVALUE(dwReadOnly);

		VSL_SET_VALIDVALUE_BSTR(pbstrEditorCaption);

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
	struct GetLastActiveViewValidValues
	{
		/*[out]*/ IVsTextView** ppView;
		HRESULT retValue;
	};

	STDMETHOD(GetLastActiveView)(
		/*[out]*/ IVsTextView** ppView)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastActiveView)

		VSL_SET_VALIDVALUE_INTERFACE(ppView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
