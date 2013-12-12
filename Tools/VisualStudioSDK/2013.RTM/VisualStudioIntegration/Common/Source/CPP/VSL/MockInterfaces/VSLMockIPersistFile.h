/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPersistFileNotImpl :
	public IPersistFile
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistFileNotImpl)

public:

	typedef IPersistFile Interface;

	STDMETHOD(IsDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in]*/ LPCOLESTR /*pszFileName*/,
		/*[in]*/ DWORD /*dwMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in,unique]*/ LPCOLESTR /*pszFileName*/,
		/*[in]*/ BOOL /*fRemember*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveCompleted)(
		/*[in,unique]*/ LPCOLESTR /*pszFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurFile)(
		/*[out]*/ LPOLESTR* /*ppszFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistFileMockImpl :
	public IPersistFile,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistFileMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistFileMockImpl)

	typedef IPersistFile Interface;
	struct IsDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in]*/ LPCOLESTR pszFileName;
		/*[in]*/ DWORD dwMode;
		HRESULT retValue;
	};

	STDMETHOD(Load)(
		/*[in]*/ LPCOLESTR pszFileName,
		/*[in]*/ DWORD dwMode)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE(dwMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in,unique]*/ LPCOLESTR pszFileName;
		/*[in]*/ BOOL fRemember;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in,unique]*/ LPCOLESTR pszFileName,
		/*[in]*/ BOOL fRemember)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE(fRemember);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveCompletedValidValues
	{
		/*[in,unique]*/ LPCOLESTR pszFileName;
		HRESULT retValue;
	};

	STDMETHOD(SaveCompleted)(
		/*[in,unique]*/ LPCOLESTR pszFileName)
	{
		VSL_DEFINE_MOCK_METHOD(SaveCompleted)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurFileValidValues
	{
		/*[out]*/ LPOLESTR* ppszFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetCurFile)(
		/*[out]*/ LPOLESTR* ppszFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurFile)

		VSL_SET_VALIDVALUE(ppszFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassIDValidValues
	{
		/*[out]*/ CLSID* pClassID;
		HRESULT retValue;
	};

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* pClassID)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassID)

		VSL_SET_VALIDVALUE(pClassID);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERSISTFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
