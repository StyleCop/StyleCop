/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCFGPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCFGPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCfgProvider2NotImpl :
	public IVsCfgProvider2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProvider2NotImpl)

public:

	typedef IVsCfgProvider2 Interface;

	STDMETHOD(GetCfgNames)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ BSTR[] /*rgbstr*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPlatformNames)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ BSTR[] /*rgbstr*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCfgOfName)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/,
		/*[in]*/ LPCOLESTR /*pszPlatformName*/,
		/*[out]*/ IVsCfg** /*ppCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/,
		/*[in]*/ LPCOLESTR /*pszCloneCfgName*/,
		/*[in]*/ BOOL /*fPrivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR /*pszCfgName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR /*pszOldName*/,
		/*[in]*/ LPCOLESTR /*pszNewName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddCfgsOfPlatformName)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/,
		/*[in]*/ LPCOLESTR /*pszClonePlatformName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteCfgsOfPlatformName)(
		/*[in]*/ LPCOLESTR /*pszPlatformName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSupportedPlatformNames)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ BSTR[] /*rgbstr*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCfgProviderProperty)(
		/*[in]*/ VSCFGPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseCfgProviderEvents)(
		/*[in]*/ IVsCfgProviderEvents* /*pCPE*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseCfgProviderEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCfgs)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ IVsCfg*[] /*rgpcfg*/,
		/*[out,optional]*/ ULONG* /*pcActual*/,
		/*[out,optional]*/ VSCFGFLAGS* /*prgfFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCfgProvider2MockImpl :
	public IVsCfgProvider2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgProvider2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCfgProvider2MockImpl)

	typedef IVsCfgProvider2 Interface;
	struct GetCfgNamesValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ BSTR* rgbstr;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetCfgNames)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ BSTR rgbstr[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetCfgNames)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgbstr, celt*sizeof(rgbstr[0]), validValues.celt*sizeof(validValues.rgbstr[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPlatformNamesValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ BSTR* rgbstr;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetPlatformNames)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ BSTR rgbstr[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetPlatformNames)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgbstr, celt*sizeof(rgbstr[0]), validValues.celt*sizeof(validValues.rgbstr[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCfgOfNameValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		/*[in]*/ LPCOLESTR pszPlatformName;
		/*[out]*/ IVsCfg** ppCfg;
		HRESULT retValue;
	};

	STDMETHOD(GetCfgOfName)(
		/*[in]*/ LPCOLESTR pszCfgName,
		/*[in]*/ LPCOLESTR pszPlatformName,
		/*[out]*/ IVsCfg** ppCfg)
	{
		VSL_DEFINE_MOCK_METHOD(GetCfgOfName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_SET_VALIDVALUE_INTERFACE(ppCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddCfgsOfCfgNameValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		/*[in]*/ LPCOLESTR pszCloneCfgName;
		/*[in]*/ BOOL fPrivate;
		HRESULT retValue;
	};

	STDMETHOD(AddCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR pszCfgName,
		/*[in]*/ LPCOLESTR pszCloneCfgName,
		/*[in]*/ BOOL fPrivate)
	{
		VSL_DEFINE_MOCK_METHOD(AddCfgsOfCfgName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCloneCfgName);

		VSL_CHECK_VALIDVALUE(fPrivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteCfgsOfCfgNameValidValues
	{
		/*[in]*/ LPCOLESTR pszCfgName;
		HRESULT retValue;
	};

	STDMETHOD(DeleteCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR pszCfgName)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteCfgsOfCfgName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCfgName);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameCfgsOfCfgNameValidValues
	{
		/*[in]*/ LPCOLESTR pszOldName;
		/*[in]*/ LPCOLESTR pszNewName;
		HRESULT retValue;
	};

	STDMETHOD(RenameCfgsOfCfgName)(
		/*[in]*/ LPCOLESTR pszOldName,
		/*[in]*/ LPCOLESTR pszNewName)
	{
		VSL_DEFINE_MOCK_METHOD(RenameCfgsOfCfgName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNewName);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddCfgsOfPlatformNameValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		/*[in]*/ LPCOLESTR pszClonePlatformName;
		HRESULT retValue;
	};

	STDMETHOD(AddCfgsOfPlatformName)(
		/*[in]*/ LPCOLESTR pszPlatformName,
		/*[in]*/ LPCOLESTR pszClonePlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(AddCfgsOfPlatformName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszClonePlatformName);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteCfgsOfPlatformNameValidValues
	{
		/*[in]*/ LPCOLESTR pszPlatformName;
		HRESULT retValue;
	};

	STDMETHOD(DeleteCfgsOfPlatformName)(
		/*[in]*/ LPCOLESTR pszPlatformName)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteCfgsOfPlatformName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPlatformName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSupportedPlatformNamesValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ BSTR* rgbstr;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetSupportedPlatformNames)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ BSTR rgbstr[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetSupportedPlatformNames)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgbstr, celt*sizeof(rgbstr[0]), validValues.celt*sizeof(validValues.rgbstr[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCfgProviderPropertyValidValues
	{
		/*[in]*/ VSCFGPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetCfgProviderProperty)(
		/*[in]*/ VSCFGPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetCfgProviderProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseCfgProviderEventsValidValues
	{
		/*[in]*/ IVsCfgProviderEvents* pCPE;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseCfgProviderEvents)(
		/*[in]*/ IVsCfgProviderEvents* pCPE,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseCfgProviderEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCPE);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseCfgProviderEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseCfgProviderEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseCfgProviderEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCfgsValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ IVsCfg** rgpcfg;
		/*[out,optional]*/ ULONG* pcActual;
		/*[out,optional]*/ VSCFGFLAGS* prgfFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetCfgs)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ IVsCfg* rgpcfg[],
		/*[out,optional]*/ ULONG* pcActual,
		/*[out,optional]*/ VSCFGFLAGS* prgfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetCfgs)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgpcfg, celt, validValues.celt);

		VSL_SET_VALIDVALUE(pcActual);

		VSL_SET_VALIDVALUE(prgfFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCFGPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
