/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTIMAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTIMAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextImage2NotImpl :
	public IVsTextImage2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImage2NotImpl)

public:

	typedef IVsTextImage2 Interface;

	STDMETHOD(GetEolTypeEx)(
		/*[in]*/ const LINEDATAEX* /*pld*/,
		/*[out]*/ DWORD* /*piEolType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEolLengthEx)(
		/*[in]*/ const LINEDATAEX* /*pld*/,
		/*[out]*/ unsigned int* /*piEolType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEolTextEx)(
		/*[in]*/ const LINEDATAEX* /*pld*/,
		/*[out]*/ BSTR* /*pbstrEolText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextImage2MockImpl :
	public IVsTextImage2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImage2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextImage2MockImpl)

	typedef IVsTextImage2 Interface;
	struct GetEolTypeExValidValues
	{
		/*[in]*/ LINEDATAEX* pld;
		/*[out]*/ DWORD* piEolType;
		HRESULT retValue;
	};

	STDMETHOD(GetEolTypeEx)(
		/*[in]*/ const LINEDATAEX* pld,
		/*[out]*/ DWORD* piEolType)
	{
		VSL_DEFINE_MOCK_METHOD(GetEolTypeEx)

		VSL_CHECK_VALIDVALUE_POINTER(pld);

		VSL_SET_VALIDVALUE(piEolType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEolLengthExValidValues
	{
		/*[in]*/ LINEDATAEX* pld;
		/*[out]*/ unsigned int* piEolType;
		HRESULT retValue;
	};

	STDMETHOD(GetEolLengthEx)(
		/*[in]*/ const LINEDATAEX* pld,
		/*[out]*/ unsigned int* piEolType)
	{
		VSL_DEFINE_MOCK_METHOD(GetEolLengthEx)

		VSL_CHECK_VALIDVALUE_POINTER(pld);

		VSL_SET_VALIDVALUE(piEolType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEolTextExValidValues
	{
		/*[in]*/ LINEDATAEX* pld;
		/*[out]*/ BSTR* pbstrEolText;
		HRESULT retValue;
	};

	STDMETHOD(GetEolTextEx)(
		/*[in]*/ const LINEDATAEX* pld,
		/*[out]*/ BSTR* pbstrEolText)
	{
		VSL_DEFINE_MOCK_METHOD(GetEolTextEx)

		VSL_CHECK_VALIDVALUE_POINTER(pld);

		VSL_SET_VALIDVALUE_BSTR(pbstrEolText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTIMAGE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
