/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLORUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLORUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorUtilitiesNotImpl :
	public IVsFontAndColorUtilities
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorUtilitiesNotImpl)

public:

	typedef IVsFontAndColorUtilities Interface;

	STDMETHOD(EncodeIndexedColor)(
		/*[in]*/ COLORINDEX /*idx*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodeSysColor)(
		/*[in]*/ int /*iSysColor*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodeVSColor)(
		/*[in]*/ VSSYSCOLOREX /*vsColor*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodeTrackedItem)(
		/*[in]*/ int /*iItemToTrack*/,
		/*[in]*/ VSCOLORASPECT /*aspect*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodeInvalidColor)(
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EncodeAutomaticColor)(
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColorType)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[out]*/ VSCOLORTYPE* /*pctType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEncodedIndex)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[out]*/ COLORINDEX* /*pIdx*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEncodedSysColor)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[out]*/ int* /*piSysColor*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEncodedVSColor)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[out]*/ VSSYSCOLOREX* /*pVSColor*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTrackedItemIndex)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[out]*/ VSCOLORASPECT* /*pAspect*/,
		/*[out]*/ int* /*piItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRGBOfIndex)(
		/*[in]*/ COLORINDEX /*idx*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRGBOfItem)(
		/*[in]*/ AllColorableItemInfo* /*pInfo*/,
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[out]*/ COLORREF* /*pcrForeground*/,
		/*[out]*/ COLORREF* /*pcrBackground*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRGBOfEncodedColor)(
		/*[in]*/ COLORREF /*crSource*/,
		/*[in]*/ COLORREF /*crAutoColor*/,
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[out]*/ COLORREF* /*pcrResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitFontInfo)(
		/*[in,out]*/ FontInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreeFontInfo)(
		/*[in,out]*/ FontInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyFontInfo)(
		/*[in,out]*/ FontInfo* /*pDest*/,
		/*[in]*/ const FontInfo* /*pSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FreeItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* /*pDest*/,
		/*[in]*/ const AllColorableItemInfo* /*pSource*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorUtilitiesMockImpl :
	public IVsFontAndColorUtilities,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorUtilitiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorUtilitiesMockImpl)

	typedef IVsFontAndColorUtilities Interface;
	struct EncodeIndexedColorValidValues
	{
		/*[in]*/ COLORINDEX idx;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeIndexedColor)(
		/*[in]*/ COLORINDEX idx,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeIndexedColor)

		VSL_CHECK_VALIDVALUE(idx);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodeSysColorValidValues
	{
		/*[in]*/ int iSysColor;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeSysColor)(
		/*[in]*/ int iSysColor,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeSysColor)

		VSL_CHECK_VALIDVALUE(iSysColor);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodeVSColorValidValues
	{
		/*[in]*/ VSSYSCOLOREX vsColor;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeVSColor)(
		/*[in]*/ VSSYSCOLOREX vsColor,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeVSColor)

		VSL_CHECK_VALIDVALUE(vsColor);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodeTrackedItemValidValues
	{
		/*[in]*/ int iItemToTrack;
		/*[in]*/ VSCOLORASPECT aspect;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeTrackedItem)(
		/*[in]*/ int iItemToTrack,
		/*[in]*/ VSCOLORASPECT aspect,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeTrackedItem)

		VSL_CHECK_VALIDVALUE(iItemToTrack);

		VSL_CHECK_VALIDVALUE(aspect);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodeInvalidColorValidValues
	{
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeInvalidColor)(
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeInvalidColor)

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EncodeAutomaticColorValidValues
	{
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(EncodeAutomaticColor)(
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(EncodeAutomaticColor)

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColorTypeValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[out]*/ VSCOLORTYPE* pctType;
		HRESULT retValue;
	};

	STDMETHOD(GetColorType)(
		/*[in]*/ COLORREF crSource,
		/*[out]*/ VSCOLORTYPE* pctType)
	{
		VSL_DEFINE_MOCK_METHOD(GetColorType)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_SET_VALIDVALUE(pctType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEncodedIndexValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[out]*/ COLORINDEX* pIdx;
		HRESULT retValue;
	};

	STDMETHOD(GetEncodedIndex)(
		/*[in]*/ COLORREF crSource,
		/*[out]*/ COLORINDEX* pIdx)
	{
		VSL_DEFINE_MOCK_METHOD(GetEncodedIndex)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_SET_VALIDVALUE(pIdx);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEncodedSysColorValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[out]*/ int* piSysColor;
		HRESULT retValue;
	};

	STDMETHOD(GetEncodedSysColor)(
		/*[in]*/ COLORREF crSource,
		/*[out]*/ int* piSysColor)
	{
		VSL_DEFINE_MOCK_METHOD(GetEncodedSysColor)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_SET_VALIDVALUE(piSysColor);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEncodedVSColorValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[out]*/ VSSYSCOLOREX* pVSColor;
		HRESULT retValue;
	};

	STDMETHOD(GetEncodedVSColor)(
		/*[in]*/ COLORREF crSource,
		/*[out]*/ VSSYSCOLOREX* pVSColor)
	{
		VSL_DEFINE_MOCK_METHOD(GetEncodedVSColor)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_SET_VALIDVALUE(pVSColor);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTrackedItemIndexValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[out]*/ VSCOLORASPECT* pAspect;
		/*[out]*/ int* piItem;
		HRESULT retValue;
	};

	STDMETHOD(GetTrackedItemIndex)(
		/*[in]*/ COLORREF crSource,
		/*[out]*/ VSCOLORASPECT* pAspect,
		/*[out]*/ int* piItem)
	{
		VSL_DEFINE_MOCK_METHOD(GetTrackedItemIndex)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_SET_VALIDVALUE(pAspect);

		VSL_SET_VALIDVALUE(piItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRGBOfIndexValidValues
	{
		/*[in]*/ COLORINDEX idx;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(GetRGBOfIndex)(
		/*[in]*/ COLORINDEX idx,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(GetRGBOfIndex)

		VSL_CHECK_VALIDVALUE(idx);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRGBOfItemValidValues
	{
		/*[in]*/ AllColorableItemInfo* pInfo;
		/*[in]*/ REFGUID rguidCategory;
		/*[out]*/ COLORREF* pcrForeground;
		/*[out]*/ COLORREF* pcrBackground;
		HRESULT retValue;
	};

	STDMETHOD(GetRGBOfItem)(
		/*[in]*/ AllColorableItemInfo* pInfo,
		/*[in]*/ REFGUID rguidCategory,
		/*[out]*/ COLORREF* pcrForeground,
		/*[out]*/ COLORREF* pcrBackground)
	{
		VSL_DEFINE_MOCK_METHOD(GetRGBOfItem)

		VSL_CHECK_VALIDVALUE_POINTER(pInfo);

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_SET_VALIDVALUE(pcrForeground);

		VSL_SET_VALIDVALUE(pcrBackground);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRGBOfEncodedColorValidValues
	{
		/*[in]*/ COLORREF crSource;
		/*[in]*/ COLORREF crAutoColor;
		/*[in]*/ REFGUID rguidCategory;
		/*[out]*/ COLORREF* pcrResult;
		HRESULT retValue;
	};

	STDMETHOD(GetRGBOfEncodedColor)(
		/*[in]*/ COLORREF crSource,
		/*[in]*/ COLORREF crAutoColor,
		/*[in]*/ REFGUID rguidCategory,
		/*[out]*/ COLORREF* pcrResult)
	{
		VSL_DEFINE_MOCK_METHOD(GetRGBOfEncodedColor)

		VSL_CHECK_VALIDVALUE(crSource);

		VSL_CHECK_VALIDVALUE(crAutoColor);

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_SET_VALIDVALUE(pcrResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitFontInfoValidValues
	{
		/*[in,out]*/ FontInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(InitFontInfo)(
		/*[in,out]*/ FontInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(InitFontInfo)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeFontInfoValidValues
	{
		/*[in,out]*/ FontInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(FreeFontInfo)(
		/*[in,out]*/ FontInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(FreeFontInfo)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyFontInfoValidValues
	{
		/*[in,out]*/ FontInfo* pDest;
		/*[in]*/ FontInfo* pSource;
		HRESULT retValue;
	};

	STDMETHOD(CopyFontInfo)(
		/*[in,out]*/ FontInfo* pDest,
		/*[in]*/ const FontInfo* pSource)
	{
		VSL_DEFINE_MOCK_METHOD(CopyFontInfo)

		VSL_SET_VALIDVALUE(pDest);

		VSL_CHECK_VALIDVALUE_POINTER(pSource);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitItemInfoValidValues
	{
		/*[in,out]*/ AllColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(InitItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(InitItemInfo)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeItemInfoValidValues
	{
		/*[in,out]*/ AllColorableItemInfo* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(FreeItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(FreeItemInfo)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyItemInfoValidValues
	{
		/*[in,out]*/ AllColorableItemInfo* pDest;
		/*[in]*/ AllColorableItemInfo* pSource;
		HRESULT retValue;
	};

	STDMETHOD(CopyItemInfo)(
		/*[in,out]*/ AllColorableItemInfo* pDest,
		/*[in]*/ const AllColorableItemInfo* pSource)
	{
		VSL_DEFINE_MOCK_METHOD(CopyItemInfo)

		VSL_SET_VALIDVALUE(pDest);

		VSL_CHECK_VALIDVALUE_POINTER(pSource);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLORUTILITIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
