/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROFILESETTINGSFILECOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROFILESETTINGSFILECOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProfileSettingsFileCollectionNotImpl :
	public IVsProfileSettingsFileCollection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsFileCollectionNotImpl)

public:

	typedef IVsProfileSettingsFileCollection Interface;

	STDMETHOD(GetCount)(
		/*[out]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSettingsFile)(
		/*[in]*/ int /*index*/,
		/*[out]*/ IVsProfileSettingsFileInfo** /*ppFileInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddBrowseFile)(
		/*[in]*/ BSTR /*bstrFilePath*/,
		/*[out]*/ IVsProfileSettingsFileInfo** /*ppFileInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProfileSettingsFileCollectionMockImpl :
	public IVsProfileSettingsFileCollection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProfileSettingsFileCollectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProfileSettingsFileCollectionMockImpl)

	typedef IVsProfileSettingsFileCollection Interface;
	struct GetCountValidValues
	{
		/*[out]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetCount)(
		/*[out]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSettingsFileValidValues
	{
		/*[in]*/ int index;
		/*[out]*/ IVsProfileSettingsFileInfo** ppFileInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetSettingsFile)(
		/*[in]*/ int index,
		/*[out]*/ IVsProfileSettingsFileInfo** ppFileInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetSettingsFile)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(ppFileInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddBrowseFileValidValues
	{
		/*[in]*/ BSTR bstrFilePath;
		/*[out]*/ IVsProfileSettingsFileInfo** ppFileInfo;
		HRESULT retValue;
	};

	STDMETHOD(AddBrowseFile)(
		/*[in]*/ BSTR bstrFilePath,
		/*[out]*/ IVsProfileSettingsFileInfo** ppFileInfo)
	{
		VSL_DEFINE_MOCK_METHOD(AddBrowseFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFilePath);

		VSL_SET_VALIDVALUE_INTERFACE(ppFileInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROFILESETTINGSFILECOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
