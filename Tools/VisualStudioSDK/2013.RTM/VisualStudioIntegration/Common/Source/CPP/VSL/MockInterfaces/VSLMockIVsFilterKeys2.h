/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILTERKEYS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILTERKEYS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFilterKeys2NotImpl :
	public IVsFilterKeys2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterKeys2NotImpl)

public:

	typedef IVsFilterKeys2 Interface;

	STDMETHOD(TranslateAcceleratorEx)(
		/*[in]*/ LPMSG /*pMsg*/,
		/*[in]*/ VSTRANSACCELEXFLAGS /*dwFlags*/,
		/*[in]*/ DWORD /*cKeyBindingScopes*/,
		/*[in,size_is(cKeyBindingScopes)]*/ const GUID[] /*rgguidKeyBindingScopes*/,
		/*[out]*/ GUID* /*pguidCmd*/,
		/*[out]*/ DWORD* /*pdwCmd*/,
		/*[out]*/ BOOL* /*fCmdTranslated*/,
		/*[out]*/ BOOL* /*pfKeyComboStartsChord*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFilterKeys2MockImpl :
	public IVsFilterKeys2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterKeys2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFilterKeys2MockImpl)

	typedef IVsFilterKeys2 Interface;
	struct TranslateAcceleratorExValidValues
	{
		/*[in]*/ LPMSG pMsg;
		/*[in]*/ VSTRANSACCELEXFLAGS dwFlags;
		/*[in]*/ DWORD cKeyBindingScopes;
		/*[in,size_is(cKeyBindingScopes)]*/ GUID* rgguidKeyBindingScopes;
		/*[out]*/ GUID* pguidCmd;
		/*[out]*/ DWORD* pdwCmd;
		/*[out]*/ BOOL* fCmdTranslated;
		/*[out]*/ BOOL* pfKeyComboStartsChord;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAcceleratorEx)(
		/*[in]*/ LPMSG pMsg,
		/*[in]*/ VSTRANSACCELEXFLAGS dwFlags,
		/*[in]*/ DWORD cKeyBindingScopes,
		/*[in,size_is(cKeyBindingScopes)]*/ const GUID rgguidKeyBindingScopes[],
		/*[out]*/ GUID* pguidCmd,
		/*[out]*/ DWORD* pdwCmd,
		/*[out]*/ BOOL* fCmdTranslated,
		/*[out]*/ BOOL* pfKeyComboStartsChord)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAcceleratorEx)

		VSL_CHECK_VALIDVALUE(pMsg);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(cKeyBindingScopes);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidKeyBindingScopes, cKeyBindingScopes*sizeof(rgguidKeyBindingScopes[0]), validValues.cKeyBindingScopes*sizeof(validValues.rgguidKeyBindingScopes[0]));

		VSL_SET_VALIDVALUE(pguidCmd);

		VSL_SET_VALIDVALUE(pdwCmd);

		VSL_SET_VALIDVALUE(fCmdTranslated);

		VSL_SET_VALIDVALUE(pfKeyComboStartsChord);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILTERKEYS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
