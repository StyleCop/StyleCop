/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPackageNotImpl :
	public IVsPackage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageNotImpl)

public:

	typedef IVsPackage Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryClose)(
		/*[out]*/ BOOL* /*pfCanClose*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAutomationObject)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[out]*/ IDispatch** /*ppDisp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateTool)(
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetDefaults)(
		/*[in]*/ VSPKGRESETFLAGS /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPropertyPage)(
		/*[in]*/ REFGUID /*rguidPage*/,
		/*[in,out]*/ VSPROPSHEETPAGE* /*ppage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPackageMockImpl :
	public IVsPackage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPackageMockImpl)

	typedef IVsPackage Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCloseValidValues
	{
		/*[out]*/ BOOL* pfCanClose;
		HRESULT retValue;
	};

	STDMETHOD(QueryClose)(
		/*[out]*/ BOOL* pfCanClose)
	{
		VSL_DEFINE_MOCK_METHOD(QueryClose)

		VSL_SET_VALIDVALUE(pfCanClose);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAutomationObjectValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[out]*/ IDispatch** ppDisp;
		HRESULT retValue;
	};

	STDMETHOD(GetAutomationObject)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[out]*/ IDispatch** ppDisp)
	{
		VSL_DEFINE_MOCK_METHOD(GetAutomationObject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_SET_VALIDVALUE_INTERFACE(ppDisp);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateToolValidValues
	{
		/*[in]*/ REFGUID rguidPersistenceSlot;
		HRESULT retValue;
	};

	STDMETHOD(CreateTool)(
		/*[in]*/ REFGUID rguidPersistenceSlot)
	{
		VSL_DEFINE_MOCK_METHOD(CreateTool)

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetDefaultsValidValues
	{
		/*[in]*/ VSPKGRESETFLAGS grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(ResetDefaults)(
		/*[in]*/ VSPKGRESETFLAGS grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(ResetDefaults)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyPageValidValues
	{
		/*[in]*/ REFGUID rguidPage;
		/*[in,out]*/ VSPROPSHEETPAGE* ppage;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyPage)(
		/*[in]*/ REFGUID rguidPage,
		/*[in,out]*/ VSPROPSHEETPAGE* ppage)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyPage)

		VSL_CHECK_VALIDVALUE(rguidPage);

		VSL_SET_VALIDVALUE(ppage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPACKAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
