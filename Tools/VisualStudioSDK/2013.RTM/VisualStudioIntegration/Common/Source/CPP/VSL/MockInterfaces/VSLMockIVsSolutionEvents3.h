/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionEvents3NotImpl :
	public IVsSolutionEvents3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEvents3NotImpl)

public:

	typedef IVsSolutionEvents3 Interface;

	STDMETHOD(OnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterMergeSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fAdded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryCloseProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fRemoving*/,
		/*[in,out]*/ BOOL* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ BOOL /*fRemoved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* /*pStubHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pRealHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryUnloadProject)(
		/*[in]*/ IVsHierarchy* /*pRealHierarchy*/,
		/*[in,out]*/ BOOL* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* /*pRealHierarchy*/,
		/*[in]*/ IVsHierarchy* /*pStubHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterOpenSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/,
		/*[in]*/ BOOL /*fNewSolution*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryCloseSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/,
		/*[in,out]*/ BOOL* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnBeforeCloseSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterCloseSolution)(
		/*[in]*/ IUnknown* /*pUnkReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionEvents3MockImpl :
	public IVsSolutionEvents3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEvents3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionEvents3MockImpl)

	typedef IVsSolutionEvents3 Interface;
	struct OnBeforeOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterOpeningChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterOpeningChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterOpeningChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterClosingChildrenValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterClosingChildren)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterClosingChildren)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterMergeSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterMergeSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterMergeSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterOpenProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fAdded;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterOpenProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fAdded)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterOpenProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fAdded);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryCloseProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fRemoving;
		/*[in,out]*/ BOOL* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryCloseProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fRemoving,
		/*[in,out]*/ BOOL* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryCloseProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fRemoving);

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeCloseProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ BOOL fRemoved;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeCloseProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ BOOL fRemoved)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeCloseProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fRemoved);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterLoadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pStubHierarchy;
		/*[in]*/ IVsHierarchy* pRealHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterLoadProject)(
		/*[in]*/ IVsHierarchy* pStubHierarchy,
		/*[in]*/ IVsHierarchy* pRealHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterLoadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStubHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryUnloadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pRealHierarchy;
		/*[in,out]*/ BOOL* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryUnloadProject)(
		/*[in]*/ IVsHierarchy* pRealHierarchy,
		/*[in,out]*/ BOOL* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryUnloadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealHierarchy);

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeUnloadProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pRealHierarchy;
		/*[in]*/ IVsHierarchy* pStubHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeUnloadProject)(
		/*[in]*/ IVsHierarchy* pRealHierarchy,
		/*[in]*/ IVsHierarchy* pStubHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeUnloadProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pRealHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStubHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterOpenSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		/*[in]*/ BOOL fNewSolution;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterOpenSolution)(
		/*[in]*/ IUnknown* pUnkReserved,
		/*[in]*/ BOOL fNewSolution)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterOpenSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_CHECK_VALIDVALUE(fNewSolution);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryCloseSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		/*[in,out]*/ BOOL* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryCloseSolution)(
		/*[in]*/ IUnknown* pUnkReserved,
		/*[in,out]*/ BOOL* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryCloseSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnBeforeCloseSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeCloseSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeCloseSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterCloseSolutionValidValues
	{
		/*[in]*/ IUnknown* pUnkReserved;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterCloseSolution)(
		/*[in]*/ IUnknown* pUnkReserved)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterCloseSolution)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
