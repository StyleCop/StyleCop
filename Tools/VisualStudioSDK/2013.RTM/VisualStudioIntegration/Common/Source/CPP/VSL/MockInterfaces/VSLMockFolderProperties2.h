/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef FOLDERPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define FOLDERPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class FolderProperties2NotImpl :
	public FolderProperties2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(FolderProperties2NotImpl)

public:

	typedef FolderProperties2 Interface;

	STDMETHOD(get_WebReferenceInterface)(
		/*[out,retval]*/ IUnknown** /*ppWebReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FileName)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_FileName)(
		/*[in]*/ BSTR /*bstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_LocalPath)(
		/*[out,retval]*/ BSTR* /*pbstrLocalPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FullPath)(
		/*[out,retval]*/ BSTR* /*pbstrFullPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_URL)(
		/*[out,retval]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR /*ExtenderName*/,
		/*[out,retval]*/ IDispatch** /*Extender*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* /*ExtenderNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* /*pRetval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebReference)(
		/*[out,retval]*/ BSTR* /*pbstrWebReferenceUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_WebReference)(
		/*[in]*/ BSTR /*bstrWebReferenceUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefaultNamespace)(
		/*[out,retval]*/ BSTR* /*pbstrNamespace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_UrlBehavior)(
		/*[out,retval]*/ webrefUrlBehavior* /*pUrlBehavior*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_UrlBehavior)(
		/*[in]*/ webrefUrlBehavior /*urlBehavior*/)VSL_STDMETHOD_NOTIMPL

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

class FolderProperties2MockImpl :
	public FolderProperties2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(FolderProperties2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(FolderProperties2MockImpl)

	typedef FolderProperties2 Interface;
	struct get_WebReferenceInterfaceValidValues
	{
		/*[out,retval]*/ IUnknown** ppWebReference;
		HRESULT retValue;
	};

	STDMETHOD(get_WebReferenceInterface)(
		/*[out,retval]*/ IUnknown** ppWebReference)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebReferenceInterface)

		VSL_SET_VALIDVALUE_INTERFACE(ppWebReference);

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
	struct get_WebReferenceValidValues
	{
		/*[out,retval]*/ BSTR* pbstrWebReferenceUrl;
		HRESULT retValue;
	};

	STDMETHOD(get_WebReference)(
		/*[out,retval]*/ BSTR* pbstrWebReferenceUrl)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebReference)

		VSL_SET_VALIDVALUE_BSTR(pbstrWebReferenceUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WebReferenceValidValues
	{
		/*[in]*/ BSTR bstrWebReferenceUrl;
		HRESULT retValue;
	};

	STDMETHOD(put_WebReference)(
		/*[in]*/ BSTR bstrWebReferenceUrl)
	{
		VSL_DEFINE_MOCK_METHOD(put_WebReference)

		VSL_CHECK_VALIDVALUE_BSTR(bstrWebReferenceUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefaultNamespaceValidValues
	{
		/*[out,retval]*/ BSTR* pbstrNamespace;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultNamespace)(
		/*[out,retval]*/ BSTR* pbstrNamespace)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultNamespace)

		VSL_SET_VALIDVALUE_BSTR(pbstrNamespace);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_UrlBehaviorValidValues
	{
		/*[out,retval]*/ webrefUrlBehavior* pUrlBehavior;
		HRESULT retValue;
	};

	STDMETHOD(get_UrlBehavior)(
		/*[out,retval]*/ webrefUrlBehavior* pUrlBehavior)
	{
		VSL_DEFINE_MOCK_METHOD(get_UrlBehavior)

		VSL_SET_VALIDVALUE(pUrlBehavior);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_UrlBehaviorValidValues
	{
		/*[in]*/ webrefUrlBehavior urlBehavior;
		HRESULT retValue;
	};

	STDMETHOD(put_UrlBehavior)(
		/*[in]*/ webrefUrlBehavior urlBehavior)
	{
		VSL_DEFINE_MOCK_METHOD(put_UrlBehavior)

		VSL_CHECK_VALIDVALUE(urlBehavior);

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

#endif // FOLDERPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
