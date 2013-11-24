/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPRINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPRINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DocObj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPrintNotImpl :
	public IPrint
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPrintNotImpl)

public:

	typedef IPrint Interface;

	STDMETHOD(SetInitialPageNum)(
		/*[in]*/ LONG /*nFirstPage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPageInfo)(
		/*[out]*/ LONG* /*pnFirstPage*/,
		/*[out]*/ LONG* /*pcPages*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Print)(
		/*[in]*/ DWORD /*grfFlags*/,
		/*[in,out]*/ DVTARGETDEVICE** /*pptd*/,
		/*[in,out]*/ PAGESET** /*ppPageSet*/,
		/*[in,out,unique]*/ STGMEDIUM* /*pstgmOptions*/,
		/*[in]*/ IContinueCallback* /*pcallback*/,
		/*[in]*/ LONG /*nFirstPage*/,
		/*[out]*/ LONG* /*pcPagesPrinted*/,
		/*[out]*/ LONG* /*pnLastPage*/)VSL_STDMETHOD_NOTIMPL
};

class IPrintMockImpl :
	public IPrint,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPrintMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPrintMockImpl)

	typedef IPrint Interface;
	struct SetInitialPageNumValidValues
	{
		/*[in]*/ LONG nFirstPage;
		HRESULT retValue;
	};

	STDMETHOD(SetInitialPageNum)(
		/*[in]*/ LONG nFirstPage)
	{
		VSL_DEFINE_MOCK_METHOD(SetInitialPageNum)

		VSL_CHECK_VALIDVALUE(nFirstPage);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPageInfoValidValues
	{
		/*[out]*/ LONG* pnFirstPage;
		/*[out]*/ LONG* pcPages;
		HRESULT retValue;
	};

	STDMETHOD(GetPageInfo)(
		/*[out]*/ LONG* pnFirstPage,
		/*[out]*/ LONG* pcPages)
	{
		VSL_DEFINE_MOCK_METHOD(GetPageInfo)

		VSL_SET_VALIDVALUE(pnFirstPage);

		VSL_SET_VALIDVALUE(pcPages);

		VSL_RETURN_VALIDVALUES();
	}
	struct PrintValidValues
	{
		/*[in]*/ DWORD grfFlags;
		/*[in,out]*/ DVTARGETDEVICE** pptd;
		/*[in,out]*/ PAGESET** ppPageSet;
		/*[in,out,unique]*/ STGMEDIUM* pstgmOptions;
		/*[in]*/ IContinueCallback* pcallback;
		/*[in]*/ LONG nFirstPage;
		/*[out]*/ LONG* pcPagesPrinted;
		/*[out]*/ LONG* pnLastPage;
		HRESULT retValue;
	};

	STDMETHOD(Print)(
		/*[in]*/ DWORD grfFlags,
		/*[in,out]*/ DVTARGETDEVICE** pptd,
		/*[in,out]*/ PAGESET** ppPageSet,
		/*[in,out,unique]*/ STGMEDIUM* pstgmOptions,
		/*[in]*/ IContinueCallback* pcallback,
		/*[in]*/ LONG nFirstPage,
		/*[out]*/ LONG* pcPagesPrinted,
		/*[out]*/ LONG* pnLastPage)
	{
		VSL_DEFINE_MOCK_METHOD(Print)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_SET_VALIDVALUE(pptd);

		VSL_SET_VALIDVALUE(ppPageSet);

		VSL_SET_VALIDVALUE(pstgmOptions);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pcallback);

		VSL_CHECK_VALIDVALUE(nFirstPage);

		VSL_SET_VALIDVALUE(pcPagesPrinted);

		VSL_SET_VALIDVALUE(pnLastPage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPRINT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
