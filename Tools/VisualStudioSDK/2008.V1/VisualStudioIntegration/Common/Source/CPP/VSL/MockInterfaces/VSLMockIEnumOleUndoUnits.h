/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IENUMOLEUNDOUNITS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IENUMOLEUNDOUNITS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IEnumOleUndoUnitsNotImpl :
	public IEnumOleUndoUnits
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumOleUndoUnitsNotImpl)

public:

	typedef IEnumOleUndoUnits Interface;

	STDMETHOD(Next)(
		/*[in]*/ ULONG /*cElt*/,
		/*[out,size_is(cElt),length_is(*pcEltFetched)]*/ IOleUndoUnit** /*rgElt*/,
		/*[out]*/ ULONG* /*pcEltFetched*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Skip)(
		/*[in]*/ ULONG /*cElt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[out]*/ IEnumOleUndoUnits** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IEnumOleUndoUnitsMockImpl :
	public IEnumOleUndoUnits,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEnumOleUndoUnitsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEnumOleUndoUnitsMockImpl)

	typedef IEnumOleUndoUnits Interface;
	struct NextValidValues
	{
		/*[in]*/ ULONG cElt;
		/*[out,size_is(cElt),length_is(*pcEltFetched)]*/ IOleUndoUnit** rgElt;
		/*[out]*/ ULONG* pcEltFetched;
		HRESULT retValue;
	};

	STDMETHOD(Next)(
		/*[in]*/ ULONG cElt,
		/*[out,size_is(cElt),length_is(*pcEltFetched)]*/ IOleUndoUnit** rgElt,
		/*[out]*/ ULONG* pcEltFetched)
	{
		VSL_DEFINE_MOCK_METHOD(Next)

		VSL_CHECK_VALIDVALUE(cElt);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgElt, cElt, *(validValues.pcEltFetched));

		VSL_SET_VALIDVALUE(pcEltFetched);

		VSL_RETURN_VALIDVALUES();
	}
	struct SkipValidValues
	{
		/*[in]*/ ULONG cElt;
		HRESULT retValue;
	};

	STDMETHOD(Skip)(
		/*[in]*/ ULONG cElt)
	{
		VSL_DEFINE_MOCK_METHOD(Skip)

		VSL_CHECK_VALIDVALUE(cElt);

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
	struct CloneValidValues
	{
		/*[out]*/ IEnumOleUndoUnits** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[out]*/ IEnumOleUndoUnits** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IENUMOLEUNDOUNITS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
