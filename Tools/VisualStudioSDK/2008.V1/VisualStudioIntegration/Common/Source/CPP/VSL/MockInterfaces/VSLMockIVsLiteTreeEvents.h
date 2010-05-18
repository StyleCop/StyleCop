/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLITETREEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLITETREEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLiteTreeEventsNotImpl :
	public IVsLiteTreeEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLiteTreeEventsNotImpl)

public:

	typedef IVsLiteTreeEvents Interface;

	STDMETHOD(OnToggleExpansion)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[in]*/ long /*cChange*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnToggleState)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[in]*/ VSTREESTATECHANGEREFRESH /*tscr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRefresh)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInsertItems)(
		/*[in]*/ ULONG /*iAfter*/,
		/*[in]*/ ULONG /*Count*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDeleteItems)(
		/*[in]*/ ULONG /*iStart*/,
		/*[in]*/ ULONG /*Count*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnSetRedraw)(
		/*[in]*/ BOOL /*fOn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryItemVisible)(
		/*[in]*/ ULONG /*AbsIndex*/,
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLiteTreeEventsMockImpl :
	public IVsLiteTreeEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLiteTreeEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLiteTreeEventsMockImpl)

	typedef IVsLiteTreeEvents Interface;
	struct OnToggleExpansionValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[in]*/ long cChange;
		HRESULT retValue;
	};

	STDMETHOD(OnToggleExpansion)(
		/*[in]*/ ULONG AbsIndex,
		/*[in]*/ long cChange)
	{
		VSL_DEFINE_MOCK_METHOD(OnToggleExpansion)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_CHECK_VALIDVALUE(cChange);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnToggleStateValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[in]*/ VSTREESTATECHANGEREFRESH tscr;
		HRESULT retValue;
	};

	STDMETHOD(OnToggleState)(
		/*[in]*/ ULONG AbsIndex,
		/*[in]*/ VSTREESTATECHANGEREFRESH tscr)
	{
		VSL_DEFINE_MOCK_METHOD(OnToggleState)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_CHECK_VALIDVALUE(tscr);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRefreshValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnRefresh)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnRefresh)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInsertItemsValidValues
	{
		/*[in]*/ ULONG iAfter;
		/*[in]*/ ULONG Count;
		HRESULT retValue;
	};

	STDMETHOD(OnInsertItems)(
		/*[in]*/ ULONG iAfter,
		/*[in]*/ ULONG Count)
	{
		VSL_DEFINE_MOCK_METHOD(OnInsertItems)

		VSL_CHECK_VALIDVALUE(iAfter);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDeleteItemsValidValues
	{
		/*[in]*/ ULONG iStart;
		/*[in]*/ ULONG Count;
		HRESULT retValue;
	};

	STDMETHOD(OnDeleteItems)(
		/*[in]*/ ULONG iStart,
		/*[in]*/ ULONG Count)
	{
		VSL_DEFINE_MOCK_METHOD(OnDeleteItems)

		VSL_CHECK_VALIDVALUE(iStart);

		VSL_CHECK_VALIDVALUE(Count);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnSetRedrawValidValues
	{
		/*[in]*/ BOOL fOn;
		HRESULT retValue;
	};

	STDMETHOD(OnSetRedraw)(
		/*[in]*/ BOOL fOn)
	{
		VSL_DEFINE_MOCK_METHOD(OnSetRedraw)

		VSL_CHECK_VALIDVALUE(fOn);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryItemVisibleValidValues
	{
		/*[in]*/ ULONG AbsIndex;
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryItemVisible)(
		/*[in]*/ ULONG AbsIndex,
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryItemVisible)

		VSL_CHECK_VALIDVALUE(AbsIndex);

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLITETREEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
