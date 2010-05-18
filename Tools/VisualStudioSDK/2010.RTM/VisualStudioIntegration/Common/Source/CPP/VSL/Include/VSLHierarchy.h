/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLVsSite.h>
#include <VSLHierarchyNode.h>
#include <VSLControls.h>

namespace VSL
{

class IVsHierarchyItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyItem)

public:
	typedef IVsHierarchyItem ItemInterface;

	virtual const GUID& GetGuidProperty(_In_ VSHPROPID propid) const = 0;

	virtual void SetGuidProperty(_In_ VSHPROPID propid,	_In_ REFGUID rguid) = 0;

	virtual void GetProperty(_In_ VSHPROPID propid, _Out_ VARIANT* pVar) = 0;

	virtual void SetProperty(_In_ VSHPROPID propid, _In_ VARIANT& rVar) = 0;

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
	virtual const ATL::CComBSTR& GetCanonicalName() const = 0;

	virtual VSITEMID ParseCanonicalName(_In_ LPCOLESTR pszName) const = 0;
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

	virtual VSITEMID GetVSITEMID() const = 0;

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
	virtual const GUID& GetTypeGuid() const = 0;
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

	virtual IVsHierarchyEvents* GetIVsHierarchyEvents() = 0;
};

class IVsUIHierarchyItem :
	public IVsHierarchyItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierarchyItem)

public:
	typedef IVsUIHierarchyItem ItemInterface;

	enum
	{
		SupportsUI
	};

	virtual IOleCommandTarget* GetIOleCommandTarget() = 0;

	virtual IDispatch* GetIDispatch() = 0;

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
	virtual IVsUserContext* GetIVsUserContext() = 0;
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

	virtual bool IsVisible() const = 0;

	virtual const GUID& GetCmdUIGuid() const = 0;

	virtual const ATL::CComBSTR& GetCaption() const = 0;

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
	virtual const ATL::CComBSTR& GetName() const = 0;

	virtual const ATL::CComBSTR& GetEditLabel() const = 0;
	virtual void SetEditLabel(BSTR rbstrEditLabel) = 0;
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

	virtual UINT GetIconIndex() const = 0;

	virtual HICON GetIconHandle() const = 0;

	virtual HICON GetOpenFolderIconHandle() const = 0;

	virtual UINT GetOpenFolderIconIndex() const = 0;

	virtual bool IsExpandable() const = 0;

	virtual bool IsExpandedByDefault() const = 0;

	virtual bool IsExpanded() const = 0;

	virtual void SetExpanded(bool bExpanded) = 0;
};

template <class ItemInterface_T = IVsHierarchyItem>
class IVsHierarchyRootItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyRootItem)

public:
	typedef ItemInterface_T ItemInterface;

	virtual ItemInterface& GetItem(_In_ VSITEMID itemid) = 0;

	virtual const GUID& GetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid) const = 0;

	virtual void SetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _In_ REFGUID rguid) = 0;

	virtual void GetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _Out_ VARIANT* pVar) const = 0;

	virtual void SetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _In_ VARIANT& rVar) = 0;
};

template <class Base_T = IVsHierarchyRootItem<IVSUIHierarchyItem> >
class IVsUIHierarchyRootItem :
	public Base_T
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUIHierarchyRootItem)

public:

	virtual ImageListWin32Control& GetIconImageList() = 0;
};

#pragma warning(push)
#pragma warning(disable : 4355) // 'this' : used in base member initializer list
// Warning disabled as this is safe, as the node just holds the item, but doesn't call into it
// This must be disable at the class scope rather then the at the scope of each constructor

template <
	class Base_T = IVsHierarchyItem,
	class HierarchyNode_T = HierarchyNode<HierarchyNodeTraits<Base_T::ItemInterface*> > >
