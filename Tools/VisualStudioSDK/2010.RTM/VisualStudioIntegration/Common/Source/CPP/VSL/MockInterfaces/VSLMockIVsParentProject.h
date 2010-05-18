/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPARENTPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPARENTPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsParentProjectNotImpl :
	public IVsParentProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentProjectNotImpl)

public:

	typedef IVsParentProject Interface;

	STDMETHOD(OpenChildren)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseChildren)()VSL_STDMETHOD_NOTIMPL
};

class IVsParentProjectMockImpl :
	public IVsParentProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParentProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsParentProjectMockImpl)

	typedef IVsParentProject Interface;
	struct OpenChildrenValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OpenChildren)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OpenChildren)

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseChildrenValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseChildren)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseChildren)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPARENTPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
