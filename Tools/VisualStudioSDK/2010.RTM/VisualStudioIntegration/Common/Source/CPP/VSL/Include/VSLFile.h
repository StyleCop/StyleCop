/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

// VSL includes
#include <VSLVsSite.h>

// ATL includes
#include <ATLFile.h>

namespace VSL
{

class File
{
public:
	File() :
		m_szFullPathName(),
		m_hFile()
	{
	}

	// Transfers ownership of the handle
	// Having the parameter be const allows it to work correctly with STL containers
	File(_In_ const File& file) :
		m_szFullPathName(const_cast<File&>(file).m_szFullPathName),
		m_hFile(const_cast<File&>(file).m_hFile)
	{
	}

	// Does not open the file handle
	explicit File(_In_z_ const wchar_t* szFullPathName) :
		m_szFullPathName(szFullPathName),
		m_hFile()
	{
	}

	const ATL::CStringW& GetFullPathName() const
	{
		return m_szFullPathName;
	}

	ATL::CStringW& GetFullPathName()
	{
		return m_szFullPathName;
	}

	operator const wchar_t*() const
	{
		return m_szFullPathName;
	}

	bool IsFileReadOnly()
	{
		VSL_CHECKBOOLEAN(!m_szFullPathName.IsEmpty(), E_FAIL);
		DWORD dwAttr = ::GetFileAttributesW(m_szFullPathName);
		VSL_CHECKBOOLEAN_GLE(dwAttr != 0);
		return (dwAttr & FILE_ATTRIBUTE_READONLY);
	}

	void Create(
		_In_ DWORD dwDesiredAccess,
		_In_ DWORD dwShareMode,
		_In_ DWORD dwCreationDisposition,
		_In_ DWORD dwFlagsAndAttributes = FILE_ATTRIBUTE_NORMAL,
		_In_opt_ LPSECURITY_ATTRIBUTES lpsa = NULL,
		_In_opt_ HANDLE hTemplateFile = NULL)
	{
		VSL_CHECKBOOLEAN(!m_szFullPathName.IsEmpty(), E_FAIL);

		HRESULT hr = m_hFile.Create(
			m_szFullPathName,
			dwDesiredAccess,
			dwShareMode,
			dwCreationDisposition,
			dwFlagsAndAttributes,
			lpsa,
			hTemplateFile);

		VSL_CHECKHRESULT(hr);
	}

	bool IsZeroLength()
	{
		ULONGLONG iSize;
		VSL_CHECKHRESULT(
			m_hFile.GetSize(iSize));

		return iSize == 0;
	}

	void Close()
	{
		m_hFile.Close();
	}

	operator HANDLE()
	{
		return m_hFile.m_h;
	}

	DWORD GetFileType()
	{
		DWORD dwFileType = ::GetFileType(GetHandle());
		if(FILE_TYPE_UNKNOWN == dwFileType)
		{
			DWORD dwError = ::GetLastError();
			if(dwError != NO_ERROR)
			{
				VSL_CREATE_ERROR_WIN32(dwError);
			}
		}
		return dwFileType;
	}

	bool IsOnDisk()
	{
		return FILE_TYPE_DISK == GetFileType();
	}

	HANDLE GetHandle()
	{
		VSL_CHECKBOOLEAN(m_hFile.m_h, E_FAIL);
		return m_hFile.m_h;
	}

	void Read(
		_Out_bytecap_(nBufSize) LPVOID pBuffer,
		_In_ DWORD nBufSize,
		_Out_ DWORD& nBytesRead)
	{
		VSL_CHECKHRESULT(m_hFile.Read(pBuffer, nBufSize, nBytesRead));
	}

	void Write(
		_In_bytecount_(nBufSize) LPCVOID pBuffer,
		_In_ DWORD nBufSize,
		_Out_opt_ DWORD* pnBytesWritten = NULL)
	{
		VSL_CHECKHRESULT(m_hFile.Write(pBuffer, nBufSize, pnBytesWritten));
	}

