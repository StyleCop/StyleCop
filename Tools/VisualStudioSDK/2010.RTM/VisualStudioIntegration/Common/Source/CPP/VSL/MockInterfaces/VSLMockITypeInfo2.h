/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITypeInfo2NotImpl :
	public ITypeInfo2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeInfo2NotImpl)

public:

	typedef ITypeInfo2 Interface;

	STDMETHOD(GetTypeKind)(
		/*[out]*/ TYPEKIND* /*pTypeKind*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeFlags)(
		/*[out]*/ ULONG* /*pTypeFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFuncIndexOfMemId)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ INVOKEKIND /*invKind*/,
		/*[out]*/ UINT* /*pFuncIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVarIndexOfMemId)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[out]*/ UINT* /*pVarIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCustData)(
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFuncCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParamCustData)(
		/*[in]*/ UINT /*indexFunc*/,
		/*[in]*/ UINT /*indexParam*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVarCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImplTypeCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[out]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentation2)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ BSTR* /*pbstrHelpString*/,
		/*[out]*/ DWORD* /*pdwHelpStringContext*/,
		/*[out]*/ BSTR* /*pbstrHelpStringDll*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllCustData)(
		/*[out]*/ CUSTDATA* /*pCustData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllFuncCustData)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ CUSTDATA* /*pCustData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllParamCustData)(
		/*[in]*/ UINT /*indexFunc*/,
		/*[in]*/ UINT /*indexParam*/,
		/*[out]*/ CUSTDATA* /*pCustData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllVarCustData)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ CUSTDATA* /*pCustData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAllImplTypeCustData)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ CUSTDATA* /*pCustData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeAttr)(
		/*[out]*/ TYPEATTR** /*ppTypeAttr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeComp)(
		/*[out]*/ ITypeComp** /*ppTComp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFuncDesc)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ FUNCDESC** /*ppFuncDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetVarDesc)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ VARDESC** /*ppVarDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNames)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[out,size_is(cMaxNames),length_is(*pcNames)]*/ BSTR* /*rgBstrNames*/,
		/*[in]*/ UINT /*cMaxNames*/,
		/*[out]*/ UINT* /*pcNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRefTypeOfImplType)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ HREFTYPE* /*pRefType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetImplTypeFlags)(
		/*[in]*/ UINT /*index*/,
		/*[out]*/ INT* /*pImplTypeFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[out,size_is(cNames)]*/ MEMBERID* /*pMemId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ PVOID /*pvInstance*/,
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentation)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[out]*/ BSTR* /*pBstrName*/,
		/*[out]*/ BSTR* /*pBstrDocString*/,
		/*[out]*/ DWORD* /*pdwHelpContext*/,
		/*[out]*/ BSTR* /*pBstrHelpFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDllEntry)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ INVOKEKIND /*invKind*/,
		/*[out]*/ BSTR* /*pBstrDllName*/,
		/*[out]*/ BSTR* /*pBstrName*/,
		/*[out]*/ WORD* /*pwOrdinal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRefTypeInfo)(
		/*[in]*/ HREFTYPE /*hRefType*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddressOfMember)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ INVOKEKIND /*invKind*/,
		/*[out]*/ PVOID* /*ppv*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateInstance)(
		/*[in]*/ IUnknown* /*pUnkOuter*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ PVOID* /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMops)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[out]*/ BSTR* /*pBstrMops*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContainingTypeLib)(
		/*[out]*/ ITypeLib** /*ppTLib*/,
		/*[out]*/ UINT* /*pIndex*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE ReleaseTypeAttr(
		/*[in]*/ TYPEATTR* /*pTypeAttr*/){ return ; }

	virtual void STDMETHODCALLTYPE ReleaseFuncDesc(
		/*[in]*/ FUNCDESC* /*pFuncDesc*/){ return ; }

	virtual void STDMETHODCALLTYPE ReleaseVarDesc(
		/*[in]*/ VARDESC* /*pVarDesc*/){ return ; }
};

