/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef FILEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define FILEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class FilePropertiesNotImpl :
	public FileProperties
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(FilePropertiesNotImpl)

public:

	typedef FileProperties Interface;

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FileName)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_FileName)(
		/*[in]*/ BSTR /*bstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extension)(
		/*[out,retval]*/ BSTR* /*pbstrExtension*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Filesize)(
		/*[out,retval]*/ unsigned long* /*pdwSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_LocalPath)(
		/*[out,retval]*/ BSTR* /*pbstrLocalPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FullPath)(
		/*[out,retval]*/ BSTR* /*pbstrFullPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_URL)(
		/*[out,retval]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_HTMLTitle)(
		/*[out,retval]*/ BSTR* /*pbstrTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Author)(
		/*[out,retval]*/ BSTR* /*pbstrTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DateCreated)(
		/*[out,retval]*/ BSTR* /*pbstrDateCreated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DateModified)(
		/*[out,retval]*/ BSTR* /*pbstrDateCreated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ModifiedBy)(
		/*[out,retval]*/ BSTR* /*pbstrDateCreated*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SubType)(
		/*[out,retval]*/ BSTR* /*pbstrSubType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_SubType)(
		/*[in]*/ BSTR /*bstrSubType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR /*ExtenderName*/,
		/*[out,retval]*/ IDispatch** /*Extender*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* /*ExtenderNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* /*pRetval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_BuildAction)(
		/*[out,retval]*/ prjBuildAction* /*pbuildAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_BuildAction)(
		/*[in]*/ prjBuildAction /*buildAction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CustomTool)(
		/*[out,retval]*/ BSTR* /*pbstrCustomTool*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_CustomTool)(
		/*[in]*/ BSTR /*bstrCustomTool*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CustomToolNamespace)(
		/*[out,retval]*/ BSTR* /*pbstrCustomToolNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_CustomToolNamespace)(
		/*[in]*/ BSTR /*bstrCustomToolNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CustomToolOutput)(
		/*[out,retval]*/ BSTR* /*pbstrCustomToolOutput*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsCustomToolOutput)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIsCustomToolOutput*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsDependentFile)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIsDepedentFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsLink)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIsLinkFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsDesignTimeBuildInput)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIsDesignTimeBuildInput*/)VSL_STDMETHOD_NOTIMPL

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

