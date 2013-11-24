/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICREATETYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICREATETYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ICreateTypeLibNotImpl :
	public ICreateTypeLib
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateTypeLibNotImpl)

public:

	typedef ICreateTypeLib Interface;

	STDMETHOD(CreateTypeInfo)(
		/*[in]*/ LPOLESTR /*szName*/,
		/*[in]*/ TYPEKIND /*tkind*/,
		/*[out]*/ ICreateTypeInfo** /*ppCTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetName)(
		/*[in]*/ LPOLESTR /*szName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVersion)(
		/*[in]*/ WORD /*wMajorVerNum*/,
		/*[in]*/ WORD /*wMinorVerNum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetGuid)(
		/*[in]*/ REFGUID /*guid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDocString)(
		/*[in]*/ LPOLESTR /*szDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpFileName)(
		/*[in]*/ LPOLESTR /*szHelpFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpContext)(
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLcid)(
		/*[in]*/ LCID /*lcid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLibFlags)(
		/*[in]*/ UINT /*uLibFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveAllChanges)()VSL_STDMETHOD_NOTIMPL
};

class ICreateTypeLibMockImpl :
	public ICreateTypeLib,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateTypeLibMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICreateTypeLibMockImpl)

	typedef ICreateTypeLib Interface;
	struct CreateTypeInfoValidValues
	{
		/*[in]*/ LPOLESTR szName;
		/*[in]*/ TYPEKIND tkind;
		/*[out]*/ ICreateTypeInfo** ppCTInfo;
		HRESULT retValue;
	};

	STDMETHOD(CreateTypeInfo)(
		/*[in]*/ LPOLESTR szName,
		/*[in]*/ TYPEKIND tkind,
		/*[out]*/ ICreateTypeInfo** ppCTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(CreateTypeInfo)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE(tkind);

		VSL_SET_VALIDVALUE_INTERFACE(ppCTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNameValidValues
	{
		/*[in]*/ LPOLESTR szName;
		HRESULT retValue;
	};

	STDMETHOD(SetName)(
		/*[in]*/ LPOLESTR szName)
	{
		VSL_DEFINE_MOCK_METHOD(SetName)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVersionValidValues
	{
		/*[in]*/ WORD wMajorVerNum;
		/*[in]*/ WORD wMinorVerNum;
		HRESULT retValue;
	};

	STDMETHOD(SetVersion)(
		/*[in]*/ WORD wMajorVerNum,
		/*[in]*/ WORD wMinorVerNum)
	{
		VSL_DEFINE_MOCK_METHOD(SetVersion)

		VSL_CHECK_VALIDVALUE(wMajorVerNum);

		VSL_CHECK_VALIDVALUE(wMinorVerNum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetGuidValidValues
	{
		/*[in]*/ REFGUID guid;
		HRESULT retValue;
	};

	STDMETHOD(SetGuid)(
		/*[in]*/ REFGUID guid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGuid)

		VSL_CHECK_VALIDVALUE(guid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDocStringValidValues
	{
		/*[in]*/ LPOLESTR szDoc;
		HRESULT retValue;
	};

	STDMETHOD(SetDocString)(
		/*[in]*/ LPOLESTR szDoc)
	{
		VSL_DEFINE_MOCK_METHOD(SetDocString)

		VSL_CHECK_VALIDVALUE_STRINGW(szDoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHelpFileNameValidValues
	{
		/*[in]*/ LPOLESTR szHelpFileName;
		HRESULT retValue;
	};

	STDMETHOD(SetHelpFileName)(
		/*[in]*/ LPOLESTR szHelpFileName)
	{
		VSL_DEFINE_MOCK_METHOD(SetHelpFileName)

		VSL_CHECK_VALIDVALUE_STRINGW(szHelpFileName);

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
	struct SetLcidValidValues
	{
		/*[in]*/ LCID lcid;
		HRESULT retValue;
	};

	STDMETHOD(SetLcid)(
		/*[in]*/ LCID lcid)
	{
		VSL_DEFINE_MOCK_METHOD(SetLcid)

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLibFlagsValidValues
	{
		/*[in]*/ UINT uLibFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetLibFlags)(
		/*[in]*/ UINT uLibFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetLibFlags)

		VSL_CHECK_VALIDVALUE(uLibFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveAllChangesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SaveAllChanges)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SaveAllChanges)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICREATETYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
