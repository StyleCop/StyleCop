/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBBROWSERUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBBROWSERUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsbrowse.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebBrowserUserNotImpl :
	public IVsWebBrowserUser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowserUserNotImpl)

public:

	typedef IVsWebBrowserUser Interface;

	STDMETHOD(Disconnect)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCustomMenuInfo)(
		/*[in]*/ IUnknown* /*pUnkCmdReserved*/,
		/*[in]*/ IDispatch* /*pDispReserved*/,
		/*[in]*/ DWORD /*dwType*/,
		/*[in]*/ DWORD /*dwPosition*/,
		/*[out]*/ GUID* /*pguidCmdGroup*/,
		/*[out]*/ long* /*pdwMenuID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCmdUIGuid)(
		/*[out]*/ GUID* /*pguidCmdUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExternalObject)(
		/*[out]*/ IDispatch** /*ppDispObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateUrl)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ LPCOLESTR /*lpszURLIn*/,
		/*[out]*/ LPOLESTR* /*lppszURLOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterDataObject)(
		/*[in]*/ IDataObject* /*pDataObjIn*/,
		/*[out]*/ IDataObject** /*ppDataObjOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDropTarget)(
		/*[in]*/ IDropTarget* /*pDropTgtIn*/,
		/*[out]*/ IDropTarget** /*ppDropTgtOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelarator)(
		/*[in]*/ LPMSG /*lpMsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCustomURL)(
		/*[in]*/ VSWBCUSTOMURL /*nPage*/,
		/*[out]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOptionKeyPath)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[out]*/ BSTR* /*pbstrKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Resize)(
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebBrowserUserMockImpl :
	public IVsWebBrowserUser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowserUserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebBrowserUserMockImpl)

	typedef IVsWebBrowserUser Interface;
	struct DisconnectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Disconnect)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Disconnect)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCustomMenuInfoValidValues
	{
		/*[in]*/ IUnknown* pUnkCmdReserved;
		/*[in]*/ IDispatch* pDispReserved;
		/*[in]*/ DWORD dwType;
		/*[in]*/ DWORD dwPosition;
		/*[out]*/ GUID* pguidCmdGroup;
		/*[out]*/ long* pdwMenuID;
		HRESULT retValue;
	};

	STDMETHOD(GetCustomMenuInfo)(
		/*[in]*/ IUnknown* pUnkCmdReserved,
		/*[in]*/ IDispatch* pDispReserved,
		/*[in]*/ DWORD dwType,
		/*[in]*/ DWORD dwPosition,
		/*[out]*/ GUID* pguidCmdGroup,
		/*[out]*/ long* pdwMenuID)
	{
		VSL_DEFINE_MOCK_METHOD(GetCustomMenuInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkCmdReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDispReserved);

		VSL_CHECK_VALIDVALUE(dwType);

		VSL_CHECK_VALIDVALUE(dwPosition);

		VSL_SET_VALIDVALUE(pguidCmdGroup);

		VSL_SET_VALIDVALUE(pdwMenuID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCmdUIGuidValidValues
	{
		/*[out]*/ GUID* pguidCmdUI;
		HRESULT retValue;
	};

	STDMETHOD(GetCmdUIGuid)(
		/*[out]*/ GUID* pguidCmdUI)
	{
		VSL_DEFINE_MOCK_METHOD(GetCmdUIGuid)

		VSL_SET_VALIDVALUE(pguidCmdUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExternalObjectValidValues
	{
		/*[out]*/ IDispatch** ppDispObject;
		HRESULT retValue;
	};

	STDMETHOD(GetExternalObject)(
		/*[out]*/ IDispatch** ppDispObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetExternalObject)

		VSL_SET_VALIDVALUE_INTERFACE(ppDispObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateUrlValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ LPCOLESTR lpszURLIn;
		/*[out]*/ LPOLESTR* lppszURLOut;
		HRESULT retValue;
	};

	STDMETHOD(TranslateUrl)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ LPCOLESTR lpszURLIn,
		/*[out]*/ LPOLESTR* lppszURLOut)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateUrl)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURLIn);

		VSL_SET_VALIDVALUE(lppszURLOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterDataObjectValidValues
	{
		/*[in]*/ IDataObject* pDataObjIn;
		/*[out]*/ IDataObject** ppDataObjOut;
		HRESULT retValue;
	};

	STDMETHOD(FilterDataObject)(
		/*[in]*/ IDataObject* pDataObjIn,
		/*[out]*/ IDataObject** ppDataObjOut)
	{
		VSL_DEFINE_MOCK_METHOD(FilterDataObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObjIn);

		VSL_SET_VALIDVALUE_INTERFACE(ppDataObjOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDropTargetValidValues
	{
		/*[in]*/ IDropTarget* pDropTgtIn;
		/*[out]*/ IDropTarget** ppDropTgtOut;
		HRESULT retValue;
	};

	STDMETHOD(GetDropTarget)(
		/*[in]*/ IDropTarget* pDropTgtIn,
		/*[out]*/ IDropTarget** ppDropTgtOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetDropTarget)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDropTgtIn);

		VSL_SET_VALIDVALUE_INTERFACE(ppDropTgtOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAccelaratorValidValues
	{
		/*[in]*/ LPMSG lpMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelarator)(
		/*[in]*/ LPMSG lpMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelarator)

		VSL_CHECK_VALIDVALUE(lpMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCustomURLValidValues
	{
		/*[in]*/ VSWBCUSTOMURL nPage;
		/*[out]*/ BSTR* pbstrURL;
		HRESULT retValue;
	};

	STDMETHOD(GetCustomURL)(
		/*[in]*/ VSWBCUSTOMURL nPage,
		/*[out]*/ BSTR* pbstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(GetCustomURL)

		VSL_CHECK_VALIDVALUE(nPage);

		VSL_SET_VALIDVALUE_BSTR(pbstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOptionKeyPathValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[out]*/ BSTR* pbstrKey;
		HRESULT retValue;
	};

	STDMETHOD(GetOptionKeyPath)(
		/*[in]*/ DWORD dwReserved,
		/*[out]*/ BSTR* pbstrKey)
	{
		VSL_DEFINE_MOCK_METHOD(GetOptionKeyPath)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE_BSTR(pbstrKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResizeValidValues
	{
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		HRESULT retValue;
	};

	STDMETHOD(Resize)(
		/*[in]*/ int cx,
		/*[in]*/ int cy)
	{
		VSL_DEFINE_MOCK_METHOD(Resize)

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBBROWSERUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
