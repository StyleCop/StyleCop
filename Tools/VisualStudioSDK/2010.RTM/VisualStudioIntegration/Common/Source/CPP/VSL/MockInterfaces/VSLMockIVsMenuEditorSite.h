/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMENUEDITORSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMENUEDITORSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMenuEditorSiteNotImpl :
	public IVsMenuEditorSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuEditorSiteNotImpl)

public:

	typedef IVsMenuEditorSite Interface;

	STDMETHOD(CreateItem)(
		/*[in]*/ IVsMenuItem* /*pIMIParent*/,
		/*[in]*/ IVsMenuItem* /*pIMIInsertAfter*/,
		/*[out]*/ IVsMenuItem** /*ppIMINew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteItem)(
		/*[in]*/ IVsMenuItem* /*pIMI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MoveItems)(
		/*[in]*/ IVsMenuItem* /*pIMIFirst*/,
		/*[in]*/ IVsMenuItem* /*pIMILast*/,
		/*[in]*/ IVsMenuItem* /*pIMIParent*/,
		/*[in]*/ IVsMenuItem* /*pIMIInsertAfter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectionChange)(
		/*[in]*/ IVsMenuItem** /*ppIMI*/,
		/*[in]*/ VSMESELCMD /*SelCmd*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMenuEditorSiteMockImpl :
	public IVsMenuEditorSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuEditorSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMenuEditorSiteMockImpl)

	typedef IVsMenuEditorSite Interface;
	struct CreateItemValidValues
	{
		/*[in]*/ IVsMenuItem* pIMIParent;
		/*[in]*/ IVsMenuItem* pIMIInsertAfter;
		/*[out]*/ IVsMenuItem** ppIMINew;
		HRESULT retValue;
	};

	STDMETHOD(CreateItem)(
		/*[in]*/ IVsMenuItem* pIMIParent,
		/*[in]*/ IVsMenuItem* pIMIInsertAfter,
		/*[out]*/ IVsMenuItem** ppIMINew)
	{
		VSL_DEFINE_MOCK_METHOD(CreateItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIParent);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIInsertAfter);

		VSL_SET_VALIDVALUE_INTERFACE(ppIMINew);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteItemValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		HRESULT retValue;
	};

	STDMETHOD(DeleteItem)(
		/*[in]*/ IVsMenuItem* pIMI)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_RETURN_VALIDVALUES();
	}
	struct MoveItemsValidValues
	{
		/*[in]*/ IVsMenuItem* pIMIFirst;
		/*[in]*/ IVsMenuItem* pIMILast;
		/*[in]*/ IVsMenuItem* pIMIParent;
		/*[in]*/ IVsMenuItem* pIMIInsertAfter;
		HRESULT retValue;
	};

	STDMETHOD(MoveItems)(
		/*[in]*/ IVsMenuItem* pIMIFirst,
		/*[in]*/ IVsMenuItem* pIMILast,
		/*[in]*/ IVsMenuItem* pIMIParent,
		/*[in]*/ IVsMenuItem* pIMIInsertAfter)
	{
		VSL_DEFINE_MOCK_METHOD(MoveItems)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIFirst);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMILast);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIParent);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIInsertAfter);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectionChangeValidValues
	{
		/*[in]*/ IVsMenuItem** ppIMI;
		/*[in]*/ VSMESELCMD SelCmd;
		HRESULT retValue;
	};

	STDMETHOD(SelectionChange)(
		/*[in]*/ IVsMenuItem** ppIMI,
		/*[in]*/ VSMESELCMD SelCmd)
	{
		VSL_DEFINE_MOCK_METHOD(SelectionChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppIMI);

		VSL_CHECK_VALIDVALUE(SelCmd);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMENUEDITORSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
