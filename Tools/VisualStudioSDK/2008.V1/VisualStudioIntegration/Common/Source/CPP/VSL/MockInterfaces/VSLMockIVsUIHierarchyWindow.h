/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUIHIERARCHYWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUIHIERARCHYWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUIHierarchyWindowNotImpl :
	public IVsUIHierarchyWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierarchyWindowNotImpl)

public:

	typedef IVsUIHierarchyWindow Interface;

	STDMETHOD(Init)(
		/*[in]*/ IVsUIHierarchy* /*pUIH*/,
		/*[in]*/ UIHWINFLAGS /*grfUIHWF*/,
		/*[out]*/ IUnknown** /*ppunkOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExpandItem)(
		/*[in]*/ IVsUIHierarchy* /*pUIH*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ EXPANDFLAGS /*expf*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddUIHierarchy)(
		/*[in]*/ IVsUIHierarchy* /*pUIH*/,
		/*[in]*/ VSADDHIEROPTIONS /*grfAddOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveUIHierarchy)(
		/*[in]*/ IVsUIHierarchy* /*pUIH*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetWindowHelpTopic)(
		/*[in]*/ LPCOLESTR /*lpszHelpFile*/,
		/*[in]*/ DWORD /*dwContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemState)(
		/*[in]*/ IVsUIHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSHIERARCHYITEMSTATE /*dwStateMask*/,
		/*[out,retval]*/ VSHIERARCHYITEMSTATE* /*pdwState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindCommonSelectedHierarchy)(
		/*[in]*/ VSCOMHIEROPTIONS /*grfOpt*/,
		/*[out,retval]*/ IVsUIHierarchy** /*lppCommonUIH*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCursor)(
		/*[in]*/ HCURSOR /*hNewCursor*/,
		/*[out,retval]*/ HCURSOR* /*phOldCursor*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** /*ppHier*/,
		/*[out]*/ VSITEMID* /*pitemid*/,
		/*[out]*/ IVsMultiItemSelect** /*ppMIS*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIHierarchyWindowMockImpl :
	public IVsUIHierarchyWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierarchyWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIHierarchyWindowMockImpl)

	typedef IVsUIHierarchyWindow Interface;
	struct InitValidValues
	{
		/*[in]*/ IVsUIHierarchy* pUIH;
		/*[in]*/ UIHWINFLAGS grfUIHWF;
		/*[out]*/ IUnknown** ppunkOut;
		HRESULT retValue;
	};

	STDMETHOD(Init)(
		/*[in]*/ IVsUIHierarchy* pUIH,
		/*[in]*/ UIHWINFLAGS grfUIHWF,
		/*[out]*/ IUnknown** ppunkOut)
	{
		VSL_DEFINE_MOCK_METHOD(Init)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIH);

		VSL_CHECK_VALIDVALUE(grfUIHWF);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExpandItemValidValues
	{
		/*[in]*/ IVsUIHierarchy* pUIH;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ EXPANDFLAGS expf;
		HRESULT retValue;
	};

	STDMETHOD(ExpandItem)(
		/*[in]*/ IVsUIHierarchy* pUIH,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ EXPANDFLAGS expf)
	{
		VSL_DEFINE_MOCK_METHOD(ExpandItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIH);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(expf);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddUIHierarchyValidValues
	{
		/*[in]*/ IVsUIHierarchy* pUIH;
		/*[in]*/ VSADDHIEROPTIONS grfAddOptions;
		HRESULT retValue;
	};

	STDMETHOD(AddUIHierarchy)(
		/*[in]*/ IVsUIHierarchy* pUIH,
		/*[in]*/ VSADDHIEROPTIONS grfAddOptions)
	{
		VSL_DEFINE_MOCK_METHOD(AddUIHierarchy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIH);

		VSL_CHECK_VALIDVALUE(grfAddOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveUIHierarchyValidValues
	{
		/*[in]*/ IVsUIHierarchy* pUIH;
		HRESULT retValue;
	};

	STDMETHOD(RemoveUIHierarchy)(
		/*[in]*/ IVsUIHierarchy* pUIH)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveUIHierarchy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIH);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetWindowHelpTopicValidValues
	{
		/*[in]*/ LPCOLESTR lpszHelpFile;
		/*[in]*/ DWORD dwContext;
		HRESULT retValue;
	};

	STDMETHOD(SetWindowHelpTopic)(
		/*[in]*/ LPCOLESTR lpszHelpFile,
		/*[in]*/ DWORD dwContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetWindowHelpTopic)

		VSL_CHECK_VALIDVALUE_STRINGW(lpszHelpFile);

		VSL_CHECK_VALIDVALUE(dwContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemStateValidValues
	{
		/*[in]*/ IVsUIHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSHIERARCHYITEMSTATE dwStateMask;
		/*[out,retval]*/ VSHIERARCHYITEMSTATE* pdwState;
		HRESULT retValue;
	};

	STDMETHOD(GetItemState)(
		/*[in]*/ IVsUIHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSHIERARCHYITEMSTATE dwStateMask,
		/*[out,retval]*/ VSHIERARCHYITEMSTATE* pdwState)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(dwStateMask);

		VSL_SET_VALIDVALUE(pdwState);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindCommonSelectedHierarchyValidValues
	{
		/*[in]*/ VSCOMHIEROPTIONS grfOpt;
		/*[out,retval]*/ IVsUIHierarchy** lppCommonUIH;
		HRESULT retValue;
	};

	STDMETHOD(FindCommonSelectedHierarchy)(
		/*[in]*/ VSCOMHIEROPTIONS grfOpt,
		/*[out,retval]*/ IVsUIHierarchy** lppCommonUIH)
	{
		VSL_DEFINE_MOCK_METHOD(FindCommonSelectedHierarchy)

		VSL_CHECK_VALIDVALUE(grfOpt);

		VSL_SET_VALIDVALUE_INTERFACE(lppCommonUIH);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCursorValidValues
	{
		/*[in]*/ HCURSOR hNewCursor;
		/*[out,retval]*/ HCURSOR* phOldCursor;
		HRESULT retValue;
	};

	STDMETHOD(SetCursor)(
		/*[in]*/ HCURSOR hNewCursor,
		/*[out,retval]*/ HCURSOR* phOldCursor)
	{
		VSL_DEFINE_MOCK_METHOD(SetCursor)

		VSL_CHECK_VALIDVALUE(hNewCursor);

		VSL_SET_VALIDVALUE(phOldCursor);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentSelectionValidValues
	{
		/*[out]*/ IVsHierarchy** ppHier;
		/*[out]*/ VSITEMID* pitemid;
		/*[out]*/ IVsMultiItemSelect** ppMIS;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentSelection)(
		/*[out]*/ IVsHierarchy** ppHier,
		/*[out]*/ VSITEMID* pitemid,
		/*[out]*/ IVsMultiItemSelect** ppMIS)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentSelection)

		VSL_SET_VALIDVALUE_INTERFACE(ppHier);

		VSL_SET_VALIDVALUE(pitemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppMIS);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUIHIERARCHYWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
