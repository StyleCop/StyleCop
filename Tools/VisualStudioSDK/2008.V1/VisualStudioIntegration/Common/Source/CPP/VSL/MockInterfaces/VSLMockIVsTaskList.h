/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTASKLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTASKLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTaskListNotImpl :
	public IVsTaskList
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskListNotImpl)

public:

	typedef IVsTaskList Interface;

	STDMETHOD(RegisterTaskProvider)(
		/*[in]*/ IVsTaskProvider* /*pProvider*/,
		/*[out]*/ VSCOOKIE* /*pdwProviderCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterTaskProvider)(
		/*[in]*/ VSCOOKIE /*dwProviderCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshTasks)(
		/*[in]*/ VSCOOKIE /*dwProviderCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumTaskItems)(
		/*[out]*/ IVsEnumTaskItems** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AutoFilter)(
		/*[in]*/ VSTASKCATEGORY /*cat*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateProviderInfo)(
		/*[in]*/ VSCOOKIE /*dwProviderCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSilentOutputMode)(
		/*[in]*/ BOOL /*fSilent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DumpOutput)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ VSTASKCATEGORY /*cat*/,
		/*[in]*/ IStream* /*pstmOutput*/,
		/*[out]*/ BOOL* /*pfOutputWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterCustomCategory)(
		/*[in]*/ REFGUID /*guidCat*/,
		/*[in]*/ DWORD /*dwSortOrder*/,
		/*[out]*/ VSTASKCATEGORY* /*pCat*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterCustomCategory)(
		/*[in]*/ VSTASKCATEGORY /*catAssigned*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AutoFilter2)(
		/*[in]*/ REFGUID /*guidCustomView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTaskListMockImpl :
	public IVsTaskList,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTaskListMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTaskListMockImpl)

	typedef IVsTaskList Interface;
	struct RegisterTaskProviderValidValues
	{
		/*[in]*/ IVsTaskProvider* pProvider;
		/*[out]*/ VSCOOKIE* pdwProviderCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterTaskProvider)(
		/*[in]*/ IVsTaskProvider* pProvider,
		/*[out]*/ VSCOOKIE* pdwProviderCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterTaskProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProvider);

		VSL_SET_VALIDVALUE(pdwProviderCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterTaskProviderValidValues
	{
		/*[in]*/ VSCOOKIE dwProviderCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterTaskProvider)(
		/*[in]*/ VSCOOKIE dwProviderCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterTaskProvider)

		VSL_CHECK_VALIDVALUE(dwProviderCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshTasksValidValues
	{
		/*[in]*/ VSCOOKIE dwProviderCookie;
		HRESULT retValue;
	};

	STDMETHOD(RefreshTasks)(
		/*[in]*/ VSCOOKIE dwProviderCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RefreshTasks)

		VSL_CHECK_VALIDVALUE(dwProviderCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumTaskItemsValidValues
	{
		/*[out]*/ IVsEnumTaskItems** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumTaskItems)(
		/*[out]*/ IVsEnumTaskItems** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumTaskItems)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct AutoFilterValidValues
	{
		/*[in]*/ VSTASKCATEGORY cat;
		HRESULT retValue;
	};

	STDMETHOD(AutoFilter)(
		/*[in]*/ VSTASKCATEGORY cat)
	{
		VSL_DEFINE_MOCK_METHOD(AutoFilter)

		VSL_CHECK_VALIDVALUE(cat);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateProviderInfoValidValues
	{
		/*[in]*/ VSCOOKIE dwProviderCookie;
		HRESULT retValue;
	};

	STDMETHOD(UpdateProviderInfo)(
		/*[in]*/ VSCOOKIE dwProviderCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateProviderInfo)

		VSL_CHECK_VALIDVALUE(dwProviderCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSilentOutputModeValidValues
	{
		/*[in]*/ BOOL fSilent;
		HRESULT retValue;
	};

	STDMETHOD(SetSilentOutputMode)(
		/*[in]*/ BOOL fSilent)
	{
		VSL_DEFINE_MOCK_METHOD(SetSilentOutputMode)

		VSL_CHECK_VALIDVALUE(fSilent);

		VSL_RETURN_VALIDVALUES();
	}
	struct DumpOutputValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ VSTASKCATEGORY cat;
		/*[in]*/ IStream* pstmOutput;
		/*[out]*/ BOOL* pfOutputWritten;
		HRESULT retValue;
	};

	STDMETHOD(DumpOutput)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ VSTASKCATEGORY cat,
		/*[in]*/ IStream* pstmOutput,
		/*[out]*/ BOOL* pfOutputWritten)
	{
		VSL_DEFINE_MOCK_METHOD(DumpOutput)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(cat);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstmOutput);

		VSL_SET_VALIDVALUE(pfOutputWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterCustomCategoryValidValues
	{
		/*[in]*/ REFGUID guidCat;
		/*[in]*/ DWORD dwSortOrder;
		/*[out]*/ VSTASKCATEGORY* pCat;
		HRESULT retValue;
	};

	STDMETHOD(RegisterCustomCategory)(
		/*[in]*/ REFGUID guidCat,
		/*[in]*/ DWORD dwSortOrder,
		/*[out]*/ VSTASKCATEGORY* pCat)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterCustomCategory)

		VSL_CHECK_VALIDVALUE(guidCat);

		VSL_CHECK_VALIDVALUE(dwSortOrder);

		VSL_SET_VALIDVALUE(pCat);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterCustomCategoryValidValues
	{
		/*[in]*/ VSTASKCATEGORY catAssigned;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterCustomCategory)(
		/*[in]*/ VSTASKCATEGORY catAssigned)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterCustomCategory)

		VSL_CHECK_VALIDVALUE(catAssigned);

		VSL_RETURN_VALIDVALUES();
	}
	struct AutoFilter2ValidValues
	{
		/*[in]*/ REFGUID guidCustomView;
		HRESULT retValue;
	};

	STDMETHOD(AutoFilter2)(
		/*[in]*/ REFGUID guidCustomView)
	{
		VSL_DEFINE_MOCK_METHOD(AutoFilter2)

		VSL_CHECK_VALIDVALUE(guidCustomView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTASKLIST_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
