/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLCOMMANDTARGET_H_25EF07F8_138A_4CA3_9721_3DD66041241D
#define VSLCOMMANDTARGET_H_25EF07F8_138A_4CA3_9721_3DD66041241D

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>
#include <VSLErrorHandlers.h>
#include <VSLExceptionHandlers.h>
#include <VsShellInterfaces.h>
#include <limits>
#include <AtlColl.h>
#include <atlstr.h>

namespace VSL
{

// A command is identified by VS using a GUID/DWORD pair where the GUID is the command set
// and the DWORD is a unique identifier for the command inside the command set.
class CommandId
{
private:

	// No default construction or assignment
	CommandId();
	const CommandId& operator=(const CommandId& rToCopy);

public:
	CommandId(const GUID& rGuid, DWORD id) :
		m_CommandGuid(rGuid),
		m_Id(id)
	{
	}

	CommandId(const CommandId& rToCopy) :
		m_CommandGuid(rToCopy.m_CommandGuid),
		m_Id(rToCopy.m_Id)
	{
	}

	const GUID& GetGuid() const
	{
		return m_CommandGuid;
	}

	const DWORD GetId() const
	{
		return m_Id;
	}

	bool operator==(const CommandId& rCommandID) const
	{
		return (m_CommandGuid == rCommandID.m_CommandGuid) && (m_Id == rCommandID.m_Id);
	}

	bool operator!=(const CommandId& rCommandID) const
	{
		return !operator==(rCommandID);
	}

	// This operator is used by the ATL map to get a hash code for the object.
	operator ULONG_PTR() const
	{
		return m_CommandGuid.Data1 ^ (((int)m_CommandGuid.Data2 << 16) | (int)m_CommandGuid.Data3) ^ 
	         (((int)m_CommandGuid.Data4[3] << 24) | m_CommandGuid.Data4[7]) ^ m_Id;
	}

private:

	GUID m_CommandGuid;
	DWORD m_Id;
};

// This class handles a single command. It provides a default implementation for
// the QueryStatus and the Exec methods.
template<class Target_T>
class CommandHandlerBase
{

VSL_DECLARE_NOT_COPYABLE(CommandHandlerBase)

public:
	// Define the types for the functions that handle the QueryStatus and Exec methods.
	typedef void (Target_T::*QueryStatusHandler)(const typename Target_T::CommandHandler& handler, OLECMD*, OLECMDTEXT*);
	typedef void (Target_T::*ExecHandler)(typename Target_T::CommandHandler* handler, DWORD, VARIANT*, VARIANT*);

	CommandHandlerBase(const CommandId& commandId, QueryStatusHandler statusHandler = NULL, ExecHandler execHandler = NULL, DWORD dwStatus = OLECMDF_SUPPORTED | OLECMDF_ENABLED, const wchar_t* szText = NULL) :
		m_CommandId(commandId),
		m_OleCommandFlags(dwStatus),
		m_StatusHandler(DefaultStatusHandlerOnNull(statusHandler)),
		m_ExecHandler(execHandler),
		m_strText(szText)
	{
	}

	CommandHandlerBase(const GUID& rGuid, DWORD id, QueryStatusHandler statusHandler = NULL, ExecHandler execHandler = NULL, DWORD dwStatus = OLECMDF_SUPPORTED | OLECMDF_ENABLED, const wchar_t* szText = NULL) :
		m_CommandId(rGuid, id),
		m_OleCommandFlags(dwStatus),
		m_StatusHandler(DefaultStatusHandlerOnNull(statusHandler)),
		m_ExecHandler(execHandler),
		m_strText(szText)
	{
	}

	virtual ~CommandHandlerBase() {}

	// QueryStatus: this method is called when the shell needs to get the status of the commands,
	// e.g. when a menu is show.
	virtual void QueryStatus(Target_T* pTarget, OLECMD* pOleCmd, OLECMDTEXT* pOleText)
	{
		VSL_CHECKBOOLEAN(m_StatusHandler != NULL, E_POINTER);
		VSL_CHECKPOINTER_DEFAULT(pTarget);
		VSL_CHECKPOINTER_DEFAULT(pOleCmd);
		(pTarget->*m_StatusHandler)(*this, pOleCmd, pOleText);
	}

