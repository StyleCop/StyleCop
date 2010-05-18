/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLIBRARYREFERENCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLIBRARYREFERENCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLibraryReferenceManagerNotImpl :
	public IVsLibraryReferenceManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryReferenceManagerNotImpl)

public:

	typedef IVsLibraryReferenceManager Interface;

	STDMETHOD(AddComponentReference)(
		/*[in]*/ LPCOLESTR /*wszPath*/,
		/*[in]*/ IUnknown* /*pVsLibrary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveComponentReference)(
		/*[in]*/ LPCOLESTR /*wszPath*/,
		/*[in]*/ IUnknown* /*pVsLibrary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IncrementCheckCount)(
		/*[in]*/ LPCOLESTR /*wszPath*/,
		/*[in]*/ IUnknown* /*pVsLibrary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DecrementCheckCount)(
		/*[in]*/ LPCOLESTR /*wszPath*/,
		/*[in]*/ IUnknown* /*pVsLibrary*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListIndex)(
		/*[in]*/ VSOBJECTINFO* /*pobjInfo*/,
		/*[out]*/ IVsObjectList** /*ppList*/,
		/*[out]*/ ULONG* /*pIndex*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLibraryReferenceManagerMockImpl :
	public IVsLibraryReferenceManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLibraryReferenceManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLibraryReferenceManagerMockImpl)

	typedef IVsLibraryReferenceManager Interface;
	struct AddComponentReferenceValidValues
	{
		/*[in]*/ LPCOLESTR wszPath;
		/*[in]*/ IUnknown* pVsLibrary;
		HRESULT retValue;
	};

	STDMETHOD(AddComponentReference)(
		/*[in]*/ LPCOLESTR wszPath,
		/*[in]*/ IUnknown* pVsLibrary)
	{
		VSL_DEFINE_MOCK_METHOD(AddComponentReference)

		VSL_CHECK_VALIDVALUE_STRINGW(wszPath);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLibrary);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveComponentReferenceValidValues
	{
		/*[in]*/ LPCOLESTR wszPath;
		/*[in]*/ IUnknown* pVsLibrary;
		HRESULT retValue;
	};

	STDMETHOD(RemoveComponentReference)(
		/*[in]*/ LPCOLESTR wszPath,
		/*[in]*/ IUnknown* pVsLibrary)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveComponentReference)

		VSL_CHECK_VALIDVALUE_STRINGW(wszPath);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLibrary);

		VSL_RETURN_VALIDVALUES();
	}
	struct IncrementCheckCountValidValues
	{
		/*[in]*/ LPCOLESTR wszPath;
		/*[in]*/ IUnknown* pVsLibrary;
		HRESULT retValue;
	};

	STDMETHOD(IncrementCheckCount)(
		/*[in]*/ LPCOLESTR wszPath,
		/*[in]*/ IUnknown* pVsLibrary)
	{
		VSL_DEFINE_MOCK_METHOD(IncrementCheckCount)

		VSL_CHECK_VALIDVALUE_STRINGW(wszPath);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLibrary);

		VSL_RETURN_VALIDVALUES();
	}
	struct DecrementCheckCountValidValues
	{
		/*[in]*/ LPCOLESTR wszPath;
		/*[in]*/ IUnknown* pVsLibrary;
		HRESULT retValue;
	};

	STDMETHOD(DecrementCheckCount)(
		/*[in]*/ LPCOLESTR wszPath,
		/*[in]*/ IUnknown* pVsLibrary)
	{
		VSL_DEFINE_MOCK_METHOD(DecrementCheckCount)

		VSL_CHECK_VALIDVALUE_STRINGW(wszPath);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsLibrary);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListIndexValidValues
	{
		/*[in]*/ VSOBJECTINFO* pobjInfo;
		/*[out]*/ IVsObjectList** ppList;
		/*[out]*/ ULONG* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetListIndex)(
		/*[in]*/ VSOBJECTINFO* pobjInfo,
		/*[out]*/ IVsObjectList** ppList,
		/*[out]*/ ULONG* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetListIndex)

		VSL_CHECK_VALIDVALUE_POINTER(pobjInfo);

		VSL_SET_VALIDVALUE_INTERFACE(ppList);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLIBRARYREFERENCEMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
