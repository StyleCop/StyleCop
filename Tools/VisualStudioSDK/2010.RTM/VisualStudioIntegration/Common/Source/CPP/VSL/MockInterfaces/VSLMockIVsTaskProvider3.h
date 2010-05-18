/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKPROVIDER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKPROVIDER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskProvider3NotImpl :
	public IVsTaskProvider3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskProvider3NotImpl)

public:

	typedef IVsTaskProvider3 Interface;

	STDMETHOD(GetProviderFlags)(
		/*[out]*/ VSTASKPROVIDERFLAGS* /*tpfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderGuid)(
		/*[out]*/ GUID* /*pguidProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSurrogateProviderGuid)(
		/*[out]*/ GUID* /*pguidProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderToolbar)(
		/*[out]*/ GUID* /*pguidGroup*/,
		/*[out]*/ DWORD* /*pdwID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColumnCount)(
		/*[out]*/ int* /*pnColumns*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColumn)(
		/*[in]*/ int /*iColumn*/,
		/*[out]*/ VSTASKCOLUMN* /*pColumn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeginTaskEdit)(
		/*[in]*/ IVsTaskItem* /*pItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnEndTaskEdit)(
		/*[in]*/ IVsTaskItem* /*pItem*/,
		/*[in]*/ BOOL /*fCommitChanges*/,
		/*[out]*/ BOOL* /*pfAllowChanges*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTaskProvider3MockImpl :
	public IVsTaskProvider3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskProvider3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskProvider3MockImpl)

	typedef IVsTaskProvider3 Interface;
	struct GetProviderFlagsValidValues
	{
		/*[out]*/ VSTASKPROVIDERFLAGS* tpfFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderFlags)(
		/*[out]*/ VSTASKPROVIDERFLAGS* tpfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderFlags)

		VSL_SET_VALIDVALUE(tpfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderGuidValidValues
	{
		/*[out]*/ GUID* pguidProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderGuid)(
		/*[out]*/ GUID* pguidProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderGuid)

		VSL_SET_VALIDVALUE(pguidProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSurrogateProviderGuidValidValues
	{
		/*[out]*/ GUID* pguidProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetSurrogateProviderGuid)(
		/*[out]*/ GUID* pguidProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetSurrogateProviderGuid)

		VSL_SET_VALIDVALUE(pguidProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderToolbarValidValues
	{
		/*[out]*/ GUID* pguidGroup;
		/*[out]*/ DWORD* pdwID;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderToolbar)(
		/*[out]*/ GUID* pguidGroup,
		/*[out]*/ DWORD* pdwID)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderToolbar)

		VSL_SET_VALIDVALUE(pguidGroup);

		VSL_SET_VALIDVALUE(pdwID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColumnCountValidValues
	{
		/*[out]*/ int* pnColumns;
		HRESULT retValue;
	};

	STDMETHOD(GetColumnCount)(
		/*[out]*/ int* pnColumns)
	{
		VSL_DEFINE_MOCK_METHOD(GetColumnCount)

		VSL_SET_VALIDVALUE(pnColumns);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColumnValidValues
	{
		/*[in]*/ int iColumn;
		/*[out]*/ VSTASKCOLUMN* pColumn;
		HRESULT retValue;
	};

	STDMETHOD(GetColumn)(
		/*[in]*/ int iColumn,
		/*[out]*/ VSTASKCOLUMN* pColumn)
	{
		VSL_DEFINE_MOCK_METHOD(GetColumn)

		VSL_CHECK_VALIDVALUE(iColumn);

		VSL_SET_VALIDVALUE(pColumn);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeginTaskEditValidValues
	{
		/*[in]*/ IVsTaskItem* pItem;
		HRESULT retValue;
	};

	STDMETHOD(OnBeginTaskEdit)(
		/*[in]*/ IVsTaskItem* pItem)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeginTaskEdit)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEndTaskEditValidValues
	{
		/*[in]*/ IVsTaskItem* pItem;
		/*[in]*/ BOOL fCommitChanges;
		/*[out]*/ BOOL* pfAllowChanges;
		HRESULT retValue;
	};

	STDMETHOD(OnEndTaskEdit)(
		/*[in]*/ IVsTaskItem* pItem,
		/*[in]*/ BOOL fCommitChanges,
		/*[out]*/ BOOL* pfAllowChanges)
	{
		VSL_DEFINE_MOCK_METHOD(OnEndTaskEdit)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pItem);

		VSL_CHECK_VALIDVALUE(fCommitChanges);

		VSL_SET_VALIDVALUE(pfAllowChanges);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKPROVIDER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
