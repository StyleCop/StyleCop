/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTRESOURCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTRESOURCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectResourcesNotImpl :
	public IVsProjectResources
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectResourcesNotImpl)

public:

	typedef IVsProjectResources Interface;

	STDMETHOD(GetResourceItem)(
		/*[in]*/ VSITEMID /*itemidDocument*/,
		/*[in]*/ LPCOLESTR /*pszCulture*/,
		/*[in]*/ VSPROJRESFLAGS /*grfPRF*/,
		/*[out,retval]*/ VSITEMID* /*pitemidResource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateResourceDocData)(
		/*[in]*/ VSITEMID /*itemidResource*/,
		/*[out,retval]*/ IUnknown** /*punkDocData*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectResourcesMockImpl :
	public IVsProjectResources,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectResourcesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectResourcesMockImpl)

	typedef IVsProjectResources Interface;
	struct GetResourceItemValidValues
	{
		/*[in]*/ VSITEMID itemidDocument;
		/*[in]*/ LPCOLESTR pszCulture;
		/*[in]*/ VSPROJRESFLAGS grfPRF;
		/*[out,retval]*/ VSITEMID* pitemidResource;
		HRESULT retValue;
	};

	STDMETHOD(GetResourceItem)(
		/*[in]*/ VSITEMID itemidDocument,
		/*[in]*/ LPCOLESTR pszCulture,
		/*[in]*/ VSPROJRESFLAGS grfPRF,
		/*[out,retval]*/ VSITEMID* pitemidResource)
	{
		VSL_DEFINE_MOCK_METHOD(GetResourceItem)

		VSL_CHECK_VALIDVALUE(itemidDocument);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCulture);

		VSL_CHECK_VALIDVALUE(grfPRF);

		VSL_SET_VALIDVALUE(pitemidResource);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateResourceDocDataValidValues
	{
		/*[in]*/ VSITEMID itemidResource;
		/*[out,retval]*/ IUnknown** punkDocData;
		HRESULT retValue;
	};

	STDMETHOD(CreateResourceDocData)(
		/*[in]*/ VSITEMID itemidResource,
		/*[out,retval]*/ IUnknown** punkDocData)
	{
		VSL_DEFINE_MOCK_METHOD(CreateResourceDocData)

		VSL_CHECK_VALIDVALUE(itemidResource);

		VSL_SET_VALIDVALUE_INTERFACE(punkDocData);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTRESOURCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
