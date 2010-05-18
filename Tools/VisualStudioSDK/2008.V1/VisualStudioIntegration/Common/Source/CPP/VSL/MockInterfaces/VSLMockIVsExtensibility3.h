/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXTENSIBILITY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXTENSIBILITY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExtensibility3NotImpl :
	public IVsExtensibility3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExtensibility3NotImpl)

public:

	typedef IVsExtensibility3 Interface;

	STDMETHOD(GetProperties)(
		/*[in]*/ IUnknown* /*pParent*/,
		/*[in]*/ IDispatch* /*pdispPropObj*/,
		/*[out]*/ IDispatch** /*ppProperties*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RunWizardFile)(
		/*[in]*/ BSTR /*bstrWizFilename*/,
		/*[in]*/ long /*hwndOwner*/,
		/*[in]*/ SAFEARRAY** /*vContextParams*/,
		/*[out,retval]*/ long* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnterAutomationFunction)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExitAutomationFunction)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsInAutomationFunction)(
		/*[out,retval]*/ BOOL* /*pfInAutoFunc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUserControl)(
		/*[out]*/ VARIANT_BOOL* /*fUserControl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUserControl)(
		/*[in]*/ VARIANT_BOOL /*fUserControl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUserControlUnlatched)(
		/*[in]*/ VARIANT_BOOL /*fUserControl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockServer)(
		/*[in]*/ VARIANT_BOOL /*param1*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLockCount)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TestForShutdown)(
		/*[out,retval]*/ VARIANT_BOOL* /*fShutdown*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGlobalsObject)(
		/*[in]*/ VARIANT /*ExtractFrom*/,
		/*[out,retval]*/ IUnknown** /*ppGlobals*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetConfigMgr)(
		/*[in]*/ IUnknown* /*pIVsProject*/,
		/*[in]*/ DWORD_PTR /*itemid*/,
		/*[out,retval]*/ IUnknown** /*ppCfgMgr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireMacroReset)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentFromDocCookie)(
		/*[in]*/ LONG_PTR /*lDocCookie*/,
		/*[out,retval]*/ IUnknown** /*ppDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsMethodDisabled)(
		/*[in]*/ const GUID* /*pGUID*/,
		/*[in]*/ long /*dispid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSuppressUI)(
		/*[in]*/ VARIANT_BOOL /*In*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSuppressUI)(
		/*[in,out]*/ VARIANT_BOOL* /*pOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectsEvent_ItemAdded)(
		/*[in]*/ IUnknown* /*Project*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectsEvent_ItemRemoved)(
		/*[in]*/ IUnknown* /*Project*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectsEvent_ItemRenamed)(
		/*[in]*/ IUnknown* /*Project*/,
		/*[in]*/ BSTR /*OldName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectItemsEvent_ItemAdded)(
		/*[in]*/ IUnknown* /*ProjectItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectItemsEvent_ItemRemoved)(
		/*[in]*/ IUnknown* /*ProjectItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireProjectItemsEvent_ItemRenamed)(
		/*[in]*/ IUnknown* /*ProjectItem*/,
		/*[in]*/ BSTR /*OldName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsFireCodeModelEventNeeded)(
		/*[in,out]*/ VARIANT_BOOL* /*vbNeeded*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RunWizardFileEx)(
		/*[in]*/ BSTR /*bstrWizFilename*/,
		/*[in]*/ long /*hwndOwner*/,
		/*[in]*/ SAFEARRAY** /*vContextParams*/,
		/*[in]*/ SAFEARRAY** /*vCustomParams*/,
		/*[out,retval]*/ long* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FireCodeModelEvent3)(
		/*[in]*/ DISPID /*dispid*/,
		/*[in]*/ IDispatch* /*pParent*/,
		/*[in]*/ IUnknown* /*pElement*/,
		/*[in]*/ long /*changeKind*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExtensibility3MockImpl :
	public IVsExtensibility3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExtensibility3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExtensibility3MockImpl)

	typedef IVsExtensibility3 Interface;
	struct GetPropertiesValidValues
	{
		/*[in]*/ IUnknown* pParent;
		/*[in]*/ IDispatch* pdispPropObj;
		/*[out]*/ IDispatch** ppProperties;
		HRESULT retValue;
	};

	STDMETHOD(GetProperties)(
		/*[in]*/ IUnknown* pParent,
		/*[in]*/ IDispatch* pdispPropObj,
		/*[out]*/ IDispatch** ppProperties)
	{
		VSL_DEFINE_MOCK_METHOD(GetProperties)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pParent);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pdispPropObj);

		VSL_SET_VALIDVALUE_INTERFACE(ppProperties);

		VSL_RETURN_VALIDVALUES();
	}
	struct RunWizardFileValidValues
	{
		/*[in]*/ BSTR bstrWizFilename;
		/*[in]*/ long hwndOwner;
		/*[in]*/ SAFEARRAY** vContextParams;
		/*[out,retval]*/ long* pResult;
		HRESULT retValue;
	};

	STDMETHOD(RunWizardFile)(
		/*[in]*/ BSTR bstrWizFilename,
		/*[in]*/ long hwndOwner,
		/*[in]*/ SAFEARRAY** vContextParams,
		/*[out,retval]*/ long* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(RunWizardFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrWizFilename);

		VSL_CHECK_VALIDVALUE(hwndOwner);

		VSL_CHECK_VALIDVALUE_POINTER(vContextParams);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnterAutomationFunctionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(EnterAutomationFunction)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(EnterAutomationFunction)

		VSL_RETURN_VALIDVALUES();
	}
	struct ExitAutomationFunctionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ExitAutomationFunction)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ExitAutomationFunction)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsInAutomationFunctionValidValues
	{
		/*[out,retval]*/ BOOL* pfInAutoFunc;
		HRESULT retValue;
	};

	STDMETHOD(IsInAutomationFunction)(
		/*[out,retval]*/ BOOL* pfInAutoFunc)
	{
		VSL_DEFINE_MOCK_METHOD(IsInAutomationFunction)

		VSL_SET_VALIDVALUE(pfInAutoFunc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUserControlValidValues
	{
		/*[out]*/ VARIANT_BOOL* fUserControl;
		HRESULT retValue;
	};

	STDMETHOD(GetUserControl)(
		/*[out]*/ VARIANT_BOOL* fUserControl)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserControl)

		VSL_SET_VALIDVALUE(fUserControl);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUserControlValidValues
	{
		/*[in]*/ VARIANT_BOOL fUserControl;
		HRESULT retValue;
	};

	STDMETHOD(SetUserControl)(
		/*[in]*/ VARIANT_BOOL fUserControl)
	{
		VSL_DEFINE_MOCK_METHOD(SetUserControl)

		VSL_CHECK_VALIDVALUE(fUserControl);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUserControlUnlatchedValidValues
	{
		/*[in]*/ VARIANT_BOOL fUserControl;
		HRESULT retValue;
	};

	STDMETHOD(SetUserControlUnlatched)(
		/*[in]*/ VARIANT_BOOL fUserControl)
	{
		VSL_DEFINE_MOCK_METHOD(SetUserControlUnlatched)

		VSL_CHECK_VALIDVALUE(fUserControl);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockServerValidValues
	{
		/*[in]*/ VARIANT_BOOL param1;
		HRESULT retValue;
	};

	STDMETHOD(LockServer)(
		/*[in]*/ VARIANT_BOOL param1)
	{
		VSL_DEFINE_MOCK_METHOD(LockServer)

		VSL_CHECK_VALIDVALUE(param1);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLockCountValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetLockCount)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetLockCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct TestForShutdownValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* fShutdown;
		HRESULT retValue;
	};

	STDMETHOD(TestForShutdown)(
		/*[out,retval]*/ VARIANT_BOOL* fShutdown)
	{
		VSL_DEFINE_MOCK_METHOD(TestForShutdown)

		VSL_SET_VALIDVALUE(fShutdown);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGlobalsObjectValidValues
	{
		/*[in]*/ VARIANT ExtractFrom;
		/*[out,retval]*/ IUnknown** ppGlobals;
		HRESULT retValue;
	};

	STDMETHOD(GetGlobalsObject)(
		/*[in]*/ VARIANT ExtractFrom,
		/*[out,retval]*/ IUnknown** ppGlobals)
	{
		VSL_DEFINE_MOCK_METHOD(GetGlobalsObject)

		VSL_CHECK_VALIDVALUE(ExtractFrom);

		VSL_SET_VALIDVALUE_INTERFACE(ppGlobals);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetConfigMgrValidValues
	{
		/*[in]*/ IUnknown* pIVsProject;
		/*[in]*/ DWORD_PTR itemid;
		/*[out,retval]*/ IUnknown** ppCfgMgr;
		HRESULT retValue;
	};

	STDMETHOD(GetConfigMgr)(
		/*[in]*/ IUnknown* pIVsProject,
		/*[in]*/ DWORD_PTR itemid,
		/*[out,retval]*/ IUnknown** ppCfgMgr)
	{
		VSL_DEFINE_MOCK_METHOD(GetConfigMgr)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsProject);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppCfgMgr);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireMacroResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(FireMacroReset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(FireMacroReset)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentFromDocCookieValidValues
	{
		/*[in]*/ LONG_PTR lDocCookie;
		/*[out,retval]*/ IUnknown** ppDoc;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentFromDocCookie)(
		/*[in]*/ LONG_PTR lDocCookie,
		/*[out,retval]*/ IUnknown** ppDoc)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentFromDocCookie)

		VSL_CHECK_VALIDVALUE(lDocCookie);

		VSL_SET_VALIDVALUE_INTERFACE(ppDoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsMethodDisabledValidValues
	{
		/*[in]*/ GUID* pGUID;
		/*[in]*/ long dispid;
		HRESULT retValue;
	};

	STDMETHOD(IsMethodDisabled)(
		/*[in]*/ const GUID* pGUID,
		/*[in]*/ long dispid)
	{
		VSL_DEFINE_MOCK_METHOD(IsMethodDisabled)

		VSL_CHECK_VALIDVALUE_POINTER(pGUID);

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSuppressUIValidValues
	{
		/*[in]*/ VARIANT_BOOL In;
		HRESULT retValue;
	};

	STDMETHOD(SetSuppressUI)(
		/*[in]*/ VARIANT_BOOL In)
	{
		VSL_DEFINE_MOCK_METHOD(SetSuppressUI)

		VSL_CHECK_VALIDVALUE(In);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSuppressUIValidValues
	{
		/*[in,out]*/ VARIANT_BOOL* pOut;
		HRESULT retValue;
	};

	STDMETHOD(GetSuppressUI)(
		/*[in,out]*/ VARIANT_BOOL* pOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetSuppressUI)

		VSL_SET_VALIDVALUE(pOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectsEvent_ItemAddedValidValues
	{
		/*[in]*/ IUnknown* Project;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectsEvent_ItemAdded)(
		/*[in]*/ IUnknown* Project)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectsEvent_ItemAdded)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(Project);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectsEvent_ItemRemovedValidValues
	{
		/*[in]*/ IUnknown* Project;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectsEvent_ItemRemoved)(
		/*[in]*/ IUnknown* Project)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectsEvent_ItemRemoved)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(Project);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectsEvent_ItemRenamedValidValues
	{
		/*[in]*/ IUnknown* Project;
		/*[in]*/ BSTR OldName;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectsEvent_ItemRenamed)(
		/*[in]*/ IUnknown* Project,
		/*[in]*/ BSTR OldName)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectsEvent_ItemRenamed)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(Project);

		VSL_CHECK_VALIDVALUE_BSTR(OldName);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectItemsEvent_ItemAddedValidValues
	{
		/*[in]*/ IUnknown* ProjectItem;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectItemsEvent_ItemAdded)(
		/*[in]*/ IUnknown* ProjectItem)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectItemsEvent_ItemAdded)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ProjectItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectItemsEvent_ItemRemovedValidValues
	{
		/*[in]*/ IUnknown* ProjectItem;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectItemsEvent_ItemRemoved)(
		/*[in]*/ IUnknown* ProjectItem)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectItemsEvent_ItemRemoved)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ProjectItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireProjectItemsEvent_ItemRenamedValidValues
	{
		/*[in]*/ IUnknown* ProjectItem;
		/*[in]*/ BSTR OldName;
		HRESULT retValue;
	};

	STDMETHOD(FireProjectItemsEvent_ItemRenamed)(
		/*[in]*/ IUnknown* ProjectItem,
		/*[in]*/ BSTR OldName)
	{
		VSL_DEFINE_MOCK_METHOD(FireProjectItemsEvent_ItemRenamed)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ProjectItem);

		VSL_CHECK_VALIDVALUE_BSTR(OldName);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsFireCodeModelEventNeededValidValues
	{
		/*[in,out]*/ VARIANT_BOOL* vbNeeded;
		HRESULT retValue;
	};

	STDMETHOD(IsFireCodeModelEventNeeded)(
		/*[in,out]*/ VARIANT_BOOL* vbNeeded)
	{
		VSL_DEFINE_MOCK_METHOD(IsFireCodeModelEventNeeded)

		VSL_SET_VALIDVALUE(vbNeeded);

		VSL_RETURN_VALIDVALUES();
	}
	struct RunWizardFileExValidValues
	{
		/*[in]*/ BSTR bstrWizFilename;
		/*[in]*/ long hwndOwner;
		/*[in]*/ SAFEARRAY** vContextParams;
		/*[in]*/ SAFEARRAY** vCustomParams;
		/*[out,retval]*/ long* pResult;
		HRESULT retValue;
	};

	STDMETHOD(RunWizardFileEx)(
		/*[in]*/ BSTR bstrWizFilename,
		/*[in]*/ long hwndOwner,
		/*[in]*/ SAFEARRAY** vContextParams,
		/*[in]*/ SAFEARRAY** vCustomParams,
		/*[out,retval]*/ long* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(RunWizardFileEx)

		VSL_CHECK_VALIDVALUE_BSTR(bstrWizFilename);

		VSL_CHECK_VALIDVALUE(hwndOwner);

		VSL_CHECK_VALIDVALUE_POINTER(vContextParams);

		VSL_CHECK_VALIDVALUE_POINTER(vCustomParams);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct FireCodeModelEvent3ValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[in]*/ IDispatch* pParent;
		/*[in]*/ IUnknown* pElement;
		/*[in]*/ long changeKind;
		HRESULT retValue;
	};

	STDMETHOD(FireCodeModelEvent3)(
		/*[in]*/ DISPID dispid,
		/*[in]*/ IDispatch* pParent,
		/*[in]*/ IUnknown* pElement,
		/*[in]*/ long changeKind)
	{
		VSL_DEFINE_MOCK_METHOD(FireCodeModelEvent3)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pParent);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pElement);

		VSL_CHECK_VALIDVALUE(changeKind);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXTENSIBILITY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
