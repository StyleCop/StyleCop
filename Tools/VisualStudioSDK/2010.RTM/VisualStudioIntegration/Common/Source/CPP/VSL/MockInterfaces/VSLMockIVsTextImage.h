/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextImageNotImpl :
	public IVsTextImage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImageNotImpl)

public:

	typedef IVsTextImage Interface;

	STDMETHOD(GetCharSize)(
		/*[out,retval]*/ LONG* /*pcch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineSize)(
		/*[out,retval]*/ LONG* /*pcLines*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOffsetOfTextAddress)(
		/*[in]*/ TextAddress /*ta*/,
		/*[out,retval]*/ LONG* /*piOffset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextAddressOfOffset)(
		/*[in]*/ LONG /*iOffset*/,
		/*[out,retval]*/ TextAddress* /*pta*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Replace)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ const TextSpan* /*pts*/,
		/*[in]*/ LONG /*cch*/,
		/*[in,size_is(cch)]*/ LPCOLESTR /*pchText*/,
		/*[out,retval]*/ TextSpan* /*ptsChanged*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSpanLength)(
		/*[in]*/ const TextSpan* /*pts*/,
		/*[out,retval]*/ LONG* /*pcch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTextBSTR)(
		/*[in]*/ const TextSpan* /*pts*/,
		/*[out,retval]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

#pragma warning(push)
#pragma warning(disable:4100) // unreferenced formal parameter(cch). It is needed for sal annotation.
	STDMETHOD(GetText)(
		/*[in]*/ const TextSpan* /*pts*/,
		/*[in]*/ LONG cch /*cch*/,
		/*[out,size_is(cch)]*/ _Out_cap_(cch) LPOLESTR /*psz*/)VSL_STDMETHOD_NOTIMPL
