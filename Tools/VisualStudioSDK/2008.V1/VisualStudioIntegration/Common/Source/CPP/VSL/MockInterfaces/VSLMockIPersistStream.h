/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPersistStreamNotImpl :
	public IPersistStream
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistStreamNotImpl)

public:

	typedef IPersistStream Interface;

	STDMETHOD(IsDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in,unique]*/ IStream* /*pStm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[in,unique]*/ IStream* /*pStm*/,
		/*[in]*/ BOOL /*fClearDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULARGE_INTEGER* /*pcbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistStreamMockImpl :
	public IPersistStream,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistStreamMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistStreamMockImpl)

	typedef IPersistStream Interface;
	struct IsDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		HRESULT retValue;
	};

	STDMETHOD(Load)(
		/*[in,unique]*/ IStream* pStm)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[in,unique]*/ IStream* pStm;
		/*[in]*/ BOOL fClearDirty;
		HRESULT retValue;
	};

	STDMETHOD(Save)(
		/*[in,unique]*/ IStream* pStm,
		/*[in]*/ BOOL fClearDirty)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStm);

		VSL_CHECK_VALIDVALUE(fClearDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeMaxValidValues
	{
		/*[out]*/ ULARGE_INTEGER* pcbSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULARGE_INTEGER* pcbSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizeMax)

		VSL_SET_VALIDVALUE(pcbSize);

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

#endif // IPERSISTSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
