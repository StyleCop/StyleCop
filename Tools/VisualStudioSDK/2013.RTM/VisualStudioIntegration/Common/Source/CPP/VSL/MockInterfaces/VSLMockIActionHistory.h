/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IACTIONHISTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IACTIONHISTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IActionHistoryNotImpl :
	public IActionHistory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActionHistoryNotImpl)

public:

	typedef IActionHistory Interface;

	STDMETHOD(RecordAction)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenAction)(
		/*[in]*/ IAction* /*pAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseAction)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AbortAction)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanUndo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanRedo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Undo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Redo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumUndoActions)(
		/*[in]*/ IEnumActions** /*ppEnumUndoActions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumRedoActions)(
		/*[in]*/ IEnumActions** /*ppEnumRedoActions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL
};

class IActionHistoryMockImpl :
	public IActionHistory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IActionHistoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IActionHistoryMockImpl)

	typedef IActionHistory Interface;
	struct RecordActionValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(RecordAction)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(RecordAction)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenActionValidValues
	{
		/*[in]*/ IAction* pAction;
		HRESULT retValue;
	};

	STDMETHOD(OpenAction)(
		/*[in]*/ IAction* pAction)
	{
		VSL_DEFINE_MOCK_METHOD(OpenAction)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseActionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CloseAction)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CloseAction)

		VSL_RETURN_VALIDVALUES();
	}
	struct AbortActionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AbortAction)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AbortAction)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanUndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanUndo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanUndo)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanRedoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanRedo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanRedo)

		VSL_RETURN_VALIDVALUES();
	}
	struct UndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Undo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Undo)

		VSL_RETURN_VALIDVALUES();
	}
	struct RedoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Redo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Redo)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumUndoActionsValidValues
	{
		/*[in]*/ IEnumActions** ppEnumUndoActions;
		HRESULT retValue;
	};

	STDMETHOD(EnumUndoActions)(
		/*[in]*/ IEnumActions** ppEnumUndoActions)
	{
		VSL_DEFINE_MOCK_METHOD(EnumUndoActions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppEnumUndoActions);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumRedoActionsValidValues
	{
		/*[in]*/ IEnumActions** ppEnumRedoActions;
		HRESULT retValue;
	};

	STDMETHOD(EnumRedoActions)(
		/*[in]*/ IEnumActions** ppEnumRedoActions)
	{
		VSL_DEFINE_MOCK_METHOD(EnumRedoActions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ppEnumRedoActions);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IACTIONHISTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
