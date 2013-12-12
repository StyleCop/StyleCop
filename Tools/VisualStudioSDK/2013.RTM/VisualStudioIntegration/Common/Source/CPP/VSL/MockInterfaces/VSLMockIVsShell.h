/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsShellNotImpl :
	public IVsShell
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShellNotImpl)

public:

	typedef IVsShell Interface;

	STDMETHOD(GetPackageEnum)(
		/*[out]*/ IEnumPackages** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProperty)(
		/*[in]*/ VSSPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetProperty)(
		/*[in]*/ VSSPROPID /*propid*/,
		/*[in]*/ VARIANT /*var*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseBroadcastMessages)(
		/*[in]*/ IVsBroadcastMessageEvents* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseBroadcastMessages)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseShellPropertyChanges)(
		/*[in]*/ IVsShellPropertyEvents* /*pSink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseShellPropertyChanges)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadPackage)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[out,retval]*/ IVsPackage** /*ppPackage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadPackageString)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ ULONG /*resid*/,
		/*[out,retval]*/ BSTR* /*pbstrOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadUILibrary)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[in]*/ DWORD /*dwExFlags*/,
		/*[out,retval]*/ DWORD_PTR* /*phinstOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsPackageInstalled)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[out,retval]*/ BOOL* /*pfInstalled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsPackageLoaded)(
		/*[in]*/ REFGUID /*guidPackage*/,
		/*[out,retval]*/ IVsPackage** /*ppPackage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsShellMockImpl :
	public IVsShell,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsShellMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsShellMockImpl)

	typedef IVsShell Interface;
	struct GetPackageEnumValidValues
	{
		/*[out]*/ IEnumPackages** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetPackageEnum)(
		/*[out]*/ IEnumPackages** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetPackageEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyValidValues
	{
		/*[in]*/ VSSPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetProperty)(
		/*[in]*/ VSSPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValidValues
	{
		/*[in]*/ VSSPROPID propid;
		/*[in]*/ VARIANT var;
		HRESULT retValue;
	};

	STDMETHOD(SetProperty)(
		/*[in]*/ VSSPROPID propid,
		/*[in]*/ VARIANT var)
	{
		VSL_DEFINE_MOCK_METHOD(SetProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_CHECK_VALIDVALUE(var);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseBroadcastMessagesValidValues
	{
		/*[in]*/ IVsBroadcastMessageEvents* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseBroadcastMessages)(
		/*[in]*/ IVsBroadcastMessageEvents* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseBroadcastMessages)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseBroadcastMessagesValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseBroadcastMessages)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseBroadcastMessages)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseShellPropertyChangesValidValues
	{
		/*[in]*/ IVsShellPropertyEvents* pSink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseShellPropertyChanges)(
		/*[in]*/ IVsShellPropertyEvents* pSink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseShellPropertyChanges)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseShellPropertyChangesValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseShellPropertyChanges)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseShellPropertyChanges)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadPackageValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[out,retval]*/ IVsPackage** ppPackage;
		HRESULT retValue;
	};

	STDMETHOD(LoadPackage)(
		/*[in]*/ REFGUID guidPackage,
		/*[out,retval]*/ IVsPackage** ppPackage)
	{
		VSL_DEFINE_MOCK_METHOD(LoadPackage)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_SET_VALIDVALUE_INTERFACE(ppPackage);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadPackageStringValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ ULONG resid;
		/*[out,retval]*/ BSTR* pbstrOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadPackageString)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ ULONG resid,
		/*[out,retval]*/ BSTR* pbstrOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadPackageString)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(resid);

		VSL_SET_VALIDVALUE_BSTR(pbstrOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadUILibraryValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[in]*/ DWORD dwExFlags;
		/*[out,retval]*/ DWORD_PTR* phinstOut;
		HRESULT retValue;
	};

	STDMETHOD(LoadUILibrary)(
		/*[in]*/ REFGUID guidPackage,
		/*[in]*/ DWORD dwExFlags,
		/*[out,retval]*/ DWORD_PTR* phinstOut)
	{
		VSL_DEFINE_MOCK_METHOD(LoadUILibrary)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_CHECK_VALIDVALUE(dwExFlags);

		VSL_SET_VALIDVALUE(phinstOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsPackageInstalledValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[out,retval]*/ BOOL* pfInstalled;
		HRESULT retValue;
	};

	STDMETHOD(IsPackageInstalled)(
		/*[in]*/ REFGUID guidPackage,
		/*[out,retval]*/ BOOL* pfInstalled)
	{
		VSL_DEFINE_MOCK_METHOD(IsPackageInstalled)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_SET_VALIDVALUE(pfInstalled);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsPackageLoadedValidValues
	{
		/*[in]*/ REFGUID guidPackage;
		/*[out,retval]*/ IVsPackage** ppPackage;
		HRESULT retValue;
	};

	STDMETHOD(IsPackageLoaded)(
		/*[in]*/ REFGUID guidPackage,
		/*[out,retval]*/ IVsPackage** ppPackage)
	{
		VSL_DEFINE_MOCK_METHOD(IsPackageLoaded)

		VSL_CHECK_VALIDVALUE(guidPackage);

		VSL_SET_VALIDVALUE_INTERFACE(ppPackage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
