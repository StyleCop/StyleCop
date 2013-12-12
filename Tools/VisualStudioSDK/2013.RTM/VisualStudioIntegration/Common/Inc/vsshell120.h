

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.00.0601 */
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

/* verify that the <rpcsal.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCSAL_H_VERSION__
#define __REQUIRED_RPCSAL_H_VERSION__ 100
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __vsshell120_h__
#define __vsshell120_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IVsPackageLoadEvents_FWD_DEFINED__
#define __IVsPackageLoadEvents_FWD_DEFINED__
typedef interface IVsPackageLoadEvents IVsPackageLoadEvents;

#endif 	/* __IVsPackageLoadEvents_FWD_DEFINED__ */


#ifndef __IVsShell6_FWD_DEFINED__
#define __IVsShell6_FWD_DEFINED__
typedef interface IVsShell6 IVsShell6;

#endif 	/* __IVsShell6_FWD_DEFINED__ */


#ifndef __IVsFileBackup2_FWD_DEFINED__
#define __IVsFileBackup2_FWD_DEFINED__
typedef interface IVsFileBackup2 IVsFileBackup2;

#endif 	/* __IVsFileBackup2_FWD_DEFINED__ */


#ifndef __IVsXMLMemberDataDeprecation_FWD_DEFINED__
#define __IVsXMLMemberDataDeprecation_FWD_DEFINED__
typedef interface IVsXMLMemberDataDeprecation IVsXMLMemberDataDeprecation;

#endif 	/* __IVsXMLMemberDataDeprecation_FWD_DEFINED__ */


#ifndef __IVsXMLMemberData5_FWD_DEFINED__
#define __IVsXMLMemberData5_FWD_DEFINED__
typedef interface IVsXMLMemberData5 IVsXMLMemberData5;

#endif 	/* __IVsXMLMemberData5_FWD_DEFINED__ */


#ifndef __IVsConnectedServiceProperties_FWD_DEFINED__
#define __IVsConnectedServiceProperties_FWD_DEFINED__
typedef interface IVsConnectedServiceProperties IVsConnectedServiceProperties;

#endif 	/* __IVsConnectedServiceProperties_FWD_DEFINED__ */


#ifndef __IVsPersistConnectedServices_FWD_DEFINED__
#define __IVsPersistConnectedServices_FWD_DEFINED__
typedef interface IVsPersistConnectedServices IVsPersistConnectedServices;

#endif 	/* __IVsPersistConnectedServices_FWD_DEFINED__ */


#ifndef __IVsConnectedServiceInstanceReference_FWD_DEFINED__
#define __IVsConnectedServiceInstanceReference_FWD_DEFINED__
typedef interface IVsConnectedServiceInstanceReference IVsConnectedServiceInstanceReference;

#endif 	/* __IVsConnectedServiceInstanceReference_FWD_DEFINED__ */


#ifndef __IVsConnectedServiceInstanceReferenceProviderContext_FWD_DEFINED__
#define __IVsConnectedServiceInstanceReferenceProviderContext_FWD_DEFINED__
typedef interface IVsConnectedServiceInstanceReferenceProviderContext IVsConnectedServiceInstanceReferenceProviderContext;

#endif 	/* __IVsConnectedServiceInstanceReferenceProviderContext_FWD_DEFINED__ */


#ifndef __IVsUIShellArrangeWindows_FWD_DEFINED__
#define __IVsUIShellArrangeWindows_FWD_DEFINED__
typedef interface IVsUIShellArrangeWindows IVsUIShellArrangeWindows;

#endif 	/* __IVsUIShellArrangeWindows_FWD_DEFINED__ */


#ifndef __IVsRunningDocumentTable4_FWD_DEFINED__
#define __IVsRunningDocumentTable4_FWD_DEFINED__
typedef interface IVsRunningDocumentTable4 IVsRunningDocumentTable4;

#endif 	/* __IVsRunningDocumentTable4_FWD_DEFINED__ */


#ifndef __IVsUIHierarchyNativeWindow_FWD_DEFINED__
#define __IVsUIHierarchyNativeWindow_FWD_DEFINED__
typedef interface IVsUIHierarchyNativeWindow IVsUIHierarchyNativeWindow;

#endif 	/* __IVsUIHierarchyNativeWindow_FWD_DEFINED__ */


#ifndef __IVsPropertiesInfo_FWD_DEFINED__
#define __IVsPropertiesInfo_FWD_DEFINED__
typedef interface IVsPropertiesInfo IVsPropertiesInfo;

#endif 	/* __IVsPropertiesInfo_FWD_DEFINED__ */


#ifndef __IVsTaskSchedulerService2_FWD_DEFINED__
#define __IVsTaskSchedulerService2_FWD_DEFINED__
typedef interface IVsTaskSchedulerService2 IVsTaskSchedulerService2;

#endif 	/* __IVsTaskSchedulerService2_FWD_DEFINED__ */


#ifndef __IVsBuildManagerAccessor3_FWD_DEFINED__
#define __IVsBuildManagerAccessor3_FWD_DEFINED__
typedef interface IVsBuildManagerAccessor3 IVsBuildManagerAccessor3;

#endif 	/* __IVsBuildManagerAccessor3_FWD_DEFINED__ */


#ifndef __IVsWindowFrame4_FWD_DEFINED__
#define __IVsWindowFrame4_FWD_DEFINED__
typedef interface IVsWindowFrame4 IVsWindowFrame4;

#endif 	/* __IVsWindowFrame4_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "vsshell.h"
#include "vsshell2.h"
#include "vsshell80.h"
#include "vsshell90.h"
#include "vsshell100.h"
#include "vsshell110.h"

