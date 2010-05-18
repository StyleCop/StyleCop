/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEXTENDEDTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEXTENDEDTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IExtendedTypeLibNotImpl :
	public IExtendedTypeLib
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExtendedTypeLibNotImpl)

public:

	typedef IExtendedTypeLib Interface;

	STDMETHOD(CreateExtendedTypeLib)(
		/*[in]*/ LPCOLESTR /*lpstrCtrlLibFileName*/,
		/*[in]*/ LPCOLESTR /*lpstrLibNamePrepend*/,
		/*[in]*/ ITypeInfo* /*ptinfoExtender*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPCOLESTR /*lpstrDirectoryName*/,
		/*[out]*/ ITypeLib** /*pptLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddRefExtendedTypeLib)(
		/*[in]*/ LPCOLESTR /*lpstrCtrlLibFileName*/,
		/*[in]*/ LPCOLESTR /*lpstrLibNamePrepend*/,
		/*[in]*/ ITypeInfo* /*ptinfoExtender*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPCOLESTR /*lpstrDirectoryName*/,
		/*[out]*/ ITypeLib** /*pptLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddRefExtendedTypeLibOfClsid)(
		/*[in]*/ REFCLSID /*rclsidControl*/,
		/*[in]*/ LPCOLESTR /*lpstrLibNamePrepend*/,
		/*[in]*/ ITypeInfo* /*ptinfoExtender*/,
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPCOLESTR /*lpstrDirectoryName*/,
		/*[out]*/ ITypeInfo** /*pptinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetExtenderInfo)(
		/*[in]*/ LPCOLESTR /*lpstrDirectoryName*/,
		/*[in]*/ ITypeInfo* /*ptinfoExtender*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IExtendedTypeLibMockImpl :
	public IExtendedTypeLib,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExtendedTypeLibMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IExtendedTypeLibMockImpl)

	typedef IExtendedTypeLib Interface;
	struct CreateExtendedTypeLibValidValues
	{
		/*[in]*/ LPCOLESTR lpstrCtrlLibFileName;
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend;
		/*[in]*/ ITypeInfo* ptinfoExtender;
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPCOLESTR lpstrDirectoryName;
		/*[out]*/ ITypeLib** pptLib;
		HRESULT retValue;
	};

	STDMETHOD(CreateExtendedTypeLib)(
		/*[in]*/ LPCOLESTR lpstrCtrlLibFileName,
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend,
		/*[in]*/ ITypeInfo* ptinfoExtender,
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPCOLESTR lpstrDirectoryName,
		/*[out]*/ ITypeLib** pptLib)
	{
		VSL_DEFINE_MOCK_METHOD(CreateExtendedTypeLib)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrCtrlLibFileName);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrLibNamePrepend);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ptinfoExtender);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDirectoryName);

		VSL_SET_VALIDVALUE_INTERFACE(pptLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddRefExtendedTypeLibValidValues
	{
		/*[in]*/ LPCOLESTR lpstrCtrlLibFileName;
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend;
		/*[in]*/ ITypeInfo* ptinfoExtender;
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPCOLESTR lpstrDirectoryName;
		/*[out]*/ ITypeLib** pptLib;
		HRESULT retValue;
	};

	STDMETHOD(AddRefExtendedTypeLib)(
		/*[in]*/ LPCOLESTR lpstrCtrlLibFileName,
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend,
		/*[in]*/ ITypeInfo* ptinfoExtender,
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPCOLESTR lpstrDirectoryName,
		/*[out]*/ ITypeLib** pptLib)
	{
		VSL_DEFINE_MOCK_METHOD(AddRefExtendedTypeLib)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrCtrlLibFileName);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrLibNamePrepend);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ptinfoExtender);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDirectoryName);

		VSL_SET_VALIDVALUE_INTERFACE(pptLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddRefExtendedTypeLibOfClsidValidValues
	{
		/*[in]*/ REFCLSID rclsidControl;
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend;
		/*[in]*/ ITypeInfo* ptinfoExtender;
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPCOLESTR lpstrDirectoryName;
		/*[out]*/ ITypeInfo** pptinfo;
		HRESULT retValue;
	};

	STDMETHOD(AddRefExtendedTypeLibOfClsid)(
		/*[in]*/ REFCLSID rclsidControl,
		/*[in]*/ LPCOLESTR lpstrLibNamePrepend,
		/*[in]*/ ITypeInfo* ptinfoExtender,
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPCOLESTR lpstrDirectoryName,
		/*[out]*/ ITypeInfo** pptinfo)
	{
		VSL_DEFINE_MOCK_METHOD(AddRefExtendedTypeLibOfClsid)

		VSL_CHECK_VALIDVALUE(rclsidControl);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrLibNamePrepend);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ptinfoExtender);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDirectoryName);

		VSL_SET_VALIDVALUE_INTERFACE(pptinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetExtenderInfoValidValues
	{
		/*[in]*/ LPCOLESTR lpstrDirectoryName;
		/*[in]*/ ITypeInfo* ptinfoExtender;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(SetExtenderInfo)(
		/*[in]*/ LPCOLESTR lpstrDirectoryName,
		/*[in]*/ ITypeInfo* ptinfoExtender,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(SetExtenderInfo)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrDirectoryName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(ptinfoExtender);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEXTENDEDTYPELIB_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
