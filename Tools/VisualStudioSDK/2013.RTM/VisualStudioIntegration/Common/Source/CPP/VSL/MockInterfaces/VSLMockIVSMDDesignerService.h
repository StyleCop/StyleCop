/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDDESIGNERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDDESIGNERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVSMDDesignerServiceNotImpl :
	public IVSMDDesignerService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerServiceNotImpl)

public:

	typedef IVSMDDesignerService Interface;

	STDMETHOD(get_DesignViewAttribute)(
		/*[out,retval]*/ BSTR* /*pbstrAttribute*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateDesigner)(
		/*[in]*/ IServiceProvider* /*pSp*/,
		/*[in]*/ IUnknown* /*pDesignerLoader*/,
		/*[out,retval]*/ IVSMDDesigner** /*ppDesigner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateDesignerForClass)(
		/*[in]*/ IServiceProvider* /*pSp*/,
		/*[in]*/ LPCOLESTR /*pwszComponentClass*/,
		/*[out,retval]*/ IVSMDDesigner** /*ppDesigner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateDesignerLoader)(
		/*[in]*/ LPCOLESTR /*pwszCodeStreamClass*/,
		/*[out,retval]*/ IUnknown** /*ppCodeStream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDesignerLoaderClassForFile)(
		/*[in]*/ LPCOLESTR /*pwszFileName*/,
		/*[out,retval]*/ BSTR* /*pbstrDesignerLoaderClass*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterDesignViewAttribute)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ int /*dwClass*/,
		/*[in]*/ LPOLESTR /*pwszAttributeValue*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDDesignerServiceMockImpl :
	public IVSMDDesignerService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDDesignerServiceMockImpl)

	typedef IVSMDDesignerService Interface;
	struct get_DesignViewAttributeValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAttribute;
		HRESULT retValue;
	};

	STDMETHOD(get_DesignViewAttribute)(
		/*[out,retval]*/ BSTR* pbstrAttribute)
	{
		VSL_DEFINE_MOCK_METHOD(get_DesignViewAttribute)

		VSL_SET_VALIDVALUE_BSTR(pbstrAttribute);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateDesignerValidValues
	{
		/*[in]*/ IServiceProvider* pSp;
		/*[in]*/ IUnknown* pDesignerLoader;
		/*[out,retval]*/ IVSMDDesigner** ppDesigner;
		HRESULT retValue;
	};

	STDMETHOD(CreateDesigner)(
		/*[in]*/ IServiceProvider* pSp,
		/*[in]*/ IUnknown* pDesignerLoader,
		/*[out,retval]*/ IVSMDDesigner** ppDesigner)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDesigner)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSp);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDesignerLoader);

		VSL_SET_VALIDVALUE_INTERFACE(ppDesigner);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateDesignerForClassValidValues
	{
		/*[in]*/ IServiceProvider* pSp;
		/*[in]*/ LPCOLESTR pwszComponentClass;
		/*[out,retval]*/ IVSMDDesigner** ppDesigner;
		HRESULT retValue;
	};

	STDMETHOD(CreateDesignerForClass)(
		/*[in]*/ IServiceProvider* pSp,
		/*[in]*/ LPCOLESTR pwszComponentClass,
		/*[out,retval]*/ IVSMDDesigner** ppDesigner)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDesignerForClass)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSp);

		VSL_CHECK_VALIDVALUE_STRINGW(pwszComponentClass);

		VSL_SET_VALIDVALUE_INTERFACE(ppDesigner);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateDesignerLoaderValidValues
	{
		/*[in]*/ LPCOLESTR pwszCodeStreamClass;
		/*[out,retval]*/ IUnknown** ppCodeStream;
		HRESULT retValue;
	};

	STDMETHOD(CreateDesignerLoader)(
		/*[in]*/ LPCOLESTR pwszCodeStreamClass,
		/*[out,retval]*/ IUnknown** ppCodeStream)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDesignerLoader)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszCodeStreamClass);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeStream);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDesignerLoaderClassForFileValidValues
	{
		/*[in]*/ LPCOLESTR pwszFileName;
		/*[out,retval]*/ BSTR* pbstrDesignerLoaderClass;
		HRESULT retValue;
	};

	STDMETHOD(GetDesignerLoaderClassForFile)(
		/*[in]*/ LPCOLESTR pwszFileName,
		/*[out,retval]*/ BSTR* pbstrDesignerLoaderClass)
	{
		VSL_DEFINE_MOCK_METHOD(GetDesignerLoaderClassForFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszFileName);

		VSL_SET_VALIDVALUE_BSTR(pbstrDesignerLoaderClass);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterDesignViewAttributeValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ int dwClass;
		/*[in]*/ LPOLESTR pwszAttributeValue;
		HRESULT retValue;
	};

	STDMETHOD(RegisterDesignViewAttribute)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ int dwClass,
		/*[in]*/ LPOLESTR pwszAttributeValue)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterDesignViewAttribute)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(dwClass);

		VSL_CHECK_VALIDVALUE_STRINGW(pwszAttributeValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDDESIGNERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
