/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISYNCHRONIZEHANDLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISYNCHRONIZEHANDLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISynchronizeHandleNotImpl :
	public ISynchronizeHandle
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeHandleNotImpl)

public:

	typedef ISynchronizeHandle Interface;

	STDMETHOD(GetHandle)(
		/*[out]*/ HANDLE* /*ph*/)VSL_STDMETHOD_NOTIMPL
};

class ISynchronizeHandleMockImpl :
	public ISynchronizeHandle,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeHandleMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISynchronizeHandleMockImpl)

	typedef ISynchronizeHandle Interface;
	struct GetHandleValidValues
	{
		/*[out]*/ HANDLE* ph;
		HRESULT retValue;
	};

	STDMETHOD(GetHandle)(
		/*[out]*/ HANDLE* ph)
	{
		VSL_DEFINE_MOCK_METHOD(GetHandle)

		VSL_SET_VALIDVALUE(ph);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISYNCHRONIZEHANDLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
