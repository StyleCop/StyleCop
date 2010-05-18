/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEWINDOWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEWINDOWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCodeWindowExNotImpl :
	public IVsCodeWindowEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowExNotImpl)

public:

	typedef IVsCodeWindowEx Interface;

	STDMETHOD(Initialize)(
		/*[in]*/ CODEWINDOWBEHAVIORFLAGS /*grfCodeWindowBehaviorFlags*/,
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE /*usageAuxUserContext*/,
		/*[in]*/ LPCOLESTR /*szNameAuxUserContext*/,
		/*[in]*/ LPCOLESTR /*szValueAuxUserContext*/,
		/*[in]*/ DWORD /*InitViewFlags*/,
		/*[in]*/ const INITVIEW* /*pInitView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsReadOnly)()VSL_STDMETHOD_NOTIMPL
};

class IVsCodeWindowExMockImpl :
	public IVsCodeWindowEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeWindowExMockImpl)

	typedef IVsCodeWindowEx Interface;
	struct InitializeValidValues
	{
		/*[in]*/ CODEWINDOWBEHAVIORFLAGS grfCodeWindowBehaviorFlags;
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE usageAuxUserContext;
		/*[in]*/ LPCOLESTR szNameAuxUserContext;
		/*[in]*/ LPCOLESTR szValueAuxUserContext;
		/*[in]*/ DWORD InitViewFlags;
		/*[in]*/ INITVIEW* pInitView;
		HRESULT retValue;
	};

	STDMETHOD(Initialize)(
		/*[in]*/ CODEWINDOWBEHAVIORFLAGS grfCodeWindowBehaviorFlags,
		/*[in]*/ VSUSERCONTEXTATTRIBUTEUSAGE usageAuxUserContext,
		/*[in]*/ LPCOLESTR szNameAuxUserContext,
		/*[in]*/ LPCOLESTR szValueAuxUserContext,
		/*[in]*/ DWORD InitViewFlags,
		/*[in]*/ const INITVIEW* pInitView)
	{
		VSL_DEFINE_MOCK_METHOD(Initialize)

		VSL_CHECK_VALIDVALUE(grfCodeWindowBehaviorFlags);

		VSL_CHECK_VALIDVALUE(usageAuxUserContext);

		VSL_CHECK_VALIDVALUE_STRINGW(szNameAuxUserContext);

		VSL_CHECK_VALIDVALUE_STRINGW(szValueAuxUserContext);

		VSL_CHECK_VALIDVALUE(InitViewFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pInitView);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsReadOnlyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsReadOnly)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsReadOnly)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEWINDOWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
