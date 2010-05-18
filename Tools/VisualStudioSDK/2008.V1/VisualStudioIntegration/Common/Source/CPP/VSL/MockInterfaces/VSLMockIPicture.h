/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPICTURE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPICTURE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPictureNotImpl :
	public IPicture
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPictureNotImpl)

public:

	typedef IPicture Interface;

	STDMETHOD(get_Handle)(
		/*[out]*/ OLE_HANDLE* /*pHandle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_hPal)(
		/*[out]*/ OLE_HANDLE* /*phPal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Type)(
		/*[out]*/ SHORT* /*pType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Width)(
		/*[out]*/ OLE_XSIZE_HIMETRIC* /*pWidth*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Height)(
		/*[out]*/ OLE_YSIZE_HIMETRIC* /*pHeight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Render)(
		/*[in]*/ HDC /*hDC*/,
		/*[in]*/ LONG /*x*/,
		/*[in]*/ LONG /*y*/,
		/*[in]*/ LONG /*cx*/,
		/*[in]*/ LONG /*cy*/,
		/*[in]*/ OLE_XPOS_HIMETRIC /*xSrc*/,
		/*[in]*/ OLE_YPOS_HIMETRIC /*ySrc*/,
		/*[in]*/ OLE_XSIZE_HIMETRIC /*cxSrc*/,
		/*[in]*/ OLE_YSIZE_HIMETRIC /*cySrc*/,
		/*[in]*/ LPCRECT /*pRcWBounds*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(set_hPal)(
		/*[in]*/ OLE_HANDLE /*hPal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CurDC)(
		/*[out]*/ HDC* /*phDC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectPicture)(
		/*[in]*/ HDC /*hDCIn*/,
		/*[out]*/ HDC* /*phDCOut*/,
		/*[out]*/ OLE_HANDLE* /*phBmpOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_KeepOriginalFormat)(
		/*[out]*/ BOOL* /*pKeep*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_KeepOriginalFormat)(
		/*[in]*/ BOOL /*keep*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PictureChanged)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveAsFile)(
		/*[in]*/ LPSTREAM /*pStream*/,
		/*[in]*/ BOOL /*fSaveMemCopy*/,
		/*[out]*/ LONG* /*pCbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Attributes)(
		/*[out]*/ DWORD* /*pDwAttr*/)VSL_STDMETHOD_NOTIMPL
};

