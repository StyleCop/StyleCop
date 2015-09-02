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

#include "CommandTarget.h"
#include <VSLCommandTarget.h>
#include <VSLMockSystemInterfaces.h>

static const GUID guidCmdSet1 = {0xbe604d71, 0x9569, 0x4abc, {0xba, 0x6b, 0xab, 0x68, 0xc7, 0x65, 0x32, 0xb5}};
static const GUID guidCmdSet2 = {0x11770c63, 0xc2f5, 0x4149, {0x99, 0x0b, 0xd6, 0x99, 0x74, 0x06, 0x07, 0xb3}};

class TestEmptyMap :
	public VSL::IOleCommandTargetImpl<TestEmptyMap>
{
public:
	TestEmptyMap() {};

	VSL_DEFINE_IUNKNOWN_NOTIMPL

	VSL_BEGIN_COMMAND_MAP()
	VSL_END_VSCOMMAND_MAP()
};

class DefaultCommand :
	public VSL::IOleCommandTargetImpl<DefaultCommand>
{
public:
	DefaultCommand() {};

	VSL_DEFINE_IUNKNOWN_NOTIMPL

	VSL_BEGIN_COMMAND_MAP()
		VSL_COMMAND_MAP_ENTRY(guidCmdSet1, 1, NULL, NULL)
	VSL_END_VSCOMMAND_MAP()
};

class DerivedCommand :
	public VSL::IOleCommandTargetImpl<DerivedCommand>
{
private:
	class MyCommand : public CommandHandler
	{
	private:
		CStringW m_str;
	public:
		MyCommand(VSL::CommandId id, const wchar_t* text) :
			CommandHandler(id, NULL, NULL, OLECMDF_SUPPORTED | OLECMDF_ENABLED, text),
			m_str(s_strDerivedText)
		{
		}

		const CStringW& GetText() const { return m_str; }
	};

public:
	static const wchar_t* s_strBaseText;
	static const wchar_t* s_strDerivedText;

	DerivedCommand() {};

	VSL_DEFINE_IUNKNOWN_NOTIMPL

	VSL_BEGIN_COMMAND_MAP()
		VSL_COMMAND_MAP_CLASS_ENTRY(MyCommand, (VSL::CommandId(guidCmdSet1, 1), s_strBaseText))
	VSL_END_VSCOMMAND_MAP()
};

const wchar_t* DerivedCommand::s_strBaseText = L"Base string";
const wchar_t* DerivedCommand::s_strDerivedText = L"Derived string";


TargetTest::TargetTest(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	// Create a command target without any command.
	TestEmptyMap testEmptyMap;
	IOleCommandTarget* target = static_cast<IOleCommandTarget*>(&testEmptyMap);

	// Check that Exec returns E_POINTER if the pointer to the GUID is null.
	UTCHKEX(E_POINTER==target->Exec(NULL, 0, 0, NULL, NULL), L"Unexpected value returned by Exec.");
	// Check that Exec returns NOTSUPPORTED for any command.
	UTCHKEX(OLECMDERR_E_NOTSUPPORTED==target->Exec(&guidCmdSet1, 1, 0, NULL, NULL), L"Unexpected value returned by Exec.");

	// Check that QueryStatus can handle NULL arguments.
	UTCHKEX(E_POINTER==target->QueryStatus(NULL, 0, NULL, NULL), L"Unexpected value returned by QueryStatus.");
	UTCHKEX(E_POINTER==target->QueryStatus(&guidCmdSet1, 1, NULL, NULL), L"Unexpected value returned by QueryStatus.");
	OLECMD oleCmd;
	UTCHKEX(E_INVALIDARG==target->QueryStatus(&guidCmdSet1, 0, &oleCmd, NULL), L"Unexpected value returned by QueryStatus.");
	UTCHKEX(E_INVALIDARG==target->QueryStatus(&guidCmdSet1, 3, &oleCmd, NULL), L"Unexpected value returned by QueryStatus.");
	UTCHKEX(OLECMDERR_E_NOTSUPPORTED==target->QueryStatus(&guidCmdSet1, 1, &oleCmd, NULL), L"Unexpected value returned by QueryStatus.");

	// Create a command target with default commands
	DefaultCommand defaultCommand;
	target = static_cast<IOleCommandTarget*>(&defaultCommand);

	UTCHK(OLECMDERR_E_NOTSUPPORTED==target->Exec(&guidCmdSet1, 10, 0, NULL, NULL));
	UTCHK(OLECMDERR_E_NOTSUPPORTED==target->Exec(&guidCmdSet2, 1, 0, NULL, NULL));
	UTCHK(S_OK==target->Exec(&guidCmdSet1, 1, 0, NULL, NULL));

	oleCmd.cmdf = 0;
	oleCmd.cmdID = 10;
	UTCHK(OLECMDERR_E_NOTSUPPORTED==target->QueryStatus(&guidCmdSet1, 1, &oleCmd, NULL));
	oleCmd.cmdID = 1;
	UTCHK(OLECMDERR_E_NOTSUPPORTED==target->QueryStatus(&guidCmdSet2, 1, &oleCmd, NULL));
	UTCHK(S_OK==target->QueryStatus(&guidCmdSet1, 1, &oleCmd, NULL));
	UTCHK((OLECMDF_SUPPORTED|OLECMDF_ENABLED) == oleCmd.cmdf);

	// Check that query status correctly retrieves the text passed in to custom constructor on the map.
	DerivedCommand derivedCommand;
	target = static_cast<IOleCommandTarget*>(&derivedCommand);
	const size_t stringSize = 20;
	const size_t bufferSize = sizeof(OLECMDTEXT)+ ((stringSize-1)*sizeof(wchar_t));
	BYTE buffer[bufferSize];
	OLECMDTEXT* pOleText = (OLECMDTEXT*)buffer;
	pOleText->cmdtextf = OLECMDTEXTF_NAME;
	pOleText->cwActual = 0;
	pOleText->cwBuf = stringSize;
	oleCmd.cmdID = 10;
	oleCmd.cmdID = 1;
	UTCHK(S_OK==target->QueryStatus(&guidCmdSet1, 1, &oleCmd, pOleText));
	UTCHK(0 == wcscmp(DerivedCommand::s_strBaseText, pOleText->rgwz));
}

