/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VBPACKAGESETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VBPACKAGESETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class VBPackageSettingsNotImpl :
	public VBPackageSettings
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VBPackageSettingsNotImpl)

public:

	typedef VBPackageSettings Interface;

	STDMETHOD(get_OptionExplicit)(
		/*[out,retval]*/ pkgOptionExplicit* /*pOptionExplicit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionExplicit)(
		/*[in]*/ pkgOptionExplicit /*optionExplicit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OptionCompare)(
		/*[out,retval]*/ pkgCompare* /*pOptionCompare*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionCompare)(
		/*[in]*/ pkgCompare /*optionCompare*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OptionStrict)(
		/*[out,retval]*/ pkgOptionStrict* /*pOptionStrict*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionStrict)(
		/*[in]*/ pkgOptionStrict /*optionStrict*/)VSL_STDMETHOD_NOTIMPL

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

class VBPackageSettingsMockImpl :
	public VBPackageSettings,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VBPackageSettingsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(VBPackageSettingsMockImpl)

	typedef VBPackageSettings Interface;
	struct get_OptionExplicitValidValues
	{
		/*[out,retval]*/ pkgOptionExplicit* pOptionExplicit;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionExplicit)(
		/*[out,retval]*/ pkgOptionExplicit* pOptionExplicit)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionExplicit)

		VSL_SET_VALIDVALUE(pOptionExplicit);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionExplicitValidValues
	{
		/*[in]*/ pkgOptionExplicit optionExplicit;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionExplicit)(
		/*[in]*/ pkgOptionExplicit optionExplicit)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionExplicit)

		VSL_CHECK_VALIDVALUE(optionExplicit);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptionCompareValidValues
	{
		/*[out,retval]*/ pkgCompare* pOptionCompare;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionCompare)(
		/*[out,retval]*/ pkgCompare* pOptionCompare)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionCompare)

		VSL_SET_VALIDVALUE(pOptionCompare);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionCompareValidValues
	{
		/*[in]*/ pkgCompare optionCompare;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionCompare)(
		/*[in]*/ pkgCompare optionCompare)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionCompare)

		VSL_CHECK_VALIDVALUE(optionCompare);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptionStrictValidValues
	{
		/*[out,retval]*/ pkgOptionStrict* pOptionStrict;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionStrict)(
		/*[out,retval]*/ pkgOptionStrict* pOptionStrict)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionStrict)

		VSL_SET_VALIDVALUE(pOptionStrict);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionStrictValidValues
	{
		/*[in]*/ pkgOptionStrict optionStrict;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionStrict)(
		/*[in]*/ pkgOptionStrict optionStrict)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionStrict)

		VSL_CHECK_VALIDVALUE(optionStrict);

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

#endif // VBPACKAGESETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
