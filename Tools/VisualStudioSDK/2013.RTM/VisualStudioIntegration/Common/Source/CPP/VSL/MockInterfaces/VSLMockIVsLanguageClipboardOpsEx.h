/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGECLIPBOARDOPSEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGECLIPBOARDOPSEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageClipboardOpsExNotImpl :
	public IVsLanguageClipboardOpsEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageClipboardOpsExNotImpl)

public:

	typedef IVsLanguageClipboardOpsEx Interface;

	STDMETHOD(IsTextDataEx)(
		/*[in]*/ IDataObject* /*pDO*/,
		/*[in]*/ IVsTextLines* /*pBuffer*/,
		/*[out]*/ BOOL* /*pfIsTextData*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageClipboardOpsExMockImpl :
	public IVsLanguageClipboardOpsEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageClipboardOpsExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageClipboardOpsExMockImpl)

	typedef IVsLanguageClipboardOpsEx Interface;
	struct IsTextDataExValidValues
	{
		/*[in]*/ IDataObject* pDO;
		/*[in]*/ IVsTextLines* pBuffer;
		/*[out]*/ BOOL* pfIsTextData;
		HRESULT retValue;
	};

	STDMETHOD(IsTextDataEx)(
		/*[in]*/ IDataObject* pDO,
		/*[in]*/ IVsTextLines* pBuffer,
		/*[out]*/ BOOL* pfIsTextData)
	{
		VSL_DEFINE_MOCK_METHOD(IsTextDataEx)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDO);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_SET_VALIDVALUE(pfIsTextData);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGECLIPBOARDOPSEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
