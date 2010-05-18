/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJECTSEARCHPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJECTSEARCHPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsObjectSearchPaneNotImpl :
	public IVsObjectSearchPane
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectSearchPaneNotImpl)

public:

	typedef IVsObjectSearchPane Interface;

	STDMETHOD(SetResultsList)(
		/*[in]*/ IVsLibrary* /*pLibrary*/,
		/*[in]*/ IVsObjectList* /*pList*/,
		/*[in]*/ VSOBSEARCHFLAGS /*flags*/,
		/*[out]*/ IVsObjectListOwner** /*ppListOwner*/)VSL_STDMETHOD_NOTIMPL
};

class IVsObjectSearchPaneMockImpl :
	public IVsObjectSearchPane,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjectSearchPaneMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjectSearchPaneMockImpl)

	typedef IVsObjectSearchPane Interface;
	struct SetResultsListValidValues
	{
		/*[in]*/ IVsLibrary* pLibrary;
		/*[in]*/ IVsObjectList* pList;
		/*[in]*/ VSOBSEARCHFLAGS flags;
		/*[out]*/ IVsObjectListOwner** ppListOwner;
		HRESULT retValue;
	};

	STDMETHOD(SetResultsList)(
		/*[in]*/ IVsLibrary* pLibrary,
		/*[in]*/ IVsObjectList* pList,
		/*[in]*/ VSOBSEARCHFLAGS flags,
		/*[out]*/ IVsObjectListOwner** ppListOwner)
	{
		VSL_DEFINE_MOCK_METHOD(SetResultsList)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLibrary);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pList);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_SET_VALIDVALUE_INTERFACE(ppListOwner);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJECTSEARCHPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
