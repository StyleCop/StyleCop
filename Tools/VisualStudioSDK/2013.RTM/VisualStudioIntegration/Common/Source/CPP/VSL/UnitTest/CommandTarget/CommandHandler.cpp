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

#include "CommandHandler.h"

static const GUID  guidTest1 = {0x8e00c93c, 0x827f, 0x4bb5, {0xb5, 0xd7, 0x48, 0x08, 0xba, 0xa0, 0xf7, 0x29}};
static const DWORD dwTestId1 = 21;

HandlerTestProperties::HandlerTestProperties(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	// Create a CommandId for this command handler.
	VSL::CommandId testId(guidTest1, dwTestId1);

	// Check the default values.
	{   // Create the command handler via first constructor
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId);
		CheckDefaultValues(handler, testId);
	}
	{   // Create the command handler via second constructor
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId.GetGuid(), testId.GetId());
		CheckDefaultValues(handler, testId);
	}

	// Check the status properties when set from the constructor
	{   
		// Create the command handler with only the supported flag set.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId, NULL, NULL, OLECMDF_SUPPORTED);
		CheckSupportedWasSet(handler, testId);
	}
	{   
		// Create the command handler with only the supported flag set.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId.GetGuid(), testId.GetId(), NULL, NULL, OLECMDF_SUPPORTED);
		CheckSupportedWasSet(handler, testId);
	}
	DWORD dwVariousFlags = OLECMDF_ENABLED | OLECMDF_INVISIBLE | OLECMDF_LATCHED;
	{   
		// Create the command handler.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId, NULL, NULL, dwVariousFlags);
		CheckVariousFlagsSet(handler, testId, dwVariousFlags);
	}
	{   
		// Create the command handler.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId.GetGuid(), testId.GetId(), NULL, NULL, dwVariousFlags);
		CheckVariousFlagsSet(handler, testId, dwVariousFlags);
	}

	// Check that the properties are set correctly by the setter methods.
	{
		// Create a command handler with the default settings.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId);
		CheckSetters(handler);
	}
	{
		// Create a command handler with the default settings.
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId.GetGuid(), testId.GetId());
		CheckSetters(handler);
	}

	// Check that the Text property is set correctly by the constructor and setter method.
	const wchar_t szText[] = L"Original Text";
	{
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId, NULL, NULL, OLECMDF_ENABLED | OLECMDF_SUPPORTED, szText);
		CheckText(handler, szText);
	}
	{
		VSL::CommandHandlerBase<HandlerTestProperties> handler(testId.GetGuid(), testId.GetId(), NULL, NULL, OLECMDF_ENABLED | OLECMDF_SUPPORTED, szText);
		CheckText(handler, szText);
	}
}


