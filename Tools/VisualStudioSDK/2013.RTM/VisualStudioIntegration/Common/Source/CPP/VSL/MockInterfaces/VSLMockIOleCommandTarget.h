/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DocObj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleCommandTargetNotImpl :
	public IOleCommandTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCommandTargetNotImpl)

public:

	typedef IOleCommandTarget Interface;

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ ULONG /*cCmds*/,
		/*[size_is(cCmds),in,out]*/ OLECMD[] /*prgCmds*/,
		/*[in,out,unique]*/ OLECMDTEXT* /*pCmdText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdID*/,
		/*[in]*/ DWORD /*nCmdexecopt*/,
		/*[in,unique]*/ VARIANT* /*pvaIn*/,
		/*[in,out,unique]*/ VARIANT* /*pvaOut*/)VSL_STDMETHOD_NOTIMPL
};

class IOleCommandTargetMockImpl :
	public IOleCommandTarget,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCommandTargetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleCommandTargetMockImpl)

	typedef IOleCommandTarget Interface;
	struct QueryStatusValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ ULONG cCmds;
		/*[size_is(cCmds),in,out]*/ OLECMD* prgCmds;
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatus)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ ULONG cCmds,
		/*[size_is(cCmds),in,out]*/ OLECMD prgCmds[],
		/*[in,out,unique]*/ OLECMDTEXT* pCmdText)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatus)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(cCmds);

		VSL_SET_VALIDVALUE_MEMCPY(prgCmds, cCmds*sizeof(prgCmds[0]), validValues.cCmds*sizeof(validValues.prgCmds[0]));

		VSL_SET_VALIDVALUE(pCmdText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdID;
		/*[in]*/ DWORD nCmdexecopt;
		/*[in,unique]*/ VARIANT* pvaIn;
		/*[in,out,unique]*/ VARIANT* pvaOut;
		HRESULT retValue;
	};

	STDMETHOD(Exec)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdID,
		/*[in]*/ DWORD nCmdexecopt,
		/*[in,unique]*/ VARIANT* pvaIn,
		/*[in,out,unique]*/ VARIANT* pvaOut)
	{
		VSL_DEFINE_MOCK_METHOD(Exec)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdID);

		VSL_CHECK_VALIDVALUE(nCmdexecopt);

		VSL_CHECK_VALIDVALUE_POINTER(pvaIn);

		VSL_SET_VALIDVALUE_VARIANT(pvaOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECOMMANDTARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
