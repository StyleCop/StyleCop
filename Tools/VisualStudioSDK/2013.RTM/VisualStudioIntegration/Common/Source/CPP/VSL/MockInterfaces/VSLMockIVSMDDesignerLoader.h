/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDDESIGNERLOADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDDESIGNERLOADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVSMDDesignerLoaderNotImpl :
	public IVSMDDesignerLoader
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerLoaderNotImpl)

public:

	typedef IVSMDDesignerLoader Interface;

	STDMETHOD(Dispose)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEditorCaption)(
		/*[in]*/ READONLYSTATUS /*status*/,
		/*[out,retval]*/ BSTR* /*pbstrCaption*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Initialize)(
		/*[in]*/ IServiceProvider* /*pSp*/,
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*pDocData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBaseEditorCaption)(
		/*[in]*/ LPCOLESTR /*pwszCaption*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDDesignerLoaderMockImpl :
	public IVSMDDesignerLoader,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerLoaderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDDesignerLoaderMockImpl)

	typedef IVSMDDesignerLoader Interface;
	struct DisposeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Dispose)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Dispose)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEditorCaptionValidValues
	{
		/*[in]*/ READONLYSTATUS status;
		/*[out,retval]*/ BSTR* pbstrCaption;
		HRESULT retValue;
	};

	STDMETHOD(GetEditorCaption)(
		/*[in]*/ READONLYSTATUS status,
		/*[out,retval]*/ BSTR* pbstrCaption)
	{
		VSL_DEFINE_MOCK_METHOD(GetEditorCaption)

		VSL_CHECK_VALIDVALUE(status);

		VSL_SET_VALIDVALUE_BSTR(pbstrCaption);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeValidValues
	{
		/*[in]*/ IServiceProvider* pSp;
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* pDocData;
		HRESULT retValue;
	};

	STDMETHOD(Initialize)(
		/*[in]*/ IServiceProvider* pSp,
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* pDocData)
	{
		VSL_DEFINE_MOCK_METHOD(Initialize)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSp);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDocData);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBaseEditorCaptionValidValues
	{
		/*[in]*/ LPCOLESTR pwszCaption;
		HRESULT retValue;
	};

	STDMETHOD(SetBaseEditorCaption)(
		/*[in]*/ LPCOLESTR pwszCaption)
	{
		VSL_DEFINE_MOCK_METHOD(SetBaseEditorCaption)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszCaption);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDDESIGNERLOADER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
