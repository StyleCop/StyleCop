/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFIRESOLUTIONEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFIRESOLUTIONEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFireSolutionEvents2NotImpl :
	public IVsFireSolutionEvents2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFireSolutionEvents2NotImpl)

public:

	typedef IVsFireSolutionEvents2 Interface;

	STDMETHOD(FireOnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnQueryChangeProjectParent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pNewParentHier*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFireSolutionEvents2MockImpl :
	public IVsFireSolutionEvents2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFireSolutionEvents2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFireSolutionEvents2MockImpl)

	typedef IVsFireSolutionEvents2 Interface;
	struct FireOnAfterRenameProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterRenameProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnQueryChangeProjectParentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ IVsHierarchy* pNewParentHier;
		HRESULT retValue;
	};

	STDMETHOD(FireOnQueryChangeProjectParent)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ IVsHierarchy* pNewParentHier)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnQueryChangeProjectParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNewParentHier);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnAfterChangeProjectParentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterChangeProjectParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnAfterAsynchOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterAsynchOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFIRESOLUTIONEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
