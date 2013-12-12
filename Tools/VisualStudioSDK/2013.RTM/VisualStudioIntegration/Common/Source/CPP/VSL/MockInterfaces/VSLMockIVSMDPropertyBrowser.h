/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsmanaged.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVSMDPropertyBrowserNotImpl :
	public IVSMDPropertyBrowser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDPropertyBrowserNotImpl)

public:

	typedef IVSMDPropertyBrowser Interface;

	STDMETHOD(get_WindowGlyphResourceID)(
		/*[out,retval]*/ DWORD* /*pdwResID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreatePropertyGrid)(
		/*[out,retval]*/ IVSMDPropertyGrid** /*ppGrid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Refresh)()VSL_STDMETHOD_NOTIMPL
};

class IVSMDPropertyBrowserMockImpl :
	public IVSMDPropertyBrowser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDPropertyBrowserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDPropertyBrowserMockImpl)

	typedef IVSMDPropertyBrowser Interface;
	struct get_WindowGlyphResourceIDValidValues
	{
		/*[out,retval]*/ DWORD* pdwResID;
		HRESULT retValue;
	};

	STDMETHOD(get_WindowGlyphResourceID)(
		/*[out,retval]*/ DWORD* pdwResID)
	{
		VSL_DEFINE_MOCK_METHOD(get_WindowGlyphResourceID)

		VSL_SET_VALIDVALUE(pdwResID);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreatePropertyGridValidValues
	{
		/*[out,retval]*/ IVSMDPropertyGrid** ppGrid;
		HRESULT retValue;
	};

	STDMETHOD(CreatePropertyGrid)(
		/*[out,retval]*/ IVSMDPropertyGrid** ppGrid)
	{
		VSL_DEFINE_MOCK_METHOD(CreatePropertyGrid)

		VSL_SET_VALIDVALUE_INTERFACE(ppGrid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Refresh)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Refresh)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