class FilePropertiesMockImpl :
	public FileProperties,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(FilePropertiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(FilePropertiesMockImpl)

	typedef FileProperties Interface;
	struct get___idValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get___id)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FileNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_FileName)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_FileName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_FileNameValidValues
	{
		/*[in]*/ BSTR bstrName;
		HRESULT retValue;
	};

	STDMETHOD(put_FileName)(
		/*[in]*/ BSTR bstrName)
	{
		VSL_DEFINE_MOCK_METHOD(put_FileName)

		VSL_CHECK_VALIDVALUE_BSTR(bstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtensionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrExtension;
		HRESULT retValue;
	};

	STDMETHOD(get_Extension)(
		/*[out,retval]*/ BSTR* pbstrExtension)
	{
		VSL_DEFINE_MOCK_METHOD(get_Extension)

		VSL_SET_VALIDVALUE_BSTR(pbstrExtension);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FilesizeValidValues
	{
		/*[out,retval]*/ unsigned long* pdwSize;
		HRESULT retValue;
	};

	STDMETHOD(get_Filesize)(
		/*[out,retval]*/ unsigned long* pdwSize)
	{
		VSL_DEFINE_MOCK_METHOD(get_Filesize)

		VSL_SET_VALIDVALUE(pdwSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_LocalPathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrLocalPath;
		HRESULT retValue;
	};

	STDMETHOD(get_LocalPath)(
		/*[out,retval]*/ BSTR* pbstrLocalPath)
	{
		VSL_DEFINE_MOCK_METHOD(get_LocalPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrLocalPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FullPathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFullPath;
		HRESULT retValue;
	};

	STDMETHOD(get_FullPath)(
		/*[out,retval]*/ BSTR* pbstrFullPath)
	{
		VSL_DEFINE_MOCK_METHOD(get_FullPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrFullPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_URLValidValues
	{
		/*[out,retval]*/ BSTR* pbstrURL;
		HRESULT retValue;
	};

	STDMETHOD(get_URL)(
		/*[out,retval]*/ BSTR* pbstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_URL)

		VSL_SET_VALIDVALUE_BSTR(pbstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_HTMLTitleValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTitle;
		HRESULT retValue;
	};

	STDMETHOD(get_HTMLTitle)(
		/*[out,retval]*/ BSTR* pbstrTitle)
	{
		VSL_DEFINE_MOCK_METHOD(get_HTMLTitle)

		VSL_SET_VALIDVALUE_BSTR(pbstrTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AuthorValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTitle;
		HRESULT retValue;
	};

	STDMETHOD(get_Author)(
		/*[out,retval]*/ BSTR* pbstrTitle)
	{
		VSL_DEFINE_MOCK_METHOD(get_Author)

		VSL_SET_VALIDVALUE_BSTR(pbstrTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DateCreatedValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDateCreated;
		HRESULT retValue;
	};

	STDMETHOD(get_DateCreated)(
		/*[out,retval]*/ BSTR* pbstrDateCreated)
	{
		VSL_DEFINE_MOCK_METHOD(get_DateCreated)

		VSL_SET_VALIDVALUE_BSTR(pbstrDateCreated);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DateModifiedValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDateCreated;
		HRESULT retValue;
	};

	STDMETHOD(get_DateModified)(
		/*[out,retval]*/ BSTR* pbstrDateCreated)
	{
		VSL_DEFINE_MOCK_METHOD(get_DateModified)

		VSL_SET_VALIDVALUE_BSTR(pbstrDateCreated);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ModifiedByValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDateCreated;
		HRESULT retValue;
	};

	STDMETHOD(get_ModifiedBy)(
		/*[out,retval]*/ BSTR* pbstrDateCreated)
	{
		VSL_DEFINE_MOCK_METHOD(get_ModifiedBy)

		VSL_SET_VALIDVALUE_BSTR(pbstrDateCreated);

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
		/*[in]*/ BSTR bstrSubType;
		HRESULT retValue;
	};

	STDMETHOD(put_SubType)(
		/*[in]*/ BSTR bstrSubType)
	{
		VSL_DEFINE_MOCK_METHOD(put_SubType)

		VSL_CHECK_VALIDVALUE_BSTR(bstrSubType);

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
	struct get_BuildActionValidValues
	{
		/*[out,retval]*/ prjBuildAction* pbuildAction;
		HRESULT retValue;
	};

	STDMETHOD(get_BuildAction)(
		/*[out,retval]*/ prjBuildAction* pbuildAction)
	{
		VSL_DEFINE_MOCK_METHOD(get_BuildAction)

		VSL_SET_VALIDVALUE(pbuildAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_BuildActionValidValues
	{
		/*[in]*/ prjBuildAction buildAction;
		HRESULT retValue;
	};

	STDMETHOD(put_BuildAction)(
		/*[in]*/ prjBuildAction buildAction)
	{
		VSL_DEFINE_MOCK_METHOD(put_BuildAction)

		VSL_CHECK_VALIDVALUE(buildAction);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CustomToolValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCustomTool;
		HRESULT retValue;
	};

	STDMETHOD(get_CustomTool)(
		/*[out,retval]*/ BSTR* pbstrCustomTool)
	{
		VSL_DEFINE_MOCK_METHOD(get_CustomTool)

		VSL_SET_VALIDVALUE_BSTR(pbstrCustomTool);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CustomToolValidValues
	{
		/*[in]*/ BSTR bstrCustomTool;
		HRESULT retValue;
	};

	STDMETHOD(put_CustomTool)(
		/*[in]*/ BSTR bstrCustomTool)
	{
		VSL_DEFINE_MOCK_METHOD(put_CustomTool)

		VSL_CHECK_VALIDVALUE_BSTR(bstrCustomTool);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CustomToolNamespaceValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCustomToolNamespace;
		HRESULT retValue;
	};

	STDMETHOD(get_CustomToolNamespace)(
		/*[out,retval]*/ BSTR* pbstrCustomToolNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(get_CustomToolNamespace)

		VSL_SET_VALIDVALUE_BSTR(pbstrCustomToolNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CustomToolNamespaceValidValues
	{
		/*[in]*/ BSTR bstrCustomToolNamespace;
		HRESULT retValue;
	};

	STDMETHOD(put_CustomToolNamespace)(
		/*[in]*/ BSTR bstrCustomToolNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(put_CustomToolNamespace)

		VSL_CHECK_VALIDVALUE_BSTR(bstrCustomToolNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CustomToolOutputValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCustomToolOutput;
		HRESULT retValue;
	};

	STDMETHOD(get_CustomToolOutput)(
		/*[out,retval]*/ BSTR* pbstrCustomToolOutput)
	{
		VSL_DEFINE_MOCK_METHOD(get_CustomToolOutput)

		VSL_SET_VALIDVALUE_BSTR(pbstrCustomToolOutput);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsCustomToolOutputValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIsCustomToolOutput;
		HRESULT retValue;
	};

	STDMETHOD(get_IsCustomToolOutput)(
		/*[out,retval]*/ VARIANT_BOOL* pbIsCustomToolOutput)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsCustomToolOutput)

		VSL_SET_VALIDVALUE(pbIsCustomToolOutput);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsDependentFileValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIsDepedentFile;
		HRESULT retValue;
	};

	STDMETHOD(get_IsDependentFile)(
		/*[out,retval]*/ VARIANT_BOOL* pbIsDepedentFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsDependentFile)

		VSL_SET_VALIDVALUE(pbIsDepedentFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsLinkValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIsLinkFile;
		HRESULT retValue;
	};

	STDMETHOD(get_IsLink)(
		/*[out,retval]*/ VARIANT_BOOL* pbIsLinkFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsLink)

		VSL_SET_VALIDVALUE(pbIsLinkFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsDesignTimeBuildInputValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIsDesignTimeBuildInput;
		HRESULT retValue;
	};

	STDMETHOD(get_IsDesignTimeBuildInput)(
		/*[out,retval]*/ VARIANT_BOOL* pbIsDesignTimeBuildInput)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsDesignTimeBuildInput)

		VSL_SET_VALIDVALUE(pbIsDesignTimeBuildInput);

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

#endif // FILEPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
