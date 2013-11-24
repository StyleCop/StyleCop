/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOXDATAPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOXDATAPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolboxDataProviderNotImpl :
	public IVsToolboxDataProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProviderNotImpl)

public:

	typedef IVsToolboxDataProvider Interface;

	STDMETHOD(FileDropped)(
		/*[in]*/ LPCOLESTR /*pszFileName*/,
		/*[in]*/ IVsHierarchy* /*pHierSource*/,
		/*[out,retval]*/ BOOL* /*pfFileProcessed*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsSupported)(
		/*[in]*/ IDataObject* /*pDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDataSupported)(
		/*[in]*/ FORMATETC* /*pfetc*/,
		/*[in]*/ STGMEDIUM* /*pstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemInfo)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ PTBXITEMINFO /*ptif*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxDataProviderMockImpl :
	public IVsToolboxDataProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxDataProviderMockImpl)

	typedef IVsToolboxDataProvider Interface;
	struct FileDroppedValidValues
	{
		/*[in]*/ LPCOLESTR pszFileName;
		/*[in]*/ IVsHierarchy* pHierSource;
		/*[out,retval]*/ BOOL* pfFileProcessed;
		HRESULT retValue;
	};

	STDMETHOD(FileDropped)(
		/*[in]*/ LPCOLESTR pszFileName,
		/*[in]*/ IVsHierarchy* pHierSource,
		/*[out,retval]*/ BOOL* pfFileProcessed)
	{
		VSL_DEFINE_MOCK_METHOD(FileDropped)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierSource);

		VSL_SET_VALIDVALUE(pfFileProcessed);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsSupportedValidValues
	{
		/*[in]*/ IDataObject* pDO;
		HRESULT retValue;
	};

	STDMETHOD(IsSupported)(
		/*[in]*/ IDataObject* pDO)
	{
		VSL_DEFINE_MOCK_METHOD(IsSupported)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDataSupportedValidValues
	{
		/*[in]*/ FORMATETC* pfetc;
		/*[in]*/ STGMEDIUM* pstm;
		HRESULT retValue;
	};

	STDMETHOD(IsDataSupported)(
		/*[in]*/ FORMATETC* pfetc,
		/*[in]*/ STGMEDIUM* pstm)
	{
		VSL_DEFINE_MOCK_METHOD(IsDataSupported)

		VSL_CHECK_VALIDVALUE_POINTER(pfetc);

		VSL_CHECK_VALIDVALUE_POINTER(pstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemInfoValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[out]*/ PTBXITEMINFO ptif;
		HRESULT retValue;
	};

	STDMETHOD(GetItemInfo)(
		/*[in]*/ IDataObject* pDO,
		/*[out]*/ PTBXITEMINFO ptif)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_SET_VALIDVALUE(ptif);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOXDATAPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
