/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTPOSITIONOFFSET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTPOSITIONOFFSET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugDocumentPositionOffset2NotImpl :
	public IDebugDocumentPositionOffset2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentPositionOffset2NotImpl)

public:

	typedef IDebugDocumentPositionOffset2 Interface;

	STDMETHOD(GetRange)(
		/*[in,out,ptr]*/ DWORD* /*pdwBegOffset*/,
		/*[in,out,ptr]*/ DWORD* /*pdwEndOffset*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentPositionOffset2MockImpl :
	public IDebugDocumentPositionOffset2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentPositionOffset2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentPositionOffset2MockImpl)

	typedef IDebugDocumentPositionOffset2 Interface;
	struct GetRangeValidValues
	{
		/*[in,out,ptr]*/ DWORD* pdwBegOffset;
		/*[in,out,ptr]*/ DWORD* pdwEndOffset;
		HRESULT retValue;
	};

	STDMETHOD(GetRange)(
		/*[in,out,ptr]*/ DWORD* pdwBegOffset,
		/*[in,out,ptr]*/ DWORD* pdwEndOffset)
	{
		VSL_DEFINE_MOCK_METHOD(GetRange)

		VSL_SET_VALIDVALUE(pdwBegOffset);

		VSL_SET_VALIDVALUE(pdwEndOffset);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTPOSITIONOFFSET2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