	static void QueryStatusDefault(const CommandHandlerBase<Target_T>& rSender, OLECMD* pOleCmd, OLECMDTEXT* pOleText)
	{
		pOleCmd->cmdf = rSender.GetFlags();
		// Check if the shell is asking for the text of this command.
		if((NULL != pOleText) && (0 != (pOleText->cmdtextf & OLECMDTEXTF_NAME)) && (rSender.GetText()))
		{
			ULONG charsToWrite = rSender.GetText().GetLength();
			if (charsToWrite > pOleText->cwBuf-1)
				charsToWrite = pOleText->cwBuf-1;
			::wcsncpy_s(pOleText->rgwz, pOleText->cwBuf, rSender.GetText(), charsToWrite);
			pOleText->cwActual = charsToWrite;
		}
	}

	// Exec: This method is called when the user selects a command clicking on a menu item or on a
	// toolbar button.
	virtual void Exec(Target_T* pTarget, DWORD dwFlags, VARIANT* pIn, VARIANT* pOut)
	{
		if((NULL != m_ExecHandler))
		{
			VSL_CHECKPOINTER_DEFAULT(pTarget);
			(pTarget->*m_ExecHandler)(this, dwFlags, pIn, pOut);
		}
	}

	// Get the ID of the command handled by this object.
	const CommandId& GetId() const
	{
		return m_CommandId;
	}

	// Command Text
	const CStringW& GetText() const
	{
		return m_strText;
	}

	CStringW& GetText()
	{
		return m_strText;
	}
	
	DWORD GetFlags() const
	{
		return m_OleCommandFlags;
	}

	// Command Checked
	bool GetChecked() const
	{ 
		return (0 != (m_OleCommandFlags & OLECMDF_LATCHED));
	}

	void SetChecked(bool bChecked)
	{
		SetFlag(OLECMDF_LATCHED, bChecked);
	}

	// Command Enabled
	bool GetEnabled() const
	{
		return (0 != (m_OleCommandFlags & OLECMDF_ENABLED));
	}

	void SetEnabled(bool bEnabled)
	{
		SetFlag(OLECMDF_ENABLED, bEnabled);
	}

	// Command Supported
	bool GetSupported() const
	{
		return (0 != (m_OleCommandFlags & OLECMDF_SUPPORTED));
	}

	void SetSupported(bool bSupported)
	{
		SetFlag(OLECMDF_SUPPORTED, bSupported);
	}

	// Command Visible
	bool GetVisible() const
	{
		return (0 == (m_OleCommandFlags & OLECMDF_INVISIBLE));
	}

	void SetVisible(bool bVisible)
	{
		SetFlag(OLECMDF_INVISIBLE, !bVisible);
	}

private:

	void SetFlag(DWORD flag, bool bSet)
	{
		if(bSet)
		{
			m_OleCommandFlags |= flag;
		}
		else
		{
			m_OleCommandFlags &= ~flag;
		}
	}

	QueryStatusHandler DefaultStatusHandlerOnNull(QueryStatusHandler statusHandler)
	{
		return statusHandler != NULL ? statusHandler : &Target_T::QueryStatusDefault;
	}

	CommandId m_CommandId; // The Id of this command.
	DWORD m_OleCommandFlags; // The dwFlags for the command.
	QueryStatusHandler m_StatusHandler; // The function to call for the QueryStatus.
	ExecHandler	m_ExecHandler; // The function to call for the Exec.
	CStringW m_strText;

};

template <class Derived_T>
class IOleCommandTargetImpl :
	public IOleCommandTarget
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCommandTargetImpl)

public:
	typedef CommandHandlerBase<Derived_T> CommandHandler;

protected:
	CommandHandler& GetCommand(const CommandId& rId)
	{
		CommandHandler* handler = Base_T::GetCommand(rId);
		VSL_CHECKBOOLEAN(NULL != handler, OLECMDERR_E_NOTSUPPORTED);
#pragma warning(push) // compiler doesn't get that the above line will throw if pair is NULL
#pragma warning(disable : 6011) // Dereferencing NULL pointer 'pair'
		return *handler;
#pragma warning(pop)
	}

	CommandHandler* TryToGetCommand(const CommandId& rId)
	{
		return Derived_T::GetCommand(rId);
	}

