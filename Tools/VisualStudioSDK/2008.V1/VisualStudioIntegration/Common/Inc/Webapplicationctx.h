

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0499 */
/* Compiler settings for webapplicationctx.idl:
    Oicf, W0, Zp8, env=Win32 (32b run)
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

/* verify that the <rpcsal.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCSAL_H_VERSION__
#define __REQUIRED_RPCSAL_H_VERSION__ 100
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __webapplicationctx_h__
#define __webapplicationctx_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IWebApplicationCtxSvc_FWD_DEFINED__
#define __IWebApplicationCtxSvc_FWD_DEFINED__
typedef interface IWebApplicationCtxSvc IWebApplicationCtxSvc;
#endif 	/* __IWebApplicationCtxSvc_FWD_DEFINED__ */


#ifndef __IWebFileCtxService_FWD_DEFINED__
#define __IWebFileCtxService_FWD_DEFINED__
typedef interface IWebFileCtxService IWebFileCtxService;
#endif 	/* __IWebFileCtxService_FWD_DEFINED__ */


#ifndef __IWebClassLibProjectEvents_FWD_DEFINED__
#define __IWebClassLibProjectEvents_FWD_DEFINED__
typedef interface IWebClassLibProjectEvents IWebClassLibProjectEvents;
#endif 	/* __IWebClassLibProjectEvents_FWD_DEFINED__ */


#ifndef __IWebClassLibProject_FWD_DEFINED__
#define __IWebClassLibProject_FWD_DEFINED__
typedef interface IWebClassLibProject IWebClassLibProject;
#endif 	/* __IWebClassLibProject_FWD_DEFINED__ */


#ifndef __IWebClassLibProjectSvc_FWD_DEFINED__
#define __IWebClassLibProjectSvc_FWD_DEFINED__
typedef interface IWebClassLibProjectSvc IWebClassLibProjectSvc;
#endif 	/* __IWebClassLibProjectSvc_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "vsshell.h"

#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __WebApplicationCtx_LIBRARY_DEFINED__
#define __WebApplicationCtx_LIBRARY_DEFINED__

/* library WebApplicationCtx */
/* [helpstring][version][uuid] */ 

#define SID_SWebApplicationCtxSvc IID_IWebApplicationCtxSvc
#define SID_SWebFileCtxService IID_IWebFileCtxService

enum tagCreateClassLibFlags
    {	CCL_UseAnchorWebConfig	= 1,
	CCL_CreateP2PReference	= 2
    } ;
typedef DWORD CREATECLASSLIBFLAGS;


EXTERN_C const IID LIBID_WebApplicationCtx;

#ifndef __IWebApplicationCtxSvc_INTERFACE_DEFINED__
#define __IWebApplicationCtxSvc_INTERFACE_DEFINED__

/* interface IWebApplicationCtxSvc */
/* [object][unique][helpstring][uuid] */ 


