/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLINKEDUNDOTRANSACTIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLINKEDUNDOTRANSACTIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLinkedUndoTransactionManagerNotImpl :
	public IVsLinkedUndoTransactionManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLinkedUndoTransactionManagerNotImpl)

public:

	typedef IVsLinkedUndoTransactionManager Interface;

	STDMETHOD(OpenLinkedUndo)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ const WCHAR* /*pszDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseLinkedUndo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AbortLinkedUndo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsAborted)(
		/*[in]*/ BOOL* /*pfAborted*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsStrict)(
		/*[in]*/ BOOL* /*pfStrict*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountOpenTransactions)(
		/*[in]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLinkedUndoTransactionManagerMockImpl :
	public IVsLinkedUndoTransactionManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLinkedUndoTransactionManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLinkedUndoTransactionManagerMockImpl)

	typedef IVsLinkedUndoTransactionManager Interface;
	struct OpenLinkedUndoValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ WCHAR* pszDescription;
		HRESULT retValue;
	};

	STDMETHOD(OpenLinkedUndo)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ const WCHAR* pszDescription)
	{
		VSL_DEFINE_MOCK_METHOD(OpenLinkedUndo)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseLinkedUndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseLinkedUndo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseLinkedUndo)

		VSL_RETURN_VALIDVALUES();
	}
	struct AbortLinkedUndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AbortLinkedUndo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AbortLinkedUndo)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsAbortedValidValues
	{
		/*[in]*/ BOOL* pfAborted;
		HRESULT retValue;
	};

	STDMETHOD(IsAborted)(
		/*[in]*/ BOOL* pfAborted)
	{
		VSL_DEFINE_MOCK_METHOD(IsAborted)

		VSL_CHECK_VALIDVALUE_POINTER(pfAborted);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsStrictValidValues
	{
		/*[in]*/ BOOL* pfStrict;
		HRESULT retValue;
	};

	STDMETHOD(IsStrict)(
		/*[in]*/ BOOL* pfStrict)
	{
		VSL_DEFINE_MOCK_METHOD(IsStrict)

		VSL_CHECK_VALIDVALUE_POINTER(pfStrict);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountOpenTransactionsValidValues
	{
		/*[in]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(CountOpenTransactions)(
		/*[in]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(CountOpenTransactions)

		VSL_CHECK_VALIDVALUE_POINTER(pCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLINKEDUNDOTRANSACTIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
