/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUPDATESOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUPDATESOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUpdateSolutionEvents3NotImpl :
	public IVsUpdateSolutionEvents3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpdateSolutionEvents3NotImpl)

public:

	typedef IVsUpdateSolutionEvents3 Interface;

	STDMETHOD(OnBeforeActiveSolutionCfgChange)(
		/*[in]*/ IVsCfg* /*pOldActiveSlnCfg*/,
		/*[in]*/ IVsCfg* /*pNewActiveSlnCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterActiveSolutionCfgChange)(
		/*[in]*/ IVsCfg* /*pOldActiveSlnCfg*/,
		/*[in]*/ IVsCfg* /*pNewActiveSlnCfg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUpdateSolutionEvents3MockImpl :
	public IVsUpdateSolutionEvents3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUpdateSolutionEvents3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUpdateSolutionEvents3MockImpl)

	typedef IVsUpdateSolutionEvents3 Interface;
	struct OnBeforeActiveSolutionCfgChangeValidValues
	{
		/*[in]*/ IVsCfg* pOldActiveSlnCfg;
		/*[in]*/ IVsCfg* pNewActiveSlnCfg;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeActiveSolutionCfgChange)(
		/*[in]*/ IVsCfg* pOldActiveSlnCfg,
		/*[in]*/ IVsCfg* pNewActiveSlnCfg)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeActiveSolutionCfgChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOldActiveSlnCfg);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNewActiveSlnCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterActiveSolutionCfgChangeValidValues
	{
		/*[in]*/ IVsCfg* pOldActiveSlnCfg;
		/*[in]*/ IVsCfg* pNewActiveSlnCfg;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterActiveSolutionCfgChange)(
		/*[in]*/ IVsCfg* pOldActiveSlnCfg,
		/*[in]*/ IVsCfg* pNewActiveSlnCfg)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterActiveSolutionCfgChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOldActiveSlnCfg);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNewActiveSlnCfg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUPDATESOLUTIONEVENTS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
