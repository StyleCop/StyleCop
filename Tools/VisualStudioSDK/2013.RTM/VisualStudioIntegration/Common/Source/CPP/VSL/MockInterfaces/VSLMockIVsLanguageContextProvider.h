/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGECONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGECONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageContextProviderNotImpl :
	public IVsLanguageContextProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageContextProviderNotImpl)

public:

	typedef IVsLanguageContextProvider Interface;

	STDMETHOD(UpdateLanguageContext)(
		/*[in]*/ DWORD /*dwHint*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[in]*/ TextSpan* /*ptsSelection*/,
		/*[in]*/ IVsUserContext* /*pUC*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageContextProviderMockImpl :
	public IVsLanguageContextProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageContextProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageContextProviderMockImpl)

	typedef IVsLanguageContextProvider Interface;
	struct UpdateLanguageContextValidValues
	{
		/*[in]*/ DWORD dwHint;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[in]*/ TextSpan* ptsSelection;
		/*[in]*/ IVsUserContext* pUC;
		HRESULT retValue;
	};

	STDMETHOD(UpdateLanguageContext)(
		/*[in]*/ DWORD dwHint,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[in]*/ TextSpan* ptsSelection,
		/*[in]*/ IVsUserContext* pUC)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateLanguageContext)

		VSL_CHECK_VALIDVALUE(dwHint);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE_POINTER(ptsSelection);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUC);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGECONTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
