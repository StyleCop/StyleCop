/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCCONTROLNEWSOLUTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCCONTROLNEWSOLUTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccControlNewSolution.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccControlNewSolutionNotImpl :
	public IVsSccControlNewSolution
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccControlNewSolutionNotImpl)

public:

	typedef IVsSccControlNewSolution Interface;

	STDMETHOD(AddNewSolutionToSourceControl)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayStringForAction)(
		/*[out]*/ BSTR* /*pbstrActionName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccControlNewSolutionMockImpl :
	public IVsSccControlNewSolution,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccControlNewSolutionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccControlNewSolutionMockImpl)

	typedef IVsSccControlNewSolution Interface;
	struct AddNewSolutionToSourceControlValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AddNewSolutionToSourceControl)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AddNewSolutionToSourceControl)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayStringForActionValidValues
	{
		/*[out]*/ BSTR* pbstrActionName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayStringForAction)(
		/*[out]*/ BSTR* pbstrActionName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayStringForAction)

		VSL_SET_VALIDVALUE_BSTR(pbstrActionName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCCONTROLNEWSOLUTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
