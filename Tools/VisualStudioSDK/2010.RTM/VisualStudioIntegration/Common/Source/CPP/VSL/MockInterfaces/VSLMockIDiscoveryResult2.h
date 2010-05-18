/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDISCOVERYRESULT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDISCOVERYRESULT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDiscoveryResult2NotImpl :
	public IDiscoveryResult2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryResult2NotImpl)

public:

	typedef IDiscoveryResult2 Interface;

	STDMETHOD(DownloadServiceDocument)(
		/*[in]*/ BSTR /*bstrDestinationPath*/,
		/*[in]*/ BSTR /*bstrDiscomapFileName*/,
		/*[out,retval]*/ IDiscoveryClientResultCollection** /*ppIDiscoveryClientResultCollection*/)VSL_STDMETHOD_NOTIMPL
};

class IDiscoveryResult2MockImpl :
	public IDiscoveryResult2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryResult2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDiscoveryResult2MockImpl)

	typedef IDiscoveryResult2 Interface;
	struct DownloadServiceDocumentValidValues
	{
		/*[in]*/ BSTR bstrDestinationPath;
		/*[in]*/ BSTR bstrDiscomapFileName;
		/*[out,retval]*/ IDiscoveryClientResultCollection** ppIDiscoveryClientResultCollection;
		HRESULT retValue;
	};

	STDMETHOD(DownloadServiceDocument)(
		/*[in]*/ BSTR bstrDestinationPath,
		/*[in]*/ BSTR bstrDiscomapFileName,
		/*[out,retval]*/ IDiscoveryClientResultCollection** ppIDiscoveryClientResultCollection)
	{
		VSL_DEFINE_MOCK_METHOD(DownloadServiceDocument)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestinationPath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDiscomapFileName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIDiscoveryClientResultCollection);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDISCOVERYRESULT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
