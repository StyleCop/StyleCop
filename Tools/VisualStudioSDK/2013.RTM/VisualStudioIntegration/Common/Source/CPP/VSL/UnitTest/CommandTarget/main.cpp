/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include "StdAfx.h"

#include "VSLUnitTest.h"

#include "CommandId.h"
#include "CommandHandler.h"
#include "CommandTarget.h"

int _cdecl wmain()
{
	VSL_UTRUN(CommandIdTest);
	VSL_UTRUN(HandlerTestProperties);
	VSL_UTRUN(HandlerTestStandardMethods);
	VSL_UTRUN(HandlerTestCallbacks);
	VSL_UTRUN(TargetTest);
	return VSL::FailureCounter::Get();
}
