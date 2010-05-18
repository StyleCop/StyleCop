#pragma once
//-------------------------------------------------------------------------------------------------
// <copyright file="cabcutil.h" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
// <summary>
//    Header for cabinet creation helper functions.
// </summary>
//-------------------------------------------------------------------------------------------------

#include <fci.h>
#include <fcntl.h>

#define CAB_MAX_SIZE 0x7FFFFFFF   // (see KB: Q174866)

#ifdef __cplusplus
extern "C" {
#endif

// time vs. space trade-off
enum COMPRESSION_TYPE 
{ 
	COMPRESSION_TYPE_NONE, // fastest
	COMPRESSION_TYPE_LOW, 
	COMPRESSION_TYPE_MEDIUM,
	COMPRESSION_TYPE_HIGH, // smallest
	COMPRESSION_TYPE_MSZIP
};

// functions
HRESULT DAPI CabCBegin(
	__in LPCWSTR wzCab,
	__in LPCWSTR wzCabDir,
	__in DWORD dwMaxSize,
	__in DWORD dwMaxThresh,
	__in COMPRESSION_TYPE ct,
	__out HANDLE *phContext
	);
HRESULT DAPI CabCNextCab(
	__in HANDLE hContext
	);
HRESULT DAPI CabCAddFile(
	__in LPCWSTR wzFile,
	__in LPCWSTR wzToken,
	__in HANDLE hContext
	);
HRESULT DAPI CabCFinish(
	__in HANDLE hContext
	);

#ifdef __cplusplus
}
#endif
