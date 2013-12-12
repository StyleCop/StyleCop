/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef PROJECTPROPERTIES3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define PROJECTPROPERTIES3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ProjectProperties3NotImpl :
	public ProjectProperties3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ProjectProperties3NotImpl)

public:

	typedef ProjectProperties3 Interface;

	STDMETHOD(get_Title)(
		/*[out,retval]*/ BSTR* /*pbstrTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Title)(
		/*[in]*/ BSTR /*Title*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Description)(
		/*[out,retval]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Description)(
		/*[in]*/ BSTR /*Description*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Company)(
		/*[out,retval]*/ BSTR* /*pbstrCompany*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Company)(
		/*[in]*/ BSTR /*Company*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Product)(
		/*[out,retval]*/ BSTR* /*pbstrProduct*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Product)(
		/*[in]*/ BSTR /*Product*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Copyright)(
		/*[out,retval]*/ BSTR* /*pbstrCopyright*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Copyright)(
		/*[in]*/ BSTR /*Copyright*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Trademark)(
		/*[out,retval]*/ BSTR* /*pbstrTrademark*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Trademark)(
		/*[in]*/ BSTR /*Trademark*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyType)(
		/*[out,retval]*/ prjAssemblyType* /*pAssemblyType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyType)(
		/*[in]*/ prjAssemblyType /*AssemblyType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TypeComplianceDiagnostics)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbTypeComplianceDiagnostics*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_TypeComplianceDiagnostics)(
		/*[in]*/ VARIANT_BOOL /*TypeComplianceDiagnostics*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Win32ResourceFile)(
		/*[out,retval]*/ BSTR* /*pbstrW32ResourceFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Win32ResourceFile)(
		/*[in]*/ BSTR /*Win32ResourceFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyKeyProviderName)(
		/*[out,retval]*/ BSTR* /*pbstrKeyProviderName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyKeyProviderName)(
		/*[in]*/ BSTR /*KeyProviderName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyOriginatorKeyFileType)(
		/*[out,retval]*/ DWORD* /*pdwOriginatorKeyFileType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyOriginatorKeyFileType)(
		/*[in]*/ DWORD /*OriginatorKeyFileType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyVersion)(
		/*[out,retval]*/ BSTR* /*pbstrAssemblyVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyVersion)(
		/*[in]*/ BSTR /*AssemblyVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyFileVersion)(
		/*[out,retval]*/ BSTR* /*pbstrAssemblyFileVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyFileVersion)(
		/*[in]*/ BSTR /*AssemblyFileVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_GenerateManifests)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbGenerateManifests*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_GenerateManifests)(
		/*[in]*/ VARIANT_BOOL /*GenerateManifests*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnableSecurityDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableSecurityDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_EnableSecurityDebugging)(
		/*[in]*/ VARIANT_BOOL /*EnableSecurityDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DebugSecurityZoneURL)(
		/*[out,retval]*/ BSTR* /*pbstrSecurityURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DebugSecurityZoneURL)(
		/*[in]*/ BSTR /*SecurityURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Publish)(
		/*[out,retval]*/ IDispatch** /*ppdispPublish*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ComVisible)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbComVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ComVisible)(
		/*[in]*/ VARIANT_BOOL /*ComVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyGuid)(
		/*[out,retval]*/ BSTR* /*pbstrAssemblyGuid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyGuid)(
		/*[in]*/ BSTR /*AssemblyGuid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_NeutralResourcesLanguage)(
		/*[out,retval]*/ BSTR* /*pbstrNeutralResourcesLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_NeutralResourcesLanguage)(
		/*[in]*/ BSTR /*NeutralResourcesLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SignAssembly)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbSignAssembly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_SignAssembly)(
		/*[in]*/ VARIANT_BOOL /*SignAssembly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_SignManifests)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbSignManifests*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_SignManifests)(
		/*[in]*/ VARIANT_BOOL /*bSignManifests*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TargetZone)(
		/*[out,retval]*/ BSTR* /*pbstrTargetZone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_TargetZone)(
		/*[in]*/ BSTR /*TargetZone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExcludedPermissions)(
		/*[out,retval]*/ BSTR* /*pbstrExcludedPermissions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ExcludedPermissions)(
		/*[in]*/ BSTR /*ExcludedPermissions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ManifestCertificateThumbprint)(
		/*[out,retval]*/ BSTR* /*pbstrManifestCertificateThumbprint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ManifestCertificateThumbprint)(
		/*[in]*/ BSTR /*ManifestCertificateThumbprint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ManifestKeyFile)(
		/*[out,retval]*/ BSTR* /*pbstrManifestKeyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ManifestKeyFile)(
		/*[in]*/ BSTR /*ManifestKeyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ManifestTimestampUrl)(
		/*[out,retval]*/ BSTR* /*pbstrManifestTimestampUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ManifestTimestampUrl)(
		/*[in]*/ BSTR /*ManifestTimestampUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_PreBuildEvent)(
		/*[out,retval]*/ BSTR* /*pbstrOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_PreBuildEvent)(
		/*[in]*/ BSTR /*bstrIn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_PostBuildEvent)(
		/*[out,retval]*/ BSTR* /*pbstrOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_PostBuildEvent)(
		/*[in]*/ BSTR /*bstrIn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RunPostBuildEvent)(
		/*[out,retval]*/ prjRunPostBuildEvent* /*pOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RunPostBuildEvent)(
		/*[in]*/ prjRunPostBuildEvent /*run*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AspnetVersion)(
		/*[out,retval]*/ BSTR* /*pOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get___project)(
		/*[out,retval]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartupObject)(
		/*[out,retval]*/ BSTR* /*pbstrStartupObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartupObject)(
		/*[in]*/ BSTR /*bstrStartupObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OutputType)(
		/*[out,retval]*/ prjOutputType* /*pOutputType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OutputType)(
		/*[in]*/ prjOutputType /*outputType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RootNamespace)(
		/*[out,retval]*/ BSTR* /*pbstrRootNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RootNamespace)(
		/*[in]*/ BSTR /*bstrRootNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyName)(
		/*[out,retval]*/ BSTR* /*pbstrAssemblyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyName)(
		/*[in]*/ BSTR /*bstrAssemblyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyOriginatorKeyFile)(
		/*[out,retval]*/ BSTR* /*pbstrOriginatorKeyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyOriginatorKeyFile)(
		/*[in]*/ BSTR /*bstrOriginatorKeyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyKeyContainerName)(
		/*[out,retval]*/ BSTR* /*pbstrKeyContainerName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyKeyContainerName)(
		/*[in]*/ BSTR /*bstrKeyContainerName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AssemblyOriginatorKeyMode)(
		/*[out,retval]*/ prjOriginatorKeyMode* /*pOriginatorKeyMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AssemblyOriginatorKeyMode)(
		/*[in]*/ prjOriginatorKeyMode /*originatorKeyMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DelaySign)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbDelaySign*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DelaySign)(
		/*[in]*/ VARIANT_BOOL /*bDelaySign*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebServer)(
		/*[out,retval]*/ BSTR* /*pbstrWebServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebServerVersion)(
		/*[out,retval]*/ BSTR* /*pbstrWebServerVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ServerExtensionsVersion)(
		/*[out,retval]*/ BSTR* /*pbstrServerExtensionsVersion*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_LinkRepair)(
		/*[out,retval]*/ VARIANT_BOOL* /*pLinkRepair*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_LinkRepair)(
		/*[in]*/ VARIANT_BOOL /*linkRepair*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OfflineURL)(
		/*[out,retval]*/ BSTR* /*pbstrOfflineURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FileSharePath)(
		/*[out,retval]*/ BSTR* /*pbstrFileSharePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_FileSharePath)(
		/*[in]*/ BSTR /*bstrFileSharePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ActiveFileSharePath)(
		/*[out,retval]*/ BSTR* /*pbstrFileSharePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebAccessMethod)(
		/*[out,retval]*/ prjWebAccessMethod* /*pWebAccessMethod*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_WebAccessMethod)(
		/*[in]*/ prjWebAccessMethod /*authoringAccessMethod*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ActiveWebAccessMethod)(
		/*[out,retval]*/ prjWebAccessMethod* /*pActiveWebAccessMethod*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefaultClientScript)(
		/*[out,retval]*/ prjScriptLanguage* /*pScriptLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefaultClientScript)(
		/*[in]*/ prjScriptLanguage /*scriptLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefaultTargetSchema)(
		/*[out,retval]*/ prjTargetSchema* /*pTargetSchema*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefaultTargetSchema)(
		/*[in]*/ prjTargetSchema /*htmlPlatform*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefaultHTMLPageLayout)(
		/*[out,retval]*/ prjHTMLPageLayout* /*pHTMLPageLayout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefaultHTMLPageLayout)(
		/*[in]*/ prjHTMLPageLayout /*htmlPageLayout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FileName)(
		/*[out,retval]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_FileName)(
		/*[in]*/ BSTR /*bstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FullPath)(
		/*[out,retval]*/ BSTR* /*pbstrFullPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_LocalPath)(
		/*[out,retval]*/ BSTR* /*pbstrLocalPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_URL)(
		/*[out,retval]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ActiveConfigurationSettings)(
		/*[out,retval]*/ ProjectConfigurationProperties** /*ppVBProjConfigProps*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR /*ExtenderName*/,
		/*[out,retval]*/ IDispatch** /*Extender*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* /*ExtenderNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* /*pRetval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ApplicationIcon)(
		/*[out,retval]*/ BSTR* /*pbstrApplicationIcon*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ApplicationIcon)(
		/*[in]*/ BSTR /*bstrApplicationIcon*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OptionStrict)(
		/*[out,retval]*/ prjOptionStrict* /*pOptionStrict*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionStrict)(
		/*[in]*/ prjOptionStrict /*optionStrict*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ReferencePath)(
		/*[out,retval]*/ BSTR* /*pbstrReferencePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ReferencePath)(
		/*[in]*/ BSTR /*bstrReferencePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OutputFileName)(
		/*[out,retval]*/ BSTR* /*pbstrOutputFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AbsoluteProjectDirectory)(
		/*[out,retval]*/ BSTR* /*pbstrDir*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OptionExplicit)(
		/*[out,retval]*/ prjOptionExplicit* /*pOptionExplicit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionExplicit)(
		/*[in]*/ prjOptionExplicit /*optionExplicit*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OptionCompare)(
		/*[out,retval]*/ prjCompare* /*pOptionCompare*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OptionCompare)(
		/*[in]*/ prjCompare /*optionCompare*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ProjectType)(
		/*[out,retval]*/ prjProjectType* /*pProjectType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefaultNamespace)(
		/*[out,retval]*/ BSTR* /*pbstrRootNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefaultNamespace)(
		/*[in]*/ BSTR /*bstrRootNamespace*/)VSL_STDMETHOD_NOTIMPL

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

