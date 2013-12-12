/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSLCONTROLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSLCONTROLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include <VSL.h>
#include <VSLWindows.h>
#include <mscomctl.h>

namespace VSL
{

// FUTURE - support LVS_OWNERDATA

template<
	bool AllowLabelEditing_T = true,
	bool AllowMultiselection_T = true,
	bool AlwaysShowSelection_T = true,
	bool Sort_T = true,
	bool SortAsceneding_T = true,
	bool HasColumnHeader_T = true,
	bool ColumnHeaderDoesNotActAsButton_T = true>
class ReportViewTraits
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(ReportViewTraits)

public:
	enum {
		ReportView
	};

	static const bool AllowMultiselection = AllowMultiselection_T;

	static unsigned short GetStyle()
	{
		unsigned short style = LVS_REPORT;
		style |= AllowLabelEditing_T ? LVS_EDITLABELS : 0;
		style |= AllowMultiselection_T ? 0 : LVS_SINGLESEL;
		style |= AlwaysShowSelection_T ? LVS_SHOWSELALWAYS : 0;
		style |= Sort_T ? (SortAsceneding_T ? LVS_SORTASCENDING : LVS_SORTDESCENDING) : 0;
		style |= HasColumnHeader_T ? 0 : LVS_NOCOLUMNHEADER;
		style |= ColumnHeaderDoesNotActAsButton_T ? LVS_NOSORTHEADER : 0;
		return style;
	}
};

