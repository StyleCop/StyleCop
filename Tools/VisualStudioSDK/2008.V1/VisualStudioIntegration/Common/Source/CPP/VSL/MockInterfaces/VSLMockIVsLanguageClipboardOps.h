/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGECLIPBOARDOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGECLIPBOARDOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageClipboardOpsNotImpl :
	public IVsLanguageClipboardOps
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageClipboardOpsNotImpl)

public:

	typedef IVsLanguageClipboardOps Interface;

	STDMETHOD(GetDataObject)(
		/*[in]*/ IVsTextView* /*pView*/,
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[out,retval]*/ IDataObject** /*ppDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsTextData)(
		/*[in]*/ IDataObject* /*pDO*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TextFromData)(
		/*[in]*/ IVsTextLayer* /*pTextLayer*/,
		/*[in]*/ IDataObject* /*pDO*/,
		/*[out]*/ LTE_TEXTDATAFLAGS* /*ptdfFlags*/,
		/*[out,retval]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DataObjectRendered)(
		/*[in]*/ IVsTextLines* /*pTextLines*/,
		/*[in]*/ DWORD /*dwHint*/,
		/*[in]*/ TextSpan* /*ptsInsertedText*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageClipboardOpsMockImpl :
	public IVsLanguageClipboardOps,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageClipboardOpsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageClipboardOpsMockImpl)

	typedef IVsLanguageClipboardOps Interface;
	struct GetDataObjectValidValues
	{
		/*[in]*/ IVsTextView* pView;
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[out,retval]*/ IDataObject** ppDO;
		HRESULT retValue;
	};

	STDMETHOD(GetDataObject)(
		/*[in]*/ IVsTextView* pView,
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[out,retval]*/ IDataObject** ppDO)
	{
		VSL_DEFINE_MOCK_METHOD(GetDataObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_SET_VALIDVALUE_INTERFACE(ppDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsTextDataValidValues
	{
		/*[in]*/ IDataObject* pDO;
		HRESULT retValue;
	};

	STDMETHOD(IsTextData)(
		/*[in]*/ IDataObject* pDO)
	{
		VSL_DEFINE_MOCK_METHOD(IsTextData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_RETURN_VALIDVALUES();
	}
	struct TextFromDataValidValues
	{
		/*[in]*/ IVsTextLayer* pTextLayer;
		/*[in]*/ IDataObject* pDO;
		/*[out]*/ LTE_TEXTDATAFLAGS* ptdfFlags;
		/*[out,retval]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(TextFromData)(
		/*[in]*/ IVsTextLayer* pTextLayer,
		/*[in]*/ IDataObject* pDO,
		/*[out]*/ LTE_TEXTDATAFLAGS* ptdfFlags,
		/*[out,retval]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(TextFromData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLayer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_SET_VALIDVALUE(ptdfFlags);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct DataObjectRenderedValidValues
	{
		/*[in]*/ IVsTextLines* pTextLines;
		/*[in]*/ DWORD dwHint;
		/*[in]*/ TextSpan* ptsInsertedText;
		HRESULT retValue;
	};

	STDMETHOD(DataObjectRendered)(
		/*[in]*/ IVsTextLines* pTextLines,
		/*[in]*/ DWORD dwHint,
		/*[in]*/ TextSpan* ptsInsertedText)
	{
		VSL_DEFINE_MOCK_METHOD(DataObjectRendered)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLines);

		VSL_CHECK_VALIDVALUE(dwHint);

		VSL_CHECK_VALIDVALUE_POINTER(ptsInsertedText);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGECLIPBOARDOPS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
