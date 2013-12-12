/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILECHANGEEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILECHANGEEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFileChangeExNotImpl :
	public IVsFileChangeEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileChangeExNotImpl)

public:

	typedef IVsFileChangeEx Interface;

	STDMETHOD(AdviseFileChange)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ VSFILECHANGEFLAGS /*grfFilter*/,
		/*[in]*/ IVsFileChangeEvents* /*pFCE*/,
		/*[out]*/ VSCOOKIE* /*pvsCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseFileChange)(
		/*[in]*/ VSCOOKIE /*vsCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SyncFile)(
		/*[in]*/ LPCOLESTR /*pszMkDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IgnoreFile)(
		/*[in]*/ VSCOOKIE /*vsCookie*/,
		/*[in]*/ LPCOLESTR /*pszMkDocument*/,
		/*[in]*/ BOOL /*fIgnore*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseDirChange)(
		/*[in]*/ LPCOLESTR /*pszDir*/,
		/*[in]*/ BOOL /*fWatchSubDir*/,
		/*[in]*/ IVsFileChangeEvents* /*pFCE*/,
		/*[out]*/ VSCOOKIE* /*pvsCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseDirChange)(
		/*[in]*/ VSCOOKIE /*vsCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFileChangeExMockImpl :
	public IVsFileChangeEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileChangeExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFileChangeExMockImpl)

	typedef IVsFileChangeEx Interface;
	struct AdviseFileChangeValidValues
	{
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ VSFILECHANGEFLAGS grfFilter;
		/*[in]*/ IVsFileChangeEvents* pFCE;
		/*[out]*/ VSCOOKIE* pvsCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseFileChange)(
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ VSFILECHANGEFLAGS grfFilter,
		/*[in]*/ IVsFileChangeEvents* pFCE,
		/*[out]*/ VSCOOKIE* pvsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseFileChange)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(grfFilter);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFCE);

		VSL_SET_VALIDVALUE(pvsCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseFileChangeValidValues
	{
		/*[in]*/ VSCOOKIE vsCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseFileChange)(
		/*[in]*/ VSCOOKIE vsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseFileChange)

		VSL_CHECK_VALIDVALUE(vsCookie);

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
		/*[in]*/ VSCOOKIE vsCookie;
		/*[in]*/ LPCOLESTR pszMkDocument;
		/*[in]*/ BOOL fIgnore;
		HRESULT retValue;
	};

	STDMETHOD(IgnoreFile)(
		/*[in]*/ VSCOOKIE vsCookie,
		/*[in]*/ LPCOLESTR pszMkDocument,
		/*[in]*/ BOOL fIgnore)
	{
		VSL_DEFINE_MOCK_METHOD(IgnoreFile)

		VSL_CHECK_VALIDVALUE(vsCookie);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMkDocument);

		VSL_CHECK_VALIDVALUE(fIgnore);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseDirChangeValidValues
	{
		/*[in]*/ LPCOLESTR pszDir;
		/*[in]*/ BOOL fWatchSubDir;
		/*[in]*/ IVsFileChangeEvents* pFCE;
		/*[out]*/ VSCOOKIE* pvsCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseDirChange)(
		/*[in]*/ LPCOLESTR pszDir,
		/*[in]*/ BOOL fWatchSubDir,
		/*[in]*/ IVsFileChangeEvents* pFCE,
		/*[out]*/ VSCOOKIE* pvsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseDirChange)

		VSL_CHECK_VALIDVALUE_STRINGW(pszDir);

		VSL_CHECK_VALIDVALUE(fWatchSubDir);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFCE);

		VSL_SET_VALIDVALUE(pvsCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseDirChangeValidValues
	{
		/*[in]*/ VSCOOKIE vsCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseDirChange)(
		/*[in]*/ VSCOOKIE vsCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseDirChange)

		VSL_CHECK_VALIDVALUE(vsCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILECHANGEEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
