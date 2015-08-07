// Package.h

#pragma once

#include <atlstr.h>
#include <VSLCommandTarget.h>


#include "resource.h"       // main symbols
#include "Guids.h"
#include "..\%ProjectName%UI\Resource.h"

#include "..\%ProjectName%UI\CommandIds.h"

%ToolWindowItemStart%
#include "MyToolWindow.h"
#include <commctrl.h>
%ToolWindowItemEnd%%EditorStart%
#include "EditorFactory.h"
%EditorEnd%

using namespace VSL;

%EditorStart%/***************************************************************************
C%ProjectClass%Package handles the necessary registration for this package.

See EditorFactory.h for the details of the Editor key section in 
%ProjectClass%.pkgdef.

See the Package C++ reference sample for the details of the Package key section in
%ProjectClass%.pkgdef.

See the MenuAndCommands C++ reference sample for the details of the Menu key section in 
%ProjectClass%.pkgdef.

See EditorDocument.h for the details of the KeyBindingTables key section in
%ProjectName%.pkgdef.

The following Projects key section exists in %ProjectClass%.pkgdef in order to
register the new file template.

//The first GUID below is the GUID for the Miscellaneous Files project type, and can be changed
//  to the GUID of any other project you wish.
[$RootKey$\Projects\{A2FE74E1-B743-11d0-AE1A-00A0C90FFFC3}\AddItemTemplates\TemplateDirs\{%PackageGuid%}\/1]
@="#100"
"TemplatesDir"="$PackageFolder$\Templates"
"SortPriority"=dword:00004E20

The contents of %ProjectClass%.vsdir, which is located a the location registered above are:

myext.myext|{ab02f9cb-42e8-467c-a242-d9bb2e1918a0}|#106|80|#109|{ab02f9cb-42e8-467c-a242-d9bb2e1918a0}|401|0|#107
The meaning of the fields are as follows:
	- Default.rtf - the default .RTF file
	- {ab02f9cb-42e8-467c-a242-d9bb2e1918a0} - same as CLSID_%ProjectClass%Package
	- #106 - the literal value of IDS_EDITOR_NAME in %ProjectClass%UI.rc,
		which is displayed under the icon in the new file dialog.
	- 80 - the display ordering priority
	- #109 - the literal value of IDS_FILE_DESCRIPTION in %ProjectClass%UI.rc, which is displayed
		in the description window in the new file dialog.
	- {ab02f9cb-42e8-467c-a242-d9bb2e1918a0} - resource dll package guid
	- 401 - the literal value of IDI_FILE_ICON in %ProjectClass%.rc (not %ProjectClass%UI.rc), 
		which is the icon to display in the new file dialog.
	- 0 - template flags, which are unused here(we don't use this - see vsshell.idl)
	- #107 - the literal value of IDS_DEFAULT_NAME in %ProjectClass%UI.rc, which is the base
		name of the new files (i.e. myext1.myext, myext2.myext, etc.).

***************************************************************************/
%EditorEnd%
class ATL_NO_VTABLE C%ProjectClass%Package : 
	// CComObjectRootEx and CComCoClass are used to implement a non-thread safe COM object, and 
	// a partial implementation for IUnknown (the COM map below provides the rest).
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<C%ProjectClass%Package, &CLSID_%ProjectClass%>,
	// Provides the implementation for IVsPackage to make this COM object into a VS Package.
	public IVsPackageImpl<C%ProjectClass%Package, &CLSID_%ProjectClass%>,
	public IOleCommandTargetImpl<C%ProjectClass%Package>,
	// Provides consumers of this object with the ability to determine which interfaces support
	// extended error information.
	public ATL::ISupportErrorInfoImpl<&__uuidof(IVsPackage)>
{
public:

// Provides a portion of the implementation of IUnknown, in particular the list of interfaces
// the C%ProjectClass%Package object will support via QueryInterface
BEGIN_COM_MAP(C%ProjectClass%Package)
	COM_INTERFACE_ENTRY(IVsPackage)
	COM_INTERFACE_ENTRY(IOleCommandTarget)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
END_COM_MAP()

// COM objects typically should not be cloned, and this prevents cloning by declaring the 
// copy constructor and assignment operator private (NOTE:  this macro includes the declaration of
// a private section, so everything following this macro and preceding a public or protected 
// section will be private).
VSL_DECLARE_NOT_COPYABLE(C%ProjectClass%Package)

public:
	C%ProjectClass%Package()%EditorOrToolWindowStart%:
		%EditorStart%m_dwEditorCookie(0)%EditorEnd%%EditorAndToolWindowStart%,%EditorAndToolWindowEnd%
		%ToolWindowItemStart%m_MyToolWindow(GetVsSiteCache())%ToolWindowItemEnd%%EditorOrToolWindowEnd%
	{
	}
	
	~C%ProjectClass%Package()
	{
	}

%EditorStart%
	// This method will be called after IVsPackage::SetSite is called with a valid site
	void PostSited(IVsPackageEnums::SetSiteResult /*result*/)
	{
		if(m_dwEditorCookie == 0) 
		{
			// Create the editor factory
			CComObject<EditorFactory> *pFactory = new CComObject<EditorFactory>;
			if(NULL == pFactory)
			{
				ERRHR(E_OUTOFMEMORY);
			}
			CComPtr<IVsEditorFactory> spIVsEditorFactory = static_cast<IVsEditorFactory*>(pFactory);

			// Register the editor factory
			CComPtr<IVsRegisterEditors> spIVsRegisterEditors;
			CHKHR(GetVsSiteCache().QueryService(SID_SVsRegisterEditors, &spIVsRegisterEditors));
			CHKHR(spIVsRegisterEditors->RegisterEditor(CLSID_%ProjectClass%EditorFactory, spIVsEditorFactory, &m_dwEditorCookie));
		}
	}

	void PreClosing()
	{
		if(m_dwEditorCookie != 0)
		{
			// Unregister the editor factory
			CComPtr<IVsRegisterEditors> spIVsRegisterEditors;
			CHKHR(GetVsSiteCache().QueryService(SID_SVsRegisterEditors, &spIVsRegisterEditors));
			CHKHR(spIVsRegisterEditors->UnregisterEditor(m_dwEditorCookie));
		}
	}
%EditorEnd%
	// This function provides the error information if it is not possible to load
	// the UI dll. It is for this reason that the resource IDS_E_BADINSTALL must
	// be defined inside this dll's resources.
	static const LoadUILibrary::ExtendedErrorInfo& GetLoadUILibraryErrorInfo()
	{
		static LoadUILibrary::ExtendedErrorInfo errorInfo(IDS_E_BADINSTALL);
		return errorInfo;
	}

	// DLL is registered with VS via a pkgdef file. Don't do anything if asked to
	// self-register.
	static HRESULT WINAPI UpdateRegistry(BOOL bRegister)
	{
		return S_OK;
	}

// NOTE - the arguments passed to these macros can not have names longer then 30 characters
// Definition of the commands handled by this package
VSL_BEGIN_COMMAND_MAP()
%MenuItemStart%
    VSL_COMMAND_MAP_ENTRY(CLSID_%ProjectClass%CmdSet, %CommandID%, NULL, CommandHandler::ExecHandler(&OnMyCommand))%MenuItemEnd%
%ToolWindowItemStart%    VSL_COMMAND_MAP_ENTRY(CLSID_%ProjectClass%CmdSet, %ToolCommandID%, NULL, CommandHandler::ExecHandler(&OnMyTool))%ToolWindowItemEnd%
VSL_END_VSCOMMAND_MAP()

%ToolWindowItemStart%
// The tool map implements IVsPackage::CreateTool that is called by VS to create a tool window 
// when appropriate.
VSL_BEGIN_TOOL_MAP()
    VSL_TOOL_ENTRY(CLSID_guidPersistanceSlot, m_MyToolWindow.CreateAndShow())
VSL_END_TOOL_MAP()

// Command handler called when the user selects the command to show the toolwindow.
void OnMyTool(CommandHandler* /*pSender*/, DWORD /*flags*/, VARIANT* /*pIn*/, VARIANT* /*pOut*/)
{
    m_MyToolWindow.CreateAndShow();
}
%ToolWindowItemEnd%%MenuItemStart%
// Command handler called when the user selects the "My Command" command.
void OnMyCommand(CommandHandler* /*pSender*/, DWORD /*flags*/, VARIANT* /*pIn*/, VARIANT* /*pOut*/)
{
	// Get the string for the title of the message box from the resource dll.
	CComBSTR bstrTitle;
	VSL_CHECKBOOL_GLE(bstrTitle.LoadStringW(_AtlBaseModule.GetResourceInstance(), IDS_PROJNAME));
	// Get a pointer to the UI Shell service to show the message box.
	CComPtr<IVsUIShell> spUiShell = this->GetVsSiteCache().GetCachedService<IVsUIShell, SID_SVsUIShell>();
	LONG lResult;
	HRESULT hr = spUiShell->ShowMessageBox(
	                             0,
	                             CLSID_NULL,
	                             bstrTitle,
	                             W2OLE(L"%CPPMenuItemCallbackText%"),
	                             NULL,
	                             0,
	                             OLEMSGBUTTON_OK,
	                             OLEMSGDEFBUTTON_FIRST,
	                             OLEMSGICON_INFO,
	                             0,
	                             &lResult);
	VSL_CHECKHRESULT(hr);
}
%MenuItemEnd%

private:
%ToolWindowItemStart%    %ProjectClass%ToolWindow m_MyToolWindow;%ToolWindowItemEnd%

%EditorStart%	// Cookie returned when registering editor
	VSCOOKIE m_dwEditorCookie;%EditorEnd%
};

// This exposes C%ProjectClass%Package for instantiation via DllGetClassObject; however, an instance
// can not be created by CoCreateInstance, as C%ProjectClass%Package is specifically registered with
// VS, not the the system in general.
OBJECT_ENTRY_AUTO(CLSID_%ProjectClass%, C%ProjectClass%Package)
