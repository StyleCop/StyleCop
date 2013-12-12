/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGEDEBUGINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGEDEBUGINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageDebugInfo2NotImpl :
	public IVsLanguageDebugInfo2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDebugInfo2NotImpl)

public:

	typedef IVsLanguageDebugInfo2 Interface;

	STDMETHOD(QueryCommonLanguageBlock)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[in]*/ DWORD /*dwFlag*/,
		/*[out]*/ BOOL* /*pfInBlock*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ValidateInstructionpointLocation)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ TextSpan* /*pCodeSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryCatchLineSpan)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ BOOL* /*pfIsInCatch*/,
		/*[out]*/ TextSpan* /*ptsCatchLine*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageDebugInfo2MockImpl :
	public IVsLanguageDebugInfo2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDebugInfo2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageDebugInfo2MockImpl)

	typedef IVsLanguageDebugInfo2 Interface;
	struct QueryCommonLanguageBlockValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[in]*/ DWORD dwFlag;
		/*[out]*/ BOOL* pfInBlock;
		HRESULT retValue;
	};

	STDMETHOD(QueryCommonLanguageBlock)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[in]*/ DWORD dwFlag,
		/*[out]*/ BOOL* pfInBlock)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCommonLanguageBlock)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_CHECK_VALIDVALUE(dwFlag);

		VSL_SET_VALIDVALUE(pfInBlock);

		VSL_RETURN_VALIDVALUES();
	}
	struct ValidateInstructionpointLocationValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ TextSpan* pCodeSpan;
		HRESULT retValue;
	};

	STDMETHOD(ValidateInstructionpointLocation)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ TextSpan* pCodeSpan)
	{
		VSL_DEFINE_MOCK_METHOD(ValidateInstructionpointLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE(pCodeSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryCatchLineSpanValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ BOOL* pfIsInCatch;
		/*[out]*/ TextSpan* ptsCatchLine;
		HRESULT retValue;
	};

	STDMETHOD(QueryCatchLineSpan)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ BOOL* pfIsInCatch,
		/*[out]*/ TextSpan* ptsCatchLine)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCatchLineSpan)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE(pfIsInCatch);

		VSL_SET_VALIDVALUE(ptsCatchLine);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGEDEBUGINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
