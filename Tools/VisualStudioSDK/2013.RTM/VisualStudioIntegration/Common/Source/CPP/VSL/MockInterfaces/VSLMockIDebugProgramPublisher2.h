/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAMPUBLISHER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAMPUBLISHER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugProgramPublisher2NotImpl :
	public IDebugProgramPublisher2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramPublisher2NotImpl)

public:

	typedef IDebugProgramPublisher2 Interface;

	STDMETHOD(PublishProgramNode)(
		/*[in]*/ IDebugProgramNode2* /*pProgramNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnpublishProgramNode)(
		/*[in]*/ IDebugProgramNode2* /*pProgramNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PublishProgram)(
		/*[in]*/ CONST_GUID_ARRAY /*Engines*/,
		/*[in,ptr]*/ LPCOLESTR /*szFriendlyName*/,
		/*[in]*/ IUnknown* /*pDebuggeeInterface*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnpublishProgram)(
		/*[in]*/ IUnknown* /*pDebuggeeInterface*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDebuggerPresent)(
		/*[in]*/ BOOL /*fDebuggerPresent*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProgramPublisher2MockImpl :
	public IDebugProgramPublisher2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramPublisher2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgramPublisher2MockImpl)

	typedef IDebugProgramPublisher2 Interface;
	struct PublishProgramNodeValidValues
	{
		/*[in]*/ IDebugProgramNode2* pProgramNode;
		HRESULT retValue;
	};

	STDMETHOD(PublishProgramNode)(
		/*[in]*/ IDebugProgramNode2* pProgramNode)
	{
		VSL_DEFINE_MOCK_METHOD(PublishProgramNode)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgramNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnpublishProgramNodeValidValues
	{
		/*[in]*/ IDebugProgramNode2* pProgramNode;
		HRESULT retValue;
	};

	STDMETHOD(UnpublishProgramNode)(
		/*[in]*/ IDebugProgramNode2* pProgramNode)
	{
		VSL_DEFINE_MOCK_METHOD(UnpublishProgramNode)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgramNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct PublishProgramValidValues
	{
		/*[in]*/ CONST_GUID_ARRAY Engines;
		/*[in,ptr]*/ LPCOLESTR szFriendlyName;
		/*[in]*/ IUnknown* pDebuggeeInterface;
		HRESULT retValue;
	};

	STDMETHOD(PublishProgram)(
		/*[in]*/ CONST_GUID_ARRAY Engines,
		/*[in,ptr]*/ LPCOLESTR szFriendlyName,
		/*[in]*/ IUnknown* pDebuggeeInterface)
	{
		VSL_DEFINE_MOCK_METHOD(PublishProgram)

		VSL_CHECK_VALIDVALUE(Engines);

		VSL_CHECK_VALIDVALUE_STRINGW(szFriendlyName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDebuggeeInterface);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnpublishProgramValidValues
	{
		/*[in]*/ IUnknown* pDebuggeeInterface;
		HRESULT retValue;
	};

	STDMETHOD(UnpublishProgram)(
		/*[in]*/ IUnknown* pDebuggeeInterface)
	{
		VSL_DEFINE_MOCK_METHOD(UnpublishProgram)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDebuggeeInterface);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDebuggerPresentValidValues
	{
		/*[in]*/ BOOL fDebuggerPresent;
		HRESULT retValue;
	};

	STDMETHOD(SetDebuggerPresent)(
		/*[in]*/ BOOL fDebuggerPresent)
	{
		VSL_DEFINE_MOCK_METHOD(SetDebuggerPresent)

		VSL_CHECK_VALIDVALUE(fDebuggerPresent);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAMPUBLISHER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
