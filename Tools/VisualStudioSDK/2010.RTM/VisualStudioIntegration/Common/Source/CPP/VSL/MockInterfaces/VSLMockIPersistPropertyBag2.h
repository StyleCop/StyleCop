/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IPersistPropertyBag2NotImpl :
	public IPersistPropertyBag2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistPropertyBag2NotImpl)

public:

	typedef IPersistPropertyBag2 Interface;

	STDMETHOD(InitNew)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in]*/ IPropertyBag2* /*pPropBag*/,
		/*[in]*/ IErrorLog* /*pErrLog*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in]*/ IPropertyBag2* /*pPropBag*/,
		/*[in]*/ BOOL /*fClearDirty*/,
		/*[in]*/ BOOL /*fSaveAllProperties*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistPropertyBag2MockImpl :
	public IPersistPropertyBag2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistPropertyBag2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistPropertyBag2MockImpl)

	typedef IPersistPropertyBag2 Interface;
	struct InitNewValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(InitNew)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(InitNew)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in]*/ IPropertyBag2* pPropBag;
		/*[in]*/ IErrorLog* pErrLog;
		HRESULT retValue;
	};

	STDMETHOD(Load)(
		/*[in]*/ IPropertyBag2* pPropBag,
		/*[in]*/ IErrorLog* pErrLog)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPropBag);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrLog);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in]*/ IPropertyBag2* pPropBag;
		/*[in]*/ BOOL fClearDirty;
		/*[in]*/ BOOL fSaveAllProperties;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in]*/ IPropertyBag2* pPropBag,
		/*[in]*/ BOOL fClearDirty,
		/*[in]*/ BOOL fSaveAllProperties)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPropBag);

		VSL_CHECK_VALIDVALUE(fClearDirty);

		VSL_CHECK_VALIDVALUE(fSaveAllProperties);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassIDValidValues
	{
		/*[out]*/ CLSID* pClassID;
		HRESULT retValue;
	};

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* pClassID)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassID)

		VSL_SET_VALIDVALUE(pClassID);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERSISTPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
