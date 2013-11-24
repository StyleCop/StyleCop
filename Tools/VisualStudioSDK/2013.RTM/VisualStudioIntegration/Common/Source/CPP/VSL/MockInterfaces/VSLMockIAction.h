/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "undoredo.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IActionNotImpl :
	public IAction
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActionNotImpl)

public:

	typedef IAction Interface;

	STDMETHOD(GetName)(
		/*[in]*/ BSTR* /*bstrName*/,
		/*[in]*/ BOOL /*fLongName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[in]*/ long* /*piSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Undo)(
		/*[in]*/ IUnknown* /*pObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Redo)(
		/*[in]*/ IUnknown* /*pObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Abort)(
		/*[in]*/ IUnknown* /*pObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddSibling)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNextSibling)(
		/*[in]*/ IAction** /*ppAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddChild)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFirstChild)(
		/*[in]*/ IAction** /*ppAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanMerge)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Merge)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL
};

class IActionMockImpl :
	public IAction,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IActionMockImpl)

	typedef IAction Interface;
	struct GetNameValidValues
	{
		/*[in]*/ BSTR* bstrName;
		/*[in]*/ BOOL fLongName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[in]*/ BSTR* bstrName,
		/*[in]*/ BOOL fLongName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_CHECK_VALIDVALUE_POINTER(bstrName);

		VSL_CHECK_VALIDVALUE(fLongName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[in]*/ long* piSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[in]*/ long* piSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_CHECK_VALIDVALUE_POINTER(piSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct UndoValidValues
	{
		/*[in]*/ IUnknown* pObject;
		HRESULT retValue;
	};

	STDMETHOD(Undo)(
		/*[in]*/ IUnknown* pObject)
	{
		VSL_DEFINE_MOCK_METHOD(Undo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct RedoValidValues
	{
		/*[in]*/ IUnknown* pObject;
		HRESULT retValue;
	};

	STDMETHOD(Redo)(
		/*[in]*/ IUnknown* pObject)
	{
		VSL_DEFINE_MOCK_METHOD(Redo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct AbortValidValues
	{
		/*[in]*/ IUnknown* pObject;
		HRESULT retValue;
	};

	STDMETHOD(Abort)(
		/*[in]*/ IUnknown* pObject)
	{
		VSL_DEFINE_MOCK_METHOD(Abort)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddSiblingValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(AddSibling)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(AddSibling)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNextSiblingValidValues
	{
		/*[in]*/ IAction** ppAction;
		HRESULT retValue;
	};

	STDMETHOD(GetNextSibling)(
		/*[in]*/ IAction** ppAction)
	{
		VSL_DEFINE_MOCK_METHOD(GetNextSibling)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddChildValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(AddChild)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(AddChild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFirstChildValidValues
	{
		/*[in]*/ IAction** ppAction;
		HRESULT retValue;
	};

	STDMETHOD(GetFirstChild)(
		/*[in]*/ IAction** ppAction)
	{
		VSL_DEFINE_MOCK_METHOD(GetFirstChild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanMergeValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(CanMerge)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(CanMerge)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct MergeValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(Merge)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(Merge)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IACTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
