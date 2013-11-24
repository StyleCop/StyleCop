/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTBUFFERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTBUFFERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextBufferProviderNotImpl :
	public IVsTextBufferProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferProviderNotImpl)

public:

	typedef IVsTextBufferProvider Interface;

	STDMETHOD(GetTextBuffer)(
		/*[out]*/ IVsTextLines** /*ppTextBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTextBuffer)(
		/*[in]*/ IVsTextLines* /*pTextBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockTextBuffer)(
		/*[in]*/ BOOL /*fLock*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextBufferProviderMockImpl :
	public IVsTextBufferProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextBufferProviderMockImpl)

	typedef IVsTextBufferProvider Interface;
	struct GetTextBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppTextBuffer;
		HRESULT retValue;
	};

	STDMETHOD(GetTextBuffer)(
		/*[out]*/ IVsTextLines** ppTextBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppTextBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTextBufferValidValues
	{
		/*[in]*/ IVsTextLines* pTextBuffer;
		HRESULT retValue;
	};

	STDMETHOD(SetTextBuffer)(
		/*[in]*/ IVsTextLines* pTextBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(SetTextBuffer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockTextBufferValidValues
	{
		/*[in]*/ BOOL fLock;
		HRESULT retValue;
	};

	STDMETHOD(LockTextBuffer)(
		/*[in]*/ BOOL fLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockTextBuffer)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTBUFFERPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
