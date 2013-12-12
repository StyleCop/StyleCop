/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWindowViewNotImpl :
	public IVsWindowView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowViewNotImpl)

public:

	typedef IVsWindowView Interface;

	STDMETHOD(GetProperty)(
		/*[in]*/ VSVPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSVPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSVPROPID /*propid*/,
		/*[out]*/ GUID* /*pguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSVPROPID /*propid*/,
		/*[in]*/ REFGUID /*rguid*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowViewMockImpl :
	public IVsWindowView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowViewMockImpl)

	typedef IVsWindowView Interface;
	struct GetPropertyValidValues
	{
		/*[in]*/ VSVPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSVPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSVPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSVPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGuidPropertyValidValues
	{
		/*[in]*/ VSVPROPID propid;
		/*[out]*/ GUID* pguid;
		HRESULT retValue;
	};

	STDMETHOD(GetGuidProperty)(
		/*[in]*/ VSVPROPID propid,
		/*[out]*/ GUID* pguid)
	{
		VSL_DEFINE_MOCK_METHOD(GetGuidProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE(pguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetGuidPropertyValidValues
	{
		/*[in]*/ VSVPROPID propid;
		/*[in]*/ REFGUID rguid;
		HRESULT retValue;
	};

	STDMETHOD(SetGuidProperty)(
		/*[in]*/ VSVPROPID propid,
		/*[in]*/ REFGUID rguid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGuidProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(rguid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
