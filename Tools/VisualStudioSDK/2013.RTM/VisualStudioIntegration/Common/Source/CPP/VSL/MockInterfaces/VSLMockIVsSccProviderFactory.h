/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROVIDERFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROVIDERFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProviderFactory.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProviderFactoryNotImpl :
	public IVsSccProviderFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProviderFactoryNotImpl)

public:

	typedef IVsSccProviderFactory Interface;

	STDMETHOD(CreateProvider)(
		/*[in]*/ LPCOLESTR /*lpszProjectServerPath*/,
		/*[in]*/ LPCOLESTR /*lpszProjectLocalPath*/,
		/*[out,retval]*/ IUnknown** /*punkSession*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProviderFactoryMockImpl :
	public IVsSccProviderFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProviderFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProviderFactoryMockImpl)

	typedef IVsSccProviderFactory Interface;
	struct CreateProviderValidValues
	{
		/*[in]*/ LPCOLESTR lpszProjectServerPath;
		/*[in]*/ LPCOLESTR lpszProjectLocalPath;
		/*[out,retval]*/ IUnknown** punkSession;
		HRESULT retValue;
	};

	STDMETHOD(CreateProvider)(
		/*[in]*/ LPCOLESTR lpszProjectServerPath,
		/*[in]*/ LPCOLESTR lpszProjectLocalPath,
		/*[out,retval]*/ IUnknown** punkSession)
	{
		VSL_DEFINE_MOCK_METHOD(CreateProvider)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectServerPath);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszProjectLocalPath);

		VSL_SET_VALIDVALUE_INTERFACE(punkSession);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROVIDERFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
