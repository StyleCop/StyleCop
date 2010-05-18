//-------------------------------------------------------------------------------------------------
// <copyright file="dirutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Directory helper funtions.
// </summary>
//-------------------------------------------------------------------------------------------------

#pragma once

#ifdef __cplusplus
extern "C" {
#endif

BOOL DAPI DirExists(
    __in LPCWSTR wzPath, 
    __out_opt DWORD *pdwAttributes
    );

HRESULT DAPI DirCreateTempPath(
    __in LPCWSTR wzPrefix,
    __in LPWSTR wzPath,
    __in DWORD cchPath
    );

HRESULT DAPI DirEnsureExists(
    __in LPCWSTR wzPath, 
    __in_opt LPSECURITY_ATTRIBUTES psa
    );

HRESULT DAPI DirEnsureDelete(
    __in LPCWSTR wzPath,
    __in BOOL fDeleteFiles,
    __in BOOL fRecurse
    );

#ifdef __cplusplus
}
#endif