EXTERN_C const IID IID_IWebApplicationCtxSvc;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("CCCECEE2-D225-4294-858E-2B8C3F7D84EA")
    IWebApplicationCtxSvc : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE GetItemContext( 
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier,
            /* [in] */ VSITEMID itemid,
            /* [out] */ __RPC__deref_out_opt IServiceProvider **ppServiceProvider) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetItemContextFromPath( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [in] */ BOOL bCreate,
            /* [out] */ __RPC__deref_out_opt IVsHierarchy **ppHier,
            /* [out] */ __RPC__out VSITEMID *pitemid) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWebApplicationCtxSvcVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWebApplicationCtxSvc * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWebApplicationCtxSvc * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWebApplicationCtxSvc * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetItemContext )( 
            IWebApplicationCtxSvc * This,
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier,
            /* [in] */ VSITEMID itemid,
            /* [out] */ __RPC__deref_out_opt IServiceProvider **ppServiceProvider);
        
        HRESULT ( STDMETHODCALLTYPE *GetItemContextFromPath )( 
            IWebApplicationCtxSvc * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [in] */ BOOL bCreate,
            /* [out] */ __RPC__deref_out_opt IVsHierarchy **ppHier,
            /* [out] */ __RPC__out VSITEMID *pitemid);
        
        END_INTERFACE
    } IWebApplicationCtxSvcVtbl;

    interface IWebApplicationCtxSvc
    {
        CONST_VTBL struct IWebApplicationCtxSvcVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWebApplicationCtxSvc_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IWebApplicationCtxSvc_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IWebApplicationCtxSvc_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IWebApplicationCtxSvc_GetItemContext(This,pHier,itemid,ppServiceProvider)	\
    ( (This)->lpVtbl -> GetItemContext(This,pHier,itemid,ppServiceProvider) ) 

#define IWebApplicationCtxSvc_GetItemContextFromPath(This,pszFilePath,bCreate,ppHier,pitemid)	\
    ( (This)->lpVtbl -> GetItemContextFromPath(This,pszFilePath,bCreate,ppHier,pitemid) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IWebApplicationCtxSvc_INTERFACE_DEFINED__ */


#ifndef __IWebFileCtxService_INTERFACE_DEFINED__
#define __IWebFileCtxService_INTERFACE_DEFINED__

/* interface IWebFileCtxService */
/* [object][unique][helpstring][uuid] */ 


EXTERN_C const IID IID_IWebFileCtxService;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("05B4B4B7-6A9D-4a70-BDB1-04CBB26C9248")
    IWebFileCtxService : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE AddFileToIntellisense( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__out VSITEMID *pItemID) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE EnsureFileOpened( 
            /* [in] */ VSITEMID itemid,
            /* [out] */ __RPC__deref_out_opt IVsWindowFrame **ppFrame) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RemoveFileFromIntellisense( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetWebRootPath( 
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrWebRootPath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetIntellisenseProjectName( 
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrProjectName) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE AddDependentAssemblyFile( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RemoveDependentAssemblyFile( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE ConvertToAppRelPath( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrAppRelPath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CBMCallbackActive( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE WaitForIntellisenseReady( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE IsDocumentInProject( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__out VSITEMID *pItemID) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWebFileCtxServiceVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWebFileCtxService * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWebFileCtxService * This);
        
        HRESULT ( STDMETHODCALLTYPE *AddFileToIntellisense )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__out VSITEMID *pItemID);
        
        HRESULT ( STDMETHODCALLTYPE *EnsureFileOpened )( 
            IWebFileCtxService * This,
            /* [in] */ VSITEMID itemid,
            /* [out] */ __RPC__deref_out_opt IVsWindowFrame **ppFrame);
        
        HRESULT ( STDMETHODCALLTYPE *RemoveFileFromIntellisense )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath);
        
        HRESULT ( STDMETHODCALLTYPE *GetWebRootPath )( 
            IWebFileCtxService * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrWebRootPath);
        
        HRESULT ( STDMETHODCALLTYPE *GetIntellisenseProjectName )( 
            IWebFileCtxService * This,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrProjectName);
        
        HRESULT ( STDMETHODCALLTYPE *AddDependentAssemblyFile )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath);
        
        HRESULT ( STDMETHODCALLTYPE *RemoveDependentAssemblyFile )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath);
        
        HRESULT ( STDMETHODCALLTYPE *ConvertToAppRelPath )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__deref_out_opt BSTR *pbstrAppRelPath);
        
        HRESULT ( STDMETHODCALLTYPE *CBMCallbackActive )( 
            IWebFileCtxService * This);
        
        HRESULT ( STDMETHODCALLTYPE *WaitForIntellisenseReady )( 
            IWebFileCtxService * This);
        
        HRESULT ( STDMETHODCALLTYPE *IsDocumentInProject )( 
            IWebFileCtxService * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [out] */ __RPC__out VSITEMID *pItemID);
        
        END_INTERFACE
    } IWebFileCtxServiceVtbl;

    interface IWebFileCtxService
    {
        CONST_VTBL struct IWebFileCtxServiceVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWebFileCtxService_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IWebFileCtxService_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IWebFileCtxService_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IWebFileCtxService_AddFileToIntellisense(This,pszFilePath,pItemID)	\
    ( (This)->lpVtbl -> AddFileToIntellisense(This,pszFilePath,pItemID) ) 

#define IWebFileCtxService_EnsureFileOpened(This,itemid,ppFrame)	\
    ( (This)->lpVtbl -> EnsureFileOpened(This,itemid,ppFrame) ) 

#define IWebFileCtxService_RemoveFileFromIntellisense(This,pszFilePath)	\
    ( (This)->lpVtbl -> RemoveFileFromIntellisense(This,pszFilePath) ) 

#define IWebFileCtxService_GetWebRootPath(This,pbstrWebRootPath)	\
    ( (This)->lpVtbl -> GetWebRootPath(This,pbstrWebRootPath) ) 

#define IWebFileCtxService_GetIntellisenseProjectName(This,pbstrProjectName)	\
    ( (This)->lpVtbl -> GetIntellisenseProjectName(This,pbstrProjectName) ) 

#define IWebFileCtxService_AddDependentAssemblyFile(This,pszFilePath)	\
    ( (This)->lpVtbl -> AddDependentAssemblyFile(This,pszFilePath) ) 

#define IWebFileCtxService_RemoveDependentAssemblyFile(This,pszFilePath)	\
    ( (This)->lpVtbl -> RemoveDependentAssemblyFile(This,pszFilePath) ) 

#define IWebFileCtxService_ConvertToAppRelPath(This,pszFilePath,pbstrAppRelPath)	\
    ( (This)->lpVtbl -> ConvertToAppRelPath(This,pszFilePath,pbstrAppRelPath) ) 

#define IWebFileCtxService_CBMCallbackActive(This)	\
    ( (This)->lpVtbl -> CBMCallbackActive(This) ) 

#define IWebFileCtxService_WaitForIntellisenseReady(This)	\
    ( (This)->lpVtbl -> WaitForIntellisenseReady(This) ) 

#define IWebFileCtxService_IsDocumentInProject(This,pszFilePath,pItemID)	\
    ( (This)->lpVtbl -> IsDocumentInProject(This,pszFilePath,pItemID) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IWebFileCtxService_INTERFACE_DEFINED__ */


#ifndef __IWebClassLibProjectEvents_INTERFACE_DEFINED__
#define __IWebClassLibProjectEvents_INTERFACE_DEFINED__

/* interface IWebClassLibProjectEvents */
/* [object][unique][helpstring][uuid] */ 


EXTERN_C const IID IID_IWebClassLibProjectEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("465BE4D1-B10C-4a7e-AFCF-3C55AD3EDAE3")
    IWebClassLibProjectEvents : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE OnReferenceAdded( 
            /* [in] */ __RPC__in LPCWSTR pszReferencePath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnFileAdded( 
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [in] */ VARIANT_BOOL foldersMustBeInProject) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE StartWebAdminTool( void) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWebClassLibProjectEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWebClassLibProjectEvents * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWebClassLibProjectEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWebClassLibProjectEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *OnReferenceAdded )( 
            IWebClassLibProjectEvents * This,
            /* [in] */ __RPC__in LPCWSTR pszReferencePath);
        
        HRESULT ( STDMETHODCALLTYPE *OnFileAdded )( 
            IWebClassLibProjectEvents * This,
            /* [in] */ __RPC__in LPCWSTR pszFilePath,
            /* [in] */ VARIANT_BOOL foldersMustBeInProject);
        
        HRESULT ( STDMETHODCALLTYPE *StartWebAdminTool )( 
            IWebClassLibProjectEvents * This);
        
        END_INTERFACE
    } IWebClassLibProjectEventsVtbl;

    interface IWebClassLibProjectEvents
    {
        CONST_VTBL struct IWebClassLibProjectEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWebClassLibProjectEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IWebClassLibProjectEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IWebClassLibProjectEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IWebClassLibProjectEvents_OnReferenceAdded(This,pszReferencePath)	\
    ( (This)->lpVtbl -> OnReferenceAdded(This,pszReferencePath) ) 

#define IWebClassLibProjectEvents_OnFileAdded(This,pszFilePath,foldersMustBeInProject)	\
    ( (This)->lpVtbl -> OnFileAdded(This,pszFilePath,foldersMustBeInProject) ) 

#define IWebClassLibProjectEvents_StartWebAdminTool(This)	\
    ( (This)->lpVtbl -> StartWebAdminTool(This) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IWebClassLibProjectEvents_INTERFACE_DEFINED__ */


#ifndef __IWebClassLibProject_INTERFACE_DEFINED__
#define __IWebClassLibProject_INTERFACE_DEFINED__

/* interface IWebClassLibProject */
/* [object][unique][helpstring][uuid] */ 


EXTERN_C const IID IID_IWebClassLibProject;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("F4DD7776-905A-4b75-98F4-162C2D3C7AFA")
    IWebClassLibProject : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE UpdateAnchoredPath( 
            /* [in] */ __RPC__in LPCWSTR pszNewRootPath,
            /* [in] */ __RPC__in LPCWSTR pszOptionalVDir) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE CloseProject( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE UnloadAppDomain( 
            /* [in] */ BOOL bWaitForReset) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE UpdateProjectReference( 
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnBeforeFileAdd( 
            /* [in] */ __RPC__in LPCWSTR pszFileAdded) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnBeforeFileRemove( 
            /* [in] */ __RPC__in LPCWSTR pszFileRemoved) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnBeforeFileMove( 
            /* [in] */ __RPC__in LPCOLESTR pwszOldAbsPath,
            /* [in] */ __RPC__in LPCOLESTR pwszNewAbsPath) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE OnBeforeFileSave( 
            /* [in] */ __RPC__in LPCOLESTR pwszFileSaved) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWebClassLibProjectVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWebClassLibProject * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWebClassLibProject * This);
        
        HRESULT ( STDMETHODCALLTYPE *UpdateAnchoredPath )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in LPCWSTR pszNewRootPath,
            /* [in] */ __RPC__in LPCWSTR pszOptionalVDir);
        
        HRESULT ( STDMETHODCALLTYPE *CloseProject )( 
            IWebClassLibProject * This);
        
        HRESULT ( STDMETHODCALLTYPE *UnloadAppDomain )( 
            IWebClassLibProject * This,
            /* [in] */ BOOL bWaitForReset);
        
        HRESULT ( STDMETHODCALLTYPE *UpdateProjectReference )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier);
        
        HRESULT ( STDMETHODCALLTYPE *OnBeforeFileAdd )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in LPCWSTR pszFileAdded);
        
        HRESULT ( STDMETHODCALLTYPE *OnBeforeFileRemove )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in LPCWSTR pszFileRemoved);
        
        HRESULT ( STDMETHODCALLTYPE *OnBeforeFileMove )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in LPCOLESTR pwszOldAbsPath,
            /* [in] */ __RPC__in LPCOLESTR pwszNewAbsPath);
        
        HRESULT ( STDMETHODCALLTYPE *OnBeforeFileSave )( 
            IWebClassLibProject * This,
            /* [in] */ __RPC__in LPCOLESTR pwszFileSaved);
        
        END_INTERFACE
    } IWebClassLibProjectVtbl;

    interface IWebClassLibProject
    {
        CONST_VTBL struct IWebClassLibProjectVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWebClassLibProject_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IWebClassLibProject_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IWebClassLibProject_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IWebClassLibProject_UpdateAnchoredPath(This,pszNewRootPath,pszOptionalVDir)	\
    ( (This)->lpVtbl -> UpdateAnchoredPath(This,pszNewRootPath,pszOptionalVDir) ) 

#define IWebClassLibProject_CloseProject(This)	\
    ( (This)->lpVtbl -> CloseProject(This) ) 

#define IWebClassLibProject_UnloadAppDomain(This,bWaitForReset)	\
    ( (This)->lpVtbl -> UnloadAppDomain(This,bWaitForReset) ) 

#define IWebClassLibProject_UpdateProjectReference(This,pHier)	\
    ( (This)->lpVtbl -> UpdateProjectReference(This,pHier) ) 

#define IWebClassLibProject_OnBeforeFileAdd(This,pszFileAdded)	\
    ( (This)->lpVtbl -> OnBeforeFileAdd(This,pszFileAdded) ) 

#define IWebClassLibProject_OnBeforeFileRemove(This,pszFileRemoved)	\
    ( (This)->lpVtbl -> OnBeforeFileRemove(This,pszFileRemoved) ) 

#define IWebClassLibProject_OnBeforeFileMove(This,pwszOldAbsPath,pwszNewAbsPath)	\
    ( (This)->lpVtbl -> OnBeforeFileMove(This,pwszOldAbsPath,pwszNewAbsPath) ) 

#define IWebClassLibProject_OnBeforeFileSave(This,pwszFileSaved)	\
    ( (This)->lpVtbl -> OnBeforeFileSave(This,pwszFileSaved) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IWebClassLibProject_INTERFACE_DEFINED__ */


#ifndef __IWebClassLibProjectSvc_INTERFACE_DEFINED__
#define __IWebClassLibProjectSvc_INTERFACE_DEFINED__

/* interface IWebClassLibProjectSvc */
/* [object][unique][helpstring][uuid] */ 


EXTERN_C const IID IID_IWebClassLibProjectSvc;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("95D018C3-B554-430e-B62C-950E79728B0D")
    IWebClassLibProjectSvc : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE CreateClassLibProject( 
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier,
            /* [in] */ __RPC__in LPCWSTR pszRootPathOrUrl,
            /* [in] */ CREATECLASSLIBFLAGS dwFlags,
            /* [in] */ __RPC__in LPCWSTR pszOptionalVDir,
            /* [out] */ __RPC__deref_out_opt IWebClassLibProject **ppClassLibProject) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IWebClassLibProjectSvcVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IWebClassLibProjectSvc * This,
            /* [in] */ __RPC__in REFIID riid,
            /* [iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IWebClassLibProjectSvc * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IWebClassLibProjectSvc * This);
        
        HRESULT ( STDMETHODCALLTYPE *CreateClassLibProject )( 
            IWebClassLibProjectSvc * This,
            /* [in] */ __RPC__in_opt IVsHierarchy *pHier,
            /* [in] */ __RPC__in LPCWSTR pszRootPathOrUrl,
            /* [in] */ CREATECLASSLIBFLAGS dwFlags,
            /* [in] */ __RPC__in LPCWSTR pszOptionalVDir,
            /* [out] */ __RPC__deref_out_opt IWebClassLibProject **ppClassLibProject);
        
        END_INTERFACE
    } IWebClassLibProjectSvcVtbl;

    interface IWebClassLibProjectSvc
    {
        CONST_VTBL struct IWebClassLibProjectSvcVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IWebClassLibProjectSvc_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IWebClassLibProjectSvc_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IWebClassLibProjectSvc_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IWebClassLibProjectSvc_CreateClassLibProject(This,pHier,pszRootPathOrUrl,dwFlags,pszOptionalVDir,ppClassLibProject)	\
    ( (This)->lpVtbl -> CreateClassLibProject(This,pHier,pszRootPathOrUrl,dwFlags,pszOptionalVDir,ppClassLibProject) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IWebClassLibProjectSvc_INTERFACE_DEFINED__ */

#endif /* __WebApplicationCtx_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


