/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleUndoManagerNotImpl :
	public IOleUndoManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleUndoManagerNotImpl)

public:

	typedef IOleUndoManager Interface;

	STDMETHOD(Open)(
		/*[in]*/ IOleParentUndoUnit* /*pPUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ IOleParentUndoUnit* /*pPUU*/,
		/*[in]*/ BOOL /*fCommit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Add)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOpenParentState)(
		/*[out]*/ DWORD* /*pdwState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiscardFrom)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UndoTo)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RedoTo)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumUndoable)(
		/*[out]*/ IEnumOleUndoUnits** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumRedoable)(
		/*[out]*/ IEnumOleUndoUnits** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastUndoDescription)(
		/*[out]*/ BSTR* /*pBstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastRedoDescription)(
		/*[out]*/ BSTR* /*pBstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Enable)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL
};

class IOleUndoManagerMockImpl :
	public IOleUndoManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleUndoManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleUndoManagerMockImpl)

	typedef IOleUndoManager Interface;
	struct OpenValidValues
	{
		/*[in]*/ IOleParentUndoUnit* pPUU;
		HRESULT retValue;
	};

	STDMETHOD(Open)(
		/*[in]*/ IOleParentUndoUnit* pPUU)
	{
		VSL_DEFINE_MOCK_METHOD(Open)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		/*[in]*/ IOleParentUndoUnit* pPUU;
		/*[in]*/ BOOL fCommit;
		HRESULT retValue;
	};

	STDMETHOD(Close)(
		/*[in]*/ IOleParentUndoUnit* pPUU,
		/*[in]*/ BOOL fCommit)
	{
		VSL_DEFINE_MOCK_METHOD(Close)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPUU);

		VSL_CHECK_VALIDVALUE(fCommit);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddValidValues
	{
		/*[in]*/ IOleUndoUnit* pUU;
		HRESULT retValue;
	};

	STDMETHOD(Add)(
		/*[in]*/ IOleUndoUnit* pUU)
	{
		VSL_DEFINE_MOCK_METHOD(Add)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOpenParentStateValidValues
	{
		/*[out]*/ DWORD* pdwState;
		HRESULT retValue;
	};

	STDMETHOD(GetOpenParentState)(
		/*[out]*/ DWORD* pdwState)
	{
		VSL_DEFINE_MOCK_METHOD(GetOpenParentState)

		VSL_SET_VALIDVALUE(pdwState);

		VSL_RETURN_VALIDVALUES();
	}
	struct DiscardFromValidValues
	{
		/*[in]*/ IOleUndoUnit* pUU;
		HRESULT retValue;
	};

	STDMETHOD(DiscardFrom)(
		/*[in]*/ IOleUndoUnit* pUU)
	{
		VSL_DEFINE_MOCK_METHOD(DiscardFrom)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct UndoToValidValues
	{
		/*[in]*/ IOleUndoUnit* pUU;
		HRESULT retValue;
	};

	STDMETHOD(UndoTo)(
		/*[in]*/ IOleUndoUnit* pUU)
	{
		VSL_DEFINE_MOCK_METHOD(UndoTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct RedoToValidValues
	{
		/*[in]*/ IOleUndoUnit* pUU;
		HRESULT retValue;
	};

	STDMETHOD(RedoTo)(
		/*[in]*/ IOleUndoUnit* pUU)
	{
		VSL_DEFINE_MOCK_METHOD(RedoTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumUndoableValidValues
	{
		/*[out]*/ IEnumOleUndoUnits** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumUndoable)(
		/*[out]*/ IEnumOleUndoUnits** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumUndoable)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumRedoableValidValues
	{
		/*[out]*/ IEnumOleUndoUnits** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumRedoable)(
		/*[out]*/ IEnumOleUndoUnits** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumRedoable)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastUndoDescriptionValidValues
	{
		/*[out]*/ BSTR* pBstr;
		HRESULT retValue;
	};

	STDMETHOD(GetLastUndoDescription)(
		/*[out]*/ BSTR* pBstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastUndoDescription)

		VSL_SET_VALIDVALUE_BSTR(pBstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastRedoDescriptionValidValues
	{
		/*[out]*/ BSTR* pBstr;
		HRESULT retValue;
	};

	STDMETHOD(GetLastRedoDescription)(
		/*[out]*/ BSTR* pBstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastRedoDescription)

		VSL_SET_VALIDVALUE_BSTR(pBstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableValidValues
	{
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(Enable)(
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(Enable)

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEUNDOMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
