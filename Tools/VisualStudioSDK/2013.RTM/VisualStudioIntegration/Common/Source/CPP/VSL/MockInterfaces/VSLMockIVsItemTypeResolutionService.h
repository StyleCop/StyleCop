/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSITEMTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSITEMTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsItemTypeResolutionServiceNotImpl :
	public IVsItemTypeResolutionService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsItemTypeResolutionServiceNotImpl)

public:

	typedef IVsItemTypeResolutionService Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IUnknown* /*punkVsItemTypeResolutionSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeReferences)(
		/*[in]*/ IUnknown* /*punkCompilerParameters*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReferenceAdded)(
		/*[in]*/ BSTR /*pszReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReferenceRemoved)(
		/*[in]*/ BSTR /*pszReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReferenceChanged)(
		/*[in]*/ BSTR /*pszReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL
};

class IVsItemTypeResolutionServiceMockImpl :
	public IVsItemTypeResolutionService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsItemTypeResolutionServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsItemTypeResolutionServiceMockImpl)

	typedef IVsItemTypeResolutionService Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IUnknown* punkVsItemTypeResolutionSite;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IUnknown* punkVsItemTypeResolutionSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkVsItemTypeResolutionSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeReferencesValidValues
	{
		/*[in]*/ IUnknown* punkCompilerParameters;
		HRESULT retValue;
	};

	STDMETHOD(InitializeReferences)(
		/*[in]*/ IUnknown* punkCompilerParameters)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeReferences)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkCompilerParameters);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReferenceAddedValidValues
	{
		/*[in]*/ BSTR pszReference;
		HRESULT retValue;
	};

	STDMETHOD(ReferenceAdded)(
		/*[in]*/ BSTR pszReference)
	{
		VSL_DEFINE_MOCK_METHOD(ReferenceAdded)

		VSL_CHECK_VALIDVALUE_BSTR(pszReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReferenceRemovedValidValues
	{
		/*[in]*/ BSTR pszReference;
		HRESULT retValue;
	};

	STDMETHOD(ReferenceRemoved)(
		/*[in]*/ BSTR pszReference)
	{
		VSL_DEFINE_MOCK_METHOD(ReferenceRemoved)

		VSL_CHECK_VALIDVALUE_BSTR(pszReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReferenceChangedValidValues
	{
		/*[in]*/ BSTR pszReference;
		HRESULT retValue;
	};

	STDMETHOD(ReferenceChanged)(
		/*[in]*/ BSTR pszReference)
	{
		VSL_DEFINE_MOCK_METHOD(ReferenceChanged)

		VSL_CHECK_VALIDVALUE_BSTR(pszReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSITEMTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
