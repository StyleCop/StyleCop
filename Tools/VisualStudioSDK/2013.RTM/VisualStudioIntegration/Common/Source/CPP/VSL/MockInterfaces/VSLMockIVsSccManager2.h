/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccManager2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccManager2NotImpl :
	public IVsSccManager2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccManager2NotImpl)

public:

	typedef IVsSccManager2 Interface;

	STDMETHOD(RegisterSccProject)(
		/*[in]*/ IVsSccProject2* /*pscp2Project*/,
		/*[in]*/ LPCOLESTR /*pszSccProjectName*/,
		/*[in]*/ LPCOLESTR /*pszSccAuxPath*/,
		/*[in]*/ LPCOLESTR /*pszSccLocalPath*/,
		/*[in]*/ LPCOLESTR /*pszProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterSccProject)(
		/*[in]*/ IVsSccProject2* /*pscp2Project*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccGlyph)(
		/*[in]*/ int /*cFiles*/,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR[] /*rgpszFullPaths*/,
		/*[out,size_is(cFiles)]*/ VsStateIcon[] /*rgsiGlyphs*/,
		/*[out,size_is(cFiles)]*/ DWORD[] /*rgdwSccStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccGlyphFromStatus)(
		/*[in]*/ DWORD /*dwSccStatus*/,
		/*[out,retval]*/ VsStateIcon* /*psiGlyph*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsInstalled)(
		/*[out,retval]*/ BOOL* /*pbInstalled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BrowseForProject)(
		/*[out]*/ BSTR* /*pbstrDirectory*/,
		/*[out]*/ BOOL* /*pfOK*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelAfterBrowseForProject)()VSL_STDMETHOD_NOTIMPL
};

class IVsSccManager2MockImpl :
	public IVsSccManager2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccManager2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccManager2MockImpl)

	typedef IVsSccManager2 Interface;
	struct RegisterSccProjectValidValues
	{
		/*[in]*/ IVsSccProject2* pscp2Project;
		/*[in]*/ LPCOLESTR pszSccProjectName;
		/*[in]*/ LPCOLESTR pszSccAuxPath;
		/*[in]*/ LPCOLESTR pszSccLocalPath;
		/*[in]*/ LPCOLESTR pszProvider;
		HRESULT retValue;
	};

	STDMETHOD(RegisterSccProject)(
		/*[in]*/ IVsSccProject2* pscp2Project,
		/*[in]*/ LPCOLESTR pszSccProjectName,
		/*[in]*/ LPCOLESTR pszSccAuxPath,
		/*[in]*/ LPCOLESTR pszSccLocalPath,
		/*[in]*/ LPCOLESTR pszProvider)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterSccProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pscp2Project);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccProjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccAuxPath);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSccLocalPath);

		VSL_CHECK_VALIDVALUE_STRINGW(pszProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterSccProjectValidValues
	{
		/*[in]*/ IVsSccProject2* pscp2Project;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterSccProject)(
		/*[in]*/ IVsSccProject2* pscp2Project)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterSccProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pscp2Project);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccGlyphValidValues
	{
		/*[in]*/ int cFiles;
		/*[in,size_is(cFiles)]*/ LPCOLESTR* rgpszFullPaths;
		/*[out,size_is(cFiles)]*/ VsStateIcon* rgsiGlyphs;
		/*[out,size_is(cFiles)]*/ DWORD* rgdwSccStatus;
		HRESULT retValue;
	};

	STDMETHOD(GetSccGlyph)(
		/*[in]*/ int cFiles,
		/*[in,size_is(cFiles)]*/ const LPCOLESTR rgpszFullPaths[],
		/*[out,size_is(cFiles)]*/ VsStateIcon rgsiGlyphs[],
		/*[out,size_is(cFiles)]*/ DWORD rgdwSccStatus[])
	{
		VSL_DEFINE_MOCK_METHOD(GetSccGlyph)

		VSL_CHECK_VALIDVALUE(cFiles);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFullPaths, cFiles*sizeof(rgpszFullPaths[0]), validValues.cFiles*sizeof(validValues.rgpszFullPaths[0]));

		VSL_SET_VALIDVALUE_MEMCPY(rgsiGlyphs, cFiles*sizeof(rgsiGlyphs[0]), validValues.cFiles*sizeof(validValues.rgsiGlyphs[0]));

		VSL_SET_VALIDVALUE_MEMCPY(rgdwSccStatus, cFiles*sizeof(rgdwSccStatus[0]), validValues.cFiles*sizeof(validValues.rgdwSccStatus[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccGlyphFromStatusValidValues
	{
		/*[in]*/ DWORD dwSccStatus;
		/*[out,retval]*/ VsStateIcon* psiGlyph;
		HRESULT retValue;
	};

	STDMETHOD(GetSccGlyphFromStatus)(
		/*[in]*/ DWORD dwSccStatus,
		/*[out,retval]*/ VsStateIcon* psiGlyph)
	{
		VSL_DEFINE_MOCK_METHOD(GetSccGlyphFromStatus)

		VSL_CHECK_VALIDVALUE(dwSccStatus);

		VSL_SET_VALIDVALUE(psiGlyph);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsInstalledValidValues
	{
		/*[out,retval]*/ BOOL* pbInstalled;
		HRESULT retValue;
	};

	STDMETHOD(IsInstalled)(
		/*[out,retval]*/ BOOL* pbInstalled)
	{
		VSL_DEFINE_MOCK_METHOD(IsInstalled)

		VSL_SET_VALIDVALUE(pbInstalled);

		VSL_RETURN_VALIDVALUES();
	}
	struct BrowseForProjectValidValues
	{
		/*[out]*/ BSTR* pbstrDirectory;
		/*[out]*/ BOOL* pfOK;
		HRESULT retValue;
	};

	STDMETHOD(BrowseForProject)(
		/*[out]*/ BSTR* pbstrDirectory,
		/*[out]*/ BOOL* pfOK)
	{
		VSL_DEFINE_MOCK_METHOD(BrowseForProject)

		VSL_SET_VALIDVALUE_BSTR(pbstrDirectory);

		VSL_SET_VALIDVALUE(pfOK);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelAfterBrowseForProjectValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CancelAfterBrowseForProject)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CancelAfterBrowseForProject)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
