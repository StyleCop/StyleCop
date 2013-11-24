/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSHORTCUTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSHORTCUTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsShortcutManagerNotImpl :
	public IVsShortcutManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShortcutManagerNotImpl)

public:

	typedef IVsShortcutManager Interface;

	STDMETHOD(CreateItem)(
		/*[in]*/ long /*iShortcutLine*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ LPCOLESTR /*pszBufMoniker*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveItem)(
		/*[in]*/ IVsTextLineMarker* /*pMarker*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteUserOptions)(
		/*[in]*/ IStream* /*pOptionsStream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReadUserOptions)(
		/*[in]*/ IStream* /*pOptionsStream*/)VSL_STDMETHOD_NOTIMPL
};

class IVsShortcutManagerMockImpl :
	public IVsShortcutManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShortcutManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsShortcutManagerMockImpl)

	typedef IVsShortcutManager Interface;
	struct CreateItemValidValues
	{
		/*[in]*/ long iShortcutLine;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ LPCOLESTR pszBufMoniker;
		HRESULT retValue;
	};

	STDMETHOD(CreateItem)(
		/*[in]*/ long iShortcutLine,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ LPCOLESTR pszBufMoniker)
	{
		VSL_DEFINE_MOCK_METHOD(CreateItem)

		VSL_CHECK_VALIDVALUE(iShortcutLine);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBufMoniker);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveItemValidValues
	{
		/*[in]*/ IVsTextLineMarker* pMarker;
		HRESULT retValue;
	};

	STDMETHOD(RemoveItem)(
		/*[in]*/ IVsTextLineMarker* pMarker)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMarker);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteUserOptionsValidValues
	{
		/*[in]*/ IStream* pOptionsStream;
		HRESULT retValue;
	};

	STDMETHOD(WriteUserOptions)(
		/*[in]*/ IStream* pOptionsStream)
	{
		VSL_DEFINE_MOCK_METHOD(WriteUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOptionsStream);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadUserOptionsValidValues
	{
		/*[in]*/ IStream* pOptionsStream;
		HRESULT retValue;
	};

	STDMETHOD(ReadUserOptions)(
		/*[in]*/ IStream* pOptionsStream)
	{
		VSL_DEFINE_MOCK_METHOD(ReadUserOptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOptionsStream);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSHORTCUTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
