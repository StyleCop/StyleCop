/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWPANECOMMITFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWPANECOMMITFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWindowPaneCommitFilterNotImpl :
	public IVsWindowPaneCommitFilter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowPaneCommitFilterNotImpl)

public:

	typedef IVsWindowPaneCommitFilter Interface;

	STDMETHOD(IsCommitCommand)(
		/*[in]*/ REFGUID /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwCmdID*/,
		/*[out]*/ BOOL* /*pfCommitCommand*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowPaneCommitFilterMockImpl :
	public IVsWindowPaneCommitFilter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowPaneCommitFilterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowPaneCommitFilterMockImpl)

	typedef IVsWindowPaneCommitFilter Interface;
	struct IsCommitCommandValidValues
	{
		/*[in]*/ REFGUID pguidCmdGroup;
		/*[in]*/ DWORD dwCmdID;
		/*[out]*/ BOOL* pfCommitCommand;
		HRESULT retValue;
	};

	STDMETHOD(IsCommitCommand)(
		/*[in]*/ REFGUID pguidCmdGroup,
		/*[in]*/ DWORD dwCmdID,
		/*[out]*/ BOOL* pfCommitCommand)
	{
		VSL_DEFINE_MOCK_METHOD(IsCommitCommand)

		VSL_CHECK_VALIDVALUE(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwCmdID);

		VSL_SET_VALIDVALUE(pfCommitCommand);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWPANECOMMITFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
