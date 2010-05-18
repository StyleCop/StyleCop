/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTFLAVORREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTFLAVORREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectFlavorReferencesNotImpl :
	public IVsProjectFlavorReferences
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorReferencesNotImpl)

public:

	typedef IVsProjectFlavorReferences Interface;

	STDMETHOD(QueryAddProjectReference)(
		/*[in]*/ IUnknown* /*pReferencedProject*/,
		/*[out,retval]*/ BOOL* /*pbCanAdd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryCanBeReferenced)(
		/*[in]*/ IUnknown* /*pReferencingProject*/,
		/*[out,retval]*/ BOOL* /*pbAllowReferenced*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryRefreshReferences)(
		/*[in]*/ UPDATE_REFERENCE_REASON /*reason*/,
		/*[out,retval]*/ BOOL* /*pbUpdate*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectFlavorReferencesMockImpl :
	public IVsProjectFlavorReferences,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorReferencesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectFlavorReferencesMockImpl)

	typedef IVsProjectFlavorReferences Interface;
	struct QueryAddProjectReferenceValidValues
	{
		/*[in]*/ IUnknown* pReferencedProject;
		/*[out,retval]*/ BOOL* pbCanAdd;
		HRESULT retValue;
	};

	STDMETHOD(QueryAddProjectReference)(
		/*[in]*/ IUnknown* pReferencedProject,
		/*[out,retval]*/ BOOL* pbCanAdd)
	{
		VSL_DEFINE_MOCK_METHOD(QueryAddProjectReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReferencedProject);

		VSL_SET_VALIDVALUE(pbCanAdd);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCanBeReferencedValidValues
	{
		/*[in]*/ IUnknown* pReferencingProject;
		/*[out,retval]*/ BOOL* pbAllowReferenced;
		HRESULT retValue;
	};

	STDMETHOD(QueryCanBeReferenced)(
		/*[in]*/ IUnknown* pReferencingProject,
		/*[out,retval]*/ BOOL* pbAllowReferenced)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCanBeReferenced)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pReferencingProject);

		VSL_SET_VALIDVALUE(pbAllowReferenced);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryRefreshReferencesValidValues
	{
		/*[in]*/ UPDATE_REFERENCE_REASON reason;
		/*[out,retval]*/ BOOL* pbUpdate;
		HRESULT retValue;
	};

	STDMETHOD(QueryRefreshReferences)(
		/*[in]*/ UPDATE_REFERENCE_REASON reason,
		/*[out,retval]*/ BOOL* pbUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(QueryRefreshReferences)

		VSL_CHECK_VALIDVALUE(reason);

		VSL_SET_VALIDVALUE(pbUpdate);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTFLAVORREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
