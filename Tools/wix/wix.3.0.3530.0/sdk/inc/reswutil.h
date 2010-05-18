//-------------------------------------------------------------------------------------------------
// <copyright file="reswutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Resource writer helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#pragma once


#ifdef __cplusplus
extern "C" {
#endif

HRESULT DAPI ResWriteString(
    __in LPCWSTR wzResourceFile,
    __in DWORD dwDataId,
    __in LPCWSTR wzData,
    __in WORD wLangId
    );

HRESULT DAPI ResWriteData(
    __in LPCWSTR wzResourceFile,
    __in LPCSTR szDataName,
    __in PVOID pData,
    __in DWORD cbData
    );

HRESULT DAPI ResImportDataFromFile(
    __in LPCWSTR wzTargetFile,
    __in LPCWSTR wzSourceFile,
    __in LPCSTR szDataName
    );

#ifdef __cplusplus
}
#endif