#ifdef __cplusplus
extern "C"{
#endif 


/* interface __MIDL_itf_vsshell120_0000_0000 */
/* [local] */ 

#pragma once

enum __VSPROPID6
    {
        VSPROPID_IsSolutionInEndRetargetingBatch	= -8043,
        VSPROPID_FIRST6	= -8043
    } ;
typedef /* [public] */ DWORD VSPROPID6;


enum __VSHPROPID6
    {
        VSHPROPID_ConnectedServicesPersistence	= -2133,
        VSHPROPID_ProjectRetargeting	= -2134,
        VSHPROPID_ShowAllProjectFilesInProjectView	= -2135,
        VSHPROPID_FIRST6	= -2135
    } ;
typedef /* [public] */ DWORD VSHPROPID6;


enum __VSTASKCONTINUATIONOPTIONS2
    {
        VSTCO_CancelWithParent	= 0x20000000
    } ;
typedef DWORD VSTASKCONTINUATIONOPTIONS2;


enum __VSTASKCREATIONOPTIONS2
    {
        VSTCRO_CancelWithParent	= VSTCO_CancelWithParent
    } ;
typedef DWORD VSTASKCREATIONOPTIONS2;


enum __VSDBGLAUNCHFLAGS120
    {
        DBGLAUNCH_ALLOW_EVENTS_AFTER_STOPPED	= 0x80000
    } ;
typedef DWORD VSDBGLAUNCHFLAGS120;



extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0000_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0000_v0_0_s_ifspec;

#ifndef __IVsPackageLoadEvents_INTERFACE_DEFINED__
#define __IVsPackageLoadEvents_INTERFACE_DEFINED__

/* interface IVsPackageLoadEvents */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsPackageLoadEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("21861181-88B1-410A-BCA8-441FB3F3F1FC")
    IVsPackageLoadEvents : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE OnPackageLoaded( 
            /* [in] */ __RPC__in REFGUID packageGuid,
            /* [in] */ __RPC__in_opt IVsPackage *package) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsPackageLoadEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsPackageLoadEvents * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsPackageLoadEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsPackageLoadEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *OnPackageLoaded )( 
            __RPC__in IVsPackageLoadEvents * This,
            /* [in] */ __RPC__in REFGUID packageGuid,
            /* [in] */ __RPC__in_opt IVsPackage *package);
        
        END_INTERFACE
    } IVsPackageLoadEventsVtbl;

    interface IVsPackageLoadEvents
    {
        CONST_VTBL struct IVsPackageLoadEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsPackageLoadEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsPackageLoadEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsPackageLoadEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsPackageLoadEvents_OnPackageLoaded(This,packageGuid,package)	\
    ( (This)->lpVtbl -> OnPackageLoaded(This,packageGuid,package) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsPackageLoadEvents_INTERFACE_DEFINED__ */


#ifndef __IVsShell6_INTERFACE_DEFINED__
#define __IVsShell6_INTERFACE_DEFINED__

/* interface IVsShell6 */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsShell6;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("D111DB4B-584E-4F93-BCEC-5F7E0990E9E7")
    IVsShell6 : public IVsShell5
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE AdvisePackageLoadEvents( 
            /* [in] */ __RPC__in_opt IVsPackageLoadEvents *eventSink,
            /* [retval][out] */ __RPC__out VSCOOKIE *pCookie) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE UnadvisePackageLoadEvents( 
            /* [in] */ VSCOOKIE cookie) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE NotifyExtensionSettingsChanged( void) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsShell6Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsShell6 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsShell6 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsShell6 * This);
        
        HRESULT ( STDMETHODCALLTYPE *LoadPackageWithContext )( 
            __RPC__in IVsShell6 * This,
            /* [in] */ __RPC__in REFGUID packageGuid,
            /* [in] */ int reason,
            /* [in] */ __RPC__in REFGUID context,
            /* [retval][out] */ __RPC__deref_out_opt IVsPackage **package);
        
        HRESULT ( STDMETHODCALLTYPE *CreatePackageExtension )( 
            __RPC__in IVsShell6 * This,
            /* [in] */ __RPC__in REFGUID package,
            /* [in] */ __RPC__in REFCLSID extensionPoint,
            /* [in] */ __RPC__in REFGUID instance,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **ppunk);
        
        HRESULT ( STDMETHODCALLTYPE *AdvisePackageLoadEvents )( 
            __RPC__in IVsShell6 * This,
            /* [in] */ __RPC__in_opt IVsPackageLoadEvents *eventSink,
            /* [retval][out] */ __RPC__out VSCOOKIE *pCookie);
        
        HRESULT ( STDMETHODCALLTYPE *UnadvisePackageLoadEvents )( 
            __RPC__in IVsShell6 * This,
            /* [in] */ VSCOOKIE cookie);
        
        HRESULT ( STDMETHODCALLTYPE *NotifyExtensionSettingsChanged )( 
            __RPC__in IVsShell6 * This);
        
        END_INTERFACE
    } IVsShell6Vtbl;

    interface IVsShell6
    {
        CONST_VTBL struct IVsShell6Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsShell6_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsShell6_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsShell6_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsShell6_LoadPackageWithContext(This,packageGuid,reason,context,package)	\
    ( (This)->lpVtbl -> LoadPackageWithContext(This,packageGuid,reason,context,package) ) 

#define IVsShell6_CreatePackageExtension(This,package,extensionPoint,instance,ppunk)	\
    ( (This)->lpVtbl -> CreatePackageExtension(This,package,extensionPoint,instance,ppunk) ) 


#define IVsShell6_AdvisePackageLoadEvents(This,eventSink,pCookie)	\
    ( (This)->lpVtbl -> AdvisePackageLoadEvents(This,eventSink,pCookie) ) 

#define IVsShell6_UnadvisePackageLoadEvents(This,cookie)	\
    ( (This)->lpVtbl -> UnadvisePackageLoadEvents(This,cookie) ) 

#define IVsShell6_NotifyExtensionSettingsChanged(This)	\
    ( (This)->lpVtbl -> NotifyExtensionSettingsChanged(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsShell6_INTERFACE_DEFINED__ */


#ifndef __IVsFileBackup2_INTERFACE_DEFINED__
#define __IVsFileBackup2_INTERFACE_DEFINED__

/* interface IVsFileBackup2 */
/* [object][uuid] */ 


EXTERN_C const IID IID_IVsFileBackup2;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("4FFA05A4-6C77-4952-AB60-B33E0A6416C5")
    IVsFileBackup2 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE BackupFileAsync( 
            /* [in] */ __RPC__in LPCOLESTR szBackupFileName,
            /* [retval][out] */ __RPC__deref_out_opt IVsTask **ppTask) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE HasChangedSinceLastBackup( 
            /* [retval][out] */ __RPC__out VARIANT_BOOL *pbObsolete) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsFileBackup2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsFileBackup2 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsFileBackup2 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsFileBackup2 * This);
        
        HRESULT ( STDMETHODCALLTYPE *BackupFileAsync )( 
            __RPC__in IVsFileBackup2 * This,
            /* [in] */ __RPC__in LPCOLESTR szBackupFileName,
            /* [retval][out] */ __RPC__deref_out_opt IVsTask **ppTask);
        
        HRESULT ( STDMETHODCALLTYPE *HasChangedSinceLastBackup )( 
            __RPC__in IVsFileBackup2 * This,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *pbObsolete);
        
        END_INTERFACE
    } IVsFileBackup2Vtbl;

    interface IVsFileBackup2
    {
        CONST_VTBL struct IVsFileBackup2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsFileBackup2_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsFileBackup2_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsFileBackup2_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsFileBackup2_BackupFileAsync(This,szBackupFileName,ppTask)	\
    ( (This)->lpVtbl -> BackupFileAsync(This,szBackupFileName,ppTask) ) 

#define IVsFileBackup2_HasChangedSinceLastBackup(This,pbObsolete)	\
    ( (This)->lpVtbl -> HasChangedSinceLastBackup(This,pbObsolete) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsFileBackup2_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0003 */
/* [local] */ 


enum __XMLMEMBERDATA_DEPRECATION_TYPE
    {
        XMLMEMBERDATA_DEPRECATION_TYPE_DEPRECATE	= 0,
        XMLMEMBERDATA_DEPRECATION_TYPE_REMOVE	= 0x1
    } ;
typedef DWORD XMLMEMBERDATA_DEPRECATION_TYPE;



extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0003_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0003_v0_0_s_ifspec;

#ifndef __IVsXMLMemberDataDeprecation_INTERFACE_DEFINED__
#define __IVsXMLMemberDataDeprecation_INTERFACE_DEFINED__

/* interface IVsXMLMemberDataDeprecation */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsXMLMemberDataDeprecation;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("AF87BDDD-FB89-4787-9809-1749FD500ABC")
    IVsXMLMemberDataDeprecation : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Type( 
            /* [retval][out] */ __RPC__out XMLMEMBERDATA_DEPRECATION_TYPE *pType) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Description( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrDescription) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsXMLMemberDataDeprecationVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsXMLMemberDataDeprecation * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsXMLMemberDataDeprecation * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsXMLMemberDataDeprecation * This);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Type )( 
            __RPC__in IVsXMLMemberDataDeprecation * This,
            /* [retval][out] */ __RPC__out XMLMEMBERDATA_DEPRECATION_TYPE *pType);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Description )( 
            __RPC__in IVsXMLMemberDataDeprecation * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrDescription);
        
        END_INTERFACE
    } IVsXMLMemberDataDeprecationVtbl;

    interface IVsXMLMemberDataDeprecation
    {
        CONST_VTBL struct IVsXMLMemberDataDeprecationVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsXMLMemberDataDeprecation_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsXMLMemberDataDeprecation_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsXMLMemberDataDeprecation_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsXMLMemberDataDeprecation_get_Type(This,pType)	\
    ( (This)->lpVtbl -> get_Type(This,pType) ) 

#define IVsXMLMemberDataDeprecation_get_Description(This,pbstrDescription)	\
    ( (This)->lpVtbl -> get_Description(This,pbstrDescription) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsXMLMemberDataDeprecation_INTERFACE_DEFINED__ */


#ifndef __IVsXMLMemberData5_INTERFACE_DEFINED__
#define __IVsXMLMemberData5_INTERFACE_DEFINED__

/* interface IVsXMLMemberData5 */
/* [object][custom][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsXMLMemberData5;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ABF5E2FB-3F36-4B99-B384-BDF85D598C6C")
    IVsXMLMemberData5 : public IVsXMLMemberData4
    {
    public:
        virtual /* [custom] */ HRESULT STDMETHODCALLTYPE GetDeprecation( 
            /* [retval][out] */ __RPC__deref_out_opt IVsXMLMemberDataDeprecation **ppDeprecation) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsXMLMemberData5Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsXMLMemberData5 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsXMLMemberData5 * This);
        
        HRESULT ( STDMETHODCALLTYPE *SetOptions )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ XMLMEMBERDATA_OPTIONS options);
        
        HRESULT ( STDMETHODCALLTYPE *GetSummaryText )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrSummary);
        
        HRESULT ( STDMETHODCALLTYPE *GetParamCount )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__out long *piParams);
        
        HRESULT ( STDMETHODCALLTYPE *GetParamTextAt )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ long iParam,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrName,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrText);
        
        HRESULT ( STDMETHODCALLTYPE *GetReturnsText )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrReturns);
        
        HRESULT ( STDMETHODCALLTYPE *GetRemarksText )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrRemarks);
        
        HRESULT ( STDMETHODCALLTYPE *GetExceptionCount )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__out long *piExceptions);
        
        HRESULT ( STDMETHODCALLTYPE *GetExceptionTextAt )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ long iException,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrType,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrText);
        
        HRESULT ( STDMETHODCALLTYPE *GetFilterPriority )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__out long *piFilterPriority);
        
        HRESULT ( STDMETHODCALLTYPE *GetCompletionListText )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrCompletionList);
        
        HRESULT ( STDMETHODCALLTYPE *GetCompletionListTextAt )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ long iParam,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrCompletionList);
        
        HRESULT ( STDMETHODCALLTYPE *GetPermissionSet )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrPermissionSetXML);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeParamCount )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [out] */ __RPC__out long *piTypeParams);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeParamTextAt )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [in] */ long iTypeParam,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrName,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrText);
        
        /* [custom] */ HRESULT ( STDMETHODCALLTYPE *GetAssociatedCapabilities )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [retval][out] */ __RPC__deref_out_opt SAFEARRAY * *prgCapabilities);
        
        /* [custom] */ HRESULT ( STDMETHODCALLTYPE *GetDeprecation )( 
            __RPC__in IVsXMLMemberData5 * This,
            /* [retval][out] */ __RPC__deref_out_opt IVsXMLMemberDataDeprecation **ppDeprecation);
        
        END_INTERFACE
    } IVsXMLMemberData5Vtbl;

    interface IVsXMLMemberData5
    {
        CONST_VTBL struct IVsXMLMemberData5Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsXMLMemberData5_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsXMLMemberData5_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsXMLMemberData5_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsXMLMemberData5_SetOptions(This,options)	\
    ( (This)->lpVtbl -> SetOptions(This,options) ) 

#define IVsXMLMemberData5_GetSummaryText(This,pbstrSummary)	\
    ( (This)->lpVtbl -> GetSummaryText(This,pbstrSummary) ) 

#define IVsXMLMemberData5_GetParamCount(This,piParams)	\
    ( (This)->lpVtbl -> GetParamCount(This,piParams) ) 

#define IVsXMLMemberData5_GetParamTextAt(This,iParam,pbstrName,pbstrText)	\
    ( (This)->lpVtbl -> GetParamTextAt(This,iParam,pbstrName,pbstrText) ) 

#define IVsXMLMemberData5_GetReturnsText(This,pbstrReturns)	\
    ( (This)->lpVtbl -> GetReturnsText(This,pbstrReturns) ) 

#define IVsXMLMemberData5_GetRemarksText(This,pbstrRemarks)	\
    ( (This)->lpVtbl -> GetRemarksText(This,pbstrRemarks) ) 

#define IVsXMLMemberData5_GetExceptionCount(This,piExceptions)	\
    ( (This)->lpVtbl -> GetExceptionCount(This,piExceptions) ) 

#define IVsXMLMemberData5_GetExceptionTextAt(This,iException,pbstrType,pbstrText)	\
    ( (This)->lpVtbl -> GetExceptionTextAt(This,iException,pbstrType,pbstrText) ) 

#define IVsXMLMemberData5_GetFilterPriority(This,piFilterPriority)	\
    ( (This)->lpVtbl -> GetFilterPriority(This,piFilterPriority) ) 

#define IVsXMLMemberData5_GetCompletionListText(This,pbstrCompletionList)	\
    ( (This)->lpVtbl -> GetCompletionListText(This,pbstrCompletionList) ) 

#define IVsXMLMemberData5_GetCompletionListTextAt(This,iParam,pbstrCompletionList)	\
    ( (This)->lpVtbl -> GetCompletionListTextAt(This,iParam,pbstrCompletionList) ) 

#define IVsXMLMemberData5_GetPermissionSet(This,pbstrPermissionSetXML)	\
    ( (This)->lpVtbl -> GetPermissionSet(This,pbstrPermissionSetXML) ) 

#define IVsXMLMemberData5_GetTypeParamCount(This,piTypeParams)	\
    ( (This)->lpVtbl -> GetTypeParamCount(This,piTypeParams) ) 

#define IVsXMLMemberData5_GetTypeParamTextAt(This,iTypeParam,pbstrName,pbstrText)	\
    ( (This)->lpVtbl -> GetTypeParamTextAt(This,iTypeParam,pbstrName,pbstrText) ) 


#define IVsXMLMemberData5_GetAssociatedCapabilities(This,prgCapabilities)	\
    ( (This)->lpVtbl -> GetAssociatedCapabilities(This,prgCapabilities) ) 


#define IVsXMLMemberData5_GetDeprecation(This,ppDeprecation)	\
    ( (This)->lpVtbl -> GetDeprecation(This,ppDeprecation) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsXMLMemberData5_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0005 */
/* [local] */ 




extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0005_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0005_v0_0_s_ifspec;

#ifndef __IVsConnectedServiceProperties_INTERFACE_DEFINED__
#define __IVsConnectedServiceProperties_INTERFACE_DEFINED__

/* interface IVsConnectedServiceProperties */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsConnectedServiceProperties;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("6ED0B110-2132-4675-9F87-7715B312CCC2")
    IVsConnectedServiceProperties : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ServiceIdentity( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pszIdentity) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Collection( 
            /* [retval][out] */ __RPC__deref_out_opt IVsPersistConnectedServices **ppCollection) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetProperty( 
            /* [in] */ __RPC__in LPCOLESTR szPropertyName,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pszValue) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SetProperty( 
            /* [in] */ __RPC__in LPCOLESTR szPropertyName,
            /* [in] */ __RPC__in LPCOLESTR szValue) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsConnectedServicePropertiesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsConnectedServiceProperties * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsConnectedServiceProperties * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsConnectedServiceProperties * This);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ServiceIdentity )( 
            __RPC__in IVsConnectedServiceProperties * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pszIdentity);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Collection )( 
            __RPC__in IVsConnectedServiceProperties * This,
            /* [retval][out] */ __RPC__deref_out_opt IVsPersistConnectedServices **ppCollection);
        
        HRESULT ( STDMETHODCALLTYPE *GetProperty )( 
            __RPC__in IVsConnectedServiceProperties * This,
            /* [in] */ __RPC__in LPCOLESTR szPropertyName,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pszValue);
        
        HRESULT ( STDMETHODCALLTYPE *SetProperty )( 
            __RPC__in IVsConnectedServiceProperties * This,
            /* [in] */ __RPC__in LPCOLESTR szPropertyName,
            /* [in] */ __RPC__in LPCOLESTR szValue);
        
        END_INTERFACE
    } IVsConnectedServicePropertiesVtbl;

    interface IVsConnectedServiceProperties
    {
        CONST_VTBL struct IVsConnectedServicePropertiesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsConnectedServiceProperties_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsConnectedServiceProperties_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsConnectedServiceProperties_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsConnectedServiceProperties_get_ServiceIdentity(This,pszIdentity)	\
    ( (This)->lpVtbl -> get_ServiceIdentity(This,pszIdentity) ) 

#define IVsConnectedServiceProperties_get_Collection(This,ppCollection)	\
    ( (This)->lpVtbl -> get_Collection(This,ppCollection) ) 

#define IVsConnectedServiceProperties_GetProperty(This,szPropertyName,pszValue)	\
    ( (This)->lpVtbl -> GetProperty(This,szPropertyName,pszValue) ) 

#define IVsConnectedServiceProperties_SetProperty(This,szPropertyName,szValue)	\
    ( (This)->lpVtbl -> SetProperty(This,szPropertyName,szValue) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsConnectedServiceProperties_INTERFACE_DEFINED__ */


#ifndef __IVsPersistConnectedServices_INTERFACE_DEFINED__
#define __IVsPersistConnectedServices_INTERFACE_DEFINED__

/* interface IVsPersistConnectedServices */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsPersistConnectedServices;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("9C68F455-FF06-43D0-8473-195EFAFCB833")
    IVsPersistConnectedServices : public IUnknown
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Project( 
            /* [retval][out] */ __RPC__deref_out_opt IVsHierarchy **ppProject) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_Count( 
            /* [retval][out] */ __RPC__out DWORD *pdwCount) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetConnectedServices( 
            /* [in] */ DWORD dwMaxReferences,
            /* [length_is][size_is][out] */ __RPC__out_ecount_part(dwMaxReferences, *pdwConnectedServicesReturned) IVsConnectedServiceProperties *rgpServices[  ],
            /* [retval][out] */ __RPC__out DWORD *pdwConnectedServicesReturned) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetConnectedService( 
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity,
            /* [retval][out] */ __RPC__deref_out_opt IVsConnectedServiceProperties **ppConnectedService) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Add( 
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity,
            /* [in] */ DWORD dwCountMetadata,
            /* [size_is][in] */ __RPC__in_ecount_full(dwCountMetadata) LPCOLESTR szProperties[  ],
            /* [size_is][in] */ __RPC__in_ecount_full(dwCountMetadata) LPCOLESTR szValues[  ],
            /* [retval][out] */ __RPC__deref_out_opt IVsConnectedServiceProperties **ppAdded) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Remove( 
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsPersistConnectedServicesVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsPersistConnectedServices * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsPersistConnectedServices * This);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Project )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [retval][out] */ __RPC__deref_out_opt IVsHierarchy **ppProject);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Count )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [retval][out] */ __RPC__out DWORD *pdwCount);
        
        HRESULT ( STDMETHODCALLTYPE *GetConnectedServices )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [in] */ DWORD dwMaxReferences,
            /* [length_is][size_is][out] */ __RPC__out_ecount_part(dwMaxReferences, *pdwConnectedServicesReturned) IVsConnectedServiceProperties *rgpServices[  ],
            /* [retval][out] */ __RPC__out DWORD *pdwConnectedServicesReturned);
        
        HRESULT ( STDMETHODCALLTYPE *GetConnectedService )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity,
            /* [retval][out] */ __RPC__deref_out_opt IVsConnectedServiceProperties **ppConnectedService);
        
        HRESULT ( STDMETHODCALLTYPE *Add )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity,
            /* [in] */ DWORD dwCountMetadata,
            /* [size_is][in] */ __RPC__in_ecount_full(dwCountMetadata) LPCOLESTR szProperties[  ],
            /* [size_is][in] */ __RPC__in_ecount_full(dwCountMetadata) LPCOLESTR szValues[  ],
            /* [retval][out] */ __RPC__deref_out_opt IVsConnectedServiceProperties **ppAdded);
        
        HRESULT ( STDMETHODCALLTYPE *Remove )( 
            __RPC__in IVsPersistConnectedServices * This,
            /* [in] */ __RPC__in LPCOLESTR szServiceIdentity);
        
        END_INTERFACE
    } IVsPersistConnectedServicesVtbl;

    interface IVsPersistConnectedServices
    {
        CONST_VTBL struct IVsPersistConnectedServicesVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsPersistConnectedServices_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsPersistConnectedServices_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsPersistConnectedServices_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsPersistConnectedServices_get_Project(This,ppProject)	\
    ( (This)->lpVtbl -> get_Project(This,ppProject) ) 

#define IVsPersistConnectedServices_get_Count(This,pdwCount)	\
    ( (This)->lpVtbl -> get_Count(This,pdwCount) ) 

#define IVsPersistConnectedServices_GetConnectedServices(This,dwMaxReferences,rgpServices,pdwConnectedServicesReturned)	\
    ( (This)->lpVtbl -> GetConnectedServices(This,dwMaxReferences,rgpServices,pdwConnectedServicesReturned) ) 

#define IVsPersistConnectedServices_GetConnectedService(This,szServiceIdentity,ppConnectedService)	\
    ( (This)->lpVtbl -> GetConnectedService(This,szServiceIdentity,ppConnectedService) ) 

#define IVsPersistConnectedServices_Add(This,szServiceIdentity,dwCountMetadata,szProperties,szValues,ppAdded)	\
    ( (This)->lpVtbl -> Add(This,szServiceIdentity,dwCountMetadata,szProperties,szValues,ppAdded) ) 

#define IVsPersistConnectedServices_Remove(This,szServiceIdentity)	\
    ( (This)->lpVtbl -> Remove(This,szServiceIdentity) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsPersistConnectedServices_INTERFACE_DEFINED__ */


#ifndef __IVsConnectedServiceInstanceReference_INTERFACE_DEFINED__
#define __IVsConnectedServiceInstanceReference_INTERFACE_DEFINED__

/* interface IVsConnectedServiceInstanceReference */
/* [object][oleautomation][version][uuid] */ 


EXTERN_C const IID IID_IVsConnectedServiceInstanceReference;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("13A70605-F511-4350-8DAF-4387F10B97BE")
    IVsConnectedServiceInstanceReference : public IVsReference
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ProviderIdentity( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pRetVal) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_ProviderIdentity( 
            /* [in] */ __RPC__in LPCOLESTR pRetVal) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_InstanceIdentity( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pRetVal) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_InstanceIdentity( 
            /* [in] */ __RPC__in LPCOLESTR pRetVal) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsConnectedServiceInstanceReferenceVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsConnectedServiceInstanceReference * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsConnectedServiceInstanceReference * This);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_Name )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *bstrName);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_Name )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ __RPC__in LPCOLESTR strName);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_FullPath )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *bstrFullPath);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_FullPath )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ __RPC__in LPCOLESTR bstrFullPath);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_AlreadyReferenced )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *boolAlreadyReferenced);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_AlreadyReferenced )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ VARIANT_BOOL boolAlreadyReferenced);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ProviderIdentity )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pRetVal);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_ProviderIdentity )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ __RPC__in LPCOLESTR pRetVal);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_InstanceIdentity )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pRetVal);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_InstanceIdentity )( 
            __RPC__in IVsConnectedServiceInstanceReference * This,
            /* [in] */ __RPC__in LPCOLESTR pRetVal);
        
        END_INTERFACE
    } IVsConnectedServiceInstanceReferenceVtbl;

    interface IVsConnectedServiceInstanceReference
    {
        CONST_VTBL struct IVsConnectedServiceInstanceReferenceVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsConnectedServiceInstanceReference_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsConnectedServiceInstanceReference_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsConnectedServiceInstanceReference_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsConnectedServiceInstanceReference_get_Name(This,bstrName)	\
    ( (This)->lpVtbl -> get_Name(This,bstrName) ) 

#define IVsConnectedServiceInstanceReference_put_Name(This,strName)	\
    ( (This)->lpVtbl -> put_Name(This,strName) ) 

#define IVsConnectedServiceInstanceReference_get_FullPath(This,bstrFullPath)	\
    ( (This)->lpVtbl -> get_FullPath(This,bstrFullPath) ) 

#define IVsConnectedServiceInstanceReference_put_FullPath(This,bstrFullPath)	\
    ( (This)->lpVtbl -> put_FullPath(This,bstrFullPath) ) 

#define IVsConnectedServiceInstanceReference_get_AlreadyReferenced(This,boolAlreadyReferenced)	\
    ( (This)->lpVtbl -> get_AlreadyReferenced(This,boolAlreadyReferenced) ) 

#define IVsConnectedServiceInstanceReference_put_AlreadyReferenced(This,boolAlreadyReferenced)	\
    ( (This)->lpVtbl -> put_AlreadyReferenced(This,boolAlreadyReferenced) ) 


#define IVsConnectedServiceInstanceReference_get_ProviderIdentity(This,pRetVal)	\
    ( (This)->lpVtbl -> get_ProviderIdentity(This,pRetVal) ) 

#define IVsConnectedServiceInstanceReference_put_ProviderIdentity(This,pRetVal)	\
    ( (This)->lpVtbl -> put_ProviderIdentity(This,pRetVal) ) 

#define IVsConnectedServiceInstanceReference_get_InstanceIdentity(This,pRetVal)	\
    ( (This)->lpVtbl -> get_InstanceIdentity(This,pRetVal) ) 

#define IVsConnectedServiceInstanceReference_put_InstanceIdentity(This,pRetVal)	\
    ( (This)->lpVtbl -> put_InstanceIdentity(This,pRetVal) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsConnectedServiceInstanceReference_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0008 */
/* [local] */ 

DEFINE_GUID(GUID_ConnectedServiceInstanceReferenceProvider, 0xC18E5D73, 0xE6D1, 0x43AA, 0xAC, 0x5E, 0x58, 0xD8, 0x2E, 0x44, 0xDA, 0x9C);


extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0008_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0008_v0_0_s_ifspec;

#ifndef __IVsConnectedServiceInstanceReferenceProviderContext_INTERFACE_DEFINED__
#define __IVsConnectedServiceInstanceReferenceProviderContext_INTERFACE_DEFINED__

/* interface IVsConnectedServiceInstanceReferenceProviderContext */
/* [object][oleautomation][version][uuid] */ 


EXTERN_C const IID IID_IVsConnectedServiceInstanceReferenceProviderContext;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C9127230-28C1-413D-BDC5-39F3A700FCBD")
    IVsConnectedServiceInstanceReferenceProviderContext : public IVsReferenceProviderContext
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_ProjectCapabilities( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrProjectCapabilities) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_ProjectCapabilities( 
            /* [in] */ __RPC__in LPCOLESTR strProjectCapabilities) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_TargetPlatformIdentifier( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlatformIdentifier) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_TargetPlatformIdentifier( 
            /* [in] */ __RPC__in LPCOLESTR strTargetPlatformIdentifier) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_TargetPlatformVersion( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlaformVersion) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_TargetPlatformVersion( 
            /* [in] */ __RPC__in LPCOLESTR strTargetPlaformVersion) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_TargetFrameworkMoniker( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlatformMoniker) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_TargetFrameworkMoniker( 
            /* [in] */ __RPC__in LPCOLESTR strTargetPlatformMoniker) = 0;
        
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_VisualStudioVersion( 
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrVisualStudioVersion) = 0;
        
        virtual /* [propput] */ HRESULT STDMETHODCALLTYPE put_VisualStudioVersion( 
            /* [in] */ __RPC__in LPCOLESTR strVisualStudioVersion) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsConnectedServiceInstanceReferenceProviderContextVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ProviderGuid )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__out GUID *pguidProvider);
        
        /* [propget][local] */ HRESULT ( STDMETHODCALLTYPE *get_References )( 
            IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ SAFEARRAY * *pReferences);
        
        HRESULT ( STDMETHODCALLTYPE *AddReference )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in_opt IVsReference *pReference);
        
        HRESULT ( STDMETHODCALLTYPE *CreateReference )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt IVsReference **pRetVal);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ReferenceFilterPaths )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt SAFEARRAY * *pFilterPaths);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_ReferenceFilterPaths )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in SAFEARRAY * filterPaths);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_ProjectCapabilities )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrProjectCapabilities);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_ProjectCapabilities )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in LPCOLESTR strProjectCapabilities);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_TargetPlatformIdentifier )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlatformIdentifier);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_TargetPlatformIdentifier )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in LPCOLESTR strTargetPlatformIdentifier);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_TargetPlatformVersion )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlaformVersion);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_TargetPlatformVersion )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in LPCOLESTR strTargetPlaformVersion);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_TargetFrameworkMoniker )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrTargetPlatformMoniker);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_TargetFrameworkMoniker )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in LPCOLESTR strTargetPlatformMoniker);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_VisualStudioVersion )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *pbstrVisualStudioVersion);
        
        /* [propput] */ HRESULT ( STDMETHODCALLTYPE *put_VisualStudioVersion )( 
            __RPC__in IVsConnectedServiceInstanceReferenceProviderContext * This,
            /* [in] */ __RPC__in LPCOLESTR strVisualStudioVersion);
        
        END_INTERFACE
    } IVsConnectedServiceInstanceReferenceProviderContextVtbl;

    interface IVsConnectedServiceInstanceReferenceProviderContext
    {
        CONST_VTBL struct IVsConnectedServiceInstanceReferenceProviderContextVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsConnectedServiceInstanceReferenceProviderContext_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsConnectedServiceInstanceReferenceProviderContext_get_ProviderGuid(This,pguidProvider)	\
    ( (This)->lpVtbl -> get_ProviderGuid(This,pguidProvider) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_References(This,pReferences)	\
    ( (This)->lpVtbl -> get_References(This,pReferences) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_AddReference(This,pReference)	\
    ( (This)->lpVtbl -> AddReference(This,pReference) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_CreateReference(This,pRetVal)	\
    ( (This)->lpVtbl -> CreateReference(This,pRetVal) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_ReferenceFilterPaths(This,pFilterPaths)	\
    ( (This)->lpVtbl -> get_ReferenceFilterPaths(This,pFilterPaths) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_ReferenceFilterPaths(This,filterPaths)	\
    ( (This)->lpVtbl -> put_ReferenceFilterPaths(This,filterPaths) ) 


#define IVsConnectedServiceInstanceReferenceProviderContext_get_ProjectCapabilities(This,pbstrProjectCapabilities)	\
    ( (This)->lpVtbl -> get_ProjectCapabilities(This,pbstrProjectCapabilities) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_ProjectCapabilities(This,strProjectCapabilities)	\
    ( (This)->lpVtbl -> put_ProjectCapabilities(This,strProjectCapabilities) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_TargetPlatformIdentifier(This,pbstrTargetPlatformIdentifier)	\
    ( (This)->lpVtbl -> get_TargetPlatformIdentifier(This,pbstrTargetPlatformIdentifier) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_TargetPlatformIdentifier(This,strTargetPlatformIdentifier)	\
    ( (This)->lpVtbl -> put_TargetPlatformIdentifier(This,strTargetPlatformIdentifier) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_TargetPlatformVersion(This,pbstrTargetPlaformVersion)	\
    ( (This)->lpVtbl -> get_TargetPlatformVersion(This,pbstrTargetPlaformVersion) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_TargetPlatformVersion(This,strTargetPlaformVersion)	\
    ( (This)->lpVtbl -> put_TargetPlatformVersion(This,strTargetPlaformVersion) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_TargetFrameworkMoniker(This,pbstrTargetPlatformMoniker)	\
    ( (This)->lpVtbl -> get_TargetFrameworkMoniker(This,pbstrTargetPlatformMoniker) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_TargetFrameworkMoniker(This,strTargetPlatformMoniker)	\
    ( (This)->lpVtbl -> put_TargetFrameworkMoniker(This,strTargetPlatformMoniker) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_get_VisualStudioVersion(This,pbstrVisualStudioVersion)	\
    ( (This)->lpVtbl -> get_VisualStudioVersion(This,pbstrVisualStudioVersion) ) 

#define IVsConnectedServiceInstanceReferenceProviderContext_put_VisualStudioVersion(This,strVisualStudioVersion)	\
    ( (This)->lpVtbl -> put_VisualStudioVersion(This,strVisualStudioVersion) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsConnectedServiceInstanceReferenceProviderContext_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0009 */
/* [local] */ 

extern const __declspec(selectany) GUID GUID_BlueColorTheme             = { 0xa4d6a176, 0xb948, 0x4b29, { 0x8c, 0x66, 0x53, 0xc9, 0x7a, 0x1e, 0xd7, 0xd0} };
extern const __declspec(selectany) GUID GUID_HighContrastColorTheme     = { 0xA5C004B4, 0x2D4B, 0x494E, { 0xBF, 0x01, 0x45, 0xFC, 0x49, 0x25, 0x22, 0xC7} };
extern const __declspec(selectany) GUID GUID_DebugColorTheme            = { 0x72F0B33F, 0xF6D5, 0x47E0, { 0xB8, 0x1C, 0x0E, 0xD3, 0x6B, 0xF9, 0xD6, 0xC7} };

enum __VSArrangeWindowFlags
    {
        AWF_Left	= 0x1,
        AWF_Top	= 0x2,
        AWF_Width	= 0x4,
        AWF_Height	= 0x8
    } ;
typedef DWORD VSArrangeWindowFlags;

typedef struct __VSArrangeWindowInfo
    {
    HWND hwnd;
    VSArrangeWindowFlags flags;
    } 	VSArrangeWindowInfo;

#ifndef WINUSERAPI       // If not already defined by winuser.h...
typedef struct tagWINDOWPOS
    {
    HWND hwnd;
    HWND hwndInsertAfter;
    int x;
    int y;
    int cx;
    int cy;
    UINT flags;
    } 	WINDOWPOS;

#endif  // WINUSERAPI


extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0009_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0009_v0_0_s_ifspec;

#ifndef __IVsUIShellArrangeWindows_INTERFACE_DEFINED__
#define __IVsUIShellArrangeWindows_INTERFACE_DEFINED__

/* interface IVsUIShellArrangeWindows */
/* [object][uuid] */ 


EXTERN_C const IID IID_IVsUIShellArrangeWindows;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("54457dad-5384-41b5-b6aa-efffde468cdc")
    IVsUIShellArrangeWindows : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE ComputeWindowSizeChange( 
            /* [in] */ __RPC__in HWND hwnd,
            /* [in] */ __RPC__in WINDOWPOS *newPos,
            /* [retval][out] */ __RPC__out SIZE *size) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Arrange( 
            /* [size_is][in] */ __RPC__in_ecount_full(count) VSArrangeWindowInfo infos[  ],
            /* [in] */ int count,
            /* [in] */ SIZE size) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsUIShellArrangeWindowsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsUIShellArrangeWindows * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsUIShellArrangeWindows * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsUIShellArrangeWindows * This);
        
        HRESULT ( STDMETHODCALLTYPE *ComputeWindowSizeChange )( 
            __RPC__in IVsUIShellArrangeWindows * This,
            /* [in] */ __RPC__in HWND hwnd,
            /* [in] */ __RPC__in WINDOWPOS *newPos,
            /* [retval][out] */ __RPC__out SIZE *size);
        
        HRESULT ( STDMETHODCALLTYPE *Arrange )( 
            __RPC__in IVsUIShellArrangeWindows * This,
            /* [size_is][in] */ __RPC__in_ecount_full(count) VSArrangeWindowInfo infos[  ],
            /* [in] */ int count,
            /* [in] */ SIZE size);
        
        END_INTERFACE
    } IVsUIShellArrangeWindowsVtbl;

    interface IVsUIShellArrangeWindows
    {
        CONST_VTBL struct IVsUIShellArrangeWindowsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsUIShellArrangeWindows_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsUIShellArrangeWindows_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsUIShellArrangeWindows_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsUIShellArrangeWindows_ComputeWindowSizeChange(This,hwnd,newPos,size)	\
    ( (This)->lpVtbl -> ComputeWindowSizeChange(This,hwnd,newPos,size) ) 

#define IVsUIShellArrangeWindows_Arrange(This,infos,count,size)	\
    ( (This)->lpVtbl -> Arrange(This,infos,count,size) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsUIShellArrangeWindows_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0010 */
/* [local] */ 


enum __VSNEWDOCUMENTSTATE2
    {
        NDS_Reserved	= 0xff00,
        NDS_TryProvisional	= 0x20000001
    } ;

enum __VSSEARCHNAVIGATIONKEY2
    {
        SNK_ESCAPE	= 0x7
    } ;

enum __VSIDOFLAGS2
    {
        IDO_IncludeUninitializedFrames	= 0x4
    } ;

enum __VSFPROPID6
    {
        VSFPROPID_PendingInitialization	= -5027,
        VSFPROPID6_FIRST	= -5027
    } ;
typedef LONG VSFPROPID6;


enum __VSRDTATTRIB3
    {
        RDTA_DocumentInitialized	= 0x100000,
        RDTA_HierarchyInitialized	= 0x200000
    } ;
typedef DWORD VSRDTATTRIB3;


enum _VSRDTFLAGS4
    {
        RDT_PendingInitialization	= 0x40000,
        RDT_PendingHierarchyInitialization	= 0x80000
    } ;
typedef DWORD VSRDTFLAGS4;



extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0010_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0010_v0_0_s_ifspec;

#ifndef __IVsRunningDocumentTable4_INTERFACE_DEFINED__
#define __IVsRunningDocumentTable4_INTERFACE_DEFINED__

/* interface IVsRunningDocumentTable4 */
/* [object][uuid] */ 


EXTERN_C const IID IID_IVsRunningDocumentTable4;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("86a4da78-d580-4ae4-a1be-f805bc663e04")
    IVsRunningDocumentTable4 : public IVsRunningDocumentTable3
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE IsMonikerValid( 
            /* [in] */ __RPC__in LPCOLESTR moniker,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *valid) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE IsCookieValid( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *valid) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentCookie( 
            /* [in] */ __RPC__in LPCOLESTR moniker,
            /* [retval][out] */ __RPC__out VSCOOKIE *cookie) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentFlags( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VSRDTFLAGS *flags) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentReadLockCount( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out DWORD *count) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentEditLockCount( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out DWORD *count) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentMoniker( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *moniker) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentHierarchyItem( 
            /* [in] */ VSCOOKIE cookie,
            /* [out] */ __RPC__deref_out_opt IVsHierarchy **hierarchy,
            /* [out] */ __RPC__out VSITEMID *itemID) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentData( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **docdata) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDocumentProjectGuid( 
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out GUID *guid) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsRunningDocumentTable4Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsRunningDocumentTable4 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsRunningDocumentTable4 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetRelatedSaveTreeItems )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [in] */ VSRDTSAVEOPTIONS grfSave,
            /* [in] */ ULONG celt,
            /* [length_is][size_is][out] */ __RPC__out_ecount_part(celt, *pcActual) VSSAVETREEITEM rgSaveTreeItems[  ],
            /* [retval][out] */ __RPC__out ULONG *pcActual);
        
        HRESULT ( STDMETHODCALLTYPE *NotifyDocumentChangedEx )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [in] */ VSRDTATTRIB2 attributes);
        
        HRESULT ( STDMETHODCALLTYPE *IsDocumentDirty )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *dirty);
        
        HRESULT ( STDMETHODCALLTYPE *IsDocumentReadOnly )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *readOnly);
        
        HRESULT ( STDMETHODCALLTYPE *UpdateDirtyState )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie);
        
        HRESULT ( STDMETHODCALLTYPE *UpdateReadOnlyState )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie);
        
        HRESULT ( STDMETHODCALLTYPE *IsMonikerValid )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ __RPC__in LPCOLESTR moniker,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *valid);
        
        HRESULT ( STDMETHODCALLTYPE *IsCookieValid )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *valid);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentCookie )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ __RPC__in LPCOLESTR moniker,
            /* [retval][out] */ __RPC__out VSCOOKIE *cookie);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentFlags )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out VSRDTFLAGS *flags);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentReadLockCount )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out DWORD *count);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentEditLockCount )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out DWORD *count);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentMoniker )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__deref_out_opt BSTR *moniker);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentHierarchyItem )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [out] */ __RPC__deref_out_opt IVsHierarchy **hierarchy,
            /* [out] */ __RPC__out VSITEMID *itemID);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentData )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **docdata);
        
        HRESULT ( STDMETHODCALLTYPE *GetDocumentProjectGuid )( 
            __RPC__in IVsRunningDocumentTable4 * This,
            /* [in] */ VSCOOKIE cookie,
            /* [retval][out] */ __RPC__out GUID *guid);
        
        END_INTERFACE
    } IVsRunningDocumentTable4Vtbl;

    interface IVsRunningDocumentTable4
    {
        CONST_VTBL struct IVsRunningDocumentTable4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsRunningDocumentTable4_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsRunningDocumentTable4_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsRunningDocumentTable4_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsRunningDocumentTable4_GetRelatedSaveTreeItems(This,cookie,grfSave,celt,rgSaveTreeItems,pcActual)	\
    ( (This)->lpVtbl -> GetRelatedSaveTreeItems(This,cookie,grfSave,celt,rgSaveTreeItems,pcActual) ) 

#define IVsRunningDocumentTable4_NotifyDocumentChangedEx(This,cookie,attributes)	\
    ( (This)->lpVtbl -> NotifyDocumentChangedEx(This,cookie,attributes) ) 

#define IVsRunningDocumentTable4_IsDocumentDirty(This,cookie,dirty)	\
    ( (This)->lpVtbl -> IsDocumentDirty(This,cookie,dirty) ) 

#define IVsRunningDocumentTable4_IsDocumentReadOnly(This,cookie,readOnly)	\
    ( (This)->lpVtbl -> IsDocumentReadOnly(This,cookie,readOnly) ) 

#define IVsRunningDocumentTable4_UpdateDirtyState(This,cookie)	\
    ( (This)->lpVtbl -> UpdateDirtyState(This,cookie) ) 

#define IVsRunningDocumentTable4_UpdateReadOnlyState(This,cookie)	\
    ( (This)->lpVtbl -> UpdateReadOnlyState(This,cookie) ) 


#define IVsRunningDocumentTable4_IsMonikerValid(This,moniker,valid)	\
    ( (This)->lpVtbl -> IsMonikerValid(This,moniker,valid) ) 

#define IVsRunningDocumentTable4_IsCookieValid(This,cookie,valid)	\
    ( (This)->lpVtbl -> IsCookieValid(This,cookie,valid) ) 

#define IVsRunningDocumentTable4_GetDocumentCookie(This,moniker,cookie)	\
    ( (This)->lpVtbl -> GetDocumentCookie(This,moniker,cookie) ) 

#define IVsRunningDocumentTable4_GetDocumentFlags(This,cookie,flags)	\
    ( (This)->lpVtbl -> GetDocumentFlags(This,cookie,flags) ) 

#define IVsRunningDocumentTable4_GetDocumentReadLockCount(This,cookie,count)	\
    ( (This)->lpVtbl -> GetDocumentReadLockCount(This,cookie,count) ) 

#define IVsRunningDocumentTable4_GetDocumentEditLockCount(This,cookie,count)	\
    ( (This)->lpVtbl -> GetDocumentEditLockCount(This,cookie,count) ) 

#define IVsRunningDocumentTable4_GetDocumentMoniker(This,cookie,moniker)	\
    ( (This)->lpVtbl -> GetDocumentMoniker(This,cookie,moniker) ) 

#define IVsRunningDocumentTable4_GetDocumentHierarchyItem(This,cookie,hierarchy,itemID)	\
    ( (This)->lpVtbl -> GetDocumentHierarchyItem(This,cookie,hierarchy,itemID) ) 

#define IVsRunningDocumentTable4_GetDocumentData(This,cookie,docdata)	\
    ( (This)->lpVtbl -> GetDocumentData(This,cookie,docdata) ) 

#define IVsRunningDocumentTable4_GetDocumentProjectGuid(This,cookie,guid)	\
    ( (This)->lpVtbl -> GetDocumentProjectGuid(This,cookie,guid) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsRunningDocumentTable4_INTERFACE_DEFINED__ */


#ifndef __IVsUIHierarchyNativeWindow_INTERFACE_DEFINED__
#define __IVsUIHierarchyNativeWindow_INTERFACE_DEFINED__

/* interface IVsUIHierarchyNativeWindow */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsUIHierarchyNativeWindow;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("280CC247-9EF8-42F2-9009-A75B86EA871B")
    IVsUIHierarchyNativeWindow : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE SetTreeRedraw( 
            /* [in] */ VARIANT_BOOL fEnabled) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsUIHierarchyNativeWindowVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsUIHierarchyNativeWindow * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsUIHierarchyNativeWindow * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsUIHierarchyNativeWindow * This);
        
        HRESULT ( STDMETHODCALLTYPE *SetTreeRedraw )( 
            __RPC__in IVsUIHierarchyNativeWindow * This,
            /* [in] */ VARIANT_BOOL fEnabled);
        
        END_INTERFACE
    } IVsUIHierarchyNativeWindowVtbl;

    interface IVsUIHierarchyNativeWindow
    {
        CONST_VTBL struct IVsUIHierarchyNativeWindowVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsUIHierarchyNativeWindow_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsUIHierarchyNativeWindow_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsUIHierarchyNativeWindow_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsUIHierarchyNativeWindow_SetTreeRedraw(This,fEnabled)	\
    ( (This)->lpVtbl -> SetTreeRedraw(This,fEnabled) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsUIHierarchyNativeWindow_INTERFACE_DEFINED__ */


#ifndef __IVsPropertiesInfo_INTERFACE_DEFINED__
#define __IVsPropertiesInfo_INTERFACE_DEFINED__

/* interface IVsPropertiesInfo */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsPropertiesInfo;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("C0975213-3D73-44E1-8B46-4578E16D4457")
    IVsPropertiesInfo : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE IsTransmittable( 
            DISPID id,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *pfIsTransmittable) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsPropertiesInfoVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsPropertiesInfo * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsPropertiesInfo * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsPropertiesInfo * This);
        
        HRESULT ( STDMETHODCALLTYPE *IsTransmittable )( 
            __RPC__in IVsPropertiesInfo * This,
            DISPID id,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *pfIsTransmittable);
        
        END_INTERFACE
    } IVsPropertiesInfoVtbl;

    interface IVsPropertiesInfo
    {
        CONST_VTBL struct IVsPropertiesInfoVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsPropertiesInfo_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsPropertiesInfo_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsPropertiesInfo_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsPropertiesInfo_IsTransmittable(This,id,pfIsTransmittable)	\
    ( (This)->lpVtbl -> IsTransmittable(This,id,pfIsTransmittable) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsPropertiesInfo_INTERFACE_DEFINED__ */


#ifndef __IVsTaskSchedulerService2_INTERFACE_DEFINED__
#define __IVsTaskSchedulerService2_INTERFACE_DEFINED__

/* interface IVsTaskSchedulerService2 */
/* [object][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsTaskSchedulerService2;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("8176dc77-36e2-4987-955b-9f63c6f3f229")
    IVsTaskSchedulerService2 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetAsyncTaskContext( 
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **ppTaskContext) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetTaskScheduler( 
            /* [in] */ VSTASKRUNCONTEXT context,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **ppTaskScheduler) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsTaskSchedulerService2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsTaskSchedulerService2 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsTaskSchedulerService2 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsTaskSchedulerService2 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetAsyncTaskContext )( 
            __RPC__in IVsTaskSchedulerService2 * This,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **ppTaskContext);
        
        HRESULT ( STDMETHODCALLTYPE *GetTaskScheduler )( 
            __RPC__in IVsTaskSchedulerService2 * This,
            /* [in] */ VSTASKRUNCONTEXT context,
            /* [retval][out] */ __RPC__deref_out_opt IUnknown **ppTaskScheduler);
        
        END_INTERFACE
    } IVsTaskSchedulerService2Vtbl;

    interface IVsTaskSchedulerService2
    {
        CONST_VTBL struct IVsTaskSchedulerService2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsTaskSchedulerService2_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsTaskSchedulerService2_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsTaskSchedulerService2_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsTaskSchedulerService2_GetAsyncTaskContext(This,ppTaskContext)	\
    ( (This)->lpVtbl -> GetAsyncTaskContext(This,ppTaskContext) ) 

#define IVsTaskSchedulerService2_GetTaskScheduler(This,context,ppTaskScheduler)	\
    ( (This)->lpVtbl -> GetTaskScheduler(This,context,ppTaskScheduler) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsTaskSchedulerService2_INTERFACE_DEFINED__ */


#ifndef __IVsBuildManagerAccessor3_INTERFACE_DEFINED__
#define __IVsBuildManagerAccessor3_INTERFACE_DEFINED__

/* interface IVsBuildManagerAccessor3 */
/* [object][custom][local][unique][version][uuid] */ 


EXTERN_C const IID IID_IVsBuildManagerAccessor3;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("B7E1D5A7-7FD2-454F-96B9-AB77D975C706")
    IVsBuildManagerAccessor3 : public IVsBuildManagerAccessor2
    {
    public:
        virtual /* [propget] */ HRESULT STDMETHODCALLTYPE get_SolutionBuildAvailable( 
            /* [retval][out] */ HANDLE *phWaitHandle) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsBuildManagerAccessor3Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IVsBuildManagerAccessor3 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IVsBuildManagerAccessor3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *RegisterLogger )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ LONG submissionId,
            /* [in] */ IUnknown *punkLogger);
        
        HRESULT ( STDMETHODCALLTYPE *UnregisterLoggers )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ LONG submissionId);
        
        HRESULT ( STDMETHODCALLTYPE *ClaimUIThreadForBuild )( 
            IVsBuildManagerAccessor3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *ReleaseUIThreadForBuild )( 
            IVsBuildManagerAccessor3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *BeginDesignTimeBuild )( 
            IVsBuildManagerAccessor3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *EndDesignTimeBuild )( 
            IVsBuildManagerAccessor3 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetCurrentBatchBuildId )( 
            IVsBuildManagerAccessor3 * This,
            /* [out] */ ULONG *pBatchId);
        
        HRESULT ( STDMETHODCALLTYPE *GetSolutionConfiguration )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ IUnknown *punkRootProject,
            /* [retval][out] */ BSTR *pbstrXmlFragment);
        
        HRESULT ( STDMETHODCALLTYPE *Escape )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ LPCOLESTR pwszUnescapedValue,
            /* [retval][out] */ BSTR *pbstrEscapedValue);
        
        HRESULT ( STDMETHODCALLTYPE *Unescape )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ LPCOLESTR pwszEscapedValue,
            /* [retval][out] */ BSTR *pbstrUnescapedValue);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_DesignTimeBuildAvailable )( 
            IVsBuildManagerAccessor3 * This,
            /* [retval][out] */ HANDLE *phWaitHandle);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_UIThreadIsAvailableForBuild )( 
            IVsBuildManagerAccessor3 * This,
            /* [retval][out] */ HANDLE *phWaitHandle);
        
        HRESULT ( STDMETHODCALLTYPE *AcquireBuildResources )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ VSBUILDMANAGERRESOURCE fResources,
            /* [out] */ VSCOOKIE *phCookie);
        
        HRESULT ( STDMETHODCALLTYPE *ReleaseBuildResources )( 
            IVsBuildManagerAccessor3 * This,
            /* [in] */ VSCOOKIE hCookie);
        
        /* [propget] */ HRESULT ( STDMETHODCALLTYPE *get_SolutionBuildAvailable )( 
            IVsBuildManagerAccessor3 * This,
            /* [retval][out] */ HANDLE *phWaitHandle);
        
        END_INTERFACE
    } IVsBuildManagerAccessor3Vtbl;

    interface IVsBuildManagerAccessor3
    {
        CONST_VTBL struct IVsBuildManagerAccessor3Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsBuildManagerAccessor3_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsBuildManagerAccessor3_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsBuildManagerAccessor3_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsBuildManagerAccessor3_RegisterLogger(This,submissionId,punkLogger)	\
    ( (This)->lpVtbl -> RegisterLogger(This,submissionId,punkLogger) ) 

#define IVsBuildManagerAccessor3_UnregisterLoggers(This,submissionId)	\
    ( (This)->lpVtbl -> UnregisterLoggers(This,submissionId) ) 

#define IVsBuildManagerAccessor3_ClaimUIThreadForBuild(This)	\
    ( (This)->lpVtbl -> ClaimUIThreadForBuild(This) ) 

#define IVsBuildManagerAccessor3_ReleaseUIThreadForBuild(This)	\
    ( (This)->lpVtbl -> ReleaseUIThreadForBuild(This) ) 

#define IVsBuildManagerAccessor3_BeginDesignTimeBuild(This)	\
    ( (This)->lpVtbl -> BeginDesignTimeBuild(This) ) 

#define IVsBuildManagerAccessor3_EndDesignTimeBuild(This)	\
    ( (This)->lpVtbl -> EndDesignTimeBuild(This) ) 

#define IVsBuildManagerAccessor3_GetCurrentBatchBuildId(This,pBatchId)	\
    ( (This)->lpVtbl -> GetCurrentBatchBuildId(This,pBatchId) ) 

#define IVsBuildManagerAccessor3_GetSolutionConfiguration(This,punkRootProject,pbstrXmlFragment)	\
    ( (This)->lpVtbl -> GetSolutionConfiguration(This,punkRootProject,pbstrXmlFragment) ) 

#define IVsBuildManagerAccessor3_Escape(This,pwszUnescapedValue,pbstrEscapedValue)	\
    ( (This)->lpVtbl -> Escape(This,pwszUnescapedValue,pbstrEscapedValue) ) 

#define IVsBuildManagerAccessor3_Unescape(This,pwszEscapedValue,pbstrUnescapedValue)	\
    ( (This)->lpVtbl -> Unescape(This,pwszEscapedValue,pbstrUnescapedValue) ) 


#define IVsBuildManagerAccessor3_get_DesignTimeBuildAvailable(This,phWaitHandle)	\
    ( (This)->lpVtbl -> get_DesignTimeBuildAvailable(This,phWaitHandle) ) 

#define IVsBuildManagerAccessor3_get_UIThreadIsAvailableForBuild(This,phWaitHandle)	\
    ( (This)->lpVtbl -> get_UIThreadIsAvailableForBuild(This,phWaitHandle) ) 

#define IVsBuildManagerAccessor3_AcquireBuildResources(This,fResources,phCookie)	\
    ( (This)->lpVtbl -> AcquireBuildResources(This,fResources,phCookie) ) 

#define IVsBuildManagerAccessor3_ReleaseBuildResources(This,hCookie)	\
    ( (This)->lpVtbl -> ReleaseBuildResources(This,hCookie) ) 


#define IVsBuildManagerAccessor3_get_SolutionBuildAvailable(This,phWaitHandle)	\
    ( (This)->lpVtbl -> get_SolutionBuildAvailable(This,phWaitHandle) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsBuildManagerAccessor3_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0015 */
/* [local] */ 

#define VS_E_READ_SOLUTION_FILE_FAILED    MAKE_HRESULT(SEVERITY_ERROR, FACILITY_ITF, 0x2009)


extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0015_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0015_v0_0_s_ifspec;

#ifndef __IVsWindowFrame4_INTERFACE_DEFINED__
#define __IVsWindowFrame4_INTERFACE_DEFINED__

/* interface IVsWindowFrame4 */
/* [object][version][uuid] */ 


EXTERN_C const IID IID_IVsWindowFrame4;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("841F8242-83BB-4C6D-8357-E12C21BF6CAA")
    IVsWindowFrame4 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetWindowScreenRect( 
            /* [out] */ __RPC__out int *screenLeft,
            /* [out] */ __RPC__out int *screenTop,
            /* [out] */ __RPC__out int *screenWidth,
            /* [out] */ __RPC__out int *screenHeight,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *isOnScreen) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IVsWindowFrame4Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            __RPC__in IVsWindowFrame4 * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            __RPC__in IVsWindowFrame4 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            __RPC__in IVsWindowFrame4 * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetWindowScreenRect )( 
            __RPC__in IVsWindowFrame4 * This,
            /* [out] */ __RPC__out int *screenLeft,
            /* [out] */ __RPC__out int *screenTop,
            /* [out] */ __RPC__out int *screenWidth,
            /* [out] */ __RPC__out int *screenHeight,
            /* [retval][out] */ __RPC__out VARIANT_BOOL *isOnScreen);
        
        END_INTERFACE
    } IVsWindowFrame4Vtbl;

    interface IVsWindowFrame4
    {
        CONST_VTBL struct IVsWindowFrame4Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IVsWindowFrame4_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IVsWindowFrame4_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IVsWindowFrame4_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IVsWindowFrame4_GetWindowScreenRect(This,screenLeft,screenTop,screenWidth,screenHeight,isOnScreen)	\
    ( (This)->lpVtbl -> GetWindowScreenRect(This,screenLeft,screenTop,screenWidth,screenHeight,isOnScreen) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IVsWindowFrame4_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_vsshell120_0000_0016 */
/* [local] */ 

#define szWSS_CONTROL_BORDER_THICKNESS L"ControlBorderThickness"
#define szWSS_SEARCH_HWNDSOURCE_BGCOLOR L"HwndSourceBackgroundColor"

enum __VSSPROPID6
    {
        VSSPROPID_ShutdownStarted	= -9076,
        VSSPROPID_FIRST6	= -9076
    } ;
typedef LONG VSSPROPID6;


enum _VSProjectUnloadStatus2
    {
        UNLOADSTATUS_NeedRetarget	= 5
    } ;


extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0016_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_vsshell120_0000_0016_v0_0_s_ifspec;

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     __RPC__in unsigned long *, unsigned long            , __RPC__in BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  __RPC__in unsigned long *, __RPC__inout_xcount(0) unsigned char *, __RPC__in BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(__RPC__in unsigned long *, __RPC__in_xcount(0) unsigned char *, __RPC__out BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     __RPC__in unsigned long *, __RPC__in BSTR * ); 

unsigned long             __RPC_USER  HWND_UserSize(     __RPC__in unsigned long *, unsigned long            , __RPC__in HWND * ); 
unsigned char * __RPC_USER  HWND_UserMarshal(  __RPC__in unsigned long *, __RPC__inout_xcount(0) unsigned char *, __RPC__in HWND * ); 
unsigned char * __RPC_USER  HWND_UserUnmarshal(__RPC__in unsigned long *, __RPC__in_xcount(0) unsigned char *, __RPC__out HWND * ); 
void                      __RPC_USER  HWND_UserFree(     __RPC__in unsigned long *, __RPC__in HWND * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


