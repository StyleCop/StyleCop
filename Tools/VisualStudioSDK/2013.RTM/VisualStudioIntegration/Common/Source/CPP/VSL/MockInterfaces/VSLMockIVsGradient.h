/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSGRADIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSGRADIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsGradientNotImpl :
	public IVsGradient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGradientNotImpl)

public:

	typedef IVsGradient Interface;

	STDMETHOD(DrawGradient)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*gradientRect*/,
		/*[in]*/ RECT* /*sliceRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGradientVector)(
		/*[in]*/ int /*cVector*/,
		/*[in,out,size_is(cVector)]*/ COLORREF* /*rgVector*/)VSL_STDMETHOD_NOTIMPL
};

class IVsGradientMockImpl :
	public IVsGradient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGradientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsGradientMockImpl)

	typedef IVsGradient Interface;
	struct DrawGradientValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* gradientRect;
		/*[in]*/ RECT* sliceRect;
		HRESULT retValue;
	};

	STDMETHOD(DrawGradient)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* gradientRect,
		/*[in]*/ RECT* sliceRect)
	{
		VSL_DEFINE_MOCK_METHOD(DrawGradient)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(gradientRect);

		VSL_CHECK_VALIDVALUE_POINTER(sliceRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGradientVectorValidValues
	{
		/*[in]*/ int cVector;
		/*[in,out,size_is(cVector)]*/ COLORREF* rgVector;
		HRESULT retValue;
	};

	STDMETHOD(GetGradientVector)(
		/*[in]*/ int cVector,
		/*[in,out,size_is(cVector)]*/ COLORREF* rgVector)
	{
		VSL_DEFINE_MOCK_METHOD(GetGradientVector)

		VSL_CHECK_VALIDVALUE(cVector);

		VSL_SET_VALIDVALUE_MEMCPY(rgVector, cVector*sizeof(rgVector[0]), validValues.cVector*sizeof(validValues.rgVector[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSGRADIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