class VsHierarchyItemBase :
	public Base_T
{
private:

	const VsHierarchyItemBase& operator=(const VsHierarchyItemBase& rToCopy);

public:

	typedef typename HierarchyNode_T HierarchyNode;

protected:

	VsHierarchyItemBase():
		 m_pNode()
	{
		// No default construction allowed, this method should never actually
		// be called, but it needs to be present to compile correctly in some circumstances
		VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
	}

	VsHierarchyItemBase(typename HierarchyNode::Item& item):
		 m_pNode(new HierarchyNode(item))
	{
	}

	~VsHierarchyItemBase()
	{
		// Don't delete m_pNode, it's parent node owns it
	}

public:
	explicit VsHierarchyItemBase(VsHierarchyItemBase& rParent):
		m_pNode(rParent.m_pNode->AddDescendant(this))
	{
	}

	// compile generated destructor is fine
	// Except for the root node, all of the nodes are deleted by their parent node
	// The root item is responsible for deleting the root node

	virtual const GUID& GetGuidProperty(_In_ VSHPROPID propid) const
	{
		switch(propid)
		{
		// intentional fall through below
		case VSHPROPID_Parent:
		case VSHPROPID_FirstChild:
		case VSHPROPID_NextSibling:
		case VSHPROPID_Root:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_TypeGuid:
			__if_exists(ItemInterface::GetTypeGuid)
			{
				return GetTypeGuid();
			}
			break;
		case VSHPROPID_SaveName:
		case VSHPROPID_Caption:
		case VSHPROPID_IconImgList:
		case VSHPROPID_IconIndex:
		case VSHPROPID_Expandable:
		case VSHPROPID_ExpandByDefault:
		case VSHPROPID_Name: // == VSHPROPID_ProjectName
		case VSHPROPID_IconHandle:
		case VSHPROPID_OpenFolderIconHandle:
		case VSHPROPID_OpenFolderIconIndex:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_CmdUIGuid:
			__if_exists(ItemInterface::SupportsUI)
			{
				return GetCmdUIGuid();
			}
			break;
		// intentional fall through below
		case VSHPROPID_SelContainer:
		case VSHPROPID_BrowseObject:
		case VSHPROPID_AltHierarchy:
		case VSHPROPID_AltItemid:
		case VSHPROPID_ProjectDir:
		case VSHPROPID_SortPriority:
		case VSHPROPID_UserContext:
		case VSHPROPID_EditLabel:
		case VSHPROPID_ExtObject:
		case VSHPROPID_ExtSelectedItem:
		case VSHPROPID_StateIconIndex:
		case VSHPROPID_TypeName: // == VSHPROPID_ProjectType
		case VSHPROPID_HandlesOwnReload: // == VSHPROPID_ReloadableProjectFile
		case VSHPROPID_ParentHierarchy:
		case VSHPROPID_ParentHierarchyItemid:
		case VSHPROPID_ItemDocCookie:
		case VSHPROPID_Expanded:
		case VSHPROPID_ConfigurationProvider:
		case VSHPROPID_ImplantHierarchy:
		case VSHPROPID_OwnerKey:
		case VSHPROPID_StartupServices:
		case VSHPROPID_FirstVisibleChild:
		case VSHPROPID_NextVisibleSibling:
		case VSHPROPID_IsHiddenItem:
		case VSHPROPID_IsNonMemberItem:
		case VSHPROPID_IsNonLocalStorage:
		case VSHPROPID_StorageType:
		case VSHPROPID_ItemSubType:
		case VSHPROPID_OverlayIconIndex:
		case VSHPROPID_DefaultNamespace:
		case VSHPROPID_IsNonSearchable:
		case VSHPROPID_IsFindInFilesForegroundOnly:
		case VSHPROPID_CanBuildFromMemory:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_PreferredLanguageSID:
			__if_exists(ItemInterface::GetPreferredLanguageSID)
			{
				return GetPreferredLanguageSID();
			}
			break;
		// intentional fall through below
		case VSHPROPID_ShowProjInSolutionPage:
		case VSHPROPID_AllowEditInRunMode:
		case VSHPROPID_IsNewUnsavedItem:
		case VSHPROPID_ShowOnlyItemCaption:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_ProjectIDGuid:
			__if_exists(ItemInterface::GetProjectIDGuid)
			{
				return GetProjectIDGuid();
			}
			break;
		// intentional fall through below
		case VSHPROPID_DesignerVariableNaming:
		case VSHPROPID_DesignerFunctionVisibility:
		case VSHPROPID_HasEnumerationSideEffects:
		case VSHPROPID_DefaultEnableBuildProjectCfg:
		case VSHPROPID_DefaultEnableDeployProjectCfg:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		default:
			VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
		}

		VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
		return GUID_NULL;
	}

	virtual void SetGuidProperty(_In_ VSHPROPID propid,	_In_ REFGUID rguid)
	{
		(rguid);
		switch(propid)
		{
		// intentional fall through below
		case VSHPROPID_Parent:
		case VSHPROPID_FirstChild:
		case VSHPROPID_NextSibling:
		case VSHPROPID_Root:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_TypeGuid:
			break; // Property can't be set
		// intentional fall through below
		case VSHPROPID_SaveName:
		case VSHPROPID_Caption:
		case VSHPROPID_IconImgList:
		case VSHPROPID_IconIndex:
		case VSHPROPID_Expandable:
		case VSHPROPID_ExpandByDefault:
		case VSHPROPID_Name: // == VSHPROPID_ProjectName
		case VSHPROPID_IconHandle:
		case VSHPROPID_OpenFolderIconHandle:
		case VSHPROPID_OpenFolderIconIndex:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_CmdUIGuid:
			break; // Property can't be set
		// intentional fall through below
		case VSHPROPID_SelContainer:
		case VSHPROPID_BrowseObject:
		case VSHPROPID_AltHierarchy:
		case VSHPROPID_AltItemid:
		case VSHPROPID_ProjectDir:
		case VSHPROPID_SortPriority:
		case VSHPROPID_UserContext:
		case VSHPROPID_EditLabel:
		case VSHPROPID_ExtObject:
		case VSHPROPID_ExtSelectedItem:
		case VSHPROPID_StateIconIndex:
		case VSHPROPID_TypeName: // == VSHPROPID_ProjectType
		case VSHPROPID_HandlesOwnReload: // == VSHPROPID_ReloadableProjectFile
		case VSHPROPID_ParentHierarchy:
		case VSHPROPID_ParentHierarchyItemid:
		case VSHPROPID_ItemDocCookie:
		case VSHPROPID_Expanded:
		case VSHPROPID_ConfigurationProvider:
		case VSHPROPID_ImplantHierarchy:
		case VSHPROPID_OwnerKey:
		case VSHPROPID_StartupServices:
		case VSHPROPID_FirstVisibleChild:
		case VSHPROPID_NextVisibleSibling:
		case VSHPROPID_IsHiddenItem:
		case VSHPROPID_IsNonMemberItem:
		case VSHPROPID_IsNonLocalStorage:
		case VSHPROPID_StorageType:
		case VSHPROPID_ItemSubType:
		case VSHPROPID_OverlayIconIndex:
		case VSHPROPID_DefaultNamespace:
		case VSHPROPID_IsNonSearchable:
		case VSHPROPID_IsFindInFilesForegroundOnly:
		case VSHPROPID_CanBuildFromMemory:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_PreferredLanguageSID:
			break; // Property can't be set
		// intentional fall through below
		case VSHPROPID_ShowProjInSolutionPage:
		case VSHPROPID_AllowEditInRunMode:
		case VSHPROPID_IsNewUnsavedItem:
		case VSHPROPID_ShowOnlyItemCaption:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		case VSHPROPID_ProjectIDGuid:
			break; // Property can't be set
		// intentional fall through below
		case VSHPROPID_DesignerVariableNaming:
		case VSHPROPID_DesignerFunctionVisibility:
		case VSHPROPID_HasEnumerationSideEffects:
		case VSHPROPID_DefaultEnableBuildProjectCfg:
		case VSHPROPID_DefaultEnableDeployProjectCfg:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED); // Should be calling GetProperty
			break;
		default:
			VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
		}

		VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
	}

	virtual void GetProperty(_In_ VSHPROPID propid, _Out_ VARIANT* pVar)
	{
		switch(propid)
		{
		case VSHPROPID_Parent: // intentional fall through
		case VSHPROPID_FirstChild:
			GetRelativesVSITEMID(propid, pVar);
			return;
		case VSHPROPID_NextSibling: // intentional fall through
		case VSHPROPID_Root:
			VSL_ASSERT(false); // Should never get here, root should take care of this
			break;
		case VSHPROPID_TypeGuid:
			break; // Should be calling GetPropertyGuid
		case VSHPROPID_SaveName:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_Caption:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(GetCaption());
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
		case VSHPROPID_IconImgList:
			VSL_ASSERT(false); // Should never get here, root should take care of this
			break;
		case VSHPROPID_IconIndex:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(static_cast<long>(GetIconIndex()));
				var.Detach(pVar);
				return;
			}}
			// intentional fall through
		case VSHPROPID_Expandable:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(IsExpandable());
				var.Detach(pVar);
				return;
			}}
			// intentional fall through
		case VSHPROPID_ExpandByDefault:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(IsExpandedByDefault());
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{{
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}}
			break;
		case VSHPROPID_Name: // == VSHPROPID_ProjectName
			__if_exists(ItemInterface::GetName)
			{{
				ATL::CComVariant var(GetName());
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::GetName)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_IconHandle:
			__if_exists(ItemInterface::SupportsUI)
			{{
#pragma warning(push)
#pragma warning(disable : 4311) // 'reinterpret_cast' : pointer truncation from 'HICON' to 'long'
				ATL::CComVariant var(reinterpret_cast<long>(GetIconHandle()));
#pragma warning(pop)
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_OpenFolderIconHandle:
			__if_exists(ItemInterface::SupportsUI)
			{{
#pragma warning(push)
#pragma warning(disable : 4311) // 'reinterpret_cast' : pointer truncation from 'HICON' to 'long'
				ATL::CComVariant var(reinterpret_cast<long>(GetOpenFolderIconHandle()));
#pragma warning(pop)
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_OpenFolderIconIndex:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(static_cast<long>(GetOpenFolderIconIndex()));
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_CmdUIGuid:
			break; // Should be calling GetPropertyGuid
		case VSHPROPID_SelContainer:
			__if_exists(ItemInterface::GetISelectionContainer)
			{{
				ISelectionContainer* pISelectionContainer = GetISelectionContainer();
				// Visual Studio will try VSHPROPID_BrowseObject instead
				VSL_CHECKPOINTER(pISelectionContainer, E_NOTIMPL);
				ATL::CComVariant var(pISelectionContainer);
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::GetISelectionContainer)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_BrowseObject:
			__if_exists(ItemInterface::SupportsUI)
			{{
				IDispatch* pIDispatch = GetIDispatch();
#ifdef DEBUG
			__if_not_exists(ItemInterface::GetISelectionContainer)
			{{
				if(pIDispatch == NULL)
				{
					VSL_ASSERTEX(false, L"GetIDispatch is required to return not NULL if GetISelectionContainer is not supported!");
				}
			}}
#endif // DEBUG
				VSL_CHECKPOINTER(pIDispatch, E_NOTIMPL);
				ATL::CComVariant var(pIDispatch);
				var.Detach(pVar);
				return;
			}}
		// intentional fall through here and below
		case VSHPROPID_AltHierarchy:
		case VSHPROPID_AltItemid:
		case VSHPROPID_ProjectDir:
		case VSHPROPID_SortPriority:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_UserContext:
			__if_exists(ItemInterface::GetIVsUserContext)
			{{
				IVsUserContext* pIVsUserContext = GetIVsUserContext();
				VSL_CHECKPOINTER(pIVsUserContext, E_NOTIMPL);
				ATL::CComVariant var(pIVsUserContext);
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::GetIVsUserContext)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		case VSHPROPID_EditLabel:
			__if_exists(ItemInterface::GetEditLabel)
			{{
				ATL::CComVariant var(GetEditLabel());
				var.Detach(pVar);
				return;
			}}
		// intentional fall through here and below
		case VSHPROPID_ExtObject:
		case VSHPROPID_ExtSelectedItem:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_StateIconIndex:
			__if_exists(ItemInterface::SupportsSourceControl)
			{{
				ATL::CComVariant var(static_cast<long>(GetStateIconIndex()));
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsSourceControl)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			break;
		// intentional fall through below
		case VSHPROPID_TypeName: // == VSHPROPID_ProjectType
		case VSHPROPID_HandlesOwnReload: // == VSHPROPID_ReloadableProjectFile
		case VSHPROPID_ParentHierarchy: // FUTURE - handle this here or on the root?
		case VSHPROPID_ParentHierarchyItemid: // FUTURE - handle this here or on the root?
		case VSHPROPID_ItemDocCookie:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_Expanded:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(IsExpanded());
				var.Detach(pVar);
				return;
			}}
			__if_not_exists(ItemInterface::SupportsUI)
			{{
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}}
			break;
		case VSHPROPID_ConfigurationProvider:
		case VSHPROPID_ImplantHierarchy:  // FUTURE - handle this here or on the root?
		case VSHPROPID_OwnerKey: // FUTURE - handle this here or on the root?
		case VSHPROPID_StartupServices:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_FirstVisibleChild:
			GetRelativesVSITEMID(propid, pVar);
			return;
		case VSHPROPID_NextVisibleSibling:
			VSL_ASSERT(false); // Should never get here, root should take care of this
			break;
		case VSHPROPID_IsHiddenItem:
			__if_exists(ItemInterface::SupportsUI)
			{{
				ATL::CComVariant var(!IsVisible());
				var.Detach(pVar);
				return;
			}}
		// intentional fall through here and below
		case VSHPROPID_IsNonMemberItem:
		case VSHPROPID_IsNonLocalStorage:
		case VSHPROPID_StorageType:
		case VSHPROPID_ItemSubType:
		case VSHPROPID_OverlayIconIndex:
		case VSHPROPID_DefaultNamespace:
		case VSHPROPID_IsNonSearchable:
		case VSHPROPID_IsFindInFilesForegroundOnly:
		case VSHPROPID_CanBuildFromMemory:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_PreferredLanguageSID:
			break; // Should be calling GetPropertyGuid
		// intentional fall through below
		case VSHPROPID_ShowProjInSolutionPage:
		case VSHPROPID_AllowEditInRunMode:
		case VSHPROPID_IsNewUnsavedItem:
		case VSHPROPID_ShowOnlyItemCaption:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		case VSHPROPID_ProjectIDGuid:
			break; // Should be calling GetPropertyGuid
		// intentional fall through below
		case VSHPROPID_DesignerVariableNaming:
		case VSHPROPID_DesignerFunctionVisibility:
		case VSHPROPID_HasEnumerationSideEffects:
		case VSHPROPID_DefaultEnableBuildProjectCfg:
		case VSHPROPID_DefaultEnableDeployProjectCfg:
	// __VSHPROPID2 - new for Visual Studio 8.0
		case VSHPROPID_PropertyPagesCLSIDList:
		case VSHPROPID_CfgPropertyPagesCLSIDList:
		case VSHPROPID_ExtObjectCATID:
		case VSHPROPID_BrowseObjectCATID:
		case VSHPROPID_CfgBrowseObjectCATID:
		case VSHPROPID_AddItemTemplatesGuid:
		case VSHPROPID_ChildrenEnumerated:
		case VSHPROPID_StatusBarClientText:
		case VSHPROPID_DebuggeeProcessId:
		case VSHPROPID_IsLinkFile:
		case VSHPROPID_KeepAliveDocument:
		case VSHPROPID_SupportsProjectDesigner:
		case VSHPROPID_IntellisenseUnknown:
		case VSHPROPID_IsUpgradeRequired:
		case VSHPROPID_DesignerHiddenCodeGeneration:
		case VSHPROPID_SuppressOutOfDateMessageOnBuild:
		case VSHPROPID_Container:
		case VSHPROPID_UseInnerHierarchyIconList:
		case VSHPROPID_EnableDataSourceWindow:
		case VSHPROPID_AppTitleBarTopHierarchyName:
		case VSHPROPID_DebuggerSourcePaths:
		case VSHPROPID_CategoryGuid:
		case VSHPROPID_DisableApplicationSettings:
		case VSHPROPID_ProjectDesignerEditor:
		case VSHPROPID_PriorityPropertyPagesCLSIDList:
		case VSHPROPID_NoDefaultNestedHierSorting:
		case VSHPROPID_ExcludeFromExportItemTemplate:
		case VSHPROPID_SupportedMyApplicationTypes:
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			break;
		default:
			VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
		}

		VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
	}

	virtual void SetProperty(_In_ VSHPROPID propid, _In_ VARIANT& rVar)
	{
		(rVar);
		switch(propid)
		{
		// Intentional fall through below
		case VSHPROPID_Parent:
		case VSHPROPID_FirstChild:
		case VSHPROPID_NextSibling:
		case VSHPROPID_Root:
			break; // Property can't be set
		case VSHPROPID_TypeGuid:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);  // Should be calling SetPropertyGuid
			break;
		// intentional fall through below
		case VSHPROPID_SaveName:
		case VSHPROPID_Caption:
		case VSHPROPID_IconImgList:
		case VSHPROPID_IconIndex:
		case VSHPROPID_Expandable:
		case VSHPROPID_ExpandByDefault:
		case VSHPROPID_Name: // == VSHPROPID_ProjectName
		case VSHPROPID_IconHandle:
		case VSHPROPID_OpenFolderIconHandle:
		case VSHPROPID_OpenFolderIconIndex:
			break; // Property can't be set
		case VSHPROPID_CmdUIGuid:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);  // Should be calling SetPropertyGuid
			break;
		// intentional fall through below
		case VSHPROPID_SelContainer:
		case VSHPROPID_BrowseObject:
		case VSHPROPID_AltHierarchy:
		case VSHPROPID_AltItemid:
		case VSHPROPID_ProjectDir:
		case VSHPROPID_SortPriority:
		case VSHPROPID_UserContext:
			break; // Property can't be set
		case VSHPROPID_EditLabel:
			__if_exists(ItemInterface::SetEditLabel)
			{
				VSL_CHECKBOOLEAN(rVar.vt == VT_BSTR, DISP_E_BADVARTYPE);
				SetEditLabel(rVar.bstrVal);
				return;
			}
			break;
		// intentional fall through below
		case VSHPROPID_ExtObject:
		case VSHPROPID_ExtSelectedItem:
		case VSHPROPID_StateIconIndex:
		case VSHPROPID_TypeName: // == VSHPROPID_ProjectType
		case VSHPROPID_HandlesOwnReload: // == VSHPROPID_ReloadableProjectFile
		case VSHPROPID_ParentHierarchy: // FUTURE - handle this here or on the root?
		case VSHPROPID_ParentHierarchyItemid: // FUTURE - handle this here or on the root?
		case VSHPROPID_ItemDocCookie:
			break; // Property can't be set
		case VSHPROPID_Expanded:
			__if_exists(ItemInterface::SupportsUI)
			{{
				VSL_CHECKBOOLEAN(rVar.vt == VT_BOOL, DISP_E_BADVARTYPE);
				SetExpanded(rVar.boolVal != VARIANT_FALSE);
				return;
			}}
			// else property can't be set
			break;
		case VSHPROPID_ConfigurationProvider:
		case VSHPROPID_ImplantHierarchy:
		case VSHPROPID_OwnerKey: // FUTURE - handle this here or on the root?
		case VSHPROPID_StartupServices:
		case VSHPROPID_FirstVisibleChild:
		case VSHPROPID_NextVisibleSibling:
		case VSHPROPID_IsHiddenItem:
		case VSHPROPID_IsNonMemberItem:
		case VSHPROPID_IsNonLocalStorage:
		case VSHPROPID_StorageType:
		case VSHPROPID_ItemSubType:
		case VSHPROPID_OverlayIconIndex:
		case VSHPROPID_DefaultNamespace:
		case VSHPROPID_IsNonSearchable:
		case VSHPROPID_IsFindInFilesForegroundOnly:
		case VSHPROPID_CanBuildFromMemory:
			break; // Property can't be set
		case VSHPROPID_PreferredLanguageSID:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);  // Should be calling SetPropertyGuid
			break;
		// intentional fall through below
		case VSHPROPID_ShowProjInSolutionPage:
		case VSHPROPID_AllowEditInRunMode:
		case VSHPROPID_IsNewUnsavedItem:
		case VSHPROPID_ShowOnlyItemCaption:
			break; // Property can't be set
		case VSHPROPID_ProjectIDGuid:
			VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);  // Should be calling SetPropertyGuid
			break;
		// intentional fall through below
		case VSHPROPID_DesignerVariableNaming:
		case VSHPROPID_DesignerFunctionVisibility:
		case VSHPROPID_HasEnumerationSideEffects:
		case VSHPROPID_DefaultEnableBuildProjectCfg:
		case VSHPROPID_DefaultEnableDeployProjectCfg:
			break; // Property can't be set
		default:
			VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
		}

		VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
	}

	virtual VSITEMID GetVSITEMID() const
	{
		return reinterpret_cast<VSITEMID>(static_cast<HierarchyNode::Item>(const_cast<VsHierarchyItemBase*>(this)));
	}

	virtual IVsHierarchyEvents* GetIVsHierarchyEvents()
	{
		return GetRoot()->GetIVsHierarchyEvents();
	}

