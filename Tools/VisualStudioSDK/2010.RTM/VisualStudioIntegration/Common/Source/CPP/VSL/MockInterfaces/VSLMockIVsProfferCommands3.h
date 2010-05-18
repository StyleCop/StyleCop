/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROFFERCOMMANDS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROFFERCOMMANDS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProfferCommands3NotImpl :
	public IVsProfferCommands3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfferCommands3NotImpl)

public:

	typedef IVsProfferCommands3 Interface;

	STDMETHOD(AddNamedCommand)(
		/*[in]*/ const GUID* /*pguidPackage*/,
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonical*/,
		/*[out]*/ DWORD* /*pdwCmdId*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameLocalized*/,
		/*[in,string]*/ const LPCOLESTR /*pszBtnText*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdTooltip*/,
		/*[in,string]*/ const LPCOLESTR /*pszSatelliteDLL*/,
		/*[in]*/ DWORD /*dwBitmapResourceId*/,
		/*[in]*/ DWORD /*dwBitmapImageIndex*/,
		/*[in]*/ DWORD /*dwCmdFlagsDefault*/,
		/*[in]*/ DWORD /*cUIContexts*/,
		/*[in,size_is(cUIContexts)]*/ const GUID* /*rgguidUIContexts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveNamedCommand)(
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonical*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameNamedCommand)(
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonical*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonicalNew*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameLocalizedNew*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddCommandBarControl)(
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonical*/,
		/*[in]*/ IDispatch* /*pCmdBarParent*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[in]*/ DWORD /*dwCmdType*/,
		/*[out]*/ IDispatch** /*ppCmdBarCtrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveCommandBarControl)(
		/*[in]*/ IDispatch* /*pCmdBarCtrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddCommandBar)(
		/*[in,string]*/ const LPCOLESTR /*pszCmdBarName*/,
		/*[in]*/ DWORD /*dwType*/,
		/*[in]*/ IDispatch* /*pCmdBarParent*/,
		/*[in]*/ DWORD /*dwIndex*/,
		/*[out]*/ IDispatch** /*ppCmdBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveCommandBar)(
		/*[in]*/ IDispatch* /*pCmdBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindCommandBar)(
		/*[in]*/ IUnknown* /*pToolbarSet*/,
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*dwMenuId*/,
		/*[out,retval]*/ IDispatch** /*ppdispCmdBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddNamedCommand2)(
		/*[in]*/ const GUID* /*pguidPackage*/,
		/*[in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameCanonical*/,
		/*[out]*/ DWORD* /*pdwCmdId*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdNameLocalized*/,
		/*[in,string]*/ const LPCOLESTR /*pszBtnText*/,
		/*[in,string]*/ const LPCOLESTR /*pszCmdTooltip*/,
		/*[in,string]*/ const LPCOLESTR /*pszSatelliteDLL*/,
		/*[in]*/ DWORD /*dwBitmapResourceId*/,
		/*[in]*/ DWORD /*dwBitmapImageIndex*/,
		/*[in]*/ DWORD /*dwCmdFlagsDefault*/,
		/*[in]*/ DWORD /*cUIContexts*/,
		/*[in,size_is(cUIContexts)]*/ const GUID* /*rgguidUIContexts*/,
		/*[in]*/ DWORD /*dwUIElementType*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProfferCommands3MockImpl :
	public IVsProfferCommands3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfferCommands3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProfferCommands3MockImpl)

	typedef IVsProfferCommands3 Interface;
	struct AddNamedCommandValidValues
	{
		/*[in]*/ GUID* pguidPackage;
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonical;
		/*[out]*/ DWORD* pdwCmdId;
		/*[in,string]*/ LPCOLESTR pszCmdNameLocalized;
		/*[in,string]*/ LPCOLESTR pszBtnText;
		/*[in,string]*/ LPCOLESTR pszCmdTooltip;
		/*[in,string]*/ LPCOLESTR pszSatelliteDLL;
		/*[in]*/ DWORD dwBitmapResourceId;
		/*[in]*/ DWORD dwBitmapImageIndex;
		/*[in]*/ DWORD dwCmdFlagsDefault;
		/*[in]*/ DWORD cUIContexts;
		/*[in,size_is(cUIContexts)]*/ GUID* rgguidUIContexts;
		HRESULT retValue;
	};

	STDMETHOD(AddNamedCommand)(
		/*[in]*/ const GUID* pguidPackage,
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonical,
		/*[out]*/ DWORD* pdwCmdId,
		/*[in,string]*/ const LPCOLESTR pszCmdNameLocalized,
		/*[in,string]*/ const LPCOLESTR pszBtnText,
		/*[in,string]*/ const LPCOLESTR pszCmdTooltip,
		/*[in,string]*/ const LPCOLESTR pszSatelliteDLL,
		/*[in]*/ DWORD dwBitmapResourceId,
		/*[in]*/ DWORD dwBitmapImageIndex,
		/*[in]*/ DWORD dwCmdFlagsDefault,
		/*[in]*/ DWORD cUIContexts,
		/*[in,size_is(cUIContexts)]*/ const GUID* rgguidUIContexts)
	{
		VSL_DEFINE_MOCK_METHOD(AddNamedCommand)

		VSL_CHECK_VALIDVALUE_POINTER(pguidPackage);

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonical);

		VSL_SET_VALIDVALUE(pdwCmdId);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameLocalized);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBtnText);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdTooltip);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSatelliteDLL);

		VSL_CHECK_VALIDVALUE(dwBitmapResourceId);

		VSL_CHECK_VALIDVALUE(dwBitmapImageIndex);

		VSL_CHECK_VALIDVALUE(dwCmdFlagsDefault);

		VSL_CHECK_VALIDVALUE(cUIContexts);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidUIContexts, cUIContexts*sizeof(rgguidUIContexts[0]), validValues.cUIContexts*sizeof(validValues.rgguidUIContexts[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveNamedCommandValidValues
	{
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonical;
		HRESULT retValue;
	};

	STDMETHOD(RemoveNamedCommand)(
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonical)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveNamedCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonical);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameNamedCommandValidValues
	{
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonical;
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonicalNew;
		/*[in,string]*/ LPCOLESTR pszCmdNameLocalizedNew;
		HRESULT retValue;
	};

	STDMETHOD(RenameNamedCommand)(
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonical,
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonicalNew,
		/*[in,string]*/ const LPCOLESTR pszCmdNameLocalizedNew)
	{
		VSL_DEFINE_MOCK_METHOD(RenameNamedCommand)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonical);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonicalNew);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameLocalizedNew);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddCommandBarControlValidValues
	{
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonical;
		/*[in]*/ IDispatch* pCmdBarParent;
		/*[in]*/ DWORD dwIndex;
		/*[in]*/ DWORD dwCmdType;
		/*[out]*/ IDispatch** ppCmdBarCtrl;
		HRESULT retValue;
	};

	STDMETHOD(AddCommandBarControl)(
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonical,
		/*[in]*/ IDispatch* pCmdBarParent,
		/*[in]*/ DWORD dwIndex,
		/*[in]*/ DWORD dwCmdType,
		/*[out]*/ IDispatch** ppCmdBarCtrl)
	{
		VSL_DEFINE_MOCK_METHOD(AddCommandBarControl)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonical);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdBarParent);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_CHECK_VALIDVALUE(dwCmdType);

		VSL_SET_VALIDVALUE_INTERFACE(ppCmdBarCtrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveCommandBarControlValidValues
	{
		/*[in]*/ IDispatch* pCmdBarCtrl;
		HRESULT retValue;
	};

	STDMETHOD(RemoveCommandBarControl)(
		/*[in]*/ IDispatch* pCmdBarCtrl)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveCommandBarControl)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdBarCtrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddCommandBarValidValues
	{
		/*[in,string]*/ LPCOLESTR pszCmdBarName;
		/*[in]*/ DWORD dwType;
		/*[in]*/ IDispatch* pCmdBarParent;
		/*[in]*/ DWORD dwIndex;
		/*[out]*/ IDispatch** ppCmdBar;
		HRESULT retValue;
	};

	STDMETHOD(AddCommandBar)(
		/*[in,string]*/ const LPCOLESTR pszCmdBarName,
		/*[in]*/ DWORD dwType,
		/*[in]*/ IDispatch* pCmdBarParent,
		/*[in]*/ DWORD dwIndex,
		/*[out]*/ IDispatch** ppCmdBar)
	{
		VSL_DEFINE_MOCK_METHOD(AddCommandBar)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdBarName);

		VSL_CHECK_VALIDVALUE(dwType);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdBarParent);

		VSL_CHECK_VALIDVALUE(dwIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppCmdBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveCommandBarValidValues
	{
		/*[in]*/ IDispatch* pCmdBar;
		HRESULT retValue;
	};

	STDMETHOD(RemoveCommandBar)(
		/*[in]*/ IDispatch* pCmdBar)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveCommandBar)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCmdBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindCommandBarValidValues
	{
		/*[in]*/ IUnknown* pToolbarSet;
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD dwMenuId;
		/*[out,retval]*/ IDispatch** ppdispCmdBar;
		HRESULT retValue;
	};

	STDMETHOD(FindCommandBar)(
		/*[in]*/ IUnknown* pToolbarSet,
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD dwMenuId,
		/*[out,retval]*/ IDispatch** ppdispCmdBar)
	{
		VSL_DEFINE_MOCK_METHOD(FindCommandBar)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pToolbarSet);

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(dwMenuId);

		VSL_SET_VALIDVALUE_INTERFACE(ppdispCmdBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddNamedCommand2ValidValues
	{
		/*[in]*/ GUID* pguidPackage;
		/*[in]*/ GUID* pguidCmdGroup;
		/*[in,string]*/ LPCOLESTR pszCmdNameCanonical;
		/*[out]*/ DWORD* pdwCmdId;
		/*[in,string]*/ LPCOLESTR pszCmdNameLocalized;
		/*[in,string]*/ LPCOLESTR pszBtnText;
		/*[in,string]*/ LPCOLESTR pszCmdTooltip;
		/*[in,string]*/ LPCOLESTR pszSatelliteDLL;
		/*[in]*/ DWORD dwBitmapResourceId;
		/*[in]*/ DWORD dwBitmapImageIndex;
		/*[in]*/ DWORD dwCmdFlagsDefault;
		/*[in]*/ DWORD cUIContexts;
		/*[in,size_is(cUIContexts)]*/ GUID* rgguidUIContexts;
		/*[in]*/ DWORD dwUIElementType;
		HRESULT retValue;
	};

	STDMETHOD(AddNamedCommand2)(
		/*[in]*/ const GUID* pguidPackage,
		/*[in]*/ const GUID* pguidCmdGroup,
		/*[in,string]*/ const LPCOLESTR pszCmdNameCanonical,
		/*[out]*/ DWORD* pdwCmdId,
		/*[in,string]*/ const LPCOLESTR pszCmdNameLocalized,
		/*[in,string]*/ const LPCOLESTR pszBtnText,
		/*[in,string]*/ const LPCOLESTR pszCmdTooltip,
		/*[in,string]*/ const LPCOLESTR pszSatelliteDLL,
		/*[in]*/ DWORD dwBitmapResourceId,
		/*[in]*/ DWORD dwBitmapImageIndex,
		/*[in]*/ DWORD dwCmdFlagsDefault,
		/*[in]*/ DWORD cUIContexts,
		/*[in,size_is(cUIContexts)]*/ const GUID* rgguidUIContexts,
		/*[in]*/ DWORD dwUIElementType)
	{
		VSL_DEFINE_MOCK_METHOD(AddNamedCommand2)

		VSL_CHECK_VALIDVALUE_POINTER(pguidPackage);

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameCanonical);

		VSL_SET_VALIDVALUE(pdwCmdId);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdNameLocalized);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBtnText);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCmdTooltip);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSatelliteDLL);

		VSL_CHECK_VALIDVALUE(dwBitmapResourceId);

		VSL_CHECK_VALIDVALUE(dwBitmapImageIndex);

		VSL_CHECK_VALIDVALUE(dwCmdFlagsDefault);

		VSL_CHECK_VALIDVALUE(cUIContexts);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidUIContexts, cUIContexts*sizeof(rgguidUIContexts[0]), validValues.cUIContexts*sizeof(validValues.rgguidUIContexts[0]));

		VSL_CHECK_VALIDVALUE(dwUIElementType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROFFERCOMMANDS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
