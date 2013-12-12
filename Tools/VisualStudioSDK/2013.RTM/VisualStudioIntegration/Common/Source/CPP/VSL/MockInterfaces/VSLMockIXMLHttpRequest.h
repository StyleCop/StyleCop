/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IXMLHTTPREQUEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IXMLHTTPREQUEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "XmlDom.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IXMLHttpRequestNotImpl :
	public IXMLHttpRequest
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLHttpRequestNotImpl)

public:

	typedef IXMLHttpRequest Interface;

	STDMETHOD(open)(
		/*[in]*/ BSTR /*bstrMethod*/,
		/*[in]*/ BSTR /*bstrUrl*/,
		/*[in,optional]*/ VARIANT /*varAsync*/,
		/*[in,optional]*/ VARIANT /*bstrUser*/,
		/*[in,optional]*/ VARIANT /*bstrPassword*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(setRequestHeader)(
		/*[in]*/ BSTR /*bstrHeader*/,
		/*[in]*/ BSTR /*bstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(getResponseHeader)(
		/*[in]*/ BSTR /*bstrHeader*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(getAllResponseHeaders)(
		/*[out,retval]*/ BSTR* /*pbstrHeaders*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(send)(
		/*[in,optional]*/ VARIANT /*varBody*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(abort)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_status)(
		/*[out,retval]*/ long* /*plStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_statusText)(
		/*[out,retval]*/ BSTR* /*pbstrStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_responseXML)(
		/*[out,retval]*/ IDispatch** /*ppBody*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_responseText)(
		/*[out,retval]*/ BSTR* /*pbstrBody*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_responseBody)(
		/*[out,retval]*/ VARIANT* /*pvarBody*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_responseStream)(
		/*[out,retval]*/ VARIANT* /*pvarBody*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_readyState)(
		/*[out,retval]*/ long* /*plState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_onreadystatechange)(
		/*[in]*/ IDispatch* /*pReadyStateSink*/)VSL_STDMETHOD_NOTIMPL

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

