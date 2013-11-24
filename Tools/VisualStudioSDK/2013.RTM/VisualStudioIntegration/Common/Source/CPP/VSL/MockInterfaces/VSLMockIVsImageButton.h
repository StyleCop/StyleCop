/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSIMAGEBUTTON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSIMAGEBUTTON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsImageButtonNotImpl :
	public IVsImageButton
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsImageButtonNotImpl)

public:

	typedef IVsImageButton Interface;

	STDMETHOD(Draw)(
		/*[in]*/ VSDRAWITEMSTRUCT* /*pDrawItemStruct*/,
		/*[in]*/ BOOL /*fHot*/)VSL_STDMETHOD_NOTIMPL
};

class IVsImageButtonMockImpl :
	public IVsImageButton,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsImageButtonMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsImageButtonMockImpl)

	typedef IVsImageButton Interface;
	struct DrawValidValues
	{
		/*[in]*/ VSDRAWITEMSTRUCT* pDrawItemStruct;
		/*[in]*/ BOOL fHot;
		HRESULT retValue;
	};

	STDMETHOD(Draw)(
		/*[in]*/ VSDRAWITEMSTRUCT* pDrawItemStruct,
		/*[in]*/ BOOL fHot)
	{
		VSL_DEFINE_MOCK_METHOD(Draw)

		VSL_CHECK_VALIDVALUE_POINTER(pDrawItemStruct);

		VSL_CHECK_VALIDVALUE(fHot);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSIMAGEBUTTON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
