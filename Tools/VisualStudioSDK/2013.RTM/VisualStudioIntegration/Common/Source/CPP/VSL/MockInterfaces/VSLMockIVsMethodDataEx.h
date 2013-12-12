/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMETHODDATAEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMETHODDATAEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMethodDataExNotImpl :
	public IVsMethodDataEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodDataExNotImpl)

public:

	typedef IVsMethodDataEx Interface;

	STDMETHOD(GetCopyTipText)(
		/*[in]*/ long /*iMethod*/,
		/*[out]*/ BSTR* /*pbstrTipText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMethodDataExMockImpl :
	public IVsMethodDataEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodDataExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMethodDataExMockImpl)

	typedef IVsMethodDataEx Interface;
	struct GetCopyTipTextValidValues
	{
		/*[in]*/ long iMethod;
		/*[out]*/ BSTR* pbstrTipText;
		HRESULT retValue;
	};

	STDMETHOD(GetCopyTipText)(
		/*[in]*/ long iMethod,
		/*[out]*/ BSTR* pbstrTipText)
	{
		VSL_DEFINE_MOCK_METHOD(GetCopyTipText)

		VSL_CHECK_VALIDVALUE(iMethod);

		VSL_SET_VALIDVALUE_BSTR(pbstrTipText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMETHODDATAEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
