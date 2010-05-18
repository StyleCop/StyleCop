/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCMDNAMEMAPPING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCMDNAMEMAPPING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCmdNameMappingNotImpl :
	public IVsCmdNameMapping
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCmdNameMappingNotImpl)

public:

	typedef IVsCmdNameMapping Interface;

	STDMETHOD(MapGUIDIDToName)(
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwCmdID*/,
		/*[in]*/ VSCMDNAMEOPTS /*grfOptions*/,
		/*[out]*/ BSTR* /*pbstrCmdName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapNameToGUIDID)(
		/*[in]*/ const LPCOLESTR /*pszCmdName*/,
		/*[out]*/ GUID* /*pguidCmdGroup*/,
		/*[out]*/ DWORD* /*pdwCmdID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumNames)(
		/*[in]*/ VSCMDNAMEOPTS /*grfOptions*/,
		/*[out,retval]*/ IEnumString** /*ppEnumString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastUpdated)(
		/*[out,retval]*/ DWORD* /*pdwTickCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumMacroNames)(
		/*[in]*/ VSCMDNAMEOPTS /*grfOptions*/,
		/*[out,retval]*/ IEnumString** /*ppEnumString*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCmdNameMappingMockImpl :
	public IVsCmdNameMapping,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCmdNameMappingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCmdNameMappingMockImpl)

	typedef IVsCmdNameMapping Interface;
	struct MapGUIDIDToNameValidValues
	{
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD dwCmdID;
		/*[in]*/ VSCMDNAMEOPTS grfOptions;
		/*[out]*/ BSTR* pbstrCmdName;
		HRESULT retValue;
	};

	STDMETHOD(MapGUIDIDToName)(
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD dwCmdID,
		/*[in]*/ VSCMDNAMEOPTS grfOptions,
		/*[out]*/ BSTR* pbstrCmdName)
	{
		VSL_DEFINE_MOCK_METHOD(MapGUIDIDToName)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwCmdID);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_SET_VALIDVALUE_BSTR(pbstrCmdName);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapNameToGUIDIDValidValues
	{
		/*[in]*/ LPCOLESTR pszCmdName;
		/*[out]*/ GUID* pguidCmdGroup;
		/*[out]*/ DWORD* pdwCmdID;
		HRESULT retValue;
	};

	STDMETHOD(MapNameToGUIDID)(
		/*[in]*/ const LPCOLESTR pszCmdName,
		/*[out]*/ GUID* pguidCmdGroup,
		/*[out]*/ DWORD* pdwCmdID)
	{
		VSL_DEFINE_MOCK_METHOD(MapNameToGUIDID)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdName);

		VSL_SET_VALIDVALUE(pguidCmdGroup);

		VSL_SET_VALIDVALUE(pdwCmdID);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumNamesValidValues
	{
		/*[in]*/ VSCMDNAMEOPTS grfOptions;
		/*[out,retval]*/ IEnumString** ppEnumString;
		HRESULT retValue;
	};

	STDMETHOD(EnumNames)(
		/*[in]*/ VSCMDNAMEOPTS grfOptions,
		/*[out,retval]*/ IEnumString** ppEnumString)
	{
		VSL_DEFINE_MOCK_METHOD(EnumNames)

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumString);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastUpdatedValidValues
	{
		/*[out,retval]*/ DWORD* pdwTickCount;
		HRESULT retValue;
	};

	STDMETHOD(GetLastUpdated)(
		/*[out,retval]*/ DWORD* pdwTickCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastUpdated)

		VSL_SET_VALIDVALUE(pdwTickCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumMacroNamesValidValues
	{
		/*[in]*/ VSCMDNAMEOPTS grfOptions;
		/*[out,retval]*/ IEnumString** ppEnumString;
		HRESULT retValue;
	};

	STDMETHOD(EnumMacroNames)(
		/*[in]*/ VSCMDNAMEOPTS grfOptions,
		/*[out,retval]*/ IEnumString** ppEnumString)
	{
		VSL_DEFINE_MOCK_METHOD(EnumMacroNames)

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumString);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCMDNAMEMAPPING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
