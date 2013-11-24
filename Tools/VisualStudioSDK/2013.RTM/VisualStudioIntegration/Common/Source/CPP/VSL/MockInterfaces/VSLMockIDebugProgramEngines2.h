/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAMENGINES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAMENGINES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugProgramEngines2NotImpl :
	public IDebugProgramEngines2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramEngines2NotImpl)

public:

	typedef IDebugProgramEngines2 Interface;

	STDMETHOD(EnumPossibleEngines)(
		/*[in]*/ DWORD /*celtBuffer*/,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEngines)]*/ GUID* /*rgguidEngines*/,
		/*[in,out]*/ DWORD* /*pceltEngines*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEngine)(
		/*[in]*/ REFGUID /*guidEngine*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProgramEngines2MockImpl :
	public IDebugProgramEngines2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramEngines2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgramEngines2MockImpl)

	typedef IDebugProgramEngines2 Interface;
	struct EnumPossibleEnginesValidValues
	{
		/*[in]*/ DWORD celtBuffer;
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEngines)]*/ GUID* rgguidEngines;
		/*[in,out]*/ DWORD* pceltEngines;
		HRESULT retValue;
	};

	STDMETHOD(EnumPossibleEngines)(
		/*[in]*/ DWORD celtBuffer,
		/*[in,out,ptr,size_is(celtBuffer),length_is(*pceltEngines)]*/ GUID* rgguidEngines,
		/*[in,out]*/ DWORD* pceltEngines)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPossibleEngines)

		VSL_CHECK_VALIDVALUE(celtBuffer);

		VSL_SET_VALIDVALUE_MEMCPY(rgguidEngines, celtBuffer*sizeof(rgguidEngines[0]), *(validValues.pceltEngines)*sizeof(validValues.rgguidEngines[0]));

		VSL_SET_VALIDVALUE(pceltEngines);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEngineValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		HRESULT retValue;
	};

	STDMETHOD(SetEngine)(
		/*[in]*/ REFGUID guidEngine)
	{
		VSL_DEFINE_MOCK_METHOD(SetEngine)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAMENGINES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
