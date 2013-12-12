/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYDROPDATATARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYDROPDATATARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyDropDataTargetNotImpl :
	public IVsHierarchyDropDataTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataTargetNotImpl)

public:

	typedef IVsHierarchyDropDataTarget Interface;

	STDMETHOD(DragEnter)(
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*grfKeyState*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in,out]*/ DWORD* /*pdwEffect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DragOver)(
		/*[in]*/ DWORD /*grfKeyState*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in,out]*/ DWORD* /*pdwEffect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DragLeave)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Drop)(
		/*[in]*/ IDataObject* /*pDataObject*/,
		/*[in]*/ DWORD /*grfKeyState*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in,out]*/ DWORD* /*pdwEffect*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyDropDataTargetMockImpl :
	public IVsHierarchyDropDataTarget,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDropDataTargetMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyDropDataTargetMockImpl)

	typedef IVsHierarchyDropDataTarget Interface;
	struct DragEnterValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD grfKeyState;
		/*[in]*/ VSITEMID itemid;
		/*[in,out]*/ DWORD* pdwEffect;
		HRESULT retValue;
	};

	STDMETHOD(DragEnter)(
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD grfKeyState,
		/*[in]*/ VSITEMID itemid,
		/*[in,out]*/ DWORD* pdwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(DragEnter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pdwEffect);

		VSL_RETURN_VALIDVALUES();
	}
	struct DragOverValidValues
	{
		/*[in]*/ DWORD grfKeyState;
		/*[in]*/ VSITEMID itemid;
		/*[in,out]*/ DWORD* pdwEffect;
		HRESULT retValue;
	};

	STDMETHOD(DragOver)(
		/*[in]*/ DWORD grfKeyState,
		/*[in]*/ VSITEMID itemid,
		/*[in,out]*/ DWORD* pdwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(DragOver)

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pdwEffect);

		VSL_RETURN_VALIDVALUES();
	}
	struct DragLeaveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DragLeave)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DragLeave)

		VSL_RETURN_VALIDVALUES();
	}
	struct DropValidValues
	{
		/*[in]*/ IDataObject* pDataObject;
		/*[in]*/ DWORD grfKeyState;
		/*[in]*/ VSITEMID itemid;
		/*[in,out]*/ DWORD* pdwEffect;
		HRESULT retValue;
	};

	STDMETHOD(Drop)(
		/*[in]*/ IDataObject* pDataObject,
		/*[in]*/ DWORD grfKeyState,
		/*[in]*/ VSITEMID itemid,
		/*[in,out]*/ DWORD* pdwEffect)
	{
		VSL_DEFINE_MOCK_METHOD(Drop)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pdwEffect);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYDROPDATATARGET_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
