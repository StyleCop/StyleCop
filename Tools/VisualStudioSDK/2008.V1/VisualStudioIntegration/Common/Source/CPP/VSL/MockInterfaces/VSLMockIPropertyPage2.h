/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPropertyPage2NotImpl :
	public IPropertyPage2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPage2NotImpl)

public:

	typedef IPropertyPage2 Interface;

	STDMETHOD(EditProperty)(
		/*[in]*/ DISPID /*dispID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPageSite)(
		/*[in]*/ IPropertyPageSite* /*pPageSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Activate)(
		/*[in]*/ HWND /*hWndParent*/,
		/*[in]*/ LPCRECT /*pRect*/,
		/*[in]*/ BOOL /*bModal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Deactivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPageInfo)(
		/*[out]*/ PROPPAGEINFO* /*pPageInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetObjects)(
		/*[in]*/ ULONG /*cObjects*/,
		/*[in,size_is(cObjects)]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Show)(
		/*[in]*/ UINT /*nCmdShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Move)(
		/*[in]*/ LPCRECT /*pRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsPageDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Apply)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Help)(
		/*[in]*/ LPCOLESTR /*pszHelpDir*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* /*pMsg*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyPage2MockImpl :
	public IPropertyPage2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPage2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyPage2MockImpl)

	typedef IPropertyPage2 Interface;
	struct EditPropertyValidValues
	{
		/*[in]*/ DISPID dispID;
		HRESULT retValue;
	};

	STDMETHOD(EditProperty)(
		/*[in]*/ DISPID dispID)
	{
		VSL_DEFINE_MOCK_METHOD(EditProperty)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPageSiteValidValues
	{
		/*[in]*/ IPropertyPageSite* pPageSite;
		HRESULT retValue;
	};

	STDMETHOD(SetPageSite)(
		/*[in]*/ IPropertyPageSite* pPageSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetPageSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPageSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivateValidValues
	{
		/*[in]*/ HWND hWndParent;
		/*[in]*/ LPCRECT pRect;
		/*[in]*/ BOOL bModal;
		HRESULT retValue;
	};

	STDMETHOD(Activate)(
		/*[in]*/ HWND hWndParent,
		/*[in]*/ LPCRECT pRect,
		/*[in]*/ BOOL bModal)
	{
		VSL_DEFINE_MOCK_METHOD(Activate)

		VSL_CHECK_VALIDVALUE(hWndParent);

		VSL_CHECK_VALIDVALUE(pRect);

		VSL_CHECK_VALIDVALUE(bModal);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeactivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Deactivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Deactivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPageInfoValidValues
	{
		/*[out]*/ PROPPAGEINFO* pPageInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetPageInfo)(
		/*[out]*/ PROPPAGEINFO* pPageInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetPageInfo)

		VSL_SET_VALIDVALUE(pPageInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetObjectsValidValues
	{
		/*[in]*/ ULONG cObjects;
		/*[in,size_is(cObjects)]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(SetObjects)(
		/*[in]*/ ULONG cObjects,
		/*[in,size_is(cObjects)]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(SetObjects)

		VSL_CHECK_VALIDVALUE(cObjects);

		VSL_CHECK_VALIDVALUE_ARRAY(ppUnk, cObjects, validValues.cObjects);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowValidValues
	{
		/*[in]*/ UINT nCmdShow;
		HRESULT retValue;
	};

	STDMETHOD(Show)(
		/*[in]*/ UINT nCmdShow)
	{
		VSL_DEFINE_MOCK_METHOD(Show)

		VSL_CHECK_VALIDVALUE(nCmdShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveValidValues
	{
		/*[in]*/ LPCRECT pRect;
		HRESULT retValue;
	};

	STDMETHOD(Move)(
		/*[in]*/ LPCRECT pRect)
	{
		VSL_DEFINE_MOCK_METHOD(Move)

		VSL_CHECK_VALIDVALUE(pRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsPageDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsPageDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsPageDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Apply)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Apply)

		VSL_RETURN_VALIDVALUES();
	}
	struct HelpValidValues
	{
		/*[in]*/ LPCOLESTR pszHelpDir;
		HRESULT retValue;
	};

	STDMETHOD(Help)(
		/*[in]*/ LPCOLESTR pszHelpDir)
	{
		VSL_DEFINE_MOCK_METHOD(Help)

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpDir);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ MSG* pMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE_POINTER(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYPAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
