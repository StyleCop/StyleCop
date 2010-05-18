/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUIHIERWINCLIPBOARDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUIHIERWINCLIPBOARDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIHierWinClipboardHelperNotImpl :
	public IVsUIHierWinClipboardHelper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierWinClipboardHelperNotImpl)

public:

	typedef IVsUIHierWinClipboardHelper Interface;

	STDMETHOD(Cut)(
		/*[in]*/ IDataObject* /*pDataObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Copy)(
		/*[in]*/ IDataObject* /*pDataObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Paste)(
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*dwEffects*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseClipboardHelperEvents)(
		/*[in]*/ IVsUIHierWinClipboardHelperEvents* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseClipboardHelperEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIHierWinClipboardHelperMockImpl :
	public IVsUIHierWinClipboardHelper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierWinClipboardHelperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIHierWinClipboardHelperMockImpl)

	typedef IVsUIHierWinClipboardHelper Interface;
	struct CutValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		HRESULT retValue;
	};

	STDMETHOD(Cut)(
		/*[in]*/ IDataObject* pDataObject)
	{
		VSL_DEFINE_MOCK_METHOD(Cut)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		HRESULT retValue;
	};

	STDMETHOD(Copy)(
		/*[in]*/ IDataObject* pDataObject)
	{
		VSL_DEFINE_MOCK_METHOD(Copy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct PasteValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD dwEffects;
		HRESULT retValue;
	};

	STDMETHOD(Paste)(
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD dwEffects)
	{
		VSL_DEFINE_MOCK_METHOD(Paste)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(dwEffects);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseClipboardHelperEventsValidValues
	{
		/*[in]*/ IVsUIHierWinClipboardHelperEvents* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseClipboardHelperEvents)(
		/*[in]*/ IVsUIHierWinClipboardHelperEvents* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseClipboardHelperEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseClipboardHelperEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseClipboardHelperEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseClipboardHelperEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUIHIERWINCLIPBOARDHELPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
