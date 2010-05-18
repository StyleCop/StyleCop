/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef WEBSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define WEBSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class WebSettingsNotImpl :
	public WebSettings
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(WebSettingsNotImpl)

public:

	typedef WebSettings Interface;

	STDMETHOD(get_AuthoringAccess)(
		/*[out,retval]*/ webPrjAuthoringAccess* /*pAccessMethod*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AuthoringAccess)(
		/*[in]*/ webPrjAuthoringAccess /*AccessMethod*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RepairLinks)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbRepairLinks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RepairLinks)(
		/*[in]*/ VARIANT_BOOL /*bRepairLinks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebProjectCacheDirectory)(
		/*[out,retval]*/ BSTR* /*pbstrDirectory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_WebProjectCacheDirectory)(
		/*[in]*/ BSTR /*bstrDirectory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDefaultWebProjectCacheDirectory)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,size_is(cNames)]*/ DISPID* /*rgDispId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID /*dispIdMember*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL
};

class WebSettingsMockImpl :
	public WebSettings,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(WebSettingsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(WebSettingsMockImpl)

	typedef WebSettings Interface;
	struct get_AuthoringAccessValidValues
	{
		/*[out,retval]*/ webPrjAuthoringAccess* pAccessMethod;
		HRESULT retValue;
	};

	STDMETHOD(get_AuthoringAccess)(
		/*[out,retval]*/ webPrjAuthoringAccess* pAccessMethod)
	{
		VSL_DEFINE_MOCK_METHOD(get_AuthoringAccess)

		VSL_SET_VALIDVALUE(pAccessMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AuthoringAccessValidValues
	{
		/*[in]*/ webPrjAuthoringAccess AccessMethod;
		HRESULT retValue;
	};

	STDMETHOD(put_AuthoringAccess)(
		/*[in]*/ webPrjAuthoringAccess AccessMethod)
	{
		VSL_DEFINE_MOCK_METHOD(put_AuthoringAccess)

		VSL_CHECK_VALIDVALUE(AccessMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RepairLinksValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbRepairLinks;
		HRESULT retValue;
	};

	STDMETHOD(get_RepairLinks)(
		/*[out,retval]*/ VARIANT_BOOL* pbRepairLinks)
	{
		VSL_DEFINE_MOCK_METHOD(get_RepairLinks)

		VSL_SET_VALIDVALUE(pbRepairLinks);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RepairLinksValidValues
	{
		/*[in]*/ VARIANT_BOOL bRepairLinks;
		HRESULT retValue;
	};

	STDMETHOD(put_RepairLinks)(
		/*[in]*/ VARIANT_BOOL bRepairLinks)
	{
		VSL_DEFINE_MOCK_METHOD(put_RepairLinks)

		VSL_CHECK_VALIDVALUE(bRepairLinks);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WebProjectCacheDirectoryValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDirectory;
		HRESULT retValue;
	};

	STDMETHOD(get_WebProjectCacheDirectory)(
		/*[out,retval]*/ BSTR* pbstrDirectory)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebProjectCacheDirectory)

		VSL_SET_VALIDVALUE_BSTR(pbstrDirectory);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WebProjectCacheDirectoryValidValues
	{
		/*[in]*/ BSTR bstrDirectory;
		HRESULT retValue;
	};

	STDMETHOD(put_WebProjectCacheDirectory)(
		/*[in]*/ BSTR bstrDirectory)
	{
		VSL_DEFINE_MOCK_METHOD(put_WebProjectCacheDirectory)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDirectory);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDefaultWebProjectCacheDirectoryValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetDefaultWebProjectCacheDirectory)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetDefaultWebProjectCacheDirectory)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoCountValidValues
	{
		/*[out]*/ UINT* pctinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* pctinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoCount)

		VSL_SET_VALIDVALUE(pctinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT iTInfo;
		/*[in]*/ LCID lcid;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT iTInfo,
		/*[in]*/ LCID lcid,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(iTInfo);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[in]*/ LCID lcid;
		/*[out,size_is(cNames)]*/ DISPID* rgDispId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID riid,
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[in]*/ LCID lcid,
		/*[out,size_is(cNames)]*/ DISPID* rgDispId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_MEMCPY(rgDispId, cNames*sizeof(rgDispId[0]), validValues.cNames*sizeof(validValues.rgDispId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ DISPID dispIdMember;
		/*[in]*/ REFIID riid;
		/*[in]*/ LCID lcid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID dispIdMember,
		/*[in]*/ REFIID riid,
		/*[in]*/ LCID lcid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE(dispIdMember);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // WEBSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
