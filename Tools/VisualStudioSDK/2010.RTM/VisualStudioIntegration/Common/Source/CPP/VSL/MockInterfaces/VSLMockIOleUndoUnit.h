/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleUndoUnitNotImpl :
	public IOleUndoUnit
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleUndoUnitNotImpl)

public:

	typedef IOleUndoUnit Interface;

	STDMETHOD(Do)(
		/*[in]*/ IOleUndoManager* /*pUndoManager*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pBstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUnitType)(
		/*[out]*/ CLSID* /*pClsid*/,
		/*[out]*/ LONG* /*plID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnNextAdd)()VSL_STDMETHOD_NOTIMPL
};

class IOleUndoUnitMockImpl :
	public IOleUndoUnit,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleUndoUnitMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleUndoUnitMockImpl)

	typedef IOleUndoUnit Interface;
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

#endif // IOLEUNDOUNIT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
