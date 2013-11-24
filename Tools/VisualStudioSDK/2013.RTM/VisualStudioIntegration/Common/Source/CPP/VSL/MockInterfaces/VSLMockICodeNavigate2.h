/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICODENAVIGATE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICODENAVIGATE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "designer.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ICodeNavigate2NotImpl :
	public ICodeNavigate2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICodeNavigate2NotImpl)

public:

	typedef ICodeNavigate2 Interface;

	STDMETHOD(DisplayEventHandler)(
		/*[in]*/ LPCOLESTR /*lpstrObjectName*/,
		/*[in]*/ LPCOLESTR /*lpstrEventName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayDefaultEventHandler)(
		/*[in]*/ LPCOLESTR /*lpstrObjectName*/)VSL_STDMETHOD_NOTIMPL
};

class ICodeNavigate2MockImpl :
	public ICodeNavigate2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICodeNavigate2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICodeNavigate2MockImpl)

	typedef ICodeNavigate2 Interface;
	struct DisplayEventHandlerValidValues
	{
		/*[in]*/ LPCOLESTR lpstrObjectName;
		/*[in]*/ LPCOLESTR lpstrEventName;
		HRESULT retValue;
	};

	STDMETHOD(DisplayEventHandler)(
		/*[in]*/ LPCOLESTR lpstrObjectName,
		/*[in]*/ LPCOLESTR lpstrEventName)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayEventHandler)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrEventName);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayDefaultEventHandlerValidValues
	{
		/*[in]*/ LPCOLESTR lpstrObjectName;
		HRESULT retValue;
	};

	STDMETHOD(DisplayDefaultEventHandler)(
		/*[in]*/ LPCOLESTR lpstrObjectName)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayDefaultEventHandler)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrObjectName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICODENAVIGATE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
