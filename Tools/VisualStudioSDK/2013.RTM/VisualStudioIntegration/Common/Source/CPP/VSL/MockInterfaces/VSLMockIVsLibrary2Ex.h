/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLIBRARY2EX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLIBRARY2EX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLibrary2ExNotImpl :
	public IVsLibrary2Ex
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibrary2ExNotImpl)

public:

	typedef IVsLibrary2Ex Interface;

	STDMETHOD(ProfileSettingsChanged)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNavInfoContainerData)(
		/*[in]*/ IVsNavInfo* /*pNavInfo*/,
		/*[out]*/ VSCOMPONENTSELECTORDATA* /*pcsdComponent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoIdle)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContainerAsUnchanging)(
		/*[in]*/ VSCOMPONENTSELECTORDATA* /*pcsdComponent*/,
		/*[in]*/ BOOL /*fUnchanging*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLibrary2ExMockImpl :
	public IVsLibrary2Ex,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibrary2ExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLibrary2ExMockImpl)

	typedef IVsLibrary2Ex Interface;
	struct ProfileSettingsChangedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ProfileSettingsChanged)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ProfileSettingsChanged)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNavInfoContainerDataValidValues
	{
		/*[in]*/ IVsNavInfo* pNavInfo;
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdComponent;
		HRESULT retValue;
	};

	STDMETHOD(GetNavInfoContainerData)(
		/*[in]*/ IVsNavInfo* pNavInfo,
		/*[out]*/ VSCOMPONENTSELECTORDATA* pcsdComponent)
	{
		VSL_DEFINE_MOCK_METHOD(GetNavInfoContainerData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNavInfo);

		VSL_SET_VALIDVALUE(pcsdComponent);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoIdleValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DoIdle)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DoIdle)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetContainerAsUnchangingValidValues
	{
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent;
		/*[in]*/ BOOL fUnchanging;
		HRESULT retValue;
	};

	STDMETHOD(SetContainerAsUnchanging)(
		/*[in]*/ VSCOMPONENTSELECTORDATA* pcsdComponent,
		/*[in]*/ BOOL fUnchanging)
	{
		VSL_DEFINE_MOCK_METHOD(SetContainerAsUnchanging)

		VSL_CHECK_VALIDVALUE_POINTER(pcsdComponent);

		VSL_CHECK_VALIDVALUE(fUnchanging);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLIBRARY2EX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
