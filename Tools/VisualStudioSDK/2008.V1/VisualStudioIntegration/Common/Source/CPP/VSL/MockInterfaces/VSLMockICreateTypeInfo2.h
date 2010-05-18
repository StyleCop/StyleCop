/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICREATETYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICREATETYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ICreateTypeInfo2NotImpl :
	public ICreateTypeInfo2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateTypeInfo2NotImpl)

public:

	typedef ICreateTypeInfo2 Interface;

	STDMETHOD(DeleteFuncDesc)(
		/*[in]*/ UINT /*index*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteFuncDescByMemId)(
		/*[in]*/ MEMBERID /*memid*/,
		/*[in]*/ INVOKEKIND /*invKind*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteVarDesc)(
		/*[in]*/ UINT /*index*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteVarDescByMemId)(
		/*[in]*/ MEMBERID /*memid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteImplType)(
		/*[in]*/ UINT /*index*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCustData)(
		/*[in]*/ REFGUID /*guid*/,
		/*[in]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFuncCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[in]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetParamCustData)(
		/*[in]*/ UINT /*indexFunc*/,
		/*[in]*/ UINT /*indexParam*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[in]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVarCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[in]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetImplTypeCustData)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ REFGUID /*guid*/,
		/*[in]*/ VARIANT* /*pVarVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpStringContext)(
		/*[in]*/ ULONG /*dwHelpStringContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFuncHelpStringContext)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ ULONG /*dwHelpStringContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVarHelpStringContext)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ ULONG /*dwHelpStringContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invalidate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetName)(
		/*[in]*/ LPOLESTR /*szName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetGuid)(
		/*[in]*/ REFGUID /*guid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTypeFlags)(
		/*[in]*/ UINT /*uTypeFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDocString)(
		/*[in]*/ LPOLESTR /*pStrDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHelpContext)(
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVersion)(
		/*[in]*/ WORD /*wMajorVerNum*/,
		/*[in]*/ WORD /*wMinorVerNum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddRefTypeInfo)(
		/*[in]*/ ITypeInfo* /*pTInfo*/,
		/*[in]*/ HREFTYPE* /*phRefType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddFuncDesc)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ FUNCDESC* /*pFuncDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddImplType)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ HREFTYPE /*hRefType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetImplTypeFlags)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ INT /*implTypeFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAlignment)(
		/*[in]*/ WORD /*cbAlignment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSchema)(
		/*[in]*/ LPOLESTR /*pStrSchema*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddVarDesc)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ VARDESC* /*pVarDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFuncAndParamNames)(
		/*[in]*/ UINT /*index*/,
		/*[in,size_is((UINT)cNames),in]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVarName)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ LPOLESTR /*szName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTypeDescAlias)(
		/*[in]*/ TYPEDESC* /*pTDescAlias*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DefineFuncAsDllEntry)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ LPOLESTR /*szDllName*/,
		/*[in]*/ LPOLESTR /*szProcName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFuncDocString)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ LPOLESTR /*szDocString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVarDocString)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ LPOLESTR /*szDocString*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFuncHelpContext)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVarHelpContext)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMops)(
		/*[in]*/ UINT /*index*/,
		/*[in]*/ BSTR /*bstrMops*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetTypeIdldesc)(
		/*[in]*/ IDLDESC* /*pIdlDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LayOut)()VSL_STDMETHOD_NOTIMPL
};

class ICreateTypeInfo2MockImpl :
	public ICreateTypeInfo2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICreateTypeInfo2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICreateTypeInfo2MockImpl)

	typedef ICreateTypeInfo2 Interface;
	struct DeleteFuncDescValidValues
	{
		/*[in]*/ UINT index;
		HRESULT retValue;
	};

	STDMETHOD(DeleteFuncDesc)(
		/*[in]*/ UINT index)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteFuncDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteFuncDescByMemIdValidValues
	{
		/*[in]*/ MEMBERID memid;
		/*[in]*/ INVOKEKIND invKind;
		HRESULT retValue;
	};

	STDMETHOD(DeleteFuncDescByMemId)(
		/*[in]*/ MEMBERID memid,
		/*[in]*/ INVOKEKIND invKind)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteFuncDescByMemId)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_CHECK_VALIDVALUE(invKind);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteVarDescValidValues
	{
		/*[in]*/ UINT index;
		HRESULT retValue;
	};

	STDMETHOD(DeleteVarDesc)(
		/*[in]*/ UINT index)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteVarDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteVarDescByMemIdValidValues
	{
		/*[in]*/ MEMBERID memid;
		HRESULT retValue;
	};

	STDMETHOD(DeleteVarDescByMemId)(
		/*[in]*/ MEMBERID memid)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteVarDescByMemId)

		VSL_CHECK_VALIDVALUE(memid);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteImplTypeValidValues
	{
		/*[in]*/ UINT index;
		HRESULT retValue;
	};

	STDMETHOD(DeleteImplType)(
		/*[in]*/ UINT index)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteImplType)

		VSL_CHECK_VALIDVALUE(index);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCustDataValidValues
	{
		/*[in]*/ REFGUID guid;
		/*[in]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(SetCustData)(
		/*[in]*/ REFGUID guid,
		/*[in]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetCustData)

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_POINTER(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFuncCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[in]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(SetFuncCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[in]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetFuncCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_POINTER(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetParamCustDataValidValues
	{
		/*[in]*/ UINT indexFunc;
		/*[in]*/ UINT indexParam;
		/*[in]*/ REFGUID guid;
		/*[in]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(SetParamCustData)(
		/*[in]*/ UINT indexFunc,
		/*[in]*/ UINT indexParam,
		/*[in]*/ REFGUID guid,
		/*[in]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetParamCustData)

		VSL_CHECK_VALIDVALUE(indexFunc);

		VSL_CHECK_VALIDVALUE(indexParam);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_POINTER(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVarCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[in]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(SetVarCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[in]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetVarCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_POINTER(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetImplTypeCustDataValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ REFGUID guid;
		/*[in]*/ VARIANT* pVarVal;
		HRESULT retValue;
	};

	STDMETHOD(SetImplTypeCustData)(
		/*[in]*/ UINT index,
		/*[in]*/ REFGUID guid,
		/*[in]*/ VARIANT* pVarVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetImplTypeCustData)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(guid);

		VSL_CHECK_VALIDVALUE_POINTER(pVarVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHelpStringContextValidValues
	{
		/*[in]*/ ULONG dwHelpStringContext;
		HRESULT retValue;
	};

	STDMETHOD(SetHelpStringContext)(
		/*[in]*/ ULONG dwHelpStringContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetHelpStringContext)

		VSL_CHECK_VALIDVALUE(dwHelpStringContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFuncHelpStringContextValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ ULONG dwHelpStringContext;
		HRESULT retValue;
	};

	STDMETHOD(SetFuncHelpStringContext)(
		/*[in]*/ UINT index,
		/*[in]*/ ULONG dwHelpStringContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetFuncHelpStringContext)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(dwHelpStringContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVarHelpStringContextValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ ULONG dwHelpStringContext;
		HRESULT retValue;
	};

	STDMETHOD(SetVarHelpStringContext)(
		/*[in]*/ UINT index,
		/*[in]*/ ULONG dwHelpStringContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetVarHelpStringContext)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(dwHelpStringContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvalidateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Invalidate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Invalidate)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNameValidValues
	{
		/*[in]*/ LPOLESTR szName;
		HRESULT retValue;
	};

	STDMETHOD(SetName)(
		/*[in]*/ LPOLESTR szName)
	{
		VSL_DEFINE_MOCK_METHOD(SetName)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetGuidValidValues
	{
		/*[in]*/ REFGUID guid;
		HRESULT retValue;
	};

	STDMETHOD(SetGuid)(
		/*[in]*/ REFGUID guid)
	{
		VSL_DEFINE_MOCK_METHOD(SetGuid)

		VSL_CHECK_VALIDVALUE(guid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTypeFlagsValidValues
	{
		/*[in]*/ UINT uTypeFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetTypeFlags)(
		/*[in]*/ UINT uTypeFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetTypeFlags)

		VSL_CHECK_VALIDVALUE(uTypeFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDocStringValidValues
	{
		/*[in]*/ LPOLESTR pStrDoc;
		HRESULT retValue;
	};

	STDMETHOD(SetDocString)(
		/*[in]*/ LPOLESTR pStrDoc)
	{
		VSL_DEFINE_MOCK_METHOD(SetDocString)

		VSL_CHECK_VALIDVALUE_STRINGW(pStrDoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHelpContextValidValues
	{
		/*[in]*/ DWORD dwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(SetHelpContext)(
		/*[in]*/ DWORD dwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetHelpContext)

		VSL_CHECK_VALIDVALUE(dwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVersionValidValues
	{
		/*[in]*/ WORD wMajorVerNum;
		/*[in]*/ WORD wMinorVerNum;
		HRESULT retValue;
	};

	STDMETHOD(SetVersion)(
		/*[in]*/ WORD wMajorVerNum,
		/*[in]*/ WORD wMinorVerNum)
	{
		VSL_DEFINE_MOCK_METHOD(SetVersion)

		VSL_CHECK_VALIDVALUE(wMajorVerNum);

		VSL_CHECK_VALIDVALUE(wMinorVerNum);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddRefTypeInfoValidValues
	{
		/*[in]*/ ITypeInfo* pTInfo;
		/*[in]*/ HREFTYPE* phRefType;
		HRESULT retValue;
	};

	STDMETHOD(AddRefTypeInfo)(
		/*[in]*/ ITypeInfo* pTInfo,
		/*[in]*/ HREFTYPE* phRefType)
	{
		VSL_DEFINE_MOCK_METHOD(AddRefTypeInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTInfo);

		VSL_CHECK_VALIDVALUE_POINTER(phRefType);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddFuncDescValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ FUNCDESC* pFuncDesc;
		HRESULT retValue;
	};

	STDMETHOD(AddFuncDesc)(
		/*[in]*/ UINT index,
		/*[in]*/ FUNCDESC* pFuncDesc)
	{
		VSL_DEFINE_MOCK_METHOD(AddFuncDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_POINTER(pFuncDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddImplTypeValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ HREFTYPE hRefType;
		HRESULT retValue;
	};

	STDMETHOD(AddImplType)(
		/*[in]*/ UINT index,
		/*[in]*/ HREFTYPE hRefType)
	{
		VSL_DEFINE_MOCK_METHOD(AddImplType)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(hRefType);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetImplTypeFlagsValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ INT implTypeFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetImplTypeFlags)(
		/*[in]*/ UINT index,
		/*[in]*/ INT implTypeFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetImplTypeFlags)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(implTypeFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAlignmentValidValues
	{
		/*[in]*/ WORD cbAlignment;
		HRESULT retValue;
	};

	STDMETHOD(SetAlignment)(
		/*[in]*/ WORD cbAlignment)
	{
		VSL_DEFINE_MOCK_METHOD(SetAlignment)

		VSL_CHECK_VALIDVALUE(cbAlignment);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSchemaValidValues
	{
		/*[in]*/ LPOLESTR pStrSchema;
		HRESULT retValue;
	};

	STDMETHOD(SetSchema)(
		/*[in]*/ LPOLESTR pStrSchema)
	{
		VSL_DEFINE_MOCK_METHOD(SetSchema)

		VSL_CHECK_VALIDVALUE_STRINGW(pStrSchema);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddVarDescValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ VARDESC* pVarDesc;
		HRESULT retValue;
	};

	STDMETHOD(AddVarDesc)(
		/*[in]*/ UINT index,
		/*[in]*/ VARDESC* pVarDesc)
	{
		VSL_DEFINE_MOCK_METHOD(AddVarDesc)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_POINTER(pVarDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFuncAndParamNamesValidValues
	{
		/*[in]*/ UINT index;
		/*[in,size_is((UINT)cNames),in]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		HRESULT retValue;
	};

	STDMETHOD(SetFuncAndParamNames)(
		/*[in]*/ UINT index,
		/*[in,size_is((UINT)cNames),in]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames)
	{
		VSL_DEFINE_MOCK_METHOD(SetFuncAndParamNames)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVarNameValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ LPOLESTR szName;
		HRESULT retValue;
	};

	STDMETHOD(SetVarName)(
		/*[in]*/ UINT index,
		/*[in]*/ LPOLESTR szName)
	{
		VSL_DEFINE_MOCK_METHOD(SetVarName)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTypeDescAliasValidValues
	{
		/*[in]*/ TYPEDESC* pTDescAlias;
		HRESULT retValue;
	};

	STDMETHOD(SetTypeDescAlias)(
		/*[in]*/ TYPEDESC* pTDescAlias)
	{
		VSL_DEFINE_MOCK_METHOD(SetTypeDescAlias)

		VSL_CHECK_VALIDVALUE_POINTER(pTDescAlias);

		VSL_RETURN_VALIDVALUES();
	}
	struct DefineFuncAsDllEntryValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ LPOLESTR szDllName;
		/*[in]*/ LPOLESTR szProcName;
		HRESULT retValue;
	};

	STDMETHOD(DefineFuncAsDllEntry)(
		/*[in]*/ UINT index,
		/*[in]*/ LPOLESTR szDllName,
		/*[in]*/ LPOLESTR szProcName)
	{
		VSL_DEFINE_MOCK_METHOD(DefineFuncAsDllEntry)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_STRINGW(szDllName);

		VSL_CHECK_VALIDVALUE_STRINGW(szProcName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFuncDocStringValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ LPOLESTR szDocString;
		HRESULT retValue;
	};

	STDMETHOD(SetFuncDocString)(
		/*[in]*/ UINT index,
		/*[in]*/ LPOLESTR szDocString)
	{
		VSL_DEFINE_MOCK_METHOD(SetFuncDocString)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_STRINGW(szDocString);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVarDocStringValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ LPOLESTR szDocString;
		HRESULT retValue;
	};

	STDMETHOD(SetVarDocString)(
		/*[in]*/ UINT index,
		/*[in]*/ LPOLESTR szDocString)
	{
		VSL_DEFINE_MOCK_METHOD(SetVarDocString)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_STRINGW(szDocString);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFuncHelpContextValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ DWORD dwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(SetFuncHelpContext)(
		/*[in]*/ UINT index,
		/*[in]*/ DWORD dwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetFuncHelpContext)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(dwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVarHelpContextValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ DWORD dwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(SetVarHelpContext)(
		/*[in]*/ UINT index,
		/*[in]*/ DWORD dwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetVarHelpContext)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE(dwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMopsValidValues
	{
		/*[in]*/ UINT index;
		/*[in]*/ BSTR bstrMops;
		HRESULT retValue;
	};

	STDMETHOD(SetMops)(
		/*[in]*/ UINT index,
		/*[in]*/ BSTR bstrMops)
	{
		VSL_DEFINE_MOCK_METHOD(SetMops)

		VSL_CHECK_VALIDVALUE(index);

		VSL_CHECK_VALIDVALUE_BSTR(bstrMops);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetTypeIdldescValidValues
	{
		/*[in]*/ IDLDESC* pIdlDesc;
		HRESULT retValue;
	};

	STDMETHOD(SetTypeIdldesc)(
		/*[in]*/ IDLDESC* pIdlDesc)
	{
		VSL_DEFINE_MOCK_METHOD(SetTypeIdldesc)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIdlDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct LayOutValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(LayOut)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(LayOut)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICREATETYPEINFO2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
