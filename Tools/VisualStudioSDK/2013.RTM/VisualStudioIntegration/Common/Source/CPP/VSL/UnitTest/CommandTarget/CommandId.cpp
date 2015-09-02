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

#include "CommandId.h"

// Initialize the static variables for CommandIdTest
const GUID  CommandIdTest::s_guidTest = {0x6558b1c8, 0x4257, 0x45c1, {0xb0, 0x49, 0x62, 0xce, 0x32, 0xeb, 0x6b, 0x15}};
const DWORD CommandIdTest::s_dwTestId = 42;

CommandIdTest::CommandIdTest(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	VSL::CommandId commandID1(s_guidTest, s_dwTestId);
	CheckCommandID(commandID1);
	VSL::CommandId commandID2(commandID1);
	CheckCommandID(commandID2);
	UTCHKEX(commandID1 == commandID2, L"CommandId::operator== returned an unexpected value.");
	UTCHKEX(!(commandID1 != commandID2), L"CommandId::operator== returned an unexpected value.");
}