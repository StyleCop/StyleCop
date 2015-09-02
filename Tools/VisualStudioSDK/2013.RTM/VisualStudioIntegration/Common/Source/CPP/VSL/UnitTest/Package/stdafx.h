/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#define NOMINMAX

// REVIEW - some or all of these /analyze warnings in the
// common headers should be fixed for RTM, re-enable the
// ones that are
#pragma warning(push)
#pragma warning(disable : 6011 6054 6309 6387 6535 6387)

#include <atlbase.h>
#include <atlcom.h>
#include <atlstr.h>
#include <limits>

#pragma warning(pop)

#define VSLASSERT _ASSERTE
#define VSLASSERTEX(exp, szMsg) _ASSERT_BASE(exp, szMsg)
#define VSL_TRACE ATLTRACE

#include "VSLUnitTest.h"
#include "VSLExceptionHandlers.h"
#include "VSLMockSystemInterfaces.h"
#include "VSLMockVisualStudioInterfaces.h"
#include "VSLMockIOleComponentUIManager.h"
#include "VSLContainers.h"
