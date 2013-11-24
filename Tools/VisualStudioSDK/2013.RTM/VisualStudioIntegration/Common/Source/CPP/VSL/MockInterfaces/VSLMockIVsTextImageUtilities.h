/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTIMAGEUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTIMAGEUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextImageUtilitiesNotImpl :
	public IVsTextImageUtilities
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImageUtilitiesNotImpl)

public:

	typedef IVsTextImageUtilities Interface;

	STDMETHOD(GetReplaceText)(
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[in]*/ LPCOLESTR /*pszReplace*/,
		/*[in]*/ IVsTextImage* /*pText*/,
		/*[in]*/ const TextSpan* /*pMatch*/,
		/*[in]*/ IVsTextSpanSet* /*pTags*/,
		/*[out,retval]*/ BSTR* /*pbstrComputedText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadTextFile)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[out]*/ VSTFF* /*pvstffOut*/,
		/*[out,retval]*/ BSTR* /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadTextImageFromFile)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ IVsTextImage* /*pImage*/,
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[out,retval]*/ VSTFF* /*pvstffOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveTextImageToFile)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ IVsTextImage* /*pImage*/,
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[out,retval]*/ VSTFF* /*pvstffOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextFormat)(
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[in]*/ DWORD /*cbData*/,
		/*[in,size_is(cbData)]*/ const BYTE* /*pData*/,
		/*[out,retval]*/ VSTFF* /*pvstffOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadTextImageFromMemory)(
		/*[in]*/ IVsTextImage* /*pImage*/,
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[in]*/ DWORD /*cbData*/,
		/*[in,size_is(cbData)]*/ const BYTE* /*pData*/,
		/*[out,retval]*/ VSTFF* /*pvstffOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveTextImageToMemory)(
		/*[in]*/ IVsTextImage* /*pImage*/,
		/*[in]*/ VSTFF /*vstffIn*/,
		/*[in]*/ DWORD /*cbData*/,
		/*[out,size_is(cbData),length_is(*pcbWritten)]*/ BYTE* /*pData*/,
		/*[out]*/ DWORD* /*pcbWritten*/,
		/*[out]*/ VSTFF* /*pvstffOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextImageUtilitiesMockImpl :
	public IVsTextImageUtilities,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImageUtilitiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextImageUtilitiesMockImpl)

	typedef IVsTextImageUtilities Interface;
	struct GetReplaceTextValidValues
	{
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[in]*/ LPCOLESTR pszReplace;
		/*[in]*/ IVsTextImage* pText;
		/*[in]*/ TextSpan* pMatch;
		/*[in]*/ IVsTextSpanSet* pTags;
		/*[out,retval]*/ BSTR* pbstrComputedText;
		HRESULT retValue;
	};

	STDMETHOD(GetReplaceText)(
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[in]*/ LPCOLESTR pszReplace,
		/*[in]*/ IVsTextImage* pText,
		/*[in]*/ const TextSpan* pMatch,
		/*[in]*/ IVsTextSpanSet* pTags,
		/*[out,retval]*/ BSTR* pbstrComputedText)
	{
		VSL_DEFINE_MOCK_METHOD(GetReplaceText)

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReplace);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pText);

		VSL_CHECK_VALIDVALUE_POINTER(pMatch);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTags);

		VSL_SET_VALIDVALUE_BSTR(pbstrComputedText);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadTextFileValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ VSTFF vstffIn;
		/*[out]*/ VSTFF* pvstffOut;
		/*[out,retval]*/ BSTR* pbstr;
		HRESULT retValue;
	};

	STDMETHOD(LoadTextFile)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ VSTFF vstffIn,
		/*[out]*/ VSTFF* pvstffOut,
		/*[out,retval]*/ BSTR* pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(LoadTextFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_SET_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadTextImageFromFileValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ IVsTextImage* pImage;
		/*[in]*/ VSTFF vstffIn;
		/*[out,retval]*/ VSTFF* pvstffOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadTextImageFromFile)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ IVsTextImage* pImage,
		/*[in]*/ VSTFF vstffIn,
		/*[out,retval]*/ VSTFF* pvstffOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadTextImageFromFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pImage);

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveTextImageToFileValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ IVsTextImage* pImage;
		/*[in]*/ VSTFF vstffIn;
		/*[out,retval]*/ VSTFF* pvstffOut;
		HRESULT retValue;
	};

	STDMETHOD(SaveTextImageToFile)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ IVsTextImage* pImage,
		/*[in]*/ VSTFF vstffIn,
		/*[out,retval]*/ VSTFF* pvstffOut)
	{
		VSL_DEFINE_MOCK_METHOD(SaveTextImageToFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pImage);

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextFormatValidValues
	{
		/*[in]*/ VSTFF vstffIn;
		/*[in]*/ DWORD cbData;
		/*[in,size_is(cbData)]*/ BYTE* pData;
		/*[out,retval]*/ VSTFF* pvstffOut;
		HRESULT retValue;
	};

	STDMETHOD(GetTextFormat)(
		/*[in]*/ VSTFF vstffIn,
		/*[in]*/ DWORD cbData,
		/*[in,size_is(cbData)]*/ const BYTE* pData,
		/*[out,retval]*/ VSTFF* pvstffOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextFormat)

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_CHECK_VALIDVALUE(cbData);

		VSL_CHECK_VALIDVALUE_MEMCMP(pData, cbData*sizeof(pData[0]), validValues.cbData*sizeof(validValues.pData[0]));

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadTextImageFromMemoryValidValues
	{
		/*[in]*/ IVsTextImage* pImage;
		/*[in]*/ VSTFF vstffIn;
		/*[in]*/ DWORD cbData;
		/*[in,size_is(cbData)]*/ BYTE* pData;
		/*[out,retval]*/ VSTFF* pvstffOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadTextImageFromMemory)(
		/*[in]*/ IVsTextImage* pImage,
		/*[in]*/ VSTFF vstffIn,
		/*[in]*/ DWORD cbData,
		/*[in,size_is(cbData)]*/ const BYTE* pData,
		/*[out,retval]*/ VSTFF* pvstffOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadTextImageFromMemory)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pImage);

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_CHECK_VALIDVALUE(cbData);

		VSL_CHECK_VALIDVALUE_MEMCMP(pData, cbData*sizeof(pData[0]), validValues.cbData*sizeof(validValues.pData[0]));

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveTextImageToMemoryValidValues
	{
		/*[in]*/ IVsTextImage* pImage;
		/*[in]*/ VSTFF vstffIn;
		/*[in]*/ DWORD cbData;
		/*[out,size_is(cbData),length_is(*pcbWritten)]*/ BYTE* pData;
		/*[out]*/ DWORD* pcbWritten;
		/*[out]*/ VSTFF* pvstffOut;
		HRESULT retValue;
	};

	STDMETHOD(SaveTextImageToMemory)(
		/*[in]*/ IVsTextImage* pImage,
		/*[in]*/ VSTFF vstffIn,
		/*[in]*/ DWORD cbData,
		/*[out,size_is(cbData),length_is(*pcbWritten)]*/ BYTE* pData,
		/*[out]*/ DWORD* pcbWritten,
		/*[out]*/ VSTFF* pvstffOut)
	{
		VSL_DEFINE_MOCK_METHOD(SaveTextImageToMemory)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pImage);

		VSL_CHECK_VALIDVALUE(vstffIn);

		VSL_CHECK_VALIDVALUE(cbData);

		VSL_SET_VALIDVALUE_MEMCPY(pData, cbData*sizeof(pData[0]), *(validValues.pcbWritten)*sizeof(validValues.pData[0]));

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_SET_VALIDVALUE(pvstffOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTIMAGEUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
