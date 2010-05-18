/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUIHIERWINCLIPBOARDHELPEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUIHIERWINCLIPBOARDHELPEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIHierWinClipboardHelperEventsNotImpl :
	public IVsUIHierWinClipboardHelperEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierWinClipboardHelperEventsNotImpl)

public:

	typedef IVsUIHierWinClipboardHelperEvents Interface;

	STDMETHOD(OnPaste)(
		/*[in]*/ BOOL /*fDataWasCut*/,
		/*[in]*/ DWORD /*dwEffects*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnClear)(
		/*[in]*/ BOOL /*fDataWasCut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIHierWinClipboardHelperEventsMockImpl :
	public IVsUIHierWinClipboardHelperEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierWinClipboardHelperEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIHierWinClipboardHelperEventsMockImpl)

	typedef IVsUIHierWinClipboardHelperEvents Interface;
	struct OnPasteValidValues
	{
		/*[in]*/ BOOL fDataWasCut;
		/*[in]*/ DWORD dwEffects;
		HRESULT retValue;
	};

	STDMETHOD(OnPaste)(
		/*[in]*/ BOOL fDataWasCut,
		/*[in]*/ DWORD dwEffects)
	{
		VSL_DEFINE_MOCK_METHOD(OnPaste)

		VSL_CHECK_VALIDVALUE(fDataWasCut);

		VSL_CHECK_VALIDVALUE(dwEffects);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnClearValidValues
	{
		/*[in]*/ BOOL fDataWasCut;
		HRESULT retValue;
	};

	STDMETHOD(OnClear)(
		/*[in]*/ BOOL fDataWasCut)
	{
		VSL_DEFINE_MOCK_METHOD(OnClear)

		VSL_CHECK_VALIDVALUE(fDataWasCut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUIHIERWINCLIPBOARDHELPEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
