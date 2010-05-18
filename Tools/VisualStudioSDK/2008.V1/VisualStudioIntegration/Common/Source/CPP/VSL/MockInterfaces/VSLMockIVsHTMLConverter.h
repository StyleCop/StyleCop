/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHTMLCONVERTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHTMLCONVERTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHTMLConverterNotImpl :
	public IVsHTMLConverter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHTMLConverterNotImpl)

public:

	typedef IVsHTMLConverter Interface;

	STDMETHOD(get_DefaultURLEncodingCodePage)(
		/*[out]*/ UINT* /*pulCodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConvertToEntities)(
		/*[in]*/ LPCOLESTR /*szToConvert*/,
		/*[in]*/ ULONG /*cchBuffSize*/,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR[] /*szBuffer*/,
		/*[out]*/ ULONG* /*pcchBuffSizeActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConvertFromEntities)(
		/*[in]*/ LPCOLESTR /*szToConvert*/,
		/*[in]*/ ULONG /*cchBuffSize*/,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR[] /*szBuffer*/,
		/*[out]*/ ULONG* /*pcchBuffSizeActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConvertToURLEncoding)(
		/*[in]*/ UINT /*uCodePage*/,
		/*[in]*/ LPCOLESTR /*szToConvert*/,
		/*[in]*/ ULONG /*cchBuffSize*/,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR[] /*szBuffer*/,
		/*[out]*/ ULONG* /*pcchBuffSizeActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConvertFromURLEncoding)(
		/*[in]*/ UINT /*uCodePage*/,
		/*[in]*/ LPCOLESTR /*szToConvert*/,
		/*[in]*/ ULONG /*cchBuffSize*/,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR[] /*szBuffer*/,
		/*[out]*/ ULONG* /*pcchBuffSizeActual*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHTMLConverterMockImpl :
	public IVsHTMLConverter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHTMLConverterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHTMLConverterMockImpl)

	typedef IVsHTMLConverter Interface;
	struct get_DefaultURLEncodingCodePageValidValues
	{
		/*[out]*/ UINT* pulCodePage;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultURLEncodingCodePage)(
		/*[out]*/ UINT* pulCodePage)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultURLEncodingCodePage)

		VSL_SET_VALIDVALUE(pulCodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConvertToEntitiesValidValues
	{
		/*[in]*/ LPCOLESTR szToConvert;
		/*[in]*/ ULONG cchBuffSize;
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR* szBuffer;
		/*[out]*/ ULONG* pcchBuffSizeActual;
		HRESULT retValue;
	};

	STDMETHOD(ConvertToEntities)(
		/*[in]*/ LPCOLESTR szToConvert,
		/*[in]*/ ULONG cchBuffSize,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR szBuffer[],
		/*[out]*/ ULONG* pcchBuffSizeActual)
	{
		VSL_DEFINE_MOCK_METHOD(ConvertToEntities)

		VSL_CHECK_VALIDVALUE_STRINGW(szToConvert);

		VSL_CHECK_VALIDVALUE(cchBuffSize);

		VSL_SET_VALIDVALUE_STRINGW(szBuffer, cchBuffSize);

		VSL_SET_VALIDVALUE(pcchBuffSizeActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConvertFromEntitiesValidValues
	{
		/*[in]*/ LPCOLESTR szToConvert;
		/*[in]*/ ULONG cchBuffSize;
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR* szBuffer;
		/*[out]*/ ULONG* pcchBuffSizeActual;
		HRESULT retValue;
	};

	STDMETHOD(ConvertFromEntities)(
		/*[in]*/ LPCOLESTR szToConvert,
		/*[in]*/ ULONG cchBuffSize,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR szBuffer[],
		/*[out]*/ ULONG* pcchBuffSizeActual)
	{
		VSL_DEFINE_MOCK_METHOD(ConvertFromEntities)

		VSL_CHECK_VALIDVALUE_STRINGW(szToConvert);

		VSL_CHECK_VALIDVALUE(cchBuffSize);

		VSL_SET_VALIDVALUE_STRINGW(szBuffer, cchBuffSize);

		VSL_SET_VALIDVALUE(pcchBuffSizeActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConvertToURLEncodingValidValues
	{
		/*[in]*/ UINT uCodePage;
		/*[in]*/ LPCOLESTR szToConvert;
		/*[in]*/ ULONG cchBuffSize;
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR* szBuffer;
		/*[out]*/ ULONG* pcchBuffSizeActual;
		HRESULT retValue;
	};

	STDMETHOD(ConvertToURLEncoding)(
		/*[in]*/ UINT uCodePage,
		/*[in]*/ LPCOLESTR szToConvert,
		/*[in]*/ ULONG cchBuffSize,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR szBuffer[],
		/*[out]*/ ULONG* pcchBuffSizeActual)
	{
		VSL_DEFINE_MOCK_METHOD(ConvertToURLEncoding)

		VSL_CHECK_VALIDVALUE(uCodePage);

		VSL_CHECK_VALIDVALUE_STRINGW(szToConvert);

		VSL_CHECK_VALIDVALUE(cchBuffSize);

		VSL_SET_VALIDVALUE_STRINGW(szBuffer, cchBuffSize);

		VSL_SET_VALIDVALUE(pcchBuffSizeActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConvertFromURLEncodingValidValues
	{
		/*[in]*/ UINT uCodePage;
		/*[in]*/ LPCOLESTR szToConvert;
		/*[in]*/ ULONG cchBuffSize;
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR* szBuffer;
		/*[out]*/ ULONG* pcchBuffSizeActual;
		HRESULT retValue;
	};

	STDMETHOD(ConvertFromURLEncoding)(
		/*[in]*/ UINT uCodePage,
		/*[in]*/ LPCOLESTR szToConvert,
		/*[in]*/ ULONG cchBuffSize,
		/*[in,out,size_is(cchBuffSize)]*/ OLECHAR szBuffer[],
		/*[out]*/ ULONG* pcchBuffSizeActual)
	{
		VSL_DEFINE_MOCK_METHOD(ConvertFromURLEncoding)

		VSL_CHECK_VALIDVALUE(uCodePage);

		VSL_CHECK_VALIDVALUE_STRINGW(szToConvert);

		VSL_CHECK_VALIDVALUE(cchBuffSize);

		VSL_SET_VALIDVALUE_STRINGW(szBuffer, cchBuffSize);

		VSL_SET_VALIDVALUE(pcchBuffSizeActual);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHTMLCONVERTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
