/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDISCOVERYRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDISCOVERYRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DiscoveryService.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDiscoveryResultNotImpl :
	public IDiscoveryResult
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryResultNotImpl)

public:

	typedef IDiscoveryResult Interface;

	STDMETHOD(GetRawXml)(
		/*[out,retval]*/ BSTR* /*pbstrXml*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentXml)(
		/*[in]*/ BSTR /*url*/,
		/*[out,retval]*/ BSTR* /*pbstrXml*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReferenceCount)(
		/*[out,retval]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ int /*pIndex*/,
		/*[out,retval]*/ IReferenceInfo** /*ppIReferenceInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDiscoverySession)(
		/*[out,retval]*/ IDiscoverySession** /*discoverySession*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUrl)(
		/*[out,retval]*/ BSTR* /*pbstrUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddWebReference)(
		/*[in]*/ IUnknown* /*punkWebReferenceFolder*/,
		/*[in]*/ BSTR /*bstrDestinationPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddWebReferenceTo)(
		/*[in]*/ IUnknown* /*punkWebReferenceFolder*/,
		/*[in]*/ BSTR /*bstrDestinationPath*/,
		/*[in]*/ BSTR /*bstrDiscomapFilename*/)VSL_STDMETHOD_NOTIMPL
};

class IDiscoveryResultMockImpl :
	public IDiscoveryResult,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryResultMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDiscoveryResultMockImpl)

	typedef IDiscoveryResult Interface;
	struct GetRawXmlValidValues
	{
		/*[out,retval]*/ BSTR* pbstrXml;
		HRESULT retValue;
	};

	STDMETHOD(GetRawXml)(
		/*[out,retval]*/ BSTR* pbstrXml)
	{
		VSL_DEFINE_MOCK_METHOD(GetRawXml)

		VSL_SET_VALIDVALUE_BSTR(pbstrXml);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentXmlValidValues
	{
		/*[in]*/ BSTR url;
		/*[out,retval]*/ BSTR* pbstrXml;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentXml)(
		/*[in]*/ BSTR url,
		/*[out,retval]*/ BSTR* pbstrXml)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentXml)

		VSL_CHECK_VALIDVALUE_BSTR(url);

		VSL_SET_VALIDVALUE_BSTR(pbstrXml);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReferenceCountValidValues
	{
		/*[out,retval]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetReferenceCount)(
		/*[out,retval]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetReferenceCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReferenceInfoValidValues
	{
		/*[in]*/ int pIndex;
		/*[out,retval]*/ IReferenceInfo** ppIReferenceInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetReferenceInfo)(
		/*[in]*/ int pIndex,
		/*[out,retval]*/ IReferenceInfo** ppIReferenceInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetReferenceInfo)

		VSL_CHECK_VALIDVALUE(pIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppIReferenceInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDiscoverySessionValidValues
	{
		/*[out,retval]*/ IDiscoverySession** discoverySession;
		HRESULT retValue;
	};

	STDMETHOD(GetDiscoverySession)(
		/*[out,retval]*/ IDiscoverySession** discoverySession)
	{
		VSL_DEFINE_MOCK_METHOD(GetDiscoverySession)

		VSL_SET_VALIDVALUE_INTERFACE(discoverySession);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUrlValidValues
	{
		/*[out,retval]*/ BSTR* pbstrUrl;
		HRESULT retValue;
	};

	STDMETHOD(GetUrl)(
		/*[out,retval]*/ BSTR* pbstrUrl)
	{
		VSL_DEFINE_MOCK_METHOD(GetUrl)

		VSL_SET_VALIDVALUE_BSTR(pbstrUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddWebReferenceValidValues
	{
		/*[in]*/ IUnknown* punkWebReferenceFolder;
		/*[in]*/ BSTR bstrDestinationPath;
		HRESULT retValue;
	};

	STDMETHOD(AddWebReference)(
		/*[in]*/ IUnknown* punkWebReferenceFolder,
		/*[in]*/ BSTR bstrDestinationPath)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkWebReferenceFolder);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestinationPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddWebReferenceToValidValues
	{
		/*[in]*/ IUnknown* punkWebReferenceFolder;
		/*[in]*/ BSTR bstrDestinationPath;
		/*[in]*/ BSTR bstrDiscomapFilename;
		HRESULT retValue;
	};

	STDMETHOD(AddWebReferenceTo)(
		/*[in]*/ IUnknown* punkWebReferenceFolder,
		/*[in]*/ BSTR bstrDestinationPath,
		/*[in]*/ BSTR bstrDiscomapFilename)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebReferenceTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkWebReferenceFolder);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestinationPath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDiscomapFilename);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDISCOVERYRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
