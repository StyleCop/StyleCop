/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTBUILDSYSTEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTBUILDSYSTEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectBuildSystemNotImpl :
	public IVsProjectBuildSystem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectBuildSystemNotImpl)

public:

	typedef IVsProjectBuildSystem Interface;

	STDMETHOD(SetHostObject)(
		/*[in]*/ LPCOLESTR /*pszTargetName*/,
		/*[in]*/ LPCOLESTR /*pszTaskName*/,
		/*[in]*/ IUnknown* /*punkHostObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartBatchEdit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EndBatchEdit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelBatchEdit)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BuildTarget)(
		/*[in]*/ LPCOLESTR /*pszTargetName*/,
		/*[out,retval]*/ VARIANT_BOOL* /*pbSuccess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBuildSystemKind)(
		/*[out,retval]*/ BuildSystemKindFlags* /*pBuildSystemKind*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectBuildSystemMockImpl :
	public IVsProjectBuildSystem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectBuildSystemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectBuildSystemMockImpl)

	typedef IVsProjectBuildSystem Interface;
	struct SetHostObjectValidValues
	{
		/*[in]*/ LPCOLESTR pszTargetName;
		/*[in]*/ LPCOLESTR pszTaskName;
		/*[in]*/ IUnknown* punkHostObject;
		HRESULT retValue;
	};

	STDMETHOD(SetHostObject)(
		/*[in]*/ LPCOLESTR pszTargetName,
		/*[in]*/ LPCOLESTR pszTaskName,
		/*[in]*/ IUnknown* punkHostObject)
	{
		VSL_DEFINE_MOCK_METHOD(SetHostObject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTargetName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTaskName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkHostObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartBatchEditValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StartBatchEdit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StartBatchEdit)

		VSL_RETURN_VALIDVALUES();
	}
	struct EndBatchEditValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EndBatchEdit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EndBatchEdit)

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelBatchEditValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CancelBatchEdit)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CancelBatchEdit)

		VSL_RETURN_VALIDVALUES();
	}
	struct BuildTargetValidValues
	{
		/*[in]*/ LPCOLESTR pszTargetName;
		/*[out,retval]*/ VARIANT_BOOL* pbSuccess;
		HRESULT retValue;
	};

	STDMETHOD(BuildTarget)(
		/*[in]*/ LPCOLESTR pszTargetName,
		/*[out,retval]*/ VARIANT_BOOL* pbSuccess)
	{
		VSL_DEFINE_MOCK_METHOD(BuildTarget)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTargetName);

		VSL_SET_VALIDVALUE(pbSuccess);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBuildSystemKindValidValues
	{
		/*[out,retval]*/ BuildSystemKindFlags* pBuildSystemKind;
		HRESULT retValue;
	};

	STDMETHOD(GetBuildSystemKind)(
		/*[out,retval]*/ BuildSystemKindFlags* pBuildSystemKind)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuildSystemKind)

		VSL_SET_VALIDVALUE(pBuildSystemKind);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTBUILDSYSTEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