#pragma warning(pop)

	STDMETHOD(GetLineLength)(
		/*[in]*/ LONG /*iLine*/,
		/*[out,retval]*/ LONG* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLine)(
		/*[in]*/ DWORD /*grfGet*/,
		/*[in]*/ LONG /*iLine*/,
		/*[in]*/ LONG /*iStartIndex*/,
		/*[in]*/ LONG /*iEndIndex*/,
		/*[out,retval]*/ LINEDATAEX* /*pLineData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseLine)(
		/*[in]*/ LINEDATAEX* /*pLineData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseTextImageEvents)(
		/*[in]*/ IVsTextImageEvents* /*pSink*/,
		/*[out,retval]*/ DWORD* /*pCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseTextImageEvents)(
		/*[in]*/ DWORD /*Cookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockImage)(
		/*[in]*/ DWORD /*grfLock*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockImage)(
		/*[in]*/ DWORD /*grfLock*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextImageMockImpl :
	public IVsTextImage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextImageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextImageMockImpl)

	typedef IVsTextImage Interface;
	struct GetCharSizeValidValues
	{
		/*[out,retval]*/ LONG* pcch;
		HRESULT retValue;
	};

	STDMETHOD(GetCharSize)(
		/*[out,retval]*/ LONG* pcch)
	{
		VSL_DEFINE_MOCK_METHOD(GetCharSize)

		VSL_SET_VALIDVALUE(pcch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineSizeValidValues
	{
		/*[out,retval]*/ LONG* pcLines;
		HRESULT retValue;
	};

	STDMETHOD(GetLineSize)(
		/*[out,retval]*/ LONG* pcLines)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineSize)

		VSL_SET_VALIDVALUE(pcLines);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOffsetOfTextAddressValidValues
	{
		/*[in]*/ TextAddress ta;
		/*[out,retval]*/ LONG* piOffset;
		HRESULT retValue;
	};

	STDMETHOD(GetOffsetOfTextAddress)(
		/*[in]*/ TextAddress ta,
		/*[out,retval]*/ LONG* piOffset)
	{
		VSL_DEFINE_MOCK_METHOD(GetOffsetOfTextAddress)

		VSL_CHECK_VALIDVALUE(ta);

		VSL_SET_VALIDVALUE(piOffset);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextAddressOfOffsetValidValues
	{
		/*[in]*/ LONG iOffset;
		/*[out,retval]*/ TextAddress* pta;
		HRESULT retValue;
	};

	STDMETHOD(GetTextAddressOfOffset)(
		/*[in]*/ LONG iOffset,
		/*[out,retval]*/ TextAddress* pta)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextAddressOfOffset)

		VSL_CHECK_VALIDVALUE(iOffset);

		VSL_SET_VALIDVALUE(pta);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ TextSpan* pts;
		/*[in]*/ LONG cch;
		/*[in,size_is(cch)]*/ LPCOLESTR pchText;
		/*[out,retval]*/ TextSpan* ptsChanged;
		HRESULT retValue;
	};

	STDMETHOD(Replace)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ const TextSpan* pts,
		/*[in]*/ LONG cch,
		/*[in,size_is(cch)]*/ LPCOLESTR pchText,
		/*[out,retval]*/ TextSpan* ptsChanged)
	{
		VSL_DEFINE_MOCK_METHOD(Replace)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_CHECK_VALIDVALUE_STRINGW(pchText);

		VSL_SET_VALIDVALUE(ptsChanged);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSpanLengthValidValues
	{
		/*[in]*/ TextSpan* pts;
		/*[out,retval]*/ LONG* pcch;
		HRESULT retValue;
	};

	STDMETHOD(GetSpanLength)(
		/*[in]*/ const TextSpan* pts,
		/*[out,retval]*/ LONG* pcch)
	{
		VSL_DEFINE_MOCK_METHOD(GetSpanLength)

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_SET_VALIDVALUE(pcch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextBSTRValidValues
	{
		/*[in]*/ TextSpan* pts;
		/*[out,retval]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetTextBSTR)(
		/*[in]*/ const TextSpan* pts,
		/*[out,retval]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetTextBSTR)

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[in]*/ TextSpan* pts;
		/*[in]*/ LONG cch;
		/*[out,size_is(cch)]*/ LPOLESTR psz;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[in]*/ const TextSpan* pts,
		/*[in]*/ LONG cch,
		/*[out,size_is(cch)]*/ _Out_cap_(cch) LPOLESTR psz)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_CHECK_VALIDVALUE(cch);

		VSL_SET_VALIDVALUE_STRINGW(psz, cch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineLengthValidValues
	{
		/*[in]*/ LONG iLine;
		/*[out,retval]*/ LONG* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetLineLength)(
		/*[in]*/ LONG iLine,
		/*[out,retval]*/ LONG* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineLength)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineValidValues
	{
		/*[in]*/ DWORD grfGet;
		/*[in]*/ LONG iLine;
		/*[in]*/ LONG iStartIndex;
		/*[in]*/ LONG iEndIndex;
		/*[out,retval]*/ LINEDATAEX* pLineData;
		HRESULT retValue;
	};

	STDMETHOD(GetLine)(
		/*[in]*/ DWORD grfGet,
		/*[in]*/ LONG iLine,
		/*[in]*/ LONG iStartIndex,
		/*[in]*/ LONG iEndIndex,
		/*[out,retval]*/ LINEDATAEX* pLineData)
	{
		VSL_DEFINE_MOCK_METHOD(GetLine)

		VSL_CHECK_VALIDVALUE(grfGet);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_SET_VALIDVALUE(pLineData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseLineValidValues
	{
		/*[in]*/ LINEDATAEX* pLineData;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseLine)(
		/*[in]*/ LINEDATAEX* pLineData)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseLine)

		VSL_CHECK_VALIDVALUE_POINTER(pLineData);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseTextImageEventsValidValues
	{
		/*[in]*/ IVsTextImageEvents* pSink;
		/*[out,retval]*/ DWORD* pCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseTextImageEvents)(
		/*[in]*/ IVsTextImageEvents* pSink,
		/*[out,retval]*/ DWORD* pCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseTextImageEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseTextImageEventsValidValues
	{
		/*[in]*/ DWORD Cookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseTextImageEvents)(
		/*[in]*/ DWORD Cookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseTextImageEvents)

		VSL_CHECK_VALIDVALUE(Cookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockImageValidValues
	{
		/*[in]*/ DWORD grfLock;
		HRESULT retValue;
	};

	STDMETHOD(LockImage)(
		/*[in]*/ DWORD grfLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockImage)

		VSL_CHECK_VALIDVALUE(grfLock);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockImageValidValues
	{
		/*[in]*/ DWORD grfLock;
		HRESULT retValue;
	};

	STDMETHOD(UnlockImage)(
		/*[in]*/ DWORD grfLock)
	{
		VSL_DEFINE_MOCK_METHOD(UnlockImage)

		VSL_CHECK_VALIDVALUE(grfLock);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTIMAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
