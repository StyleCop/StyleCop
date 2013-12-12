/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsmanaged.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVSMDDesignerNotImpl :
	public IVSMDDesigner
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerNotImpl)

public:

	typedef IVSMDDesigner Interface;

	STDMETHOD(get_CommandGuid)(
		/*[out,retval]*/ GUID* /*pguidCmdId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_View)(
		/*[out,retval]*/ IUnknown** /*pView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SelectionContainer)(
		/*[out,retval]*/ IUnknown** /*ppSelCon*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Dispose)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Flush)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLoadError)()VSL_STDMETHOD_NOTIMPL
};

class IVSMDDesignerMockImpl :
	public IVSMDDesigner,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDDesignerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDDesignerMockImpl)

	typedef IVSMDDesigner Interface;
	struct get_CommandGuidValidValues
	{
		/*[out,retval]*/ GUID* pguidCmdId;
		HRESULT retValue;
	};

	STDMETHOD(get_CommandGuid)(
		/*[out,retval]*/ GUID* pguidCmdId)
	{
		VSL_DEFINE_MOCK_METHOD(get_CommandGuid)

		VSL_SET_VALIDVALUE(pguidCmdId);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ViewValidValues
	{
		/*[out,retval]*/ IUnknown** pView;
		HRESULT retValue;
	};

	STDMETHOD(get_View)(
		/*[out,retval]*/ IUnknown** pView)
	{
		VSL_DEFINE_MOCK_METHOD(get_View)

		VSL_SET_VALIDVALUE_INTERFACE(pView);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SelectionContainerValidValues
	{
		/*[out,retval]*/ IUnknown** ppSelCon;
		HRESULT retValue;
	};

	STDMETHOD(get_SelectionContainer)(
		/*[out,retval]*/ IUnknown** ppSelCon)
	{
		VSL_DEFINE_MOCK_METHOD(get_SelectionContainer)

		VSL_SET_VALIDVALUE_INTERFACE(ppSelCon);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisposeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Dispose)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Dispose)

		VSL_RETURN_VALIDVALUES();
	}
	struct FlushValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Flush)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Flush)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLoadErrorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(GetLoadError)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetLoadError)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDDESIGNER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
