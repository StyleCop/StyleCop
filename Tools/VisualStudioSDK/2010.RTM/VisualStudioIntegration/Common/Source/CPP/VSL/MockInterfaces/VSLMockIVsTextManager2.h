/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextManager2NotImpl :
	public IVsTextManager2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManager2NotImpl)

public:

	typedef IVsTextManager2 Interface;

	STDMETHOD(GetBufferSccStatus3)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in,string]*/ LPCOLESTR /*pszFileName*/,
		/*[out]*/ BOOL* /*pbCheckoutSucceeded*/,
		/*[out]*/ int* /*piStatusFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AttemptToCheckOutBufferFromScc3)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in,string]*/ LPCOLESTR /*pszFileName*/,
		/*[in]*/ DWORD /*dwQueryEditFlags*/,
		/*[out]*/ BOOL* /*pbCheckoutSucceeded*/,
		/*[out]*/ int* /*piStatusFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserPreferences2)(
		/*[out]*/ VIEWPREFERENCES2* /*pViewPrefs*/,
		/*[out]*/ FRAMEPREFERENCES2* /*pFramePrefs*/,
		/*[in,out]*/ LANGPREFERENCES2* /*pLangPrefs*/,
		/*[in,out]*/ FONTCOLORPREFERENCES2* /*pColorPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUserPreferences2)(
		/*[in]*/ const VIEWPREFERENCES2* /*pViewPrefs*/,
		/*[in]*/ const FRAMEPREFERENCES2* /*pFramePrefs*/,
		/*[in]*/ const LANGPREFERENCES2* /*pLangPrefs*/,
		/*[in]*/ const FONTCOLORPREFERENCES2* /*pColorPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResetColorableItems)(
		/*[in]*/ GUID /*guidLang*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpansionManager)(
		/*[out]*/ IVsExpansionManager** /*pExpansionManager*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetActiveView2)(
		/*[in]*/ BOOL /*fMustHaveFocus*/,
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ VIEWFRAMETYPE /*grfIncludeViewFrameType*/,
		/*[out]*/ IVsTextView** /*ppView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToPosition2)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ REFGUID /*guidDocViewType*/,
		/*[in]*/ long /*iPos*/,
		/*[in]*/ long /*iLen*/,
		/*[in]*/ VIEWFRAMETYPE /*grfIncludeViewFrameType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateToLineAndColumn2)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ REFGUID /*guidDocViewType*/,
		/*[in]*/ long /*iStartRow*/,
		/*[in]*/ CharIndex /*iStartIndex*/,
		/*[in]*/ long /*iEndRow*/,
		/*[in]*/ CharIndex /*iEndIndex*/,
		/*[in]*/ VIEWFRAMETYPE /*grfIncludeViewFrameType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireReplaceAllInFilesBegin)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireReplaceAllInFilesEnd)()VSL_STDMETHOD_NOTIMPL
};

class IVsTextManager2MockImpl :
	public IVsTextManager2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManager2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextManager2MockImpl)

	typedef IVsTextManager2 Interface;
	struct GetBufferSccStatus3ValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in,string]*/ LPCOLESTR pszFileName;
		/*[out]*/ BOOL* pbCheckoutSucceeded;
		/*[out]*/ int* piStatusFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetBufferSccStatus3)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in,string]*/ LPCOLESTR pszFileName,
		/*[out]*/ BOOL* pbCheckoutSucceeded,
		/*[out]*/ int* piStatusFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetBufferSccStatus3)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_SET_VALIDVALUE(pbCheckoutSucceeded);

		VSL_SET_VALIDVALUE(piStatusFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct AttemptToCheckOutBufferFromScc3ValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in,string]*/ LPCOLESTR pszFileName;
		/*[in]*/ DWORD dwQueryEditFlags;
		/*[out]*/ BOOL* pbCheckoutSucceeded;
		/*[out]*/ int* piStatusFlags;
		HRESULT retValue;
	};

	STDMETHOD(AttemptToCheckOutBufferFromScc3)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in,string]*/ LPCOLESTR pszFileName,
		/*[in]*/ DWORD dwQueryEditFlags,
		/*[out]*/ BOOL* pbCheckoutSucceeded,
		/*[out]*/ int* piStatusFlags)
	{
		VSL_DEFINE_MOCK_METHOD(AttemptToCheckOutBufferFromScc3)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE(dwQueryEditFlags);

		VSL_SET_VALIDVALUE(pbCheckoutSucceeded);

		VSL_SET_VALIDVALUE(piStatusFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserPreferences2ValidValues
	{
		/*[out]*/ VIEWPREFERENCES2* pViewPrefs;
		/*[out]*/ FRAMEPREFERENCES2* pFramePrefs;
		/*[in,out]*/ LANGPREFERENCES2* pLangPrefs;
		/*[in,out]*/ FONTCOLORPREFERENCES2* pColorPrefs;
		HRESULT retValue;
	};

	STDMETHOD(GetUserPreferences2)(
		/*[out]*/ VIEWPREFERENCES2* pViewPrefs,
		/*[out]*/ FRAMEPREFERENCES2* pFramePrefs,
		/*[in,out]*/ LANGPREFERENCES2* pLangPrefs,
		/*[in,out]*/ FONTCOLORPREFERENCES2* pColorPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserPreferences2)

		VSL_SET_VALIDVALUE(pViewPrefs);

		VSL_SET_VALIDVALUE(pFramePrefs);

		VSL_SET_VALIDVALUE(pLangPrefs);

		VSL_SET_VALIDVALUE(pColorPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUserPreferences2ValidValues
	{
		/*[in]*/ VIEWPREFERENCES2* pViewPrefs;
		/*[in]*/ FRAMEPREFERENCES2* pFramePrefs;
		/*[in]*/ LANGPREFERENCES2* pLangPrefs;
		/*[in]*/ FONTCOLORPREFERENCES2* pColorPrefs;
		HRESULT retValue;
	};

	STDMETHOD(SetUserPreferences2)(
		/*[in]*/ const VIEWPREFERENCES2* pViewPrefs,
		/*[in]*/ const FRAMEPREFERENCES2* pFramePrefs,
		/*[in]*/ const LANGPREFERENCES2* pLangPrefs,
		/*[in]*/ const FONTCOLORPREFERENCES2* pColorPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(SetUserPreferences2)

		VSL_CHECK_VALIDVALUE_POINTER(pViewPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pFramePrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pLangPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pColorPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetColorableItemsValidValues
	{
		/*[in]*/ GUID guidLang;
		HRESULT retValue;
	};

	STDMETHOD(ResetColorableItems)(
		/*[in]*/ GUID guidLang)
	{
		VSL_DEFINE_MOCK_METHOD(ResetColorableItems)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpansionManagerValidValues
	{
		/*[out]*/ IVsExpansionManager** pExpansionManager;
		HRESULT retValue;
	};

	STDMETHOD(GetExpansionManager)(
		/*[out]*/ IVsExpansionManager** pExpansionManager)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpansionManager)

		VSL_SET_VALIDVALUE_INTERFACE(pExpansionManager);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetActiveView2ValidValues
	{
		/*[in]*/ BOOL fMustHaveFocus;
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType;
		/*[out]*/ IVsTextView** ppView;
		HRESULT retValue;
	};

	STDMETHOD(GetActiveView2)(
		/*[in]*/ BOOL fMustHaveFocus,
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType,
		/*[out]*/ IVsTextView** ppView)
	{
		VSL_DEFINE_MOCK_METHOD(GetActiveView2)

		VSL_CHECK_VALIDVALUE(fMustHaveFocus);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(grfIncludeViewFrameType);

		VSL_SET_VALIDVALUE_INTERFACE(ppView);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToPosition2ValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ REFGUID guidDocViewType;
		/*[in]*/ long iPos;
		/*[in]*/ long iLen;
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToPosition2)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ REFGUID guidDocViewType,
		/*[in]*/ long iPos,
		/*[in]*/ long iLen,
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToPosition2)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(guidDocViewType);

		VSL_CHECK_VALIDVALUE(iPos);

		VSL_CHECK_VALIDVALUE(iLen);

		VSL_CHECK_VALIDVALUE(grfIncludeViewFrameType);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateToLineAndColumn2ValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ REFGUID guidDocViewType;
		/*[in]*/ long iStartRow;
		/*[in]*/ CharIndex iStartIndex;
		/*[in]*/ long iEndRow;
		/*[in]*/ CharIndex iEndIndex;
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType;
		HRESULT retValue;
	};

	STDMETHOD(NavigateToLineAndColumn2)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ REFGUID guidDocViewType,
		/*[in]*/ long iStartRow,
		/*[in]*/ CharIndex iStartIndex,
		/*[in]*/ long iEndRow,
		/*[in]*/ CharIndex iEndIndex,
		/*[in]*/ VIEWFRAMETYPE grfIncludeViewFrameType)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateToLineAndColumn2)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(guidDocViewType);

		VSL_CHECK_VALIDVALUE(iStartRow);

		VSL_CHECK_VALIDVALUE(iStartIndex);

		VSL_CHECK_VALIDVALUE(iEndRow);

		VSL_CHECK_VALIDVALUE(iEndIndex);

		VSL_CHECK_VALIDVALUE(grfIncludeViewFrameType);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireReplaceAllInFilesBeginValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FireReplaceAllInFilesBegin)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FireReplaceAllInFilesBegin)

		VSL_RETURN_VALIDVALUES();
	}
	struct FireReplaceAllInFilesEndValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FireReplaceAllInFilesEnd)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FireReplaceAllInFilesEnd)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