class IPictureMockImpl :
	public IPicture,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPictureMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPictureMockImpl)

	typedef IPicture Interface;
	struct get_HandleValidValues
	{
		/*[out]*/ OLE_HANDLE* pHandle;
		HRESULT retValue;
	};

	STDMETHOD(get_Handle)(
		/*[out]*/ OLE_HANDLE* pHandle)
	{
		VSL_DEFINE_MOCK_METHOD(get_Handle)

		VSL_SET_VALIDVALUE(pHandle);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_hPalValidValues
	{
		/*[out]*/ OLE_HANDLE* phPal;
		HRESULT retValue;
	};

	STDMETHOD(get_hPal)(
		/*[out]*/ OLE_HANDLE* phPal)
	{
		VSL_DEFINE_MOCK_METHOD(get_hPal)

		VSL_SET_VALIDVALUE(phPal);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TypeValidValues
	{
		/*[out]*/ SHORT* pType;
		HRESULT retValue;
	};

	STDMETHOD(get_Type)(
		/*[out]*/ SHORT* pType)
	{
		VSL_DEFINE_MOCK_METHOD(get_Type)

		VSL_SET_VALIDVALUE(pType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WidthValidValues
	{
		/*[out]*/ OLE_XSIZE_HIMETRIC* pWidth;
		HRESULT retValue;
	};

	STDMETHOD(get_Width)(
		/*[out]*/ OLE_XSIZE_HIMETRIC* pWidth)
	{
		VSL_DEFINE_MOCK_METHOD(get_Width)

		VSL_SET_VALIDVALUE(pWidth);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HeightValidValues
	{
		/*[out]*/ OLE_YSIZE_HIMETRIC* pHeight;
		HRESULT retValue;
	};

	STDMETHOD(get_Height)(
		/*[out]*/ OLE_YSIZE_HIMETRIC* pHeight)
	{
		VSL_DEFINE_MOCK_METHOD(get_Height)

		VSL_SET_VALIDVALUE(pHeight);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenderValidValues
	{
		/*[in]*/ HDC hDC;
		/*[in]*/ LONG x;
		/*[in]*/ LONG y;
		/*[in]*/ LONG cx;
		/*[in]*/ LONG cy;
		/*[in]*/ OLE_XPOS_HIMETRIC xSrc;
		/*[in]*/ OLE_YPOS_HIMETRIC ySrc;
		/*[in]*/ OLE_XSIZE_HIMETRIC cxSrc;
		/*[in]*/ OLE_YSIZE_HIMETRIC cySrc;
		/*[in]*/ LPCRECT pRcWBounds;
		HRESULT retValue;
	};

	STDMETHOD(Render)(
		/*[in]*/ HDC hDC,
		/*[in]*/ LONG x,
		/*[in]*/ LONG y,
		/*[in]*/ LONG cx,
		/*[in]*/ LONG cy,
		/*[in]*/ OLE_XPOS_HIMETRIC xSrc,
		/*[in]*/ OLE_YPOS_HIMETRIC ySrc,
		/*[in]*/ OLE_XSIZE_HIMETRIC cxSrc,
		/*[in]*/ OLE_YSIZE_HIMETRIC cySrc,
		/*[in]*/ LPCRECT pRcWBounds)
	{
		VSL_DEFINE_MOCK_METHOD(Render)

		VSL_CHECK_VALIDVALUE(hDC);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_CHECK_VALIDVALUE(xSrc);

		VSL_CHECK_VALIDVALUE(ySrc);

		VSL_CHECK_VALIDVALUE(cxSrc);

		VSL_CHECK_VALIDVALUE(cySrc);

		VSL_CHECK_VALIDVALUE(pRcWBounds);

		VSL_RETURN_VALIDVALUES();
	}
	struct set_hPalValidValues
	{
		/*[in]*/ OLE_HANDLE hPal;
		HRESULT retValue;
	};

	STDMETHOD(set_hPal)(
		/*[in]*/ OLE_HANDLE hPal)
	{
		VSL_DEFINE_MOCK_METHOD(set_hPal)

		VSL_CHECK_VALIDVALUE(hPal);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CurDCValidValues
	{
		/*[out]*/ HDC* phDC;
		HRESULT retValue;
	};

	STDMETHOD(get_CurDC)(
		/*[out]*/ HDC* phDC)
	{
		VSL_DEFINE_MOCK_METHOD(get_CurDC)

		VSL_SET_VALIDVALUE(phDC);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectPictureValidValues
	{
		/*[in]*/ HDC hDCIn;
		/*[out]*/ HDC* phDCOut;
		/*[out]*/ OLE_HANDLE* phBmpOut;
		HRESULT retValue;
	};

	STDMETHOD(SelectPicture)(
		/*[in]*/ HDC hDCIn,
		/*[out]*/ HDC* phDCOut,
		/*[out]*/ OLE_HANDLE* phBmpOut)
	{
		VSL_DEFINE_MOCK_METHOD(SelectPicture)

		VSL_CHECK_VALIDVALUE(hDCIn);

		VSL_SET_VALIDVALUE(phDCOut);

		VSL_SET_VALIDVALUE(phBmpOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_KeepOriginalFormatValidValues
	{
		/*[out]*/ BOOL* pKeep;
		HRESULT retValue;
	};

	STDMETHOD(get_KeepOriginalFormat)(
		/*[out]*/ BOOL* pKeep)
	{
		VSL_DEFINE_MOCK_METHOD(get_KeepOriginalFormat)

		VSL_SET_VALIDVALUE(pKeep);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_KeepOriginalFormatValidValues
	{
		/*[in]*/ BOOL keep;
		HRESULT retValue;
	};

	STDMETHOD(put_KeepOriginalFormat)(
		/*[in]*/ BOOL keep)
	{
		VSL_DEFINE_MOCK_METHOD(put_KeepOriginalFormat)

		VSL_CHECK_VALIDVALUE(keep);

		VSL_RETURN_VALIDVALUES();
	}
	struct PictureChangedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(PictureChanged)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(PictureChanged)

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveAsFileValidValues
	{
		/*[in]*/ LPSTREAM pStream;
		/*[in]*/ BOOL fSaveMemCopy;
		/*[out]*/ LONG* pCbSize;
		HRESULT retValue;
	};

	STDMETHOD(SaveAsFile)(
		/*[in]*/ LPSTREAM pStream,
		/*[in]*/ BOOL fSaveMemCopy,
		/*[out]*/ LONG* pCbSize)
	{
		VSL_DEFINE_MOCK_METHOD(SaveAsFile)

		VSL_CHECK_VALIDVALUE(pStream);

		VSL_CHECK_VALIDVALUE(fSaveMemCopy);

		VSL_SET_VALIDVALUE(pCbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AttributesValidValues
	{
		/*[out]*/ DWORD* pDwAttr;
		HRESULT retValue;
	};

	STDMETHOD(get_Attributes)(
		/*[out]*/ DWORD* pDwAttr)
	{
		VSL_DEFINE_MOCK_METHOD(get_Attributes)

		VSL_SET_VALIDVALUE(pDwAttr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPICTURE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
