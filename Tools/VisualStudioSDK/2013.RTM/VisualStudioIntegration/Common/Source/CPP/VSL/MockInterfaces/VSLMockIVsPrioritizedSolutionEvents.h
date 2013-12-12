/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPRIORITIZEDSOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPRIORITIZEDSOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPrioritizedSolutionEventsNotImpl :
	public IVsPrioritizedSolutionEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPrioritizedSolutionEventsNotImpl)

public:

	typedef IVsPrioritizedSolutionEvents Interface;

	STDMETHOD(PrioritizedOnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fRemoved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* /*pStubHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pRealHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* /*pRealHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pStubHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterOpenSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/,
		/*[in]*/ BOOL /*fNewSolution*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnBeforeCloseSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterCloseSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterMergeSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PrioritizedOnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPrioritizedSolutionEventsMockImpl :
	public IVsPrioritizedSolutionEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPrioritizedSolutionEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPrioritizedSolutionEventsMockImpl)

	typedef IVsPrioritizedSolutionEvents Interface;
	struct PrioritizedOnAfterOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnBeforeCloseProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fRemoved;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fRemoved)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnBeforeCloseProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fRemoved);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterLoadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pStubHierarchy;
		/*[in]*/ IVsHierarchy* pRealHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* pStubHierarchy,
		/*[in]*/ IVsHierarchy* pRealHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterLoadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStubHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnBeforeUnloadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pRealHierarchy;
		/*[in]*/ IVsHierarchy* pStubHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* pRealHierarchy,
		/*[in]*/ IVsHierarchy* pStubHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnBeforeUnloadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStubHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterOpenSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		/*[in]*/ BOOL fNewSolution;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterOpenSolution)(
		/*[in]*/ IUnknown* pUnkReserved,
		/*[in]*/ BOOL fNewSolution)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterOpenSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_CHECK_VALIDVALUE(fNewSolution);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnBeforeCloseSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnBeforeCloseSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnBeforeCloseSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterCloseSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterCloseSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterCloseSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterMergeSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterMergeSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterMergeSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnBeforeOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnBeforeOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnBeforeClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnBeforeClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterRenameProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterRenameProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterRenameProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterChangeProjectParentValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterChangeProjectParent)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterChangeProjectParent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrioritizedOnAfterAsynchOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(PrioritizedOnAfterAsynchOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(PrioritizedOnAfterAsynchOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPRIORITIZEDSOLUTIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
