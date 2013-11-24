/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISELECTIONCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISELECTIONCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISelectionContainerNotImpl :
	public ISelectionContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISelectionContainerNotImpl)

public:

	typedef ISelectionContainer Interface;

	STDMETHOD(CountObjects)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ ULONG* /*pc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetObjects)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ ULONG /*cObjects*/,
		/*[out,size_is(cObjects)]*/ IUnknown** /*apUnkObjects*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectObjects)(
		/*[in]*/ ULONG /*cSelect*/,
		/*[in,size_is(cSelect)]*/ IUnknown** /*apUnkSelect*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL
};

class ISelectionContainerMockImpl :
	public ISelectionContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISelectionContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISelectionContainerMockImpl)

	typedef ISelectionContainer Interface;
	struct CountObjectsValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ ULONG* pc;
		HRESULT retValue;
	};

	STDMETHOD(CountObjects)(
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ ULONG* pc)
	{
		VSL_DEFINE_MOCK_METHOD(CountObjects)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE(pc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetObjectsValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ ULONG cObjects;
		/*[out,size_is(cObjects)]*/ IUnknown** apUnkObjects;
		HRESULT retValue;
	};

	STDMETHOD(GetObjects)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ ULONG cObjects,
		/*[out,size_is(cObjects)]*/ IUnknown** apUnkObjects)
	{
		VSL_DEFINE_MOCK_METHOD(GetObjects)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(cObjects);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(apUnkObjects, cObjects, validValues.cObjects);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectObjectsValidValues
	{
		/*[in]*/ ULONG cSelect;
		/*[in,size_is(cSelect)]*/ IUnknown** apUnkSelect;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(SelectObjects)(
		/*[in]*/ ULONG cSelect,
		/*[in,size_is(cSelect)]*/ IUnknown** apUnkSelect,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SelectObjects)

		VSL_CHECK_VALIDVALUE(cSelect);

		VSL_CHECK_VALIDVALUE_ARRAY(apUnkSelect, cSelect, validValues.cSelect);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISELECTIONCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
