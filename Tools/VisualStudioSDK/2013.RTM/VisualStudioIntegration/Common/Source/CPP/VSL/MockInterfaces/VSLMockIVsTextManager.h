/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextManagerNotImpl :
	public IVsTextManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManagerNotImpl)

public:

	typedef IVsTextManager Interface;

	STDMETHOD(RegisterView)(
		/*[in]*/ IVsTextView* /*pView*/,
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumViews)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[out]*/ IVsEnumTextViews** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateSelectionAction)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[out]*/ IVsTextSelectionAction** /*ppAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapFilenameToLanguageSID)(
		/*[in]*/ const WCHAR* /*pszFileName*/,
		/*[out]*/ GUID* /*pguidLangSID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRegisteredMarkerTypeID)(
		/*[in]*/ const GUID* /*pguidMarker*/,
		/*[out]*/ long* /*piMarkerTypeID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMarkerTypeInterface)(
		/*[in]*/ long /*iMarkerTypeID*/,
		/*[out]*/ IVsTextMarkerType** /*ppMarkerType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMarkerTypeCount)(
		/*[out]*/ long* /*piMarkerTypeCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetActiveView)(
		/*[in]*/ BOOL /*fMustHaveFocus*/,
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[out]*/ IVsTextView** /*ppView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserPreferences)(
		/*[out]*/ VIEWPREFERENCES* /*pViewPrefs*/,
		/*[out]*/ FRAMEPREFERENCES* /*pFramePrefs*/,
		/*[in,out]*/ LANGPREFERENCES* /*pLangPrefs*/,
		/*[in,out]*/ FONTCOLORPREFERENCES* /*pColorPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUserPreferences)(
		/*[in]*/ const VIEWPREFERENCES* /*pViewPrefs*/,
		/*[in]*/ const FRAMEPREFERENCES* /*pFramePrefs*/,
		/*[in]*/ const LANGPREFERENCES* /*pLangPrefs*/,
		/*[in]*/ const FONTCOLORPREFERENCES* /*pColorPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFileChangeAdvise)(
		/*[in]*/ const WCHAR* /*pszFileName*/,
		/*[in]*/ BOOL /*fStart*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SuspendFileChangeAdvise)(
		/*[in]*/ const WCHAR* /*pszFileName*/,
		/*[in]*/ BOOL /*fSuspend*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToPosition)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ REFGUID /*guidDocViewType*/,
		/*[in]*/ long /*iPos*/,
		/*[in]*/ long /*iLen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToLineAndColumn)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ REFGUID /*guidDocViewType*/,
		/*[in]*/ long /*iStartRow*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndRow*/,
		/*[in]*/ CharIndex /*iEndIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBufferSccStatus)(
		/*[in]*/ IVsUserData* /*pBufData*/,
		/*[out]*/ BOOL* /*pbNonEditable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterBuffer)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterBuffer)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumBuffers)(
		/*[out]*/ IVsEnumTextBuffers** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPerLanguagePreferences)(
		/*[out]*/ LANGPREFERENCES* /*pLangPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPerLanguagePreferences)(
		/*[in]*/ const LANGPREFERENCES* /*pLangPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AttemptToCheckOutBufferFromScc)(
		/*[in]*/ IVsUserData* /*pBufData*/,
		/*[out]*/ BOOL* /*pfCheckoutSucceeded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetShortcutManager)(
		/*[out]*/ IVsShortcutManager** /*ppShortcutMgr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterIndependentView)(
		/*[in]*/ IUnknown* /*pUnk*/,
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterIndependentView)(
		/*[in]*/ IUnknown* /*pUnk*/,
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IgnoreNextFileChange)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdjustFileChangeIgnoreCount)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ BOOL /*fIgnore*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBufferSccStatus2)(
		/*[in]*/ const WCHAR* /*pszFileName*/,
		/*[out]*/ BOOL* /*pbNonEditable*/,
		/*[out]*/ int* /*piStatusFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AttemptToCheckOutBufferFromScc2)(
		/*[in]*/ const WCHAR* /*pszFileName*/,
		/*[out]*/ BOOL* /*pfCheckoutSucceeded*/,
		/*[out]*/ int* /*piStatusFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumLanguageServices)(
		/*[out]*/ IVsEnumGUID** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumIndependentViews)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[out]*/ IVsEnumIndependentViews** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextManagerMockImpl :
	public IVsTextManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextManagerMockImpl)

	typedef IVsTextManager Interface;
	struct RegisterViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(RegisterView)(
		/*[in]*/ IVsTextView* pView,
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumViewsValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[out]*/ IVsEnumTextViews** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumViews)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[out]*/ IVsEnumTextViews** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumViews)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateSelectionActionValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[out]*/ IVsTextSelectionAction** ppAction;
		HRESULT retValue;
	};

	STDMETHOD(CreateSelectionAction)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[out]*/ IVsTextSelectionAction** ppAction)
	{
		VSL_DEFINE_MOCK_METHOD(CreateSelectionAction)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE_INTERFACE(ppAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapFilenameToLanguageSIDValidValues
	{
		/*[in]*/ WCHAR* pszFileName;
		/*[out]*/ GUID* pguidLangSID;
		HRESULT retValue;
	};

	STDMETHOD(MapFilenameToLanguageSID)(
		/*[in]*/ const WCHAR* pszFileName,
		/*[out]*/ GUID* pguidLangSID)
	{
		VSL_DEFINE_MOCK_METHOD(MapFilenameToLanguageSID)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_SET_VALIDVALUE(pguidLangSID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRegisteredMarkerTypeIDValidValues
	{
		/*[in]*/ GUID* pguidMarker;
		/*[out]*/ long* piMarkerTypeID;
		HRESULT retValue;
	};

	STDMETHOD(GetRegisteredMarkerTypeID)(
		/*[in]*/ const GUID* pguidMarker,
		/*[out]*/ long* piMarkerTypeID)
	{
		VSL_DEFINE_MOCK_METHOD(GetRegisteredMarkerTypeID)

		VSL_CHECK_VALIDVALUE_POINTER(pguidMarker);

		VSL_SET_VALIDVALUE(piMarkerTypeID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMarkerTypeInterfaceValidValues
	{
		/*[in]*/ long iMarkerTypeID;
		/*[out]*/ IVsTextMarkerType** ppMarkerType;
		HRESULT retValue;
	};

	STDMETHOD(GetMarkerTypeInterface)(
		/*[in]*/ long iMarkerTypeID,
		/*[out]*/ IVsTextMarkerType** ppMarkerType)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarkerTypeInterface)

		VSL_CHECK_VALIDVALUE(iMarkerTypeID);

		VSL_SET_VALIDVALUE_INTERFACE(ppMarkerType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMarkerTypeCountValidValues
	{
		/*[out]*/ long* piMarkerTypeCount;
		HRESULT retValue;
	};

	STDMETHOD(GetMarkerTypeCount)(
		/*[out]*/ long* piMarkerTypeCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetMarkerTypeCount)

		VSL_SET_VALIDVALUE(piMarkerTypeCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetActiveViewValidValues
	{
		/*[in]*/ BOOL fMustHaveFocus;
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[out]*/ IVsTextView** ppView;
		HRESULT retValue;
	};

	STDMETHOD(GetActiveView)(
		/*[in]*/ BOOL fMustHaveFocus,
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[out]*/ IVsTextView** ppView)
	{
		VSL_DEFINE_MOCK_METHOD(GetActiveView)

		VSL_CHECK_VALIDVALUE(fMustHaveFocus);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE_INTERFACE(ppView);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserPreferencesValidValues
	{
		/*[out]*/ VIEWPREFERENCES* pViewPrefs;
		/*[out]*/ FRAMEPREFERENCES* pFramePrefs;
		/*[in,out]*/ LANGPREFERENCES* pLangPrefs;
		/*[in,out]*/ FONTCOLORPREFERENCES* pColorPrefs;
		HRESULT retValue;
	};

	STDMETHOD(GetUserPreferences)(
		/*[out]*/ VIEWPREFERENCES* pViewPrefs,
		/*[out]*/ FRAMEPREFERENCES* pFramePrefs,
		/*[in,out]*/ LANGPREFERENCES* pLangPrefs,
		/*[in,out]*/ FONTCOLORPREFERENCES* pColorPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserPreferences)

		VSL_SET_VALIDVALUE(pViewPrefs);

		VSL_SET_VALIDVALUE(pFramePrefs);

		VSL_SET_VALIDVALUE(pLangPrefs);

		VSL_SET_VALIDVALUE(pColorPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUserPreferencesValidValues
	{
		/*[in]*/ VIEWPREFERENCES* pViewPrefs;
		/*[in]*/ FRAMEPREFERENCES* pFramePrefs;
		/*[in]*/ LANGPREFERENCES* pLangPrefs;
		/*[in]*/ FONTCOLORPREFERENCES* pColorPrefs;
		HRESULT retValue;
	};

	STDMETHOD(SetUserPreferences)(
		/*[in]*/ const VIEWPREFERENCES* pViewPrefs,
		/*[in]*/ const FRAMEPREFERENCES* pFramePrefs,
		/*[in]*/ const LANGPREFERENCES* pLangPrefs,
		/*[in]*/ const FONTCOLORPREFERENCES* pColorPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(SetUserPreferences)

		VSL_CHECK_VALIDVALUE_POINTER(pViewPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pFramePrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pLangPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pColorPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFileChangeAdviseValidValues
	{
		/*[in]*/ WCHAR* pszFileName;
		/*[in]*/ BOOL fStart;
		HRESULT retValue;
	};

	STDMETHOD(SetFileChangeAdvise)(
		/*[in]*/ const WCHAR* pszFileName,
		/*[in]*/ BOOL fStart)
	{
		VSL_DEFINE_MOCK_METHOD(SetFileChangeAdvise)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE(fStart);

		VSL_RETURN_VALIDVALUES();
	}
	struct SuspendFileChangeAdviseValidValues
	{
		/*[in]*/ WCHAR* pszFileName;
		/*[in]*/ BOOL fSuspend;
		HRESULT retValue;
	};

	STDMETHOD(SuspendFileChangeAdvise)(
		/*[in]*/ const WCHAR* pszFileName,
		/*[in]*/ BOOL fSuspend)
	{
		VSL_DEFINE_MOCK_METHOD(SuspendFileChangeAdvise)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE(fSuspend);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToPositionValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ REFGUID guidDocViewType;
		/*[in]*/ long iPos;
		/*[in]*/ long iLen;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToPosition)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ REFGUID guidDocViewType,
		/*[in]*/ long iPos,
		/*[in]*/ long iLen)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToPosition)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(guidDocViewType);

		VSL_CHECK_VALIDVALUE(iPos);

		VSL_CHECK_VALIDVALUE(iLen);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToLineAndColumnValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ REFGUID guidDocViewType;
		/*[in]*/ long iStartRow;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndRow;
		/*[in]*/ CharIndex iEndIndex;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToLineAndColumn)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ REFGUID guidDocViewType,
		/*[in]*/ long iStartRow,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndRow,
		/*[in]*/ CharIndex iEndIndex)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToLineAndColumn)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(guidDocViewType);

		VSL_CHECK_VALIDVALUE(iStartRow);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndRow);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBufferSccStatusValidValues
	{
		/*[in]*/ IVsUserData* pBufData;
		/*[out]*/ BOOL* pbNonEditable;
		HRESULT retValue;
	};

	STDMETHOD(GetBufferSccStatus)(
		/*[in]*/ IVsUserData* pBufData,
		/*[out]*/ BOOL* pbNonEditable)
	{
		VSL_DEFINE_MOCK_METHOD(GetBufferSccStatus)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBufData);

		VSL_SET_VALIDVALUE(pbNonEditable);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterBufferValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(RegisterBuffer)(
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterBuffer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterBufferValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterBuffer)(
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterBuffer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumBuffersValidValues
	{
		/*[out]*/ IVsEnumTextBuffers** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumBuffers)(
		/*[out]*/ IVsEnumTextBuffers** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumBuffers)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPerLanguagePreferencesValidValues
	{
		/*[out]*/ LANGPREFERENCES* pLangPrefs;
		HRESULT retValue;
	};

	STDMETHOD(GetPerLanguagePreferences)(
		/*[out]*/ LANGPREFERENCES* pLangPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(GetPerLanguagePreferences)

		VSL_SET_VALIDVALUE(pLangPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPerLanguagePreferencesValidValues
	{
		/*[in]*/ LANGPREFERENCES* pLangPrefs;
		HRESULT retValue;
	};

	STDMETHOD(SetPerLanguagePreferences)(
		/*[in]*/ const LANGPREFERENCES* pLangPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(SetPerLanguagePreferences)

		VSL_CHECK_VALIDVALUE_POINTER(pLangPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct AttemptToCheckOutBufferFromSccValidValues
	{
		/*[in]*/ IVsUserData* pBufData;
		/*[out]*/ BOOL* pfCheckoutSucceeded;
		HRESULT retValue;
	};

	STDMETHOD(AttemptToCheckOutBufferFromScc)(
		/*[in]*/ IVsUserData* pBufData,
		/*[out]*/ BOOL* pfCheckoutSucceeded)
	{
		VSL_DEFINE_MOCK_METHOD(AttemptToCheckOutBufferFromScc)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBufData);

		VSL_SET_VALIDVALUE(pfCheckoutSucceeded);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetShortcutManagerValidValues
	{
		/*[out]*/ IVsShortcutManager** ppShortcutMgr;
		HRESULT retValue;
	};

	STDMETHOD(GetShortcutManager)(
		/*[out]*/ IVsShortcutManager** ppShortcutMgr)
	{
		VSL_DEFINE_MOCK_METHOD(GetShortcutManager)

		VSL_SET_VALIDVALUE_INTERFACE(ppShortcutMgr);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterIndependentViewValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(RegisterIndependentView)(
		/*[in]*/ IUnknown* pUnk,
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterIndependentView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterIndependentViewValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterIndependentView)(
		/*[in]*/ IUnknown* pUnk,
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterIndependentView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct IgnoreNextFileChangeValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		HRESULT retValue;
	};

	STDMETHOD(IgnoreNextFileChange)(
		/*[in]*/ IVsTextBuffer* pBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(IgnoreNextFileChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdjustFileChangeIgnoreCountValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ BOOL fIgnore;
		HRESULT retValue;
	};

	STDMETHOD(AdjustFileChangeIgnoreCount)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ BOOL fIgnore)
	{
		VSL_DEFINE_MOCK_METHOD(AdjustFileChangeIgnoreCount)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(fIgnore);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBufferSccStatus2ValidValues
	{
		/*[in]*/ WCHAR* pszFileName;
		/*[out]*/ BOOL* pbNonEditable;
		/*[out]*/ int* piStatusFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetBufferSccStatus2)(
		/*[in]*/ const WCHAR* pszFileName,
		/*[out]*/ BOOL* pbNonEditable,
		/*[out]*/ int* piStatusFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetBufferSccStatus2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_SET_VALIDVALUE(pbNonEditable);

		VSL_SET_VALIDVALUE(piStatusFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct AttemptToCheckOutBufferFromScc2ValidValues
	{
		/*[in]*/ WCHAR* pszFileName;
		/*[out]*/ BOOL* pfCheckoutSucceeded;
		/*[out]*/ int* piStatusFlags;
		HRESULT retValue;
	};

	STDMETHOD(AttemptToCheckOutBufferFromScc2)(
		/*[in]*/ const WCHAR* pszFileName,
		/*[out]*/ BOOL* pfCheckoutSucceeded,
		/*[out]*/ int* piStatusFlags)
	{
		VSL_DEFINE_MOCK_METHOD(AttemptToCheckOutBufferFromScc2)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_SET_VALIDVALUE(pfCheckoutSucceeded);

		VSL_SET_VALIDVALUE(piStatusFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumLanguageServicesValidValues
	{
		/*[out]*/ IVsEnumGUID** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumLanguageServices)(
		/*[out]*/ IVsEnumGUID** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumLanguageServices)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumIndependentViewsValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[out]*/ IVsEnumIndependentViews** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumIndependentViews)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[out]*/ IVsEnumIndependentViews** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumIndependentViews)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