protected:

	void FirePropertyChanged(VSHPROPID propid)
	{
		VSL_CHECKHRESULT(GetIVsHierarchyEvents()->OnPropertyChanged(GetVSITEMID(), propid, 0));
	}

	void Delete()
	{
		m_pNode->GetParent()->RemoveDescendant(m_pNode);
		// instance is invalid now
	}

	HierarchyNode* const m_pNode;

private:

	IVsHierarchyItem* GetRoot()
	{
		HierarchyNode* pNodeParent = m_pNode;
		HierarchyNode* pNode = m_pNode;
		while(NULL != (pNode = pNode->GetParent()))
		{
			pNodeParent = pNode;
		}
		return **pNodeParent;
	}

	void GetRelativesVSITEMID(_In_ VSHPROPID propid, _Out_ VARIANT* pVar) const
	{
		VSITEMID requestedId = VSITEMID_NIL;

		switch(propid)
		{
		case VSHPROPID_Parent:
			requestedId = (**(m_pNode->GetParent()))->GetVSITEMID();
			break;
		case VSHPROPID_FirstChild:
			requestedId = (***(GetDescendantContainer().begin()))->GetVSITEMID();
			break;
		case VSHPROPID_FirstVisibleChild:
			{
			__if_exists(ItemInterface::SupportsUI)
			{
				HierarchyNode::DescendantContainer& rContainer = GetDescendantContainer();
				for(HierarchyNode::iterator i = rContainer.begin(); i != rContainer.end(); ++i)
				{
					if((***(i))->IsVisible())
					{
						requestedId = (***(i))->GetVSITEMID();
						break;
					}
				}
			}
			__if_not_exists(ItemInterface::SupportsUI)
			{
				VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
			}
			}
			break;
		default:
			VSL_ASSERT(false); // PARANOID - should never get here
		}

		ATL::CComVariant var(static_cast<__int32>(requestedId), VT_I4);
		var.Detach(pVar);
	}

	typename HierarchyNode::DescendantContainer& GetDescendantContainer() const
	{
		HierarchyNode::DescendantContainer& rContainer = m_pNode->GetDescendantContainer();
		VSL_CHECKBOOLEAN(!rContainer.empty(), E_INVALIDARG);
		return rContainer;
	}
};
#pragma warning(pop)

