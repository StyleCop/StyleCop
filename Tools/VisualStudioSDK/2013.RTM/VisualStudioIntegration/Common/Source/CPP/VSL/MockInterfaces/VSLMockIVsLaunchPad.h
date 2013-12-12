/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLAUNCHPAD_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLAUNCHPAD_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsLaunchPadNotImpl :
	public IVsLaunchPad
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPadNotImpl)

public:

	typedef IVsLaunchPad Interface;

	STDMETHOD(ExecCommand)(
		/*[in]*/ LPCOLESTR /*pszApplicationName*/,
		/*[in]*/ LPCOLESTR /*pszCommandLine*/,
		/*[in]*/ LPCOLESTR /*pszWorkingDir*/,
		/*[in]*/ LAUNCHPAD_FLAGS /*lpf*/,
		/*[in]*/ IVsOutputWindowPane* /*pOutputWindowPane*/,
		/*[in]*/ ULONG /*nTaskItemCategory*/,
		/*[in]*/ ULONG /*nTaskItemBitmap*/,
		/*[in]*/ LPCOLESTR /*pszTaskListSubcategory*/,
		/*[in]*/ IVsLaunchPadEvents* /*pVsLaunchPadEvents*/,
		/*[out]*/ DWORD* /*pdwProcessExitCode*/,
		/*[out]*/ BSTR* /*pbstrOutput*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecBatchScript)(
		/*[in]*/ LPCOLESTR /*pszBatchFileContents*/,
		/*[in]*/ LPCOLESTR /*pszWorkingDir*/,
		/*[in]*/ LAUNCHPAD_FLAGS /*lpf*/,
		/*[in]*/ IVsOutputWindowPane* /*pOutputWindowPane*/,
		/*[in]*/ ULONG /*nTaskItemCategory*/,
		/*[in]*/ ULONG /*nTaskItemBitmap*/,
		/*[in]*/ LPCOLESTR /*pszTaskListSubcategory*/,
		/*[in]*/ IVsLaunchPadEvents* /*pVsLaunchPadEvents*/,
		/*[out]*/ BSTR* /*pbstrOutput*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseOutputStringForTaskItem)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/,
		/*[out]*/ ULONG* /*pnPriority*/,
		/*[out]*/ BSTR* /*pbstrFilename*/,
		/*[out]*/ ULONG* /*pnLineNum*/,
		/*[out]*/ BSTR* /*pbstrTaskItemText*/,
		/*[out]*/ BOOL* /*pfTaskItemFound*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLaunchPadMockImpl :
	public IVsLaunchPad,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPadMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLaunchPadMockImpl)

	typedef IVsLaunchPad Interface;
	struct ExecCommandValidValues
	{
		/*[in]*/ LPCOLESTR pszApplicationName;
		/*[in]*/ LPCOLESTR pszCommandLine;
		/*[in]*/ LPCOLESTR pszWorkingDir;
		/*[in]*/ LAUNCHPAD_FLAGS lpf;
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane;
		/*[in]*/ ULONG nTaskItemCategory;
		/*[in]*/ ULONG nTaskItemBitmap;
		/*[in]*/ LPCOLESTR pszTaskListSubcategory;
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents;
		/*[out]*/ DWORD* pdwProcessExitCode;
		/*[out]*/ BSTR* pbstrOutput;
		HRESULT retValue;
	};

	STDMETHOD(ExecCommand)(
		/*[in]*/ LPCOLESTR pszApplicationName,
		/*[in]*/ LPCOLESTR pszCommandLine,
		/*[in]*/ LPCOLESTR pszWorkingDir,
		/*[in]*/ LAUNCHPAD_FLAGS lpf,
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane,
		/*[in]*/ ULONG nTaskItemCategory,
		/*[in]*/ ULONG nTaskItemBitmap,
		/*[in]*/ LPCOLESTR pszTaskListSubcategory,
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents,
		/*[out]*/ DWORD* pdwProcessExitCode,
		/*[out]*/ BSTR* pbstrOutput)
	{
		VSL_DEFINE_MOCK_METHOD(ExecCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(pszApplicationName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCommandLine);

		VSL_CHECK_VALIDVALUE_STRINGW(pszWorkingDir);

		VSL_CHECK_VALIDVALUE(lpf);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOutputWindowPane);

		VSL_CHECK_VALIDVALUE(nTaskItemCategory);

		VSL_CHECK_VALIDVALUE(nTaskItemBitmap);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskListSubcategory);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLaunchPadEvents);

		VSL_SET_VALIDVALUE(pdwProcessExitCode);

		VSL_SET_VALIDVALUE_BSTR(pbstrOutput);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecBatchScriptValidValues
	{
		/*[in]*/ LPCOLESTR pszBatchFileContents;
		/*[in]*/ LPCOLESTR pszWorkingDir;
		/*[in]*/ LAUNCHPAD_FLAGS lpf;
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane;
		/*[in]*/ ULONG nTaskItemCategory;
		/*[in]*/ ULONG nTaskItemBitmap;
		/*[in]*/ LPCOLESTR pszTaskListSubcategory;
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents;
		/*[out]*/ BSTR* pbstrOutput;
		HRESULT retValue;
	};

	STDMETHOD(ExecBatchScript)(
		/*[in]*/ LPCOLESTR pszBatchFileContents,
		/*[in]*/ LPCOLESTR pszWorkingDir,
		/*[in]*/ LAUNCHPAD_FLAGS lpf,
		/*[in]*/ IVsOutputWindowPane* pOutputWindowPane,
		/*[in]*/ ULONG nTaskItemCategory,
		/*[in]*/ ULONG nTaskItemBitmap,
		/*[in]*/ LPCOLESTR pszTaskListSubcategory,
		/*[in]*/ IVsLaunchPadEvents* pVsLaunchPadEvents,
		/*[out]*/ BSTR* pbstrOutput)
	{
		VSL_DEFINE_MOCK_METHOD(ExecBatchScript)

		VSL_CHECK_VALIDVALUE_STRINGW(pszBatchFileContents);

		VSL_CHECK_VALIDVALUE_STRINGW(pszWorkingDir);

		VSL_CHECK_VALIDVALUE(lpf);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOutputWindowPane);

		VSL_CHECK_VALIDVALUE(nTaskItemCategory);

		VSL_CHECK_VALIDVALUE(nTaskItemBitmap);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskListSubcategory);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLaunchPadEvents);

		VSL_SET_VALIDVALUE_BSTR(pbstrOutput);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseOutputStringForTaskItemValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		/*[out]*/ ULONG* pnPriority;
		/*[out]*/ BSTR* pbstrFilename;
		/*[out]*/ ULONG* pnLineNum;
		/*[out]*/ BSTR* pbstrTaskItemText;
		/*[out]*/ BOOL* pfTaskItemFound;
		HRESULT retValue;
	};

	STDMETHOD(ParseOutputStringForTaskItem)(
		/*[in]*/ LPCOLESTR pszOutputString,
		/*[out]*/ ULONG* pnPriority,
		/*[out]*/ BSTR* pbstrFilename,
		/*[out]*/ ULONG* pnLineNum,
		/*[out]*/ BSTR* pbstrTaskItemText,
		/*[out]*/ BOOL* pfTaskItemFound)
	{
		VSL_DEFINE_MOCK_METHOD(ParseOutputStringForTaskItem)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_SET_VALIDVALUE(pnPriority);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilename);

		VSL_SET_VALIDVALUE(pnLineNum);

		VSL_SET_VALIDVALUE_BSTR(pbstrTaskItemText);

		VSL_SET_VALIDVALUE(pfTaskItemFound);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLAUNCHPAD_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
