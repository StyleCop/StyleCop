/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFORMATFILTERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFORMATFILTERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFormatFilterProviderNotImpl :
	public IVsFormatFilterProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFormatFilterProviderNotImpl)

public:

	typedef IVsFormatFilterProvider Interface;

	STDMETHOD(GetFormatFilterList)(
		/*[out]*/ BSTR* /*pbstrFilterList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CurFileExtensionFormat)(
		/*[in]*/ BSTR /*bstrFileName*/,
		/*[out]*/ DWORD* /*pdwExtnIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryInvalidEncoding)(
		/*[in]*/ VSTFF /*format*/,
		/*[out]*/ BSTR* /*pbstrMessage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFormatFilterProviderMockImpl :
	public IVsFormatFilterProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFormatFilterProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFormatFilterProviderMockImpl)

	typedef IVsFormatFilterProvider Interface;
	struct GetFormatFilterListValidValues
	{
		/*[out]*/ BSTR* pbstrFilterList;
		HRESULT retValue;
	};

	STDMETHOD(GetFormatFilterList)(
		/*[out]*/ BSTR* pbstrFilterList)
	{
		VSL_DEFINE_MOCK_METHOD(GetFormatFilterList)

		VSL_SET_VALIDVALUE_BSTR(pbstrFilterList);

		VSL_RETURN_VALIDVALUES();
	}
	struct CurFileExtensionFormatValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		/*[out]*/ DWORD* pdwExtnIndex;
		HRESULT retValue;
	};

	STDMETHOD(CurFileExtensionFormat)(
		/*[in]*/ BSTR bstrFileName,
		/*[out]*/ DWORD* pdwExtnIndex)
	{
		VSL_DEFINE_MOCK_METHOD(CurFileExtensionFormat)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_SET_VALIDVALUE(pdwExtnIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryInvalidEncodingValidValues
	{
		/*[in]*/ VSTFF format;
		/*[out]*/ BSTR* pbstrMessage;
		HRESULT retValue;
	};

	STDMETHOD(QueryInvalidEncoding)(
		/*[in]*/ VSTFF format,
		/*[out]*/ BSTR* pbstrMessage)
	{
		VSL_DEFINE_MOCK_METHOD(QueryInvalidEncoding)

		VSL_CHECK_VALIDVALUE(format);

		VSL_SET_VALIDVALUE_BSTR(pbstrMessage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFORMATFILTERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
