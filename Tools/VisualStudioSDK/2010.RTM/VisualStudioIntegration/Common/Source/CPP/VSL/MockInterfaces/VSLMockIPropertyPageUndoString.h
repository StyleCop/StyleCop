/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYPAGEUNDOSTRING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYPAGEUNDOSTRING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ocdesign.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPropertyPageUndoStringNotImpl :
	public IPropertyPageUndoString
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPageUndoStringNotImpl)

public:

	typedef IPropertyPageUndoString Interface;

	STDMETHOD(GetUndoString)(
		/*[out]*/ LPOLESTR* /*ppszUndo*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyPageUndoStringMockImpl :
	public IPropertyPageUndoString,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPageUndoStringMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyPageUndoStringMockImpl)

	typedef IPropertyPageUndoString Interface;
	struct GetUndoStringValidValues
	{
		/*[out]*/ LPOLESTR* ppszUndo;
		HRESULT retValue;
	};

	STDMETHOD(GetUndoString)(
		/*[out]*/ LPOLESTR* ppszUndo)
	{
		VSL_DEFINE_MOCK_METHOD(GetUndoString)

		VSL_SET_VALIDVALUE(ppszUndo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYPAGEUNDOSTRING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
