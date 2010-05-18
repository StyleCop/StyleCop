/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICREATEERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICREATEERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ICreateErrorInfoNotImpl :
	public ICreateErrorInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateErrorInfoNotImpl)

public:

	typedef ICreateErrorInfo Interface;

	STDMETHOD(SetGUID)(
		/*[in]*/ REFGUID /*rguid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSource)(
		/*[in]*/ LPOLESTR /*szSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDescription)(
		/*[in]*/ LPOLESTR /*szDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpFile)(
		/*[in]*/ LPOLESTR /*szHelpFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpContext)(
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL
};

class ICreateErrorInfoMockImpl :
	public ICreateErrorInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateErrorInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICreateErrorInfoMockImpl)

	typedef ICreateErrorInfo Interface;
	struct SetGUIDValidValues
	{
		/*[in]*/ REFGUID rguid;
		HRESULT retValue;
	};

	STDMETHOD(SetGUID)(
		/*[in]*/ REFGUID rguid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGUID)

		VSL_CHECK_VALIDVALUE(rguid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSourceValidValues
	{
		/*[in]*/ LPOLESTR szSource;
		HRESULT retValue;
	};

	STDMETHOD(SetSource)(
		/*[in]*/ LPOLESTR szSource)
	{
		VSL_DEFINE_MOCK_METHOD(SetSource)

		VSL_CHECK_VALIDVALUE_STRINGW(szSource);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDescriptionValidValues
	{
		/*[in]*/ LPOLESTR szDescription;
		HRESULT retValue;
	};

	STDMETHOD(SetDescription)(
		/*[in]*/ LPOLESTR szDescription)
	{
		VSL_DEFINE_MOCK_METHOD(SetDescription)

		VSL_CHECK_VALIDVALUE_STRINGW(szDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHelpFileValidValues
	{
		/*[in]*/ LPOLESTR szHelpFile;
		HRESULT retValue;
	};

	STDMETHOD(SetHelpFile)(
		/*[in]*/ LPOLESTR szHelpFile)
	{
		VSL_DEFINE_MOCK_METHOD(SetHelpFile)

		VSL_CHECK_VALIDVALUE_STRINGW(szHelpFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHelpContextValidValues
	{
		/*[in]*/ DWORD dwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(SetHelpContext)(
		/*[in]*/ DWORD dwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetHelpContext)

		VSL_CHECK_VALIDVALUE(dwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICREATEERRORINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
