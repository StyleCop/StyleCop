/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYPAGEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYPAGEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPropertyPageFrameNotImpl :
	public IVsPropertyPageFrame
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageFrameNotImpl)

public:

	typedef IVsPropertyPageFrame Interface;

	STDMETHOD(ShowFrame)(
		/*[in]*/ CLSID /*clsidInitialPage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HideFrame)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Update)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanShowPropertyPages)(
		/*[out,retval]*/ BOOL* /*pbCanShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReportError)(
		/*[in]*/ HRESULT /*hrErr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowFrameDISPID)(
		/*[in]*/ DISPID /*dispidToActivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateAfterApply)()VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyPageFrameMockImpl :
	public IVsPropertyPageFrame,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageFrameMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyPageFrameMockImpl)

	typedef IVsPropertyPageFrame Interface;
	struct ShowFrameValidValues
	{
		/*[in]*/ CLSID clsidInitialPage;
		HRESULT retValue;
	};

	STDMETHOD(ShowFrame)(
		/*[in]*/ CLSID clsidInitialPage)
	{
		VSL_DEFINE_MOCK_METHOD(ShowFrame)

		VSL_CHECK_VALIDVALUE(clsidInitialPage);

		VSL_RETURN_VALIDVALUES();
	}
	struct HideFrameValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HideFrame)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HideFrame)

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Update)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Update)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanShowPropertyPagesValidValues
	{
		/*[out,retval]*/ BOOL* pbCanShow;
		HRESULT retValue;
	};

	STDMETHOD(CanShowPropertyPages)(
		/*[out,retval]*/ BOOL* pbCanShow)
	{
		VSL_DEFINE_MOCK_METHOD(CanShowPropertyPages)

		VSL_SET_VALIDVALUE(pbCanShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReportErrorValidValues
	{
		/*[in]*/ HRESULT hrErr;
		HRESULT retValue;
	};

	STDMETHOD(ReportError)(
		/*[in]*/ HRESULT hrErr)
	{
		VSL_DEFINE_MOCK_METHOD(ReportError)

		VSL_CHECK_VALIDVALUE(hrErr);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowFrameDISPIDValidValues
	{
		/*[in]*/ DISPID dispidToActivate;
		HRESULT retValue;
	};

	STDMETHOD(ShowFrameDISPID)(
		/*[in]*/ DISPID dispidToActivate)
	{
		VSL_DEFINE_MOCK_METHOD(ShowFrameDISPID)

		VSL_CHECK_VALIDVALUE(dispidToActivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateAfterApplyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdateAfterApply)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdateAfterApply)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYPAGEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