class ProjectProperties3MockImpl :
	public ProjectProperties3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ProjectProperties3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ProjectProperties3MockImpl)

	typedef ProjectProperties3 Interface;
	struct get_TitleValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTitle;
		HRESULT retValue;
	};

	STDMETHOD(get_Title)(
		/*[out,retval]*/ BSTR* pbstrTitle)
	{
		VSL_DEFINE_MOCK_METHOD(get_Title)

		VSL_SET_VALIDVALUE_BSTR(pbstrTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TitleValidValues
	{
		/*[in]*/ BSTR Title;
		HRESULT retValue;
	};

	STDMETHOD(put_Title)(
		/*[in]*/ BSTR Title)
	{
		VSL_DEFINE_MOCK_METHOD(put_Title)

		VSL_CHECK_VALIDVALUE_BSTR(Title);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DescriptionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(get_Description)(
		/*[out,retval]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(get_Description)

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DescriptionValidValues
	{
		/*[in]*/ BSTR Description;
		HRESULT retValue;
	};

	STDMETHOD(put_Description)(
		/*[in]*/ BSTR Description)
	{
		VSL_DEFINE_MOCK_METHOD(put_Description)

		VSL_CHECK_VALIDVALUE_BSTR(Description);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CompanyValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCompany;
		HRESULT retValue;
	};

	STDMETHOD(get_Company)(
		/*[out,retval]*/ BSTR* pbstrCompany)
	{
		VSL_DEFINE_MOCK_METHOD(get_Company)

		VSL_SET_VALIDVALUE_BSTR(pbstrCompany);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CompanyValidValues
	{
		/*[in]*/ BSTR Company;
		HRESULT retValue;
	};

	STDMETHOD(put_Company)(
		/*[in]*/ BSTR Company)
	{
		VSL_DEFINE_MOCK_METHOD(put_Company)

		VSL_CHECK_VALIDVALUE_BSTR(Company);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProductValidValues
	{
		/*[out,retval]*/ BSTR* pbstrProduct;
		HRESULT retValue;
	};

	STDMETHOD(get_Product)(
		/*[out,retval]*/ BSTR* pbstrProduct)
	{
		VSL_DEFINE_MOCK_METHOD(get_Product)

		VSL_SET_VALIDVALUE_BSTR(pbstrProduct);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ProductValidValues
	{
		/*[in]*/ BSTR Product;
		HRESULT retValue;
	};

	STDMETHOD(put_Product)(
		/*[in]*/ BSTR Product)
	{
		VSL_DEFINE_MOCK_METHOD(put_Product)

		VSL_CHECK_VALIDVALUE_BSTR(Product);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CopyrightValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCopyright;
		HRESULT retValue;
	};

	STDMETHOD(get_Copyright)(
		/*[out,retval]*/ BSTR* pbstrCopyright)
	{
		VSL_DEFINE_MOCK_METHOD(get_Copyright)

		VSL_SET_VALIDVALUE_BSTR(pbstrCopyright);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CopyrightValidValues
	{
		/*[in]*/ BSTR Copyright;
		HRESULT retValue;
	};

	STDMETHOD(put_Copyright)(
		/*[in]*/ BSTR Copyright)
	{
		VSL_DEFINE_MOCK_METHOD(put_Copyright)

		VSL_CHECK_VALIDVALUE_BSTR(Copyright);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TrademarkValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTrademark;
		HRESULT retValue;
	};

	STDMETHOD(get_Trademark)(
		/*[out,retval]*/ BSTR* pbstrTrademark)
	{
		VSL_DEFINE_MOCK_METHOD(get_Trademark)

		VSL_SET_VALIDVALUE_BSTR(pbstrTrademark);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TrademarkValidValues
	{
		/*[in]*/ BSTR Trademark;
		HRESULT retValue;
	};

	STDMETHOD(put_Trademark)(
		/*[in]*/ BSTR Trademark)
	{
		VSL_DEFINE_MOCK_METHOD(put_Trademark)

		VSL_CHECK_VALIDVALUE_BSTR(Trademark);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyTypeValidValues
	{
		/*[out,retval]*/ prjAssemblyType* pAssemblyType;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyType)(
		/*[out,retval]*/ prjAssemblyType* pAssemblyType)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyType)

		VSL_SET_VALIDVALUE(pAssemblyType);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyTypeValidValues
	{
		/*[in]*/ prjAssemblyType AssemblyType;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyType)(
		/*[in]*/ prjAssemblyType AssemblyType)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyType)

		VSL_CHECK_VALIDVALUE(AssemblyType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TypeComplianceDiagnosticsValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbTypeComplianceDiagnostics;
		HRESULT retValue;
	};

	STDMETHOD(get_TypeComplianceDiagnostics)(
		/*[out,retval]*/ VARIANT_BOOL* pbTypeComplianceDiagnostics)
	{
		VSL_DEFINE_MOCK_METHOD(get_TypeComplianceDiagnostics)

		VSL_SET_VALIDVALUE(pbTypeComplianceDiagnostics);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TypeComplianceDiagnosticsValidValues
	{
		/*[in]*/ VARIANT_BOOL TypeComplianceDiagnostics;
		HRESULT retValue;
	};

	STDMETHOD(put_TypeComplianceDiagnostics)(
		/*[in]*/ VARIANT_BOOL TypeComplianceDiagnostics)
	{
		VSL_DEFINE_MOCK_METHOD(put_TypeComplianceDiagnostics)

		VSL_CHECK_VALIDVALUE(TypeComplianceDiagnostics);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_Win32ResourceFileValidValues
	{
		/*[out,retval]*/ BSTR* pbstrW32ResourceFile;
		HRESULT retValue;
	};

	STDMETHOD(get_Win32ResourceFile)(
		/*[out,retval]*/ BSTR* pbstrW32ResourceFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_Win32ResourceFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrW32ResourceFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_Win32ResourceFileValidValues
	{
		/*[in]*/ BSTR Win32ResourceFile;
		HRESULT retValue;
	};

	STDMETHOD(put_Win32ResourceFile)(
		/*[in]*/ BSTR Win32ResourceFile)
	{
		VSL_DEFINE_MOCK_METHOD(put_Win32ResourceFile)

		VSL_CHECK_VALIDVALUE_BSTR(Win32ResourceFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyKeyProviderNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrKeyProviderName;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyKeyProviderName)(
		/*[out,retval]*/ BSTR* pbstrKeyProviderName)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyKeyProviderName)

		VSL_SET_VALIDVALUE_BSTR(pbstrKeyProviderName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyKeyProviderNameValidValues
	{
		/*[in]*/ BSTR KeyProviderName;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyKeyProviderName)(
		/*[in]*/ BSTR KeyProviderName)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyKeyProviderName)

		VSL_CHECK_VALIDVALUE_BSTR(KeyProviderName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyOriginatorKeyFileTypeValidValues
	{
		/*[out,retval]*/ DWORD* pdwOriginatorKeyFileType;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyOriginatorKeyFileType)(
		/*[out,retval]*/ DWORD* pdwOriginatorKeyFileType)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyOriginatorKeyFileType)

		VSL_SET_VALIDVALUE(pdwOriginatorKeyFileType);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyOriginatorKeyFileTypeValidValues
	{
		/*[in]*/ DWORD OriginatorKeyFileType;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyOriginatorKeyFileType)(
		/*[in]*/ DWORD OriginatorKeyFileType)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyOriginatorKeyFileType)

		VSL_CHECK_VALIDVALUE(OriginatorKeyFileType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyVersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAssemblyVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyVersion)(
		/*[out,retval]*/ BSTR* pbstrAssemblyVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyVersion)

		VSL_SET_VALIDVALUE_BSTR(pbstrAssemblyVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyVersionValidValues
	{
		/*[in]*/ BSTR AssemblyVersion;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyVersion)(
		/*[in]*/ BSTR AssemblyVersion)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyVersion)

		VSL_CHECK_VALIDVALUE_BSTR(AssemblyVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyFileVersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAssemblyFileVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyFileVersion)(
		/*[out,retval]*/ BSTR* pbstrAssemblyFileVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyFileVersion)

		VSL_SET_VALIDVALUE_BSTR(pbstrAssemblyFileVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyFileVersionValidValues
	{
		/*[in]*/ BSTR AssemblyFileVersion;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyFileVersion)(
		/*[in]*/ BSTR AssemblyFileVersion)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyFileVersion)

		VSL_CHECK_VALIDVALUE_BSTR(AssemblyFileVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_GenerateManifestsValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbGenerateManifests;
		HRESULT retValue;
	};

	STDMETHOD(get_GenerateManifests)(
		/*[out,retval]*/ VARIANT_BOOL* pbGenerateManifests)
	{
		VSL_DEFINE_MOCK_METHOD(get_GenerateManifests)

		VSL_SET_VALIDVALUE(pbGenerateManifests);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_GenerateManifestsValidValues
	{
		/*[in]*/ VARIANT_BOOL GenerateManifests;
		HRESULT retValue;
	};

	STDMETHOD(put_GenerateManifests)(
		/*[in]*/ VARIANT_BOOL GenerateManifests)
	{
		VSL_DEFINE_MOCK_METHOD(put_GenerateManifests)

		VSL_CHECK_VALIDVALUE(GenerateManifests);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnableSecurityDebuggingValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableSecurityDebugging;
		HRESULT retValue;
	};

	STDMETHOD(get_EnableSecurityDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableSecurityDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnableSecurityDebugging)

		VSL_SET_VALIDVALUE(pbEnableSecurityDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_EnableSecurityDebuggingValidValues
	{
		/*[in]*/ VARIANT_BOOL EnableSecurityDebugging;
		HRESULT retValue;
	};

	STDMETHOD(put_EnableSecurityDebugging)(
		/*[in]*/ VARIANT_BOOL EnableSecurityDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(put_EnableSecurityDebugging)

		VSL_CHECK_VALIDVALUE(EnableSecurityDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DebugSecurityZoneURLValidValues
	{
		/*[out,retval]*/ BSTR* pbstrSecurityURL;
		HRESULT retValue;
	};

	STDMETHOD(get_DebugSecurityZoneURL)(
		/*[out,retval]*/ BSTR* pbstrSecurityURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_DebugSecurityZoneURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrSecurityURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DebugSecurityZoneURLValidValues
	{
		/*[in]*/ BSTR SecurityURL;
		HRESULT retValue;
	};

	STDMETHOD(put_DebugSecurityZoneURL)(
		/*[in]*/ BSTR SecurityURL)
	{
		VSL_DEFINE_MOCK_METHOD(put_DebugSecurityZoneURL)

		VSL_CHECK_VALIDVALUE_BSTR(SecurityURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PublishValidValues
	{
		/*[out,retval]*/ IDispatch** ppdispPublish;
		HRESULT retValue;
	};

	STDMETHOD(get_Publish)(
		/*[out,retval]*/ IDispatch** ppdispPublish)
	{
		VSL_DEFINE_MOCK_METHOD(get_Publish)

		VSL_SET_VALIDVALUE_INTERFACE(ppdispPublish);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ComVisibleValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbComVisible;
		HRESULT retValue;
	};

	STDMETHOD(get_ComVisible)(
		/*[out,retval]*/ VARIANT_BOOL* pbComVisible)
	{
		VSL_DEFINE_MOCK_METHOD(get_ComVisible)

		VSL_SET_VALIDVALUE(pbComVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ComVisibleValidValues
	{
		/*[in]*/ VARIANT_BOOL ComVisible;
		HRESULT retValue;
	};

	STDMETHOD(put_ComVisible)(
		/*[in]*/ VARIANT_BOOL ComVisible)
	{
		VSL_DEFINE_MOCK_METHOD(put_ComVisible)

		VSL_CHECK_VALIDVALUE(ComVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyGuidValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAssemblyGuid;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyGuid)(
		/*[out,retval]*/ BSTR* pbstrAssemblyGuid)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyGuid)

		VSL_SET_VALIDVALUE_BSTR(pbstrAssemblyGuid);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyGuidValidValues
	{
		/*[in]*/ BSTR AssemblyGuid;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyGuid)(
		/*[in]*/ BSTR AssemblyGuid)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyGuid)

		VSL_CHECK_VALIDVALUE_BSTR(AssemblyGuid);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_NeutralResourcesLanguageValidValues
	{
		/*[out,retval]*/ BSTR* pbstrNeutralResourcesLanguage;
		HRESULT retValue;
	};

	STDMETHOD(get_NeutralResourcesLanguage)(
		/*[out,retval]*/ BSTR* pbstrNeutralResourcesLanguage)
	{
		VSL_DEFINE_MOCK_METHOD(get_NeutralResourcesLanguage)

		VSL_SET_VALIDVALUE_BSTR(pbstrNeutralResourcesLanguage);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_NeutralResourcesLanguageValidValues
	{
		/*[in]*/ BSTR NeutralResourcesLanguage;
		HRESULT retValue;
	};

	STDMETHOD(put_NeutralResourcesLanguage)(
		/*[in]*/ BSTR NeutralResourcesLanguage)
	{
		VSL_DEFINE_MOCK_METHOD(put_NeutralResourcesLanguage)

		VSL_CHECK_VALIDVALUE_BSTR(NeutralResourcesLanguage);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SignAssemblyValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbSignAssembly;
		HRESULT retValue;
	};

	STDMETHOD(get_SignAssembly)(
		/*[out,retval]*/ VARIANT_BOOL* pbSignAssembly)
	{
		VSL_DEFINE_MOCK_METHOD(get_SignAssembly)

		VSL_SET_VALIDVALUE(pbSignAssembly);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_SignAssemblyValidValues
	{
		/*[in]*/ VARIANT_BOOL SignAssembly;
		HRESULT retValue;
	};

	STDMETHOD(put_SignAssembly)(
		/*[in]*/ VARIANT_BOOL SignAssembly)
	{
		VSL_DEFINE_MOCK_METHOD(put_SignAssembly)

		VSL_CHECK_VALIDVALUE(SignAssembly);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_SignManifestsValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbSignManifests;
		HRESULT retValue;
	};

	STDMETHOD(get_SignManifests)(
		/*[out,retval]*/ VARIANT_BOOL* pbSignManifests)
	{
		VSL_DEFINE_MOCK_METHOD(get_SignManifests)

		VSL_SET_VALIDVALUE(pbSignManifests);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_SignManifestsValidValues
	{
		/*[in]*/ VARIANT_BOOL bSignManifests;
		HRESULT retValue;
	};

	STDMETHOD(put_SignManifests)(
		/*[in]*/ VARIANT_BOOL bSignManifests)
	{
		VSL_DEFINE_MOCK_METHOD(put_SignManifests)

		VSL_CHECK_VALIDVALUE(bSignManifests);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TargetZoneValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTargetZone;
		HRESULT retValue;
	};

	STDMETHOD(get_TargetZone)(
		/*[out,retval]*/ BSTR* pbstrTargetZone)
	{
		VSL_DEFINE_MOCK_METHOD(get_TargetZone)

		VSL_SET_VALIDVALUE_BSTR(pbstrTargetZone);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TargetZoneValidValues
	{
		/*[in]*/ BSTR TargetZone;
		HRESULT retValue;
	};

	STDMETHOD(put_TargetZone)(
		/*[in]*/ BSTR TargetZone)
	{
		VSL_DEFINE_MOCK_METHOD(put_TargetZone)

		VSL_CHECK_VALIDVALUE_BSTR(TargetZone);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExcludedPermissionsValidValues
	{
		/*[out,retval]*/ BSTR* pbstrExcludedPermissions;
		HRESULT retValue;
	};

	STDMETHOD(get_ExcludedPermissions)(
		/*[out,retval]*/ BSTR* pbstrExcludedPermissions)
	{
		VSL_DEFINE_MOCK_METHOD(get_ExcludedPermissions)

		VSL_SET_VALIDVALUE_BSTR(pbstrExcludedPermissions);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ExcludedPermissionsValidValues
	{
		/*[in]*/ BSTR ExcludedPermissions;
		HRESULT retValue;
	};

	STDMETHOD(put_ExcludedPermissions)(
		/*[in]*/ BSTR ExcludedPermissions)
	{
		VSL_DEFINE_MOCK_METHOD(put_ExcludedPermissions)

		VSL_CHECK_VALIDVALUE_BSTR(ExcludedPermissions);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ManifestCertificateThumbprintValidValues
	{
		/*[out,retval]*/ BSTR* pbstrManifestCertificateThumbprint;
		HRESULT retValue;
	};

	STDMETHOD(get_ManifestCertificateThumbprint)(
		/*[out,retval]*/ BSTR* pbstrManifestCertificateThumbprint)
	{
		VSL_DEFINE_MOCK_METHOD(get_ManifestCertificateThumbprint)

		VSL_SET_VALIDVALUE_BSTR(pbstrManifestCertificateThumbprint);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ManifestCertificateThumbprintValidValues
	{
		/*[in]*/ BSTR ManifestCertificateThumbprint;
		HRESULT retValue;
	};

	STDMETHOD(put_ManifestCertificateThumbprint)(
		/*[in]*/ BSTR ManifestCertificateThumbprint)
	{
		VSL_DEFINE_MOCK_METHOD(put_ManifestCertificateThumbprint)

		VSL_CHECK_VALIDVALUE_BSTR(ManifestCertificateThumbprint);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ManifestKeyFileValidValues
	{
		/*[out,retval]*/ BSTR* pbstrManifestKeyFile;
		HRESULT retValue;
	};

	STDMETHOD(get_ManifestKeyFile)(
		/*[out,retval]*/ BSTR* pbstrManifestKeyFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_ManifestKeyFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrManifestKeyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ManifestKeyFileValidValues
	{
		/*[in]*/ BSTR ManifestKeyFile;
		HRESULT retValue;
	};

	STDMETHOD(put_ManifestKeyFile)(
		/*[in]*/ BSTR ManifestKeyFile)
	{
		VSL_DEFINE_MOCK_METHOD(put_ManifestKeyFile)

		VSL_CHECK_VALIDVALUE_BSTR(ManifestKeyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ManifestTimestampUrlValidValues
	{
		/*[out,retval]*/ BSTR* pbstrManifestTimestampUrl;
		HRESULT retValue;
	};

	STDMETHOD(get_ManifestTimestampUrl)(
		/*[out,retval]*/ BSTR* pbstrManifestTimestampUrl)
	{
		VSL_DEFINE_MOCK_METHOD(get_ManifestTimestampUrl)

		VSL_SET_VALIDVALUE_BSTR(pbstrManifestTimestampUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ManifestTimestampUrlValidValues
	{
		/*[in]*/ BSTR ManifestTimestampUrl;
		HRESULT retValue;
	};

	STDMETHOD(put_ManifestTimestampUrl)(
		/*[in]*/ BSTR ManifestTimestampUrl)
	{
		VSL_DEFINE_MOCK_METHOD(put_ManifestTimestampUrl)

		VSL_CHECK_VALIDVALUE_BSTR(ManifestTimestampUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PreBuildEventValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOut;
		HRESULT retValue;
	};

	STDMETHOD(get_PreBuildEvent)(
		/*[out,retval]*/ BSTR* pbstrOut)
	{
		VSL_DEFINE_MOCK_METHOD(get_PreBuildEvent)

		VSL_SET_VALIDVALUE_BSTR(pbstrOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_PreBuildEventValidValues
	{
		/*[in]*/ BSTR bstrIn;
		HRESULT retValue;
	};

	STDMETHOD(put_PreBuildEvent)(
		/*[in]*/ BSTR bstrIn)
	{
		VSL_DEFINE_MOCK_METHOD(put_PreBuildEvent)

		VSL_CHECK_VALIDVALUE_BSTR(bstrIn);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PostBuildEventValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOut;
		HRESULT retValue;
	};

	STDMETHOD(get_PostBuildEvent)(
		/*[out,retval]*/ BSTR* pbstrOut)
	{
		VSL_DEFINE_MOCK_METHOD(get_PostBuildEvent)

		VSL_SET_VALIDVALUE_BSTR(pbstrOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_PostBuildEventValidValues
	{
		/*[in]*/ BSTR bstrIn;
		HRESULT retValue;
	};

	STDMETHOD(put_PostBuildEvent)(
		/*[in]*/ BSTR bstrIn)
	{
		VSL_DEFINE_MOCK_METHOD(put_PostBuildEvent)

		VSL_CHECK_VALIDVALUE_BSTR(bstrIn);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RunPostBuildEventValidValues
	{
		/*[out,retval]*/ prjRunPostBuildEvent* pOut;
		HRESULT retValue;
	};

	STDMETHOD(get_RunPostBuildEvent)(
		/*[out,retval]*/ prjRunPostBuildEvent* pOut)
	{
		VSL_DEFINE_MOCK_METHOD(get_RunPostBuildEvent)

		VSL_SET_VALIDVALUE(pOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RunPostBuildEventValidValues
	{
		/*[in]*/ prjRunPostBuildEvent run;
		HRESULT retValue;
	};

	STDMETHOD(put_RunPostBuildEvent)(
		/*[in]*/ prjRunPostBuildEvent run)
	{
		VSL_DEFINE_MOCK_METHOD(put_RunPostBuildEvent)

		VSL_CHECK_VALIDVALUE(run);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AspnetVersionValidValues
	{
		/*[out,retval]*/ BSTR* pOut;
		HRESULT retValue;
	};

	STDMETHOD(get_AspnetVersion)(
		/*[out,retval]*/ BSTR* pOut)
	{
		VSL_DEFINE_MOCK_METHOD(get_AspnetVersion)

		VSL_SET_VALIDVALUE_BSTR(pOut);

		VSL_RETURN_VALIDVALUES();
	}
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
	struct get___projectValidValues
	{
		/*[out,retval]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(get___project)(
		/*[out,retval]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(get___project)

		VSL_SET_VALIDVALUE_INTERFACE(ppUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartupObjectValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartupObject;
		HRESULT retValue;
	};

	STDMETHOD(get_StartupObject)(
		/*[out,retval]*/ BSTR* pbstrStartupObject)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartupObject)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartupObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartupObjectValidValues
	{
		/*[in]*/ BSTR bstrStartupObject;
		HRESULT retValue;
	};

	STDMETHOD(put_StartupObject)(
		/*[in]*/ BSTR bstrStartupObject)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartupObject)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartupObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OutputTypeValidValues
	{
		/*[out,retval]*/ prjOutputType* pOutputType;
		HRESULT retValue;
	};

	STDMETHOD(get_OutputType)(
		/*[out,retval]*/ prjOutputType* pOutputType)
	{
		VSL_DEFINE_MOCK_METHOD(get_OutputType)

		VSL_SET_VALIDVALUE(pOutputType);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OutputTypeValidValues
	{
		/*[in]*/ prjOutputType outputType;
		HRESULT retValue;
	};

	STDMETHOD(put_OutputType)(
		/*[in]*/ prjOutputType outputType)
	{
		VSL_DEFINE_MOCK_METHOD(put_OutputType)

		VSL_CHECK_VALIDVALUE(outputType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RootNamespaceValidValues
	{
		/*[out,retval]*/ BSTR* pbstrRootNamespace;
		HRESULT retValue;
	};

	STDMETHOD(get_RootNamespace)(
		/*[out,retval]*/ BSTR* pbstrRootNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(get_RootNamespace)

		VSL_SET_VALIDVALUE_BSTR(pbstrRootNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RootNamespaceValidValues
	{
		/*[in]*/ BSTR bstrRootNamespace;
		HRESULT retValue;
	};

	STDMETHOD(put_RootNamespace)(
		/*[in]*/ BSTR bstrRootNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(put_RootNamespace)

		VSL_CHECK_VALIDVALUE_BSTR(bstrRootNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrAssemblyName;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyName)(
		/*[out,retval]*/ BSTR* pbstrAssemblyName)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyName)

		VSL_SET_VALIDVALUE_BSTR(pbstrAssemblyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyNameValidValues
	{
		/*[in]*/ BSTR bstrAssemblyName;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyName)(
		/*[in]*/ BSTR bstrAssemblyName)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyName)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAssemblyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyOriginatorKeyFileValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOriginatorKeyFile;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyOriginatorKeyFile)(
		/*[out,retval]*/ BSTR* pbstrOriginatorKeyFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyOriginatorKeyFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrOriginatorKeyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyOriginatorKeyFileValidValues
	{
		/*[in]*/ BSTR bstrOriginatorKeyFile;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyOriginatorKeyFile)(
		/*[in]*/ BSTR bstrOriginatorKeyFile)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyOriginatorKeyFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrOriginatorKeyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyKeyContainerNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrKeyContainerName;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyKeyContainerName)(
		/*[out,retval]*/ BSTR* pbstrKeyContainerName)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyKeyContainerName)

		VSL_SET_VALIDVALUE_BSTR(pbstrKeyContainerName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyKeyContainerNameValidValues
	{
		/*[in]*/ BSTR bstrKeyContainerName;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyKeyContainerName)(
		/*[in]*/ BSTR bstrKeyContainerName)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyKeyContainerName)

		VSL_CHECK_VALIDVALUE_BSTR(bstrKeyContainerName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AssemblyOriginatorKeyModeValidValues
	{
		/*[out,retval]*/ prjOriginatorKeyMode* pOriginatorKeyMode;
		HRESULT retValue;
	};

	STDMETHOD(get_AssemblyOriginatorKeyMode)(
		/*[out,retval]*/ prjOriginatorKeyMode* pOriginatorKeyMode)
	{
		VSL_DEFINE_MOCK_METHOD(get_AssemblyOriginatorKeyMode)

		VSL_SET_VALIDVALUE(pOriginatorKeyMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AssemblyOriginatorKeyModeValidValues
	{
		/*[in]*/ prjOriginatorKeyMode originatorKeyMode;
		HRESULT retValue;
	};

	STDMETHOD(put_AssemblyOriginatorKeyMode)(
		/*[in]*/ prjOriginatorKeyMode originatorKeyMode)
	{
		VSL_DEFINE_MOCK_METHOD(put_AssemblyOriginatorKeyMode)

		VSL_CHECK_VALIDVALUE(originatorKeyMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DelaySignValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbDelaySign;
		HRESULT retValue;
	};

	STDMETHOD(get_DelaySign)(
		/*[out,retval]*/ VARIANT_BOOL* pbDelaySign)
	{
		VSL_DEFINE_MOCK_METHOD(get_DelaySign)

		VSL_SET_VALIDVALUE(pbDelaySign);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DelaySignValidValues
	{
		/*[in]*/ VARIANT_BOOL bDelaySign;
		HRESULT retValue;
	};

	STDMETHOD(put_DelaySign)(
		/*[in]*/ VARIANT_BOOL bDelaySign)
	{
		VSL_DEFINE_MOCK_METHOD(put_DelaySign)

		VSL_CHECK_VALIDVALUE(bDelaySign);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WebServerValidValues
	{
		/*[out,retval]*/ BSTR* pbstrWebServer;
		HRESULT retValue;
	};

	STDMETHOD(get_WebServer)(
		/*[out,retval]*/ BSTR* pbstrWebServer)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebServer)

		VSL_SET_VALIDVALUE_BSTR(pbstrWebServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WebServerVersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrWebServerVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_WebServerVersion)(
		/*[out,retval]*/ BSTR* pbstrWebServerVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebServerVersion)

		VSL_SET_VALIDVALUE_BSTR(pbstrWebServerVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ServerExtensionsVersionValidValues
	{
		/*[out,retval]*/ BSTR* pbstrServerExtensionsVersion;
		HRESULT retValue;
	};

	STDMETHOD(get_ServerExtensionsVersion)(
		/*[out,retval]*/ BSTR* pbstrServerExtensionsVersion)
	{
		VSL_DEFINE_MOCK_METHOD(get_ServerExtensionsVersion)

		VSL_SET_VALIDVALUE_BSTR(pbstrServerExtensionsVersion);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_LinkRepairValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pLinkRepair;
		HRESULT retValue;
	};

	STDMETHOD(get_LinkRepair)(
		/*[out,retval]*/ VARIANT_BOOL* pLinkRepair)
	{
		VSL_DEFINE_MOCK_METHOD(get_LinkRepair)

		VSL_SET_VALIDVALUE(pLinkRepair);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_LinkRepairValidValues
	{
		/*[in]*/ VARIANT_BOOL linkRepair;
		HRESULT retValue;
	};

	STDMETHOD(put_LinkRepair)(
		/*[in]*/ VARIANT_BOOL linkRepair)
	{
		VSL_DEFINE_MOCK_METHOD(put_LinkRepair)

		VSL_CHECK_VALIDVALUE(linkRepair);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OfflineURLValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOfflineURL;
		HRESULT retValue;
	};

	STDMETHOD(get_OfflineURL)(
		/*[out,retval]*/ BSTR* pbstrOfflineURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_OfflineURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrOfflineURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FileSharePathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFileSharePath;
		HRESULT retValue;
	};

	STDMETHOD(get_FileSharePath)(
		/*[out,retval]*/ BSTR* pbstrFileSharePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_FileSharePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrFileSharePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_FileSharePathValidValues
	{
		/*[in]*/ BSTR bstrFileSharePath;
		HRESULT retValue;
	};

	STDMETHOD(put_FileSharePath)(
		/*[in]*/ BSTR bstrFileSharePath)
	{
		VSL_DEFINE_MOCK_METHOD(put_FileSharePath)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileSharePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ActiveFileSharePathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFileSharePath;
		HRESULT retValue;
	};

	STDMETHOD(get_ActiveFileSharePath)(
		/*[out,retval]*/ BSTR* pbstrFileSharePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_ActiveFileSharePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrFileSharePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WebAccessMethodValidValues
	{
		/*[out,retval]*/ prjWebAccessMethod* pWebAccessMethod;
		HRESULT retValue;
	};

	STDMETHOD(get_WebAccessMethod)(
		/*[out,retval]*/ prjWebAccessMethod* pWebAccessMethod)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebAccessMethod)

		VSL_SET_VALIDVALUE(pWebAccessMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WebAccessMethodValidValues
	{
		/*[in]*/ prjWebAccessMethod authoringAccessMethod;
		HRESULT retValue;
	};

	STDMETHOD(put_WebAccessMethod)(
		/*[in]*/ prjWebAccessMethod authoringAccessMethod)
	{
		VSL_DEFINE_MOCK_METHOD(put_WebAccessMethod)

		VSL_CHECK_VALIDVALUE(authoringAccessMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ActiveWebAccessMethodValidValues
	{
		/*[out,retval]*/ prjWebAccessMethod* pActiveWebAccessMethod;
		HRESULT retValue;
	};

	STDMETHOD(get_ActiveWebAccessMethod)(
		/*[out,retval]*/ prjWebAccessMethod* pActiveWebAccessMethod)
	{
		VSL_DEFINE_MOCK_METHOD(get_ActiveWebAccessMethod)

		VSL_SET_VALIDVALUE(pActiveWebAccessMethod);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefaultClientScriptValidValues
	{
		/*[out,retval]*/ prjScriptLanguage* pScriptLanguage;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultClientScript)(
		/*[out,retval]*/ prjScriptLanguage* pScriptLanguage)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultClientScript)

		VSL_SET_VALIDVALUE(pScriptLanguage);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefaultClientScriptValidValues
	{
		/*[in]*/ prjScriptLanguage scriptLanguage;
		HRESULT retValue;
	};

	STDMETHOD(put_DefaultClientScript)(
		/*[in]*/ prjScriptLanguage scriptLanguage)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefaultClientScript)

		VSL_CHECK_VALIDVALUE(scriptLanguage);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefaultTargetSchemaValidValues
	{
		/*[out,retval]*/ prjTargetSchema* pTargetSchema;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultTargetSchema)(
		/*[out,retval]*/ prjTargetSchema* pTargetSchema)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultTargetSchema)

		VSL_SET_VALIDVALUE(pTargetSchema);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefaultTargetSchemaValidValues
	{
		/*[in]*/ prjTargetSchema htmlPlatform;
		HRESULT retValue;
	};

	STDMETHOD(put_DefaultTargetSchema)(
		/*[in]*/ prjTargetSchema htmlPlatform)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefaultTargetSchema)

		VSL_CHECK_VALIDVALUE(htmlPlatform);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefaultHTMLPageLayoutValidValues
	{
		/*[out,retval]*/ prjHTMLPageLayout* pHTMLPageLayout;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultHTMLPageLayout)(
		/*[out,retval]*/ prjHTMLPageLayout* pHTMLPageLayout)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultHTMLPageLayout)

		VSL_SET_VALIDVALUE(pHTMLPageLayout);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefaultHTMLPageLayoutValidValues
	{
		/*[in]*/ prjHTMLPageLayout htmlPageLayout;
		HRESULT retValue;
	};

	STDMETHOD(put_DefaultHTMLPageLayout)(
		/*[in]*/ prjHTMLPageLayout htmlPageLayout)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefaultHTMLPageLayout)

		VSL_CHECK_VALIDVALUE(htmlPageLayout);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FileNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(get_FileName)(
		/*[out,retval]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(get_FileName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_FileNameValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(put_FileName)(
		/*[in]*/ BSTR bstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(put_FileName)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

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
	struct get_ActiveConfigurationSettingsValidValues
	{
		/*[out,retval]*/ ProjectConfigurationProperties** ppVBProjConfigProps;
		HRESULT retValue;
	};

	STDMETHOD(get_ActiveConfigurationSettings)(
		/*[out,retval]*/ ProjectConfigurationProperties** ppVBProjConfigProps)
	{
		VSL_DEFINE_MOCK_METHOD(get_ActiveConfigurationSettings)

		VSL_SET_VALIDVALUE_INTERFACE(ppVBProjConfigProps);

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
	struct get_ApplicationIconValidValues
	{
		/*[out,retval]*/ BSTR* pbstrApplicationIcon;
		HRESULT retValue;
	};

	STDMETHOD(get_ApplicationIcon)(
		/*[out,retval]*/ BSTR* pbstrApplicationIcon)
	{
		VSL_DEFINE_MOCK_METHOD(get_ApplicationIcon)

		VSL_SET_VALIDVALUE_BSTR(pbstrApplicationIcon);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ApplicationIconValidValues
	{
		/*[in]*/ BSTR bstrApplicationIcon;
		HRESULT retValue;
	};

	STDMETHOD(put_ApplicationIcon)(
		/*[in]*/ BSTR bstrApplicationIcon)
	{
		VSL_DEFINE_MOCK_METHOD(put_ApplicationIcon)

		VSL_CHECK_VALIDVALUE_BSTR(bstrApplicationIcon);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptionStrictValidValues
	{
		/*[out,retval]*/ prjOptionStrict* pOptionStrict;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionStrict)(
		/*[out,retval]*/ prjOptionStrict* pOptionStrict)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionStrict)

		VSL_SET_VALIDVALUE(pOptionStrict);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionStrictValidValues
	{
		/*[in]*/ prjOptionStrict optionStrict;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionStrict)(
		/*[in]*/ prjOptionStrict optionStrict)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionStrict)

		VSL_CHECK_VALIDVALUE(optionStrict);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ReferencePathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrReferencePath;
		HRESULT retValue;
	};

	STDMETHOD(get_ReferencePath)(
		/*[out,retval]*/ BSTR* pbstrReferencePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_ReferencePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrReferencePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ReferencePathValidValues
	{
		/*[in]*/ BSTR bstrReferencePath;
		HRESULT retValue;
	};

	STDMETHOD(put_ReferencePath)(
		/*[in]*/ BSTR bstrReferencePath)
	{
		VSL_DEFINE_MOCK_METHOD(put_ReferencePath)

		VSL_CHECK_VALIDVALUE_BSTR(bstrReferencePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OutputFileNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOutputFileName;
		HRESULT retValue;
	};

	STDMETHOD(get_OutputFileName)(
		/*[out,retval]*/ BSTR* pbstrOutputFileName)
	{
		VSL_DEFINE_MOCK_METHOD(get_OutputFileName)

		VSL_SET_VALIDVALUE_BSTR(pbstrOutputFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AbsoluteProjectDirectoryValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDir;
		HRESULT retValue;
	};

	STDMETHOD(get_AbsoluteProjectDirectory)(
		/*[out,retval]*/ BSTR* pbstrDir)
	{
		VSL_DEFINE_MOCK_METHOD(get_AbsoluteProjectDirectory)

		VSL_SET_VALIDVALUE_BSTR(pbstrDir);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptionExplicitValidValues
	{
		/*[out,retval]*/ prjOptionExplicit* pOptionExplicit;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionExplicit)(
		/*[out,retval]*/ prjOptionExplicit* pOptionExplicit)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionExplicit)

		VSL_SET_VALIDVALUE(pOptionExplicit);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionExplicitValidValues
	{
		/*[in]*/ prjOptionExplicit optionExplicit;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionExplicit)(
		/*[in]*/ prjOptionExplicit optionExplicit)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionExplicit)

		VSL_CHECK_VALIDVALUE(optionExplicit);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptionCompareValidValues
	{
		/*[out,retval]*/ prjCompare* pOptionCompare;
		HRESULT retValue;
	};

	STDMETHOD(get_OptionCompare)(
		/*[out,retval]*/ prjCompare* pOptionCompare)
	{
		VSL_DEFINE_MOCK_METHOD(get_OptionCompare)

		VSL_SET_VALIDVALUE(pOptionCompare);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptionCompareValidValues
	{
		/*[in]*/ prjCompare optionCompare;
		HRESULT retValue;
	};

	STDMETHOD(put_OptionCompare)(
		/*[in]*/ prjCompare optionCompare)
	{
		VSL_DEFINE_MOCK_METHOD(put_OptionCompare)

		VSL_CHECK_VALIDVALUE(optionCompare);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProjectTypeValidValues
	{
		/*[out,retval]*/ prjProjectType* pProjectType;
		HRESULT retValue;
	};

	STDMETHOD(get_ProjectType)(
		/*[out,retval]*/ prjProjectType* pProjectType)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProjectType)

		VSL_SET_VALIDVALUE(pProjectType);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefaultNamespaceValidValues
	{
		/*[out,retval]*/ BSTR* pbstrRootNamespace;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultNamespace)(
		/*[out,retval]*/ BSTR* pbstrRootNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultNamespace)

		VSL_SET_VALIDVALUE_BSTR(pbstrRootNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefaultNamespaceValidValues
	{
		/*[in]*/ BSTR bstrRootNamespace;
		HRESULT retValue;
	};

	STDMETHOD(put_DefaultNamespace)(
		/*[in]*/ BSTR bstrRootNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefaultNamespace)

		VSL_CHECK_VALIDVALUE_BSTR(bstrRootNamespace);

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

#endif // PROJECTPROPERTIES3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
