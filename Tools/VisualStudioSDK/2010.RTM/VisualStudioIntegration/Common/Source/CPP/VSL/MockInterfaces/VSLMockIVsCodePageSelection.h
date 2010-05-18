/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEPAGESELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEPAGESELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCodePageSelectionNotImpl :
	public IVsCodePageSelection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodePageSelectionNotImpl)

public:

	typedef IVsCodePageSelection Interface;

	STDMETHOD(ShowEncodingDialog)(
		/*[in]*/ LPCOLESTR /*pszFileName*/,
		/*[in]*/ IVsUserData* /*pUserData*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodePageSelectionMockImpl :
	public IVsCodePageSelection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodePageSelectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodePageSelectionMockImpl)

	typedef IVsCodePageSelection Interface;
	struct ShowEncodingDialogValidValues
	{
		/*[in]*/ LPCOLESTR pszFileName;
		/*[in]*/ IVsUserData* pUserData;
		HRESULT retValue;
	};

	STDMETHOD(ShowEncodingDialog)(
		/*[in]*/ LPCOLESTR pszFileName,
		/*[in]*/ IVsUserData* pUserData)
	{
		VSL_DEFINE_MOCK_METHOD(ShowEncodingDialog)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUserData);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEPAGESELECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
