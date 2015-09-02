/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include "stdafx.h"

#define VSLASSERT _ASSERTE
#define VSLASSERTEX(exp, szMsg) _ASSERT_BASE(exp, szMsg)
#define VSL_TRACE ATLTRACE

// We need to explicitly test that the destructor throws, so we suppress this
#define VSL_UNIT_TEST_AddRefAndReleaseMockBase_Destructor_Supress_Assert

#include "VSLUnitTest.h"
#include "VSLExceptionHandlers.h"
#include "VSLMockSystemInterfaces.h"
#include "VSLMockVisualStudioInterfaces.h"
#include "VSLContainers.h"
#include "VSLShortNameDefines.h"

#include "MockInterfaces.h"

using namespace VSL;

class NullBase {};

#include "System.h"
#include "VisualStudio.h"


int _cdecl _tmain()
{
	VSL_UTRUN_BASE_CLASS_HAS_VIRTUAL_DESTRUCTOR(AddRefAndReleaseMockNullBase);
	UTRUN(AddRefAndReleaseMockTest);
	UTRUN(IUnknownInterfaceListTerminatorDefaultTest);
	UTRUN(InterfaceListTest);
	VSL_UTRUN_BASE_CLASS_HAS_VIRTUAL_DESTRUCTOR(QueryInterfaceMockBase);
	UTRUN(QueryInterfaceMockBaseTest);
	// TODO - make this fail correctly if destructor isn't virtual
	UTRUN(COMMockBaseTest);
	UTRUN(ISimpleAndDerivedInterfaceListTest);
	UTRUN(I2MethodsPartialImplTest);
	UTRUN(I2MethodsFullImplTest);
	UTRUN(AtlIServiceProviderMockTest);
	UTRUN(IServiceProviderImplMockTest);
	VSL_UTRUN_BASE_CLASS_HAS_VIRTUAL_DESTRUCTOR(IVsShellNotImplMock);
	UTRUN(IVsShellNotImplTest);
	UTRUN(StaticArrayTest);
	UTRUN(IVsUIShellNotImplTest);
	UTRUN(IVsOutputWindowPaneNotImplTest);
	UTRUN(IVsWindowFrameNotImplTest);
	UTRUN(IVsWindowFrame2NotImplTest);
	UTRUN(IProfferServiceNotImplTest);
	return VSL::FailureCounter::Get();
}

