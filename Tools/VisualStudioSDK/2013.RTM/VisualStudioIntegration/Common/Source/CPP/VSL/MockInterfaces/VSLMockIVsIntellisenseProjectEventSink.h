/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSEPROJECTEVENTSINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSEPROJECTEVENTSINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsIntellisenseProjectEventSinkNotImpl :
	public IVsIntellisenseProjectEventSink
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectEventSinkNotImpl)

public:

	typedef IVsIntellisenseProjectEventSink Interface;

	STDMETHOD(OnStatusChange)(
		/*[in]*/ DWORD /*dwStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnReferenceChange)(
		/*[in]*/ DWORD /*dwChangeType*/,
		/*[in]*/ LPCWSTR /*pszAssemblyPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnConfigChange)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCodeFileChange)(
		/*[in]*/ LPCWSTR /*pszOldCodeFile*/,
		/*[in]*/ LPCWSTR /*pszNewCodeFile*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseProjectEventSinkMockImpl :
	public IVsIntellisenseProjectEventSink,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectEventSinkMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseProjectEventSinkMockImpl)

	typedef IVsIntellisenseProjectEventSink Interface;
	struct OnStatusChangeValidValues
	{
		/*[in]*/ DWORD dwStatus;
		HRESULT retValue;
	};

	STDMETHOD(OnStatusChange)(
		/*[in]*/ DWORD dwStatus)
	{
		VSL_DEFINE_MOCK_METHOD(OnStatusChange)

		VSL_CHECK_VALIDVALUE(dwStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnReferenceChangeValidValues
	{
		/*[in]*/ DWORD dwChangeType;
		/*[in]*/ LPCWSTR pszAssemblyPath;
		HRESULT retValue;
	};

	STDMETHOD(OnReferenceChange)(
		/*[in]*/ DWORD dwChangeType,
		/*[in]*/ LPCWSTR pszAssemblyPath)
	{
		VSL_DEFINE_MOCK_METHOD(OnReferenceChange)

		VSL_CHECK_VALIDVALUE(dwChangeType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAssemblyPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnConfigChangeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnConfigChange)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnConfigChange)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCodeFileChangeValidValues
	{
		/*[in]*/ LPCWSTR pszOldCodeFile;
		/*[in]*/ LPCWSTR pszNewCodeFile;
		HRESULT retValue;
	};

	STDMETHOD(OnCodeFileChange)(
		/*[in]*/ LPCWSTR pszOldCodeFile,
		/*[in]*/ LPCWSTR pszNewCodeFile)
	{
		VSL_DEFINE_MOCK_METHOD(OnCodeFileChange)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldCodeFile);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNewCodeFile);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSEPROJECTEVENTSINK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
