/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSTRUCTUREDFILEIO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSTRUCTUREDFILEIO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsStructuredFileIONotImpl :
	public IVsStructuredFileIO
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStructuredFileIONotImpl)

public:

	typedef IVsStructuredFileIO Interface;

	STDMETHOD(CreateNew)(
		/*[in]*/ LPCOLESTR /*szFileName*/,
		/*[in]*/ ULONG /*nFormatIndex*/,
		/*[in]*/ DWORD /*dwShareMode*/,
		/*[in]*/ DWORD /*dwCreationDisposition*/,
		/*[in]*/ DWORD /*dwFlagsAndAttributes*/,
		/*[in]*/ IVsStructuredFileIOHelper* /*pIVsStructuredFileIOHelper*/,
		/*[in]*/ LPCOLESTR /*szFormatVersion*/,
		/*[in]*/ LPCOLESTR /*szDescription*/,
		/*[out]*/ IVsPropertyFileOut** /*ppIVsPropertyFileOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenExisting)(
		/*[in]*/ LPCOLESTR /*szFileName*/,
		/*[in]*/ DWORD /*dwShareMode*/,
		/*[in]*/ DWORD /*dwCreationDisposition*/,
		/*[in]*/ DWORD /*dwFlagsAndAttributes*/,
		/*[in]*/ IVsStructuredFileIOHelper* /*pIVsStructuredFileIOHelper*/,
		/*[out]*/ ULONG* /*pnFormatIndex*/,
		/*[out]*/ IVsPropertyFileIn** /*ppIVsPropertyFileIn*/,
		/*[out,optional]*/ BSTR* /*pbstrFormatVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFormatList)(
		/*[in]*/ LPCOLESTR /*szEntityName*/,
		/*[in]*/ LPCOLESTR /*szFileTypes*/,
		/*[out]*/ LPOLESTR* /*ppszFormatList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFormatInfo)(
		/*[in]*/ ULONG /*nFormatIndex*/,
		/*[out,optional]*/ UINT* /*puiCodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindFormatIndex)(
		/*[in]*/ UINT /*uiCodePage*/,
		/*[out,optional]*/ ULONG* /*pnFormatIndex*/)VSL_STDMETHOD_NOTIMPL
};

