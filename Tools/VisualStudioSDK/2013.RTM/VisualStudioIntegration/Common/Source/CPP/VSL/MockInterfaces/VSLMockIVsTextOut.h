/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextOutNotImpl :
	public IVsTextOut
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextOutNotImpl)

public:

	typedef IVsTextOut Interface;

	STDMETHOD(VsGetTextExtent)(
		/*[in]*/ DWORD_PTR /*hdc*/,
		/*[in]*/ int /*cch*/,
		/*[in,size_is(cch)]*/ LPCOLESTR /*pText*/,
		/*[out,retval]*/ SIZE* /*pSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(VsTextOut)(
		/*[in]*/ DWORD_PTR /*hdc*/,
		/*[in]*/ int /*cch*/,
		/*[in,size_is(cch)]*/ LPCOLESTR /*pText*/,
		/*[in]*/ DWORD /*grfETO*/,
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ const RECT* /*prc*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextOutMockImpl :
	public IVsTextOut,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextOutMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextOutMockImpl)

	typedef IVsTextOut Interface;
	struct VsGetTextExtentValidValues
	{
		/*[in]*/ DWORD_PTR hdc;
		/*[in]*/ int cch;
		/*[in,size_is(cch)]*/ LPCOLESTR pText;
		/*[out,retval]*/ SIZE* pSize;
		HRESULT retValue;
	};

	STDMETHOD(VsGetTextExtent)(
		/*[in]*/ DWORD_PTR hdc,
		/*[in]*/ int cch,
		/*[in,size_is(cch)]*/ LPCOLESTR pText,
		/*[out,retval]*/ SIZE* pSize)
	{
		VSL_DEFINE_MOCK_METHOD(VsGetTextExtent)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE_STRINGW(pText);

		VSL_SET_VALIDVALUE(pSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct VsTextOutValidValues
	{
		/*[in]*/ DWORD_PTR hdc;
		/*[in]*/ int cch;
		/*[in,size_is(cch)]*/ LPCOLESTR pText;
		/*[in]*/ DWORD grfETO;
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ RECT* prc;
		HRESULT retValue;
	};

	STDMETHOD(VsTextOut)(
		/*[in]*/ DWORD_PTR hdc,
		/*[in]*/ int cch,
		/*[in,size_is(cch)]*/ LPCOLESTR pText,
		/*[in]*/ DWORD grfETO,
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ const RECT* prc)
	{
		VSL_DEFINE_MOCK_METHOD(VsTextOut)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE_STRINGW(pText);

		VSL_CHECK_VALIDVALUE(grfETO);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE_POINTER(prc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTOUT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