template <class Base_T = VsHierarchyItemBase<IVsUIHierarchyItem> >
class VsUIHierarchyItemBase :
	public Base_T
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VsUIHierarchyItemBase)

protected:

	typedef Base_T BaseClass; // Note using the name Base causes problems with the Base template parameter for CComObject

	VsUIHierarchyItemBase(typename HierarchyNode::Item& item):
		Base_T(item),
		m_bExpanded(false)
	{
	}

public:
	VsUIHierarchyItemBase(Base_T& rParent):
		Base_T(rParent),
		m_bExpanded(false)
	{
	}

#ifdef VSL_TEST_HIERARCHY_METHODS_CALLED
	virtual ISelectionContainer* GetISelectionContainer()
	{
		return NULL;
	}

	virtual IVsUserContext* GetIVsUserContext()
	{
		return NULL;
	}
#endif // VSL_TEST_HIERARCHY_METHODS_CALLED

	virtual bool IsVisible() const
	{
		return true;
	}

	virtual UINT GetIconIndex() const
	{
		// indicates that Visual Studio should ask for the icon handle instead
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
		return 0;
	}

	virtual HICON GetIconHandle() const
	{
// If the hierarchy object doesn't support IVsProject then VS can not get the document path
// in order to try to get the file's system icon, so this is the last resort, as it is called after GetIconIndex
__if_not_exists(ItemInterface::SupportsProject)
{
		VSL_ASSERTEX(false, L"No project UI hierarchy item has no valid icon index and no icon handle, so the item can not be displayed");
}
		// indicates that Visual Studio should ask IVsProject to get a file path and use that file's associated icon instead
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
		return NULL;
	}

	virtual HICON GetOpenFolderIconHandle() const
	{
		return GetIconHandle();
	}

	virtual UINT GetOpenFolderIconIndex() const
	{
		return GetIconIndex();
	}

	virtual bool IsExpandable() const
	{
		return m_pNode->HasDescendants();
	}

	virtual bool IsExpandedByDefault() const
	{
		return false;
	}

	virtual bool IsExpanded() const
	{
		return m_bExpanded;
	}

	virtual void SetExpanded(bool bExpanded)
	{
		m_bExpanded = bExpanded;
	}

