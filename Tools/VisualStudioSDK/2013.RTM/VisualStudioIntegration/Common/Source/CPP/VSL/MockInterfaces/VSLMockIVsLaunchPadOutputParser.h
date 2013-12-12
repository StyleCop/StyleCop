/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLAUNCHPADOUTPUTPARSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLAUNCHPADOUTPUTPARSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsLaunchPadOutputParserNotImpl :
	public IVsLaunchPadOutputParser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPadOutputParserNotImpl)

public:

	typedef IVsLaunchPadOutputParser Interface;

	STDMETHOD(ParseOutputStringForInfo)(
		/*[in]*/ LPCOLESTR /*pszOutputString*/,
		/*[out,optional]*/ BSTR* /*pbstrFilename*/,
		/*[out,optional]*/ ULONG* /*pnLineNum*/,
		/*[out,optional]*/ ULONG* /*pnPriority*/,
		/*[out,optional]*/ BSTR* /*pbstrTaskItemText*/,
		/*[out,optional]*/ BSTR* /*pbstrHelpKeyword*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLaunchPadOutputParserMockImpl :
	public IVsLaunchPadOutputParser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLaunchPadOutputParserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLaunchPadOutputParserMockImpl)

	typedef IVsLaunchPadOutputParser Interface;
	struct ParseOutputStringForInfoValidValues
	{
		/*[in]*/ LPCOLESTR pszOutputString;
		/*[out,optional]*/ BSTR* pbstrFilename;
		/*[out,optional]*/ ULONG* pnLineNum;
		/*[out,optional]*/ ULONG* pnPriority;
		/*[out,optional]*/ BSTR* pbstrTaskItemText;
		/*[out,optional]*/ BSTR* pbstrHelpKeyword;
		HRESULT retValue;
	};

	STDMETHOD(ParseOutputStringForInfo)(
		/*[in]*/ LPCOLESTR pszOutputString,
		/*[out,optional]*/ BSTR* pbstrFilename,
		/*[out,optional]*/ ULONG* pnLineNum,
		/*[out,optional]*/ ULONG* pnPriority,
		/*[out,optional]*/ BSTR* pbstrTaskItemText,
		/*[out,optional]*/ BSTR* pbstrHelpKeyword)
	{
		VSL_DEFINE_MOCK_METHOD(ParseOutputStringForInfo)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOutputString);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilename);

		VSL_SET_VALIDVALUE(pnLineNum);

		VSL_SET_VALIDVALUE(pnPriority);

		VSL_SET_VALIDVALUE_BSTR(pbstrTaskItemText);

		VSL_SET_VALIDVALUE_BSTR(pbstrHelpKeyword);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLAUNCHPADOUTPUTPARSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
