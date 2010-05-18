//-------------------------------------------------------------------------------------------------
// <copyright file="resrutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Resource read helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#pragma once


#ifdef __cplusplus
extern "C" {
#endif

HRESULT DAPI ResReadString(
    __in HINSTANCE hinst,
    __in UINT uID,
    __out LPWSTR* ppwzString
    );

HRESULT DAPI ResReadData(
    __in LPCSTR szDataName,
    __out PVOID *ppv,
    __out DWORD *pcb
    );

HRESULT DAPI ResExportDataToFile(
    __in LPCSTR szDataName,
    __in LPCWSTR wzTargetFile,
    __in DWORD dwCreationDisposition
    );

#ifdef __cplusplus
}
#endif

