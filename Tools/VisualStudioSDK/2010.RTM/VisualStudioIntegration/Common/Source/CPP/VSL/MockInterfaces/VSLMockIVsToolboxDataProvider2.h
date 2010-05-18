/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOXDATAPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOXDATAPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolboxDataProvider2NotImpl :
	public IVsToolboxDataProvider2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProvider2NotImpl)

public:

	typedef IVsToolboxDataProvider2 Interface;

	STDMETHOD(GetPackageGUID)(
		/*[out]*/ GUID* /*pguidPkg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUniqueID)(
		/*[out]*/ GUID* /*pguidID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemTipInfo)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[in]*/ LPCOLESTR /*lpszCurrentName*/,
		/*[in]*/ IPropertyBag* /*pStrings*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProfileData)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ BSTR* /*pbstrData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemID)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ BSTR* /*pbstrID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReconstituteItem)(
		/*[in]*/ LPCOLESTR /*lpszCurrentName*/,
		/*[in]*/ LPCOLESTR /*lpszID*/,
		/*[in]*/ LPCOLESTR /*lpszData*/,
		/*[out]*/ IDataObject** /*ppDO*/,
		/*[out]*/ TBXITEMINFO* /*ptif*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxDataProvider2MockImpl :
	public IVsToolboxDataProvider2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProvider2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxDataProvider2MockImpl)

	typedef IVsToolboxDataProvider2 Interface;
	struct GetPackageGUIDValidValues
	{
		/*[out]*/ GUID* pguidPkg;
		HRESULT retValue;
	};

	STDMETHOD(GetPackageGUID)(
		/*[out]*/ GUID* pguidPkg)
	{
		VSL_DEFINE_MOCK_METHOD(GetPackageGUID)

		VSL_SET_VALIDVALUE(pguidPkg);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUniqueIDValidValues
	{
		/*[out]*/ GUID* pguidID;
		HRESULT retValue;
	};

	STDMETHOD(GetUniqueID)(
		/*[out]*/ GUID* pguidID)
	{
		VSL_DEFINE_MOCK_METHOD(GetUniqueID)

		VSL_SET_VALIDVALUE(pguidID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemTipInfoValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[in]*/ LPCOLESTR lpszCurrentName;
		/*[in]*/ IPropertyBag* pStrings;
		HRESULT retValue;
	};

	STDMETHOD(GetItemTipInfo)(
		/*[in]*/ IDataObject* pDO,
		/*[in]*/ LPCOLESTR lpszCurrentName,
		/*[in]*/ IPropertyBag* pStrings)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemTipInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszCurrentName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStrings);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProfileDataValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[out]*/ BSTR* pbstrData;
		HRESULT retValue;
	};

	STDMETHOD(GetProfileData)(
		/*[in]*/ IDataObject* pDO,
		/*[out]*/ BSTR* pbstrData)
	{
		VSL_DEFINE_MOCK_METHOD(GetProfileData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_SET_VALIDVALUE_BSTR(pbstrData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemIDValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[out]*/ BSTR* pbstrID;
		HRESULT retValue;
	};

	STDMETHOD(GetItemID)(
		/*[in]*/ IDataObject* pDO,
		/*[out]*/ BSTR* pbstrID)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemID)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_SET_VALIDVALUE_BSTR(pbstrID);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReconstituteItemValidValues
	{
		/*[in]*/ LPCOLESTR lpszCurrentName;
		/*[in]*/ LPCOLESTR lpszID;
		/*[in]*/ LPCOLESTR lpszData;
		/*[out]*/ IDataObject** ppDO;
		/*[out]*/ TBXITEMINFO* ptif;
		HRESULT retValue;
	};

	STDMETHOD(ReconstituteItem)(
		/*[in]*/ LPCOLESTR lpszCurrentName,
		/*[in]*/ LPCOLESTR lpszID,
		/*[in]*/ LPCOLESTR lpszData,
		/*[out]*/ IDataObject** ppDO,
		/*[out]*/ TBXITEMINFO* ptif)
	{
		VSL_DEFINE_MOCK_METHOD(ReconstituteItem)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszCurrentName);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszID);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszData);

		VSL_SET_VALIDVALUE_INTERFACE(ppDO);

		VSL_SET_VALIDVALUE(ptif);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOXDATAPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