class ITypeInfo2MockImpl :
	public ITypeInfo2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeInfo2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeInfo2MockImpl)

	typedef ITypeInfo2 Interface;
	struct GetTypeKindValidValues
	{
		/*[out]*/ TYPEKIND* pTypeKind;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeKind)(
		/*[out]*/ TYPEKIND* pTypeKind)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeKind)

		VSL_SET_VALIDVALUE(pTypeKind);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeFlagsValidValues
	{
		/*[out]*/ ULONG* pTypeFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeFlags)(
		/*[out]*/ ULONG* pTypeFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeFlags)

		VSL_SET_VALIDVALUE(pTypeFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFuncIndexOfMemIdValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[in]*/ INVOKEKIND invKind;
		/*[out]*/ UINT* pFuncIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetFuncIndexOfMemId)(
		/*[in]*/ MEMBERID memid,
		/*[in]*/ INVOKEKIND invKind,
		/*[out]*/ UINT* pFuncIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetFuncIndexOfMemId)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(invKind);

		VSL_SET_VALIDVALUE(pFuncIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVarIndexOfMemIdValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[out]*/ UINT* pVarIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetVarIndexOfMemId)(
		/*[in]*/ MEMBERID memid,
		/*[out]*/ UINT* pVarIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetVarIndexOfMemId)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_SET_VALIDVALUE(pVarIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCustDataValidValues
	{
		/*[in]*/ REFGUID guid;
		/*[out]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(GetCustData)(
		/*[in]*/ REFGUID guid,
		/*[out]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetCustData)

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_VARIANT(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFuncCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[out]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(GetFuncCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[out]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetFuncCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_VARIANT(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParamCustDataValidValues
	{
		/*[in]*/ UINT indexFunc;
		/*[in]*/ UINT indexParam;
		/*[in]*/ REFGUID guid;
		/*[out]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(GetParamCustData)(
		/*[in]*/ UINT indexFunc,
		/*[in]*/ UINT indexParam,
		/*[in]*/ REFGUID guid,
		/*[out]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetParamCustData)

		VSL_CHECK_VALIDVALUE(indexFunc);

		VSL_CHECK_VALIDVALUE(indexParam);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_VARIANT(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVarCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[out]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(GetVarCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[out]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetVarCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_VARIANT(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImplTypeCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[out]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(GetImplTypeCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[out]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetImplTypeCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_SET_VALIDVALUE_VARIANT(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentation2ValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[in]*/ LCID lcid;
		/*[out]*/ BSTR* pbstrHelpString;
		/*[out]*/ DWORD* pdwHelpStringContext;
		/*[out]*/ BSTR* pbstrHelpStringDll;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentation2)(
		/*[in]*/ MEMBERID memid,
		/*[in]*/ LCID lcid,
		/*[out]*/ BSTR* pbstrHelpString,
		/*[out]*/ DWORD* pdwHelpStringContext,
		/*[out]*/ BSTR* pbstrHelpStringDll)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentation2)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_BSTR(pbstrHelpString);

		VSL_SET_VALIDVALUE(pdwHelpStringContext);

		VSL_SET_VALIDVALUE_BSTR(pbstrHelpStringDll);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllCustDataValidValues
	{
		/*[out]*/ CUSTDATA* pCustData;
		HRESULT retValue;
	};

	STDMETHOD(GetAllCustData)(
		/*[out]*/ CUSTDATA* pCustData)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllCustData)

		VSL_SET_VALIDVALUE(pCustData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllFuncCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ CUSTDATA* pCustData;
		HRESULT retValue;
	};

	STDMETHOD(GetAllFuncCustData)(
		/*[in]*/ UINT index,
		/*[out]*/ CUSTDATA* pCustData)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllFuncCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pCustData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllParamCustDataValidValues
	{
		/*[in]*/ UINT indexFunc;
		/*[in]*/ UINT indexParam;
		/*[out]*/ CUSTDATA* pCustData;
		HRESULT retValue;
	};

	STDMETHOD(GetAllParamCustData)(
		/*[in]*/ UINT indexFunc,
		/*[in]*/ UINT indexParam,
		/*[out]*/ CUSTDATA* pCustData)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllParamCustData)

		VSL_CHECK_VALIDVALUE(indexFunc);

		VSL_CHECK_VALIDVALUE(indexParam);

		VSL_SET_VALIDVALUE(pCustData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllVarCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ CUSTDATA* pCustData;
		HRESULT retValue;
	};

	STDMETHOD(GetAllVarCustData)(
		/*[in]*/ UINT index,
		/*[out]*/ CUSTDATA* pCustData)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllVarCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pCustData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAllImplTypeCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ CUSTDATA* pCustData;
		HRESULT retValue;
	};

	STDMETHOD(GetAllImplTypeCustData)(
		/*[in]*/ UINT index,
		/*[out]*/ CUSTDATA* pCustData)
	{
		VSL_DEFINE_MOCK_METHOD(GetAllImplTypeCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pCustData);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeAttrValidValues
	{
		/*[out]*/ TYPEATTR** ppTypeAttr;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeAttr)(
		/*[out]*/ TYPEATTR** ppTypeAttr)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeAttr)

		VSL_SET_VALIDVALUE(ppTypeAttr);

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
	struct GetFuncDescValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ FUNCDESC** ppFuncDesc;
		HRESULT retValue;
	};

	STDMETHOD(GetFuncDesc)(
		/*[in]*/ UINT index,
		/*[out]*/ FUNCDESC** ppFuncDesc)
	{
		VSL_DEFINE_MOCK_METHOD(GetFuncDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(ppFuncDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetVarDescValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ VARDESC** ppVarDesc;
		HRESULT retValue;
	};

	STDMETHOD(GetVarDesc)(
		/*[in]*/ UINT index,
		/*[out]*/ VARDESC** ppVarDesc)
	{
		VSL_DEFINE_MOCK_METHOD(GetVarDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(ppVarDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNamesValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[out,size_is(cMaxNames),length_is(*pcNames)]*/ BSTR* rgBstrNames;
		/*[in]*/ UINT cMaxNames;
		/*[out]*/ UINT* pcNames;
		HRESULT retValue;
	};

	STDMETHOD(GetNames)(
		/*[in]*/ MEMBERID memid,
		/*[out,size_is(cMaxNames),length_is(*pcNames)]*/ BSTR* rgBstrNames,
		/*[in]*/ UINT cMaxNames,
		/*[out]*/ UINT* pcNames)
	{
		VSL_DEFINE_MOCK_METHOD(GetNames)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_SET_VALIDVALUE_MEMCPY(rgBstrNames, cMaxNames*sizeof(rgBstrNames[0]), *(validValues.pcNames)*sizeof(validValues.rgBstrNames[0]));

		VSL_CHECK_VALIDVALUE(cMaxNames);

		VSL_SET_VALIDVALUE(pcNames);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRefTypeOfImplTypeValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ HREFTYPE* pRefType;
		HRESULT retValue;
	};

	STDMETHOD(GetRefTypeOfImplType)(
		/*[in]*/ UINT index,
		/*[out]*/ HREFTYPE* pRefType)
	{
		VSL_DEFINE_MOCK_METHOD(GetRefTypeOfImplType)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pRefType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetImplTypeFlagsValidValues
	{
		/*[in]*/ UINT index;
		/*[out]*/ INT* pImplTypeFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetImplTypeFlags)(
		/*[in]*/ UINT index,
		/*[out]*/ INT* pImplTypeFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetImplTypeFlags)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE(pImplTypeFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[out,size_is(cNames)]*/ MEMBERID* pMemId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[out,size_is(cNames)]*/ MEMBERID* pMemId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_SET_VALIDVALUE_MEMCPY(pMemId, cNames*sizeof(pMemId[0]), validValues.cNames*sizeof(validValues.pMemId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ PVOID pvInstance;
		/*[in]*/ MEMBERID memid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
		size_t pvInstance_size_in_bytes;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ PVOID pvInstance,
		/*[in]*/ MEMBERID memid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE_PVOID(pvInstance);

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentationValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[out]*/ BSTR* pBstrName;
		/*[out]*/ BSTR* pBstrDocString;
		/*[out]*/ DWORD* pdwHelpContext;
		/*[out]*/ BSTR* pBstrHelpFile;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentation)(
		/*[in]*/ MEMBERID memid,
		/*[out]*/ BSTR* pBstrName,
		/*[out]*/ BSTR* pBstrDocString,
		/*[out]*/ DWORD* pdwHelpContext,
		/*[out]*/ BSTR* pBstrHelpFile)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentation)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_SET_VALIDVALUE_BSTR(pBstrName);

		VSL_SET_VALIDVALUE_BSTR(pBstrDocString);

		VSL_SET_VALIDVALUE(pdwHelpContext);

		VSL_SET_VALIDVALUE_BSTR(pBstrHelpFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDllEntryValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[in]*/ INVOKEKIND invKind;
		/*[out]*/ BSTR* pBstrDllName;
		/*[out]*/ BSTR* pBstrName;
		/*[out]*/ WORD* pwOrdinal;
		HRESULT retValue;
	};

	STDMETHOD(GetDllEntry)(
		/*[in]*/ MEMBERID memid,
		/*[in]*/ INVOKEKIND invKind,
		/*[out]*/ BSTR* pBstrDllName,
		/*[out]*/ BSTR* pBstrName,
		/*[out]*/ WORD* pwOrdinal)
	{
		VSL_DEFINE_MOCK_METHOD(GetDllEntry)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(invKind);

		VSL_SET_VALIDVALUE_BSTR(pBstrDllName);

		VSL_SET_VALIDVALUE_BSTR(pBstrName);

		VSL_SET_VALIDVALUE(pwOrdinal);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRefTypeInfoValidValues
	{
		/*[in]*/ HREFTYPE hRefType;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetRefTypeInfo)(
		/*[in]*/ HREFTYPE hRefType,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetRefTypeInfo)

		VSL_CHECK_VALIDVALUE(hRefType);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddressOfMemberValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[in]*/ INVOKEKIND invKind;
		/*[out]*/ PVOID* ppv;
		HRESULT retValue;
	};

	STDMETHOD(AddressOfMember)(
		/*[in]*/ MEMBERID memid,
		/*[in]*/ INVOKEKIND invKind,
		/*[out]*/ PVOID* ppv)
	{
		VSL_DEFINE_MOCK_METHOD(AddressOfMember)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(invKind);

		VSL_SET_VALIDVALUE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateInstanceValidValues
	{
		/*[in]*/ IUnknown* pUnkOuter;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ PVOID* ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstance)(
		/*[in]*/ IUnknown* pUnkOuter,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ PVOID* ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstance)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkOuter);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMopsValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[out]*/ BSTR* pBstrMops;
		HRESULT retValue;
	};

	STDMETHOD(GetMops)(
		/*[in]*/ MEMBERID memid,
		/*[out]*/ BSTR* pBstrMops)
	{
		VSL_DEFINE_MOCK_METHOD(GetMops)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_SET_VALIDVALUE_BSTR(pBstrMops);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContainingTypeLibValidValues
	{
		/*[out]*/ ITypeLib** ppTLib;
		/*[out]*/ UINT* pIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetContainingTypeLib)(
		/*[out]*/ ITypeLib** ppTLib,
		/*[out]*/ UINT* pIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetContainingTypeLib)

		VSL_SET_VALIDVALUE_INTERFACE(ppTLib);

		VSL_SET_VALIDVALUE(pIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseTypeAttrValidValues
	{
		/*[in]*/ TYPEATTR* pTypeAttr;
	};

	virtual void _stdcall ReleaseTypeAttr(
		/*[in]*/ TYPEATTR* pTypeAttr)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseTypeAttr)

		VSL_CHECK_VALIDVALUE_POINTER(pTypeAttr);

	}
	struct ReleaseFuncDescValidValues
	{
		/*[in]*/ FUNCDESC* pFuncDesc;
	};

	virtual void _stdcall ReleaseFuncDesc(
		/*[in]*/ FUNCDESC* pFuncDesc)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseFuncDesc)

		VSL_CHECK_VALIDVALUE_POINTER(pFuncDesc);

	}
	struct ReleaseVarDescValidValues
	{
		/*[in]*/ VARDESC* pVarDesc;
	};

	virtual void _stdcall ReleaseVarDesc(
		/*[in]*/ VARDESC* pVarDesc)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseVarDesc)

		VSL_CHECK_VALIDVALUE_POINTER(pVarDesc);

	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
