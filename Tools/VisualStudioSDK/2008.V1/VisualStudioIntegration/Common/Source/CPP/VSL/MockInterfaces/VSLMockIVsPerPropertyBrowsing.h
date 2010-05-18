/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPerPropertyBrowsingNotImpl :
	public IVsPerPropertyBrowsing
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPerPropertyBrowsingNotImpl)

public:

	typedef IVsPerPropertyBrowsing Interface;

	STDMETHOD(HideProperty)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out,retval]*/ BOOL* /*pfHide*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayChildProperties)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out,retval]*/ BOOL* /*pfDisplay*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLocalizedPropertyInfo)(
		/*[in]*/ DISPID /*dispid*/,
		/*[in]*/ LCID /*localeID*/,
		/*[out]*/ BSTR* /*pbstrLocalizedName*/,
		/*[out]*/ BSTR* /*pbstrLocalizeDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HasDefaultValue)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out,retval]*/ BOOL* /*fDefault*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsPropertyReadOnly)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out,retval]*/ BOOL* /*fReadOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassName)(
		/*[out,retval]*/ BSTR* /*pbstrClassName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanResetPropertyValue)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out,retval]*/ BOOL* /*pfCanReset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetPropertyValue)(
		/*[in]*/ DISPID /*dispid*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPerPropertyBrowsingMockImpl :
	public IVsPerPropertyBrowsing,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPerPropertyBrowsingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPerPropertyBrowsingMockImpl)

	typedef IVsPerPropertyBrowsing Interface;
	struct HidePropertyValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out,retval]*/ BOOL* pfHide;
		HRESULT retValue;
	};

	STDMETHOD(HideProperty)(
		/*[in]*/ DISPID dispid,
		/*[out,retval]*/ BOOL* pfHide)
	{
		VSL_DEFINE_MOCK_METHOD(HideProperty)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pfHide);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayChildPropertiesValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out,retval]*/ BOOL* pfDisplay;
		HRESULT retValue;
	};

	STDMETHOD(DisplayChildProperties)(
		/*[in]*/ DISPID dispid,
		/*[out,retval]*/ BOOL* pfDisplay)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayChildProperties)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pfDisplay);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLocalizedPropertyInfoValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[in]*/ LCID localeID;
		/*[out]*/ BSTR* pbstrLocalizedName;
		/*[out]*/ BSTR* pbstrLocalizeDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetLocalizedPropertyInfo)(
		/*[in]*/ DISPID dispid,
		/*[in]*/ LCID localeID,
		/*[out]*/ BSTR* pbstrLocalizedName,
		/*[out]*/ BSTR* pbstrLocalizeDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocalizedPropertyInfo)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_CHECK_VALIDVALUE(localeID);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocalizedName);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocalizeDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct HasDefaultValueValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out,retval]*/ BOOL* fDefault;
		HRESULT retValue;
	};

	STDMETHOD(HasDefaultValue)(
		/*[in]*/ DISPID dispid,
		/*[out,retval]*/ BOOL* fDefault)
	{
		VSL_DEFINE_MOCK_METHOD(HasDefaultValue)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(fDefault);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsPropertyReadOnlyValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out,retval]*/ BOOL* fReadOnly;
		HRESULT retValue;
	};

	STDMETHOD(IsPropertyReadOnly)(
		/*[in]*/ DISPID dispid,
		/*[out,retval]*/ BOOL* fReadOnly)
	{
		VSL_DEFINE_MOCK_METHOD(IsPropertyReadOnly)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(fReadOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrClassName;
		HRESULT retValue;
	};

	STDMETHOD(GetClassName)(
		/*[out,retval]*/ BSTR* pbstrClassName)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassName)

		VSL_SET_VALIDVALUE_BSTR(pbstrClassName);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanResetPropertyValueValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out,retval]*/ BOOL* pfCanReset;
		HRESULT retValue;
	};

	STDMETHOD(CanResetPropertyValue)(
		/*[in]*/ DISPID dispid,
		/*[out,retval]*/ BOOL* pfCanReset)
	{
		VSL_DEFINE_MOCK_METHOD(CanResetPropertyValue)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pfCanReset);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetPropertyValueValidValues
	{
		/*[in]*/ DISPID dispid;
		HRESULT retValue;
	};

	STDMETHOD(ResetPropertyValue)(
		/*[in]*/ DISPID dispid)
	{
		VSL_DEFINE_MOCK_METHOD(ResetPropertyValue)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
