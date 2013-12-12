/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTTEXTIMAGEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTTEXTIMAGEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectTextImageProviderNotImpl :
	public IVsProjectTextImageProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectTextImageProviderNotImpl)

public:

	typedef IVsProjectTextImageProvider Interface;

	STDMETHOD(OpenItemTextImage)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSPTIP_MODE /*grfMode*/,
		/*[out,retval]*/ IVsTextImage** /*ppTextImage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseItemTextImage)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSPTIP_DISPOSITION /*vsptipDisposition*/,
		/*[in]*/ IVsTextImage* /*pTextImage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectTextImageProviderMockImpl :
	public IVsProjectTextImageProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectTextImageProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectTextImageProviderMockImpl)

	typedef IVsProjectTextImageProvider Interface;
	struct OpenItemTextImageValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSPTIP_MODE grfMode;
		/*[out,retval]*/ IVsTextImage** ppTextImage;
		HRESULT retValue;
	};

	STDMETHOD(OpenItemTextImage)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSPTIP_MODE grfMode,
		/*[out,retval]*/ IVsTextImage** ppTextImage)
	{
		VSL_DEFINE_MOCK_METHOD(OpenItemTextImage)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(grfMode);

		VSL_SET_VALIDVALUE_INTERFACE(ppTextImage);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseItemTextImageValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSPTIP_DISPOSITION vsptipDisposition;
		/*[in]*/ IVsTextImage* pTextImage;
		HRESULT retValue;
	};

	STDMETHOD(CloseItemTextImage)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSPTIP_DISPOSITION vsptipDisposition,
		/*[in]*/ IVsTextImage* pTextImage)
	{
		VSL_DEFINE_MOCK_METHOD(CloseItemTextImage)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(vsptipDisposition);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextImage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTTEXTIMAGEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
