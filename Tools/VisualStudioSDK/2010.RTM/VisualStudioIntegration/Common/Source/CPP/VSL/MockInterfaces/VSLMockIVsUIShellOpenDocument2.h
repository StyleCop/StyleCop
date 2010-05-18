/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUISHELLOPENDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUISHELLOPENDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIShellOpenDocument2NotImpl :
	public IVsUIShellOpenDocument2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellOpenDocument2NotImpl)

public:

	typedef IVsUIShellOpenDocument2 Interface;

	STDMETHOD(GetDefaultPreviewers)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ VSDEFAULTPREVIEWER[] /*rgDefaultPreviewers*/,
		/*[out]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIShellOpenDocument2MockImpl :
	public IVsUIShellOpenDocument2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellOpenDocument2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIShellOpenDocument2MockImpl)

	typedef IVsUIShellOpenDocument2 Interface;
	struct GetDefaultPreviewersValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ VSDEFAULTPREVIEWER* rgDefaultPreviewers;
		/*[out]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultPreviewers)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ VSDEFAULTPREVIEWER rgDefaultPreviewers[],
		/*[out]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultPreviewers)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgDefaultPreviewers, celt*sizeof(rgDefaultPreviewers[0]), validValues.celt*sizeof(validValues.rgDefaultPreviewers[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUISHELLOPENDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
