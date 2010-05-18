#pragma once
//-------------------------------------------------------------------------------------------------
// <copyright file="wcawow64.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Windows Installer XML CustomAction utility library for Wow64 API-related functionality.
// </summary>
//-------------------------------------------------------------------------------------------------

#include "wcautil.h"

#ifdef __cplusplus
extern "C" {
#endif

HRESULT WIXAPI WcaInitializeWow64();
BOOL WIXAPI WcaIsWow64Initialized();
BOOL WIXAPI WcaDisableWow64FSRedirection();
BOOL WIXAPI WcaRevertWow64FSRedirection();
HRESULT WIXAPI WcaFinalizeWow64();

#ifdef __cplusplus
}
#endif