private:

	bool m_bExpanded;
};

template <
	class BaseImpl_T = VsHierarchyItemBase<>,
	class RootInterface_T = IVsHierarchyRootItem<BaseImpl_T::ItemInterface> >
class VsHierarchyRootItemBase :
	public BaseImpl_T,
	public RootInterface_T
{
public:
	typedef typename BaseImpl_T BaseImpl;
	typedef typename BaseImpl::ItemInterface ItemInterface;

	VsHierarchyRootItemBase(ItemInterface* pInterface):
		BaseImpl_T(pInterface),
		m_pSelection(NULL)
	{
	}

protected:
	~VsHierarchyRootItemBase()
	{
	}

public:
	void Dispose()
	{
		// The root node will delete each of it's children, and they will delete their children, and so on...
		// Destruction of the node will destory the item it contains, including this instance, so this 
		// instance is invalid after this delete.
		delete m_pNode;
	}

	virtual VSITEMID GetVSITEMID() const
	{
		return VSITEMID_ROOT;
	}

	virtual IVsHierarchyEvents* GetIVsHierarchyEvents()
	{
		// Derived class needs to implement this properly
		VSL_CREATE_ERROR_HRESULT(E_UNEXPECTED);
		return NULL;
	}

	virtual ItemInterface& GetItem(_In_ VSITEMID itemid)
	{
		VSL_CHECKBOOLEAN(itemid != VSITEMID_NIL, E_INVALIDARG);

		if(VSITEMID_ROOT == itemid)
		{
			return *this;
		}

		if(VSITEMID_SELECTION == itemid)
		{
			VSL_CHECKPOINTER(m_pSelection, E_UNEXPECTED);
			return *m_pSelection;
		}

		BaseImpl_T::HierarchyNode::ItemContainer* pItem = m_pNode->FindItemContainer(ItemIdToItem(itemid));
		VSL_CHECKPOINTER(pItem, E_INVALIDARG);
		return **pItem;
	}

	virtual const GUID& GetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid) const
	{
		return GetItem(itemid).GetGuidProperty(propid);
	}

	virtual void SetGuidProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _In_ REFGUID rguid)
	{
		GetItem(itemid).SetGuidProperty(propid, rguid);
	}

	virtual void GetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _Out_ VARIANT* pVar) const
	{
		VSITEMID requestedId = VSITEMID_ROOT;

		switch(propid)
		{
		case VSHPROPID_Root:
			break;
		case VSHPROPID_NextSibling:
			requestedId = ItemToItemId(GetNextSibling(itemid));
			break;
		case VSHPROPID_NextVisibleSibling:
			requestedId = ItemToItemId(GetNextVisibleSibling(itemid));
			break;
		case VSHPROPID_IconImgList:
			__if_exists(ItemInterface::SupportsUI)
			{{
				// VS only get's the image list from the root item, which means that it is global
				// for the entire hierarchy.
#pragma warning(push)
#pragma warning(disable : 4311) // 'reinterpret_cast' : pointer truncation from 'HIMAGELIST' to 'long'
				ATL::CComVariant var(reinterpret_cast<long>(static_cast<HIMAGELIST>(const_cast<VsHierarchyRootItemBase*>(this)->GetIconImageList())));
#pragma warning(pop)
				var.Detach(pVar);
				return;
			}}
		default:
			GetItem(itemid).GetProperty(propid, pVar);
			return;
		}

		ATL::CComVariant var(static_cast<__int32>(requestedId), VT_I4);
		var.Detach(pVar);
	}

	virtual void SetProperty(_In_ VSITEMID itemid, _In_ VSHPROPID propid, _In_ VARIANT& rVar)
	{
		GetItem(itemid).SetProperty(propid, rVar);
	}

	virtual ImageListWin32Control& GetIconImageList()
	{
		// indicates that Visual Studio will need to use icon handle for each item
		// of if no icon is provided, then attepmt to use IVsProject to get a file path 
		// and use that file's associated icon
		VSL_CREATE_ERROR_HRESULT(DISP_E_MEMBERNOTFOUND);
#pragma warning(push)
#pragma warning(disable : 4239 4172)
		return ImageListWin32Control();
#pragma warning(pop)
	}

