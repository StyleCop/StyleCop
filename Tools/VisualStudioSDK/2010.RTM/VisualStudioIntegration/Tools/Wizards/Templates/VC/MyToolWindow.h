//
// MyToolWindow.h
//
// This file contains the implementation of a tool window that hosts a .NET user control
//

#pragma once

#include <AtlWin.h>
#include <VSLWindows.h>

#include "..\%ProjectName%UI\Resource.h"

class %ProjectClass%WindowPane :
    public CComObjectRootEx<CComSingleThreadModel>,
	public VsWindowPaneFromResource<%ProjectClass%WindowPane, IDD_%ProjectClass%_DLG>,
	public VsWindowFrameEventSink<%ProjectClass%WindowPane>,
	public VSL::ISupportErrorInfoImpl<
		InterfaceSupportsErrorInfoList<IVsWindowPane,
		InterfaceSupportsErrorInfoList<IVsWindowFrameNotify,
		InterfaceSupportsErrorInfoList<IVsWindowFrameNotify3> > > >
{
	VSL_DECLARE_NOT_COPYABLE(%ProjectClass%WindowPane)

protected:

	// Protected constructor called by CComObject<%ProjectClass%WindowPane>::CreateInstance.
	%ProjectClass%WindowPane() :
		 VsWindowPaneFromResource()
	{}

	~%ProjectClass%WindowPane() {}
	
public:

BEGIN_COM_MAP(%ProjectClass%WindowPane)
	COM_INTERFACE_ENTRY(IVsWindowPane)
	COM_INTERFACE_ENTRY(IVsWindowFrameNotify)
	COM_INTERFACE_ENTRY(IVsWindowFrameNotify3)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
END_COM_MAP()

BEGIN_MSG_MAP(%ProjectClass%WindowPane)
	COMMAND_HANDLER(IDC_CLICKME_BTN, BN_CLICKED, OnButtonClick)
END_MSG_MAP()

	// Function called by VsVsWindowPaneFromResource at the end of SetSite; at this point the
	// window pane is constructed and sited and can be used, so this is where we can initialize
	// the event sink by siting it.
	void PostSited(IVsPackageEnums::SetSiteResult /*result*/)
	{
		VsWindowFrameEventSink<%ProjectClass%WindowPane>::SetSite(GetVsSiteCache());
	}

	// Callback function called by ToolWindowBase when the size of the window changes.
	void OnFrameSize(int x, int y, int w, int h)
	{
		// Center button.
		CWindow button(this->GetDlgItem(IDC_CLICKME_BTN));
		RECT buttonRectangle;
		button.GetWindowRect(&buttonRectangle);

		OffsetRect(&buttonRectangle, -buttonRectangle.left, -buttonRectangle.top);

		int iLeft = (w - buttonRectangle.right) / 2; 
		if (iLeft <= 0)
		{
			iLeft = 5;
		}

		int iTop = (h - buttonRectangle.bottom) / 2; 
		if (iTop <= 0)
		{
			iTop = 5;
		}

		button.SetWindowPos(NULL, iLeft, iTop, 0, 0, SWP_NOSIZE);
	}

	LRESULT OnButtonClick(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& bHandled)
	{
		// Load the message from the resources.
		CComBSTR strMessage;
		VSL_CHECKBOOL_GLE(strMessage.LoadStringW(_AtlBaseModule.GetResourceInstance(), IDS_BUTTONCLICK_MESSAGE));

		// Get the title of the message box (it is the same as the tool window's title).
		CComBSTR strTitle;
		VSL_CHECKBOOL_GLE(strTitle.LoadStringW(_AtlBaseModule.GetResourceInstance(), IDS_WINDOW_TITLE));

		// Get the UI Shell service.
		CComPtr<IVsUIShell> spIVsUIShell = GetVsSiteCache().GetCachedService<IVsUIShell, SID_SVsUIShell>();
		LONG lResult;
		VSL_CHECKHRESULT(spIVsUIShell->ShowMessageBox(0, GUID_NULL, strTitle, strMessage, NULL, 0, OLEMSGBUTTON_OK, OLEMSGDEFBUTTON_FIRST, OLEMSGICON_INFO, FALSE, &lResult));

		bHandled = TRUE;
		return 0;
	}
};


class %ProjectClass%ToolWindow :
	public VSL::ToolWindowBase<%ProjectClass%ToolWindow>
{
public:
	// Constructor of the tool window object.
	// The goal of this constructor is to initialize the base class with the site cache
	// of the owner package.
	%ProjectClass%ToolWindow(const PackageVsSiteCache& rPackageVsSiteCache):
		ToolWindowBase(rPackageVsSiteCache)
	{
	}

	// Caption of the tool window.
	const wchar_t* const GetCaption() const
	{
		static CStringW strCaption;
		// Avoid to load the string from the resources more that once.
		if (0 == strCaption.GetLength())
		{
			VSL_CHECKBOOL_GLE(
				strCaption.LoadStringW(_AtlBaseModule.GetResourceInstance(), IDS_WINDOW_TITLE));
		}
		return strCaption;
	}

	// Creation flags for this tool window.
	VSCREATETOOLWIN GetCreationFlags() const
	{
		return CTW_fInitNew|CTW_fForceCreate;
	}

	// Return the GUID of the persintence slot for this tool window.
	const GUID& GetToolWindowGuid() const
	{
		return CLSID_guidPersistanceSlot;
	}

	IUnknown* GetViewObject()
	{
		// Should only be called once per-instance
		VSL_CHECKBOOLEAN_EX(m_spView == NULL, E_UNEXPECTED, IDS_E_GETVIEWOBJECT_CALLED_AGAIN);

		// Create the object that implements the window pane for this tool window.
		CComObject<%ProjectClass%WindowPane>* pViewObject;
		VSL_CHECKHRESULT(CComObject<%ProjectClass%WindowPane>::CreateInstance(&pViewObject));

		// Get the pointer to IUnknown for the window pane.
		HRESULT hr = pViewObject->QueryInterface(IID_IUnknown, (void**)&m_spView);
		if (FAILED(hr))
		{
			// If QueryInterface failed, then there is something wrong with the object.
			// Delete it and throw an exception for the error.
			delete pViewObject;
			VSL_CHECKHRESULT(hr);
		}

		return m_spView;
	}

	// This method is called by the base class after the tool window is created.
	// We use it to set the icon for this window.
	void PostCreate()
	{
		CComVariant srpvt;
		srpvt.vt = VT_I4;
		srpvt.intVal = IDB_FRAME_IMAGES;
		// We don't want to make the window creation fail only becuase we can not set
		// the icon, so we will not throw if SetProperty fails.
		if (SUCCEEDED(GetIVsWindowFrame()->SetProperty(VSFPROPID_BitmapResource, srpvt)))
		{
			srpvt.intVal = 1;
			GetIVsWindowFrame()->SetProperty(VSFPROPID_BitmapIndex, srpvt);
		}
	}

private:
	CComPtr<IUnknown> m_spView;
};