class IVsStructuredFileIOMockImpl :
	public IVsStructuredFileIO,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsStructuredFileIOMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsStructuredFileIOMockImpl)

	typedef IVsStructuredFileIO Interface;
	struct CreateNewValidValues
	{
		/*[in]*/ LPCOLESTR szFileName;
		/*[in]*/ ULONG nFormatIndex;
		/*[in]*/ DWORD dwShareMode;
		/*[in]*/ DWORD dwCreationDisposition;
		/*[in]*/ DWORD dwFlagsAndAttributes;
		/*[in]*/ IVsStructuredFileIOHelper* pIVsStructuredFileIOHelper;
		/*[in]*/ LPCOLESTR szFormatVersion;
		/*[in]*/ LPCOLESTR szDescription;
		/*[out]*/ IVsPropertyFileOut** ppIVsPropertyFileOut;
		HRESULT retValue;
	};

	STDMETHOD(CreateNew)(
		/*[in]*/ LPCOLESTR szFileName,
		/*[in]*/ ULONG nFormatIndex,
		/*[in]*/ DWORD dwShareMode,
		/*[in]*/ DWORD dwCreationDisposition,
		/*[in]*/ DWORD dwFlagsAndAttributes,
		/*[in]*/ IVsStructuredFileIOHelper* pIVsStructuredFileIOHelper,
		/*[in]*/ LPCOLESTR szFormatVersion,
		/*[in]*/ LPCOLESTR szDescription,
		/*[out]*/ IVsPropertyFileOut** ppIVsPropertyFileOut)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNew)

		VSL_CHECK_VALIDVALUE_STRINGW(szFileName);

		VSL_CHECK_VALIDVALUE(nFormatIndex);

		VSL_CHECK_VALIDVALUE(dwShareMode);

		VSL_CHECK_VALIDVALUE(dwCreationDisposition);

		VSL_CHECK_VALIDVALUE(dwFlagsAndAttributes);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsStructuredFileIOHelper);

		VSL_CHECK_VALIDVALUE_STRINGW(szFormatVersion);

		VSL_CHECK_VALIDVALUE_STRINGW(szDescription);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsPropertyFileOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenExistingValidValues
	{
		/*[in]*/ LPCOLESTR szFileName;
		/*[in]*/ DWORD dwShareMode;
		/*[in]*/ DWORD dwCreationDisposition;
		/*[in]*/ DWORD dwFlagsAndAttributes;
		/*[in]*/ IVsStructuredFileIOHelper* pIVsStructuredFileIOHelper;
		/*[out]*/ ULONG* pnFormatIndex;
		/*[out]*/ IVsPropertyFileIn** ppIVsPropertyFileIn;
		/*[out,optional]*/ BSTR* pbstrFormatVersion;
		HRESULT retValue;
	};

	STDMETHOD(OpenExisting)(
		/*[in]*/ LPCOLESTR szFileName,
		/*[in]*/ DWORD dwShareMode,
		/*[in]*/ DWORD dwCreationDisposition,
		/*[in]*/ DWORD dwFlagsAndAttributes,
		/*[in]*/ IVsStructuredFileIOHelper* pIVsStructuredFileIOHelper,
		/*[out]*/ ULONG* pnFormatIndex,
		/*[out]*/ IVsPropertyFileIn** ppIVsPropertyFileIn,
		/*[out,optional]*/ BSTR* pbstrFormatVersion)
	{
		VSL_DEFINE_MOCK_METHOD(OpenExisting)

		VSL_CHECK_VALIDVALUE_STRINGW(szFileName);

		VSL_CHECK_VALIDVALUE(dwShareMode);

		VSL_CHECK_VALIDVALUE(dwCreationDisposition);

		VSL_CHECK_VALIDVALUE(dwFlagsAndAttributes);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsStructuredFileIOHelper);

		VSL_SET_VALIDVALUE(pnFormatIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsPropertyFileIn);

		VSL_SET_VALIDVALUE_BSTR(pbstrFormatVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFormatListValidValues
	{
		/*[in]*/ LPCOLESTR szEntityName;
		/*[in]*/ LPCOLESTR szFileTypes;
		/*[out]*/ LPOLESTR* ppszFormatList;
		HRESULT retValue;
	};

	STDMETHOD(GetFormatList)(
		/*[in]*/ LPCOLESTR szEntityName,
		/*[in]*/ LPCOLESTR szFileTypes,
		/*[out]*/ LPOLESTR* ppszFormatList)
	{
		VSL_DEFINE_MOCK_METHOD(GetFormatList)

		VSL_CHECK_VALIDVALUE_STRINGW(szEntityName);

		VSL_CHECK_VALIDVALUE_STRINGW(szFileTypes);

		VSL_SET_VALIDVALUE(ppszFormatList);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFormatInfoValidValues
	{
		/*[in]*/ ULONG nFormatIndex;
		/*[out,optional]*/ UINT* puiCodePage;
		HRESULT retValue;
	};

	STDMETHOD(GetFormatInfo)(
		/*[in]*/ ULONG nFormatIndex,
		/*[out,optional]*/ UINT* puiCodePage)
	{
		VSL_DEFINE_MOCK_METHOD(GetFormatInfo)

		VSL_CHECK_VALIDVALUE(nFormatIndex);

		VSL_SET_VALIDVALUE(puiCodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindFormatIndexValidValues
	{
		/*[in]*/ UINT uiCodePage;
		/*[out,optional]*/ ULONG* pnFormatIndex;
		HRESULT retValue;
	};

	STDMETHOD(FindFormatIndex)(
		/*[in]*/ UINT uiCodePage,
		/*[out,optional]*/ ULONG* pnFormatIndex)
	{
		VSL_DEFINE_MOCK_METHOD(FindFormatIndex)

		VSL_CHECK_VALIDVALUE(uiCodePage);

		VSL_SET_VALIDVALUE(pnFormatIndex);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSTRUCTUREDFILEIO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
