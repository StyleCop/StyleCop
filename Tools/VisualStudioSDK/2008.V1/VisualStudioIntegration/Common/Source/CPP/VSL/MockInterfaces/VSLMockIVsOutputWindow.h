/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTPUTWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTPUTWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsOutputWindowNotImpl :
	public IVsOutputWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindowNotImpl)

public:

	typedef IVsOutputWindow Interface;

	STDMETHOD(GetPane)(
		/*[in]*/ REFGUID /*rguidPane*/,
		/*[out]*/ IVsOutputWindowPane** /*ppPane*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreatePane)(
		/*[in]*/ REFGUID /*rguidPane*/,
		/*[in]*/ LPCOLESTR /*pszPaneName*/,
		/*[in]*/ BOOL /*fInitVisible*/,
		/*[in]*/ BOOL /*fClearWithSolution*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeletePane)(
		/*[in]*/ REFGUID /*rguidPane*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutputWindowMockImpl :
	public IVsOutputWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutputWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutputWindowMockImpl)

	typedef IVsOutputWindow Interface;
	struct GetPaneValidValues
	{
		/*[in]*/ REFGUID rguidPane;
		/*[out]*/ IVsOutputWindowPane** ppPane;
		HRESULT retValue;
	};

	STDMETHOD(GetPane)(
		/*[in]*/ REFGUID rguidPane,
		/*[out]*/ IVsOutputWindowPane** ppPane)
	{
		VSL_DEFINE_MOCK_METHOD(GetPane)

		VSL_CHECK_VALIDVALUE(rguidPane);

		VSL_SET_VALIDVALUE_INTERFACE(ppPane);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreatePaneValidValues
	{
		/*[in]*/ REFGUID rguidPane;
		/*[in]*/ LPCOLESTR pszPaneName;
		/*[in]*/ BOOL fInitVisible;
		/*[in]*/ BOOL fClearWithSolution;
		HRESULT retValue;
	};

	STDMETHOD(CreatePane)(
		/*[in]*/ REFGUID rguidPane,
		/*[in]*/ LPCOLESTR pszPaneName,
		/*[in]*/ BOOL fInitVisible,
		/*[in]*/ BOOL fClearWithSolution)
	{
		VSL_DEFINE_MOCK_METHOD(CreatePane)

		VSL_CHECK_VALIDVALUE(rguidPane);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPaneName);

		VSL_CHECK_VALIDVALUE(fInitVisible);

		VSL_CHECK_VALIDVALUE(fClearWithSolution);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeletePaneValidValues
	{
		/*[in]*/ REFGUID rguidPane;
		HRESULT retValue;
	};

	STDMETHOD(DeletePane)(
		/*[in]*/ REFGUID rguidPane)
	{
		VSL_DEFINE_MOCK_METHOD(DeletePane)

		VSL_CHECK_VALIDVALUE(rguidPane);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTPUTWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
