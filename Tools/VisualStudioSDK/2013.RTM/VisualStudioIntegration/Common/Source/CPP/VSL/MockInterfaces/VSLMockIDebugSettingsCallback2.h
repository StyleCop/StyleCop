/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGSETTINGSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGSETTINGSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugSettingsCallback2NotImpl :
	public IDebugSettingsCallback2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSettingsCallback2NotImpl)

public:

	typedef IDebugSettingsCallback2 Interface;

	STDMETHOD(GetMetricGuid)(
		/*[in]*/ LPCWSTR /*pszType*/,
		/*[in]*/ REFGUID /*guidSection*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ GUID* /*pguidValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMetricDword)(
		/*[in]*/ LPCWSTR /*pszType*/,
		/*[in]*/ REFGUID /*guidSection*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ DWORD* /*pdwValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEEMetricString)(
		/*[in]*/ REFGUID /*guidLang*/,
		/*[in]*/ REFGUID /*guidVendor*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEEMetricGuid)(
		/*[in]*/ REFGUID /*guidLang*/,
		/*[in]*/ REFGUID /*guidVendor*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ GUID* /*pguidValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEEMetricFile)(
		/*[in]*/ REFGUID /*guidLang*/,
		/*[in]*/ REFGUID /*guidVendor*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumEEs)(
		/*[in]*/ DWORD /*celtBuffer*/,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* /*rgguidLang*/,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* /*rgguidVendor*/,
		/*[in,out]*/ DWORD* /*pceltEEs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEEMetricDword)(
		/*[in]*/ REFGUID /*guidLang*/,
		/*[in]*/ REFGUID /*guidVendor*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ DWORD* /*pdwValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEELocalObject)(
		/*[in]*/ REFGUID /*guidLang*/,
		/*[in]*/ REFGUID /*guidVendor*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMetricString)(
		/*[in]*/ LPCWSTR /*pszType*/,
		/*[in]*/ REFGUID /*guidSection*/,
		/*[in]*/ LPCWSTR /*pszMetric*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugSettingsCallback2MockImpl :
	public IDebugSettingsCallback2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSettingsCallback2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugSettingsCallback2MockImpl)

	typedef IDebugSettingsCallback2 Interface;
	struct GetMetricGuidValidValues
	{
		/*[in]*/ LPCWSTR pszType;
		/*[in]*/ REFGUID guidSection;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ GUID* pguidValue;
		HRESULT retValue;
	};

	STDMETHOD(GetMetricGuid)(
		/*[in]*/ LPCWSTR pszType,
		/*[in]*/ REFGUID guidSection,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ GUID* pguidValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetMetricGuid)

		VSL_CHECK_VALIDVALUE_STRINGW(pszType);

		VSL_CHECK_VALIDVALUE(guidSection);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE(pguidValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMetricDwordValidValues
	{
		/*[in]*/ LPCWSTR pszType;
		/*[in]*/ REFGUID guidSection;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ DWORD* pdwValue;
		HRESULT retValue;
	};

	STDMETHOD(GetMetricDword)(
		/*[in]*/ LPCWSTR pszType,
		/*[in]*/ REFGUID guidSection,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ DWORD* pdwValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetMetricDword)

		VSL_CHECK_VALIDVALUE_STRINGW(pszType);

		VSL_CHECK_VALIDVALUE(guidSection);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE(pdwValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEEMetricStringValidValues
	{
		/*[in]*/ REFGUID guidLang;
		/*[in]*/ REFGUID guidVendor;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEEMetricString)(
		/*[in]*/ REFGUID guidLang,
		/*[in]*/ REFGUID guidVendor,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEEMetricString)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(guidVendor);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEEMetricGuidValidValues
	{
		/*[in]*/ REFGUID guidLang;
		/*[in]*/ REFGUID guidVendor;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ GUID* pguidValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEEMetricGuid)(
		/*[in]*/ REFGUID guidLang,
		/*[in]*/ REFGUID guidVendor,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ GUID* pguidValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEEMetricGuid)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(guidVendor);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE(pguidValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEEMetricFileValidValues
	{
		/*[in]*/ REFGUID guidLang;
		/*[in]*/ REFGUID guidVendor;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEEMetricFile)(
		/*[in]*/ REFGUID guidLang,
		/*[in]*/ REFGUID guidVendor,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEEMetricFile)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(guidVendor);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumEEsValidValues
	{
		/*[in]*/ DWORD celtBuffer;
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* rgguidLang;
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* rgguidVendor;
		/*[in,out]*/ DWORD* pceltEEs;
		HRESULT retValue;
	};

	STDMETHOD(EnumEEs)(
		/*[in]*/ DWORD celtBuffer,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* rgguidLang,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEEs)]*/ GUID* rgguidVendor,
		/*[in,out]*/ DWORD* pceltEEs)
	{
		VSL_DEFINE_MOCK_METHOD(EnumEEs)

		VSL_CHECK_VALIDVALUE(celtBuffer);

		VSL_SET_VALIDVALUE_MEMCPY(rgguidLang, celtBuffer*sizeof(rgguidLang[0]), *(validValues.pceltEEs)*sizeof(validValues.rgguidLang[0]));

		VSL_SET_VALIDVALUE_MEMCPY(rgguidVendor, celtBuffer*sizeof(rgguidVendor[0]), *(validValues.pceltEEs)*sizeof(validValues.rgguidVendor[0]));

		VSL_SET_VALIDVALUE(pceltEEs);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEEMetricDwordValidValues
	{
		/*[in]*/ REFGUID guidLang;
		/*[in]*/ REFGUID guidVendor;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ DWORD* pdwValue;
		HRESULT retValue;
	};

	STDMETHOD(GetEEMetricDword)(
		/*[in]*/ REFGUID guidLang,
		/*[in]*/ REFGUID guidVendor,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ DWORD* pdwValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetEEMetricDword)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(guidVendor);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE(pdwValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEELocalObjectValidValues
	{
		/*[in]*/ REFGUID guidLang;
		/*[in]*/ REFGUID guidVendor;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(GetEELocalObject)(
		/*[in]*/ REFGUID guidLang,
		/*[in]*/ REFGUID guidVendor,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(GetEELocalObject)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(guidVendor);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE_INTERFACE(ppUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMetricStringValidValues
	{
		/*[in]*/ LPCWSTR pszType;
		/*[in]*/ REFGUID guidSection;
		/*[in]*/ LPCWSTR pszMetric;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetMetricString)(
		/*[in]*/ LPCWSTR pszType,
		/*[in]*/ REFGUID guidSection,
		/*[in]*/ LPCWSTR pszMetric,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetMetricString)

		VSL_CHECK_VALIDVALUE_STRINGW(pszType);

		VSL_CHECK_VALIDVALUE(guidSection);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGSETTINGSCALLBACK2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
