/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTBUFFER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTBUFFER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsTextBufferNotImpl :
	public IVsTextBuffer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferNotImpl)

public:

	typedef IVsTextBuffer Interface;

	STDMETHOD(LockBuffer)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockBuffer)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeContent)(
		/*[in]*/ const WCHAR* /*pszText*/,
		/*[in]*/ long /*iLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStateFlags)(
		/*[out]*/ DWORD* /*pdwReadOnlyFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStateFlags)(
		/*[in]*/ DWORD /*dwReadOnlyFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPositionOfLine)(
		/*[in]*/ long /*iLine*/,
		/*[out]*/ long* /*piPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPositionOfLineIndex)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[out]*/ long* /*piPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineIndexOfPosition)(
		/*[in]*/ long /*iPosition*/,
		/*[out]*/ long* /*piLine*/,
		/*[out]*/ CharIndex* /*piColumn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLengthOfLine)(
		/*[in]*/ long /*iLine*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLineCount)(
		/*[out]*/ long* /*piLineCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageServiceID)(
		/*[out]*/ GUID* /*pguidLangService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLanguageServiceID)(
		/*[in]*/ REFGUID /*guidLangService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUndoManager)(
		/*[out]*/ IOleUndoManager** /*ppUndoManager*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved1)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved2)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved3)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved4)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reload)(
		/*[in]*/ BOOL /*fUndoable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockBufferEx)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockBufferEx)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLastLineIndex)(
		/*[out]*/ long* /*piLine*/,
		/*[out]*/ long* /*piIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved5)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved6)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved7)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved8)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved9)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reserved10)()VSL_STDMETHOD_NOTIMPL
};

class IVsTextBufferMockImpl :
	public IVsTextBuffer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextBufferMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextBufferMockImpl)

	typedef IVsTextBuffer Interface;
	struct LockBufferValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(LockBuffer)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(LockBuffer)

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockBufferValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(UnlockBuffer)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(UnlockBuffer)

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeContentValidValues
	{
		/*[in]*/ WCHAR* pszText;
		/*[in]*/ long iLength;
		HRESULT retValue;
	};

	STDMETHOD(InitializeContent)(
		/*[in]*/ const WCHAR* pszText,
		/*[in]*/ long iLength)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeContent)

		VSL_CHECK_VALIDVALUE_STRINGW(pszText);

		VSL_CHECK_VALIDVALUE(iLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStateFlagsValidValues
	{
		/*[out]*/ DWORD* pdwReadOnlyFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetStateFlags)(
		/*[out]*/ DWORD* pdwReadOnlyFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetStateFlags)

		VSL_SET_VALIDVALUE(pdwReadOnlyFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStateFlagsValidValues
	{
		/*[in]*/ DWORD dwReadOnlyFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetStateFlags)(
		/*[in]*/ DWORD dwReadOnlyFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetStateFlags)

		VSL_CHECK_VALIDVALUE(dwReadOnlyFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPositionOfLineValidValues
	{
		/*[in]*/ long iLine;
		/*[out]*/ long* piPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetPositionOfLine)(
		/*[in]*/ long iLine,
		/*[out]*/ long* piPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetPositionOfLine)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(piPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPositionOfLineIndexValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[out]*/ long* piPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetPositionOfLineIndex)(
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[out]*/ long* piPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetPositionOfLineIndex)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(piPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineIndexOfPositionValidValues
	{
		/*[in]*/ long iPosition;
		/*[out]*/ long* piLine;
		/*[out]*/ CharIndex* piColumn;
		HRESULT retValue;
	};

	STDMETHOD(GetLineIndexOfPosition)(
		/*[in]*/ long iPosition,
		/*[out]*/ long* piLine,
		/*[out]*/ CharIndex* piColumn)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineIndexOfPosition)

		VSL_CHECK_VALIDVALUE(iPosition);

		VSL_SET_VALIDVALUE(piLine);

		VSL_SET_VALIDVALUE(piColumn);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLengthOfLineValidValues
	{
		/*[in]*/ long iLine;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetLengthOfLine)(
		/*[in]*/ long iLine,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetLengthOfLine)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLineCountValidValues
	{
		/*[out]*/ long* piLineCount;
		HRESULT retValue;
	};

	STDMETHOD(GetLineCount)(
		/*[out]*/ long* piLineCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetLineCount)

		VSL_SET_VALIDVALUE(piLineCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLanguageServiceIDValidValues
	{
		/*[out]*/ GUID* pguidLangService;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageServiceID)(
		/*[out]*/ GUID* pguidLangService)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageServiceID)

		VSL_SET_VALIDVALUE(pguidLangService);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLanguageServiceIDValidValues
	{
		/*[in]*/ REFGUID guidLangService;
		HRESULT retValue;
	};

	STDMETHOD(SetLanguageServiceID)(
		/*[in]*/ REFGUID guidLangService)
	{
		VSL_DEFINE_MOCK_METHOD(SetLanguageServiceID)

		VSL_CHECK_VALIDVALUE(guidLangService);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUndoManagerValidValues
	{
		/*[out]*/ IOleUndoManager** ppUndoManager;
		HRESULT retValue;
	};

	STDMETHOD(GetUndoManager)(
		/*[out]*/ IOleUndoManager** ppUndoManager)
	{
		VSL_DEFINE_MOCK_METHOD(GetUndoManager)

		VSL_SET_VALIDVALUE_INTERFACE(ppUndoManager);

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved1ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved1)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved1)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved2ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved2)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved2)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved3ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved3)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved3)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved4ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved4)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved4)

		VSL_RETURN_VALIDVALUES();
	}
	struct ReloadValidValues
	{
		/*[in]*/ BOOL fUndoable;
		HRESULT retValue;
	};

	STDMETHOD(Reload)(
		/*[in]*/ BOOL fUndoable)
	{
		VSL_DEFINE_MOCK_METHOD(Reload)

		VSL_CHECK_VALIDVALUE(fUndoable);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockBufferExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(LockBufferEx)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(LockBufferEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockBufferExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UnlockBufferEx)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UnlockBufferEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLastLineIndexValidValues
	{
		/*[out]*/ long* piLine;
		/*[out]*/ long* piIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetLastLineIndex)(
		/*[out]*/ long* piLine,
		/*[out]*/ long* piIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetLastLineIndex)

		VSL_SET_VALIDVALUE(piLine);

		VSL_SET_VALIDVALUE(piIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved5ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved5)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved5)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved6ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved6)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved6)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved7ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved7)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved7)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved8ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved8)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved8)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved9ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved9)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved9)

		VSL_RETURN_VALIDVALUES();
	}
	struct Reserved10ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reserved10)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reserved10)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTBUFFER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
