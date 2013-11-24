/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEFERREDDOCVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEFERREDDOCVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDeferredDocViewNotImpl :
	public IVsDeferredDocView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeferredDocViewNotImpl)

public:

	typedef IVsDeferredDocView Interface;

	STDMETHOD(get_DocView)(
		/*[out]*/ IUnknown** /*ppUnkDocView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CmdUIGuid)(
		/*[out]*/ GUID* /*pGuidCmdId*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDeferredDocViewMockImpl :
	public IVsDeferredDocView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeferredDocViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDeferredDocViewMockImpl)

	typedef IVsDeferredDocView Interface;
	struct get_DocViewValidValues
	{
		/*[out]*/ IUnknown** ppUnkDocView;
		HRESULT retValue;
	};

	STDMETHOD(get_DocView)(
		/*[out]*/ IUnknown** ppUnkDocView)
	{
		VSL_DEFINE_MOCK_METHOD(get_DocView)

		VSL_SET_VALIDVALUE_INTERFACE(ppUnkDocView);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CmdUIGuidValidValues
	{
		/*[out]*/ GUID* pGuidCmdId;
		HRESULT retValue;
	};

	STDMETHOD(get_CmdUIGuid)(
		/*[out]*/ GUID* pGuidCmdId)
	{
		VSL_DEFINE_MOCK_METHOD(get_CmdUIGuid)

		VSL_SET_VALIDVALUE(pGuidCmdId);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEFERREDDOCVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
