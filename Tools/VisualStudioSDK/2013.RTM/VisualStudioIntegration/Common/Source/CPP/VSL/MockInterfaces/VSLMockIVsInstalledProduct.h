/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINSTALLEDPRODUCT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINSTALLEDPRODUCT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vssplash.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsInstalledProductNotImpl :
	public IVsInstalledProduct
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInstalledProductNotImpl)

public:

	typedef IVsInstalledProduct Interface;

	STDMETHOD(get_IdBmpSplash)(
		/*[out,retval]*/ UINT* /*pIdBmp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OfficialName)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ProductID)(
		/*[out,retval]*/ BSTR* /*pbstrPID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ProductDetails)(
		/*[out,retval]*/ BSTR* /*pbstrProductDetails*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IdIcoLogoForAboutbox)(
		/*[out,retval]*/ UINT* /*pIdIco*/)VSL_STDMETHOD_NOTIMPL
};

class IVsInstalledProductMockImpl :
	public IVsInstalledProduct,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInstalledProductMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsInstalledProductMockImpl)

	typedef IVsInstalledProduct Interface;
	struct get_IdBmpSplashValidValues
	{
		/*[out,retval]*/ UINT* pIdBmp;
		HRESULT retValue;
	};

	STDMETHOD(get_IdBmpSplash)(
		/*[out,retval]*/ UINT* pIdBmp)
	{
		VSL_DEFINE_MOCK_METHOD(get_IdBmpSplash)

		VSL_SET_VALIDVALUE(pIdBmp);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OfficialNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_OfficialName)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_OfficialName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProductIDValidValues
	{
		/*[out,retval]*/ BSTR* pbstrPID;
		HRESULT retValue;
	};

	STDMETHOD(get_ProductID)(
		/*[out,retval]*/ BSTR* pbstrPID)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProductID)

		VSL_SET_VALIDVALUE_BSTR(pbstrPID);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProductDetailsValidValues
	{
		/*[out,retval]*/ BSTR* pbstrProductDetails;
		HRESULT retValue;
	};

	STDMETHOD(get_ProductDetails)(
		/*[out,retval]*/ BSTR* pbstrProductDetails)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProductDetails)

		VSL_SET_VALIDVALUE_BSTR(pbstrProductDetails);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IdIcoLogoForAboutboxValidValues
	{
		/*[out,retval]*/ UINT* pIdIco;
		HRESULT retValue;
	};

	STDMETHOD(get_IdIcoLogoForAboutbox)(
		/*[out,retval]*/ UINT* pIdIco)
	{
		VSL_DEFINE_MOCK_METHOD(get_IdIcoLogoForAboutbox)

		VSL_SET_VALIDVALUE(pIdIco);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINSTALLEDPRODUCT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
