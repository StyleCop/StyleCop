/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROGRESSNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROGRESSNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IProgressNotifyNotImpl :
	public IProgressNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProgressNotifyNotImpl)

public:

	typedef IProgressNotify Interface;

	STDMETHOD(OnProgress)(
		/*[in]*/ DWORD /*dwProgressCurrent*/,
		/*[in]*/ DWORD /*dwProgressMaximum*/,
		/*[in]*/ BOOL /*fAccurate*/,
		/*[in]*/ BOOL /*fOwner*/)VSL_STDMETHOD_NOTIMPL
};

class IProgressNotifyMockImpl :
	public IProgressNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProgressNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProgressNotifyMockImpl)

	typedef IProgressNotify Interface;
	struct OnProgressValidValues
	{
		/*[in]*/ DWORD dwProgressCurrent;
		/*[in]*/ DWORD dwProgressMaximum;
		/*[in]*/ BOOL fAccurate;
		/*[in]*/ BOOL fOwner;
		HRESULT retValue;
	};

	STDMETHOD(OnProgress)(
		/*[in]*/ DWORD dwProgressCurrent,
		/*[in]*/ DWORD dwProgressMaximum,
		/*[in]*/ BOOL fAccurate,
		/*[in]*/ BOOL fOwner)
	{
		VSL_DEFINE_MOCK_METHOD(OnProgress)

		VSL_CHECK_VALIDVALUE(dwProgressCurrent);

		VSL_CHECK_VALIDVALUE(dwProgressMaximum);

		VSL_CHECK_VALIDVALUE(fAccurate);

		VSL_CHECK_VALIDVALUE(fOwner);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROGRESSNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
