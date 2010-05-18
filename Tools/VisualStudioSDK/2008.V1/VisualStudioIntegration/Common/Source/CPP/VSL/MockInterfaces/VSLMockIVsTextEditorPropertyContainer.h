/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTEDITORPROPERTYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTEDITORPROPERTYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextEditorPropertyContainerNotImpl :
	public IVsTextEditorPropertyContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextEditorPropertyContainerNotImpl)

public:

	typedef IVsTextEditorPropertyContainer Interface;

	STDMETHOD(GetProperty)(
		/*[in]*/ VSEDITPROPID /*idProp*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSEDITPROPID /*idProp*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveProperty)(
		/*[in]*/ VSEDITPROPID /*idProp*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextEditorPropertyContainerMockImpl :
	public IVsTextEditorPropertyContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextEditorPropertyContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextEditorPropertyContainerMockImpl)

	typedef IVsTextEditorPropertyContainer Interface;
	struct GetPropertyValidValues
	{
		/*[in]*/ VSEDITPROPID idProp;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSEDITPROPID idProp,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(idProp);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSEDITPROPID idProp;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSEDITPROPID idProp,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(idProp);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemovePropertyValidValues
	{
		/*[in]*/ VSEDITPROPID idProp;
		HRESULT retValue;
	};

	STDMETHOD(RemoveProperty)(
		/*[in]*/ VSEDITPROPID idProp)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveProperty)

		VSL_CHECK_VALIDVALUE(idProp);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTEDITORPROPERTYCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
