/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEDEFVIEWCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEDEFVIEWCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCodeDefViewContextNotImpl :
	public IVsCodeDefViewContext
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeDefViewContextNotImpl)

public:

	typedef IVsCodeDefViewContext Interface;

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* /*pcItems*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSymbolName)(
		/*[in]*/ ULONG /*iItem*/,
		/*[out]*/ BSTR* /*pbstrSymbolName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFileName)(
		/*[in]*/ ULONG /*iItem*/,
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLine)(
		/*[in]*/ ULONG /*iItem*/,
		/*[out]*/ ULONG* /*piLine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCol)(
		/*[in]*/ ULONG /*iItem*/,
		/*[out]*/ ULONG* /*piCol*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeDefViewContextMockImpl :
	public IVsCodeDefViewContext,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeDefViewContextMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeDefViewContextMockImpl)

	typedef IVsCodeDefViewContext Interface;
	struct GetCountValidValues
	{
		/*[out]*/ ULONG* pcItems;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ ULONG* pcItems)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pcItems);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSymbolNameValidValues
	{
		/*[in]*/ ULONG iItem;
		/*[out]*/ BSTR* pbstrSymbolName;
		HRESULT retValue;
	};

	STDMETHOD(GetSymbolName)(
		/*[in]*/ ULONG iItem,
		/*[out]*/ BSTR* pbstrSymbolName)
	{
		VSL_DEFINE_MOCK_METHOD(GetSymbolName)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE_BSTR(pbstrSymbolName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFileNameValidValues
	{
		/*[in]*/ ULONG iItem;
		/*[out]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetFileName)(
		/*[in]*/ ULONG iItem,
		/*[out]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileName)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineValidValues
	{
		/*[in]*/ ULONG iItem;
		/*[out]*/ ULONG* piLine;
		HRESULT retValue;
	};

	STDMETHOD(GetLine)(
		/*[in]*/ ULONG iItem,
		/*[out]*/ ULONG* piLine)
	{
		VSL_DEFINE_MOCK_METHOD(GetLine)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE(piLine);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColValidValues
	{
		/*[in]*/ ULONG iItem;
		/*[out]*/ ULONG* piCol;
		HRESULT retValue;
	};

	STDMETHOD(GetCol)(
		/*[in]*/ ULONG iItem,
		/*[out]*/ ULONG* piCol)
	{
		VSL_DEFINE_MOCK_METHOD(GetCol)

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_SET_VALIDVALUE(piCol);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEDEFVIEWCONTEXT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
