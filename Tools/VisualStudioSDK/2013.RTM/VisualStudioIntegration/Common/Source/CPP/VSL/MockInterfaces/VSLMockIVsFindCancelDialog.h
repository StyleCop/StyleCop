/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDCANCELDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDCANCELDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFindCancelDialogNotImpl :
	public IVsFindCancelDialog
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindCancelDialogNotImpl)

public:

	typedef IVsFindCancelDialog Interface;

	STDMETHOD(LaunchDialog)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryDialog)(
		/*[out]*/ BOOL* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseDialog)()VSL_STDMETHOD_NOTIMPL
};

class IVsFindCancelDialogMockImpl :
	public IVsFindCancelDialog,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindCancelDialogMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindCancelDialogMockImpl)

	typedef IVsFindCancelDialog Interface;
	struct LaunchDialogValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(LaunchDialog)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(LaunchDialog)

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryDialogValidValues
	{
		/*[out]*/ BOOL* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(QueryDialog)(
		/*[out]*/ BOOL* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDialog)

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseDialogValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseDialog)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseDialog)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDCANCELDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