template <class Traits_T = ReportViewTraits<>, class WindowBase_T = Window<> >
class ListViewWin32Control :
	public WindowBase_T
{

VSL_DECLARE_NOT_COPYABLE(ListViewWin32Control)

public:

	class SubWindow
	{
	protected:
		SubWindow(const WindowBase_T& listView, unsigned int iIndex = 0):
			m_iIndex(iIndex),
			m_rListView(listView)
		{
		}

		template<class LPARAM_T>
		LRESULT SendMessage(UINT uMsg, LPARAM_T lParam)
		{
			// C-style cast used here as it can function as both static_cast and reinterpret_cast
			return m_rListView.SendMessage(uMsg, m_iIndex, (LPARAM)lParam);
		}

		unsigned int m_iIndex;
		const WindowBase_T& m_rListView;
	};

__if_exists(Traits_T::ReportView)
{
	class Column :
		protected SubWindow
	{
	private:
		Column();
	public:
		Column(const WindowBase_T& listView, unsigned int iIndex = 0):
			SubWindow(listView, iIndex)
		{
		}

		WORD GetWidth()
		{
			LRESULT lRes = SendMessage(LVM_GETCOLUMNWIDTH, 0);
#if 0 // TODO - enable after unit testing can be accomplished with this check in place
			VSL_CHECKBOOLEAN(lRes >= 0, E_FAIL);
#endif
			return static_cast<WORD>(lRes);
		}

		void SetWidth(WORD width)
		{
			LRESULT lRes = SendMessage(LVM_SETCOLUMNWIDTH, MAKELPARAM(width, 0));
#if 0 // TODO - enable after unit testing can be accomplished with this check in place
			VSL_CHECKBOOLEAN(lRes == TRUE, E_FAIL);
#else
			(lRes);
#endif
		}
	};
}

	class Item :
		protected SubWindow
	{
	private:
		Item();
	public:

		Item(const WindowBase_T& listView, unsigned int iIndex = 0):
			SubWindow(listView, iIndex)
		{
		}

		Item(const WindowBase_T& listView, const LVFINDINFO& rFindInfo, int iStartIndex = -1):
			SubWindow(listView)
		{
			LRESULT lRes = m_rListView.SendMessage(LVM_FINDITEM, iStartIndex, &rFindInfo);
			VSL_CHECKBOOLEAN(lRes != -1, E_FAIL);
			m_iIndex  = static_cast<unsigned int>(lRes);
		}

		unsigned int GetIndex()
		{
			return m_iIndex;
		}

		bool IsSelected()
		{
			LRESULT lRes = SendMessage(LVM_GETITEMSTATE, LVIS_SELECTED);
			return lRes & LVIS_SELECTED;
		}

		void Select()
		{
			LVITEM item	=
			{
				LVIF_STATE,
				m_iIndex,
				0,
				LVIS_SELECTED,
				0,
				0,
				0,
				0,
				0
			};

			if(!Traits_T::AllowMultiselection)
			{
				// Since this is a single selection list, we want to set the item to be both
				// selected and focused.
				item.state |= LVIS_FOCUSED;
			}

			item.stateMask = item.state;

			LRESULT lRes = SendMessage(LVM_SETITEMSTATE, &item);
#if 0 // TODO - enable after unit testing can be accomplished with this check in place
			VSL_CHECKBOOLEAN(lRes == TRUE, E_FAIL);
#else
			(lRes);
#endif
		}

		void GetText(CStringW& rstrText)
		{
			LVITEM item	=
			{
				LVIF_TEXT,
				m_iIndex,
				0,
				0,
				0,
				rstrText.GetBuffer(),
				// add one for null terminator, as list view will null terminate
				rstrText.GetAllocLength() + 1,
				0,
				0
			};

			LRESULT lRes = SendMessage(LVM_GETITEMTEXT, &item);
			VSL_CHECKBOOLEAN(lRes >= 0, E_FAIL);

			// Now update the CString so that it know how many characters it has currently
			// The ugliness below is because CStringW doesn't expose a proper way to do this
			(reinterpret_cast<CStringData*>(const_cast<wchar_t*>(rstrText.GetString()))-1)->nDataLength = static_cast<int>(lRes);
		}

		unsigned int operator++()
		{
			return ++m_iIndex;
		}
	};

	ListViewWin32Control():
		WindowBase_T()
	{
	}

	// The compiler generated destructor is fine

	void Create(HWND hwndParent, unsigned short iControlID, _U_RECT rect = NULL)
	{
		WindowBase_T::Create(
			WC_LISTVIEW,
			hwndParent,
			rect,
			NULL, 
			WS_CHILD | Traits_T::GetStyle(),
			0,
			reinterpret_cast<HMENU>(iControlID));
	}

__if_exists(Traits_T::ReportView)
{
	template <class StdContainer_T>
	void SetColumns(const StdContainer_T& columns)
	{
		StdContainer_T::const_iterator column = columns.begin();
		for(int i = 0; column < columns.end(); ++column, ++i)
		{
			LRESULT lRes = SendMessage(LVM_INSERTCOLUMN, i, static_cast<LVCOLUMN*>(*column));
			VSL_CHECKBOOLEAN(lRes == i, E_FAIL);
		}
	}
}

	template <class StdContainer_T>
	void SetItems(const StdContainer_T& items)
	{
		//Clear the items first
		ClearItems();

		for(StdContainer_T::const_iterator item = items.begin(); item < items.end(); ++item)
		{
			LRESULT lRes = SendMessage(LVM_INSERTITEM, 0, static_cast<LVITEM*>(*item));
#if 0 // TODO - enable after unit testing can be accomplished with this check in place
			VSL_CHECKBOOLEAN(lRes == (*item)->iItem, E_FAIL);
#endif
			(lRes);
		}
	}

	unsigned int GetItemCount()
	{
		LRESULT lRes = SendMessage(LVM_GETITEMCOUNT, 0, 0);
		VSL_CHECKBOOLEAN(lRes >= 0, E_FAIL);
		return static_cast<unsigned int>(lRes);
	}

private:

	// FUTURE - this could be made public
	void ClearItems()
	{
		LRESULT lRes = SendMessage(LVM_DELETEALLITEMS, 0, 0);
#if 0 // TODO - enable after unit testing can be accomplished with this check in place
		VSL_CHECKBOOLEAN(lRes == TRUE, E_FAIL);
#else
		(lRes);
#endif
	}
};

#ifdef _RICHEDIT_

class RichEditAsWindowTraits
{

VSL_DECLARE_NONINSTANTIABLE_CLASS(RichEditAsWindowTraits)

public:
	static long GetStyle()
	{
		return WS_CLIPSIBLINGS | WS_VISIBLE | WS_VSCROLL | WS_HSCROLL | ES_MULTILINE | ES_AUTOVSCROLL | ES_AUTOHSCROLL | ES_WANTRETURN | ES_NOHIDESEL;
	}

	static LPARAM GetEvents()
	{
		return ENM_SELCHANGE | ENM_CHANGE | ENM_MOUSEEVENTS | EN_DROPFILES | ENM_KEYEVENTS;
	}
};

