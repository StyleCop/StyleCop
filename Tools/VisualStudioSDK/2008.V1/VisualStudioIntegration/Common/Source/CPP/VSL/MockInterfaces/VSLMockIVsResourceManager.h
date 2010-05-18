/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSRESOURCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSRESOURCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsResourceManagerNotImpl :
	public IVsResourceManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsResourceManagerNotImpl)

public:

	typedef IVsResourceManager Interface;

	STDMETHOD(LoadResourceString)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceBitmap)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[out,retval]*/ HBITMAP* /*hbmpValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceIcon)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/,
		/*[out,retval]*/ HICON* /*hicoValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceBlob)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[out]*/ BYTE** /*pBytes*/,
		/*[out]*/ long* /*lAllocated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceString2)(
		/*[in,string]*/ LPCOLESTR /*pszAssemblyPath*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[out,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceBitmap2)(
		/*[in,string]*/ LPCOLESTR /*pszAssemblyPath*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*szResourceName*/,
		/*[out,retval]*/ HBITMAP* /*hbmpValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceIcon2)(
		/*[in,string]*/ LPCOLESTR /*pszAssemblyPath*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/,
		/*[out,retval]*/ HICON* /*hicoValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadResourceBlob2)(
		/*[in,string]*/ LPCOLESTR /*pszAssemblyPath*/,
		/*[in]*/ int /*culture*/,
		/*[in,string]*/ LPCOLESTR /*pszResourceName*/,
		/*[out]*/ BYTE** /*pBytes*/,
		/*[out]*/ long* /*lAllocated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSatelliteAssemblyPath)(
		/*[in,string]*/ LPCOLESTR /*assemblyPath*/,
		/*[in]*/ int /*lcid*/,
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL
};

class IVsResourceManagerMockImpl :
	public IVsResourceManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsResourceManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsResourceManagerMockImpl)

	typedef IVsResourceManager Interface;
	struct LoadResourceStringValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceString)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceString)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceBitmapValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[out,retval]*/ HBITMAP* hbmpValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceBitmap)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[out,retval]*/ HBITMAP* hbmpValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceBitmap)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_SET_VALIDVALUE(hbmpValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceIconValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		/*[out,retval]*/ HICON* hicoValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceIcon)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[in]*/ int cx,
		/*[in]*/ int cy,
		/*[out,retval]*/ HICON* hicoValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceIcon)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_SET_VALIDVALUE(hicoValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceBlobValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[out]*/ BYTE** pBytes;
		/*[out]*/ long* lAllocated;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceBlob)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[out]*/ BYTE** pBytes,
		/*[out]*/ long* lAllocated)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceBlob)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_SET_VALIDVALUE(pBytes);

		VSL_SET_VALIDVALUE(lAllocated);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceString2ValidValues
	{
		/*[in,string]*/ LPCOLESTR pszAssemblyPath;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[out,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceString2)(
		/*[in,string]*/ LPCOLESTR pszAssemblyPath,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[out,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceString2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAssemblyPath);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceBitmap2ValidValues
	{
		/*[in,string]*/ LPCOLESTR pszAssemblyPath;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR szResourceName;
		/*[out,retval]*/ HBITMAP* hbmpValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceBitmap2)(
		/*[in,string]*/ LPCOLESTR pszAssemblyPath,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR szResourceName,
		/*[out,retval]*/ HBITMAP* hbmpValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceBitmap2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAssemblyPath);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(szResourceName);

		VSL_SET_VALIDVALUE(hbmpValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceIcon2ValidValues
	{
		/*[in,string]*/ LPCOLESTR pszAssemblyPath;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		/*[out,retval]*/ HICON* hicoValue;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceIcon2)(
		/*[in,string]*/ LPCOLESTR pszAssemblyPath,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[in]*/ int cx,
		/*[in]*/ int cy,
		/*[out,retval]*/ HICON* hicoValue)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceIcon2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAssemblyPath);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_SET_VALIDVALUE(hicoValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadResourceBlob2ValidValues
	{
		/*[in,string]*/ LPCOLESTR pszAssemblyPath;
		/*[in]*/ int culture;
		/*[in,string]*/ LPCOLESTR pszResourceName;
		/*[out]*/ BYTE** pBytes;
		/*[out]*/ long* lAllocated;
		HRESULT retValue;
	};

	STDMETHOD(LoadResourceBlob2)(
		/*[in,string]*/ LPCOLESTR pszAssemblyPath,
		/*[in]*/ int culture,
		/*[in,string]*/ LPCOLESTR pszResourceName,
		/*[out]*/ BYTE** pBytes,
		/*[out]*/ long* lAllocated)
	{
		VSL_DEFINE_MOCK_METHOD(LoadResourceBlob2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAssemblyPath);

		VSL_CHECK_VALIDVALUE(culture);

		VSL_CHECK_VALIDVALUE_STRINGW(pszResourceName);

		VSL_SET_VALIDVALUE(pBytes);

		VSL_SET_VALIDVALUE(lAllocated);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSatelliteAssemblyPathValidValues
	{
		/*[in,string]*/ LPCOLESTR assemblyPath;
		/*[in]*/ int lcid;
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetSatelliteAssemblyPath)(
		/*[in,string]*/ LPCOLESTR assemblyPath,
		/*[in]*/ int lcid,
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetSatelliteAssemblyPath)

		VSL_CHECK_VALIDVALUE_STRINGW(assemblyPath);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSRESOURCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
