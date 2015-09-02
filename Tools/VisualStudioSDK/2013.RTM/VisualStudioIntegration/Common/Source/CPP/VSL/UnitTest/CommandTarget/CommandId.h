/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#include <VSLUnitTest.h>
#include <VSLCommandTarget.h>
#include <VSLShortNameDefines.h>

class CommandIdTest :
	public VSL::UnitTestBase
{
private:
	static const GUID	s_guidTest;
	static const DWORD	s_dwTestId;

	void CheckCommandID(const VSL::CommandId& rCommandId)
	{
		// Check that GetGuid returns the expected value.
		UTCHKEX(s_guidTest == rCommandId.GetGuid(), L"CommandId::GetGuid() returned an unexpected value.");
		// Check that GetId() returns the expected value.
		UTCHKEX(s_dwTestId == rCommandId.GetId(), L"CommandId::GetId() returned an unexpected value.");
		UTCHKEX(0xe90ff436 == static_cast<ULONG_PTR>(rCommandId), L"CommandId::operator ULONG_PTR() didn't hash correctly.");
	}
public:
	CommandIdTest(_In_opt_ const char* const szTestName);
};