template <class Traits_T = RichEditAsWindowTraits, class WindowBase_T = Window<> >
class RichEditWin32Control :
	public WindowBase_T
{

VSL_DECLARE_NOT_COPYABLE(RichEditWin32Control)

public:

	typedef WindowBase_T Window;
	typedef RichEditWin32Control This;

	RichEditWin32Control():
		WindowBase_T()
	{
	}

	// The compiler generated destructor is fine

	void Create(_In_ HWND hwndParent, unsigned short iControlID, _U_RECT rect = NULL)
	{
		// Need to load riched20.dll before trying to create RICHEDIT_CLASS
		static Library richEdit20(L"RichEd20.dll");

		WindowBase_T::Create(
			RICHEDIT_CLASS,
			hwndParent,
			rect,
			NULL, 
			WS_CHILD | Traits_T::GetStyle(),
			0,
			reinterpret_cast<HMENU>(iControlID));

		SendMessage(EM_SETEVENTMASK, 0, Traits_T::GetEvents());

		CComPtr<IUnknown> spIUnknown;
	    SendMessage(EM_GETOLEINTERFACE, 0, &spIUnknown);
		VSL_CHECKPOINTER(spIUnknown.p, E_FAIL);
		VSL_CHECKHRESULT(spIUnknown->QueryInterface(IID_ITextDocument, reinterpret_cast<void**>(&m_spITextDocument)));
		VSL_CHECKPOINTER(m_spITextDocument.p, E_FAIL);
	}

	void Destroy()
	{
		m_spITextDocument.Release();
	}

	// Caller is responsible for AddRef and Release as appropriate
	ITextDocument* GetITextDocument()
	{
		return m_spITextDocument;
	}

	unsigned int GetLineFromIndex(unsigned int iIndex)
	{
		int result = static_cast<int>(SendMessage(EM_EXLINEFROMCHAR, 0, iIndex));
		VSL_CHECKBOOLEAN(result >= 0, E_FAIL);
		return static_cast<unsigned int>(result);
	}

	unsigned int GetCharacterPositionFromIndex(unsigned int iIndex)
	{
		// First get the index of the current line
		const WPARAM CurrentLine = static_cast<WPARAM>(-1);
		int result = static_cast<int>(SendMessage(EM_LINEINDEX, CurrentLine, 0));
		VSL_CHECKBOOLEAN(result >= 0, E_FAIL);
		// Then subtract the index of the current line from the current index to get the character position
		return iIndex - static_cast<unsigned int>(result);
	}

	int GetIndexFromLineAndCharacter(unsigned int iLine, unsigned int iCharacter)
	{
		// To determine the index given it's line and column, we need to sum
		// up all the characters on the lines preceding iLine, then add on iCharacter
		int iIndex = 0;
		int iSumOfPreviousLineLength = 0;
		for(unsigned int i = 0; i < iLine; ++i)
		{
			// EM_LINELENGTH requires the index of a character in a line whose
			// length is to be retrieved, so pass the index of the first character in the line
			iIndex += static_cast<int>(SendMessage(EM_LINELENGTH, iSumOfPreviousLineLength, 0));
			iIndex += 1; // Add one for the line ending
			iSumOfPreviousLineLength = iIndex;
		}

		// Ensure that the given character position is valid on the given line
		// iLineLength doesn't include the line ending
		unsigned int iLineLength = static_cast<int>(SendMessage(EM_LINELENGTH, iSumOfPreviousLineLength , 0));

        if( iCharacter < 0
			|| iCharacter > iLineLength)
		{
			return -1;
		}

		iIndex += iCharacter;

		return iIndex;
	}

	unsigned int GetLineLength(unsigned int iLine)
	{
		// Convert the line number into an index equivalent
		int iIndex = GetIndexFromLineAndCharacter(iLine, 0);
		// Now use that index to get the actual line length
		return static_cast<unsigned int>(SendMessage(EM_LINELENGTH, iIndex, 0));
	}

	unsigned int GetLineCount()
	{
		return static_cast<unsigned int>(SendMessage(EM_GETLINECOUNT, 0, 0));
	}

	// Returns the string for a line, including the line ending.
	unsigned int GetLineText(unsigned int iLine, Pointer<StdArrayPointerTraits<WCHAR> >& rpText)
	{
		// Get the line length inorder to create a string array that is big enough to hold the entire line
		long iLength = GetLineLength(iLine);
		iLength += 2; // Save one space for EOL and one space for NULL

		rpText = new WCHAR[iLength];
		WCHAR* szText = rpText;
		// EM_GETLINE expects the first word to be set to the buffer size
		reinterpret_cast<WORD *>(szText)[0] = static_cast<WORD>(iLength);
		int iCharactersCopied = static_cast<int>(SendMessage(EM_GETLINE, iLine, szText));

		if( iCharactersCopied > 0 &&
			iCharactersCopied == (iLength - 1))  // -1 for the line ending
		{
			szText[iLength-1] = L'\0';
		}

		return iCharactersCopied;
	}

	void SetSelection(int iStartIndex, int iEndIndex)
	{
		SendMessage(EM_SETSEL, iStartIndex, iEndIndex);
	}

	void SetReadOnly(bool bReadOnly)
	{
		SendMessage(EM_SETREADONLY, bReadOnly, 0);
	}

	void Undo()
	{
		SendMessage(EM_UNDO, 0, 0);
	}

	void SetModified(bool bModified)
	{
		SendMessage(EM_SETMODIFY, bModified, 0);
	}

	void SetCharacterFormat(const CHARFORMATW& rCharacterFormat)
	{
	    SendMessage(EM_SETCHARFORMAT, SCF_SELECTION, &rCharacterFormat);
	}

	class SuspendDrawAndNotifications
	{

	VSL_DECLARE_NOT_COPYABLE(SuspendDrawAndNotifications)

	public:

		SuspendDrawAndNotifications(This& rThis):
			m_rThis(rThis)
		{
			// Turn off drawing
			m_rThis.SendMessage(WM_SETREDRAW, FALSE, 0);

			// Turn notifications notifications off
			m_dwMaskToRestore = static_cast<DWORD>(m_rThis.SendMessage(EM_SETEVENTMASK, 0, ENM_NONE));
		}

		~SuspendDrawAndNotifications()
		{
			// Turn notifications back on
			m_rThis.SendMessage(EM_SETEVENTMASK, 0, m_dwMaskToRestore);

			// Turn on drawing
			m_rThis.SendMessage(WM_SETREDRAW, TRUE, 0);
		}
	private:
		This& m_rThis;
		DWORD m_dwMaskToRestore;
	};

private:

	CComPtr<ITextDocument> m_spITextDocument;
};

