/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IFontNotImpl :
	public IFont
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IFontNotImpl)

public:

	typedef IFont Interface;

	STDMETHOD(get_Name)(
		/*[out]*/ BSTR* /*pName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Name)(
		/*[in]*/ BSTR /*name*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Size)(
		/*[out]*/ CY* /*pSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Size)(
		/*[in]*/ CY /*size*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Bold)(
		/*[out]*/ BOOL* /*pBold*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Bold)(
		/*[in]*/ BOOL /*bold*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Italic)(
		/*[out]*/ BOOL* /*pItalic*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Italic)(
		/*[in]*/ BOOL /*italic*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Underline)(
		/*[out]*/ BOOL* /*pUnderline*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Underline)(
		/*[in]*/ BOOL /*underline*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Strikethrough)(
		/*[out]*/ BOOL* /*pStrikethrough*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Strikethrough)(
		/*[in]*/ BOOL /*strikethrough*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Weight)(
		/*[out]*/ SHORT* /*pWeight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Weight)(
		/*[in]*/ SHORT /*weight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Charset)(
		/*[out]*/ SHORT* /*pCharset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Charset)(
		/*[in]*/ SHORT /*charset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_hFont)(
		/*[out]*/ HFONT* /*phFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Clone)(
		/*[out]*/ IFont** /*ppFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in]*/ IFont* /*pFontOther*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRatio)(
		/*[in]*/ LONG /*cyLogical*/,
		/*[in]*/ LONG /*cyHimetric*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryTextMetrics)(
		/*[out]*/ TEXTMETRICOLE* /*pTM*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddRefHfont)(
		/*[in]*/ HFONT /*hFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseHfont)(
		/*[in]*/ HFONT /*hFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHdc)(
		/*[in]*/ HDC /*hDC*/)VSL_STDMETHOD_NOTIMPL
};

