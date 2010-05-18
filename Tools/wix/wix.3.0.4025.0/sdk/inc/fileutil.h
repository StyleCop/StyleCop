#pragma once
//-------------------------------------------------------------------------------------------------
// <copyright file="fileutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Header for file helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#include <wchar.h>

#ifdef __cplusplus
extern "C" {
#endif

#define ReleaseFile(h) if (INVALID_HANDLE_VALUE != h) { ::CloseHandle(h); h = INVALID_HANDLE_VALUE; }

LPWSTR DAPI FileFromPath(
    __in LPCWSTR wzPath
    );
HRESULT DAPI FileResolvePath(
    __in LPCWSTR wzRelativePath,
    __out LPWSTR *ppwzFullPath
    );
HRESULT DAPI FileStripExtension(
    __in LPCWSTR wzFileName,
    __out LPWSTR *ppwzFileNameNoExtension
    );
HRESULT DAPI FileVersionFromString(
    __in LPCWSTR wzVersion, 
    __out DWORD *pdwVerMajor, 
    __out DWORD* pdwVerMinor
    );
HRESULT DAPI FileSizeByHandle(
    __in HANDLE hFile, 
    __out LONGLONG* pllSize
    );
BOOL DAPI FileExistsEx(
    __in LPCWSTR wzPath, 
    __out_opt DWORD *pdwAttributes
    );
HRESULT DAPI FileRead(
    __out LPBYTE* ppbDest,
    __out DWORD* pcbDest,
    __in LPCWSTR wzSrcPath
    );
HRESULT DAPI FileReadUntil(
    __out LPBYTE* ppbDest,
    __out DWORD* pcbDest,
    __in LPCWSTR wzSrcPath,
    __in DWORD cbMaxRead
    );
HRESULT DAPI FileEnsureMove(
    __in LPCWSTR wzSource, 
    __in LPCWSTR wzTarget, 
    __in BOOL fOverwrite,
    __in BOOL fAllowCopy
    );
HRESULT FileCreateTemp(
    __in LPCWSTR wzPrefix,
    __in LPCWSTR wzExtension,
    __deref_out_z LPWSTR* ppwzLog,
    __out HANDLE* phLog
    );
HRESULT FileCreateTempW(
    __in LPCWSTR wzPrefix,
    __in LPCWSTR wzExtension,
    __deref_out_z LPWSTR* ppwzTempFile,
    __out HANDLE* phTempFile
    );
HRESULT FileVersion(
    __in LPCWSTR wzFilename, 
    __out DWORD *pdwVerMajor, 
    __out DWORD* pdwVerMinor
    );
HRESULT DAPI FileIsSame(
    __in LPCWSTR wzFile1,
    __in LPCWSTR wzFile2,
    __out LPBOOL lpfSameFile
    );
HRESULT DAPI FileEnsureDelete(
    __in LPCWSTR wzFile
    );

#ifdef __cplusplus
}
#endif
