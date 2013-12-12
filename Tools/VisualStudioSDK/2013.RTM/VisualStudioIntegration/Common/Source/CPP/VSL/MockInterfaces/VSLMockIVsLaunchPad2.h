/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLAUNCHPAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLAUNCHPAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLaunchPad2NotImpl :
	public IVsLaunchPad2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPad2NotImpl)

public:

	typedef IVsLaunchPad2 Interface;

	STDMETHOD(ExecCommandEx)(
		/*[in]*/ LPCOLESTR /*pszApplicationName*/,
		/*[in]*/ LPCOLESTR /*pszCommandLine*/,
		/*[in]*/ LPCOLESTR /*pszWorkingDir*/,
		/*[in]*/ LAUNCHPAD_FLAGS2 /*lpf*/,
		/*[in]*/ IVsOutputWindowPane* /*pOutputWindowPane*/,
		/*[in]*/ ULONG /*nTaskItemCategory*/,
		/*[in]*/ ULONG /*nTaskItemBitmap*/,
		/*[in]*/ LPCOLESTR /*pszTaskListSubcategory*/,
		/*[in]*/ IVsLaunchPadEvents* /*pVsLaunchPadEvents*/,
		/*[in]*/ IVsLaunchPadOutputParser* /*pOutputParser*/,
		/*[out,optional]*/ DWORD* /*pdwProcessExitCode*/,
		/*[out,optional]*/ BSTR* /*pbstrOutput*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLaunchPad2MockImpl :
	public IVsLaunchPad2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPad2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLaunchPad2MockImpl)

	typedef IVsLaunchPad2 Interface;
	struct ExecCommandExValidValues
	{
		/*[in]*/ LPCOLESTR pszApplicationName;
		/*[in]*/ LPCOLESTR pszCommandLine;
		/*[in]*/ LPCOLESTR pszWorkingDir;
		/*[in]*/ LAUNCHPAD_FLAGS2 lpf;
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane;
		/*[in]*/ ULONG nTaskItemCategory;
		/*[in]*/ ULONG nTaskItemBitmap;
		/*[in]*/ LPCOLESTR pszTaskListSubcategory;
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents;
		/*[in]*/ IVsLaunchPadOutputParser* pOutputParser;
		/*[out,optional]*/ DWORD* pdwProcessExitCode;
		/*[out,optional]*/ BSTR* pbstrOutput;
		HRESULT retValue;
	};

	STDMETHOD(ExecCommandEx)(
		/*[in]*/ LPCOLESTR pszApplicationName,
		/*[in]*/ LPCOLESTR pszCommandLine,
		/*[in]*/ LPCOLESTR pszWorkingDir,
		/*[in]*/ LAUNCHPAD_FLAGS2 lpf,
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane,
		/*[in]*/ ULONG nTaskItemCategory,
		/*[in]*/ ULONG nTaskItemBitmap,
		/*[in]*/ LPCOLESTR pszTaskListSubcategory,
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents,
		/*[in]*/ IVsLaunchPadOutputParser* pOutputParser,
		/*[out,optional]*/ DWORD* pdwProcessExitCode,
		/*[out,optional]*/ BSTR* pbstrOutput)
	{
		VSL_DEFINE_MOCK_METHOD(ExecCommandEx)

		VSL_CHECK_VALIDVALUE_STRINGW(pszApplicationName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCommandLine);

		VSL_CHECK_VALIDVALUE_STRINGW(pszWorkingDir);

		VSL_CHECK_VALIDVALUE(lpf);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOutputWindowPane);

		VSL_CHECK_VALIDVALUE(nTaskItemCategory);

		VSL_CHECK_VALIDVALUE(nTaskItemBitmap);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskListSubcategory);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLaunchPadEvents);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOutputParser);

		VSL_SET_VALIDVALUE(pdwProcessExitCode);

		VSL_SET_VALIDVALUE_BSTR(pbstrOutput);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLAUNCHPAD2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
