#pragma once
//-------------------------------------------------------------------------------------------------
// <copyright file="logutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Header for string helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#ifdef __cplusplus
extern "C" {
#endif

#define LogExitOnFailure(x, i, f) if (FAILED(x)) { LogErrorId(x, i, NULL, NULL, NULL); ExitTrace(x, f); goto LExit; }
#define LogExitOnFailure1(x, i, f, s) if (FAILED(x)) { LogErrorId(x, i, s, NULL, NULL); ExitTrace1(x, f, s); goto LExit; }
#define LogExitOnFailure2(x, i, f, s, t) if (FAILED(x)) { LogErrorId(x, i, s, t, NULL); ExitTrace2(x, f, s, t); goto LExit; }
#define LogExitOnFailure3(x, i, f, s, t, u) if (FAILED(x)) { LogErrorId(x, i, s, t, u); ExitTrace3(x, f, s, t, u); goto LExit; }

// enums

// structs

// functions
HRESULT LogInitialize(
    IN HMODULE hModule,
    IN LPCWSTR wzLog,
    IN LPCWSTR wzExt,
    IN BOOL fAppend,
    IN BOOL fHeader
    );

void LogUninitialize(
    IN BOOL fFooter
    );

BOOL LogIsOpen();

REPORT_LEVEL LogSetLevel(
    IN REPORT_LEVEL rl,
    IN BOOL fLogChange
    );

REPORT_LEVEL LogGetLevel(
    );

HRESULT LogGetPath(
    __out_ecount(cchLogPath) LPWSTR pwzLogPath, 
    __in DWORD cchLogPath
    );

HANDLE LogGetHandle(
    );

HRESULT LogString(
    IN REPORT_LEVEL rl,
    IN LPCSTR szFormat,
    ...
    );

HRESULT LogStringArgs(
    IN REPORT_LEVEL rl,
    IN LPCSTR szFormat,
    IN va_list args
    );

HRESULT LogStringLine(
    IN REPORT_LEVEL rl,
    IN LPCSTR szFormat,
    ...
    );

HRESULT LogStringLineArgs(
    IN REPORT_LEVEL rl,
    IN LPCSTR szFormat,
    IN va_list args
    );

HRESULT LogIdModuleArgs(
    IN REPORT_LEVEL rl,
    IN DWORD dwLogId,
    IN HMODULE hModule,
    va_list args
    );

/* 
 * Wraps LogIdModuleArgs, so inline to save the function call
 */

inline HRESULT LogId(
    IN REPORT_LEVEL rl,
    IN DWORD dwLogId,
    ...
    )
{
    HRESULT hr = S_OK;
    va_list args;
    
    va_start(args, dwLogId);
    hr = LogIdModuleArgs(rl, dwLogId, NULL, args);
    va_end(args);
    
    return hr;
}


/* 
 * Wraps LogIdModuleArgs, so inline to save the function call
 */
 
inline HRESULT LogIdArgs(
    IN REPORT_LEVEL rl,
    IN DWORD dwLogId,
    va_list args
    )
{
    return LogIdModuleArgs(rl, dwLogId, NULL, args);
}

HRESULT LogErrorString(
    IN HRESULT hrError,
    IN LPCSTR szFormat,
    ...
    );

HRESULT LogErrorStringArgs(
    IN HRESULT hrError,
    IN LPCSTR szFormat,
    IN va_list args
    );

HRESULT LogErrorIdModule(
    IN HRESULT hrError,
    IN DWORD dwLogId,
    IN HMODULE hModule,
    IN LPCWSTR wzString1,
    IN LPCWSTR wzString2,
    IN LPCWSTR wzString3
    );

inline HRESULT LogErrorId(
    IN HRESULT hrError,
    IN DWORD dwLogId,
    IN LPCWSTR wzString1,
    IN LPCWSTR wzString2,
    IN LPCWSTR wzString3
    )
{
    return LogErrorIdModule(hrError, dwLogId, NULL, wzString1, wzString2, wzString3);
}

HRESULT LogHeader(
    );

HRESULT LogFooter(
    );

// begin the switch of LogXXX to LogStringXXX
#define Log LogString
#define LogLine LogStringLine

#ifdef __cplusplus
}
#endif

