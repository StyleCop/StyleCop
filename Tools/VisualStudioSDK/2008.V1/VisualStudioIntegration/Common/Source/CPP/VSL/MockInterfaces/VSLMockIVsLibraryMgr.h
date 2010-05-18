/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLIBRARYMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLIBRARYMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLibraryMgrNotImpl :
	public IVsLibraryMgr
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryMgrNotImpl)

public:

	typedef IVsLibraryMgr Interface;

	STDMETHOD(GetCount)(
		/*[out,retval]*/ ULONG* /*pnCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibraryAt)(
		/*[in]*/ ULONG /*nLibIndex*/,
		/*[out,retval]*/ IVsLibrary** /*ppLibrary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNameAt)(
		/*[in]*/ ULONG /*nLibIndex*/,
		/*[out,retval]*/ WCHAR** /*pszName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleCheckAt)(
		/*[in]*/ ULONG /*nLibIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCheckAt)(
		/*[in]*/ ULONG /*nLibIndex*/,
		/*[out,retval]*/ LIB_CHECKSTATE* /*pstate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLibraryGroupEnabled)(
		/*[in]*/ LIB_PERSISTTYPE /*lpt*/,
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLibraryMgrMockImpl :
	public IVsLibraryMgr,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryMgrMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLibraryMgrMockImpl)

	typedef IVsLibraryMgr Interface;
	struct GetCountValidValues
	{
		/*[out,retval]*/ ULONG* pnCount;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out,retval]*/ ULONG* pnCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pnCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLibraryAtValidValues
	{
		/*[in]*/ ULONG nLibIndex;
		/*[out,retval]*/ IVsLibrary** ppLibrary;
		HRESULT retValue;
	};

	STDMETHOD(GetLibraryAt)(
		/*[in]*/ ULONG nLibIndex,
		/*[out,retval]*/ IVsLibrary** ppLibrary)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibraryAt)

		VSL_CHECK_VALIDVALUE(nLibIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppLibrary);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameAtValidValues
	{
		/*[in]*/ ULONG nLibIndex;
		/*[out,retval]*/ WCHAR** pszName;
		HRESULT retValue;
	};

	STDMETHOD(GetNameAt)(
		/*[in]*/ ULONG nLibIndex,
		/*[out,retval]*/ WCHAR** pszName)
	{
		VSL_DEFINE_MOCK_METHOD(GetNameAt)

		VSL_CHECK_VALIDVALUE(nLibIndex);

		VSL_SET_VALIDVALUE(pszName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleCheckAtValidValues
	{
		/*[in]*/ ULONG nLibIndex;
		HRESULT retValue;
	};

	STDMETHOD(ToggleCheckAt)(
		/*[in]*/ ULONG nLibIndex)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleCheckAt)

		VSL_CHECK_VALIDVALUE(nLibIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCheckAtValidValues
	{
		/*[in]*/ ULONG nLibIndex;
		/*[out,retval]*/ LIB_CHECKSTATE* pstate;
		HRESULT retValue;
	};

	STDMETHOD(GetCheckAt)(
		/*[in]*/ ULONG nLibIndex,
		/*[out,retval]*/ LIB_CHECKSTATE* pstate)
	{
		VSL_DEFINE_MOCK_METHOD(GetCheckAt)

		VSL_CHECK_VALIDVALUE(nLibIndex);

		VSL_SET_VALIDVALUE(pstate);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLibraryGroupEnabledValidValues
	{
		/*[in]*/ LIB_PERSISTTYPE lpt;
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(SetLibraryGroupEnabled)(
		/*[in]*/ LIB_PERSISTTYPE lpt,
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(SetLibraryGroupEnabled)

		VSL_CHECK_VALIDVALUE(lpt);

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLIBRARYMGR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
