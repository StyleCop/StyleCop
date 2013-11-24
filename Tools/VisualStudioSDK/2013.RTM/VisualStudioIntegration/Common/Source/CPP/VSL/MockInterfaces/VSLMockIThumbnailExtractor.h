/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITHUMBNAILEXTRACTOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITHUMBNAILEXTRACTOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IThumbnailExtractorNotImpl :
	public IThumbnailExtractor
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IThumbnailExtractorNotImpl)

public:

	typedef IThumbnailExtractor Interface;

	STDMETHOD(ExtractThumbnail)(
		/*[in]*/ IStorage* /*pStg*/,
		/*[in]*/ ULONG /*ulLength*/,
		/*[in]*/ ULONG /*ulHeight*/,
		/*[out]*/ ULONG* /*pulOutputLength*/,
		/*[out]*/ ULONG* /*pulOutputHeight*/,
		/*[out]*/ HBITMAP* /*phOutputBitmap*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnFileUpdated)(
		/*[in]*/ IStorage* /*pStg*/)VSL_STDMETHOD_NOTIMPL
};

class IThumbnailExtractorMockImpl :
	public IThumbnailExtractor,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IThumbnailExtractorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IThumbnailExtractorMockImpl)

	typedef IThumbnailExtractor Interface;
	struct ExtractThumbnailValidValues
	{
		/*[in]*/ IStorage* pStg;
		/*[in]*/ ULONG ulLength;
		/*[in]*/ ULONG ulHeight;
		/*[out]*/ ULONG* pulOutputLength;
		/*[out]*/ ULONG* pulOutputHeight;
		/*[out]*/ HBITMAP* phOutputBitmap;
		HRESULT retValue;
	};

	STDMETHOD(ExtractThumbnail)(
		/*[in]*/ IStorage* pStg,
		/*[in]*/ ULONG ulLength,
		/*[in]*/ ULONG ulHeight,
		/*[out]*/ ULONG* pulOutputLength,
		/*[out]*/ ULONG* pulOutputHeight,
		/*[out]*/ HBITMAP* phOutputBitmap)
	{
		VSL_DEFINE_MOCK_METHOD(ExtractThumbnail)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStg);

		VSL_CHECK_VALIDVALUE(ulLength);

		VSL_CHECK_VALIDVALUE(ulHeight);

		VSL_SET_VALIDVALUE(pulOutputLength);

		VSL_SET_VALIDVALUE(pulOutputHeight);

		VSL_SET_VALIDVALUE(phOutputBitmap);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnFileUpdatedValidValues
	{
		/*[in]*/ IStorage* pStg;
		HRESULT retValue;
	};

	STDMETHOD(OnFileUpdated)(
		/*[in]*/ IStorage* pStg)
	{
		VSL_DEFINE_MOCK_METHOD(OnFileUpdated)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITHUMBNAILEXTRACTOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
