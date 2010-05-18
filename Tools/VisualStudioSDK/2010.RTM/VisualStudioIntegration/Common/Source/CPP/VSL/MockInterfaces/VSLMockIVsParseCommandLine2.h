/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPARSECOMMANDLINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPARSECOMMANDLINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsParseCommandLine2NotImpl :
	public IVsParseCommandLine2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParseCommandLine2NotImpl)

public:

	typedef IVsParseCommandLine2 Interface;

	STDMETHOD(GetACParamOrSwitch)(
		/*[out]*/ int* /*piACIndex*/,
		/*[out]*/ int* /*piACStart*/,
		/*[out]*/ int* /*pcchACLength*/,
		/*[out]*/ BSTR* /*pbstrCurSwitch*/,
		/*[out,retval]*/ BSTR* /*pbstrACParam*/)VSL_STDMETHOD_NOTIMPL
};

class IVsParseCommandLine2MockImpl :
	public IVsParseCommandLine2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsParseCommandLine2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsParseCommandLine2MockImpl)

	typedef IVsParseCommandLine2 Interface;
	struct GetACParamOrSwitchValidValues
	{
		/*[out]*/ int* piACIndex;
		/*[out]*/ int* piACStart;
		/*[out]*/ int* pcchACLength;
		/*[out]*/ BSTR* pbstrCurSwitch;
		/*[out,retval]*/ BSTR* pbstrACParam;
		HRESULT retValue;
	};

	STDMETHOD(GetACParamOrSwitch)(
		/*[out]*/ int* piACIndex,
		/*[out]*/ int* piACStart,
		/*[out]*/ int* pcchACLength,
		/*[out]*/ BSTR* pbstrCurSwitch,
		/*[out,retval]*/ BSTR* pbstrACParam)
	{
		VSL_DEFINE_MOCK_METHOD(GetACParamOrSwitch)

		VSL_SET_VALIDVALUE(piACIndex);

		VSL_SET_VALIDVALUE(piACStart);

		VSL_SET_VALIDVALUE(pcchACLength);

		VSL_SET_VALIDVALUE_BSTR(pbstrCurSwitch);

		VSL_SET_VALIDVALUE_BSTR(pbstrACParam);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPARSECOMMANDLINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