#endif // _RICHEDIT_

// TODO - 6/14/2006 - move this elsewhere
class IconResourceTraits
{
public:
	typedef std::pair<HICON, bool> ResourceType;
	typedef HICON CastType;
	typedef IconResourceTraits Allocator;
	typedef IconResourceTraits Values;
	typedef IconResourceTraits Cloner;
	static std::pair<HICON, bool> GetNullValue()
	{
		return std::pair<HICON, bool>(static_cast<HICON>(NULL), true);
	}
	static void Free(_In_ std::pair<HICON, bool>& pair)
	{
		// See DestroyIcon documentation to determine an HICON should be destroyed
		if(pair.first != NULL && pair.second)
		{
			::DestroyIcon(pair.first);
		}
	}
	static HICON CastToResource(_In_ const std::pair<HICON, bool>& pair)
	{
		return pair.first;
	}
};

// TODO - 6/14/2006 - move this elsewhere
class Icon
{
public:

	Icon(_In_ WORD iResourceID):
		m_hIcon(Resource<IconResourceTraits>::ResourceType(reinterpret_cast<HICON>(VSL_CHECKHANDLE_GLE(::LoadIcon(_AtlBaseModule.GetResourceInstance(), MAKEINTRESOURCE(iResourceID)))), false))
	{
	}

	operator HICON()
	{
		return m_hIcon;
	}

private:
	Resource<IconResourceTraits> m_hIcon;
};

class ImageListResourceTraits
{
public:
	typedef HIMAGELIST ResourceType;
	typedef HIMAGELIST CastType;
	typedef ImageListResourceTraits Allocator;
	typedef ImageListResourceTraits Values;
	typedef ImageListResourceTraits Cloner;
	static HIMAGELIST GetNullValue()
	{
		return NULL;
	}
	static void Free(_In_ HIMAGELIST hImageList)
	{
		BOOL b = ::ImageList_Destroy(hImageList);
		(b);
		VSL_ASSERTEX(b, L"Failed to destory HIMAGELIST");
	}
	static HIMAGELIST CastToResource(_In_ HIMAGELIST hImageList)
	{
		return hImageList;
	}
};

class ImageListWin32Control
{
private:

VSL_DECLARE_NOT_COPYABLE(ImageListWin32Control)

public:

	explicit ImageListWin32Control(_In_ int iSize = 1, _In_ int iWidth = 32, _In_ int iHeight = 32, _In_ UINT iFlags = ILC_COLOR4|ILC_MASK):
		m_hImageList(VSL_CHECKPOINTER(::ImageList_Create(iWidth, iHeight, iFlags, 0, iSize), E_FAIL))
	{
	}

	~ImageListWin32Control()
	{
	}

