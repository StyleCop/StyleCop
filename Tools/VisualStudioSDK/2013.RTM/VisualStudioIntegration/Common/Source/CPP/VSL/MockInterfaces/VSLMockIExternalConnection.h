/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEXTERNALCONNECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEXTERNALCONNECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IExternalConnectionNotImpl :
	public IExternalConnection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExternalConnectionNotImpl)

public:

	typedef IExternalConnection Interface;

	virtual DWORD STDMETHODCALLTYPE AddConnection(
		/*[in]*/ DWORD /*extconn*/,
		/*[in]*/ DWORD /*reserved*/){ return DWORD(); }

	virtual DWORD STDMETHODCALLTYPE ReleaseConnection(
		/*[in]*/ DWORD /*extconn*/,
		/*[in]*/ DWORD /*reserved*/,
		/*[in]*/ BOOL /*fLastReleaseCloses*/){ return DWORD(); }
};

class IExternalConnectionMockImpl :
	public IExternalConnection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExternalConnectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IExternalConnectionMockImpl)

	typedef IExternalConnection Interface;
	struct AddConnectionValidValues
	{
		/*[in]*/ DWORD extconn;
		/*[in]*/ DWORD reserved;
		DWORD retValue;
	};

	virtual DWORD _stdcall AddConnection(
		/*[in]*/ DWORD extconn,
		/*[in]*/ DWORD reserved)
	{
		VSL_DEFINE_MOCK_METHOD(AddConnection)

		VSL_CHECK_VALIDVALUE(extconn);

		VSL_CHECK_VALIDVALUE(reserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseConnectionValidValues
	{
		/*[in]*/ DWORD extconn;
		/*[in]*/ DWORD reserved;
		/*[in]*/ BOOL fLastReleaseCloses;
		DWORD retValue;
	};

	virtual DWORD _stdcall ReleaseConnection(
		/*[in]*/ DWORD extconn,
		/*[in]*/ DWORD reserved,
		/*[in]*/ BOOL fLastReleaseCloses)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseConnection)

		VSL_CHECK_VALIDVALUE(extconn);

		VSL_CHECK_VALIDVALUE(reserved);

		VSL_CHECK_VALIDVALUE(fLastReleaseCloses);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEXTERNALCONNECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
