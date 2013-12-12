/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEPARENTUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEPARENTUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleParentUndoUnitNotImpl :
	public IOleParentUndoUnit
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleParentUndoUnitNotImpl)

public:

	typedef IOleParentUndoUnit Interface;

	STDMETHOD(Open)(
		/*[in]*/ IOleParentUndoUnit* /*pPUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)(
		/*[in]*/ IOleParentUndoUnit* /*pPUU*/,
		/*[in]*/ BOOL /*fCommit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Add)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindUnit)(
		/*[in]*/ IOleUndoUnit* /*pUU*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParentState)(
		/*[out]*/ DWORD* /*pdwState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Do)(
		/*[in]*/ IOleUndoManager* /*pUndoManager*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pBstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUnitType)(
		/*[out]*/ CLSID* /*pClsid*/,
		/*[out]*/ LONG* /*plID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnNextAdd)()VSL_STDMETHOD_NOTIMPL
};

class IOleParentUndoUnitMockImpl :
	public IOleParentUndoUnit,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleParentUndoUnitMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleParentUndoUnitMockImpl)

	typedef IOleParentUndoUnit Interface;
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
	struct FindUnitValidValues
	{
		/*[in]*/ IOleUndoUnit* pUU;
		HRESULT retValue;
	};

	STDMETHOD(FindUnit)(
		/*[in]*/ IOleUndoUnit* pUU)
	{
		VSL_DEFINE_MOCK_METHOD(FindUnit)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUU);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentStateValidValues
	{
		/*[out]*/ DWORD* pdwState;
		HRESULT retValue;
	};

	STDMETHOD(GetParentState)(
		/*[out]*/ DWORD* pdwState)
	{
		VSL_DEFINE_MOCK_METHOD(GetParentState)

		VSL_SET_VALIDVALUE(pdwState);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoValidValues
	{
		/*[in]*/ IOleUndoManager* pUndoManager;
		HRESULT retValue;
	};

	STDMETHOD(Do)(
		/*[in]*/ IOleUndoManager* pUndoManager)
	{
		VSL_DEFINE_MOCK_METHOD(Do)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUndoManager);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pBstr;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pBstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pBstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUnitTypeValidValues
	{
		/*[out]*/ CLSID* pClsid;
		/*[out]*/ LONG* plID;
		HRESULT retValue;
	};

	STDMETHOD(GetUnitType)(
		/*[out]*/ CLSID* pClsid,
		/*[out]*/ LONG* plID)
	{
		VSL_DEFINE_MOCK_METHOD(GetUnitType)

		VSL_SET_VALIDVALUE(pClsid);

		VSL_SET_VALIDVALUE(plID);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnNextAddValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnNextAdd)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnNextAdd)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEPARENTUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
