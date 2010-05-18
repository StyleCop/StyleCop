/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSLANGUAGEDEBUGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSLANGUAGEDEBUGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsLanguageDebugInfoNotImpl :
	public IVsLanguageDebugInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDebugInfoNotImpl)

public:

	typedef IVsLanguageDebugInfo Interface;

	STDMETHOD(GetProximityExpressions)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[in]*/ long /*cLines*/,
		/*[out]*/ IVsEnumBSTR** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ValidateBreakpointLocation)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ TextSpan* /*pCodeSpan*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNameOfLocation)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ BSTR* /*pbstrName*/,
		/*[out]*/ long* /*piLineOffset*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLocationOfName)(
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[out]*/ BSTR* /*pbstrMkDoc*/,
		/*[out]*/ TextSpan* /*pspanLocation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResolveName)(
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ IVsEnumDebugName** /*ppNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageID)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/,
		/*[out]*/ GUID* /*pguidLanguageID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsMappedLocation)(
		/*[in]*/ IVsTextBuffer* /*pBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ long /*iCol*/)VSL_STDMETHOD_NOTIMPL
};

class IVsLanguageDebugInfoMockImpl :
	public IVsLanguageDebugInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsLanguageDebugInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsLanguageDebugInfoMockImpl)

	typedef IVsLanguageDebugInfo Interface;
	struct GetProximityExpressionsValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[in]*/ long cLines;
		/*[out]*/ IVsEnumBSTR** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetProximityExpressions)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[in]*/ long cLines,
		/*[out]*/ IVsEnumBSTR** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetProximityExpressions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_CHECK_VALIDVALUE(cLines);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct ValidateBreakpointLocationValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ TextSpan* pCodeSpan;
		HRESULT retValue;
	};

	STDMETHOD(ValidateBreakpointLocation)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ TextSpan* pCodeSpan)
	{
		VSL_DEFINE_MOCK_METHOD(ValidateBreakpointLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE(pCodeSpan);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameOfLocationValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ BSTR* pbstrName;
		/*[out]*/ long* piLineOffset;
		HRESULT retValue;
	};

	STDMETHOD(GetNameOfLocation)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ BSTR* pbstrName,
		/*[out]*/ long* piLineOffset)
	{
		VSL_DEFINE_MOCK_METHOD(GetNameOfLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE(piLineOffset);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLocationOfNameValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		/*[out]*/ BSTR* pbstrMkDoc;
		/*[out]*/ TextSpan* pspanLocation;
		HRESULT retValue;
	};

	STDMETHOD(GetLocationOfName)(
		/*[in]*/ LPCOLESTR pszName,
		/*[out]*/ BSTR* pbstrMkDoc,
		/*[out]*/ TextSpan* pspanLocation)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocationOfName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_SET_VALIDVALUE_BSTR(pbstrMkDoc);

		VSL_SET_VALIDVALUE(pspanLocation);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResolveNameValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ IVsEnumDebugName** ppNames;
		HRESULT retValue;
	};

	STDMETHOD(ResolveName)(
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ IVsEnumDebugName** ppNames)
	{
		VSL_DEFINE_MOCK_METHOD(ResolveName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppNames);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLanguageIDValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		/*[out]*/ GUID* pguidLanguageID;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageID)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol,
		/*[out]*/ GUID* pguidLanguageID)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageID)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_SET_VALIDVALUE(pguidLanguageID);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsMappedLocationValidValues
	{
		/*[in]*/ IVsTextBuffer* pBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ long iCol;
		HRESULT retValue;
	};

	STDMETHOD(IsMappedLocation)(
		/*[in]*/ IVsTextBuffer* pBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ long iCol)
	{
		VSL_DEFINE_MOCK_METHOD(IsMappedLocation)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iCol);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSLANGUAGEDEBUGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
