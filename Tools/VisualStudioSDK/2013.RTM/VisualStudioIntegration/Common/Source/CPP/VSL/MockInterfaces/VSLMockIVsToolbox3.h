/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOX3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOX3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolbox3NotImpl :
	public IVsToolbox3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolbox3NotImpl)

public:

	typedef IVsToolbox3 Interface;

	STDMETHOD(SetIDOfTab)(
		/*[in]*/ LPCOLESTR /*lpszTabName*/,
		/*[in]*/ LPCOLESTR /*lpszTabID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDOfTab)(
		/*[in]*/ LPCOLESTR /*lpszTabName*/,
		/*[out]*/ BSTR* /*pbstrTabID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTabOfID)(
		/*[in]*/ LPCOLESTR /*lpszTabID*/,
		/*[out]*/ BSTR* /*pbstrTabName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGeneralTabID)(
		/*[out]*/ BSTR* /*pbstrTabID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemID)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ BSTR* /*pbstrID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemDisplayName)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastModifiedTime)(
		/*[out]*/ SYSTEMTIME* /*pst*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolbox3MockImpl :
	public IVsToolbox3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolbox3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolbox3MockImpl)

	typedef IVsToolbox3 Interface;
	struct SetIDOfTabValidValues
	{
		/*[in]*/ LPCOLESTR lpszTabName;
		/*[in]*/ LPCOLESTR lpszTabID;
		HRESULT retValue;
	};

	STDMETHOD(SetIDOfTab)(
		/*[in]*/ LPCOLESTR lpszTabName,
		/*[in]*/ LPCOLESTR lpszTabID)
	{
		VSL_DEFINE_MOCK_METHOD(SetIDOfTab)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTabName);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTabID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDOfTabValidValues
	{
		/*[in]*/ LPCOLESTR lpszTabName;
		/*[out]*/ BSTR* pbstrTabID;
		HRESULT retValue;
	};

	STDMETHOD(GetIDOfTab)(
		/*[in]*/ LPCOLESTR lpszTabName,
		/*[out]*/ BSTR* pbstrTabID)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDOfTab)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTabName);

		VSL_SET_VALIDVALUE_BSTR(pbstrTabID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTabOfIDValidValues
	{
		/*[in]*/ LPCOLESTR lpszTabID;
		/*[out]*/ BSTR* pbstrTabName;
		HRESULT retValue;
	};

	STDMETHOD(GetTabOfID)(
		/*[in]*/ LPCOLESTR lpszTabID,
		/*[out]*/ BSTR* pbstrTabName)
	{
		VSL_DEFINE_MOCK_METHOD(GetTabOfID)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTabID);

		VSL_SET_VALIDVALUE_BSTR(pbstrTabName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGeneralTabIDValidValues
	{
		/*[out]*/ BSTR* pbstrTabID;
		HRESULT retValue;
	};

	STDMETHOD(GetGeneralTabID)(
		/*[out]*/ BSTR* pbstrTabID)
	{
		VSL_DEFINE_MOCK_METHOD(GetGeneralTabID)

		VSL_SET_VALIDVALUE_BSTR(pbstrTabID);

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
	struct GetItemDisplayNameValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetItemDisplayName)(
		/*[in]*/ IDataObject* pDO,
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemDisplayName)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastModifiedTimeValidValues
	{
		/*[out]*/ SYSTEMTIME* pst;
		HRESULT retValue;
	};

	STDMETHOD(GetLastModifiedTime)(
		/*[out]*/ SYSTEMTIME* pst)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastModifiedTime)

		VSL_SET_VALIDVALUE(pst);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOX3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
