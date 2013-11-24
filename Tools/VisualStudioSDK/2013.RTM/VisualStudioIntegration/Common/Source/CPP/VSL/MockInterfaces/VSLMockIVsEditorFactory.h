/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEDITORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEDITORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsEditorFactoryNotImpl :
	public IVsEditorFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEditorFactoryNotImpl)

public:

	typedef IVsEditorFactory Interface;

	STDMETHOD(CreateEditorInstance)(
		/*[in]*/ VSCREATEEDITORFLAGS /*grfCreateDoc*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ IVsHierarchy* /*pvHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocDataExisting*/,
		/*[out]*/ IUnknown** /*ppunkDocView*/,
		/*[out]*/ IUnknown** /*ppunkDocData*/,
		/*[out]*/ BSTR* /*pbstrEditorCaption*/,
		/*[out]*/ GUID* /*pguidCmdUI*/,
		/*[out,retval]*/ VSEDITORCREATEDOCWIN* /*pgrfCDW*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapLogicalView)(
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ BSTR* /*pbstrPhysicalView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEditorFactoryMockImpl :
	public IVsEditorFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEditorFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEditorFactoryMockImpl)

	typedef IVsEditorFactory Interface;
	struct CreateEditorInstanceValidValues
	{
		/*[in]*/ VSCREATEEDITORFLAGS grfCreateDoc;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ IVsHierarchy* pvHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocDataExisting;
		/*[out]*/ IUnknown** ppunkDocView;
		/*[out]*/ IUnknown** ppunkDocData;
		/*[out]*/ BSTR* pbstrEditorCaption;
		/*[out]*/ GUID* pguidCmdUI;
		/*[out,retval]*/ VSEDITORCREATEDOCWIN* pgrfCDW;
		HRESULT retValue;
	};

	STDMETHOD(CreateEditorInstance)(
		/*[in]*/ VSCREATEEDITORFLAGS grfCreateDoc,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ IVsHierarchy* pvHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocDataExisting,
		/*[out]*/ IUnknown** ppunkDocView,
		/*[out]*/ IUnknown** ppunkDocData,
		/*[out]*/ BSTR* pbstrEditorCaption,
		/*[out]*/ GUID* pguidCmdUI,
		/*[out,retval]*/ VSEDITORCREATEDOCWIN* pgrfCDW)
	{
		VSL_DEFINE_MOCK_METHOD(CreateEditorInstance)

		VSL_CHECK_VALIDVALUE(grfCreateDoc);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pvHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocDataExisting);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocView);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkDocData);

		VSL_SET_VALIDVALUE_BSTR(pbstrEditorCaption);

		VSL_SET_VALIDVALUE(pguidCmdUI);

		VSL_SET_VALIDVALUE(pgrfCDW);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct MapLogicalViewValidValues
	{
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ BSTR* pbstrPhysicalView;
		HRESULT retValue;
	};

	STDMETHOD(MapLogicalView)(
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ BSTR* pbstrPhysicalView)
	{
		VSL_DEFINE_MOCK_METHOD(MapLogicalView)

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE_BSTR(pbstrPhysicalView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEDITORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
