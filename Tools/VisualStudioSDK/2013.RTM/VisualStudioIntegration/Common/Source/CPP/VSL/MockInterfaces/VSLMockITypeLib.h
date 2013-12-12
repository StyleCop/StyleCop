/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ITypeLibNotImpl :
	public ITypeLib
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeLibNotImpl)

public:

	typedef ITypeLib Interface;

	virtual UINT STDMETHODCALLTYPE GetTypeInfoCount(){ return UINT(); }

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoType)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ TYPEKIND* /*pTKind*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoOfGuid)(
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ ITypeInfo** /*ppTinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLibAttr)(
		/*[out]*/ TLIBATTR** /*ppTLibAttr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeComp)(
		/*[out]*/ ITypeComp** /*ppTComp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentation)(
		/*[in]*/ INT /*index*/,
		/*[out]*/ BSTR* /*pBstrName*/,
		/*[out]*/ BSTR* /*pBstrDocString*/,
		/*[out]*/ DWORD* /*pdwHelpContext*/,
		/*[out]*/ BSTR* /*pBstrHelpFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsName)(
		/*[in,out]*/ LPOLESTR /*szNameBuf*/,
		/*[in]*/ ULONG /*lHashVal*/,
		/*[out]*/ BOOL* /*pfName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindName)(
		/*[in,out]*/ LPOLESTR /*szNameBuf*/,
		/*[in]*/ ULONG /*lHashVal*/,
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ ITypeInfo** /*ppTInfo*/,
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ MEMBERID* /*rgMemId*/,
		/*[in,out]*/ USHORT* /*pcFound*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE ReleaseTLibAttr(
		/*[in]*/ TLIBATTR* /*pTLibAttr*/){ return ; }
};

class ITypeLibMockImpl :
	public ITypeLib,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeLibMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeLibMockImpl)

	typedef ITypeLib Interface;
	struct GetTypeInfoCountValidValues
	{
		UINT retValue;
	};

	virtual UINT _stdcall GetTypeInfoCount()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetTypeInfoCount)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT index,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoTypeValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ TYPEKIND* pTKind;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoType)(
		/*[in]*/ UINT index,
		/*[out]*/ TYPEKIND* pTKind)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoType)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pTKind);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoOfGuidValidValues
	{
		/*[in]*/ REFGUID guid;
		/*[out]*/ ITypeInfo** ppTinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoOfGuid)(
		/*[in]*/ REFGUID guid,
		/*[out]*/ ITypeInfo** ppTinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoOfGuid)

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLibAttrValidValues
	{
		/*[out]*/ TLIBATTR** ppTLibAttr;
		HRESULT retValue;
	};

	STDMETHOD(GetLibAttr)(
		/*[out]*/ TLIBATTR** ppTLibAttr)
	{
		VSL_DEFINE_MOCK_METHOD(GetLibAttr)

		VSL_SET_VALIDVALUE(ppTLibAttr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeCompValidValues
	{
		/*[out]*/ ITypeComp** ppTComp;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeComp)(
		/*[out]*/ ITypeComp** ppTComp)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeComp)

		VSL_SET_VALIDVALUE_INTERFACE(ppTComp);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentationValidValues
	{
		/*[in]*/ INT index;
		/*[out]*/ BSTR* pBstrName;
		/*[out]*/ BSTR* pBstrDocString;
		/*[out]*/ DWORD* pdwHelpContext;
		/*[out]*/ BSTR* pBstrHelpFile;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentation)(
		/*[in]*/ INT index,
		/*[out]*/ BSTR* pBstrName,
		/*[out]*/ BSTR* pBstrDocString,
		/*[out]*/ DWORD* pdwHelpContext,
		/*[out]*/ BSTR* pBstrHelpFile)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentation)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_BSTR(pBstrName);

		VSL_SET_VALIDVALUE_BSTR(pBstrDocString);

		VSL_SET_VALIDVALUE(pdwHelpContext);

		VSL_SET_VALIDVALUE_BSTR(pBstrHelpFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsNameValidValues
	{
		/*[in,out]*/ LPOLESTR szNameBuf;
		/*[in]*/ ULONG lHashVal;
		/*[out]*/ BOOL* pfName;
		HRESULT retValue;
	};

	STDMETHOD(IsName)(
		/*[in,out]*/ LPOLESTR szNameBuf,
		/*[in]*/ ULONG lHashVal,
		/*[out]*/ BOOL* pfName)
	{
		VSL_DEFINE_MOCK_METHOD(IsName)

		VSL_SET_VALIDVALUE_STRINGW(szNameBuf, VSL_VALIDVALUD_STRINGW_LENGTH(szNameBuf));

		VSL_CHECK_VALIDVALUE(lHashVal);

		VSL_SET_VALIDVALUE(pfName);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindNameValidValues
	{
		/*[in,out]*/ LPOLESTR szNameBuf;
		/*[in]*/ ULONG lHashVal;
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ ITypeInfo** ppTInfo;
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ MEMBERID* rgMemId;
		/*[in,out]*/ USHORT* pcFound;
		HRESULT retValue;
	};

	STDMETHOD(FindName)(
		/*[in,out]*/ LPOLESTR szNameBuf,
		/*[in]*/ ULONG lHashVal,
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ ITypeInfo** ppTInfo,
		/*[out,size_is(*pcFound),length_is(*pcFound)]*/ MEMBERID* rgMemId,
		/*[in,out]*/ USHORT* pcFound)
	{
		VSL_DEFINE_MOCK_METHOD(FindName)

		VSL_SET_VALIDVALUE_STRINGW(szNameBuf, VSL_VALIDVALUD_STRINGW_LENGTH(szNameBuf));

		VSL_CHECK_VALIDVALUE(lHashVal);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(ppTInfo, *pcFound, *(validValues.pcFound));

		VSL_SET_VALIDVALUE_MEMCPY(rgMemId, *pcFound*sizeof(rgMemId[0]), *(validValues.pcFound)*sizeof(validValues.rgMemId[0]));

		VSL_SET_VALIDVALUE(pcFound);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseTLibAttrValidValues
	{
		/*[in]*/ TLIBATTR* pTLibAttr;
	};

	virtual void _stdcall ReleaseTLibAttr(
		/*[in]*/ TLIBATTR* pTLibAttr)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseTLibAttr)

		VSL_CHECK_VALIDVALUE_POINTER(pTLibAttr);

	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