class IFontMockImpl :
	public IFont,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IFontMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IFontMockImpl)

	typedef IFont Interface;
	struct get_NameValidValues
	{
		/*[out]*/ BSTR* pName;
		HRESULT retValue;
	};

	STDMETHOD(get_Name)(
		/*[out]*/ BSTR* pName)
	{
		VSL_DEFINE_MOCK_METHOD(get_Name)

		VSL_SET_VALIDVALUE_BSTR(pName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_NameValidValues
	{
		/*[in]*/ BSTR name;
		HRESULT retValue;
	};

	STDMETHOD(put_Name)(
		/*[in]*/ BSTR name)
	{
		VSL_DEFINE_MOCK_METHOD(put_Name)

		VSL_CHECK_VALIDVALUE_BSTR(name);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SizeValidValues
	{
		/*[out]*/ CY* pSize;
		HRESULT retValue;
	};

	STDMETHOD(get_Size)(
		/*[out]*/ CY* pSize)
	{
		VSL_DEFINE_MOCK_METHOD(get_Size)

		VSL_SET_VALIDVALUE(pSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_SizeValidValues
	{
		/*[in]*/ CY size;
		HRESULT retValue;
	};

	STDMETHOD(put_Size)(
		/*[in]*/ CY size)
	{
		VSL_DEFINE_MOCK_METHOD(put_Size)

		VSL_CHECK_VALIDVALUE(size);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_BoldValidValues
	{
		/*[out]*/ BOOL* pBold;
		HRESULT retValue;
	};

	STDMETHOD(get_Bold)(
		/*[out]*/ BOOL* pBold)
	{
		VSL_DEFINE_MOCK_METHOD(get_Bold)

		VSL_SET_VALIDVALUE(pBold);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_BoldValidValues
	{
		/*[in]*/ BOOL bold;
		HRESULT retValue;
	};

	STDMETHOD(put_Bold)(
		/*[in]*/ BOOL bold)
	{
		VSL_DEFINE_MOCK_METHOD(put_Bold)

		VSL_CHECK_VALIDVALUE(bold);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ItalicValidValues
	{
		/*[out]*/ BOOL* pItalic;
		HRESULT retValue;
	};

	STDMETHOD(get_Italic)(
		/*[out]*/ BOOL* pItalic)
	{
		VSL_DEFINE_MOCK_METHOD(get_Italic)

		VSL_SET_VALIDVALUE(pItalic);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ItalicValidValues
	{
		/*[in]*/ BOOL italic;
		HRESULT retValue;
	};

	STDMETHOD(put_Italic)(
		/*[in]*/ BOOL italic)
	{
		VSL_DEFINE_MOCK_METHOD(put_Italic)

		VSL_CHECK_VALIDVALUE(italic);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_UnderlineValidValues
	{
		/*[out]*/ BOOL* pUnderline;
		HRESULT retValue;
	};

	STDMETHOD(get_Underline)(
		/*[out]*/ BOOL* pUnderline)
	{
		VSL_DEFINE_MOCK_METHOD(get_Underline)

		VSL_SET_VALIDVALUE(pUnderline);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_UnderlineValidValues
	{
		/*[in]*/ BOOL underline;
		HRESULT retValue;
	};

	STDMETHOD(put_Underline)(
		/*[in]*/ BOOL underline)
	{
		VSL_DEFINE_MOCK_METHOD(put_Underline)

		VSL_CHECK_VALIDVALUE(underline);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StrikethroughValidValues
	{
		/*[out]*/ BOOL* pStrikethrough;
		HRESULT retValue;
	};

	STDMETHOD(get_Strikethrough)(
		/*[out]*/ BOOL* pStrikethrough)
	{
		VSL_DEFINE_MOCK_METHOD(get_Strikethrough)

		VSL_SET_VALIDVALUE(pStrikethrough);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StrikethroughValidValues
	{
		/*[in]*/ BOOL strikethrough;
		HRESULT retValue;
	};

	STDMETHOD(put_Strikethrough)(
		/*[in]*/ BOOL strikethrough)
	{
		VSL_DEFINE_MOCK_METHOD(put_Strikethrough)

		VSL_CHECK_VALIDVALUE(strikethrough);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WeightValidValues
	{
		/*[out]*/ SHORT* pWeight;
		HRESULT retValue;
	};

	STDMETHOD(get_Weight)(
		/*[out]*/ SHORT* pWeight)
	{
		VSL_DEFINE_MOCK_METHOD(get_Weight)

		VSL_SET_VALIDVALUE(pWeight);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WeightValidValues
	{
		/*[in]*/ SHORT weight;
		HRESULT retValue;
	};

	STDMETHOD(put_Weight)(
		/*[in]*/ SHORT weight)
	{
		VSL_DEFINE_MOCK_METHOD(put_Weight)

		VSL_CHECK_VALIDVALUE(weight);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CharsetValidValues
	{
		/*[out]*/ SHORT* pCharset;
		HRESULT retValue;
	};

	STDMETHOD(get_Charset)(
		/*[out]*/ SHORT* pCharset)
	{
		VSL_DEFINE_MOCK_METHOD(get_Charset)

		VSL_SET_VALIDVALUE(pCharset);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CharsetValidValues
	{
		/*[in]*/ SHORT charset;
		HRESULT retValue;
	};

	STDMETHOD(put_Charset)(
		/*[in]*/ SHORT charset)
	{
		VSL_DEFINE_MOCK_METHOD(put_Charset)

		VSL_CHECK_VALIDVALUE(charset);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_hFontValidValues
	{
		/*[out]*/ HFONT* phFont;
		HRESULT retValue;
	};

	STDMETHOD(get_hFont)(
		/*[out]*/ HFONT* phFont)
	{
		VSL_DEFINE_MOCK_METHOD(get_hFont)

		VSL_SET_VALIDVALUE(phFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloneValidValues
	{
		/*[out]*/ IFont** ppFont;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[out]*/ IFont** ppFont)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_SET_VALIDVALUE_INTERFACE(ppFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEqualValidValues
	{
		/*[in]*/ IFont* pFontOther;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in]*/ IFont* pFontOther)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFontOther);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRatioValidValues
	{
		/*[in]*/ LONG cyLogical;
		/*[in]*/ LONG cyHimetric;
		HRESULT retValue;
	};

	STDMETHOD(SetRatio)(
		/*[in]*/ LONG cyLogical,
		/*[in]*/ LONG cyHimetric)
	{
		VSL_DEFINE_MOCK_METHOD(SetRatio)

		VSL_CHECK_VALIDVALUE(cyLogical);

		VSL_CHECK_VALIDVALUE(cyHimetric);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryTextMetricsValidValues
	{
		/*[out]*/ TEXTMETRICOLE* pTM;
		HRESULT retValue;
	};

	STDMETHOD(QueryTextMetrics)(
		/*[out]*/ TEXTMETRICOLE* pTM)
	{
		VSL_DEFINE_MOCK_METHOD(QueryTextMetrics)

		VSL_SET_VALIDVALUE(pTM);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddRefHfontValidValues
	{
		/*[in]*/ HFONT hFont;
		HRESULT retValue;
	};

	STDMETHOD(AddRefHfont)(
		/*[in]*/ HFONT hFont)
	{
		VSL_DEFINE_MOCK_METHOD(AddRefHfont)

		VSL_CHECK_VALIDVALUE(hFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseHfontValidValues
	{
		/*[in]*/ HFONT hFont;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseHfont)(
		/*[in]*/ HFONT hFont)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseHfont)

		VSL_CHECK_VALIDVALUE(hFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHdcValidValues
	{
		/*[in]*/ HDC hDC;
		HRESULT retValue;
	};

	STDMETHOD(SetHdc)(
		/*[in]*/ HDC hDC)
	{
		VSL_DEFINE_MOCK_METHOD(SetHdc)

		VSL_CHECK_VALIDVALUE(hDC);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IFONT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
