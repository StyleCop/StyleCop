/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMANAGEREVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMANAGEREVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextManagerEvents2NotImpl :
	public IVsTextManagerEvents2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManagerEvents2NotImpl)

public:

	typedef IVsTextManagerEvents2 Interface;

	STDMETHOD(OnRegisterMarkerType)(
		/*[in]*/ long /*iMarkerType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRegisterView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnUnregisterView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnUserPreferencesChanged2)(
		/*[in]*/ const VIEWPREFERENCES2* /*pViewPrefs*/,
		/*[in]*/ const FRAMEPREFERENCES2* /*pFramePrefs*/,
		/*[in]*/ const LANGPREFERENCES2* /*pLangPrefs*/,
		/*[in]*/ const FONTCOLORPREFERENCES2* /*pColorPrefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnReplaceAllInFilesBegin)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnReplaceAllInFilesEnd)()VSL_STDMETHOD_NOTIMPL
};

class IVsTextManagerEvents2MockImpl :
	public IVsTextManagerEvents2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextManagerEvents2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextManagerEvents2MockImpl)

	typedef IVsTextManagerEvents2 Interface;
	struct OnRegisterMarkerTypeValidValues
	{
		/*[in]*/ long iMarkerType;
		HRESULT retValue;
	};

	STDMETHOD(OnRegisterMarkerType)(
		/*[in]*/ long iMarkerType)
	{
		VSL_DEFINE_MOCK_METHOD(OnRegisterMarkerType)

		VSL_CHECK_VALIDVALUE(iMarkerType);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRegisterViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(OnRegisterView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(OnRegisterView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUnregisterViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(OnUnregisterView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(OnUnregisterView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUserPreferencesChanged2ValidValues
	{
		/*[in]*/ VIEWPREFERENCES2* pViewPrefs;
		/*[in]*/ FRAMEPREFERENCES2* pFramePrefs;
		/*[in]*/ LANGPREFERENCES2* pLangPrefs;
		/*[in]*/ FONTCOLORPREFERENCES2* pColorPrefs;
		HRESULT retValue;
	};

	STDMETHOD(OnUserPreferencesChanged2)(
		/*[in]*/ const VIEWPREFERENCES2* pViewPrefs,
		/*[in]*/ const FRAMEPREFERENCES2* pFramePrefs,
		/*[in]*/ const LANGPREFERENCES2* pLangPrefs,
		/*[in]*/ const FONTCOLORPREFERENCES2* pColorPrefs)
	{
		VSL_DEFINE_MOCK_METHOD(OnUserPreferencesChanged2)

		VSL_CHECK_VALIDVALUE_POINTER(pViewPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pFramePrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pLangPrefs);

		VSL_CHECK_VALIDVALUE_POINTER(pColorPrefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnReplaceAllInFilesBeginValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnReplaceAllInFilesBegin)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnReplaceAllInFilesBegin)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnReplaceAllInFilesEndValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnReplaceAllInFilesEnd)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnReplaceAllInFilesEnd)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMANAGEREVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
