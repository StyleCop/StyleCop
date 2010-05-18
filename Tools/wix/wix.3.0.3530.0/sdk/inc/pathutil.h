#pragma once
//-------------------------------------------------------------------------------------------------
// <copyright file="pathutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Header for path helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#ifdef __cplusplus
extern "C" {
#endif

enum PATH_EXPAND
{
    PATH_EXPAND_ENVIRONMENT = 0x0001,
    PATH_EXPAND_FULLPATH    = 0x0002,
};

LPWSTR DAPI PathFile(
    __in LPCWSTR wzPath
    );
HRESULT DAPI PathGetDirectory(
    __in LPCWSTR wzPath,
    __out LPWSTR *ppwzDirectory
    );
HRESULT DAPI PathExpand(
    __out LPWSTR *ppwzFullPath,
    __in LPCWSTR wzRelativePath,
    __in DWORD dwResolveFlags
    );
HRESULT DAPI PathPrefix(
    __inout LPWSTR *ppwzFullPath
    );
HRESULT DAPI PathBackslashTerminate(
    __inout LPWSTR* ppwzPath
    );
HRESULT DAPI PathFixedBackslashTerminate(
    __in LPWSTR wzPath,
    __in DWORD_PTR cchPath
    );
HRESULT DAPI PathForCurrentProcess(
    __inout LPWSTR *ppwzFullPath,
    __in_opt HMODULE hModule
    );
HRESULT DAPI PathCreateTempFile(
    __in_opt LPCWSTR wzDirectory,
    __in_opt __format_string LPCWSTR wzFileNameTemplate,
    __in DWORD dwUniqueCount,
    __in DWORD dwFileAttributes,
    __out_opt LPWSTR* ppwzTempFile,
    __out_opt HANDLE* phTempFile
    );
HRESULT DAPI PathCreateTempDirectory(
    __in_opt LPCWSTR wzDirectory,
    __in __format_string LPCWSTR wzDirectoryNameTemplate,
    __in DWORD dwUniqueCount,
    __out LPWSTR* ppwzTempDirectory
    );

#ifdef __cplusplus
}
#endif
