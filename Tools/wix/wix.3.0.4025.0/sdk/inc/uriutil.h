//-------------------------------------------------------------------------------------------------
// <copyright file="uriutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    URI helper funtions.
// </summary>
//-------------------------------------------------------------------------------------------------

#pragma once


#ifdef __cplusplus
extern "C" {
#endif

enum URI_PROTOCOL
{
    URI_PROTOCOL_UNKNOWN,
    URI_PROTOCOL_FILE,
    URI_PROTOCOL_FTP,
    URI_PROTOCOL_HTTP,
    URI_PROTOCOL_LOCAL,
    URI_PROTOCOL_UNC
};


LPWSTR DAPI UriFile(
    __in LPCWSTR wzUri
    );

HRESULT DAPI UriProtocol(
    __in LPCWSTR wzUri,
    __out URI_PROTOCOL* pProtocol
    );

HRESULT DAPI UriRoot(
    __in LPCWSTR wzUri,
    __out LPWSTR* ppwzRoot,
    __out_opt URI_PROTOCOL* pProtocol
    );

HRESULT DAPI UriResolve(
    __in LPCWSTR wzUri,
    __in_opt LPCWSTR wzBaseUri,
    __out LPWSTR* ppwzResolvedUri,
    __out_opt URI_PROTOCOL* pResolvedProtocol
    );

#ifdef __cplusplus
}
#endif