protected:

	void SetSelection(ItemInterface* pSelection)
	{
		m_pSelection = pSelection;
	}

private:
	ItemInterface& GetItem(_In_ VSITEMID itemid) const
	{
		return const_cast<VsHierarchyRootItemBase*>(this)->GetItem(itemid);
	}

	typename BaseImpl_T::HierarchyNode::Item ItemIdToItem(_In_ VSITEMID itemid) const
	{
		return reinterpret_cast<BaseImpl_T::HierarchyNode::Item>(itemid);
	}

	VSITEMID ItemToItemId(_In_ const typename HierarchyNode::Item& item) const
	{
		return item != NULL ? item->GetVSITEMID() : VSITEMID_NIL;
	}

	VSITEMID TransformVSITEMIDForSibilingSearch(_In_ VSITEMID itemid) const
	{
		if(VSITEMID_ROOT == itemid)
		{
			VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
		}

		if(VSITEMID_SELECTION == itemid)
		{
			if(m_pSelection == static_cast<const ItemInterface* const>(this))
			{
				VSL_CREATE_ERROR_HRESULT(E_INVALIDARG);
			}
			return ItemToItemId(m_pSelection);
		}

		return itemid;
	}

	ItemInterface* GetNextSibling(_In_ VSITEMID itemid) const
	{
		BaseImpl_T::HierarchyNode::FindInfo findInfo = {ItemIdToItem(TransformVSITEMIDForSibilingSearch(itemid))};
		VSL_CHECKBOOLEAN(m_pNode->FindIterator(findInfo), E_INVALIDARG);
		if((++findInfo.rFound) != findInfo.pContainer->end())
		{
			return ***(findInfo.rFound);
		}
		return NULL;
	}

	ItemInterface* GetNextVisibleSibling(_In_ VSITEMID itemid) const
	{
		__if_exists(ItemInterface::SupportsUI)
		{
			BaseImpl_T::HierarchyNode::FindInfo findInfo = {ItemIdToItem(TransformVSITEMIDForSibilingSearch(itemid))};
			VSL_CHECKBOOLEAN(m_pNode->FindIterator(findInfo), E_INVALIDARG);
			for(++findInfo.rFound; findInfo.rFound != findInfo.pContainer->end(); ++findInfo.rFound)
			{
				if((***findInfo.rFound)->IsVisible())
				{
					return ***(findInfo.rFound);
				}
			}
		}
		__if_not_exists(ItemInterface::SupportsUI)
		{
			VSL_CREATE_ERROR_HRESULT(E_NOTIMPL);
		}
		return NULL;
	}

	ItemInterface* m_pSelection;
};

class IVsHierarchyEventsDelegate :
	public IVsHierarchyEvents
{
public:

// This isn't a real COM object
VSL_DEFINE_IUNKNOWN_NOTIMPL

	virtual HRESULT STDMETHODCALLTYPE OnItemAdded( 
        /* [in] */ VSITEMID itemidParent,
        /* [in] */ VSITEMID itemidSiblingPrev,
        /* [in] */ VSITEMID itemidAdded)
	{
		return m_dOnItemAdded(itemidParent, itemidSiblingPrev, itemidAdded);
	}
    
    virtual HRESULT STDMETHODCALLTYPE OnItemsAppended( 
        /* [in] */ VSITEMID itemidParent)
	{
		return m_dOnItemsAppended(itemidParent);
	}
    
    virtual HRESULT STDMETHODCALLTYPE OnItemDeleted( 
        /* [in] */ VSITEMID itemid)
	{
		return m_dOnItemDeleted(itemid);
	}
    
    virtual HRESULT STDMETHODCALLTYPE OnPropertyChanged( 
        /* [in] */ VSITEMID itemid,
        /* [in] */ VSHPROPID propid,
        /* [in] */ DWORD flags)
	{
		return m_dOnPropertyChanged(itemid, propid, flags);
	}
    
    virtual HRESULT STDMETHODCALLTYPE OnInvalidateItems( 
        /* [in] */ VSITEMID itemidParent)
	{
		return m_dOnInvalidateItems(itemidParent);
	}
    
    virtual /* [local] */ HRESULT STDMETHODCALLTYPE OnInvalidateIcon( 
        /* [in] */ HICON hicon)
	{
		return m_dOnInvalidateIcon(hicon);
	}

	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (VSITEMID, VSITEMID, VSITEMID)> OnItemAddedFunctor;
	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (VSITEMID)> OnItemsAppendedFunctor;
	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (VSITEMID)> OnItemDeletedFunctor;
	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (VSITEMID, VSHPROPID, DWORD)> OnPropertyChangedFunctor;
	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (VSITEMID)> OnInvalidateItemsFunctor;
	typedef MemberFunctionPointerFunctor<IVsHierarchyEvents, CallingConventionStandard, HRESULT (HICON)> OnInvalidateIconFunctor;

	struct IVsHierarchyEventsFunctors
	{
		OnItemAddedFunctor m_OnItemAddedFunctor;
		OnItemsAppendedFunctor m_OnItemsAppendedFunctor;
		OnItemDeletedFunctor m_OnItemDeletedFunctor;
		OnPropertyChangedFunctor m_OnPropertyChangedFunctor;
		OnInvalidateItemsFunctor m_OnInvalidateItemsFunctor;
		OnInvalidateIconFunctor m_OnInvalidateIconFunctor;

		IVsHierarchyEventsFunctors(
			IVsHierarchyEvents* pIVsHierarchyEvents):
				m_OnItemAddedFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnItemAdded),
				m_OnItemsAppendedFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnItemsAppended),
				m_OnItemDeletedFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnItemDeleted),
				m_OnPropertyChangedFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnPropertyChanged),
				m_OnInvalidateItemsFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnInvalidateItems),
				m_OnInvalidateIconFunctor(pIVsHierarchyEvents, &IVsHierarchyEvents::OnInvalidateIcon)
		{
		}
	};

	void operator+=(IVsHierarchyEventsFunctors& rFunctors)
	{
		m_dOnItemAdded += &(rFunctors.m_OnItemAddedFunctor);
		m_dOnItemsAppended += &(rFunctors.m_OnItemsAppendedFunctor);
		m_dOnItemDeleted += &(rFunctors.m_OnItemDeletedFunctor);
		m_dOnPropertyChanged += &(rFunctors.m_OnPropertyChangedFunctor);
		m_dOnInvalidateItems += &(rFunctors.m_OnInvalidateItemsFunctor);
		m_dOnInvalidateIcon += &(rFunctors.m_OnInvalidateIconFunctor);
	}

	void operator-=(IVsHierarchyEventsFunctors& rFunctors)
	{
		m_dOnItemAdded -= &(rFunctors.m_OnItemAddedFunctor);
		m_dOnItemsAppended -= &(rFunctors.m_OnItemsAppendedFunctor);
		m_dOnItemDeleted -= &(rFunctors.m_OnItemDeletedFunctor);
		m_dOnPropertyChanged -= &(rFunctors.m_OnPropertyChangedFunctor);
		m_dOnInvalidateItems -= &(rFunctors.m_OnInvalidateItemsFunctor);
		m_dOnInvalidateIcon -= &(rFunctors.m_OnInvalidateIconFunctor);
	}

