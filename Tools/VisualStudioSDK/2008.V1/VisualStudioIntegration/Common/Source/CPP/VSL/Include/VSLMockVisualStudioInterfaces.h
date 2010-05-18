/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLMOCKVISUALSTUDIOINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLMOCKVISUALSTUDIOINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>
#include <VsShellInterfaces.h>
#include <VSLMockIVsShell.h>
#include <VSLMockIVsUIShell.h>
#include <VSLMockIEnumWindowFrames.h>
#include <VSLMockIVsOutputWindowPane.h>
#include <VSLMockIVsWindowFrame.h>
#include <VSLMockIVsWindowFrame2.h>
#include <VSLMockIVsToolWindowToolbarHost.h>
#include <VSLMockIProfferService.h>
#include <proffserv.h>

namespace VSL
{

inline void PushIVsShellLoadUILibrary(REFCLSID clsid, DWORD_PTR* ppdwModule, HRESULT hrRetrun = S_OK)
{
	VSL_START_VALIDVALUES(IVsShell, LoadUILibrary)
		clsid,
		0,
		ppdwModule,
		hrRetrun
	VSL_END_VALIDVALUES_PUSH();
}

inline void PushIVsWindowFrameGetProperty(VSFPROPID propid, VARIANT* pvar, HRESULT retValue = S_OK)
{
	VSL_PUSH_VALIDVALUES3(IVsWindowFrame, GetProperty, propid, pvar, retValue);
}

} // namespace VSL

#endif VSLMOCKVISUALSTUDIOINTERFACE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5