/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISURROGATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISURROGATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISurrogateNotImpl :
	public ISurrogate
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISurrogateNotImpl)

public:

	typedef ISurrogate Interface;

	STDMETHOD(LoadDllServer)(
		/*[in]*/ REFCLSID /*Clsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreeSurrogate)()VSL_STDMETHOD_NOTIMPL
};

class ISurrogateMockImpl :
	public ISurrogate,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISurrogateMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISurrogateMockImpl)

	typedef ISurrogate Interface;
	struct LoadDllServerValidValues
	{
		/*[in]*/ REFCLSID Clsid;
		HRESULT retValue;
	};

	STDMETHOD(LoadDllServer)(
		/*[in]*/ REFCLSID Clsid)
	{
		VSL_DEFINE_MOCK_METHOD(LoadDllServer)

		VSL_CHECK_VALIDVALUE(Clsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeSurrogateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FreeSurrogate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FreeSurrogate)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISURROGATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