private:
	Delegate<HRESULT (VSITEMID, VSITEMID, VSITEMID)> m_dOnItemAdded;
	Delegate<HRESULT (VSITEMID)> m_dOnItemsAppended;
	Delegate<HRESULT (VSITEMID)> m_dOnItemDeleted;
	Delegate<HRESULT (VSITEMID, VSHPROPID, DWORD)> m_dOnPropertyChanged;
	Delegate<HRESULT (VSITEMID)> m_dOnInvalidateItems;
	Delegate<HRESULT (HICON)> m_dOnInvalidateIcon;
};

template <
	class DerivedClass_T,
	class HierarchyRootItem_T,
	class Base_T = IVsHierarchy,
	class VsSiteCache_T = VsSiteCacheLocal >
class IVsHierarchyImpl :
	public VsSiteBaseImpl<DerivedClass_T, IVsHierarchyImpl<DerivedClass_T, HierarchyRootItem_T, Base_T, VsSiteCache_T>, Base_T, VsSiteCache_T>
{

private:

	HierarchyRootItem_T* CreateRootItemInstance()
	{
		HierarchyRootItem_T* pRootItem = NULL;
		VSL_CHECKHRESULT(HierarchyRootItem_T::CreateInstance(&pRootItem));
		VSL_CHECKPOINTER(pRootItem, E_FAIL);
#pragma warning(push) // compiler doesn't get that the above line will throw if pValidValues is NULL
#pragma warning(disable : 6011) // Dereferencing NULL pointer 'pRootItem'
		__if_exists(HierarchyRootItem_T::AddRef)
		{
			pRootItem->AddRef();
		}
		return pRootItem;
#pragma warning(pop)
	}

protected:

	
	IVsHierarchyImpl():
		m_pRoot(CreateRootItemInstance()),
	 	m_LastCookie(0)
	{
	}

	~IVsHierarchyImpl()
	{
		m_pRoot->Dispose();
	}

public:

	typedef HierarchyRootItem_T HierarchyRootItem;
	typedef typename HierarchyRootItem::ItemInterface ItemInterface;

	STDMETHOD(GetGuidProperty)( 
		_In_ VSITEMID itemid,
		_In_ VSHPROPID propid,
		_Out_ GUID *pguid)
	{
		VSL_STDMETHODTRY{

		EnsureValidVSHPROPID(propid);
		VSL_CHECKPOINTER(pguid, E_INVALIDARG);

		*pguid = GetRootItem().GetGuidProperty(itemid, propid);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(SetGuidProperty)( 
		_In_ VSITEMID itemid,
		_In_ VSHPROPID propid,
		_In_ REFGUID rguid)
	{
		VSL_STDMETHODTRY{

		EnsureValidVSHPROPID(propid);

		GetRootItem().SetGuidProperty(itemid, propid, rguid);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(GetProperty)( 
		_In_ VSITEMID itemid,
		_In_ VSHPROPID propid,
		_Out_ VARIANT *pvar)
	{
		VSL_STDMETHODTRY{

		EnsureValidVSHPROPID(propid);
		VSL_CHECKPOINTER(pvar, E_INVALIDARG);
		pvar->vt = VT_EMPTY;

		GetRootItem().GetProperty(itemid, propid, pvar);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(SetProperty)( 
		_In_ VSITEMID itemid,
		_In_ VSHPROPID propid,
		_In_ VARIANT var)
	{
		VSL_STDMETHODTRY{

		EnsureValidVSHPROPID(propid);

		GetRootItem().SetProperty(itemid, propid, var);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(GetNestedHierarchy)( 
		_In_ VSITEMID itemid,
		_In_ REFIID iidHierarchyNested,
		_Out_ void **ppHierarchyNested,
		_Out_ VSITEMID *pitemidNested)
	{
#if 1
		VSL_TRACE(_T("IVsHierarchyImpl::GetNestedHierarchy is not implemented\n"));

		(itemid, iidHierarchyNested, ppHierarchyNested, pitemidNested);

		return E_NOTIMPL;
#else // FUTURE - support IVsHierarchyImpl::GetNestedHierarchy
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppHierarchyNested, E_INVALIDARG);
		VSL_CHECKPOINTER(pitemidNested, E_INVALIDARG);

		(iidHierarchyNested);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
#endif
	}
	
	STDMETHOD(GetCanonicalName)( 
		_In_ VSITEMID itemid,
		_Out_ BSTR *pbstrName)
	{
		VSL_STDMETHODTRY_EX(E_NOTIMPL){

		VSL_CHECKPOINTER(pbstrName, E_INVALIDARG);

		__if_exists(ItemInterface::GetCanonicalName)
		{
		VSL_CHECKHRESULT(const_cast<ATL::CComBSTR&>(GetRootItem().GetItem(itemid).GetCanonicalName()).CopyTo(pbstrName));
		}
		__if_not_exists(ItemInterface::GetCanonicalName)
		{
		(itemid);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(ParseCanonicalName)( 
		_In_ LPCOLESTR pszName,
		_Out_ VSITEMID *pitemid)
	{
		VSL_STDMETHODTRY_EX(E_NOTIMPL){

		VSL_CHECKPOINTER(pszName, E_INVALIDARG);
		VSL_CHECKBOOLEAN(pszName[0] != L'\0', E_INVALIDARG);
		VSL_CHECKPOINTER(pitemid, E_INVALIDARG);

		__if_exists(ItemInterface::ParseCanonicalName)
		{
		*pitemid = GetRootItem().ParseCanonicalName(pszName);
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(Unused0)()
	{
		VSL_TRACE(_T("IVsHierarchyImpl::Unused0 is not implemented\n"));

		return E_NOTIMPL;
	}
	
	STDMETHOD(AdviseHierarchyEvents)( 
		_In_ IVsHierarchyEvents *pEventSink,
		_Out_ VSCOOKIE *pdwCookie)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pEventSink, E_INVALIDARG);
		VSL_CHECKPOINTER(pdwCookie, E_INVALIDARG);

		VSL_CHECKBOOLEAN(m_LastCookie < 0xFFFFFFFF, E_FAIL);

		m_CookieEventList.push_front(CookieEventPair(++m_LastCookie, pEventSink));
		m_IVsHierarchyEventsDelegate += (*(m_CookieEventList.begin())).second;
		*pdwCookie = m_LastCookie;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(UnadviseHierarchyEvents)( 
		_In_ VSCOOKIE dwCookie)
	{
		VSL_STDMETHODTRY{

		class RemoveCookieEvent
		{
		public:
			RemoveCookieEvent(VSCOOKIE cookie, IVsHierarchyEventsDelegate& rIVsHierarchyEventsDelegate):
				m_cookie(cookie),
				m_rIVsHierarchyEventsDelegate(rIVsHierarchyEventsDelegate)
			{
			}
			bool operator()(CookieEventPair& rToCheck)
			{
				if(rToCheck.first == m_cookie)
				{
					m_rIVsHierarchyEventsDelegate -= rToCheck.second;
					return true;
				}
				return false;
			}
			void operator=(const RemoveCookieEvent& rToCopy)
			{
				m_cookie = rToCopy.m_cookie;
				m_rIVsHierarchyEventsDelegate = rToCopy.m_rIVsHierarchyEventsDelegate;
			}
		private:
			VSCOOKIE m_cookie;
			IVsHierarchyEventsDelegate& m_rIVsHierarchyEventsDelegate;
		};

		// No verification that cookie is valid, just removal or not.
		m_CookieEventList.remove_if(RemoveCookieEvent(dwCookie, m_IVsHierarchyEventsDelegate));

		if(m_CookieEventList.empty())
		{
			// PARANOID - theoretically, over the long haul, m_LastCookie could wrap, 
			// so zero it when the list is empty
			m_LastCookie = 0;
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
	
	STDMETHOD(Unused1)()
	{
		VSL_TRACE(_T("IVsHierarchyImpl::Unused1 is not implemented\n"));

		return E_NOTIMPL;
	}
	
	STDMETHOD(Unused2)()
	{
		VSL_TRACE(_T("IVsHierarchyImpl::Unused2 is not implemented\n"));

		return E_NOTIMPL;
	}
	
	STDMETHOD(Unused3)()
	{
		VSL_TRACE(_T("IVsHierarchyImpl::Unused3 is not implemented\n"));

		return E_NOTIMPL;
	}
	
	STDMETHOD(Unused4)()
	{
		VSL_TRACE(_T("IVsHierarchyImpl::Unused4 is not implemented\n"));

		return E_NOTIMPL;
	}

	HierarchyRootItem& GetRootItem()
	{
		return *m_pRoot;
	}

	IVsHierarchyEvents* GetIVsHierarchyEvents()
	{
		return &m_IVsHierarchyEventsDelegate;
	}

protected:

	HierarchyRootItem* m_pRoot;

private:

	void EnsureValidVSHPROPID(_In_ VSHPROPID propid)
	{
		VSL_CHECKBOOLEAN(propid >= VSHPROPID_FIRST2 && propid <= VSHPROPID_LAST, E_INVALIDARG);
	}

	typedef std::pair<VSCOOKIE, IVsHierarchyEventsDelegate::IVsHierarchyEventsFunctors> CookieEventPair;

	std::list<CookieEventPair> m_CookieEventList;
	VSCOOKIE m_LastCookie;
	IVsHierarchyEventsDelegate m_IVsHierarchyEventsDelegate;
};

template <
	class DerivedClass_T,
	class HierarchyRootItem_T,
	class Base_T = IVsHierarchyImpl<DerivedClass_T, HierarchyRootItem_T, IVsUIHierarchy> >
class IVsUIHierarchyImpl :
	public Base_T
{
public:
	STDMETHOD(QueryStatusCommand)( 
		_In_ VSITEMID itemid,
		_In_ const GUID *pguidCmdGroup,
		_In_ ULONG cCmds,
		_Inout_cap_(cCmds) OLECMD prgCmds[  ],
		_Inout_opt_ OLECMDTEXT *pCmdText)
	{
		VSL_STDMETHODTRY{

		CComPtr<IOleCommandTarget> pTarget = GetRootItem().GetItem(itemid).GetIOleCommandTarget();

		if(!pTarget)
		{
			return OLECMDERR_E_NOTSUPPORTED;
		}

		return pTarget->QueryStatus(pguidCmdGroup, cCmds, prgCmds, pCmdText);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	};
	
	STDMETHOD(ExecCommand)( 
		_In_ VSITEMID itemid,
		_In_ const GUID *pguidCmdGroup,
		_In_ DWORD nCmdID,
		_In_ DWORD nCmdexecopt,
		_In_opt_ VARIANT *pvaIn,
		_Inout_opt_ VARIANT *pvaOut)
	{
		VSL_STDMETHODTRY{

		CComPtr<IOleCommandTarget> pTarget = GetRootItem().GetItem(itemid).GetIOleCommandTarget();

		if(!pTarget)
		{
			return OLECMDERR_E_NOTSUPPORTED;
		}

		return pTarget->Exec(pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}
};

} // namespace VSL

#endif // VSLHIERARCHY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
