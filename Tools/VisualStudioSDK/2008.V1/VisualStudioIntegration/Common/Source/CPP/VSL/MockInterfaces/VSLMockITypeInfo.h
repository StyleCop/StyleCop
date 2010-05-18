/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITypeInfoNotImpl :
	public ITypeInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeInfoNotImpl)

public:

	typedef ITypeInfo Interface;

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

class ITypeInfoMockImpl :
	public ITypeInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeInfoMockImpl)

	typedef ITypeInfo Interface;
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

#endif // ITYPEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