	void Seek(_In_ LONGLONG nOffset, _In_ DWORD dwFrom = FILE_CURRENT)
	{
		VSL_CHECKHRESULT(m_hFile.Seek(nOffset, dwFrom));
	}

private:
	ATL::CStringW m_szFullPathName;
	ATL::CAtlFile m_hFile;
};

template <
	class Derived_T,
	class File_T = File,
	class VsSiteCache_T = VsSiteCacheLocal>
class DocumentPersistanceBase :
	public IVsPersistDocData,
	public IVsFileChangeEvents,
	public IVsDocDataFileChangeControl,
	public IPersistFileFormat,
	public IVsFileBackup
{

VSL_DECLARE_NOT_COPYABLE(DocumentPersistanceBase)

public:

	typedef Derived_T Derived;
	typedef File_T File;
	typedef VsSiteCache_T VsSiteCache;

/***************************************************************************
 IVsFileChangeEvents methods
***************************************************************************/

	// Called to notify of file state changes
	STDMETHOD(FilesChanged)(
		DWORD cChanges, 
		LPCOLESTR rglpstrFile[], 
		_In_count_(cChanges) VSFILECHANGEFLAGS rggrfChange[])
	{
		VSL_STDMETHODTRY{

		VSL_CHECKBOOLEAN(cChanges > 0, E_INVALIDARG);
		VSL_CHECKPOINTER(rglpstrFile, E_INVALIDARG);
		VSL_CHECKPOINTER(rggrfChange, E_INVALIDARG);

		if(m_iIgnoreFileChangeLevel > 0)
		{
			// IgnoreFileChanges has been called to indicate that
			// file state changes should be ignored currently
			return S_OK;
		}

		for(DWORD i = 0; i < cChanges; ++i)
		{
			if(rglpstrFile[i] && 0 == GetFileName().CompareNoCase(rglpstrFile[i]))
			{
				Derived& rDerived = *(static_cast<Derived*>(this));

				// If the readonly file attributes has changed, then the state
				// can be updated to match the new state without prompting the 
				// user
				if(rggrfChange[i] & VSFILECHG_Attr)
				{
					BOOL fIsSysReadOnly = m_File.IsFileReadOnly();
					SetReadOnly(fIsSysReadOnly);
				}

				/*
				If the file size or time have have changed then prompt the user to see if the should be
				reloaded.
				
				The file should not be reloaded here as it is possible that there will be more than one 
				FilesChanged notification as separate notifications can be recieved in short order.  
				Additionally, it is the preferred UI style not to prompt the user, until Visual Stuidio
				is brought to the foreground.  Thus, the derived class is called to set a timer
				to cause the user to be prompted if the file should be reloaded after short delay.
				*/
				if((rggrfChange[i] & (VSFILECHG_Time | VSFILECHG_Size)) && !m_bFileChangedTimerSet)
				{
					m_bFileChangedTimerSet = true;

					// Send the message to the parent window.
					rDerived.OnFileChangedSetTimer();
				} 
			}
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// Called to notify of directoy state changes
	STDMETHOD(DirectoryChanged)(LPCOLESTR /*pszDirectory*/)
	{
		// No action required
		return S_OK;
	}

/***************************************************************************
IVsDocDataFileChangeControl methods
***************************************************************************/

	// Called to indicate that file changes should be ignored
	// Balanced calls with fIgnore set to TRUE and FALSE are expected
	STDMETHOD(IgnoreFileChanges)(BOOL fIgnore)
	{
		VSL_STDMETHODTRY{

		if(fIgnore)
		{
			++m_iIgnoreFileChangeLevel;
		}
		else 
		{
			VSL_CHECKBOOLEAN(m_iIgnoreFileChangeLevel > 0, E_UNEXPECTED);

			--m_iIgnoreFileChangeLevel;

			// If we are no longer ignoring files changes and the read only state of 
			// the file doesn't match the cached state then update accordingly to ensure 
			// the caption is update to date
			if(m_iIgnoreFileChangeLevel == 0)
			{
				bool bReadOnly = m_File.IsFileReadOnly();
				if(IsFileReadOnly() != bReadOnly)
				{
					SetReadOnly(bReadOnly);
				}
			}
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

/***************************************************************************
IPersistFileFormat methods
***************************************************************************/

	STDMETHOD(IsDirty)(_Out_ BOOL *pfIsDirty)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pfIsDirty, E_INVALIDARG);

		*pfIsDirty = IsFileDirty();

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(InitNew)(DWORD nFormatIndex)
	{
		VSL_STDMETHODTRY{

		Derived& rDerived = *(static_cast<Derived*>(this));

		VSL_CHECKBOOLEAN(rDerived.IsValidFormat(nFormatIndex), E_INVALIDARG);

		m_dwFormatIndex = nFormatIndex;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(Load)(LPCOLESTR pszFilename, DWORD /*grfMode*/, BOOL fReadOnly)
	{
		VSL_STDMETHODTRY{

		// Check that the file name is valid
		VSL_CHECKBOOLEAN(CheckFileName(pszFilename), E_INVALIDARG);

		// Set the wait cursor while we are loading the file
		CComPtr<IVsUIShell> spIVsUIShell = GetDerivedVsSiteChache().GetCachedService<IVsUIShell, SID_SVsUIShell>();
		VSL_CHECKPOINTER(spIVsUIShell.p, E_FAIL);
		VSL_CHECKHRESULT(spIVsUIShell->SetWaitCursor());

		File file(static_cast<const wchar_t*>(pszFilename));
		BOOL fIsSysReadOnly = file.IsFileReadOnly();

		// Open the file for reading
		file.Create(
			GENERIC_READ, 
			FILE_SHARE_READ | FILE_SHARE_WRITE,
			OPEN_EXISTING,
			FILE_FLAG_SEQUENTIAL_SCAN);

		VSL_CHECKBOOLEAN(file.GetFileType() == FILE_TYPE_DISK, __HRESULT_FROM_WIN32(ERROR_INVALID_NAME));

		DWORD dwFormatIndex = DEF_FORMAT_INDEX;
		HRESULT hr = S_OK;
		if(!file.IsZeroLength())
		{
			// Read in the contents, should not throw C++ exceptions
			Derived& rDerived = *(static_cast<Derived*>(this));
			// TODO - put a wrapper function around this so that ReadData can throw
			hr = rDerived.ReadData(file, FALSE, dwFormatIndex);
		}

		if(STG_E_INVALIDCODEPAGE == hr || STG_E_NOTTEXT == hr)
		{
			// These return code indicate that the file wasn't valid
			// and internal state was not modified, so return the 
			// error immediately
			return hr;
		}

		if(FAILED(hr)) // STG_S_DATALOSS like any other error
		{
			// Assume existing data has been lost, so re-initialize
			Initialize();
			return hr;
		}

		// Clear out the current file state
		ResetFileState();

		// Set appropriate flags
		m_dwFormatIndex = dwFormatIndex;
		SetDirty(false);
		SetReadOnly(fReadOnly || fIsSysReadOnly);

		// If we are not doing a reload of the same file then...
		if(GetFileName().IsEmpty() || 0 != GetFileName().Compare(pszFilename))
		{
			SetFileName(pszFilename);
			// Fire the LoadFile event
			FileLoadAdvise();
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(Save)(LPCOLESTR pszFilename, BOOL fRemember, DWORD nFormatIndex)
	{
		VSL_STDMETHODTRY{

		Derived& rDerived = *(static_cast<Derived*>(this));

		VSL_CHECKBOOLEAN(rDerived.IsValidFormat(nFormatIndex), E_INVALIDARG);

		LPCWSTR szSaveFileName = pszFilename;
		bool bDoingSave = false;

		if(NULL == szSaveFileName)
		{
			// If pszFilename is NULL, then a Save is being asked for, so the filename 
			// must be set already and the incoming value of fRemember is ignored in this case
			VSL_CHECKBOOLEAN(!GetFileName().IsEmpty(), E_INVALIDARG);

			VSL_CHECKBOOLEAN(IsFileEditable(), E_UNEXPECTED);

			szSaveFileName = m_File;
			fRemember = TRUE;
			bDoingSave = true;
		}
		else
		{
			// If pszFilename is not NULL,
			// and if fRemember is TRUE, and the file name is different then a Save As is being asked for
			// but if fRemebber is TRUE, and the file name is the same then a Save is being asked for
			// or if fRemember is FALSE, then a Save Copy As is being asked for
			// so pszFilename must be valid
			if(0 != GetFileName().CompareNoCase(szSaveFileName))
			{
				VSL_CHECKBOOLEAN(CheckFileName(pszFilename), E_INVALIDARG);
			}
			else
			{
				bDoingSave = true;
			}
		}

		if(bDoingSave)
		{
			// Suspend file change notifications on a Save, so the writing of the file during the save
			// doesn't trigger a notification.
			// For a SaveAs the previous file will be unadvised when the name changes, 
			// and SaveCopyAs doesn't affect internal state.
			SuspendFileChangeAdvise(true);
		}

		// do the actual save
		HRESULT hr = WriteToFile(szSaveFileName, nFormatIndex);

		// Resume file change notifications, before checking for an error
		if(bDoingSave)
		{
			SuspendFileChangeAdvise(false);
		}

		VSL_CHECKHRESULT(hr);

		if(fRemember)
		{
			// Save or SaveAs  
			if(!bDoingSave)
			{
				// SaveAs
				SetFileName(szSaveFileName);
			}

			SetDirty(false);
			SetReadOnly(false);
			m_dwFormatIndex = nFormatIndex;

			// Since all changes are now saved properly to disk, there's no need for a backup.
			m_bBackupObsolete = false;
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	// REVIEW - is it correct to be doing nothing here?
	STDMETHOD(SaveCompleted)(LPCOLESTR /*pszFilename*/)
	{
		return S_OK;
	}

	STDMETHOD(GetCurFile)(_Deref_out_z_ LPOLESTR* ppszFilename, _Out_ DWORD* pnFormatIndex)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppszFilename, E_INVALIDARG);
		VSL_CHECKPOINTER(pnFormatIndex, E_INVALIDARG);

		*ppszFilename = NULL;
		*pnFormatIndex = m_dwFormatIndex;

		if(!GetFileName().IsEmpty())
		{
			// +1 for null terminator, which isn't included in GetLength()
			const SIZE_T iBufferByteSize = (GetFileName().GetLength() + 1) * sizeof(**ppszFilename);
			CoTaskMemPointer pBuffer = ::CoTaskMemAlloc(iBufferByteSize);
			VSL_CHECKPOINTER(static_cast<LPVOID>(pBuffer), E_OUTOFMEMORY);

			VSL_CHECKBOOLEAN(0 == ::memcpy_s(pBuffer, iBufferByteSize, GetFileName(), iBufferByteSize), E_FAIL);
			*ppszFilename = static_cast<LPOLESTR>(pBuffer.Detach());
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(GetFormatList)(_Deref_out_z_ LPOLESTR* ppszFormatList)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(ppszFormatList, E_INVALIDARG);

		*ppszFormatList = NULL;

		Derived& rDerived = *(static_cast<Derived*>(this));

		ATL::CStringW strFormatList;
		rDerived.GetFormatListString(strFormatList);

		// +1 for null terminator, which isn't included in GetLength()
		const SIZE_T iBufferByteSize = (strFormatList.GetLength() + 1) * sizeof(OLECHAR);
		CoTaskMemPointer pBuffer = ::CoTaskMemAlloc(iBufferByteSize);
		VSL_CHECKPOINTER(static_cast<LPVOID>(pBuffer), E_OUTOFMEMORY);

		VSL_CHECKBOOLEAN(0 == ::memcpy_s(pBuffer, iBufferByteSize, strFormatList, iBufferByteSize), E_FAIL);
		*ppszFormatList = static_cast<LPOLESTR>(pBuffer.Detach());

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

/***************************************************************************
IPersist methods
***************************************************************************/

	STDMETHOD(GetClassID)(_Out_ CLSID* pClassID)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pClassID, E_INVALIDARG);

		Derived& rDerived = *(static_cast<Derived*>(this));

		*pClassID = rDerived.GetEditorTypeGuid();

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}                    

/***************************************************************************
IVsPersistDocData methods
***************************************************************************/

	STDMETHOD(GetGuidEditorType)(_Out_ CLSID* pClassID)
	{
		// Delegate to IPersist::GetClassID
		return GetClassID(pClassID);
	}                    

	STDMETHOD(IsDocDataDirty)(_Out_ BOOL* pfDirty)
	{
		// Delegate to IPersistFileFormat::IsDirty
		return IsDirty(pfDirty);
	}

	// SetUntitledDocPath is called by projects after a new document instance is created.
	// Parameter is a legacy artificat.
	STDMETHOD(SetUntitledDocPath)(LPCOLESTR /*pszDocDataPath*/)
	{
		// Delegate to IPersistFileFormat::InitNew
		return InitNew(DEF_FORMAT_INDEX);
	}

	STDMETHOD(LoadDocData)(LPCOLESTR pszMkDocument)
	{
		// Delegate to IPersistFileFormat::Load
		return Load(pszMkDocument, 0, FALSE);
	}

	STDMETHOD(SaveDocData)(VSSAVEFLAGS dwSave, _Deref_out_z_ BSTR* pbstrMkDocumentNew, _Out_ BOOL* pfSaveCanceled)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pfSaveCanceled, E_INVALIDARG);
		VSL_CHECKPOINTER(pbstrMkDocumentNew, E_INVALIDARG);

		VSL_CHECKBOOLEAN(!GetFileName().IsEmpty(), E_UNEXPECTED);

		// Initialise output parameter flag.
		*pbstrMkDocumentNew = NULL;
		*pfSaveCanceled = FALSE;

		switch(dwSave)
		{
		case VSSAVE_Save:
			{
				CComPtr<IVsQueryEditQuerySave2> spIVsQueryEditQuerySave2;
				VSL_CHECKHRESULT((
					GetDerivedVsSiteChache().QueryCachedService<
						IVsQueryEditQuerySave2, 
						SID_SVsQueryEditQuerySave>(
							&spIVsQueryEditQuerySave2)));

				VSQuerySaveResult result;
				VSL_CHECKHRESULT(spIVsQueryEditQuerySave2->QuerySaveFile(
					GetFileName(),
					0,
					NULL,
					&result));

				switch(result)
				{
				case QSR_NoSave_UserCanceled:
					*pfSaveCanceled = TRUE;
					return S_OK;
				case QSR_NoSave_Continue:
					// Do nothing
					return S_OK;
				case QSR_ForceSaveAs:
					// override
					dwSave = VSSAVE_SaveAs;
					break;
				case QSR_SaveOK:
					// Normal file save with no user dialog
					break;
				default:
					return E_FAIL;
				}
			}
			break;
		case VSSAVE_SaveAs:
			break;
		case VSSAVE_SaveCopyAs:
			break;
		default:
			return E_INVALIDARG;
		}

		CComPtr<IVsUIShell> spIVsUIShell = GetDerivedVsSiteChache().GetCachedService<
			IVsUIShell, 
			SID_SVsUIShell>();
		VSL_CHECKPOINTER(spIVsUIShell.p, E_FAIL);

		VSL_CHECKHRESULT(spIVsUIShell->SaveDocDataToFile(
			dwSave, 
			static_cast<IPersistFileFormat*>(this),
			GetFileName(),
			pbstrMkDocumentNew,
			pfSaveCanceled));

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(Close)()
	{
		// When closing, the document's IVsWindowPane::ClosePane() method is called after 
		// IVsPersistDocData::Close.  We don't clean-up here, but rather let 
		// the IVsWindowPane::ClosePane() method call OnDocumentClose
		return S_OK;
	}

	STDMETHOD(OnRegisterDocData)(VSCOOKIE /*docCookie*/, _In_ IVsHierarchy* /*pHierNew*/, VSITEMID /*itemidNew*/)
	{
		// REVIEW - return E_NOTIMPL instead
		return S_OK;
	}

	STDMETHOD(RenameDocData)( 
		VSRDTATTRIB /*grfAttribs*/,
		_In_ IVsHierarchy* /*pHierNew*/,
		VSITEMID /*itemidNew*/,
		LPCOLESTR /*pszMkDocumentNew*/)
	{
		// REVIEW - return E_NOTIMPL instead or implement it?
		return S_OK;
	}

	STDMETHOD(IsDocDataReloadable)(_Out_ BOOL* pfReloadable)
	{
		VSL_RETURN_E_INVALIDARG_IF_NULL(pfReloadable);
		
		*pfReloadable = TRUE;

		return S_OK;
	}

	STDMETHOD(ReloadDocData)(VSRELOADDOCDATA grfFlags)
	{
		VSL_STDMETHODTRY{

		// because we implement IVsDocDataFileChangeControl, then RDD_IgnoreNextFileChange
		// flag should never be specified. the caller must use 
		// IVsDocDataFileChangeControl::IgnoreFileChanges instead.
		VSL_CHECKBOOLEAN(!(grfFlags & RDD_IgnoreNextFileChange), E_INVALIDARG);

		// set our file reload flag
		m_bFileReloaded = true;

		// Call IPersistFileFormat::Load 
		VSL_CHECKHRESULT(Load(GetFileName(), 0, FALSE));

		// REVIEW - call derived if RDD_RemoveUndoStack set?

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

/***************************************************************************
IVsFileBackup methods
***************************************************************************/

	STDMETHOD(BackupFile)(LPCOLESTR pszBackupFileName)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKBOOLEAN(CheckFileName(pszBackupFileName), E_INVALIDARG);

		VSL_CHECKHRESULT(WriteToFile(pszBackupFileName));

		// Note that the backup is not obsolete (i.e. current)
		m_bBackupObsolete = false;

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	STDMETHOD(IsBackupFileObsolete)(_Out_ BOOL* pbObsolete)
	{
		VSL_STDMETHODTRY{

		VSL_CHECKPOINTER(pbObsolete, E_INVALIDARG);

		if(IsFileDirty())
		{
			// If dirty, then return current need for a backup
			*pbObsolete = m_bBackupObsolete;
		}
		else
		{
			// If not dirty, then no need for a backup
			*pbObsolete = FALSE;
		}

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

protected:

/***************************************************************************
Methods the derived class is required to call
***************************************************************************/

	DocumentPersistanceBase():
		m_File(),
		m_spIVsFileChangeEx(0),
		m_FileChangeConnectionCookie(0),
		m_iIgnoreFileChangeLevel(0),
		m_dwFormatIndex(DEF_FORMAT_INDEX),
		m_bFileChangedTimerSet(false),
		m_bFileReloaded(false),
		m_bBackupObsolete(false),
		m_bFileDirty(false),
		m_bFileReadOnly(false),
		m_bFileEditableWhenReadOnly(false)
	{
	}

	virtual ~DocumentPersistanceBase() = 0
	{
	}

	// The derived class should call this method as part of it's closing activity
	void OnDocumentClose()
	{
		if(m_spIVsFileChangeEx)
		{
			if(VSCOOKIE_NIL != m_FileChangeConnectionCookie)
			{
				Unadvise();
			}
			m_spIVsFileChangeEx.Release();
		}
	}

	// The derived class should call this method upon recieving the WM_TIMER 
	// messeage sent from OnFileChangedSetTimer
	void NotifyFileChangedTimerHandled()
	{
		m_bFileChangedTimerSet = false;
	}

/***************************************************************************
Helper methods available to the derived class
***************************************************************************/

	bool IsFileDirty()
	{
		return m_bFileDirty;
	}

	void SetFileDirty(bool bSet)
	{ 
		// Every time the document has changed in any way the previous backup is obsolete.
		m_bBackupObsolete = true;
		m_bFileDirty = bSet;
	}

	bool IsFileEditableWhenReadOnly()
	{
		return m_bFileEditableWhenReadOnly;
	}

	void SetFileEditableWhenReadOnly(bool bSet)
	{ 
		// Every time the document has changed in any way the previous backup is obsolete.
		m_bBackupObsolete = true;
		m_bFileEditableWhenReadOnly = bSet;
	}

	bool IsFileReloaded()
	{
		return m_bFileReloaded;
	}

	void SetFileReloaded(bool bFileReloaded)
	{
		m_bFileReloaded = bFileReloaded;
	}

	bool IsFileReadOnly()
	{
		return m_bFileReadOnly;
	}

	bool IsFileEditable()
	{
		return !IsFileReadOnly() || IsFileEditableWhenReadOnly();
	}

	void ResetFileState()
	{
		m_bFileDirty = false;
		m_bFileReadOnly = false;
		m_bFileEditableWhenReadOnly = false;
	}

	const CStringW& GetFileName()
	{
		return m_File.GetFullPathName();
	}

	void SetFileName(LPCWSTR szFileName)
	{
		if(VSCOOKIE_NIL != m_FileChangeConnectionCookie)
		{
			EnsureVsFileChangeEx();
			Unadvise();
		}

		if(szFileName != NULL)
		{
			EnsureVsFileChangeEx();
			VSL_CHECKHRESULT(m_spIVsFileChangeEx->AdviseFileChange(
				szFileName,
				VSFILECHG_Attr | VSFILECHG_Time | VSFILECHG_Size, 
				static_cast<IVsFileChangeEvents*>(this),
				&m_FileChangeConnectionCookie));

			VSL_CHECKBOOLEAN(m_FileChangeConnectionCookie != VSCOOKIE_NIL, E_FAIL);
		}

		m_File.GetFullPathName() = szFileName;
	}

	File& GetFile()
	{
		return m_File;
	}

/***************************************************************************
Internal helper methods
***************************************************************************/

private:

	void Initialize()
	{
		// REVIEW - 1/30/2006 - what else needs to be done to return us to a clean initial state?
		ResetFileState();
		SetFileName(NULL);
	}

	void SuspendFileChangeAdvise(bool bSuspend)
	{
		EnsureVsFileChangeEx();

		if(!bSuspend)
		{
			// Transitioning from suspended to non-suspended state - so force a
			// sync first to avoid asynchronous notifications of our own change
			VSL_CHECKHRESULT(m_spIVsFileChangeEx->SyncFile(GetFileName()));
		}

		// Suspend (true) or unsupsend (false) as indicated by caller
		VSL_CHECKHRESULT(m_spIVsFileChangeEx->IgnoreFile(NULL, GetFileName(), bSuspend));
	}

	void FileLoadAdvise()
	{
		ATL::CComPtr<IVsRunningDocumentTable> spIVsRunningDocumentTable;
		VSL_CHECKHRESULT(GetDerivedVsSiteChache().QueryService(SID_SVsRunningDocumentTable, &spIVsRunningDocumentTable));

		VSDOCCOOKIE docCookie;
		VSL_CHECKHRESULT(spIVsRunningDocumentTable->FindAndLockDocument(
			RDT_ReadLock,
			GetFileName(),
			NULL,
			NULL,
			0,
			&docCookie));

		HRESULT hr = spIVsRunningDocumentTable->NotifyDocumentChanged(docCookie, RDTA_DocDataReloaded);

		// Here we don't check for success because, even if the previous operation
		// fails, we have to unlock the document.

		VSL_CHECKHRESULT(spIVsRunningDocumentTable->UnlockDocument(RDT_ReadLock, docCookie));

		// Now check the result
		VSL_CHECKHRESULT(hr);
	}

	HRESULT WriteToFile(LPCWSTR pszFilename, DWORD dwFormatIndex = DEF_FORMAT_INDEX) throw()
	{
		VSL_STDMETHODTRY{

		File file(pszFilename);

		// Open the file for writing
		file.Create(
			GENERIC_WRITE,
			FILE_SHARE_READ,
			CREATE_ALWAYS,
			FILE_FLAG_SEQUENTIAL_SCAN);

		Derived& rDerived = *(static_cast<Derived*>(this));

		// WriteData should not modify any internal state, since WriteToFile is called to 
		// backup a file as well as to save it.
		rDerived.WriteData(file, dwFormatIndex);

		}VSL_STDMETHODCATCH()

		return VSL_GET_STDMETHOD_HRESULT();
	}

	void SetDirty(bool bDirty)
	{
		SetFileDirty(bDirty);

		Derived& rDerived = *(static_cast<Derived*>(this));
		rDerived.PostSetDirty();
	}

	void SetReadOnly(bool bReadOnly)
	{
		m_bFileReadOnly = bReadOnly;

		// When the read only status is changed, reset allowing it to be editable when read only
		SetFileEditableWhenReadOnly(false);

		Derived& rDerived = *(static_cast<Derived*>(this));
		rDerived.PostSetReadOnly();
	}

	bool CheckFileName(const wchar_t* const szFileName)
	{
		if(szFileName == NULL || *szFileName == L'\0' || ::wcslen(szFileName) >= _MAX_PATH)
		{
			return false;
		}

		return true;
	}

	// Caller needs to ensure that m_FileChangeConnectionCookie is valid
	void Unadvise()
	{
		HRESULT hr = m_spIVsFileChangeEx->UnadviseFileChange(m_FileChangeConnectionCookie);
		// This shouldn't fail, but no retail failure if it does, as there is nothing to be done about it
		VSL_ASSERT(SUCCEDDED(hr));
		(hr);
		m_FileChangeConnectionCookie = VSCOOKIE_NIL;
	}

	void EnsureVsFileChangeEx()
	{
		if(m_spIVsFileChangeEx != NULL)
		{
			return;
		}

		VSL_CHECKHRESULT(GetDerivedVsSiteChache().QueryService(SID_SVsFileChangeEx, &m_spIVsFileChangeEx));
		VSL_CHECKPOINTER(m_spIVsFileChangeEx.p, E_FAIL);
	}

	const VsSiteCache& GetDerivedVsSiteChache()
	{
		Derived& rDerived = *(static_cast<Derived*>(this));
		return rDerived.GetVsSiteCache();
	}

	File m_File;
	CComPtr<IVsFileChangeEx> m_spIVsFileChangeEx;
	VSCOOKIE m_FileChangeConnectionCookie;
	unsigned int m_iIgnoreFileChangeLevel;
	DWORD m_dwFormatIndex;
	bool m_bFileChangedTimerSet;
	bool m_bFileReloaded;
	bool m_bBackupObsolete;
	bool m_bFileDirty;
	bool m_bFileReadOnly;
	bool m_bFileEditableWhenReadOnly;

};

} // namespace VSL

#endif // VSLFILE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
