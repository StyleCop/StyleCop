/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef BUILDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define BUILDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class BuildManagerNotImpl :
	public BuildManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(BuildManagerNotImpl)

public:

	typedef BuildManager Interface;

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** /*ppDTE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Parent)(
		/*[out,retval]*/ IDispatch** /*ppdispParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ContainingProject)(
		/*[out,retval]*/ Project** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DesignTimeOutputMonikers)(
		/*[out,retval]*/ VARIANT* /*pvarMonikers*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BuildDesignTimeOutput)(
		/*[in]*/ BSTR /*bstrOutputMoniker*/,
		/*[out,retval]*/ BSTR* /*pbstrXMLFormat*/)VSL_STDMETHOD_NOTIMPL

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

class BuildManagerMockImpl :
	public BuildManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(BuildManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(BuildManagerMockImpl)

	typedef BuildManager Interface;
	struct get_DTEValidValues
	{
		/*[out,retval]*/ DTE** ppDTE;
		HRESULT retValue;
	};

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** ppDTE)
	{
		VSL_DEFINE_MOCK_METHOD(get_DTE)

		VSL_SET_VALIDVALUE(ppDTE);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ParentValidValues
	{
		/*[out,retval]*/ IDispatch** ppdispParent;
		HRESULT retValue;
	};

	STDMETHOD(get_Parent)(
		/*[out,retval]*/ IDispatch** ppdispParent)
	{
		VSL_DEFINE_MOCK_METHOD(get_Parent)

		VSL_SET_VALIDVALUE_INTERFACE(ppdispParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ContainingProjectValidValues
	{
		/*[out,retval]*/ Project** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(get_ContainingProject)(
		/*[out,retval]*/ Project** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(get_ContainingProject)

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DesignTimeOutputMonikersValidValues
	{
		/*[out,retval]*/ VARIANT* pvarMonikers;
		HRESULT retValue;
	};

	STDMETHOD(get_DesignTimeOutputMonikers)(
		/*[out,retval]*/ VARIANT* pvarMonikers)
	{
		VSL_DEFINE_MOCK_METHOD(get_DesignTimeOutputMonikers)

		VSL_SET_VALIDVALUE_VARIANT(pvarMonikers);

		VSL_RETURN_VALIDVALUES();
	}
	struct BuildDesignTimeOutputValidValues
	{
		/*[in]*/ BSTR bstrOutputMoniker;
		/*[out,retval]*/ BSTR* pbstrXMLFormat;
		HRESULT retValue;
	};

	STDMETHOD(BuildDesignTimeOutput)(
		/*[in]*/ BSTR bstrOutputMoniker,
		/*[out,retval]*/ BSTR* pbstrXMLFormat)
	{
		VSL_DEFINE_MOCK_METHOD(BuildDesignTimeOutput)

		VSL_CHECK_VALIDVALUE_BSTR(bstrOutputMoniker);

		VSL_SET_VALIDVALUE_BSTR(pbstrXMLFormat);

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

#endif // BUILDMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
