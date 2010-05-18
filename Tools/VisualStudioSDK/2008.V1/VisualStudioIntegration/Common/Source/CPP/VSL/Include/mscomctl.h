

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* at Mon Aug 22 18:05:57 2005
 */
/* Compiler settings for ..\..\..\..\..\Common\Source\CPP\VSL\Include\mscomctl.IDL:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __mscomctl_h__
#define __mscomctl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IVBDataObject_FWD_DEFINED__
#define __IVBDataObject_FWD_DEFINED__
typedef interface IVBDataObject IVBDataObject;
#endif 	/* __IVBDataObject_FWD_DEFINED__ */


#ifndef __IVBDataObjectFiles_FWD_DEFINED__
#define __IVBDataObjectFiles_FWD_DEFINED__
typedef interface IVBDataObjectFiles IVBDataObjectFiles;
#endif 	/* __IVBDataObjectFiles_FWD_DEFINED__ */


#ifndef __ITabStrip_FWD_DEFINED__
#define __ITabStrip_FWD_DEFINED__
typedef interface ITabStrip ITabStrip;
#endif 	/* __ITabStrip_FWD_DEFINED__ */


#ifndef __ITabStripEvents_FWD_DEFINED__
#define __ITabStripEvents_FWD_DEFINED__
typedef interface ITabStripEvents ITabStripEvents;
#endif 	/* __ITabStripEvents_FWD_DEFINED__ */


#ifndef __ITabs_FWD_DEFINED__
#define __ITabs_FWD_DEFINED__
typedef interface ITabs ITabs;
#endif 	/* __ITabs_FWD_DEFINED__ */


#ifndef __ITab_FWD_DEFINED__
#define __ITab_FWD_DEFINED__
typedef interface ITab ITab;
#endif 	/* __ITab_FWD_DEFINED__ */


#ifndef __IToolbar_FWD_DEFINED__
#define __IToolbar_FWD_DEFINED__
typedef interface IToolbar IToolbar;
#endif 	/* __IToolbar_FWD_DEFINED__ */


#ifndef __IToolbarEvents_FWD_DEFINED__
#define __IToolbarEvents_FWD_DEFINED__
typedef interface IToolbarEvents IToolbarEvents;
#endif 	/* __IToolbarEvents_FWD_DEFINED__ */


#ifndef __IButtons_FWD_DEFINED__
#define __IButtons_FWD_DEFINED__
typedef interface IButtons IButtons;
#endif 	/* __IButtons_FWD_DEFINED__ */


#ifndef __IButton_FWD_DEFINED__
#define __IButton_FWD_DEFINED__
typedef interface IButton IButton;
#endif 	/* __IButton_FWD_DEFINED__ */


#ifndef __IButtonMenus_FWD_DEFINED__
#define __IButtonMenus_FWD_DEFINED__
typedef interface IButtonMenus IButtonMenus;
#endif 	/* __IButtonMenus_FWD_DEFINED__ */


#ifndef __IButtonMenu_FWD_DEFINED__
#define __IButtonMenu_FWD_DEFINED__
typedef interface IButtonMenu IButtonMenu;
#endif 	/* __IButtonMenu_FWD_DEFINED__ */


#ifndef __IStatusBar_FWD_DEFINED__
#define __IStatusBar_FWD_DEFINED__
typedef interface IStatusBar IStatusBar;
#endif 	/* __IStatusBar_FWD_DEFINED__ */


#ifndef __IStatusBarEvents_FWD_DEFINED__
#define __IStatusBarEvents_FWD_DEFINED__
typedef interface IStatusBarEvents IStatusBarEvents;
#endif 	/* __IStatusBarEvents_FWD_DEFINED__ */


#ifndef __IPanels_FWD_DEFINED__
#define __IPanels_FWD_DEFINED__
typedef interface IPanels IPanels;
#endif 	/* __IPanels_FWD_DEFINED__ */


#ifndef __IPanel_FWD_DEFINED__
#define __IPanel_FWD_DEFINED__
typedef interface IPanel IPanel;
#endif 	/* __IPanel_FWD_DEFINED__ */


#ifndef __IProgressBar_FWD_DEFINED__
#define __IProgressBar_FWD_DEFINED__
typedef interface IProgressBar IProgressBar;
#endif 	/* __IProgressBar_FWD_DEFINED__ */


#ifndef __IProgressBarEvents_FWD_DEFINED__
#define __IProgressBarEvents_FWD_DEFINED__
typedef interface IProgressBarEvents IProgressBarEvents;
#endif 	/* __IProgressBarEvents_FWD_DEFINED__ */


#ifndef __ITreeView_FWD_DEFINED__
#define __ITreeView_FWD_DEFINED__
typedef interface ITreeView ITreeView;
#endif 	/* __ITreeView_FWD_DEFINED__ */


#ifndef __ITreeViewEvents_FWD_DEFINED__
#define __ITreeViewEvents_FWD_DEFINED__
typedef interface ITreeViewEvents ITreeViewEvents;
#endif 	/* __ITreeViewEvents_FWD_DEFINED__ */


#ifndef __INodes_FWD_DEFINED__
#define __INodes_FWD_DEFINED__
typedef interface INodes INodes;
#endif 	/* __INodes_FWD_DEFINED__ */


#ifndef __INode_FWD_DEFINED__
#define __INode_FWD_DEFINED__
typedef interface INode INode;
#endif 	/* __INode_FWD_DEFINED__ */


#ifndef __IListView_FWD_DEFINED__
#define __IListView_FWD_DEFINED__
typedef interface IListView IListView;
#endif 	/* __IListView_FWD_DEFINED__ */


#ifndef __ListViewEvents_FWD_DEFINED__
#define __ListViewEvents_FWD_DEFINED__
typedef interface ListViewEvents ListViewEvents;
#endif 	/* __ListViewEvents_FWD_DEFINED__ */


#ifndef __IListItems_FWD_DEFINED__
#define __IListItems_FWD_DEFINED__
typedef interface IListItems IListItems;
#endif 	/* __IListItems_FWD_DEFINED__ */


#ifndef __IListItem_FWD_DEFINED__
#define __IListItem_FWD_DEFINED__
typedef interface IListItem IListItem;
#endif 	/* __IListItem_FWD_DEFINED__ */


#ifndef __IColumnHeaders_FWD_DEFINED__
#define __IColumnHeaders_FWD_DEFINED__
typedef interface IColumnHeaders IColumnHeaders;
#endif 	/* __IColumnHeaders_FWD_DEFINED__ */


#ifndef __IColumnHeader_FWD_DEFINED__
#define __IColumnHeader_FWD_DEFINED__
typedef interface IColumnHeader IColumnHeader;
#endif 	/* __IColumnHeader_FWD_DEFINED__ */


#ifndef __IListSubItems_FWD_DEFINED__
#define __IListSubItems_FWD_DEFINED__
typedef interface IListSubItems IListSubItems;
#endif 	/* __IListSubItems_FWD_DEFINED__ */


#ifndef __IListSubItem_FWD_DEFINED__
#define __IListSubItem_FWD_DEFINED__
typedef interface IListSubItem IListSubItem;
#endif 	/* __IListSubItem_FWD_DEFINED__ */


#ifndef __IImageList_FWD_DEFINED__
#define __IImageList_FWD_DEFINED__
typedef interface IImageList IImageList;
#endif 	/* __IImageList_FWD_DEFINED__ */


#ifndef __ImageListEvents_FWD_DEFINED__
#define __ImageListEvents_FWD_DEFINED__
typedef interface ImageListEvents ImageListEvents;
#endif 	/* __ImageListEvents_FWD_DEFINED__ */


#ifndef __IImages_FWD_DEFINED__
#define __IImages_FWD_DEFINED__
typedef interface IImages IImages;
#endif 	/* __IImages_FWD_DEFINED__ */


#ifndef __IImage_FWD_DEFINED__
#define __IImage_FWD_DEFINED__
typedef interface IImage IImage;
#endif 	/* __IImage_FWD_DEFINED__ */


#ifndef __ISlider_FWD_DEFINED__
#define __ISlider_FWD_DEFINED__
typedef interface ISlider ISlider;
#endif 	/* __ISlider_FWD_DEFINED__ */


#ifndef __ISliderEvents_FWD_DEFINED__
#define __ISliderEvents_FWD_DEFINED__
typedef interface ISliderEvents ISliderEvents;
#endif 	/* __ISliderEvents_FWD_DEFINED__ */


#ifndef __IControls_FWD_DEFINED__
#define __IControls_FWD_DEFINED__
typedef interface IControls IControls;
#endif 	/* __IControls_FWD_DEFINED__ */


#ifndef __IComboItem_FWD_DEFINED__
#define __IComboItem_FWD_DEFINED__
typedef interface IComboItem IComboItem;
#endif 	/* __IComboItem_FWD_DEFINED__ */


#ifndef __IComboItems_FWD_DEFINED__
#define __IComboItems_FWD_DEFINED__
typedef interface IComboItems IComboItems;
#endif 	/* __IComboItems_FWD_DEFINED__ */


#ifndef __IImageCombo_FWD_DEFINED__
#define __IImageCombo_FWD_DEFINED__
typedef interface IImageCombo IImageCombo;
#endif 	/* __IImageCombo_FWD_DEFINED__ */


#ifndef __DImageComboEvents_FWD_DEFINED__
#define __DImageComboEvents_FWD_DEFINED__
typedef interface DImageComboEvents DImageComboEvents;
#endif 	/* __DImageComboEvents_FWD_DEFINED__ */


#ifndef __DataObject_FWD_DEFINED__
#define __DataObject_FWD_DEFINED__

#ifdef __cplusplus
typedef class DataObject DataObject;
#else
typedef struct DataObject DataObject;
#endif /* __cplusplus */

#endif 	/* __DataObject_FWD_DEFINED__ */


#ifndef __DataObjectFiles_FWD_DEFINED__
#define __DataObjectFiles_FWD_DEFINED__

#ifdef __cplusplus
typedef class DataObjectFiles DataObjectFiles;
#else
typedef struct DataObjectFiles DataObjectFiles;
#endif /* __cplusplus */

#endif 	/* __DataObjectFiles_FWD_DEFINED__ */


#ifndef __TabStrip_FWD_DEFINED__
#define __TabStrip_FWD_DEFINED__

#ifdef __cplusplus
typedef class TabStrip TabStrip;
#else
typedef struct TabStrip TabStrip;
#endif /* __cplusplus */

#endif 	/* __TabStrip_FWD_DEFINED__ */


#ifndef __Tabs_FWD_DEFINED__
#define __Tabs_FWD_DEFINED__

#ifdef __cplusplus
typedef class Tabs Tabs;
#else
typedef struct Tabs Tabs;
#endif /* __cplusplus */

#endif 	/* __Tabs_FWD_DEFINED__ */


#ifndef __Tab_FWD_DEFINED__
#define __Tab_FWD_DEFINED__

#ifdef __cplusplus
typedef class Tab Tab;
#else
typedef struct Tab Tab;
#endif /* __cplusplus */

#endif 	/* __Tab_FWD_DEFINED__ */


#ifndef __Toolbar_FWD_DEFINED__
#define __Toolbar_FWD_DEFINED__

#ifdef __cplusplus
typedef class Toolbar Toolbar;
#else
typedef struct Toolbar Toolbar;
#endif /* __cplusplus */

#endif 	/* __Toolbar_FWD_DEFINED__ */


#ifndef __Buttons_FWD_DEFINED__
#define __Buttons_FWD_DEFINED__

#ifdef __cplusplus
typedef class Buttons Buttons;
#else
typedef struct Buttons Buttons;
#endif /* __cplusplus */

#endif 	/* __Buttons_FWD_DEFINED__ */


#ifndef __ButtonMenus_FWD_DEFINED__
#define __ButtonMenus_FWD_DEFINED__

#ifdef __cplusplus
typedef class ButtonMenus ButtonMenus;
#else
typedef struct ButtonMenus ButtonMenus;
#endif /* __cplusplus */

#endif 	/* __ButtonMenus_FWD_DEFINED__ */


#ifndef __StatusBar_FWD_DEFINED__
#define __StatusBar_FWD_DEFINED__

#ifdef __cplusplus
typedef class StatusBar StatusBar;
#else
typedef struct StatusBar StatusBar;
#endif /* __cplusplus */

#endif 	/* __StatusBar_FWD_DEFINED__ */


#ifndef __Panels_FWD_DEFINED__
#define __Panels_FWD_DEFINED__

#ifdef __cplusplus
typedef class Panels Panels;
#else
typedef struct Panels Panels;
#endif /* __cplusplus */

#endif 	/* __Panels_FWD_DEFINED__ */


#ifndef __ProgressBar_FWD_DEFINED__
#define __ProgressBar_FWD_DEFINED__

#ifdef __cplusplus
typedef class ProgressBar ProgressBar;
#else
typedef struct ProgressBar ProgressBar;
#endif /* __cplusplus */

#endif 	/* __ProgressBar_FWD_DEFINED__ */


#ifndef __TreeView_FWD_DEFINED__
#define __TreeView_FWD_DEFINED__

#ifdef __cplusplus
typedef class TreeView TreeView;
#else
typedef struct TreeView TreeView;
#endif /* __cplusplus */

#endif 	/* __TreeView_FWD_DEFINED__ */


#ifndef __Nodes_FWD_DEFINED__
#define __Nodes_FWD_DEFINED__

#ifdef __cplusplus
typedef class Nodes Nodes;
#else
typedef struct Nodes Nodes;
#endif /* __cplusplus */

#endif 	/* __Nodes_FWD_DEFINED__ */


#ifndef __ListView_FWD_DEFINED__
#define __ListView_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListView ListView;
#else
typedef struct ListView ListView;
#endif /* __cplusplus */

#endif 	/* __ListView_FWD_DEFINED__ */


#ifndef __ListItems_FWD_DEFINED__
#define __ListItems_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListItems ListItems;
#else
typedef struct ListItems ListItems;
#endif /* __cplusplus */

#endif 	/* __ListItems_FWD_DEFINED__ */


#ifndef __ColumnHeaders_FWD_DEFINED__
#define __ColumnHeaders_FWD_DEFINED__

#ifdef __cplusplus
typedef class ColumnHeaders ColumnHeaders;
#else
typedef struct ColumnHeaders ColumnHeaders;
#endif /* __cplusplus */

#endif 	/* __ColumnHeaders_FWD_DEFINED__ */


#ifndef __ListSubItems_FWD_DEFINED__
#define __ListSubItems_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListSubItems ListSubItems;
#else
typedef struct ListSubItems ListSubItems;
#endif /* __cplusplus */

#endif 	/* __ListSubItems_FWD_DEFINED__ */


#ifndef __ListSubItem_FWD_DEFINED__
#define __ListSubItem_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListSubItem ListSubItem;
#else
typedef struct ListSubItem ListSubItem;
#endif /* __cplusplus */

#endif 	/* __ListSubItem_FWD_DEFINED__ */


#ifndef __ImageList_FWD_DEFINED__
#define __ImageList_FWD_DEFINED__

#ifdef __cplusplus
typedef class ImageList ImageList;
#else
typedef struct ImageList ImageList;
#endif /* __cplusplus */

#endif 	/* __ImageList_FWD_DEFINED__ */


#ifndef __ListImages_FWD_DEFINED__
#define __ListImages_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListImages ListImages;
#else
typedef struct ListImages ListImages;
#endif /* __cplusplus */

#endif 	/* __ListImages_FWD_DEFINED__ */


#ifndef __ListImage_FWD_DEFINED__
#define __ListImage_FWD_DEFINED__

#ifdef __cplusplus
typedef class ListImage ListImage;
#else
typedef struct ListImage ListImage;
#endif /* __cplusplus */

#endif 	/* __ListImage_FWD_DEFINED__ */


#ifndef __Slider_FWD_DEFINED__
#define __Slider_FWD_DEFINED__

#ifdef __cplusplus
typedef class Slider Slider;
#else
typedef struct Slider Slider;
#endif /* __cplusplus */

#endif 	/* __Slider_FWD_DEFINED__ */


#ifndef __Controls_FWD_DEFINED__
#define __Controls_FWD_DEFINED__

#ifdef __cplusplus
typedef class Controls Controls;
#else
typedef struct Controls Controls;
#endif /* __cplusplus */

#endif 	/* __Controls_FWD_DEFINED__ */


#ifndef __ComboItem_FWD_DEFINED__
#define __ComboItem_FWD_DEFINED__

#ifdef __cplusplus
typedef class ComboItem ComboItem;
#else
typedef struct ComboItem ComboItem;
#endif /* __cplusplus */

#endif 	/* __ComboItem_FWD_DEFINED__ */


#ifndef __ComboItems_FWD_DEFINED__
#define __ComboItems_FWD_DEFINED__

#ifdef __cplusplus
typedef class ComboItems ComboItems;
#else
typedef struct ComboItems ComboItems;
#endif /* __cplusplus */

#endif 	/* __ComboItems_FWD_DEFINED__ */


#ifndef __ImageCombo_FWD_DEFINED__
#define __ImageCombo_FWD_DEFINED__

#ifdef __cplusplus
typedef class ImageCombo ImageCombo;
#else
typedef struct ImageCombo ImageCombo;
#endif /* __cplusplus */

#endif 	/* __ImageCombo_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 

// Conflict with public annotations
#pragma warning(suppress:26022)
void * __RPC_USER MIDL_user_allocate(size_t);
// Conflict with public annotations
#pragma warning(suppress:26023)
#pragma warning(suppress: 4985)		// Windows annotates with declspecs
void __RPC_USER MIDL_user_free( _Inout_ void * ); 


#ifndef __MSComctlLib_LIBRARY_DEFINED__
#define __MSComctlLib_LIBRARY_DEFINED__

/* library MSComctlLib */
/* [helpcontext][helpfile][helpstring][version][uuid] */ 










































typedef float single;

typedef IButton Button;

typedef IButtonMenu ButtonMenu;

typedef IPanel Panel;

typedef INode Node;

typedef IColumnHeader ColumnHeader;

typedef IListItem ListItem;

typedef /* [public][public][public][public][public][public][public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C0-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0001
    {	ccNone	= 0,
	ccFixedSingle	= 1
    } 	BorderStyleConstants;

typedef /* [public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C1-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0002
    {	ccDefault	= 0,
	ccArrow	= 1,
	ccCross	= 2,
	ccIBeam	= 3,
	ccIcon	= 4,
	ccSize	= 5,
	ccSizeNESW	= 6,
	ccSizeNS	= 7,
	ccSizeNWSE	= 8,
	ccSizeEW	= 9,
	ccUpArrow	= 10,
	ccHourglass	= 11,
	ccNoDrop	= 12,
	ccArrowHourglass	= 13,
	ccArrowQuestion	= 14,
	ccSizeAll	= 15,
	ccCustom	= 99
    } 	MousePointerConstants;

typedef /* [public][public][public][public][public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C2-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0003
    {	ccFlat	= 0,
	cc3D	= 1
    } 	AppearanceConstants;

typedef /* [public] */ 
enum __MIDL___MIDL_itf_mscomctl_0116_0004
    {	vbFlat	= 0,
	vb3D	= 1
    } 	VB4AppearanceConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C3-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0005
    {	ccScrollingStandard	= 0,
	ccScrollingSmooth	= 1
    } 	ScrollingConstants;

typedef /* [public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C4-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0006
    {	ccOrientationHorizontal	= 0,
	ccOrientationVertical	= 1
    } 	OrientationConstants;

typedef /* [public][public][public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("D8898460-742F-11CF-8AEA-00AA00C00905") 
enum __MIDL___MIDL_itf_mscomctl_0116_0007
    {	ccOLEDragManual	= 0,
	ccOLEDragAutomatic	= 1
    } 	OLEDragConstants;

typedef /* [public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("D8898461-742F-11CF-8AEA-00AA00C00905") 
enum __MIDL___MIDL_itf_mscomctl_0116_0008
    {	ccOLEDropNone	= 0,
	ccOLEDropManual	= 1
    } 	OLEDropConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("D8898464-742F-11CF-8AEA-00AA00C00905") 
enum __MIDL___MIDL_itf_mscomctl_0116_0009
    {	ccEnter	= 0,
	ccLeave	= 1,
	ccOver	= 2
    } 	DragOverConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("D8898462-742F-11CF-8AEA-00AA00C00905") 
enum __MIDL___MIDL_itf_mscomctl_0116_0010
    {	ccCFText	= 1,
	ccCFBitmap	= 2,
	ccCFMetafile	= 3,
	ccCFDIB	= 8,
	ccCFPalette	= 9,
	ccCFEMetafile	= 14,
	ccCFFiles	= 15,
	ccCFRTF	= 0xffffbf01
    } 	ClipBoardConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("D8898463-742F-11CF-8AEA-00AA00C00905") 
enum __MIDL___MIDL_itf_mscomctl_0116_0011
    {	ccOLEDropEffectNone	= 0,
	ccOLEDropEffectCopy	= 1,
	ccOLEDropEffectMove	= 2,
	ccOLEDropEffectScroll	= 0x80000000
    } 	OLEDropEffectConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("76B523C5-8579-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0012
    {	ccInvalidProcedureCall	= 5,
	ccOutOfMemory	= 7,
	ccTypeMismatch	= 13,
	ccObjectVariableNotSet	= 91,
	ccInvalidPropertyValue	= 380,
	ccSetNotSupportedAtRuntime	= 382,
	ccSetNotSupported	= 383,
	ccSetNotPermitted	= 387,
	ccGetNotSupported	= 394,
	ccInvalidPicture	= 481,
	ccInvalidObjectUse	= 425,
	ccWrongClipboardFormat	= 461,
	ccDataObjectLocked	= 672,
	ccExpectedAnArgument	= 673,
	ccRecursiveOleDrag	= 674,
	ccFormatNotByteArray	= 675,
	ccDataNotSetForFormat	= 676,
	ccIndexOutOfBounds	= 35600,
	ccElemNotFound	= 35601,
	ccNonUniqueKey	= 35602,
	ccInvalidKey	= 35603,
	ccElemNotPartOfCollection	= 35605,
	ccCollectionChangedDuringEnum	= 35606,
	ccWouldIntroduceCycle	= 35614,
	ccMissingRequiredArg	= 35607,
	ccBadObjectReference	= 35610,
	ccCircularReference	= 35700,
	ccCol1MustBeLeftAligned	= 35604,
	ccReadOnlyIfHasImages	= 35611,
	ccImageListMustBeInitialized	= 35613,
	ccNotSameSize	= 35615,
	ccImageListLocked	= 35617,
	ccMaxPanelsExceeded	= 35616,
	ccMaxButtonsExceeded	= 35619,
	ccInvalidSafeModeProcCall	= 680
    } 	ErrorConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("1EFB6590-857C-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0013
    {	tabJustified	= 0,
	tabNonJustified	= 1,
	tabFixed	= 2
    } 	TabWidthStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("1EFB6591-857C-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0014
    {	tabTabs	= 0,
	tabButtons	= 1,
	tabFlatButtons	= 2
    } 	TabStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("1EFB6592-857C-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0015
    {	tabPlacementTop	= 0,
	tabPlacementBottom	= 1,
	tabPlacementLeft	= 2,
	tabPlacementRight	= 3
    } 	PlacementConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("1EFB6593-857C-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0116_0016
    {	tabTabStandard	= 0,
	tabTabOpposite	= 1
    } 	TabSelStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("66833FE0-8583-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0120_0001
    {	tbrDefault	= 0,
	tbrCheck	= 1,
	tbrButtonGroup	= 2,
	tbrSeparator	= 3,
	tbrPlaceholder	= 4,
	tbrDropdown	= 5
    } 	ButtonStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("66833FE1-8583-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0120_0002
    {	tbrUnpressed	= 0,
	tbrPressed	= 1
    } 	ValueConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("66833FE2-8583-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0120_0003
    {	tbrStandard	= 0,
	tbrFlat	= 1
    } 	ToolbarStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("66833FE3-8583-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0120_0004
    {	tbrTextAlignBottom	= 0,
	tbrTextAlignRight	= 1
    } 	ToolbarTextAlignConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("8E3867A0-8586-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0126_0001
    {	sbrNormal	= 0,
	sbrSimple	= 1
    } 	SbarStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("8E3867A6-8586-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0129_0001
    {	sbrLeft	= 0,
	sbrCenter	= 1,
	sbrRight	= 2
    } 	PanelAlignmentConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("8E3867A7-8586-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0129_0002
    {	sbrNoAutoSize	= 0,
	sbrSpring	= 1,
	sbrContents	= 2
    } 	PanelAutoSizeConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("8E3867A8-8586-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0129_0003
    {	sbrNoBevel	= 0,
	sbrInset	= 1,
	sbrRaised	= 2
    } 	PanelBevelConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("8E3867A9-8586-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0129_0004
    {	sbrText	= 0,
	sbrCaps	= 1,
	sbrNum	= 2,
	sbrIns	= 3,
	sbrScrl	= 4,
	sbrTime	= 5,
	sbrDate	= 6,
	sbrKana	= 7
    } 	PanelStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("C74190B0-8589-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0132_0001
    {	tvwAutomatic	= 0,
	tvwManual	= 1
    } 	LabelEditConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("C74190B1-8589-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0132_0002
    {	tvwTreeLines	= 0,
	tvwRootLines	= 1
    } 	TreeLineStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("C74190B2-8589-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0132_0003
    {	tvwTextOnly	= 0,
	tvwPictureText	= 1,
	tvwPlusMinusText	= 2,
	tvwPlusPictureText	= 3,
	tvwTreelinesText	= 4,
	tvwTreelinesPictureText	= 5,
	tvwTreelinesPlusMinusText	= 6,
	tvwTreelinesPlusMinusPictureText	= 7
    } 	TreeStyleConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("C74190B3-8589-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0132_0004
    {	tvwFirst	= 0,
	tvwLast	= 1,
	tvwNext	= 2,
	tvwPrevious	= 3,
	tvwChild	= 4
    } 	TreeRelationshipConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F040-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0001
    {	lvwTransparent	= 0,
	lvwOpaque	= 1
    } 	ListTextBackgroundConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F041-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0002
    {	lvwNone	= 0,
	lvwAutoLeft	= 1,
	lvwAutoTop	= 2
    } 	ListArrangeConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F042-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0003
    {	lvwTopLeft	= 0,
	lvwTopRight	= 1,
	lvwBottomLeft	= 2,
	lvwBottomRight	= 3,
	lvwCenter	= 4,
	lvwTile	= 5
    } 	ListPictureAlignmentConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F043-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0004
    {	lvwAutomatic	= 0,
	lvwManual	= 1
    } 	ListLabelEditConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F044-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0005
    {	lvwAscending	= 0,
	lvwDescending	= 1
    } 	ListSortOrderConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F045-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0006
    {	lvwIcon	= 0,
	lvwSmallIcon	= 1,
	lvwList	= 2,
	lvwReport	= 3
    } 	ListViewConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F046-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0007
    {	lvwColumnLeft	= 0,
	lvwColumnRight	= 1,
	lvwColumnCenter	= 2
    } 	ListColumnAlignmentConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F047-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0008
    {	lvwText	= 0,
	lvwSubItem	= 1,
	lvwTag	= 2
    } 	ListFindItemWhereConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("BDD1F048-858B-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0136_0009
    {	lvwWhole	= 0,
	lvwPartial	= 1
    } 	ListFindItemHowConstants;

typedef /* [public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("2C247F20-8591-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0144_0001
    {	imlNormal	= 0,
	imlTransparent	= 1,
	imlSelected	= 2,
	imlFocus	= 3
    } 	ImageDrawConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("F08DF950-8592-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0148_0001
    {	sldBottomRight	= 0,
	sldTopLeft	= 1,
	sldBoth	= 2,
	sldNoTicks	= 3
    } 	TickStyleConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("F08DF951-8592-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0148_0002
    {	sldAboveLeft	= 0,
	sldBelowRight	= 1
    } 	TextPositionConstants;

typedef /* [public][public][public][helpcontext][helpstring][uuid] */  DECLSPEC_UUID("DD9DA667-8594-11D1-B16A-00C0F0283628") 
enum __MIDL___MIDL_itf_mscomctl_0153_0001
    {	ImgCboDropdownCombo	= 0,
	ImgCboSimpleCombo	= 1,
	ImgCboDropdownList	= 2
    } 	ImageComboStyleConstants;


EXTERN_C const IID LIBID_MSComctlLib;

#ifndef __IVBDataObject_INTERFACE_DEFINED__
#define __IVBDataObject_INTERFACE_DEFINED__

/* interface IVBDataObject */
/* [object][oleautomation][nonextensible][dual][hidden][uuid] */ 


EXTERN_C const IID IID_IVBDataObject;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2334D2B1-713E-11CF-8AE5-00AA00C00905")
    IVBDataObject : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE GetData( 
            /* [in] */ short sFormat,
            /* [retval][out] */ VARIANT *pvData) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE GetFormat( 
            /* [in] */ short sFormat,
            /* [retval][out] */ VARIANT_BOOL *pbFormatSupported) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE SetData( 
            /* [optional][in] */ VARIANT vValue,
            /* [optional][in] */ VARIANT vFormat) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Files( 
            /* [retval][out] */ IVBDataObjectFiles **pFiles) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IVBDataObjectVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IVBDataObject * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IVBDataObject * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IVBDataObject * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IVBDataObject * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IVBDataObject * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IVBDataObject * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IVBDataObject * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IVBDataObject * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetData )( 
            IVBDataObject * This,
            /* [in] */ short sFormat,
            /* [retval][out] */ VARIANT *pvData);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetFormat )( 
            IVBDataObject * This,
            /* [in] */ short sFormat,
            /* [retval][out] */ VARIANT_BOOL *pbFormatSupported);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SetData )( 
            IVBDataObject * This,
            /* [optional][in] */ VARIANT vValue,
            /* [optional][in] */ VARIANT vFormat);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Files )( 
            IVBDataObject * This,
            /* [retval][out] */ IVBDataObjectFiles **pFiles);
        
        END_INTERFACE
    } IVBDataObjectVtbl;

    interface IVBDataObject
    {
        CONST_VTBL struct IVBDataObjectVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVBDataObject_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IVBDataObject_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IVBDataObject_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IVBDataObject_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IVBDataObject_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IVBDataObject_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IVBDataObject_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IVBDataObject_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IVBDataObject_GetData(This,sFormat,pvData)	\
    (This)->lpVtbl -> GetData(This,sFormat,pvData)

#define IVBDataObject_GetFormat(This,sFormat,pbFormatSupported)	\
    (This)->lpVtbl -> GetFormat(This,sFormat,pbFormatSupported)

#define IVBDataObject_SetData(This,vValue,vFormat)	\
    (This)->lpVtbl -> SetData(This,vValue,vFormat)

#define IVBDataObject_get_Files(This,pFiles)	\
    (This)->lpVtbl -> get_Files(This,pFiles)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObject_Clear_Proxy( 
    IVBDataObject * This);


void __RPC_STUB IVBDataObject_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObject_GetData_Proxy( 
    IVBDataObject * This,
    /* [in] */ short sFormat,
    /* [retval][out] */ VARIANT *pvData);


void __RPC_STUB IVBDataObject_GetData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObject_GetFormat_Proxy( 
    IVBDataObject * This,
    /* [in] */ short sFormat,
    /* [retval][out] */ VARIANT_BOOL *pbFormatSupported);


void __RPC_STUB IVBDataObject_GetFormat_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObject_SetData_Proxy( 
    IVBDataObject * This,
    /* [optional][in] */ VARIANT vValue,
    /* [optional][in] */ VARIANT vFormat);


void __RPC_STUB IVBDataObject_SetData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IVBDataObject_get_Files_Proxy( 
    IVBDataObject * This,
    /* [retval][out] */ IVBDataObjectFiles **pFiles);


void __RPC_STUB IVBDataObject_get_Files_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IVBDataObject_INTERFACE_DEFINED__ */


#ifndef __IVBDataObjectFiles_INTERFACE_DEFINED__
#define __IVBDataObjectFiles_INTERFACE_DEFINED__

/* interface IVBDataObjectFiles */
/* [object][oleautomation][nonextensible][dual][hidden][uuid] */ 


EXTERN_C const IID IID_IVBDataObjectFiles;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2334D2B3-713E-11CF-8AE5-00AA00C00905")
    IVBDataObjectFiles : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ long lIndex,
            /* [retval][out] */ BSTR *bstrItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [in] */ BSTR bstrFilename,
            /* [optional][in] */ VARIANT vIndex) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT vIndex) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IUnknown **ppUnk) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IVBDataObjectFilesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IVBDataObjectFiles * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IVBDataObjectFiles * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IVBDataObjectFiles * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IVBDataObjectFiles * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IVBDataObjectFiles * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IVBDataObjectFiles * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IVBDataObjectFiles * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IVBDataObjectFiles * This,
            /* [in] */ long lIndex,
            /* [retval][out] */ BSTR *bstrItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IVBDataObjectFiles * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IVBDataObjectFiles * This,
            /* [in] */ BSTR bstrFilename,
            /* [optional][in] */ VARIANT vIndex);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IVBDataObjectFiles * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IVBDataObjectFiles * This,
            /* [in] */ VARIANT vIndex);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IVBDataObjectFiles * This,
            /* [retval][out] */ IUnknown **ppUnk);
        
        END_INTERFACE
    } IVBDataObjectFilesVtbl;

    interface IVBDataObjectFiles
    {
        CONST_VTBL struct IVBDataObjectFilesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVBDataObjectFiles_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IVBDataObjectFiles_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IVBDataObjectFiles_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IVBDataObjectFiles_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IVBDataObjectFiles_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IVBDataObjectFiles_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IVBDataObjectFiles_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IVBDataObjectFiles_get_Item(This,lIndex,bstrItem)	\
    (This)->lpVtbl -> get_Item(This,lIndex,bstrItem)

#define IVBDataObjectFiles_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IVBDataObjectFiles_Add(This,bstrFilename,vIndex)	\
    (This)->lpVtbl -> Add(This,bstrFilename,vIndex)

#define IVBDataObjectFiles_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IVBDataObjectFiles_Remove(This,vIndex)	\
    (This)->lpVtbl -> Remove(This,vIndex)

#define IVBDataObjectFiles__NewEnum(This,ppUnk)	\
    (This)->lpVtbl -> _NewEnum(This,ppUnk)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles_get_Item_Proxy( 
    IVBDataObjectFiles * This,
    /* [in] */ long lIndex,
    /* [retval][out] */ BSTR *bstrItem);


void __RPC_STUB IVBDataObjectFiles_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles_get_Count_Proxy( 
    IVBDataObjectFiles * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IVBDataObjectFiles_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles_Add_Proxy( 
    IVBDataObjectFiles * This,
    /* [in] */ BSTR bstrFilename,
    /* [optional][in] */ VARIANT vIndex);


void __RPC_STUB IVBDataObjectFiles_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles_Clear_Proxy( 
    IVBDataObjectFiles * This);


void __RPC_STUB IVBDataObjectFiles_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles_Remove_Proxy( 
    IVBDataObjectFiles * This,
    /* [in] */ VARIANT vIndex);


void __RPC_STUB IVBDataObjectFiles_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IVBDataObjectFiles__NewEnum_Proxy( 
    IVBDataObjectFiles * This,
    /* [retval][out] */ IUnknown **ppUnk);


void __RPC_STUB IVBDataObjectFiles__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IVBDataObjectFiles_INTERFACE_DEFINED__ */


#ifndef __ITabStrip_INTERFACE_DEFINED__
#define __ITabStrip_INTERFACE_DEFINED__

/* interface ITabStrip */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_ITabStrip;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1EFB6594-857C-11D1-B16A-00C0F0283628")
    ITabStrip : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tabs( 
            /* [retval][out] */ ITabs **ppTabs) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tabs( 
            /* [in] */ ITabs *ppTabs) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Font( 
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp) = 0;
        
        virtual /* [helpcontext][helpstring][bindable][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MultiRow( 
            /* [retval][out] */ VARIANT_BOOL *pbMultiRow) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MultiRow( 
            /* [in] */ VARIANT_BOOL pbMultiRow) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ TabStyleConstants *psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ TabStyleConstants psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TabFixedWidth( 
            /* [retval][out] */ short *psTabFixedWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TabFixedWidth( 
            /* [in] */ short psTabFixedWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TabWidthStyle( 
            /* [retval][out] */ TabWidthStyleConstants *psTabWidthStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TabWidthStyle( 
            /* [in] */ TabWidthStyleConstants psTabWidthStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ClientTop( 
            /* [retval][out] */ single *pfClientTop) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ClientTop( 
            /* [in] */ single pfClientTop) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ClientLeft( 
            /* [retval][out] */ single *pfClientLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ClientLeft( 
            /* [in] */ single pfClientLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ClientHeight( 
            /* [retval][out] */ single *pfClientHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ClientHeight( 
            /* [in] */ single pfClientHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ClientWidth( 
            /* [retval][out] */ single *pfClientWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ClientWidth( 
            /* [in] */ single pfClientWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageList( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TabFixedHeight( 
            /* [retval][out] */ short *psTabFixedHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TabFixedHeight( 
            /* [in] */ short psTabFixedHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ShowTips( 
            /* [retval][out] */ VARIANT_BOOL *pbShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ShowTips( 
            /* [in] */ VARIANT_BOOL pbShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectedItem( 
            /* [retval][out] */ ITab **ppSelectedItem) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_SelectedItem( 
            /* [in] */ ITab *ppSelectedItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectedItem( 
            /* [in] */ VARIANT *ppSelectedItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_HotTracking( 
            /* [retval][out] */ VARIANT_BOOL *pbHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_HotTracking( 
            /* [in] */ VARIANT_BOOL pbHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_MultiSelect( 
            /* [retval][out] */ VARIANT_BOOL *pbMultiSelect) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_MultiSelect( 
            /* [in] */ VARIANT_BOOL pbMultiSelect) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Placement( 
            /* [retval][out] */ PlacementConstants *penumPlacement) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Placement( 
            /* [in] */ PlacementConstants penumPlacement) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Separators( 
            /* [retval][out] */ VARIANT_BOOL *pbSeparators) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_Separators( 
            /* [in] */ VARIANT_BOOL pbSeparators) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TabMinWidth( 
            /* [retval][out] */ single *pflTabMinWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TabMinWidth( 
            /* [in] */ single pflTabMinWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TabStyle( 
            /* [retval][out] */ TabSelStyleConstants *penumTabStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TabStyle( 
            /* [in] */ TabSelStyleConstants penumTabStyle) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE DeselectAll( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITabStripVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITabStrip * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITabStrip * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITabStrip * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITabStrip * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITabStrip * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITabStrip * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITabStrip * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tabs )( 
            ITabStrip * This,
            /* [retval][out] */ ITabs **ppTabs);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tabs )( 
            ITabStrip * This,
            /* [in] */ ITabs *ppTabs);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Font )( 
            ITabStrip * This,
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp);
        
        /* [helpcontext][helpstring][bindable][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Font )( 
            ITabStrip * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            ITabStrip * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            ITabStrip * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            ITabStrip * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            ITabStrip * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            ITabStrip * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MultiRow )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbMultiRow);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MultiRow )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbMultiRow);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            ITabStrip * This,
            /* [retval][out] */ TabStyleConstants *psStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            ITabStrip * This,
            /* [in] */ TabStyleConstants psStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TabFixedWidth )( 
            ITabStrip * This,
            /* [retval][out] */ short *psTabFixedWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TabFixedWidth )( 
            ITabStrip * This,
            /* [in] */ short psTabFixedWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TabWidthStyle )( 
            ITabStrip * This,
            /* [retval][out] */ TabWidthStyleConstants *psTabWidthStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TabWidthStyle )( 
            ITabStrip * This,
            /* [in] */ TabWidthStyleConstants psTabWidthStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ClientTop )( 
            ITabStrip * This,
            /* [retval][out] */ single *pfClientTop);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ClientTop )( 
            ITabStrip * This,
            /* [in] */ single pfClientTop);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ClientLeft )( 
            ITabStrip * This,
            /* [retval][out] */ single *pfClientLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ClientLeft )( 
            ITabStrip * This,
            /* [in] */ single pfClientLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ClientHeight )( 
            ITabStrip * This,
            /* [retval][out] */ single *pfClientHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ClientHeight )( 
            ITabStrip * This,
            /* [in] */ single pfClientHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ClientWidth )( 
            ITabStrip * This,
            /* [retval][out] */ single *pfClientWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ClientWidth )( 
            ITabStrip * This,
            /* [in] */ single pfClientWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            ITabStrip * This,
            /* [retval][out] */ MousePointerConstants *psMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            ITabStrip * This,
            /* [in] */ MousePointerConstants psMousePointer);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageList )( 
            ITabStrip * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageList )( 
            ITabStrip * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ImageList )( 
            ITabStrip * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TabFixedHeight )( 
            ITabStrip * This,
            /* [retval][out] */ short *psTabFixedHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TabFixedHeight )( 
            ITabStrip * This,
            /* [in] */ short psTabFixedHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ShowTips )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbShowTips);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ShowTips )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbShowTips);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectedItem )( 
            ITabStrip * This,
            /* [retval][out] */ ITab **ppSelectedItem);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_SelectedItem )( 
            ITabStrip * This,
            /* [in] */ ITab *ppSelectedItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectedItem )( 
            ITabStrip * This,
            /* [in] */ VARIANT *ppSelectedItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            ITabStrip * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            ITabStrip * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            ITabStrip * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            ITabStrip * This);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            ITabStrip * This);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HotTracking )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbHotTracking);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HotTracking )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbHotTracking);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MultiSelect )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbMultiSelect);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MultiSelect )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbMultiSelect);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Placement )( 
            ITabStrip * This,
            /* [retval][out] */ PlacementConstants *penumPlacement);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Placement )( 
            ITabStrip * This,
            /* [in] */ PlacementConstants penumPlacement);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Separators )( 
            ITabStrip * This,
            /* [retval][out] */ VARIANT_BOOL *pbSeparators);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Separators )( 
            ITabStrip * This,
            /* [in] */ VARIANT_BOOL pbSeparators);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TabMinWidth )( 
            ITabStrip * This,
            /* [retval][out] */ single *pflTabMinWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TabMinWidth )( 
            ITabStrip * This,
            /* [in] */ single pflTabMinWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TabStyle )( 
            ITabStrip * This,
            /* [retval][out] */ TabSelStyleConstants *penumTabStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TabStyle )( 
            ITabStrip * This,
            /* [in] */ TabSelStyleConstants penumTabStyle);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DeselectAll )( 
            ITabStrip * This);
        
        END_INTERFACE
    } ITabStripVtbl;

    interface ITabStrip
    {
        CONST_VTBL struct ITabStripVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITabStrip_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITabStrip_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITabStrip_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITabStrip_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITabStrip_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITabStrip_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITabStrip_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ITabStrip_get_Tabs(This,ppTabs)	\
    (This)->lpVtbl -> get_Tabs(This,ppTabs)

#define ITabStrip_putref_Tabs(This,ppTabs)	\
    (This)->lpVtbl -> putref_Tabs(This,ppTabs)

#define ITabStrip_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define ITabStrip_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define ITabStrip_get_Font(This,ppFontDisp)	\
    (This)->lpVtbl -> get_Font(This,ppFontDisp)

#define ITabStrip_putref_Font(This,ppFontDisp)	\
    (This)->lpVtbl -> putref_Font(This,ppFontDisp)

#define ITabStrip_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define ITabStrip_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define ITabStrip_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define ITabStrip_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define ITabStrip_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define ITabStrip_get_MultiRow(This,pbMultiRow)	\
    (This)->lpVtbl -> get_MultiRow(This,pbMultiRow)

#define ITabStrip_put_MultiRow(This,pbMultiRow)	\
    (This)->lpVtbl -> put_MultiRow(This,pbMultiRow)

#define ITabStrip_get_Style(This,psStyle)	\
    (This)->lpVtbl -> get_Style(This,psStyle)

#define ITabStrip_put_Style(This,psStyle)	\
    (This)->lpVtbl -> put_Style(This,psStyle)

#define ITabStrip_get_TabFixedWidth(This,psTabFixedWidth)	\
    (This)->lpVtbl -> get_TabFixedWidth(This,psTabFixedWidth)

#define ITabStrip_put_TabFixedWidth(This,psTabFixedWidth)	\
    (This)->lpVtbl -> put_TabFixedWidth(This,psTabFixedWidth)

#define ITabStrip_get_TabWidthStyle(This,psTabWidthStyle)	\
    (This)->lpVtbl -> get_TabWidthStyle(This,psTabWidthStyle)

#define ITabStrip_put_TabWidthStyle(This,psTabWidthStyle)	\
    (This)->lpVtbl -> put_TabWidthStyle(This,psTabWidthStyle)

#define ITabStrip_get_ClientTop(This,pfClientTop)	\
    (This)->lpVtbl -> get_ClientTop(This,pfClientTop)

#define ITabStrip_put_ClientTop(This,pfClientTop)	\
    (This)->lpVtbl -> put_ClientTop(This,pfClientTop)

#define ITabStrip_get_ClientLeft(This,pfClientLeft)	\
    (This)->lpVtbl -> get_ClientLeft(This,pfClientLeft)

#define ITabStrip_put_ClientLeft(This,pfClientLeft)	\
    (This)->lpVtbl -> put_ClientLeft(This,pfClientLeft)

#define ITabStrip_get_ClientHeight(This,pfClientHeight)	\
    (This)->lpVtbl -> get_ClientHeight(This,pfClientHeight)

#define ITabStrip_put_ClientHeight(This,pfClientHeight)	\
    (This)->lpVtbl -> put_ClientHeight(This,pfClientHeight)

#define ITabStrip_get_ClientWidth(This,pfClientWidth)	\
    (This)->lpVtbl -> get_ClientWidth(This,pfClientWidth)

#define ITabStrip_put_ClientWidth(This,pfClientWidth)	\
    (This)->lpVtbl -> put_ClientWidth(This,pfClientWidth)

#define ITabStrip_get_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,psMousePointer)

#define ITabStrip_put_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,psMousePointer)

#define ITabStrip_get_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> get_ImageList(This,ppImageList)

#define ITabStrip_put_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> put_ImageList(This,ppImageList)

#define ITabStrip_putref_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> putref_ImageList(This,ppImageList)

#define ITabStrip_get_TabFixedHeight(This,psTabFixedHeight)	\
    (This)->lpVtbl -> get_TabFixedHeight(This,psTabFixedHeight)

#define ITabStrip_put_TabFixedHeight(This,psTabFixedHeight)	\
    (This)->lpVtbl -> put_TabFixedHeight(This,psTabFixedHeight)

#define ITabStrip_get_ShowTips(This,pbShowTips)	\
    (This)->lpVtbl -> get_ShowTips(This,pbShowTips)

#define ITabStrip_put_ShowTips(This,pbShowTips)	\
    (This)->lpVtbl -> put_ShowTips(This,pbShowTips)

#define ITabStrip_get_SelectedItem(This,ppSelectedItem)	\
    (This)->lpVtbl -> get_SelectedItem(This,ppSelectedItem)

#define ITabStrip_putref_SelectedItem(This,ppSelectedItem)	\
    (This)->lpVtbl -> putref_SelectedItem(This,ppSelectedItem)

#define ITabStrip_put_SelectedItem(This,ppSelectedItem)	\
    (This)->lpVtbl -> put_SelectedItem(This,ppSelectedItem)

#define ITabStrip_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define ITabStrip_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define ITabStrip_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define ITabStrip_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define ITabStrip_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define ITabStrip_get_HotTracking(This,pbHotTracking)	\
    (This)->lpVtbl -> get_HotTracking(This,pbHotTracking)

#define ITabStrip_put_HotTracking(This,pbHotTracking)	\
    (This)->lpVtbl -> put_HotTracking(This,pbHotTracking)

#define ITabStrip_get_MultiSelect(This,pbMultiSelect)	\
    (This)->lpVtbl -> get_MultiSelect(This,pbMultiSelect)

#define ITabStrip_put_MultiSelect(This,pbMultiSelect)	\
    (This)->lpVtbl -> put_MultiSelect(This,pbMultiSelect)

#define ITabStrip_get_Placement(This,penumPlacement)	\
    (This)->lpVtbl -> get_Placement(This,penumPlacement)

#define ITabStrip_put_Placement(This,penumPlacement)	\
    (This)->lpVtbl -> put_Placement(This,penumPlacement)

#define ITabStrip_get_Separators(This,pbSeparators)	\
    (This)->lpVtbl -> get_Separators(This,pbSeparators)

#define ITabStrip_put_Separators(This,pbSeparators)	\
    (This)->lpVtbl -> put_Separators(This,pbSeparators)

#define ITabStrip_get_TabMinWidth(This,pflTabMinWidth)	\
    (This)->lpVtbl -> get_TabMinWidth(This,pflTabMinWidth)

#define ITabStrip_put_TabMinWidth(This,pflTabMinWidth)	\
    (This)->lpVtbl -> put_TabMinWidth(This,pflTabMinWidth)

#define ITabStrip_get_TabStyle(This,penumTabStyle)	\
    (This)->lpVtbl -> get_TabStyle(This,penumTabStyle)

#define ITabStrip_put_TabStyle(This,penumTabStyle)	\
    (This)->lpVtbl -> put_TabStyle(This,penumTabStyle)

#define ITabStrip_DeselectAll(This)	\
    (This)->lpVtbl -> DeselectAll(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Tabs_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ ITabs **ppTabs);


void __RPC_STUB ITabStrip_get_Tabs_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_putref_Tabs_Proxy( 
    ITabStrip * This,
    /* [in] */ ITabs *ppTabs);


void __RPC_STUB ITabStrip_putref_Tabs_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Enabled_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB ITabStrip_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_Enabled_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB ITabStrip_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Font_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp);


void __RPC_STUB ITabStrip_get_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][bindable][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_putref_Font_Proxy( 
    ITabStrip * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp);


void __RPC_STUB ITabStrip_putref_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_hWnd_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB ITabStrip_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_hWnd_Proxy( 
    ITabStrip * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB ITabStrip_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_MouseIcon_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB ITabStrip_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_MouseIcon_Proxy( 
    ITabStrip * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ITabStrip_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_putref_MouseIcon_Proxy( 
    ITabStrip * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ITabStrip_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_MultiRow_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbMultiRow);


void __RPC_STUB ITabStrip_get_MultiRow_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_MultiRow_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbMultiRow);


void __RPC_STUB ITabStrip_put_MultiRow_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Style_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ TabStyleConstants *psStyle);


void __RPC_STUB ITabStrip_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_Style_Proxy( 
    ITabStrip * This,
    /* [in] */ TabStyleConstants psStyle);


void __RPC_STUB ITabStrip_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_TabFixedWidth_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ short *psTabFixedWidth);


void __RPC_STUB ITabStrip_get_TabFixedWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_TabFixedWidth_Proxy( 
    ITabStrip * This,
    /* [in] */ short psTabFixedWidth);


void __RPC_STUB ITabStrip_put_TabFixedWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_TabWidthStyle_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ TabWidthStyleConstants *psTabWidthStyle);


void __RPC_STUB ITabStrip_get_TabWidthStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_TabWidthStyle_Proxy( 
    ITabStrip * This,
    /* [in] */ TabWidthStyleConstants psTabWidthStyle);


void __RPC_STUB ITabStrip_put_TabWidthStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ClientTop_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ single *pfClientTop);


void __RPC_STUB ITabStrip_get_ClientTop_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ClientTop_Proxy( 
    ITabStrip * This,
    /* [in] */ single pfClientTop);


void __RPC_STUB ITabStrip_put_ClientTop_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ClientLeft_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ single *pfClientLeft);


void __RPC_STUB ITabStrip_get_ClientLeft_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ClientLeft_Proxy( 
    ITabStrip * This,
    /* [in] */ single pfClientLeft);


void __RPC_STUB ITabStrip_put_ClientLeft_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ClientHeight_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ single *pfClientHeight);


void __RPC_STUB ITabStrip_get_ClientHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ClientHeight_Proxy( 
    ITabStrip * This,
    /* [in] */ single pfClientHeight);


void __RPC_STUB ITabStrip_put_ClientHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ClientWidth_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ single *pfClientWidth);


void __RPC_STUB ITabStrip_get_ClientWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ClientWidth_Proxy( 
    ITabStrip * This,
    /* [in] */ single pfClientWidth);


void __RPC_STUB ITabStrip_put_ClientWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_MousePointer_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ MousePointerConstants *psMousePointer);


void __RPC_STUB ITabStrip_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_MousePointer_Proxy( 
    ITabStrip * This,
    /* [in] */ MousePointerConstants psMousePointer);


void __RPC_STUB ITabStrip_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ImageList_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB ITabStrip_get_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ImageList_Proxy( 
    ITabStrip * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB ITabStrip_put_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_putref_ImageList_Proxy( 
    ITabStrip * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB ITabStrip_putref_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_TabFixedHeight_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ short *psTabFixedHeight);


void __RPC_STUB ITabStrip_get_TabFixedHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_TabFixedHeight_Proxy( 
    ITabStrip * This,
    /* [in] */ short psTabFixedHeight);


void __RPC_STUB ITabStrip_put_TabFixedHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_ShowTips_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbShowTips);


void __RPC_STUB ITabStrip_get_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_ShowTips_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbShowTips);


void __RPC_STUB ITabStrip_put_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_SelectedItem_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ ITab **ppSelectedItem);


void __RPC_STUB ITabStrip_get_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_putref_SelectedItem_Proxy( 
    ITabStrip * This,
    /* [in] */ ITab *ppSelectedItem);


void __RPC_STUB ITabStrip_putref_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_SelectedItem_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT *ppSelectedItem);


void __RPC_STUB ITabStrip_put_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_OLEDropMode_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB ITabStrip_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_OLEDropMode_Proxy( 
    ITabStrip * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB ITabStrip_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_Refresh_Proxy( 
    ITabStrip * This);


void __RPC_STUB ITabStrip_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_OLEDrag_Proxy( 
    ITabStrip * This);


void __RPC_STUB ITabStrip_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_AboutBox_Proxy( 
    ITabStrip * This);


void __RPC_STUB ITabStrip_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_HotTracking_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbHotTracking);


void __RPC_STUB ITabStrip_get_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_HotTracking_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbHotTracking);


void __RPC_STUB ITabStrip_put_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_MultiSelect_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbMultiSelect);


void __RPC_STUB ITabStrip_get_MultiSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_MultiSelect_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbMultiSelect);


void __RPC_STUB ITabStrip_put_MultiSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Placement_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ PlacementConstants *penumPlacement);


void __RPC_STUB ITabStrip_get_Placement_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_Placement_Proxy( 
    ITabStrip * This,
    /* [in] */ PlacementConstants penumPlacement);


void __RPC_STUB ITabStrip_put_Placement_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_Separators_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ VARIANT_BOOL *pbSeparators);


void __RPC_STUB ITabStrip_get_Separators_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_Separators_Proxy( 
    ITabStrip * This,
    /* [in] */ VARIANT_BOOL pbSeparators);


void __RPC_STUB ITabStrip_put_Separators_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_TabMinWidth_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ single *pflTabMinWidth);


void __RPC_STUB ITabStrip_get_TabMinWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_TabMinWidth_Proxy( 
    ITabStrip * This,
    /* [in] */ single pflTabMinWidth);


void __RPC_STUB ITabStrip_put_TabMinWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_get_TabStyle_Proxy( 
    ITabStrip * This,
    /* [retval][out] */ TabSelStyleConstants *penumTabStyle);


void __RPC_STUB ITabStrip_get_TabStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_put_TabStyle_Proxy( 
    ITabStrip * This,
    /* [in] */ TabSelStyleConstants penumTabStyle);


void __RPC_STUB ITabStrip_put_TabStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabStrip_DeselectAll_Proxy( 
    ITabStrip * This);


void __RPC_STUB ITabStrip_DeselectAll_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ITabStrip_INTERFACE_DEFINED__ */


#ifndef __ITabStripEvents_DISPINTERFACE_DEFINED__
#define __ITabStripEvents_DISPINTERFACE_DEFINED__

/* dispinterface ITabStripEvents */
/* [nonextensible][uuid] */ 


EXTERN_C const IID DIID_ITabStripEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("1EFB6595-857C-11D1-B16A-00C0F0283628")
    ITabStripEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ITabStripEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITabStripEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITabStripEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITabStripEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITabStripEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITabStripEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITabStripEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITabStripEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ITabStripEventsVtbl;

    interface ITabStripEvents
    {
        CONST_VTBL struct ITabStripEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITabStripEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITabStripEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITabStripEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITabStripEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITabStripEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITabStripEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITabStripEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ITabStripEvents_DISPINTERFACE_DEFINED__ */


#ifndef __ITabs_INTERFACE_DEFINED__
#define __ITabs_INTERFACE_DEFINED__

/* interface ITabs */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_ITabs;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1EFB6597-857C-11D1-B16A-00C0F0283628")
    ITabs : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *psCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short psCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *pvIndex,
            /* [retval][out] */ ITab **ppTab) = 0;
        
        virtual /* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ControlDefault( 
            /* [in] */ VARIANT *pvIndex,
            /* [in] */ ITab *ppTab) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *pvIndex,
            /* [retval][out] */ ITab **ppTab) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Item( 
            /* [in] */ VARIANT *pvIndex,
            /* [in] */ ITab *ppTab) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *pvIndex) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *pvIndex,
            /* [optional][in] */ VARIANT *pvKey,
            /* [optional][in] */ VARIANT *pvCaption,
            /* [optional][in] */ VARIANT *pvImage,
            /* [retval][out] */ ITab **ppTab) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITabsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITabs * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITabs * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITabs * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITabs * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITabs * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITabs * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITabs * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            ITabs * This,
            /* [retval][out] */ short *psCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            ITabs * This,
            /* [in] */ short psCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            ITabs * This,
            /* [in] */ VARIANT *pvIndex,
            /* [retval][out] */ ITab **ppTab);
        
        /* [hidden][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ControlDefault )( 
            ITabs * This,
            /* [in] */ VARIANT *pvIndex,
            /* [in] */ ITab *ppTab);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            ITabs * This,
            /* [in] */ VARIANT *pvIndex,
            /* [retval][out] */ ITab **ppTab);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Item )( 
            ITabs * This,
            /* [in] */ VARIANT *pvIndex,
            /* [in] */ ITab *ppTab);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            ITabs * This,
            /* [in] */ VARIANT *pvIndex);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            ITabs * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            ITabs * This,
            /* [optional][in] */ VARIANT *pvIndex,
            /* [optional][in] */ VARIANT *pvKey,
            /* [optional][in] */ VARIANT *pvCaption,
            /* [optional][in] */ VARIANT *pvImage,
            /* [retval][out] */ ITab **ppTab);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            ITabs * This,
            /* [retval][out] */ IDispatch **ppNewEnum);
        
        END_INTERFACE
    } ITabsVtbl;

    interface ITabs
    {
        CONST_VTBL struct ITabsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITabs_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITabs_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITabs_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITabs_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITabs_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITabs_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITabs_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ITabs_get_Count(This,psCount)	\
    (This)->lpVtbl -> get_Count(This,psCount)

#define ITabs_put_Count(This,psCount)	\
    (This)->lpVtbl -> put_Count(This,psCount)

#define ITabs_get_ControlDefault(This,pvIndex,ppTab)	\
    (This)->lpVtbl -> get_ControlDefault(This,pvIndex,ppTab)

#define ITabs_putref_ControlDefault(This,pvIndex,ppTab)	\
    (This)->lpVtbl -> putref_ControlDefault(This,pvIndex,ppTab)

#define ITabs_get_Item(This,pvIndex,ppTab)	\
    (This)->lpVtbl -> get_Item(This,pvIndex,ppTab)

#define ITabs_putref_Item(This,pvIndex,ppTab)	\
    (This)->lpVtbl -> putref_Item(This,pvIndex,ppTab)

#define ITabs_Remove(This,pvIndex)	\
    (This)->lpVtbl -> Remove(This,pvIndex)

#define ITabs_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define ITabs_Add(This,pvIndex,pvKey,pvCaption,pvImage,ppTab)	\
    (This)->lpVtbl -> Add(This,pvIndex,pvKey,pvCaption,pvImage,ppTab)

#define ITabs__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabs_get_Count_Proxy( 
    ITabs * This,
    /* [retval][out] */ short *psCount);


void __RPC_STUB ITabs_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITabs_put_Count_Proxy( 
    ITabs * This,
    /* [in] */ short psCount);


void __RPC_STUB ITabs_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE ITabs_get_ControlDefault_Proxy( 
    ITabs * This,
    /* [in] */ VARIANT *pvIndex,
    /* [retval][out] */ ITab **ppTab);


void __RPC_STUB ITabs_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabs_putref_ControlDefault_Proxy( 
    ITabs * This,
    /* [in] */ VARIANT *pvIndex,
    /* [in] */ ITab *ppTab);


void __RPC_STUB ITabs_putref_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITabs_get_Item_Proxy( 
    ITabs * This,
    /* [in] */ VARIANT *pvIndex,
    /* [retval][out] */ ITab **ppTab);


void __RPC_STUB ITabs_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITabs_putref_Item_Proxy( 
    ITabs * This,
    /* [in] */ VARIANT *pvIndex,
    /* [in] */ ITab *ppTab);


void __RPC_STUB ITabs_putref_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabs_Remove_Proxy( 
    ITabs * This,
    /* [in] */ VARIANT *pvIndex);


void __RPC_STUB ITabs_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabs_Clear_Proxy( 
    ITabs * This);


void __RPC_STUB ITabs_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITabs_Add_Proxy( 
    ITabs * This,
    /* [optional][in] */ VARIANT *pvIndex,
    /* [optional][in] */ VARIANT *pvKey,
    /* [optional][in] */ VARIANT *pvCaption,
    /* [optional][in] */ VARIANT *pvImage,
    /* [retval][out] */ ITab **ppTab);


void __RPC_STUB ITabs_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE ITabs__NewEnum_Proxy( 
    ITabs * This,
    /* [retval][out] */ IDispatch **ppNewEnum);


void __RPC_STUB ITabs__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ITabs_INTERFACE_DEFINED__ */


#ifndef __ITab_INTERFACE_DEFINED__
#define __ITab_INTERFACE_DEFINED__

/* interface ITab */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_ITab;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("1EFB6599-857C-11D1-B16A-00C0F0283628")
    ITab : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstrCaption) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstrCaption) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Caption( 
            /* [retval][out] */ BSTR *pbstrCaption) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Caption( 
            /* [in] */ BSTR pbstrCaption) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ToolTipText( 
            /* [retval][out] */ BSTR *pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ToolTipText( 
            /* [in] */ BSTR pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Width( 
            /* [retval][out] */ single *pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Width( 
            /* [in] */ single pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Height( 
            /* [retval][out] */ single *pfHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Height( 
            /* [in] */ single pfHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Top( 
            /* [retval][out] */ single *pfTop) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Top( 
            /* [in] */ single pfTop) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Left( 
            /* [retval][out] */ single *pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Left( 
            /* [in] */ single pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Selected( 
            /* [retval][out] */ VARIANT_BOOL *pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Selected( 
            /* [in] */ VARIANT_BOOL pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Image( 
            /* [retval][out] */ VARIANT *pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Image( 
            /* [in] */ VARIANT pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HighLighted( 
            /* [retval][out] */ VARIANT_BOOL *pbHighLighted) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HighLighted( 
            /* [in] */ VARIANT_BOOL pbHighLighted) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITabVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITab * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITab * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITab * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITab * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITab * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITab * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITab * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            ITab * This,
            /* [retval][out] */ BSTR *pbstrCaption);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            ITab * This,
            /* [in] */ BSTR pbstrCaption);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Caption )( 
            ITab * This,
            /* [retval][out] */ BSTR *pbstrCaption);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Caption )( 
            ITab * This,
            /* [in] */ BSTR pbstrCaption);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            ITab * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            ITab * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            ITab * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            ITab * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            ITab * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            ITab * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ToolTipText )( 
            ITab * This,
            /* [retval][out] */ BSTR *pbstrToolTipText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ToolTipText )( 
            ITab * This,
            /* [in] */ BSTR pbstrToolTipText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Width )( 
            ITab * This,
            /* [retval][out] */ single *pfWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Width )( 
            ITab * This,
            /* [in] */ single pfWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Height )( 
            ITab * This,
            /* [retval][out] */ single *pfHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Height )( 
            ITab * This,
            /* [in] */ single pfHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Top )( 
            ITab * This,
            /* [retval][out] */ single *pfTop);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Top )( 
            ITab * This,
            /* [in] */ single pfTop);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Left )( 
            ITab * This,
            /* [retval][out] */ single *pfLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Left )( 
            ITab * This,
            /* [in] */ single pfLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Selected )( 
            ITab * This,
            /* [retval][out] */ VARIANT_BOOL *pbSelected);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Selected )( 
            ITab * This,
            /* [in] */ VARIANT_BOOL pbSelected);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Image )( 
            ITab * This,
            /* [retval][out] */ VARIANT *pvImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Image )( 
            ITab * This,
            /* [in] */ VARIANT pvImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HighLighted )( 
            ITab * This,
            /* [retval][out] */ VARIANT_BOOL *pbHighLighted);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HighLighted )( 
            ITab * This,
            /* [in] */ VARIANT_BOOL pbHighLighted);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            ITab * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } ITabVtbl;

    interface ITab
    {
        CONST_VTBL struct ITabVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITab_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITab_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITab_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITab_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITab_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITab_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITab_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ITab_get__ObjectDefault(This,pbstrCaption)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstrCaption)

#define ITab_put__ObjectDefault(This,pbstrCaption)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstrCaption)

#define ITab_get_Caption(This,pbstrCaption)	\
    (This)->lpVtbl -> get_Caption(This,pbstrCaption)

#define ITab_put_Caption(This,pbstrCaption)	\
    (This)->lpVtbl -> put_Caption(This,pbstrCaption)

#define ITab_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define ITab_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define ITab_get_Index(This,psIndex)	\
    (This)->lpVtbl -> get_Index(This,psIndex)

#define ITab_put_Index(This,psIndex)	\
    (This)->lpVtbl -> put_Index(This,psIndex)

#define ITab_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define ITab_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define ITab_get_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> get_ToolTipText(This,pbstrToolTipText)

#define ITab_put_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> put_ToolTipText(This,pbstrToolTipText)

#define ITab_get_Width(This,pfWidth)	\
    (This)->lpVtbl -> get_Width(This,pfWidth)

#define ITab_put_Width(This,pfWidth)	\
    (This)->lpVtbl -> put_Width(This,pfWidth)

#define ITab_get_Height(This,pfHeight)	\
    (This)->lpVtbl -> get_Height(This,pfHeight)

#define ITab_put_Height(This,pfHeight)	\
    (This)->lpVtbl -> put_Height(This,pfHeight)

#define ITab_get_Top(This,pfTop)	\
    (This)->lpVtbl -> get_Top(This,pfTop)

#define ITab_put_Top(This,pfTop)	\
    (This)->lpVtbl -> put_Top(This,pfTop)

#define ITab_get_Left(This,pfLeft)	\
    (This)->lpVtbl -> get_Left(This,pfLeft)

#define ITab_put_Left(This,pfLeft)	\
    (This)->lpVtbl -> put_Left(This,pfLeft)

#define ITab_get_Selected(This,pbSelected)	\
    (This)->lpVtbl -> get_Selected(This,pbSelected)

#define ITab_put_Selected(This,pbSelected)	\
    (This)->lpVtbl -> put_Selected(This,pbSelected)

#define ITab_get_Image(This,pvImage)	\
    (This)->lpVtbl -> get_Image(This,pvImage)

#define ITab_put_Image(This,pvImage)	\
    (This)->lpVtbl -> put_Image(This,pvImage)

#define ITab_get_HighLighted(This,pbHighLighted)	\
    (This)->lpVtbl -> get_HighLighted(This,pbHighLighted)

#define ITab_put_HighLighted(This,pbHighLighted)	\
    (This)->lpVtbl -> put_HighLighted(This,pbHighLighted)

#define ITab_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get__ObjectDefault_Proxy( 
    ITab * This,
    /* [retval][out] */ BSTR *pbstrCaption);


void __RPC_STUB ITab_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put__ObjectDefault_Proxy( 
    ITab * This,
    /* [in] */ BSTR pbstrCaption);


void __RPC_STUB ITab_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Caption_Proxy( 
    ITab * This,
    /* [retval][out] */ BSTR *pbstrCaption);


void __RPC_STUB ITab_get_Caption_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Caption_Proxy( 
    ITab * This,
    /* [in] */ BSTR pbstrCaption);


void __RPC_STUB ITab_put_Caption_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Tag_Proxy( 
    ITab * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB ITab_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Tag_Proxy( 
    ITab * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB ITab_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Index_Proxy( 
    ITab * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB ITab_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Index_Proxy( 
    ITab * This,
    /* [in] */ short psIndex);


void __RPC_STUB ITab_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Key_Proxy( 
    ITab * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB ITab_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Key_Proxy( 
    ITab * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB ITab_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_ToolTipText_Proxy( 
    ITab * This,
    /* [retval][out] */ BSTR *pbstrToolTipText);


void __RPC_STUB ITab_get_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_ToolTipText_Proxy( 
    ITab * This,
    /* [in] */ BSTR pbstrToolTipText);


void __RPC_STUB ITab_put_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Width_Proxy( 
    ITab * This,
    /* [retval][out] */ single *pfWidth);


void __RPC_STUB ITab_get_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Width_Proxy( 
    ITab * This,
    /* [in] */ single pfWidth);


void __RPC_STUB ITab_put_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Height_Proxy( 
    ITab * This,
    /* [retval][out] */ single *pfHeight);


void __RPC_STUB ITab_get_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Height_Proxy( 
    ITab * This,
    /* [in] */ single pfHeight);


void __RPC_STUB ITab_put_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Top_Proxy( 
    ITab * This,
    /* [retval][out] */ single *pfTop);


void __RPC_STUB ITab_get_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Top_Proxy( 
    ITab * This,
    /* [in] */ single pfTop);


void __RPC_STUB ITab_put_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Left_Proxy( 
    ITab * This,
    /* [retval][out] */ single *pfLeft);


void __RPC_STUB ITab_get_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Left_Proxy( 
    ITab * This,
    /* [in] */ single pfLeft);


void __RPC_STUB ITab_put_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Selected_Proxy( 
    ITab * This,
    /* [retval][out] */ VARIANT_BOOL *pbSelected);


void __RPC_STUB ITab_get_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Selected_Proxy( 
    ITab * This,
    /* [in] */ VARIANT_BOOL pbSelected);


void __RPC_STUB ITab_put_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_Image_Proxy( 
    ITab * This,
    /* [retval][out] */ VARIANT *pvImage);


void __RPC_STUB ITab_get_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_Image_Proxy( 
    ITab * This,
    /* [in] */ VARIANT pvImage);


void __RPC_STUB ITab_put_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITab_get_HighLighted_Proxy( 
    ITab * This,
    /* [retval][out] */ VARIANT_BOOL *pbHighLighted);


void __RPC_STUB ITab_get_HighLighted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITab_put_HighLighted_Proxy( 
    ITab * This,
    /* [in] */ VARIANT_BOOL pbHighLighted);


void __RPC_STUB ITab_put_HighLighted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITab_putref_Tag_Proxy( 
    ITab * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB ITab_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ITab_INTERFACE_DEFINED__ */


#ifndef __IToolbar_INTERFACE_DEFINED__
#define __IToolbar_INTERFACE_DEFINED__

/* interface IToolbar */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IToolbar;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("66833FE4-8583-11D1-B16A-00C0F0283628")
    IToolbar : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Appearance( 
            /* [retval][out] */ AppearanceConstants *pnAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Appearance( 
            /* [in] */ AppearanceConstants pnAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_AllowCustomize( 
            /* [retval][out] */ VARIANT_BOOL *pbAllowCustomize) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_AllowCustomize( 
            /* [in] */ VARIANT_BOOL pbAllowCustomize) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Buttons( 
            /* [retval][out] */ IButtons **ppButtons) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Buttons( 
            /* [in] */ IButtons *ppButtons) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Controls( 
            /* [retval][out] */ IControls **ppControls) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageList( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ShowTips( 
            /* [retval][out] */ VARIANT_BOOL *bShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ShowTips( 
            /* [in] */ VARIANT_BOOL bShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_BorderStyle( 
            /* [retval][out] */ BorderStyleConstants *psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_BorderStyle( 
            /* [in] */ BorderStyleConstants psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Wrappable( 
            /* [retval][out] */ VARIANT_BOOL *pbWrappable) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Wrappable( 
            /* [in] */ VARIANT_BOOL pbWrappable) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ButtonHeight( 
            /* [retval][out] */ single *pfButtonHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ButtonHeight( 
            /* [in] */ single pfButtonHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ButtonWidth( 
            /* [retval][out] */ single *pfButtonWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ButtonWidth( 
            /* [in] */ single pfButtonWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HelpContextID( 
            /* [retval][out] */ long *plHelpContextID) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HelpContextID( 
            /* [in] */ long plHelpContextID) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HelpFile( 
            /* [retval][out] */ BSTR *pbstrHelpFile) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HelpFile( 
            /* [in] */ BSTR pbstrHelpFile) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Customize( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE SaveToolbar( 
            /* [in] */ BSTR Key,
            /* [in] */ BSTR Subkey,
            /* [in] */ BSTR Value) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE RestoreToolbar( 
            /* [in] */ BSTR Key,
            /* [in] */ BSTR Subkey,
            /* [in] */ BSTR Value) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_DisabledImageList( 
            /* [retval][out] */ IDispatch **ppDisabledImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_DisabledImageList( 
            /* [in] */ IDispatch *ppDisabledImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_DisabledImageList( 
            /* [in] */ IDispatch *ppDisabledImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HotImageList( 
            /* [retval][out] */ IDispatch **ppHotImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HotImageList( 
            /* [in] */ IDispatch *ppHotImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_HotImageList( 
            /* [in] */ IDispatch *ppHotImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ ToolbarStyleConstants *penumStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ ToolbarStyleConstants penumStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TextAlignment( 
            /* [retval][out] */ ToolbarTextAlignConstants *penumTextAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TextAlignment( 
            /* [in] */ ToolbarTextAlignConstants penumTextAlignment) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IToolbarVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IToolbar * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IToolbar * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IToolbar * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IToolbar * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IToolbar * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IToolbar * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IToolbar * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Appearance )( 
            IToolbar * This,
            /* [retval][out] */ AppearanceConstants *pnAppearance);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Appearance )( 
            IToolbar * This,
            /* [in] */ AppearanceConstants pnAppearance);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_AllowCustomize )( 
            IToolbar * This,
            /* [retval][out] */ VARIANT_BOOL *pbAllowCustomize);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_AllowCustomize )( 
            IToolbar * This,
            /* [in] */ VARIANT_BOOL pbAllowCustomize);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Buttons )( 
            IToolbar * This,
            /* [retval][out] */ IButtons **ppButtons);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Buttons )( 
            IToolbar * This,
            /* [in] */ IButtons *ppButtons);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Controls )( 
            IToolbar * This,
            /* [retval][out] */ IControls **ppControls);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IToolbar * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IToolbar * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            IToolbar * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            IToolbar * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            IToolbar * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            IToolbar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            IToolbar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            IToolbar * This,
            /* [retval][out] */ MousePointerConstants *psMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            IToolbar * This,
            /* [in] */ MousePointerConstants psMousePointer);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageList )( 
            IToolbar * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ShowTips )( 
            IToolbar * This,
            /* [retval][out] */ VARIANT_BOOL *bShowTips);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ShowTips )( 
            IToolbar * This,
            /* [in] */ VARIANT_BOOL bShowTips);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BorderStyle )( 
            IToolbar * This,
            /* [retval][out] */ BorderStyleConstants *psBorderStyle);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BorderStyle )( 
            IToolbar * This,
            /* [in] */ BorderStyleConstants psBorderStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Wrappable )( 
            IToolbar * This,
            /* [retval][out] */ VARIANT_BOOL *pbWrappable);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Wrappable )( 
            IToolbar * This,
            /* [in] */ VARIANT_BOOL pbWrappable);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ButtonHeight )( 
            IToolbar * This,
            /* [retval][out] */ single *pfButtonHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ButtonHeight )( 
            IToolbar * This,
            /* [in] */ single pfButtonHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ButtonWidth )( 
            IToolbar * This,
            /* [retval][out] */ single *pfButtonWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ButtonWidth )( 
            IToolbar * This,
            /* [in] */ single pfButtonWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HelpContextID )( 
            IToolbar * This,
            /* [retval][out] */ long *plHelpContextID);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HelpContextID )( 
            IToolbar * This,
            /* [in] */ long plHelpContextID);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HelpFile )( 
            IToolbar * This,
            /* [retval][out] */ BSTR *pbstrHelpFile);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HelpFile )( 
            IToolbar * This,
            /* [in] */ BSTR pbstrHelpFile);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            IToolbar * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            IToolbar * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            IToolbar * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Customize )( 
            IToolbar * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SaveToolbar )( 
            IToolbar * This,
            /* [in] */ BSTR Key,
            /* [in] */ BSTR Subkey,
            /* [in] */ BSTR Value);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *RestoreToolbar )( 
            IToolbar * This,
            /* [in] */ BSTR Key,
            /* [in] */ BSTR Subkey,
            /* [in] */ BSTR Value);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            IToolbar * This);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            IToolbar * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_DisabledImageList )( 
            IToolbar * This,
            /* [retval][out] */ IDispatch **ppDisabledImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_DisabledImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppDisabledImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_DisabledImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppDisabledImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HotImageList )( 
            IToolbar * This,
            /* [retval][out] */ IDispatch **ppHotImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HotImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppHotImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_HotImageList )( 
            IToolbar * This,
            /* [in] */ IDispatch *ppHotImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            IToolbar * This,
            /* [retval][out] */ ToolbarStyleConstants *penumStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            IToolbar * This,
            /* [in] */ ToolbarStyleConstants penumStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TextAlignment )( 
            IToolbar * This,
            /* [retval][out] */ ToolbarTextAlignConstants *penumTextAlignment);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TextAlignment )( 
            IToolbar * This,
            /* [in] */ ToolbarTextAlignConstants penumTextAlignment);
        
        END_INTERFACE
    } IToolbarVtbl;

    interface IToolbar
    {
        CONST_VTBL struct IToolbarVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IToolbar_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IToolbar_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IToolbar_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IToolbar_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IToolbar_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IToolbar_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IToolbar_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IToolbar_get_Appearance(This,pnAppearance)	\
    (This)->lpVtbl -> get_Appearance(This,pnAppearance)

#define IToolbar_put_Appearance(This,pnAppearance)	\
    (This)->lpVtbl -> put_Appearance(This,pnAppearance)

#define IToolbar_get_AllowCustomize(This,pbAllowCustomize)	\
    (This)->lpVtbl -> get_AllowCustomize(This,pbAllowCustomize)

#define IToolbar_put_AllowCustomize(This,pbAllowCustomize)	\
    (This)->lpVtbl -> put_AllowCustomize(This,pbAllowCustomize)

#define IToolbar_get_Buttons(This,ppButtons)	\
    (This)->lpVtbl -> get_Buttons(This,ppButtons)

#define IToolbar_putref_Buttons(This,ppButtons)	\
    (This)->lpVtbl -> putref_Buttons(This,ppButtons)

#define IToolbar_get_Controls(This,ppControls)	\
    (This)->lpVtbl -> get_Controls(This,ppControls)

#define IToolbar_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IToolbar_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IToolbar_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define IToolbar_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define IToolbar_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define IToolbar_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define IToolbar_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define IToolbar_get_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,psMousePointer)

#define IToolbar_put_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,psMousePointer)

#define IToolbar_get_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> get_ImageList(This,ppImageList)

#define IToolbar_put_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> put_ImageList(This,ppImageList)

#define IToolbar_putref_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> putref_ImageList(This,ppImageList)

#define IToolbar_get_ShowTips(This,bShowTips)	\
    (This)->lpVtbl -> get_ShowTips(This,bShowTips)

#define IToolbar_put_ShowTips(This,bShowTips)	\
    (This)->lpVtbl -> put_ShowTips(This,bShowTips)

#define IToolbar_get_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> get_BorderStyle(This,psBorderStyle)

#define IToolbar_put_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> put_BorderStyle(This,psBorderStyle)

#define IToolbar_get_Wrappable(This,pbWrappable)	\
    (This)->lpVtbl -> get_Wrappable(This,pbWrappable)

#define IToolbar_put_Wrappable(This,pbWrappable)	\
    (This)->lpVtbl -> put_Wrappable(This,pbWrappable)

#define IToolbar_get_ButtonHeight(This,pfButtonHeight)	\
    (This)->lpVtbl -> get_ButtonHeight(This,pfButtonHeight)

#define IToolbar_put_ButtonHeight(This,pfButtonHeight)	\
    (This)->lpVtbl -> put_ButtonHeight(This,pfButtonHeight)

#define IToolbar_get_ButtonWidth(This,pfButtonWidth)	\
    (This)->lpVtbl -> get_ButtonWidth(This,pfButtonWidth)

#define IToolbar_put_ButtonWidth(This,pfButtonWidth)	\
    (This)->lpVtbl -> put_ButtonWidth(This,pfButtonWidth)

#define IToolbar_get_HelpContextID(This,plHelpContextID)	\
    (This)->lpVtbl -> get_HelpContextID(This,plHelpContextID)

#define IToolbar_put_HelpContextID(This,plHelpContextID)	\
    (This)->lpVtbl -> put_HelpContextID(This,plHelpContextID)

#define IToolbar_get_HelpFile(This,pbstrHelpFile)	\
    (This)->lpVtbl -> get_HelpFile(This,pbstrHelpFile)

#define IToolbar_put_HelpFile(This,pbstrHelpFile)	\
    (This)->lpVtbl -> put_HelpFile(This,pbstrHelpFile)

#define IToolbar_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define IToolbar_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define IToolbar_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define IToolbar_Customize(This)	\
    (This)->lpVtbl -> Customize(This)

#define IToolbar_SaveToolbar(This,Key,Subkey,Value)	\
    (This)->lpVtbl -> SaveToolbar(This,Key,Subkey,Value)

#define IToolbar_RestoreToolbar(This,Key,Subkey,Value)	\
    (This)->lpVtbl -> RestoreToolbar(This,Key,Subkey,Value)

#define IToolbar_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define IToolbar_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define IToolbar_get_DisabledImageList(This,ppDisabledImageList)	\
    (This)->lpVtbl -> get_DisabledImageList(This,ppDisabledImageList)

#define IToolbar_put_DisabledImageList(This,ppDisabledImageList)	\
    (This)->lpVtbl -> put_DisabledImageList(This,ppDisabledImageList)

#define IToolbar_putref_DisabledImageList(This,ppDisabledImageList)	\
    (This)->lpVtbl -> putref_DisabledImageList(This,ppDisabledImageList)

#define IToolbar_get_HotImageList(This,ppHotImageList)	\
    (This)->lpVtbl -> get_HotImageList(This,ppHotImageList)

#define IToolbar_put_HotImageList(This,ppHotImageList)	\
    (This)->lpVtbl -> put_HotImageList(This,ppHotImageList)

#define IToolbar_putref_HotImageList(This,ppHotImageList)	\
    (This)->lpVtbl -> putref_HotImageList(This,ppHotImageList)

#define IToolbar_get_Style(This,penumStyle)	\
    (This)->lpVtbl -> get_Style(This,penumStyle)

#define IToolbar_put_Style(This,penumStyle)	\
    (This)->lpVtbl -> put_Style(This,penumStyle)

#define IToolbar_get_TextAlignment(This,penumTextAlignment)	\
    (This)->lpVtbl -> get_TextAlignment(This,penumTextAlignment)

#define IToolbar_put_TextAlignment(This,penumTextAlignment)	\
    (This)->lpVtbl -> put_TextAlignment(This,penumTextAlignment)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Appearance_Proxy( 
    IToolbar * This,
    /* [retval][out] */ AppearanceConstants *pnAppearance);


void __RPC_STUB IToolbar_get_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_Appearance_Proxy( 
    IToolbar * This,
    /* [in] */ AppearanceConstants pnAppearance);


void __RPC_STUB IToolbar_put_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_AllowCustomize_Proxy( 
    IToolbar * This,
    /* [retval][out] */ VARIANT_BOOL *pbAllowCustomize);


void __RPC_STUB IToolbar_get_AllowCustomize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_AllowCustomize_Proxy( 
    IToolbar * This,
    /* [in] */ VARIANT_BOOL pbAllowCustomize);


void __RPC_STUB IToolbar_put_AllowCustomize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Buttons_Proxy( 
    IToolbar * This,
    /* [retval][out] */ IButtons **ppButtons);


void __RPC_STUB IToolbar_get_Buttons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IToolbar_putref_Buttons_Proxy( 
    IToolbar * This,
    /* [in] */ IButtons *ppButtons);


void __RPC_STUB IToolbar_putref_Buttons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Controls_Proxy( 
    IToolbar * This,
    /* [retval][out] */ IControls **ppControls);


void __RPC_STUB IToolbar_get_Controls_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Enabled_Proxy( 
    IToolbar * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IToolbar_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_Enabled_Proxy( 
    IToolbar * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IToolbar_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_hWnd_Proxy( 
    IToolbar * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB IToolbar_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_hWnd_Proxy( 
    IToolbar * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB IToolbar_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_MouseIcon_Proxy( 
    IToolbar * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB IToolbar_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_MouseIcon_Proxy( 
    IToolbar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IToolbar_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IToolbar_putref_MouseIcon_Proxy( 
    IToolbar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IToolbar_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_MousePointer_Proxy( 
    IToolbar * This,
    /* [retval][out] */ MousePointerConstants *psMousePointer);


void __RPC_STUB IToolbar_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_MousePointer_Proxy( 
    IToolbar * This,
    /* [in] */ MousePointerConstants psMousePointer);


void __RPC_STUB IToolbar_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_ImageList_Proxy( 
    IToolbar * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB IToolbar_get_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_ImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IToolbar_put_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IToolbar_putref_ImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IToolbar_putref_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_ShowTips_Proxy( 
    IToolbar * This,
    /* [retval][out] */ VARIANT_BOOL *bShowTips);


void __RPC_STUB IToolbar_get_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_ShowTips_Proxy( 
    IToolbar * This,
    /* [in] */ VARIANT_BOOL bShowTips);


void __RPC_STUB IToolbar_put_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_BorderStyle_Proxy( 
    IToolbar * This,
    /* [retval][out] */ BorderStyleConstants *psBorderStyle);


void __RPC_STUB IToolbar_get_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_BorderStyle_Proxy( 
    IToolbar * This,
    /* [in] */ BorderStyleConstants psBorderStyle);


void __RPC_STUB IToolbar_put_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Wrappable_Proxy( 
    IToolbar * This,
    /* [retval][out] */ VARIANT_BOOL *pbWrappable);


void __RPC_STUB IToolbar_get_Wrappable_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_Wrappable_Proxy( 
    IToolbar * This,
    /* [in] */ VARIANT_BOOL pbWrappable);


void __RPC_STUB IToolbar_put_Wrappable_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_ButtonHeight_Proxy( 
    IToolbar * This,
    /* [retval][out] */ single *pfButtonHeight);


void __RPC_STUB IToolbar_get_ButtonHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_ButtonHeight_Proxy( 
    IToolbar * This,
    /* [in] */ single pfButtonHeight);


void __RPC_STUB IToolbar_put_ButtonHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_ButtonWidth_Proxy( 
    IToolbar * This,
    /* [retval][out] */ single *pfButtonWidth);


void __RPC_STUB IToolbar_get_ButtonWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_ButtonWidth_Proxy( 
    IToolbar * This,
    /* [in] */ single pfButtonWidth);


void __RPC_STUB IToolbar_put_ButtonWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_HelpContextID_Proxy( 
    IToolbar * This,
    /* [retval][out] */ long *plHelpContextID);


void __RPC_STUB IToolbar_get_HelpContextID_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_HelpContextID_Proxy( 
    IToolbar * This,
    /* [in] */ long plHelpContextID);


void __RPC_STUB IToolbar_put_HelpContextID_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_HelpFile_Proxy( 
    IToolbar * This,
    /* [retval][out] */ BSTR *pbstrHelpFile);


void __RPC_STUB IToolbar_get_HelpFile_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_HelpFile_Proxy( 
    IToolbar * This,
    /* [in] */ BSTR pbstrHelpFile);


void __RPC_STUB IToolbar_put_HelpFile_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_OLEDropMode_Proxy( 
    IToolbar * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB IToolbar_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_OLEDropMode_Proxy( 
    IToolbar * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB IToolbar_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IToolbar_Refresh_Proxy( 
    IToolbar * This);


void __RPC_STUB IToolbar_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IToolbar_Customize_Proxy( 
    IToolbar * This);


void __RPC_STUB IToolbar_Customize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IToolbar_SaveToolbar_Proxy( 
    IToolbar * This,
    /* [in] */ BSTR Key,
    /* [in] */ BSTR Subkey,
    /* [in] */ BSTR Value);


void __RPC_STUB IToolbar_SaveToolbar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IToolbar_RestoreToolbar_Proxy( 
    IToolbar * This,
    /* [in] */ BSTR Key,
    /* [in] */ BSTR Subkey,
    /* [in] */ BSTR Value);


void __RPC_STUB IToolbar_RestoreToolbar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IToolbar_OLEDrag_Proxy( 
    IToolbar * This);


void __RPC_STUB IToolbar_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IToolbar_AboutBox_Proxy( 
    IToolbar * This);


void __RPC_STUB IToolbar_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_DisabledImageList_Proxy( 
    IToolbar * This,
    /* [retval][out] */ IDispatch **ppDisabledImageList);


void __RPC_STUB IToolbar_get_DisabledImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_DisabledImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppDisabledImageList);


void __RPC_STUB IToolbar_put_DisabledImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IToolbar_putref_DisabledImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppDisabledImageList);


void __RPC_STUB IToolbar_putref_DisabledImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_HotImageList_Proxy( 
    IToolbar * This,
    /* [retval][out] */ IDispatch **ppHotImageList);


void __RPC_STUB IToolbar_get_HotImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_HotImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppHotImageList);


void __RPC_STUB IToolbar_put_HotImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IToolbar_putref_HotImageList_Proxy( 
    IToolbar * This,
    /* [in] */ IDispatch *ppHotImageList);


void __RPC_STUB IToolbar_putref_HotImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_Style_Proxy( 
    IToolbar * This,
    /* [retval][out] */ ToolbarStyleConstants *penumStyle);


void __RPC_STUB IToolbar_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_Style_Proxy( 
    IToolbar * This,
    /* [in] */ ToolbarStyleConstants penumStyle);


void __RPC_STUB IToolbar_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IToolbar_get_TextAlignment_Proxy( 
    IToolbar * This,
    /* [retval][out] */ ToolbarTextAlignConstants *penumTextAlignment);


void __RPC_STUB IToolbar_get_TextAlignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IToolbar_put_TextAlignment_Proxy( 
    IToolbar * This,
    /* [in] */ ToolbarTextAlignConstants penumTextAlignment);


void __RPC_STUB IToolbar_put_TextAlignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IToolbar_INTERFACE_DEFINED__ */


#ifndef __IToolbarEvents_DISPINTERFACE_DEFINED__
#define __IToolbarEvents_DISPINTERFACE_DEFINED__

/* dispinterface IToolbarEvents */
/* [helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_IToolbarEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("66833FE5-8583-11D1-B16A-00C0F0283628")
    IToolbarEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct IToolbarEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IToolbarEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IToolbarEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IToolbarEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IToolbarEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IToolbarEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IToolbarEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IToolbarEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IToolbarEventsVtbl;

    interface IToolbarEvents
    {
        CONST_VTBL struct IToolbarEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IToolbarEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IToolbarEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IToolbarEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IToolbarEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IToolbarEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IToolbarEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IToolbarEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __IToolbarEvents_DISPINTERFACE_DEFINED__ */


#ifndef __IButtons_INTERFACE_DEFINED__
#define __IButtons_INTERFACE_DEFINED__

/* interface IButtons */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IButtons;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("66833FE7-8583-11D1-B16A-00C0F0283628")
    IButtons : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *psCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short psCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButton **ppButton) = 0;
        
        virtual /* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IButton *ppButton) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButton **ppButton) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IButton *ppButton) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Caption,
            /* [optional][in] */ VARIANT *Style,
            /* [optional][in] */ VARIANT *Image,
            /* [retval][out] */ IButton **ppButton) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppDispatch) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IButtonsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IButtons * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IButtons * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IButtons * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IButtons * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IButtons * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IButtons * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IButtons * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IButtons * This,
            /* [retval][out] */ short *psCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IButtons * This,
            /* [in] */ short psCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IButtons * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButton **ppButton);
        
        /* [hidden][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ControlDefault )( 
            IButtons * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IButton *ppButton);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IButtons * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButton **ppButton);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Item )( 
            IButtons * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IButton *ppButton);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IButtons * This,
            /* [in] */ VARIANT *Index);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IButtons * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IButtons * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Caption,
            /* [optional][in] */ VARIANT *Style,
            /* [optional][in] */ VARIANT *Image,
            /* [retval][out] */ IButton **ppButton);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IButtons * This,
            /* [retval][out] */ IDispatch **ppDispatch);
        
        END_INTERFACE
    } IButtonsVtbl;

    interface IButtons
    {
        CONST_VTBL struct IButtonsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IButtons_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IButtons_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IButtons_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IButtons_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IButtons_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IButtons_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IButtons_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IButtons_get_Count(This,psCount)	\
    (This)->lpVtbl -> get_Count(This,psCount)

#define IButtons_put_Count(This,psCount)	\
    (This)->lpVtbl -> put_Count(This,psCount)

#define IButtons_get_ControlDefault(This,Index,ppButton)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppButton)

#define IButtons_putref_ControlDefault(This,Index,ppButton)	\
    (This)->lpVtbl -> putref_ControlDefault(This,Index,ppButton)

#define IButtons_get_Item(This,Index,ppButton)	\
    (This)->lpVtbl -> get_Item(This,Index,ppButton)

#define IButtons_putref_Item(This,Index,ppButton)	\
    (This)->lpVtbl -> putref_Item(This,Index,ppButton)

#define IButtons_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IButtons_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IButtons_Add(This,Index,Key,Caption,Style,Image,ppButton)	\
    (This)->lpVtbl -> Add(This,Index,Key,Caption,Style,Image,ppButton)

#define IButtons__NewEnum(This,ppDispatch)	\
    (This)->lpVtbl -> _NewEnum(This,ppDispatch)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtons_get_Count_Proxy( 
    IButtons * This,
    /* [retval][out] */ short *psCount);


void __RPC_STUB IButtons_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtons_put_Count_Proxy( 
    IButtons * This,
    /* [in] */ short psCount);


void __RPC_STUB IButtons_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IButtons_get_ControlDefault_Proxy( 
    IButtons * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IButton **ppButton);


void __RPC_STUB IButtons_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE IButtons_putref_ControlDefault_Proxy( 
    IButtons * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IButton *ppButton);


void __RPC_STUB IButtons_putref_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtons_get_Item_Proxy( 
    IButtons * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IButton **ppButton);


void __RPC_STUB IButtons_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IButtons_putref_Item_Proxy( 
    IButtons * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IButton *ppButton);


void __RPC_STUB IButtons_putref_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtons_Remove_Proxy( 
    IButtons * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IButtons_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtons_Clear_Proxy( 
    IButtons * This);


void __RPC_STUB IButtons_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtons_Add_Proxy( 
    IButtons * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Caption,
    /* [optional][in] */ VARIANT *Style,
    /* [optional][in] */ VARIANT *Image,
    /* [retval][out] */ IButton **ppButton);


void __RPC_STUB IButtons_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IButtons__NewEnum_Proxy( 
    IButtons * This,
    /* [retval][out] */ IDispatch **ppDispatch);


void __RPC_STUB IButtons__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IButtons_INTERFACE_DEFINED__ */


#ifndef __IButton_INTERFACE_DEFINED__
#define __IButton_INTERFACE_DEFINED__

/* interface IButton */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IButton;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("66833FE9-8583-11D1-B16A-00C0F0283628")
    IButton : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstr_ObjectDefault) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstr_ObjectDefault) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Caption( 
            /* [retval][out] */ BSTR *pbstrCaption) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Caption( 
            /* [in] */ BSTR pbstrCaption) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ToolTipText( 
            /* [retval][out] */ BSTR *pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ToolTipText( 
            /* [in] */ BSTR pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Visible( 
            /* [retval][out] */ VARIANT_BOOL *pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Visible( 
            /* [in] */ VARIANT_BOOL pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Width( 
            /* [retval][out] */ single *pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Width( 
            /* [in] */ single pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Height( 
            /* [retval][out] */ single *pfHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Height( 
            /* [in] */ single pfHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Top( 
            /* [retval][out] */ single *pfTop) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Top( 
            /* [in] */ single pfTop) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Left( 
            /* [retval][out] */ single *pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Left( 
            /* [in] */ single pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Value( 
            /* [retval][out] */ ValueConstants *psValue) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Value( 
            /* [in] */ ValueConstants psValue) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ ButtonStyleConstants *psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ ButtonStyleConstants psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Description( 
            /* [retval][out] */ BSTR *pbstrDescription) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Description( 
            /* [in] */ BSTR pbstrDescription) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Image( 
            /* [retval][out] */ VARIANT *pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Image( 
            /* [in] */ VARIANT pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MixedState( 
            /* [retval][out] */ VARIANT_BOOL *pbMixedState) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MixedState( 
            /* [in] */ VARIANT_BOOL pbMixedState) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ButtonMenus( 
            /* [retval][out] */ IButtonMenus **ppButtonMenus) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ButtonMenus( 
            /* [in] */ IButtonMenus *ppButtonMenus) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IButtonVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IButton * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IButton * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IButton * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IButton * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IButton * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IButton * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IButton * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            IButton * This,
            /* [retval][out] */ BSTR *pbstr_ObjectDefault);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            IButton * This,
            /* [in] */ BSTR pbstr_ObjectDefault);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Caption )( 
            IButton * This,
            /* [retval][out] */ BSTR *pbstrCaption);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Caption )( 
            IButton * This,
            /* [in] */ BSTR pbstrCaption);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IButton * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IButton * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IButton * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IButton * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IButton * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IButton * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IButton * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IButton * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ToolTipText )( 
            IButton * This,
            /* [retval][out] */ BSTR *pbstrToolTipText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ToolTipText )( 
            IButton * This,
            /* [in] */ BSTR pbstrToolTipText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Visible )( 
            IButton * This,
            /* [retval][out] */ VARIANT_BOOL *pbVisible);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Visible )( 
            IButton * This,
            /* [in] */ VARIANT_BOOL pbVisible);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Width )( 
            IButton * This,
            /* [retval][out] */ single *pfWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Width )( 
            IButton * This,
            /* [in] */ single pfWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Height )( 
            IButton * This,
            /* [retval][out] */ single *pfHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Height )( 
            IButton * This,
            /* [in] */ single pfHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Top )( 
            IButton * This,
            /* [retval][out] */ single *pfTop);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Top )( 
            IButton * This,
            /* [in] */ single pfTop);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Left )( 
            IButton * This,
            /* [retval][out] */ single *pfLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Left )( 
            IButton * This,
            /* [in] */ single pfLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Value )( 
            IButton * This,
            /* [retval][out] */ ValueConstants *psValue);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Value )( 
            IButton * This,
            /* [in] */ ValueConstants psValue);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            IButton * This,
            /* [retval][out] */ ButtonStyleConstants *psStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            IButton * This,
            /* [in] */ ButtonStyleConstants psStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Description )( 
            IButton * This,
            /* [retval][out] */ BSTR *pbstrDescription);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Description )( 
            IButton * This,
            /* [in] */ BSTR pbstrDescription);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Image )( 
            IButton * This,
            /* [retval][out] */ VARIANT *pvImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Image )( 
            IButton * This,
            /* [in] */ VARIANT pvImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MixedState )( 
            IButton * This,
            /* [retval][out] */ VARIANT_BOOL *pbMixedState);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MixedState )( 
            IButton * This,
            /* [in] */ VARIANT_BOOL pbMixedState);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ButtonMenus )( 
            IButton * This,
            /* [retval][out] */ IButtonMenus **ppButtonMenus);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ButtonMenus )( 
            IButton * This,
            /* [in] */ IButtonMenus *ppButtonMenus);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IButton * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } IButtonVtbl;

    interface IButton
    {
        CONST_VTBL struct IButtonVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IButton_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IButton_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IButton_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IButton_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IButton_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IButton_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IButton_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IButton_get__ObjectDefault(This,pbstr_ObjectDefault)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstr_ObjectDefault)

#define IButton_put__ObjectDefault(This,pbstr_ObjectDefault)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstr_ObjectDefault)

#define IButton_get_Caption(This,pbstrCaption)	\
    (This)->lpVtbl -> get_Caption(This,pbstrCaption)

#define IButton_put_Caption(This,pbstrCaption)	\
    (This)->lpVtbl -> put_Caption(This,pbstrCaption)

#define IButton_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IButton_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IButton_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IButton_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IButton_get_Index(This,psIndex)	\
    (This)->lpVtbl -> get_Index(This,psIndex)

#define IButton_put_Index(This,psIndex)	\
    (This)->lpVtbl -> put_Index(This,psIndex)

#define IButton_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IButton_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IButton_get_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> get_ToolTipText(This,pbstrToolTipText)

#define IButton_put_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> put_ToolTipText(This,pbstrToolTipText)

#define IButton_get_Visible(This,pbVisible)	\
    (This)->lpVtbl -> get_Visible(This,pbVisible)

#define IButton_put_Visible(This,pbVisible)	\
    (This)->lpVtbl -> put_Visible(This,pbVisible)

#define IButton_get_Width(This,pfWidth)	\
    (This)->lpVtbl -> get_Width(This,pfWidth)

#define IButton_put_Width(This,pfWidth)	\
    (This)->lpVtbl -> put_Width(This,pfWidth)

#define IButton_get_Height(This,pfHeight)	\
    (This)->lpVtbl -> get_Height(This,pfHeight)

#define IButton_put_Height(This,pfHeight)	\
    (This)->lpVtbl -> put_Height(This,pfHeight)

#define IButton_get_Top(This,pfTop)	\
    (This)->lpVtbl -> get_Top(This,pfTop)

#define IButton_put_Top(This,pfTop)	\
    (This)->lpVtbl -> put_Top(This,pfTop)

#define IButton_get_Left(This,pfLeft)	\
    (This)->lpVtbl -> get_Left(This,pfLeft)

#define IButton_put_Left(This,pfLeft)	\
    (This)->lpVtbl -> put_Left(This,pfLeft)

#define IButton_get_Value(This,psValue)	\
    (This)->lpVtbl -> get_Value(This,psValue)

#define IButton_put_Value(This,psValue)	\
    (This)->lpVtbl -> put_Value(This,psValue)

#define IButton_get_Style(This,psStyle)	\
    (This)->lpVtbl -> get_Style(This,psStyle)

#define IButton_put_Style(This,psStyle)	\
    (This)->lpVtbl -> put_Style(This,psStyle)

#define IButton_get_Description(This,pbstrDescription)	\
    (This)->lpVtbl -> get_Description(This,pbstrDescription)

#define IButton_put_Description(This,pbstrDescription)	\
    (This)->lpVtbl -> put_Description(This,pbstrDescription)

#define IButton_get_Image(This,pvImage)	\
    (This)->lpVtbl -> get_Image(This,pvImage)

#define IButton_put_Image(This,pvImage)	\
    (This)->lpVtbl -> put_Image(This,pvImage)

#define IButton_get_MixedState(This,pbMixedState)	\
    (This)->lpVtbl -> get_MixedState(This,pbMixedState)

#define IButton_put_MixedState(This,pbMixedState)	\
    (This)->lpVtbl -> put_MixedState(This,pbMixedState)

#define IButton_get_ButtonMenus(This,ppButtonMenus)	\
    (This)->lpVtbl -> get_ButtonMenus(This,ppButtonMenus)

#define IButton_putref_ButtonMenus(This,ppButtonMenus)	\
    (This)->lpVtbl -> putref_ButtonMenus(This,ppButtonMenus)

#define IButton_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get__ObjectDefault_Proxy( 
    IButton * This,
    /* [retval][out] */ BSTR *pbstr_ObjectDefault);


void __RPC_STUB IButton_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put__ObjectDefault_Proxy( 
    IButton * This,
    /* [in] */ BSTR pbstr_ObjectDefault);


void __RPC_STUB IButton_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Caption_Proxy( 
    IButton * This,
    /* [retval][out] */ BSTR *pbstrCaption);


void __RPC_STUB IButton_get_Caption_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Caption_Proxy( 
    IButton * This,
    /* [in] */ BSTR pbstrCaption);


void __RPC_STUB IButton_put_Caption_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Tag_Proxy( 
    IButton * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IButton_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Tag_Proxy( 
    IButton * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IButton_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Enabled_Proxy( 
    IButton * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IButton_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Enabled_Proxy( 
    IButton * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IButton_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Index_Proxy( 
    IButton * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB IButton_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Index_Proxy( 
    IButton * This,
    /* [in] */ short psIndex);


void __RPC_STUB IButton_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Key_Proxy( 
    IButton * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IButton_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Key_Proxy( 
    IButton * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IButton_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_ToolTipText_Proxy( 
    IButton * This,
    /* [retval][out] */ BSTR *pbstrToolTipText);


void __RPC_STUB IButton_get_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_ToolTipText_Proxy( 
    IButton * This,
    /* [in] */ BSTR pbstrToolTipText);


void __RPC_STUB IButton_put_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Visible_Proxy( 
    IButton * This,
    /* [retval][out] */ VARIANT_BOOL *pbVisible);


void __RPC_STUB IButton_get_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Visible_Proxy( 
    IButton * This,
    /* [in] */ VARIANT_BOOL pbVisible);


void __RPC_STUB IButton_put_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Width_Proxy( 
    IButton * This,
    /* [retval][out] */ single *pfWidth);


void __RPC_STUB IButton_get_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Width_Proxy( 
    IButton * This,
    /* [in] */ single pfWidth);


void __RPC_STUB IButton_put_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Height_Proxy( 
    IButton * This,
    /* [retval][out] */ single *pfHeight);


void __RPC_STUB IButton_get_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Height_Proxy( 
    IButton * This,
    /* [in] */ single pfHeight);


void __RPC_STUB IButton_put_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Top_Proxy( 
    IButton * This,
    /* [retval][out] */ single *pfTop);


void __RPC_STUB IButton_get_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Top_Proxy( 
    IButton * This,
    /* [in] */ single pfTop);


void __RPC_STUB IButton_put_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Left_Proxy( 
    IButton * This,
    /* [retval][out] */ single *pfLeft);


void __RPC_STUB IButton_get_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Left_Proxy( 
    IButton * This,
    /* [in] */ single pfLeft);


void __RPC_STUB IButton_put_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Value_Proxy( 
    IButton * This,
    /* [retval][out] */ ValueConstants *psValue);


void __RPC_STUB IButton_get_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Value_Proxy( 
    IButton * This,
    /* [in] */ ValueConstants psValue);


void __RPC_STUB IButton_put_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Style_Proxy( 
    IButton * This,
    /* [retval][out] */ ButtonStyleConstants *psStyle);


void __RPC_STUB IButton_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Style_Proxy( 
    IButton * This,
    /* [in] */ ButtonStyleConstants psStyle);


void __RPC_STUB IButton_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Description_Proxy( 
    IButton * This,
    /* [retval][out] */ BSTR *pbstrDescription);


void __RPC_STUB IButton_get_Description_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Description_Proxy( 
    IButton * This,
    /* [in] */ BSTR pbstrDescription);


void __RPC_STUB IButton_put_Description_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_Image_Proxy( 
    IButton * This,
    /* [retval][out] */ VARIANT *pvImage);


void __RPC_STUB IButton_get_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_Image_Proxy( 
    IButton * This,
    /* [in] */ VARIANT pvImage);


void __RPC_STUB IButton_put_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_MixedState_Proxy( 
    IButton * This,
    /* [retval][out] */ VARIANT_BOOL *pbMixedState);


void __RPC_STUB IButton_get_MixedState_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButton_put_MixedState_Proxy( 
    IButton * This,
    /* [in] */ VARIANT_BOOL pbMixedState);


void __RPC_STUB IButton_put_MixedState_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButton_get_ButtonMenus_Proxy( 
    IButton * This,
    /* [retval][out] */ IButtonMenus **ppButtonMenus);


void __RPC_STUB IButton_get_ButtonMenus_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IButton_putref_ButtonMenus_Proxy( 
    IButton * This,
    /* [in] */ IButtonMenus *ppButtonMenus);


void __RPC_STUB IButton_putref_ButtonMenus_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IButton_putref_Tag_Proxy( 
    IButton * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IButton_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IButton_INTERFACE_DEFINED__ */


#ifndef __IButtonMenus_INTERFACE_DEFINED__
#define __IButtonMenus_INTERFACE_DEFINED__

/* interface IButtonMenus */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IButtonMenus;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("66833FEB-8583-11D1-B16A-00C0F0283628")
    IButtonMenus : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *psCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short psCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButtonMenu **ppButtonMenu) = 0;
        
        virtual /* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IButtonMenu *ppButtonMenu) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButtonMenu **ppButtonMenu) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IButtonMenu *ppButtonMenu) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [retval][out] */ IButtonMenu **ppButtonMenu) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppDispatch) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IButtonMenusVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IButtonMenus * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IButtonMenus * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IButtonMenus * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IButtonMenus * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IButtonMenus * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IButtonMenus * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IButtonMenus * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IButtonMenus * This,
            /* [retval][out] */ short *psCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IButtonMenus * This,
            /* [in] */ short psCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IButtonMenus * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButtonMenu **ppButtonMenu);
        
        /* [hidden][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ControlDefault )( 
            IButtonMenus * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IButtonMenu *ppButtonMenu);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IButtonMenus * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IButtonMenu **ppButtonMenu);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Item )( 
            IButtonMenus * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IButtonMenu *ppButtonMenu);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IButtonMenus * This,
            /* [in] */ VARIANT *Index);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IButtonMenus * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IButtonMenus * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [retval][out] */ IButtonMenu **ppButtonMenu);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IButtonMenus * This,
            /* [retval][out] */ IDispatch **ppDispatch);
        
        END_INTERFACE
    } IButtonMenusVtbl;

    interface IButtonMenus
    {
        CONST_VTBL struct IButtonMenusVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IButtonMenus_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IButtonMenus_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IButtonMenus_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IButtonMenus_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IButtonMenus_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IButtonMenus_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IButtonMenus_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IButtonMenus_get_Count(This,psCount)	\
    (This)->lpVtbl -> get_Count(This,psCount)

#define IButtonMenus_put_Count(This,psCount)	\
    (This)->lpVtbl -> put_Count(This,psCount)

#define IButtonMenus_get_ControlDefault(This,Index,ppButtonMenu)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppButtonMenu)

#define IButtonMenus_putref_ControlDefault(This,Index,ppButtonMenu)	\
    (This)->lpVtbl -> putref_ControlDefault(This,Index,ppButtonMenu)

#define IButtonMenus_get_Item(This,Index,ppButtonMenu)	\
    (This)->lpVtbl -> get_Item(This,Index,ppButtonMenu)

#define IButtonMenus_putref_Item(This,Index,ppButtonMenu)	\
    (This)->lpVtbl -> putref_Item(This,Index,ppButtonMenu)

#define IButtonMenus_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IButtonMenus_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IButtonMenus_Add(This,Index,Key,Text,ppButtonMenu)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,ppButtonMenu)

#define IButtonMenus__NewEnum(This,ppDispatch)	\
    (This)->lpVtbl -> _NewEnum(This,ppDispatch)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_get_Count_Proxy( 
    IButtonMenus * This,
    /* [retval][out] */ short *psCount);


void __RPC_STUB IButtonMenus_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_put_Count_Proxy( 
    IButtonMenus * This,
    /* [in] */ short psCount);


void __RPC_STUB IButtonMenus_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_get_ControlDefault_Proxy( 
    IButtonMenus * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IButtonMenu **ppButtonMenu);


void __RPC_STUB IButtonMenus_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_putref_ControlDefault_Proxy( 
    IButtonMenus * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IButtonMenu *ppButtonMenu);


void __RPC_STUB IButtonMenus_putref_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_get_Item_Proxy( 
    IButtonMenus * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IButtonMenu **ppButtonMenu);


void __RPC_STUB IButtonMenus_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_putref_Item_Proxy( 
    IButtonMenus * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IButtonMenu *ppButtonMenu);


void __RPC_STUB IButtonMenus_putref_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_Remove_Proxy( 
    IButtonMenus * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IButtonMenus_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_Clear_Proxy( 
    IButtonMenus * This);


void __RPC_STUB IButtonMenus_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus_Add_Proxy( 
    IButtonMenus * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [retval][out] */ IButtonMenu **ppButtonMenu);


void __RPC_STUB IButtonMenus_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IButtonMenus__NewEnum_Proxy( 
    IButtonMenus * This,
    /* [retval][out] */ IDispatch **ppDispatch);


void __RPC_STUB IButtonMenus__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IButtonMenus_INTERFACE_DEFINED__ */


#ifndef __IButtonMenu_INTERFACE_DEFINED__
#define __IButtonMenu_INTERFACE_DEFINED__

/* interface IButtonMenu */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IButtonMenu;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("66833FED-8583-11D1-B16A-00C0F0283628")
    IButtonMenu : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstrObjectDefault) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstrObjectDefault) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Parent( 
            /* [retval][out] */ IButton **ppParent) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Parent( 
            /* [in] */ IButton *ppParent) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Visible( 
            /* [retval][out] */ VARIANT_BOOL *pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Visible( 
            /* [in] */ VARIANT_BOOL pbVisible) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IButtonMenuVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IButtonMenu * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IButtonMenu * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IButtonMenu * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IButtonMenu * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IButtonMenu * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IButtonMenu * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IButtonMenu * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            IButtonMenu * This,
            /* [retval][out] */ BSTR *pbstrObjectDefault);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            IButtonMenu * This,
            /* [in] */ BSTR pbstrObjectDefault);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IButtonMenu * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IButtonMenu * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IButtonMenu * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IButtonMenu * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IButtonMenu * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IButtonMenu * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Parent )( 
            IButtonMenu * This,
            /* [retval][out] */ IButton **ppParent);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Parent )( 
            IButtonMenu * This,
            /* [in] */ IButton *ppParent);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IButtonMenu * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IButtonMenu * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IButtonMenu * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IButtonMenu * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Visible )( 
            IButtonMenu * This,
            /* [retval][out] */ VARIANT_BOOL *pbVisible);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Visible )( 
            IButtonMenu * This,
            /* [in] */ VARIANT_BOOL pbVisible);
        
        END_INTERFACE
    } IButtonMenuVtbl;

    interface IButtonMenu
    {
        CONST_VTBL struct IButtonMenuVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IButtonMenu_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IButtonMenu_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IButtonMenu_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IButtonMenu_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IButtonMenu_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IButtonMenu_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IButtonMenu_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IButtonMenu_get__ObjectDefault(This,pbstrObjectDefault)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstrObjectDefault)

#define IButtonMenu_put__ObjectDefault(This,pbstrObjectDefault)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstrObjectDefault)

#define IButtonMenu_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IButtonMenu_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IButtonMenu_get_Index(This,psIndex)	\
    (This)->lpVtbl -> get_Index(This,psIndex)

#define IButtonMenu_put_Index(This,psIndex)	\
    (This)->lpVtbl -> put_Index(This,psIndex)

#define IButtonMenu_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IButtonMenu_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IButtonMenu_get_Parent(This,ppParent)	\
    (This)->lpVtbl -> get_Parent(This,ppParent)

#define IButtonMenu_putref_Parent(This,ppParent)	\
    (This)->lpVtbl -> putref_Parent(This,ppParent)

#define IButtonMenu_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IButtonMenu_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IButtonMenu_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IButtonMenu_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IButtonMenu_get_Visible(This,pbVisible)	\
    (This)->lpVtbl -> get_Visible(This,pbVisible)

#define IButtonMenu_put_Visible(This,pbVisible)	\
    (This)->lpVtbl -> put_Visible(This,pbVisible)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get__ObjectDefault_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ BSTR *pbstrObjectDefault);


void __RPC_STUB IButtonMenu_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put__ObjectDefault_Proxy( 
    IButtonMenu * This,
    /* [in] */ BSTR pbstrObjectDefault);


void __RPC_STUB IButtonMenu_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Enabled_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IButtonMenu_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Enabled_Proxy( 
    IButtonMenu * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IButtonMenu_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Index_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB IButtonMenu_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Index_Proxy( 
    IButtonMenu * This,
    /* [in] */ short psIndex);


void __RPC_STUB IButtonMenu_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Key_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IButtonMenu_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Key_Proxy( 
    IButtonMenu * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IButtonMenu_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Parent_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ IButton **ppParent);


void __RPC_STUB IButtonMenu_get_Parent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_putref_Parent_Proxy( 
    IButtonMenu * This,
    /* [in] */ IButton *ppParent);


void __RPC_STUB IButtonMenu_putref_Parent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Tag_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IButtonMenu_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Tag_Proxy( 
    IButtonMenu * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IButtonMenu_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Text_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IButtonMenu_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Text_Proxy( 
    IButtonMenu * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IButtonMenu_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_get_Visible_Proxy( 
    IButtonMenu * This,
    /* [retval][out] */ VARIANT_BOOL *pbVisible);


void __RPC_STUB IButtonMenu_get_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IButtonMenu_put_Visible_Proxy( 
    IButtonMenu * This,
    /* [in] */ VARIANT_BOOL pbVisible);


void __RPC_STUB IButtonMenu_put_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IButtonMenu_INTERFACE_DEFINED__ */


#ifndef __IStatusBar_INTERFACE_DEFINED__
#define __IStatusBar_INTERFACE_DEFINED__

/* interface IStatusBar */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IStatusBar;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8E3867A1-8586-11D1-B16A-00C0F0283628")
    IStatusBar : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SimpleText( 
            /* [retval][out] */ BSTR *pbstrSimpleText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SimpleText( 
            /* [in] */ BSTR pbstrSimpleText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ SbarStyleConstants *psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ SbarStyleConstants psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Panels( 
            /* [retval][out] */ IPanels **ppPanels) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Panels( 
            /* [in] */ IPanels *ppPanels) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ShowTips( 
            /* [retval][out] */ VARIANT_BOOL *bShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ShowTips( 
            /* [in] */ VARIANT_BOOL bShowTips) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_PanelProperties( 
            /* [retval][out] */ BSTR *pbstrPanelProperties) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_PanelProperties( 
            /* [in] */ BSTR pbstrPanelProperties) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Font( 
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IStatusBarVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IStatusBar * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IStatusBar * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IStatusBar * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IStatusBar * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IStatusBar * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IStatusBar * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IStatusBar * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SimpleText )( 
            IStatusBar * This,
            /* [retval][out] */ BSTR *pbstrSimpleText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SimpleText )( 
            IStatusBar * This,
            /* [in] */ BSTR pbstrSimpleText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            IStatusBar * This,
            /* [retval][out] */ SbarStyleConstants *psStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            IStatusBar * This,
            /* [in] */ SbarStyleConstants psStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Panels )( 
            IStatusBar * This,
            /* [retval][out] */ IPanels **ppPanels);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Panels )( 
            IStatusBar * This,
            /* [in] */ IPanels *ppPanels);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            IStatusBar * This,
            /* [retval][out] */ MousePointerConstants *psMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            IStatusBar * This,
            /* [in] */ MousePointerConstants psMousePointer);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            IStatusBar * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            IStatusBar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            IStatusBar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ShowTips )( 
            IStatusBar * This,
            /* [retval][out] */ VARIANT_BOOL *bShowTips);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ShowTips )( 
            IStatusBar * This,
            /* [in] */ VARIANT_BOOL bShowTips);
        
        /* [helpcontext][helpstring][hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_PanelProperties )( 
            IStatusBar * This,
            /* [retval][out] */ BSTR *pbstrPanelProperties);
        
        /* [helpcontext][helpstring][hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_PanelProperties )( 
            IStatusBar * This,
            /* [in] */ BSTR pbstrPanelProperties);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            IStatusBar * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            IStatusBar * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IStatusBar * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IStatusBar * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Font )( 
            IStatusBar * This,
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Font )( 
            IStatusBar * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFont);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            IStatusBar * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            IStatusBar * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            IStatusBar * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            IStatusBar * This);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            IStatusBar * This);
        
        END_INTERFACE
    } IStatusBarVtbl;

    interface IStatusBar
    {
        CONST_VTBL struct IStatusBarVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IStatusBar_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IStatusBar_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IStatusBar_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IStatusBar_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IStatusBar_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IStatusBar_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IStatusBar_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IStatusBar_get_SimpleText(This,pbstrSimpleText)	\
    (This)->lpVtbl -> get_SimpleText(This,pbstrSimpleText)

#define IStatusBar_put_SimpleText(This,pbstrSimpleText)	\
    (This)->lpVtbl -> put_SimpleText(This,pbstrSimpleText)

#define IStatusBar_get_Style(This,psStyle)	\
    (This)->lpVtbl -> get_Style(This,psStyle)

#define IStatusBar_put_Style(This,psStyle)	\
    (This)->lpVtbl -> put_Style(This,psStyle)

#define IStatusBar_get_Panels(This,ppPanels)	\
    (This)->lpVtbl -> get_Panels(This,ppPanels)

#define IStatusBar_putref_Panels(This,ppPanels)	\
    (This)->lpVtbl -> putref_Panels(This,ppPanels)

#define IStatusBar_get_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,psMousePointer)

#define IStatusBar_put_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,psMousePointer)

#define IStatusBar_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define IStatusBar_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define IStatusBar_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define IStatusBar_get_ShowTips(This,bShowTips)	\
    (This)->lpVtbl -> get_ShowTips(This,bShowTips)

#define IStatusBar_put_ShowTips(This,bShowTips)	\
    (This)->lpVtbl -> put_ShowTips(This,bShowTips)

#define IStatusBar_get_PanelProperties(This,pbstrPanelProperties)	\
    (This)->lpVtbl -> get_PanelProperties(This,pbstrPanelProperties)

#define IStatusBar_put_PanelProperties(This,pbstrPanelProperties)	\
    (This)->lpVtbl -> put_PanelProperties(This,pbstrPanelProperties)

#define IStatusBar_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define IStatusBar_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define IStatusBar_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IStatusBar_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IStatusBar_get_Font(This,ppFont)	\
    (This)->lpVtbl -> get_Font(This,ppFont)

#define IStatusBar_putref_Font(This,ppFont)	\
    (This)->lpVtbl -> putref_Font(This,ppFont)

#define IStatusBar_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define IStatusBar_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define IStatusBar_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define IStatusBar_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define IStatusBar_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_SimpleText_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ BSTR *pbstrSimpleText);


void __RPC_STUB IStatusBar_get_SimpleText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_SimpleText_Proxy( 
    IStatusBar * This,
    /* [in] */ BSTR pbstrSimpleText);


void __RPC_STUB IStatusBar_put_SimpleText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_Style_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ SbarStyleConstants *psStyle);


void __RPC_STUB IStatusBar_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_Style_Proxy( 
    IStatusBar * This,
    /* [in] */ SbarStyleConstants psStyle);


void __RPC_STUB IStatusBar_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_Panels_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ IPanels **ppPanels);


void __RPC_STUB IStatusBar_get_Panels_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_putref_Panels_Proxy( 
    IStatusBar * This,
    /* [in] */ IPanels *ppPanels);


void __RPC_STUB IStatusBar_putref_Panels_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_MousePointer_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ MousePointerConstants *psMousePointer);


void __RPC_STUB IStatusBar_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_MousePointer_Proxy( 
    IStatusBar * This,
    /* [in] */ MousePointerConstants psMousePointer);


void __RPC_STUB IStatusBar_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_MouseIcon_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB IStatusBar_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_MouseIcon_Proxy( 
    IStatusBar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IStatusBar_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_putref_MouseIcon_Proxy( 
    IStatusBar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IStatusBar_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_ShowTips_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ VARIANT_BOOL *bShowTips);


void __RPC_STUB IStatusBar_get_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_ShowTips_Proxy( 
    IStatusBar * This,
    /* [in] */ VARIANT_BOOL bShowTips);


void __RPC_STUB IStatusBar_put_ShowTips_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_PanelProperties_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ BSTR *pbstrPanelProperties);


void __RPC_STUB IStatusBar_get_PanelProperties_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_PanelProperties_Proxy( 
    IStatusBar * This,
    /* [in] */ BSTR pbstrPanelProperties);


void __RPC_STUB IStatusBar_put_PanelProperties_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_OLEDropMode_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB IStatusBar_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_OLEDropMode_Proxy( 
    IStatusBar * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB IStatusBar_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_Enabled_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IStatusBar_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_Enabled_Proxy( 
    IStatusBar * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IStatusBar_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_Font_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);


void __RPC_STUB IStatusBar_get_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_putref_Font_Proxy( 
    IStatusBar * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFont);


void __RPC_STUB IStatusBar_putref_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_get_hWnd_Proxy( 
    IStatusBar * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB IStatusBar_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_put_hWnd_Proxy( 
    IStatusBar * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB IStatusBar_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_Refresh_Proxy( 
    IStatusBar * This);


void __RPC_STUB IStatusBar_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_OLEDrag_Proxy( 
    IStatusBar * This);


void __RPC_STUB IStatusBar_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IStatusBar_AboutBox_Proxy( 
    IStatusBar * This);


void __RPC_STUB IStatusBar_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IStatusBar_INTERFACE_DEFINED__ */


#ifndef __IStatusBarEvents_DISPINTERFACE_DEFINED__
#define __IStatusBarEvents_DISPINTERFACE_DEFINED__

/* dispinterface IStatusBarEvents */
/* [nonextensible][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_IStatusBarEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("8E3867A2-8586-11D1-B16A-00C0F0283628")
    IStatusBarEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct IStatusBarEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IStatusBarEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IStatusBarEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IStatusBarEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IStatusBarEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IStatusBarEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IStatusBarEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IStatusBarEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IStatusBarEventsVtbl;

    interface IStatusBarEvents
    {
        CONST_VTBL struct IStatusBarEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IStatusBarEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IStatusBarEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IStatusBarEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IStatusBarEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IStatusBarEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IStatusBarEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IStatusBarEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __IStatusBarEvents_DISPINTERFACE_DEFINED__ */


#ifndef __IPanels_INTERFACE_DEFINED__
#define __IPanels_INTERFACE_DEFINED__

/* interface IPanels */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IPanels;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8E3867A4-8586-11D1-B16A-00C0F0283628")
    IPanels : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *sCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short sCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IPanel **ppPanel) = 0;
        
        virtual /* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IPanel *ppPanel) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Style,
            /* [optional][in] */ VARIANT *Picture,
            /* [retval][out] */ IPanel **ppPanel) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IPanel **ppPanel) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IPanel *ppPanel) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IPanelsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IPanels * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IPanels * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IPanels * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IPanels * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IPanels * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IPanels * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IPanels * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IPanels * This,
            /* [retval][out] */ short *sCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IPanels * This,
            /* [in] */ short sCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IPanels * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IPanel **ppPanel);
        
        /* [hidden][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ControlDefault )( 
            IPanels * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IPanel *ppPanel);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IPanels * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Style,
            /* [optional][in] */ VARIANT *Picture,
            /* [retval][out] */ IPanel **ppPanel);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IPanels * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IPanels * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IPanel **ppPanel);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Item )( 
            IPanels * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IPanel *ppPanel);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IPanels * This,
            /* [in] */ VARIANT *Index);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IPanels * This,
            /* [retval][out] */ IDispatch **ppNewEnum);
        
        END_INTERFACE
    } IPanelsVtbl;

    interface IPanels
    {
        CONST_VTBL struct IPanelsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IPanels_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IPanels_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IPanels_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IPanels_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IPanels_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IPanels_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IPanels_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IPanels_get_Count(This,sCount)	\
    (This)->lpVtbl -> get_Count(This,sCount)

#define IPanels_put_Count(This,sCount)	\
    (This)->lpVtbl -> put_Count(This,sCount)

#define IPanels_get_ControlDefault(This,Index,ppPanel)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppPanel)

#define IPanels_putref_ControlDefault(This,Index,ppPanel)	\
    (This)->lpVtbl -> putref_ControlDefault(This,Index,ppPanel)

#define IPanels_Add(This,Index,Key,Text,Style,Picture,ppPanel)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,Style,Picture,ppPanel)

#define IPanels_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IPanels_get_Item(This,Index,ppPanel)	\
    (This)->lpVtbl -> get_Item(This,Index,ppPanel)

#define IPanels_putref_Item(This,Index,ppPanel)	\
    (This)->lpVtbl -> putref_Item(This,Index,ppPanel)

#define IPanels_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IPanels__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanels_get_Count_Proxy( 
    IPanels * This,
    /* [retval][out] */ short *sCount);


void __RPC_STUB IPanels_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanels_put_Count_Proxy( 
    IPanels * This,
    /* [in] */ short sCount);


void __RPC_STUB IPanels_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IPanels_get_ControlDefault_Proxy( 
    IPanels * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IPanel **ppPanel);


void __RPC_STUB IPanels_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE IPanels_putref_ControlDefault_Proxy( 
    IPanels * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IPanel *ppPanel);


void __RPC_STUB IPanels_putref_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IPanels_Add_Proxy( 
    IPanels * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Style,
    /* [optional][in] */ VARIANT *Picture,
    /* [retval][out] */ IPanel **ppPanel);


void __RPC_STUB IPanels_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IPanels_Clear_Proxy( 
    IPanels * This);


void __RPC_STUB IPanels_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanels_get_Item_Proxy( 
    IPanels * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IPanel **ppPanel);


void __RPC_STUB IPanels_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IPanels_putref_Item_Proxy( 
    IPanels * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IPanel *ppPanel);


void __RPC_STUB IPanels_putref_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IPanels_Remove_Proxy( 
    IPanels * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IPanels_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IPanels__NewEnum_Proxy( 
    IPanels * This,
    /* [retval][out] */ IDispatch **ppNewEnum);


void __RPC_STUB IPanels__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IPanels_INTERFACE_DEFINED__ */


#ifndef __IPanel_INTERFACE_DEFINED__
#define __IPanel_INTERFACE_DEFINED__

/* interface IPanel */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IPanel;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8E3867AA-8586-11D1-B16A-00C0F0283628")
    IPanel : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Alignment( 
            /* [retval][out] */ PanelAlignmentConstants *psAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Alignment( 
            /* [in] */ PanelAlignmentConstants psAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_AutoSize( 
            /* [retval][out] */ PanelAutoSizeConstants *psAutoSize) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_AutoSize( 
            /* [in] */ PanelAutoSizeConstants psAutoSize) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Bevel( 
            /* [retval][out] */ PanelBevelConstants *psBevel) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Bevel( 
            /* [in] */ PanelBevelConstants psBevel) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *sIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short sIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Left( 
            /* [retval][out] */ single *pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Left( 
            /* [in] */ single pfLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MinWidth( 
            /* [retval][out] */ single *pfMinWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MinWidth( 
            /* [in] */ single pfMinWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Picture( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPicture) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Picture( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPicture) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ PanelStyleConstants *psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ PanelStyleConstants psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ToolTipText( 
            /* [retval][out] */ BSTR *pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ToolTipText( 
            /* [in] */ BSTR pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Visible( 
            /* [retval][out] */ VARIANT_BOOL *pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Visible( 
            /* [in] */ VARIANT_BOOL pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Width( 
            /* [retval][out] */ single *pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Width( 
            /* [in] */ single pfWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Picture( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPicture) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IPanelVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IPanel * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IPanel * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IPanel * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IPanel * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IPanel * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IPanel * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IPanel * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            IPanel * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            IPanel * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Alignment )( 
            IPanel * This,
            /* [retval][out] */ PanelAlignmentConstants *psAlignment);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Alignment )( 
            IPanel * This,
            /* [in] */ PanelAlignmentConstants psAlignment);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_AutoSize )( 
            IPanel * This,
            /* [retval][out] */ PanelAutoSizeConstants *psAutoSize);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_AutoSize )( 
            IPanel * This,
            /* [in] */ PanelAutoSizeConstants psAutoSize);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Bevel )( 
            IPanel * This,
            /* [retval][out] */ PanelBevelConstants *psBevel);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Bevel )( 
            IPanel * This,
            /* [in] */ PanelBevelConstants psBevel);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IPanel * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IPanel * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IPanel * This,
            /* [retval][out] */ short *sIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IPanel * This,
            /* [in] */ short sIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IPanel * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IPanel * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Left )( 
            IPanel * This,
            /* [retval][out] */ single *pfLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Left )( 
            IPanel * This,
            /* [in] */ single pfLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MinWidth )( 
            IPanel * This,
            /* [retval][out] */ single *pfMinWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MinWidth )( 
            IPanel * This,
            /* [in] */ single pfMinWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Picture )( 
            IPanel * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPicture);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Picture )( 
            IPanel * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPicture);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            IPanel * This,
            /* [retval][out] */ PanelStyleConstants *psStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            IPanel * This,
            /* [in] */ PanelStyleConstants psStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IPanel * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IPanel * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IPanel * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IPanel * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ToolTipText )( 
            IPanel * This,
            /* [retval][out] */ BSTR *pbstrToolTipText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ToolTipText )( 
            IPanel * This,
            /* [in] */ BSTR pbstrToolTipText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Visible )( 
            IPanel * This,
            /* [retval][out] */ VARIANT_BOOL *pbVisible);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Visible )( 
            IPanel * This,
            /* [in] */ VARIANT_BOOL pbVisible);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Width )( 
            IPanel * This,
            /* [retval][out] */ single *pfWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Width )( 
            IPanel * This,
            /* [in] */ single pfWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Picture )( 
            IPanel * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPicture);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IPanel * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } IPanelVtbl;

    interface IPanel
    {
        CONST_VTBL struct IPanelVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IPanel_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IPanel_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IPanel_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IPanel_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IPanel_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IPanel_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IPanel_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IPanel_get__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstrText)

#define IPanel_put__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstrText)

#define IPanel_get_Alignment(This,psAlignment)	\
    (This)->lpVtbl -> get_Alignment(This,psAlignment)

#define IPanel_put_Alignment(This,psAlignment)	\
    (This)->lpVtbl -> put_Alignment(This,psAlignment)

#define IPanel_get_AutoSize(This,psAutoSize)	\
    (This)->lpVtbl -> get_AutoSize(This,psAutoSize)

#define IPanel_put_AutoSize(This,psAutoSize)	\
    (This)->lpVtbl -> put_AutoSize(This,psAutoSize)

#define IPanel_get_Bevel(This,psBevel)	\
    (This)->lpVtbl -> get_Bevel(This,psBevel)

#define IPanel_put_Bevel(This,psBevel)	\
    (This)->lpVtbl -> put_Bevel(This,psBevel)

#define IPanel_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IPanel_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IPanel_get_Index(This,sIndex)	\
    (This)->lpVtbl -> get_Index(This,sIndex)

#define IPanel_put_Index(This,sIndex)	\
    (This)->lpVtbl -> put_Index(This,sIndex)

#define IPanel_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IPanel_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IPanel_get_Left(This,pfLeft)	\
    (This)->lpVtbl -> get_Left(This,pfLeft)

#define IPanel_put_Left(This,pfLeft)	\
    (This)->lpVtbl -> put_Left(This,pfLeft)

#define IPanel_get_MinWidth(This,pfMinWidth)	\
    (This)->lpVtbl -> get_MinWidth(This,pfMinWidth)

#define IPanel_put_MinWidth(This,pfMinWidth)	\
    (This)->lpVtbl -> put_MinWidth(This,pfMinWidth)

#define IPanel_get_Picture(This,ppPicture)	\
    (This)->lpVtbl -> get_Picture(This,ppPicture)

#define IPanel_putref_Picture(This,ppPicture)	\
    (This)->lpVtbl -> putref_Picture(This,ppPicture)

#define IPanel_get_Style(This,psStyle)	\
    (This)->lpVtbl -> get_Style(This,psStyle)

#define IPanel_put_Style(This,psStyle)	\
    (This)->lpVtbl -> put_Style(This,psStyle)

#define IPanel_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IPanel_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IPanel_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IPanel_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IPanel_get_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> get_ToolTipText(This,pbstrToolTipText)

#define IPanel_put_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> put_ToolTipText(This,pbstrToolTipText)

#define IPanel_get_Visible(This,pbVisible)	\
    (This)->lpVtbl -> get_Visible(This,pbVisible)

#define IPanel_put_Visible(This,pbVisible)	\
    (This)->lpVtbl -> put_Visible(This,pbVisible)

#define IPanel_get_Width(This,pfWidth)	\
    (This)->lpVtbl -> get_Width(This,pfWidth)

#define IPanel_put_Width(This,pfWidth)	\
    (This)->lpVtbl -> put_Width(This,pfWidth)

#define IPanel_put_Picture(This,ppPicture)	\
    (This)->lpVtbl -> put_Picture(This,ppPicture)

#define IPanel_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get__ObjectDefault_Proxy( 
    IPanel * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IPanel_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put__ObjectDefault_Proxy( 
    IPanel * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IPanel_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Alignment_Proxy( 
    IPanel * This,
    /* [retval][out] */ PanelAlignmentConstants *psAlignment);


void __RPC_STUB IPanel_get_Alignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Alignment_Proxy( 
    IPanel * This,
    /* [in] */ PanelAlignmentConstants psAlignment);


void __RPC_STUB IPanel_put_Alignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_AutoSize_Proxy( 
    IPanel * This,
    /* [retval][out] */ PanelAutoSizeConstants *psAutoSize);


void __RPC_STUB IPanel_get_AutoSize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_AutoSize_Proxy( 
    IPanel * This,
    /* [in] */ PanelAutoSizeConstants psAutoSize);


void __RPC_STUB IPanel_put_AutoSize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Bevel_Proxy( 
    IPanel * This,
    /* [retval][out] */ PanelBevelConstants *psBevel);


void __RPC_STUB IPanel_get_Bevel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Bevel_Proxy( 
    IPanel * This,
    /* [in] */ PanelBevelConstants psBevel);


void __RPC_STUB IPanel_put_Bevel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Enabled_Proxy( 
    IPanel * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IPanel_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Enabled_Proxy( 
    IPanel * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IPanel_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Index_Proxy( 
    IPanel * This,
    /* [retval][out] */ short *sIndex);


void __RPC_STUB IPanel_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Index_Proxy( 
    IPanel * This,
    /* [in] */ short sIndex);


void __RPC_STUB IPanel_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Key_Proxy( 
    IPanel * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IPanel_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Key_Proxy( 
    IPanel * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IPanel_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Left_Proxy( 
    IPanel * This,
    /* [retval][out] */ single *pfLeft);


void __RPC_STUB IPanel_get_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Left_Proxy( 
    IPanel * This,
    /* [in] */ single pfLeft);


void __RPC_STUB IPanel_put_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_MinWidth_Proxy( 
    IPanel * This,
    /* [retval][out] */ single *pfMinWidth);


void __RPC_STUB IPanel_get_MinWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_MinWidth_Proxy( 
    IPanel * This,
    /* [in] */ single pfMinWidth);


void __RPC_STUB IPanel_put_MinWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Picture_Proxy( 
    IPanel * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPicture);


void __RPC_STUB IPanel_get_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IPanel_putref_Picture_Proxy( 
    IPanel * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPicture);


void __RPC_STUB IPanel_putref_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Style_Proxy( 
    IPanel * This,
    /* [retval][out] */ PanelStyleConstants *psStyle);


void __RPC_STUB IPanel_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Style_Proxy( 
    IPanel * This,
    /* [in] */ PanelStyleConstants psStyle);


void __RPC_STUB IPanel_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Tag_Proxy( 
    IPanel * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IPanel_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Tag_Proxy( 
    IPanel * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IPanel_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Text_Proxy( 
    IPanel * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IPanel_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Text_Proxy( 
    IPanel * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IPanel_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_ToolTipText_Proxy( 
    IPanel * This,
    /* [retval][out] */ BSTR *pbstrToolTipText);


void __RPC_STUB IPanel_get_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_ToolTipText_Proxy( 
    IPanel * This,
    /* [in] */ BSTR pbstrToolTipText);


void __RPC_STUB IPanel_put_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Visible_Proxy( 
    IPanel * This,
    /* [retval][out] */ VARIANT_BOOL *pbVisible);


void __RPC_STUB IPanel_get_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Visible_Proxy( 
    IPanel * This,
    /* [in] */ VARIANT_BOOL pbVisible);


void __RPC_STUB IPanel_put_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IPanel_get_Width_Proxy( 
    IPanel * This,
    /* [retval][out] */ single *pfWidth);


void __RPC_STUB IPanel_get_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Width_Proxy( 
    IPanel * This,
    /* [in] */ single pfWidth);


void __RPC_STUB IPanel_put_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IPanel_put_Picture_Proxy( 
    IPanel * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPicture);


void __RPC_STUB IPanel_put_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IPanel_putref_Tag_Proxy( 
    IPanel * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IPanel_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IPanel_INTERFACE_DEFINED__ */


#ifndef __IProgressBar_INTERFACE_DEFINED__
#define __IProgressBar_INTERFACE_DEFINED__

/* interface IProgressBar */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IProgressBar;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("35053A20-8589-11D1-B16A-00C0F0283628")
    IProgressBar : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [retval][out] */ single *pfValue) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_ControlDefault( 
            /* [in] */ single pfValue) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Max( 
            /* [retval][out] */ single *pfMax) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Max( 
            /* [in] */ single pfMax) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Min( 
            /* [retval][out] */ single *pfMin) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Min( 
            /* [in] */ single pfMin) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *pMousePointers) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants pMousePointers) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Value( 
            /* [retval][out] */ single *pfValue) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Value( 
            /* [in] */ single pfValue) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Appearance( 
            /* [retval][out] */ AppearanceConstants *penumAppearances) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Appearance( 
            /* [in] */ AppearanceConstants penumAppearances) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BorderStyle( 
            /* [retval][out] */ BorderStyleConstants *penumBorderStyles) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BorderStyle( 
            /* [in] */ BorderStyleConstants penumBorderStyles) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *bEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL bEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Orientation( 
            /* [retval][out] */ OrientationConstants *penumOrientation) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Orientation( 
            /* [in] */ OrientationConstants penumOrientation) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Scrolling( 
            /* [retval][out] */ ScrollingConstants *penumScrolling) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Scrolling( 
            /* [in] */ ScrollingConstants penumScrolling) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IProgressBarVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProgressBar * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProgressBar * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProgressBar * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProgressBar * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProgressBar * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProgressBar * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProgressBar * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IProgressBar * This,
            /* [retval][out] */ single *pfValue);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ControlDefault )( 
            IProgressBar * This,
            /* [in] */ single pfValue);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Max )( 
            IProgressBar * This,
            /* [retval][out] */ single *pfMax);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Max )( 
            IProgressBar * This,
            /* [in] */ single pfMax);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Min )( 
            IProgressBar * This,
            /* [retval][out] */ single *pfMin);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Min )( 
            IProgressBar * This,
            /* [in] */ single pfMin);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            IProgressBar * This,
            /* [retval][out] */ MousePointerConstants *pMousePointers);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            IProgressBar * This,
            /* [in] */ MousePointerConstants pMousePointers);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            IProgressBar * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            IProgressBar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            IProgressBar * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Value )( 
            IProgressBar * This,
            /* [retval][out] */ single *pfValue);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Value )( 
            IProgressBar * This,
            /* [in] */ single pfValue);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            IProgressBar * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            IProgressBar * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Appearance )( 
            IProgressBar * This,
            /* [retval][out] */ AppearanceConstants *penumAppearances);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Appearance )( 
            IProgressBar * This,
            /* [in] */ AppearanceConstants penumAppearances);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BorderStyle )( 
            IProgressBar * This,
            /* [retval][out] */ BorderStyleConstants *penumBorderStyles);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BorderStyle )( 
            IProgressBar * This,
            /* [in] */ BorderStyleConstants penumBorderStyles);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IProgressBar * This,
            /* [retval][out] */ VARIANT_BOOL *bEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IProgressBar * This,
            /* [in] */ VARIANT_BOOL bEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            IProgressBar * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            IProgressBar * This);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            IProgressBar * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Orientation )( 
            IProgressBar * This,
            /* [retval][out] */ OrientationConstants *penumOrientation);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Orientation )( 
            IProgressBar * This,
            /* [in] */ OrientationConstants penumOrientation);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Scrolling )( 
            IProgressBar * This,
            /* [retval][out] */ ScrollingConstants *penumScrolling);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Scrolling )( 
            IProgressBar * This,
            /* [in] */ ScrollingConstants penumScrolling);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            IProgressBar * This);
        
        END_INTERFACE
    } IProgressBarVtbl;

    interface IProgressBar
    {
        CONST_VTBL struct IProgressBarVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProgressBar_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProgressBar_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProgressBar_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProgressBar_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProgressBar_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProgressBar_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProgressBar_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IProgressBar_get_ControlDefault(This,pfValue)	\
    (This)->lpVtbl -> get_ControlDefault(This,pfValue)

#define IProgressBar_put_ControlDefault(This,pfValue)	\
    (This)->lpVtbl -> put_ControlDefault(This,pfValue)

#define IProgressBar_get_Max(This,pfMax)	\
    (This)->lpVtbl -> get_Max(This,pfMax)

#define IProgressBar_put_Max(This,pfMax)	\
    (This)->lpVtbl -> put_Max(This,pfMax)

#define IProgressBar_get_Min(This,pfMin)	\
    (This)->lpVtbl -> get_Min(This,pfMin)

#define IProgressBar_put_Min(This,pfMin)	\
    (This)->lpVtbl -> put_Min(This,pfMin)

#define IProgressBar_get_MousePointer(This,pMousePointers)	\
    (This)->lpVtbl -> get_MousePointer(This,pMousePointers)

#define IProgressBar_put_MousePointer(This,pMousePointers)	\
    (This)->lpVtbl -> put_MousePointer(This,pMousePointers)

#define IProgressBar_get_MouseIcon(This,ppPictureDisp)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppPictureDisp)

#define IProgressBar_putref_MouseIcon(This,ppPictureDisp)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppPictureDisp)

#define IProgressBar_put_MouseIcon(This,ppPictureDisp)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppPictureDisp)

#define IProgressBar_get_Value(This,pfValue)	\
    (This)->lpVtbl -> get_Value(This,pfValue)

#define IProgressBar_put_Value(This,pfValue)	\
    (This)->lpVtbl -> put_Value(This,pfValue)

#define IProgressBar_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define IProgressBar_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define IProgressBar_get_Appearance(This,penumAppearances)	\
    (This)->lpVtbl -> get_Appearance(This,penumAppearances)

#define IProgressBar_put_Appearance(This,penumAppearances)	\
    (This)->lpVtbl -> put_Appearance(This,penumAppearances)

#define IProgressBar_get_BorderStyle(This,penumBorderStyles)	\
    (This)->lpVtbl -> get_BorderStyle(This,penumBorderStyles)

#define IProgressBar_put_BorderStyle(This,penumBorderStyles)	\
    (This)->lpVtbl -> put_BorderStyle(This,penumBorderStyles)

#define IProgressBar_get_Enabled(This,bEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,bEnabled)

#define IProgressBar_put_Enabled(This,bEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,bEnabled)

#define IProgressBar_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define IProgressBar_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define IProgressBar_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define IProgressBar_get_Orientation(This,penumOrientation)	\
    (This)->lpVtbl -> get_Orientation(This,penumOrientation)

#define IProgressBar_put_Orientation(This,penumOrientation)	\
    (This)->lpVtbl -> put_Orientation(This,penumOrientation)

#define IProgressBar_get_Scrolling(This,penumScrolling)	\
    (This)->lpVtbl -> get_Scrolling(This,penumScrolling)

#define IProgressBar_put_Scrolling(This,penumScrolling)	\
    (This)->lpVtbl -> put_Scrolling(This,penumScrolling)

#define IProgressBar_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_ControlDefault_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ single *pfValue);


void __RPC_STUB IProgressBar_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_ControlDefault_Proxy( 
    IProgressBar * This,
    /* [in] */ single pfValue);


void __RPC_STUB IProgressBar_put_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Max_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ single *pfMax);


void __RPC_STUB IProgressBar_get_Max_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Max_Proxy( 
    IProgressBar * This,
    /* [in] */ single pfMax);


void __RPC_STUB IProgressBar_put_Max_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Min_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ single *pfMin);


void __RPC_STUB IProgressBar_get_Min_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Min_Proxy( 
    IProgressBar * This,
    /* [in] */ single pfMin);


void __RPC_STUB IProgressBar_put_Min_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_MousePointer_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ MousePointerConstants *pMousePointers);


void __RPC_STUB IProgressBar_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_MousePointer_Proxy( 
    IProgressBar * This,
    /* [in] */ MousePointerConstants pMousePointers);


void __RPC_STUB IProgressBar_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_MouseIcon_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);


void __RPC_STUB IProgressBar_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_putref_MouseIcon_Proxy( 
    IProgressBar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);


void __RPC_STUB IProgressBar_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_MouseIcon_Proxy( 
    IProgressBar * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);


void __RPC_STUB IProgressBar_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Value_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ single *pfValue);


void __RPC_STUB IProgressBar_get_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Value_Proxy( 
    IProgressBar * This,
    /* [in] */ single pfValue);


void __RPC_STUB IProgressBar_put_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_OLEDropMode_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB IProgressBar_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_OLEDropMode_Proxy( 
    IProgressBar * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB IProgressBar_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Appearance_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ AppearanceConstants *penumAppearances);


void __RPC_STUB IProgressBar_get_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Appearance_Proxy( 
    IProgressBar * This,
    /* [in] */ AppearanceConstants penumAppearances);


void __RPC_STUB IProgressBar_put_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_BorderStyle_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ BorderStyleConstants *penumBorderStyles);


void __RPC_STUB IProgressBar_get_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_BorderStyle_Proxy( 
    IProgressBar * This,
    /* [in] */ BorderStyleConstants penumBorderStyles);


void __RPC_STUB IProgressBar_put_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Enabled_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ VARIANT_BOOL *bEnabled);


void __RPC_STUB IProgressBar_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Enabled_Proxy( 
    IProgressBar * This,
    /* [in] */ VARIANT_BOOL bEnabled);


void __RPC_STUB IProgressBar_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_hWnd_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB IProgressBar_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_OLEDrag_Proxy( 
    IProgressBar * This);


void __RPC_STUB IProgressBar_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_AboutBox_Proxy( 
    IProgressBar * This);


void __RPC_STUB IProgressBar_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Orientation_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ OrientationConstants *penumOrientation);


void __RPC_STUB IProgressBar_get_Orientation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Orientation_Proxy( 
    IProgressBar * This,
    /* [in] */ OrientationConstants penumOrientation);


void __RPC_STUB IProgressBar_put_Orientation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_get_Scrolling_Proxy( 
    IProgressBar * This,
    /* [retval][out] */ ScrollingConstants *penumScrolling);


void __RPC_STUB IProgressBar_get_Scrolling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IProgressBar_put_Scrolling_Proxy( 
    IProgressBar * This,
    /* [in] */ ScrollingConstants penumScrolling);


void __RPC_STUB IProgressBar_put_Scrolling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IProgressBar_Refresh_Proxy( 
    IProgressBar * This);


void __RPC_STUB IProgressBar_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IProgressBar_INTERFACE_DEFINED__ */


#ifndef __IProgressBarEvents_DISPINTERFACE_DEFINED__
#define __IProgressBarEvents_DISPINTERFACE_DEFINED__

/* dispinterface IProgressBarEvents */
/* [nonextensible][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_IProgressBarEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("35053A21-8589-11D1-B16A-00C0F0283628")
    IProgressBarEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct IProgressBarEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IProgressBarEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IProgressBarEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IProgressBarEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IProgressBarEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IProgressBarEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IProgressBarEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IProgressBarEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IProgressBarEventsVtbl;

    interface IProgressBarEvents
    {
        CONST_VTBL struct IProgressBarEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IProgressBarEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IProgressBarEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IProgressBarEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IProgressBarEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IProgressBarEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IProgressBarEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IProgressBarEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __IProgressBarEvents_DISPINTERFACE_DEFINED__ */


#ifndef __ITreeView_INTERFACE_DEFINED__
#define __ITreeView_INTERFACE_DEFINED__

/* interface ITreeView */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_ITreeView;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C74190B4-8589-11D1-B16A-00C0F0283628")
    ITreeView : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_DropHighlight( 
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_DropHighlight( 
            /* [in] */ INode *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_DropHighlight( 
            /* [in] */ VARIANT *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HideSelection( 
            /* [retval][out] */ VARIANT_BOOL *pbHideSelection) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HideSelection( 
            /* [in] */ VARIANT_BOOL pbHideSelection) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageList( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Indentation( 
            /* [retval][out] */ single *pfIndentation) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Indentation( 
            /* [in] */ single pfIndentation) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LabelEdit( 
            /* [retval][out] */ LabelEditConstants *psLabelEdit) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_LabelEdit( 
            /* [in] */ LabelEditConstants psLabelEdit) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LineStyle( 
            /* [retval][out] */ TreeLineStyleConstants *psLineStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_LineStyle( 
            /* [in] */ TreeLineStyleConstants psLineStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Nodes( 
            /* [retval][out] */ INodes **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Nodes( 
            /* [in] */ INodes *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_PathSeparator( 
            /* [retval][out] */ BSTR *pbstrPathSeparator) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_PathSeparator( 
            /* [in] */ BSTR pbstrPathSeparator) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectedItem( 
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_SelectedItem( 
            /* [in] */ INode *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectedItem( 
            /* [in] */ VARIANT *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Sorted( 
            /* [retval][out] */ VARIANT_BOOL *pbSorted) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Sorted( 
            /* [in] */ VARIANT_BOOL pbSorted) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ TreeStyleConstants *psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ TreeStyleConstants psStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDragMode( 
            /* [retval][out] */ OLEDragConstants *psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDragMode( 
            /* [in] */ OLEDragConstants psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Appearance( 
            /* [retval][out] */ AppearanceConstants *psAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Appearance( 
            /* [in] */ AppearanceConstants psAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BorderStyle( 
            /* [retval][out] */ BorderStyleConstants *psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BorderStyle( 
            /* [in] */ BorderStyleConstants psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Font( 
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE HitTest( 
            /* [in] */ single x,
            /* [in] */ single y,
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE GetVisibleCount( 
            /* [retval][out] */ long *plVisibleCount) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE StartLabelEdit( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Checkboxes( 
            /* [retval][out] */ VARIANT_BOOL *pbCheckboxes) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Checkboxes( 
            /* [in] */ VARIANT_BOOL pbCheckboxes) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_FullRowSelect( 
            /* [retval][out] */ VARIANT_BOOL *pbFullRowSelect) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_FullRowSelect( 
            /* [in] */ VARIANT_BOOL pbFullRowSelect) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HotTracking( 
            /* [retval][out] */ VARIANT_BOOL *pbHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HotTracking( 
            /* [in] */ VARIANT_BOOL pbHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Scroll( 
            /* [retval][out] */ VARIANT_BOOL *pbScroll) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Scroll( 
            /* [in] */ VARIANT_BOOL pbScroll) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SingleSel( 
            /* [retval][out] */ VARIANT_BOOL *pbSingleSel) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SingleSel( 
            /* [in] */ VARIANT_BOOL pbSingleSel) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ITreeViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITreeView * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITreeView * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITreeView * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITreeView * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITreeView * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITreeView * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITreeView * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_DropHighlight )( 
            ITreeView * This,
            /* [retval][out] */ INode **ppNode);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_DropHighlight )( 
            ITreeView * This,
            /* [in] */ INode *ppNode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_DropHighlight )( 
            ITreeView * This,
            /* [in] */ VARIANT *ppNode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HideSelection )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbHideSelection);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HideSelection )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbHideSelection);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageList )( 
            ITreeView * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ImageList )( 
            ITreeView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageList )( 
            ITreeView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Indentation )( 
            ITreeView * This,
            /* [retval][out] */ single *pfIndentation);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Indentation )( 
            ITreeView * This,
            /* [in] */ single pfIndentation);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LabelEdit )( 
            ITreeView * This,
            /* [retval][out] */ LabelEditConstants *psLabelEdit);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_LabelEdit )( 
            ITreeView * This,
            /* [in] */ LabelEditConstants psLabelEdit);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LineStyle )( 
            ITreeView * This,
            /* [retval][out] */ TreeLineStyleConstants *psLineStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_LineStyle )( 
            ITreeView * This,
            /* [in] */ TreeLineStyleConstants psLineStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            ITreeView * This,
            /* [retval][out] */ MousePointerConstants *psMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            ITreeView * This,
            /* [in] */ MousePointerConstants psMousePointer);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            ITreeView * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            ITreeView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            ITreeView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Nodes )( 
            ITreeView * This,
            /* [retval][out] */ INodes **ppNode);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Nodes )( 
            ITreeView * This,
            /* [in] */ INodes *ppNode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_PathSeparator )( 
            ITreeView * This,
            /* [retval][out] */ BSTR *pbstrPathSeparator);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_PathSeparator )( 
            ITreeView * This,
            /* [in] */ BSTR pbstrPathSeparator);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectedItem )( 
            ITreeView * This,
            /* [retval][out] */ INode **ppNode);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_SelectedItem )( 
            ITreeView * This,
            /* [in] */ INode *ppNode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectedItem )( 
            ITreeView * This,
            /* [in] */ VARIANT *ppNode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Sorted )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbSorted);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Sorted )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbSorted);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            ITreeView * This,
            /* [retval][out] */ TreeStyleConstants *psStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            ITreeView * This,
            /* [in] */ TreeStyleConstants psStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDragMode )( 
            ITreeView * This,
            /* [retval][out] */ OLEDragConstants *psOLEDragMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDragMode )( 
            ITreeView * This,
            /* [in] */ OLEDragConstants psOLEDragMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            ITreeView * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            ITreeView * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Appearance )( 
            ITreeView * This,
            /* [retval][out] */ AppearanceConstants *psAppearance);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Appearance )( 
            ITreeView * This,
            /* [in] */ AppearanceConstants psAppearance);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BorderStyle )( 
            ITreeView * This,
            /* [retval][out] */ BorderStyleConstants *psBorderStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BorderStyle )( 
            ITreeView * This,
            /* [in] */ BorderStyleConstants psBorderStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Font )( 
            ITreeView * This,
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Font )( 
            ITreeView * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFont);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Font )( 
            ITreeView * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFont);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            ITreeView * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            ITreeView * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HitTest )( 
            ITreeView * This,
            /* [in] */ single x,
            /* [in] */ single y,
            /* [retval][out] */ INode **ppNode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetVisibleCount )( 
            ITreeView * This,
            /* [retval][out] */ long *plVisibleCount);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StartLabelEdit )( 
            ITreeView * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            ITreeView * This);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            ITreeView * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            ITreeView * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Checkboxes )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbCheckboxes);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Checkboxes )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbCheckboxes);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_FullRowSelect )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbFullRowSelect);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_FullRowSelect )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbFullRowSelect);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HotTracking )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbHotTracking);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HotTracking )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbHotTracking);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Scroll )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbScroll);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Scroll )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbScroll);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SingleSel )( 
            ITreeView * This,
            /* [retval][out] */ VARIANT_BOOL *pbSingleSel);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SingleSel )( 
            ITreeView * This,
            /* [in] */ VARIANT_BOOL pbSingleSel);
        
        END_INTERFACE
    } ITreeViewVtbl;

    interface ITreeView
    {
        CONST_VTBL struct ITreeViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITreeView_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITreeView_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITreeView_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITreeView_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITreeView_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITreeView_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITreeView_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ITreeView_get_DropHighlight(This,ppNode)	\
    (This)->lpVtbl -> get_DropHighlight(This,ppNode)

#define ITreeView_putref_DropHighlight(This,ppNode)	\
    (This)->lpVtbl -> putref_DropHighlight(This,ppNode)

#define ITreeView_put_DropHighlight(This,ppNode)	\
    (This)->lpVtbl -> put_DropHighlight(This,ppNode)

#define ITreeView_get_HideSelection(This,pbHideSelection)	\
    (This)->lpVtbl -> get_HideSelection(This,pbHideSelection)

#define ITreeView_put_HideSelection(This,pbHideSelection)	\
    (This)->lpVtbl -> put_HideSelection(This,pbHideSelection)

#define ITreeView_get_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> get_ImageList(This,ppImageList)

#define ITreeView_putref_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> putref_ImageList(This,ppImageList)

#define ITreeView_put_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> put_ImageList(This,ppImageList)

#define ITreeView_get_Indentation(This,pfIndentation)	\
    (This)->lpVtbl -> get_Indentation(This,pfIndentation)

#define ITreeView_put_Indentation(This,pfIndentation)	\
    (This)->lpVtbl -> put_Indentation(This,pfIndentation)

#define ITreeView_get_LabelEdit(This,psLabelEdit)	\
    (This)->lpVtbl -> get_LabelEdit(This,psLabelEdit)

#define ITreeView_put_LabelEdit(This,psLabelEdit)	\
    (This)->lpVtbl -> put_LabelEdit(This,psLabelEdit)

#define ITreeView_get_LineStyle(This,psLineStyle)	\
    (This)->lpVtbl -> get_LineStyle(This,psLineStyle)

#define ITreeView_put_LineStyle(This,psLineStyle)	\
    (This)->lpVtbl -> put_LineStyle(This,psLineStyle)

#define ITreeView_get_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,psMousePointer)

#define ITreeView_put_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,psMousePointer)

#define ITreeView_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define ITreeView_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define ITreeView_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define ITreeView_get_Nodes(This,ppNode)	\
    (This)->lpVtbl -> get_Nodes(This,ppNode)

#define ITreeView_putref_Nodes(This,ppNode)	\
    (This)->lpVtbl -> putref_Nodes(This,ppNode)

#define ITreeView_get_PathSeparator(This,pbstrPathSeparator)	\
    (This)->lpVtbl -> get_PathSeparator(This,pbstrPathSeparator)

#define ITreeView_put_PathSeparator(This,pbstrPathSeparator)	\
    (This)->lpVtbl -> put_PathSeparator(This,pbstrPathSeparator)

#define ITreeView_get_SelectedItem(This,ppNode)	\
    (This)->lpVtbl -> get_SelectedItem(This,ppNode)

#define ITreeView_putref_SelectedItem(This,ppNode)	\
    (This)->lpVtbl -> putref_SelectedItem(This,ppNode)

#define ITreeView_put_SelectedItem(This,ppNode)	\
    (This)->lpVtbl -> put_SelectedItem(This,ppNode)

#define ITreeView_get_Sorted(This,pbSorted)	\
    (This)->lpVtbl -> get_Sorted(This,pbSorted)

#define ITreeView_put_Sorted(This,pbSorted)	\
    (This)->lpVtbl -> put_Sorted(This,pbSorted)

#define ITreeView_get_Style(This,psStyle)	\
    (This)->lpVtbl -> get_Style(This,psStyle)

#define ITreeView_put_Style(This,psStyle)	\
    (This)->lpVtbl -> put_Style(This,psStyle)

#define ITreeView_get_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> get_OLEDragMode(This,psOLEDragMode)

#define ITreeView_put_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> put_OLEDragMode(This,psOLEDragMode)

#define ITreeView_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define ITreeView_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define ITreeView_get_Appearance(This,psAppearance)	\
    (This)->lpVtbl -> get_Appearance(This,psAppearance)

#define ITreeView_put_Appearance(This,psAppearance)	\
    (This)->lpVtbl -> put_Appearance(This,psAppearance)

#define ITreeView_get_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> get_BorderStyle(This,psBorderStyle)

#define ITreeView_put_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> put_BorderStyle(This,psBorderStyle)

#define ITreeView_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define ITreeView_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define ITreeView_get_Font(This,ppFont)	\
    (This)->lpVtbl -> get_Font(This,ppFont)

#define ITreeView_put_Font(This,ppFont)	\
    (This)->lpVtbl -> put_Font(This,ppFont)

#define ITreeView_putref_Font(This,ppFont)	\
    (This)->lpVtbl -> putref_Font(This,ppFont)

#define ITreeView_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define ITreeView_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define ITreeView_HitTest(This,x,y,ppNode)	\
    (This)->lpVtbl -> HitTest(This,x,y,ppNode)

#define ITreeView_GetVisibleCount(This,plVisibleCount)	\
    (This)->lpVtbl -> GetVisibleCount(This,plVisibleCount)

#define ITreeView_StartLabelEdit(This)	\
    (This)->lpVtbl -> StartLabelEdit(This)

#define ITreeView_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define ITreeView_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define ITreeView_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define ITreeView_get_Checkboxes(This,pbCheckboxes)	\
    (This)->lpVtbl -> get_Checkboxes(This,pbCheckboxes)

#define ITreeView_put_Checkboxes(This,pbCheckboxes)	\
    (This)->lpVtbl -> put_Checkboxes(This,pbCheckboxes)

#define ITreeView_get_FullRowSelect(This,pbFullRowSelect)	\
    (This)->lpVtbl -> get_FullRowSelect(This,pbFullRowSelect)

#define ITreeView_put_FullRowSelect(This,pbFullRowSelect)	\
    (This)->lpVtbl -> put_FullRowSelect(This,pbFullRowSelect)

#define ITreeView_get_HotTracking(This,pbHotTracking)	\
    (This)->lpVtbl -> get_HotTracking(This,pbHotTracking)

#define ITreeView_put_HotTracking(This,pbHotTracking)	\
    (This)->lpVtbl -> put_HotTracking(This,pbHotTracking)

#define ITreeView_get_Scroll(This,pbScroll)	\
    (This)->lpVtbl -> get_Scroll(This,pbScroll)

#define ITreeView_put_Scroll(This,pbScroll)	\
    (This)->lpVtbl -> put_Scroll(This,pbScroll)

#define ITreeView_get_SingleSel(This,pbSingleSel)	\
    (This)->lpVtbl -> get_SingleSel(This,pbSingleSel)

#define ITreeView_put_SingleSel(This,pbSingleSel)	\
    (This)->lpVtbl -> put_SingleSel(This,pbSingleSel)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_DropHighlight_Proxy( 
    ITreeView * This,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB ITreeView_get_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_DropHighlight_Proxy( 
    ITreeView * This,
    /* [in] */ INode *ppNode);


void __RPC_STUB ITreeView_putref_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_DropHighlight_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT *ppNode);


void __RPC_STUB ITreeView_put_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_HideSelection_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbHideSelection);


void __RPC_STUB ITreeView_get_HideSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_HideSelection_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbHideSelection);


void __RPC_STUB ITreeView_put_HideSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_ImageList_Proxy( 
    ITreeView * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB ITreeView_get_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_ImageList_Proxy( 
    ITreeView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB ITreeView_putref_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_ImageList_Proxy( 
    ITreeView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB ITreeView_put_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Indentation_Proxy( 
    ITreeView * This,
    /* [retval][out] */ single *pfIndentation);


void __RPC_STUB ITreeView_get_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Indentation_Proxy( 
    ITreeView * This,
    /* [in] */ single pfIndentation);


void __RPC_STUB ITreeView_put_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_LabelEdit_Proxy( 
    ITreeView * This,
    /* [retval][out] */ LabelEditConstants *psLabelEdit);


void __RPC_STUB ITreeView_get_LabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_LabelEdit_Proxy( 
    ITreeView * This,
    /* [in] */ LabelEditConstants psLabelEdit);


void __RPC_STUB ITreeView_put_LabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_LineStyle_Proxy( 
    ITreeView * This,
    /* [retval][out] */ TreeLineStyleConstants *psLineStyle);


void __RPC_STUB ITreeView_get_LineStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_LineStyle_Proxy( 
    ITreeView * This,
    /* [in] */ TreeLineStyleConstants psLineStyle);


void __RPC_STUB ITreeView_put_LineStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_MousePointer_Proxy( 
    ITreeView * This,
    /* [retval][out] */ MousePointerConstants *psMousePointer);


void __RPC_STUB ITreeView_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_MousePointer_Proxy( 
    ITreeView * This,
    /* [in] */ MousePointerConstants psMousePointer);


void __RPC_STUB ITreeView_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_MouseIcon_Proxy( 
    ITreeView * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB ITreeView_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_MouseIcon_Proxy( 
    ITreeView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ITreeView_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_MouseIcon_Proxy( 
    ITreeView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ITreeView_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Nodes_Proxy( 
    ITreeView * This,
    /* [retval][out] */ INodes **ppNode);


void __RPC_STUB ITreeView_get_Nodes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_Nodes_Proxy( 
    ITreeView * This,
    /* [in] */ INodes *ppNode);


void __RPC_STUB ITreeView_putref_Nodes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_PathSeparator_Proxy( 
    ITreeView * This,
    /* [retval][out] */ BSTR *pbstrPathSeparator);


void __RPC_STUB ITreeView_get_PathSeparator_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_PathSeparator_Proxy( 
    ITreeView * This,
    /* [in] */ BSTR pbstrPathSeparator);


void __RPC_STUB ITreeView_put_PathSeparator_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_SelectedItem_Proxy( 
    ITreeView * This,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB ITreeView_get_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_SelectedItem_Proxy( 
    ITreeView * This,
    /* [in] */ INode *ppNode);


void __RPC_STUB ITreeView_putref_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_SelectedItem_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT *ppNode);


void __RPC_STUB ITreeView_put_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Sorted_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbSorted);


void __RPC_STUB ITreeView_get_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Sorted_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbSorted);


void __RPC_STUB ITreeView_put_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Style_Proxy( 
    ITreeView * This,
    /* [retval][out] */ TreeStyleConstants *psStyle);


void __RPC_STUB ITreeView_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Style_Proxy( 
    ITreeView * This,
    /* [in] */ TreeStyleConstants psStyle);


void __RPC_STUB ITreeView_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_OLEDragMode_Proxy( 
    ITreeView * This,
    /* [retval][out] */ OLEDragConstants *psOLEDragMode);


void __RPC_STUB ITreeView_get_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_OLEDragMode_Proxy( 
    ITreeView * This,
    /* [in] */ OLEDragConstants psOLEDragMode);


void __RPC_STUB ITreeView_put_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_OLEDropMode_Proxy( 
    ITreeView * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB ITreeView_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_OLEDropMode_Proxy( 
    ITreeView * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB ITreeView_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Appearance_Proxy( 
    ITreeView * This,
    /* [retval][out] */ AppearanceConstants *psAppearance);


void __RPC_STUB ITreeView_get_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Appearance_Proxy( 
    ITreeView * This,
    /* [in] */ AppearanceConstants psAppearance);


void __RPC_STUB ITreeView_put_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_BorderStyle_Proxy( 
    ITreeView * This,
    /* [retval][out] */ BorderStyleConstants *psBorderStyle);


void __RPC_STUB ITreeView_get_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_BorderStyle_Proxy( 
    ITreeView * This,
    /* [in] */ BorderStyleConstants psBorderStyle);


void __RPC_STUB ITreeView_put_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Enabled_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB ITreeView_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Enabled_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB ITreeView_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Font_Proxy( 
    ITreeView * This,
    /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);


void __RPC_STUB ITreeView_get_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Font_Proxy( 
    ITreeView * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFont);


void __RPC_STUB ITreeView_put_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ITreeView_putref_Font_Proxy( 
    ITreeView * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFont);


void __RPC_STUB ITreeView_putref_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_hWnd_Proxy( 
    ITreeView * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB ITreeView_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_hWnd_Proxy( 
    ITreeView * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB ITreeView_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITreeView_HitTest_Proxy( 
    ITreeView * This,
    /* [in] */ single x,
    /* [in] */ single y,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB ITreeView_HitTest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITreeView_GetVisibleCount_Proxy( 
    ITreeView * This,
    /* [retval][out] */ long *plVisibleCount);


void __RPC_STUB ITreeView_GetVisibleCount_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITreeView_StartLabelEdit_Proxy( 
    ITreeView * This);


void __RPC_STUB ITreeView_StartLabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITreeView_Refresh_Proxy( 
    ITreeView * This);


void __RPC_STUB ITreeView_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE ITreeView_AboutBox_Proxy( 
    ITreeView * This);


void __RPC_STUB ITreeView_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ITreeView_OLEDrag_Proxy( 
    ITreeView * This);


void __RPC_STUB ITreeView_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Checkboxes_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbCheckboxes);


void __RPC_STUB ITreeView_get_Checkboxes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Checkboxes_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbCheckboxes);


void __RPC_STUB ITreeView_put_Checkboxes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_FullRowSelect_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbFullRowSelect);


void __RPC_STUB ITreeView_get_FullRowSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_FullRowSelect_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbFullRowSelect);


void __RPC_STUB ITreeView_put_FullRowSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_HotTracking_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbHotTracking);


void __RPC_STUB ITreeView_get_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_HotTracking_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbHotTracking);


void __RPC_STUB ITreeView_put_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_Scroll_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbScroll);


void __RPC_STUB ITreeView_get_Scroll_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_Scroll_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbScroll);


void __RPC_STUB ITreeView_put_Scroll_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ITreeView_get_SingleSel_Proxy( 
    ITreeView * This,
    /* [retval][out] */ VARIANT_BOOL *pbSingleSel);


void __RPC_STUB ITreeView_get_SingleSel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ITreeView_put_SingleSel_Proxy( 
    ITreeView * This,
    /* [in] */ VARIANT_BOOL pbSingleSel);


void __RPC_STUB ITreeView_put_SingleSel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ITreeView_INTERFACE_DEFINED__ */


#ifndef __ITreeViewEvents_DISPINTERFACE_DEFINED__
#define __ITreeViewEvents_DISPINTERFACE_DEFINED__

/* dispinterface ITreeViewEvents */
/* [nonextensible][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_ITreeViewEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("C74190B5-8589-11D1-B16A-00C0F0283628")
    ITreeViewEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ITreeViewEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITreeViewEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITreeViewEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITreeViewEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITreeViewEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITreeViewEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITreeViewEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITreeViewEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ITreeViewEventsVtbl;

    interface ITreeViewEvents
    {
        CONST_VTBL struct ITreeViewEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITreeViewEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ITreeViewEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ITreeViewEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ITreeViewEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ITreeViewEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ITreeViewEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ITreeViewEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ITreeViewEvents_DISPINTERFACE_DEFINED__ */


#ifndef __INodes_INTERFACE_DEFINED__
#define __INodes_INTERFACE_DEFINED__

/* interface INodes */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_INodes;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C74190B7-8589-11D1-B16A-00C0F0283628")
    INodes : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *psCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short psCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ INode *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Relative,
            /* [optional][in] */ VARIANT *Relationship,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Image,
            /* [optional][in] */ VARIANT *SelectedImage,
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ INode **ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ INode *ppNode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct INodesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            INodes * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            INodes * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            INodes * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            INodes * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            INodes * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            INodes * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            INodes * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            INodes * This,
            /* [retval][out] */ short *psCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            INodes * This,
            /* [in] */ short psCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            INodes * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ INode **ppNode);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ControlDefault )( 
            INodes * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ INode *ppNode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            INodes * This,
            /* [optional][in] */ VARIANT *Relative,
            /* [optional][in] */ VARIANT *Relationship,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Image,
            /* [optional][in] */ VARIANT *SelectedImage,
            /* [retval][out] */ INode **ppNode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            INodes * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            INodes * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ INode **ppNode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Item )( 
            INodes * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ INode *ppNode);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            INodes * This,
            /* [in] */ VARIANT *Index);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            INodes * This,
            /* [retval][out] */ IDispatch **ppNewEnum);
        
        END_INTERFACE
    } INodesVtbl;

    interface INodes
    {
        CONST_VTBL struct INodesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define INodes_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define INodes_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define INodes_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define INodes_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define INodes_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define INodes_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define INodes_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define INodes_get_Count(This,psCount)	\
    (This)->lpVtbl -> get_Count(This,psCount)

#define INodes_put_Count(This,psCount)	\
    (This)->lpVtbl -> put_Count(This,psCount)

#define INodes_get_ControlDefault(This,Index,ppNode)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppNode)

#define INodes_put_ControlDefault(This,Index,ppNode)	\
    (This)->lpVtbl -> put_ControlDefault(This,Index,ppNode)

#define INodes_Add(This,Relative,Relationship,Key,Text,Image,SelectedImage,ppNode)	\
    (This)->lpVtbl -> Add(This,Relative,Relationship,Key,Text,Image,SelectedImage,ppNode)

#define INodes_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define INodes_get_Item(This,Index,ppNode)	\
    (This)->lpVtbl -> get_Item(This,Index,ppNode)

#define INodes_put_Item(This,Index,ppNode)	\
    (This)->lpVtbl -> put_Item(This,Index,ppNode)

#define INodes_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define INodes__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INodes_get_Count_Proxy( 
    INodes * This,
    /* [retval][out] */ short *psCount);


void __RPC_STUB INodes_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INodes_put_Count_Proxy( 
    INodes * This,
    /* [in] */ short psCount);


void __RPC_STUB INodes_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE INodes_get_ControlDefault_Proxy( 
    INodes * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB INodes_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE INodes_put_ControlDefault_Proxy( 
    INodes * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ INode *ppNode);


void __RPC_STUB INodes_put_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE INodes_Add_Proxy( 
    INodes * This,
    /* [optional][in] */ VARIANT *Relative,
    /* [optional][in] */ VARIANT *Relationship,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Image,
    /* [optional][in] */ VARIANT *SelectedImage,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB INodes_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE INodes_Clear_Proxy( 
    INodes * This);


void __RPC_STUB INodes_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INodes_get_Item_Proxy( 
    INodes * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ INode **ppNode);


void __RPC_STUB INodes_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INodes_put_Item_Proxy( 
    INodes * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ INode *ppNode);


void __RPC_STUB INodes_put_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE INodes_Remove_Proxy( 
    INodes * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB INodes_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE INodes__NewEnum_Proxy( 
    INodes * This,
    /* [retval][out] */ IDispatch **ppNewEnum);


void __RPC_STUB INodes__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __INodes_INTERFACE_DEFINED__ */


#ifndef __INode_INTERFACE_DEFINED__
#define __INode_INTERFACE_DEFINED__

/* interface INode */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_INode;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C74190B8-8589-11D1-B16A-00C0F0283628")
    INode : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Child( 
            /* [retval][out] */ INode **ppChild) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Child( 
            /* [in] */ INode *ppChild) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Children( 
            /* [retval][out] */ short *psChildren) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Children( 
            /* [in] */ short psChildren) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Expanded( 
            /* [retval][out] */ VARIANT_BOOL *pbExpanded) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Expanded( 
            /* [in] */ VARIANT_BOOL pbExpanded) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ExpandedImage( 
            /* [retval][out] */ VARIANT *pExpandedImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ExpandedImage( 
            /* [in] */ VARIANT pExpandedImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_FirstSibling( 
            /* [retval][out] */ INode **ppFirstSibling) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_FirstSibling( 
            /* [in] */ INode *ppFirstSibling) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_FullPath( 
            /* [retval][out] */ BSTR *pbstrFullPath) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_FullPath( 
            /* [in] */ BSTR pbstrFullPath) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Image( 
            /* [retval][out] */ VARIANT *pImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Image( 
            /* [in] */ VARIANT pImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LastSibling( 
            /* [retval][out] */ INode **ppLastSibling) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_LastSibling( 
            /* [in] */ INode *ppLastSibling) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Next( 
            /* [retval][out] */ INode **ppNext) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Next( 
            /* [in] */ INode *ppNext) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Parent( 
            /* [retval][out] */ INode **ppParent) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Parent( 
            /* [in] */ INode *ppParent) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Previous( 
            /* [retval][out] */ INode **ppPrevious) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Previous( 
            /* [in] */ INode *ppPrevious) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Root( 
            /* [retval][out] */ INode **ppRoot) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Root( 
            /* [in] */ INode *ppRoot) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Selected( 
            /* [retval][out] */ VARIANT_BOOL *pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Selected( 
            /* [in] */ VARIANT_BOOL pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectedImage( 
            /* [retval][out] */ VARIANT *pSelectedImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectedImage( 
            /* [in] */ VARIANT pSelectedImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Sorted( 
            /* [retval][out] */ VARIANT_BOOL *pbSorted) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Sorted( 
            /* [in] */ VARIANT_BOOL pbSorted) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *bstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR bstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Visible( 
            /* [retval][out] */ VARIANT_BOOL *pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Visible( 
            /* [in] */ VARIANT_BOOL pbVisible) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE CreateDragImage( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppDragImage) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE EnsureVisible( 
            /* [retval][out] */ VARIANT_BOOL *pbEnsureVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BackColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BackColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Bold( 
            /* [retval][out] */ VARIANT_BOOL *pbBold) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Bold( 
            /* [in] */ VARIANT_BOOL pbBold) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Checked( 
            /* [retval][out] */ VARIANT_BOOL *pbChecked) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Checked( 
            /* [in] */ VARIANT_BOOL pbChecked) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ForeColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ForeColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct INodeVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            INode * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            INode * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            INode * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            INode * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            INode * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            INode * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            INode * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            INode * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            INode * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Child )( 
            INode * This,
            /* [retval][out] */ INode **ppChild);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Child )( 
            INode * This,
            /* [in] */ INode *ppChild);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Children )( 
            INode * This,
            /* [retval][out] */ short *psChildren);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Children )( 
            INode * This,
            /* [in] */ short psChildren);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Expanded )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbExpanded);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Expanded )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbExpanded);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ExpandedImage )( 
            INode * This,
            /* [retval][out] */ VARIANT *pExpandedImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ExpandedImage )( 
            INode * This,
            /* [in] */ VARIANT pExpandedImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_FirstSibling )( 
            INode * This,
            /* [retval][out] */ INode **ppFirstSibling);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_FirstSibling )( 
            INode * This,
            /* [in] */ INode *ppFirstSibling);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_FullPath )( 
            INode * This,
            /* [retval][out] */ BSTR *pbstrFullPath);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_FullPath )( 
            INode * This,
            /* [in] */ BSTR pbstrFullPath);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Image )( 
            INode * This,
            /* [retval][out] */ VARIANT *pImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Image )( 
            INode * This,
            /* [in] */ VARIANT pImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            INode * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            INode * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            INode * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            INode * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LastSibling )( 
            INode * This,
            /* [retval][out] */ INode **ppLastSibling);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_LastSibling )( 
            INode * This,
            /* [in] */ INode *ppLastSibling);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Next )( 
            INode * This,
            /* [retval][out] */ INode **ppNext);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Next )( 
            INode * This,
            /* [in] */ INode *ppNext);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Parent )( 
            INode * This,
            /* [retval][out] */ INode **ppParent);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Parent )( 
            INode * This,
            /* [in] */ INode *ppParent);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Previous )( 
            INode * This,
            /* [retval][out] */ INode **ppPrevious);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Previous )( 
            INode * This,
            /* [in] */ INode *ppPrevious);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Root )( 
            INode * This,
            /* [retval][out] */ INode **ppRoot);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Root )( 
            INode * This,
            /* [in] */ INode *ppRoot);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Selected )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbSelected);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Selected )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbSelected);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectedImage )( 
            INode * This,
            /* [retval][out] */ VARIANT *pSelectedImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectedImage )( 
            INode * This,
            /* [in] */ VARIANT pSelectedImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Sorted )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbSorted);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Sorted )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbSorted);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            INode * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            INode * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            INode * This,
            /* [retval][out] */ BSTR *bstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            INode * This,
            /* [in] */ BSTR bstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Visible )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbVisible);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Visible )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbVisible);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CreateDragImage )( 
            INode * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppDragImage);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EnsureVisible )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnsureVisible);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BackColor )( 
            INode * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BackColor )( 
            INode * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Bold )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbBold);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Bold )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbBold);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Checked )( 
            INode * This,
            /* [retval][out] */ VARIANT_BOOL *pbChecked);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Checked )( 
            INode * This,
            /* [in] */ VARIANT_BOOL pbChecked);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ForeColor )( 
            INode * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ForeColor )( 
            INode * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            INode * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } INodeVtbl;

    interface INode
    {
        CONST_VTBL struct INodeVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define INode_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define INode_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define INode_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define INode_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define INode_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define INode_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define INode_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define INode_get__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstrText)

#define INode_put__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstrText)

#define INode_get_Child(This,ppChild)	\
    (This)->lpVtbl -> get_Child(This,ppChild)

#define INode_putref_Child(This,ppChild)	\
    (This)->lpVtbl -> putref_Child(This,ppChild)

#define INode_get_Children(This,psChildren)	\
    (This)->lpVtbl -> get_Children(This,psChildren)

#define INode_put_Children(This,psChildren)	\
    (This)->lpVtbl -> put_Children(This,psChildren)

#define INode_get_Expanded(This,pbExpanded)	\
    (This)->lpVtbl -> get_Expanded(This,pbExpanded)

#define INode_put_Expanded(This,pbExpanded)	\
    (This)->lpVtbl -> put_Expanded(This,pbExpanded)

#define INode_get_ExpandedImage(This,pExpandedImage)	\
    (This)->lpVtbl -> get_ExpandedImage(This,pExpandedImage)

#define INode_put_ExpandedImage(This,pExpandedImage)	\
    (This)->lpVtbl -> put_ExpandedImage(This,pExpandedImage)

#define INode_get_FirstSibling(This,ppFirstSibling)	\
    (This)->lpVtbl -> get_FirstSibling(This,ppFirstSibling)

#define INode_putref_FirstSibling(This,ppFirstSibling)	\
    (This)->lpVtbl -> putref_FirstSibling(This,ppFirstSibling)

#define INode_get_FullPath(This,pbstrFullPath)	\
    (This)->lpVtbl -> get_FullPath(This,pbstrFullPath)

#define INode_put_FullPath(This,pbstrFullPath)	\
    (This)->lpVtbl -> put_FullPath(This,pbstrFullPath)

#define INode_get_Image(This,pImage)	\
    (This)->lpVtbl -> get_Image(This,pImage)

#define INode_put_Image(This,pImage)	\
    (This)->lpVtbl -> put_Image(This,pImage)

#define INode_get_Index(This,psIndex)	\
    (This)->lpVtbl -> get_Index(This,psIndex)

#define INode_put_Index(This,psIndex)	\
    (This)->lpVtbl -> put_Index(This,psIndex)

#define INode_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define INode_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define INode_get_LastSibling(This,ppLastSibling)	\
    (This)->lpVtbl -> get_LastSibling(This,ppLastSibling)

#define INode_putref_LastSibling(This,ppLastSibling)	\
    (This)->lpVtbl -> putref_LastSibling(This,ppLastSibling)

#define INode_get_Next(This,ppNext)	\
    (This)->lpVtbl -> get_Next(This,ppNext)

#define INode_putref_Next(This,ppNext)	\
    (This)->lpVtbl -> putref_Next(This,ppNext)

#define INode_get_Parent(This,ppParent)	\
    (This)->lpVtbl -> get_Parent(This,ppParent)

#define INode_putref_Parent(This,ppParent)	\
    (This)->lpVtbl -> putref_Parent(This,ppParent)

#define INode_get_Previous(This,ppPrevious)	\
    (This)->lpVtbl -> get_Previous(This,ppPrevious)

#define INode_putref_Previous(This,ppPrevious)	\
    (This)->lpVtbl -> putref_Previous(This,ppPrevious)

#define INode_get_Root(This,ppRoot)	\
    (This)->lpVtbl -> get_Root(This,ppRoot)

#define INode_putref_Root(This,ppRoot)	\
    (This)->lpVtbl -> putref_Root(This,ppRoot)

#define INode_get_Selected(This,pbSelected)	\
    (This)->lpVtbl -> get_Selected(This,pbSelected)

#define INode_put_Selected(This,pbSelected)	\
    (This)->lpVtbl -> put_Selected(This,pbSelected)

#define INode_get_SelectedImage(This,pSelectedImage)	\
    (This)->lpVtbl -> get_SelectedImage(This,pSelectedImage)

#define INode_put_SelectedImage(This,pSelectedImage)	\
    (This)->lpVtbl -> put_SelectedImage(This,pSelectedImage)

#define INode_get_Sorted(This,pbSorted)	\
    (This)->lpVtbl -> get_Sorted(This,pbSorted)

#define INode_put_Sorted(This,pbSorted)	\
    (This)->lpVtbl -> put_Sorted(This,pbSorted)

#define INode_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define INode_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define INode_get_Text(This,bstrText)	\
    (This)->lpVtbl -> get_Text(This,bstrText)

#define INode_put_Text(This,bstrText)	\
    (This)->lpVtbl -> put_Text(This,bstrText)

#define INode_get_Visible(This,pbVisible)	\
    (This)->lpVtbl -> get_Visible(This,pbVisible)

#define INode_put_Visible(This,pbVisible)	\
    (This)->lpVtbl -> put_Visible(This,pbVisible)

#define INode_CreateDragImage(This,ppDragImage)	\
    (This)->lpVtbl -> CreateDragImage(This,ppDragImage)

#define INode_EnsureVisible(This,pbEnsureVisible)	\
    (This)->lpVtbl -> EnsureVisible(This,pbEnsureVisible)

#define INode_get_BackColor(This,pocBackColor)	\
    (This)->lpVtbl -> get_BackColor(This,pocBackColor)

#define INode_put_BackColor(This,pocBackColor)	\
    (This)->lpVtbl -> put_BackColor(This,pocBackColor)

#define INode_get_Bold(This,pbBold)	\
    (This)->lpVtbl -> get_Bold(This,pbBold)

#define INode_put_Bold(This,pbBold)	\
    (This)->lpVtbl -> put_Bold(This,pbBold)

#define INode_get_Checked(This,pbChecked)	\
    (This)->lpVtbl -> get_Checked(This,pbChecked)

#define INode_put_Checked(This,pbChecked)	\
    (This)->lpVtbl -> put_Checked(This,pbChecked)

#define INode_get_ForeColor(This,pocForeColor)	\
    (This)->lpVtbl -> get_ForeColor(This,pocForeColor)

#define INode_put_ForeColor(This,pocForeColor)	\
    (This)->lpVtbl -> put_ForeColor(This,pocForeColor)

#define INode_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get__ObjectDefault_Proxy( 
    INode * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB INode_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put__ObjectDefault_Proxy( 
    INode * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB INode_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Child_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppChild);


void __RPC_STUB INode_get_Child_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Child_Proxy( 
    INode * This,
    /* [in] */ INode *ppChild);


void __RPC_STUB INode_putref_Child_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Children_Proxy( 
    INode * This,
    /* [retval][out] */ short *psChildren);


void __RPC_STUB INode_get_Children_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Children_Proxy( 
    INode * This,
    /* [in] */ short psChildren);


void __RPC_STUB INode_put_Children_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Expanded_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbExpanded);


void __RPC_STUB INode_get_Expanded_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Expanded_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbExpanded);


void __RPC_STUB INode_put_Expanded_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_ExpandedImage_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT *pExpandedImage);


void __RPC_STUB INode_get_ExpandedImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_ExpandedImage_Proxy( 
    INode * This,
    /* [in] */ VARIANT pExpandedImage);


void __RPC_STUB INode_put_ExpandedImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_FirstSibling_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppFirstSibling);


void __RPC_STUB INode_get_FirstSibling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_FirstSibling_Proxy( 
    INode * This,
    /* [in] */ INode *ppFirstSibling);


void __RPC_STUB INode_putref_FirstSibling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_FullPath_Proxy( 
    INode * This,
    /* [retval][out] */ BSTR *pbstrFullPath);


void __RPC_STUB INode_get_FullPath_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_FullPath_Proxy( 
    INode * This,
    /* [in] */ BSTR pbstrFullPath);


void __RPC_STUB INode_put_FullPath_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Image_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT *pImage);


void __RPC_STUB INode_get_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Image_Proxy( 
    INode * This,
    /* [in] */ VARIANT pImage);


void __RPC_STUB INode_put_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Index_Proxy( 
    INode * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB INode_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Index_Proxy( 
    INode * This,
    /* [in] */ short psIndex);


void __RPC_STUB INode_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Key_Proxy( 
    INode * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB INode_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Key_Proxy( 
    INode * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB INode_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_LastSibling_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppLastSibling);


void __RPC_STUB INode_get_LastSibling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_LastSibling_Proxy( 
    INode * This,
    /* [in] */ INode *ppLastSibling);


void __RPC_STUB INode_putref_LastSibling_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Next_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppNext);


void __RPC_STUB INode_get_Next_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Next_Proxy( 
    INode * This,
    /* [in] */ INode *ppNext);


void __RPC_STUB INode_putref_Next_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Parent_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppParent);


void __RPC_STUB INode_get_Parent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Parent_Proxy( 
    INode * This,
    /* [in] */ INode *ppParent);


void __RPC_STUB INode_putref_Parent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Previous_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppPrevious);


void __RPC_STUB INode_get_Previous_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Previous_Proxy( 
    INode * This,
    /* [in] */ INode *ppPrevious);


void __RPC_STUB INode_putref_Previous_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Root_Proxy( 
    INode * This,
    /* [retval][out] */ INode **ppRoot);


void __RPC_STUB INode_get_Root_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Root_Proxy( 
    INode * This,
    /* [in] */ INode *ppRoot);


void __RPC_STUB INode_putref_Root_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Selected_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbSelected);


void __RPC_STUB INode_get_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Selected_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbSelected);


void __RPC_STUB INode_put_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_SelectedImage_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT *pSelectedImage);


void __RPC_STUB INode_get_SelectedImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_SelectedImage_Proxy( 
    INode * This,
    /* [in] */ VARIANT pSelectedImage);


void __RPC_STUB INode_put_SelectedImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Sorted_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbSorted);


void __RPC_STUB INode_get_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Sorted_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbSorted);


void __RPC_STUB INode_put_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Tag_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB INode_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Tag_Proxy( 
    INode * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB INode_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Text_Proxy( 
    INode * This,
    /* [retval][out] */ BSTR *bstrText);


void __RPC_STUB INode_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Text_Proxy( 
    INode * This,
    /* [in] */ BSTR bstrText);


void __RPC_STUB INode_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Visible_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbVisible);


void __RPC_STUB INode_get_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Visible_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbVisible);


void __RPC_STUB INode_put_Visible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE INode_CreateDragImage_Proxy( 
    INode * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppDragImage);


void __RPC_STUB INode_CreateDragImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE INode_EnsureVisible_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnsureVisible);


void __RPC_STUB INode_EnsureVisible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_BackColor_Proxy( 
    INode * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor);


void __RPC_STUB INode_get_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_BackColor_Proxy( 
    INode * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor);


void __RPC_STUB INode_put_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Bold_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbBold);


void __RPC_STUB INode_get_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Bold_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbBold);


void __RPC_STUB INode_put_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_Checked_Proxy( 
    INode * This,
    /* [retval][out] */ VARIANT_BOOL *pbChecked);


void __RPC_STUB INode_get_Checked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_Checked_Proxy( 
    INode * This,
    /* [in] */ VARIANT_BOOL pbChecked);


void __RPC_STUB INode_put_Checked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE INode_get_ForeColor_Proxy( 
    INode * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor);


void __RPC_STUB INode_get_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE INode_put_ForeColor_Proxy( 
    INode * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor);


void __RPC_STUB INode_put_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE INode_putref_Tag_Proxy( 
    INode * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB INode_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __INode_INTERFACE_DEFINED__ */


#ifndef __IListView_INTERFACE_DEFINED__
#define __IListView_INTERFACE_DEFINED__

/* interface IListView */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IListView;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F049-858B-11D1-B16A-00C0F0283628")
    IListView : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Arrange( 
            /* [retval][out] */ ListArrangeConstants *pArrange) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Arrange( 
            /* [in] */ ListArrangeConstants pArrange) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ColumnHeaders( 
            /* [retval][out] */ IColumnHeaders **ppIColumnHeaders) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ColumnHeaders( 
            /* [in] */ IColumnHeaders *ppIColumnHeaders) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_DropHighlight( 
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_DropHighlight( 
            /* [in] */ IListItem *ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_DropHighlight( 
            /* [in] */ VARIANT *ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HideColumnHeaders( 
            /* [retval][out] */ VARIANT_BOOL *pfHide) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HideColumnHeaders( 
            /* [in] */ VARIANT_BOOL pfHide) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HideSelection( 
            /* [retval][out] */ VARIANT_BOOL *pfHide) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HideSelection( 
            /* [in] */ VARIANT_BOOL pfHide) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Icons( 
            /* [retval][out] */ IDispatch **ppIcons) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Icons( 
            /* [in] */ IDispatch *ppIcons) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Icons( 
            /* [in] */ IDispatch *ppIcons) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ListItems( 
            /* [retval][out] */ IListItems **ppListItems) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ListItems( 
            /* [in] */ IListItems *ppListItems) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LabelEdit( 
            /* [retval][out] */ ListLabelEditConstants *pRet) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_LabelEdit( 
            /* [in] */ ListLabelEditConstants pRet) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LabelWrap( 
            /* [retval][out] */ VARIANT_BOOL *pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_LabelWrap( 
            /* [in] */ VARIANT_BOOL pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MultiSelect( 
            /* [retval][out] */ VARIANT_BOOL *pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MultiSelect( 
            /* [in] */ VARIANT_BOOL pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectedItem( 
            /* [retval][out] */ IListItem **ppListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_SelectedItem( 
            /* [in] */ IListItem *ppListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectedItem( 
            /* [in] */ VARIANT *ppListItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SmallIcons( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_SmallIcons( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SmallIcons( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Sorted( 
            /* [retval][out] */ VARIANT_BOOL *pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Sorted( 
            /* [in] */ VARIANT_BOOL pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SortKey( 
            /* [retval][out] */ short *psKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SortKey( 
            /* [in] */ short psKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SortOrder( 
            /* [retval][out] */ ListSortOrderConstants *pOrder) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SortOrder( 
            /* [in] */ ListSortOrderConstants pOrder) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_View( 
            /* [retval][out] */ ListViewConstants *pnView) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_View( 
            /* [in] */ ListViewConstants pnView) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDragMode( 
            /* [retval][out] */ OLEDragConstants *psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDragMode( 
            /* [in] */ OLEDragConstants psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Appearance( 
            /* [retval][out] */ AppearanceConstants *pnAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Appearance( 
            /* [in] */ AppearanceConstants pnAppearance) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BackColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrBack) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BackColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pcrBack) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BorderStyle( 
            /* [retval][out] */ BorderStyleConstants *pnStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BorderStyle( 
            /* [in] */ BorderStyleConstants pnStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pfEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pfEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Font( 
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ForeColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ForeColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE FindItem( 
            /* [in] */ BSTR sz,
            /* [optional][in] */ VARIANT *Where,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *fPartial,
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE GetFirstVisible( 
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE HitTest( 
            /* [in] */ single x,
            /* [in] */ single y,
            /* [retval][out] */ IListItem **ppListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE StartLabelEdit( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [hidden][id] */ void STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_AllowColumnReorder( 
            /* [retval][out] */ VARIANT_BOOL *pfAllowColumnReorder) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_AllowColumnReorder( 
            /* [in] */ VARIANT_BOOL pfAllowColumnReorder) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Checkboxes( 
            /* [retval][out] */ VARIANT_BOOL *pfCheckboxes) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Checkboxes( 
            /* [in] */ VARIANT_BOOL pfCheckboxes) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_FlatScrollBar( 
            /* [retval][out] */ VARIANT_BOOL *pfFlatScrollBar) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_FlatScrollBar( 
            /* [in] */ VARIANT_BOOL pfFlatScrollBar) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_FullRowSelect( 
            /* [retval][out] */ VARIANT_BOOL *pfFullRowSelect) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_FullRowSelect( 
            /* [in] */ VARIANT_BOOL pfFullRowSelect) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_GridLines( 
            /* [retval][out] */ VARIANT_BOOL *pfGridLines) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_GridLines( 
            /* [in] */ VARIANT_BOOL pfGridLines) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HotTracking( 
            /* [retval][out] */ VARIANT_BOOL *pfHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HotTracking( 
            /* [in] */ VARIANT_BOOL pfHotTracking) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_HoverSelection( 
            /* [retval][out] */ VARIANT_BOOL *pfHoverSelection) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_HoverSelection( 
            /* [in] */ VARIANT_BOOL pfHoverSelection) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Picture( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Picture( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Picture( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_PictureAlignment( 
            /* [retval][out] */ ListPictureAlignmentConstants *psAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_PictureAlignment( 
            /* [in] */ ListPictureAlignmentConstants psAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ColumnHeaderIcons( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ColumnHeaderIcons( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ColumnHeaderIcons( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TextBackground( 
            /* [retval][out] */ ListTextBackgroundConstants *penumTextBackground) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TextBackground( 
            /* [in] */ ListTextBackgroundConstants penumTextBackground) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IListViewVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IListView * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IListView * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IListView * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IListView * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IListView * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IListView * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IListView * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Arrange )( 
            IListView * This,
            /* [retval][out] */ ListArrangeConstants *pArrange);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Arrange )( 
            IListView * This,
            /* [in] */ ListArrangeConstants pArrange);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ColumnHeaders )( 
            IListView * This,
            /* [retval][out] */ IColumnHeaders **ppIColumnHeaders);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ColumnHeaders )( 
            IListView * This,
            /* [in] */ IColumnHeaders *ppIColumnHeaders);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_DropHighlight )( 
            IListView * This,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_DropHighlight )( 
            IListView * This,
            /* [in] */ IListItem *ppIListItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_DropHighlight )( 
            IListView * This,
            /* [in] */ VARIANT *ppIListItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HideColumnHeaders )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfHide);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HideColumnHeaders )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfHide);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HideSelection )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfHide);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HideSelection )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfHide);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Icons )( 
            IListView * This,
            /* [retval][out] */ IDispatch **ppIcons);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Icons )( 
            IListView * This,
            /* [in] */ IDispatch *ppIcons);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Icons )( 
            IListView * This,
            /* [in] */ IDispatch *ppIcons);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ListItems )( 
            IListView * This,
            /* [retval][out] */ IListItems **ppListItems);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ListItems )( 
            IListView * This,
            /* [in] */ IListItems *ppListItems);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LabelEdit )( 
            IListView * This,
            /* [retval][out] */ ListLabelEditConstants *pRet);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_LabelEdit )( 
            IListView * This,
            /* [in] */ ListLabelEditConstants pRet);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LabelWrap )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfOn);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_LabelWrap )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfOn);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            IListView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            IListView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            IListView * This,
            /* [retval][out] */ MousePointerConstants *pnIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            IListView * This,
            /* [in] */ MousePointerConstants pnIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MultiSelect )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfOn);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MultiSelect )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfOn);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectedItem )( 
            IListView * This,
            /* [retval][out] */ IListItem **ppListItem);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_SelectedItem )( 
            IListView * This,
            /* [in] */ IListItem *ppListItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectedItem )( 
            IListView * This,
            /* [in] */ VARIANT *ppListItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SmallIcons )( 
            IListView * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_SmallIcons )( 
            IListView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SmallIcons )( 
            IListView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Sorted )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfOn);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Sorted )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfOn);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SortKey )( 
            IListView * This,
            /* [retval][out] */ short *psKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SortKey )( 
            IListView * This,
            /* [in] */ short psKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SortOrder )( 
            IListView * This,
            /* [retval][out] */ ListSortOrderConstants *pOrder);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SortOrder )( 
            IListView * This,
            /* [in] */ ListSortOrderConstants pOrder);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_View )( 
            IListView * This,
            /* [retval][out] */ ListViewConstants *pnView);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_View )( 
            IListView * This,
            /* [in] */ ListViewConstants pnView);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDragMode )( 
            IListView * This,
            /* [retval][out] */ OLEDragConstants *psOLEDragMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDragMode )( 
            IListView * This,
            /* [in] */ OLEDragConstants psOLEDragMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            IListView * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            IListView * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Appearance )( 
            IListView * This,
            /* [retval][out] */ AppearanceConstants *pnAppearance);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Appearance )( 
            IListView * This,
            /* [in] */ AppearanceConstants pnAppearance);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BackColor )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrBack);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BackColor )( 
            IListView * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pcrBack);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BorderStyle )( 
            IListView * This,
            /* [retval][out] */ BorderStyleConstants *pnStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BorderStyle )( 
            IListView * This,
            /* [in] */ BorderStyleConstants pnStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Font )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Font )( 
            IListView * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ForeColor )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ForeColor )( 
            IListView * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            IListView * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *FindItem )( 
            IListView * This,
            /* [in] */ BSTR sz,
            /* [optional][in] */ VARIANT *Where,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *fPartial,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetFirstVisible )( 
            IListView * This,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HitTest )( 
            IListView * This,
            /* [in] */ single x,
            /* [in] */ single y,
            /* [retval][out] */ IListItem **ppListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *StartLabelEdit )( 
            IListView * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            IListView * This);
        
        /* [helpcontext][helpstring][id] */ void ( STDMETHODCALLTYPE *Refresh )( 
            IListView * This);
        
        /* [hidden][id] */ void ( STDMETHODCALLTYPE *AboutBox )( 
            IListView * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_AllowColumnReorder )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfAllowColumnReorder);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_AllowColumnReorder )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfAllowColumnReorder);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Checkboxes )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfCheckboxes);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Checkboxes )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfCheckboxes);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_FlatScrollBar )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfFlatScrollBar);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_FlatScrollBar )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfFlatScrollBar);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_FullRowSelect )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfFullRowSelect);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_FullRowSelect )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfFullRowSelect);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_GridLines )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfGridLines);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_GridLines )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfGridLines);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HotTracking )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfHotTracking);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HotTracking )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfHotTracking);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_HoverSelection )( 
            IListView * This,
            /* [retval][out] */ VARIANT_BOOL *pfHoverSelection);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_HoverSelection )( 
            IListView * This,
            /* [in] */ VARIANT_BOOL pfHoverSelection);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Picture )( 
            IListView * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Picture )( 
            IListView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Picture )( 
            IListView * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_PictureAlignment )( 
            IListView * This,
            /* [retval][out] */ ListPictureAlignmentConstants *psAlignment);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_PictureAlignment )( 
            IListView * This,
            /* [in] */ ListPictureAlignmentConstants psAlignment);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ColumnHeaderIcons )( 
            IListView * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ColumnHeaderIcons )( 
            IListView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ColumnHeaderIcons )( 
            IListView * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TextBackground )( 
            IListView * This,
            /* [retval][out] */ ListTextBackgroundConstants *penumTextBackground);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TextBackground )( 
            IListView * This,
            /* [in] */ ListTextBackgroundConstants penumTextBackground);
        
        END_INTERFACE
    } IListViewVtbl;

    interface IListView
    {
        CONST_VTBL struct IListViewVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IListView_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IListView_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IListView_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IListView_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IListView_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IListView_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IListView_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IListView_get_Arrange(This,pArrange)	\
    (This)->lpVtbl -> get_Arrange(This,pArrange)

#define IListView_put_Arrange(This,pArrange)	\
    (This)->lpVtbl -> put_Arrange(This,pArrange)

#define IListView_get_ColumnHeaders(This,ppIColumnHeaders)	\
    (This)->lpVtbl -> get_ColumnHeaders(This,ppIColumnHeaders)

#define IListView_put_ColumnHeaders(This,ppIColumnHeaders)	\
    (This)->lpVtbl -> put_ColumnHeaders(This,ppIColumnHeaders)

#define IListView_get_DropHighlight(This,ppIListItem)	\
    (This)->lpVtbl -> get_DropHighlight(This,ppIListItem)

#define IListView_putref_DropHighlight(This,ppIListItem)	\
    (This)->lpVtbl -> putref_DropHighlight(This,ppIListItem)

#define IListView_put_DropHighlight(This,ppIListItem)	\
    (This)->lpVtbl -> put_DropHighlight(This,ppIListItem)

#define IListView_get_HideColumnHeaders(This,pfHide)	\
    (This)->lpVtbl -> get_HideColumnHeaders(This,pfHide)

#define IListView_put_HideColumnHeaders(This,pfHide)	\
    (This)->lpVtbl -> put_HideColumnHeaders(This,pfHide)

#define IListView_get_HideSelection(This,pfHide)	\
    (This)->lpVtbl -> get_HideSelection(This,pfHide)

#define IListView_put_HideSelection(This,pfHide)	\
    (This)->lpVtbl -> put_HideSelection(This,pfHide)

#define IListView_get_Icons(This,ppIcons)	\
    (This)->lpVtbl -> get_Icons(This,ppIcons)

#define IListView_putref_Icons(This,ppIcons)	\
    (This)->lpVtbl -> putref_Icons(This,ppIcons)

#define IListView_put_Icons(This,ppIcons)	\
    (This)->lpVtbl -> put_Icons(This,ppIcons)

#define IListView_get_ListItems(This,ppListItems)	\
    (This)->lpVtbl -> get_ListItems(This,ppListItems)

#define IListView_put_ListItems(This,ppListItems)	\
    (This)->lpVtbl -> put_ListItems(This,ppListItems)

#define IListView_get_LabelEdit(This,pRet)	\
    (This)->lpVtbl -> get_LabelEdit(This,pRet)

#define IListView_put_LabelEdit(This,pRet)	\
    (This)->lpVtbl -> put_LabelEdit(This,pRet)

#define IListView_get_LabelWrap(This,pfOn)	\
    (This)->lpVtbl -> get_LabelWrap(This,pfOn)

#define IListView_put_LabelWrap(This,pfOn)	\
    (This)->lpVtbl -> put_LabelWrap(This,pfOn)

#define IListView_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define IListView_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define IListView_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define IListView_get_MousePointer(This,pnIndex)	\
    (This)->lpVtbl -> get_MousePointer(This,pnIndex)

#define IListView_put_MousePointer(This,pnIndex)	\
    (This)->lpVtbl -> put_MousePointer(This,pnIndex)

#define IListView_get_MultiSelect(This,pfOn)	\
    (This)->lpVtbl -> get_MultiSelect(This,pfOn)

#define IListView_put_MultiSelect(This,pfOn)	\
    (This)->lpVtbl -> put_MultiSelect(This,pfOn)

#define IListView_get_SelectedItem(This,ppListItem)	\
    (This)->lpVtbl -> get_SelectedItem(This,ppListItem)

#define IListView_putref_SelectedItem(This,ppListItem)	\
    (This)->lpVtbl -> putref_SelectedItem(This,ppListItem)

#define IListView_put_SelectedItem(This,ppListItem)	\
    (This)->lpVtbl -> put_SelectedItem(This,ppListItem)

#define IListView_get_SmallIcons(This,ppImageList)	\
    (This)->lpVtbl -> get_SmallIcons(This,ppImageList)

#define IListView_putref_SmallIcons(This,ppImageList)	\
    (This)->lpVtbl -> putref_SmallIcons(This,ppImageList)

#define IListView_put_SmallIcons(This,ppImageList)	\
    (This)->lpVtbl -> put_SmallIcons(This,ppImageList)

#define IListView_get_Sorted(This,pfOn)	\
    (This)->lpVtbl -> get_Sorted(This,pfOn)

#define IListView_put_Sorted(This,pfOn)	\
    (This)->lpVtbl -> put_Sorted(This,pfOn)

#define IListView_get_SortKey(This,psKey)	\
    (This)->lpVtbl -> get_SortKey(This,psKey)

#define IListView_put_SortKey(This,psKey)	\
    (This)->lpVtbl -> put_SortKey(This,psKey)

#define IListView_get_SortOrder(This,pOrder)	\
    (This)->lpVtbl -> get_SortOrder(This,pOrder)

#define IListView_put_SortOrder(This,pOrder)	\
    (This)->lpVtbl -> put_SortOrder(This,pOrder)

#define IListView_get_View(This,pnView)	\
    (This)->lpVtbl -> get_View(This,pnView)

#define IListView_put_View(This,pnView)	\
    (This)->lpVtbl -> put_View(This,pnView)

#define IListView_get_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> get_OLEDragMode(This,psOLEDragMode)

#define IListView_put_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> put_OLEDragMode(This,psOLEDragMode)

#define IListView_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define IListView_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define IListView_get_Appearance(This,pnAppearance)	\
    (This)->lpVtbl -> get_Appearance(This,pnAppearance)

#define IListView_put_Appearance(This,pnAppearance)	\
    (This)->lpVtbl -> put_Appearance(This,pnAppearance)

#define IListView_get_BackColor(This,pcrBack)	\
    (This)->lpVtbl -> get_BackColor(This,pcrBack)

#define IListView_put_BackColor(This,pcrBack)	\
    (This)->lpVtbl -> put_BackColor(This,pcrBack)

#define IListView_get_BorderStyle(This,pnStyle)	\
    (This)->lpVtbl -> get_BorderStyle(This,pnStyle)

#define IListView_put_BorderStyle(This,pnStyle)	\
    (This)->lpVtbl -> put_BorderStyle(This,pnStyle)

#define IListView_get_Enabled(This,pfEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pfEnabled)

#define IListView_put_Enabled(This,pfEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pfEnabled)

#define IListView_get_Font(This,ppFontDisp)	\
    (This)->lpVtbl -> get_Font(This,ppFontDisp)

#define IListView_putref_Font(This,ppFontDisp)	\
    (This)->lpVtbl -> putref_Font(This,ppFontDisp)

#define IListView_get_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> get_ForeColor(This,pcrFore)

#define IListView_put_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> put_ForeColor(This,pcrFore)

#define IListView_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define IListView_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define IListView_FindItem(This,sz,Where,Index,fPartial,ppIListItem)	\
    (This)->lpVtbl -> FindItem(This,sz,Where,Index,fPartial,ppIListItem)

#define IListView_GetFirstVisible(This,ppIListItem)	\
    (This)->lpVtbl -> GetFirstVisible(This,ppIListItem)

#define IListView_HitTest(This,x,y,ppListItem)	\
    (This)->lpVtbl -> HitTest(This,x,y,ppListItem)

#define IListView_StartLabelEdit(This)	\
    (This)->lpVtbl -> StartLabelEdit(This)

#define IListView_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define IListView_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define IListView_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define IListView_get_AllowColumnReorder(This,pfAllowColumnReorder)	\
    (This)->lpVtbl -> get_AllowColumnReorder(This,pfAllowColumnReorder)

#define IListView_put_AllowColumnReorder(This,pfAllowColumnReorder)	\
    (This)->lpVtbl -> put_AllowColumnReorder(This,pfAllowColumnReorder)

#define IListView_get_Checkboxes(This,pfCheckboxes)	\
    (This)->lpVtbl -> get_Checkboxes(This,pfCheckboxes)

#define IListView_put_Checkboxes(This,pfCheckboxes)	\
    (This)->lpVtbl -> put_Checkboxes(This,pfCheckboxes)

#define IListView_get_FlatScrollBar(This,pfFlatScrollBar)	\
    (This)->lpVtbl -> get_FlatScrollBar(This,pfFlatScrollBar)

#define IListView_put_FlatScrollBar(This,pfFlatScrollBar)	\
    (This)->lpVtbl -> put_FlatScrollBar(This,pfFlatScrollBar)

#define IListView_get_FullRowSelect(This,pfFullRowSelect)	\
    (This)->lpVtbl -> get_FullRowSelect(This,pfFullRowSelect)

#define IListView_put_FullRowSelect(This,pfFullRowSelect)	\
    (This)->lpVtbl -> put_FullRowSelect(This,pfFullRowSelect)

#define IListView_get_GridLines(This,pfGridLines)	\
    (This)->lpVtbl -> get_GridLines(This,pfGridLines)

#define IListView_put_GridLines(This,pfGridLines)	\
    (This)->lpVtbl -> put_GridLines(This,pfGridLines)

#define IListView_get_HotTracking(This,pfHotTracking)	\
    (This)->lpVtbl -> get_HotTracking(This,pfHotTracking)

#define IListView_put_HotTracking(This,pfHotTracking)	\
    (This)->lpVtbl -> put_HotTracking(This,pfHotTracking)

#define IListView_get_HoverSelection(This,pfHoverSelection)	\
    (This)->lpVtbl -> get_HoverSelection(This,pfHoverSelection)

#define IListView_put_HoverSelection(This,pfHoverSelection)	\
    (This)->lpVtbl -> put_HoverSelection(This,pfHoverSelection)

#define IListView_get_Picture(This,ppPictureDisp)	\
    (This)->lpVtbl -> get_Picture(This,ppPictureDisp)

#define IListView_put_Picture(This,ppPictureDisp)	\
    (This)->lpVtbl -> put_Picture(This,ppPictureDisp)

#define IListView_putref_Picture(This,ppPictureDisp)	\
    (This)->lpVtbl -> putref_Picture(This,ppPictureDisp)

#define IListView_get_PictureAlignment(This,psAlignment)	\
    (This)->lpVtbl -> get_PictureAlignment(This,psAlignment)

#define IListView_put_PictureAlignment(This,psAlignment)	\
    (This)->lpVtbl -> put_PictureAlignment(This,psAlignment)

#define IListView_get_ColumnHeaderIcons(This,ppImageList)	\
    (This)->lpVtbl -> get_ColumnHeaderIcons(This,ppImageList)

#define IListView_putref_ColumnHeaderIcons(This,ppImageList)	\
    (This)->lpVtbl -> putref_ColumnHeaderIcons(This,ppImageList)

#define IListView_put_ColumnHeaderIcons(This,ppImageList)	\
    (This)->lpVtbl -> put_ColumnHeaderIcons(This,ppImageList)

#define IListView_get_TextBackground(This,penumTextBackground)	\
    (This)->lpVtbl -> get_TextBackground(This,penumTextBackground)

#define IListView_put_TextBackground(This,penumTextBackground)	\
    (This)->lpVtbl -> put_TextBackground(This,penumTextBackground)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Arrange_Proxy( 
    IListView * This,
    /* [retval][out] */ ListArrangeConstants *pArrange);


void __RPC_STUB IListView_get_Arrange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Arrange_Proxy( 
    IListView * This,
    /* [in] */ ListArrangeConstants pArrange);


void __RPC_STUB IListView_put_Arrange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_ColumnHeaders_Proxy( 
    IListView * This,
    /* [retval][out] */ IColumnHeaders **ppIColumnHeaders);


void __RPC_STUB IListView_get_ColumnHeaders_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_ColumnHeaders_Proxy( 
    IListView * This,
    /* [in] */ IColumnHeaders *ppIColumnHeaders);


void __RPC_STUB IListView_put_ColumnHeaders_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_DropHighlight_Proxy( 
    IListView * This,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListView_get_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_DropHighlight_Proxy( 
    IListView * This,
    /* [in] */ IListItem *ppIListItem);


void __RPC_STUB IListView_putref_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_DropHighlight_Proxy( 
    IListView * This,
    /* [in] */ VARIANT *ppIListItem);


void __RPC_STUB IListView_put_DropHighlight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_HideColumnHeaders_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfHide);


void __RPC_STUB IListView_get_HideColumnHeaders_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_HideColumnHeaders_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfHide);


void __RPC_STUB IListView_put_HideColumnHeaders_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_HideSelection_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfHide);


void __RPC_STUB IListView_get_HideSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_HideSelection_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfHide);


void __RPC_STUB IListView_put_HideSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Icons_Proxy( 
    IListView * This,
    /* [retval][out] */ IDispatch **ppIcons);


void __RPC_STUB IListView_get_Icons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_Icons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppIcons);


void __RPC_STUB IListView_putref_Icons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Icons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppIcons);


void __RPC_STUB IListView_put_Icons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_ListItems_Proxy( 
    IListView * This,
    /* [retval][out] */ IListItems **ppListItems);


void __RPC_STUB IListView_get_ListItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_ListItems_Proxy( 
    IListView * This,
    /* [in] */ IListItems *ppListItems);


void __RPC_STUB IListView_put_ListItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_LabelEdit_Proxy( 
    IListView * This,
    /* [retval][out] */ ListLabelEditConstants *pRet);


void __RPC_STUB IListView_get_LabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_LabelEdit_Proxy( 
    IListView * This,
    /* [in] */ ListLabelEditConstants pRet);


void __RPC_STUB IListView_put_LabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_LabelWrap_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfOn);


void __RPC_STUB IListView_get_LabelWrap_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_LabelWrap_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfOn);


void __RPC_STUB IListView_put_LabelWrap_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_MouseIcon_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB IListView_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_MouseIcon_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IListView_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_MouseIcon_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IListView_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_MousePointer_Proxy( 
    IListView * This,
    /* [retval][out] */ MousePointerConstants *pnIndex);


void __RPC_STUB IListView_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_MousePointer_Proxy( 
    IListView * This,
    /* [in] */ MousePointerConstants pnIndex);


void __RPC_STUB IListView_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_MultiSelect_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfOn);


void __RPC_STUB IListView_get_MultiSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_MultiSelect_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfOn);


void __RPC_STUB IListView_put_MultiSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_SelectedItem_Proxy( 
    IListView * This,
    /* [retval][out] */ IListItem **ppListItem);


void __RPC_STUB IListView_get_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_SelectedItem_Proxy( 
    IListView * This,
    /* [in] */ IListItem *ppListItem);


void __RPC_STUB IListView_putref_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_SelectedItem_Proxy( 
    IListView * This,
    /* [in] */ VARIANT *ppListItem);


void __RPC_STUB IListView_put_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_SmallIcons_Proxy( 
    IListView * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB IListView_get_SmallIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_SmallIcons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IListView_putref_SmallIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_SmallIcons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IListView_put_SmallIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Sorted_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfOn);


void __RPC_STUB IListView_get_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Sorted_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfOn);


void __RPC_STUB IListView_put_Sorted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_SortKey_Proxy( 
    IListView * This,
    /* [retval][out] */ short *psKey);


void __RPC_STUB IListView_get_SortKey_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_SortKey_Proxy( 
    IListView * This,
    /* [in] */ short psKey);


void __RPC_STUB IListView_put_SortKey_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_SortOrder_Proxy( 
    IListView * This,
    /* [retval][out] */ ListSortOrderConstants *pOrder);


void __RPC_STUB IListView_get_SortOrder_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_SortOrder_Proxy( 
    IListView * This,
    /* [in] */ ListSortOrderConstants pOrder);


void __RPC_STUB IListView_put_SortOrder_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_View_Proxy( 
    IListView * This,
    /* [retval][out] */ ListViewConstants *pnView);


void __RPC_STUB IListView_get_View_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_View_Proxy( 
    IListView * This,
    /* [in] */ ListViewConstants pnView);


void __RPC_STUB IListView_put_View_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_OLEDragMode_Proxy( 
    IListView * This,
    /* [retval][out] */ OLEDragConstants *psOLEDragMode);


void __RPC_STUB IListView_get_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_OLEDragMode_Proxy( 
    IListView * This,
    /* [in] */ OLEDragConstants psOLEDragMode);


void __RPC_STUB IListView_put_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_OLEDropMode_Proxy( 
    IListView * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB IListView_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_OLEDropMode_Proxy( 
    IListView * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB IListView_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Appearance_Proxy( 
    IListView * This,
    /* [retval][out] */ AppearanceConstants *pnAppearance);


void __RPC_STUB IListView_get_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Appearance_Proxy( 
    IListView * This,
    /* [in] */ AppearanceConstants pnAppearance);


void __RPC_STUB IListView_put_Appearance_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_BackColor_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrBack);


void __RPC_STUB IListView_get_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_BackColor_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pcrBack);


void __RPC_STUB IListView_put_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_BorderStyle_Proxy( 
    IListView * This,
    /* [retval][out] */ BorderStyleConstants *pnStyle);


void __RPC_STUB IListView_get_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_BorderStyle_Proxy( 
    IListView * This,
    /* [in] */ BorderStyleConstants pnStyle);


void __RPC_STUB IListView_put_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Enabled_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfEnabled);


void __RPC_STUB IListView_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Enabled_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfEnabled);


void __RPC_STUB IListView_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Font_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ IFontDisp **ppFontDisp);


void __RPC_STUB IListView_get_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_Font_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFontDisp);


void __RPC_STUB IListView_putref_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_ForeColor_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);


void __RPC_STUB IListView_get_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_ForeColor_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);


void __RPC_STUB IListView_put_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_hWnd_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB IListView_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_hWnd_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB IListView_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListView_FindItem_Proxy( 
    IListView * This,
    /* [in] */ BSTR sz,
    /* [optional][in] */ VARIANT *Where,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *fPartial,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListView_FindItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListView_GetFirstVisible_Proxy( 
    IListView * This,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListView_GetFirstVisible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListView_HitTest_Proxy( 
    IListView * This,
    /* [in] */ single x,
    /* [in] */ single y,
    /* [retval][out] */ IListItem **ppListItem);


void __RPC_STUB IListView_HitTest_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListView_StartLabelEdit_Proxy( 
    IListView * This);


void __RPC_STUB IListView_StartLabelEdit_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListView_OLEDrag_Proxy( 
    IListView * This);


void __RPC_STUB IListView_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE IListView_Refresh_Proxy( 
    IListView * This);


void __RPC_STUB IListView_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ void STDMETHODCALLTYPE IListView_AboutBox_Proxy( 
    IListView * This);


void __RPC_STUB IListView_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_AllowColumnReorder_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfAllowColumnReorder);


void __RPC_STUB IListView_get_AllowColumnReorder_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_AllowColumnReorder_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfAllowColumnReorder);


void __RPC_STUB IListView_put_AllowColumnReorder_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Checkboxes_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfCheckboxes);


void __RPC_STUB IListView_get_Checkboxes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Checkboxes_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfCheckboxes);


void __RPC_STUB IListView_put_Checkboxes_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_FlatScrollBar_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfFlatScrollBar);


void __RPC_STUB IListView_get_FlatScrollBar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_FlatScrollBar_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfFlatScrollBar);


void __RPC_STUB IListView_put_FlatScrollBar_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_FullRowSelect_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfFullRowSelect);


void __RPC_STUB IListView_get_FullRowSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_FullRowSelect_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfFullRowSelect);


void __RPC_STUB IListView_put_FullRowSelect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_GridLines_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfGridLines);


void __RPC_STUB IListView_get_GridLines_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_GridLines_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfGridLines);


void __RPC_STUB IListView_put_GridLines_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_HotTracking_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfHotTracking);


void __RPC_STUB IListView_get_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_HotTracking_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfHotTracking);


void __RPC_STUB IListView_put_HotTracking_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_HoverSelection_Proxy( 
    IListView * This,
    /* [retval][out] */ VARIANT_BOOL *pfHoverSelection);


void __RPC_STUB IListView_get_HoverSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_HoverSelection_Proxy( 
    IListView * This,
    /* [in] */ VARIANT_BOOL pfHoverSelection);


void __RPC_STUB IListView_put_HoverSelection_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_Picture_Proxy( 
    IListView * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);


void __RPC_STUB IListView_get_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_Picture_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);


void __RPC_STUB IListView_put_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_Picture_Proxy( 
    IListView * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);


void __RPC_STUB IListView_putref_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_PictureAlignment_Proxy( 
    IListView * This,
    /* [retval][out] */ ListPictureAlignmentConstants *psAlignment);


void __RPC_STUB IListView_get_PictureAlignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_PictureAlignment_Proxy( 
    IListView * This,
    /* [in] */ ListPictureAlignmentConstants psAlignment);


void __RPC_STUB IListView_put_PictureAlignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_ColumnHeaderIcons_Proxy( 
    IListView * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB IListView_get_ColumnHeaderIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListView_putref_ColumnHeaderIcons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IListView_putref_ColumnHeaderIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_ColumnHeaderIcons_Proxy( 
    IListView * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IListView_put_ColumnHeaderIcons_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListView_get_TextBackground_Proxy( 
    IListView * This,
    /* [retval][out] */ ListTextBackgroundConstants *penumTextBackground);


void __RPC_STUB IListView_get_TextBackground_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListView_put_TextBackground_Proxy( 
    IListView * This,
    /* [in] */ ListTextBackgroundConstants penumTextBackground);


void __RPC_STUB IListView_put_TextBackground_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IListView_INTERFACE_DEFINED__ */


#ifndef __ListViewEvents_DISPINTERFACE_DEFINED__
#define __ListViewEvents_DISPINTERFACE_DEFINED__

/* dispinterface ListViewEvents */
/* [nonextensible][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_ListViewEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("BDD1F04A-858B-11D1-B16A-00C0F0283628")
    ListViewEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ListViewEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ListViewEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ListViewEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ListViewEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ListViewEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ListViewEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ListViewEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ListViewEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ListViewEventsVtbl;

    interface ListViewEvents
    {
        CONST_VTBL struct ListViewEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ListViewEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ListViewEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ListViewEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ListViewEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ListViewEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ListViewEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ListViewEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ListViewEvents_DISPINTERFACE_DEFINED__ */


#ifndef __IListItems_INTERFACE_DEFINED__
#define __IListItems_INTERFACE_DEFINED__

/* interface IListItems */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IListItems;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F04C-858B-11D1-B16A-00C0F0283628")
    IListItems : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ long plCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Icon,
            /* [optional][in] */ VARIANT *SmallIcon,
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListItem **ppIListItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IUnknown **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IListItemsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IListItems * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IListItems * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IListItems * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IListItems * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IListItems * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IListItems * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IListItems * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IListItems * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IListItems * This,
            /* [in] */ long plCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IListItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IListItems * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Icon,
            /* [optional][in] */ VARIANT *SmallIcon,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IListItems * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IListItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListItem **ppIListItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IListItems * This,
            /* [in] */ VARIANT *Index);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IListItems * This,
            /* [retval][out] */ IUnknown **ppNewEnum);
        
        END_INTERFACE
    } IListItemsVtbl;

    interface IListItems
    {
        CONST_VTBL struct IListItemsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IListItems_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IListItems_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IListItems_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IListItems_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IListItems_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IListItems_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IListItems_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IListItems_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IListItems_put_Count(This,plCount)	\
    (This)->lpVtbl -> put_Count(This,plCount)

#define IListItems_get_ControlDefault(This,Index,ppIListItem)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppIListItem)

#define IListItems_Add(This,Index,Key,Text,Icon,SmallIcon,ppIListItem)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,Icon,SmallIcon,ppIListItem)

#define IListItems_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IListItems_get_Item(This,Index,ppIListItem)	\
    (This)->lpVtbl -> get_Item(This,Index,ppIListItem)

#define IListItems_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IListItems__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItems_get_Count_Proxy( 
    IListItems * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IListItems_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItems_put_Count_Proxy( 
    IListItems * This,
    /* [in] */ long plCount);


void __RPC_STUB IListItems_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IListItems_get_ControlDefault_Proxy( 
    IListItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListItems_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListItems_Add_Proxy( 
    IListItems * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Icon,
    /* [optional][in] */ VARIANT *SmallIcon,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListItems_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListItems_Clear_Proxy( 
    IListItems * This);


void __RPC_STUB IListItems_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItems_get_Item_Proxy( 
    IListItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IListItem **ppIListItem);


void __RPC_STUB IListItems_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListItems_Remove_Proxy( 
    IListItems * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IListItems_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IListItems__NewEnum_Proxy( 
    IListItems * This,
    /* [retval][out] */ IUnknown **ppNewEnum);


void __RPC_STUB IListItems__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IListItems_INTERFACE_DEFINED__ */


#ifndef __IListItem_INTERFACE_DEFINED__
#define __IListItem_INTERFACE_DEFINED__

/* interface IListItem */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IListItem;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F04E-858B-11D1-B16A-00C0F0283628")
    IListItem : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_Default( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_Default( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Ghosted( 
            /* [retval][out] */ VARIANT_BOOL *pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Ghosted( 
            /* [in] */ VARIANT_BOOL pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Height( 
            /* [retval][out] */ single *pflHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Height( 
            /* [in] */ single pflHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Icon( 
            /* [retval][out] */ VARIANT *pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Icon( 
            /* [in] */ VARIANT pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ long *plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ long plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Left( 
            /* [retval][out] */ single *pflLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Left( 
            /* [in] */ single pflLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Selected( 
            /* [retval][out] */ VARIANT_BOOL *pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Selected( 
            /* [in] */ VARIANT_BOOL pfOn) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SmallIcon( 
            /* [retval][out] */ VARIANT *pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SmallIcon( 
            /* [in] */ VARIANT pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Top( 
            /* [retval][out] */ single *pflTop) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Top( 
            /* [in] */ single pflTop) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Width( 
            /* [retval][out] */ single *pflWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Width( 
            /* [in] */ single pflWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SubItems( 
            /* [in] */ short Index,
            /* [retval][out] */ BSTR *pbstrItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SubItems( 
            /* [in] */ short Index,
            /* [in] */ BSTR pbstrItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE CreateDragImage( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppImage) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE EnsureVisible( 
            /* [retval][out] */ VARIANT_BOOL *pfVisible) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ListSubItems( 
            /* [retval][out] */ IListSubItems **ppSubItems) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ListSubItems( 
            /* [in] */ IListSubItems *ppSubItems) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Checked( 
            /* [retval][out] */ VARIANT_BOOL *pfChecked) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Checked( 
            /* [in] */ VARIANT_BOOL pfChecked) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ForeColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ForeColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ToolTipText( 
            /* [retval][out] */ BSTR *pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ToolTipText( 
            /* [in] */ BSTR pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Bold( 
            /* [retval][out] */ VARIANT_BOOL *pfBold) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Bold( 
            /* [in] */ VARIANT_BOOL pfBold) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IListItemVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IListItem * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IListItem * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IListItem * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IListItem * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IListItem * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IListItem * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IListItem * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Default )( 
            IListItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Default )( 
            IListItem * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IListItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IListItem * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Ghosted )( 
            IListItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfOn);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Ghosted )( 
            IListItem * This,
            /* [in] */ VARIANT_BOOL pfOn);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Height )( 
            IListItem * This,
            /* [retval][out] */ single *pflHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Height )( 
            IListItem * This,
            /* [in] */ single pflHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Icon )( 
            IListItem * This,
            /* [retval][out] */ VARIANT *pnIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Icon )( 
            IListItem * This,
            /* [in] */ VARIANT pnIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IListItem * This,
            /* [retval][out] */ long *plIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IListItem * This,
            /* [in] */ long plIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IListItem * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IListItem * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Left )( 
            IListItem * This,
            /* [retval][out] */ single *pflLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Left )( 
            IListItem * This,
            /* [in] */ single pflLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Selected )( 
            IListItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfOn);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Selected )( 
            IListItem * This,
            /* [in] */ VARIANT_BOOL pfOn);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SmallIcon )( 
            IListItem * This,
            /* [retval][out] */ VARIANT *pnIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SmallIcon )( 
            IListItem * This,
            /* [in] */ VARIANT pnIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IListItem * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IListItem * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Top )( 
            IListItem * This,
            /* [retval][out] */ single *pflTop);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Top )( 
            IListItem * This,
            /* [in] */ single pflTop);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Width )( 
            IListItem * This,
            /* [retval][out] */ single *pflWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Width )( 
            IListItem * This,
            /* [in] */ single pflWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SubItems )( 
            IListItem * This,
            /* [in] */ short Index,
            /* [retval][out] */ BSTR *pbstrItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SubItems )( 
            IListItem * This,
            /* [in] */ short Index,
            /* [in] */ BSTR pbstrItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CreateDragImage )( 
            IListItem * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppImage);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *EnsureVisible )( 
            IListItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfVisible);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IListItem * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ListSubItems )( 
            IListItem * This,
            /* [retval][out] */ IListSubItems **ppSubItems);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ListSubItems )( 
            IListItem * This,
            /* [in] */ IListSubItems *ppSubItems);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Checked )( 
            IListItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfChecked);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Checked )( 
            IListItem * This,
            /* [in] */ VARIANT_BOOL pfChecked);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ForeColor )( 
            IListItem * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ForeColor )( 
            IListItem * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ToolTipText )( 
            IListItem * This,
            /* [retval][out] */ BSTR *pbstrToolTipText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ToolTipText )( 
            IListItem * This,
            /* [in] */ BSTR pbstrToolTipText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Bold )( 
            IListItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfBold);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Bold )( 
            IListItem * This,
            /* [in] */ VARIANT_BOOL pfBold);
        
        END_INTERFACE
    } IListItemVtbl;

    interface IListItem
    {
        CONST_VTBL struct IListItemVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IListItem_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IListItem_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IListItem_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IListItem_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IListItem_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IListItem_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IListItem_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IListItem_get_Default(This,pbstrText)	\
    (This)->lpVtbl -> get_Default(This,pbstrText)

#define IListItem_put_Default(This,pbstrText)	\
    (This)->lpVtbl -> put_Default(This,pbstrText)

#define IListItem_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IListItem_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IListItem_get_Ghosted(This,pfOn)	\
    (This)->lpVtbl -> get_Ghosted(This,pfOn)

#define IListItem_put_Ghosted(This,pfOn)	\
    (This)->lpVtbl -> put_Ghosted(This,pfOn)

#define IListItem_get_Height(This,pflHeight)	\
    (This)->lpVtbl -> get_Height(This,pflHeight)

#define IListItem_put_Height(This,pflHeight)	\
    (This)->lpVtbl -> put_Height(This,pflHeight)

#define IListItem_get_Icon(This,pnIndex)	\
    (This)->lpVtbl -> get_Icon(This,pnIndex)

#define IListItem_put_Icon(This,pnIndex)	\
    (This)->lpVtbl -> put_Icon(This,pnIndex)

#define IListItem_get_Index(This,plIndex)	\
    (This)->lpVtbl -> get_Index(This,plIndex)

#define IListItem_put_Index(This,plIndex)	\
    (This)->lpVtbl -> put_Index(This,plIndex)

#define IListItem_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IListItem_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IListItem_get_Left(This,pflLeft)	\
    (This)->lpVtbl -> get_Left(This,pflLeft)

#define IListItem_put_Left(This,pflLeft)	\
    (This)->lpVtbl -> put_Left(This,pflLeft)

#define IListItem_get_Selected(This,pfOn)	\
    (This)->lpVtbl -> get_Selected(This,pfOn)

#define IListItem_put_Selected(This,pfOn)	\
    (This)->lpVtbl -> put_Selected(This,pfOn)

#define IListItem_get_SmallIcon(This,pnIndex)	\
    (This)->lpVtbl -> get_SmallIcon(This,pnIndex)

#define IListItem_put_SmallIcon(This,pnIndex)	\
    (This)->lpVtbl -> put_SmallIcon(This,pnIndex)

#define IListItem_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IListItem_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IListItem_get_Top(This,pflTop)	\
    (This)->lpVtbl -> get_Top(This,pflTop)

#define IListItem_put_Top(This,pflTop)	\
    (This)->lpVtbl -> put_Top(This,pflTop)

#define IListItem_get_Width(This,pflWidth)	\
    (This)->lpVtbl -> get_Width(This,pflWidth)

#define IListItem_put_Width(This,pflWidth)	\
    (This)->lpVtbl -> put_Width(This,pflWidth)

#define IListItem_get_SubItems(This,Index,pbstrItem)	\
    (This)->lpVtbl -> get_SubItems(This,Index,pbstrItem)

#define IListItem_put_SubItems(This,Index,pbstrItem)	\
    (This)->lpVtbl -> put_SubItems(This,Index,pbstrItem)

#define IListItem_CreateDragImage(This,ppImage)	\
    (This)->lpVtbl -> CreateDragImage(This,ppImage)

#define IListItem_EnsureVisible(This,pfVisible)	\
    (This)->lpVtbl -> EnsureVisible(This,pfVisible)

#define IListItem_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#define IListItem_get_ListSubItems(This,ppSubItems)	\
    (This)->lpVtbl -> get_ListSubItems(This,ppSubItems)

#define IListItem_put_ListSubItems(This,ppSubItems)	\
    (This)->lpVtbl -> put_ListSubItems(This,ppSubItems)

#define IListItem_get_Checked(This,pfChecked)	\
    (This)->lpVtbl -> get_Checked(This,pfChecked)

#define IListItem_put_Checked(This,pfChecked)	\
    (This)->lpVtbl -> put_Checked(This,pfChecked)

#define IListItem_get_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> get_ForeColor(This,pcrFore)

#define IListItem_put_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> put_ForeColor(This,pcrFore)

#define IListItem_get_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> get_ToolTipText(This,pbstrToolTipText)

#define IListItem_put_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> put_ToolTipText(This,pbstrToolTipText)

#define IListItem_get_Bold(This,pfBold)	\
    (This)->lpVtbl -> get_Bold(This,pfBold)

#define IListItem_put_Bold(This,pfBold)	\
    (This)->lpVtbl -> put_Bold(This,pfBold)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Default_Proxy( 
    IListItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IListItem_get_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Default_Proxy( 
    IListItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IListItem_put_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Text_Proxy( 
    IListItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IListItem_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Text_Proxy( 
    IListItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IListItem_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Ghosted_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfOn);


void __RPC_STUB IListItem_get_Ghosted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Ghosted_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT_BOOL pfOn);


void __RPC_STUB IListItem_put_Ghosted_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Height_Proxy( 
    IListItem * This,
    /* [retval][out] */ single *pflHeight);


void __RPC_STUB IListItem_get_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Height_Proxy( 
    IListItem * This,
    /* [in] */ single pflHeight);


void __RPC_STUB IListItem_put_Height_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Icon_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT *pnIndex);


void __RPC_STUB IListItem_get_Icon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Icon_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT pnIndex);


void __RPC_STUB IListItem_put_Icon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Index_Proxy( 
    IListItem * This,
    /* [retval][out] */ long *plIndex);


void __RPC_STUB IListItem_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Index_Proxy( 
    IListItem * This,
    /* [in] */ long plIndex);


void __RPC_STUB IListItem_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Key_Proxy( 
    IListItem * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IListItem_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Key_Proxy( 
    IListItem * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IListItem_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Left_Proxy( 
    IListItem * This,
    /* [retval][out] */ single *pflLeft);


void __RPC_STUB IListItem_get_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Left_Proxy( 
    IListItem * This,
    /* [in] */ single pflLeft);


void __RPC_STUB IListItem_put_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Selected_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfOn);


void __RPC_STUB IListItem_get_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Selected_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT_BOOL pfOn);


void __RPC_STUB IListItem_put_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_SmallIcon_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT *pnIndex);


void __RPC_STUB IListItem_get_SmallIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_SmallIcon_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT pnIndex);


void __RPC_STUB IListItem_put_SmallIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Tag_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IListItem_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Tag_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IListItem_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Top_Proxy( 
    IListItem * This,
    /* [retval][out] */ single *pflTop);


void __RPC_STUB IListItem_get_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Top_Proxy( 
    IListItem * This,
    /* [in] */ single pflTop);


void __RPC_STUB IListItem_put_Top_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Width_Proxy( 
    IListItem * This,
    /* [retval][out] */ single *pflWidth);


void __RPC_STUB IListItem_get_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Width_Proxy( 
    IListItem * This,
    /* [in] */ single pflWidth);


void __RPC_STUB IListItem_put_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_SubItems_Proxy( 
    IListItem * This,
    /* [in] */ short Index,
    /* [retval][out] */ BSTR *pbstrItem);


void __RPC_STUB IListItem_get_SubItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_SubItems_Proxy( 
    IListItem * This,
    /* [in] */ short Index,
    /* [in] */ BSTR pbstrItem);


void __RPC_STUB IListItem_put_SubItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListItem_CreateDragImage_Proxy( 
    IListItem * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppImage);


void __RPC_STUB IListItem_CreateDragImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListItem_EnsureVisible_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfVisible);


void __RPC_STUB IListItem_EnsureVisible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListItem_putref_Tag_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IListItem_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_ListSubItems_Proxy( 
    IListItem * This,
    /* [retval][out] */ IListSubItems **ppSubItems);


void __RPC_STUB IListItem_get_ListSubItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_ListSubItems_Proxy( 
    IListItem * This,
    /* [in] */ IListSubItems *ppSubItems);


void __RPC_STUB IListItem_put_ListSubItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Checked_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfChecked);


void __RPC_STUB IListItem_get_Checked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Checked_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT_BOOL pfChecked);


void __RPC_STUB IListItem_put_Checked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_ForeColor_Proxy( 
    IListItem * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);


void __RPC_STUB IListItem_get_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_ForeColor_Proxy( 
    IListItem * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);


void __RPC_STUB IListItem_put_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_ToolTipText_Proxy( 
    IListItem * This,
    /* [retval][out] */ BSTR *pbstrToolTipText);


void __RPC_STUB IListItem_get_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_ToolTipText_Proxy( 
    IListItem * This,
    /* [in] */ BSTR pbstrToolTipText);


void __RPC_STUB IListItem_put_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListItem_get_Bold_Proxy( 
    IListItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfBold);


void __RPC_STUB IListItem_get_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListItem_put_Bold_Proxy( 
    IListItem * This,
    /* [in] */ VARIANT_BOOL pfBold);


void __RPC_STUB IListItem_put_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IListItem_INTERFACE_DEFINED__ */


#ifndef __IColumnHeaders_INTERFACE_DEFINED__
#define __IColumnHeaders_INTERFACE_DEFINED__

/* interface IColumnHeaders */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IColumnHeaders;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F050-858B-11D1-B16A-00C0F0283628")
    IColumnHeaders : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ long plCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][id] */ HRESULT STDMETHODCALLTYPE Add_PreVB98( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Width,
            /* [optional][in] */ VARIANT *Alignment,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IUnknown **ppUnknown) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Width,
            /* [optional][in] */ VARIANT *Alignment,
            /* [optional][in] */ VARIANT *Icon,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IColumnHeadersVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IColumnHeaders * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IColumnHeaders * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IColumnHeaders * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IColumnHeaders * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IColumnHeaders * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IColumnHeaders * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IColumnHeaders * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IColumnHeaders * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IColumnHeaders * This,
            /* [in] */ long plCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IColumnHeaders * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader);
        
        /* [helpcontext][helpstring][hidden][id] */ HRESULT ( STDMETHODCALLTYPE *Add_PreVB98 )( 
            IColumnHeaders * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Width,
            /* [optional][in] */ VARIANT *Alignment,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IColumnHeaders * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IColumnHeaders * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IColumnHeaders * This,
            /* [in] */ VARIANT *Index);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IColumnHeaders * This,
            /* [retval][out] */ IUnknown **ppUnknown);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IColumnHeaders * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Width,
            /* [optional][in] */ VARIANT *Alignment,
            /* [optional][in] */ VARIANT *Icon,
            /* [retval][out] */ IColumnHeader **ppIColumnHeader);
        
        END_INTERFACE
    } IColumnHeadersVtbl;

    interface IColumnHeaders
    {
        CONST_VTBL struct IColumnHeadersVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IColumnHeaders_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IColumnHeaders_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IColumnHeaders_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IColumnHeaders_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IColumnHeaders_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IColumnHeaders_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IColumnHeaders_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IColumnHeaders_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IColumnHeaders_put_Count(This,plCount)	\
    (This)->lpVtbl -> put_Count(This,plCount)

#define IColumnHeaders_get_ControlDefault(This,Index,ppIColumnHeader)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppIColumnHeader)

#define IColumnHeaders_Add_PreVB98(This,Index,Key,Text,Width,Alignment,ppIColumnHeader)	\
    (This)->lpVtbl -> Add_PreVB98(This,Index,Key,Text,Width,Alignment,ppIColumnHeader)

#define IColumnHeaders_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IColumnHeaders_get_Item(This,Index,ppIColumnHeader)	\
    (This)->lpVtbl -> get_Item(This,Index,ppIColumnHeader)

#define IColumnHeaders_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IColumnHeaders__NewEnum(This,ppUnknown)	\
    (This)->lpVtbl -> _NewEnum(This,ppUnknown)

#define IColumnHeaders_Add(This,Index,Key,Text,Width,Alignment,Icon,ppIColumnHeader)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,Width,Alignment,Icon,ppIColumnHeader)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_get_Count_Proxy( 
    IColumnHeaders * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IColumnHeaders_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_put_Count_Proxy( 
    IColumnHeaders * This,
    /* [in] */ long plCount);


void __RPC_STUB IColumnHeaders_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_get_ControlDefault_Proxy( 
    IColumnHeaders * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IColumnHeader **ppIColumnHeader);


void __RPC_STUB IColumnHeaders_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_Add_PreVB98_Proxy( 
    IColumnHeaders * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Width,
    /* [optional][in] */ VARIANT *Alignment,
    /* [retval][out] */ IColumnHeader **ppIColumnHeader);


void __RPC_STUB IColumnHeaders_Add_PreVB98_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_Clear_Proxy( 
    IColumnHeaders * This);


void __RPC_STUB IColumnHeaders_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_get_Item_Proxy( 
    IColumnHeaders * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IColumnHeader **ppIColumnHeader);


void __RPC_STUB IColumnHeaders_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_Remove_Proxy( 
    IColumnHeaders * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IColumnHeaders_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders__NewEnum_Proxy( 
    IColumnHeaders * This,
    /* [retval][out] */ IUnknown **ppUnknown);


void __RPC_STUB IColumnHeaders__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IColumnHeaders_Add_Proxy( 
    IColumnHeaders * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Width,
    /* [optional][in] */ VARIANT *Alignment,
    /* [optional][in] */ VARIANT *Icon,
    /* [retval][out] */ IColumnHeader **ppIColumnHeader);


void __RPC_STUB IColumnHeaders_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IColumnHeaders_INTERFACE_DEFINED__ */


#ifndef __IColumnHeader_INTERFACE_DEFINED__
#define __IColumnHeader_INTERFACE_DEFINED__

/* interface IColumnHeader */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IColumnHeader;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F051-858B-11D1-B16A-00C0F0283628")
    IColumnHeader : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_Default( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_Default( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Alignment( 
            /* [retval][out] */ ListColumnAlignmentConstants *pnAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Alignment( 
            /* [in] */ ListColumnAlignmentConstants pnAlignment) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ long *plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ long plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Left( 
            /* [retval][out] */ single *pflLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Left( 
            /* [in] */ single pflLeft) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SubItemIndex( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SubItemIndex( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Width( 
            /* [retval][out] */ single *pflWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Width( 
            /* [in] */ single pflWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Icon( 
            /* [retval][out] */ VARIANT *pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Icon( 
            /* [in] */ VARIANT pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Position( 
            /* [retval][out] */ short *piPosition) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Position( 
            /* [in] */ short piPosition) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IColumnHeaderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IColumnHeader * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IColumnHeader * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IColumnHeader * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IColumnHeader * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IColumnHeader * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IColumnHeader * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IColumnHeader * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Default )( 
            IColumnHeader * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Default )( 
            IColumnHeader * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IColumnHeader * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IColumnHeader * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Alignment )( 
            IColumnHeader * This,
            /* [retval][out] */ ListColumnAlignmentConstants *pnAlignment);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Alignment )( 
            IColumnHeader * This,
            /* [in] */ ListColumnAlignmentConstants pnAlignment);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IColumnHeader * This,
            /* [retval][out] */ long *plIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IColumnHeader * This,
            /* [in] */ long plIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IColumnHeader * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IColumnHeader * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Left )( 
            IColumnHeader * This,
            /* [retval][out] */ single *pflLeft);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Left )( 
            IColumnHeader * This,
            /* [in] */ single pflLeft);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SubItemIndex )( 
            IColumnHeader * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SubItemIndex )( 
            IColumnHeader * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IColumnHeader * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IColumnHeader * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Width )( 
            IColumnHeader * This,
            /* [retval][out] */ single *pflWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Width )( 
            IColumnHeader * This,
            /* [in] */ single pflWidth);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IColumnHeader * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Icon )( 
            IColumnHeader * This,
            /* [retval][out] */ VARIANT *pnIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Icon )( 
            IColumnHeader * This,
            /* [in] */ VARIANT pnIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Position )( 
            IColumnHeader * This,
            /* [retval][out] */ short *piPosition);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Position )( 
            IColumnHeader * This,
            /* [in] */ short piPosition);
        
        END_INTERFACE
    } IColumnHeaderVtbl;

    interface IColumnHeader
    {
        CONST_VTBL struct IColumnHeaderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IColumnHeader_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IColumnHeader_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IColumnHeader_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IColumnHeader_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IColumnHeader_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IColumnHeader_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IColumnHeader_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IColumnHeader_get_Default(This,pbstrText)	\
    (This)->lpVtbl -> get_Default(This,pbstrText)

#define IColumnHeader_put_Default(This,pbstrText)	\
    (This)->lpVtbl -> put_Default(This,pbstrText)

#define IColumnHeader_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IColumnHeader_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IColumnHeader_get_Alignment(This,pnAlignment)	\
    (This)->lpVtbl -> get_Alignment(This,pnAlignment)

#define IColumnHeader_put_Alignment(This,pnAlignment)	\
    (This)->lpVtbl -> put_Alignment(This,pnAlignment)

#define IColumnHeader_get_Index(This,plIndex)	\
    (This)->lpVtbl -> get_Index(This,plIndex)

#define IColumnHeader_put_Index(This,plIndex)	\
    (This)->lpVtbl -> put_Index(This,plIndex)

#define IColumnHeader_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IColumnHeader_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IColumnHeader_get_Left(This,pflLeft)	\
    (This)->lpVtbl -> get_Left(This,pflLeft)

#define IColumnHeader_put_Left(This,pflLeft)	\
    (This)->lpVtbl -> put_Left(This,pflLeft)

#define IColumnHeader_get_SubItemIndex(This,psIndex)	\
    (This)->lpVtbl -> get_SubItemIndex(This,psIndex)

#define IColumnHeader_put_SubItemIndex(This,psIndex)	\
    (This)->lpVtbl -> put_SubItemIndex(This,psIndex)

#define IColumnHeader_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IColumnHeader_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IColumnHeader_get_Width(This,pflWidth)	\
    (This)->lpVtbl -> get_Width(This,pflWidth)

#define IColumnHeader_put_Width(This,pflWidth)	\
    (This)->lpVtbl -> put_Width(This,pflWidth)

#define IColumnHeader_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#define IColumnHeader_get_Icon(This,pnIndex)	\
    (This)->lpVtbl -> get_Icon(This,pnIndex)

#define IColumnHeader_put_Icon(This,pnIndex)	\
    (This)->lpVtbl -> put_Icon(This,pnIndex)

#define IColumnHeader_get_Position(This,piPosition)	\
    (This)->lpVtbl -> get_Position(This,piPosition)

#define IColumnHeader_put_Position(This,piPosition)	\
    (This)->lpVtbl -> put_Position(This,piPosition)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Default_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IColumnHeader_get_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Default_Proxy( 
    IColumnHeader * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IColumnHeader_put_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Text_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IColumnHeader_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Text_Proxy( 
    IColumnHeader * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IColumnHeader_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Alignment_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ ListColumnAlignmentConstants *pnAlignment);


void __RPC_STUB IColumnHeader_get_Alignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Alignment_Proxy( 
    IColumnHeader * This,
    /* [in] */ ListColumnAlignmentConstants pnAlignment);


void __RPC_STUB IColumnHeader_put_Alignment_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Index_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ long *plIndex);


void __RPC_STUB IColumnHeader_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Index_Proxy( 
    IColumnHeader * This,
    /* [in] */ long plIndex);


void __RPC_STUB IColumnHeader_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Key_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IColumnHeader_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Key_Proxy( 
    IColumnHeader * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IColumnHeader_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Left_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ single *pflLeft);


void __RPC_STUB IColumnHeader_get_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Left_Proxy( 
    IColumnHeader * This,
    /* [in] */ single pflLeft);


void __RPC_STUB IColumnHeader_put_Left_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_SubItemIndex_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB IColumnHeader_get_SubItemIndex_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_SubItemIndex_Proxy( 
    IColumnHeader * This,
    /* [in] */ short psIndex);


void __RPC_STUB IColumnHeader_put_SubItemIndex_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Tag_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IColumnHeader_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Tag_Proxy( 
    IColumnHeader * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IColumnHeader_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Width_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ single *pflWidth);


void __RPC_STUB IColumnHeader_get_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Width_Proxy( 
    IColumnHeader * This,
    /* [in] */ single pflWidth);


void __RPC_STUB IColumnHeader_put_Width_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_putref_Tag_Proxy( 
    IColumnHeader * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IColumnHeader_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Icon_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ VARIANT *pnIndex);


void __RPC_STUB IColumnHeader_get_Icon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Icon_Proxy( 
    IColumnHeader * This,
    /* [in] */ VARIANT pnIndex);


void __RPC_STUB IColumnHeader_put_Icon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_get_Position_Proxy( 
    IColumnHeader * This,
    /* [retval][out] */ short *piPosition);


void __RPC_STUB IColumnHeader_get_Position_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IColumnHeader_put_Position_Proxy( 
    IColumnHeader * This,
    /* [in] */ short piPosition);


void __RPC_STUB IColumnHeader_put_Position_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IColumnHeader_INTERFACE_DEFINED__ */


#ifndef __IListSubItems_INTERFACE_DEFINED__
#define __IListSubItems_INTERFACE_DEFINED__

/* interface IListSubItems */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IListSubItems;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F053-858B-11D1-B16A-00C0F0283628")
    IListSubItems : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ long plCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListSubItem **ppIListSubItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *ReportIcon,
            /* [optional][in] */ VARIANT *ToolTipText,
            /* [retval][out] */ IListSubItem **ppIListSubItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListSubItem **ppIListSubItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IUnknown **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IListSubItemsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IListSubItems * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IListSubItems * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IListSubItems * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IListSubItems * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IListSubItems * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IListSubItems * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IListSubItems * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IListSubItems * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IListSubItems * This,
            /* [in] */ long plCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IListSubItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListSubItem **ppIListSubItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IListSubItems * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *ReportIcon,
            /* [optional][in] */ VARIANT *ToolTipText,
            /* [retval][out] */ IListSubItem **ppIListSubItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IListSubItems * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IListSubItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IListSubItem **ppIListSubItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IListSubItems * This,
            /* [in] */ VARIANT *Index);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IListSubItems * This,
            /* [retval][out] */ IUnknown **ppNewEnum);
        
        END_INTERFACE
    } IListSubItemsVtbl;

    interface IListSubItems
    {
        CONST_VTBL struct IListSubItemsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IListSubItems_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IListSubItems_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IListSubItems_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IListSubItems_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IListSubItems_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IListSubItems_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IListSubItems_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IListSubItems_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IListSubItems_put_Count(This,plCount)	\
    (This)->lpVtbl -> put_Count(This,plCount)

#define IListSubItems_get_ControlDefault(This,Index,ppIListSubItem)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppIListSubItem)

#define IListSubItems_Add(This,Index,Key,Text,ReportIcon,ToolTipText,ppIListSubItem)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,ReportIcon,ToolTipText,ppIListSubItem)

#define IListSubItems_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IListSubItems_get_Item(This,Index,ppIListSubItem)	\
    (This)->lpVtbl -> get_Item(This,Index,ppIListSubItem)

#define IListSubItems_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IListSubItems__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_get_Count_Proxy( 
    IListSubItems * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IListSubItems_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_put_Count_Proxy( 
    IListSubItems * This,
    /* [in] */ long plCount);


void __RPC_STUB IListSubItems_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_get_ControlDefault_Proxy( 
    IListSubItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IListSubItem **ppIListSubItem);


void __RPC_STUB IListSubItems_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_Add_Proxy( 
    IListSubItems * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *ReportIcon,
    /* [optional][in] */ VARIANT *ToolTipText,
    /* [retval][out] */ IListSubItem **ppIListSubItem);


void __RPC_STUB IListSubItems_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_Clear_Proxy( 
    IListSubItems * This);


void __RPC_STUB IListSubItems_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_get_Item_Proxy( 
    IListSubItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IListSubItem **ppIListSubItem);


void __RPC_STUB IListSubItems_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IListSubItems_Remove_Proxy( 
    IListSubItems * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IListSubItems_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IListSubItems__NewEnum_Proxy( 
    IListSubItems * This,
    /* [retval][out] */ IUnknown **ppNewEnum);


void __RPC_STUB IListSubItems__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IListSubItems_INTERFACE_DEFINED__ */


#ifndef __IListSubItem_INTERFACE_DEFINED__
#define __IListSubItem_INTERFACE_DEFINED__

/* interface IListSubItem */
/* [object][oleautomation][nonextensible][dual][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IListSubItem;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("BDD1F055-858B-11D1-B16A-00C0F0283628")
    IListSubItem : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_Default( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put_Default( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ForeColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ForeColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Bold( 
            /* [retval][out] */ VARIANT_BOOL *pfBold) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Bold( 
            /* [in] */ VARIANT_BOOL pfBold) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ReportIcon( 
            /* [retval][out] */ VARIANT *pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ReportIcon( 
            /* [in] */ VARIANT pnIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ToolTipText( 
            /* [retval][out] */ BSTR *pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ToolTipText( 
            /* [in] */ BSTR pbstrToolTipText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ long *plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ long plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IListSubItemVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IListSubItem * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IListSubItem * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IListSubItem * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IListSubItem * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IListSubItem * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IListSubItem * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IListSubItem * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Default )( 
            IListSubItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Default )( 
            IListSubItem * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IListSubItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IListSubItem * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ForeColor )( 
            IListSubItem * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ForeColor )( 
            IListSubItem * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Bold )( 
            IListSubItem * This,
            /* [retval][out] */ VARIANT_BOOL *pfBold);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Bold )( 
            IListSubItem * This,
            /* [in] */ VARIANT_BOOL pfBold);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ReportIcon )( 
            IListSubItem * This,
            /* [retval][out] */ VARIANT *pnIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ReportIcon )( 
            IListSubItem * This,
            /* [in] */ VARIANT pnIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ToolTipText )( 
            IListSubItem * This,
            /* [retval][out] */ BSTR *pbstrToolTipText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ToolTipText )( 
            IListSubItem * This,
            /* [in] */ BSTR pbstrToolTipText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IListSubItem * This,
            /* [retval][out] */ long *plIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IListSubItem * This,
            /* [in] */ long plIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IListSubItem * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IListSubItem * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IListSubItem * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IListSubItem * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IListSubItem * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } IListSubItemVtbl;

    interface IListSubItem
    {
        CONST_VTBL struct IListSubItemVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IListSubItem_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IListSubItem_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IListSubItem_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IListSubItem_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IListSubItem_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IListSubItem_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IListSubItem_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IListSubItem_get_Default(This,pbstrText)	\
    (This)->lpVtbl -> get_Default(This,pbstrText)

#define IListSubItem_put_Default(This,pbstrText)	\
    (This)->lpVtbl -> put_Default(This,pbstrText)

#define IListSubItem_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IListSubItem_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IListSubItem_get_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> get_ForeColor(This,pcrFore)

#define IListSubItem_put_ForeColor(This,pcrFore)	\
    (This)->lpVtbl -> put_ForeColor(This,pcrFore)

#define IListSubItem_get_Bold(This,pfBold)	\
    (This)->lpVtbl -> get_Bold(This,pfBold)

#define IListSubItem_put_Bold(This,pfBold)	\
    (This)->lpVtbl -> put_Bold(This,pfBold)

#define IListSubItem_get_ReportIcon(This,pnIndex)	\
    (This)->lpVtbl -> get_ReportIcon(This,pnIndex)

#define IListSubItem_put_ReportIcon(This,pnIndex)	\
    (This)->lpVtbl -> put_ReportIcon(This,pnIndex)

#define IListSubItem_get_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> get_ToolTipText(This,pbstrToolTipText)

#define IListSubItem_put_ToolTipText(This,pbstrToolTipText)	\
    (This)->lpVtbl -> put_ToolTipText(This,pbstrToolTipText)

#define IListSubItem_get_Index(This,plIndex)	\
    (This)->lpVtbl -> get_Index(This,plIndex)

#define IListSubItem_put_Index(This,plIndex)	\
    (This)->lpVtbl -> put_Index(This,plIndex)

#define IListSubItem_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IListSubItem_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IListSubItem_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IListSubItem_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IListSubItem_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Default_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IListSubItem_get_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Default_Proxy( 
    IListSubItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IListSubItem_put_Default_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Text_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IListSubItem_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Text_Proxy( 
    IListSubItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IListSubItem_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_ForeColor_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pcrFore);


void __RPC_STUB IListSubItem_get_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_ForeColor_Proxy( 
    IListSubItem * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pcrFore);


void __RPC_STUB IListSubItem_put_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Bold_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ VARIANT_BOOL *pfBold);


void __RPC_STUB IListSubItem_get_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Bold_Proxy( 
    IListSubItem * This,
    /* [in] */ VARIANT_BOOL pfBold);


void __RPC_STUB IListSubItem_put_Bold_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_ReportIcon_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ VARIANT *pnIndex);


void __RPC_STUB IListSubItem_get_ReportIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_ReportIcon_Proxy( 
    IListSubItem * This,
    /* [in] */ VARIANT pnIndex);


void __RPC_STUB IListSubItem_put_ReportIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_ToolTipText_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ BSTR *pbstrToolTipText);


void __RPC_STUB IListSubItem_get_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_ToolTipText_Proxy( 
    IListSubItem * This,
    /* [in] */ BSTR pbstrToolTipText);


void __RPC_STUB IListSubItem_put_ToolTipText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Index_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ long *plIndex);


void __RPC_STUB IListSubItem_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Index_Proxy( 
    IListSubItem * This,
    /* [in] */ long plIndex);


void __RPC_STUB IListSubItem_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Key_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IListSubItem_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Key_Proxy( 
    IListSubItem * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IListSubItem_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_get_Tag_Proxy( 
    IListSubItem * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IListSubItem_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_put_Tag_Proxy( 
    IListSubItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IListSubItem_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IListSubItem_putref_Tag_Proxy( 
    IListSubItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IListSubItem_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IListSubItem_INTERFACE_DEFINED__ */


#ifndef __IImageList_INTERFACE_DEFINED__
#define __IImageList_INTERFACE_DEFINED__

/* interface IImageList */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IImageList;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2C247F21-8591-11D1-B16A-00C0F0283628")
    IImageList : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageHeight( 
            /* [retval][out] */ short *psImageHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageHeight( 
            /* [in] */ short psImageHeight) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageWidth( 
            /* [retval][out] */ short *psImageWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageWidth( 
            /* [in] */ short psImageWidth) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MaskColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrMaskColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MaskColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pclrMaskColor) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_UseMaskColor( 
            /* [retval][out] */ VARIANT_BOOL *pbState) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_UseMaskColor( 
            /* [in] */ VARIANT_BOOL pbState) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ListImages( 
            /* [retval][out] */ IImages **ppListImages) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ListImages( 
            /* [in] */ IImages *ppListImages) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hImageList( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hImageList( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BackColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BackColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pclrBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Overlay( 
            /* [in] */ VARIANT *Key1,
            /* [in] */ VARIANT *Key2,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IImageListVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IImageList * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IImageList * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IImageList * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IImageList * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IImageList * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IImageList * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IImageList * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageHeight )( 
            IImageList * This,
            /* [retval][out] */ short *psImageHeight);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageHeight )( 
            IImageList * This,
            /* [in] */ short psImageHeight);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageWidth )( 
            IImageList * This,
            /* [retval][out] */ short *psImageWidth);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageWidth )( 
            IImageList * This,
            /* [in] */ short psImageWidth);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MaskColor )( 
            IImageList * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrMaskColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MaskColor )( 
            IImageList * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pclrMaskColor);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_UseMaskColor )( 
            IImageList * This,
            /* [retval][out] */ VARIANT_BOOL *pbState);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_UseMaskColor )( 
            IImageList * This,
            /* [in] */ VARIANT_BOOL pbState);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ListImages )( 
            IImageList * This,
            /* [retval][out] */ IImages **ppListImages);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ListImages )( 
            IImageList * This,
            /* [in] */ IImages *ppListImages);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hImageList )( 
            IImageList * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hImageList )( 
            IImageList * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BackColor )( 
            IImageList * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrBackColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BackColor )( 
            IImageList * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pclrBackColor);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Overlay )( 
            IImageList * This,
            /* [in] */ VARIANT *Key1,
            /* [in] */ VARIANT *Key2,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            IImageList * This);
        
        END_INTERFACE
    } IImageListVtbl;

    interface IImageList
    {
        CONST_VTBL struct IImageListVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IImageList_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IImageList_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IImageList_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IImageList_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IImageList_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IImageList_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IImageList_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IImageList_get_ImageHeight(This,psImageHeight)	\
    (This)->lpVtbl -> get_ImageHeight(This,psImageHeight)

#define IImageList_put_ImageHeight(This,psImageHeight)	\
    (This)->lpVtbl -> put_ImageHeight(This,psImageHeight)

#define IImageList_get_ImageWidth(This,psImageWidth)	\
    (This)->lpVtbl -> get_ImageWidth(This,psImageWidth)

#define IImageList_put_ImageWidth(This,psImageWidth)	\
    (This)->lpVtbl -> put_ImageWidth(This,psImageWidth)

#define IImageList_get_MaskColor(This,pclrMaskColor)	\
    (This)->lpVtbl -> get_MaskColor(This,pclrMaskColor)

#define IImageList_put_MaskColor(This,pclrMaskColor)	\
    (This)->lpVtbl -> put_MaskColor(This,pclrMaskColor)

#define IImageList_get_UseMaskColor(This,pbState)	\
    (This)->lpVtbl -> get_UseMaskColor(This,pbState)

#define IImageList_put_UseMaskColor(This,pbState)	\
    (This)->lpVtbl -> put_UseMaskColor(This,pbState)

#define IImageList_get_ListImages(This,ppListImages)	\
    (This)->lpVtbl -> get_ListImages(This,ppListImages)

#define IImageList_putref_ListImages(This,ppListImages)	\
    (This)->lpVtbl -> putref_ListImages(This,ppListImages)

#define IImageList_get_hImageList(This,phImageList)	\
    (This)->lpVtbl -> get_hImageList(This,phImageList)

#define IImageList_put_hImageList(This,phImageList)	\
    (This)->lpVtbl -> put_hImageList(This,phImageList)

#define IImageList_get_BackColor(This,pclrBackColor)	\
    (This)->lpVtbl -> get_BackColor(This,pclrBackColor)

#define IImageList_put_BackColor(This,pclrBackColor)	\
    (This)->lpVtbl -> put_BackColor(This,pclrBackColor)

#define IImageList_Overlay(This,Key1,Key2,ppPictureDisp)	\
    (This)->lpVtbl -> Overlay(This,Key1,Key2,ppPictureDisp)

#define IImageList_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_ImageHeight_Proxy( 
    IImageList * This,
    /* [retval][out] */ short *psImageHeight);


void __RPC_STUB IImageList_get_ImageHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_ImageHeight_Proxy( 
    IImageList * This,
    /* [in] */ short psImageHeight);


void __RPC_STUB IImageList_put_ImageHeight_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_ImageWidth_Proxy( 
    IImageList * This,
    /* [retval][out] */ short *psImageWidth);


void __RPC_STUB IImageList_get_ImageWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_ImageWidth_Proxy( 
    IImageList * This,
    /* [in] */ short psImageWidth);


void __RPC_STUB IImageList_put_ImageWidth_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_MaskColor_Proxy( 
    IImageList * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrMaskColor);


void __RPC_STUB IImageList_get_MaskColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_MaskColor_Proxy( 
    IImageList * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pclrMaskColor);


void __RPC_STUB IImageList_put_MaskColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_UseMaskColor_Proxy( 
    IImageList * This,
    /* [retval][out] */ VARIANT_BOOL *pbState);


void __RPC_STUB IImageList_get_UseMaskColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_UseMaskColor_Proxy( 
    IImageList * This,
    /* [in] */ VARIANT_BOOL pbState);


void __RPC_STUB IImageList_put_UseMaskColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_ListImages_Proxy( 
    IImageList * This,
    /* [retval][out] */ IImages **ppListImages);


void __RPC_STUB IImageList_get_ListImages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageList_putref_ListImages_Proxy( 
    IImageList * This,
    /* [in] */ IImages *ppListImages);


void __RPC_STUB IImageList_putref_ListImages_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_hImageList_Proxy( 
    IImageList * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phImageList);


void __RPC_STUB IImageList_get_hImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_hImageList_Proxy( 
    IImageList * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phImageList);


void __RPC_STUB IImageList_put_hImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageList_get_BackColor_Proxy( 
    IImageList * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pclrBackColor);


void __RPC_STUB IImageList_get_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageList_put_BackColor_Proxy( 
    IImageList * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pclrBackColor);


void __RPC_STUB IImageList_put_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImageList_Overlay_Proxy( 
    IImageList * This,
    /* [in] */ VARIANT *Key1,
    /* [in] */ VARIANT *Key2,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);


void __RPC_STUB IImageList_Overlay_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IImageList_AboutBox_Proxy( 
    IImageList * This);


void __RPC_STUB IImageList_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IImageList_INTERFACE_DEFINED__ */


#ifndef __ImageListEvents_DISPINTERFACE_DEFINED__
#define __ImageListEvents_DISPINTERFACE_DEFINED__

/* dispinterface ImageListEvents */
/* [helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_ImageListEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("2C247F22-8591-11D1-B16A-00C0F0283628")
    ImageListEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ImageListEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ImageListEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ImageListEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ImageListEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ImageListEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ImageListEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ImageListEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ImageListEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ImageListEventsVtbl;

    interface ImageListEvents
    {
        CONST_VTBL struct ImageListEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ImageListEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ImageListEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ImageListEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ImageListEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ImageListEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ImageListEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ImageListEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ImageListEvents_DISPINTERFACE_DEFINED__ */


#ifndef __IImages_INTERFACE_DEFINED__
#define __IImages_INTERFACE_DEFINED__

/* interface IImages */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IImages;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2C247F24-8591-11D1-B16A-00C0F0283628")
    IImages : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ short *psCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ short psCount) = 0;
        
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IImage **ppListImage) = 0;
        
        virtual /* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ControlDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IImage *ppListImage) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Picture,
            /* [retval][out] */ IImage **ppListImage) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IImage **Item) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IImage *Item) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IImagesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IImages * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IImages * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IImages * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IImages * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IImages * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IImages * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IImages * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IImages * This,
            /* [retval][out] */ short *psCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IImages * This,
            /* [in] */ short psCount);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ControlDefault )( 
            IImages * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IImage **ppListImage);
        
        /* [hidden][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ControlDefault )( 
            IImages * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IImage *ppListImage);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IImages * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Picture,
            /* [retval][out] */ IImage **ppListImage);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IImages * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IImages * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IImage **Item);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Item )( 
            IImages * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IImage *Item);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IImages * This,
            /* [in] */ VARIANT *Index);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IImages * This,
            /* [retval][out] */ IDispatch **ppNewEnum);
        
        END_INTERFACE
    } IImagesVtbl;

    interface IImages
    {
        CONST_VTBL struct IImagesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IImages_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IImages_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IImages_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IImages_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IImages_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IImages_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IImages_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IImages_get_Count(This,psCount)	\
    (This)->lpVtbl -> get_Count(This,psCount)

#define IImages_put_Count(This,psCount)	\
    (This)->lpVtbl -> put_Count(This,psCount)

#define IImages_get_ControlDefault(This,Index,ppListImage)	\
    (This)->lpVtbl -> get_ControlDefault(This,Index,ppListImage)

#define IImages_putref_ControlDefault(This,Index,ppListImage)	\
    (This)->lpVtbl -> putref_ControlDefault(This,Index,ppListImage)

#define IImages_Add(This,Index,Key,Picture,ppListImage)	\
    (This)->lpVtbl -> Add(This,Index,Key,Picture,ppListImage)

#define IImages_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IImages_get_Item(This,Index,Item)	\
    (This)->lpVtbl -> get_Item(This,Index,Item)

#define IImages_putref_Item(This,Index,Item)	\
    (This)->lpVtbl -> putref_Item(This,Index,Item)

#define IImages_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IImages__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImages_get_Count_Proxy( 
    IImages * This,
    /* [retval][out] */ short *psCount);


void __RPC_STUB IImages_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImages_put_Count_Proxy( 
    IImages * This,
    /* [in] */ short psCount);


void __RPC_STUB IImages_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IImages_get_ControlDefault_Proxy( 
    IImages * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IImage **ppListImage);


void __RPC_STUB IImages_get_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propputref][id] */ HRESULT STDMETHODCALLTYPE IImages_putref_ControlDefault_Proxy( 
    IImages * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IImage *ppListImage);


void __RPC_STUB IImages_putref_ControlDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImages_Add_Proxy( 
    IImages * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Picture,
    /* [retval][out] */ IImage **ppListImage);


void __RPC_STUB IImages_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImages_Clear_Proxy( 
    IImages * This);


void __RPC_STUB IImages_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImages_get_Item_Proxy( 
    IImages * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IImage **Item);


void __RPC_STUB IImages_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImages_putref_Item_Proxy( 
    IImages * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IImage *Item);


void __RPC_STUB IImages_putref_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImages_Remove_Proxy( 
    IImages * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IImages_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IImages__NewEnum_Proxy( 
    IImages * This,
    /* [retval][out] */ IDispatch **ppNewEnum);


void __RPC_STUB IImages__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IImages_INTERFACE_DEFINED__ */


#ifndef __IImage_INTERFACE_DEFINED__
#define __IImage_INTERFACE_DEFINED__

/* interface IImage */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IImage;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("2C247F26-8591-11D1-B16A-00C0F0283628")
    IImage : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ short *psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ short psIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Picture( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Picture( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Draw( 
            /* [in] */ /* external definition not present */ OLE_HANDLE hDC,
            /* [optional][in] */ VARIANT *x,
            /* [optional][in] */ VARIANT *y,
            /* [optional][in] */ VARIANT *Style) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ExtractIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppIconDisp) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IImageVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IImage * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IImage * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IImage * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IImage * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IImage * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IImage * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IImage * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IImage * This,
            /* [retval][out] */ short *psIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IImage * This,
            /* [in] */ short psIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IImage * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IImage * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IImage * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IImage * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Picture )( 
            IImage * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Picture )( 
            IImage * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Draw )( 
            IImage * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE hDC,
            /* [optional][in] */ VARIANT *x,
            /* [optional][in] */ VARIANT *y,
            /* [optional][in] */ VARIANT *Style);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *ExtractIcon )( 
            IImage * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppIconDisp);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IImage * This,
            /* [in] */ VARIANT pvTag);
        
        END_INTERFACE
    } IImageVtbl;

    interface IImage
    {
        CONST_VTBL struct IImageVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IImage_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IImage_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IImage_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IImage_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IImage_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IImage_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IImage_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IImage_get_Index(This,psIndex)	\
    (This)->lpVtbl -> get_Index(This,psIndex)

#define IImage_put_Index(This,psIndex)	\
    (This)->lpVtbl -> put_Index(This,psIndex)

#define IImage_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IImage_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IImage_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IImage_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IImage_get_Picture(This,ppPictureDisp)	\
    (This)->lpVtbl -> get_Picture(This,ppPictureDisp)

#define IImage_putref_Picture(This,ppPictureDisp)	\
    (This)->lpVtbl -> putref_Picture(This,ppPictureDisp)

#define IImage_Draw(This,hDC,x,y,Style)	\
    (This)->lpVtbl -> Draw(This,hDC,x,y,Style)

#define IImage_ExtractIcon(This,ppIconDisp)	\
    (This)->lpVtbl -> ExtractIcon(This,ppIconDisp)

#define IImage_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImage_get_Index_Proxy( 
    IImage * This,
    /* [retval][out] */ short *psIndex);


void __RPC_STUB IImage_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImage_put_Index_Proxy( 
    IImage * This,
    /* [in] */ short psIndex);


void __RPC_STUB IImage_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImage_get_Key_Proxy( 
    IImage * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IImage_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImage_put_Key_Proxy( 
    IImage * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IImage_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImage_get_Tag_Proxy( 
    IImage * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IImage_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImage_put_Tag_Proxy( 
    IImage * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IImage_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImage_get_Picture_Proxy( 
    IImage * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppPictureDisp);


void __RPC_STUB IImage_get_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImage_putref_Picture_Proxy( 
    IImage * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppPictureDisp);


void __RPC_STUB IImage_putref_Picture_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImage_Draw_Proxy( 
    IImage * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE hDC,
    /* [optional][in] */ VARIANT *x,
    /* [optional][in] */ VARIANT *y,
    /* [optional][in] */ VARIANT *Style);


void __RPC_STUB IImage_Draw_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImage_ExtractIcon_Proxy( 
    IImage * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppIconDisp);


void __RPC_STUB IImage_ExtractIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImage_putref_Tag_Proxy( 
    IImage * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IImage_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IImage_INTERFACE_DEFINED__ */


#ifndef __ISlider_INTERFACE_DEFINED__
#define __ISlider_INTERFACE_DEFINED__

/* interface ISlider */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_ISlider;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F08DF952-8592-11D1-B16A-00C0F0283628")
    ISlider : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__Value( 
            /* [retval][out] */ long *plValue) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__Value( 
            /* [in] */ long plValue) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_LargeChange( 
            /* [retval][out] */ long *plLargeChange) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_LargeChange( 
            /* [in] */ long plLargeChange) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SmallChange( 
            /* [retval][out] */ long *plSmallChange) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SmallChange( 
            /* [in] */ long plSmallChange) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Max( 
            /* [retval][out] */ long *plMax) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Max( 
            /* [in] */ long plMax) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Min( 
            /* [retval][out] */ long *plMin) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Min( 
            /* [in] */ long plMin) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Orientation( 
            /* [retval][out] */ OrientationConstants *pOrientation) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Orientation( 
            /* [in] */ OrientationConstants pOrientation) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectRange( 
            /* [retval][out] */ VARIANT_BOOL *pbSelectRange) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectRange( 
            /* [in] */ VARIANT_BOOL pbSelectRange) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelStart( 
            /* [retval][out] */ long *plSelStart) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelStart( 
            /* [in] */ long plSelStart) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelLength( 
            /* [retval][out] */ long *plSelLength) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelLength( 
            /* [in] */ long plSelLength) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TickStyle( 
            /* [retval][out] */ TickStyleConstants *pTickStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TickStyle( 
            /* [in] */ TickStyleConstants pTickStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TickFrequency( 
            /* [retval][out] */ long *plTickFrequency) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TickFrequency( 
            /* [in] */ long plTickFrequency) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Value( 
            /* [retval][out] */ long *plValue) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Value( 
            /* [in] */ long plValue) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants psMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BorderStyle( 
            /* [retval][out] */ BorderStyleConstants *psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BorderStyle( 
            /* [in] */ BorderStyleConstants psBorderStyle) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE ClearSel( void) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][id] */ void STDMETHODCALLTYPE DoClick( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_GetNumTicks( 
            /* [retval][out] */ long *plNumTicks) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
        virtual /* [hidden][id] */ void STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_TextPosition( 
            /* [retval][out] */ TextPositionConstants *penumTextPosition) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_TextPosition( 
            /* [in] */ TextPositionConstants penumTextPosition) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISliderVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISlider * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISlider * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISlider * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISlider * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISlider * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISlider * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISlider * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__Value )( 
            ISlider * This,
            /* [retval][out] */ long *plValue);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__Value )( 
            ISlider * This,
            /* [in] */ long plValue);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_LargeChange )( 
            ISlider * This,
            /* [retval][out] */ long *plLargeChange);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_LargeChange )( 
            ISlider * This,
            /* [in] */ long plLargeChange);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SmallChange )( 
            ISlider * This,
            /* [retval][out] */ long *plSmallChange);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SmallChange )( 
            ISlider * This,
            /* [in] */ long plSmallChange);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Max )( 
            ISlider * This,
            /* [retval][out] */ long *plMax);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Max )( 
            ISlider * This,
            /* [in] */ long plMax);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Min )( 
            ISlider * This,
            /* [retval][out] */ long *plMin);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Min )( 
            ISlider * This,
            /* [in] */ long plMin);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Orientation )( 
            ISlider * This,
            /* [retval][out] */ OrientationConstants *pOrientation);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Orientation )( 
            ISlider * This,
            /* [in] */ OrientationConstants pOrientation);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectRange )( 
            ISlider * This,
            /* [retval][out] */ VARIANT_BOOL *pbSelectRange);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectRange )( 
            ISlider * This,
            /* [in] */ VARIANT_BOOL pbSelectRange);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelStart )( 
            ISlider * This,
            /* [retval][out] */ long *plSelStart);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelStart )( 
            ISlider * This,
            /* [in] */ long plSelStart);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelLength )( 
            ISlider * This,
            /* [retval][out] */ long *plSelLength);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelLength )( 
            ISlider * This,
            /* [in] */ long plSelLength);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TickStyle )( 
            ISlider * This,
            /* [retval][out] */ TickStyleConstants *pTickStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TickStyle )( 
            ISlider * This,
            /* [in] */ TickStyleConstants pTickStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TickFrequency )( 
            ISlider * This,
            /* [retval][out] */ long *plTickFrequency);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TickFrequency )( 
            ISlider * This,
            /* [in] */ long plTickFrequency);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Value )( 
            ISlider * This,
            /* [retval][out] */ long *plValue);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Value )( 
            ISlider * This,
            /* [in] */ long plValue);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            ISlider * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            ISlider * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            ISlider * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            ISlider * This,
            /* [retval][out] */ MousePointerConstants *psMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            ISlider * This,
            /* [in] */ MousePointerConstants psMousePointer);
        
        /* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            ISlider * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            ISlider * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            ISlider * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            ISlider * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BorderStyle )( 
            ISlider * This,
            /* [retval][out] */ BorderStyleConstants *psBorderStyle);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BorderStyle )( 
            ISlider * This,
            /* [in] */ BorderStyleConstants psBorderStyle);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            ISlider * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            ISlider * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][id] */ void ( STDMETHODCALLTYPE *Refresh )( 
            ISlider * This);
        
        /* [helpcontext][helpstring][id] */ void ( STDMETHODCALLTYPE *ClearSel )( 
            ISlider * This);
        
        /* [helpcontext][helpstring][hidden][id] */ void ( STDMETHODCALLTYPE *DoClick )( 
            ISlider * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_GetNumTicks )( 
            ISlider * This,
            /* [retval][out] */ long *plNumTicks);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            ISlider * This);
        
        /* [hidden][id] */ void ( STDMETHODCALLTYPE *AboutBox )( 
            ISlider * This);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            ISlider * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            ISlider * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_TextPosition )( 
            ISlider * This,
            /* [retval][out] */ TextPositionConstants *penumTextPosition);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_TextPosition )( 
            ISlider * This,
            /* [in] */ TextPositionConstants penumTextPosition);
        
        END_INTERFACE
    } ISliderVtbl;

    interface ISlider
    {
        CONST_VTBL struct ISliderVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISlider_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISlider_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISlider_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISlider_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISlider_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISlider_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISlider_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define ISlider_get__Value(This,plValue)	\
    (This)->lpVtbl -> get__Value(This,plValue)

#define ISlider_put__Value(This,plValue)	\
    (This)->lpVtbl -> put__Value(This,plValue)

#define ISlider_get_LargeChange(This,plLargeChange)	\
    (This)->lpVtbl -> get_LargeChange(This,plLargeChange)

#define ISlider_put_LargeChange(This,plLargeChange)	\
    (This)->lpVtbl -> put_LargeChange(This,plLargeChange)

#define ISlider_get_SmallChange(This,plSmallChange)	\
    (This)->lpVtbl -> get_SmallChange(This,plSmallChange)

#define ISlider_put_SmallChange(This,plSmallChange)	\
    (This)->lpVtbl -> put_SmallChange(This,plSmallChange)

#define ISlider_get_Max(This,plMax)	\
    (This)->lpVtbl -> get_Max(This,plMax)

#define ISlider_put_Max(This,plMax)	\
    (This)->lpVtbl -> put_Max(This,plMax)

#define ISlider_get_Min(This,plMin)	\
    (This)->lpVtbl -> get_Min(This,plMin)

#define ISlider_put_Min(This,plMin)	\
    (This)->lpVtbl -> put_Min(This,plMin)

#define ISlider_get_Orientation(This,pOrientation)	\
    (This)->lpVtbl -> get_Orientation(This,pOrientation)

#define ISlider_put_Orientation(This,pOrientation)	\
    (This)->lpVtbl -> put_Orientation(This,pOrientation)

#define ISlider_get_SelectRange(This,pbSelectRange)	\
    (This)->lpVtbl -> get_SelectRange(This,pbSelectRange)

#define ISlider_put_SelectRange(This,pbSelectRange)	\
    (This)->lpVtbl -> put_SelectRange(This,pbSelectRange)

#define ISlider_get_SelStart(This,plSelStart)	\
    (This)->lpVtbl -> get_SelStart(This,plSelStart)

#define ISlider_put_SelStart(This,plSelStart)	\
    (This)->lpVtbl -> put_SelStart(This,plSelStart)

#define ISlider_get_SelLength(This,plSelLength)	\
    (This)->lpVtbl -> get_SelLength(This,plSelLength)

#define ISlider_put_SelLength(This,plSelLength)	\
    (This)->lpVtbl -> put_SelLength(This,plSelLength)

#define ISlider_get_TickStyle(This,pTickStyle)	\
    (This)->lpVtbl -> get_TickStyle(This,pTickStyle)

#define ISlider_put_TickStyle(This,pTickStyle)	\
    (This)->lpVtbl -> put_TickStyle(This,pTickStyle)

#define ISlider_get_TickFrequency(This,plTickFrequency)	\
    (This)->lpVtbl -> get_TickFrequency(This,plTickFrequency)

#define ISlider_put_TickFrequency(This,plTickFrequency)	\
    (This)->lpVtbl -> put_TickFrequency(This,plTickFrequency)

#define ISlider_get_Value(This,plValue)	\
    (This)->lpVtbl -> get_Value(This,plValue)

#define ISlider_put_Value(This,plValue)	\
    (This)->lpVtbl -> put_Value(This,plValue)

#define ISlider_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define ISlider_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define ISlider_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define ISlider_get_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,psMousePointer)

#define ISlider_put_MousePointer(This,psMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,psMousePointer)

#define ISlider_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define ISlider_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define ISlider_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define ISlider_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define ISlider_get_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> get_BorderStyle(This,psBorderStyle)

#define ISlider_put_BorderStyle(This,psBorderStyle)	\
    (This)->lpVtbl -> put_BorderStyle(This,psBorderStyle)

#define ISlider_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define ISlider_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define ISlider_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define ISlider_ClearSel(This)	\
    (This)->lpVtbl -> ClearSel(This)

#define ISlider_DoClick(This)	\
    (This)->lpVtbl -> DoClick(This)

#define ISlider_get_GetNumTicks(This,plNumTicks)	\
    (This)->lpVtbl -> get_GetNumTicks(This,plNumTicks)

#define ISlider_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#define ISlider_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define ISlider_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define ISlider_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define ISlider_get_TextPosition(This,penumTextPosition)	\
    (This)->lpVtbl -> get_TextPosition(This,penumTextPosition)

#define ISlider_put_TextPosition(This,penumTextPosition)	\
    (This)->lpVtbl -> put_TextPosition(This,penumTextPosition)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get__Value_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plValue);


void __RPC_STUB ISlider_get__Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put__Value_Proxy( 
    ISlider * This,
    /* [in] */ long plValue);


void __RPC_STUB ISlider_put__Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_LargeChange_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plLargeChange);


void __RPC_STUB ISlider_get_LargeChange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_LargeChange_Proxy( 
    ISlider * This,
    /* [in] */ long plLargeChange);


void __RPC_STUB ISlider_put_LargeChange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_SmallChange_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plSmallChange);


void __RPC_STUB ISlider_get_SmallChange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_SmallChange_Proxy( 
    ISlider * This,
    /* [in] */ long plSmallChange);


void __RPC_STUB ISlider_put_SmallChange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Max_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plMax);


void __RPC_STUB ISlider_get_Max_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Max_Proxy( 
    ISlider * This,
    /* [in] */ long plMax);


void __RPC_STUB ISlider_put_Max_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Min_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plMin);


void __RPC_STUB ISlider_get_Min_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Min_Proxy( 
    ISlider * This,
    /* [in] */ long plMin);


void __RPC_STUB ISlider_put_Min_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Orientation_Proxy( 
    ISlider * This,
    /* [retval][out] */ OrientationConstants *pOrientation);


void __RPC_STUB ISlider_get_Orientation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Orientation_Proxy( 
    ISlider * This,
    /* [in] */ OrientationConstants pOrientation);


void __RPC_STUB ISlider_put_Orientation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_SelectRange_Proxy( 
    ISlider * This,
    /* [retval][out] */ VARIANT_BOOL *pbSelectRange);


void __RPC_STUB ISlider_get_SelectRange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_SelectRange_Proxy( 
    ISlider * This,
    /* [in] */ VARIANT_BOOL pbSelectRange);


void __RPC_STUB ISlider_put_SelectRange_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_SelStart_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plSelStart);


void __RPC_STUB ISlider_get_SelStart_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_SelStart_Proxy( 
    ISlider * This,
    /* [in] */ long plSelStart);


void __RPC_STUB ISlider_put_SelStart_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_SelLength_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plSelLength);


void __RPC_STUB ISlider_get_SelLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_SelLength_Proxy( 
    ISlider * This,
    /* [in] */ long plSelLength);


void __RPC_STUB ISlider_put_SelLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_TickStyle_Proxy( 
    ISlider * This,
    /* [retval][out] */ TickStyleConstants *pTickStyle);


void __RPC_STUB ISlider_get_TickStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_TickStyle_Proxy( 
    ISlider * This,
    /* [in] */ TickStyleConstants pTickStyle);


void __RPC_STUB ISlider_put_TickStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_TickFrequency_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plTickFrequency);


void __RPC_STUB ISlider_get_TickFrequency_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_TickFrequency_Proxy( 
    ISlider * This,
    /* [in] */ long plTickFrequency);


void __RPC_STUB ISlider_put_TickFrequency_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Value_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plValue);


void __RPC_STUB ISlider_get_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Value_Proxy( 
    ISlider * This,
    /* [in] */ long plValue);


void __RPC_STUB ISlider_put_Value_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_MouseIcon_Proxy( 
    ISlider * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB ISlider_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_MouseIcon_Proxy( 
    ISlider * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ISlider_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE ISlider_putref_MouseIcon_Proxy( 
    ISlider * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB ISlider_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_MousePointer_Proxy( 
    ISlider * This,
    /* [retval][out] */ MousePointerConstants *psMousePointer);


void __RPC_STUB ISlider_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_MousePointer_Proxy( 
    ISlider * This,
    /* [in] */ MousePointerConstants psMousePointer);


void __RPC_STUB ISlider_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Enabled_Proxy( 
    ISlider * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB ISlider_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Enabled_Proxy( 
    ISlider * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB ISlider_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_hWnd_Proxy( 
    ISlider * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB ISlider_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_hWnd_Proxy( 
    ISlider * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB ISlider_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_BorderStyle_Proxy( 
    ISlider * This,
    /* [retval][out] */ BorderStyleConstants *psBorderStyle);


void __RPC_STUB ISlider_get_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_BorderStyle_Proxy( 
    ISlider * This,
    /* [in] */ BorderStyleConstants psBorderStyle);


void __RPC_STUB ISlider_put_BorderStyle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_OLEDropMode_Proxy( 
    ISlider * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB ISlider_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_OLEDropMode_Proxy( 
    ISlider * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB ISlider_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE ISlider_Refresh_Proxy( 
    ISlider * This);


void __RPC_STUB ISlider_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ void STDMETHODCALLTYPE ISlider_ClearSel_Proxy( 
    ISlider * This);


void __RPC_STUB ISlider_ClearSel_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][id] */ void STDMETHODCALLTYPE ISlider_DoClick_Proxy( 
    ISlider * This);


void __RPC_STUB ISlider_DoClick_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_GetNumTicks_Proxy( 
    ISlider * This,
    /* [retval][out] */ long *plNumTicks);


void __RPC_STUB ISlider_get_GetNumTicks_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE ISlider_OLEDrag_Proxy( 
    ISlider * This);


void __RPC_STUB ISlider_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ void STDMETHODCALLTYPE ISlider_AboutBox_Proxy( 
    ISlider * This);


void __RPC_STUB ISlider_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_Text_Proxy( 
    ISlider * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB ISlider_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_Text_Proxy( 
    ISlider * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB ISlider_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE ISlider_get_TextPosition_Proxy( 
    ISlider * This,
    /* [retval][out] */ TextPositionConstants *penumTextPosition);


void __RPC_STUB ISlider_get_TextPosition_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE ISlider_put_TextPosition_Proxy( 
    ISlider * This,
    /* [in] */ TextPositionConstants penumTextPosition);


void __RPC_STUB ISlider_put_TextPosition_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISlider_INTERFACE_DEFINED__ */


#ifndef __ISliderEvents_DISPINTERFACE_DEFINED__
#define __ISliderEvents_DISPINTERFACE_DEFINED__

/* dispinterface ISliderEvents */
/* [helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_ISliderEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("F08DF953-8592-11D1-B16A-00C0F0283628")
    ISliderEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ISliderEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISliderEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISliderEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISliderEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ISliderEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ISliderEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ISliderEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ISliderEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ISliderEventsVtbl;

    interface ISliderEvents
    {
        CONST_VTBL struct ISliderEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISliderEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISliderEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISliderEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISliderEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define ISliderEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define ISliderEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define ISliderEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ISliderEvents_DISPINTERFACE_DEFINED__ */


#ifndef __IControls_INTERFACE_DEFINED__
#define __IControls_INTERFACE_DEFINED__

/* interface IControls */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IControls;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C8A3DC00-8593-11D1-B16A-00C0F0283628")
    IControls : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ long Index,
            /* [retval][out] */ IDispatch **ppDisp) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IUnknown **ppUnk) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IControlsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IControls * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IControls * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IControls * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IControls * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IControls * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IControls * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IControls * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IControls * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IControls * This,
            /* [in] */ long Index,
            /* [retval][out] */ IDispatch **ppDisp);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IControls * This,
            /* [retval][out] */ IUnknown **ppUnk);
        
        END_INTERFACE
    } IControlsVtbl;

    interface IControls
    {
        CONST_VTBL struct IControlsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IControls_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IControls_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IControls_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IControls_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IControls_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IControls_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IControls_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IControls_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IControls_get_Item(This,Index,ppDisp)	\
    (This)->lpVtbl -> get_Item(This,Index,ppDisp)

#define IControls__NewEnum(This,ppUnk)	\
    (This)->lpVtbl -> _NewEnum(This,ppUnk)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IControls_get_Count_Proxy( 
    IControls * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IControls_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IControls_get_Item_Proxy( 
    IControls * This,
    /* [in] */ long Index,
    /* [retval][out] */ IDispatch **ppDisp);


void __RPC_STUB IControls_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IControls__NewEnum_Proxy( 
    IControls * This,
    /* [retval][out] */ IUnknown **ppUnk);


void __RPC_STUB IControls__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IControls_INTERFACE_DEFINED__ */


#ifndef __IComboItem_INTERFACE_DEFINED__
#define __IComboItem_INTERFACE_DEFINED__

/* interface IComboItem */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IComboItem;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD9DA660-8594-11D1-B16A-00C0F0283628")
    IComboItem : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__ObjectDefault( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__ObjectDefault( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Image( 
            /* [retval][out] */ VARIANT *pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Image( 
            /* [in] */ VARIANT pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Indentation( 
            /* [retval][out] */ short *psIndent) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Indentation( 
            /* [in] */ short psIndent) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Index( 
            /* [retval][out] */ long *plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Index( 
            /* [in] */ long plIndex) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Key( 
            /* [retval][out] */ BSTR *pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Key( 
            /* [in] */ BSTR pbstrKey) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Selected( 
            /* [retval][out] */ VARIANT_BOOL *pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Selected( 
            /* [in] */ VARIANT_BOOL pbSelected) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelImage( 
            /* [retval][out] */ VARIANT *pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelImage( 
            /* [in] */ VARIANT pvImage) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Tag( 
            /* [retval][out] */ VARIANT *pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Tag( 
            /* [in] */ VARIANT pvTag) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComboItemVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComboItem * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComboItem * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComboItem * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComboItem * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComboItem * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComboItem * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComboItem * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__ObjectDefault )( 
            IComboItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__ObjectDefault )( 
            IComboItem * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Image )( 
            IComboItem * This,
            /* [retval][out] */ VARIANT *pvImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Image )( 
            IComboItem * This,
            /* [in] */ VARIANT pvImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Indentation )( 
            IComboItem * This,
            /* [retval][out] */ short *psIndent);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Indentation )( 
            IComboItem * This,
            /* [in] */ short psIndent);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Index )( 
            IComboItem * This,
            /* [retval][out] */ long *plIndex);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Index )( 
            IComboItem * This,
            /* [in] */ long plIndex);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Key )( 
            IComboItem * This,
            /* [retval][out] */ BSTR *pbstrKey);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Key )( 
            IComboItem * This,
            /* [in] */ BSTR pbstrKey);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Selected )( 
            IComboItem * This,
            /* [retval][out] */ VARIANT_BOOL *pbSelected);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Selected )( 
            IComboItem * This,
            /* [in] */ VARIANT_BOOL pbSelected);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelImage )( 
            IComboItem * This,
            /* [retval][out] */ VARIANT *pvImage);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelImage )( 
            IComboItem * This,
            /* [in] */ VARIANT pvImage);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Tag )( 
            IComboItem * This,
            /* [retval][out] */ VARIANT *pvTag);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Tag )( 
            IComboItem * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Tag )( 
            IComboItem * This,
            /* [in] */ VARIANT pvTag);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IComboItem * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IComboItem * This,
            /* [in] */ BSTR pbstrText);
        
        END_INTERFACE
    } IComboItemVtbl;

    interface IComboItem
    {
        CONST_VTBL struct IComboItemVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComboItem_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComboItem_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComboItem_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComboItem_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComboItem_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComboItem_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComboItem_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IComboItem_get__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> get__ObjectDefault(This,pbstrText)

#define IComboItem_put__ObjectDefault(This,pbstrText)	\
    (This)->lpVtbl -> put__ObjectDefault(This,pbstrText)

#define IComboItem_get_Image(This,pvImage)	\
    (This)->lpVtbl -> get_Image(This,pvImage)

#define IComboItem_put_Image(This,pvImage)	\
    (This)->lpVtbl -> put_Image(This,pvImage)

#define IComboItem_get_Indentation(This,psIndent)	\
    (This)->lpVtbl -> get_Indentation(This,psIndent)

#define IComboItem_put_Indentation(This,psIndent)	\
    (This)->lpVtbl -> put_Indentation(This,psIndent)

#define IComboItem_get_Index(This,plIndex)	\
    (This)->lpVtbl -> get_Index(This,plIndex)

#define IComboItem_put_Index(This,plIndex)	\
    (This)->lpVtbl -> put_Index(This,plIndex)

#define IComboItem_get_Key(This,pbstrKey)	\
    (This)->lpVtbl -> get_Key(This,pbstrKey)

#define IComboItem_put_Key(This,pbstrKey)	\
    (This)->lpVtbl -> put_Key(This,pbstrKey)

#define IComboItem_get_Selected(This,pbSelected)	\
    (This)->lpVtbl -> get_Selected(This,pbSelected)

#define IComboItem_put_Selected(This,pbSelected)	\
    (This)->lpVtbl -> put_Selected(This,pbSelected)

#define IComboItem_get_SelImage(This,pvImage)	\
    (This)->lpVtbl -> get_SelImage(This,pvImage)

#define IComboItem_put_SelImage(This,pvImage)	\
    (This)->lpVtbl -> put_SelImage(This,pvImage)

#define IComboItem_get_Tag(This,pvTag)	\
    (This)->lpVtbl -> get_Tag(This,pvTag)

#define IComboItem_put_Tag(This,pvTag)	\
    (This)->lpVtbl -> put_Tag(This,pvTag)

#define IComboItem_putref_Tag(This,pvTag)	\
    (This)->lpVtbl -> putref_Tag(This,pvTag)

#define IComboItem_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IComboItem_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get__ObjectDefault_Proxy( 
    IComboItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IComboItem_get__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put__ObjectDefault_Proxy( 
    IComboItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IComboItem_put__ObjectDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Image_Proxy( 
    IComboItem * This,
    /* [retval][out] */ VARIANT *pvImage);


void __RPC_STUB IComboItem_get_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Image_Proxy( 
    IComboItem * This,
    /* [in] */ VARIANT pvImage);


void __RPC_STUB IComboItem_put_Image_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Indentation_Proxy( 
    IComboItem * This,
    /* [retval][out] */ short *psIndent);


void __RPC_STUB IComboItem_get_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Indentation_Proxy( 
    IComboItem * This,
    /* [in] */ short psIndent);


void __RPC_STUB IComboItem_put_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Index_Proxy( 
    IComboItem * This,
    /* [retval][out] */ long *plIndex);


void __RPC_STUB IComboItem_get_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Index_Proxy( 
    IComboItem * This,
    /* [in] */ long plIndex);


void __RPC_STUB IComboItem_put_Index_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Key_Proxy( 
    IComboItem * This,
    /* [retval][out] */ BSTR *pbstrKey);


void __RPC_STUB IComboItem_get_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Key_Proxy( 
    IComboItem * This,
    /* [in] */ BSTR pbstrKey);


void __RPC_STUB IComboItem_put_Key_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Selected_Proxy( 
    IComboItem * This,
    /* [retval][out] */ VARIANT_BOOL *pbSelected);


void __RPC_STUB IComboItem_get_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Selected_Proxy( 
    IComboItem * This,
    /* [in] */ VARIANT_BOOL pbSelected);


void __RPC_STUB IComboItem_put_Selected_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_SelImage_Proxy( 
    IComboItem * This,
    /* [retval][out] */ VARIANT *pvImage);


void __RPC_STUB IComboItem_get_SelImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_SelImage_Proxy( 
    IComboItem * This,
    /* [in] */ VARIANT pvImage);


void __RPC_STUB IComboItem_put_SelImage_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Tag_Proxy( 
    IComboItem * This,
    /* [retval][out] */ VARIANT *pvTag);


void __RPC_STUB IComboItem_get_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Tag_Proxy( 
    IComboItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IComboItem_put_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IComboItem_putref_Tag_Proxy( 
    IComboItem * This,
    /* [in] */ VARIANT pvTag);


void __RPC_STUB IComboItem_putref_Tag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItem_get_Text_Proxy( 
    IComboItem * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IComboItem_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItem_put_Text_Proxy( 
    IComboItem * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IComboItem_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComboItem_INTERFACE_DEFINED__ */


#ifndef __IComboItems_INTERFACE_DEFINED__
#define __IComboItems_INTERFACE_DEFINED__

/* interface IComboItems */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IComboItems;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD9DA662-8594-11D1-B16A-00C0F0283628")
    IComboItems : public IDispatch
    {
    public:
        virtual /* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE get__CollectionDefault( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IComboItem **ppComboItem) = 0;
        
        virtual /* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE put__CollectionDefault( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IComboItem *ppComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ long *plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Count( 
            /* [in] */ long plCount) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Item( 
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IComboItem **ppComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Item( 
            /* [in] */ VARIANT *Index,
            /* [in] */ IComboItem *ppComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Image,
            /* [optional][in] */ VARIANT *SelImage,
            /* [optional][in] */ VARIANT *Indentation,
            /* [retval][out] */ IComboItem **ppComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Clear( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ VARIANT *Index) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE _NewEnum( 
            /* [retval][out] */ IDispatch **ppNewEnum) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IComboItemsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IComboItems * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IComboItems * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IComboItems * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IComboItems * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IComboItems * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IComboItems * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IComboItems * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [hidden][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get__CollectionDefault )( 
            IComboItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IComboItem **ppComboItem);
        
        /* [hidden][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put__CollectionDefault )( 
            IComboItems * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IComboItem *ppComboItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            IComboItems * This,
            /* [retval][out] */ long *plCount);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Count )( 
            IComboItems * This,
            /* [in] */ long plCount);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Item )( 
            IComboItems * This,
            /* [in] */ VARIANT *Index,
            /* [retval][out] */ IComboItem **ppComboItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Item )( 
            IComboItems * This,
            /* [in] */ VARIANT *Index,
            /* [in] */ IComboItem *ppComboItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IComboItems * This,
            /* [optional][in] */ VARIANT *Index,
            /* [optional][in] */ VARIANT *Key,
            /* [optional][in] */ VARIANT *Text,
            /* [optional][in] */ VARIANT *Image,
            /* [optional][in] */ VARIANT *SelImage,
            /* [optional][in] */ VARIANT *Indentation,
            /* [retval][out] */ IComboItem **ppComboItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Clear )( 
            IComboItems * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Remove )( 
            IComboItems * This,
            /* [in] */ VARIANT *Index);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *_NewEnum )( 
            IComboItems * This,
            /* [retval][out] */ IDispatch **ppNewEnum);
        
        END_INTERFACE
    } IComboItemsVtbl;

    interface IComboItems
    {
        CONST_VTBL struct IComboItemsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IComboItems_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IComboItems_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IComboItems_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IComboItems_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IComboItems_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IComboItems_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IComboItems_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IComboItems_get__CollectionDefault(This,Index,ppComboItem)	\
    (This)->lpVtbl -> get__CollectionDefault(This,Index,ppComboItem)

#define IComboItems_put__CollectionDefault(This,Index,ppComboItem)	\
    (This)->lpVtbl -> put__CollectionDefault(This,Index,ppComboItem)

#define IComboItems_get_Count(This,plCount)	\
    (This)->lpVtbl -> get_Count(This,plCount)

#define IComboItems_put_Count(This,plCount)	\
    (This)->lpVtbl -> put_Count(This,plCount)

#define IComboItems_get_Item(This,Index,ppComboItem)	\
    (This)->lpVtbl -> get_Item(This,Index,ppComboItem)

#define IComboItems_put_Item(This,Index,ppComboItem)	\
    (This)->lpVtbl -> put_Item(This,Index,ppComboItem)

#define IComboItems_Add(This,Index,Key,Text,Image,SelImage,Indentation,ppComboItem)	\
    (This)->lpVtbl -> Add(This,Index,Key,Text,Image,SelImage,Indentation,ppComboItem)

#define IComboItems_Clear(This)	\
    (This)->lpVtbl -> Clear(This)

#define IComboItems_Remove(This,Index)	\
    (This)->lpVtbl -> Remove(This,Index)

#define IComboItems__NewEnum(This,ppNewEnum)	\
    (This)->lpVtbl -> _NewEnum(This,ppNewEnum)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [hidden][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItems_get__CollectionDefault_Proxy( 
    IComboItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IComboItem **ppComboItem);


void __RPC_STUB IComboItems_get__CollectionDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItems_put__CollectionDefault_Proxy( 
    IComboItems * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IComboItem *ppComboItem);


void __RPC_STUB IComboItems_put__CollectionDefault_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItems_get_Count_Proxy( 
    IComboItems * This,
    /* [retval][out] */ long *plCount);


void __RPC_STUB IComboItems_get_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItems_put_Count_Proxy( 
    IComboItems * This,
    /* [in] */ long plCount);


void __RPC_STUB IComboItems_put_Count_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IComboItems_get_Item_Proxy( 
    IComboItems * This,
    /* [in] */ VARIANT *Index,
    /* [retval][out] */ IComboItem **ppComboItem);


void __RPC_STUB IComboItems_get_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IComboItems_put_Item_Proxy( 
    IComboItems * This,
    /* [in] */ VARIANT *Index,
    /* [in] */ IComboItem *ppComboItem);


void __RPC_STUB IComboItems_put_Item_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IComboItems_Add_Proxy( 
    IComboItems * This,
    /* [optional][in] */ VARIANT *Index,
    /* [optional][in] */ VARIANT *Key,
    /* [optional][in] */ VARIANT *Text,
    /* [optional][in] */ VARIANT *Image,
    /* [optional][in] */ VARIANT *SelImage,
    /* [optional][in] */ VARIANT *Indentation,
    /* [retval][out] */ IComboItem **ppComboItem);


void __RPC_STUB IComboItems_Add_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IComboItems_Clear_Proxy( 
    IComboItems * This);


void __RPC_STUB IComboItems_Clear_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IComboItems_Remove_Proxy( 
    IComboItems * This,
    /* [in] */ VARIANT *Index);


void __RPC_STUB IComboItems_Remove_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IComboItems__NewEnum_Proxy( 
    IComboItems * This,
    /* [retval][out] */ IDispatch **ppNewEnum);


void __RPC_STUB IComboItems__NewEnum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IComboItems_INTERFACE_DEFINED__ */


#ifndef __IImageCombo_INTERFACE_DEFINED__
#define __IImageCombo_INTERFACE_DEFINED__

/* interface IImageCombo */
/* [object][oleautomation][nonextensible][dual][hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID IID_IImageCombo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD9DA664-8594-11D1-B16A-00C0F0283628")
    IImageCombo : public IDispatch
    {
    public:
        virtual /* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE get_Text( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE put_Text( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_BackColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_BackColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Enabled( 
            /* [retval][out] */ VARIANT_BOOL *pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Enabled( 
            /* [in] */ VARIANT_BOOL pbEnabled) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Font( 
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_Font( 
            /* [in] */ /* external definition not present */ IFontDisp *ppFont) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ForeColor( 
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ForeColor( 
            /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_hWnd( 
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_hWnd( 
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ImageList( 
            /* [retval][out] */ IDispatch **ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_ImageList( 
            /* [in] */ IDispatch *ppImageList) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Indentation( 
            /* [retval][out] */ short *psIndent) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Indentation( 
            /* [in] */ short psIndent) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_ComboItems( 
            /* [retval][out] */ IComboItems **ppComboItems) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_ComboItems( 
            /* [in] */ IComboItems *ppComboItems) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_Locked( 
            /* [retval][out] */ VARIANT_BOOL *pbLocked) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_Locked( 
            /* [in] */ VARIANT_BOOL pbLocked) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MouseIcon( 
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_MouseIcon( 
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_MousePointer( 
            /* [retval][out] */ MousePointerConstants *penumMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_MousePointer( 
            /* [in] */ MousePointerConstants penumMousePointer) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDragMode( 
            /* [retval][out] */ OLEDragConstants *psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDragMode( 
            /* [in] */ OLEDragConstants psOLEDragMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_OLEDropMode( 
            /* [retval][out] */ OLEDropConstants *psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_OLEDropMode( 
            /* [in] */ OLEDropConstants psOLEDropMode) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelectedItem( 
            /* [retval][out] */ IComboItem **ppIComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE putref_SelectedItem( 
            /* [in] */ IComboItem *ppIComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelectedItem( 
            /* [in] */ VARIANT *ppIComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelLength( 
            /* [retval][out] */ long *plSelLength) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelLength( 
            /* [in] */ long plSelLength) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelStart( 
            /* [retval][out] */ long *plSelStart) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelStart( 
            /* [in] */ long plSelStart) = 0;
        
        virtual /* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE get_SelText( 
            /* [retval][out] */ BSTR *pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE put_SelText( 
            /* [in] */ BSTR pbstrText) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT STDMETHODCALLTYPE get_Style( 
            /* [retval][out] */ ImageComboStyleConstants *penumStyle) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT STDMETHODCALLTYPE put_Style( 
            /* [in] */ ImageComboStyleConstants penumStyle) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT STDMETHODCALLTYPE get_UsePathSep( 
            /* [retval][out] */ VARIANT_BOOL *pbUsePathSep) = 0;
        
        virtual /* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT STDMETHODCALLTYPE put_UsePathSep( 
            /* [in] */ VARIANT_BOOL pbUsePathSep) = 0;
        
        virtual /* [hidden][id] */ HRESULT STDMETHODCALLTYPE AboutBox( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE GetFirstVisible( 
            /* [retval][out] */ IComboItem **ppIComboItem) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE Refresh( void) = 0;
        
        virtual /* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE OLEDrag( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IImageComboVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IImageCombo * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IImageCombo * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IImageCombo * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IImageCombo * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IImageCombo * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IImageCombo * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IImageCombo * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        /* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Text )( 
            IImageCombo * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Text )( 
            IImageCombo * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_BackColor )( 
            IImageCombo * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_BackColor )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Enabled )( 
            IImageCombo * This,
            /* [retval][out] */ VARIANT_BOOL *pbEnabled);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Enabled )( 
            IImageCombo * This,
            /* [in] */ VARIANT_BOOL pbEnabled);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Font )( 
            IImageCombo * This,
            /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Font )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFont);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_Font )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ IFontDisp *ppFont);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ForeColor )( 
            IImageCombo * This,
            /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ForeColor )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_hWnd )( 
            IImageCombo * This,
            /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_hWnd )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ImageList )( 
            IImageCombo * This,
            /* [retval][out] */ IDispatch **ppImageList);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ImageList )( 
            IImageCombo * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_ImageList )( 
            IImageCombo * This,
            /* [in] */ IDispatch *ppImageList);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Indentation )( 
            IImageCombo * This,
            /* [retval][out] */ short *psIndent);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Indentation )( 
            IImageCombo * This,
            /* [in] */ short psIndent);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_ComboItems )( 
            IImageCombo * This,
            /* [retval][out] */ IComboItems **ppComboItems);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_ComboItems )( 
            IImageCombo * This,
            /* [in] */ IComboItems *ppComboItems);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Locked )( 
            IImageCombo * This,
            /* [retval][out] */ VARIANT_BOOL *pbLocked);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Locked )( 
            IImageCombo * This,
            /* [in] */ VARIANT_BOOL pbLocked);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MouseIcon )( 
            IImageCombo * This,
            /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MouseIcon )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_MouseIcon )( 
            IImageCombo * This,
            /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_MousePointer )( 
            IImageCombo * This,
            /* [retval][out] */ MousePointerConstants *penumMousePointer);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_MousePointer )( 
            IImageCombo * This,
            /* [in] */ MousePointerConstants penumMousePointer);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDragMode )( 
            IImageCombo * This,
            /* [retval][out] */ OLEDragConstants *psOLEDragMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDragMode )( 
            IImageCombo * This,
            /* [in] */ OLEDragConstants psOLEDragMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_OLEDropMode )( 
            IImageCombo * This,
            /* [retval][out] */ OLEDropConstants *psOLEDropMode);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_OLEDropMode )( 
            IImageCombo * This,
            /* [in] */ OLEDropConstants psOLEDropMode);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelectedItem )( 
            IImageCombo * This,
            /* [retval][out] */ IComboItem **ppIComboItem);
        
        /* [helpcontext][helpstring][propputref][id] */ HRESULT ( STDMETHODCALLTYPE *putref_SelectedItem )( 
            IImageCombo * This,
            /* [in] */ IComboItem *ppIComboItem);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelectedItem )( 
            IImageCombo * This,
            /* [in] */ VARIANT *ppIComboItem);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelLength )( 
            IImageCombo * This,
            /* [retval][out] */ long *plSelLength);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelLength )( 
            IImageCombo * This,
            /* [in] */ long plSelLength);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelStart )( 
            IImageCombo * This,
            /* [retval][out] */ long *plSelStart);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelStart )( 
            IImageCombo * This,
            /* [in] */ long plSelStart);
        
        /* [helpcontext][helpstring][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_SelText )( 
            IImageCombo * This,
            /* [retval][out] */ BSTR *pbstrText);
        
        /* [helpcontext][helpstring][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_SelText )( 
            IImageCombo * This,
            /* [in] */ BSTR pbstrText);
        
        /* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_Style )( 
            IImageCombo * This,
            /* [retval][out] */ ImageComboStyleConstants *penumStyle);
        
        /* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_Style )( 
            IImageCombo * This,
            /* [in] */ ImageComboStyleConstants penumStyle);
        
        /* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT ( STDMETHODCALLTYPE *get_UsePathSep )( 
            IImageCombo * This,
            /* [retval][out] */ VARIANT_BOOL *pbUsePathSep);
        
        /* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT ( STDMETHODCALLTYPE *put_UsePathSep )( 
            IImageCombo * This,
            /* [in] */ VARIANT_BOOL pbUsePathSep);
        
        /* [hidden][id] */ HRESULT ( STDMETHODCALLTYPE *AboutBox )( 
            IImageCombo * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *GetFirstVisible )( 
            IImageCombo * This,
            /* [retval][out] */ IComboItem **ppIComboItem);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Refresh )( 
            IImageCombo * This);
        
        /* [helpcontext][helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *OLEDrag )( 
            IImageCombo * This);
        
        END_INTERFACE
    } IImageComboVtbl;

    interface IImageCombo
    {
        CONST_VTBL struct IImageComboVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IImageCombo_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IImageCombo_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IImageCombo_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IImageCombo_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IImageCombo_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IImageCombo_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IImageCombo_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IImageCombo_get_Text(This,pbstrText)	\
    (This)->lpVtbl -> get_Text(This,pbstrText)

#define IImageCombo_put_Text(This,pbstrText)	\
    (This)->lpVtbl -> put_Text(This,pbstrText)

#define IImageCombo_get_BackColor(This,pocBackColor)	\
    (This)->lpVtbl -> get_BackColor(This,pocBackColor)

#define IImageCombo_put_BackColor(This,pocBackColor)	\
    (This)->lpVtbl -> put_BackColor(This,pocBackColor)

#define IImageCombo_get_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> get_Enabled(This,pbEnabled)

#define IImageCombo_put_Enabled(This,pbEnabled)	\
    (This)->lpVtbl -> put_Enabled(This,pbEnabled)

#define IImageCombo_get_Font(This,ppFont)	\
    (This)->lpVtbl -> get_Font(This,ppFont)

#define IImageCombo_put_Font(This,ppFont)	\
    (This)->lpVtbl -> put_Font(This,ppFont)

#define IImageCombo_putref_Font(This,ppFont)	\
    (This)->lpVtbl -> putref_Font(This,ppFont)

#define IImageCombo_get_ForeColor(This,pocForeColor)	\
    (This)->lpVtbl -> get_ForeColor(This,pocForeColor)

#define IImageCombo_put_ForeColor(This,pocForeColor)	\
    (This)->lpVtbl -> put_ForeColor(This,pocForeColor)

#define IImageCombo_get_hWnd(This,phWnd)	\
    (This)->lpVtbl -> get_hWnd(This,phWnd)

#define IImageCombo_put_hWnd(This,phWnd)	\
    (This)->lpVtbl -> put_hWnd(This,phWnd)

#define IImageCombo_get_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> get_ImageList(This,ppImageList)

#define IImageCombo_putref_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> putref_ImageList(This,ppImageList)

#define IImageCombo_put_ImageList(This,ppImageList)	\
    (This)->lpVtbl -> put_ImageList(This,ppImageList)

#define IImageCombo_get_Indentation(This,psIndent)	\
    (This)->lpVtbl -> get_Indentation(This,psIndent)

#define IImageCombo_put_Indentation(This,psIndent)	\
    (This)->lpVtbl -> put_Indentation(This,psIndent)

#define IImageCombo_get_ComboItems(This,ppComboItems)	\
    (This)->lpVtbl -> get_ComboItems(This,ppComboItems)

#define IImageCombo_putref_ComboItems(This,ppComboItems)	\
    (This)->lpVtbl -> putref_ComboItems(This,ppComboItems)

#define IImageCombo_get_Locked(This,pbLocked)	\
    (This)->lpVtbl -> get_Locked(This,pbLocked)

#define IImageCombo_put_Locked(This,pbLocked)	\
    (This)->lpVtbl -> put_Locked(This,pbLocked)

#define IImageCombo_get_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> get_MouseIcon(This,ppMouseIcon)

#define IImageCombo_put_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> put_MouseIcon(This,ppMouseIcon)

#define IImageCombo_putref_MouseIcon(This,ppMouseIcon)	\
    (This)->lpVtbl -> putref_MouseIcon(This,ppMouseIcon)

#define IImageCombo_get_MousePointer(This,penumMousePointer)	\
    (This)->lpVtbl -> get_MousePointer(This,penumMousePointer)

#define IImageCombo_put_MousePointer(This,penumMousePointer)	\
    (This)->lpVtbl -> put_MousePointer(This,penumMousePointer)

#define IImageCombo_get_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> get_OLEDragMode(This,psOLEDragMode)

#define IImageCombo_put_OLEDragMode(This,psOLEDragMode)	\
    (This)->lpVtbl -> put_OLEDragMode(This,psOLEDragMode)

#define IImageCombo_get_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> get_OLEDropMode(This,psOLEDropMode)

#define IImageCombo_put_OLEDropMode(This,psOLEDropMode)	\
    (This)->lpVtbl -> put_OLEDropMode(This,psOLEDropMode)

#define IImageCombo_get_SelectedItem(This,ppIComboItem)	\
    (This)->lpVtbl -> get_SelectedItem(This,ppIComboItem)

#define IImageCombo_putref_SelectedItem(This,ppIComboItem)	\
    (This)->lpVtbl -> putref_SelectedItem(This,ppIComboItem)

#define IImageCombo_put_SelectedItem(This,ppIComboItem)	\
    (This)->lpVtbl -> put_SelectedItem(This,ppIComboItem)

#define IImageCombo_get_SelLength(This,plSelLength)	\
    (This)->lpVtbl -> get_SelLength(This,plSelLength)

#define IImageCombo_put_SelLength(This,plSelLength)	\
    (This)->lpVtbl -> put_SelLength(This,plSelLength)

#define IImageCombo_get_SelStart(This,plSelStart)	\
    (This)->lpVtbl -> get_SelStart(This,plSelStart)

#define IImageCombo_put_SelStart(This,plSelStart)	\
    (This)->lpVtbl -> put_SelStart(This,plSelStart)

#define IImageCombo_get_SelText(This,pbstrText)	\
    (This)->lpVtbl -> get_SelText(This,pbstrText)

#define IImageCombo_put_SelText(This,pbstrText)	\
    (This)->lpVtbl -> put_SelText(This,pbstrText)

#define IImageCombo_get_Style(This,penumStyle)	\
    (This)->lpVtbl -> get_Style(This,penumStyle)

#define IImageCombo_put_Style(This,penumStyle)	\
    (This)->lpVtbl -> put_Style(This,penumStyle)

#define IImageCombo_get_UsePathSep(This,pbUsePathSep)	\
    (This)->lpVtbl -> get_UsePathSep(This,pbUsePathSep)

#define IImageCombo_put_UsePathSep(This,pbUsePathSep)	\
    (This)->lpVtbl -> put_UsePathSep(This,pbUsePathSep)

#define IImageCombo_AboutBox(This)	\
    (This)->lpVtbl -> AboutBox(This)

#define IImageCombo_GetFirstVisible(This,ppIComboItem)	\
    (This)->lpVtbl -> GetFirstVisible(This,ppIComboItem)

#define IImageCombo_Refresh(This)	\
    (This)->lpVtbl -> Refresh(This)

#define IImageCombo_OLEDrag(This)	\
    (This)->lpVtbl -> OLEDrag(This)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Text_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IImageCombo_get_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][defaultbind][displaybind][requestedit][bindable][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Text_Proxy( 
    IImageCombo * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IImageCombo_put_Text_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_BackColor_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocBackColor);


void __RPC_STUB IImageCombo_get_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_BackColor_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pocBackColor);


void __RPC_STUB IImageCombo_put_BackColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Enabled_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ VARIANT_BOOL *pbEnabled);


void __RPC_STUB IImageCombo_get_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Enabled_Proxy( 
    IImageCombo * This,
    /* [in] */ VARIANT_BOOL pbEnabled);


void __RPC_STUB IImageCombo_put_Enabled_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Font_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ /* external definition not present */ IFontDisp **ppFont);


void __RPC_STUB IImageCombo_get_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Font_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFont);


void __RPC_STUB IImageCombo_put_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_putref_Font_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ IFontDisp *ppFont);


void __RPC_STUB IImageCombo_putref_Font_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_ForeColor_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ /* external definition not present */ OLE_COLOR *pocForeColor);


void __RPC_STUB IImageCombo_get_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_ForeColor_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ OLE_COLOR pocForeColor);


void __RPC_STUB IImageCombo_put_ForeColor_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_hWnd_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ /* external definition not present */ OLE_HANDLE *phWnd);


void __RPC_STUB IImageCombo_get_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_hWnd_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ OLE_HANDLE phWnd);


void __RPC_STUB IImageCombo_put_hWnd_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_ImageList_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ IDispatch **ppImageList);


void __RPC_STUB IImageCombo_get_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_putref_ImageList_Proxy( 
    IImageCombo * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IImageCombo_putref_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_ImageList_Proxy( 
    IImageCombo * This,
    /* [in] */ IDispatch *ppImageList);


void __RPC_STUB IImageCombo_put_ImageList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Indentation_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ short *psIndent);


void __RPC_STUB IImageCombo_get_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Indentation_Proxy( 
    IImageCombo * This,
    /* [in] */ short psIndent);


void __RPC_STUB IImageCombo_put_Indentation_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_ComboItems_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ IComboItems **ppComboItems);


void __RPC_STUB IImageCombo_get_ComboItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_putref_ComboItems_Proxy( 
    IImageCombo * This,
    /* [in] */ IComboItems *ppComboItems);


void __RPC_STUB IImageCombo_putref_ComboItems_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Locked_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ VARIANT_BOOL *pbLocked);


void __RPC_STUB IImageCombo_get_Locked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Locked_Proxy( 
    IImageCombo * This,
    /* [in] */ VARIANT_BOOL pbLocked);


void __RPC_STUB IImageCombo_put_Locked_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_MouseIcon_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ /* external definition not present */ IPictureDisp **ppMouseIcon);


void __RPC_STUB IImageCombo_get_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_MouseIcon_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IImageCombo_put_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_putref_MouseIcon_Proxy( 
    IImageCombo * This,
    /* [in] */ /* external definition not present */ IPictureDisp *ppMouseIcon);


void __RPC_STUB IImageCombo_putref_MouseIcon_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_MousePointer_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ MousePointerConstants *penumMousePointer);


void __RPC_STUB IImageCombo_get_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_MousePointer_Proxy( 
    IImageCombo * This,
    /* [in] */ MousePointerConstants penumMousePointer);


void __RPC_STUB IImageCombo_put_MousePointer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_OLEDragMode_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ OLEDragConstants *psOLEDragMode);


void __RPC_STUB IImageCombo_get_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_OLEDragMode_Proxy( 
    IImageCombo * This,
    /* [in] */ OLEDragConstants psOLEDragMode);


void __RPC_STUB IImageCombo_put_OLEDragMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_OLEDropMode_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ OLEDropConstants *psOLEDropMode);


void __RPC_STUB IImageCombo_get_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_OLEDropMode_Proxy( 
    IImageCombo * This,
    /* [in] */ OLEDropConstants psOLEDropMode);


void __RPC_STUB IImageCombo_put_OLEDropMode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_SelectedItem_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ IComboItem **ppIComboItem);


void __RPC_STUB IImageCombo_get_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propputref][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_putref_SelectedItem_Proxy( 
    IImageCombo * This,
    /* [in] */ IComboItem *ppIComboItem);


void __RPC_STUB IImageCombo_putref_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_SelectedItem_Proxy( 
    IImageCombo * This,
    /* [in] */ VARIANT *ppIComboItem);


void __RPC_STUB IImageCombo_put_SelectedItem_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_SelLength_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ long *plSelLength);


void __RPC_STUB IImageCombo_get_SelLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_SelLength_Proxy( 
    IImageCombo * This,
    /* [in] */ long plSelLength);


void __RPC_STUB IImageCombo_put_SelLength_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_SelStart_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ long *plSelStart);


void __RPC_STUB IImageCombo_get_SelStart_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_SelStart_Proxy( 
    IImageCombo * This,
    /* [in] */ long plSelStart);


void __RPC_STUB IImageCombo_put_SelStart_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_SelText_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ BSTR *pbstrText);


void __RPC_STUB IImageCombo_get_SelText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_SelText_Proxy( 
    IImageCombo * This,
    /* [in] */ BSTR pbstrText);


void __RPC_STUB IImageCombo_put_SelText_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_Style_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ ImageComboStyleConstants *penumStyle);


void __RPC_STUB IImageCombo_get_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_Style_Proxy( 
    IImageCombo * This,
    /* [in] */ ImageComboStyleConstants penumStyle);


void __RPC_STUB IImageCombo_put_Style_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][restricted][propget][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_get_UsePathSep_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ VARIANT_BOOL *pbUsePathSep);


void __RPC_STUB IImageCombo_get_UsePathSep_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][hidden][restricted][propput][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_put_UsePathSep_Proxy( 
    IImageCombo * This,
    /* [in] */ VARIANT_BOOL pbUsePathSep);


void __RPC_STUB IImageCombo_put_UsePathSep_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [hidden][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_AboutBox_Proxy( 
    IImageCombo * This);


void __RPC_STUB IImageCombo_AboutBox_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_GetFirstVisible_Proxy( 
    IImageCombo * This,
    /* [retval][out] */ IComboItem **ppIComboItem);


void __RPC_STUB IImageCombo_GetFirstVisible_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_Refresh_Proxy( 
    IImageCombo * This);


void __RPC_STUB IImageCombo_Refresh_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpcontext][helpstring][id] */ HRESULT STDMETHODCALLTYPE IImageCombo_OLEDrag_Proxy( 
    IImageCombo * This);


void __RPC_STUB IImageCombo_OLEDrag_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IImageCombo_INTERFACE_DEFINED__ */


#ifndef __DImageComboEvents_DISPINTERFACE_DEFINED__
#define __DImageComboEvents_DISPINTERFACE_DEFINED__

/* dispinterface DImageComboEvents */
/* [hidden][helpcontext][helpstring][uuid] */ 


EXTERN_C const IID DIID_DImageComboEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("DD9DA665-8594-11D1-B16A-00C0F0283628")
    DImageComboEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct DImageComboEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            DImageComboEvents * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            DImageComboEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            DImageComboEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            DImageComboEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            DImageComboEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            DImageComboEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            DImageComboEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } DImageComboEventsVtbl;

    interface DImageComboEvents
    {
        CONST_VTBL struct DImageComboEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define DImageComboEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define DImageComboEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define DImageComboEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define DImageComboEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define DImageComboEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define DImageComboEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define DImageComboEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __DImageComboEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_DataObject;

#ifdef __cplusplus

class DECLSPEC_UUID("2334D2B2-713E-11CF-8AE5-00AA00C00905")
DataObject;
#endif

EXTERN_C const CLSID CLSID_DataObjectFiles;

#ifdef __cplusplus

class DECLSPEC_UUID("2334D2B4-713E-11CF-8AE5-00AA00C00905")
DataObjectFiles;
#endif

EXTERN_C const CLSID CLSID_TabStrip;

#ifdef __cplusplus

class DECLSPEC_UUID("1EFB6596-857C-11D1-B16A-00C0F0283628")
TabStrip;
#endif

EXTERN_C const CLSID CLSID_Tabs;

#ifdef __cplusplus

class DECLSPEC_UUID("1EFB6598-857C-11D1-B16A-00C0F0283628")
Tabs;
#endif

EXTERN_C const CLSID CLSID_Tab;

#ifdef __cplusplus

class DECLSPEC_UUID("1EFB659A-857C-11D1-B16A-00C0F0283628")
Tab;
#endif

EXTERN_C const CLSID CLSID_Toolbar;

#ifdef __cplusplus

class DECLSPEC_UUID("66833FE6-8583-11D1-B16A-00C0F0283628")
Toolbar;
#endif

EXTERN_C const CLSID CLSID_Buttons;

#ifdef __cplusplus

class DECLSPEC_UUID("66833FE8-8583-11D1-B16A-00C0F0283628")
Buttons;
#endif

EXTERN_C const CLSID CLSID_ButtonMenus;

#ifdef __cplusplus

class DECLSPEC_UUID("66833FEC-8583-11D1-B16A-00C0F0283628")
ButtonMenus;
#endif

EXTERN_C const CLSID CLSID_StatusBar;

#ifdef __cplusplus

class DECLSPEC_UUID("8E3867A3-8586-11D1-B16A-00C0F0283628")
StatusBar;
#endif

EXTERN_C const CLSID CLSID_Panels;

#ifdef __cplusplus

class DECLSPEC_UUID("8E3867A5-8586-11D1-B16A-00C0F0283628")
Panels;
#endif

EXTERN_C const CLSID CLSID_ProgressBar;

#ifdef __cplusplus

class DECLSPEC_UUID("35053A22-8589-11D1-B16A-00C0F0283628")
ProgressBar;
#endif

EXTERN_C const CLSID CLSID_TreeView;

#ifdef __cplusplus

class DECLSPEC_UUID("C74190B6-8589-11D1-B16A-00C0F0283628")
TreeView;
#endif

EXTERN_C const CLSID CLSID_Nodes;

#ifdef __cplusplus

class DECLSPEC_UUID("0713E8C0-850A-101B-AFC0-4210102A8DA7")
Nodes;
#endif

EXTERN_C const CLSID CLSID_ListView;

#ifdef __cplusplus

class DECLSPEC_UUID("BDD1F04B-858B-11D1-B16A-00C0F0283628")
ListView;
#endif

EXTERN_C const CLSID CLSID_ListItems;

#ifdef __cplusplus

class DECLSPEC_UUID("BDD1F04D-858B-11D1-B16A-00C0F0283628")
ListItems;
#endif

EXTERN_C const CLSID CLSID_ColumnHeaders;

#ifdef __cplusplus

class DECLSPEC_UUID("0713E8C6-850A-101B-AFC0-4210102A8DA7")
ColumnHeaders;
#endif

EXTERN_C const CLSID CLSID_ListSubItems;

#ifdef __cplusplus

class DECLSPEC_UUID("BDD1F054-858B-11D1-B16A-00C0F0283628")
ListSubItems;
#endif

EXTERN_C const CLSID CLSID_ListSubItem;

#ifdef __cplusplus

class DECLSPEC_UUID("BDD1F056-858B-11D1-B16A-00C0F0283628")
ListSubItem;
#endif

EXTERN_C const CLSID CLSID_ImageList;

#ifdef __cplusplus

class DECLSPEC_UUID("2C247F23-8591-11D1-B16A-00C0F0283628")
ImageList;
#endif

EXTERN_C const CLSID CLSID_ListImages;

#ifdef __cplusplus

class DECLSPEC_UUID("2C247F25-8591-11D1-B16A-00C0F0283628")
ListImages;
#endif

EXTERN_C const CLSID CLSID_ListImage;

#ifdef __cplusplus

class DECLSPEC_UUID("2C247F27-8591-11D1-B16A-00C0F0283628")
ListImage;
#endif

EXTERN_C const CLSID CLSID_Slider;

#ifdef __cplusplus

class DECLSPEC_UUID("F08DF954-8592-11D1-B16A-00C0F0283628")
Slider;
#endif

EXTERN_C const CLSID CLSID_Controls;

#ifdef __cplusplus

class DECLSPEC_UUID("C8A3DC01-8593-11D1-B16A-00C0F0283628")
Controls;
#endif

EXTERN_C const CLSID CLSID_ComboItem;

#ifdef __cplusplus

class DECLSPEC_UUID("DD9DA661-8594-11D1-B16A-00C0F0283628")
ComboItem;
#endif

EXTERN_C const CLSID CLSID_ComboItems;

#ifdef __cplusplus

class DECLSPEC_UUID("DD9DA663-8594-11D1-B16A-00C0F0283628")
ComboItems;
#endif

EXTERN_C const CLSID CLSID_ImageCombo;

#ifdef __cplusplus

class DECLSPEC_UUID("DD9DA666-8594-11D1-B16A-00C0F0283628")
ImageCombo;
#endif
#endif /* __MSComctlLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