	int AddIcon(_In_ HICON hIcon)
	{
		int iIconIndex = ::ImageList_AddIcon(m_hImageList, hIcon);
		VSL_CHECKBOOLEAN(iIconIndex != -1, E_FAIL);
		return iIconIndex;
	}

	operator HIMAGELIST()
	{
		return m_hImageList;
	}

private:
	Resource<ImageListResourceTraits> m_hImageList;
};

class SingleIconImageListWin32Control :
	public ImageListWin32Control
{
public:
	SingleIconImageListWin32Control(WORD iResourceID)
	{
		VSL_CHECKBOOLEAN(0 == AddIcon(Icon(iResourceID)), E_FAIL);
	}
};

template <class Derived_T>
class StaticallySizedIconImageListWin32Control :
	public ImageListWin32Control
{
public:
	StaticallySizedIconImageListWin32Control(_In_ int iWidth = 32, _In_ int iHeight = 32, _In_ UINT iFlags = ILC_COLOR4|ILC_MASK):
		ImageListWin32Control(Derived_T::CountOfImages, iWidth, iHeight, iFlags)
	{
		C_ASSERT(Derived_T::CountOfImages > 0);
		for(int i = 0; i < Derived_T::CountOfImages; ++i)
		{
			VSL_CHECKBOOLEAN(i == AddIcon(Icon(Derived_T::m_sResourceIDs[i])), E_FAIL);
		}
	}
};

template <class Control_T, class WindowBase_T = ATL::CWindowImplBaseT<> >
class Win32ControlContainer :
	public WindowBase_T
{

VSL_DECLARE_NOT_COPYABLE(Win32ControlContainer)

public:

	typedef Control_T Control;

	static const unsigned short iContainedControlID = 1;

	Win32ControlContainer():
		WindowBase_T(),
		m_Control()
	{
	}

	void Create(_In_ HWND hWndParent, _U_RECT rect)
	{
		static CWndClassInfo classInfo =
		{
			{ sizeof(WNDCLASSEX), 0, StartWindowProc,
			  0, 0, 0, 0, 0, (HBRUSH)(COLOR_WINDOW + 1), 0, _T("Win32ControlContainer"), 0 },
			NULL, NULL, NULL, TRUE, 0, _T("")
		};

		ATOM atom = classInfo.Register(&m_pfnSuperWindowProc);

		HWND hWnd = WindowBase_T::Create(hWndParent, rect, NULL,
			GetWndStyle(0), GetWndExStyle(0), 0U, atom, NULL);
		VSL_CHECKBOOLEAN(hWnd == m_hWnd, E_UNEXPECTED);

		m_Control.Create(m_hWnd, iContainedControlID, rect);
	}

VSL_BEGIN_MSG_MAP(Win32ControlContainer)
	MESSAGE_HANDLER(WM_SIZE, OnSize)
	MESSAGE_HANDLER(WM_SETFOCUS, OnSetFocus)
	REFLECT_NOTIFICATIONS()
VSL_END_MSG_MAP()

	LRESULT OnSize(UINT /*uMsg*/, _In_ WPARAM /*wParam*/, _In_ LPARAM lParam, BOOL& /*bHandled*/)
	{
		if(m_Control.GetHWND() == NULL)
		{
			return 1; // return other then 0 to indicate not processed
		}

		BOOL bRet = m_Control.MoveWindow(0, 0, LOWORD(lParam), HIWORD(lParam), TRUE);
		if(bRet != TRUE)
		{
			VSL_TRACE("Win32ControlContainer::OnSize - m_Control.MoveWindow failed");
		}
		return 0;
	}

	LRESULT OnSetFocus(UINT /*uMsg*/, _In_ WPARAM /*wParam*/, _In_ LPARAM /*lParam*/, BOOL& /*bHandled*/)
	{
		if(m_Control.GetHWND() == NULL)
		{
			return 1; // return other then 0 to indicate not processed
		}

		HWND hWnd = m_Control.SetFocus();
		if(hWnd == NULL)
		{
			VSL_TRACE("Win32ControlContainer::OnSize - m_Control.SetFocus failed");
		}
		return 0;
	}

protected:

	Control_T& GetControl()
	{
		return m_Control;
	}

	HWND GetHWND()
	{
		return m_hWnd;
	}

	void Destroy()
	{
		__if_exists(Control::Destroy)
		{
			m_Control.Destroy();
		}
		// This will cause the control to be destory as well,
		// so the control shouldn't call DestroyWindow itself
		DestroyWindow();
	}

private:

	Control_T m_Control;
};

} // namespace VSL

#endif // VSLCONTROLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
