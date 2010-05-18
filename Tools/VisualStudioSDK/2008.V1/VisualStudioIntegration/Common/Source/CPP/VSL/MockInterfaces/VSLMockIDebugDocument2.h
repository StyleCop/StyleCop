/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDocument2NotImpl :
	public IDebugDocument2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocument2NotImpl)

public:

	typedef IDebugDocument2 Interface;

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE /*gnType*/,
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentClassId)(
		/*[out]*/ CLSID* /*pclsid*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocument2MockImpl :
	public IDebugDocument2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocument2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocument2MockImpl)

	typedef IDebugDocument2 Interface;
	struct GetNameValidValues
	{
		/*[in]*/ GETNAME_TYPE gnType;
		/*[out]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE gnType,
		/*[out]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_CHECK_VALIDVALUE(gnType);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentClassIdValidValues
	{
		/*[out]*/ CLSID* pclsid;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentClassId)(
		/*[out]*/ CLSID* pclsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentClassId)

		VSL_SET_VALIDVALUE(pclsid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
