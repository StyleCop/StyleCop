/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROFILESETTINGSFILEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROFILESETTINGSFILEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProfileSettingsFileInfoNotImpl :
	public IVsProfileSettingsFileInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsFileInfoNotImpl)

public:

	typedef IVsProfileSettingsFileInfo Interface;

	STDMETHOD(GetFilePath)(
		/*[out]*/ BSTR* /*pbstrFilePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFileLocation)(
		/*[out]*/ VSPROFILELOCATIONS* /*pfileLocation*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFriendlyName)(
		/*[out]*/ BSTR* /*pbstrFriendlyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* /*pbstrDescription*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSettingsForImport)(
		/*[out]*/ IVsProfileSettingsTree** /*ppSettingsTree*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProfileSettingsFileInfoMockImpl :
	public IVsProfileSettingsFileInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsFileInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProfileSettingsFileInfoMockImpl)

	typedef IVsProfileSettingsFileInfo Interface;
	struct GetFilePathValidValues
	{
		/*[out]*/ BSTR* pbstrFilePath;
		HRESULT retValue;
	};

	STDMETHOD(GetFilePath)(
		/*[out]*/ BSTR* pbstrFilePath)
	{
		VSL_DEFINE_MOCK_METHOD(GetFilePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrFilePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFileLocationValidValues
	{
		/*[out]*/ VSPROFILELOCATIONS* pfileLocation;
		HRESULT retValue;
	};

	STDMETHOD(GetFileLocation)(
		/*[out]*/ VSPROFILELOCATIONS* pfileLocation)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileLocation)

		VSL_SET_VALIDVALUE(pfileLocation);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFriendlyNameValidValues
	{
		/*[out]*/ BSTR* pbstrFriendlyName;
		HRESULT retValue;
	};

	STDMETHOD(GetFriendlyName)(
		/*[out]*/ BSTR* pbstrFriendlyName)
	{
		VSL_DEFINE_MOCK_METHOD(GetFriendlyName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFriendlyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDescriptionValidValues
	{
		/*[out]*/ BSTR* pbstrDescription;
		HRESULT retValue;
	};

	STDMETHOD(GetDescription)(
		/*[out]*/ BSTR* pbstrDescription)
	{
		VSL_DEFINE_MOCK_METHOD(GetDescription)

		VSL_SET_VALIDVALUE_BSTR(pbstrDescription);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSettingsForImportValidValues
	{
		/*[out]*/ IVsProfileSettingsTree** ppSettingsTree;
		HRESULT retValue;
	};

	STDMETHOD(GetSettingsForImport)(
		/*[out]*/ IVsProfileSettingsTree** ppSettingsTree)
	{
		VSL_DEFINE_MOCK_METHOD(GetSettingsForImport)

		VSL_SET_VALIDVALUE_INTERFACE(ppSettingsTree);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROFILESETTINGSFILEINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
