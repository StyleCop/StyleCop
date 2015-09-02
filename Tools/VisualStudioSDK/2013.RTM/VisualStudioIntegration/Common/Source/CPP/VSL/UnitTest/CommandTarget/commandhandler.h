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

class HandlerTestProperties :
	public VSL::UnitTestBase
{
private:
	void CheckDefaultValues(
		const VSL::CommandHandlerBase<HandlerTestProperties>& rHandler, 
		const VSL::CommandId& rID)
	{
		// Check the ID for the command.
		UTCHKEX(rID == rHandler.GetId(), L"CommandHandlerBase::GetId returned an unexpected value.");
		// The text should be NULL or empty.
		const wchar_t* szText = rHandler.GetText();
		UTCHKEX((NULL==szText) || (0==wcslen(szText)), L"CommandHandlerBase::GetText should return NULL.");
		// Check the status properties.
		UTCHKEX(false == rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return false.");
		UTCHKEX(rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return true.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return true.");
	}

	void CheckSupportedWasSet(
		const VSL::CommandHandlerBase<HandlerTestProperties>& rHandler, 
		const VSL::CommandId& rID)
	{
		// Check the ID for the command.
		UTCHKEX(rID == rHandler.GetId(), L"CommandHandlerBase::GetId returned an unexpected value.");
		// The text should be NULL or empty.
		const wchar_t* szText = rHandler.GetText();
		UTCHKEX((NULL==szText) || (0==wcslen(szText)), L"CommandHandlerBase::GetText should return NULL.");
		// Check the status properties.
		UTCHKEX(false == rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return false.");
		UTCHKEX(false == rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return false.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return true.");
		UTCHKEX(OLECMDF_SUPPORTED == rHandler.GetFlags(), L"CommandHandlerBase::GetFlags returned an unexpected value.");
	}

	void CheckVariousFlagsSet(
		const VSL::CommandHandlerBase<HandlerTestProperties>& rHandler, 
		const VSL::CommandId& rID,
		DWORD dwFlags)
	{
		// Check the ID for the command.
		UTCHKEX(rID == rHandler.GetId(), L"CommandHandlerBase::GetId returned an unexpected value.");
		// The text should be NULL or empty.
		const wchar_t* szText = rHandler.GetText();
		UTCHKEX((NULL==szText) || (0==wcslen(szText)), L"CommandHandlerBase::GetText should return NULL.");
		// Check the status properties.
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return true.");
		UTCHKEX(false == rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return false.");
		UTCHKEX(false == rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return false.");
		UTCHKEX(dwFlags == rHandler.GetFlags(), L"CommandHandlerBase::GetFlags returned an unexpected value.");
	}

	void CheckSetters(VSL::CommandHandlerBase<HandlerTestProperties>& rHandler)
	{
		// Enable the Checked property.
		rHandler.SetChecked(true);
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return true.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return true.");
		// Enable the Visible property (it was setted before, so nothing should change).
		rHandler.SetVisible(true);
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return true.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return true.");
		// Disable the Visible property.
		rHandler.SetVisible(false);
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return true.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(false == rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return false.");
		// Disable the Enable property.
		rHandler.SetEnabled(false);
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(false == rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return false.");
		UTCHKEX(rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return true.");
		UTCHKEX(false == rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return false.");
		// Disable the Supported property.
		rHandler.SetSupported(false);
		UTCHKEX(rHandler.GetChecked(), L"CommandHandlerBase::GetChecked should return true.");
		UTCHKEX(false == rHandler.GetEnabled(), L"CommandHandlerBase::GetEnabled should return false.");
		UTCHKEX(false == rHandler.GetSupported(), L"CommandHandlerBase::GetSupported should return false.");
		UTCHKEX(false == rHandler.GetVisible(), L"CommandHandlerBase::GetVisible should return false.");
	}

	void CheckText(VSL::CommandHandlerBase<HandlerTestProperties>& rHandler, const wchar_t* const szText)
	{
		const VSL::CommandHandlerBase<HandlerTestProperties>& crHandler = rHandler;
		UTCHKEX(0 == wcscmp(szText, crHandler.GetText()), L"The text was not set correctly by the constructor.");
		const wchar_t szNewText[] = L"New Text";
		rHandler.GetText() = szNewText;
		UTCHKEX(0 == wcscmp(szNewText, crHandler.GetText()), L"The text was not set correctly by the constructor.");
	}

public:
	typedef VSL::CommandHandlerBase<HandlerTestProperties> CommandHandler;

	HandlerTestProperties(_In_opt_ const char* const szTestName);

	void QueryStatusDefault(const CommandHandler& pSender, OLECMD* oleCmd, OLECMDTEXT* oleText)
	{
		CommandHandler::QueryStatusDefault(pSender, oleCmd, oleText);
	}
};

class HandlerTestStandardMethods :
	public VSL::UnitTestBase
{
public:
	typedef VSL::CommandHandlerBase<HandlerTestStandardMethods> CommandHandler;

	HandlerTestStandardMethods(_In_opt_ const char* const szTestName);

	void QueryStatusDefault(const CommandHandler& pSender, OLECMD* oleCmd, OLECMDTEXT* oleText)
	{
		CommandHandler::QueryStatusDefault(pSender, oleCmd, oleText);
	}
};

class HandlerTestCallbacks :
	public VSL::UnitTestBase
{
public:
	HandlerTestCallbacks(_In_opt_ const char* const szTestName);
	typedef VSL::CommandHandlerBase<HandlerTestCallbacks> CommandHandler;

	void QueryStatusDefault(const CommandHandler& pSender, OLECMD* oleCmd, OLECMDTEXT* oleText)
	{
		CommandHandler::QueryStatusDefault(pSender, oleCmd, oleText);
	}
private:
	bool fCallbackCalled;

	void Exec(CommandHandler* caller, DWORD /*flags*/, VARIANT* /*pvIn*/, VARIANT* /*pvOut*/) 
	{
		UTCHKEX(NULL != caller, L"Exec callback called with NULL caller.");
		fCallbackCalled = true;
	}
	void QueryStatus(const CommandHandler& /*caller*/, OLECMD* /*oleCmd*/, OLECMDTEXT* /*oleText*/)
	{
		fCallbackCalled = true; 
	}
};
