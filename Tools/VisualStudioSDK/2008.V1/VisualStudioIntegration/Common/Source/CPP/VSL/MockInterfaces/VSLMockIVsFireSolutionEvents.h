/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFIRESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFIRESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFireSolutionEventsNotImpl :
	public IVsFireSolutionEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFireSolutionEventsNotImpl)

public:

	typedef IVsFireSolutionEvents Interface;

	STDMETHOD(FireOnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnQueryCloseProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fRemoving*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fRemoved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnQueryUnloadProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireOnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFireSolutionEventsMockImpl :
	public IVsFireSolutionEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFireSolutionEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFireSolutionEventsMockImpl)

	typedef IVsFireSolutionEvents Interface;
	struct FireOnAfterOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnQueryCloseProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fRemoving;
		HRESULT retValue;
	};

	STDMETHOD(FireOnQueryCloseProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fRemoving)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnQueryCloseProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fRemoving);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnBeforeCloseProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fRemoved;
		HRESULT retValue;
	};

	STDMETHOD(FireOnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fRemoved)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnBeforeCloseProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fRemoved);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnAfterLoadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterLoadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnQueryUnloadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnQueryUnloadProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnQueryUnloadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnBeforeUnloadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnBeforeUnloadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnBeforeOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnBeforeOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnAfterOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnBeforeClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnBeforeClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireOnAfterClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(FireOnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(FireOnAfterClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFIRESOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
