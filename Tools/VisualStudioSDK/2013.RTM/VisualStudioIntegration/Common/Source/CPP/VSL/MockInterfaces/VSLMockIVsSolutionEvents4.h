/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSolutionEvents4NotImpl :
	public IVsSolutionEvents4
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEvents4NotImpl)

public:

	typedef IVsSolutionEvents4 Interface;

	STDMETHOD(OnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryChangeProjectParent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pNewParentHier*/,
		/*[in,out]*/ BOOL* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionEvents4MockImpl :
	public IVsSolutionEvents4,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEvents4MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionEvents4MockImpl)

	typedef IVsSolutionEvents4 Interface;
	struct OnAfterRenameProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterRenameProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryChangeProjectParentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ IVsHierarchy* pNewParentHier;
		/*[in,out]*/ BOOL* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryChangeProjectParent)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ IVsHierarchy* pNewParentHier,
		/*[in,out]*/ BOOL* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryChangeProjectParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNewParentHier);

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterChangeProjectParentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterChangeProjectParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterAsynchOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterAsynchOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONEVENTS4_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
