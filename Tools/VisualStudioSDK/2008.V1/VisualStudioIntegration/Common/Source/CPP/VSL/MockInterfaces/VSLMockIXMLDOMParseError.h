/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IXMLDOMPARSEERROR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IXMLDOMPARSEERROR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IXMLDOMParseErrorNotImpl :
	public IXMLDOMParseError
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMParseErrorNotImpl)

public:

	typedef IXMLDOMParseError Interface;

	STDMETHOD(get_errorCode)(
		/*[retval,out]*/ long* /*errorCode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_url)(
		/*[retval,out]*/ BSTR* /*urlString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_reason)(
		/*[retval,out]*/ BSTR* /*reasonString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_srcText)(
		/*[retval,out]*/ BSTR* /*sourceString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_line)(
		/*[retval,out]*/ long* /*lineNumber*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_linepos)(
		/*[retval,out]*/ long* /*linePosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_filepos)(
		/*[retval,out]*/ long* /*filePosition*/)VSL_STDMETHOD_NOTIMPL

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

class IXMLDOMParseErrorMockImpl :
	public IXMLDOMParseError,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IXMLDOMParseErrorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IXMLDOMParseErrorMockImpl)

	typedef IXMLDOMParseError Interface;
	struct get_errorCodeValidValues
	{
		/*[retval,out]*/ long* errorCode;
		HRESULT retValue;
	};

	STDMETHOD(get_errorCode)(
		/*[retval,out]*/ long* errorCode)
	{
		VSL_DEFINE_MOCK_METHOD(get_errorCode)

		VSL_SET_VALIDVALUE(errorCode);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_urlValidValues
	{
		/*[retval,out]*/ BSTR* urlString;
		HRESULT retValue;
	};

	STDMETHOD(get_url)(
		/*[retval,out]*/ BSTR* urlString)
	{
		VSL_DEFINE_MOCK_METHOD(get_url)

		VSL_SET_VALIDVALUE_BSTR(urlString);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_reasonValidValues
	{
		/*[retval,out]*/ BSTR* reasonString;
		HRESULT retValue;
	};

	STDMETHOD(get_reason)(
		/*[retval,out]*/ BSTR* reasonString)
	{
		VSL_DEFINE_MOCK_METHOD(get_reason)

		VSL_SET_VALIDVALUE_BSTR(reasonString);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_srcTextValidValues
	{
		/*[retval,out]*/ BSTR* sourceString;
		HRESULT retValue;
	};

	STDMETHOD(get_srcText)(
		/*[retval,out]*/ BSTR* sourceString)
	{
		VSL_DEFINE_MOCK_METHOD(get_srcText)

		VSL_SET_VALIDVALUE_BSTR(sourceString);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_lineValidValues
	{
		/*[retval,out]*/ long* lineNumber;
		HRESULT retValue;
	};

	STDMETHOD(get_line)(
		/*[retval,out]*/ long* lineNumber)
	{
		VSL_DEFINE_MOCK_METHOD(get_line)

		VSL_SET_VALIDVALUE(lineNumber);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_lineposValidValues
	{
		/*[retval,out]*/ long* linePosition;
		HRESULT retValue;
	};

	STDMETHOD(get_linepos)(
		/*[retval,out]*/ long* linePosition)
	{
		VSL_DEFINE_MOCK_METHOD(get_linepos)

		VSL_SET_VALIDVALUE(linePosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_fileposValidValues
	{
		/*[retval,out]*/ long* filePosition;
		HRESULT retValue;
	};

	STDMETHOD(get_filepos)(
		/*[retval,out]*/ long* filePosition)
	{
		VSL_DEFINE_MOCK_METHOD(get_filepos)

		VSL_SET_VALIDVALUE(filePosition);

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

#endif // IXMLDOMPARSEERROR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
