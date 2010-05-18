/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTLAYER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTLAYER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextLayerNotImpl :
	public IVsTextLayer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextLayerNotImpl)

public:

	typedef IVsTextLayer Interface;

	STDMETHOD(LocalLineIndexToBase)(
		/*[in]*/ long /*iLocalLine*/,
		/*[in]*/ CharIndex /*iLocalIndex*/,
		/*[out]*/ long* /*piBaseLine*/,
		/*[out]*/ CharIndex* /*piBaseIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BaseLineIndexToLocal)(
		/*[in]*/ long /*iBaseLine*/,
		/*[in]*/ CharIndex /*iBaseIndex*/,
		/*[out]*/ long* /*piLocalLine*/,
		/*[out]*/ CharIndex* /*piLocalIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LocalLineIndexToDeeperLayer)(
		/*[in]*/ IVsTextLayer* /*pTargetLayer*/,
		/*[in]*/ long /*iLocalLine*/,
		/*[in]*/ CharIndex /*iLocalIndex*/,
		/*[out]*/ long* /*piTargetLine*/,
		/*[out]*/ CharIndex* /*piTargetIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeeperLayerLineIndexToLocal)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IVsTextLayer* /*pTargetLayer*/,
		/*[in]*/ long /*iLayerLine*/,
		/*[in]*/ CharIndex /*iLayerIndex*/,
		/*[out]*/ long* /*piLocalLine*/,
		/*[out]*/ CharIndex* /*piLocalIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseBuffer)(
		/*[out]*/ IVsTextLines** /*ppiBuf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockBufferEx)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockBufferEx)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLengthOfLine)(
		/*[in]*/ long /*iLine*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineCount)(
		/*[out]*/ long* /*piLineCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastLineIndex)(
		/*[out]*/ long* /*piLine*/,
		/*[out]*/ long* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMarkerData)(
		/*[in]*/ long /*iTopLine*/,
		/*[in]*/ long /*iBottomLine*/,
		/*[out]*/ MARKERDATA* /*pMarkerData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseMarkerData)(
		/*[in]*/ MARKERDATA* /*pMarkerData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineDataEx)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iStartIndex*/,
		/*[in]*/ long /*iEndIndex*/,
		/*[out]*/ LINEDATAEX* /*pLineData*/,
		/*[in]*/ MARKERDATA* /*pMarkerData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseLineDataEx)(
		/*[in]*/ LINEDATAEX* /*pLineData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineText)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[out]*/ BSTR* /*pbstrBuf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyLineText)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ LPWSTR /*pszBuf*/,
		/*[in,out]*/ long* /*pcchBuf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReplaceLines)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ LPCWSTR /*pszText*/,
		/*[in]*/ long /*iNewLen*/,
		/*[out]*/ TextSpan* /*pChangedSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanReplaceLines)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ long /*iNewLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateTrackingPoint)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[out]*/ IVsTextTrackingPoint** /*ppMarker*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumLayerMarkers)(
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ long /*iMarkerType*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ IVsEnumLayerMarkers** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReplaceLinesEx)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ long /*iStartLine*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndLine*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ LPCWSTR /*pszText*/,
		/*[in]*/ long /*iNewLen*/,
		/*[out]*/ TextSpan* /*pChangedSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapLocalSpansToTextOriginatingLayer)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ IVsEnumTextSpans* /*pLocalSpanEnum*/,
		/*[out]*/ IVsTextLayer** /*ppTargetLayer*/,
		/*[out]*/ IVsEnumTextSpans** /*ppTargetSpanEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextLayerMockImpl :
	public IVsTextLayer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextLayerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextLayerMockImpl)

	typedef IVsTextLayer Interface;
	struct LocalLineIndexToBaseValidValues
	{
		/*[in]*/ long iLocalLine;
		/*[in]*/ CharIndex iLocalIndex;
		/*[out]*/ long* piBaseLine;
		/*[out]*/ CharIndex* piBaseIndex;
		HRESULT retValue;
	};

	STDMETHOD(LocalLineIndexToBase)(
		/*[in]*/ long iLocalLine,
		/*[in]*/ CharIndex iLocalIndex,
		/*[out]*/ long* piBaseLine,
		/*[out]*/ CharIndex* piBaseIndex)
	{
		VSL_DEFINE_MOCK_METHOD(LocalLineIndexToBase)

		VSL_CHECK_VALIDVALUE(iLocalLine);

		VSL_CHECK_VALIDVALUE(iLocalIndex);

		VSL_SET_VALIDVALUE(piBaseLine);

		VSL_SET_VALIDVALUE(piBaseIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct BaseLineIndexToLocalValidValues
	{
		/*[in]*/ long iBaseLine;
		/*[in]*/ CharIndex iBaseIndex;
		/*[out]*/ long* piLocalLine;
		/*[out]*/ CharIndex* piLocalIndex;
		HRESULT retValue;
	};

	STDMETHOD(BaseLineIndexToLocal)(
		/*[in]*/ long iBaseLine,
		/*[in]*/ CharIndex iBaseIndex,
		/*[out]*/ long* piLocalLine,
		/*[out]*/ CharIndex* piLocalIndex)
	{
		VSL_DEFINE_MOCK_METHOD(BaseLineIndexToLocal)

		VSL_CHECK_VALIDVALUE(iBaseLine);

		VSL_CHECK_VALIDVALUE(iBaseIndex);

		VSL_SET_VALIDVALUE(piLocalLine);

		VSL_SET_VALIDVALUE(piLocalIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct LocalLineIndexToDeeperLayerValidValues
	{
		/*[in]*/ IVsTextLayer* pTargetLayer;
		/*[in]*/ long iLocalLine;
		/*[in]*/ CharIndex iLocalIndex;
		/*[out]*/ long* piTargetLine;
		/*[out]*/ CharIndex* piTargetIndex;
		HRESULT retValue;
	};

	STDMETHOD(LocalLineIndexToDeeperLayer)(
		/*[in]*/ IVsTextLayer* pTargetLayer,
		/*[in]*/ long iLocalLine,
		/*[in]*/ CharIndex iLocalIndex,
		/*[out]*/ long* piTargetLine,
		/*[out]*/ CharIndex* piTargetIndex)
	{
		VSL_DEFINE_MOCK_METHOD(LocalLineIndexToDeeperLayer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTargetLayer);

		VSL_CHECK_VALIDVALUE(iLocalLine);

		VSL_CHECK_VALIDVALUE(iLocalIndex);

		VSL_SET_VALIDVALUE(piTargetLine);

		VSL_SET_VALIDVALUE(piTargetIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeeperLayerLineIndexToLocalValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IVsTextLayer* pTargetLayer;
		/*[in]*/ long iLayerLine;
		/*[in]*/ CharIndex iLayerIndex;
		/*[out]*/ long* piLocalLine;
		/*[out]*/ CharIndex* piLocalIndex;
		HRESULT retValue;
	};

	STDMETHOD(DeeperLayerLineIndexToLocal)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IVsTextLayer* pTargetLayer,
		/*[in]*/ long iLayerLine,
		/*[in]*/ CharIndex iLayerIndex,
		/*[out]*/ long* piLocalLine,
		/*[out]*/ CharIndex* piLocalIndex)
	{
		VSL_DEFINE_MOCK_METHOD(DeeperLayerLineIndexToLocal)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTargetLayer);

		VSL_CHECK_VALIDVALUE(iLayerLine);

		VSL_CHECK_VALIDVALUE(iLayerIndex);

		VSL_SET_VALIDVALUE(piLocalLine);

		VSL_SET_VALIDVALUE(piLocalIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseBufferValidValues
	{
		/*[out]*/ IVsTextLines** ppiBuf;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseBuffer)(
		/*[out]*/ IVsTextLines** ppiBuf)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseBuffer)

		VSL_SET_VALIDVALUE_INTERFACE(ppiBuf);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockBufferExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(LockBufferEx)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(LockBufferEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockBufferExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UnlockBufferEx)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UnlockBufferEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLengthOfLineValidValues
	{
		/*[in]*/ long iLine;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetLengthOfLine)(
		/*[in]*/ long iLine,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetLengthOfLine)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineCountValidValues
	{
		/*[out]*/ long* piLineCount;
		HRESULT retValue;
	};

	STDMETHOD(GetLineCount)(
		/*[out]*/ long* piLineCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineCount)

		VSL_SET_VALIDVALUE(piLineCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastLineIndexValidValues
	{
		/*[out]*/ long* piLine;
		/*[out]*/ long* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetLastLineIndex)(
		/*[out]*/ long* piLine,
		/*[out]*/ long* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastLineIndex)

		VSL_SET_VALIDVALUE(piLine);

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMarkerDataValidValues
	{
		/*[in]*/ long iTopLine;
		/*[in]*/ long iBottomLine;
		/*[out]*/ MARKERDATA* pMarkerData;
		HRESULT retValue;
	};

	STDMETHOD(GetMarkerData)(
		/*[in]*/ long iTopLine,
		/*[in]*/ long iBottomLine,
		/*[out]*/ MARKERDATA* pMarkerData)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarkerData)

		VSL_CHECK_VALIDVALUE(iTopLine);

		VSL_CHECK_VALIDVALUE(iBottomLine);

		VSL_SET_VALIDVALUE(pMarkerData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseMarkerDataValidValues
	{
		/*[in]*/ MARKERDATA* pMarkerData;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseMarkerData)(
		/*[in]*/ MARKERDATA* pMarkerData)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseMarkerData)

		VSL_CHECK_VALIDVALUE_POINTER(pMarkerData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineDataExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ long iLine;
		/*[in]*/ long iStartIndex;
		/*[in]*/ long iEndIndex;
		/*[out]*/ LINEDATAEX* pLineData;
		/*[in]*/ MARKERDATA* pMarkerData;
		HRESULT retValue;
	};

	STDMETHOD(GetLineDataEx)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ long iLine,
		/*[in]*/ long iStartIndex,
		/*[in]*/ long iEndIndex,
		/*[out]*/ LINEDATAEX* pLineData,
		/*[in]*/ MARKERDATA* pMarkerData)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineDataEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_SET_VALIDVALUE(pLineData);

		VSL_CHECK_VALIDVALUE_POINTER(pMarkerData);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseLineDataExValidValues
	{
		/*[in]*/ LINEDATAEX* pLineData;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseLineDataEx)(
		/*[in]*/ LINEDATAEX* pLineData)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseLineDataEx)

		VSL_CHECK_VALIDVALUE_POINTER(pLineData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineTextValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[out]*/ BSTR* pbstrBuf;
		HRESULT retValue;
	};

	STDMETHOD(GetLineText)(
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[out]*/ BSTR* pbstrBuf)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineText)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrBuf);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyLineTextValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ LPWSTR pszBuf;
		/*[in,out]*/ long* pcchBuf;
		HRESULT retValue;
	};

	STDMETHOD(CopyLineText)(
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ LPWSTR pszBuf,
		/*[in,out]*/ long* pcchBuf)
	{
		VSL_DEFINE_MOCK_METHOD(CopyLineText)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBuf);

		VSL_SET_VALIDVALUE(pcchBuf);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceLinesValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ LPCWSTR pszText;
		/*[in]*/ long iNewLen;
		/*[out]*/ TextSpan* pChangedSpan;
		HRESULT retValue;
	};

	STDMETHOD(ReplaceLines)(
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ LPCWSTR pszText,
		/*[in]*/ long iNewLen,
		/*[out]*/ TextSpan* pChangedSpan)
	{
		VSL_DEFINE_MOCK_METHOD(ReplaceLines)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iNewLen);

		VSL_SET_VALIDVALUE(pChangedSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanReplaceLinesValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ long iNewLen;
		HRESULT retValue;
	};

	STDMETHOD(CanReplaceLines)(
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ long iNewLen)
	{
		VSL_DEFINE_MOCK_METHOD(CanReplaceLines)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE(iNewLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateTrackingPointValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[out]*/ IVsTextTrackingPoint** ppMarker;
		HRESULT retValue;
	};

	STDMETHOD(CreateTrackingPoint)(
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[out]*/ IVsTextTrackingPoint** ppMarker)
	{
		VSL_DEFINE_MOCK_METHOD(CreateTrackingPoint)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppMarker);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumLayerMarkersValidValues
	{
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ long iMarkerType;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ IVsEnumLayerMarkers** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumLayerMarkers)(
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ long iMarkerType,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ IVsEnumLayerMarkers** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumLayerMarkers)

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE(iMarkerType);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceLinesExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ long iStartLine;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndLine;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ LPCWSTR pszText;
		/*[in]*/ long iNewLen;
		/*[out]*/ TextSpan* pChangedSpan;
		HRESULT retValue;
	};

	STDMETHOD(ReplaceLinesEx)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ long iStartLine,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndLine,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ LPCWSTR pszText,
		/*[in]*/ long iNewLen,
		/*[out]*/ TextSpan* pChangedSpan)
	{
		VSL_DEFINE_MOCK_METHOD(ReplaceLinesEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(iStartLine);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndLine);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iNewLen);

		VSL_SET_VALIDVALUE(pChangedSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapLocalSpansToTextOriginatingLayerValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ IVsEnumTextSpans* pLocalSpanEnum;
		/*[out]*/ IVsTextLayer** ppTargetLayer;
		/*[out]*/ IVsEnumTextSpans** ppTargetSpanEnum;
		HRESULT retValue;
	};

	STDMETHOD(MapLocalSpansToTextOriginatingLayer)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ IVsEnumTextSpans* pLocalSpanEnum,
		/*[out]*/ IVsTextLayer** ppTargetLayer,
		/*[out]*/ IVsEnumTextSpans** ppTargetSpanEnum)
	{
		VSL_DEFINE_MOCK_METHOD(MapLocalSpansToTextOriginatingLayer)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLocalSpanEnum);

		VSL_SET_VALIDVALUE_INTERFACE(ppTargetLayer);

		VSL_SET_VALIDVALUE_INTERFACE(ppTargetSpanEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTLAYER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
