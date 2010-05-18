/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPERSISTENTTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPERSISTENTTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPersistentTextImageNotImpl :
	public IVsPersistentTextImage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistentTextImageNotImpl)

public:

	typedef IVsPersistentTextImage Interface;

	virtual void* STDMETHODCALLTYPE Image_Alloc(
		/*[in]*/ int /*iSize*/){ return NULL; }

	virtual void* STDMETHODCALLTYPE Image_Realloc(
		/*[in,out]*/ void* /*p*/,
		/*[in]*/ int /*iSize*/){ return NULL; }

	virtual void STDMETHODCALLTYPE Image_Free(
		/*[in]*/ void* /*p*/){ return ; }

	virtual long STDMETHODCALLTYPE Image_GetLength(){ return long(); }

	STDMETHOD(Image_LoadText)(
		/*[in]*/ const WCHAR* /*pszText*/,
		/*[in]*/ INT /*iLength*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Image_OpenFullTextScan)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Image_FullTextRead)(
		/*[out]*/ const WCHAR** /*ppszText*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Image_CloseFullTextScan)()VSL_STDMETHOD_NOTIMPL
};

class IVsPersistentTextImageMockImpl :
	public IVsPersistentTextImage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPersistentTextImageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPersistentTextImageMockImpl)

	typedef IVsPersistentTextImage Interface;
	struct Image_AllocValidValues
	{
		/*[in]*/ int iSize;
		void* retValue;
	};

	virtual void* _stdcall Image_Alloc(
		/*[in]*/ int iSize)
	{
		VSL_DEFINE_MOCK_METHOD(Image_Alloc)

		VSL_CHECK_VALIDVALUE(iSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_ReallocValidValues
	{
		/*[in,out]*/ void* p;
		/*[in]*/ int iSize;
		void* retValue;
		size_t p_size_in_bytes;
	};

	virtual void* _stdcall Image_Realloc(
		/*[in,out]*/ void* p,
		/*[in]*/ int iSize)
	{
		VSL_DEFINE_MOCK_METHOD(Image_Realloc)

		VSL_SET_VALIDVALUE_PVOID(p);

		VSL_CHECK_VALIDVALUE(iSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_FreeValidValues
	{
		/*[in]*/ void* p;
		size_t p_size_in_bytes;
	};

	virtual void _stdcall Image_Free(
		/*[in]*/ void* p)
	{
		VSL_DEFINE_MOCK_METHOD(Image_Free)

		VSL_CHECK_VALIDVALUE_PVOID(p);

	}
	struct Image_GetLengthValidValues
	{
		long retValue;
	};

	virtual long _stdcall Image_GetLength()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Image_GetLength)

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_LoadTextValidValues
	{
		/*[in]*/ WCHAR* pszText;
		/*[in]*/ INT iLength;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(Image_LoadText)(
		/*[in]*/ const WCHAR* pszText,
		/*[in]*/ INT iLength,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(Image_LoadText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iLength);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_OpenFullTextScanValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Image_OpenFullTextScan)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Image_OpenFullTextScan)

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_FullTextReadValidValues
	{
		/*[out]*/ WCHAR** ppszText;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(Image_FullTextRead)(
		/*[out]*/ const WCHAR** ppszText,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(Image_FullTextRead)

		VSL_SET_VALIDVALUE_CONST(ppszText, WCHAR**);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct Image_CloseFullTextScanValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Image_CloseFullTextScan)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Image_CloseFullTextScan)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPERSISTENTTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
