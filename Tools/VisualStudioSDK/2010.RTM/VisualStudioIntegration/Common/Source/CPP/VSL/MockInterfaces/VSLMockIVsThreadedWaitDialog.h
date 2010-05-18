/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTHREADEDWAITDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTHREADEDWAITDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsThreadedWaitDialogNotImpl :
	public IVsThreadedWaitDialog
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsThreadedWaitDialogNotImpl)

public:

	typedef IVsThreadedWaitDialog Interface;

	STDMETHOD(StartWaitDialog)(
		/*[in]*/ BSTR /*bstrWaitCaption*/,
		/*[in]*/ BSTR /*bstrWaitMessage*/,
		/*[in]*/ BSTR /*bstrIfTruncateAppend*/,
		/*[in]*/ VSTWDFLAGS /*dwFlags*/,
		/*[in]*/ VARIANT /*varStatusBmpAnim*/,
		/*[in]*/ BSTR /*bstrStatusBarText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndWaitDialog)(
		/*[in]*/ BOOL* /*pfCancelled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GiveTimeSlice)(
		/*[in]*/ BSTR /*bstrUpdatedWaitMessage*/,
		/*[in]*/ BSTR /*bstrIfTruncateAppend*/,
		/*[in]*/ BOOL /*fDisableCancel*/,
		/*[out]*/ BOOL* /*pfCancelled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsThreadedWaitDialogMockImpl :
	public IVsThreadedWaitDialog,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsThreadedWaitDialogMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsThreadedWaitDialogMockImpl)

	typedef IVsThreadedWaitDialog Interface;
	struct StartWaitDialogValidValues
	{
		/*[in]*/ BSTR bstrWaitCaption;
		/*[in]*/ BSTR bstrWaitMessage;
		/*[in]*/ BSTR bstrIfTruncateAppend;
		/*[in]*/ VSTWDFLAGS dwFlags;
		/*[in]*/ VARIANT varStatusBmpAnim;
		/*[in]*/ BSTR bstrStatusBarText;
		HRESULT retValue;
	};

	STDMETHOD(StartWaitDialog)(
		/*[in]*/ BSTR bstrWaitCaption,
		/*[in]*/ BSTR bstrWaitMessage,
		/*[in]*/ BSTR bstrIfTruncateAppend,
		/*[in]*/ VSTWDFLAGS dwFlags,
		/*[in]*/ VARIANT varStatusBmpAnim,
		/*[in]*/ BSTR bstrStatusBarText)
	{
		VSL_DEFINE_MOCK_METHOD(StartWaitDialog)

		VSL_CHECK_VALIDVALUE_BSTR(bstrWaitCaption);

		VSL_CHECK_VALIDVALUE_BSTR(bstrWaitMessage);

		VSL_CHECK_VALIDVALUE_BSTR(bstrIfTruncateAppend);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(varStatusBmpAnim);

		VSL_CHECK_VALIDVALUE_BSTR(bstrStatusBarText);

		VSL_RETURN_VALIDVALUES();
	}
	struct EndWaitDialogValidValues
	{
		/*[in]*/ BOOL* pfCancelled;
		HRESULT retValue;
	};

	STDMETHOD(EndWaitDialog)(
		/*[in]*/ BOOL* pfCancelled)
	{
		VSL_DEFINE_MOCK_METHOD(EndWaitDialog)

		VSL_CHECK_VALIDVALUE_POINTER(pfCancelled);

		VSL_RETURN_VALIDVALUES();
	}
	struct GiveTimeSliceValidValues
	{
		/*[in]*/ BSTR bstrUpdatedWaitMessage;
		/*[in]*/ BSTR bstrIfTruncateAppend;
		/*[in]*/ BOOL fDisableCancel;
		/*[out]*/ BOOL* pfCancelled;
		HRESULT retValue;
	};

	STDMETHOD(GiveTimeSlice)(
		/*[in]*/ BSTR bstrUpdatedWaitMessage,
		/*[in]*/ BSTR bstrIfTruncateAppend,
		/*[in]*/ BOOL fDisableCancel,
		/*[out]*/ BOOL* pfCancelled)
	{
		VSL_DEFINE_MOCK_METHOD(GiveTimeSlice)

		VSL_CHECK_VALIDVALUE_BSTR(bstrUpdatedWaitMessage);

		VSL_CHECK_VALIDVALUE_BSTR(bstrIfTruncateAppend);

		VSL_CHECK_VALIDVALUE(fDisableCancel);

		VSL_SET_VALIDVALUE(pfCancelled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTHREADEDWAITDIALOG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
