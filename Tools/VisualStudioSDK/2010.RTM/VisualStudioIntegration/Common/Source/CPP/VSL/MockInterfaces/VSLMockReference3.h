/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef REFERENCE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define REFERENCE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class Reference3NotImpl :
	public Reference3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(Reference3NotImpl)

public:

	typedef Reference3 Interface;

	STDMETHOD(get_SpecificVersion)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbSpecificVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_SpecificVersion)(
		/*[in]*/ VARIANT_BOOL /*SpecificVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SubType)(
		/*[out,retval]*/ BSTR* /*pbstrSubType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_SubType)(
		/*[in]*/ BSTR /*SubType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Isolated)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIsolated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Isolated)(
		/*[in]*/ VARIANT_BOOL /*Isolated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Aliases)(
		/*[out,retval]*/ BSTR* /*pbstrAliases*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Aliases)(
		/*[in]*/ BSTR /*Aliases*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RefType)(
		/*[out,retval]*/ PROJECTREFERENCETYPE* /*pProjRefType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AutoReferenced)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbAutoReferenced*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Resolved)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbResolved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RuntimeVersion)(
		/*[out,retval]*/ BSTR* /*pbstrVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** /*ppDTE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Collection)(
		/*[out,retval]*/ References** /*ppProjectReferences*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ContainingProject)(
		/*[out,retval]*/ Project** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Remove)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Name)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Type)(
		/*[out,retval]*/ prjReferenceType* /*pType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Identity)(
		/*[out,retval]*/ BSTR* /*pbstrIdentity*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Path)(
		/*[out,retval]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Description)(
		/*[out,retval]*/ BSTR* /*pbstrDesc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Culture)(
		/*[out,retval]*/ BSTR* /*pbstrCulture*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_MajorVersion)(
		/*[out,retval]*/ long* /*plMajorVer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_MinorVersion)(
		/*[out,retval]*/ long* /*plMinorVer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RevisionNumber)(
		/*[out,retval]*/ long* /*plRevNo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_BuildNumber)(
		/*[out,retval]*/ long* /*plBuildNo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StrongName)(
		/*[out,retval]*/ VARIANT_BOOL* /*pfStrongName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SourceProject)(
		/*[out,retval]*/ Project** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CopyLocal)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbCopyLocal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_CopyLocal)(
		/*[in]*/ VARIANT_BOOL /*bCopyLocal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR /*ExtenderName*/,
		/*[out,retval]*/ IDispatch** /*Extender*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* /*ExtenderNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* /*pRetval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_PublicKeyToken)(
		/*[out,retval]*/ BSTR* /*pbstrPublicKeyToken*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Version)(
		/*[out,retval]*/ BSTR* /*pbstrVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,size_is(cNames)]*/ DISPID* /*rgDispId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID /*dispIdMember*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL
};

class Reference3MockImpl :
	public Reference3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(Reference3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(Reference3MockImpl)

	typedef Reference3 Interface;
	struct get_SpecificVersionValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbSpecificVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_SpecificVersion)(
		/*[out,retval]*/ VARIANT_BOOL* pbSpecificVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_SpecificVersion)

		VSL_SET_VALIDVALUE(pbSpecificVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_SpecificVersionValidValues
	{
		/*[in]*/ VARIANT_BOOL SpecificVersion;
		HRESULT retValue;
	};

	STDMETHOD(put_SpecificVersion)(
		/*[in]*/ VARIANT_BOOL SpecificVersion)
	{
		VSL_DEFINE_MOCK_METHOD(put_SpecificVersion)

		VSL_CHECK_VALIDVALUE(SpecificVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SubTypeValidValues
	{
		/*[out,retval]*/ BSTR* pbstrSubType;
		HRESULT retValue;
	};

	STDMETHOD(get_SubType)(
		/*[out,retval]*/ BSTR* pbstrSubType)
	{
		VSL_DEFINE_MOCK_METHOD(get_SubType)

		VSL_SET_VALIDVALUE_BSTR(pbstrSubType);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_SubTypeValidValues
	{
		/*[in]*/ BSTR SubType;
		HRESULT retValue;
	};

	STDMETHOD(put_SubType)(
		/*[in]*/ BSTR SubType)
	{
		VSL_DEFINE_MOCK_METHOD(put_SubType)

		VSL_CHECK_VALIDVALUE_BSTR(SubType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsolatedValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIsolated;
		HRESULT retValue;
	};

	STDMETHOD(get_Isolated)(
		/*[out,retval]*/ VARIANT_BOOL* pbIsolated)
	{
		VSL_DEFINE_MOCK_METHOD(get_Isolated)

		VSL_SET_VALIDVALUE(pbIsolated);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_IsolatedValidValues
	{
		/*[in]*/ VARIANT_BOOL Isolated;
		HRESULT retValue;
	};

	STDMETHOD(put_Isolated)(
		/*[in]*/ VARIANT_BOOL Isolated)
	{
		VSL_DEFINE_MOCK_METHOD(put_Isolated)

		VSL_CHECK_VALIDVALUE(Isolated);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AliasesValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAliases;
		HRESULT retValue;
	};

	STDMETHOD(get_Aliases)(
		/*[out,retval]*/ BSTR* pbstrAliases)
	{
		VSL_DEFINE_MOCK_METHOD(get_Aliases)

		VSL_SET_VALIDVALUE_BSTR(pbstrAliases);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AliasesValidValues
	{
		/*[in]*/ BSTR Aliases;
		HRESULT retValue;
	};

	STDMETHOD(put_Aliases)(
		/*[in]*/ BSTR Aliases)
	{
		VSL_DEFINE_MOCK_METHOD(put_Aliases)

		VSL_CHECK_VALIDVALUE_BSTR(Aliases);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RefTypeValidValues
	{
		/*[out,retval]*/ PROJECTREFERENCETYPE* pProjRefType;
		HRESULT retValue;
	};

	STDMETHOD(get_RefType)(
		/*[out,retval]*/ PROJECTREFERENCETYPE* pProjRefType)
	{
		VSL_DEFINE_MOCK_METHOD(get_RefType)

		VSL_SET_VALIDVALUE(pProjRefType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AutoReferencedValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbAutoReferenced;
		HRESULT retValue;
	};

	STDMETHOD(get_AutoReferenced)(
		/*[out,retval]*/ VARIANT_BOOL* pbAutoReferenced)
	{
		VSL_DEFINE_MOCK_METHOD(get_AutoReferenced)

		VSL_SET_VALIDVALUE(pbAutoReferenced);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ResolvedValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbResolved;
		HRESULT retValue;
	};

	STDMETHOD(get_Resolved)(
		/*[out,retval]*/ VARIANT_BOOL* pbResolved)
	{
		VSL_DEFINE_MOCK_METHOD(get_Resolved)

		VSL_SET_VALIDVALUE(pbResolved);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RuntimeVersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_RuntimeVersion)(
		/*[out,retval]*/ BSTR* pbstrVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_RuntimeVersion)

		VSL_SET_VALIDVALUE_BSTR(pbstrVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DTEValidValues
	{
		/*[out,retval]*/ DTE** ppDTE;
		HRESULT retValue;
	};

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** ppDTE)
	{
		VSL_DEFINE_MOCK_METHOD(get_DTE)

		VSL_SET_VALIDVALUE(ppDTE);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CollectionValidValues
	{
		/*[out,retval]*/ References** ppProjectReferences;
		HRESULT retValue;
	};

	STDMETHOD(get_Collection)(
		/*[out,retval]*/ References** ppProjectReferences)
	{
		VSL_DEFINE_MOCK_METHOD(get_Collection)

		VSL_SET_VALIDVALUE_INTERFACE(ppProjectReferences);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ContainingProjectValidValues
	{
		/*[out,retval]*/ Project** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(get_ContainingProject)(
		/*[out,retval]*/ Project** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(get_ContainingProject)

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Remove)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Remove)

		VSL_RETURN_VALIDVALUES();
	}
	struct get_NameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_Name)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_Name)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TypeValidValues
	{
		/*[out,retval]*/ prjReferenceType* pType;
		HRESULT retValue;
	};

	STDMETHOD(get_Type)(
		/*[out,retval]*/ prjReferenceType* pType)
	{
		VSL_DEFINE_MOCK_METHOD(get_Type)

		VSL_SET_VALIDVALUE(pType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IdentityValidValues
	{
		/*[out,retval]*/ BSTR* pbstrIdentity;
		HRESULT retValue;
	};

	STDMETHOD(get_Identity)(
		/*[out,retval]*/ BSTR* pbstrIdentity)
	{
		VSL_DEFINE_MOCK_METHOD(get_Identity)

		VSL_SET_VALIDVALUE_BSTR(pbstrIdentity);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(get_Path)(
		/*[out,retval]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(get_Path)

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DescriptionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDesc;
		HRESULT retValue;
	};

	STDMETHOD(get_Description)(
		/*[out,retval]*/ BSTR* pbstrDesc)
	{
		VSL_DEFINE_MOCK_METHOD(get_Description)

		VSL_SET_VALIDVALUE_BSTR(pbstrDesc);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CultureValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCulture;
		HRESULT retValue;
	};

	STDMETHOD(get_Culture)(
		/*[out,retval]*/ BSTR* pbstrCulture)
	{
		VSL_DEFINE_MOCK_METHOD(get_Culture)

		VSL_SET_VALIDVALUE_BSTR(pbstrCulture);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_MajorVersionValidValues
	{
		/*[out,retval]*/ long* plMajorVer;
		HRESULT retValue;
	};

	STDMETHOD(get_MajorVersion)(
		/*[out,retval]*/ long* plMajorVer)
	{
		VSL_DEFINE_MOCK_METHOD(get_MajorVersion)

		VSL_SET_VALIDVALUE(plMajorVer);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_MinorVersionValidValues
	{
		/*[out,retval]*/ long* plMinorVer;
		HRESULT retValue;
	};

	STDMETHOD(get_MinorVersion)(
		/*[out,retval]*/ long* plMinorVer)
	{
		VSL_DEFINE_MOCK_METHOD(get_MinorVersion)

		VSL_SET_VALIDVALUE(plMinorVer);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RevisionNumberValidValues
	{
		/*[out,retval]*/ long* plRevNo;
		HRESULT retValue;
	};

	STDMETHOD(get_RevisionNumber)(
		/*[out,retval]*/ long* plRevNo)
	{
		VSL_DEFINE_MOCK_METHOD(get_RevisionNumber)

		VSL_SET_VALIDVALUE(plRevNo);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_BuildNumberValidValues
	{
		/*[out,retval]*/ long* plBuildNo;
		HRESULT retValue;
	};

	STDMETHOD(get_BuildNumber)(
		/*[out,retval]*/ long* plBuildNo)
	{
		VSL_DEFINE_MOCK_METHOD(get_BuildNumber)

		VSL_SET_VALIDVALUE(plBuildNo);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StrongNameValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pfStrongName;
		HRESULT retValue;
	};

	STDMETHOD(get_StrongName)(
		/*[out,retval]*/ VARIANT_BOOL* pfStrongName)
	{
		VSL_DEFINE_MOCK_METHOD(get_StrongName)

		VSL_SET_VALIDVALUE(pfStrongName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SourceProjectValidValues
	{
		/*[out,retval]*/ Project** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(get_SourceProject)(
		/*[out,retval]*/ Project** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(get_SourceProject)

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CopyLocalValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbCopyLocal;
		HRESULT retValue;
	};

	STDMETHOD(get_CopyLocal)(
		/*[out,retval]*/ VARIANT_BOOL* pbCopyLocal)
	{
		VSL_DEFINE_MOCK_METHOD(get_CopyLocal)

		VSL_SET_VALIDVALUE(pbCopyLocal);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CopyLocalValidValues
	{
		/*[in]*/ VARIANT_BOOL bCopyLocal;
		HRESULT retValue;
	};

	STDMETHOD(put_CopyLocal)(
		/*[in]*/ VARIANT_BOOL bCopyLocal)
	{
		VSL_DEFINE_MOCK_METHOD(put_CopyLocal)

		VSL_CHECK_VALIDVALUE(bCopyLocal);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderValidValues
	{
		/*[in]*/ BSTR ExtenderName;
		/*[out,retval]*/ IDispatch** Extender;
		HRESULT retValue;
	};

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR ExtenderName,
		/*[out,retval]*/ IDispatch** Extender)
	{
		VSL_DEFINE_MOCK_METHOD(get_Extender)

		VSL_CHECK_VALIDVALUE_BSTR(ExtenderName);

		VSL_SET_VALIDVALUE_INTERFACE(Extender);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderNamesValidValues
	{
		/*[out,retval]*/ VARIANT* ExtenderNames;
		HRESULT retValue;
	};

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* ExtenderNames)
	{
		VSL_DEFINE_MOCK_METHOD(get_ExtenderNames)

		VSL_SET_VALIDVALUE_VARIANT(ExtenderNames);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderCATIDValidValues
	{
		/*[out,retval]*/ BSTR* pRetval;
		HRESULT retValue;
	};

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* pRetval)
	{
		VSL_DEFINE_MOCK_METHOD(get_ExtenderCATID)

		VSL_SET_VALIDVALUE_BSTR(pRetval);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PublicKeyTokenValidValues
	{
		/*[out,retval]*/ BSTR* pbstrPublicKeyToken;
		HRESULT retValue;
	};

	STDMETHOD(get_PublicKeyToken)(
		/*[out,retval]*/ BSTR* pbstrPublicKeyToken)
	{
		VSL_DEFINE_MOCK_METHOD(get_PublicKeyToken)

		VSL_SET_VALIDVALUE_BSTR(pbstrPublicKeyToken);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_VersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_Version)(
		/*[out,retval]*/ BSTR* pbstrVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_Version)

		VSL_SET_VALIDVALUE_BSTR(pbstrVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoCountValidValues
	{
		/*[out]*/ UINT* pctinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* pctinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoCount)

		VSL_SET_VALIDVALUE(pctinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT iTInfo;
		/*[in]*/ LCID lcid;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT iTInfo,
		/*[in]*/ LCID lcid,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(iTInfo);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[in]*/ LCID lcid;
		/*[out,size_is(cNames)]*/ DISPID* rgDispId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID riid,
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[in]*/ LCID lcid,
		/*[out,size_is(cNames)]*/ DISPID* rgDispId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_MEMCPY(rgDispId, cNames*sizeof(rgDispId[0]), validValues.cNames*sizeof(validValues.rgDispId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ DISPID dispIdMember;
		/*[in]*/ REFIID riid;
		/*[in]*/ LCID lcid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID dispIdMember,
		/*[in]*/ REFIID riid,
		/*[in]*/ LCID lcid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE(dispIdMember);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // REFERENCE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
