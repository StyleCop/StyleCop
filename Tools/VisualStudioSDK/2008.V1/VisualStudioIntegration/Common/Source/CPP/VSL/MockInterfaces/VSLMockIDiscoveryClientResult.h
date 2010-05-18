/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDISCOVERYCLIENTRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDISCOVERYCLIENTRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DiscoveryService80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDiscoveryClientResultNotImpl :
	public IDiscoveryClientResult
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryClientResultNotImpl)

public:

	typedef IDiscoveryClientResult Interface;

	STDMETHOD(GetFileName)(
		/*[out,retval]*/ BSTR* /*pbstrFilename*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReferenceTypeName)(
		/*[out,retval]*/ BSTR* /*pbstrReferenceTypeName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUrl)(
		/*[out,retval]*/ BSTR* /*pbstrUrl*/)VSL_STDMETHOD_NOTIMPL
};

class IDiscoveryClientResultMockImpl :
	public IDiscoveryClientResult,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryClientResultMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDiscoveryClientResultMockImpl)

	typedef IDiscoveryClientResult Interface;
	struct GetFileNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFilename;
		HRESULT retValue;
	};

	STDMETHOD(GetFileName)(
		/*[out,retval]*/ BSTR* pbstrFilename)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFilename);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReferenceTypeNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrReferenceTypeName;
		HRESULT retValue;
	};

	STDMETHOD(GetReferenceTypeName)(
		/*[out,retval]*/ BSTR* pbstrReferenceTypeName)
	{
		VSL_DEFINE_MOCK_METHOD(GetReferenceTypeName)

		VSL_SET_VALIDVALUE_BSTR(pbstrReferenceTypeName);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IDISCOVERYCLIENTRESULT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