HandlerTestStandardMethods::HandlerTestStandardMethods(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	// Create a CommandId for this command handler.
	VSL::CommandId testId(guidTest1, dwTestId1);

	// Test the standard HandlerTestStandardMethods (no callback).
	{
		VSL::CommandHandlerBase<HandlerTestStandardMethods> handler(testId);
		handler.Exec(NULL, 0, NULL, NULL);

		// QueryStatus
		VSL_STDMETHODTRY {

		handler.QueryStatus(this, NULL, NULL);

		}VSL_STDMETHODCATCH()
		UTCHKEX(E_POINTER==VSL_GET_STDMETHOD_HRESULT(), L"E_POINTER expected from CommandHandlerBase::QueryStatus if there is no OLECMD.");

		OLECMD oleCmd;
		handler.QueryStatus(this, &oleCmd, NULL);
		UTCHKEX((OLECMDF_ENABLED|OLECMDF_SUPPORTED) == oleCmd.cmdf, L"Unexpected OLECMD returned by CommandHandlerBase::QueryStatus.");

		// Define a buffer big enough for the OLECMDTEXT structure with a text of stringLen wchars; notice that when we allocate
		// the buffer we reduce the len of the string by one because the first char is defined inside the structure.
		const size_t stringSize = 11;
		const size_t bufferSize = sizeof(OLECMDTEXT)+ ((stringSize-1)*sizeof(wchar_t)) + 1;
		const BYTE testValue = 7;
		BYTE buffer[bufferSize];
		buffer[bufferSize-1] = testValue; // set a value right after the end of the buffer used by OLECMDTEXT so that we can catch
		                                  // off by 1 errors.
		OLECMDTEXT* pOleText = (OLECMDTEXT*)buffer;
		// Set the flags to 0 so that the QueryStatus does not try to set the text field.
		pOleText->cmdtextf = 0;
		pOleText->cwActual = 0;
		pOleText->cwBuf = stringSize;
		pOleText->rgwz[0] = 309;	// Set some random number so that we can check that it is not changed by QueryStatus.
		handler.QueryStatus(this, &oleCmd, pOleText);
		UTCHKEX(309==pOleText->rgwz[0], L"CommandHandlerBase::QueryStatus has changed the OLECMDTEXT structure without the OLECMDTEXTF_NAME flag set.");
		UTCHKEX(testValue==buffer[bufferSize-1], L"CommandHandlerBase::QueryStatus har corrupted the memory around OLECMDTEXT.");

		// Now check that the text is set to an empty string.
		pOleText->cmdtextf = OLECMDTEXTF_NAME;
		handler.QueryStatus(this, &oleCmd, pOleText);
		UTCHKEX(0==pOleText->rgwz[0], L"CommandHandlerBase::QueryStatus has not set the OLETEXT;");
		UTCHKEX(testValue==buffer[bufferSize-1], L"CommandHandlerBase::QueryStatus har corrupted the memory around OLECMDTEXT.");

		// Check that the text is set for a not empty string.
		const wchar_t szText[] = L"Test";
		handler.GetText() = szText;
		handler.QueryStatus(this, &oleCmd, pOleText);
		UTCHKEX(0 == wcscmp(szText, pOleText->rgwz), L"Wrong text set by CommandHandlerBase::QueryStatus");
		UTCHKEX(wcslen(szText)==pOleText->cwActual, L"Wrong buffer size set by CommandHandlerBase::QueryStatus");
		UTCHKEX(testValue==buffer[bufferSize-1], L"CommandHandlerBase::QueryStatus har corrupted the memory around OLECMDTEXT.");

		#define BIG_STRING_BASE L"0123456789"
		// Check the result if the command text is as big as the string in OLECMDTEXT.
		handler.GetText() = BIG_STRING_BASE;
		handler.QueryStatus(this, &oleCmd, pOleText);
		UTCHKEX(0 == wcsncmp(BIG_STRING_BASE, pOleText->rgwz, stringSize), L"Wrong text set by CommandHandlerBase::QueryStatus");
		UTCHKEX(stringSize-1==pOleText->cwActual, L"Wrong buffer size set by CommandHandlerBase::QueryStatus");
		UTCHKEX(testValue==buffer[bufferSize-1], L"CommandHandlerBase::QueryStatus har corrupted the memory around OLECMDTEXT.");

		// Check the result if the command text is bigger than the string in OLECMDTEXT.
		handler.GetText() = BIG_STRING_BASE BIG_STRING_BASE;
		handler.QueryStatus(this, &oleCmd, pOleText);
		UTCHKEX(0 == wcsncmp(BIG_STRING_BASE, pOleText->rgwz, stringSize), L"Wrong text set by CommandHandlerBase::QueryStatus");
		UTCHKEX(stringSize-1==pOleText->cwActual, L"Wrong buffer size set by CommandHandlerBase::QueryStatus");
		UTCHKEX(testValue==buffer[bufferSize-1], L"CommandHandlerBase::QueryStatus har corrupted the memory around OLECMDTEXT.");
	}
}

// HandlerTestCallbacks
HandlerTestCallbacks::HandlerTestCallbacks(const char* const szTestName) :
	VSL::UnitTestBase(szTestName)
{
	// Create a CommandId for this command handler.
	VSL::CommandId testId(guidTest1, dwTestId1);

	// Test the callbacks.
	{
		CommandHandler handler(testId, CommandHandler::QueryStatusHandler(&HandlerTestCallbacks::QueryStatus), CommandHandler::ExecHandler(&HandlerTestCallbacks::Exec));

		// The Exec callback should not be called if there is no target.
		fCallbackCalled = false;
		HRESULT VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		handler.Exec(NULL, 0, NULL, NULL);

		}VSL_STDMETHODCATCH()
		UTCHKEX(E_POINTER==VSL_GET_STDMETHOD_HRESULT(), L"E_POINTER expected from CommandHandlerBase::Exec if there is no target.");
		UTCHKEX(false==fCallbackCalled, L"CommandHandlerBase::Exec invoked the callback when not expected.");

		// Check that the callback is called.
		fCallbackCalled = false;
		handler.Exec(this, 0, NULL, NULL);
		UTCHKEX(true==fCallbackCalled, L"Callback not invoked from CommandHandlerBase::Exec.");

		// The QueryStatus callback should not be invoked if there is not target
		fCallbackCalled = false;
		OLECMD oleCmd;

		VSL_STDMETHOD_HRESULT = VSL_STDMETHOD_HRESULT_INIT;
		try{

		handler.QueryStatus(NULL, &oleCmd, NULL);
		
		}VSL_STDMETHODCATCH()
		UTCHKEX(E_POINTER==VSL_GET_STDMETHOD_HRESULT(), L"E_POINTER expected from CommandHandlerBase::QueryStatus if there is no target.");
		UTCHKEX(false==fCallbackCalled, L"CommandHandlerBase::QueryStatus invoked the callback when not expected.");

		// Check that the callback is called.
		fCallbackCalled = false;
		handler.QueryStatus(this, &oleCmd, NULL);
		UTCHKEX(true==fCallbackCalled, L"Callback not invoked from CommandHandlerBase::QUeryStatus.");
	}
}
