/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSQUERYLINECHANGECOMMIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSQUERYLINECHANGECOMMIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsQueryLineChangeCommitNotImpl :
	public IVsQueryLineChangeCommit
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryLineChangeCommitNotImpl)

public:

	typedef IVsQueryLineChangeCommit Interface;

	STDMETHOD(QuerySendEnterLineCommit)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ long /*iLineStart*/,
		/*[in]*/ long /*iLineEnd*/,
		/*[out,retval]*/ QuerySendCommitFlags* /*dwQuerySendCommitFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IVsQueryLineChangeCommitMockImpl :
	public IVsQueryLineChangeCommit,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsQueryLineChangeCommitMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsQueryLineChangeCommitMockImpl)

	typedef IVsQueryLineChangeCommit Interface;
	struct QuerySendEnterLineCommitValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ long iLineStart;
		/*[in]*/ long iLineEnd;
		/*[out,retval]*/ QuerySendCommitFlags* dwQuerySendCommitFlags;
		HRESULT retValue;
	};

	STDMETHOD(QuerySendEnterLineCommit)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ long iLineStart,
		/*[in]*/ long iLineEnd,
		/*[out,retval]*/ QuerySendCommitFlags* dwQuerySendCommitFlags)
	{
		VSL_DEFINE_MOCK_METHOD(QuerySendEnterLineCommit)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(iLineStart);

		VSL_CHECK_VALIDVALUE(iLineEnd);

		VSL_SET_VALIDVALUE(dwQuerySendCommitFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSQUERYLINECHANGECOMMIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
