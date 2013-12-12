/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUPDATESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUPDATESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUpdateSolutionEventsNotImpl :
	public IVsUpdateSolutionEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpdateSolutionEventsNotImpl)

public:

	typedef IVsUpdateSolutionEvents Interface;

	STDMETHOD(UpdateSolution_Begin)(
		/*[in,out]*/ BOOL* /*pfCancelUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSolution_Done)(
		/*[in]*/ BOOL /*fSucceeded*/,
		/*[in]*/ BOOL /*fModified*/,
		/*[in]*/ BOOL /*fCancelCommand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSolution_StartUpdate)(
		/*[in,out]*/ BOOL* /*pfCancelUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSolution_Cancel)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnActiveProjectCfgChange)(
		/*[in]*/ IVsHierarchy* /*pIVsHierarchy*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUpdateSolutionEventsMockImpl :
	public IVsUpdateSolutionEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpdateSolutionEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUpdateSolutionEventsMockImpl)

	typedef IVsUpdateSolutionEvents Interface;
	struct UpdateSolution_BeginValidValues
	{
		/*[in,out]*/ BOOL* pfCancelUpdate;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSolution_Begin)(
		/*[in,out]*/ BOOL* pfCancelUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSolution_Begin)

		VSL_SET_VALIDVALUE(pfCancelUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSolution_DoneValidValues
	{
		/*[in]*/ BOOL fSucceeded;
		/*[in]*/ BOOL fModified;
		/*[in]*/ BOOL fCancelCommand;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSolution_Done)(
		/*[in]*/ BOOL fSucceeded,
		/*[in]*/ BOOL fModified,
		/*[in]*/ BOOL fCancelCommand)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSolution_Done)

		VSL_CHECK_VALIDVALUE(fSucceeded);

		VSL_CHECK_VALIDVALUE(fModified);

		VSL_CHECK_VALIDVALUE(fCancelCommand);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSolution_StartUpdateValidValues
	{
		/*[in,out]*/ BOOL* pfCancelUpdate;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSolution_StartUpdate)(
		/*[in,out]*/ BOOL* pfCancelUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSolution_StartUpdate)

		VSL_SET_VALIDVALUE(pfCancelUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSolution_CancelValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UpdateSolution_Cancel)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UpdateSolution_Cancel)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnActiveProjectCfgChangeValidValues
	{
		/*[in]*/ IVsHierarchy* pIVsHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnActiveProjectCfgChange)(
		/*[in]*/ IVsHierarchy* pIVsHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnActiveProjectCfgChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUPDATESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
