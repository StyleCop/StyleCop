/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSGENERATORPROGRESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSGENERATORPROGRESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsGeneratorProgressNotImpl :
	public IVsGeneratorProgress
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGeneratorProgressNotImpl)

public:

	typedef IVsGeneratorProgress Interface;

	STDMETHOD(GeneratorError)(
		/*[in]*/ BOOL /*fWarning*/,
		/*[in]*/ DWORD /*dwLevel*/,
		/*[in]*/ BSTR /*bstrError*/,
		/*[in]*/ DWORD /*dwLine*/,
		/*[in]*/ DWORD /*dwColumn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Progress)(
		/*[in]*/ ULONG /*nComplete*/,
		/*[in]*/ ULONG /*nTotal*/)VSL_STDMETHOD_NOTIMPL
};

class IVsGeneratorProgressMockImpl :
	public IVsGeneratorProgress,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsGeneratorProgressMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsGeneratorProgressMockImpl)

	typedef IVsGeneratorProgress Interface;
	struct GeneratorErrorValidValues
	{
		/*[in]*/ BOOL fWarning;
		/*[in]*/ DWORD dwLevel;
		/*[in]*/ BSTR bstrError;
		/*[in]*/ DWORD dwLine;
		/*[in]*/ DWORD dwColumn;
		HRESULT retValue;
	};

	STDMETHOD(GeneratorError)(
		/*[in]*/ BOOL fWarning,
		/*[in]*/ DWORD dwLevel,
		/*[in]*/ BSTR bstrError,
		/*[in]*/ DWORD dwLine,
		/*[in]*/ DWORD dwColumn)
	{
		VSL_DEFINE_MOCK_METHOD(GeneratorError)

		VSL_CHECK_VALIDVALUE(fWarning);

		VSL_CHECK_VALIDVALUE(dwLevel);

		VSL_CHECK_VALIDVALUE_BSTR(bstrError);

		VSL_CHECK_VALIDVALUE(dwLine);

		VSL_CHECK_VALIDVALUE(dwColumn);

		VSL_RETURN_VALIDVALUES();
	}
	struct ProgressValidValues
	{
		/*[in]*/ ULONG nComplete;
		/*[in]*/ ULONG nTotal;
		HRESULT retValue;
	};

	STDMETHOD(Progress)(
		/*[in]*/ ULONG nComplete,
		/*[in]*/ ULONG nTotal)
	{
		VSL_DEFINE_MOCK_METHOD(Progress)

		VSL_CHECK_VALIDVALUE(nComplete);

		VSL_CHECK_VALIDVALUE(nTotal);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSGENERATORPROGRESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
