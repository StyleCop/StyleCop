/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILECHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILECHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsFileChangeNotImpl :
	public IVsFileChange
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileChangeNotImpl)

public:

	typedef IVsFileChange Interface;

	STDMETHOD(AdviseFileChangeEvents)(
		/*[in]*/ IVsFileChangeEvents* /*pFCE*/,
		/*[out]*/ VSCOOKIE* /*pdwAdvise*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseFileChangeEvents)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddFile)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSFILECHANGEFLAGS /*grfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveFile)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddDirectory)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/,
		/*[in]*/ LPCOLESTR /*pszPath*/,
		/*[in]*/ BOOL /*fWatchSubDir*/,
		/*[in]*/ VSFILECHANGEFLAGS /*grfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveDirectory)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SyncFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IgnoreFile)(
		/*[in]*/ VSCOOKIE /*dwAdvise*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ BOOL /*fIgnore*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFileChangeMockImpl :
	public IVsFileChange,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileChangeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFileChangeMockImpl)

	typedef IVsFileChange Interface;
	struct AdviseFileChangeEventsValidValues
	{
		/*[in]*/ IVsFileChangeEvents* pFCE;
		/*[out]*/ VSCOOKIE* pdwAdvise;
		HRESULT retValue;
	};

	STDMETHOD(AdviseFileChangeEvents)(
		/*[in]*/ IVsFileChangeEvents* pFCE,
		/*[out]*/ VSCOOKIE* pdwAdvise)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseFileChangeEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFCE);

		VSL_SET_VALIDVALUE(pdwAdvise);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseFileChangeEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseFileChangeEvents)(
		/*[in]*/ VSCOOKIE dwAdvise)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseFileChangeEvents)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddFileValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSFILECHANGEFLAGS grfFilter;
		HRESULT retValue;
	};

	STDMETHOD(AddFile)(
		/*[in]*/ VSCOOKIE dwAdvise,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSFILECHANGEFLAGS grfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(AddFile)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(grfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveFileValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(RemoveFile)(
		/*[in]*/ VSCOOKIE dwAdvise,
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveFile)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddDirectoryValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		/*[in]*/ LPCOLESTR pszPath;
		/*[in]*/ BOOL fWatchSubDir;
		/*[in]*/ VSFILECHANGEFLAGS grfFilter;
		HRESULT retValue;
	};

	STDMETHOD(AddDirectory)(
		/*[in]*/ VSCOOKIE dwAdvise,
		/*[in]*/ LPCOLESTR pszPath,
		/*[in]*/ BOOL fWatchSubDir,
		/*[in]*/ VSFILECHANGEFLAGS grfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(AddDirectory)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPath);

		VSL_CHECK_VALIDVALUE(fWatchSubDir);

		VSL_CHECK_VALIDVALUE(grfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveDirectoryValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(RemoveDirectory)(
		/*[in]*/ VSCOOKIE dwAdvise,
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveDirectory)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct SyncFileValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		HRESULT retValue;
	};

	STDMETHOD(SyncFile)(
		/*[in]*/ LPCOLESTR pszMkDocument)
	{
		VSL_DEFINE_MOCK_METHOD(SyncFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct IgnoreFileValidValues
	{
		/*[in]*/ VSCOOKIE dwAdvise;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ BOOL fIgnore;
		HRESULT retValue;
	};

	STDMETHOD(IgnoreFile)(
		/*[in]*/ VSCOOKIE dwAdvise,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ BOOL fIgnore)
	{
		VSL_DEFINE_MOCK_METHOD(IgnoreFile)

		VSL_CHECK_VALIDVALUE(dwAdvise);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(fIgnore);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILECHANGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