class IXMLHttpRequestMockImpl :
	public IXMLHttpRequest,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLHttpRequestMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IXMLHttpRequestMockImpl)

	typedef IXMLHttpRequest Interface;
	struct openValidValues
	{
		/*[in]*/ BSTR bstrMethod;
		/*[in]*/ BSTR bstrUrl;
		/*[in,optional]*/ VARIANT varAsync;
		/*[in,optional]*/ VARIANT bstrUser;
		/*[in,optional]*/ VARIANT bstrPassword;
		HRESULT retValue;
	};

	STDMETHOD(open)(
		/*[in]*/ BSTR bstrMethod,
		/*[in]*/ BSTR bstrUrl,
		/*[in,optional]*/ VARIANT varAsync,
		/*[in,optional]*/ VARIANT bstrUser,
		/*[in,optional]*/ VARIANT bstrPassword)
	{
		VSL_DEFINE_MOCK_METHOD(open)

		VSL_CHECK_VALIDVALUE_BSTR(bstrMethod);

		VSL_CHECK_VALIDVALUE_BSTR(bstrUrl);

		VSL_CHECK_VALIDVALUE(varAsync);

		VSL_CHECK_VALIDVALUE(bstrUser);

		VSL_CHECK_VALIDVALUE(bstrPassword);

		VSL_RETURN_VALIDVALUES();
	}
	struct setRequestHeaderValidValues
	{
		/*[in]*/ BSTR bstrHeader;
		/*[in]*/ BSTR bstrValue;
		HRESULT retValue;
	};

	STDMETHOD(setRequestHeader)(
		/*[in]*/ BSTR bstrHeader,
		/*[in]*/ BSTR bstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(setRequestHeader)

		VSL_CHECK_VALIDVALUE_BSTR(bstrHeader);

		VSL_CHECK_VALIDVALUE_BSTR(bstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct getResponseHeaderValidValues
	{
		/*[in]*/ BSTR bstrHeader;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(getResponseHeader)(
		/*[in]*/ BSTR bstrHeader,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(getResponseHeader)

		VSL_CHECK_VALIDVALUE_BSTR(bstrHeader);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct getAllResponseHeadersValidValues
	{
		/*[out,retval]*/ BSTR* pbstrHeaders;
		HRESULT retValue;
	};

	STDMETHOD(getAllResponseHeaders)(
		/*[out,retval]*/ BSTR* pbstrHeaders)
	{
		VSL_DEFINE_MOCK_METHOD(getAllResponseHeaders)

		VSL_SET_VALIDVALUE_BSTR(pbstrHeaders);

		VSL_RETURN_VALIDVALUES();
	}
	struct sendValidValues
	{
		/*[in,optional]*/ VARIANT varBody;
		HRESULT retValue;
	};

	STDMETHOD(send)(
		/*[in,optional]*/ VARIANT varBody)
	{
		VSL_DEFINE_MOCK_METHOD(send)

		VSL_CHECK_VALIDVALUE(varBody);

		VSL_RETURN_VALIDVALUES();
	}
	struct abortValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(abort)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(abort)

		VSL_RETURN_VALIDVALUES();
	}
	struct get_statusValidValues
	{
		/*[out,retval]*/ long* plStatus;
		HRESULT retValue;
	};

	STDMETHOD(get_status)(
		/*[out,retval]*/ long* plStatus)
	{
		VSL_DEFINE_MOCK_METHOD(get_status)

		VSL_SET_VALIDVALUE(plStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_statusTextValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStatus;
		HRESULT retValue;
	};

	STDMETHOD(get_statusText)(
		/*[out,retval]*/ BSTR* pbstrStatus)
	{
		VSL_DEFINE_MOCK_METHOD(get_statusText)

		VSL_SET_VALIDVALUE_BSTR(pbstrStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_responseXMLValidValues
	{
		/*[out,retval]*/ IDispatch** ppBody;
		HRESULT retValue;
	};

	STDMETHOD(get_responseXML)(
		/*[out,retval]*/ IDispatch** ppBody)
	{
		VSL_DEFINE_MOCK_METHOD(get_responseXML)

		VSL_SET_VALIDVALUE_INTERFACE(ppBody);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_responseTextValidValues
	{
		/*[out,retval]*/ BSTR* pbstrBody;
		HRESULT retValue;
	};

	STDMETHOD(get_responseText)(
		/*[out,retval]*/ BSTR* pbstrBody)
	{
		VSL_DEFINE_MOCK_METHOD(get_responseText)

		VSL_SET_VALIDVALUE_BSTR(pbstrBody);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_responseBodyValidValues
	{
		/*[out,retval]*/ VARIANT* pvarBody;
		HRESULT retValue;
	};

	STDMETHOD(get_responseBody)(
		/*[out,retval]*/ VARIANT* pvarBody)
	{
		VSL_DEFINE_MOCK_METHOD(get_responseBody)

		VSL_SET_VALIDVALUE_VARIANT(pvarBody);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_responseStreamValidValues
	{
		/*[out,retval]*/ VARIANT* pvarBody;
		HRESULT retValue;
	};

	STDMETHOD(get_responseStream)(
		/*[out,retval]*/ VARIANT* pvarBody)
	{
		VSL_DEFINE_MOCK_METHOD(get_responseStream)

		VSL_SET_VALIDVALUE_VARIANT(pvarBody);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_readyStateValidValues
	{
		/*[out,retval]*/ long* plState;
		HRESULT retValue;
	};

	STDMETHOD(get_readyState)(
		/*[out,retval]*/ long* plState)
	{
		VSL_DEFINE_MOCK_METHOD(get_readyState)

		VSL_SET_VALIDVALUE(plState);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_onreadystatechangeValidValues
	{
		/*[in]*/ IDispatch* pReadyStateSink;
		HRESULT retValue;
	};

	STDMETHOD(put_onreadystatechange)(
		/*[in]*/ IDispatch* pReadyStateSink)
	{
		VSL_DEFINE_MOCK_METHOD(put_onreadystatechange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReadyStateSink);

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

#endif // IXMLHTTPREQUEST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
