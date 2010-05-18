/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPARSEDISPLAYNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPARSEDISPLAYNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IParseDisplayNameNotImpl :
	public IParseDisplayName
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IParseDisplayNameNotImpl)

public:

	typedef IParseDisplayName Interface;

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* /*pbc*/,
		/*[in]*/ LPOLESTR /*pszDisplayName*/,
		/*[out]*/ ULONG* /*pchEaten*/,
		/*[out]*/ IMoniker** /*ppmkOut*/)VSL_STDMETHOD_NOTIMPL
};

class IParseDisplayNameMockImpl :
	public IParseDisplayName,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IParseDisplayNameMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IParseDisplayNameMockImpl)

	typedef IParseDisplayName Interface;
	struct ParseDisplayNameValidValues
	{
		/*[in,unique]*/ IBindCtx* pbc;
		/*[in]*/ LPOLESTR pszDisplayName;
		/*[out]*/ ULONG* pchEaten;
		/*[out]*/ IMoniker** ppmkOut;
		HRESULT retValue;
	};

	STDMETHOD(ParseDisplayName)(
		/*[in,unique]*/ IBindCtx* pbc,
		/*[in]*/ LPOLESTR pszDisplayName,
		/*[out]*/ ULONG* pchEaten,
		/*[out]*/ IMoniker** ppmkOut)
	{
		VSL_DEFINE_MOCK_METHOD(ParseDisplayName)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDisplayName);

		VSL_SET_VALIDVALUE(pchEaten);

		VSL_SET_VALIDVALUE_INTERFACE(ppmkOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPARSEDISPLAYNAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
