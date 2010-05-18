/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSELECTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSELECTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSelectionEventsNotImpl :
	public IVsSelectionEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectionEventsNotImpl)

public:

	typedef IVsSelectionEvents Interface;

	STDMETHOD(OnSelectionChanged)(
		/*[in]*/ IVsHierarchy* /*pHierOld*/,
		/*[in]*/ VSITEMID /*itemidOld*/,
		/*[in]*/ IVsMultiItemSelect* /*pMISOld*/,
		/*[in]*/ ISelectionContainer* /*pSCOld*/,
		/*[in]*/ IVsHierarchy* /*pHierNew*/,
		/*[in]*/ VSITEMID /*itemidNew*/,
		/*[in]*/ IVsMultiItemSelect* /*pMISNew*/,
		/*[in]*/ ISelectionContainer* /*pSCNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnElementValueChanged)(
		/*[in]*/ VSSELELEMID /*elementid*/,
		/*[in]*/ VARIANT /*varValueOld*/,
		/*[in]*/ VARIANT /*varValueNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCmdUIContextChanged)(
		/*[in]*/ VSCOOKIE /*dwCmdUICookie*/,
		/*[in]*/ BOOL /*fActive*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSelectionEventsMockImpl :
	public IVsSelectionEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSelectionEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSelectionEventsMockImpl)

	typedef IVsSelectionEvents Interface;
	struct OnSelectionChangedValidValues
	{
		/*[in]*/ IVsHierarchy* pHierOld;
		/*[in]*/ VSITEMID itemidOld;
		/*[in]*/ IVsMultiItemSelect* pMISOld;
		/*[in]*/ ISelectionContainer* pSCOld;
		/*[in]*/ IVsHierarchy* pHierNew;
		/*[in]*/ VSITEMID itemidNew;
		/*[in]*/ IVsMultiItemSelect* pMISNew;
		/*[in]*/ ISelectionContainer* pSCNew;
		HRESULT retValue;
	};

	STDMETHOD(OnSelectionChanged)(
		/*[in]*/ IVsHierarchy* pHierOld,
		/*[in]*/ VSITEMID itemidOld,
		/*[in]*/ IVsMultiItemSelect* pMISOld,
		/*[in]*/ ISelectionContainer* pSCOld,
		/*[in]*/ IVsHierarchy* pHierNew,
		/*[in]*/ VSITEMID itemidNew,
		/*[in]*/ IVsMultiItemSelect* pMISNew,
		/*[in]*/ ISelectionContainer* pSCNew)
	{
		VSL_DEFINE_MOCK_METHOD(OnSelectionChanged)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierOld);

		VSL_CHECK_VALIDVALUE(itemidOld);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMISOld);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSCOld);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierNew);

		VSL_CHECK_VALIDVALUE(itemidNew);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMISNew);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSCNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnElementValueChangedValidValues
	{
		/*[in]*/ VSSELELEMID elementid;
		/*[in]*/ VARIANT varValueOld;
		/*[in]*/ VARIANT varValueNew;
		HRESULT retValue;
	};

	STDMETHOD(OnElementValueChanged)(
		/*[in]*/ VSSELELEMID elementid,
		/*[in]*/ VARIANT varValueOld,
		/*[in]*/ VARIANT varValueNew)
	{
		VSL_DEFINE_MOCK_METHOD(OnElementValueChanged)

		VSL_CHECK_VALIDVALUE(elementid);

		VSL_CHECK_VALIDVALUE(varValueOld);

		VSL_CHECK_VALIDVALUE(varValueNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCmdUIContextChangedValidValues
	{
		/*[in]*/ VSCOOKIE dwCmdUICookie;
		/*[in]*/ BOOL fActive;
		HRESULT retValue;
	};

	STDMETHOD(OnCmdUIContextChanged)(
		/*[in]*/ VSCOOKIE dwCmdUICookie,
		/*[in]*/ BOOL fActive)
	{
		VSL_DEFINE_MOCK_METHOD(OnCmdUIContextChanged)

		VSL_CHECK_VALIDVALUE(dwCmdUICookie);

		VSL_CHECK_VALIDVALUE(fActive);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSELECTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
