/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IErrorInfoNotImpl :
	public IErrorInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IErrorInfoNotImpl)

public:

	typedef IErrorInfo Interface;

	STDMETHOD(GetGUID)(
		/*[out]*/ GUID* /*pGUID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSource)(
		/*[out]*/ BSTR* /*pBstrSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pBstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHelpFile)(
		/*[out]*/ BSTR* /*pBstrHelpFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHelpContext)(
		/*[out]*/ DWORD* /*pdwHelpContext*/)VSL_STDMETHOD_NOTIMPL
};

class IErrorInfoMockImpl :
	public IErrorInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IErrorInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IErrorInfoMockImpl)

	typedef IErrorInfo Interface;
	struct GetGUIDValidValues
	{
		/*[out]*/ GUID* pGUID;
		HRESULT retValue;
	};

	STDMETHOD(GetGUID)(
		/*[out]*/ GUID* pGUID)
	{
		VSL_DEFINE_MOCK_METHOD(GetGUID)

		VSL_SET_VALIDVALUE(pGUID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSourceValidValues
	{
		/*[out]*/ BSTR* pBstrSource;
		HRESULT retValue;
	};

	STDMETHOD(GetSource)(
		/*[out]*/ BSTR* pBstrSource)
	{
		VSL_DEFINE_MOCK_METHOD(GetSource)

		VSL_SET_VALIDVALUE_BSTR(pBstrSource);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pBstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pBstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pBstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHelpFileValidValues
	{
		/*[out]*/ BSTR* pBstrHelpFile;
		HRESULT retValue;
	};

	STDMETHOD(GetHelpFile)(
		/*[out]*/ BSTR* pBstrHelpFile)
	{
		VSL_DEFINE_MOCK_METHOD(GetHelpFile)

		VSL_SET_VALIDVALUE_BSTR(pBstrHelpFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHelpContextValidValues
	{
		/*[out]*/ DWORD* pdwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(GetHelpContext)(
		/*[out]*/ DWORD* pdwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetHelpContext)

		VSL_SET_VALIDVALUE(pdwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
