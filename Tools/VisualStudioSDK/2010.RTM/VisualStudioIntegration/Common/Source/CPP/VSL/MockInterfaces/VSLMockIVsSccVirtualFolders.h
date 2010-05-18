/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCVIRTUALFOLDERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCVIRTUALFOLDERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccVirtualFolders.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccVirtualFoldersNotImpl :
	public IVsSccVirtualFolders
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccVirtualFoldersNotImpl)

public:

	typedef IVsSccVirtualFolders Interface;

	STDMETHOD(GetVirtualFolders)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ CALPOLESTR* /*pCaStringsOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsItemChildOfVirtualFolder)(
		/*[in]*/ LPCOLESTR /*pszItemName*/,
		/*[out]*/ VARIANT_BOOL* /*pfResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccVirtualFoldersMockImpl :
	public IVsSccVirtualFolders,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccVirtualFoldersMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccVirtualFoldersMockImpl)

	typedef IVsSccVirtualFolders Interface;
	struct GetVirtualFoldersValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ CALPOLESTR* pCaStringsOut;
		HRESULT retValue;
	};

	STDMETHOD(GetVirtualFolders)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ CALPOLESTR* pCaStringsOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetVirtualFolders)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE(pCaStringsOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsItemChildOfVirtualFolderValidValues
	{
		/*[in]*/ LPCOLESTR pszItemName;
		/*[out]*/ VARIANT_BOOL* pfResult;
		HRESULT retValue;
	};

	STDMETHOD(IsItemChildOfVirtualFolder)(
		/*[in]*/ LPCOLESTR pszItemName,
		/*[out]*/ VARIANT_BOOL* pfResult)
	{
		VSL_DEFINE_MOCK_METHOD(IsItemChildOfVirtualFolder)

		VSL_CHECK_VALIDVALUE_STRINGW(pszItemName);

		VSL_SET_VALIDVALUE(pfResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCVIRTUALFOLDERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