public:

	STDMETHOD(QueryStatus)(
		_In_ const GUID* pCmdGroupGuid,
		_In_ ULONG cCmds, 
		_Inout_cap_(cCmds) OLECMD pCmds[], 
		_Inout_opt_ OLECMDTEXT* pCmdText)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(pCmdGroupGuid);
		VSL_CHECKPOINTER_DEFAULT(pCmds);
		VSL_CHECKBOOLEAN(1 == cCmds, E_INVALIDARG);

		// It is expected and common that the command is not found, so in this case we want to use
		// the non throwing version of GetCommand.
		CommandHandler* pCommandHandler = TryToGetCommand(CommandId(*pCmdGroupGuid, pCmds[0].cmdID));
		if (NULL == pCommandHandler)
		{
			return OLECMDERR_E_NOTSUPPORTED;
		}

		pCommandHandler->QueryStatus(static_cast<Derived_T*>(this), pCmds, pCmdText);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(Exec)(
		_In_ const GUID* pCmdGroupGuid,
		_In_ DWORD nCmdID,
		_In_ DWORD nCmdexecopt, 
		_In_opt_ VARIANT* pIn,
		_Inout_opt_ VARIANT* pOut)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER_DEFAULT(pCmdGroupGuid);

		// It is expected and common that the command is not found, so in this case we want to use
		// the non throwing version of GetCommand.
		CommandHandler* pCommandHandler = TryToGetCommand(CommandId(*pCmdGroupGuid, nCmdID));
		if (NULL == pCommandHandler)
		{
			return OLECMDERR_E_NOTSUPPORTED;
		}

		pCommandHandler->Exec(static_cast<Derived_T*>(this), nCmdexecopt, pIn, pOut);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	void QueryStatusDefault(const CommandHandler& rSender, OLECMD* pOleCmd, OLECMDTEXT* pOleText)
	{
		CommandHandler::QueryStatusDefault(rSender, pOleCmd, pOleText);
	}
};

#define VSL_BEGIN_COMMAND_MAP() \
	static CommandHandler* GetCommand(const VSL::CommandId& rId) \
	{ \
		/* Default, unfortunatley ATL doesn't supply a const for it. */ \
		UINT iNumberOfBins = 17; \
		__if_exists(CAtlMapNumberOfBins) \
		{ \
			iNumberOfBins = CAtlMapNumberOfBins; \
		} \
		\
		typedef CAtlMap<const VSL::CommandId, CommandHandler*> CommandMap; \
		\
		static CommandMap commands; \
		static bool bInitialized = false; \
		if(!bInitialized) \
		{ \
			commands.InitHashTable(iNumberOfBins, false);

#define VSL_COMMAND_MAP_ENTRY(guid, id, qsHandler, execHandler) \
			static CommandHandler guid##id##CommandHandler(guid, id, static_cast<CommandHandler::QueryStatusHandler>(qsHandler), static_cast<CommandHandler::ExecHandler>(execHandler)); \
			commands[guid##id##CommandHandler.GetId()] = &guid##id##CommandHandler;

#define VSL_COMMAND_MAP_ENTRY_WITH_FLAGS(guid, id, qsHandler, execHandler, dwFlags) \
			static CommandHandler guid##id##CommandHandler(guid, id, static_cast<CommandHandler::QueryStatusHandler>(qsHandler), static_cast<CommandHandler::ExecHandler>(execHandler), dwFlags); \
			commands[guid##id##CommandHandler.GetId()] = &guid##id##CommandHandler;

#define VSL_COMMAND_MAP_CLASS_ENTRY(type, parameters) \
			{ \
				static type handler parameters; \
				commands[handler.GetId()] = &handler; \
			}

#define VSL_END_VSCOMMAND_MAP() \
			bInitialized = true; \
		}; \
		\
		CommandMap::CPair* pair = commands.Lookup(rId); \
		if(NULL == pair) \
		{ \
			return NULL; \
		} \
		return pair->m_value; \
	}

} // namespace VSL

#endif // VSLCOMMANDTARGET_H_25EF07F8_138A_4CA3_9721_3DD66041241D
