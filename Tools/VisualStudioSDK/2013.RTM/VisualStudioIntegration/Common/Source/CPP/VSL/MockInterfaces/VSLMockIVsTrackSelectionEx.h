/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTRACKSELECTIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTRACKSELECTIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTrackSelectionExNotImpl :
	public IVsTrackSelectionEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackSelectionExNotImpl)

public:

	typedef IVsTrackSelectionEx Interface;

	STDMETHOD(OnSelectChangeEx)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IVsMultiItemSelect* /*pMIS*/,
		/*[in]*/ ISelectionContainer* /*pSC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsMyHierarchyCurrent)(
		/*[out]*/ BOOL* /*pfCurrent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnElementValueChange)(
		/*[in]*/ VSSELELEMID /*elementid*/,
		/*[in]*/ BOOL /*fDontPropagate*/,
		/*[in]*/ VARIANT /*varValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IVsMultiItemSelect** /*ppMIS*/,
		/*[out]*/ ISelectionContainer** /*ppSC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnSelectChange)(
		/*[in]*/ ISelectionContainer* /*pSC*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTrackSelectionExMockImpl :
	public IVsTrackSelectionEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTrackSelectionExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTrackSelectionExMockImpl)

	typedef IVsTrackSelectionEx Interface;
	struct OnSelectChangeExValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IVsMultiItemSelect* pMIS;
		/*[in]*/ ISelectionContainer* pSC;
		HRESULT retValue;
	};

	STDMETHOD(OnSelectChangeEx)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IVsMultiItemSelect* pMIS,
		/*[in]*/ ISelectionContainer* pSC)
	{
		VSL_DEFINE_MOCK_METHOD(OnSelectChangeEx)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMIS);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSC);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsMyHierarchyCurrentValidValues
	{
		/*[out]*/ BOOL* pfCurrent;
		HRESULT retValue;
	};

	STDMETHOD(IsMyHierarchyCurrent)(
		/*[out]*/ BOOL* pfCurrent)
	{
		VSL_DEFINE_MOCK_METHOD(IsMyHierarchyCurrent)

		VSL_SET_VALIDVALUE(pfCurrent);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnElementValueChangeValidValues
	{
		/*[in]*/ VSSELELEMID elementid;
		/*[in]*/ BOOL fDontPropagate;
		/*[in]*/ VARIANT varValue;
		HRESULT retValue;
	};

	STDMETHOD(OnElementValueChange)(
		/*[in]*/ VSSELELEMID elementid,
		/*[in]*/ BOOL fDontPropagate,
		/*[in]*/ VARIANT varValue)
	{
		VSL_DEFINE_MOCK_METHOD(OnElementValueChange)

		VSL_CHECK_VALIDVALUE(elementid);

		VSL_CHECK_VALIDVALUE(fDontPropagate);

		VSL_CHECK_VALIDVALUE(varValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentSelectionValidValues
	{
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IVsMultiItemSelect** ppMIS;
		/*[out]*/ ISelectionContainer** ppSC;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IVsMultiItemSelect** ppMIS,
		/*[out]*/ ISelectionContainer** ppSC)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentSelection)

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppMIS);

		VSL_SET_VALIDVALUE_INTERFACE(ppSC);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnSelectChangeValidValues
	{
		/*[in]*/ ISelectionContainer* pSC;
		HRESULT retValue;
	};

	STDMETHOD(OnSelectChange)(
		/*[in]*/ ISelectionContainer* pSC)
	{
		VSL_DEFINE_MOCK_METHOD(OnSelectChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSC);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTRACKSELECTIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
