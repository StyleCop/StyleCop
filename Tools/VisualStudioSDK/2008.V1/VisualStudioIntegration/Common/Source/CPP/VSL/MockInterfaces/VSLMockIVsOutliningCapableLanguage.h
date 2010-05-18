/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTLININGCAPABLELANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTLININGCAPABLELANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsOutliningCapableLanguageNotImpl :
	public IVsOutliningCapableLanguage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutliningCapableLanguageNotImpl)

public:

	typedef IVsOutliningCapableLanguage Interface;

	STDMETHOD(CollapseToDefinitions)(
		/*[in]*/ IVsTextLines* /*pTextLines*/,
		/*[in]*/ IVsOutliningSession* /*pSession*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutliningCapableLanguageMockImpl :
	public IVsOutliningCapableLanguage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutliningCapableLanguageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutliningCapableLanguageMockImpl)

	typedef IVsOutliningCapableLanguage Interface;
	struct CollapseToDefinitionsValidValues
	{
		/*[in]*/ IVsTextLines* pTextLines;
		/*[in]*/ IVsOutliningSession* pSession;
		HRESULT retValue;
	};

	STDMETHOD(CollapseToDefinitions)(
		/*[in]*/ IVsTextLines* pTextLines,
		/*[in]*/ IVsOutliningSession* pSession)
	{
		VSL_DEFINE_MOCK_METHOD(CollapseToDefinitions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextLines);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSession);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTLININGCAPABLELANGUAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
