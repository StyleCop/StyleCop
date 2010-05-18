/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYDELETEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYDELETEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyDeleteHandlerNotImpl :
	public IVsHierarchyDeleteHandler
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDeleteHandlerNotImpl)

public:

	typedef IVsHierarchyDeleteHandler Interface;

	STDMETHOD(QueryDeleteItem)(
		/*[in]*/ VSDELETEITEMOPERATION /*dwDelItemOp*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out,retval]*/ BOOL* /*pfCanDelete*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteItem)(
		/*[in]*/ VSDELETEITEMOPERATION /*dwDelItemOp*/,
		/*[in]*/ VSITEMID /*itemid*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyDeleteHandlerMockImpl :
	public IVsHierarchyDeleteHandler,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDeleteHandlerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyDeleteHandlerMockImpl)

	typedef IVsHierarchyDeleteHandler Interface;
	struct QueryDeleteItemValidValues
	{
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp;
		/*[in]*/ VSITEMID itemid;
		/*[out,retval]*/ BOOL* pfCanDelete;
		HRESULT retValue;
	};

	STDMETHOD(QueryDeleteItem)(
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp,
		/*[in]*/ VSITEMID itemid,
		/*[out,retval]*/ BOOL* pfCanDelete)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDeleteItem)

		VSL_CHECK_VALIDVALUE(dwDelItemOp);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pfCanDelete);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteItemValidValues
	{
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp;
		/*[in]*/ VSITEMID itemid;
		HRESULT retValue;
	};

	STDMETHOD(DeleteItem)(
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp,
		/*[in]*/ VSITEMID itemid)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteItem)

		VSL_CHECK_VALIDVALUE(dwDelItemOp);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYDELETEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
