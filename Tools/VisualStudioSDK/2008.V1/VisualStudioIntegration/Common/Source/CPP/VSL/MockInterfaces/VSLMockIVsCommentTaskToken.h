/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMENTTASKTOKEN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMENTTASKTOKEN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCommentTaskTokenNotImpl :
	public IVsCommentTaskToken
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommentTaskTokenNotImpl)

public:

	typedef IVsCommentTaskToken Interface;

	STDMETHOD(get_Text)(
		/*[out,retval]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Priority)(
		/*[out,retval]*/ VSTASKPRIORITY* /*ptpPriority*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCommentTaskTokenMockImpl :
	public IVsCommentTaskToken,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommentTaskTokenMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommentTaskTokenMockImpl)

	typedef IVsCommentTaskToken Interface;
	struct get_TextValidValues
	{
		/*[out,retval]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(get_Text)(
		/*[out,retval]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(get_Text)

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PriorityValidValues
	{
		/*[out,retval]*/ VSTASKPRIORITY* ptpPriority;
		HRESULT retValue;
	};

	STDMETHOD(get_Priority)(
		/*[out,retval]*/ VSTASKPRIORITY* ptpPriority)
	{
		VSL_DEFINE_MOCK_METHOD(get_Priority)

		VSL_SET_VALIDVALUE(ptpPriority);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMENTTASKTOKEN_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
