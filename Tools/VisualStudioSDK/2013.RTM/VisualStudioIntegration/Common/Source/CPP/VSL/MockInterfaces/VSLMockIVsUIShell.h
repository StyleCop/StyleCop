/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUISHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUISHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsUIShellNotImpl :
	public IVsUIShell
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellNotImpl)

public:

	typedef IVsUIShell Interface;

	STDMETHOD(GetToolWindowEnum)(
		/*[out]*/ IEnumWindowFrames** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentWindowEnum)(
		/*[out]*/ IEnumWindowFrames** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindToolWindow)(
		/*[in]*/ VSFINDTOOLWIN /*grfFTW*/,
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateToolWindow)(
		/*[in]*/ VSCREATETOOLWIN /*grfCTW*/,
		/*[in]*/ DWORD /*dwToolWindowId*/,
		/*[in]*/ IUnknown* /*punkTool*/,
		/*[in]*/ REFCLSID /*rclsidTool*/,
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[in]*/ REFGUID /*rguidAutoActivate*/,
		/*[in]*/ IServiceProvider* /*pSP*/,
		/*[in]*/ LPCOLESTR /*pszCaption*/,
		/*[out]*/ BOOL* /*pfDefaultPosition*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateDocumentWindow)(
		/*[in]*/ VSCREATEDOCWIN /*grfCDW*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ IVsUIHierarchy* /*pUIH*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IUnknown* /*punkDocView*/,
		/*[in]*/ IUnknown* /*punkDocData*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidCmdUI*/,
		/*[in]*/ IServiceProvider* /*pSP*/,
		/*[in]*/ LPCOLESTR /*pszOwnerCaption*/,
		/*[in]*/ LPCOLESTR /*pszEditorCaption*/,
		/*[out]*/ BOOL* /*pfDefaultPosition*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetErrorInfo)(
		/*[in]*/ HRESULT /*hr*/,
		/*[in]*/ LPCOLESTR /*pszDescription*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ LPCOLESTR /*pszHelpKeyword*/,
		/*[in]*/ LPCOLESTR /*pszSource*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReportErrorInfo)(
		/*[in]*/ HRESULT /*hr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDialogOwnerHwnd)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveDocDataToFile)(
		/*[in]*/ VSSAVEFLAGS /*grfSave*/,
		/*[in]*/ IUnknown* /*pPersistFile*/,
		/*[in]*/ LPCOLESTR /*pszUntitledPath*/,
		/*[out]*/ BSTR* /*pbstrDocumentNew*/,
		/*[out]*/ BOOL* /*pfCanceled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetupToolbar)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ IVsToolWindowToolbar* /*ptwt*/,
		/*[out]*/ IVsToolWindowToolbarHost** /*pptwth*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetForegroundWindow)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAcceleratorAsACmd)(
		/*[in]*/ LPMSG /*pMsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateCommandUI)(
		/*[in]*/ BOOL /*fImmediateUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateDocDataIsDirtyFeedback)(
		/*[in]*/ VSCOOKIE /*docCookie*/,
		/*[in]*/ BOOL /*fDirty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshPropertyBrowser)(
		/*[in]*/ DISPID /*dispid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetWaitCursor)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PostExecCommand)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdID*/,
		/*[in]*/ DWORD /*nCmdexecopt*/,
		/*[in,unique]*/ VARIANT* /*pvaIn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowContextMenu)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidActive*/,
		/*[in]*/ LONG /*nMenuId*/,
		/*[in]*/ REFPOINTS /*pos*/,
		/*[in]*/ IOleCommandTarget* /*pCmdTrgtActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowMessageBox)(
		/*[in]*/ DWORD /*dwCompRole*/,
		/*[in]*/ REFCLSID /*rclsidComp*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszTitle*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszText*/,
		/*[in]*/ _In_z_ LPOLESTR /*pszHelpFile*/,
		/*[in]*/ DWORD /*dwHelpContextID*/,
		/*[in]*/ OLEMSGBUTTON /*msgbtn*/,
		/*[in]*/ OLEMSGDEFBUTTON /*msgdefbtn*/,
		/*[in]*/ OLEMSGICON /*msgicon*/,
		/*[in]*/ BOOL /*fSysAlert*/,
		/*[out,retval]*/ LONG* /*pnResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMRUComboText)(
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwCmdId*/,
		/*[in]*/ _In_ LPSTR /*lpszText*/,
		/*[in]*/ BOOL /*fAddToList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetToolbarVisibleInFullScreen)(
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwToolbarId*/,
		/*[in]*/ BOOL /*fVisibleInFullScreen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindToolWindowEx)(
		/*[in]*/ VSFINDTOOLWIN /*grfFTW*/,
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[in]*/ DWORD /*dwToolWinId*/,
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAppName)(
		/*[out]*/ BSTR* /*pbstrAppName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVSSysColor)(
		/*[in]*/ VSSYSCOLOR /*dwSysColIndex*/,
		/*[out]*/ DWORD* /*pdwRGBval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMRUComboTextW)(
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwCmdId*/,
		/*[in]*/ _In_ LPWSTR /*pwszText*/,
		/*[in]*/ BOOL /*fAddToList*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PostSetFocusMenuCommand)(
		/*[in,unique]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/,
		/*[out]*/ BSTR* /*pbstrData*/,
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddNewBFNavigationItem)(
		/*[in]*/ IVsWindowFrame* /*pWindowFrame*/,
		/*[in]*/ BSTR /*bstrData*/,
		/*[in]*/ IUnknown* /*punk*/,
		/*[in]*/ BOOL /*fReplaceCurrent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnModeChange)(
		/*[in]*/ DBGMODE /*dbgmodeNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetErrorInfo)(
		/*[out]*/ BSTR* /*pbstrErrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOpenFileNameViaDlg)(
		/*[in,out]*/ VSOPENFILENAMEW* /*pOpenFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSaveFileNameViaDlg)(
		/*[in,out]*/ VSSAVEFILENAMEW* /*pSaveFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDirectoryViaBrowseDlg)(
		/*[in,out]*/ VSBROWSEINFOW* /*pBrowse*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CenterDialogOnWindow)(
		/*[in]*/ HWND /*hwndDialog*/,
		/*[in]*/ HWND /*hwndParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPreviousBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/,
		/*[out]*/ BSTR* /*pbstrData*/,
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNextBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** /*ppWindowFrame*/,
		/*[out]*/ BSTR* /*pbstrData*/,
		/*[out]*/ IUnknown** /*ppunk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetURLViaDlg)(
		/*[in]*/ LPCOLESTR /*pszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*pszStaticLabel*/,
		/*[in]*/ LPCOLESTR /*pszHelpTopic*/,
		/*[out]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAdjacentBFNavigationItem)(
		/*[in]*/ RemoveBFDirection /*rdDir*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveCurrentNavigationDupes)(
		/*[in]*/ RemoveBFDirection /*rdDir*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUIShellMockImpl :
	public IVsUIShell,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIShellMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUIShellMockImpl)

	typedef IVsUIShell Interface;
	struct GetToolWindowEnumValidValues
	{
		/*[out]*/ IEnumWindowFrames** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetToolWindowEnum)(
		/*[out]*/ IEnumWindowFrames** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetToolWindowEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentWindowEnumValidValues
	{
		/*[out]*/ IEnumWindowFrames** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentWindowEnum)(
		/*[out]*/ IEnumWindowFrames** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentWindowEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindToolWindowValidValues
	{
		/*[in]*/ VSFINDTOOLWIN grfFTW;
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(FindToolWindow)(
		/*[in]*/ VSFINDTOOLWIN grfFTW,
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(FindToolWindow)

		VSL_CHECK_VALIDVALUE(grfFTW);

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateToolWindowValidValues
	{
		/*[in]*/ VSCREATETOOLWIN grfCTW;
		/*[in]*/ DWORD dwToolWindowId;
		/*[in]*/ IUnknown* punkTool;
		/*[in]*/ REFCLSID rclsidTool;
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[in]*/ REFGUID rguidAutoActivate;
		/*[in]*/ IServiceProvider* pSP;
		/*[in]*/ LPCOLESTR pszCaption;
		/*[out]*/ BOOL* pfDefaultPosition;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(CreateToolWindow)(
		/*[in]*/ VSCREATETOOLWIN grfCTW,
		/*[in]*/ DWORD dwToolWindowId,
		/*[in]*/ IUnknown* punkTool,
		/*[in]*/ REFCLSID rclsidTool,
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[in]*/ REFGUID rguidAutoActivate,
		/*[in]*/ IServiceProvider* pSP,
		/*[in]*/ LPCOLESTR pszCaption,
		/*[out]*/ BOOL* pfDefaultPosition,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(CreateToolWindow)

		VSL_CHECK_VALIDVALUE(grfCTW);

		VSL_CHECK_VALIDVALUE(dwToolWindowId);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkTool);

		VSL_CHECK_VALIDVALUE(rclsidTool);

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_CHECK_VALIDVALUE(rguidAutoActivate);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCaption);

		VSL_SET_VALIDVALUE(pfDefaultPosition);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateDocumentWindowValidValues
	{
		/*[in]*/ VSCREATEDOCWIN grfCDW;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ IVsUIHierarchy* pUIH;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IUnknown* punkDocView;
		/*[in]*/ IUnknown* punkDocData;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidCmdUI;
		/*[in]*/ IServiceProvider* pSP;
		/*[in]*/ LPCOLESTR pszOwnerCaption;
		/*[in]*/ LPCOLESTR pszEditorCaption;
		/*[out]*/ BOOL* pfDefaultPosition;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(CreateDocumentWindow)(
		/*[in]*/ VSCREATEDOCWIN grfCDW,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ IVsUIHierarchy* pUIH,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IUnknown* punkDocView,
		/*[in]*/ IUnknown* punkDocData,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidCmdUI,
		/*[in]*/ IServiceProvider* pSP,
		/*[in]*/ LPCOLESTR pszOwnerCaption,
		/*[in]*/ LPCOLESTR pszEditorCaption,
		/*[out]*/ BOOL* pfDefaultPosition,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDocumentWindow)

		VSL_CHECK_VALIDVALUE(grfCDW);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIH);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDocData);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidCmdUI);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOwnerCaption);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEditorCaption);

		VSL_SET_VALIDVALUE(pfDefaultPosition);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetErrorInfoValidValues
	{
		/*[in]*/ HRESULT hr;
		/*[in]*/ LPCOLESTR pszDescription;
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ LPCOLESTR pszHelpKeyword;
		/*[in]*/ LPCOLESTR pszSource;
		HRESULT retValue;
	};

	STDMETHOD(SetErrorInfo)(
		/*[in]*/ HRESULT hr,
		/*[in]*/ LPCOLESTR pszDescription,
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ LPCOLESTR pszHelpKeyword,
		/*[in]*/ LPCOLESTR pszSource)
	{
		VSL_DEFINE_MOCK_METHOD(SetErrorInfo)

		VSL_CHECK_VALIDVALUE(hr);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDescription);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpKeyword);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSource);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReportErrorInfoValidValues
	{
		/*[in]*/ HRESULT hr;
		HRESULT retValue;
	};

	STDMETHOD(ReportErrorInfo)(
		/*[in]*/ HRESULT hr)
	{
		VSL_DEFINE_MOCK_METHOD(ReportErrorInfo)

		VSL_CHECK_VALIDVALUE(hr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDialogOwnerHwndValidValues
	{
		/*[out]*/ HWND* phwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetDialogOwnerHwnd)(
		/*[out]*/ HWND* phwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetDialogOwnerHwnd)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableModelessValidValues
	{
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(EnableModeless)

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveDocDataToFileValidValues
	{
		/*[in]*/ VSSAVEFLAGS grfSave;
		/*[in]*/ IUnknown* pPersistFile;
		/*[in]*/ LPCOLESTR pszUntitledPath;
		/*[out]*/ BSTR* pbstrDocumentNew;
		/*[out]*/ BOOL* pfCanceled;
		HRESULT retValue;
	};

	STDMETHOD(SaveDocDataToFile)(
		/*[in]*/ VSSAVEFLAGS grfSave,
		/*[in]*/ IUnknown* pPersistFile,
		/*[in]*/ LPCOLESTR pszUntitledPath,
		/*[out]*/ BSTR* pbstrDocumentNew,
		/*[out]*/ BOOL* pfCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(SaveDocDataToFile)

		VSL_CHECK_VALIDVALUE(grfSave);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPersistFile);

		VSL_CHECK_VALIDVALUE_STRINGW(pszUntitledPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrDocumentNew);

		VSL_SET_VALIDVALUE(pfCanceled);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetupToolbarValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ IVsToolWindowToolbar* ptwt;
		/*[out]*/ IVsToolWindowToolbarHost** pptwth;
		HRESULT retValue;
	};

	STDMETHOD(SetupToolbar)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ IVsToolWindowToolbar* ptwt,
		/*[out]*/ IVsToolWindowToolbarHost** pptwth)
	{
		VSL_DEFINE_MOCK_METHOD(SetupToolbar)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ptwt);

		VSL_SET_VALIDVALUE_INTERFACE(pptwth);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetForegroundWindowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetForegroundWindow)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetForegroundWindow)

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorAsACmdValidValues
	{
		/*[in]*/ LPMSG pMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAcceleratorAsACmd)(
		/*[in]*/ LPMSG pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAcceleratorAsACmd)

		VSL_CHECK_VALIDVALUE(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateCommandUIValidValues
	{
		/*[in]*/ BOOL fImmediateUpdate;
		HRESULT retValue;
	};

	STDMETHOD(UpdateCommandUI)(
		/*[in]*/ BOOL fImmediateUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateCommandUI)

		VSL_CHECK_VALIDVALUE(fImmediateUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateDocDataIsDirtyFeedbackValidValues
	{
		/*[in]*/ VSCOOKIE docCookie;
		/*[in]*/ BOOL fDirty;
		HRESULT retValue;
	};

	STDMETHOD(UpdateDocDataIsDirtyFeedback)(
		/*[in]*/ VSCOOKIE docCookie,
		/*[in]*/ BOOL fDirty)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateDocDataIsDirtyFeedback)

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_CHECK_VALIDVALUE(fDirty);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshPropertyBrowserValidValues
	{
		/*[in]*/ DISPID dispid;
		HRESULT retValue;
	};

	STDMETHOD(RefreshPropertyBrowser)(
		/*[in]*/ DISPID dispid)
	{
		VSL_DEFINE_MOCK_METHOD(RefreshPropertyBrowser)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetWaitCursorValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetWaitCursor)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetWaitCursor)

		VSL_RETURN_VALIDVALUES();
	}
	struct PostExecCommandValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdID;
		/*[in]*/ DWORD nCmdexecopt;
		/*[in,unique]*/ VARIANT* pvaIn;
		HRESULT retValue;
	};

	STDMETHOD(PostExecCommand)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdID,
		/*[in]*/ DWORD nCmdexecopt,
		/*[in,unique]*/ VARIANT* pvaIn)
	{
		VSL_DEFINE_MOCK_METHOD(PostExecCommand)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdID);

		VSL_CHECK_VALIDVALUE(nCmdexecopt);

		VSL_CHECK_VALIDVALUE_POINTER(pvaIn);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowContextMenuValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidActive;
		/*[in]*/ LONG nMenuId;
		/*[in]*/ REFPOINTS pos;
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive;
		HRESULT retValue;
	};

	STDMETHOD(ShowContextMenu)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidActive,
		/*[in]*/ LONG nMenuId,
		/*[in]*/ REFPOINTS pos,
		/*[in]*/ IOleCommandTarget* pCmdTrgtActive)
	{
		VSL_DEFINE_MOCK_METHOD(ShowContextMenu)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidActive);

		VSL_CHECK_VALIDVALUE(nMenuId);

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdTrgtActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowMessageBoxValidValues
	{
		/*[in]*/ DWORD dwCompRole;
		/*[in]*/ REFCLSID rclsidComp;
		/*[in]*/ LPOLESTR pszTitle;
		/*[in]*/ LPOLESTR pszText;
		/*[in]*/ LPOLESTR pszHelpFile;
		/*[in]*/ DWORD dwHelpContextID;
		/*[in]*/ OLEMSGBUTTON msgbtn;
		/*[in]*/ OLEMSGDEFBUTTON msgdefbtn;
		/*[in]*/ OLEMSGICON msgicon;
		/*[in]*/ BOOL fSysAlert;
		/*[out,retval]*/ LONG* pnResult;
		HRESULT retValue;
	};

	STDMETHOD(ShowMessageBox)(
		/*[in]*/ DWORD dwCompRole,
		/*[in]*/ REFCLSID rclsidComp,
		/*[in]*/ _In_z_ LPOLESTR pszTitle,
		/*[in]*/ _In_z_ LPOLESTR pszText,
		/*[in]*/ _In_z_ LPOLESTR pszHelpFile,
		/*[in]*/ DWORD dwHelpContextID,
		/*[in]*/ OLEMSGBUTTON msgbtn,
		/*[in]*/ OLEMSGDEFBUTTON msgdefbtn,
		/*[in]*/ OLEMSGICON msgicon,
		/*[in]*/ BOOL fSysAlert,
		/*[out,retval]*/ LONG* pnResult)
	{
		VSL_DEFINE_MOCK_METHOD(ShowMessageBox)

		VSL_CHECK_VALIDVALUE(dwCompRole);

		VSL_CHECK_VALIDVALUE(rclsidComp);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpFile);

		VSL_CHECK_VALIDVALUE(dwHelpContextID);

		VSL_CHECK_VALIDVALUE(msgbtn);

		VSL_CHECK_VALIDVALUE(msgdefbtn);

		VSL_CHECK_VALIDVALUE(msgicon);

		VSL_CHECK_VALIDVALUE(fSysAlert);

		VSL_SET_VALIDVALUE(pnResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMRUComboTextValidValues
	{
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD dwCmdId;
		/*[in]*/ LPSTR lpszText;
		/*[in]*/ BOOL fAddToList;
		HRESULT retValue;
	};

	STDMETHOD(SetMRUComboText)(
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD dwCmdId,
		/*[in]*/ _In_opt_ LPSTR lpszText,
		/*[in]*/ BOOL fAddToList)
	{
		VSL_DEFINE_MOCK_METHOD(SetMRUComboText)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwCmdId);

		VSL_CHECK_VALIDVALUE_STRINGA(lpszText);

		VSL_CHECK_VALIDVALUE(fAddToList);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetToolbarVisibleInFullScreenValidValues
	{
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD dwToolbarId;
		/*[in]*/ BOOL fVisibleInFullScreen;
		HRESULT retValue;
	};

	STDMETHOD(SetToolbarVisibleInFullScreen)(
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD dwToolbarId,
		/*[in]*/ BOOL fVisibleInFullScreen)
	{
		VSL_DEFINE_MOCK_METHOD(SetToolbarVisibleInFullScreen)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwToolbarId);

		VSL_CHECK_VALIDVALUE(fVisibleInFullScreen);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindToolWindowExValidValues
	{
		/*[in]*/ VSFINDTOOLWIN grfFTW;
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[in]*/ DWORD dwToolWinId;
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		HRESULT retValue;
	};

	STDMETHOD(FindToolWindowEx)(
		/*[in]*/ VSFINDTOOLWIN grfFTW,
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[in]*/ DWORD dwToolWinId,
		/*[out]*/ IVsWindowFrame** ppWindowFrame)
	{
		VSL_DEFINE_MOCK_METHOD(FindToolWindowEx)

		VSL_CHECK_VALIDVALUE(grfFTW);

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_CHECK_VALIDVALUE(dwToolWinId);

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAppNameValidValues
	{
		/*[out]*/ BSTR* pbstrAppName;
		HRESULT retValue;
	};

	STDMETHOD(GetAppName)(
		/*[out]*/ BSTR* pbstrAppName)
	{
		VSL_DEFINE_MOCK_METHOD(GetAppName)

		VSL_SET_VALIDVALUE_BSTR(pbstrAppName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVSSysColorValidValues
	{
		/*[in]*/ VSSYSCOLOR dwSysColIndex;
		/*[out]*/ DWORD* pdwRGBval;
		HRESULT retValue;
	};

	STDMETHOD(GetVSSysColor)(
		/*[in]*/ VSSYSCOLOR dwSysColIndex,
		/*[out]*/ DWORD* pdwRGBval)
	{
		VSL_DEFINE_MOCK_METHOD(GetVSSysColor)

		VSL_CHECK_VALIDVALUE(dwSysColIndex);

		VSL_SET_VALIDVALUE(pdwRGBval);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMRUComboTextWValidValues
	{
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD dwCmdId;
		/*[in]*/ LPWSTR pwszText;
		/*[in]*/ BOOL fAddToList;
		HRESULT retValue;
	};

	STDMETHOD(SetMRUComboTextW)(
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD dwCmdId,
		/*[in]*/ _In_opt_ LPWSTR pwszText,
		/*[in]*/ BOOL fAddToList)
	{
		VSL_DEFINE_MOCK_METHOD(SetMRUComboTextW)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwCmdId);

		VSL_CHECK_VALIDVALUE_STRINGW(pwszText);

		VSL_CHECK_VALIDVALUE(fAddToList);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostSetFocusMenuCommandValidValues
	{
		/*[in,unique]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdId;
		HRESULT retValue;
	};

	STDMETHOD(PostSetFocusMenuCommand)(
		/*[in,unique]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdId)
	{
		VSL_DEFINE_MOCK_METHOD(PostSetFocusMenuCommand)

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentBFNavigationItemValidValues
	{
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		/*[out]*/ BSTR* pbstrData;
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** ppWindowFrame,
		/*[out]*/ BSTR* pbstrData,
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentBFNavigationItem)

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_SET_VALIDVALUE_BSTR(pbstrData);

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddNewBFNavigationItemValidValues
	{
		/*[in]*/ IVsWindowFrame* pWindowFrame;
		/*[in]*/ BSTR bstrData;
		/*[in]*/ IUnknown* punk;
		/*[in]*/ BOOL fReplaceCurrent;
		HRESULT retValue;
	};

	STDMETHOD(AddNewBFNavigationItem)(
		/*[in]*/ IVsWindowFrame* pWindowFrame,
		/*[in]*/ BSTR bstrData,
		/*[in]*/ IUnknown* punk,
		/*[in]*/ BOOL fReplaceCurrent)
	{
		VSL_DEFINE_MOCK_METHOD(AddNewBFNavigationItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pWindowFrame);

		VSL_CHECK_VALIDVALUE_BSTR(bstrData);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_CHECK_VALIDVALUE(fReplaceCurrent);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnModeChangeValidValues
	{
		/*[in]*/ DBGMODE dbgmodeNew;
		HRESULT retValue;
	};

	STDMETHOD(OnModeChange)(
		/*[in]*/ DBGMODE dbgmodeNew)
	{
		VSL_DEFINE_MOCK_METHOD(OnModeChange)

		VSL_CHECK_VALIDVALUE(dbgmodeNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetErrorInfoValidValues
	{
		/*[out]*/ BSTR* pbstrErrText;
		HRESULT retValue;
	};

	STDMETHOD(GetErrorInfo)(
		/*[out]*/ BSTR* pbstrErrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetErrorInfo)

		VSL_SET_VALIDVALUE_BSTR(pbstrErrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOpenFileNameViaDlgValidValues
	{
		/*[in,out]*/ VSOPENFILENAMEW* pOpenFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetOpenFileNameViaDlg)(
		/*[in,out]*/ VSOPENFILENAMEW* pOpenFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetOpenFileNameViaDlg)

		VSL_SET_VALIDVALUE(pOpenFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSaveFileNameViaDlgValidValues
	{
		/*[in,out]*/ VSSAVEFILENAMEW* pSaveFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetSaveFileNameViaDlg)(
		/*[in,out]*/ VSSAVEFILENAMEW* pSaveFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetSaveFileNameViaDlg)

		VSL_SET_VALIDVALUE(pSaveFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDirectoryViaBrowseDlgValidValues
	{
		/*[in,out]*/ VSBROWSEINFOW* pBrowse;
		HRESULT retValue;
	};

	STDMETHOD(GetDirectoryViaBrowseDlg)(
		/*[in,out]*/ VSBROWSEINFOW* pBrowse)
	{
		VSL_DEFINE_MOCK_METHOD(GetDirectoryViaBrowseDlg)

		VSL_SET_VALIDVALUE(pBrowse);

		VSL_RETURN_VALIDVALUES();
	}
	struct CenterDialogOnWindowValidValues
	{
		/*[in]*/ HWND hwndDialog;
		/*[in]*/ HWND hwndParent;
		HRESULT retValue;
	};

	STDMETHOD(CenterDialogOnWindow)(
		/*[in]*/ HWND hwndDialog,
		/*[in]*/ HWND hwndParent)
	{
		VSL_DEFINE_MOCK_METHOD(CenterDialogOnWindow)

		VSL_CHECK_VALIDVALUE(hwndDialog);

		VSL_CHECK_VALIDVALUE(hwndParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPreviousBFNavigationItemValidValues
	{
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		/*[out]*/ BSTR* pbstrData;
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetPreviousBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** ppWindowFrame,
		/*[out]*/ BSTR* pbstrData,
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetPreviousBFNavigationItem)

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_SET_VALIDVALUE_BSTR(pbstrData);

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNextBFNavigationItemValidValues
	{
		/*[out]*/ IVsWindowFrame** ppWindowFrame;
		/*[out]*/ BSTR* pbstrData;
		/*[out]*/ IUnknown** ppunk;
		HRESULT retValue;
	};

	STDMETHOD(GetNextBFNavigationItem)(
		/*[out]*/ IVsWindowFrame** ppWindowFrame,
		/*[out]*/ BSTR* pbstrData,
		/*[out]*/ IUnknown** ppunk)
	{
		VSL_DEFINE_MOCK_METHOD(GetNextBFNavigationItem)

		VSL_SET_VALIDVALUE_INTERFACE(ppWindowFrame);

		VSL_SET_VALIDVALUE_BSTR(pbstrData);

		VSL_SET_VALIDVALUE_INTERFACE(ppunk);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetURLViaDlgValidValues
	{
		/*[in]*/ LPCOLESTR pszDlgTitle;
		/*[in]*/ LPCOLESTR pszStaticLabel;
		/*[in]*/ LPCOLESTR pszHelpTopic;
		/*[out]*/ BSTR* pbstrURL;
		HRESULT retValue;
	};

	STDMETHOD(GetURLViaDlg)(
		/*[in]*/ LPCOLESTR pszDlgTitle,
		/*[in]*/ LPCOLESTR pszStaticLabel,
		/*[in]*/ LPCOLESTR pszHelpTopic,
		/*[out]*/ BSTR* pbstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(GetURLViaDlg)

		VSL_CHECK_VALIDVALUE_STRINGW(pszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(pszStaticLabel);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpTopic);

		VSL_SET_VALIDVALUE_BSTR(pbstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAdjacentBFNavigationItemValidValues
	{
		/*[in]*/ RemoveBFDirection rdDir;
		HRESULT retValue;
	};

	STDMETHOD(RemoveAdjacentBFNavigationItem)(
		/*[in]*/ RemoveBFDirection rdDir)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveAdjacentBFNavigationItem)

		VSL_CHECK_VALIDVALUE(rdDir);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveCurrentNavigationDupesValidValues
	{
		/*[in]*/ RemoveBFDirection rdDir;
		HRESULT retValue;
	};

	STDMETHOD(RemoveCurrentNavigationDupes)(
		/*[in]*/ RemoveBFDirection rdDir)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveCurrentNavigationDupes)

		VSL_CHECK_VALIDVALUE(rdDir);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUISHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
